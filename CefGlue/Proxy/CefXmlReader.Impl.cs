namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefXmlReader
    {
        /// <summary>
        /// Create a new CefXmlReader object. The returned object's methods can
        /// only be called from the thread that created the object.
        /// </summary>
        /* FIXME: CefXmlReader.Create public */
        static cef_xml_reader_t* Create(cef_stream_reader_t* stream, cef_xml_encoding_type_t encodingType, /*const*/ cef_string_t* URI)
        {
            // TODO: CefXmlReader.Create
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the next node in the document. This method must
        /// be called at least once to set the current cursor position. Returns
        /// true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToNextNode public */
        int MoveToNextNode()
        {
            // TODO: CefXmlReader.MoveToNextNode
            throw new NotImplementedException();
        }

        /// <summary>
        /// Close the document. This should be called directly to ensure that
        /// cleanup occurs on the correct thread.
        /// </summary>
        /* FIXME: CefXmlReader.Close public */
        int Close()
        {
            // TODO: CefXmlReader.Close
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if an error has been reported by the XML parser.
        /// </summary>
        /* FIXME: CefXmlReader.HasError public */
        int HasError()
        {
            // TODO: CefXmlReader.HasError
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the error string.
        /// </summary>
        /* FIXME: CefXmlReader.GetError public */
        cef_string_userfree_t GetError()
        {
            // TODO: CefXmlReader.GetError
            throw new NotImplementedException();
        }


        // The below methods retrieve data for the node at the current cursor position.

        /// <summary>
        /// Returns the node type.
        /// </summary>
        /* FIXME: CefXmlReader.GetType public */
        cef_xml_node_type_t GetType()
        {
            // TODO: CefXmlReader.GetType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the node depth. Depth starts at 0 for the root node.
        /// </summary>
        /* FIXME: CefXmlReader.GetDepth public */
        int GetDepth()
        {
            // TODO: CefXmlReader.GetDepth
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the local name. See http://www.w3.org/TR/REC-xml-names/#NT-
        /// LocalPart for additional details.
        /// </summary>
        /* FIXME: CefXmlReader.GetLocalName public */
        cef_string_userfree_t GetLocalName()
        {
            // TODO: CefXmlReader.GetLocalName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the namespace prefix. See http://www.w3.org/TR/REC-xml-names/
        /// for additional details.
        /// </summary>
        /* FIXME: CefXmlReader.GetPrefix public */
        cef_string_userfree_t GetPrefix()
        {
            // TODO: CefXmlReader.GetPrefix
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the qualified name, equal to (Prefix:)LocalName. See
        /// http://www.w3.org/TR/REC-xml-names/#ns-qualnames for additional
        /// details.
        /// </summary>
        /* FIXME: CefXmlReader.GetQualifiedName public */
        cef_string_userfree_t GetQualifiedName()
        {
            // TODO: CefXmlReader.GetQualifiedName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the URI defining the namespace associated with the node. See
        /// http://www.w3.org/TR/REC-xml-names/ for additional details.
        /// </summary>
        /* FIXME: CefXmlReader.GetNamespaceURI public */
        cef_string_userfree_t GetNamespaceURI()
        {
            // TODO: CefXmlReader.GetNamespaceURI
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the base URI of the node. See http://www.w3.org/TR/xmlbase/
        /// for additional details.
        /// </summary>
        /* FIXME: CefXmlReader.GetBaseURI public */
        cef_string_userfree_t GetBaseURI()
        {
            // TODO: CefXmlReader.GetBaseURI
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the xml:lang scope within which the node resides. See
        /// http://www.w3.org/TR/REC-xml/#sec-lang-tag for additional details.
        /// </summary>
        /* FIXME: CefXmlReader.GetXmlLang public */
        cef_string_userfree_t GetXmlLang()
        {
            // TODO: CefXmlReader.GetXmlLang
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the node represents an empty element. <a/> is
        /// considered empty but <a></a> is not.
        /// </summary>
        /* FIXME: CefXmlReader.IsEmptyElement public */
        int IsEmptyElement()
        {
            // TODO: CefXmlReader.IsEmptyElement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the node has a text value.
        /// </summary>
        /* FIXME: CefXmlReader.HasValue public */
        int HasValue()
        {
            // TODO: CefXmlReader.HasValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the text value.
        /// </summary>
        /* FIXME: CefXmlReader.GetValue public */
        cef_string_userfree_t GetValue()
        {
            // TODO: CefXmlReader.GetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the node has attributes.
        /// </summary>
        /* FIXME: CefXmlReader.HasAttributes public */
        int HasAttributes()
        {
            // TODO: CefXmlReader.HasAttributes
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of attributes.
        /// </summary>
        /* FIXME: CefXmlReader.GetAttributeCount public */
        int GetAttributeCount()
        {
            // TODO: CefXmlReader.GetAttributeCount
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value of the attribute at the specified 0-based index.
        /// </summary>
        /* FIXME: CefXmlReader.GetAttribute public */
        cef_string_userfree_t GetAttribute(int index)
        {
            // TODO: CefXmlReader.GetAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value of the attribute with the specified qualified name.
        /// </summary>
        /* FIXME: CefXmlReader.GetAttribute public */
        cef_string_userfree_t GetAttribute(/*const*/ cef_string_t* qualifiedName)
        {
            // TODO: CefXmlReader.GetAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value of the attribute with the specified local name and
        /// namespace URI.
        /// </summary>
        /* FIXME: CefXmlReader.GetAttribute public */
        cef_string_userfree_t GetAttribute(/*const*/ cef_string_t* localName, /*const*/ cef_string_t* namespaceURI)
        {
            // TODO: CefXmlReader.GetAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an XML representation of the current node's children.
        /// </summary>
        /* FIXME: CefXmlReader.GetInnerXml public */
        cef_string_userfree_t GetInnerXml()
        {
            // TODO: CefXmlReader.GetInnerXml
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an XML representation of the current node including its
        /// children.
        /// </summary>
        /* FIXME: CefXmlReader.GetOuterXml public */
        cef_string_userfree_t GetOuterXml()
        {
            // TODO: CefXmlReader.GetOuterXml
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the line number for the current node.
        /// </summary>
        /* FIXME: CefXmlReader.GetLineNumber public */
        int GetLineNumber()
        {
            // TODO: CefXmlReader.GetLineNumber
            throw new NotImplementedException();
        }


        // Attribute nodes are not traversed by default. The below methods can
        // be used to move the cursor to an attribute node.
        // MoveToCarryingElement() can be called afterwards to return the cursor
        // to the carrying element. The depth of an attribute node will be 1 +
        // the depth of the carrying element.

        /// <summary>
        /// Moves the cursor to the attribute at the specified 0-based index.
        /// Returns true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToAttribute public */
        int MoveToAttribute(int index)
        {
            // TODO: CefXmlReader.MoveToAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the attribute with the specified qualified name.
        /// Returns true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToAttribute public */
        int MoveToAttribute(/*const*/ cef_string_t* qualifiedName)
        {
            // TODO: CefXmlReader.MoveToAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the attribute with the specified local name and
        /// namespace URI. Returns true if the cursor position was set
        /// successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToAttribute public */
        int MoveToAttribute(/*const*/ cef_string_t* localName, /*const*/ cef_string_t* namespaceURI)
        {
            // TODO: CefXmlReader.MoveToAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the first attribute in the current element.
        /// Returns true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToFirstAttribute public */
        int MoveToFirstAttribute()
        {
            // TODO: CefXmlReader.MoveToFirstAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor to the next attribute in the current element.
        /// Returns true if the cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToNextAttribute public */
        int MoveToNextAttribute()
        {
            // TODO: CefXmlReader.MoveToNextAttribute
            throw new NotImplementedException();
        }

        /// <summary>
        /// Moves the cursor back to the carrying element. Returns true if the
        /// cursor position was set successfully.
        /// </summary>
        /* FIXME: CefXmlReader.MoveToCarryingElement public */
        int MoveToCarryingElement()
        {
            // TODO: CefXmlReader.MoveToCarryingElement
            throw new NotImplementedException();
        }


    }
}
