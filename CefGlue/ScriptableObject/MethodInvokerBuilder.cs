namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using Core;
    using Diagnostics;
    using Emit;

    internal unsafe delegate void MethodInvoker(object obj, int argumentsCount, cef_v8value_t** arguments, cef_v8value_t** retval);

    internal class MethodInvokerBuilder
    {
        /// <summary>
        /// Forces a return V8.Undefined for void return type.
        /// If CEF issue #329 (http://code.google.com/p/chromiumembedded/issues/detail?id=329) 
        /// will be fixed then this value must be false.
        /// </summary>
        private static readonly bool ForceVoidToUndefined = false;

        private const int objArgIndex = 0;
        private const int argumentsCountArgIndex = 1;
        private const int argumentsArgIndex = 2;
        private const int retvalArgIndex = 3;

        public static MethodInvoker Create(MethodDef methodDef)
        {
            return new MethodInvokerBuilder(methodDef).Create();
        }

        private static readonly MethodInfo createUndefinedNativeV8ValueMethod;
        private static readonly MethodInfo throwArgumentCountMismatchMethod;

        static unsafe MethodInvokerBuilder()
        {
            createUndefinedNativeV8ValueMethod = new MethodInvokerHelper.CreateUndefinedNativeV8Value(libcef.v8value_create_undefined).Method;
            throwArgumentCountMismatchMethod = new Action(MethodInvokerHelper.ThrowArgumentCountMismatch).Method;
        }

        private readonly MethodDef def;

        private MethodInvokerBuilder(MethodDef methodDef)
        {
            this.def = methodDef;
        }

        public MethodInvoker Create()
        {
            #if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.ScriptableObject, "Creating method [{0}]", GetMethodInvokerName(this.def));
            #endif

            // Passing method arguments by ref is not supported.
            if (this.def.GetMethods().Any(_ => _.GetParameters().Any(p => p.ParameterType.IsByRef)))
            {
                throw new ScriptableObjectException("Passing method arguments by ref is not supported.");
            }

            // Mixing static and instance methods are not supported.
            if (this.def.GetMethods().All(_ => _.IsStatic)
                == this.def.GetMethods().All(_ => !_.IsStatic)
                )
            {
                throw new ScriptableObjectException("Mixing static and instance methods are not supported.");
            }

            var methodInvoker = typeof(MethodInvoker).GetMethod("Invoke");
            var emit = new DynamicMethodHelper(
                GetMethodInvokerName(def),
                methodInvoker.ReturnType,
                methodInvoker.GetParameters().Select(_ => _.ParameterType).ToArray()
                )
                .Emitter;

            if (!this.def.HasOverloads)
            {
                EmitInvoker(emit,
                    this.def.GetMethods().Single(),
                    this.def.Setter
                    );
            }
            else
            {
                var methodsByArgc = this.def.GetMethods()
                    .GroupBy(_ => _.GetParameters().Length, _ => _)
                    .ToDictionary(_ => _.Key, _ => _.ToArray())
                    ;

                if (methodsByArgc.Values.Any(_ => _.Length > 1))
                {
                    throw new ScriptableObjectException("Overloading by argument type variance currently is not supported.");
                }

                // TODO: check, optimize type variance or throw if not supported

                throw new NotSupportedException("Overloads currently is not supported.");
            }

            return (MethodInvoker)emit.DynamicMethod.CreateDelegate(typeof(MethodInvoker));
        }

        private static void EmitInvoker(EmitHelper emit, MethodInfo method, bool setter)
        {
            EmitThrowIfArgumentCountMismatch(emit, method.GetParameters().Length);

            emit.LdArg(retvalArgIndex);

            // instance method
            if (!method.IsStatic)
            {
                emit.LdArg(objArgIndex);
            }

            // prepare arguments
            var targetParamters = method.GetParameters();
            for (var i = 0; i < targetParamters.Length; i++)
            {
                var parameter = targetParamters[i];

                var changeTypeMethod = CefConvert.GetChangeTypeMethod(typeof(cef_v8value_t*), parameter.ParameterType);

                EmitLdV8Argument(emit, i);
                emit.Call(changeTypeMethod);
            }

            // call target method
            if (method.IsStatic)
            {
                emit.Call(method);
            }
            else
            {
                emit.CallVirt(method);
            }


            if (method.ReturnType == typeof(void))
            {
                // If method is setter, then it can be called with retval == null from V8Accessor.
                if (setter)
                {
                    var returnValueLabel = emit.DefineLabel();

                    emit.Dup()
                        .BrTrueS(returnValueLabel)
                        .Pop()
                        .Ret()
                        .MarkLabel(returnValueLabel);
                        ;
                }

                if (ForceVoidToUndefined)
                {
                    emit.Call(createUndefinedNativeV8ValueMethod);
                }
                else
                {
                    emit.LdNull();
                }
            }
            else
            {
                // convert return value
                var retValchangeTypeMethod = CefConvert.GetChangeTypeMethod(method.ReturnType, typeof(cef_v8value_t*));
                emit.Call(retValchangeTypeMethod);
            }

            // store result at retval
            emit.StIndI();

            // return
            emit.Ret();
        }

        private static void EmitThrowIfArgumentCountMismatch(EmitHelper emit, int expectedArgumentCount)
        {
            var doneLabel = emit.DefineLabel();

            emit.LdArg(argumentsCountArgIndex)
                .LdConstI4(expectedArgumentCount)
                .BeqS(doneLabel)
                .Call(throwArgumentCountMismatchMethod)
                .MarkLabel(doneLabel)
                ;
        }

        private static void EmitLdV8Argument(EmitHelper emit, int index)
        {
            if (index < 0) throw new ArgumentException("index");

            emit.LdArg(argumentsArgIndex);
            if (index > 0)
            {
                emit.LdConstI4(index * IntPtr.Size)
                    .Add();
            }
            emit.LdIndI();
        }

        private static string GetMethodInvokerName(MethodDef method, bool includeClassName = true)
        {
            if (includeClassName)
            {
                return string.Format("MethodInvoker:[{0}].{1}",
                    method.GetMethods().First().ReflectedType.FullName,
                    method.Name
                    );
            }
            else
            {
                return string.Format("MethodInvoker:[].{0}",
                    method.Name
                    );
            }
        }
    }
}
