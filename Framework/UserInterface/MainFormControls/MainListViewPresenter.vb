Public MustInherit Class MainListViewPresenter(Of T)

    Friend nHibernateSession As NHibernate.ISession
    Friend ObjectList As IList(Of T)
    Friend QueryHelper As IListViewQueryable
    Friend CurrentQueryCriteria As NHibernate.ICriteria
    Private CurrentUserCriteria As MainFormUserCriteria
    Private WithEvents MainListView As IMainFormListViewView

    Friend MustOverride Sub OnOpenListItem(id As Integer)
    Friend MustOverride Sub SetQuery()
    Friend MustOverride Function GetIcon() As Image
    Friend MustOverride Function GetTitle() As String
    Friend MustOverride Function GetDescription() As String
    Friend MustOverride Function GetListBuilder() As IListBuilder

    Friend Sub New(MainForm As IMainFormListViewView)
        MainListView = MainForm
        nHibernateSession = SessionManager.Factory.OpenSession()
        SetQuery()
        ResetUserCriteria()
        SetMainFormUserCriteria()
        AddEventHandlers()
    End Sub

    Private Sub AddEventHandlers()
        AddHandler MainListView.RaiseRefreshList, AddressOf OnRefreshList
        AddHandler MainListView.RaiseExportList, AddressOf OnExport
        AddHandler MainListView.RaiseSelectListItem, AddressOf OnSelectListItem
        AddHandler MainListView.RaiseListChange, AddressOf OnListChange
        AddHandler MainListView.RaiseOpenListItem, AddressOf OnOpenListItem
    End Sub

    Friend Overridable Function GetFilterBuilder() As IFilterPanelBuildable
        Return Nothing
    End Function

    Friend Overridable Function GetActionPanelBuilder() As IActionPanelBuildable
        Return Nothing
    End Function

    Friend Overridable Function GetDefaultUserCriteria() As MainFormUserCriteria
        Return New MainFormUserCriteria With {.CurrentPage = 1,
                                              .Size = 50,
                                              .Orderedby = "Id",
                                              .SortOrder = Sort.Desc,
                                              .CriteriaFilter = RefreshQuery()}
    End Function

    Friend Overridable Sub OnSelectListItem(ids As List(Of Integer))
    End Sub

    Friend Sub BuildActionPanel()
        MainListView.SetActionPanel(GetActionPanelBuilder())
    End Sub

    Public Sub Initialise()
        OnRefreshList()
        SetNavigationIcon()
        SetNavigationTitle()
        SetNavigationDescription()
        BuildActionPanel()
        'BuildFilterPanel()
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

    Private Sub ResetUserCriteria()
        CurrentUserCriteria = GetDefaultUserCriteria()
    End Sub

    Private Sub SetMainFormUserCriteria()
        MainListView.SetUserQuery(CurrentUserCriteria)
    End Sub

    Private Sub OnRefreshList()
        ObjectList = GetObjectList(BuildCriteria)
        SetItemCount()
        DisplayListView()
        BuildActionPanel()
    End Sub

    Private Function BuildCriteria() As NHibernate.ICriteria
        CurrentQueryCriteria = RefreshQuery()
        CreateQuickSearchQuery()
        CreateFilterQuery()
        AddPagingToQuery()
        AddOrderbyToQuery()
        ResetUserCriteria()
        Return CurrentQueryCriteria
    End Function

    Private Function GetCount() As Integer
        CurrentQueryCriteria = RefreshQuery()
        CreateQuickSearchQuery()
        ResetUserCriteria()
        Return GetObjectCount()
    End Function

    Private Sub CreateQuickSearchQuery()
        If (Not String.IsNullOrEmpty(CurrentUserCriteria.QuickSearch)) AndAlso CurrentUserCriteria.State = UserCriteriaState.QuickSearch Then CurrentQueryCriteria = QuickSearchQuery(CurrentUserCriteria.QuickSearch)
    End Sub

    Private Sub CreateFilterQuery()
        If Not CurrentUserCriteria.CriteriaFilter Is Nothing AndAlso CurrentUserCriteria.State = UserCriteriaState.Criteria Then CurrentQueryCriteria = CurrentUserCriteria.CriteriaFilter
    End Sub

    Private Sub AddPagingToQuery()
        CurrentQueryCriteria.SetFirstResult(CurrentUserCriteria.Size * (CurrentUserCriteria.CurrentPage - 1)).SetMaxResults(CurrentUserCriteria.Size)
    End Sub

    Private Sub AddOrderbyToQuery()
        CurrentQueryCriteria.ClearOrders()
        Select Case CurrentUserCriteria.SortOrder
            Case Sort.Asc
                CurrentQueryCriteria.AddOrder(NHibernate.Criterion.Order.Asc(CurrentUserCriteria.Orderedby))
            Case Sort.Desc
                CurrentQueryCriteria.AddOrder(NHibernate.Criterion.Order.Desc(CurrentUserCriteria.Orderedby))
        End Select
    End Sub

    Private Sub OnListChange(UserCriteria As MainFormUserCriteria)
        CurrentUserCriteria = UserCriteria
        OnRefreshList()
    End Sub

    Private Sub ResetPage()
        MainListView.ResetPageNumber()
    End Sub

    Private Sub SetItemCount()
        MainListView.SetItemCount(GetCount)
    End Sub

    Private Sub DisplayListView()
        MainListView.SetList(GetListBuilder())
    End Sub

    'Private Sub BuildFilterPanel()
    '    MainListView.SetFilterPanel(GetFilterBuilder)
    'End Sub

    Private Sub OnExport()
        Throw New NotImplementedException()
    End Sub

    Private Function GetObjectList(Criteria As NHibernate.ICriteria) As System.Collections.Generic.IList(Of T)
        Return Criteria.List(Of T)()
    End Function

    Private Function GetObjectCount() As Integer
        Return QueryHelper.CriteriaCount(CurrentQueryCriteria)
    End Function

    Private Function QuickSearchQuery(SearchString As String) As NHibernate.ICriteria
        Return QueryHelper.QuickSearchQuery(CurrentQueryCriteria, SearchString)
    End Function

    Friend Function RefreshQuery() As NHibernate.ICriteria
        Return QueryHelper.CreateListViewQuery(nHibernateSession)
    End Function
End Class
