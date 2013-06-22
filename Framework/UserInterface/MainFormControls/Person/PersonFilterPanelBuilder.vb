Public Class PersonFilterPanelBuilder
    Implements IFilterPanelBuildable

    Private m_personService As New PersonService

    Public Sub BuildActionPanel(target As FilterPanel) Implements IFilterPanelBuildable.BuildFilterPanel
        Dim ActionCommandGroup = New CommandGroup("Person Filter")
        ActionCommandGroup.Commands.Add(New MonthCalendarCommand("Month Calendar 1"))
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
