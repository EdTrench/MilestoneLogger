<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonView
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
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.cboTitle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkSave = New System.Windows.Forms.LinkLabel()
        Me.lnkRemove = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(115, 69)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(283, 20)
        Me.txtFirstname.TabIndex = 0
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(116, 95)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(281, 20)
        Me.txtSurname.TabIndex = 1
        '
        'dtpDOB
        '
        Me.dtpDOB.Location = New System.Drawing.Point(116, 121)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(200, 20)
        Me.dtpDOB.TabIndex = 2
        '
        'cboTitle
        '
        Me.cboTitle.FormattingEnabled = True
        Me.cboTitle.Location = New System.Drawing.Point(116, 42)
        Me.cboTitle.Name = "cboTitle"
        Me.cboTitle.Size = New System.Drawing.Size(94, 21)
        Me.cboTitle.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Title:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Firstname:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Surname:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "DOB:"
        '
        'lnkSave
        '
        Me.lnkSave.AutoSize = True
        Me.lnkSave.Location = New System.Drawing.Point(497, 24)
        Me.lnkSave.Name = "lnkSave"
        Me.lnkSave.Size = New System.Drawing.Size(32, 13)
        Me.lnkSave.TabIndex = 8
        Me.lnkSave.TabStop = True
        Me.lnkSave.Text = "Save"
        '
        'lnkRemove
        '
        Me.lnkRemove.AutoSize = True
        Me.lnkRemove.Location = New System.Drawing.Point(497, 37)
        Me.lnkRemove.Name = "lnkRemove"
        Me.lnkRemove.Size = New System.Drawing.Size(47, 13)
        Me.lnkRemove.TabIndex = 9
        Me.lnkRemove.TabStop = True
        Me.lnkRemove.Text = "Remove"
        '
        'lnkNew
        '
        Me.lnkNew.AutoSize = True
        Me.lnkNew.Location = New System.Drawing.Point(497, 50)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(29, 13)
        Me.lnkNew.TabIndex = 10
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "New"
        '
        'PersonView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 212)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkRemove)
        Me.Controls.Add(Me.lnkSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTitle)
        Me.Controls.Add(Me.dtpDOB)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.txtFirstname)
        Me.Name = "PersonView"
        Me.Text = "Person"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFirstname As System.Windows.Forms.TextBox
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents dtpDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lnkSave As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRemove As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel

End Class
