<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKePNMTTheoThang
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
        Dim SpinEditorButton1 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Dim SpinEditorButton2 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongKePNMTTheoThang))
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cbkChitiet = New System.Windows.Forms.CheckBox
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuDVC = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.dtpThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radCT_KhuA = New System.Windows.Forms.RadioButton
        Me.radCT_TCT = New System.Windows.Forms.RadioButton
        Me.radCT_KhuDVC = New System.Windows.Forms.RadioButton
        Me.radCT_KhuB = New System.Windows.Forms.RadioButton
        Me.radMTD7Thang = New System.Windows.Forms.RadioButton
        Me.radThaisan = New System.Windows.Forms.RadioButton
        Me.radVe15h30 = New System.Windows.Forms.RadioButton
        Me.dtpThang1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.tabTKPNMTThang = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnThongKe = New TD.SandBar.ButtonItem
        Me.btnXemchitiet = New TD.SandBar.ButtonItem
        Me.btnExcel = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtpThang1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.tabTKPNMTThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKPNMTThang.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(876, 62)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.cbkChitiet)
        Me.UltraGroupBox2.Controls.Add(Me.radKhuA)
        Me.UltraGroupBox2.Controls.Add(Me.radTCT)
        Me.UltraGroupBox2.Controls.Add(Me.radKhuDVC)
        Me.UltraGroupBox2.Controls.Add(Me.radKhuB)
        Me.UltraGroupBox2.Controls.Add(Me.dtpThang)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 5)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(728, 53)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.Text = "Điều Kiện Xem"
        '
        'cbkChitiet
        '
        Me.cbkChitiet.AutoSize = True
        Me.cbkChitiet.Location = New System.Drawing.Point(489, 22)
        Me.cbkChitiet.Name = "cbkChitiet"
        Me.cbkChitiet.Size = New System.Drawing.Size(58, 17)
        Me.cbkChitiet.TabIndex = 40
        Me.cbkChitiet.Text = "Chi tiết"
        Me.cbkChitiet.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Checked = True
        Me.radKhuA.Location = New System.Drawing.Point(185, 22)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 39
        Me.radKhuA.TabStop = True
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Location = New System.Drawing.Point(395, 22)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(88, 17)
        Me.radTCT.TabIndex = 38
        Me.radTCT.Text = "Toàn công ty"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuDVC
        '
        Me.radKhuDVC.AutoSize = True
        Me.radKhuDVC.Location = New System.Drawing.Point(316, 22)
        Me.radKhuDVC.Name = "radKhuDVC"
        Me.radKhuDVC.Size = New System.Drawing.Size(69, 17)
        Me.radKhuDVC.TabIndex = 38
        Me.radKhuDVC.Text = "Khu DVC"
        Me.radKhuDVC.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Location = New System.Drawing.Point(248, 22)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 37
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'dtpThang
        '
        SpinEditorButton1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThang.ButtonsRight.Add(SpinEditorButton1)
        Me.dtpThang.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThang.Location = New System.Drawing.Point(58, 20)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(105, 21)
        Me.dtpThang.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Tháng :"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(876, 62)
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.Panel1)
        Me.UltraGroupBox3.Controls.Add(Me.radMTD7Thang)
        Me.UltraGroupBox3.Controls.Add(Me.radThaisan)
        Me.UltraGroupBox3.Controls.Add(Me.radVe15h30)
        Me.UltraGroupBox3.Controls.Add(Me.dtpThang1)
        Me.UltraGroupBox3.Controls.Add(Me.Label2)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 5)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(868, 53)
        Me.UltraGroupBox3.TabIndex = 1
        Me.UltraGroupBox3.Text = "Điều Kiện Xem"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.radCT_KhuA)
        Me.Panel1.Controls.Add(Me.radCT_TCT)
        Me.Panel1.Controls.Add(Me.radCT_KhuDVC)
        Me.Panel1.Controls.Add(Me.radCT_KhuB)
        Me.Panel1.Location = New System.Drawing.Point(427, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 34)
        Me.Panel1.TabIndex = 37
        '
        'radCT_KhuA
        '
        Me.radCT_KhuA.AutoSize = True
        Me.radCT_KhuA.Checked = True
        Me.radCT_KhuA.Location = New System.Drawing.Point(9, 9)
        Me.radCT_KhuA.Name = "radCT_KhuA"
        Me.radCT_KhuA.Size = New System.Drawing.Size(54, 17)
        Me.radCT_KhuA.TabIndex = 43
        Me.radCT_KhuA.TabStop = True
        Me.radCT_KhuA.Text = "Khu A"
        Me.radCT_KhuA.UseVisualStyleBackColor = True
        '
        'radCT_TCT
        '
        Me.radCT_TCT.AutoSize = True
        Me.radCT_TCT.Location = New System.Drawing.Point(219, 9)
        Me.radCT_TCT.Name = "radCT_TCT"
        Me.radCT_TCT.Size = New System.Drawing.Size(88, 17)
        Me.radCT_TCT.TabIndex = 42
        Me.radCT_TCT.Text = "Toàn công ty"
        Me.radCT_TCT.UseVisualStyleBackColor = True
        '
        'radCT_KhuDVC
        '
        Me.radCT_KhuDVC.AutoSize = True
        Me.radCT_KhuDVC.Location = New System.Drawing.Point(140, 9)
        Me.radCT_KhuDVC.Name = "radCT_KhuDVC"
        Me.radCT_KhuDVC.Size = New System.Drawing.Size(69, 17)
        Me.radCT_KhuDVC.TabIndex = 41
        Me.radCT_KhuDVC.Text = "Khu DVC"
        Me.radCT_KhuDVC.UseVisualStyleBackColor = True
        '
        'radCT_KhuB
        '
        Me.radCT_KhuB.AutoSize = True
        Me.radCT_KhuB.Location = New System.Drawing.Point(72, 9)
        Me.radCT_KhuB.Name = "radCT_KhuB"
        Me.radCT_KhuB.Size = New System.Drawing.Size(54, 17)
        Me.radCT_KhuB.TabIndex = 40
        Me.radCT_KhuB.Text = "Khu B"
        Me.radCT_KhuB.UseVisualStyleBackColor = True
        '
        'radMTD7Thang
        '
        Me.radMTD7Thang.AutoSize = True
        Me.radMTD7Thang.Checked = True
        Me.radMTD7Thang.Location = New System.Drawing.Point(179, 22)
        Me.radMTD7Thang.Name = "radMTD7Thang"
        Me.radMTD7Thang.Size = New System.Drawing.Size(86, 17)
        Me.radMTD7Thang.TabIndex = 36
        Me.radMTD7Thang.TabStop = True
        Me.radMTD7Thang.Text = "Dưới 7 tháng"
        Me.radMTD7Thang.UseVisualStyleBackColor = True
        '
        'radThaisan
        '
        Me.radThaisan.AutoSize = True
        Me.radThaisan.Location = New System.Drawing.Point(355, 22)
        Me.radThaisan.Name = "radThaisan"
        Me.radThaisan.Size = New System.Drawing.Size(66, 17)
        Me.radThaisan.TabIndex = 36
        Me.radThaisan.Text = "Thai sản"
        Me.radThaisan.UseVisualStyleBackColor = True
        '
        'radVe15h30
        '
        Me.radVe15h30.AutoSize = True
        Me.radVe15h30.Location = New System.Drawing.Point(272, 22)
        Me.radVe15h30.Name = "radVe15h30"
        Me.radVe15h30.Size = New System.Drawing.Size(71, 17)
        Me.radVe15h30.TabIndex = 36
        Me.radVe15h30.Text = "Về 15h30"
        Me.radVe15h30.UseVisualStyleBackColor = True
        '
        'dtpThang1
        '
        SpinEditorButton2.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThang1.ButtonsRight.Add(SpinEditorButton2)
        Me.dtpThang1.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThang1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThang1.Location = New System.Drawing.Point(58, 20)
        Me.dtpThang1.Name = "dtpThang1"
        Me.dtpThang1.Size = New System.Drawing.Size(105, 21)
        Me.dtpThang1.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Tháng :"
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 109)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 7
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.tabTKPNMTThang)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(880, 109)
        Me.pnlDetail.TabIndex = 0
        '
        'tabTKPNMTThang
        '
        Appearance6.BackColor = System.Drawing.Color.AliceBlue
        Me.tabTKPNMTThang.Appearance = Appearance6
        Me.tabTKPNMTThang.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTKPNMTThang.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTKPNMTThang.Controls.Add(Me.UltraTabPageControl1)
        Me.tabTKPNMTThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTKPNMTThang.Location = New System.Drawing.Point(0, 24)
        Me.tabTKPNMTThang.Name = "tabTKPNMTThang"
        Me.tabTKPNMTThang.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTKPNMTThang.Size = New System.Drawing.Size(880, 85)
        Me.tabTKPNMTThang.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.tabTKPNMTThang.TabIndex = 7
        UltraTab1.TabPage = Me.UltraTabPageControl2
        UltraTab1.Text = "Thống Kê"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Danh sách"
        Me.tabTKPNMTThang.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(876, 62)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(880, 24)
        Me.XpCaption1.TabIndex = 4
        Me.XpCaption1.Text = "THỐNG KÊ PHỤ NỮ MANG THAI THEO THÁNG"
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 117)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(880, 328)
        Me.pnlList.TabIndex = 5
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(880, 270)
        Me.dgrBC.TabIndex = 10
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(880, 58)
        Me.pnlButton.TabIndex = 7
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnThongKe, Me.btnXemchitiet, Me.btnExcel})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(2, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(881, 26)
        Me.ToolBar1.TabIndex = 11
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnThongKe
        '
        Me.btnThongKe.ImageIndex = 8
        Me.btnThongKe.Text = "Thống kê"
        '
        'btnXemchitiet
        '
        Me.btnXemchitiet.ImageIndex = 8
        Me.btnXemchitiet.Text = "Xem chi tiết"
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
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(880, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(886, 448)
        Me.UltraGroupBox1.TabIndex = 18
        '
        'UltraGridExcelExporter1
        '
        '
        '_frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom
        '
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 0)
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.Name = "_frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom"
        Me._frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(0, 0)
        '
        'frmThongKePNMTTheoThang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 448)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "frmThongKePNMTTheoThang"
        Me.Text = "frmThongKePNMTTheoThang"
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtpThang1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.tabTKPNMTThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKPNMTThang.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents tabTKPNMTThang As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btnThongKe As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents _frmThongKePNMTTheoThang_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents dtpThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnXemchitiet As TD.SandBar.ButtonItem
    Friend WithEvents btnExcel As TD.SandBar.ButtonItem
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtpThang1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents radMTD7Thang As System.Windows.Forms.RadioButton
    Friend WithEvents radThaisan As System.Windows.Forms.RadioButton
    Friend WithEvents radVe15h30 As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radCT_KhuA As System.Windows.Forms.RadioButton
    Friend WithEvents radCT_TCT As System.Windows.Forms.RadioButton
    Friend WithEvents radCT_KhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents radCT_KhuB As System.Windows.Forms.RadioButton
    Friend WithEvents cbkChitiet As System.Windows.Forms.CheckBox
End Class
