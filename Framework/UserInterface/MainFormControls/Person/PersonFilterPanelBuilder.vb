Public Class PersonFilterPanelBuilder
    Implements IFilterPanelBuildable

    Private m_personService As New PersonService

    Public Sub BuildActionPanel(target As FilterPanel) Implements IFilterPanelBuildable.BuildFilterPanel
        Dim ActionCommandGroup = New CommandGroup("Person Filter")
        ActionCommandGroup.Commands.Add(New CheckBoxCommand("Date of Birth", False))
        ActionCommandGroup.Commands.Add(New DateTimePickerCommand("Date Time Picker From"))
        ActionCommandGroup.Commands.Add(New DateTimePickerCommand("Date Time Picker To"))
        ActionCommandGroup.Commands.Add(New LinkLabelCommand("Apply Filter", Sub() ApplyFilter()))
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

    Private Sub ApplyFilter()
        Throw New NotImplementedException
    End Sub

End Class
