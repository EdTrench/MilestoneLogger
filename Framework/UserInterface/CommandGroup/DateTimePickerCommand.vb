Public Class DateTimePickerCommand
    Implements ICommand

    Public Property ActionText As String
    Public Property AssociatedControl As System.Windows.Forms.Control Implements ICommand.AssociatedControl
    Private m_dateTimePicker As New DateTimePicker

    Public Delegate Sub MonthCalendarCommandEventHandler(sender As Object, Args As EventArgs)
    Public Event OnChange As MonthCalendarCommandEventHandler

    Public Sub New(ActionText As String)
        Me.ActionText = ActionText
    End Sub

    Public Sub CreateCommand(target As System.Windows.Forms.TableLayoutPanel) Implements ICommand.CreateCommand
        With target

            With m_dateTimePicker
                .Format = DateTimePickerFormat.Short
                .Anchor = AnchorStyles.Left
            End With

            AddHandler m_dateTimePicker.ValueChanged, AddressOf DateTimePickerValueChanged

            'Link control to command to allow caller to manipulate control
            AssociatedControl = m_dateTimePicker

            .Controls.Add(m_dateTimePicker, 1, .RowCount - 1)
            .RowCount += 1

        End With
    End Sub

    Private Sub DateTimePickerValueChanged(sender As Object, e As EventArgs)
        'RaiseEvent OnChange(Me, New EventArgs With {
        '                     = m_monthCalendar.Text})
    End Sub
End Class