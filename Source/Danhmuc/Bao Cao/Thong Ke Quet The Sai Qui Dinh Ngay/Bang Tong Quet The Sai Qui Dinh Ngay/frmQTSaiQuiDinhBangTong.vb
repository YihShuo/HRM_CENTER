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

Public Class frmQTSaiQuiDinhBangTong
    Inherits Form
    Dim tblXuong, tblKhu As DataTable
    Dim obj As New objQTSaiQuiDinhBangTong
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmQTSaiQuiDinh_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    'Public Sub btnIn_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnIn.Activate
    '    Dim report As New FrmReport
    '    report.reportID = "024"
    '    Dim strArray As String() = New String() {"Tỷ Xuân", "Khu Công Nghiệp Hòa Phú - Long Hồ - Vĩnh Long", "Tel: (070)962052 - Fax: (070)962051"}
    '    report.para = strArray
    '    report.issysReport = True
    '    report.Show()
    'End Sub

    'Public Sub btnLuu_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Activate
    '    Me.LuuDuLieu()
    'End Sub

    'Public Sub btnSua_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnSua.Activate
    '    Me.showGroupinvi()
    '    Me.HieuChinh()
    'End Sub

    'Public Sub btnThem_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnThem.Activate
    '    Me.showGroupinvi()
    '    Me.ThemMoi()
    'End Sub

    'Public Sub btnXoa_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnXoa.Activate
    '    Me.XoaDuLieu()
    'End Sub



    'Public Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
    '    If Me.btnSua.Enabled Then
    '        Me.showGroupinvi()
    '        Me.HieuChinh()
    '    End If
    'End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Public Sub frmNgayNghi_Load(ByVal sender As Object, ByVal e As EventArgs)
    '    clsTools.GridTheme1(Me.dgrBC)
    '    Me.b = New clsBNgayNghi
    '    If Me.splDetail.IsCollapsed Then
    '        Me.splDetail.ToggleState()
    '    End If
    '    Me.methodLoad()
    '    Me.txtID.Focus()
    'End Sub

    'Public Sub frmNgayNghi_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
    '        Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    End If
    'End Sub

    'Public Sub HieuChinh()
    '    Try
    '        Dim grid As New clsTformatGrid
    '        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
    '        If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
    '            Me.txtID.Text = activeRow.Cells.Item("DayOff_ID").Value.ToString
    '            Me.txtID.ReadOnly = True
    '            Me.txtLyDo.Text = activeRow.Cells.Item("DayOff_Name").Value.ToString
    '            Me.txtGhichu.Text = activeRow.Cells.Item("Note").Value.ToString
    '            Me.txtNoiTraLuong.Text = activeRow.Cells.Item("Paid_By").Value.ToString
    '            Me.txtMucLuong.Text = activeRow.Cells.Item("Percentage").Value.ToString
    '            Me.txtLyDo.Select()
    '            Me.ThemSua = 1
    '        End If
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        ProjectData.ClearProjectError()
    '    End Try
    'End Sub

    Public Sub InitControl()
        'Me.btnExcel.Enabled = False
        'Me.btnIn.Enabled = False
        'Me.btnXoa.Enabled = False
        'Me.btnLuu.Enabled = False
        'Me.UltraToolbarsManager1.Tools.Item("mnuThem").SharedProps.Enabled = Me.btnExcel.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuSua").SharedProps.Enabled = Me.btnIn.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuXoa").SharedProps.Enabled = Me.btnXoa.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuLuu").SharedProps.Enabled = Me.btnLuu.Enabled
        'Me.ThemSua = 0
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQTSaiQuiDinhBangTong))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbKhu = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.lblKhu = New Infragistics.Win.Misc.UltraLabel
        Me.chkDaChamCong = New System.Windows.Forms.CheckBox
        Me.chkKhongTinhTangCa = New System.Windows.Forms.CheckBox
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.radTuan = New System.Windows.Forms.RadioButton
        Me.radNgay = New System.Windows.Forms.RadioButton
        Me.txtTuan = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtNgaykt = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtNgaybd = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblNgaykt = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.lblTuNgay = New Infragistics.Win.Misc.UltraLabel
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnExcel = New TD.SandBar.ButtonItem
        Me.btXem = New TD.SandBar.ButtonItem
        Me.btnBaoCao = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaybd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox2)
        Me.UltraTabPageControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(910, 110)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbKhu)
        Me.GroupBox2.Controls.Add(Me.lblKhu)
        Me.GroupBox2.Controls.Add(Me.chkDaChamCong)
        Me.GroupBox2.Controls.Add(Me.chkKhongTinhTangCa)
        Me.GroupBox2.Controls.Add(Me.cbXuong)
        Me.GroupBox2.Controls.Add(Me.radTuan)
        Me.GroupBox2.Controls.Add(Me.radNgay)
        Me.GroupBox2.Controls.Add(Me.txtTuan)
        Me.GroupBox2.Controls.Add(Me.txtNgaykt)
        Me.GroupBox2.Controls.Add(Me.txtNgaybd)
        Me.GroupBox2.Controls.Add(Me.lblNgaykt)
        Me.GroupBox2.Controls.Add(Me.UltraLabel1)
        Me.GroupBox2.Controls.Add(Me.lblTuNgay)
        Me.GroupBox2.Controls.Add(Me.ProgressBar)
        Me.GroupBox2.Controls.Add(Me.dtpNgay)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(902, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Điều Kiện Lọc Báo Cáo"
        '
        'cbKhu
        '
        Me.cbKhu.DisplayMember = ""
        Me.cbKhu.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKhu.Location = New System.Drawing.Point(222, 11)
        Me.cbKhu.Name = "cbKhu"
        Me.cbKhu.Size = New System.Drawing.Size(96, 21)
        Me.cbKhu.TabIndex = 42
        Me.cbKhu.ValueMember = "DV_MA"
        '
        'lblKhu
        '
        Me.lblKhu.Location = New System.Drawing.Point(189, 13)
        Me.lblKhu.Name = "lblKhu"
        Me.lblKhu.Size = New System.Drawing.Size(32, 19)
        Me.lblKhu.TabIndex = 41
        Me.lblKhu.Text = "Khu :"
        '
        'chkDaChamCong
        '
        Me.chkDaChamCong.AutoSize = True
        Me.chkDaChamCong.Checked = True
        Me.chkDaChamCong.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDaChamCong.ForeColor = System.Drawing.Color.Teal
        Me.chkDaChamCong.Location = New System.Drawing.Point(5, 71)
        Me.chkDaChamCong.Name = "chkDaChamCong"
        Me.chkDaChamCong.Size = New System.Drawing.Size(96, 18)
        Me.chkDaChamCong.TabIndex = 39
        Me.chkDaChamCong.Text = "Đã chấm công"
        Me.chkDaChamCong.UseVisualStyleBackColor = True
        '
        'chkKhongTinhTangCa
        '
        Me.chkKhongTinhTangCa.AutoSize = True
        Me.chkKhongTinhTangCa.Checked = True
        Me.chkKhongTinhTangCa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKhongTinhTangCa.ForeColor = System.Drawing.Color.Teal
        Me.chkKhongTinhTangCa.Location = New System.Drawing.Point(105, 70)
        Me.chkKhongTinhTangCa.Name = "chkKhongTinhTangCa"
        Me.chkKhongTinhTangCa.Size = New System.Drawing.Size(116, 18)
        Me.chkKhongTinhTangCa.TabIndex = 40
        Me.chkKhongTinhTangCa.Text = "Không tính tăng ca"
        Me.chkKhongTinhTangCa.UseVisualStyleBackColor = True
        '
        'cbXuong
        '
        Me.cbXuong.DisplayMember = ""
        Me.cbXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbXuong.Location = New System.Drawing.Point(379, 11)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(96, 21)
        Me.cbXuong.TabIndex = 38
        Me.cbXuong.ValueMember = "DV_MA"
        '
        'radTuan
        '
        Me.radTuan.AutoSize = True
        Me.radTuan.Location = New System.Drawing.Point(5, 43)
        Me.radTuan.Name = "radTuan"
        Me.radTuan.Size = New System.Drawing.Size(71, 18)
        Me.radTuan.TabIndex = 29
        Me.radTuan.Text = "Tuần thứ:"
        Me.radTuan.UseVisualStyleBackColor = True
        '
        'radNgay
        '
        Me.radNgay.AutoSize = True
        Me.radNgay.Checked = True
        Me.radNgay.Location = New System.Drawing.Point(5, 19)
        Me.radNgay.Name = "radNgay"
        Me.radNgay.Size = New System.Drawing.Size(50, 18)
        Me.radNgay.TabIndex = 30
        Me.radNgay.TabStop = True
        Me.radNgay.Text = "Ngày"
        Me.radNgay.UseVisualStyleBackColor = True
        '
        'txtTuan
        '
        Me.txtTuan.Enabled = False
        Me.txtTuan.Location = New System.Drawing.Point(79, 41)
        Me.txtTuan.Name = "txtTuan"
        Me.txtTuan.Size = New System.Drawing.Size(60, 21)
        Me.txtTuan.TabIndex = 34
        '
        'txtNgaykt
        '
        Me.txtNgaykt.Enabled = False
        Me.txtNgaykt.Location = New System.Drawing.Point(320, 40)
        Me.txtNgaykt.Name = "txtNgaykt"
        Me.txtNgaykt.Size = New System.Drawing.Size(92, 21)
        Me.txtNgaykt.TabIndex = 35
        '
        'txtNgaybd
        '
        Me.txtNgaybd.Enabled = False
        Me.txtNgaybd.Location = New System.Drawing.Point(222, 40)
        Me.txtNgaybd.Name = "txtNgaybd"
        Me.txtNgaybd.Size = New System.Drawing.Size(85, 21)
        Me.txtNgaybd.TabIndex = 36
        '
        'lblNgaykt
        '
        Me.lblNgaykt.Location = New System.Drawing.Point(309, 40)
        Me.lblNgaykt.Name = "lblNgaykt"
        Me.lblNgaykt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNgaykt.Size = New System.Drawing.Size(20, 21)
        Me.lblNgaykt.TabIndex = 33
        Me.lblNgaykt.Text = "-"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(334, 13)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(49, 19)
        Me.UltraLabel1.TabIndex = 31
        Me.UltraLabel1.Text = "Xưởng :"
        '
        'lblTuNgay
        '
        Me.lblTuNgay.Location = New System.Drawing.Point(157, 43)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(63, 19)
        Me.lblTuNgay.TabIndex = 32
        Me.lblTuNgay.Text = "Bắt đầu từ :"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(222, 71)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(190, 18)
        Me.ProgressBar.TabIndex = 27
        '
        'dtpNgay
        '
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(79, 15)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(87, 20)
        Me.dtpNgay.TabIndex = 3
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(920, 160)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(920, 136)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(914, 133)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Quẹt thẻ sai qui định bảng tổng"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(910, 110)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(920, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin các đơn vi quẹt thẻ sai qui định"
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 168)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(920, 274)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(920, 216)
        Me.dgrBC.TabIndex = 1
        Me.dgrBC.Text = "UltraGrid1"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(920, 58)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnExcel, Me.btXem, Me.btnBaoCao})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(920, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 9
        Me.btnExcel.Text = "Excel"
        '
        'btXem
        '
        Me.btXem.ImageIndex = 8
        Me.btXem.Text = "Xem"
        '
        'btnBaoCao
        '
        Me.btnBaoCao.ImageIndex = 3
        Me.btnBaoCao.Text = "Báo cáo"
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
        Me.XpCaption2.Size = New System.Drawing.Size(920, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách các đơn vị quẹt thẻ sai qui định"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(926, 445)
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
        'frmQTSaiQuiDinhBangTong
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(926, 445)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmQTSaiQuiDinhBangTong"
        Me.Text = "Quet the sai qui dinh bang tong"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaybd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    'Public Sub LuuDuLieu()
    '    Dim nghi As New objNgayNghi
    '    If (StringType.StrCmp(Me.txtID.Text, "", False) = 0) Then
    '        MessageBox.Show("Ch" & ChrW(432) & "a nh" & ChrW(7853) & "p m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & ".", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Me.txtID.Focus()
    '    ElseIf (StringType.StrCmp(Me.txtLyDo.Text, "", False) = 0) Then
    '        MessageBox.Show("Ch" & ChrW(432) & "a nh" & ChrW(7853) & "p l" & ChrW(253) & " do ng" & ChrW(224) & "y ngh" & ChrW(7881) & ".", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Me.txtLyDo.Focus()
    '    ElseIf (Integer.Parse(Me.txtMucLuong.Text) > 100) Then
    '        MessageBox.Show("M" & ChrW(7913) & "c l" & ChrW(432) & ChrW(417) & "ng ng" & ChrW(224) & "y ngh" & ChrW(7881) & " t" & ChrW(7889) & "i " & ChrW(273) & "a l" & ChrW(224) & " 100% l" & ChrW(432) & ChrW(417) & "ng.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Me.txtMucLuong.Focus()
    '    Else
    '        nghi.setvalue(Me.txtID.Text, Me.txtNoiTraLuong.Text, Me.txtMucLuong.Text, Me.txtLyDo.Text, Me.txtGhichu.Text)
    '        Me.b = New clsBNgayNghi
    '        Try
    '            If Me.b.CapNhat(nghi, Me.ThemSua) Then
    '                MessageBox.Show(ChrW(272) & ChrW(227) & " l" & ChrW(432) & "u d" & ChrW(7919) & " li" & ChrW(7879) & "u.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                nghi.Setnull()
    '                Me.dgrBC.DataSource = Me.b.LoadDS(nghi)
    '                If Me.btnThem.Enabled Then
    '                    Me.ThemMoi()
    '                End If
    '            Else
    '                Me.txtID.Focus()
    '            End If
    '        Catch exception1 As Exception
    '            ProjectData.SetProjectError(exception1)
    '            Dim exception As Exception = exception1
    '            clsTools.thongbaoLoi(exception.Message)
    '            ProjectData.ClearProjectError()
    '        End Try
    '    End If
    'End Sub

    'Public Sub methodLoad(ByVal obj As objQTSaiQuiDinhBangTong)
    '    Dim grid As New clsTformatGrid
    '    Me.dgrBC.DataSource = Me.b.LoadDS(obj)
    '    Dim dgrBC As Object = Me.dgrBC
    '    If obj.ChonBang = 1 Then
    '        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/BangTongQuetTheSaiQuiDinhLenCa.xml"), typeControl.Grid, "coldgrquetthesaiquidinh")
    '    End If
    '    If obj.ChonBang = 2 Then
    '        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/BangTongQuetTheSaiQuiDinhXuongCa.xml"), typeControl.Grid, "coldgrquetthesaiquidinh")
    '    End If
    '    If obj.ChonBang = 3 Then
    '        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/BangTongQuetTheSaiQuiDinh.xml"), typeControl.Grid, "coldgrquetthesaiquidinh")
    '    End If
    'End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub

    'Public Sub ThemMoi()
    '    Me.b = New clsBNgayNghi
    '    Me.txtID.Clear()
    '    Me.txtLyDo.Clear()
    '    Me.txtGhichu.Clear()
    '    Me.txtNoiTraLuong.Clear()
    '    Me.txtMucLuong.Text = "0"
    '    Me.txtID.ReadOnly = False
    '    Me.txtID.Focus()
    '    Me.ThemSua = 0
    'End Sub

    'Public Sub txtMucLuong_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMucLuong.TextChanged
    '    Try
    '        clsTools.TextBox_Change1(Me.txtMucLuong)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        ProjectData.ClearProjectError()
    '    End Try
    'End Sub

    'Public Sub UltraToolbarsManager1_ToolClick(ByVal sender As Object, ByVal e As ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
    '    Dim key As String = e.Tool.Key
    '    If (StringType.StrCmp(key, "mnuThem", False) = 0) Then
    '        Me.btnThem_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuSua", False) = 0) Then
    '        Me.btnSua_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuXoa", False) = 0) Then
    '        Me.btnXoa_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuLuu", False) = 0) Then
    '        Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuIn", False) = 0) Then
    '        Me.btnIn_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    End If
    'End Sub

    '    Public Sub XoaDuLieu()
    '        Try
    '            Dim nghi As New objNgayNghi
    '            If (Me.dgrBC.Selected.Rows.Count > 0) Then
    '                Dim str As String
    '                If (Me.dgrBC.Selected.Rows.Count = 1) Then
    '                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
    '                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
    '                        str = StringType.FromObject(activeRow.Cells.Item("DayOff_ID").Value)
    '                        nghi.ID = str
    '                        If Me.b.IsDeleteOK(str) Then
    '                            If (MessageBox.Show(("B" & ChrW(7841) & "n mu" & ChrW(7889) & "n x" & ChrW(243) & "a ng" & ChrW(224) & "y ngh" & ChrW(7881) & " c" & ChrW(243) & " m" & ChrW(227) & ": " & str & "?"), "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
    '                                If Me.b.DeleteInfo(nghi) Then
    '                                    MessageBox.Show(ChrW(272) & ChrW(227) & " x" & ChrW(243) & "a th" & ChrW(224) & "nh c" & ChrW(244) & "ng.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                                    GoTo Label_0274
    '                                End If
    '                                MessageBox.Show("X" & ChrW(243) & "a b" & ChrW(7883) & " l" & ChrW(7895) & "i." & ChrW(13) & ChrW(10) & "Ki" & ChrW(7875) & "m tra v" & ChrW(224) & " th" & ChrW(7921) & "c hi" & ChrW(7879) & "n l" & ChrW(7841) & "i.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '                            End If
    '                        Else
    '                            MessageBox.Show("Kh" & ChrW(244) & "ng " & ChrW(273) & ChrW(432) & ChrW(7907) & "c x" & ChrW(243) & "a ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        End If
    '                    End If
    '                    Return
    '                End If
    '                If (MessageBox.Show(("B" & ChrW(7841) & "n mu" & ChrW(7889) & "n x" & ChrW(243) & "a " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " " & ChrW(273) & ChrW(227) & " ch" & ChrW(7885) & "n?"), "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
    '                    Return
    '                End If
    '                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
    '                Dim i As Integer = 0
    '                Do While (i <= num2)
    '                    str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("DayOff_ID").Value)
    '                    nghi.ID = str
    '                    If Me.b.IsDeleteOK(str) Then
    '                        If Me.b.DeleteInfo(nghi) Then
    '                        Else
    '                            MessageBox.Show("X" & ChrW(243) & "a b" & ChrW(7883) & " l" & ChrW(7895) & "i." & ChrW(13) & ChrW(10) & "Ki" & ChrW(7875) & "m tra v" & ChrW(224) & " th" & ChrW(7921) & "c hi" & ChrW(7879) & "n l" & ChrW(7841) & "i.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '                        End If
    '                    Else
    '                        MessageBox.Show(("Kh" & ChrW(244) & "ng " & ChrW(273) & ChrW(432) & ChrW(7907) & "c x" & ChrW(243) & "a ng" & ChrW(224) & "y ngh" & ChrW(7881) & " " & str & "."), "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    End If
    '                    i += 1
    '                Loop
    '            End If
    'Label_0274:
    '            nghi.Setnull()
    '            Me.dgrBC.DataSource = Me.b.LoadDS(nghi)
    '            If Me.btnThem.Enabled Then
    '                Me.ThemMoi()
    '            End If
    '        Catch exception1 As Exception
    '            ProjectData.SetProjectError(exception1)
    '            Dim exception As Exception = exception1
    '            ProjectData.ClearProjectError()
    '        End Try
    '    End Sub


    ' Fields
    Friend WithEvents b As clsBQTSaiQuiDinhBangTong
    Friend WithEvents btXem As ButtonItem
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
    Friend WithEvents btnBaoCao As TD.SandBar.ButtonItem
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents chkDaChamCong As System.Windows.Forms.CheckBox
    Friend WithEvents chkKhongTinhTangCa As System.Windows.Forms.CheckBox
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents radTuan As System.Windows.Forms.RadioButton
    Friend WithEvents radNgay As System.Windows.Forms.RadioButton
    Friend WithEvents txtTuan As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNgaykt As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNgaybd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNgaykt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTuNgay As Infragistics.Win.Misc.UltraLabel
    Public ThemSua As Integer
    Public Tabletk As DataTable
    Friend WithEvents cbKhu As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblKhu As Infragistics.Win.Misc.UltraLabel
    Public i As Integer
    Private Sub frmQTSaiQuiDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBQTSaiQuiDinhBangTong
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Dim tblXuong As DataTable
        Dim obj As New objQTSaiQuiDinhBangTong
        Me.b = New clsBQTSaiQuiDinhBangTong

        Dim ngaytam() As Date = D_C_Tuan(Me.dtpNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpNgay.Value)

        'obj.ChonBang = 1
        'tblXuong = Me.b.LoadDS(obj)
        ''tblXuong.Rows.Add("TCT")
        ''tblXuong.Rows.Add("KHUA")
        ''tblXuong.Rows.Add("KHUB")
        'Me.cbXuong.DataSource = tblXuong
        'Me.cbXuong.DisplayMember() = "X_MA_"
        'Me.cbXuong.ValueMember() = "X_MA_"
        'Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        'If tblXuong.Rows.Count > 0 Then
        '    Me.cbXuong.SelectedIndex = 0
        'Else
        '    Me.cbXuong.Enabled = False
        '    Exit Sub
        'End If

        Me.radNgay.Checked = True
        loadkhu()
        loadxuong()

    End Sub
    Private Sub loadkhu()

        Me.tblKhu = Nothing
        ' Dim tblKhu As DataTable
        ' Dim obj As New objQTSaiQuiDinh
        Me.b = New clsBQTSaiQuiDinhBangTong
        ' Load khu
        obj.ChonBang = 4
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
    Private Sub loadxuong()
        Me.tblXuong = Nothing
        Me.b = New clsBQTSaiQuiDinhBangTong
        If Me.cbKhu.Text <> "" Then
            obj.ChonKhu = Me.cbKhu.Value.ToString()
            obj.ChonBang = 1

            tblXuong = Me.b.LoadDS(obj)
            If obj.ChonKhu <> "TCT" Then
                Me.cbXuong.Enabled = False
                tblXuong.Rows.Add("TOANKHU", "Toàn khu " & obj.ChonKhu)
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

    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            With Me.dgrBC.DisplayLayout.Bands(0)
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next

                If Me.radTuan.Checked Then
                Else
                    .Columns("NGAY").Header.Caption = "Ngày"
                End If

                .Columns("DV_MA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DV_MA").Header.Caption = "Đơn vị"
                .Columns("X_MA_").Header.Caption = "Xưởng"
                .Columns("VAOSOM").Header.Caption = "SL Vào sớm"
                .Columns("VAOTRE").Header.Caption = "SL Vào trễ"
                .Columns("RASOM").Header.Caption = "SL Ra sớm"
                .Columns("RATRE").Header.Caption = "SL Ra trễ"
                .Columns("KHU").Header.Caption = "Khu"

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
    Public Sub methodLoad(ByVal iXemBaoCao As Integer)
        Dim songay, songaycuoithang As Integer
        Dim bienngaytam As Date
        Dim m_sNgaydauthang, m_sNgaycuoithang As String
        Dim obj As New objQTSaiQuiDinhBangTong
        Me.b = New clsBQTSaiQuiDinhBangTong

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
        Dim m_sTungay As String = "'" + CDate(Me.txtNgaybd.Text).Year.ToString() + "/" + CDate(Me.txtNgaybd.Text).Month.ToString() + "/" + CDate(Me.txtNgaybd.Text).Day.ToString() + "'"
        Dim m_sDenngay As String = "'" + CDate(Me.txtNgaykt.Text).Year.ToString() + "/" + CDate(Me.txtNgaykt.Text).Month.ToString() + "/" + CDate(Me.txtNgaykt.Text).Day.ToString() + "'"

        songay = DateDiff(DateInterval.Day, CDate(txtNgaybd.Text), CDate(txtNgaykt.Text))
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Style = ProgressBarStyle.Marquee

        obj.ChonMoBaoCao = iXemBaoCao
        obj.NgayDauTuan = m_sTungay
        obj.NgayCuoiTuan = m_sDenngay
        obj.ChonXuong = Me.cbXuong.Value.ToString.ToUpper()
        obj.ChonKhu = Me.cbKhu.Value.ToString()
        songaycuoithang = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Me.dtpNgay.Value))).Day

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

        If Me.radNgay.Checked Then
            m_sNgayChon = "'" + Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString() + "'"

            obj.D_Ngay = CInt(Me.dtpNgay.Value.Day.ToString())
            obj.M_Ngay = CInt(Me.dtpNgay.Value.Month.ToString())
            obj.Y_Ngay = CInt(Me.dtpNgay.Value.Year.ToString())
            obj.Ngay = m_sNgayChon

            If iXemBaoCao = 1 Then
                ''============ xem bao cao ====
                LayThamSo_BaoCaoNgay(CDate(Me.dtpNgay.Value), Me.cbXuong.Value.ToString.ToUpper(), Me.cbKhu.Value.ToString(), obj.KhongTinhTangCa, obj.DaChamCong)
            Else
                obj.ChonBang = 2
                Me.XpCaption2.Text = "Danh sách các đơn vị quẹt thẻ sai qui định ngày - " + obj.ChonXuong + ""
                tbl = Me.b.LoadDS(obj)
                Me.dgrBC.DataSource = tbl
            End If
            Me.ProgressBar.Value = 100
            Me.ProgressBar.Style = ProgressBarStyle.Blocks
            Exit Sub
        Else
            ''============= lặp từ ngày đầu - ngày cuối tuần =============''
            If Me.radTuan.Checked Then
                For i = 0 To songay
                    bienngaytam = DateAdd(DateInterval.Day, i, CDate(txtNgaybd.Text))
                    m_sNgayChon = "'" + bienngaytam.Year.ToString() + "/" + bienngaytam.Month.ToString() + "/" + bienngaytam.Day.ToString() + "'"

                    obj.D_Ngay = CInt(bienngaytam.Day.ToString())
                    obj.M_Ngay = CInt(bienngaytam.Month.ToString())
                    obj.Y_Ngay = CInt(bienngaytam.Year.ToString())
                    obj.Ngay = m_sNgayChon

                    Application.DoEvents()
                    Me.b.ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Delete(obj, Me.radTuan.Checked)
                    Me.b.ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Insert(obj, Me.radTuan.Checked)
                Next
            End If

            If iXemBaoCao = 1 Then
                ''============ xem bao cao ====
                If Me.radTuan.Checked Then
                    LayThamSo_BaoCaoTuan(CDate(Me.txtNgaybd.Text), CDate(Me.txtNgaykt.Text), Me.cbXuong.Value.ToString.ToUpper(), Me.cbKhu.Value.ToString())
                End If
            Else
                obj.ChonBang = 3
                Me.XpCaption2.Text = "Danh sách các đơn vị quẹt thẻ sai qui định tuần theo " + obj.ChonXuong + " (" + Me.txtNgaybd.Text + " - " + Me.txtNgaykt.Text + ")"
                tbl = Me.b.LoadDS(obj)
                Me.dgrBC.DataSource = tbl
            End If
            Me.ProgressBar.Value = 100
            Me.ProgressBar.Style = ProgressBarStyle.Blocks
        End If
    End Sub
    Private Sub LayThamSo_BaoCaoTuan(ByVal sTuNgay As Date, ByVal sDenNgay As Date, ByVal sXuong As String, ByVal sKhu As String)
        Dim report As New FrmReport
        Dim strArray As String()
        Dim sTngay As String = sTuNgay.Year.ToString() + "/" + sTuNgay.Month.ToString() + "/" + sTuNgay.Day.ToString()
        Dim sDngay As String = sDenNgay.Year.ToString() + "/" + sDenNgay.Month.ToString() + "/" + sDenNgay.Day.ToString()

        'Select Case sXuong
        '    Case "TCT"
        '        report.reportID = "QTSQD_17"
        '        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định toàn công ty theo tuần"
        '    Case "KHUA"
        '        report.reportID = "QTSQD_19"
        '        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định khu A theo tuần"
        '    Case "KHUB"
        '        report.reportID = "QTSQD_20"
        '        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định khu B theo tuần"
        '    Case Else
        '        report.reportID = "QTSQD_18"
        '        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định xưởng theo tuần"
        'End Select
        Select Case sKhu
            Case "TCT"
                report.reportID = "QTSQD_17"
                report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định toàn công ty theo tuần"
                ' strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
                strArray = New String() {sTngay, sDngay, sXuong, sKhu}
            Case Else
                Select Case sXuong

                    Case "TOANKHU"
                        Dim dsxuong As String
                        For Each row As DataRow In tblXuong.Rows
                            If row("X_MA_").ToString <> "TOANKHU" Then
                                dsxuong = dsxuong + "" + row("X_MA_").ToString + ", "
                            End If
                        Next
                        dsxuong = dsxuong.Remove(dsxuong.Length - 2, 1) ' bỏ dấu phẩy cuối cùng 
                        ' report.reportID = "QTSQD_22" 'QTSQD_19
                        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định khu " + sKhu + " theo tuần"
                        report.reportID = "QTSQD_22"
                        strArray = New String() {sTngay, sDngay, sXuong, dsxuong, sKhu}
                    Case Else
                        Dim dsxuong As String
                        ' report.reportID = "QTSQD_18"
                        dsxuong = ""
                        report.Text = "Danh sách quẹt thẻ sai quy định xưởng theo tuần"
                        report.reportID = "QTSQD_22"
                        strArray = New String() {sTngay, sDngay, sXuong, dsxuong, sKhu}


                End Select
              
        End Select
        ' strArray = New String() {sXuong, sTngay, sDngay}
        report.para = strArray
        report.issysReport = True
        report.Update()
        report.Refresh()
        report.Show()
    End Sub
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
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
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        If (Me.cbXuong.Value.ToString() <> "" And Me.dtpNgay.Text <> "") Then
            methodLoad(0)
            LoadGridView()
        Else
            MessageBox.Show("Vui lòng chọn xưởng,ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Sub LayThamSo_BaoCaoNgay(ByVal sNgay As Date, ByVal sXuong As String, ByVal sKhu As String, ByVal chkKhongTinhTangCa As Integer, ByVal chkDaChamCong As Integer)
        Dim report As New FrmReport
        Dim strArray As String()
        Dim ngay As String
        ngay = sNgay.Year.ToString() + "/" + sNgay.Month.ToString() + "/" + sNgay.Day.ToString()

        Select Case sKhu
            Case "TCT"
                report.reportID = "QTSQD_13"
                report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định toàn công ty theo ngày"
                strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
            Case Else
                Select Case sXuong
                    Case "TOANKHU"
                        Dim dsxuong As String
                        For Each row As DataRow In tblXuong.Rows
                            If row("X_MA_").ToString <> "TOANKHU" Then
                                dsxuong = dsxuong + "" + row("X_MA_").ToString + ", "
                            End If
                        Next
                        dsxuong = dsxuong.Remove(dsxuong.Length - 2, 1) ' bỏ dấu phẩy cuối cùng 
                        report.reportID = "QTSQD_21"
                        report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định khu " + sKhu + " theo ngày"
                        strArray = New String() {ngay, sKhu, dsxuong, chkKhongTinhTangCa, chkDaChamCong}
                        'Case "B"
                        'report.reportID = "QTSQD_16"
                        'report.Text = "Danh sách quẹt thẻ sai quy định khu B theo ngày"
                        'strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
                        '  Case "DVC"
                        ' LÀM BÁO CÁO KHU ĐVC 

                        ' End Select
                        'Case "TCT"
                        '    report.reportID = "QTSQD_13"
                        '    report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định toàn công ty theo ngày"
                        '    strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
                        'Case "KHUA"
                        '    report.reportID = "QTSQD_15"
                        '    report.Text = "Danh sách các đơn vị quẹt thẻ sai quy định khu A theo ngày"
                        '    strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
                        'Case "KHUB"
                        '    report.reportID = "QTSQD_16"
                        '    report.Text = "Danh sách quẹt thẻ sai quy định khu B theo ngày"
                        '    strArray = New String() {ngay, chkKhongTinhTangCa, chkDaChamCong}
                    Case Else
                        report.reportID = "QTSQD_14"
                        report.Text = "Danh sách quẹt thẻ sai quy định xưởng theo ngày"
                        strArray = New String() {Me.cbXuong.Value.ToString(), ngay, chkKhongTinhTangCa, chkDaChamCong}
                End Select
        End Select

     
        report.para = strArray
        report.issysReport = True
        report.Update()
        report.Refresh()
        report.Show()
    End Sub
    Private Sub btnBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaoCao.Activate
        If (Me.cbXuong.Value.ToString() <> "" And Me.dtpNgay.Text <> "") Then
            methodLoad(1) ''===tải dữ liệu từ ngày đầu tuần - cuối tuần vào bảng tam : THONGKEQUETTHESAIQUYDINH_TUAN
        Else
            MessageBox.Show("Vui lòng chọn xưởng,ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Dim ngaytam() As Date = D_C_Tuan(Me.dtpNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpNgay.Value)
    End Sub

    Private Sub cbKhu_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKhu.ValueChanged
        loadxuong()
    End Sub
End Class

