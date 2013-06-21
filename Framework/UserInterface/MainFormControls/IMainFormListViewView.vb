
Public Delegate Sub SelectListItemItemHandler(id As Integer)
Public Delegate Sub QuickSearchHandler(SearchString As String)
Public Delegate Sub RefreshHandler()
Public Delegate Sub ExportHandler()
Public Delegate Sub PageChangeHandler(PageNumber As Integer)

Public Interface IMainFormListViewView

    Property NavigationIcon As Image
    Property NavigationDescription As String
    Property NavigationTitle As String

    Sub ResetPageNumber()
    Sub SetList(Builder As IListBuilder)
    Sub SetItemCount(Count As Integer)
    Sub SetActionPanel(x As IActionPanelBuildable)

    Event RaiseSelectListItem As SelectListItemItemHandler
    Event RaiseQuickSearch As QuickSearchHandler
    Event RaiseRefreshList As RefreshHandler
    Event RaiseExportList As ExportHandler
    Event RaisePageChange As PageChangeHandler

End Interface

