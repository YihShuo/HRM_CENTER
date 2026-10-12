Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO

Public Class frmQTSaiQuiDinh
    Inherits Form
    ' Methods
    Public Tabletk As DataTable
    Dim tblXuong, tblKhu As DataTable
    Dim obj As New objQTSaiQuiDinh



    Public sChuoiTieuDe As String = ""
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNgaycuoithang As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents radVaoTreRaSom As System.Windows.Forms.RadioButton
    Friend WithEvents RadVaoSomRaTre As System.Windows.Forms.RadioButton
    Friend WithEvents radRaSom As System.Windows.Forms.RadioButton
    Friend WithEvents radRaTre As System.Windows.Forms.RadioButton
    Friend WithEvents radTatca As System.Windows.Forms.RadioButton
    Friend WithEvents radVaoTre As System.Windows.Forms.RadioButton
    Friend WithEvents radVaoSom As System.Windows.Forms.RadioButton
    Friend WithEvents chkDaChamCong As System.Windows.Forms.CheckBox
    Friend WithEvents chkKhongTinhTangCa As System.Windows.Forms.CheckBox
    Friend WithEvents lblNgaydauthang As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkTongSoLan As System.Windows.Forms.CheckBox
    Friend WithEvents cbKhu As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public i As Integer
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmQTSaiQuiDinh_Load)
        Me.InitializeComponent()
    End Sub
    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQTSaiQuiDinh))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbKhu = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.radThang = New System.Windows.Forms.RadioButton()
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.radTuan = New System.Windows.Forms.RadioButton()
        Me.radNgay = New System.Windows.Forms.RadioButton()
        Me.txtThang = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtTuan = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNgaykt = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNgaybd = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNgaykt = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTuNgay = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNgaycuoithang = New Infragistics.Win.Misc.UltraLabel()
        Me.radVaoTreRaSom = New System.Windows.Forms.RadioButton()
        Me.RadVaoSomRaTre = New System.Windows.Forms.RadioButton()
        Me.radRaSom = New System.Windows.Forms.RadioButton()
        Me.radRaTre = New System.Windows.Forms.RadioButton()
        Me.radTatca = New System.Windows.Forms.RadioButton()
        Me.radVaoTre = New System.Windows.Forms.RadioButton()
        Me.radVaoSom = New System.Windows.Forms.RadioButton()
        Me.chkDaChamCong = New System.Windows.Forms.CheckBox()
        Me.chkTongSoLan = New System.Windows.Forms.CheckBox()
        Me.chkKhongTinhTangCa = New System.Windows.Forms.CheckBox()
        Me.lblNgaydauthang = New Infragistics.Win.Misc.UltraLabel()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption()
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.ToolBar1 = New TD.SandBar.ToolBar()
        Me.btnExcel = New TD.SandBar.ButtonItem()
        Me.btnXem = New TD.SandBar.ButtonItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption()
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaybd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.AutoScroll = True
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox2)
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1024, 110)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbKhu)
        Me.GroupBox2.Controls.Add(Me.ProgressBar)
        Me.GroupBox2.Controls.Add(Me.radThang)
        Me.GroupBox2.Controls.Add(Me.cbXuong)
        Me.GroupBox2.Controls.Add(Me.radTuan)
        Me.GroupBox2.Controls.Add(Me.radNgay)
        Me.GroupBox2.Controls.Add(Me.txtThang)
        Me.GroupBox2.Controls.Add(Me.txtTuan)
        Me.GroupBox2.Controls.Add(Me.txtNgaykt)
        Me.GroupBox2.Controls.Add(Me.txtNgaybd)
        Me.GroupBox2.Controls.Add(Me.lblNgaykt)
        Me.GroupBox2.Controls.Add(Me.lblTuNgay)
        Me.GroupBox2.Controls.Add(Me.dtpNgay)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Điều Kiện Lọc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Khu : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(344, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Xưởng : "
        '
        'cbKhu
        '
        Me.cbKhu.DisplayMember = ""
        Me.cbKhu.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKhu.Location = New System.Drawing.Point(222, 21)
        Me.cbKhu.Name = "cbKhu"
        Me.cbKhu.Size = New System.Drawing.Size(85, 21)
        Me.cbKhu.TabIndex = 29
        Me.cbKhu.ValueMember = "DV_MA"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(222, 73)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(200, 18)
        Me.ProgressBar.TabIndex = 26
        '
        'radThang
        '
        Me.radThang.AutoSize = True
        Me.radThang.Location = New System.Drawing.Point(8, 66)
        Me.radThang.Name = "radThang"
        Me.radThang.Size = New System.Drawing.Size(55, 18)
        Me.radThang.TabIndex = 3
        Me.radThang.Text = "Tháng"
        Me.radThang.UseVisualStyleBackColor = True
        '
        'cbXuong
        '
        Me.cbXuong.DisplayMember = ""
        Me.cbXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbXuong.Location = New System.Drawing.Point(330, 21)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(92, 21)
        Me.cbXuong.TabIndex = 27
        Me.cbXuong.ValueMember = "DV_MA"
        '
        'radTuan
        '
        Me.radTuan.AutoSize = True
        Me.radTuan.Location = New System.Drawing.Point(8, 40)
        Me.radTuan.Name = "radTuan"
        Me.radTuan.Size = New System.Drawing.Size(71, 18)
        Me.radTuan.TabIndex = 3
        Me.radTuan.Text = "Tuần thứ:"
        Me.radTuan.UseVisualStyleBackColor = True
        '
        'radNgay
        '
        Me.radNgay.AutoSize = True
        Me.radNgay.Checked = True
        Me.radNgay.Location = New System.Drawing.Point(9, 16)
        Me.radNgay.Name = "radNgay"
        Me.radNgay.Size = New System.Drawing.Size(50, 18)
        Me.radNgay.TabIndex = 3
        Me.radNgay.TabStop = True
        Me.radNgay.Text = "Ngày"
        Me.radNgay.UseVisualStyleBackColor = True
        '
        'txtThang
        '
        Me.txtThang.Enabled = False
        Me.txtThang.Location = New System.Drawing.Point(87, 65)
        Me.txtThang.Name = "txtThang"
        Me.txtThang.Size = New System.Drawing.Size(60, 21)
        Me.txtThang.TabIndex = 23
        '
        'txtTuan
        '
        Me.txtTuan.Enabled = False
        Me.txtTuan.Location = New System.Drawing.Point(87, 38)
        Me.txtTuan.Name = "txtTuan"
        Me.txtTuan.Size = New System.Drawing.Size(60, 21)
        Me.txtTuan.TabIndex = 23
        '
        'txtNgaykt
        '
        Me.txtNgaykt.Enabled = False
        Me.txtNgaykt.Location = New System.Drawing.Point(330, 46)
        Me.txtNgaykt.Name = "txtNgaykt"
        Me.txtNgaykt.Size = New System.Drawing.Size(92, 21)
        Me.txtNgaykt.TabIndex = 24
        '
        'txtNgaybd
        '
        Me.txtNgaybd.Enabled = False
        Me.txtNgaybd.Location = New System.Drawing.Point(222, 46)
        Me.txtNgaybd.Name = "txtNgaybd"
        Me.txtNgaybd.Size = New System.Drawing.Size(85, 21)
        Me.txtNgaybd.TabIndex = 25
        '
        'lblNgaykt
        '
        Me.lblNgaykt.Location = New System.Drawing.Point(313, 46)
        Me.lblNgaykt.Name = "lblNgaykt"
        Me.lblNgaykt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNgaykt.Size = New System.Drawing.Size(20, 21)
        Me.lblNgaykt.TabIndex = 21
        Me.lblNgaykt.Text = "-"
        '
        'lblTuNgay
        '
        Me.lblTuNgay.Location = New System.Drawing.Point(163, 48)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(70, 19)
        Me.lblTuNgay.TabIndex = 20
        Me.lblTuNgay.Text = "Bắt đầu từ :"
        '
        'dtpNgay
        '
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(68, 13)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(79, 20)
        Me.dtpNgay.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblNgaycuoithang)
        Me.GroupBox1.Controls.Add(Me.radVaoTreRaSom)
        Me.GroupBox1.Controls.Add(Me.RadVaoSomRaTre)
        Me.GroupBox1.Controls.Add(Me.radRaSom)
        Me.GroupBox1.Controls.Add(Me.radRaTre)
        Me.GroupBox1.Controls.Add(Me.radTatca)
        Me.GroupBox1.Controls.Add(Me.radVaoTre)
        Me.GroupBox1.Controls.Add(Me.radVaoSom)
        Me.GroupBox1.Controls.Add(Me.chkDaChamCong)
        Me.GroupBox1.Controls.Add(Me.chkTongSoLan)
        Me.GroupBox1.Controls.Add(Me.chkKhongTinhTangCa)
        Me.GroupBox1.Controls.Add(Me.lblNgaydauthang)
        Me.GroupBox1.Location = New System.Drawing.Point(456, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 97)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tùy chọn"
        '
        'lblNgaycuoithang
        '
        Me.lblNgaycuoithang.Location = New System.Drawing.Point(202, 68)
        Me.lblNgaycuoithang.Name = "lblNgaycuoithang"
        Me.lblNgaycuoithang.Size = New System.Drawing.Size(70, 19)
        Me.lblNgaycuoithang.TabIndex = 31
        Me.lblNgaycuoithang.Text = "2 :"
        Me.lblNgaycuoithang.Visible = False
        '
        'radVaoTreRaSom
        '
        Me.radVaoTreRaSom.AutoSize = True
        Me.radVaoTreRaSom.Location = New System.Drawing.Point(202, 40)
        Me.radVaoTreRaSom.Name = "radVaoTreRaSom"
        Me.radVaoTreRaSom.Size = New System.Drawing.Size(105, 18)
        Me.radVaoTreRaSom.TabIndex = 39
        Me.radVaoTreRaSom.Text = "Vào trễ - ra sớm"
        Me.radVaoTreRaSom.UseVisualStyleBackColor = True
        '
        'RadVaoSomRaTre
        '
        Me.RadVaoSomRaTre.AutoSize = True
        Me.RadVaoSomRaTre.Location = New System.Drawing.Point(203, 13)
        Me.RadVaoSomRaTre.Name = "RadVaoSomRaTre"
        Me.RadVaoSomRaTre.Size = New System.Drawing.Size(105, 18)
        Me.RadVaoSomRaTre.TabIndex = 38
        Me.RadVaoSomRaTre.Text = "Vào sớm - ra trễ"
        Me.RadVaoSomRaTre.UseVisualStyleBackColor = True
        '
        'radRaSom
        '
        Me.radRaSom.AutoSize = True
        Me.radRaSom.Location = New System.Drawing.Point(106, 40)
        Me.radRaSom.Name = "radRaSom"
        Me.radRaSom.Size = New System.Drawing.Size(62, 18)
        Me.radRaSom.TabIndex = 37
        Me.radRaSom.Text = "Ra sớm"
        Me.radRaSom.UseVisualStyleBackColor = True
        '
        'radRaTre
        '
        Me.radRaTre.AutoSize = True
        Me.radRaTre.Location = New System.Drawing.Point(106, 14)
        Me.radRaTre.Name = "radRaTre"
        Me.radRaTre.Size = New System.Drawing.Size(54, 18)
        Me.radRaTre.TabIndex = 40
        Me.radRaTre.Text = "Ra trễ"
        Me.radRaTre.UseVisualStyleBackColor = True
        '
        'radTatca
        '
        Me.radTatca.AutoSize = True
        Me.radTatca.Checked = True
        Me.radTatca.Location = New System.Drawing.Point(24, 63)
        Me.radTatca.Name = "radTatca"
        Me.radTatca.Size = New System.Drawing.Size(55, 18)
        Me.radTatca.TabIndex = 35
        Me.radTatca.TabStop = True
        Me.radTatca.Text = "Tất cả"
        Me.tolTip.SetToolTip(Me.radTatca, "vào sớm -ra trễ ; vào trễ - ra sớm")
        Me.radTatca.UseVisualStyleBackColor = True
        '
        'radVaoTre
        '
        Me.radVaoTre.AutoSize = True
        Me.radVaoTre.Location = New System.Drawing.Point(24, 40)
        Me.radVaoTre.Name = "radVaoTre"
        Me.radVaoTre.Size = New System.Drawing.Size(61, 18)
        Me.radVaoTre.TabIndex = 36
        Me.radVaoTre.Text = "Vào trễ"
        Me.radVaoTre.UseVisualStyleBackColor = True
        '
        'radVaoSom
        '
        Me.radVaoSom.AutoSize = True
        Me.radVaoSom.Location = New System.Drawing.Point(25, 14)
        Me.radVaoSom.Name = "radVaoSom"
        Me.radVaoSom.Size = New System.Drawing.Size(69, 18)
        Me.radVaoSom.TabIndex = 34
        Me.radVaoSom.Text = "Vào sớm"
        Me.radVaoSom.UseVisualStyleBackColor = True
        '
        'chkDaChamCong
        '
        Me.chkDaChamCong.AutoSize = True
        Me.chkDaChamCong.Checked = True
        Me.chkDaChamCong.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDaChamCong.ForeColor = System.Drawing.Color.Teal
        Me.chkDaChamCong.Location = New System.Drawing.Point(336, 15)
        Me.chkDaChamCong.Name = "chkDaChamCong"
        Me.chkDaChamCong.Size = New System.Drawing.Size(96, 18)
        Me.chkDaChamCong.TabIndex = 32
        Me.chkDaChamCong.Text = "Đã chấm công"
        Me.chkDaChamCong.UseVisualStyleBackColor = True
        '
        'chkTongSoLan
        '
        Me.chkTongSoLan.AutoSize = True
        Me.chkTongSoLan.ForeColor = System.Drawing.Color.Teal
        Me.chkTongSoLan.Location = New System.Drawing.Point(336, 62)
        Me.chkTongSoLan.Name = "chkTongSoLan"
        Me.chkTongSoLan.Size = New System.Drawing.Size(122, 18)
        Me.chkTongSoLan.TabIndex = 33
        Me.chkTongSoLan.Text = "Tổng số lần vi phạm"
        Me.chkTongSoLan.UseVisualStyleBackColor = True
        '
        'chkKhongTinhTangCa
        '
        Me.chkKhongTinhTangCa.AutoSize = True
        Me.chkKhongTinhTangCa.Checked = True
        Me.chkKhongTinhTangCa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKhongTinhTangCa.ForeColor = System.Drawing.Color.Teal
        Me.chkKhongTinhTangCa.Location = New System.Drawing.Point(336, 38)
        Me.chkKhongTinhTangCa.Name = "chkKhongTinhTangCa"
        Me.chkKhongTinhTangCa.Size = New System.Drawing.Size(116, 18)
        Me.chkKhongTinhTangCa.TabIndex = 33
        Me.chkKhongTinhTangCa.Text = "Không tính tăng ca"
        Me.chkKhongTinhTangCa.UseVisualStyleBackColor = True
        '
        'lblNgaydauthang
        '
        Me.lblNgaydauthang.Location = New System.Drawing.Point(106, 68)
        Me.lblNgaydauthang.Name = "lblNgaydauthang"
        Me.lblNgaydauthang.Size = New System.Drawing.Size(70, 19)
        Me.lblNgaydauthang.TabIndex = 30
        Me.lblNgaydauthang.Text = "1 :"
        Me.lblNgaydauthang.Visible = False
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(1034, 160)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(1034, 136)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Appearance1.FontData.Name = "Arial"
        Me.UltraTabControl1.Appearance = Appearance1
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(1028, 133)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết quẹt thẻ sai qui định"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1024, 110)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(1034, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin chi tiết nhân viên quẹt thẻ sai qui định"
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 163)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(1034, 279)
        Me.pnlList.TabIndex = 13
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(1034, 54)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnExcel, Me.btnXem})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(1034, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 9
        Me.btnExcel.Text = "Excel"
        '
        'btnXem
        '
        Me.btnXem.ImageIndex = 8
        Me.btnXem.Text = "Refresh"
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
        Me.XpCaption2.Size = New System.Drawing.Size(1034, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên quẹt thẻ sai qui định"
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgrBC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(1034, 279)
        Me.dgrBC.TabIndex = 1
        Me.dgrBC.Text = "UltraGrid1"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1040, 445)
        Me.UltraGroupBox1.TabIndex = 14
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 160)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'UltraGridExcelExporter1
        '
        '
        'frmQTSaiQuiDinh
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1040, 445)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmQTSaiQuiDinh"
        Me.Text = "Danh sach nhan vien quet the sai qui dinh"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaybd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private Sub frmQTSaiQuiDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblXuong, tblKhu As DataTable
        Dim skhu As String
        Dim obj As New objQTSaiQuiDinh
        Me.b = New clsBQTSaiQuiDinh
        ''=========== hiện đầu tuần cuối tuần theo ngày đang chọn ===========''
        Dim ngaytam() As Date = D_C_Tuan(Me.dtpNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpNgay.Value)
        Me.txtThang.Text = CDate(Me.dtpNgay.Value).Month.ToString()
         Me.radNgay.Checked = True
        'Me.rdLenca.Checked = True
        ';'=============Gía trị chọn mặc định ==============''
        Me.radTatca.Checked = True
        'Me.rdXuong.Checked = True
        loadcomboboxkhu()
        loadcomboboxxuong()
    End Sub
    Private Sub loadcomboboxkhu()
        Me.tblKhu = Nothing
        ' Dim tblKhu As DataTable
        ' Dim obj As New objQTSaiQuiDinh
        Me.b = New clsBQTSaiQuiDinh
        ' Load khu
        obj.ChonBang = 5
        tblKhu = Me.b.LoadDS(obj)
        tblKhu.Rows.Add("TCT", "Toàn công ty")
        Me.cbKhu.DataSource = tblKhu
        Me.cbKhu.DisplayMember() = "KHU_TEN"
        Me.cbKhu.ValueMember() = "KHU_MA"
        Me.cbKhu.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        If tblKhu.Rows.Count > 0 Then
            Me.cbKhu.SelectedIndex = 0
        Else
            Me.cbKhu.Enabled = False
            Exit Sub
        End If
    End Sub
    Private Sub loadcomboboxxuong()
        ' Dim tblXuong As DataTable
        ' Dim obj As New objQTSaiQuiDinh
        Me.tblXuong = Nothing
        Me.b = New clsBQTSaiQuiDinh
        If Me.cbKhu.Text <> "" Then
            obj.Khu = Me.cbKhu.Value.ToString()
            obj.ChonBang = 1

            tblXuong = Me.b.LoadDS(obj)
            If obj.Khu <> "TCT" Then
                Me.cbXuong.Enabled = False
                tblXuong.Rows.Add("TOANKHU", "Toàn khu " & obj.Khu)
            Else
                Me.cbXuong.Enabled = False
                Exit Sub
            End If

            'tblXuong.Rows.Add("TCT")
            'tblXuong.Rows.Add("KHUA")
            'tblXuong.Rows.Add("KHUB")
            Me.cbXuong.DataSource = tblXuong
            Me.cbXuong.ValueMember() = "X_MA_"
            Me.cbXuong.DisplayMember() = "X_TEN"
            Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            If tblXuong.Rows.Count > 0 Then
                Me.cbXuong.Enabled = True
                Me.cbXuong.SelectedIndex = tblXuong.Rows.Count - 1
            Else
                Me.cbXuong.Enabled = False
                Exit Sub
            End If
        End If
    End Sub
    Private Sub UltraGridExcelExporter1_CellExported(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs) Handles UltraGridExcelExporter1.CellExported
        Dim cell As UltraGridCell = e.GridRow.Cells(e.GridColumn)
        Dim mergedCells() As UltraGridCell = cell.GetMergedCells()

        If Not mergedCells Is Nothing Then

            Dim isFirstCell As Boolean = True
            For Each mergedCell As UltraGridCell In mergedCells
                If cell.Row.Index > mergedCell.Row.Index Then
                    isFirstCell = False
                    Return
                End If
            Next

            If isFirstCell Then
                Dim rowIndex, colIndex As Integer

                rowIndex = e.CurrentRowIndex
                colIndex = e.CurrentColumnIndex
                e.CurrentWorksheet.MergedCellsRegions.Add(rowIndex, colIndex, rowIndex + (mergedCells.Length - 1), colIndex)
            End If
        End If
    End Sub
    Public Sub methodLoad()
        Dim songay, songaycuoithang As Integer
        Dim bienngaytam As Date
        Dim m_sNgaydauthang, m_sNgaycuoithang As String
        Dim obj As New objQTSaiQuiDinh
        Me.b = New clsBQTSaiQuiDinh
        Dim dNgaydauthangtam As Date
        Dim grid As New clsTformatGrid
        Dim dgrBC As Object = Me.dgrBC

        Dim tbl As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()

        Dim m_sNgayChon As String '' = "'" + ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString() + "'"

        Dim ngaytam() As Date = D_C_Tuan(Me.dtpNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpNgay.Value)
        Dim m_sTungay As String = CDate(Me.txtNgaybd.Text).Year.ToString() + "/" + CDate(Me.txtNgaybd.Text).Month.ToString() + "/" + CDate(Me.txtNgaybd.Text).Day.ToString()
        Dim m_sDenngay As String = CDate(Me.txtNgaykt.Text).Year.ToString() + "/" + CDate(Me.txtNgaykt.Text).Month.ToString() + "/" + CDate(Me.txtNgaykt.Text).Day.ToString()

        songay = DateDiff(DateInterval.Day, CDate(txtNgaybd.Text), CDate(txtNgaykt.Text))
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Style = ProgressBarStyle.Marquee


        obj.NgayDauTuan = m_sTungay
        obj.NgayCuoiTuan = m_sDenngay
        obj.ChonXuong = Me.cbXuong.Value.ToString.ToUpper()
        obj.Khu = Me.cbKhu.Value.ToString()
        Select Case obj.Khu
            Case "TCT"
                sChuoiTieuDe = "MẨU BIỂU THỐNG KÊ QUẸT THẺ SAI QUY ĐỊNH THEO TOÀN CÔNG TY " & Chr(10) & " (NGÀY, TUẦN, THÁNG)"
            Case "A"
                sChuoiTieuDe = "MẨU BIỂU THỐNG KÊ QUẸT THẺ SAI QUY ĐỊNH THEO KHU A " & Chr(10) & " (A1,A2,A1A2,R1,R2,R3,VP,GIA CÔNG)"
            Case "B"
                sChuoiTieuDe = "MẨU BIỂU THỐNG KÊ QUẸT THẺ SAI QUY ĐỊNH THEO KHU B " & Chr(10) & " (B,B1,B7,BR1,BR2,B6)"
            Case "DVC"
                sChuoiTieuDe = "MẨU BIỂU THỐNG KÊ QUẸT THẺ SAI QUY ĐỊNH THEO KHU ĐƠN VỊ CHUNG " & Chr(10) & " (VP) "
            Case Else
                sChuoiTieuDe = "MẨU BIỂU THỐNG KÊ QUẸT THẺ SAI QUY ĐỊNH THEO TỪNG XƯỞNG " & Chr(10) & " (NGÀY, TUẦN, THÁNG)"
        End Select
        dNgaydauthangtam = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/01"
        'songaycuoithang = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(dNgaydauthangtam))).Day
        songaycuoithang = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, dNgaydauthangtam))).Day

        Me.lblNgaydauthang.Text = CDate(Me.dtpNgay.Text).Year.ToString() + "/" + CDate(Me.dtpNgay.Text).Month.ToString() + "/01"
        Me.lblNgaycuoithang.Text = CDate(Me.dtpNgay.Text).Year.ToString() + "/" + CDate(Me.dtpNgay.Text).Month.ToString() + "/" + songaycuoithang.ToString()

        obj.Ngaydauthang = lblNgaydauthang.Text
        obj.Ngaycuoithang = lblNgaycuoithang.Text

        If Me.chkKhongTinhTangCa.Checked Then
            obj.KhongTinhTangCa = 1
        Else
            obj.KhongTinhTangCa = 0
        End If

        ''======== loại trừ đi ca đêm có giờ vào nằm ở ngày hôm sau ==========''
        If Me.chkDaChamCong.Checked Then
            obj.DaChamCong = 1
        Else
            obj.DaChamCong = 0
        End If

        ''========= dieu kien loc trang thai quet the sai quy dinh ==========''
        If Me.radVaoSom.Checked Then
            obj.VaoSom = 1
        Else
            obj.VaoSom = 0
        End If

        If Me.radRaTre.Checked Then
            obj.RaTre = 1
        Else
            obj.RaTre = 0
        End If

        If Me.RadVaoSomRaTre.Checked Then
            obj.VaoSomRaTre = 1
        Else
            obj.VaoSomRaTre = 0
        End If


        ''============================
        If Me.radVaoTre.Checked Then
            obj.VaoTre = 1
        Else
            obj.VaoTre = 0
        End If

        If Me.radRaSom.Checked Then
            obj.RaSom = 1
        Else
            obj.RaSom = 0
        End If

        If Me.radVaoTreRaSom.Checked Then
            obj.VaoTreRaSom = 1
        Else
            obj.VaoTreRaSom = 0
        End If

        If Me.radTatca.Checked Then
            obj.Tatca = 1
        Else
            obj.Tatca = 0
        End If

        If Me.radNgay.Checked Then
            m_sNgayChon = "'" + Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString() + "'"

            obj.D_Ngay = CInt(Me.dtpNgay.Value.Day.ToString())
            obj.M_Ngay = CInt(Me.dtpNgay.Value.Month.ToString())
            obj.Y_Ngay = CInt(Me.dtpNgay.Value.Year.ToString())
            obj.Ngay = m_sNgayChon

            obj.ChonBang = 2
            Me.XpCaption2.Text = "Danh sách nhân viên quẹt thẻ sai qui định ngày"
            tbl = Me.b.LoadDS(obj)
            Me.dgrBC.DataSource = tbl

            Me.ProgressBar.Value = 100
            Me.ProgressBar.Style = ProgressBarStyle.Blocks
        End If

        ''============= lặp từ ngày đầu - ngày cuối tuần =============''
        If Me.radTuan.Checked Then
            If Me.chkTongSoLan.Checked Then
                Me.b.ThongKeQuetTheSaiQuyDinh_TungNgay_Delete(obj, Me.radTuan.Checked)
            End If

            For i = 0 To songay
                bienngaytam = DateAdd(DateInterval.Day, i, CDate(txtNgaybd.Text))
                m_sNgayChon = "'" + bienngaytam.Year.ToString() + "/" + bienngaytam.Month.ToString() + "/" + bienngaytam.Day.ToString() + "'"

                obj.D_Ngay = CInt(bienngaytam.Day.ToString())
                obj.M_Ngay = CInt(bienngaytam.Month.ToString())
                obj.Y_Ngay = CInt(bienngaytam.Year.ToString())
                obj.Ngay = m_sNgayChon

                If Me.chkTongSoLan.Checked = False Then
                    obj.ChonBang = 2
                    Me.XpCaption2.Text = "Danh sách nhân viên quẹt thẻ sai qui định tuần"
                    tbl = Me.b.LoadDS(obj)
                    If tbl Is Nothing Then
                    ElseIf tbl.Rows.Count <= 0 Then
                    Else
                        Me.Tabletk.Merge(tbl)
                    End If
                Else
                    obj.ChonBang = 3
                    Me.b.ThongKeQuetTheSaiQuyDinh_TungNgay_Insert(obj, Me.radTuan.Checked)
                End If
            Next
            If Me.chkTongSoLan.Checked = False Then
                Me.dgrBC.DataSource = Tabletk
               
            Else
                obj.ChonBang = 4
                tbl = Me.b.LoadDS(obj)

                If tbl Is Nothing Then
                ElseIf tbl.Rows.Count <= 0 Then
                Else
                    Me.dgrBC.DataSource = tbl
                End If
            End If
        End If

        ''============= lặp từ ngày đầu - ngày cuối tháng =============''
        If Me.radThang.Checked Then
            ''========= hiện cột tổng số lần vi phạm không hiện cột ngày trên lưới để cộng lại -==================''
            obj.Ngaydauthang = Me.lblNgaydauthang.Text
            obj.Ngaycuoithang = Me.lblNgaycuoithang.Text

            If Me.chkTongSoLan.Checked Then
                Me.b.ThongKeQuetTheSaiQuyDinh_TungNgay_Delete(obj, Me.radTuan.Checked)
            End If

            For i = 1 To songaycuoithang
                m_sNgayChon = "'" + CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + i.ToString() + "'"
                obj.Ngay = m_sNgayChon
                obj.D_Ngay = i
                obj.M_Ngay = CInt(Me.txtThang.Text)
                obj.Y_Ngay = CInt(CDate(Me.dtpNgay.Value).Year.ToString())


                Me.XpCaption2.Text = "Danh sách nhân viên quẹt thẻ sai qui định tháng"
                If Me.chkTongSoLan.Checked Then
                    obj.ChonBang = 3
                    Me.b.ThongKeQuetTheSaiQuyDinh_TungNgay_Insert(obj, Me.radTuan.Checked)
                Else
                    obj.ChonBang = 2
                    tbl = Me.b.LoadDS(obj)
                    If tbl Is Nothing Then
                    ElseIf tbl.Rows.Count <= 0 Then
                    Else
                        Me.Tabletk.Merge(tbl)
                    End If
                End If
            Next

            If Me.chkTongSoLan.Checked = False Then
                Me.dgrBC.DataSource = Tabletk

            Else
                obj.ChonBang = 3
                tbl = Me.b.LoadDS(obj)

                If tbl Is Nothing Then
                ElseIf tbl.Rows.Count <= 0 Then
                Else
                    Me.dgrBC.DataSource = tbl
                End If
            End If

        End If
        Me.ProgressBar.Value = 100
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
    End Sub
    Private Const stXL_SUBKEY As String = "\Excel.Application\CurVer"
    Dim rkVersionKey As RegistryKey = Nothing
    Private Function CheckInstallExcel()
        rkVersionKey = Registry.ClassesRoot.OpenSubKey(name:=stXL_SUBKEY, writable:=False)
        If rkVersionKey Is Nothing Then
            'not installed
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        'Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        'If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        '    MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        'End If

        If CheckInstallExcel() = False Then
            MessageBox.Show("Không tìm thấy ứng dụng excel.", "Thông báo chưa cài đặt excel.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim myWorkbook As New Workbook
            Dim wb As Workbook
            Dim myWorksheet As Worksheet
            Dim fs As FileStream
            Dim tenfile, path As String
            Dim vt As Integer
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    path = Me.SaveFileDialog1.FileName.ToString()
                    vt = path.Substring(0, path.LastIndexOf("\")).Length + 1
                    tenfile = path.Substring(vt, path.Length - vt)
                    Try
                        If Me.SaveFileDialog1.CheckFileExists() Then
                            MessageBox.Show("File lưu ở đường dẫn này đã có rồi,đóng file cũ lại để ghi đè.", "Thông báo chưa cài đặt excel.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Lỗi ghi dữ liệu.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                    myWorksheet = myWorkbook.Worksheets.Add("QTSQD")
                    Dim sheet As Worksheet = myWorkbook.Worksheets("QTSQD")
                    myWorksheet.Rows(1).Cells(0).CellFormat.Font.Color = Color.Red
                    myWorksheet.Rows(1).Cells(0).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(1).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(1).Cells(0).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(0).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(0).CellFormat.Font.Height = 300
                    myWorksheet.Rows(1).Cells(0).Value = sChuoiTieuDe

                    Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 0)
                    sheet.MergedCellsRegions.Add(0, 0, 1, 19)
                    sheet.Rows(0).Height = 500
                    BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                    MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        If (Me.cbXuong.Value.ToString() <> "" And Me.dtpNgay.Text <> "") Then
            methodLoad()
            If (Me.radThang.Checked Or Me.radTuan.Checked) And Me.chkTongSoLan.Checked Then
                LoadGridViewTongSoLanViPham()
                Exit Sub
            End If
            LoadGridView()
        Else
            MessageBox.Show("Vui lòng chọn xưởng,ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Sub btnXemTSLan_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Me.cbXuong.Value.ToString() <> "" And Me.dtpNgay.Text <> "") Then
            methodLoad()
            LoadGridView()
        Else
            MessageBox.Show("Vui lòng chọn xưởng,ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Sub LoadGridViewTongSoLanViPham()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next

                .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DV_MA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("NV_MA").Header.Caption = "Số thẻ"
                .Columns("NV_TEN").Header.Caption = "Họ tên"
                .Columns("DV_MA").Header.Caption = "Đơn vị"
                .Columns("XUONG").Header.Caption = "Xưởng"
                .Columns("KHU").Header.Caption = "Khu"
                .Columns("TONGVAOSOM").Header.Caption = "Tổng số lần vào sớm"
                .Columns("TONGVAOTRE").Header.Caption = "Tổng số lần vào trễ"
                .Columns("TONGRASOM").Header.Caption = "Tổng số lần ra sớm"
                .Columns("TONGRATRE").Header.Caption = "Tổng số lần ra trễ"
                .Columns("TONGVAOSOMRATRE").Header.Caption = "Tổng số lần vào sớm - ra trễ"
                .Columns("TONGVAOTRERASOM").Header.Caption = "Tổng số lần vào trễ - ra sớm"
                .Columns("TONGSOLANVIPHAM").Header.Caption = "Tổng số lần vi phạm"

                Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
                band.Layout.Bands(0).Summaries.Clear()

                band.Layout.Override.FilterUIType = FilterUIType.FilterRow
                band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
                band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
                band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
                band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
                band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
                band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
                band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
                band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
                'Column Chooser

                Dim columnToSummarize1 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGVAOSOM")
                Dim summary1 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng vào sớm:", SummaryType.Sum, columnToSummarize1)
                summary1.Appearance.TextHAlign = HAlign.Right
                summary1.DisplayFormat = "Tổng vào sớm = {0}"

                Dim columnToSummarize2 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGVAOTRE")
                Dim summary2 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng vào trễ:", SummaryType.Sum, columnToSummarize2)
                summary2.Appearance.TextHAlign = HAlign.Right
                summary2.DisplayFormat = "Tổng vào trễ = {0}"

                Dim columnToSummarize3 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGRASOM")
                Dim summary3 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng ra sớm:", SummaryType.Sum, columnToSummarize3)
                summary3.Appearance.TextHAlign = HAlign.Right
                summary3.DisplayFormat = "Tổng ra sớm = {0}"

                Dim columnToSummarize4 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGRATRE")
                Dim summary4 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng ra trễ:", SummaryType.Sum, columnToSummarize4)
                summary4.Appearance.TextHAlign = HAlign.Right
                summary4.DisplayFormat = "Tổng ra trễ = {0}"

                Dim columnToSummarize5 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGVAOSOMRATRE")
                Dim summary5 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng vào sớm -ra trễ:", SummaryType.Sum, columnToSummarize5)
                summary5.Appearance.TextHAlign = HAlign.Right
                summary5.DisplayFormat = "Tổng vào sớm -ra trễ = {0}"

                Dim columnToSummarize6 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGVAOTRERASOM")
                Dim summary6 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng vào trễ - ra sớm:", SummaryType.Sum, columnToSummarize6)
                summary6.Appearance.TextHAlign = HAlign.Right
                summary6.DisplayFormat = "Tổng vào trễ - ra sớm = {0}"

                Dim columnToSummarize7 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGSOLANVIPHAM")
                Dim summary7 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng số lần vi phạm:", SummaryType.Sum, columnToSummarize7)
                summary7.Appearance.TextHAlign = HAlign.Right
                summary7.DisplayFormat = "Tổng số lần vi phạm = {0}"

                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số dòng: "

                band = Nothing
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next

                .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DV_MA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                .Columns("GIO_VAO").Format = "HH:mm:ss"
                .Columns("GIO_RA").Format = "HH:mm:ss"
                .Columns("NGAY").Header.Caption = "Ngày"
                .Columns("GIO_VAO").Header.Caption = "Giờ vào"
                .Columns("GIO_RA").Header.Caption = "Giờ ra"
                .Columns("NV_MA").Header.Caption = "Số thẻ"
                .Columns("NV_TEN").Header.Caption = "Họ tên"
                .Columns("DV_MA").Header.Caption = "Đơn vị"
                .Columns("X_MA_").Header.Caption = "Xưởng"
                .Columns("KHU").Header.Caption = "Khu"

                If Me.radRaSom.Checked Then
                    .Columns("RASOM").Header.Caption = "Ra sớm"
                End If

                If Me.radRaTre.Checked Then
                    .Columns("RATRE").Header.Caption = "Ra trễ"
                End If

                If Me.radVaoSom.Checked Then
                    .Columns("VAOSOM").Header.Caption = "Vào sớm"
                End If

                If Me.radVaoTre.Checked Then
                    .Columns("VAOTRE").Header.Caption = "Vào trễ"
                End If

                If Me.RadVaoSomRaTre.Checked Then
                    .Columns("VAOSOM").Header.Caption = "Vào sớm"
                    .Columns("RATRE").Header.Caption = "Ra trễ"
                    .Columns("VAOSOMRATRE").Header.Caption = "Có vào sớm - Ra trễ"
                    .Columns("VAOSOM").Hidden = True
                    .Columns("RATRE").Hidden = True
                End If

                If Me.radVaoTreRaSom.Checked Then
                    .Columns("VAOTRE").Header.Caption = "Vào trễ"
                    .Columns("RASOM").Header.Caption = "Ra sớm"
                    .Columns("VAOTRERASOM").Header.Caption = "Có vào trễ - Ra sớm"
                    .Columns("VAOTRE").Hidden = True
                    .Columns("RASOM").Hidden = True
                End If

                If Me.radTatca.Checked Then
                    .Columns("RASOM").Header.Caption = "Ra sớm"
                    .Columns("RATRE").Header.Caption = "Ra trễ"
                    .Columns("VAOSOM").Header.Caption = "Vào sớm"
                    .Columns("VAOTRE").Header.Caption = "Vào trễ"
                    .Columns("VAOSOMRATRE").Header.Caption = "Có vào sớm - Ra trễ"
                    .Columns("VAOTRERASOM").Header.Caption = "Có vào trễ - Ra sớm"

                    .Columns("RASOM").Hidden = True
                    .Columns("RATRE").Hidden = True
                    .Columns("VAOSOM").Hidden = True
                    .Columns("VAOTRE").Hidden = True
                    .Columns("VAOSOMRATRE").Hidden = True
                    .Columns("VAOTRERASOM").Hidden = True
                End If



                Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
                band.Layout.Override.FilterUIType = FilterUIType.FilterRow
                band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
                band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
                band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
                band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
                band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
                band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
                band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
                band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
                'Column Chooser
                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
                band.Layout.Bands(0).Summaries.Clear()
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số dòng: "
                band = Nothing
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function D_C_Tuan(ByVal NgayHT As Date, ByVal bTinhCN As Boolean) As Date()
        Dim ngay(1) As Date '0: Ngày đầu tuần; Ngày cuối tuần
        Select Case Weekday(NgayHT)
            Case 1 'Chủ nhật
                ngay(0) = NgayHT
                ngay(1) = DateAdd(DateInterval.Day, 6, NgayHT)
            Case 2
                ngay(0) = DateAdd(DateInterval.Day, -1, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 5, NgayHT)
            Case 3
                ngay(0) = DateAdd(DateInterval.Day, -2, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 4, NgayHT)
            Case 4
                ngay(0) = DateAdd(DateInterval.Day, -3, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 3, NgayHT)
            Case 5
                ngay(0) = DateAdd(DateInterval.Day, -4, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 2, NgayHT)
            Case 6
                ngay(0) = DateAdd(DateInterval.Day, -5, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 1, NgayHT)
            Case 7 'Thứ bảy
                ngay(0) = DateAdd(DateInterval.Day, -6, NgayHT)
                ngay(1) = NgayHT
        End Select
        If bTinhCN = False Then
            ngay(0) = DateAdd(DateInterval.Day, 1, ngay(0))
        End If
        Return ngay
    End Function
    Private Sub cbNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Dim ngaytam() As Date = D_C_Tuan(Me.dtpNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpNgay.Value)
        Me.txtThang.Text = CDate(Me.dtpNgay.Value).Month.ToString()
    End Sub
    ' Fields
    Friend WithEvents b As clsBQTSaiQuiDinh
    Friend WithEvents btnXem As ButtonItem
    Friend WithEvents btnExcel As ButtonItem
    Friend WithEvents dgrBC As UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents pnlButton As Panel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents pnlList As Panel
    Friend WithEvents splDetail As CollapsibleSplitter
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents UltraGroupBox1 As UltraGroupBox
    Friend WithEvents UltraTabControl1 As UltraTabControl
    Friend WithEvents UltraTabPageControl1 As UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage1 As UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As XPCaption
    Friend WithEvents XpCaption2 As XPCaption
    Private components As System.ComponentModel.IContainer
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtTuan As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNgaykt As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNgaybd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblTuNgay As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents radTuan As System.Windows.Forms.RadioButton
    Friend WithEvents radNgay As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblNgaykt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents radThang As System.Windows.Forms.RadioButton
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtThang As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private Sub cbKhu_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKhu.ValueChanged
        loadcomboboxxuong()
    End Sub
End Class

