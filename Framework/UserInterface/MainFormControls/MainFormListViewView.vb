Imports System.Runtime.InteropServices

Public Class MainFormListViewView
    Implements IMainFormListViewView

#Region "Event & Handlers"

    Public Event RaiseExportList() Implements IMainFormListViewView.RaiseExportList
    Public Event RaiseRefreshList() Implements IMainFormListViewView.RaiseRefreshList
    Public Event RaiseQuickSearch(SearchString As String) Implements IMainFormListViewView.RaiseQuickSearch
    Public Event RaiseListChange(UserQuery As MainFormUserCriteria) Implements IMainFormListViewView.RaiseListChange
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

    Private Sub ListChange()
        RaiseEvent RaiseListChange(CurrentUserCriteria)
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

    Private Sub ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs)
        SelectListItem()
    End Sub

    Private Sub SelectViewItem(sender As System.Object, e As System.EventArgs)
        SelectListItem()
    End Sub

    Private Sub SelectListItem()
        Dim SelectedIds As New List(Of Integer)
        For Each item As ListViewItem In MainFormListView.SelectedItems
            SelectedIds.Add(Convert.ToInt32(item.Text))
        Next
        RaiseEvent RaiseSelectListItem(SelectedIds)
    End Sub

    Private Sub PageNext(sender As System.Object, e As System.EventArgs)
        If CurrentUserCriteria.CurrentPage < MaxPages() Then
            CurrentUserCriteria.CurrentPage += 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub PagePrevious(sender As System.Object, e As System.EventArgs)
        If CurrentUserCriteria.CurrentPage > 1 Then
            CurrentUserCriteria.CurrentPage -= 1
            ChangePageNumber()
        End If
    End Sub

    Private Sub KeyPressUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then QuickSearch(sender, e)
    End Sub

    Private Sub ColumnClick(sender As System.Object, e As ColumnClickEventArgs)
        CurrentUserCriteria.Orderedby = CurrentListBuilder.OrderBy(e.Column)
        If CurrentUserCriteria.SortOrder = Sort.Desc Then CurrentUserCriteria.SortOrder = Sort.Asc Else CurrentUserCriteria.SortOrder = Sort.Desc
        ListChange()
    End Sub

    Private Sub QuickSearch(sender As System.Object, e As System.EventArgs)
        CurrentUserCriteria.State = UserCriteriaState.QuickSearch
        CurrentUserCriteria.QuickSearch = QuickSearchCueTextBox.Text
        ListChange()
    End Sub

#End Region

#Region "Public Methods"

    Private CurrentListBuilder As IListBuilder

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        RegisterHandlers()
        SetListViewWatermark()
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
        CurrentUserCriteria.CurrentPage = 1
        ChangePageNumber()
    End Sub

#End Region

#Region "Private Methods"

    Private ItemCount As Integer

    Private Sub ChangePageNumber()
        SetPageDisplay()
        ListChange()
    End Sub

    Private Sub SetPageDisplay()
        If MaxPages() > 1 Then
            MainFormListViewPageControl.Visible = True
            MainFormListViewPageControl.lblPagetext.Text = String.Format("{0}/{1}",
                                                                         CurrentUserCriteria.CurrentPage.ToString,
                                                                         MaxPages)
        Else
            MainFormListViewPageControl.Visible = False
        End If
    End Sub

    Private Function MaxPages() As Integer
        If (ItemCount > 0) Then Return Convert.ToInt32(Math.Ceiling(ItemCount / 50)) Else Return Nothing
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

#Region "Filter Panel"

    Private CurrentFilterPanelBuilder As IFilterPanelBuildable

    'Public Sub SetFilterPanel(FilterPanelBuilder As IFilterPanelBuildable) Implements IMainFormListViewView.SetFilterPanel
    '    If FilterPanelBuilder Is Nothing Then
    '        ActionFilterSplitContainer.Panel2Collapsed = True
    '    Else
    '        CurrentFilterPanelBuilder = FilterPanelBuilder
    '        BuildFilterPanel()
    '    End If
    'End Sub

    'Private Sub BuildFilterPanel()
    '    CurrentFilterPanelBuilder.BuildFilterPanel(CurrentUserCriteria.CriteriaFilter, tlpFilter)
    '    AddHandler CurrentFilterPanelBuilder.RaiseUserCriteriaChange, AddressOf FilterSelectionChanged
    'End Sub

    Private Sub FilterSelectionChanged(UserCriteria As NHibernate.ICriteria)
        CurrentUserCriteria.State = UserCriteriaState.Criteria
        CurrentUserCriteria.CriteriaFilter = UserCriteria
        ListChange()
    End Sub

#End Region

    Private CurrentUserCriteria As MainFormUserCriteria

    Public Sub SetUserCriteria(UserCriteria As MainFormUserCriteria) Implements IMainFormListViewView.SetUserQuery
        CurrentUserCriteria = UserCriteria
    End Sub

    Private Sub SetListViewWatermark()
        'Const alphaValue As Int32 = 242

        'Dim watermark As Bitmap = Nothing
        'Dim alphaBitmap As Bitmap = Nothing
        'Dim g As Graphics = Nothing

        'Try
        '    watermark = My.Resources._Global.Watermark

        '    Dim lvImage As New Win32.LVBKIMAGE() With {.hbm = watermark.GetHbitmap()}

        '    Dim flags = Win32.LVBKIF_TYPE_WATERMARK Or Win32.LVBKIF_FLAG_ALPHABLEND
        '    lvImage.ulFlags = flags

        '    alphaBitmap = New Bitmap(watermark.Width, watermark.Height)

        '    g = Graphics.FromImage(alphaBitmap)
        '    g.Clear(MainFormListView.BackColor)
        '    g.DrawImage(watermark, 0, 0, alphaBitmap.Width, alphaBitmap.Height)
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(alphaValue, MainFormListView.BackColor.R, MainFormListView.BackColor.G, MainFormListView.BackColor.B)),
        '                                   New RectangleF(0, 0, alphaBitmap.Width, alphaBitmap.Height))

        '    lvImage.hbm = alphaBitmap.GetHbitmap

        '    Dim lvImageSize As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(lvImage))

        '    Marshal.StructureToPtr(lvImage, lvImageSize, False)

        '    Win32.SendMessage(MainFormListView.Handle, Win32.LVM_SETBKIMAGE, IntPtr.Zero, lvImageSize)
        '    Marshal.FreeCoTaskMem(lvImageSize)

        'Finally
        '    watermark.Dispose()
        '    alphaBitmap.Dispose()
        '    g.Dispose()
        'End Try

    End Sub
End Class