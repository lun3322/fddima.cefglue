namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDomEvent
    {
        /// <summary>
        /// Returns the event type.
        /// </summary>
        public string Type
        {
            get
            {
                var n_type = this.get_type(this.ptr);
                return n_type.GetStringAndFree();
            }
        }

        /// <summary>
        /// Returns the event category.
        /// </summary>
        public CefDomEventCategory Category
        {
            get
            {
                return (CefDomEventCategory)this.get_category(this.ptr);
            }
        }

        /// <summary>
        /// Returns the event processing phase.
        /// </summary>
        public CefDomEventPhase Phase
        {
            get
            {
                return (CefDomEventPhase)this.get_phase(this.ptr);
            }
        }

        /// <summary>
        /// Returns true if the event can bubble up the tree.
        /// </summary>
        public bool CanBubble
        {
            get
            {
                return this.can_bubble(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if the event can be canceled.
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return this.can_cancel(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns the document associated with this event.
        /// </summary>
        public CefDomDocument GetDocument()
        {
            return CefDomDocument.From(
                this.get_document(this.ptr)
                );
        }

        /// <summary>
        /// Returns the target of the event.
        /// </summary>
        public CefDomNode GetTarget()
        {
            return CefDomNode.From(
                this.get_target(this.ptr)
                );
        }

        /// <summary>
        /// Returns the current target of the event.
        /// </summary>
        public CefDomNode GetCurrentTarget()
        {
            return CefDomNode.From(
                this.get_current_target(this.ptr)
                );
        }


    }
}
