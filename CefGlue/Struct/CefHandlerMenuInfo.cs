﻿namespace CefGlue
{
    using System;
    using Core;

    /// <summary>
    /// Menu information.
    /// </summary>
    public sealed unsafe class CefHandlerMenuInfo : IDisposable
    {
        internal static CefHandlerMenuInfo From(cef_handler_menuinfo_t* ptr)
        {
            return new CefHandlerMenuInfo(ptr);
        }

        private cef_handler_menuinfo_t* ptr;
        private CefHandlerMenuInfo(cef_handler_menuinfo_t* ptr)
        {
            this.ptr = ptr;
        }

        ~CefHandlerMenuInfo()
        {
            this.ptr = null;
        }

        public void Dispose()
        {
            this.ptr = null;
        }

        public CefHandlerMenuTypeBits TypeFlags { get { return (CefHandlerMenuTypeBits)this.ptr->typeFlags; } }

        /// <summary>
        /// If window rendering is enabled value will be in screen coordinates.
        /// Otherwise, value will be in view coordinates.
        /// </summary>
        public int X { get { return this.ptr->x; } }

        /// <summary>
        /// If window rendering is enabled value will be in screen coordinates.
        /// Otherwise, value will be in view coordinates.
        /// </summary>
        public int Y { get { return this.ptr->y; } }

        public string LinkUrl { get { return cef_string_t.ToString(&this.ptr->linkUrl); } }
        public string ImageUrl { get { return cef_string_t.ToString(&this.ptr->imageUrl); } }
        public string PageUrl { get { return cef_string_t.ToString(&this.ptr->pageUrl); } }
        public string FrameUrl { get { return cef_string_t.ToString(&this.ptr->frameUrl); } }
        public string SelectionText { get { return cef_string_t.ToString(&this.ptr->selectionText); } }
        public string MisspelledWord { get { return cef_string_t.ToString(&this.ptr->misspelledWord); } }

        public CefHandlerMenuCapabilityBits EditFlags { get { return (CefHandlerMenuCapabilityBits)this.ptr->editFlags; } }

        public string SecurityInfo { get { return cef_string_t.ToString(&this.ptr->securityInfo); } }
    }
}
