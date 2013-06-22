Class PersonActionPanelBuilder
    Implements IActionPanelBuildable

    Private m_personService As New PersonService

    Public Sub BuildActionPanel(target As ActionPanel) Implements IActionPanelBuildable.BuildActionPanel
        Dim ActionCommandGroup = New CommandGroup("Person Actions")
        ActionCommandGroup.Commands.Add(New LinkLabelCommand("Open", Sub() OpenPerson()))
        ActionCommandGroup.Commands.Add(New LinkLabelCommand("Remove", Sub() RemovePerson()))
        target.RegisterCommandGroup(ActionCommandGroup)
        target.Initialise()
        target.BuildActionPanelCompenetents()
    End Sub

    Private Sub OpenPerson()
        Throw New NotImplementedException
    End Sub

    Private Sub RemovePerson()
        Throw New NotImplementedException
    End Sub

End Class
