//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace CefGlue
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Core;
    using Diagnostics;

    public abstract unsafe partial class CefDownloadHandler 
    {
#if DIAGNOSTICS
        internal static int ObjectCt;
#endif

        private static ObjectTable<CefDownloadHandler> pointers = new ObjectTable<CefDownloadHandler>();



        private int refct;
        private cef_download_handler_t* ptr;
        private bool disposed;

        private cef_base_t.add_ref_delegate bs_add_ref;
        private cef_base_t.release_delegate bs_release;
        private cef_base_t.get_refct_delegate bs_get_refct;
        private cef_download_handler_t.received_data_delegate bs_received_data;
        private cef_download_handler_t.complete_delegate bs_complete;

        public CefDownloadHandler()
        {
            this.refct = 0;
            this.ptr = cef_download_handler_t.Alloc();
#if DIAGNOSTICS
			Interlocked.Increment(ref ObjectCt);
#endif

#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefDownloadHandler, this.ptr, LogOperation.Create);
#endif

            this.bs_add_ref = new cef_base_t.add_ref_delegate(this.add_ref);
            this.ptr->@base.add_ref = Marshal.GetFunctionPointerForDelegate(this.bs_add_ref);

            this.bs_release = new cef_base_t.release_delegate(this.release);
            this.ptr->@base.release = Marshal.GetFunctionPointerForDelegate(this.bs_release);

            this.bs_get_refct = new cef_base_t.get_refct_delegate(this.get_refct);
            this.ptr->@base.get_refct = Marshal.GetFunctionPointerForDelegate(this.bs_get_refct);

            this.bs_received_data = new cef_download_handler_t.received_data_delegate(this.received_data);
            this.ptr->received_data = Marshal.GetFunctionPointerForDelegate(this.bs_received_data);

            this.bs_complete = new cef_download_handler_t.complete_delegate(this.complete);
            this.ptr->complete = Marshal.GetFunctionPointerForDelegate(this.bs_complete);

        }

        ~CefDownloadHandler()
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefDownloadHandler, this.ptr, "~CefDownloadHandler");
#endif
			Dispose(false);
        }


		protected virtual void Dispose(bool disposing)
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefDownloadHandler, this.ptr, LogOperation.Dispose, "Disposing=[{0}]", disposing);
#endif

			this.disposed = true;

			if (this.ptr != null)
            {
#if DIAGNOSTICS
                Interlocked.Decrement(ref ObjectCt);
#endif
				cef_download_handler_t.Free(this.ptr);
                this.ptr = null;
			}

            if (disposing)
			{
			}
        }

        /// <summary>
        /// The AddRef method increments the reference count for the object.
		/// It should be called for every new copy of a pointer to a given object.
		/// The resulting reference count value is returned and should be used for diagnostic/testing purposes only.
        /// </summary>
        internal int AddRef()
        {
            var result = Interlocked.Increment(ref this.refct);
            #if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefDownloadHandler, this.ptr, LogOperation.AddRef, "{0}", result);
            #endif
			if (result == 1)
			{
				pointers.Add((IntPtr)ptr, this);
			}
            return result;
        }

        /// <summary>
        /// The Release method decrements the reference count for the object.
		/// If the reference count on the object falls to 0, then the object should free itself from memory.
		/// The resulting reference count value is returned and should be used for diagnostic/testing purposes only.
        /// </summary>
        internal int ReleaseRef(bool disposing = true)
        {
            var result = Interlocked.Decrement(ref this.refct);
            #if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefDownloadHandler, this.ptr, LogOperation.ReleaseRef, "{0}", result);
            #endif
			if (result == 0)
			{
                pointers.Remove((IntPtr)ptr);
			}
            return result;
        }

        /// <summary>
        /// Return the current number of references.
        /// </summary>
        internal int RefCount
        {
            get { return this.refct; }
        }

        internal cef_download_handler_t* NativePointer
        {
            get { return this.ptr; }
        }

        internal cef_download_handler_t* GetNativePointerAndAddRef()
        {
            AddRef();
            return this.ptr;
        }

        private int add_ref(cef_base_t* self)
        {
            ThrowIfObjectDisposed();
            return AddRef();
        }

        private int release(cef_base_t* self)
        {
            ThrowIfObjectDisposed();
            return ReleaseRef();
        }

        private int get_refct(cef_base_t* self)
        {
            ThrowIfObjectDisposed();
            return RefCount;
        }

        protected void ThrowIfObjectDisposed()
        {
            if (this.disposed) ThrowObjectDisposedException();
        }

        private static void ThrowObjectDisposedException()
        {
            throw new ObjectDisposedException("CefDownloadHandler");
        }

		[Conditional("DEBUG")]
		private void CheckNativePointer()
		{
            if (this.ptr == null) ThrowObjectDisposedException();
		}
    }
}