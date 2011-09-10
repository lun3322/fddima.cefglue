namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using Core;

    internal unsafe delegate void InvokeMethod(object obj, int argumentsCount, cef_v8value_t** arguments, cef_v8value_t** retval);

    internal class InvokeMethodBuilder
    {
        /// <summary>
        /// Forces a return V8.Undefined for void return type.
        /// If CEF issue #329 (http://code.google.com/p/chromiumembedded/issues/detail?id=329) 
        /// will be fixed then this value must be false.
        /// </summary>
        private static readonly bool ForceVoidToUndefined = true;

        public static InvokeMethod Create(MethodDef methodDef, MethodInfo method)
        {
            return new InvokeMethodBuilder(methodDef, method).Create();
        }

        private static readonly MethodInfo createUndefinedNativeV8ValueMethod;
        private static readonly MethodInfo throwArgumentCountMismatchMethod;

        static unsafe InvokeMethodBuilder()
        {
            createUndefinedNativeV8ValueMethod = new InvokeMethodHelper.CreateUndefinedNativeV8Value(libcef.v8value_create_undefined).Method;
            throwArgumentCountMismatchMethod = new Action(InvokeMethodHelper.ThrowArgumentCountMismatch).Method;
        }

        private readonly MethodDef methodDef;
        private readonly MethodInfo method;

        private readonly DynamicMethod dynamicMethod;
        private readonly ILGenerator il;

        private InvokeMethodBuilder(MethodDef methodDef, MethodInfo method)
        {
            this.methodDef = methodDef;
            this.method = method;

            var invokeCoreMethod = typeof(InvokeMethod).GetMethod("Invoke");

            // TODO: generate dynamic method name for debugging ?

            this.dynamicMethod = new DynamicMethod(
                "InvokeCore_" + method.Name,
                invokeCoreMethod.ReturnType,
                invokeCoreMethod.GetParameters().Select(_ => _.ParameterType).ToArray(),
                // new Type[] { typeof(object), typeof(int), typeof(cef_v8value_t**), typeof(cef_v8value_t**) },
                this.GetType(),
                true
                );

            this.il = dynamicMethod.GetILGenerator();
        }

        public InvokeMethod Create()
        {
            // TODO: we also must check praramter types for generating right code
            // for examples values can't be passed via ref/out...

            EmitCheckArgumentCount();

            EmitLdRetVal();

            // instance
            if (!method.IsStatic)
            {
                EmitLdInstance();
            }

            // prepare arguments
            var targetParamters = this.method.GetParameters();
            for (var i = 0; i < targetParamters.Length; i++)
            {
                var parameter = targetParamters[i];

                var changeTypeMethod = CefConvert.GetChangeTypeMethod(typeof(cef_v8value_t*), parameter.ParameterType);

                EmitGetArgument(i);
                il.EmitCall(OpCodes.Call, changeTypeMethod, null);
            }

            // call target method
            il.EmitCall(method.IsStatic ? OpCodes.Call : OpCodes.Callvirt, this.method, null);


            if (method.ReturnType == typeof(void))
            {
                // If method is setter, then it can be called with retval == null from V8Accessor.
                if (this.methodDef.Setter)
                {
                    var returnValueLabel = il.DefineLabel();

                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Brtrue_S, returnValueLabel);

                    il.Emit(OpCodes.Pop);
                    il.Emit(OpCodes.Ret);

                    il.MarkLabel(returnValueLabel);
                }

                if (ForceVoidToUndefined)
                {
                    il.EmitCall(OpCodes.Call, createUndefinedNativeV8ValueMethod, null);
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                }
            }
            else
            {
                // convert return value
                var retValchangeTypeMethod = CefConvert.GetChangeTypeMethod(method.ReturnType, typeof(cef_v8value_t*));
                il.EmitCall(OpCodes.Call, retValchangeTypeMethod, null);
            }

            // store result at retval
            il.Emit(OpCodes.Stind_I);

            // return
            il.Emit(OpCodes.Ret);

            return (InvokeMethod)this.dynamicMethod.CreateDelegate(typeof(InvokeMethod));
        }

        private void EmitLdInstance()
        {
            this.il.Emit(OpCodes.Ldarg_0);
        }

        private void EmitLdArgumentsCount()
        {
            this.il.Emit(OpCodes.Ldarg_1);
        }

        private void EmitLdArguments()
        {
            this.il.Emit(OpCodes.Ldarg_2);
        }

        private void EmitLdRetVal()
        {
            this.il.Emit(OpCodes.Ldarg_3);
        }

        private void EmitGetArgument(int index)
        {
            if (index < 0) throw new ArgumentException("index");

            EmitLdArguments();
            if (index > 0)
            {
                EmitLdConstI4(index * IntPtr.Size);
                il.Emit(OpCodes.Add);
            }
            il.Emit(OpCodes.Ldind_I);
        }

        private void EmitCheckArgumentCount()
        {
            var doneLabel = il.DefineLabel();

            EmitLdArgumentsCount();
            EmitLdConstI4(this.method.GetParameters().Length);
            il.Emit(OpCodes.Beq_S, doneLabel);
            il.EmitCall(OpCodes.Call, throwArgumentCountMismatchMethod, null);

            il.MarkLabel(doneLabel);
        }

        private void EmitLdConstI4(int value)
        {
            switch (value)
            {
                case -1: il.Emit(OpCodes.Ldc_I4_M1); return;
                case 0: il.Emit(OpCodes.Ldc_I4_0); return;
                case 1: il.Emit(OpCodes.Ldc_I4_1); return;
                case 2: il.Emit(OpCodes.Ldc_I4_2); return;
                case 3: il.Emit(OpCodes.Ldc_I4_3); return;
                case 4: il.Emit(OpCodes.Ldc_I4_4); return;
                case 5: il.Emit(OpCodes.Ldc_I4_5); return;
                case 6: il.Emit(OpCodes.Ldc_I4_6); return;
                case 7: il.Emit(OpCodes.Ldc_I4_7); return;
                default:
                    if (value >= -128 && value <= 127)
                    {
                        il.Emit(OpCodes.Ldc_I4_S, value);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldc_I4, value);
                    }
                    return;
            }
        }
    }
}
