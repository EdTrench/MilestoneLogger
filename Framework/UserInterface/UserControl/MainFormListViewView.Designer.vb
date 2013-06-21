<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFormListViewView
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
        Me.MainListViewSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MainListViewToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.MainListViewStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.MainFormListView = New System.Windows.Forms.ListView()
        Me.ActionFilterSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MainListViewOverviewPanel = New System.Windows.Forms.Panel()
        CType(Me.MainListViewSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainListViewSplitContainer.Panel1.SuspendLayout()
        Me.MainListViewSplitContainer.Panel2.SuspendLayout()
        Me.MainListViewSplitContainer.SuspendLayout()
        Me.MainListViewToolStrip.SuspendLayout()
        CType(Me.ActionFilterSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionFilterSplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainListViewSplitContainer
        '
        Me.MainListViewSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainListViewSplitContainer.Location = New System.Drawing.Point(0, 50)
        Me.MainListViewSplitContainer.Name = "MainListViewSplitContainer"
        '
        'MainListViewSplitContainer.Panel1
        '
        Me.MainListViewSplitContainer.Panel1.Controls.Add(Me.MainListViewToolStrip)
        Me.MainListViewSplitContainer.Panel1.Controls.Add(Me.MainListViewStatusStrip)
        Me.MainListViewSplitContainer.Panel1.Controls.Add(Me.MainFormListView)
        '
        'MainListViewSplitContainer.Panel2
        '
        Me.MainListViewSplitContainer.Panel2.Controls.Add(Me.ActionFilterSplitContainer)
        Me.MainListViewSplitContainer.Size = New System.Drawing.Size(680, 342)
        Me.MainListViewSplitContainer.SplitterDistance = 515
        Me.MainListViewSplitContainer.TabIndex = 0
        '
        'MainListViewToolStrip
        '
        Me.MainListViewToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.MainListViewToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainListViewToolStrip.Name = "MainListViewToolStrip"
        Me.MainListViewToolStrip.Size = New System.Drawing.Size(515, 25)
        Me.MainListViewToolStrip.TabIndex = 2
        Me.MainListViewToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.ASDAN.Athena.My.Resources.Resources.RefreshSmall
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'MainListViewStatusStrip
        '
        Me.MainListViewStatusStrip.Location = New System.Drawing.Point(0, 320)
        Me.MainListViewStatusStrip.Name = "MainListViewStatusStrip"
        Me.MainListViewStatusStrip.Size = New System.Drawing.Size(515, 22)
        Me.MainListViewStatusStrip.TabIndex = 1
        Me.MainListViewStatusStrip.Text = "StatusStrip1"
        '
        'MainFormListView
        '
        Me.MainFormListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainFormListView.Location = New System.Drawing.Point(3, 28)
        Me.MainFormListView.Name = "MainFormListView"
        Me.MainFormListView.Size = New System.Drawing.Size(509, 289)
        Me.MainFormListView.TabIndex = 0
        Me.MainFormListView.UseCompatibleStateImageBehavior = False
        Me.MainFormListView.View = System.Windows.Forms.View.Details
        '
        'ActionFilterSplitContainer
        '
        Me.ActionFilterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActionFilterSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.ActionFilterSplitContainer.Name = "ActionFilterSplitContainer"
        Me.ActionFilterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ActionFilterSplitContainer.Size = New System.Drawing.Size(161, 342)
        Me.ActionFilterSplitContainer.SplitterDistance = 169
        Me.ActionFilterSplitContainer.TabIndex = 0
        '
        'MainListViewOverviewPanel
        '
        Me.MainListViewOverviewPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainListViewOverviewPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainListViewOverviewPanel.Name = "MainListViewOverviewPanel"
        Me.MainListViewOverviewPanel.Size = New System.Drawing.Size(683, 47)
        Me.MainListViewOverviewPanel.TabIndex = 1
        '
        'MainFormListViewControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MainListViewOverviewPanel)
        Me.Controls.Add(Me.MainListViewSplitContainer)
        Me.Name = "MainFormListViewControl"
        Me.Size = New System.Drawing.Size(683, 395)
        Me.MainListViewSplitContainer.Panel1.ResumeLayout(False)
        Me.MainListViewSplitContainer.Panel1.PerformLayout()
        Me.MainListViewSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainListViewSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainListViewSplitContainer.ResumeLayout(False)
        Me.MainListViewToolStrip.ResumeLayout(False)
        Me.MainListViewToolStrip.PerformLayout()
        CType(Me.ActionFilterSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionFilterSplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainListViewSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MainFormListView As System.Windows.Forms.ListView
    Friend WithEvents MainListViewToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MainListViewStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ActionFilterSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MainListViewOverviewPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
