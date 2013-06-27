Class PersonActionPanelBuilder
    Implements IActionPanelBuildable

    Private m_target As ActionPanel
    Private m_actionCommandGroup As CommandGroup
    Private m_selectedIds As New List(Of Integer)
    Private m_service As PersonService

    Public Sub New()
        m_service = New PersonService()
    End Sub

    Public Sub New(ids As System.Collections.Generic.List(Of Integer))
        Me.New()
        m_selectedIds = ids
    End Sub

    Public Sub BuildActionPanel(Target As ActionPanel) Implements IActionPanelBuildable.BuildActionPanel
        m_target = Target
        Initialise()
    End Sub

    Private Sub Initialise()
        Dim ActionCommandGroup = New CommandGroup("Event Types")
        If m_selectedIds.Count = 1 Then ActionCommandGroup.Commands.Add(New LinkLabelCommand("Open", Sub() Open()))
        If m_selectedIds.Count = 1 Then ActionCommandGroup.Commands.Add(New LinkLabelCommand("Remove", Sub() Remove()))
        ActionCommandGroup.Commands.Add(New LinkLabelCommand("New", Sub() Create()))
        m_actionCommandGroup = ActionCommandGroup
        m_target.ClearActionPanelComponents()
        m_target.RegisterCommandGroup(m_actionCommandGroup)
        m_target.BuildActionPanelComponents()
    End Sub

    Private Sub Open()
        m_service.Open(m_selectedIds.First())
    End Sub

    Private Sub Remove()
        m_service.Remove(m_selectedIds.First())
    End Sub

    Private Sub Create()
        m_service.Open()
    End Sub

End Class
