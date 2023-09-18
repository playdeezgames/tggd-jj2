Public Interface ITagHolder
    Sub SetTag(tagName As String)
    Function HasTag(tagName As String) As Boolean
    Sub RemoveTag(tagName As String)
End Interface
