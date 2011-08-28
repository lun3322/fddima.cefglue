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

    public abstract unsafe partial class CefWebUrlRequestClient 
    {
#if DIAGNOSTICS
        internal static int ObjectCt;
#endif

        private static ObjectTable<CefWebUrlRequestClient> pointers = new ObjectTable<CefWebUrlRequestClient>();



        private int refct;
        private cef_web_urlrequest_client_t* ptr;
        private bool disposed;

        private cef_base_t.add_ref_delegate bs_add_ref;
        private cef_base_t.release_delegate bs_release;
        private cef_base_t.get_refct_delegate bs_get_refct;
        private cef_web_urlrequest_client_t.on_state_change_delegate bs_on_state_change;
        private cef_web_urlrequest_client_t.on_redirect_delegate bs_on_redirect;
        private cef_web_urlrequest_client_t.on_headers_received_delegate bs_on_headers_received;
        private cef_web_urlrequest_client_t.on_progress_delegate bs_on_progress;
        private cef_web_urlrequest_client_t.on_data_delegate bs_on_data;
        private cef_web_urlrequest_client_t.on_error_delegate bs_on_error;

        public CefWebUrlRequestClient()
        {
            this.refct = 0;
            this.ptr = cef_web_urlrequest_client_t.Alloc();
#if DIAGNOSTICS
			Interlocked.Increment(ref ObjectCt);
#endif

#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefWebUrlRequestClient, this.ptr, LogOperation.Create);
#endif

            this.bs_add_ref = new cef_base_t.add_ref_delegate(this.add_ref);
            this.ptr->@base.add_ref = Marshal.GetFunctionPointerForDelegate(this.bs_add_ref);

            this.bs_release = new cef_base_t.release_delegate(this.release);
            this.ptr->@base.release = Marshal.GetFunctionPointerForDelegate(this.bs_release);

            this.bs_get_refct = new cef_base_t.get_refct_delegate(this.get_refct);
            this.ptr->@base.get_refct = Marshal.GetFunctionPointerForDelegate(this.bs_get_refct);

            this.bs_on_state_change = new cef_web_urlrequest_client_t.on_state_change_delegate(this.on_state_change);
            this.ptr->on_state_change = Marshal.GetFunctionPointerForDelegate(this.bs_on_state_change);

            this.bs_on_redirect = new cef_web_urlrequest_client_t.on_redirect_delegate(this.on_redirect);
            this.ptr->on_redirect = Marshal.GetFunctionPointerForDelegate(this.bs_on_redirect);

            this.bs_on_headers_received = new cef_web_urlrequest_client_t.on_headers_received_delegate(this.on_headers_received);
            this.ptr->on_headers_received = Marshal.GetFunctionPointerForDelegate(this.bs_on_headers_received);

            this.bs_on_progress = new cef_web_urlrequest_client_t.on_progress_delegate(this.on_progress);
            this.ptr->on_progress = Marshal.GetFunctionPointerForDelegate(this.bs_on_progress);

            this.bs_on_data = new cef_web_urlrequest_client_t.on_data_delegate(this.on_data);
            this.ptr->on_data = Marshal.GetFunctionPointerForDelegate(this.bs_on_data);

            this.bs_on_error = new cef_web_urlrequest_client_t.on_error_delegate(this.on_error);
            this.ptr->on_error = Marshal.GetFunctionPointerForDelegate(this.bs_on_error);

        }

        ~CefWebUrlRequestClient()
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefWebUrlRequestClient, this.ptr, "~CefWebUrlRequestClient");
#endif
			Dispose(false);
        }


		protected virtual void Dispose(bool disposing)
        {
#if DIAGNOSTICS
            Cef.Logger.Trace(LogTarget.CefWebUrlRequestClient, this.ptr, LogOperation.Dispose, "Disposing=[{0}]", disposing);
#endif

			this.disposed = true;

			if (this.ptr != null)
            {
#if DIAGNOSTICS
                Interlocked.Decrement(ref ObjectCt);
#endif
				cef_web_urlrequest_client_t.Free(this.ptr);
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
            Cef.Logger.Trace(LogTarget.CefWebUrlRequestClient, this.ptr, LogOperation.AddRef, "{0}", result);
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
            Cef.Logger.Trace(LogTarget.CefWebUrlRequestClient, this.ptr, LogOperation.ReleaseRef, "{0}", result);
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

        internal cef_web_urlrequest_client_t* NativePointer
        {
            get { return this.ptr; }
        }

        internal cef_web_urlrequest_client_t* GetNativePointerAndAddRef()
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
            throw new ObjectDisposedException("CefWebUrlRequestClient");
        }

		[Conditional("DEBUG")]
		private void CheckNativePointer()
		{
            if (this.ptr == null) ThrowObjectDisposedException();
		}
    }
}