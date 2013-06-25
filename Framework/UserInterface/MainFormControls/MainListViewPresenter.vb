Public Enum QueryState
    Criteria
    QuickSearch
End Enum

Public MustInherit Class MainListViewPresenter(Of T)

    Friend session As NHibernate.ISession
    Friend ObjectList As IList(Of T)

    Private CurrentUserQuery As MainFormUserQuery
    Private WithEvents MainListView As IMainFormListViewView

    Friend Sub New(MainForm As IMainFormListViewView)
        MainListView = MainForm
        session = SessionManager.Factory.OpenSession()
        CurrentUserQuery = GetDefaultUserQuery()
        SetQuery()
        SetUserQuery()
        AddEventHandlers()
    End Sub

    Private Sub AddEventHandlers()
        AddHandler MainListView.RaiseRefreshList, AddressOf OnRefreshList
        AddHandler MainListView.RaiseExportList, AddressOf OnExport
        AddHandler MainListView.RaiseSelectListItem, AddressOf OnSelectListItem
        AddHandler MainListView.RaiseListChange, AddressOf OnListChange
        AddHandler MainListView.RaiseOpenListItem, AddressOf OnOpenListItem
    End Sub

    Friend MustOverride Sub OnOpenListItem(id As Integer)
    Friend MustOverride Sub SetQuery()
    Friend MustOverride Function GetIcon() As Image
    Friend MustOverride Function GetTitle() As String
    Friend MustOverride Function GetDescription() As String
    Friend MustOverride Function RefreshQuery() As NHibernate.ICriteria
    Friend MustOverride Function QuickSearchQuery(SearchString As String) As NHibernate.ICriteria
    Friend MustOverride Function GetObjectCount() As Integer
    Friend MustOverride Function GetObjectList(Criteria As NHibernate.ICriteria) As IList(Of T)
    Friend MustOverride Function GetListBuilder() As IListBuilder

    Friend Overridable Function GetActionPanelBuilder() As IActionPanelBuildable
        Return Nothing
    End Function

    Friend Overridable Function GetFilterPanelBuilder() As IFilterPanelBuildable
        Return Nothing
    End Function

    Friend Overridable Function GetDefaultUserQuery() As MainFormUserQuery
        Return New MainFormUserQuery With {.CurrentPage = 1,
                                           .Size = 50,
                                           .Orderedby = "Id",
                                           .SortOrder = Sort.Desc}
    End Function

    Friend Overridable Sub OnSelectListItem(ids As List(Of Integer))
    End Sub

    Public Sub Initialise()
        OnRefreshList()
        SetNavigationIcon()
        SetNavigationTitle()
        SetNavigationDescription()
        BuildActionPanel()
    End Sub
    Private Sub SetNavigationIcon()
        MainListView.NavigationIcon = GetIcon()
    End Sub

    Private Sub SetNavigationTitle()
        MainListView.NavigationTitle = GetTitle()
    End Sub

    Private Sub SetNavigationDescription()
        MainListView.NavigationDescription = GetDescription()
    End Sub

    Private Sub SetUserQuery()
        MainListView.SetUserQuery(CurrentUserQuery)
    End Sub

    Private CurrentQueryCriteria As NHibernate.ICriteria

    Private Function BuildCriteria() As NHibernate.ICriteria
        CurrentQueryCriteria = RefreshQuery()
        CreateQuickSearchQuery()
        AddPagingToQuery()
        AddOrderbyToQuery()
        Return CurrentQueryCriteria
    End Function

    Private Sub CreateQuickSearchQuery()
        CurrentQueryCriteria = QuickSearchQuery(CurrentUserQuery.QuickSearch)
    End Sub

    Private Sub AddPagingToQuery()
        CurrentQueryCriteria.SetFirstResult(CurrentUserQuery.Size * (CurrentUserQuery.CurrentPage - 1)).SetMaxResults(CurrentUserQuery.Size)
    End Sub

    Private Sub AddOrderbyToQuery()
        Select Case CurrentUserQuery.SortOrder
            Case Sort.Asc
                CurrentQueryCriteria.AddOrder(NHibernate.Criterion.Order.Asc(CurrentUserQuery.Orderedby))
            Case Sort.Desc
                CurrentQueryCriteria.AddOrder(NHibernate.Criterion.Order.Desc(CurrentUserQuery.Orderedby))
        End Select
    End Sub

    Private Sub OnListChange(UserQuery As MainFormUserQuery)
        CurrentUserQuery = UserQuery
        OnRefreshList()
    End Sub

    Private Sub OnRefreshList()
        ObjectList = GetObjectList(BuildCriteria)
        SetItemCount()
        DisplayListView()
        BuildActionPanel()
    End Sub

    Private Sub ResetPage()
        MainListView.ResetPageNumber()
    End Sub

    Private Sub SetItemCount()
        MainListView.SetItemCount(GetObjectCount)
    End Sub

    Private Sub DisplayListView()
        MainListView.SetList(GetListBuilder())
    End Sub

    Friend Sub BuildActionPanel()
        MainListView.SetActionPanel(GetActionPanelBuilder())
    End Sub

    Private Sub OnExport()
        Throw New NotImplementedException()
    End Sub

End Class