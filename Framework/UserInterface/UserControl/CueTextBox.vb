Imports System.Runtime.InteropServices

Public Class CueTextBox

#Region "Win32"
    Private Const EM_SETCUEBANNER As Integer = &H1501

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
    End Function
#End Region

    Private m_cue As String
    Public Property Cue As String
        Get
            Return m_cue
        End Get
        Set(ByVal value As String)
            If value <> m_cue Then
                m_cue = value
                SendMessage(Me.Handle, EM_SETCUEBANNER, New System.IntPtr(1), m_cue)
            End If
        End Set
    End Property

    Private Sub CueTextBox_TextChanged(sender As Object, e As System.EventArgs) Handles Me.TextChanged
        'Remove Italics
        If Not String.IsNullOrWhiteSpace(Me.Text) Then
            Me.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)

        Else
            Me.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Italic)
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If

        MyBase.OnKeyPress(e)

    End Sub
End Class
