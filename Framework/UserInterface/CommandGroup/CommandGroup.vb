Public NotInheritable Class CommandGroup

    Public Property Headertext As String
    Public Property HeaderControl As Control
    Public Property HeadSeperatorControl As Control
    Public Property EndSeperatorControl As Control
    Public Property Collapsible As Boolean
    Private Expand As Boolean = True
    Private pbCollapase As PictureBox
    Private m_commands As New List(Of ICommand)

    Public ReadOnly Property Commands As IList
        Get
            Return m_commands
        End Get
    End Property

    Public Sub New(header As String, Optional collapsible As Boolean = True)
        Me.Collapsible = collapsible
        Headertext = header
    End Sub

    Public Sub SetVisible(Visiblity As Boolean)
        For Each c In m_commands
            c.AssociatedControl.Visible = Visiblity
        Next
        HeaderControl.Visible = Visiblity
        EndSeperatorControl.Visible = Visiblity
        pbCollapase.Visible = Visiblity
    End Sub

    Public Sub SetEnabled(Enabled As Boolean)
        For Each c As ICommand In m_commands
            c.AssociatedControl.Enabled = Enabled
        Next
        HeaderControl.Enabled = Enabled
        HeadSeperatorControl.Enabled = Enabled
        EndSeperatorControl.Enabled = Enabled
    End Sub

    Public Sub CreateCommandPanel(ByVal Panel As TableLayoutPanel)
        With Panel

            .ColumnCount += 1

            If Collapsible Then
                pbCollapase = CreateCollapseCommand()

                AddHandler pbCollapase.Click, AddressOf ToggleCollapaseClick

                .Controls.Add(pbCollapase, 2, .RowCount)
            End If

            If Headertext IsNot Nothing OrElse Headertext.Length > 1 Then
                Dim header As New Label() With {
                    .Text = Headertext,
                    .Anchor = AnchorStyles.Left,
                    .ForeColor = Color.DimGray,
                    .Font = New Font(Panel.Parent.Font.FontFamily,
                                     Panel.Parent.Font.Size,
                                     FontStyle.Bold)}

                HeaderControl = header

                .RowCount += 1
                .Controls.Add(header, 1, .RowCount - 1)
                .RowCount += 1
            End If

            For Each c As ICommand In Commands
                c.CreateCommand(Panel)
            Next

            'Seperator bar
            Dim EndSeperator As Label = CreateSeperator()
            EndSeperatorControl = EndSeperator
            .RowCount += 1
            .Controls.Add(EndSeperator, 1, .RowCount - 1)
            .SetColumnSpan(EndSeperator, 2)

            For Each r As RowStyle In .RowStyles
                r.SizeType = SizeType.AutoSize
            Next

            'Add superfluous row to autosize
            .RowCount += 1
        End With
    End Sub

    Private Function CreateSeperator() As Label
        Return New Label() With {
            .Anchor = AnchorStyles.Left Or AnchorStyles.Right,
            .AutoSize = False,
            .Height = 2,
            .BorderStyle = BorderStyle.Fixed3D,
            .Margin = New Padding(3, 0, 5, 4)}
    End Function

    Private Function CreateCollapseCommand() As PictureBox
        Return New PictureBox With {
            .Anchor = AnchorStyles.Right,
            .Height = 13,
            .Width = 13,
            .Image = My.Resources.Collapse}
    End Function

    Private Sub SetExpand(x As Boolean)
        Expand = x
        For Each c As ICommand In Commands
            c.AssociatedControl.Visible = x
        Next
    End Sub

    Private Sub ToggleCollapaseClick(sender As Object, e As System.EventArgs)
        If Expand Then
            SetExpand(False)
            pbCollapase.Image = My.Resources.Expand
        Else
            SetExpand(True)
            pbCollapase.Image = My.Resources.Collapse
        End If
    End Sub
End Class
