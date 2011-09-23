#if DIAGNOSTICS
namespace CefGlue.Diagnostics
{
    using System;

    public enum LogTarget
    {
        Default = 0,

        ObjectCt,

        //
        CefUserData,

        // 
        CefString,

        // Handlers
        CefClient,
        CefContentFilter,
        CefCookieVisitor,
        CefDisplayHandler,
        CefDomEventListener,
        CefDomVisitor,
        CefDownloadHandler,
        CefFindHandler,
        CefFocusHandler,
        CefJSBindingHandler,
        CefJSDialogHandler,
        CefKeyboardHandler,
        CefLifeSpanHandler,
        CefLoadHandler,
        CefMenuHandler,
        CefPrintHandler,
        CefReadHandler,
        CefRenderHandler,
        CefRequestHandler,
        CefSchemeHandler,
        CefSchemeHandlerFactory,
        CefTask,
        CefV8Accessor,
        CefV8Handler,
        CefWriteHandler,

        // Proxies
        CefBrowser,
        CefDomDocument,
        CefDomEvent,
        CefDomNode,
        CefFrame,
        CefPostData,
        CefPostDataElement,
        CefRequest,
        CefResponse,
        CefStreamReader,
        CefStreamWriter,
        CefV8Context,
        CefV8Value,
        CefWebUrlRequest,
        CefWebUrlRequestClient,
        CefXmlReader,
        CefZipReader,
    }
}
#endif
