Public Enum QueryState
    Citeria
    QuickSearch
End Enum

Public MustInherit Class MainListViewPresenter(Of T)

    Friend session As NHibernate.ISession
    Friend QueryCiteria As NHibernate.ICriteria
    Friend ObjectList As IList(Of T)

    Private WithEvents MainListView As IMainFormListViewView
    Private CurrentQueryType As QueryState
    Private IsPaged As Boolean = True
    Private PageSize As Integer = 50
    Private CurrentPage As Integer = 1

    Friend Sub New(MainForm As IMainFormListViewView)
        MainListView = MainForm
        SetQuery()
        CurrentQueryType = QueryState.Citeria
        session = SessionManager.Factory.OpenSession()
        AddEventHandlers()
    End Sub

    Private Sub AddEventHandlers()
        AddHandler MainListView.RaiseRefreshList, AddressOf OnRefreshList
        AddHandler MainListView.RaiseQuickSearch, AddressOf OnQuickSearch
        AddHandler MainListView.RaiseExportList, AddressOf OnExport
        AddHandler MainListView.RaiseSelectListItem, AddressOf OnSelectListViewItem
        AddHandler MainListView.RaisePageChange, AddressOf OnPageChange
    End Sub

    Friend MustOverride Function SetTitle() As String
    Friend MustOverride Function SetDescription() As String
    Friend MustOverride Function SetIcon() As Image
    Friend MustOverride ReadOnly Property Description As String
    Friend MustOverride Sub SetQuery()
    Friend MustOverride Function RefreshQuery() As NHibernate.ICriteria
    Friend MustOverride Function QuickSearchQuery(SearchString As String) As NHibernate.ICriteria
    Friend MustOverride Function SetObjectCount() As Integer
    Friend MustOverride Function GetObjectList() As IList(Of T)
    Friend MustOverride Function GetListBuilder() As IListBuilder
    Friend Overridable Function GetActionPanelBuilder() As IActionPanelBuildable
        Return Nothing
    End Function
    Friend Overridable Function GetFilterPanelBuilder() As IFilterPanelBuildable
        Return Nothing
    End Function

    Public Sub Initialise()
        QueryCiteria = RefreshQuery()
        OnRefreshList()
        SetNavigationIcon()
        SetNavigationTitle()
        SetNavigationDescription()
        BuildActionPanel()
        BuildFilterPanel()
    End Sub

    Private Sub SetNavigationIcon()
        MainListView.NavigationIcon = SetIcon()
    End Sub

    Public Sub OnBuildList()
        OnRefreshList()
    End Sub

    Private Sub SetNavigationTitle()
        MainListView.NavigationTitle = SetTitle()
    End Sub

    Private Sub SetNavigationDescription()
        MainListView.NavigationDescription = SetDescription()
    End Sub

    Private Sub AddPagingToQuery()
        QueryCiteria.SetFirstResult(PageSize * (CurrentPage - 1)).SetMaxResults(PageSize)
    End Sub

    Friend Sub OnRefreshList()
        If IsPaged Then AddPagingToQuery()
        ObjectList = GetObjectList()
        SetItemCount()
        DisplayListView()
    End Sub

    Private Sub SetItemCount()
        MainListView.SetItemCount(SetObjectCount)
    End Sub

    Private Sub OnQuickSearch(SearchString As String)
        CurrentQueryType = QueryState.QuickSearch
        QueryCiteria = QuickSearchQuery(SearchString)
        OnRefreshList()
    End Sub

    Private Sub OnFilter()
        CurrentQueryType = QueryState.Citeria
        RefreshQuery()
        OnRefreshList()
    End Sub

    Private Sub OnExport()
        Stop
    End Sub

    Private Sub OnSelectListViewItem(id As Integer)
        Stop
    End Sub

    Private Sub OnPageChange(GotoPage As Integer)
        If CurrentPage <> GotoPage Then
            CurrentPage = GotoPage
            OnRefreshList()
        End If
    End Sub

    Private Sub DisplayListView()
        MainListView.SetList(GetListBuilder)
    End Sub

    Private Sub BuildActionPanel()
        MainListView.SetActionPanel(GetActionPanelBuilder())
    End Sub

    Private Sub BuildFilterPanel()
        MainListView.SetFilterPanel(GetFilterPanelBuilder())
    End Sub

End Class

