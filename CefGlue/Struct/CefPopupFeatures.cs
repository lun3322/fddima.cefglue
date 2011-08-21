namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;

    public sealed unsafe class CefPopupFeatures : IDisposable
    {
        internal static CefPopupFeatures From(cef_popup_features_t* pointer)
        {
            return new CefPopupFeatures(pointer);
        }

        private cef_popup_features_t* _ptr;
        private bool _owner;

        public CefPopupFeatures()
        {
            _ptr = cef_popup_features_t.Alloc();
            _owner = true;
        }

        private CefPopupFeatures(cef_popup_features_t* pointer)
        {
            _ptr = pointer;
            _owner = false;
        }

        #region IDisposable
        ~CefPopupFeatures()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_ptr != null)
            {
                if (_owner)
                {
                    cef_popup_features_t.Free(_ptr);
                }
                _ptr = null;
            }
        }
        #endregion

        internal cef_popup_features_t* NativePointer
        {
            get
            {
                CheckNativePointer();
                return _ptr;
            }
        }

        private void CheckNativePointer()
        {
            if (_ptr == null) ThrowObjectDisposedException();
        }

        private void ThrowObjectDisposedException()
        {
            throw new ObjectDisposedException("{0} is disposed.", this.GetType().Name);
        }

        // ....

    }
}
