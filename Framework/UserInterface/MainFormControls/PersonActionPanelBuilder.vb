Class PersonActionPanelBuilder
    Implements IActionPanelBuildable

    Private m_personService As New PersonService

    Public Sub BuildActionPanel(Target As ActionPanel) Implements IActionPanelBuildable.BuildActionPanel
        Dim ActionCommandGroup = New CommandGroup("Person Actions")
        ActionCommandGroup.Commands.Add(New LinkLabelCommand("Save", Sub() Save(New Person)))
        Target.RegisterCommandGroup(ActionCommandGroup)
        Target.Initialise()
        Target.BuildActionPanelCompenetents()
    End Sub

    Private Sub Save(person As Person)
        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            m_personService.Save(person, session)
        End Using
    End Sub
End Class
