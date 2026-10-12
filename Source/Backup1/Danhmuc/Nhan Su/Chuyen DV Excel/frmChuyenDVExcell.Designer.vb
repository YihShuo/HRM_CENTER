<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuyenDVExcell
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChuyenDVExcell))
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btd = New System.Windows.Forms.Button
        Me.txtMa = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btex = New TD.SandBar.ButtonItem
        Me.btcn = New TD.SandBar.ButtonItem
        Me.btx = New TD.SandBar.ButtonItem
        Me.btnexcel = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.pnl2 = New System.Windows.Forms.Panel
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.CollapsibleSplitter1 = New NJFLib.Controls.CollapsibleSplitter
        Me.pnl1 = New System.Windows.Forms.Panel
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtMa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl2.SuspendLayout()
        Me.pnl1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(489, 86)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.btd)
        Me.UltraGroupBox1.Controls.Add(Me.txtMa)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(489, 86)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Duyệt file"
        '
        'btd
        '
        Me.btd.Location = New System.Drawing.Point(304, 34)
        Me.btd.Name = "btd"
        Me.btd.Size = New System.Drawing.Size(31, 23)
        Me.btd.TabIndex = 10
        Me.btd.Text = "..."
        Me.btd.UseVisualStyleBackColor = True
        '
        'txtMa
        '
        Me.txtMa.Location = New System.Drawing.Point(117, 36)
        Me.txtMa.MaxLength = 6
        Me.txtMa.Name = "txtMa"
        Me.txtMa.Size = New System.Drawing.Size(181, 21)
        Me.txtMa.TabIndex = 6
        '
        'UltraLabel1
        '
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance5
        Me.UltraLabel1.Location = New System.Drawing.Point(18, 36)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(93, 23)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Tên tệp :"
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btex, Me.btcn, Me.btx, Me.btnexcel})
        Me.ToolBar1.Guid = New System.Guid("3b2086a4-9f76-4da9-b720-dbb4334ec81d")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 40)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(491, 26)
        Me.ToolBar1.TabIndex = 2
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btex
        '
        Me.btex.ImageIndex = 5
        Me.btex.Text = "Lấy dữ liệu Excel"
        '
        'btcn
        '
        Me.btcn.ImageIndex = 4
        Me.btcn.Text = "Cập nhật đơn vị DD"
        '
        'btx
        '
        Me.btx.ImageIndex = 2
        Me.btx.Text = "Tải dữ liệu vừa chuyển"
        '
        'btnexcel
        '
        Me.btnexcel.ImageIndex = 3
        Me.btnexcel.Text = "Excel"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "0.add.ico")
        Me.ImageList1.Images.SetKeyName(1, "1.xoa.ico")
        Me.ImageList1.Images.SetKeyName(2, "2.note.ico")
        Me.ImageList1.Images.SetKeyName(3, "3.PRINTER.ico")
        Me.ImageList1.Images.SetKeyName(4, "4.save.ico")
        Me.ImageList1.Images.SetKeyName(5, "5.a91.ico")
        '
        'dgrBC
        '
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgrBC.DisplayLayout.Appearance = Appearance44
        Me.dgrBC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance45.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.GroupByBox.Appearance = Appearance45
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance46
        Me.dgrBC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.GroupByBox.Hidden = True
        Appearance47.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance47.BackColor2 = System.Drawing.SystemColors.Control
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.PromptAppearance = Appearance47
        Me.dgrBC.DisplayLayout.MaxColScrollRegions = 1
        Me.dgrBC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrBC.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgrBC.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.dgrBC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgrBC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgrBC.DisplayLayout.Override.CellAppearance = Appearance11
        Me.dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgrBC.DisplayLayout.Override.CellPadding = 0
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance17.TextHAlignAsString = "Left"
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgrBC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.dgrBC.DisplayLayout.Override.RowAppearance = Appearance16
        Me.dgrBC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgrBC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 66)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(491, 199)
        Me.dgrBC.TabIndex = 3
        Me.dgrBC.Text = "UltraGrid1"
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(489, 86)
        '
        'pnl2
        '
        Me.pnl2.Controls.Add(Me.dgrBC)
        Me.pnl2.Controls.Add(Me.ToolBar1)
        Me.pnl2.Controls.Add(Me.XpCaption2)
        Me.pnl2.Controls.Add(Me.CollapsibleSplitter1)
        Me.pnl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl2.Location = New System.Drawing.Point(0, 141)
        Me.pnl2.Name = "pnl2"
        Me.pnl2.Size = New System.Drawing.Size(491, 265)
        Me.pnl2.TabIndex = 4
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption2.Location = New System.Drawing.Point(0, 8)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(491, 32)
        Me.XpCaption2.TabIndex = 1
        Me.XpCaption2.Text = "Danh Sách"
        '
        'CollapsibleSplitter1
        '
        Me.CollapsibleSplitter1.AnimationDelay = 20
        Me.CollapsibleSplitter1.AnimationStep = 20
        Me.CollapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.CollapsibleSplitter1.ControlToHide = Me.pnl1
        Me.CollapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CollapsibleSplitter1.ExpandParentForm = False
        Me.CollapsibleSplitter1.Location = New System.Drawing.Point(0, 0)
        Me.CollapsibleSplitter1.Name = "CollapsibleSplitter1"
        Me.CollapsibleSplitter1.TabIndex = 0
        Me.CollapsibleSplitter1.TabStop = False
        Me.CollapsibleSplitter1.UseAnimations = False
        Me.CollapsibleSplitter1.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.UltraTabControl1)
        Me.pnl1.Controls.Add(Me.XpCaption1)
        Me.pnl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl1.Location = New System.Drawing.Point(0, 0)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(491, 141)
        Me.pnl1.TabIndex = 3
        '
        'UltraTabControl1
        '
        Appearance7.FontData.Name = "Tahoma"
        Appearance7.ForeColor = System.Drawing.Color.Red
        Me.UltraTabControl1.ActiveTabAppearance = Appearance7
        Appearance6.ForeColor = System.Drawing.Color.Red
        Me.UltraTabControl1.Appearance = Appearance6
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 32)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.UltraGroupBox1})
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(491, 109)
        Me.UltraTabControl1.TabIndex = 1
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Duyệt dữ liệu Excel"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(491, 32)
        Me.XpCaption1.TabIndex = 0
        Me.XpCaption1.Text = "Nhân Viên Chuyển Đơn Vị"
        '
        '_frmChuyenDV_Toolbars_Dock_Area_Bottom
        '
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 406)
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.Name = "_frmChuyenDV_Toolbars_Dock_Area_Bottom"
        Me._frmChuyenDV_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(491, 0)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmChuyenDVExcell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 406)
        Me.Controls.Add(Me.pnl2)
        Me.Controls.Add(Me._frmChuyenDV_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.pnl1)
        Me.Name = "frmChuyenDVExcell"
        Me.Text = "Chuyển đơn vị trong file Excel"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtMa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl2.ResumeLayout(False)
        Me.pnl1.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btex As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtMa As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents pnl2 As System.Windows.Forms.Panel
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents CollapsibleSplitter1 As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents _frmChuyenDV_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btd As System.Windows.Forms.Button
    Friend WithEvents b As ClsBChuyenDVExcel
    Friend WithEvents btcn As TD.SandBar.ButtonItem
    Friend WithEvents btx As TD.SandBar.ButtonItem
    Friend WithEvents btnexcel As TD.SandBar.ButtonItem
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
