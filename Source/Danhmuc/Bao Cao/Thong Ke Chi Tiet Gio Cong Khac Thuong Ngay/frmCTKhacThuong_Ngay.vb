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

Public Class frmCTKhacThuong_Ngay
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmCTKhacThuong_Ngay_Load)
        'AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmNgayNghi_KeyUp)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

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
        'Me.btnThem.Enabled = False
        'Me.btnSua.Enabled = False
        'Me.btnXoa.Enabled = False
        'Me.btnLuu.Enabled = False
        'Me.UltraToolbarsManager1.Tools.Item("mnuThem").SharedProps.Enabled = Me.btnThem.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuSua").SharedProps.Enabled = Me.btnSua.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuXoa").SharedProps.Enabled = Me.btnXoa.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuLuu").SharedProps.Enabled = Me.btnLuu.Enabled
        'Me.ThemSua = 0
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCTKhacThuong_Ngay))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.chbXuong = New System.Windows.Forms.CheckBox
        Me.chbNgay = New System.Windows.Forms.CheckBox
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btExcel = New TD.SandBar.ButtonItem
        Me.btXemBC = New TD.SandBar.ButtonItem
        Me.ButtonItem1 = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UltraTabPageControl1.Controls.Add(Me.chbXuong)
        Me.UltraTabPageControl1.Controls.Add(Me.chbNgay)
        Me.UltraTabPageControl1.Controls.Add(Me.cbXuong)
        Me.UltraTabPageControl1.Controls.Add(Me.DateTimePicker1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(548, 110)
        '
        'chbXuong
        '
        Me.chbXuong.AutoSize = True
        Me.chbXuong.Location = New System.Drawing.Point(104, 48)
        Me.chbXuong.Name = "chbXuong"
        Me.chbXuong.Size = New System.Drawing.Size(65, 18)
        Me.chbXuong.TabIndex = 3
        Me.chbXuong.Text = "Xưởng :"
        Me.chbXuong.UseVisualStyleBackColor = True
        '
        'chbNgay
        '
        Me.chbNgay.AutoSize = True
        Me.chbNgay.Location = New System.Drawing.Point(104, 16)
        Me.chbNgay.Name = "chbNgay"
        Me.chbNgay.Size = New System.Drawing.Size(57, 18)
        Me.chbNgay.TabIndex = 3
        Me.chbNgay.Text = "Ngày :"
        Me.chbNgay.UseVisualStyleBackColor = True
        '
        'cbXuong
        '
        Me.cbXuong.Location = New System.Drawing.Point(173, 47)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(121, 21)
        Me.cbXuong.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(173, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(558, 160)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(558, 136)
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
        Me.UltraTabControl1.Size = New System.Drawing.Size(552, 133)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết giờ tăng ca khác thường ngày"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(548, 110)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(558, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin chi tiết giờ tăng ca khác thường ngày"
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
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 168)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(558, 274)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(558, 210)
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
        Me.pnlButton.Size = New System.Drawing.Size(558, 64)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btExcel, Me.btXemBC, Me.ButtonItem1})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(558, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btExcel
        '
        Me.btExcel.IconSize = New System.Drawing.Size(32, 32)
        Me.btExcel.ImageIndex = 6
        Me.btExcel.Text = "Excel"
        '
        'btXemBC
        '
        Me.btXemBC.ImageIndex = 3
        Me.btXemBC.Text = "Xem Báo Cáo"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ImageIndex = 7
        Me.ButtonItem1.Text = "Refresh"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(558, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên có giờ tăng ca vượt quá"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(564, 445)
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
        'frmCTKhacThuong_Ngay
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(564, 445)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmCTKhacThuong_Ngay"
        Me.ShowIcon = False
        Me.Text = "Chi tiet gio tang ca khac thuong ngay"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
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

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objCTKhacThuong_Ngay
        obj.Setnull()

        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/Thongke/Thongkechitiet_giotangcakhacthuong_ngay/ChiTietGioTangCaKhacThuong_Ngay.xml"), typeControl.Grid, "coldgrkhacthuongngay")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        'If (Me.dgrBC.Rows.Count > 0) Then
        '    Me.dgrBC.Rows.Item(0).Selected = True
        '    Dim dataSource As DataTable = DirectCast(Me.dgrBC.DataSource, DataTable)
        '    Me.txtID.Text = dataSource.Rows.Item(0).Item("DayOff_ID").ToString
        '    Me.txtLyDo.Text = dataSource.Rows.Item(0).Item("DayOff_Name").ToString
        '    Me.txtGhichu.Text = dataSource.Rows.Item(0).Item("Note").ToString
        '    Me.txtNoiTraLuong.Text = dataSource.Rows.Item(0).Item("Paid_By").ToString
        '    Me.txtMucLuong.Text = dataSource.Rows.Item(0).Item("Percentage").ToString
        '    Me.txtID.ReadOnly = True
        '    Me.ThemSua = 1
        'End If
    End Sub

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
    Friend WithEvents b As clsBCTKhacThuong_Ngay
    Friend WithEvents dgrBC As UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btExcel As TD.SandBar.ButtonItem
    Friend WithEvents btXemBC As TD.SandBar.ButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents chbXuong As System.Windows.Forms.CheckBox
    Friend WithEvents chbNgay As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonItem1 As TD.SandBar.ButtonItem
    Public ThemSua As Integer

    Private Sub frmCTKhacThuong_Ngay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim obj As New objCTKhacThuong_Ngay
        obj.ChonBang = 1
        Me.b = New clsBCTKhacThuong_Ngay
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.SelectedIndex = 0
        clsTools.GridTheme1(Me.dgrBC)
        Me.SetCheckBoxNull()
        Me.HienThiComBo()

        'Me.methodLoad()

    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btXemBC_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Activate
        Dim report As New FrmReport
        report.reportID = "060"
        Dim strArray As String() = New String() {Me.DateTimePicker1.Text, Me.cbXuong.Text, Me.chstateNgay, Me.chstateXuong}
        report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    Public chstateNgay As Boolean
    Public chstateXuong As Boolean

    Private Sub chbNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgay.CheckedChanged
        Me.chstateNgay = Me.chbNgay.Checked
        Me.HienThiComBo()

    End Sub

    Private Sub chbXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbXuong.CheckedChanged
        Me.chstateXuong = Me.chbXuong.Checked
        Me.HienThiComBo()

    End Sub
    Private Sub HienThiComBo()
        Me.cbXuong.Enabled = Me.chstateXuong
        Me.DateTimePicker1.Enabled = Me.chstateNgay
    End Sub

    Private Sub SetCheckBoxNull()
        Me.chbXuong.Checked = False
        Me.chbNgay.Checked = False
    End Sub

    Private Sub ButtonItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Activate
        Me.methodLoad()
    End Sub

    Private Sub XpCaption2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XpCaption2.Load

    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'e.Layout.Bands(0).Columns("NGAYC").Format = "yyyy/MM/dd"
    End Sub
End Class

