# Copyright (c) 2011 The Chromium Embedded Framework Authors. All rights
# reserved. Use of this source code is governed by a BSD-style license that
# can be found in the LICENSE file.

from cef_parser import *

def is_handler_class(cls):
    name = cls.get_capi_name();
    return (re.match(".*handler_.*", name) != None 
            or re.match(".*_listener_.*", name) != None 
            or re.match(".*_filter_.*", name) != None 
            or name == "cef_client_t"
            or name == "cef_v8accessor_t"
            or name == "cef_task_t"
            or re.match(".*visitor_t", name) != None
            );

def make_cefglue_handler(cls, cefgluedir):
    dir = cefgluedir + "/Handler";

    filename = cls.get_cefglue_name() + ".tt";
    result = """<#@ template language="C#" hostspecific="false" debug="false" #>
<#@ output extension=".g.cs" #>
<#@ include file="Handler.ttinclude" #><#
    var def = new HandlerDef()
    {
        ClassName = """ + '"' + cls.get_cefglue_name() + '"' + """,
        StructName = """ + '"' + cls.get_capi_name() + '"' + """,
    };
""";

    funcs = cls.get_virtual_funcs();
    for func in funcs:
        result += """\n    def.AddProperty(""" + '"' + func.get_capi_name() + '"' + """);""";

    result += """

    WriteHandler(def);
#>""";

    write_cefglue_file(dir, filename, result);


    filename = cls.get_cefglue_name() + ".Impl.cs";
    result = """namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class """ + cls.get_cefglue_name() + """
    {
""";

    indent = "        ";


    # static functions (actual handlers doesn't have static functions)
    funcs = cls.get_static_funcs()
    for func in funcs:
        parts = func.get_cefglue_parts();
        result += format_comment_cefglue(func.get_comment(), indent)
        result += indent + '/* FIXME: ' + cls.get_cefglue_name() + '.' + func.get_name() + ' public */\n'
        result += indent + 'static ' + parts['retval'] + ' ' + func.get_name() + '(' + string.join(parts['args'], ', ') + ')\n';
        result += indent + '{\n';
        result += indent + '    // TODO: ' + cls.get_cefglue_name() + '.' + func.get_name() + '\n';
        result += indent + '    ' + 'throw new NotImplementedException();\n';
        result += indent + '}\n';
        result += '\n'


    funcs = cls.get_virtual_funcs();
    for func in funcs:
        parts = func.get_cefglue_parts();
        result += format_comment_cefglue(func.get_comment(), indent)
        result += indent + 'private ' + parts['retval'] + ' ' + parts['name'] + '(' + string.join(parts['args'], ', ') + ')\n';
        result += indent + '{\n';
        result += indent + '    ThrowIfObjectDisposed();\n';
        result += indent + '    // TODO: ' + cls.get_cefglue_name() + '.' + parts['name'] + '\n';
        result += indent + '    ' + 'throw new NotImplementedException();\n';
        result += indent + '}\n';
        result += '\n'

    result += """
    }
}
""";

    write_cefglue_file(dir, filename, result);

    return

def make_cefglue_proxy(cls, cefgluedir):
    dir = cefgluedir + "/Proxy";

    filename = cls.get_cefglue_name() + ".tt";
    result = """<#@ template language="C#" hostspecific="false" debug="false" #>
<#@ output extension=".g.cs" #>
<#@ include file="Proxy.ttinclude" #><#
    var def = new ProxyDef()
    {
        ClassName = """ + '"' + cls.get_cefglue_name() + '"' + """,
        StructName = """ + '"' + cls.get_capi_name() + '"' + """,
    };
""";

    funcs = cls.get_virtual_funcs();
    for func in funcs:
        result += """\n    def.AddMethod(""" + '"' + func.get_capi_name() + '"' + """);""";

    result += """

    WriteProxy(def);
#>""";
    write_cefglue_file(dir, filename, result);



    filename = cls.get_cefglue_name() + ".Impl.cs";
    result = """namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class """ + cls.get_cefglue_name() + """
    {
""";

    indent = "        ";

    # static functions
    funcs = cls.get_static_funcs()
    for func in funcs:
        parts = func.get_cefglue_parts();
        result += format_comment_cefglue(func.get_comment(), indent)
        result += indent + '/* FIXME: ' + cls.get_cefglue_name() + '.' + func.get_name() + ' public */\n'
        result += indent + 'static ' + parts['retval'] + ' ' + func.get_name() + '(' + string.join(parts['args'], ', ') + ')\n';
        result += indent + '{\n';
        result += indent + '    // TODO: ' + cls.get_cefglue_name() + '.' + func.get_name() + '\n';
        result += indent + '    ' + 'throw new NotImplementedException();\n';
        result += indent + '}\n';
        result += '\n'


    funcs = cls.get_virtual_funcs();
    for func in funcs:
        parts = func.get_cefglue_parts();
        result += format_comment_cefglue(func.get_comment(), indent)

        #sys.stdout.write( format_comment_cefglue(func.get_comment(), indent) )
        #if 'CefV8Value.HasValue' == (cls.get_cefglue_name() + '.' + func.get_name()):
        #    sys.stdout.write( format_comment_cefglue(func.get_comment(), indent) )

        result += indent + '/* FIXME: ' + cls.get_cefglue_name() + '.' + func.get_name() + ' public */\n'
        result += indent + parts['retval'] + ' ' + func.get_name() + '(' + string.join(parts['args'][1:], ', ') + ')\n';
        result += indent + '{\n';
        result += indent + '    // TODO: ' + cls.get_cefglue_name() + '.' + func.get_name() + '\n';
        result += indent + '    ' + 'throw new NotImplementedException();\n';
        result += indent + '}\n';
        result += '\n'

    result += """
    }
}
""";

    write_cefglue_file(dir, filename, result);

    return

def make_cefglue_structlayout():
	result = '[StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]'
	return result

def make_cefglue_unmanaged_function_pointer():
	result = '[UnmanagedFunctionPointer(libcef.Callback), SuppressUnmanagedCodeSecurity]'
	return result

def make_struct_decl():
	result = 'internal unsafe partial struct'
	return result

def make_nativemethods_decl():
	result = 'internal static unsafe partial class libcef'
	return result

def format_comment_cefglue(comment, indent, translate_map = None, maxchars = 80):
	result = format_comment(comment, indent, translate_map, maxchars)
	result = string.replace(result, "&", "&amp;");
	result = string.replace(result, "<", "&lt;");
	result = string.replace(result, ">", "&gt;");
	result = string.replace(result, "// ", "{=__cefglue_placeholder_1}")
	result = string.replace(result, "///\n", "/// <summary>\n", 1)
	result = string.replace(result, "///\n", "/// </summary>\n", 1)
	result = string.replace(result, "{=__cefglue_placeholder_1}", "/// ")
	return result

def make_cefglue_global_funcs(funcs, defined_names, translate_map, indent):
    result = ''
    first = True
    for func in funcs:
        comment = func.get_comment()
        if first or len(comment) > 0:
            result += '\n'+format_comment_cefglue(comment, indent, translate_map);
        if func.get_retval().get_type().is_result_string():
            result += indent + '/// <remarks>\n' + indent + '/// The resulting string must be freed by calling cef_string_userfree_free().\n' + indent + '/// </remarks>\n'

        parts = func.get_cefglue_parts()
        result += indent + "[DllImport(DllName, EntryPoint = \"" + parts['name'] + "\", CallingConvention = Call)]\n";
        result += indent + "public static extern " + func.get_cefglue_proto(defined_names) + ";\n"

        #result += wrap_code(indent+'CEF_EXPORT '+
        #                    func.get_capi_proto(defined_names)+';')

        if first:
            first = False
    return result

def make_cefglue_member_funcs(funcs, defined_names, translate_map, indent):
    result = ''
    first = True
    for func in funcs:
        comment = func.get_comment()

        if first or len(comment) > 0:
            result += '\n' + format_comment_cefglue(comment, indent, translate_map)

        if func.get_retval().get_type().is_result_string():
            result += indent + '/// <remarks>\n' + indent + '/// The resulting string must be freed by calling cef_string_userfree_free().\n' + indent + '/// </remarks>\n'

        parts = func.get_cefglue_parts()
        result += indent + 'public IntPtr ' + parts['name'] + ';\n'

        result += indent + make_cefglue_unmanaged_function_pointer() + '\n'
        result += indent + 'public delegate ' + parts['retval'] + ' ' + parts['name'] + '_delegate' + \
                  '(' + string.join(parts['args'], ', ') + ');\n'

        #result += wrap_code(indent+parts['retval']+' (CEF_CALLBACK *'+
        #                    parts['name']+')('+
        #                    string.join(parts['args'], ', ')+');')

        if first:
            first = False
    return result

def make_cefglue(header, cefgluedir):
    # structure names that have already been defined
    defined_names = header.get_defined_structs()
    
    # map of strings that will be changed in C++ comments
    translate_map = header.get_capi_translations()
    
    # header string
    result = \
"""//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

#if !DEBUG
    [SuppressUnmanagedCodeSecurity]
#endif
    """ + make_nativemethods_decl() + """
    {
        internal const int StructPack = 0;
        internal const CallingConvention Call = CallingConvention.Cdecl;
        internal const CallingConvention Callback = CallingConvention.StdCall;
        internal const string DllName = "libcef.dll";

"""

    # output global functions
    result += make_cefglue_global_funcs(header.get_funcs(), defined_names,
                                     translate_map, '        ')

    result += \
"""
    }

"""	
   
    # output classes
    classes = header.get_classes()
    for cls in classes:
        # virtual functions are inside the structure
        classname = cls.get_capi_name()
        result += '\n' + format_comment_cefglue(cls.get_comment(), '    ', translate_map);
        result += '    ' + make_cefglue_structlayout() + '\n'
        result += '    ' + make_struct_decl() + ' ' + classname + \
                  '\n    {\n        /// <summary>\n        /// Base structure.\n        /// </summary>\n        public cef_base_t @base;\n'
        funcs = cls.get_virtual_funcs()
        result += make_cefglue_member_funcs(funcs, defined_names,
                                         translate_map, '        ')
        result += '\n    };\n\n'
        
        defined_names.append(cls.get_capi_name())
        
        # static functions become global
        funcs = cls.get_static_funcs()
        if len(funcs) > 0:
            result += '    ' + make_nativemethods_decl() + '\n'
            result += '    ' + '{\n'
            result += make_cefglue_global_funcs(funcs, defined_names,
                                             translate_map, '        ')+'\n'
            result += '    ' + '}\n'
    
    # footer string
    result += \
"""
}

"""

    for cls in classes:
        if is_handler_class(cls):
            make_cefglue_handler(cls, cefgluedir)
        else:
            make_cefglue_proxy(cls, cefgluedir)
    
    return result


def write_cefglue(header, file, backup, cefgluedir):
    if file_exists(file):
        oldcontents = read_file(file)
    else:
        oldcontents = ''
    
    newcontents = make_cefglue(header, cefgluedir)
    if newcontents != oldcontents:
        if backup and oldcontents != '':
            backup_file(file)
        write_file(file, newcontents)
        return True
    
    return False

def write_cefglue_file(dir, file, contents):
    if not os.path.isdir(dir):
        os.makedirs(dir);

    #sys.stdout.write(file + "... ");
    file = dir + "/" + file;

    if file_exists(file):
        oldcontents = read_file(file)
    else:
        oldcontents = ''
        
    if contents != oldcontents:
        write_file(file, contents)
        #sys.stdout.write("updated.\n");
        return True
    
    #sys.stdout.write("up-to-date.\n");
    return False


# test the module
if __name__ == "__main__":
    import sys
    
    # verify that the correct number of command-line arguments are provided
    if len(sys.argv) < 2:
        sys.stderr.write('Usage: '+sys.argv[0]+' <infile>')
        sys.exit()
        
    # create the header object
    header = obj_header(sys.argv[1])
    
    # dump the result to stdout
    sys.stdout.write(make_cefglue_header(header))
