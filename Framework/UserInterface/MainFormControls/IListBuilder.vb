Public Interface IListBuilder
    Sub BuildListView(TargetControl As ListView)
    Function OrderBy(index As Integer) As String
End Interface