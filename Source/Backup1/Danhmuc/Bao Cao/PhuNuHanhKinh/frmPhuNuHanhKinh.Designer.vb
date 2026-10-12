<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhuNuHanhKinh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhuNuHanhKinh))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.radSothe = New System.Windows.Forms.RadioButton
        Me.radDV = New System.Windows.Forms.RadioButton
        Me.cboDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.txtSothe = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtpThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpThangNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDonviNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.bntKiemTraST = New TD.SandBar.ToolBar
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.btnXoanhom = New TD.SandBar.ButtonItem
        Me.btnExcel = New TD.SandBar.ButtonItem
        Me.btnXemchitiet = New TD.SandBar.ButtonItem
        Me.btnTinhSoGioHK = New TD.SandBar.ButtonItem
        Me.btnXemDSHKNV = New TD.SandBar.ButtonItem
        Me.btnTinhSoGioHKNV = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.tabTraCuu = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.cboDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTraCuu.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.dtpNgay)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.radSothe)
        Me.UltraTabPageControl2.Controls.Add(Me.radDV)
        Me.UltraTabPageControl2.Controls.Add(Me.cboDonvi)
        Me.UltraTabPageControl2.Controls.Add(Me.txtSothe)
        Me.UltraTabPageControl2.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(907, 50)
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(55, 12)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(128, 21)
        Me.dtpNgay.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Ngày:"
        '
        'radSothe
        '
        Me.radSothe.AutoSize = True
        Me.radSothe.Location = New System.Drawing.Point(202, 14)
        Me.radSothe.Name = "radSothe"
        Me.radSothe.Size = New System.Drawing.Size(66, 19)
        Me.radSothe.TabIndex = 28
        Me.radSothe.Text = "Số thẻ :"
        Me.radSothe.UseVisualStyleBackColor = True
        '
        'radDV
        '
        Me.radDV.AutoSize = True
        Me.radDV.Checked = True
        Me.radDV.Location = New System.Drawing.Point(383, 14)
        Me.radDV.Name = "radDV"
        Me.radDV.Size = New System.Drawing.Size(66, 19)
        Me.radDV.TabIndex = 28
        Me.radDV.TabStop = True
        Me.radDV.Text = "Đơn vị :"
        Me.radDV.UseVisualStyleBackColor = True
        '
        'cboDonvi
        '
        Me.cboDonvi.AlwaysInEditMode = True
        Me.cboDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboDonvi.DisplayMember = "DV_TEN"
        Me.cboDonvi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDonvi.Location = New System.Drawing.Point(454, 12)
        Me.cboDonvi.Name = "cboDonvi"
        Me.cboDonvi.Size = New System.Drawing.Size(293, 22)
        Me.cboDonvi.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue
        Me.cboDonvi.TabIndex = 27
        Me.cboDonvi.ValueMember = "DV_MA"
        '
        'txtSothe
        '
        Me.txtSothe.Enabled = False
        Me.txtSothe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSothe.HideSelection = False
        Me.txtSothe.Location = New System.Drawing.Point(272, 12)
        Me.txtSothe.Name = "txtSothe"
        Me.txtSothe.Size = New System.Drawing.Size(98, 21)
        Me.txtSothe.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(7, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 45)
        Me.Panel1.TabIndex = 33
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.dtpThang)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(907, 50)
        '
        'dtpThang
        '
        SpinEditorButton1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThang.ButtonsRight.Add(SpinEditorButton1)
        Me.dtpThang.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThang.Location = New System.Drawing.Point(97, 12)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(128, 22)
        Me.dtpThang.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tháng:"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Label4)
        Me.UltraTabPageControl3.Controls.Add(Me.dtpThangNV)
        Me.UltraTabPageControl3.Controls.Add(Me.Label3)
        Me.UltraTabPageControl3.Controls.Add(Me.cboDonviNV)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(907, 50)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Đơn vị"
        '
        'dtpThangNV
        '
        SpinEditorButton2.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThangNV.ButtonsRight.Add(SpinEditorButton2)
        Me.dtpThangNV.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThangNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThangNV.Location = New System.Drawing.Point(154, 14)
        Me.dtpThangNV.Name = "dtpThangNV"
        Me.dtpThangNV.Size = New System.Drawing.Size(128, 22)
        Me.dtpThangNV.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Tháng tính:"
        '
        'cboDonviNV
        '
        Me.cboDonviNV.AlwaysInEditMode = True
        Me.cboDonviNV.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboDonviNV.DisplayMember = "DV_TEN"
        Me.cboDonviNV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDonviNV.Location = New System.Drawing.Point(343, 14)
        Me.cboDonviNV.Name = "cboDonviNV"
        Me.cboDonviNV.Size = New System.Drawing.Size(293, 22)
        Me.cboDonviNV.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue
        Me.cboDonviNV.TabIndex = 29
        Me.cboDonviNV.ValueMember = "DV_MA"
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 109)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(911, 276)
        Me.pnlList.TabIndex = 5
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance4.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(911, 218)
        Me.dgrBC.TabIndex = 8
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.bntKiemTraST)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(911, 58)
        Me.pnlButton.TabIndex = 7
        '
        'bntKiemTraST
        '
        Me.bntKiemTraST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntKiemTraST.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnLuu, Me.btnXoanhom, Me.btnExcel, Me.btnXemchitiet, Me.btnTinhSoGioHK, Me.btnXemDSHKNV, Me.btnTinhSoGioHKNV})
        Me.bntKiemTraST.Dock = System.Windows.Forms.DockStyle.None
        Me.bntKiemTraST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntKiemTraST.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.bntKiemTraST.ImageList = Me.ImageList1
        Me.bntKiemTraST.Location = New System.Drawing.Point(1, 27)
        Me.bntKiemTraST.Name = "bntKiemTraST"
        Me.bntKiemTraST.Size = New System.Drawing.Size(909, 26)
        Me.bntKiemTraST.TabIndex = 11
        Me.bntKiemTraST.Text = "ToolBar1"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 4
        Me.btnLuu.Text = "Lưu"
        '
        'btnXoanhom
        '
        Me.btnXoanhom.ImageIndex = 2
        Me.btnXoanhom.Text = "Xóa nhóm"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 9
        Me.btnExcel.Text = "Excel"
        '
        'btnXemchitiet
        '
        Me.btnXemchitiet.ImageIndex = 8
        Me.btnXemchitiet.Text = "Xem chi tiết số ngày nghỉ"
        '
        'btnTinhSoGioHK
        '
        Me.btnTinhSoGioHK.ImageIndex = 5
        Me.btnTinhSoGioHK.Text = "Cập nhật số giờ hành kinh"
        '
        'btnXemDSHKNV
        '
        Me.btnXemDSHKNV.ImageIndex = 8
        Me.btnXemDSHKNV.Text = "Xem danh sách"
        '
        'btnTinhSoGioHKNV
        '
        Me.btnTinhSoGioHKNV.ImageIndex = 5
        Me.btnTinhSoGioHKNV.Text = "Cập nhật hành kinh nghỉ việc"
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
        Me.ImageList1.Images.SetKeyName(10, "document_accept.png")
        '
        'XpCaption2
        '
        Me.XpCaption2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(911, 28)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(907, 50)
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 101)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 7
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlDetail.Controls.Add(Me.tabTraCuu)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(911, 101)
        Me.pnlDetail.TabIndex = 0
        '
        'tabTraCuu
        '
        Appearance32.BackColor = System.Drawing.Color.AliceBlue
        Me.tabTraCuu.Appearance = Appearance32
        Me.tabTraCuu.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTraCuu.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTraCuu.Controls.Add(Me.UltraTabPageControl1)
        Me.tabTraCuu.Controls.Add(Me.UltraTabPageControl3)
        Me.tabTraCuu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTraCuu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabTraCuu.Location = New System.Drawing.Point(0, 28)
        Me.tabTraCuu.Name = "tabTraCuu"
        Me.tabTraCuu.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTraCuu.Size = New System.Drawing.Size(911, 73)
        Me.tabTraCuu.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.tabTraCuu.TabIndex = 7
        Appearance33.BackColor = System.Drawing.Color.AliceBlue
        UltraTab5.Appearance = Appearance33
        UltraTab5.TabPage = Me.UltraTabPageControl2
        UltraTab5.Text = "Thông Tin Nhập Liệu"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Số giờ nghỉ hành kinh trong tháng"
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "Cập nhật hành kinh nghỉ việc"
        Me.tabTraCuu.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5, UltraTab1, UltraTab2})
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(911, 28)
        Me.XpCaption1.TabIndex = 4
        Me.XpCaption1.Text = "Quản lý lao động nữ nghỉ chế độ hành kinh"
        '
        '_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom
        '
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 388)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Name = "_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom"
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(917, 0)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(917, 388)
        Me.UltraGroupBox1.TabIndex = 26
        '
        'frmPhuNuHanhKinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 388)
        Me.Controls.Add(Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "frmPhuNuHanhKinh"
        Me.Text = "frmPhuNuHanhKinh"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.cboDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTraCuu.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents radDV As System.Windows.Forms.RadioButton
    Friend WithEvents cboDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtSothe As System.Windows.Forms.TextBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents bntKiemTraST As TD.SandBar.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents tabTraCuu As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents _frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents radSothe As System.Windows.Forms.RadioButton
    Friend WithEvents btnLuu As TD.SandBar.ButtonItem
    Friend WithEvents btnXoanhom As TD.SandBar.ButtonItem
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As TD.SandBar.ButtonItem
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnXemchitiet As TD.SandBar.ButtonItem
    Friend WithEvents btnTinhSoGioHK As TD.SandBar.ButtonItem
    Friend WithEvents dtpThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnXemDSHKNV As TD.SandBar.ButtonItem
    Friend WithEvents btnTinhSoGioHKNV As TD.SandBar.ButtonItem
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpThangNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDonviNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
