### CefGlue

CefGlue is a .NET CLR binding for [The Chromium Embedded Framework (CEF)](http://code.google.com/p/chromiumembedded) by Marshall A. Greenblatt.

This project is licensed under New BSD License.


### Documentation

Latest [on-line documentation](http://cefglue.dmitriid.com/doc/) available.


### Support

CefGlue support and related discussion is available on the [CefGlue discussion group](https://groups.google.com/forum/#!forum/cefglue).


### Version 0.4.7-cef-r306

Download [CefGlue-0.4.7-cef-r306.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.7-cef-r306.zip), [cef_binary_r306_windows.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r306_windows.zip)

- Ciritcal fix for unpredictable crashes on multiprocessor platforms.
- Fix CefStringMap implementation.


### Version 0.4.6-cef-r306

Download [CefGlue-0.4.6-cef-r306.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.6-cef-r306.zip), [cef_binary_r306_windows.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r306_windows.zip)

- Compatible with CEF R306.
- Executing JS scripts via IvokeScript method.
- Various CefWebBrowser improvements (IsLoading/IsLoadingChanged, KeyEvent, BeforeBrowse events). 


### Version 0.4.5-cef-r293

Download [CefGlue-0.4.5-cef-r293.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.5-cef-r293.zip), [cef_binary_r293_VS2008-VS2010.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r293_VS2008-VS2010.zip)

- Compatible with CEF R293, it contains many fixes about V8 stuff, including memory leak.


### Version 0.4.4-cef-r275

Download [CefGlue-0.4.4-cef-r275.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.4-cef-r275.zip), [cef_binary_r275_VS2008.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r275_VS2008.zip)

- Fixes for crashes on application exit (issue #42).
- Client now support command line (to run it in different modes like multithreaded/singlethreaded message loop, and different message loop workers, note, that only multithreaded message loop is official way).
- More simple types support for ScriptableObject.
- Fixes for debug builds.


### Version 0.4.3-cef-r275

Download [CefGlue-0.4.3-cef-r275.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.3-cef-r275.zip), [cef_binary_r275_VS2008.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r275_VS2008.zip)

- Initial version of ScriptableObject feature: this is allow to expose CLR objects to browser via V8 Extension or JS Binding.
- Interop code allow work with CEF objects without managed proxies (invoke_XXX methods).
- Some fixes.


### Version 0.4.2-cef-r275

Download [CefGlue-0.4.2-cef-r275.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.2-cef-r275.zip), [cef_binary_r275_VS2008.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r275_VS2008.zip)

- No more CefGlue.Core assembly exists.
- Caching delegates to native methods (speed up, decreases GC pressure).
- Fixed some kind of crashes and deadlocks.
- CefGlue.Cilent: implements custom scheme handler.
- CefGlue.Cilent: JavaScript Extension Tests: Dump & Performance
- CefGlue.Client: auto focus on browser control on load.
- CefV8Value API changes.
- Fix cef_string_userfree_t.


### Version 0.4.1-cef-r275

Download [CefGlue-0.4.1-cef-r275.zip](https://bitbucket.org/fddima/cefglue/downloads/CefGlue-0.4.1-cef-r275.zip), [cef_binary_r275_VS2008.zip](http://chromiumembedded.googlecode.com/files/cef_binary_r275_VS2008.zip)

- Implemented full set of CEF API.
- Provide simple windows forms browser control.
- Simple sample application.

