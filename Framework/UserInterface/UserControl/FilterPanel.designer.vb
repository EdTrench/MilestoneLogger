<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterPanel
    Inherits System.Windows.Forms.UserControl

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlpClosePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpActions = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlpClosePanel)
        Me.Panel1.Controls.Add(Me.tlpActions)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(137, 193)
        Me.Panel1.TabIndex = 0
        '
        'tlpClosePanel
        '
        Me.tlpClosePanel.ColumnCount = 2
        Me.tlpClosePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67883!))
        Me.tlpClosePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.32117!))
        Me.tlpClosePanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpClosePanel.Location = New System.Drawing.Point(0, 138)
        Me.tlpClosePanel.MaximumSize = New System.Drawing.Size(0, 55)
        Me.tlpClosePanel.MinimumSize = New System.Drawing.Size(0, 55)
        Me.tlpClosePanel.Name = "tlpClosePanel"
        Me.tlpClosePanel.RowCount = 1
        Me.tlpClosePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpClosePanel.Size = New System.Drawing.Size(137, 55)
        Me.tlpClosePanel.TabIndex = 1
        '
        'tlpActions
        '
        Me.tlpActions.ColumnCount = 2
        Me.tlpActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67883!))
        Me.tlpActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.32117!))
        Me.tlpActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpActions.Location = New System.Drawing.Point(0, 0)
        Me.tlpActions.Name = "tlpActions"
        Me.tlpActions.RowCount = 1
        Me.tlpActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpActions.Size = New System.Drawing.Size(137, 130)
        Me.tlpActions.TabIndex = 0
        '
        'ActionPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ActionPanel"
        Me.Size = New System.Drawing.Size(137, 193)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlpActions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpClosePanel As System.Windows.Forms.TableLayoutPanel

End Class
