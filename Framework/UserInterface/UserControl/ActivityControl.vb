Public Class ActivityControl

    Private CurrentCentre As Centre
    Private Activitys As List(Of Activity)
    Private ActivityController As ActivityController = New ActivityController()
    Private ActionPanel As CommandGroup = New CommandGroup("Centre Activivty")

    Public Sub Initialise(Centre As Centre)

        CurrentCentre = Centre
        ActivityController.Install()

        RefreshActionPanel()
        RefreshList()

        ELVActivities.SortMode = ListViewSortMode.Group

    End Sub

    Private Sub RefreshList()

        Dim CountOfActivities As Integer

        ClearListView()
        AddColumns()

        ELVActivities.BeginUpdate()

        Activitys = ActivityController.GetData(CurrentCentre.Id)

        For Each item In Activitys
            Dim NewListItem As New ListViewItem With {.Text = item.Text,
                                                      .Name = item.NavigationText,
                                                      .Tag = item.EntityId.ToString}
            If item.User Is Nothing Then
                NewListItem.SubItems.Add("n/a")
            Else
                NewListItem.SubItems.Add(item.User.ToString)
            End If

            If item.ActionDate.HasValue Then
                NewListItem.SubItems.Add(item.ActionDate.Value.ToString("dd-MMM-yy"))
            Else
                NewListItem.SubItems.Add("n/a")
            End If

            ELVActivities.Items.Add(NewListItem)

            CountOfActivities += 1
        Next

        ToolStripStatusLabel1.Text = String.Format("{0} Item(s)", CountOfActivities)

        ELVActivities.EndUpdate()

    End Sub

    Private Sub RefreshActionPanel()
        AddTo(tlp)
    End Sub

    Private Sub CheckedChanged(sender As Object, e As CheckboxCommandEventArgs)
        ActivityController.GetByName(e.Text).First.Visible = e.Value
        RefreshList()
    End Sub

    Private Sub AddColumns()
        ELVActivities.Columns.Add("Description", 450)
        ELVActivities.Columns.Add("Administrator", 150)
        ELVActivities.Columns.Add("Date", 100)
    End Sub

    Private Sub ClearListView()
        ELVActivities.Columns.Clear()
        ELVActivities.Items.Clear()
    End Sub

    Private Sub ListViewClick(sender As Object, e As MouseEventArgs) Handles ELVActivities.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim SelectedItem = ELVActivities.SelectedItems(0)

            Dim b = ActivityController.GetByName(SelectedItem.Name.ToString)
            If b IsNot Nothing Then
                Dim menu = New ContextMenuStrip()
                menu.Items.Add(New ToolStripMenuItem() With {.Text = b.First().ContextMenuText,
                                                             .Tag = SelectedItem.Tag})
                AddHandler menu.ItemClicked, AddressOf OnContextMenuItemClick
                menu.Show(DirectCast(sender, Control), e.Location)

            End If
        End If
    End Sub

    Public Sub OnContextMenuItemClick(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        'Hide context menu otherwise it's still visible during actions
        e.ClickedItem.Owner.Visible = False

        Dim SelectedItem = ELVActivities.SelectedItems(0)
        Dim Builder = ActivityController.GetByName(SelectedItem.Name.ToString).First()

        Select Case e.ClickedItem.Text
            Case Builder.ContextMenuText
                If Builder.ContextMenuText = "Open Event" Then
                    Dim form = New EventDialog
                    'need to get by type [Event]???? how to do this by type
                    form.ShowForUpdate([Event].GetById(Convert.ToInt32(SelectedItem.Tag)))
                End If
        End Select

    End Sub

    Private Sub AddTo(tlp As TableLayoutPanel)

        tlp.Controls.Clear()

        For Each Group In (From I In ActivityController.InstalledActivityBuilders
                   Select I.Grouping).Distinct()

            Dim GroupEnum = Group
            Dim GroupText = EnumHelper.GetEnumDescription(Group)
            Dim GroupCommand = New CommandGroup(GroupText)

            For Each n In (From I In ActivityController.InstalledActivityBuilders
                           Where I.Grouping = GroupEnum
                           Select I)
                Dim c = New CheckBoxCommand(n.NavigationText, n.Visible)

                AddHandler c.OnChange, AddressOf CheckedChanged
                GroupCommand.Commands.Add(c)
            Next
            GroupCommand.CreateCommandPanel(tlp)
        Next
    End Sub

    'Private Sub HandleNodeChecked(ParentNode As TreeNode)

    '    ActivityController.GetByName(ParentNode.Text).First().Visible = ParentNode.Checked

    '    'Casade checked to children
    '    If ParentNode.Nodes.Count > 0 Then
    '        For Each SubNode As TreeNode In ParentNode.Nodes
    '            SubNode.Checked = ParentNode.Checked
    '            ActivityController.GetByName(SubNode.Text).First().Visible = ParentNode.Checked
    '        Next
    '    End If
    'End Sub

End Class
