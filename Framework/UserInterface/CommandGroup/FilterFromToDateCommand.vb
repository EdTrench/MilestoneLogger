Public Class FilterFromToDateCommand
    Implements ICommand

    Public Property AssociatedControl As Control Implements ICommand.AssociatedControl
    Public Property ActionText As String
    Private m_fromdateTimePicker As New DateTimePicker
    Private m_toDateTimePicker As New DateTimePicker
    Private m_propertyCheckBox As New CheckBox
    Private m_applyFilterLinkLabelCommand As New LinkLabelCommand()

    Public Sub CreateCommand(target As TableLayoutPanel) Implements ICommand.CreateCommand

        With target



        End With

    End Sub
End Class
