<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageControl
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
        Me.PageBack = New System.Windows.Forms.PictureBox()
        Me.PageForward = New System.Windows.Forms.PictureBox()
        Me.lblPagetext = New System.Windows.Forms.Label()
        CType(Me.PageBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PageForward, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PageBack
        '
        Me.PageBack.Image = My.Resources.Resources.LeftSmall
        Me.PageBack.Location = New System.Drawing.Point(2, 2)
        Me.PageBack.Name = "PageBack"
        Me.PageBack.Size = New System.Drawing.Size(16, 16)
        Me.PageBack.TabIndex = 0
        Me.PageBack.TabStop = False
        '
        'PageForward
        '
        Me.PageForward.Image = My.Resources.Resources.RightSmall
        Me.PageForward.Location = New System.Drawing.Point(21, 2)
        Me.PageForward.Name = "PageForward"
        Me.PageForward.Size = New System.Drawing.Size(16, 16)
        Me.PageForward.TabIndex = 1
        Me.PageForward.TabStop = False
        '
        'lblPagetext
        '
        Me.lblPagetext.AutoSize = True
        Me.lblPagetext.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagetext.Location = New System.Drawing.Point(42, 3)
        Me.lblPagetext.Name = "lblPagetext"
        Me.lblPagetext.Size = New System.Drawing.Size(39, 13)
        Me.lblPagetext.TabIndex = 2
        Me.lblPagetext.Text = "Page 1"
        '
        'PageControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPagetext)
        Me.Controls.Add(Me.PageForward)
        Me.Controls.Add(Me.PageBack)
        Me.Name = "PageControl"
        Me.Size = New System.Drawing.Size(87, 22)
        CType(Me.PageBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PageForward, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PageBack As System.Windows.Forms.PictureBox
    Friend WithEvents PageForward As System.Windows.Forms.PictureBox
    Friend WithEvents lblPagetext As System.Windows.Forms.Label

End Class
