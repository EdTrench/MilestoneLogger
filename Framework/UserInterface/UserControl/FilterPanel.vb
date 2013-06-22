Public Class FilterPanel

    Private CommandGroups As IList(Of CommandGroup)
    Private CloseCommandGroup As CommandGroup
    Private Collapsible As Boolean = True
    Private HasCloseButton As Boolean = False

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        CommandGroups = New List(Of CommandGroup)
    End Sub

    Public Sub Initialise(Optional HasCloseButton As Boolean = False)
        Me.HasCloseButton = HasCloseButton
        If HasCloseButton Then CloseCommandGroup = New CommandGroup("", False)
    End Sub

    Public Sub BuildActionPanelCompenetents()
        For Each cg In CommandGroups
            cg.CreateCommandPanel(tlpActions)
        Next
        If HasCloseButton Then BuildCloseLabel()
    End Sub

    Public Sub RegisterCommandGroup(CommandGroup As CommandGroup)
        CommandGroups.Add(CommandGroup)
    End Sub

    Private Sub BuildCloseLabel()
        CloseCommandGroup.Commands.Add(New LinkLabelCommand With {.ActionText = "Close", .Action = Sub() CloseForm()})
        CloseCommandGroup.CreateCommandPanel(tlpClosePanel)
    End Sub

    Private Sub CloseForm()
        ParentForm.Close()
    End Sub

End Class
