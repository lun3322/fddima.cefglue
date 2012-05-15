﻿#if DIAGNOSTICS
namespace CefGlue.Diagnostics
{
    using System;

    public enum LogTarget
    {
        Default = 0,

        CefString,
        ObjectCt,
        ScriptableObject,
        CefWebBrowser,
        CefUserData,

        // TODO: generate it from ProxySchema and HandlerSchema

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
        CefJSDialogHandler,
        CefKeyboardHandler,
        CefLifeSpanHandler,
        CefLoadHandler,
        CefMenuHandler,
        CefPermissionHandler,
        CefPrintHandler,
        CefProxyHandler,
        CefReadHandler,
        CefRenderHandler,
        CefRequestHandler,
        CefResourceBundleHandler,
        CefSchemeHandler,
        CefSchemeHandlerFactory,
        CefTask,
        CefV8Accessor,
        CefV8ContextHandler,
        CefV8Handler,
        CefWriteHandler,
        CefDragHandler,
        CefStorageVisitor,

        // Proxies
        CefApp,
        CefBrowser,
        CefCommandLine,
        CefCookieManager,
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
        CefV8Exception,
        CefV8Value,
        CefWebUrlRequest,
        CefWebUrlRequestClient,
        CefXmlReader,
        CefZipReader,
        CefDragData,
        CefSchemeHandlerCallback,
        CefWebPluginInfo
    }
}
#endif
