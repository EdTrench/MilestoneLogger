Public Enum Sort
    Asc
    Desc
End Enum

Public Class MainFormUserQuery

    Public Property Size As Integer = 50
    Public Property CurrentPage As Integer
    Public Property Orderedby As String
    Public Property SortOrder As Sort = Sort.Asc
    Public Property QueryState As QueryState
    Public Property QuickSearch As String

End Class