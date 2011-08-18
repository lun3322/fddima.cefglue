namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDomDocument
    {
        /// <summary>
        /// Returns the document type.
        /// </summary>
        /* FIXME: CefDomDocument.GetType public */
        cef_dom_document_type_t GetType()
        {
            // TODO: CefDomDocument.GetType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the root document node.
        /// </summary>
        /* FIXME: CefDomDocument.GetDocument public */
        cef_domnode_t* GetDocument()
        {
            // TODO: CefDomDocument.GetDocument
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the BODY node of an HTML document.
        /// </summary>
        /* FIXME: CefDomDocument.GetBody public */
        cef_domnode_t* GetBody()
        {
            // TODO: CefDomDocument.GetBody
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the HEAD node of an HTML document.
        /// </summary>
        /* FIXME: CefDomDocument.GetHead public */
        cef_domnode_t* GetHead()
        {
            // TODO: CefDomDocument.GetHead
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the title of an HTML document.
        /// </summary>
        /* FIXME: CefDomDocument.GetTitle public */
        cef_string_userfree_t GetTitle()
        {
            // TODO: CefDomDocument.GetTitle
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the document element with the specified ID value.
        /// </summary>
        /* FIXME: CefDomDocument.GetElementById public */
        cef_domnode_t* GetElementById(/*const*/ cef_string_t* id)
        {
            // TODO: CefDomDocument.GetElementById
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the node that currently has keyboard focus.
        /// </summary>
        /* FIXME: CefDomDocument.GetFocusedNode public */
        cef_domnode_t* GetFocusedNode()
        {
            // TODO: CefDomDocument.GetFocusedNode
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if a portion of the document is selected.
        /// </summary>
        /* FIXME: CefDomDocument.HasSelection public */
        int HasSelection()
        {
            // TODO: CefDomDocument.HasSelection
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the selection start node.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionStartNode public */
        cef_domnode_t* GetSelectionStartNode()
        {
            // TODO: CefDomDocument.GetSelectionStartNode
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the selection offset within the start node.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionStartOffset public */
        int GetSelectionStartOffset()
        {
            // TODO: CefDomDocument.GetSelectionStartOffset
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the selection end node.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionEndNode public */
        cef_domnode_t* GetSelectionEndNode()
        {
            // TODO: CefDomDocument.GetSelectionEndNode
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the selection offset within the end node.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionEndOffset public */
        int GetSelectionEndOffset()
        {
            // TODO: CefDomDocument.GetSelectionEndOffset
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the contents of this selection as markup.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionAsMarkup public */
        cef_string_userfree_t GetSelectionAsMarkup()
        {
            // TODO: CefDomDocument.GetSelectionAsMarkup
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the contents of this selection as text.
        /// </summary>
        /* FIXME: CefDomDocument.GetSelectionAsText public */
        cef_string_userfree_t GetSelectionAsText()
        {
            // TODO: CefDomDocument.GetSelectionAsText
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the base URL for the document.
        /// </summary>
        /* FIXME: CefDomDocument.GetBaseURL public */
        cef_string_userfree_t GetBaseURL()
        {
            // TODO: CefDomDocument.GetBaseURL
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a complete URL based on the document base URL and the
        /// specified partial URL.
        /// </summary>
        /* FIXME: CefDomDocument.GetCompleteURL public */
        cef_string_userfree_t GetCompleteURL(/*const*/ cef_string_t* partialURL)
        {
            // TODO: CefDomDocument.GetCompleteURL
            throw new NotImplementedException();
        }


    }
}
