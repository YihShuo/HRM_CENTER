<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaocaochitietgiocong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaocaochitietgiocong))
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.grbDieukienloc = New Infragistics.Win.Misc.UltraGroupBox
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.chbDonvi = New System.Windows.Forms.CheckBox
        Me.lbDonvi = New Infragistics.Win.Misc.UltraLabel
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cbNgaythangnam = New System.Windows.Forms.DateTimePicker
        Me.txtNam = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lbNam = New Infragistics.Win.Misc.UltraLabel
        Me.chbXuong = New System.Windows.Forms.CheckBox
        Me.lbXuong = New Infragistics.Win.Misc.UltraLabel
        Me.txtTuan = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lbTuan = New Infragistics.Win.Misc.UltraLabel
        Me.lbNgay = New Infragistics.Win.Misc.UltraLabel
        Me.chbTuan = New System.Windows.Forms.CheckBox
        Me.chbNgay = New System.Windows.Forms.CheckBox
        Me.grbTKCTgiocong = New Infragistics.Win.Misc.UltraGroupBox
        Me.btCapnhatnam = New System.Windows.Forms.Button
        Me.btCapnhatthang = New System.Windows.Forms.Button
        Me.btCapnhatTuan = New System.Windows.Forms.Button
        Me.btCapnhatngay = New System.Windows.Forms.Button
        Me.rdCTNam = New System.Windows.Forms.RadioButton
        Me.rdCTThang = New System.Windows.Forms.RadioButton
        Me.rdCTTuan = New System.Windows.Forms.RadioButton
        Me.rdCTNgay = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btExcel = New TD.SandBar.ButtonItem
        Me.btXemBCao = New TD.SandBar.ButtonItem
        Me.btRefresh = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.xpDSgiocong = New SteepValley.Windows.Forms.XPCaption
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tabTKCTgiocong = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.xpTKCTgiocong = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDieukienloc.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grbTKCTgiocong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbTKCTgiocong.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tabTKCTgiocong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKCTgiocong.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grbDieukienloc)
        Me.UltraTabPageControl1.Controls.Add(Me.grbTKCTgiocong)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(712, 211)
        '
        'grbDieukienloc
        '
        Me.grbDieukienloc.Controls.Add(Me.cbDonvi)
        Me.grbDieukienloc.Controls.Add(Me.chbDonvi)
        Me.grbDieukienloc.Controls.Add(Me.lbDonvi)
        Me.grbDieukienloc.Controls.Add(Me.cbXuong)
        Me.grbDieukienloc.Controls.Add(Me.cbNgaythangnam)
        Me.grbDieukienloc.Controls.Add(Me.txtNam)
        Me.grbDieukienloc.Controls.Add(Me.lbNam)
        Me.grbDieukienloc.Controls.Add(Me.chbXuong)
        Me.grbDieukienloc.Controls.Add(Me.lbXuong)
        Me.grbDieukienloc.Controls.Add(Me.txtTuan)
        Me.grbDieukienloc.Controls.Add(Me.lbTuan)
        Me.grbDieukienloc.Controls.Add(Me.lbNgay)
        Me.grbDieukienloc.Controls.Add(Me.chbTuan)
        Me.grbDieukienloc.Controls.Add(Me.chbNgay)
        Me.grbDieukienloc.Location = New System.Drawing.Point(381, 39)
        Me.grbDieukienloc.Name = "grbDieukienloc"
        Me.grbDieukienloc.Size = New System.Drawing.Size(286, 139)
        Me.grbDieukienloc.TabIndex = 1
        Me.grbDieukienloc.Text = "Điều Kiện Lọc Báo Cáo"
        '
        'cbDonvi
        '
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Location = New System.Drawing.Point(86, 93)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(128, 21)
        Me.cbDonvi.TabIndex = 17
        '
        'chbDonvi
        '
        Me.chbDonvi.AutoSize = True
        Me.chbDonvi.Location = New System.Drawing.Point(23, 98)
        Me.chbDonvi.Name = "chbDonvi"
        Me.chbDonvi.Size = New System.Drawing.Size(15, 14)
        Me.chbDonvi.TabIndex = 14
        Me.chbDonvi.UseVisualStyleBackColor = True
        '
        'lbDonvi
        '
        Appearance1.TextHAlignAsString = "Left"
        Me.lbDonvi.Appearance = Appearance1
        Me.lbDonvi.Location = New System.Drawing.Point(40, 97)
        Me.lbDonvi.Name = "lbDonvi"
        Me.lbDonvi.Size = New System.Drawing.Size(44, 15)
        Me.lbDonvi.TabIndex = 13
        Me.lbDonvi.Text = "Đơn Vị :"
        '
        'cbXuong
        '
        Me.cbXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbXuong.Location = New System.Drawing.Point(87, 63)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(128, 21)
        Me.cbXuong.TabIndex = 10
        '
        'cbNgaythangnam
        '
        Me.cbNgaythangnam.CustomFormat = "dd/MM/yyyy"
        Me.cbNgaythangnam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNgaythangnam.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cbNgaythangnam.Location = New System.Drawing.Point(87, 30)
        Me.cbNgaythangnam.Name = "cbNgaythangnam"
        Me.cbNgaythangnam.Size = New System.Drawing.Size(128, 20)
        Me.cbNgaythangnam.TabIndex = 6
        '
        'txtNam
        '
        Me.txtNam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNam.Location = New System.Drawing.Point(162, 31)
        Me.txtNam.MaxLength = 4
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(51, 21)
        Me.txtNam.TabIndex = 3
        Me.txtNam.Text = "2009"
        '
        'lbNam
        '
        Appearance2.TextHAlignAsString = "Left"
        Me.lbNam.Appearance = Appearance2
        Me.lbNam.Location = New System.Drawing.Point(123, 37)
        Me.lbNam.Name = "lbNam"
        Me.lbNam.Size = New System.Drawing.Size(34, 15)
        Me.lbNam.TabIndex = 1
        Me.lbNam.Text = "Năm :"
        '
        'chbXuong
        '
        Me.chbXuong.AutoSize = True
        Me.chbXuong.Location = New System.Drawing.Point(24, 66)
        Me.chbXuong.Name = "chbXuong"
        Me.chbXuong.Size = New System.Drawing.Size(15, 14)
        Me.chbXuong.TabIndex = 5
        Me.chbXuong.UseVisualStyleBackColor = True
        '
        'lbXuong
        '
        Appearance4.TextHAlignAsString = "Left"
        Me.lbXuong.Appearance = Appearance4
        Me.lbXuong.Location = New System.Drawing.Point(40, 66)
        Me.lbXuong.Name = "lbXuong"
        Me.lbXuong.Size = New System.Drawing.Size(45, 15)
        Me.lbXuong.TabIndex = 1
        Me.lbXuong.Text = "Xưởng :"
        '
        'txtTuan
        '
        Me.txtTuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTuan.Location = New System.Drawing.Point(87, 31)
        Me.txtTuan.MaxLength = 2
        Me.txtTuan.Name = "txtTuan"
        Me.txtTuan.Size = New System.Drawing.Size(31, 21)
        Me.txtTuan.TabIndex = 3
        Me.txtTuan.Text = "01"
        '
        'lbTuan
        '
        Appearance5.TextHAlignAsString = "Left"
        Me.lbTuan.Appearance = Appearance5
        Me.lbTuan.Location = New System.Drawing.Point(41, 34)
        Me.lbTuan.Name = "lbTuan"
        Me.lbTuan.Size = New System.Drawing.Size(45, 15)
        Me.lbTuan.TabIndex = 1
        Me.lbTuan.Text = "Tuần :"
        '
        'lbNgay
        '
        Appearance6.TextHAlignAsString = "Left"
        Me.lbNgay.Appearance = Appearance6
        Me.lbNgay.Location = New System.Drawing.Point(49, 35)
        Me.lbNgay.Name = "lbNgay"
        Me.lbNgay.Size = New System.Drawing.Size(45, 15)
        Me.lbNgay.TabIndex = 1
        Me.lbNgay.Text = "Ngày :"
        '
        'chbTuan
        '
        Me.chbTuan.AutoSize = True
        Me.chbTuan.Location = New System.Drawing.Point(24, 34)
        Me.chbTuan.Name = "chbTuan"
        Me.chbTuan.Size = New System.Drawing.Size(15, 14)
        Me.chbTuan.TabIndex = 7
        Me.chbTuan.UseVisualStyleBackColor = True
        '
        'chbNgay
        '
        Me.chbNgay.AutoSize = True
        Me.chbNgay.Location = New System.Drawing.Point(24, 34)
        Me.chbNgay.Name = "chbNgay"
        Me.chbNgay.Size = New System.Drawing.Size(15, 14)
        Me.chbNgay.TabIndex = 5
        Me.chbNgay.UseVisualStyleBackColor = True
        '
        'grbTKCTgiocong
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.grbTKCTgiocong.Appearance = Appearance7
        Me.grbTKCTgiocong.Controls.Add(Me.btCapnhatnam)
        Me.grbTKCTgiocong.Controls.Add(Me.btCapnhatthang)
        Me.grbTKCTgiocong.Controls.Add(Me.btCapnhatTuan)
        Me.grbTKCTgiocong.Controls.Add(Me.btCapnhatngay)
        Me.grbTKCTgiocong.Controls.Add(Me.rdCTNam)
        Me.grbTKCTgiocong.Controls.Add(Me.rdCTThang)
        Me.grbTKCTgiocong.Controls.Add(Me.rdCTTuan)
        Me.grbTKCTgiocong.Controls.Add(Me.rdCTNgay)
        Me.grbTKCTgiocong.Location = New System.Drawing.Point(58, 39)
        Me.grbTKCTgiocong.Name = "grbTKCTgiocong"
        Me.grbTKCTgiocong.Size = New System.Drawing.Size(317, 139)
        Me.grbTKCTgiocong.TabIndex = 0
        Me.grbTKCTgiocong.Text = "Thống Kê Chi Tiết Giờ Công"
        Me.grbTKCTgiocong.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        '
        'btCapnhatnam
        '
        Me.btCapnhatnam.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatnam.Location = New System.Drawing.Point(226, 104)
        Me.btCapnhatnam.Name = "btCapnhatnam"
        Me.btCapnhatnam.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatnam.TabIndex = 2
        Me.btCapnhatnam.Text = "Cập Nhật"
        Me.btCapnhatnam.UseVisualStyleBackColor = True
        '
        'btCapnhatthang
        '
        Me.btCapnhatthang.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatthang.Location = New System.Drawing.Point(226, 79)
        Me.btCapnhatthang.Name = "btCapnhatthang"
        Me.btCapnhatthang.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatthang.TabIndex = 2
        Me.btCapnhatthang.Text = "Cập Nhật"
        Me.btCapnhatthang.UseVisualStyleBackColor = True
        '
        'btCapnhatTuan
        '
        Me.btCapnhatTuan.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatTuan.Location = New System.Drawing.Point(226, 54)
        Me.btCapnhatTuan.Name = "btCapnhatTuan"
        Me.btCapnhatTuan.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatTuan.TabIndex = 2
        Me.btCapnhatTuan.Text = "Cập Nhật"
        Me.btCapnhatTuan.UseVisualStyleBackColor = True
        '
        'btCapnhatngay
        '
        Me.btCapnhatngay.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatngay.Location = New System.Drawing.Point(226, 30)
        Me.btCapnhatngay.Name = "btCapnhatngay"
        Me.btCapnhatngay.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatngay.TabIndex = 2
        Me.btCapnhatngay.Text = "Cập Nhật"
        Me.btCapnhatngay.UseVisualStyleBackColor = True
        '
        'rdCTNam
        '
        Me.rdCTNam.AutoSize = True
        Me.rdCTNam.Location = New System.Drawing.Point(34, 107)
        Me.rdCTNam.Name = "rdCTNam"
        Me.rdCTNam.Size = New System.Drawing.Size(183, 17)
        Me.rdCTNam.TabIndex = 0
        Me.rdCTNam.Text = "Thống Kê Chi Tiết Giờ Công Năm"
        Me.rdCTNam.UseVisualStyleBackColor = True
        '
        'rdCTThang
        '
        Me.rdCTThang.AutoSize = True
        Me.rdCTThang.Location = New System.Drawing.Point(34, 82)
        Me.rdCTThang.Name = "rdCTThang"
        Me.rdCTThang.Size = New System.Drawing.Size(192, 17)
        Me.rdCTThang.TabIndex = 0
        Me.rdCTThang.Text = "Thống Kê Chi Tiết Giờ Công Tháng"
        Me.rdCTThang.UseVisualStyleBackColor = True
        '
        'rdCTTuan
        '
        Me.rdCTTuan.AutoSize = True
        Me.rdCTTuan.Location = New System.Drawing.Point(34, 57)
        Me.rdCTTuan.Name = "rdCTTuan"
        Me.rdCTTuan.Size = New System.Drawing.Size(186, 17)
        Me.rdCTTuan.TabIndex = 0
        Me.rdCTTuan.Text = "Thống Kê Chi Tiết Giờ Công Tuần"
        Me.rdCTTuan.UseVisualStyleBackColor = True
        '
        'rdCTNgay
        '
        Me.rdCTNgay.AutoSize = True
        Me.rdCTNgay.Location = New System.Drawing.Point(34, 32)
        Me.rdCTNgay.Name = "rdCTNgay"
        Me.rdCTNgay.Size = New System.Drawing.Size(186, 17)
        Me.rdCTNgay.TabIndex = 0
        Me.rdCTNgay.Text = "Thống Kê Chi Tiết Giờ Công Ngày"
        Me.rdCTNgay.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ToolBar1)
        Me.Panel3.Controls.Add(Me.dgrBC)
        Me.Panel3.Controls.Add(Me.xpDSgiocong)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 232)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(714, 268)
        Me.Panel3.TabIndex = 11
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btExcel, Me.btXemBCao, Me.btRefresh})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(714, 26)
        Me.ToolBar1.TabIndex = 15
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btExcel
        '
        Me.btExcel.ImageIndex = 6
        Me.btExcel.Text = "Excel"
        '
        'btXemBCao
        '
        Me.btXemBCao.ImageIndex = 3
        Me.btXemBCao.Text = "Xem Báo Cáo"
        '
        'btRefresh
        '
        Me.btRefresh.ImageIndex = 7
        Me.btRefresh.Text = "Refresh"
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
        Me.ImageList1.Images.SetKeyName(6, "excel.ico")
        Me.ImageList1.Images.SetKeyName(7, "Refresh.ico")
        '
        'dgrBC
        '
        Me.dgrBC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrBC.Location = New System.Drawing.Point(0, 56)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(714, 212)
        Me.dgrBC.TabIndex = 9
        '
        'xpDSgiocong
        '
        Me.xpDSgiocong.Dock = System.Windows.Forms.DockStyle.Top
        Me.xpDSgiocong.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.xpDSgiocong.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.xpDSgiocong.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.xpDSgiocong.Location = New System.Drawing.Point(0, 0)
        Me.xpDSgiocong.Name = "xpDSgiocong"
        Me.xpDSgiocong.Size = New System.Drawing.Size(714, 24)
        Me.xpDSgiocong.TabIndex = 8
        Me.xpDSgiocong.Text = "Danh Sách Chi Tiết Giờ Công"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 500)
        Me.Panel1.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabTKCTgiocong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(714, 232)
        Me.Panel2.TabIndex = 10
        '
        'tabTKCTgiocong
        '
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColor2 = System.Drawing.Color.White
        Me.tabTKCTgiocong.Appearance = Appearance9
        Me.tabTKCTgiocong.Controls.Add(Me.UltraTabPageControl1)
        Me.tabTKCTgiocong.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTKCTgiocong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTKCTgiocong.Location = New System.Drawing.Point(0, 0)
        Me.tabTKCTgiocong.Name = "tabTKCTgiocong"
        Me.tabTKCTgiocong.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTKCTgiocong.Size = New System.Drawing.Size(714, 232)
        Me.tabTKCTgiocong.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.tabTKCTgiocong.TabIndex = 6
        Appearance10.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance10.BackColor2 = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance10
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thống Kê Chi Tiết Giờ Công"
        Me.tabTKCTgiocong.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.tabTKCTgiocong.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(712, 211)
        '
        'xpTKCTgiocong
        '
        Me.xpTKCTgiocong.Dock = System.Windows.Forms.DockStyle.Top
        Me.xpTKCTgiocong.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xpTKCTgiocong.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.xpTKCTgiocong.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.xpTKCTgiocong.Location = New System.Drawing.Point(0, 0)
        Me.xpTKCTgiocong.Name = "xpTKCTgiocong"
        Me.xpTKCTgiocong.Size = New System.Drawing.Size(714, 24)
        Me.xpTKCTgiocong.TabIndex = 13
        Me.xpTKCTgiocong.Text = "Thống Kê Chi Tiết Giờ Công"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.TruncateData
        '
        'frmBaocaochitietgiocong
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(714, 524)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.xpTKCTgiocong)
        Me.Name = "frmBaocaochitietgiocong"
        Me.ShowIcon = False
        Me.Text = "Thống Kê Chi Tiết Giờ Công"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDieukienloc.ResumeLayout(False)
        Me.grbDieukienloc.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grbTKCTgiocong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbTKCTgiocong.ResumeLayout(False)
        Me.grbTKCTgiocong.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.tabTKCTgiocong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKCTgiocong.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents xpDSgiocong As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grbDieukienloc As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cbNgaythangnam As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNam As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lbNam As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chbTuan As System.Windows.Forms.CheckBox
    Friend WithEvents chbNgay As System.Windows.Forms.CheckBox
    Friend WithEvents chbXuong As System.Windows.Forms.CheckBox
    Friend WithEvents lbXuong As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbTuan As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbNgay As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtTuan As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents grbTKCTgiocong As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents rdCTThang As System.Windows.Forms.RadioButton
    Friend WithEvents rdCTTuan As System.Windows.Forms.RadioButton
    Friend WithEvents rdCTNgay As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabTKCTgiocong As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents xpTKCTgiocong As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents rdCTNam As System.Windows.Forms.RadioButton
    Friend WithEvents chbDonvi As System.Windows.Forms.CheckBox
    Friend WithEvents lbDonvi As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btCapnhatnam As System.Windows.Forms.Button
    Friend WithEvents btCapnhatthang As System.Windows.Forms.Button
    Friend WithEvents btCapnhatTuan As System.Windows.Forms.Button
    Friend WithEvents btCapnhatngay As System.Windows.Forms.Button
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btExcel As TD.SandBar.ButtonItem
    Friend WithEvents btXemBCao As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btRefresh As TD.SandBar.ButtonItem
End Class
