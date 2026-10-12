<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXinDiKhamBenh
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXinDiKhamBenh))
        Dim SpinEditorButton1 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Dim SpinEditorButton2 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.linkNoiKCB = New System.Windows.Forms.LinkLabel
        Me.cboNoiKCB = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDonVi = New System.Windows.Forms.TextBox
        Me.txtGhiChu = New System.Windows.Forms.TextBox
        Me.txtChanDoan = New System.Windows.Forms.TextBox
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.txtSothe = New System.Windows.Forms.TextBox
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtpThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pnlList = New System.Windows.Forms.Panel
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.bntKiemTraST = New TD.SandBar.ToolBar
        Me.btSua = New TD.SandBar.ButtonItem
        Me.btXoa = New TD.SandBar.ButtonItem
        Me.btExcel = New TD.SandBar.ButtonItem
        Me.ButtonItem1 = New TD.SandBar.ButtonItem
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpThangNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDonviNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboNoiKCB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgrBC.Size = New System.Drawing.Size(976, 278)
        Me.dgrBC.TabIndex = 8
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
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
        Me.XpCaption2.Size = New System.Drawing.Size(976, 28)
        Me.XpCaption2.TabIndex = 16
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        '_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom
        '
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 538)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Name = "_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom"
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(982, 0)
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 191)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 15
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlDetail.Controls.Add(Me.GroupBox1)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(976, 191)
        Me.pnlDetail.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.linkNoiKCB)
        Me.GroupBox1.Controls.Add(Me.cboNoiKCB)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDonVi)
        Me.GroupBox1.Controls.Add(Me.txtGhiChu)
        Me.GroupBox1.Controls.Add(Me.txtChanDoan)
        Me.GroupBox1.Controls.Add(Me.txtHoTen)
        Me.GroupBox1.Controls.Add(Me.txtSothe)
        Me.GroupBox1.Controls.Add(Me.dtpNgay)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(976, 163)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'linkNoiKCB
        '
        Me.linkNoiKCB.AutoSize = True
        Me.linkNoiKCB.Location = New System.Drawing.Point(181, 48)
        Me.linkNoiKCB.Name = "linkNoiKCB"
        Me.linkNoiKCB.Size = New System.Drawing.Size(112, 13)
        Me.linkNoiKCB.TabIndex = 9
        Me.linkNoiKCB.TabStop = True
        Me.linkNoiKCB.Text = "Nơi khám chữa bệnh :"
        '
        'cboNoiKCB
        '
        Me.cboNoiKCB.AlwaysInEditMode = True
        Me.cboNoiKCB.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboNoiKCB.DisplayMember = "DV_TEN"
        Me.cboNoiKCB.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboNoiKCB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNoiKCB.Location = New System.Drawing.Point(296, 44)
        Me.cboNoiKCB.Name = "cboNoiKCB"
        Me.cboNoiKCB.Size = New System.Drawing.Size(369, 22)
        Me.cboNoiKCB.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue
        Me.cboNoiKCB.TabIndex = 10
        Me.cboNoiKCB.ValueMember = "DV_MA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(22, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Ghi chú:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(7, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Chẩn đoán:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(34, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ngày:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(26, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Số thẻ :"
        '
        'txtDonVi
        '
        Me.txtDonVi.Enabled = False
        Me.txtDonVi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDonVi.HideSelection = False
        Me.txtDonVi.Location = New System.Drawing.Point(430, 18)
        Me.txtDonVi.Name = "txtDonVi"
        Me.txtDonVi.Size = New System.Drawing.Size(235, 21)
        Me.txtDonVi.TabIndex = 6
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGhiChu.HideSelection = False
        Me.txtGhiChu.Location = New System.Drawing.Point(72, 116)
        Me.txtGhiChu.Multiline = True
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(355, 41)
        Me.txtGhiChu.TabIndex = 14
        '
        'txtChanDoan
        '
        Me.txtChanDoan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChanDoan.HideSelection = False
        Me.txtChanDoan.Location = New System.Drawing.Point(72, 72)
        Me.txtChanDoan.Multiline = True
        Me.txtChanDoan.Name = "txtChanDoan"
        Me.txtChanDoan.Size = New System.Drawing.Size(355, 41)
        Me.txtChanDoan.TabIndex = 12
        '
        'txtHoTen
        '
        Me.txtHoTen.Enabled = False
        Me.txtHoTen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoTen.HideSelection = False
        Me.txtHoTen.Location = New System.Drawing.Point(173, 19)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(254, 21)
        Me.txtHoTen.TabIndex = 5
        '
        'txtSothe
        '
        Me.txtSothe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSothe.HideSelection = False
        Me.txtSothe.Location = New System.Drawing.Point(72, 19)
        Me.txtSothe.MaxLength = 6
        Me.txtSothe.Name = "txtSothe"
        Me.txtSothe.Size = New System.Drawing.Size(98, 21)
        Me.txtSothe.TabIndex = 4
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(72, 46)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(98, 20)
        Me.dtpNgay.TabIndex = 8
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(976, 28)
        Me.XpCaption1.TabIndex = 1
        Me.XpCaption1.Text = "Quản lý lao động nghỉ khám chữa bệnh"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.dtpThang)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(784, 50)
        '
        'dtpThang
        '
        SpinEditorButton1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThang.ButtonsRight.Add(SpinEditorButton1)
        Me.dtpThang.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThang.Location = New System.Drawing.Point(97, 12)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(128, 21)
        Me.dtpThang.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tháng:"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 4
        Me.btnLuu.Tag = "18"
        Me.btnLuu.Text = "Lưu"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(982, 538)
        Me.UltraGroupBox1.TabIndex = 28
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 199)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(976, 336)
        Me.pnlList.TabIndex = 5
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.bntKiemTraST)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(976, 58)
        Me.pnlButton.TabIndex = 7
        '
        'bntKiemTraST
        '
        Me.bntKiemTraST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntKiemTraST.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnLuu, Me.btSua, Me.btXoa, Me.btExcel, Me.ButtonItem1})
        Me.bntKiemTraST.Dock = System.Windows.Forms.DockStyle.None
        Me.bntKiemTraST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntKiemTraST.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.bntKiemTraST.ImageList = Me.ImageList1
        Me.bntKiemTraST.Location = New System.Drawing.Point(1, 27)
        Me.bntKiemTraST.Name = "bntKiemTraST"
        Me.bntKiemTraST.Size = New System.Drawing.Size(974, 26)
        Me.bntKiemTraST.TabIndex = 17
        Me.bntKiemTraST.Text = "ToolBar1"
        '
        'btSua
        '
        Me.btSua.ImageIndex = 1
        Me.btSua.Tag = "19"
        Me.btSua.Text = "Sửa"
        '
        'btXoa
        '
        Me.btXoa.ImageIndex = 2
        Me.btXoa.Tag = "20"
        Me.btXoa.Text = "Xóa"
        '
        'btExcel
        '
        Me.btExcel.ImageIndex = 9
        Me.btExcel.Text = "Excel"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Label4)
        Me.UltraTabPageControl3.Controls.Add(Me.dtpThangNV)
        Me.UltraTabPageControl3.Controls.Add(Me.Label3)
        Me.UltraTabPageControl3.Controls.Add(Me.cboDonviNV)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(784, 50)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
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
        Me.dtpThangNV.Size = New System.Drawing.Size(128, 21)
        Me.dtpThangNV.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
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
        'frmXinDiKhamBenh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 538)
        Me.Controls.Add(Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "frmXinDiKhamBenh"
        Me.Tag = "0"
        Me.Text = "frmXinDiKhamBenh"
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboNoiKCB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents _frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents dtpThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnLuu As TD.SandBar.ButtonItem
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents bntKiemTraST As TD.SandBar.ToolBar
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpThangNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDonviNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDonVi As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents txtSothe As System.Windows.Forms.TextBox
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents linkNoiKCB As System.Windows.Forms.LinkLabel
    Friend WithEvents cboNoiKCB As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtChanDoan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGhiChu As System.Windows.Forms.TextBox
    Friend WithEvents btSua As TD.SandBar.ButtonItem
    Friend WithEvents btXoa As TD.SandBar.ButtonItem
    Friend WithEvents btExcel As TD.SandBar.ButtonItem
    Friend WithEvents ButtonItem1 As TD.SandBar.ButtonItem
End Class
