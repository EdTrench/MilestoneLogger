Public Class MainFormListViewView
    Implements IMainFormListViewView
#Region "Event & handlers"

    Public Event RaiseExportList() Implements IMainFormListViewView.RaiseExportList
    Public Event RaiseRefreshList() Implements IMainFormListViewView.RaiseRefreshList
    Public Event RaiseSelectListItem(id As Integer) Implements IMainFormListViewView.RaiseSelectListItem
    Public Event RaiseQuickSearch(SearchString As String) Implements IMainFormListViewView.RaiseQuickSearch
    Public Event RaisePageChange(PageNumber As Integer) Implements IMainFormListViewView.RaisePageChange

    Private Sub RegisterHandlers()
        AddHandler QuickSearchButton.Click, AddressOf QuickSearch
        AddHandler ToolStripButtonRefresh.Click, AddressOf RefreshView
        AddHandler ToolStripButtonExport.Click, AddressOf ExportView
        AddHandler MainFormListView.MouseDoubleClick, AddressOf SelectListViewItem
        AddHandler MainFormListViewPageControl.PageForward.Click, AddressOf PageNext
        AddHandler MainFormListViewPageControl.PageBack.Click, AddressOf PagePrevious
        AddHandler QuickSearchCueTextBox.KeyUp, AddressOf KeyPressUp
    End Sub

    Private Sub QuickSearch(sender As System.Object, e As System.EventArgs)
        RaiseEvent RaiseQuickSearch(QuickSearchCueTextBox.Text)
    End Sub

    Private Sub RefreshView(sender As System.Object, e As System.EventArgs)
        RaiseEvent RaiseRefreshList()
    End Sub

    Private Sub ExportView(sender As System.Object, e As System.EventArgs)
        RaiseEvent RaiseExportList()
    End Sub

    Private Sub SelectListViewItem(sender As System.Object, e As System.EventArgs)
        Dim Id = CInt(MainFormListView.SelectedItems(0).Text)
        If Id <> 0 Then RaiseEvent RaiseSelectListItem(Id)
    End Sub

    Private Sub PageNext(sender As System.Object, e As System.EventArgs)
        If PageNumber < MaxPages() Then
            PageNumber += 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub PagePrevious(sender As System.Object, e As System.EventArgs)
        If PageNumber > 1 Then
            PageNumber -= 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub KeyPressUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then QuickSearch(sender, e)
    End Sub

#End Region

#Region "Public Methods"

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
        UpdateListCount()
        MainListViewToolStripStatusLabel.Text = String.Format("{0} Item(s)", value)
        SetPageDisplay()
    End Sub

    Public Sub SetList(Builder As IListBuilder) Implements IMainFormListViewView.SetList
        Builder.BuildListView(MainFormListView)
    End Sub

    Public Sub ResetPageNumber() Implements IMainFormListViewView.ResetPageNumber
        PageNumber = 1
        ChangePageNumber()
    End Sub

#Region "Action Panel"

    Private m_currentActionPanelBuilder As IActionPanelBuildable

    Public Sub SetActionPanel(actionPanelBuilder As IActionPanelBuildable) Implements IMainFormListViewView.SetActionPanel

        If actionPanelBuilder Is Nothing Then
            MainListViewSplitContainer.Panel2Collapsed = True
        Else
            m_currentActionPanelBuilder = actionPanelBuilder
            BuildActionPanel()
        End If
    End Sub

    Private Sub BuildActionPanel()
        m_currentActionPanelBuilder.BuildActionPanel(MainFormActionPanel)
    End Sub

#End Region

#Region "Filter Panel"

    Private m_currentFilterPanelBuilder As IFilterPanelBuildable

    Public Sub SetFilterPanel(filterPanelBuilder As IFilterPanelBuildable) Implements IMainFormListViewView.SetFilterPanel

        If filterPanelBuilder Is Nothing Then
            MainListViewSplitContainer.Panel2Collapsed = True
        Else
            m_currentFilterPanelBuilder = filterPanelBuilder
            BuildFilterPanel()
        End If

    End Sub

    Private Sub BuildFilterPanel()
        m_currentFilterPanelBuilder.BuildFilterPanel(MainFormFilterPanel)
    End Sub

#End Region

#End Region

#Region "Private Methods"

    Private IsPaged As Boolean = True
    Private PageNumber As Integer = 1
    Private ItemCount As Integer

    Private Sub ChangePageNumber()
        RaiseEvent RaisePageChange(PageNumber)
        SetPageDisplay()
    End Sub

    Private Sub UpdateListCount()
        If IsPaged Then
            SetPageDisplay()
        Else
            ItemCount = MainFormListView.Items.Count
        End If

        MainListViewToolStripStatusLabel.Text = String.Format("{0} Item(s)", ItemCount)
    End Sub

    Private Sub SetPageDisplay()
        If MaxPages() > 1 Then
            MainFormListViewPageControl.lblPagetext.Text = String.Format("{0}/{1}",
                                                                         PageNumber.ToString,
                                                                         MaxPages)
        Else
            MainFormListViewPageControl.Visible = False
        End If
    End Sub

    Private Function MaxPages() As Integer
        Return Convert.ToInt32(Math.Ceiling(ItemCount / 50))
    End Function

#End Region

End Class