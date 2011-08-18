namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDomEvent
    {
        /// <summary>
        /// Returns the event type.
        /// </summary>
        /* FIXME: CefDomEvent.GetType public */
        cef_string_userfree_t GetType()
        {
            // TODO: CefDomEvent.GetType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the event category.
        /// </summary>
        /* FIXME: CefDomEvent.GetCategory public */
        cef_dom_event_category_t GetCategory()
        {
            // TODO: CefDomEvent.GetCategory
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the event processing phase.
        /// </summary>
        /* FIXME: CefDomEvent.GetPhase public */
        cef_dom_event_phase_t GetPhase()
        {
            // TODO: CefDomEvent.GetPhase
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the event can bubble up the tree.
        /// </summary>
        /* FIXME: CefDomEvent.CanBubble public */
        int CanBubble()
        {
            // TODO: CefDomEvent.CanBubble
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the event can be canceled.
        /// </summary>
        /* FIXME: CefDomEvent.CanCancel public */
        int CanCancel()
        {
            // TODO: CefDomEvent.CanCancel
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the document associated with this event.
        /// </summary>
        /* FIXME: CefDomEvent.GetDocument public */
        cef_domdocument_t* GetDocument()
        {
            // TODO: CefDomEvent.GetDocument
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the target of the event.
        /// </summary>
        /* FIXME: CefDomEvent.GetTarget public */
        cef_domnode_t* GetTarget()
        {
            // TODO: CefDomEvent.GetTarget
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the current target of the event.
        /// </summary>
        /* FIXME: CefDomEvent.GetCurrentTarget public */
        cef_domnode_t* GetCurrentTarget()
        {
            // TODO: CefDomEvent.GetCurrentTarget
            throw new NotImplementedException();
        }


    }
}
