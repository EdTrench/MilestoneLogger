<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonListView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.MainFormListViewView = New MilestoneLogger.MainFormListViewView()
        Me.SuspendLayout()
        '
        'MainFormListViewView
        '
        Me.MainFormListViewView.Location = New System.Drawing.Point(13, 13)
        Me.MainFormListViewView.Name = "MainFormListViewView"
        Me.MainFormListViewView.NavigationDescription = "Helpful description for this feature goes here."
        Me.MainFormListViewView.NavigationIcon = Nothing
        Me.MainFormListViewView.NavigationTitle = "[lblNavigationTitle]"
        Me.MainFormListViewView.Size = New System.Drawing.Size(683, 395)
        Me.MainFormListViewView.TabIndex = 0
        '
        'PersonListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 421)
        Me.Controls.Add(Me.MainFormListViewView)
        Me.Name = "PersonListView"
        Me.Text = "Person List View"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainFormListViewView As MilestoneLogger.MainFormListViewView
End Class
