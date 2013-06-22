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
        Me.MainFormListViewPageControl = New MilestoneLogger.PageControl()
        Me.MainListViewToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonExport = New System.Windows.Forms.ToolStripButton()
        Me.MainListViewStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.MainListViewToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainFormListView = New System.Windows.Forms.ListView()
        Me.ActionFilterSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MainFormActionPanel = New MilestoneLogger.ActionPanel()
        Me.MainFormFilterPanel = New MilestoneLogger.FilterPanel()
        Me.MainListViewOverviewPanel = New System.Windows.Forms.Panel()
        Me.MainFormIcon = New System.Windows.Forms.PictureBox()
        Me.QuickSearchButton = New System.Windows.Forms.Button()
        Me.QuickSearchCueTextBox = New MilestoneLogger.CueTextBox()
        Me.lblNavigationDescription = New System.Windows.Forms.Label()
        Me.lblNavigationTitle = New System.Windows.Forms.Label()
        CType(Me.MainListViewSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainListViewSplitContainer.Panel1.SuspendLayout()
        Me.MainListViewSplitContainer.Panel2.SuspendLayout()
        Me.MainListViewSplitContainer.SuspendLayout()
        Me.MainListViewToolStrip.SuspendLayout()
        Me.MainListViewStatusStrip.SuspendLayout()
        CType(Me.ActionFilterSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionFilterSplitContainer.Panel1.SuspendLayout()
        Me.ActionFilterSplitContainer.Panel2.SuspendLayout()
        Me.ActionFilterSplitContainer.SuspendLayout()
        Me.MainListViewOverviewPanel.SuspendLayout()
        CType(Me.MainFormIcon, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MainListViewSplitContainer.Panel1.Controls.Add(Me.MainFormListViewPageControl)
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
        'MainFormListViewPageControl
        '
        Me.MainFormListViewPageControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainFormListViewPageControl.Location = New System.Drawing.Point(425, 323)
        Me.MainFormListViewPageControl.Name = "MainFormListViewPageControl"
        Me.MainFormListViewPageControl.Size = New System.Drawing.Size(87, 19)
        Me.MainFormListViewPageControl.TabIndex = 3
        '
        'MainListViewToolStrip
        '
        Me.MainListViewToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefresh, Me.ToolStripButtonExport})
        Me.MainListViewToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainListViewToolStrip.Name = "MainListViewToolStrip"
        Me.MainListViewToolStrip.Size = New System.Drawing.Size(515, 25)
        Me.MainListViewToolStrip.TabIndex = 2
        Me.MainListViewToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButtonRefresh
        '
        Me.ToolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRefresh.Image = Global.MilestoneLogger.My.Resources.Resources.RefreshSmall
        Me.ToolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRefresh.Name = "ToolStripButtonRefresh"
        Me.ToolStripButtonRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonRefresh.Text = "ToolStripButton1"
        '
        'ToolStripButtonExport
        '
        Me.ToolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonExport.Image = Global.MilestoneLogger.My.Resources.Resources.ExportSmall
        Me.ToolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonExport.Name = "ToolStripButtonExport"
        Me.ToolStripButtonExport.Size = New System.Drawing.Size(23, 22)
        '
        'MainListViewStatusStrip
        '
        Me.MainListViewStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainListViewToolStripStatusLabel})
        Me.MainListViewStatusStrip.Location = New System.Drawing.Point(0, 320)
        Me.MainListViewStatusStrip.Name = "MainListViewStatusStrip"
        Me.MainListViewStatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MainListViewStatusStrip.Size = New System.Drawing.Size(515, 22)
        Me.MainListViewStatusStrip.SizingGrip = False
        Me.MainListViewStatusStrip.TabIndex = 1
        '
        'MainListViewToolStripStatusLabel
        '
        Me.MainListViewToolStripStatusLabel.Name = "MainListViewToolStripStatusLabel"
        Me.MainListViewToolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MainListViewToolStripStatusLabel.Size = New System.Drawing.Size(193, 17)
        Me.MainListViewToolStripStatusLabel.Text = "[MainListViewToolStripStatusLabel]"
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
        '
        'ActionFilterSplitContainer.Panel1
        '
        Me.ActionFilterSplitContainer.Panel1.Controls.Add(Me.MainFormActionPanel)
        '
        'ActionFilterSplitContainer.Panel2
        '
        Me.ActionFilterSplitContainer.Panel2.Controls.Add(Me.MainFormFilterPanel)
        Me.ActionFilterSplitContainer.Size = New System.Drawing.Size(161, 342)
        Me.ActionFilterSplitContainer.SplitterDistance = 169
        Me.ActionFilterSplitContainer.TabIndex = 0
        '
        'MainFormActionPanel
        '
        Me.MainFormActionPanel.Location = New System.Drawing.Point(3, 3)
        Me.MainFormActionPanel.Name = "MainFormActionPanel"
        Me.MainFormActionPanel.Size = New System.Drawing.Size(155, 163)
        Me.MainFormActionPanel.TabIndex = 0
        '
        'MainFormFilterPanel
        '
        Me.MainFormFilterPanel.Location = New System.Drawing.Point(4, 4)
        Me.MainFormFilterPanel.Name = "MainFormFilterPanel"
        Me.MainFormFilterPanel.Size = New System.Drawing.Size(154, 162)
        Me.MainFormFilterPanel.TabIndex = 0
        '
        'MainListViewOverviewPanel
        '
        Me.MainListViewOverviewPanel.Controls.Add(Me.MainFormIcon)
        Me.MainListViewOverviewPanel.Controls.Add(Me.QuickSearchButton)
        Me.MainListViewOverviewPanel.Controls.Add(Me.QuickSearchCueTextBox)
        Me.MainListViewOverviewPanel.Controls.Add(Me.lblNavigationDescription)
        Me.MainListViewOverviewPanel.Controls.Add(Me.lblNavigationTitle)
        Me.MainListViewOverviewPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainListViewOverviewPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainListViewOverviewPanel.Name = "MainListViewOverviewPanel"
        Me.MainListViewOverviewPanel.Size = New System.Drawing.Size(683, 47)
        Me.MainListViewOverviewPanel.TabIndex = 1
        '
        'MainFormIcon
        '
        Me.MainFormIcon.Location = New System.Drawing.Point(3, 3)
        Me.MainFormIcon.Name = "MainFormIcon"
        Me.MainFormIcon.Size = New System.Drawing.Size(38, 33)
        Me.MainFormIcon.TabIndex = 5
        Me.MainFormIcon.TabStop = False
        '
        'QuickSearchButton
        '
        Me.QuickSearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuickSearchButton.Image = Global.MilestoneLogger.My.Resources.Resources.PlaySmall
        Me.QuickSearchButton.Location = New System.Drawing.Point(648, 13)
        Me.QuickSearchButton.Name = "QuickSearchButton"
        Me.QuickSearchButton.Size = New System.Drawing.Size(22, 23)
        Me.QuickSearchButton.TabIndex = 4
        Me.QuickSearchButton.UseVisualStyleBackColor = True
        '
        'QuickSearchCueTextBox
        '
        Me.QuickSearchCueTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuickSearchCueTextBox.Cue = "Find..."
        Me.QuickSearchCueTextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuickSearchCueTextBox.Location = New System.Drawing.Point(468, 13)
        Me.QuickSearchCueTextBox.Multiline = True
        Me.QuickSearchCueTextBox.Name = "QuickSearchCueTextBox"
        Me.QuickSearchCueTextBox.Size = New System.Drawing.Size(183, 23)
        Me.QuickSearchCueTextBox.TabIndex = 3
        '
        'lblNavigationDescription
        '
        Me.lblNavigationDescription.AutoSize = True
        Me.lblNavigationDescription.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblNavigationDescription.Location = New System.Drawing.Point(5, 34)
        Me.lblNavigationDescription.Name = "lblNavigationDescription"
        Me.lblNavigationDescription.Size = New System.Drawing.Size(217, 13)
        Me.lblNavigationDescription.TabIndex = 2
        Me.lblNavigationDescription.Text = "Helpful description for this feature goes here."
        '
        'lblNavigationTitle
        '
        Me.lblNavigationTitle.AutoSize = True
        Me.lblNavigationTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavigationTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNavigationTitle.Location = New System.Drawing.Point(47, 3)
        Me.lblNavigationTitle.Name = "lblNavigationTitle"
        Me.lblNavigationTitle.Size = New System.Drawing.Size(173, 25)
        Me.lblNavigationTitle.TabIndex = 0
        Me.lblNavigationTitle.Text = "[lblNavigationTitle]"
        '
        'MainFormListViewView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MainListViewOverviewPanel)
        Me.Controls.Add(Me.MainListViewSplitContainer)
        Me.Name = "MainFormListViewView"
        Me.Size = New System.Drawing.Size(683, 395)
        Me.MainListViewSplitContainer.Panel1.ResumeLayout(False)
        Me.MainListViewSplitContainer.Panel1.PerformLayout()
        Me.MainListViewSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainListViewSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainListViewSplitContainer.ResumeLayout(False)
        Me.MainListViewToolStrip.ResumeLayout(False)
        Me.MainListViewToolStrip.PerformLayout()
        Me.MainListViewStatusStrip.ResumeLayout(False)
        Me.MainListViewStatusStrip.PerformLayout()
        Me.ActionFilterSplitContainer.Panel1.ResumeLayout(False)
        Me.ActionFilterSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.ActionFilterSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionFilterSplitContainer.ResumeLayout(False)
        Me.MainListViewOverviewPanel.ResumeLayout(False)
        Me.MainListViewOverviewPanel.PerformLayout()
        CType(Me.MainFormIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainListViewSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MainFormListView As System.Windows.Forms.ListView
    Friend WithEvents MainListViewToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MainListViewStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ActionFilterSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MainListViewOverviewPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNavigationTitle As System.Windows.Forms.Label
    Friend WithEvents lblNavigationDescription As System.Windows.Forms.Label
    Friend WithEvents QuickSearchButton As System.Windows.Forms.Button
    Friend WithEvents QuickSearchCueTextBox As MilestoneLogger.CueTextBox
    Friend WithEvents MainListViewToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButtonExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainFormListViewPageControl As MilestoneLogger.PageControl
    Friend WithEvents MainFormActionPanel As MilestoneLogger.ActionPanel
    Friend WithEvents MainFormIcon As System.Windows.Forms.PictureBox
    Friend WithEvents MainFormFilterPanel As MilestoneLogger.FilterPanel

End Class
