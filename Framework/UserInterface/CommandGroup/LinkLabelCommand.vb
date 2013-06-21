
Public NotInheritable Class LinkLabelCommand
    Implements ICommand

    Public Property ActionText As String
    Public Property Action As Action
    Public Property Image As Bitmap
    Public Property CommandImage As PictureBox
    Public Property AssociatedControl As Control Implements ICommand.AssociatedControl

    Public Property SubControls As New List(Of Control)
    Public Sub New()
        'Default Constuctor
    End Sub

    Public Sub New(ByVal ActionText As String)
        Me.ActionText = ActionText
    End Sub

    Public Sub New(ByVal ActionText As String,
                   ByVal action As Action)
        Me.ActionText = ActionText
        Me.Action = action
    End Sub

    Public Sub New(ByVal ActionText As String,
                   ByVal action As Action,
                   ByVal image As Bitmap)
        Me.ActionText = ActionText
        Me.Image = image
        Me.Action = action
    End Sub

    Public Sub CreateCommand(Panel As TableLayoutPanel) Implements ICommand.CreateCommand

        With Panel

            For Each sc In SubControls
                .Controls.Add(sc, 1, .RowCount - 1)
                .RowCount += 1
            Next

            Dim commandText As New LinkLabel() With {
                .Text = ActionText,
                .AutoSize = True,
                .Anchor = AnchorStyles.Left,
                .LinkColor = Color.SteelBlue,
                .LinkBehavior = LinkBehavior.HoverUnderline}
            AddHandler commandText.Click, AddressOf Execute

            'Link control to command to allow caller to manipulate control
            AssociatedControl = commandText

            If Image IsNot Nothing Then
                CommandImage = New PictureBox
                CommandImage.Image = Image
                CommandImage.Anchor = AnchorStyles.Left
                CommandImage.SizeMode = PictureBoxSizeMode.AutoSize
                .Controls.Add(CommandImage, 0, .RowCount - 1)
                AddHandler CommandImage.MouseHover, AddressOf MouseHover
                AddHandler CommandImage.Click, AddressOf Execute
            End If
            .Controls.Add(commandText, 1, .RowCount - 1)
            .RowCount += 1

        End With

    End Sub

    Public Sub MouseHover(sender As Object, e As System.EventArgs)
        Cursor.Current = Cursors.Hand
        SubControls = New List(Of Control)
    End Sub

    Public Sub Execute(sender As Object, e As System.EventArgs)
        If Action IsNot Nothing Then Action.Invoke()
    End Sub

End Class
