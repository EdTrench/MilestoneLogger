Public NotInheritable Class CheckBoxCommand
    Implements ICommand

    Public Property ActionText As String
    Public Property AssociatedControl As System.Windows.Forms.Control Implements ICommand.AssociatedControl
    Private CheckBox As New CheckBox

    Public Delegate Sub CheckboxCommandEventHandler(sender As Object, Args As CheckboxCommandEventArgs)
    Public Event OnChange As CheckboxCommandEventHandler

    Public Sub New(ActionText As String, Checked As Boolean)
        Me.ActionText = ActionText
        Me.CheckBox.Checked = Checked
    End Sub

    Public Sub CreateCommand(target As System.Windows.Forms.TableLayoutPanel) Implements ICommand.CreateCommand
        With target

            With CheckBox
                .Text = ActionText
                .AutoSize = True
                .Anchor = AnchorStyles.Left
            End With

            AddHandler CheckBox.CheckedChanged, AddressOf CheckBoxChanged

            'Link control to command to allow caller to manipulate control
            AssociatedControl = CheckBox

            .Controls.Add(CheckBox, 1, .RowCount - 1)
            .RowCount += 1

        End With
    End Sub

    Private Sub CheckBoxChanged(sender As Object, e As EventArgs)
        RaiseEvent OnChange(Me, New CheckboxCommandEventArgs With {
                            .Text = CheckBox.Text,
                            .Value = CheckBox.Checked})
    End Sub

End Class

Public NotInheritable Class CheckboxCommandEventArgs
    Inherits EventArgs
    Public Text As String
    Public Value As Boolean
End Class
