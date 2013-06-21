<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivityControl
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
        Me.SSActivities = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSActivities = New System.Windows.Forms.ToolStrip()
        Me.SCActivities = New System.Windows.Forms.SplitContainer()
        Me.tlp = New System.Windows.Forms.TableLayoutPanel()
        Me.ELVActivities = New ASDAN.Athena.ExtendedListView()
        Me.SSActivities.SuspendLayout()
        CType(Me.SCActivities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCActivities.Panel1.SuspendLayout()
        Me.SCActivities.Panel2.SuspendLayout()
        Me.SCActivities.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSActivities
        '
        Me.SSActivities.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.SSActivities.Location = New System.Drawing.Point(0, 439)
        Me.SSActivities.Name = "SSActivities"
        Me.SSActivities.Size = New System.Drawing.Size(692, 22)
        Me.SSActivities.SizingGrip = False
        Me.SSActivities.TabIndex = 0
        Me.SSActivities.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(65, 17)
        Me.ToolStripStatusLabel1.Text = "TSSLCount"
        '
        'TSActivities
        '
        Me.TSActivities.Location = New System.Drawing.Point(0, 0)
        Me.TSActivities.Name = "TSActivities"
        Me.TSActivities.Size = New System.Drawing.Size(692, 25)
        Me.TSActivities.TabIndex = 1
        Me.TSActivities.Text = "ToolStrip1"
        '
        'SCActivities
        '
        Me.SCActivities.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCActivities.Location = New System.Drawing.Point(0, 0)
        Me.SCActivities.Name = "SCActivities"
        '
        'SCActivities.Panel1
        '
        Me.SCActivities.Panel1.Controls.Add(Me.tlp)
        '
        'SCActivities.Panel2
        '
        Me.SCActivities.Panel2.Controls.Add(Me.ELVActivities)
        Me.SCActivities.Panel2.Controls.Add(Me.TSActivities)
        Me.SCActivities.Panel2.Controls.Add(Me.SSActivities)
        Me.SCActivities.Size = New System.Drawing.Size(945, 461)
        Me.SCActivities.SplitterDistance = 249
        Me.SCActivities.TabIndex = 2
        '
        'tlp
        '
        Me.tlp.ColumnCount = 2
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.506438!))
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.49356!))
        Me.tlp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp.Location = New System.Drawing.Point(0, 0)
        Me.tlp.Name = "tlp"
        Me.tlp.RowCount = 1
        Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp.Size = New System.Drawing.Size(249, 461)
        Me.tlp.TabIndex = 0
        '
        'ELVActivities
        '
        Me.ELVActivities.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ELVActivities.GroupMode = ASDAN.Athena.ListViewGroupMode.Expanded
        Me.ELVActivities.Location = New System.Drawing.Point(0, 25)
        Me.ELVActivities.Name = "ELVActivities"
        Me.ELVActivities.Size = New System.Drawing.Size(692, 414)
        Me.ELVActivities.SortMode = ASDAN.Athena.ListViewSortMode.None
        Me.ELVActivities.TabIndex = 0
        Me.ELVActivities.UseCompatibleStateImageBehavior = False
        Me.ELVActivities.View = System.Windows.Forms.View.Details
        '
        'ActivityControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = true
        Me.Controls.Add(Me.SCActivities)
        Me.Name = "ActivityControl"
        Me.Size = New System.Drawing.Size(945, 461)
        Me.SSActivities.ResumeLayout(false)
        Me.SSActivities.PerformLayout
        Me.SCActivities.Panel1.ResumeLayout(false)
        Me.SCActivities.Panel2.ResumeLayout(false)
        Me.SCActivities.Panel2.PerformLayout
        CType(Me.SCActivities,System.ComponentModel.ISupportInitialize).EndInit
        Me.SCActivities.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents SSActivities As System.Windows.Forms.StatusStrip
    Friend WithEvents TSActivities As System.Windows.Forms.ToolStrip
    Friend WithEvents SCActivities As System.Windows.Forms.SplitContainer
    Friend WithEvents ELVActivities As ASDAN.Athena.ExtendedListView
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlp As System.Windows.Forms.TableLayoutPanel

End Class
