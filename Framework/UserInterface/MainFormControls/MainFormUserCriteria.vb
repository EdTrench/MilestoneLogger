Public Enum Sort
    Asc
    Desc
End Enum

Public Enum UserCriteriaState
    Criteria
    QuickSearch
End Enum

Public Class MainFormUserCriteria
    Public Property Size As Integer
    Public Property CurrentPage As Integer
    Public Property Orderedby As String
    Public Property SortOrder As Sort = Sort.Asc
    Public Property State As UserCriteriaState
    Public Property QuickSearch As String
    Public Property CriteriaFilter As NHibernate.ICriteria
End Class
