namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// "Verb" of a drag-and-drop operation as negotiated between the source and
    /// destination. These constants match their equivalents in WebCore's
    /// DragActions.h and should not be renumbered.
    /// </summary>
    [Flags]
    public enum CefDragOperations : uint
    {
        None = cef_drag_operations_mask_t.DRAG_OPERATION_NONE,
        Copy = cef_drag_operations_mask_t.DRAG_OPERATION_COPY,
        Link = cef_drag_operations_mask_t.DRAG_OPERATION_LINK,
        Generic = cef_drag_operations_mask_t.DRAG_OPERATION_GENERIC,
        Private = cef_drag_operations_mask_t.DRAG_OPERATION_PRIVATE,
        Move = cef_drag_operations_mask_t.DRAG_OPERATION_MOVE,
        Delete = cef_drag_operations_mask_t.DRAG_OPERATION_DELETE,
        Every = cef_drag_operations_mask_t.DRAG_OPERATION_EVERY,
    };
}
