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

    public sealed unsafe partial class CefPostDataElement : IDisposable
	{
#if DIAGNOSTICS
		internal static int ObjectCt;
#endif

        /// <summary>
        /// Create CefPostDataElement proxy from pointer.
        /// </summary>
        internal static CefPostDataElement From(cef_post_data_element_t* ptr)
        {
            if (ptr == null) ThrowNullNativePointer();
			return new CefPostDataElement(ptr);
        }
		
        internal static CefPostDataElement FromOrDefault(cef_post_data_element_t* ptr)
        {
            if (ptr != null) return new CefPostDataElement(ptr);
            else return null;
        }

        private static void ThrowNullNativePointer()
        {
            throw new NullReferenceException("CefPostDataElement");
        }

        private cef_post_data_element_t* ptr;

        private CefPostDataElement(cef_post_data_element_t* ptr)
        {
            this.ptr = ptr;

#if DIAGNOSTICS
            Interlocked.Increment(ref ObjectCt);
            Cef.Logger.Trace(LogTarget.CefPostDataElement, this.ptr, LogOperation.Create);
#endif

            // if (addRef) this.AddRef();
        }

        #region IDisposable
        ~CefPostDataElement()
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
            if (this.ptr != null)
            {
                var refct = ReleaseRef();
#if DIAGNOSTICS
                var total = Interlocked.Decrement(ref ObjectCt);
                Cef.Logger.Trace(LogTarget.CefPostDataElement, this.ptr, LogOperation.Dispose, "RefCount=[{0}]", refct);
#endif
                this.ptr = null;
            }
        }
        #endregion

        private cef_base_t.add_ref_delegate add_ref
        {
            get
            {
                return (cef_base_t.add_ref_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->@base.add_ref, typeof(cef_base_t.add_ref_delegate));
            }
        }

        private cef_base_t.release_delegate release
        {
            get
            {
                return (cef_base_t.release_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->@base.release, typeof(cef_base_t.release_delegate));
            }
        }

        private cef_base_t.get_refct_delegate get_refct
        {
            get
            {
                return (cef_base_t.get_refct_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->@base.get_refct, typeof(cef_base_t.get_refct_delegate));
            }
        }

        /// <summary>
        /// The AddRef method increments the reference count for the object. It should
        /// be called for every new copy of a pointer to a given object. The resulting
        /// reference count value is returned and should be used for diagnostic/testing
        /// purposes only.
        /// </summary>
        internal int AddRef()
        {
            return add_ref(&this.ptr->@base);
        }

        /// <summary>
        /// The Release method decrements the reference count for the object. If the
        /// reference count on the object falls to 0, then the object should free
        /// itself from memory.  The resulting reference count value is returned and
        /// should be used for diagnostic/testing purposes only.
        /// </summary>
        internal int ReleaseRef()
        {
            return release(&this.ptr->@base);
        }

        /// <summary>
        /// Return the current number of references.
        /// </summary>
        internal int RefCount
        {
            get { return get_refct(&this.ptr->@base); }
        }

        internal cef_post_data_element_t* NativePointer
        {
            get
            {
                return this.ptr;
            }
        }

        internal cef_post_data_element_t* GetNativePointerAndAddRef()
        {
            AddRef();
            return this.ptr;
        }

        private cef_post_data_element_t.set_to_empty_delegate set_to_empty
        {
            get
            {
                return (cef_post_data_element_t.set_to_empty_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->set_to_empty, typeof(cef_post_data_element_t.set_to_empty_delegate));
            }
        }

        private cef_post_data_element_t.set_to_file_delegate set_to_file
        {
            get
            {
                return (cef_post_data_element_t.set_to_file_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->set_to_file, typeof(cef_post_data_element_t.set_to_file_delegate));
            }
        }

        private cef_post_data_element_t.set_to_bytes_delegate set_to_bytes
        {
            get
            {
                return (cef_post_data_element_t.set_to_bytes_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->set_to_bytes, typeof(cef_post_data_element_t.set_to_bytes_delegate));
            }
        }

        private cef_post_data_element_t.get_type_delegate get_type
        {
            get
            {
                return (cef_post_data_element_t.get_type_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->get_type, typeof(cef_post_data_element_t.get_type_delegate));
            }
        }

        private cef_post_data_element_t.get_file_delegate get_file
        {
            get
            {
                return (cef_post_data_element_t.get_file_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->get_file, typeof(cef_post_data_element_t.get_file_delegate));
            }
        }

        private cef_post_data_element_t.get_bytes_count_delegate get_bytes_count
        {
            get
            {
                return (cef_post_data_element_t.get_bytes_count_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->get_bytes_count, typeof(cef_post_data_element_t.get_bytes_count_delegate));
            }
        }

        private cef_post_data_element_t.get_bytes_delegate get_bytes
        {
            get
            {
                return (cef_post_data_element_t.get_bytes_delegate)Marshal.GetDelegateForFunctionPointer(this.ptr->get_bytes, typeof(cef_post_data_element_t.get_bytes_delegate));
            }
        }

    }
}