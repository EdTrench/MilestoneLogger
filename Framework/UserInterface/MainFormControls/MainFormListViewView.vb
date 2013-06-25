Public Class MainFormListViewView
    Implements IMainFormListViewView


#Region "Event & Handlers"

    Public Event RaiseExportList() Implements IMainFormListViewView.RaiseExportList
    Public Event RaiseRefreshList() Implements IMainFormListViewView.RaiseRefreshList
    Public Event RaiseQuickSearch(SearchString As String) Implements IMainFormListViewView.RaiseQuickSearch
    Public Event RaiseListChange(UserQuery As MainFormUserQuery) Implements IMainFormListViewView.RaiseListChange
    Public Event RaiseOpenListItem(id As Integer) Implements IMainFormListViewView.RaiseOpenListItem
    Public Event RaiseSelectListItem(ids As System.Collections.Generic.List(Of Integer)) Implements IMainFormListViewView.RaiseSelectListItem

    Private Sub RegisterHandlers()
        AddHandler QuickSearchButton.Click, AddressOf QuickSearch
        AddHandler ToolStripButtonRefresh.Click, AddressOf RefreshView
        AddHandler ToolStripButtonExport.Click, AddressOf ExportView
        AddHandler MainFormListView.MouseDoubleClick, AddressOf OpenViewItem
        AddHandler MainFormListView.MouseClick, AddressOf SelectViewItem
        AddHandler MainFormListViewPageControl.PageForward.Click, AddressOf PageNext
        AddHandler MainFormListViewPageControl.PageBack.Click, AddressOf PagePrevious
        AddHandler QuickSearchCueTextBox.KeyUp, AddressOf KeyPressUp
        AddHandler MainFormListView.ColumnClick, AddressOf ColumnClick
        AddHandler MainFormListView.ItemSelectionChanged, AddressOf ItemSelectionChanged
    End Sub

    Private Sub QuickSearch(sender As System.Object, e As System.EventArgs)
        CurrentUserQuery.QuickSearch = QuickSearchCueTextBox.Text
        RaiseEvent RaiseListChange(CurrentUserQuery)
    End Sub

    Private Sub RefreshView(sender As System.Object, e As System.EventArgs)
        RaiseEvent RaiseRefreshList()
    End Sub

    Private Sub ExportView(sender As System.Object, e As System.EventArgs)
        RaiseEvent RaiseExportList()
    End Sub

    Private Sub OpenViewItem(sender As System.Object, e As System.EventArgs)
        Dim SelectedId = Convert.ToInt32(MainFormListView.SelectedItems(0).Text)
        If SelectedId <> 0 Then RaiseEvent RaiseOpenListItem(SelectedId)
    End Sub

    Private Sub SelectViewItem(sender As System.Object, e As System.EventArgs)
        Dim SelectedIds As New List(Of Integer)
        For Each item As ListViewItem In MainFormListView.SelectedItems
            SelectedIds.Add(Convert.ToInt32(item.Text))
        Next
        RaiseEvent RaiseSelectListItem(SelectedIds)
    End Sub

    Private Sub PageNext(sender As System.Object, e As System.EventArgs)
        If CurrentUserQuery.CurrentPage < MaxPages() Then
            CurrentUserQuery.CurrentPage += 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub PagePrevious(sender As System.Object, e As System.EventArgs)
        If CurrentUserQuery.CurrentPage > 1 Then
            CurrentUserQuery.CurrentPage -= 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub KeyPressUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then QuickSearch(sender, e)
    End Sub

    Private Sub ColumnClick(sender As System.Object, e As ColumnClickEventArgs)
        CurrentUserQuery.Orderedby = CurrentListBuilder.OrderBy(e.Column)
        If CurrentUserQuery.SortOrder = Sort.Desc Then CurrentUserQuery.SortOrder = Sort.Asc Else CurrentUserQuery.SortOrder = Sort.Desc
        RaiseEvent RaiseListChange(CurrentUserQuery)
    End Sub

    Private Sub ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs)
        Me.SelectViewItem(sender, e)
    End Sub

#End Region

#Region "Public Methods"

    Private CurrentListBuilder As IListBuilder

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        RegisterHandlers()
    End Sub

    Public Property NavigationIcon As Image Implements IMainFormListViewView.NavigationIcon
        Get
            Return MainFormIcon.Image
        End Get
        Set(ByVal value As Image)
            MainFormIcon.Image = value
        End Set
    End Property

    Public Property NavigationDescription As String Implements IMainFormListViewView.NavigationDescription
        Get
            Return lblNavigationDescription.Text
        End Get
        Set(ByVal value As String)
            lblNavigationDescription.Text = value
        End Set
    End Property

    Public Property NavigationTitle As String Implements IMainFormListViewView.NavigationTitle
        Get
            Return lblNavigationTitle.Text
        End Get
        Set(ByVal value As String)
            lblNavigationTitle.Text = value
        End Set
    End Property

    Public Sub SetItemCount(value As Integer) Implements IMainFormListViewView.SetItemCount
        ItemCount = value
        MainListViewToolStripStatusLabel.Text = String.Format("{0} Item(s)", value)
        SetPageDisplay()
    End Sub

    Public Sub SetList(Builder As IListBuilder) Implements IMainFormListViewView.SetList
        CurrentListBuilder = Builder
        Builder.BuildListView(MainFormListView)
    End Sub

    Public Sub ResetPageNumber() Implements IMainFormListViewView.ResetPageNumber
        CurrentUserQuery.CurrentPage = 1
        ChangePageNumber()
    End Sub

#End Region

#Region "Private Methods"

    Private ItemCount As Integer

    Private Sub ChangePageNumber()
        SetPageDisplay()
        RaiseEvent RaiseListChange(CurrentUserQuery)
    End Sub

    Private Sub SetPageDisplay()
        If MaxPages() > 1 Then
            MainFormListViewPageControl.lblPagetext.Text = String.Format("{0}/{1}",
                                                                         CurrentUserQuery.CurrentPage.ToString,
                                                                         MaxPages)
        Else
            MainFormListViewPageControl.Visible = False
        End If
    End Sub

    Private Function MaxPages() As Integer
        Return Convert.ToInt32(Math.Ceiling(ItemCount / 50))
    End Function

#End Region

#Region "Action Panel"

    Private CurrentActionPanelBuilder As IActionPanelBuildable

    Public Sub SetActionPanel(ActionPanelBuilder As IActionPanelBuildable) Implements IMainFormListViewView.SetActionPanel
        If ActionPanelBuilder Is Nothing Then
            MainListViewSplitContainer.Panel2Collapsed = True
        Else
            CurrentActionPanelBuilder = ActionPanelBuilder
            BuildActionPanel()
        End If
    End Sub

    Private Sub BuildActionPanel()
        CurrentActionPanelBuilder.BuildActionPanel(MainFormActionPanel)
    End Sub

#End Region

    Private CurrentUserQuery As MainFormUserQuery

    Public Sub SetUserQuery(UserQuery As MainFormUserQuery) Implements IMainFormListViewView.SetUserQuery
        CurrentUserQuery = UserQuery
    End Sub

End Class