
Public Delegate Sub SelectListItemHandler(ids As List(Of Integer))
Public Delegate Sub OpenListItemHandler(id As Integer)
Public Delegate Sub QuickSearchHandler(SearchString As String)
Public Delegate Sub RefreshHandler()
Public Delegate Sub ExportHandler()
Public Delegate Sub ListChangeHandler(UserQuery As MainFormUserCriteria)

Public Interface IMainFormListViewView

    Property NavigationIcon As Image
    Property NavigationDescription As String
    Property NavigationTitle As String

    Sub ResetPageNumber()
    Sub SetUserQuery(UserQuery As MainFormUserCriteria)
    Sub SetList(Builder As IListBuilder)
    Sub SetItemCount(Count As Integer)
    Sub SetActionPanel(ActionPanel As IActionPanelBuildable)
    'Sub SetFilterPanel(FilterPanelBuilder As IFilterPanelBuildable)

    Event RaiseSelectListItem As SelectListItemHandler
    Event RaiseOpenListItem As OpenListItemHandler
    Event RaiseQuickSearch As QuickSearchHandler
    Event RaiseRefreshList As RefreshHandler
    Event RaiseExportList As ExportHandler
    Event RaiseListChange As ListChangeHandler

End Interface