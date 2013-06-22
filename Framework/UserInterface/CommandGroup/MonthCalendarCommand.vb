Public Class MonthCalendarCommand
        Implements ICommand

    Public Property ActionText As String
    Public Property AssociatedControl As System.Windows.Forms.Control Implements ICommand.AssociatedControl
    Private m_monthCalendar As New MonthCalendar

    Public Delegate Sub MonthCalendarCommandEventHandler(sender As Object, Args As EventArgs)
    Public Event OnChange As MonthCalendarCommandEventHandler

    Public Sub New(ActionText As String)
        Me.ActionText = ActionText
    End Sub

    Public Sub CreateCommand(target As System.Windows.Forms.TableLayoutPanel) Implements ICommand.CreateCommand
        With target

            With m_monthCalendar
                .Text = ActionText
                .AutoSize = True
                .Anchor = AnchorStyles.Left
            End With

            AddHandler m_monthCalendar.DateChanged, AddressOf MonthCalendarDateChanged

            'Link control to command to allow caller to manipulate control
            AssociatedControl = m_monthCalendar

            .Controls.Add(m_monthCalendar, 1, .RowCount - 1)
            .RowCount += 1

        End With
    End Sub

    Private Sub MonthCalendarDateChanged(sender As Object, e As EventArgs)
        'RaiseEvent OnChange(Me, New EventArgs With {
        '                     = m_monthCalendar.Text})
    End Sub
End Class