namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDomNode
    {
        /// <summary>
        /// Returns the type for this node.
        /// </summary>
        /* FIXME: CefDomNode.GetType public */
        cef_dom_node_type_t GetType()
        {
            // TODO: CefDomNode.GetType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this is a text node.
        /// </summary>
        /* FIXME: CefDomNode.IsText public */
        int IsText()
        {
            // TODO: CefDomNode.IsText
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this is an element node.
        /// </summary>
        /* FIXME: CefDomNode.IsElement public */
        int IsElement()
        {
            // TODO: CefDomNode.IsElement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /* FIXME: CefDomNode.IsSame public */
        int IsSame(cef_domnode_t* that)
        {
            // TODO: CefDomNode.IsSame
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of this node.
        /// </summary>
        /* FIXME: CefDomNode.GetName public */
        cef_string_userfree_t GetName()
        {
            // TODO: CefDomNode.GetName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value of this node.
        /// </summary>
        /* FIXME: CefDomNode.GetValue public */
        cef_string_userfree_t GetValue()
        {
            // TODO: CefDomNode.GetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the value of this node. Returns true on success.
        /// </summary>
        /* FIXME: CefDomNode.SetValue public */
        int SetValue(/*const*/ cef_string_t* value)
        {
            // TODO: CefDomNode.SetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the contents of this node as markup.
        /// </summary>
        /* FIXME: CefDomNode.GetAsMarkup public */
        cef_string_userfree_t GetAsMarkup()
        {
            // TODO: CefDomNode.GetAsMarkup
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the document associated with this node.
        /// </summary>
        /* FIXME: CefDomNode.GetDocument public */
        cef_domdocument_t* GetDocument()
        {
            // TODO: CefDomNode.GetDocument
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the parent node.
        /// </summary>
        /* FIXME: CefDomNode.GetParent public */
        cef_domnode_t* GetParent()
        {
            // TODO: CefDomNode.GetParent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the previous sibling node.
        /// </summary>
        /* FIXME: CefDomNode.GetPreviousSibling public */
        cef_domnode_t* GetPreviousSibling()
        {
            // TODO: CefDomNode.GetPreviousSibling
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the next sibling node.
        /// </summary>
        /* FIXME: CefDomNode.GetNextSibling public */
        cef_domnode_t* GetNextSibling()
        {
            // TODO: CefDomNode.GetNextSibling
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this node has child nodes.
        /// </summary>
        /* FIXME: CefDomNode.HasChildren public */
        int HasChildren()
        {
            // TODO: CefDomNode.HasChildren
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the first child node.
        /// </summary>
        /* FIXME: CefDomNode.GetFirstChild public */
        cef_domnode_t* GetFirstChild()
        {
            // TODO: CefDomNode.GetFirstChild
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the last child node.
        /// </summary>
        /* FIXME: CefDomNode.GetLastChild public */
        cef_domnode_t* GetLastChild()
        {
            // TODO: CefDomNode.GetLastChild
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add an event listener to this node for the specified event type. If
        /// |useCapture| is true then this listener will be considered a
        /// capturing listener. Capturing listeners will recieve all events of
        /// the specified type before the events are dispatched to any other
        /// event targets beneath the current node in the tree. Events which are
        /// bubbling upwards through the tree will not trigger a capturing
        /// listener. Separate calls to this method can be used to register the
        /// same listener with and without capture. See WebCore/dom/EventNames.h
        /// for the list of supported event types.
        /// </summary>
        /* FIXME: CefDomNode.AddEventListener public */
        void AddEventListener(/*const*/ cef_string_t* eventType, cef_domevent_listener_t* listener, int useCapture)
        {
            // TODO: CefDomNode.AddEventListener
            throw new NotImplementedException();
        }


        // The following methods are valid only for element nodes.

        /// <summary>
        /// Returns the tag name of this element.
        /// </summary>
        /* FIXME: CefDomNode.GetElementTagName public */
        cef_string_userfree_t GetElementTagName()
        {
            // TODO: CefDomNode.GetElementTagName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this element has attributes.
        /// </summary>
        /* FIXME: CefDomNode.HasElementAttributes public */
        int HasElementAttributes()
        {
            // TODO: CefDomNode.HasElementAttributes
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this element has an attribute named |attrName|.
        /// </summary>
        /* FIXME: CefDomNode.HasElementAttribute public */
        int HasElementAttribute(/*const*/ cef_string_t* attrName)
        {
            // TODO: CefDomNode.HasElementAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the element attribute named |attrName|.
        /// </summary>
        /* FIXME: CefDomNode.GetElementAttribute public */
        cef_string_userfree_t GetElementAttribute(/*const*/ cef_string_t* attrName)
        {
            // TODO: CefDomNode.GetElementAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a map of all element attributes.
        /// </summary>
        /* FIXME: CefDomNode.GetElementAttributes public */
        void GetElementAttributes(cef_string_map_t attrMap)
        {
            // TODO: CefDomNode.GetElementAttributes
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the value for the element attribute named |attrName|. Returns
        /// true on success.
        /// </summary>
        /* FIXME: CefDomNode.SetElementAttribute public */
        int SetElementAttribute(/*const*/ cef_string_t* attrName, /*const*/ cef_string_t* value)
        {
            // TODO: CefDomNode.SetElementAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the inner text of the element.
        /// </summary>
        /* FIXME: CefDomNode.GetElementInnerText public */
        cef_string_userfree_t GetElementInnerText()
        {
            // TODO: CefDomNode.GetElementInnerText
            throw new NotImplementedException();
        }


    }
}
