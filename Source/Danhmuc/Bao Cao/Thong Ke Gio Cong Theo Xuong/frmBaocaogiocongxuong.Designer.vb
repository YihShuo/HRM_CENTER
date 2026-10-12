<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaocaogiocongxuong
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaocaogiocongxuong))
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.grbDieukienloc = New Infragistics.Win.Misc.UltraGroupBox
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cbNgaythangnam = New System.Windows.Forms.DateTimePicker
        Me.txtNam = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lbNam = New Infragistics.Win.Misc.UltraLabel
        Me.chbTuan = New System.Windows.Forms.CheckBox
        Me.chbNgay = New System.Windows.Forms.CheckBox
        Me.chbXuong = New System.Windows.Forms.CheckBox
        Me.lbXuong = New Infragistics.Win.Misc.UltraLabel
        Me.txtTuan = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lbNgay = New Infragistics.Win.Misc.UltraLabel
        Me.lbTuan = New Infragistics.Win.Misc.UltraLabel
        Me.grbTKgiocongxuong = New Infragistics.Win.Misc.UltraGroupBox
        Me.btCapnhatnam = New System.Windows.Forms.Button
        Me.btCapnhatthang = New System.Windows.Forms.Button
        Me.btCapnhattuan = New System.Windows.Forms.Button
        Me.btCapnhatngay = New System.Windows.Forms.Button
        Me.rdKTNamXuong = New System.Windows.Forms.RadioButton
        Me.rdKTThangXuong = New System.Windows.Forms.RadioButton
        Me.rdKTTuanXuong = New System.Windows.Forms.RadioButton
        Me.rdKTNgayXuong = New System.Windows.Forms.RadioButton
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.xpDSgiocong = New SteepValley.Windows.Forms.XPCaption
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btExcel = New TD.SandBar.ButtonItem
        Me.btXemBaoCao = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tabTKgiocongxuong = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.xpTKgiocong = New SteepValley.Windows.Forms.XPCaption
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.btRefresh = New TD.SandBar.ButtonItem
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDieukienloc.SuspendLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grbTKgiocongxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbTKgiocongxuong.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKgiocongxuong.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grbDieukienloc)
        Me.UltraTabPageControl1.Controls.Add(Me.grbTKgiocongxuong)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(673, 211)
        '
        'grbDieukienloc
        '
        Me.grbDieukienloc.Controls.Add(Me.cbXuong)
        Me.grbDieukienloc.Controls.Add(Me.cbNgaythangnam)
        Me.grbDieukienloc.Controls.Add(Me.txtNam)
        Me.grbDieukienloc.Controls.Add(Me.lbNam)
        Me.grbDieukienloc.Controls.Add(Me.chbTuan)
        Me.grbDieukienloc.Controls.Add(Me.chbNgay)
        Me.grbDieukienloc.Controls.Add(Me.chbXuong)
        Me.grbDieukienloc.Controls.Add(Me.lbXuong)
        Me.grbDieukienloc.Controls.Add(Me.txtTuan)
        Me.grbDieukienloc.Controls.Add(Me.lbNgay)
        Me.grbDieukienloc.Controls.Add(Me.lbTuan)
        Me.grbDieukienloc.Location = New System.Drawing.Point(318, 29)
        Me.grbDieukienloc.Name = "grbDieukienloc"
        Me.grbDieukienloc.Size = New System.Drawing.Size(326, 142)
        Me.grbDieukienloc.TabIndex = 1
        Me.grbDieukienloc.Text = "Điều Kiện Lọc Báo Cáo"
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
        Me.cbNgaythangnam.Location = New System.Drawing.Point(87, 31)
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
        Appearance1.TextHAlignAsString = "Left"
        Me.lbNam.Appearance = Appearance1
        Me.lbNam.Location = New System.Drawing.Point(123, 37)
        Me.lbNam.Name = "lbNam"
        Me.lbNam.Size = New System.Drawing.Size(34, 15)
        Me.lbNam.TabIndex = 1
        Me.lbNam.Text = "Năm :"
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
        Appearance3.TextHAlignAsString = "Left"
        Me.lbXuong.Appearance = Appearance3
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
        'lbNgay
        '
        Appearance4.TextHAlignAsString = "Left"
        Me.lbNgay.Appearance = Appearance4
        Me.lbNgay.Location = New System.Drawing.Point(49, 35)
        Me.lbNgay.Name = "lbNgay"
        Me.lbNgay.Size = New System.Drawing.Size(45, 15)
        Me.lbNgay.TabIndex = 1
        Me.lbNgay.Text = "Ngày :"
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
        'grbTKgiocongxuong
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Me.grbTKgiocongxuong.Appearance = Appearance6
        Me.grbTKgiocongxuong.Controls.Add(Me.btCapnhatnam)
        Me.grbTKgiocongxuong.Controls.Add(Me.btCapnhatthang)
        Me.grbTKgiocongxuong.Controls.Add(Me.btCapnhattuan)
        Me.grbTKgiocongxuong.Controls.Add(Me.btCapnhatngay)
        Me.grbTKgiocongxuong.Controls.Add(Me.rdKTNamXuong)
        Me.grbTKgiocongxuong.Controls.Add(Me.rdKTThangXuong)
        Me.grbTKgiocongxuong.Controls.Add(Me.rdKTTuanXuong)
        Me.grbTKgiocongxuong.Controls.Add(Me.rdKTNgayXuong)
        Me.grbTKgiocongxuong.Location = New System.Drawing.Point(36, 29)
        Me.grbTKgiocongxuong.Name = "grbTKgiocongxuong"
        Me.grbTKgiocongxuong.Size = New System.Drawing.Size(276, 142)
        Me.grbTKgiocongxuong.TabIndex = 0
        Me.grbTKgiocongxuong.Text = "Thống Kê Giờ Công Theo Xưởng"
        Me.grbTKgiocongxuong.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        '
        'btCapnhatnam
        '
        Me.btCapnhatnam.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatnam.Location = New System.Drawing.Point(188, 104)
        Me.btCapnhatnam.Name = "btCapnhatnam"
        Me.btCapnhatnam.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatnam.TabIndex = 2
        Me.btCapnhatnam.Text = "Cập Nhật"
        Me.btCapnhatnam.UseVisualStyleBackColor = True
        '
        'btCapnhatthang
        '
        Me.btCapnhatthang.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatthang.Location = New System.Drawing.Point(188, 79)
        Me.btCapnhatthang.Name = "btCapnhatthang"
        Me.btCapnhatthang.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatthang.TabIndex = 2
        Me.btCapnhatthang.Text = "Cập Nhật"
        Me.btCapnhatthang.UseVisualStyleBackColor = True
        '
        'btCapnhattuan
        '
        Me.btCapnhattuan.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhattuan.Location = New System.Drawing.Point(188, 54)
        Me.btCapnhattuan.Name = "btCapnhattuan"
        Me.btCapnhattuan.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhattuan.TabIndex = 2
        Me.btCapnhattuan.Text = "Cập Nhật"
        Me.btCapnhattuan.UseVisualStyleBackColor = True
        '
        'btCapnhatngay
        '
        Me.btCapnhatngay.ForeColor = System.Drawing.Color.Blue
        Me.btCapnhatngay.Location = New System.Drawing.Point(188, 29)
        Me.btCapnhatngay.Name = "btCapnhatngay"
        Me.btCapnhatngay.Size = New System.Drawing.Size(75, 23)
        Me.btCapnhatngay.TabIndex = 2
        Me.btCapnhatngay.Text = "Cập Nhật"
        Me.btCapnhatngay.UseVisualStyleBackColor = True
        '
        'rdKTNamXuong
        '
        Me.rdKTNamXuong.AutoSize = True
        Me.rdKTNamXuong.Location = New System.Drawing.Point(34, 107)
        Me.rdKTNamXuong.Name = "rdKTNamXuong"
        Me.rdKTNamXuong.Size = New System.Drawing.Size(147, 17)
        Me.rdKTNamXuong.TabIndex = 0
        Me.rdKTNamXuong.Text = "Thống Kê Giờ Công  Năm"
        Me.rdKTNamXuong.UseVisualStyleBackColor = True
        '
        'rdKTThangXuong
        '
        Me.rdKTThangXuong.AutoSize = True
        Me.rdKTThangXuong.Location = New System.Drawing.Point(34, 82)
        Me.rdKTThangXuong.Name = "rdKTThangXuong"
        Me.rdKTThangXuong.Size = New System.Drawing.Size(153, 17)
        Me.rdKTThangXuong.TabIndex = 0
        Me.rdKTThangXuong.Text = "Thống Kê Giờ Công Tháng"
        Me.rdKTThangXuong.UseVisualStyleBackColor = True
        '
        'rdKTTuanXuong
        '
        Me.rdKTTuanXuong.AutoSize = True
        Me.rdKTTuanXuong.Location = New System.Drawing.Point(34, 57)
        Me.rdKTTuanXuong.Name = "rdKTTuanXuong"
        Me.rdKTTuanXuong.Size = New System.Drawing.Size(147, 17)
        Me.rdKTTuanXuong.TabIndex = 0
        Me.rdKTTuanXuong.Text = "Thống Kê Giờ Công Tuần"
        Me.rdKTTuanXuong.UseVisualStyleBackColor = True
        '
        'rdKTNgayXuong
        '
        Me.rdKTNgayXuong.AutoSize = True
        Me.rdKTNgayXuong.Location = New System.Drawing.Point(34, 32)
        Me.rdKTNgayXuong.Name = "rdKTNgayXuong"
        Me.rdKTNgayXuong.Size = New System.Drawing.Size(150, 17)
        Me.rdKTNgayXuong.TabIndex = 0
        Me.rdKTNgayXuong.Text = "Thống Kê Giờ Công  Ngày"
        Me.rdKTNgayXuong.UseVisualStyleBackColor = True
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(673, 211)
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(675, 143)
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
        Me.xpDSgiocong.Size = New System.Drawing.Size(675, 24)
        Me.xpDSgiocong.TabIndex = 8
        Me.xpDSgiocong.Text = "Danh Sách Giờ Công"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 429)
        Me.Panel1.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 232)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(675, 197)
        Me.Panel3.TabIndex = 11
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgrBC)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 54)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(675, 143)
        Me.Panel5.TabIndex = 15
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.xpDSgiocong)
        Me.Panel4.Controls.Add(Me.ToolBar1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(675, 54)
        Me.Panel4.TabIndex = 14
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btExcel, Me.btXemBaoCao, Me.btRefresh})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 25)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(675, 26)
        Me.ToolBar1.TabIndex = 13
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btExcel
        '
        Me.btExcel.ImageIndex = 6
        Me.btExcel.Text = "Excel"
        '
        'btXemBaoCao
        '
        Me.btXemBaoCao.ImageIndex = 3
        Me.btXemBaoCao.Text = "Xem Báo Cáo"
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabTKgiocongxuong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 232)
        Me.Panel2.TabIndex = 10
        '
        'tabTKgiocongxuong
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BackColor2 = System.Drawing.Color.White
        Me.tabTKgiocongxuong.Appearance = Appearance8
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabPageControl1)
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTKgiocongxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTKgiocongxuong.Location = New System.Drawing.Point(0, 0)
        Me.tabTKgiocongxuong.Name = "tabTKgiocongxuong"
        Me.tabTKgiocongxuong.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTKgiocongxuong.Size = New System.Drawing.Size(675, 232)
        Me.tabTKgiocongxuong.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.tabTKgiocongxuong.TabIndex = 6
        Appearance9.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance9.BackColor2 = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance9
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thống Kê Giờ Công Theo Xưởng"
        Me.tabTKgiocongxuong.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.tabTKgiocongxuong.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'xpTKgiocong
        '
        Me.xpTKgiocong.Dock = System.Windows.Forms.DockStyle.Top
        Me.xpTKgiocong.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xpTKgiocong.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.xpTKgiocong.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.xpTKgiocong.Location = New System.Drawing.Point(0, 0)
        Me.xpTKgiocong.Name = "xpTKgiocong"
        Me.xpTKgiocong.Size = New System.Drawing.Size(675, 24)
        Me.xpTKgiocong.TabIndex = 11
        Me.xpTKgiocong.Text = "Thống Kê Giờ Công"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.TruncateData
        '
        'btRefresh
        '
        Me.btRefresh.ImageIndex = 7
        Me.btRefresh.Text = "Refresh"
        '
        'frmBaocaogiocongxuong
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(675, 453)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.xpTKgiocong)
        Me.Name = "frmBaocaogiocongxuong"
        Me.ShowIcon = False
        Me.Text = "Thống Kê Giờ Công"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDieukienloc.ResumeLayout(False)
        Me.grbDieukienloc.PerformLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grbTKgiocongxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbTKgiocongxuong.ResumeLayout(False)
        Me.grbTKgiocongxuong.PerformLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKgiocongxuong.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents grbTKgiocongxuong As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents rdKTNamXuong As System.Windows.Forms.RadioButton
    Friend WithEvents rdKTThangXuong As System.Windows.Forms.RadioButton
    Friend WithEvents rdKTTuanXuong As System.Windows.Forms.RadioButton
    Friend WithEvents rdKTNgayXuong As System.Windows.Forms.RadioButton
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents xpDSgiocong As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tabTKgiocongxuong As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents xpTKgiocong As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btCapnhatnam As System.Windows.Forms.Button
    Friend WithEvents btCapnhatthang As System.Windows.Forms.Button
    Friend WithEvents btCapnhattuan As System.Windows.Forms.Button
    Friend WithEvents btCapnhatngay As System.Windows.Forms.Button
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btExcel As TD.SandBar.ButtonItem
    Friend WithEvents btXemBaoCao As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btRefresh As TD.SandBar.ButtonItem
End Class
