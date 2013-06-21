Imports System.Runtime.InteropServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtendedListView
    Inherits System.Windows.Forms.ListView

    <DllImport("uxtheme.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)> _
    Private Shared Function SetWindowTheme(hWnd As IntPtr, pszSubAppName As [String], pszSubIdList As [String]) As Integer
    End Function

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ExtendedListView
        '
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.DoubleBuffered = True
    End Sub


End Class
