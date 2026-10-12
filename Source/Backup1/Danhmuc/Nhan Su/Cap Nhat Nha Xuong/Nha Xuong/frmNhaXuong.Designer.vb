<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhaXuong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNhaXuong))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSoTT = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtGhiChu = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTenNX = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtMaNX = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pnlList = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnThem = New TD.SandBar.ButtonItem
        Me.btnSua = New TD.SandBar.ButtonItem
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.btnExcel = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.txtSoTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGhiChu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenNX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaNX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Label8)
        Me.UltraTabPageControl2.Controls.Add(Me.Label6)
        Me.UltraTabPageControl2.Controls.Add(Me.Label5)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.txtSoTT)
        Me.UltraTabPageControl2.Controls.Add(Me.txtGhiChu)
        Me.UltraTabPageControl2.Controls.Add(Me.txtTenNX)
        Me.UltraTabPageControl2.Controls.Add(Me.txtMaNX)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1273, 137)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(43, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Ghi Chú :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(43, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Thứ Tự  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(5, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tên Nhà Xưởng :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mã Nhà Xưởng :"
        '
        'txtSoTT
        '
        Me.txtSoTT.Location = New System.Drawing.Point(98, 74)
        Me.txtSoTT.MaxLength = 14
        Me.txtSoTT.Name = "txtSoTT"
        Me.txtSoTT.Size = New System.Drawing.Size(201, 21)
        Me.txtSoTT.TabIndex = 1
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Location = New System.Drawing.Point(98, 107)
        Me.txtGhiChu.MaxLength = 14
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(201, 21)
        Me.txtGhiChu.TabIndex = 1
        '
        'txtTenNX
        '
        Me.txtTenNX.Location = New System.Drawing.Point(98, 41)
        Me.txtTenNX.Name = "txtTenNX"
        Me.txtTenNX.Size = New System.Drawing.Size(201, 21)
        Me.txtTenNX.TabIndex = 1
        '
        'txtMaNX
        '
        Me.txtMaNX.Location = New System.Drawing.Point(98, 10)
        Me.txtMaNX.MaxLength = 4
        Me.txtMaNX.Name = "txtMaNX"
        Me.txtMaNX.Size = New System.Drawing.Size(110, 21)
        Me.txtMaNX.TabIndex = 1
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1289, 571)
        Me.UltraGroupBox1.TabIndex = 4
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.Panel1)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 197)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(1283, 371)
        Me.pnlList.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgrBC)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1283, 319)
        Me.Panel1.TabIndex = 7
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(1283, 52)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnThem, Me.btnSua, Me.btnLuu, Me.btnExcel})
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Guid = New System.Guid("ab002a63-4662-40c9-b9a7-6743bf17514c")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(1283, 26)
        Me.ToolBar1.TabIndex = 31
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnThem
        '
        Me.btnThem.ImageIndex = 0
        Me.btnThem.Text = "Thêm"
        '
        'btnSua
        '
        Me.btnSua.ImageIndex = 1
        Me.btnSua.Text = "Sửa"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 4
        Me.btnLuu.Text = "Lưu"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 9
        Me.btnExcel.Text = "Excel"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "doc excel.ico")
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(1283, 26)
        Me.XpCaption2.TabIndex = 30
        Me.XpCaption2.Text = "Danh Sách Nhà Xưởng"
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 189)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.AutoScroll = True
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(1283, 189)
        Me.pnlDetail.TabIndex = 1
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 26)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(1283, 163)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Appearance1.BackColor = System.Drawing.Color.AliceBlue
        Appearance1.BackColor2 = System.Drawing.Color.AliceBlue
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.UltraTabControl1.Appearance = Appearance1
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(1277, 160)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 1
        Appearance2.BackColor = System.Drawing.Color.AliceBlue
        Appearance2.BackColor2 = System.Drawing.Color.AliceBlue
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.ForeColor = System.Drawing.Color.Red
        UltraTab2.ActiveAppearance = Appearance2
        UltraTab2.CloseButtonAlignment = Infragistics.Win.UltraWinTabs.TabCloseButtonAlignment.BeforeContent
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Nhà Xưởng"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Standard
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1273, 137)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(1283, 26)
        Me.XpCaption1.TabIndex = 2
        Me.XpCaption1.Text = "Nhập Liệu"
        '
        'dgrBC
        '
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgrBC.DisplayLayout.Appearance = Appearance7
        Me.dgrBC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.dgrBC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.GroupByBox.Hidden = True
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.dgrBC.DisplayLayout.MaxColScrollRegions = 1
        Me.dgrBC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrBC.DisplayLayout.Override.ActiveCellAppearance = Appearance15
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgrBC.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.dgrBC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgrBC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgrBC.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgrBC.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance14.TextHAlignAsString = "Left"
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgrBC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.dgrBC.DisplayLayout.Override.RowAppearance = Appearance13
        Me.dgrBC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgrBC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance11
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(1283, 319)
        Me.dgrBC.TabIndex = 5
        Me.dgrBC.Text = "UltraGrid1"
        '
        'frmNhaXuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 571)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "frmNhaXuong"
        Me.Text = "frmNhaXuong"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.txtSoTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGhiChu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenNX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaNX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btnThem As TD.SandBar.ButtonItem
    Friend WithEvents btnSua As TD.SandBar.ButtonItem
    Friend WithEvents btnLuu As TD.SandBar.ButtonItem
    Friend WithEvents btnExcel As TD.SandBar.ButtonItem
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents grpDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    ''Friend WithEvents _frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    ''Friend WithEvents _frmKhoanCongKhac_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    ''Friend WithEvents _frmCVNhanVien_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSoTT As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtGhiChu As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTenNX As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMaNX As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
