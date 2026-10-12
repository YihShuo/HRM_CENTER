''Ngày cập nhật: 03/03/2014
''Người cập nhật: Trân,Gấm(2018 thêm chức năng xoá nhóm, chknuoiconnho cho phép TS)
''Nội dung: hiển thị thông tin cột DV_MA lên lưới lấy từ bảng dữ liệu lên
''Nội dung cập nhật: mở cái mục ẩn số ngày phép thực tế - 30/03/2016
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
Imports TongHop
Imports System.Math


Imports DataObject
Imports BusinessObject
Imports Microsoft.ApplicationBlocks.Data
Imports Utility
Imports TD.SandBar.ToolBar
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmKiemTraPhepNam
    Inherits Form
    Public Sub New()
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub
    Public NgayHienTai As String = ""
    Public NgayCC As String = ""
    Public DonViCu As String = ""
    Public Flag_NC As Boolean = False
    Public Flag_CapNhat As Boolean = False
    Public Them As Boolean = False
    Public Sua As Boolean = False
    Public Xoa As Boolean = False
    Dim bChonDonViDD As Boolean = False
    Public bAdmin As Boolean = False
    Dim dTuNgay As Date
    Dim sTuNgay As Date
    Dim dDenNgay As Date
    Dim sDenNgay As Date


    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Friend WithEvents d As New clsDKiemTraPhepNam
    Friend WithEvents b As New clsBKiemTraPhepNam
    Friend WithEvents obj As New objKiemTraPhepNam
    Public ThemSua As Integer
    Public Sub LayNamChoCbNamThongKe()
        Dim dt As New DataTable
        Me.b = New clsBKiemTraPhepNam
        Dim obj As New objKiemTraPhepNam
        obj.ChonBang = 82
        dt = b.LoadDS(obj)
        Me.cbNamThongKe.DataSource = dt
        Me.cbNamThongKe.DisplayMember = "Nam"
        Me.cbNamThongKe.ValueMember = "Nam"
    End Sub
    
    'Private Sub HienThiReport()
    '    Dim document As ReportDocument
    '    Dim report As New ClsBReport
    '    Try
    '        If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
    '            document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
    '        Else
    '            document = report.InitReport(Me.reportID)
    '        End If
    '    Catch exception1 As Exception
    '        'ProjectData.SetProjectError(exception1)
    '        'Dim exception As Exception = exception1
    '        'Interaction.MsgBox(Exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
    '        'Me.Close()
    '        'ProjectData.ClearProjectError()
    '        Return
    '    End Try
    '    If Me.issysReport Then
    '        document = report.SetParameter(document, Me.para)
    '    End If
    '    rptToKhaiThue.ReportSource = document

    'End Sub
    Private Sub frmKiemTraPhepNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LayNamChoCbNamThongKe()
        cbNamThongKe.Text = Year(Today).ToString()
        'cbNam.Items.Add(Now().Year.ToString())
        Me.btnXoaNhom.Visible = False
        Me.cbNam.SelectedIndex = 1
        Me.cboNamTab2.SelectedIndex = 1
        Me.chDonvi.Checked = False
        Me.LoadComBo()
        ''an ngay nhap phep
        Me.txtNgaynhapphepHT.Enabled = False
        Me.txtNgaynhapphepHT.ReadOnly = False
        Me.lblThongtinthoiviec.Visible = False
        ''trang thai lua chon mac dinh
        If Me.cbDonvi.Items.Count > 0 Then
            cbDonvi.SelectedIndex = 0
            cbDonvi.Select()
        End If
        ''mac dinh hien tai
        Me.cbNam.Text = Now().Year.ToString()
        Me.cboNamTab2.Text = Now().Year.ToString()
        Me.txtManv_p.Focus()
        ''luoi mac dinh
        'clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBKiemTraPhepNam
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        ThemMoi()
        ''gan max len = 5
        Me.txtManv_p.MaxLength = 6
        ''================= XET TRANG THAI PHAN QUYEN THEM XOA SUA ============
        ''Ngay sua: 11/10/2013,15/10/2013
        ''nguoi sua: Trân
        ''noi dung: phan quyen them xoa sua. quyen admin thi khong xet
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.ChonBang = 26
        Dim TQuyenTruyCap, TUser As New DataTable
        TUser = Me.b.LoadDS(obj)
        If TUser.Rows.Count > 0 Then
            obj.ChonBang = 27
            TQuyenTruyCap = Me.b.LoadDS(obj)
            If TQuyenTruyCap.Rows.Count > 0 Then
                ''======================== xet trang thai la admin thi bo qua ==============''
                If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Then
                    Them = True
                    Sua = True
                    Xoa = True
                    bAdmin = True
                    Me.lblDanghiTT.Visible = True
                    Me.txtDaNghiTT.Visible = True
                    ''gan mac dinh admin dc xem
                Else
                    bAdmin = False
                    If TQuyenTruyCap.Rows(0).Item("Them").ToString() = "" Then
                        Them = False
                    Else
                        Them = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Them"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Sua").ToString() = "" Then
                        Sua = False
                    Else
                        Sua = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Sua"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Xoa").ToString() = "" Then
                        Xoa = False
                    Else
                        Xoa = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Xoa"))
                    End If
                    QuyenTruyCap()
                End If
            Else
                Them = False
                Sua = False
                Xoa = False
            End If

        Else
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Public Sub QuyenTruyCap()
        If Them Then
            Me.btnThem.Visible = True
            Me.btnThem.Enabled = True
        Else
            Me.btnThem.Visible = False
        End If

        If Sua Then
            Me.btSua.Visible = True
            'Me.btSua.Enabled = True
        Else
            Me.btSua.Visible = False
        End If
        If Xoa Then
            Me.btnXoa.Visible = True
            Me.btnXoa.Enabled = True
            If Me.chkDonvi.Checked Then
                Me.btnXoaNhom.Visible = True
                ' Me.btnXoaNhom.Enabled = True
            End If

        Else
            Me.btnXoa.Visible = False
            ' Me.btnXoaNhom.Visible = False
        End If
        ''==============an menu context ================''
        Me.lblDanghiTT.Visible = True
        Me.txtDaNghiTT.Visible = True
        If bAdmin Then
        Else
            If Them And Sua And Xoa Then
                Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = True
                Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = True
            Else
                Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = False
            End If
        End If
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub ChonDong()
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        If Not activeRow Is Nothing Then
            If activeRow.Index <> -1 Then
                Me.dgrBC.Rows(activeRow.Index).Selected = True
                Me.oldRow = activeRow.Index
            ElseIf Me.dgrBC.Rows.Count > 0 Then
                Me.dgrBC.Rows(0).Activated = True
                Me.dgrBC.Rows(0).Selected = True
            End If
        Else
            If Me.dgrBC.Rows.Count > 0 Then
                Me.dgrBC.Rows(0).Activated = True
                Me.dgrBC.Rows(0).Selected = True
            End If
        End If
    End Sub
    Public Sub methodLoad()
        ''==========================================================''
        ''Ngày cập nhật: Trân22/02/2014
        ''Người cập nhật: Trân
        ''Nội dung: hiển thị đơn vị trong bảng nghỉ phép khi ấn nút xem
        Dim grid As New clsTformatGrid
        'clsTools.GridTheme1(Me.dgrBC)
        Dim temp As DataTable
        Dim i As Integer
        Dim obj As New objKiemTraPhepNam
        If Me.cbLoaiphep.Value.ToString().Equals("OM") = False Then
            If Me.chDonvi.Checked = False Then
                obj.ChonBang = 6
                obj.MANV = Me.txtManv_p.Text.ToString()
                If obj.MANV = "" Then
                    obj.MANV = obj.MANV
                End If
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                Dim dgrBC As Object = Me.dgrBC
                If Me.dgrBC.Rows.Count > 0 Then
                    LoadGridView()
                End If
                'grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
                'If Me.dgrBC.Rows.Count <= 0 Then
                '    Exit Sub
                'End If
                Me.btnXoaNhom.Visible = False ' xem theo số thẻ thì k có chức năng xó nhóm
            Else
                ''xem theo don vi: cột DV_MA trong bảng phép hiện lên lưới, lưu vào bảng dùng cột DV_MA_ 

                If Me.cbDonvi.Text = "" Then
                    If Me.DonViCu <> "" Then
                        obj.DonVi = Me.DonViCu
                    Else
                        obj.DonVi = Me.cbDonvi.Value.ToString()
                    End If
                Else
                    obj.DonVi = Me.cbDonvi.Value.ToString()
                End If
                If obj.DonVi = "TCT" Then
                    obj.ChonBang = 122
                Else
                    obj.ChonBang = 12
                End If
                obj.TuNgay = Me.dtpTungay.Value.Year.ToString() + "-" + Me.dtpTungay.Value.Month.ToString() + "-" + Me.dtpTungay.Value.Day.ToString()
                obj.DenNgay = Me.dtpDenngay.Value.Year.ToString() + "-" + Me.dtpDenngay.Value.Month.ToString() + "-" + Me.dtpDenngay.Value.Day.ToString()
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                Dim dgrBC As Object = Me.dgrBC
                If Me.dgrBC.Rows.Count > 0 Then
                    LoadGridView()
                    Me.btnXoaNhom.Visible = True
                End If
                ' grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
                If Me.dgrBC.Rows.Count <= 0 Then
                    MessageBox.Show("Không có " & txtManv_p.Text & " dữ liệu nghỉ phép đơn vị: " & Me.cbDonvi.Text, "Thông báo", MessageBoxButtons.OK)
                End If

            End If
        Else
            If Me.chDonvi.Checked = False Then
                obj.ChonBang = 666 '6
                obj.MANV = Me.txtManv_p.Text.ToString()
                If obj.MANV = "" Then
                    obj.MANV = obj.MANV
                End If
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                Dim dgrBC As Object = Me.dgrBC
                If Me.dgrBC.Rows.Count > 0 Then
                    LoadGridViewOM()
                End If
                'grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
                'If Me.dgrBC.Rows.Count <= 0 Then
                '    Exit Sub
                'End If
                Me.btnXoaNhom.Visible = False ' xem theo số thẻ thì k có chức năng xó nhóm
            Else
                ''xem theo don vi: cột DV_MA trong bảng phép hiện lên lưới, lưu vào bảng dùng cột DV_MA_ 

                If Me.cbDonvi.Text = "" Then
                    If Me.DonViCu <> "" Then
                        obj.DonVi = Me.DonViCu
                    Else
                        obj.DonVi = Me.cbDonvi.Value.ToString()
                    End If
                Else
                    obj.DonVi = Me.cbDonvi.Value.ToString()
                End If
                If obj.DonVi = "TCT" Then
                    obj.ChonBang = 1221 '122
                Else
                    obj.ChonBang = 1222 '12
                End If
                obj.TuNgay = Me.dtpTungay.Value.Year.ToString() + "-" + Me.dtpTungay.Value.Month.ToString() + "-" + Me.dtpTungay.Value.Day.ToString()
                obj.DenNgay = Me.dtpDenngay.Value.Year.ToString() + "-" + Me.dtpDenngay.Value.Month.ToString() + "-" + Me.dtpDenngay.Value.Day.ToString()
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                Dim dgrBC As Object = Me.dgrBC
                If Me.dgrBC.Rows.Count > 0 Then
                    LoadGridViewOM()
                    Me.btnXoaNhom.Visible = True
                End If
                ' grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
                If Me.dgrBC.Rows.Count <= 0 Then
                    MessageBox.Show("Không có " & txtManv_p.Text & " dữ liệu nghỉ phép đơn vị: " & Me.cbDonvi.Text, "Thông báo", MessageBoxButtons.OK)
                End If

            End If
        End If

        ''xem theo so the
        
        ''load lai thong tin phep nam : hieu chinh ngay 06-08-2013
        Me.LayThongTin()
        ChonDong()
        Me.HieuChinh()

    End Sub
    Private Sub LoadGridViewOM()

        'Dim i As Integer
        'With Me.dgrBC.DisplayLayout.Bands(0)
        '    For i = 0 To .Columns.Count - 1
        '        .Columns(i).CellActivation() = Activation.NoEdit
        '        .Columns(i).CellAppearance.TextHAlign = HAlign.Center
        '        .Columns(i).CellAppearance.TextVAlign = VAlign.Middle
        '    Next

        'End With
        Try
            'Sort
            Me.dgrBC.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            'Filter
            Me.dgrBC.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            Me.dgrBC.DisplayLayout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
            Me.dgrBC.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
            Me.dgrBC.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
            Me.dgrBC.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
            Me.dgrBC.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.LightYellow
            'e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
            Me.dgrBC.DisplayLayout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
            Me.dgrBC.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            Me.dgrBC.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
            'Column Chooser

            Me.dgrBC.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            Me.dgrBC.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Me.dgrBC.DisplayLayout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
            With dgrBC.DisplayLayout.Bands(0)
                If Me.chkDonvi.Checked Then
                    If dgrBC.DisplayLayout.Bands(0).Columns.Exists("CHON") = False Then
                        Dim checkColumn As UltraGridColumn = .Columns.Add("CHON", "Chọn")
                        checkColumn.DataType = GetType(Boolean)
                        checkColumn.Style = UltraWinGrid.ColumnStyle.CheckBox
                        ' checkColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                        checkColumn.CellActivation = CellClickAction.Edit
                        checkColumn.Header.VisiblePosition = 0
                    End If
                    .Columns("CHON").CellClickAction = CellClickAction.Edit
                    .Columns("CHON").CellActivation = Activation.AllowEdit
                Else
                    If dgrBC.DisplayLayout.Bands(0).Columns.Exists("CHON") = True Then
                        .Columns.Remove(0)
                    End If


                End If


                'If dgrBC.DisplayLayout.Bands(0).Columns.Exists("STT") = False Then
                '    Dim STT As UltraGridColumn = dgrBC.DisplayLayout.Bands(0).Columns.Add("STT", "STT")
                '    STT.DataType = GetType(Integer)
                '    STT.CellActivation = Activation.NoEdit
                '    STT.Header.VisiblePosition = 0
                'End If
                '.Columns("STT").Header.Caption = "STT"
                '.Columns("STT").Width = 60
                .Columns("NV_MA").Header.Caption = "Số Thẻ"
                '.Columns("NV_MA").Width = 120

                .Columns("NP_TuNgay").Header.Caption = "Nghỉ Từ Ngày"
                '.Columns("NP_TuNgay").Width = 200

                .Columns("NP_DenNgay").Header.Caption = "Nghỉ Đến Ngày"
                ' .Columns("NP_DenNgay").Width = 180

                .Columns("DV_MA").Header.Caption = "Đơn Vị Điều Động"
                .Columns("DV_MA").Hidden = True
                '.Columns("DV_MA").Width = 150

                .Columns("DV_MA_LUOI").Header.Caption = "Đơn Vị"
                ' .Columns("DV_MA_LUOI").Width = 450

                .Columns("NP_Ma").Header.Caption = "Loại Phép"
                '.Columns("NP_Ma").Width = 450

                .Columns("NP_CONGTYDUYET").Header.Caption = "Cty duyệt"
                ' .Columns("NP_CONGTYDUYET").Width = 450

                .Columns("NP_XINCONNUOI").Header.Caption = "Xin con nuôi"

                .Columns("NP_GhiChu").Header.Caption = "Ghi Chú"
                ' .Columns("NP_GhiChu").Width = 450

                .Columns("NP_NGAYNHAPPHEP").Header.Caption = "Ngày nhập"
                ' .Columns("NP_NGAYNHAPPHEP").Width = 450

                .Columns("NP_NGAYNHAPSUA").Header.Caption = "Ngày duyệt"
                '.Columns("NP_NGAYNHAPSUA").Width = 450

                .Columns("NP_NGAYSUA_NS").Header.Caption = "Ngày sửa"
                '.Columns("NP_NGAYSUA_NS").Width = 450
                .Columns("TT_TEN").Header.Caption = "TỈNH THÀNH"
                .Columns("QH_TEN").Header.Caption = "QUẬN HUYỆN"
                .Columns("XP_TEN").Header.Caption = "XÃ PHƯỜNG"

            End With

            'Dim ii As Integer
            'For ii = 0 To Me.dgrBC.Rows.Count - 1
            '    dgrBC.Rows(ii).Cells("STT").Value = ii + 1
            'Next
            'Dim i As Integer
            'For i = 1 To 4
            '    dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            '    ' dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            'Next
            Me.dgrBC.UpdateData()
            'ChonDongCu()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        ' AddSummaryColunm("Count", dgrBC, "NV_MA", "Số dòng")
        'AddSummaryColunm("Count", dgrBC2, "NV_MA", "Số dòng")
    End Sub
    Private Sub LoadGridView()

        'Dim i As Integer
        'With Me.dgrBC.DisplayLayout.Bands(0)
        '    For i = 0 To .Columns.Count - 1
        '        .Columns(i).CellActivation() = Activation.NoEdit
        '        .Columns(i).CellAppearance.TextHAlign = HAlign.Center
        '        .Columns(i).CellAppearance.TextVAlign = VAlign.Middle
        '    Next

        'End With
        Try
            'Sort
            Me.dgrBC.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            'Filter
            Me.dgrBC.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            Me.dgrBC.DisplayLayout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
            Me.dgrBC.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
            Me.dgrBC.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
            Me.dgrBC.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
            Me.dgrBC.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.LightYellow
            'e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
            Me.dgrBC.DisplayLayout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
            Me.dgrBC.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            Me.dgrBC.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
            'Column Chooser

            Me.dgrBC.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            Me.dgrBC.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Me.dgrBC.DisplayLayout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
            With dgrBC.DisplayLayout.Bands(0)
                If Me.chkDonvi.Checked Then
                    If dgrBC.DisplayLayout.Bands(0).Columns.Exists("CHON") = False Then
                        Dim checkColumn As UltraGridColumn = .Columns.Add("CHON", "Chọn")
                        checkColumn.DataType = GetType(Boolean)
                        checkColumn.Style = UltraWinGrid.ColumnStyle.CheckBox
                        ' checkColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                        checkColumn.CellActivation = CellClickAction.Edit
                        checkColumn.Header.VisiblePosition = 0
                    End If
                    .Columns("CHON").CellClickAction = CellClickAction.Edit
                    .Columns("CHON").CellActivation = Activation.AllowEdit
                Else
                    If dgrBC.DisplayLayout.Bands(0).Columns.Exists("CHON") = True Then
                        .Columns.Remove(0)
                    End If


                End If


                'If dgrBC.DisplayLayout.Bands(0).Columns.Exists("STT") = False Then
                '    Dim STT As UltraGridColumn = dgrBC.DisplayLayout.Bands(0).Columns.Add("STT", "STT")
                '    STT.DataType = GetType(Integer)
                '    STT.CellActivation = Activation.NoEdit
                '    STT.Header.VisiblePosition = 0
                'End If
                '.Columns("STT").Header.Caption = "STT"
                '.Columns("STT").Width = 60
                .Columns("NV_MA").Header.Caption = "Số Thẻ"
                '.Columns("NV_MA").Width = 120

                .Columns("NP_TuNgay").Header.Caption = "Nghỉ Từ Ngày"
                '.Columns("NP_TuNgay").Width = 200

                .Columns("NP_DenNgay").Header.Caption = "Nghỉ Đến Ngày"
                ' .Columns("NP_DenNgay").Width = 180

                .Columns("DV_MA").Header.Caption = "Đơn Vị Điều Động"
                .Columns("DV_MA").Hidden = True
                '.Columns("DV_MA").Width = 150

                .Columns("DV_MA_LUOI").Header.Caption = "Đơn Vị"
                ' .Columns("DV_MA_LUOI").Width = 450

                .Columns("NP_Ma").Header.Caption = "Loại Phép"
                '.Columns("NP_Ma").Width = 450

                .Columns("NP_CONGTYDUYET").Header.Caption = "Cty duyệt"
                ' .Columns("NP_CONGTYDUYET").Width = 450

                .Columns("SN_CHUNHAT").Header.Caption = "Ngày Chủ Nhật"

                .Columns("NP_XINCONNUOI").Header.Caption = "Xin con nuôi"

                .Columns("NP_GhiChu").Header.Caption = "Ghi Chú"
                ' .Columns("NP_GhiChu").Width = 450

                .Columns("NP_NGAYNHAPPHEP").Header.Caption = "Ngày nhập"
                ' .Columns("NP_NGAYNHAPPHEP").Width = 450

                .Columns("NP_NGAYNHAPSUA").Header.Caption = "Ngày duyệt"
                '.Columns("NP_NGAYNHAPSUA").Width = 450

                .Columns("NP_NGAYSUA_NS").Header.Caption = "Ngày sửa"
                '.Columns("NP_NGAYSUA_NS").Width = 450

            End With

            'Dim ii As Integer
            'For ii = 0 To Me.dgrBC.Rows.Count - 1
            '    dgrBC.Rows(ii).Cells("STT").Value = ii + 1
            'Next
            'Dim i As Integer
            'For i = 1 To 4
            '    dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            '    ' dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            'Next
            Me.dgrBC.UpdateData()
            'ChonDongCu()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        ' AddSummaryColunm("Count", dgrBC, "NV_MA", "Số dòng")
        'AddSummaryColunm("Count", dgrBC2, "NV_MA", "Số dòng")
    End Sub
    Public Sub methodLoad1()
        Dim grid As New clsTformatGrid
        Dim obj As New objKiemTraPhepNam
        Me.b = New clsBKiemTraPhepNam

        'clsTools.GridTheme1(Me.dgrBC)
        obj.ChonBang = 32
        obj.NAM = Me.cboNamTab2.Text
        obj.MANV = Me.txtManvTab2.Text.Trim.ToString()

        If obj.NAM <> "" And obj.MANV <> "" Then
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            If Me.dgrBC.Rows.Count > 0 Then
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
            Else
                MessageBox.Show("Nhân viên này không có dữ liệu nghỉ phép ốm - con ốm ! ")
            End If
        End If
    End Sub
    Private Sub LoadComBo()
        'Load danh sach don vi========================
        Dim Table, Table1 As DataTable
        Dim obj As New objKiemTraPhepNam
        obj.ChonBang = 4
        Me.b = New clsBKiemTraPhepNam
        Table = Me.b.LoadDS(obj)
        Table.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Table
        Me.cbDonvi.SelectedIndex = 0

        'Load danh sach phep==========================
        obj.ChonBang = 5
        Me.b = New clsBKiemTraPhepNam
        Table1 = Me.b.LoadDS(obj)
        Me.cbLoaiphep.DataSource = Table1
        If Table1.Rows.Count > 0 Then
            Me.cbLoaiphep.SelectedIndex = 0
            Me.cbLoaiphep.Select()
        End If
        ''========= load thong tin cho tab2==============
        Me.cboDonviTab2.Enabled = False

        ''========= load thong tin tinh thanh ===========

        obj.ChonBang = 61
        'Load Tinh cho combobox TinhthanhQQ
        Me.b = New clsBKiemTraPhepNam
        Me.cbTinhThanhQQ.DataSource = Me.b.LoadDS(obj)
        Me.cbTinhThanhQQ.DisplayMember() = "TT_Ten"
        Me.cbTinhThanhQQ.ValueMember() = "TT_Ma"
        Me.cbTinhThanhQQ.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        cbTinhThanhQQ.Visible = False
        cbQuanHuyenQQ.Visible = False
        cbXaQQ.Visible = False
        lbtinh.Visible = False
        lbhuyen.Visible = False
        lbxa.Visible = False

    End Sub
    Private Sub txtManv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManv.ValueChanged
        Me.LayThongTin()
    End Sub
    Private Sub LayThongTin()
        Dim Table As DataTable
        Dim obj As New objKiemTraPhepNam
        Dim SongayCL As Double
        obj.ChonBang = 1
        obj.MANV = Me.txtManv.Text.ToString()
        obj.NAM = Me.cbNam.Text.ToString()
        Me.b = New clsBKiemTraPhepNam
        'Lay thong tin trong bang st_phepnam=================
        Me.lblThoiviec.Text = ""
        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count > 0 Then
            Me.txtPhepnamnamtruoc.Text = Table.Rows(0).Item("PN_Songaynamtruoc").ToString()
            Me.txtPhepnamnamnay.Text = Table.Rows(0).Item("PN_Songaynamnay").ToString()
            Me.txtTren5Nam.Text = Table.Rows(0).Item("PN_PhepTren5Nam").ToString()
            Me.txtNangNhocDocHai.Text = Table.Rows(0).Item("PN_NangnhocDH").ToString()
            Me.txtthangnndh.Text = Table.Rows(0).Item("PN_Sothanglamnndh").ToString()
        Else
            Me.txtPhepnamnamtruoc.Clear()
            Me.txtPhepnamnamnay.Clear()
            Me.txtNangNhocDocHai.Clear()
            Me.txtSongayconlai.Clear()
            Me.txtTren5Nam.Clear()
            Me.txtthangnndh.Clear()
        End If

        'Lay thong tin trong bang st_nhanviennghiphep=================
        obj.ChonBang = 2
        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count > 0 Then
            Me.txtSongaydanghi.Text = Table.Rows(0).Item("SONGAYDANGHI").ToString()
            SongayCL = (Val(Me.txtPhepnamnamtruoc.Text) + Val(Me.txtPhepnamnamnay.Text) + Val(Me.txtNangNhocDocHai.Text) + Val(Me.txtTren5Nam.Text)) - Val(Me.txtSongaydanghi.Text)

            Me.txtSongayconlai.Text = SongayCL.ToString()
            If Val(Me.txtPhepnamnamtruoc.Text) < 0 Then ' Hiệu chỉnh nếu số ngày ntruoc (âm lại) thì công vào , ngược lại k cộng 
                Me.txtDaNghiTT.Text = (Abs(Val(Me.txtPhepnamnamtruoc.Text)) + Val(Me.txtSongaydanghi.Text))
            Else
                Me.txtDaNghiTT.Text = Val(Me.txtSongaydanghi.Text)
            End If
        Else
            Me.txtSongaydanghi.Clear()
            Me.txtSongayconlai.Clear()
            Me.txtDaNghiTT.Clear()
        End If

        'Lay thong tin trong bang st_nhanvien=================
        obj.ChonBang = 3
        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count > 0 Then
            Me.txtTen.Text = Table.Rows(0).Item("NV_TEN").ToString()
            Me.txtNgayvao.Text = Table.Rows(0).Item("NV_NGAYVAO").ToString()
            If Table.Rows(0).Item("TV_NGAYTHOIVIEC").ToString() <> "" Then
                Me.lblThoiviec.Visible = True
                Me.lblThoiviec.Text = Me.txtManv.Text & " thôi việc ngày: " & Table.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
            End If
        Else
            Me.txtTen.Clear()
            Me.txtNgayvao.Clear()
            Me.lblThoiviec.Visible = False
            Me.lblThoiviec.Text = ""
        End If
    End Sub
    Private Function KiemtradlMT(ByVal Manv As String) As Boolean
        ''tim trong IT_PNMT
        Dim t As DataTable
        obj.ChonBang = 19
        obj.MANV = Manv
        t = Me.b.LoadDS(obj)
        If t.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TinhSoLanTS(ByVal manv As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", manv))
        Me.b.GoiThuTuc("SP_TINHSOLANTS", listpar)
        listpar.Clear()
    End Sub
    Private Function KiemtraPhepLongNhau(ByVal manv As String, ByVal tungay As String, ByVal denngay As String, ByVal thaotac As String) As Boolean
        Dim SqlParam As SqlParameter() = {New SqlParameter("@NV_MA", SqlDbType.NVarChar, 50), _
                                          New SqlParameter("@TUNGAY", SqlDbType.NVarChar, 50), _
                                          New SqlParameter("@THAOTAC", SqlDbType.NVarChar, 50), _
                                          New SqlParameter("@DENNGAY", SqlDbType.NVarChar, 50)}
        SqlParam(0).Value = manv
        SqlParam(1).Value = tungay
        SqlParam(2).Value = thaotac
        SqlParam(3).Value = denngay

        Dim tblTemp As DataTable
        tblTemp = Me.b.PhepLongNhau("SP_KTRA_PHEP_LONGNHAU ", SqlParam)

        If tblTemp.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub NgayHT()
        Me.b = New clsBKiemTraPhepNam
        Dim tableNgay As DataTable
        Dim ngayt As Date
        Dim ngay As Date
        obj.ChonBang = 18
        tableNgay = Me.b.LoadDS(obj)
        If tableNgay.Rows.Count > 0 Then
            NgayHienTai = tableNgay.Rows(0).Item("NGAY").ToString()
            Me.txtNgaynhapphepHT.Text = NgayHienTai
            ngayt = NgayHienTai
            ngay = ngayt
            obj.NGAYNHAP = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()

            NgayCC = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ((ngay.Day)).ToString()
            Me.txtNgaynhapphepHT.Text = ngay.ToString("dd-MM-yyyy")
            Me.NgayHienTai = obj.NGAYNHAP
            obj.Thoigian = tableNgay.Rows(0).Item("NGAY").ToString()
        Else
            Me.NgayHienTai = Now().ToString("dd-MM-yyyy")
            Me.txtNgaynhapphepHT.Text = NgayHienTai
            ngay = NgayHienTai
            obj.NGAYNHAP = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
            NgayCC = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ((ngay.Day) - 1).ToString()
            Me.txtNgaynhapphepHT.Text = NgayHienTai.ToString("dd-MM-yyyy")
            Me.NgayHienTai = obj.NGAYNHAP
        End If
    End Sub
    Private Sub cbNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNam.SelectedIndexChanged
        Me.LayThongTin()
    End Sub
    Private Sub DonViCheckChange()

    End Sub
    Private Sub chDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chDonvi.CheckedChanged
        Me.ThemMoi()
        If Me.chDonvi.Checked = True Then
            Me.cbDonvi.ReadOnly = False
            Me.txtManv_p.Clear()
            Me.txtManv_p.Enabled = False
            If Me.cbDonvi.Items.Count > 0 Then
                cbDonvi.SelectedIndex = 0
                cbDonvi.Select()
            End If
            Me.chkDonvi.Checked = True
            Me.btSua.Enabled = False
            '  Me.btnXoaNhom.Visible = True
        Else
            Me.cbDonvi.ReadOnly = True
            Me.txtManv_p.Enabled = True
            Me.chkDonvi.Checked = False
            Me.btnXoaNhom.Visible = False
        End If
    End Sub
    Private Sub txtManv_p_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManv_p.KeyPress
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar))) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtManv_p_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManv_p.TextChanged
        Dim Table, TableTV As DataTable
        obj.MANV = Me.txtManv_p.Text.ToString()
        Me.b = New clsBKiemTraPhepNam
        Me.lblThongtinthoiviec.Text = ""
        Me.lblThoiviec.Text = ""
        Me.dtpTungay.Enabled = True
        Me.lblSoNV.Text = ""
        Me.txtTen_p.Clear()
        Me.cbDonvi.Clear()
        Me.txtNgayvao_p.Clear()
        Me.lblThongtinthoiviec.Visible = False
        Me.dtpTungay.Value = Now()
        Me.dtpDenngay.Value = Now()
        Me.btSua.Enabled = False
        '  Me.btnXoaNhom.Visible = False
        '  Me.btnXoa.Enabled = False
        If txtManv_p.Text.Trim.Length = 6 Then
            ''=================== bat trang thai tim kiem theo don vi dieu dong ================''
            Me.bChonDonViDD = True
            obj.ChonBang = 9
            TableTV = Me.b.LoadDS(obj)

            If TableTV.Rows.Count > 0 Then
                Me.lblThongtinthoiviec.Visible = True
                'Me.lblThongtinthoiviec.Text = "Số thẻ: " & Me.txtManv_p.Text.ToString() & " đã thôi việc ngày: " & TableTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                ''ngay cap nhat: 16/07/2013, 19/07/2013,06-08-2013
                '' nguoi cap nhat: Tran
                ''neu co thoi viec thi khong cho them sua xoa thong tin phep,clear thong tin, kiem tra maxlen,..*,load ham lay phep nam hien len group ben phai 
                ' Me.btnThem.Enabled = False
                ' Me.btnXoa.Enabled = False
                Me.btSua.Enabled = False
                Me.btnXoaNhom.Visible = False
                Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = False
                ''========== co thoi viec kiem tra la don vi T hay NV
                obj.ChonBang = 25
                Table = Me.b.LoadDS(obj)
                If Table.Rows.Count > 0 Then
                    Me.txtTen_p.Text = Table.Rows(0).Item("NV_TEN").ToString()
                    Me.txtNgayvao_p.Text = Table.Rows(0).Item("NV_NGAYVAO").ToString()
                    If Not Table.Rows(0).Item("DV_MA") Is Nothing Then
                        ''============ DON VI THOI VIEC LA NV
                        If Table.Rows(0).Item("DV_MA") = "NV" Or Table.Rows(0).Item("DV_MA") = "NV01" Or Table.Rows(0).Item("DV_MA") = "NV02" Or Table.Rows(0).Item("DV_MA") = "NV03" Or Table.Rows(0).Item("DV_MA") = "NV04" Then
                            cbDonvi.Value = ""
                            Me.lblThongtinthoiviec.Text = "Số thẻ: " & Me.txtManv_p.Text.ToString() & " đã thôi việc ngày: " & TableTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString() & " đơn vị: " & Table.Rows(0).Item("DV_MA").ToString()
                            Me.lblThoiviec.Visible = True
                            Me.lblThoiviec.Text = lblThongtinthoiviec.Text
                        End If
                        ''============ DON VI THOI VIEC LA T
                        If Table.Rows(0).Item("DV_MA") = "T" Or Table.Rows(0).Item("DV_MA") = "T01" Or Table.Rows(0).Item("DV_MA") = "T02" Or Table.Rows(0).Item("DV_MA") = "T03" Or Table.Rows(0).Item("DV_MA") = "TST" Or Table.Rows(0).Item("DV_MA") = "T01ST" Or Table.Rows(0).Item("DV_MA") = "T02ST" Or Table.Rows(0).Item("DV_MA") = "T03ST" Then
                            Me.cbDonvi.Value = Table.Rows(0).Item("DV_MA").ToString()
                            Me.lblThongtinthoiviec.Text = "Số thẻ: " & Me.txtManv_p.Text.ToString() & " đã thôi việc ngày: " & TableTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                            Me.lblThoiviec.Visible = True
                            Me.lblThoiviec.Text = lblThongtinthoiviec.Text
                        End If
                        ''================== DIEU DONG SAI; KHONG DUNG DON VI LA T OR NV MA LA 1 DON VI KHAC
                        If Table.Rows(0).Item("DV_MA") <> "T" And Table.Rows(0).Item("DV_MA") <> "T01" And Table.Rows(0).Item("DV_MA") <> "T02" And Table.Rows(0).Item("DV_MA") <> "T03" And Table.Rows(0).Item("DV_MA") <> "TST" And Table.Rows(0).Item("DV_MA") <> "T01ST" And Table.Rows(0).Item("DV_MA") <> "T02ST" And Table.Rows(0).Item("DV_MA") <> "T03ST" And Table.Rows(0).Item("DV_MA") <> "NV" And Table.Rows(0).Item("DV_MA") <> "NV01" And Table.Rows(0).Item("DV_MA") <> "NV02" And Table.Rows(0).Item("DV_MA") <> "NV03" And Table.Rows(0).Item("DV_MA") <> "NV04" Then
                            Me.cbDonvi.Value = Table.Rows(0).Item("DV_MA").ToString()
                            Me.lblThongtinthoiviec.Text = "Số thẻ: " & Me.txtManv_p.Text.ToString() & " đã thôi việc ngày: " & TableTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                            Me.lblThoiviec.Visible = True
                            Me.lblThoiviec.Text = lblThongtinthoiviec.Text
                        End If
                    End If
                End If
            Else
                ''==================== KHONG CO THOI VIEC
                obj.ChonBang = 3
                Table = Me.b.LoadDS(obj)
                If Table.Rows.Count > 0 Then
                    Me.txtTen_p.Text = Table.Rows(0).Item("NV_TEN").ToString()
                    Me.txtNgayvao_p.Text = Table.Rows(0).Item("NV_NGAYVAO").ToString()
                    Me.cbDonvi.Value = Table.Rows(0).Item("DV_MA").ToString()
                    ''======= fix khong lay duoc so the cua don vi ban giam doc ===========
                    If Not Table.Rows(0).Item("DV_MA") Is Nothing Then
                        If Table.Rows(0).Item("DV_MA") = "BGD" Or Table.Rows(0).Item("DV_MA") = "BGDX" Then
                            MessageBox.Show("Số thẻ: " & Me.txtManv_p.Text & " thuộc " & Table.Rows(0).Item("DV_MA") & ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtManv_p.Focus()
                            Me.txtManv_p.SelectAll()
                            Me.btnThem.Enabled = False
                            Me.btnXoa.Enabled = False
                            '  Me.btnXoaNhom.Visible = False
                            Me.btSua.Enabled = False
                            Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = False
                            Exit Sub
                        End If
                        If Table.Rows(0).Item("DV_MA") = "" Then
                            MessageBox.Show("Số thẻ: " & Me.txtManv_p.Text & " không có đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtManv_p.Focus()
                            Me.txtManv_p.SelectAll()
                            Me.btnThem.Enabled = False
                            Me.btnXoa.Enabled = False
                            ' Me.btnXoaNhom.Visible = False
                            Me.btSua.Enabled = False
                            Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = False
                            Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = False
                            Exit Sub
                        End If
                        Try
                            Me.TongSoDonvi(Me.cbDonvi.Value.ToString())
                        Catch ex As Exception
                            Return
                        End Try

                    End If
                    '''============ DA DIEU DONG THI LAY T
                    ''' KHONG DIEU DONG LAY DV_MA_
                    ''' hieu chinh theo quyen truy cap them xoa sua ngay 11/09/2013 Tran
                    Me.cbDonvi.Value = Table.Rows(0).Item("DV_MA").ToString()
                    Me.lblThongtinthoiviec.Visible = False
                    Me.QuyenTruyCap()
                Else
                    '' khong tim thay
                    Me.txtTen_p.Clear()
                    Me.cbDonvi.Clear()
                    Me.txtNgayvao_p.Clear()
                    Me.lblThongtinthoiviec.Visible = False
                    MessageBox.Show("Không tìm thấy số thẻ:" & Me.txtManv_p.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtManv_p.Focus()
                    Me.txtManv_p.SelectAll()
                    Exit Sub
                End If
                LayThongTin()
            End If
        Else
            '' chua du text leng hoac khong tim thay so the hop le
            Me.txtTen_p.Clear()
            Me.cbDonvi.Clear()
            Me.txtNgayvao_p.Clear()
            Me.lblThongtinthoiviec.Visible = False
            Me.dtpTungay.Value = Now()
            Me.dtpDenngay.Value = Now()
            Me.btSua.Enabled = False
            ' Me.btnXoaNhom.Visible = False
            ' Me.btnXoa.Enabled = False
            Exit Sub
        End If
        Me.txtManv.Text = Me.txtManv_p.Text
    End Sub
    Private Sub btnRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Activate
        Select Case Me.UltraTabControl1.SelectedTab.Index

            Case 0

                Me.methodLoad()
                If Me.chkDonvi.Checked Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If Me.dgrBC.Selected.Rows.Count = 1 Then
                    Else
                        If Me.dtpTungay.Enabled = False Then
                            Me.dtpTungay.Enabled = True
                            Me.dtpTungay.Value = Now()
                            Me.dtpDenngay.Value = Now()
                        End If
                    End If
                    Me.btSua.Enabled = False
                    Me.btnXoaNhom.Visible = True
                Else
                    ''' ham nay dung them moi cho so the
                    ThemMoi()
                    Me.btnXoaNhom.Visible = False
                End If
            Case 1
                ''========= xem cac ngay nghi phep OM-CO ==========
                methodLoad1()
        End Select
    End Sub
    Private Function KiemtraNgayCN(ByVal tungay As Date, ByVal denngay As Date) As Boolean
        Dim i, k As Integer
        Dim songay As Integer = 0
        Dim ngaykt As Date
        songay = DateDiff(DateInterval.Day, tungay, denngay) + 1
        If Weekday(tungay) = 1 Or Weekday(denngay) = 1 Then
            Return False
        ElseIf songay >= 1 Then
            k = songay
            ngaykt = tungay
            For i = 1 To k
                ''add them 1 ngay 
                If Weekday(ngaykt) = 1 Then
                    Return False
                    Exit Function
                End If
                ngaykt = DateAdd(DateInterval.Day, i, tungay)
            Next
            Return True
        Else
            Return True
        End If
    End Function
    Dim oldRow As Integer = 0
    Private Sub TongSoDonvi(ByVal donvi)
        Dim table1 As DataTable
        If Me.chkDonvi.Checked Or (Me.txtManv_p.Text.Trim.ToString() <> "" And Me.txtManv_p.Enabled = True) Then
            obj.ChonBang = 24
            If Not Me.cbDonvi.Value Is Nothing Then
                obj.DonVi = Me.cbDonvi.Value.ToString()
                table1 = Me.b.LoadDS(obj)
                If table1.Rows.Count > 0 Then
                    Me.lblSoNV.Text = " : " & table1.Rows(0).Item("SLNV")
                End If
            End If
        Else
            Me.lblSoNV.Text = ""
        End If
    End Sub
    'Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
    '    obj.Setnull()
    '    ThemSua = 0
    '    Dim i As Integer = 0
    '    Dim tngay As Date = Me.dtpTungay.Value
    '    Dim tungay As String = tngay.Year.ToString() + "-" + tngay.Month.ToString() + "-" + tngay.Day.ToString()
    '    Dim dngay As Date = Me.dtpDenngay.Value
    '    Dim denngay As String = dngay.Year.ToString() + "-" + dngay.Month.ToString() + "-" + dngay.Day.ToString()
    '    Dim sDonvi As String

    '    Dim xaqq As String
    '    Dim huyenqq As String
    '    Dim tinhqq As String

    '    If Me.cbTinhThanhQQ.Text = "" Then
    '        tinhqq = ""
    '    Else
    '        tinhqq = Me.cbTinhThanhQQ.Value.ToString().Trim
    '    End If
    '    obj.TTQQ = tinhqq

    '    'lay gia tri huyen neu cbQuanHuyenQQ khác rỗng
    '    If Me.cbQuanHuyenQQ.Text = "" Then
    '        huyenqq = ""
    '    Else
    '        huyenqq = Me.cbQuanHuyenQQ.Value.ToString().Trim
    '    End If

    '    obj.QHQQ = huyenqq

    '    'lay gia tri xa neu cbXaQQ khác rỗng
    '    If Me.cbXaQQ.Text = "" Then
    '        xaqq = ""
    '    Else
    '        xaqq = Me.cbXaQQ.Value.ToString().Trim
    '    End If

    '    obj.XAQQ = xaqq

    '    ''====================== bat trang thai tim kiem theo don vi dieu dong ===========''
    '    Me.bChonDonViDD = True
    '    ''=========== kiem tra den ngay >= tu ngay =============
    '    Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
    '                                                               New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
    '                                                               New SqlParameter("@LoaiPhep", SqlDbType.NVarChar, 50), _
    '                                                               New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
    '    SqlParam(0).Value = ""
    '    SqlParam(1).Value = tungay
    '    SqlParam(2).Value = Me.cbLoaiphep.Value
    '    SqlParam(3).Value = denngay
    '    Dim tblKiemtraphep As DataTable
    '    tblKiemtraphep = Me.b.PhepLongNhau("SP_NHANVIENNGHIPHEP_KIEMTRANGAYNHAP", SqlParam) ' có ngày lễ hoặc chọn khoảng time hơn 30 ngày 
    '    If tblKiemtraphep.Rows(0).Item(0).ToString <> "OK" Then
    '        MessageBox.Show("" & tblKiemtraphep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '        Exit Sub
    '    End If
    '    If dngay < tngay Then
    '        MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        If Me.chDonvi.Checked = True Then
    '            If Me.chkDonvi.Checked Then
    '                ''chon toan don vi
    '                txtManv_p.Enabled = False
    '                If (MessageBox.Show(("Bạn muốn nhập phép: " & Me.cbLoaiphep.Text & " cho toàn đơn vị: " & Me.cbDonvi.Text & " Từ ngày:" & tngay.Day.ToString() + "/" + tngay.Month.ToString() + "/" + tngay.Year.ToString() & " đến ngày:" & dngay.Day.ToString() + "/" + dngay.Month.ToString() + "/" + dngay.Year.ToString() & " đúng không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
    '                    Dim TableDV As DataTable
    '                    Dim MaNV As String
    '                    Me.b = New clsBKiemTraPhepNam
    '                    If Me.cbDonvi.Value Is Nothing Then
    '                        MessageBox.Show("Vui lòng chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        Exit Sub
    '                    End If
    '                    obj.DonVi = Me.cbDonvi.Value
    '                    obj.setvalue(Me.txtManv_p.Text, tungay, denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), chkCongTyDuyet.Checked, chkXinConNuoi.Checked)
    '                    If cbDonvi.Value.ToString() = "" Or obj.TuNgay = "" Or obj.DenNgay = "" Or obj.LoaiPhep = "" Then
    '                        MessageBox.Show("Dữ liệu không bỏ trống, vui lòng chọn đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        Me.methodLoad()
    '                        Exit Sub
    '                    Else
    '                        DonViCu = obj.DonVi
    '                        TongSoDonvi(obj.DonVi)
    '                    End If
    '                    If obj.LoaiPhep = "TS" Or obj.LoaiPhep = "DS" Or obj.LoaiPhep = "ST" Then
    '                        MessageBox.Show("Xin vui lòng nhập dữ liệu từng người cho các loại phép này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        Me.methodLoad()
    '                        Exit Sub
    '                    End If
    '                    ''============== kiem tra ngay chu nhat : P,R
    '                    'If KiemtraNgayCN(tungay, denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
    '                    '    MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    '    Exit Sub
    '                    'Else
    '                    If KiemtraNgayCN(tungay, denngay) = False And
    '                           (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then

    '                        MessageBox.Show("Đây là ngày Chủ nhật. Vẫn tiếp tục lưu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Else
    '                        ''' cap nhat phep theo don vi loai phep khac TS,ST,DS
    '                        ''===================NGUOI CAP NHAT: TRAN
    '                        ''===================NGAY CAP NHAT: 21-01-2014
    '                        ''===================NOI DUNG: KIEM TRA PHEP LONG NHAU THI BO QUA

    '                        Me.txtManv_p.Text = MaNV
    '                        ''cap nhat cot ngay nhap phep
    '                        Me.NgayHT()
    '                        obj.NGAYNHAP = Me.NgayHienTai
    '                        obj.ChonBang = 11
    '                        obj.DonVi = Me.cbDonvi.Value
    '                        TableDV = Me.b.LoadDS(obj)
    '                        Me.chkXinConNuoi.Checked = False 'nhập phép đơn vị thì k cho nhập phép TS ,xin con nuôi
    '                        While i < TableDV.Rows.Count  '' TONG SO TRONG DON VI
    '                            obj.TuNgay = tungay
    '                            obj.DenNgay = denngay
    '                            obj.CONGTYDUYET = Me.chkCongTyDuyet.Checked
    '                            obj.XINCONNUOI = Me.chkXinConNuoi.Checked
    '                            obj.LoaiPhep = Me.cbLoaiphep.Value.ToString()
    '                            obj.MANV = TableDV.Rows(i).Item("NV_MA").ToString()
    '                            obj.GhiChu = Me.txtGhichu.Text
    '                            Dim dlom As DataTable
    '                            ''KIEM TRA PHEP LONG NHAU
    '                            If KiemtraPhepLongNhau(obj.MANV, tungay, denngay, "THEM") Then
    '                                obj.ChonBang = 51
    '                                obj.MANV = Me.txtManv_p.Text.Trim
    '                                obj.TuNgay = tungay
    '                                dlom = Me.b.LoadDS(obj)
    '                                If CInt(dlom.Rows(0).Item(0).ToString) > 30 Then
    '                                    If (MessageBox.Show(("Nhân viên " & obj.MANV & " đã nghỉ OM 30 ngày, bạn có muốn thêm?"), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK) Then
    '                                    Else
    '                                        Me.b.InsertInfo(obj)
    '                                    End If
    '                                Else

    '                                    If CInt(dlom.Rows(0).Item(0).ToString) + (DateDiff("Day", dtpTungay.Value, dtpDenngay.Value) + 1) > 30 Then
    '                                        If (MessageBox.Show(("Nhân viên " & obj.MANV & " đã nghỉ OM " & dlom.Rows(0).Item(0).ToString() & " ngày, nếu bạn nhập phép OM từ ngày " & dtpTungay.Value.ToString("dd-MM-yyyy") & " đến ngày " & dtpDenngay.Value.ToString("dd-MM-yyyy") & " sẽ vượt quá 30 nghỉ OM, bạn có muốn thêm?"), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK) Then
    '                                        Else
    '                                            Me.b.InsertInfo(obj)
    '                                        End If
    '                                    Else
    '                                        Me.b.InsertInfo(obj)
    '                                    End If
    '                                End If
    '                                ''============ them du lieu back up tung so the ==========
    '                                BackupThaoTac(obj.MANV, tungay, denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value.ToString(), Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked, obj, ThemSua, True)
    '                                Me.b.Capnhat(obj)
    '                            End If
    '                            i = i + 1
    '                        End While
    '                        MessageBox.Show("Đã cập nhật dữ liệu thành công cho toàn đơn vị ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        Me.cbDonvi.Value = DonViCu
    '                        methodLoad()
    '                        ThemMoi()
    '                    End If
    '                End If
    '            End If
    '        End If
    '        '=============== NHAP 1 SO THE===============
    '        If Me.txtManv_p.Enabled Then
    '            If Me.txtManv_p.Text = "" Then
    '                MessageBox.Show("Vui lòng nhập vào số thẻ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If
    '            If KiemTraCoNgaySanh(Me.txtManv_p.Text, tungay) Then
    '                MessageBox.Show("Số thẻ này đã nhập ngày sanh, không thể thêm phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If
    '            'If KiemTraNuoiCon12Thang(Me.txtManv_p.Text) Then
    '            'MessageBox.Show("Số thẻ này đang chấm công nuôi con, không thể thêm phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            ' Exit Sub
    '            ' End If
    '            If Me.KiemTra(Me.txtManv_p.Text) = True Then  ''kiem tra thong tin, kiem tra phep long nhau,...
    '                ''============== kiem tra ngay chu nhat ngoai tru: dan quan, duong suc, kthai, thai san, st, tai nan ld, hs ,khhgd
    '                If KiemtraNgayCN(tungay, denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
    '                    MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                Else
    '                    Dim dlim As DataTable
    '                    obj.ChonBang = 51
    '                    obj.MANV = Me.txtManv_p.Text.Trim
    '                    obj.TuNgay = tungay
    '                    dlim = Me.b.LoadDS(obj)
    '                    'MessageBox.Show(CInt(dlim.Rows(0).Item(0).ToString))
    '                    If CInt(dlim.Rows(0).Item(0).ToString) > 30 Then
    '                        If (MessageBox.Show(("Nhân viên " & obj.MANV & " đã nghỉ OM 30 ngày, bạn có muốn thêm?"), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK) Then
    '                        Else
    '                            Me.Luu(Me.txtManv_p.Text.ToString())
    '                        End If
    '                    Else
    '                        If CInt(dlim.Rows(0).Item(0).ToString) + (DateDiff(DateInterval.Day, dtpTungay.Value, dtpDenngay.Value) + 1) > 30 Then
    '                            If (MessageBox.Show(("Nhân viên " & obj.MANV & " đã nghỉ OM " & dlim.Rows(0).Item(0).ToString() & " ngày, nếu bạn nhập phép OM từ ngày " & dtpTungay.Value.ToString("dd-MM-yyyy") & " đến ngày " & dtpDenngay.Value.ToString("dd-MM-yyyy") & " sẽ vượt quá 30 nghỉ OM, bạn có muốn thêm?"), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK) Then
    '                            Else
    '                                Me.Luu(Me.txtManv_p.Text.ToString())
    '                            End If
    '                        Else
    '                            Me.Luu(Me.txtManv_p.Text.ToString())
    '                        End If
    '                    End If
    '                End If
    '            End If
    '            Me.methodLoad()
    '            Me.ThemMoi()
    '            Exit Sub
    '        End If
    '    End If
    '    Me.methodLoad()
    'End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        obj.Setnull()
        ThemSua = 0
        Dim i As Integer = 0
        Dim tngay As Date = Me.dtpTungay.Value
        Dim tungay As String = tngay.Year.ToString() + "-" + tngay.Month.ToString() + "-" + tngay.Day.ToString()
        Dim dngay As Date = Me.dtpDenngay.Value
        Dim denngay As String = dngay.Year.ToString() + "-" + dngay.Month.ToString() + "-" + dngay.Day.ToString()
        Dim sDonvi As String
        Dim xaqq As String
        Dim huyenqq As String
        Dim tinhqq As String
        If Me.cbTinhThanhQQ.Text = "" Then
            tinhqq = ""
        Else
            tinhqq = Me.cbTinhThanhQQ.Value.ToString().Trim
        End If
        obj.TTQQ = tinhqq
        If Me.cbQuanHuyenQQ.Text = "" Then
            huyenqq = ""
        Else
            huyenqq = Me.cbQuanHuyenQQ.Value.ToString().Trim
        End If

        obj.QHQQ = huyenqq
        If Me.cbXaQQ.Text = "" Then
            xaqq = ""
        Else
            xaqq = Me.cbXaQQ.Value.ToString().Trim
        End If

        obj.XAQQ = xaqq
        Me.bChonDonViDD = True
        Dim SqlParam As SqlParameter() = {
        New SqlParameter("@MANV", SqlDbType.NVarChar, 50),
        New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50),
        New SqlParameter("@LoaiPhep", SqlDbType.NVarChar, 50),
        New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)
    }

        SqlParam(0).Value = ""
        SqlParam(1).Value = tungay
        SqlParam(2).Value = Me.cbLoaiphep.Value
        SqlParam(3).Value = denngay

        Dim tblKiemtraphep As DataTable

        tblKiemtraphep = Me.b.PhepLongNhau(
        "SP_NHANVIENNGHIPHEP_KIEMTRANGAYNHAP",
        SqlParam
    )
        If tblKiemtraphep.Rows(0).Item(0).ToString <> "OK" Then
            MessageBox.Show(tblKiemtraphep.Rows(0).Item(0).ToString,
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End If

        If dngay < tngay Then

            MessageBox.Show(
            "Ngày kết thúc phải >= ngày bắt đầu.",
            "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

        Else
            If Me.chDonvi.Checked = True Then

                If Me.chkDonvi.Checked Then
                    txtManv_p.Enabled = False
                    If (
                    MessageBox.Show(
                        "Bạn muốn nhập phép: " & Me.cbLoaiphep.Text &
                        " cho toàn đơn vị: " & Me.cbDonvi.Text &
                        " Từ ngày:" &
                        tngay.Day.ToString() + "/" +
                        tngay.Month.ToString() + "/" +
                        tngay.Year.ToString() &
                        " đến ngày:" &
                        dngay.Day.ToString() + "/" +
                        dngay.Month.ToString() + "/" +
                        dngay.Year.ToString() &
                        " đúng không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    ) <> DialogResult.No
                ) Then
                        Dim TableDV As DataTable
                        Dim MaNV As String

                        Me.b = New clsBKiemTraPhepNam
                        If Me.cbDonvi.Value Is Nothing Then

                            MessageBox.Show(
                            "Vui lòng chọn đơn vị",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                            Exit Sub

                        End If
                        obj.DonVi = Me.cbDonvi.Value

                        obj.setvalue(
                        Me.txtManv_p.Text,
                        tungay,
                        denngay,
                        Me.cbDonvi.Value,
                        Me.cbLoaiphep.Value,
                        Me.txtGhichu.Text.ToString(),
                        chkCongTyDuyet.Checked,
                        chkXinConNuoi.Checked
                    )
                        If cbDonvi.Value.ToString() = "" Or
                       obj.TuNgay = "" Or
                       obj.DenNgay = "" Or
                       obj.LoaiPhep = "" Then

                            MessageBox.Show(
                            "Dữ liệu không bỏ trống, vui lòng chọn đầy đủ thông tin",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                            Me.methodLoad()
                            Exit Sub

                        Else

                            DonViCu = obj.DonVi
                            TongSoDonvi(obj.DonVi)

                        End If
                        If obj.LoaiPhep = "TS" Or
                       obj.LoaiPhep = "DS" Or
                       obj.LoaiPhep = "ST" Then

                            MessageBox.Show(
                            "Xin vui lòng nhập dữ liệu từng người cho các loại phép này.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )

                            Me.methodLoad()
                            Exit Sub

                        End If
                        If KiemtraNgayCN(tungay, denngay) = False And
                       (
                           Me.cbLoaiphep.Value.ToUpper() = "P" Or
                           Me.cbLoaiphep.Value.ToUpper() = "R"
                       ) Then

                            MessageBox.Show(
                            "Khoảng thời gian đã chọn có chứa ngày Chủ nhật." &
                            vbCrLf &
                            "Chương trình vẫn tiếp tục lưu.",
                            "Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        End If

                        Me.txtManv_p.Text = MaNV
                        Me.NgayHT()

                        obj.NGAYNHAP = Me.NgayHienTai
                        obj.ChonBang = 11
                        obj.DonVi = Me.cbDonvi.Value

                        TableDV = Me.b.LoadDS(obj)

                        Me.chkXinConNuoi.Checked = False
                        While i < TableDV.Rows.Count

                            obj.TuNgay = tungay
                            obj.DenNgay = denngay

                            obj.CONGTYDUYET = Me.chkCongTyDuyet.Checked
                            obj.XINCONNUOI = Me.chkXinConNuoi.Checked

                            obj.LoaiPhep = Me.cbLoaiphep.Value.ToString()

                            obj.MANV = TableDV.Rows(i).Item("NV_MA").ToString()

                            obj.GhiChu = Me.txtGhichu.Text
                            If KiemtraPhepLongNhau(
                            obj.MANV,
                            tungay,
                            denngay,
                            "THEM"
                        ) Then

                                obj.ChonBang = 51

                                obj.MANV = Me.txtManv_p.Text.Trim

                                obj.TuNgay = tungay

                                Dim dlom As DataTable

                                dlom = Me.b.LoadDS(obj)
                                If CInt(dlom.Rows(0).Item(0).ToString) > 30 Then

                                    If (
                                    MessageBox.Show(
                                        "Nhân viên " & obj.MANV &
                                        " đã nghỉ OM 30 ngày, bạn có muốn thêm?",
                                        "Thông Báo",
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2
                                    ) <> DialogResult.OK
                                ) Then

                                    Else

                                        Me.b.InsertInfo(obj)

                                    End If


                                Else

                                    If CInt(dlom.Rows(0).Item(0).ToString) +
                                   (
                                       DateDiff(
                                           "Day",
                                           dtpTungay.Value,
                                           dtpDenngay.Value
                                       ) + 1
                                   ) > 30 Then


                                        If (
                                        MessageBox.Show(
                                            "Nhân viên " & obj.MANV &
                                            " đã nghỉ OM " &
                                            dlom.Rows(0).Item(0).ToString() &
                                            " ngày, nếu bạn nhập phép OM từ ngày " &
                                            dtpTungay.Value.ToString("dd-MM-yyyy") &
                                            " đến ngày " &
                                            dtpDenngay.Value.ToString("dd-MM-yyyy") &
                                            " sẽ vượt quá 30 nghỉ OM, bạn có muốn thêm?",
                                            "Thông Báo",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2
                                        ) <> DialogResult.OK
                                    ) Then

                                        Else

                                            Me.b.InsertInfo(obj)

                                        End If


                                    Else

                                        Me.b.InsertInfo(obj)

                                    End If

                                End If
                                BackupThaoTac(
                                obj.MANV,
                                tungay,
                                denngay,
                                Me.cbDonvi.Value,
                                Me.cbLoaiphep.Value.ToString(),
                                Me.txtGhichu.Text.ToString(),
                                Me.chkCongTyDuyet.Checked,
                                Me.chkXinConNuoi.Checked,
                                obj,
                                ThemSua,
                                True
                            )
                                Me.b.Capnhat(obj)

                            End If
                            i = i + 1
                        End While
                        MessageBox.Show(
                        "Đã cập nhật dữ liệu thành công cho toàn đơn vị ",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )
                        Me.cbDonvi.Value = DonViCu
                        methodLoad()
                        ThemMoi()
                    End If
                End If
            End If
            If Me.txtManv_p.Enabled Then
                If Me.txtManv_p.Text = "" Then
                    MessageBox.Show(
                    "Vui lòng nhập vào số thẻ.",
                    "Thông Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
                    Exit Sub
                End If
                If KiemTraCoNgaySanh(
                Me.txtManv_p.Text,
                tungay
            ) Then
                    MessageBox.Show(
                    "Số thẻ này đã nhập ngày sanh, không thể thêm phép.",
                    "Thông Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
                    Exit Sub
                End If
                If Me.KiemTra(Me.txtManv_p.Text) = True Then
                    If KiemtraNgayCN(tungay, denngay) = False And
                   (
                       Me.cbLoaiphep.Value.ToUpper() = "P" Or
                       cbLoaiphep.Value.ToUpper() = "R"
                   ) Then

                        MessageBox.Show(
                        "Khoảng thời gian đã chọn có chứa ngày Chủ nhật." &
                        vbCrLf &
                        "Chương trình vẫn tiếp tục lưu.",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    )

                    End If
                    Dim dlim As DataTable

                    obj.ChonBang = 51
                    obj.MANV = Me.txtManv_p.Text.Trim
                    obj.TuNgay = tungay

                    dlim = Me.b.LoadDS(obj)
                    If CInt(dlim.Rows(0).Item(0).ToString) > 30 Then

                        If (
                        MessageBox.Show(
                            "Nhân viên " & obj.MANV &
                            " đã nghỉ OM 30 ngày, bạn có muốn thêm?",
                            "Thông Báo",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2
                        ) = DialogResult.OK
                    ) Then
                            Me.Luu(Me.txtManv_p.Text.ToString())
                        End If
                    Else
                        If CInt(dlim.Rows(0).Item(0).ToString) +
                       (
                           DateDiff(
                               DateInterval.Day,
                               dtpTungay.Value,
                               dtpDenngay.Value
                           ) + 1
                       ) > 30 Then
                            If (
                            MessageBox.Show(
                                "Nhân viên " & obj.MANV &
                                " đã nghỉ OM " &
                                dlim.Rows(0).Item(0).ToString() &
                                " ngày, nếu bạn nhập phép OM từ ngày " &
                                dtpTungay.Value.ToString("dd-MM-yyyy") &
                                " đến ngày " &
                                dtpDenngay.Value.ToString("dd-MM-yyyy") &
                                " sẽ vượt quá 30 nghỉ OM, bạn có muốn thêm?",
                                "Thông Báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2
                            ) = DialogResult.OK
                        ) Then
                                Me.Luu(Me.txtManv_p.Text.ToString())
                            End If
                        Else
                            Me.Luu(Me.txtManv_p.Text.ToString())

                        End If

                    End If

                End If
                Me.methodLoad()
                Me.ThemMoi()
                Exit Sub
            End If
        End If
        Me.methodLoad()
    End Sub

    Private Sub ThemMoi()
        Me.txtManv_p.Clear()
        Me.txtGhichu.Clear()
        Me.chkCongTyDuyet.Checked = False
        Me.chkCongTyDuyet.Enabled = False
        Me.chkXinConNuoi.Checked = False
        Me.chkXinConNuoi.Enabled = False
        If Me.cbLoaiphep.Items.Count > 0 Then
            Me.cbLoaiphep.SelectedIndex = 0
            Me.cbLoaiphep.Select()
        End If
        If cbLoaiphep.Value = "P" Then
            chkCongTyDuyet.Enabled = True
            chkCongTyDuyet.Checked = False
        Else
            chkCongTyDuyet.Enabled = False
            chkCongTyDuyet.Checked = False
        End If
        If cbLoaiphep.Value = "TS" Then
            chkXinConNuoi.Enabled = True
            chkXinConNuoi.Checked = False
        Else
            chkXinConNuoi.Enabled = False
            chkXinConNuoi.Checked = False
        End If
        Me.dtpTungay.Value = Now
        Me.dtpDenngay.Value = Now
        Me.dtpTungay.Enabled = True
        Me.txtManv_p.Focus()
        Me.btnThem.Enabled = True
    End Sub
    Private Sub XoaDieuKhien()
        Me.txtManvTab2.Clear()
        Me.txtHotenTab2.Clear()
        Me.cboDonviTab2.Text = ""
        txtDonviCuTab2.Clear()
        Me.cboNamTab2.SelectedIndex = 0
        Me.cboNamTab2.Text = Now().Year.ToString()

        Me.txtNgayvaoTab2.Clear()
        Me.txtSongaynghiOMTab2.Clear()
        Me.txtDaNghiTTTab2_OM.Clear()
        Me.lblGhichu.Visible = False
        Me.lblGhichu.Text = ""
        Me.chkNNDH.Checked = False
        Me.txtCVHT.Clear()
    End Sub
    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        '======== Khoi tao gia tri ban dau ===============================
        ThemSua = 2
        bChonDonViDD = True
        Dim tableP As DataTable
        obj.Setnull()
        Try
            Dim TuNgayD, DenNgayD, tngay, dngay, tungayluoi As Date
            Dim tungayl, ngaybd_luoi As String, denngayl, ghichul, donvil, tungaydtp, denngaydtp, loaiphepl, congtyduyetl, xinconnuoil As String
            Me.b = New clsBKiemTraPhepNam

            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                '1========Neu chi co mot dong duoc chon va nut toan don vi/taon cty khong chon ===============================
                If (Me.dgrBC.Selected.Rows.Count = 1) AndAlso Me.chkDonvi.Checked = False Then

                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        obj.MANV = StringType.FromObject(activeRow.Cells.Item("NV_MA").Value)
                        TuNgayD = StringType.FromObject(activeRow.Cells.Item("NP_TuNgay").Value)
                        obj.TuNgay = TuNgayD.Year.ToString() + "/" + TuNgayD.Month.ToString() + "/" + TuNgayD.Day.ToString()
                        obj.LoaiPhep = StringType.FromObject(activeRow.Cells.Item("NP_MA").Value)
                        DenNgayD = StringType.FromObject(activeRow.Cells.Item("NP_DenNgay").Value)
                        obj.DenNgay = DenNgayD.Year.ToString() + "/" + DenNgayD.Month.ToString() + "/" + DenNgayD.Day.ToString()
                        obj.CONGTYDUYET = StringType.FromObject(activeRow.Cells.Item("NP_CONGTYDUYET").Value)
                        obj.XINCONNUOI = StringType.FromObject(activeRow.Cells.Item("NP_XINCONNUOI").Value)
                        '' ------------------ lay gia tri cu dong dang active ------------
                        tungayl = activeRow.Cells.Item("NP_TuNgay").Value.ToString()
                        denngayl = activeRow.Cells.Item("NP_DenNgay").Value.ToString()
                        ghichul = activeRow.Cells.Item("NP_GhiChu").Value.ToString()
                        donvil = activeRow.Cells.Item("DV_MA").Value.ToString()
                        loaiphepl = activeRow.Cells.Item("NP_MA").Value.ToString()
                        congtyduyetl = activeRow.Cells.Item("NP_CONGTYDUYET").Value.ToString()
                        xinconnuoil = activeRow.Cells.Item("NP_XINCONNUOI").Value.ToString()
                        obj.setbackvalue(obj.MANV, tungayl, denngayl, donvil, obj.LoaiPhep, ghichul, obj.CONGTYDUYET, obj.XINCONNUOI)
                        ''=========== 17-09-2013 ====== ''
                        tungayluoi = Convert.ToDateTime(Me.dgrBC.ActiveRow.Cells("NP_TUNGAY").Value)
                        ngaybd_luoi = tungayluoi.Year.ToString() + "-" + tungayluoi.Month.ToString() + "-" + tungayluoi.Day.ToString()

                        '' ---------------------------
                        Me.HieuChinh()
                        If Me.b.IsDeleteOK(obj) Then
                            If obj.LoaiPhep = "TS" Then
                                ''kiem tra co dang nuoi con nho khong: neu co thi khong cho xoa
                                ' If (MessageBox.Show("Bạn có muốn xoá dòng được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                'If KiemTraNuoiCon12Thang(Me.txtManv_p.Text) Then
                                '    MessageBox.Show("Số thẻ này đang chấm công nuôi con, không thể xóa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '    Exit Sub
                                'Else
                                If KiemTraCoNgaySanh(Me.txtManv_p.Text, ngaybd_luoi) Then
                                    MessageBox.Show("Số thẻ này đã nhập ngày sanh, không thể xóa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                Else
                                    Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
                                    SqlParam(0).Value = obj.MANV
                                    SqlParam(1).Value = obj.TuNgay
                                    SqlParam(2).Value = obj.DenNgay
                                    Dim tblXoaPhep As DataTable
                                    tblXoaPhep = Me.b.XoaPhep("SP_NHANVIENNGHIPHEP_XOA_TS", SqlParam)
                                    If tblXoaPhep.Rows(0).Item(0).ToString = "OK" Then
                                        MessageBox.Show("Xóa thành công nhân viên " & obj.MANV & " ngày nghỉ phép " & TuNgayD.Day.ToString() + "/" + TuNgayD.Month.ToString() + "/" + TuNgayD.Year.ToString() & "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        BackupThaoTac(obj.MANV, tungayl, denngayl, donvil, loaiphepl, ghichul, congtyduyetl, xinconnuoil, obj, ThemSua, False)
                                    Else
                                        MessageBox.Show("" & tblXoaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                    End If
                                    GoTo Label_0274


                                End If
                                ' End If
                            Else ''xoa doi voi phep binh thuong
                                'If (MessageBox.Show("Bạn có muốn xoá dòng được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then

                                Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
                                SqlParam(0).Value = obj.MANV
                                SqlParam(1).Value = obj.TuNgay
                                SqlParam(2).Value = obj.DenNgay
                                Dim tblXoaPhep As DataTable
                                tblXoaPhep = Me.b.XoaPhep("SP_NHANVIENNGHIPHEP_XOA ", SqlParam)
                                If tblXoaPhep.Rows(0).Item(0).ToString = "OK" Then
                                    MessageBox.Show("Xóa thành công nhân viên " & obj.MANV & " ngày nghỉ phép " & TuNgayD.Day.ToString() + "/" + TuNgayD.Month.ToString() + "/" + TuNgayD.Year.ToString() & "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    BackupThaoTac(obj.MANV, tungayl, denngayl, donvil, loaiphepl, ghichul, congtyduyetl, xinconnuoil, obj, ThemSua, False)
                                Else
                                    MessageBox.Show("" & tblXoaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                End If
                                GoTo Label_0274
                            End If
                            'End If
                            GoTo Label_0274
                        Else
                            MessageBox.Show("Thao tác xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                    Else ''khong chon dong nao ma an nut xoa
                        MessageBox.Show("Không thể xoá nhân viên " + obj.MANV + " ở Nghỉ phép Từ Ngày là : " + obj.TuNgay + " .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    ''' ============= xoa phep ca don vi ===============
                    ''ngay cap nhat: 11/07/2013
                    ''nguoi cap nhat: Tran
                    '' hieu chinh: Neu chon don vi thi lay phep tai dong active
                    If Me.chkDonvi.Checked Then
                        If Me.cbLoaiphep.Value.ToString() = "" Then
                            MessageBox.Show("Vui lòng chọn loại phép cần xóa cho đơn vị.", "Thông báo", MessageBoxButtons.OK)
                            Exit Sub
                        End If
                        If Me.cbLoaiphep.Value.ToString() = "TS" Then
                            MessageBox.Show("Không được phép xóa toàn đơn vị loại phép là Thai Sản.", "Thông báo", MessageBoxButtons.OK)
                            Exit Sub
                        End If
                        Dim ngay, MANV, MaPhep, GhiChu, CongTyDuyet, ngaybd, ngaykt, xinconnuoi As String
                        Dim i As Integer
                        obj.LoaiPhep = StringType.FromObject(activeRow.Cells.Item("NP_MA").Value)
                        obj.CONGTYDUYET = StringType.FromObject(activeRow.Cells.Item("NP_CONGTYDUYET").Value)
                        TuNgayD = StringType.FromObject(activeRow.Cells.Item("NP_TuNgay").Value)
                        obj.TuNgay = TuNgayD.Year.ToString() + "/" + TuNgayD.Month.ToString() + "/" + TuNgayD.Day.ToString()
                        DenNgayD = StringType.FromObject(activeRow.Cells.Item("NP_DenNgay").Value)
                        obj.DenNgay = DenNgayD.Year.ToString() + "/" + DenNgayD.Month.ToString() + "/" + DenNgayD.Day.ToString()
                        ngay = TuNgayD.Day.ToString() + "/" + TuNgayD.Month.ToString() + "/" + TuNgayD.Year.ToString()
                        If obj.LoaiPhep.ToString <> "TS" Then
                            If (MessageBox.Show("Bạn muốn xoá phép: " & obj.LoaiPhep & " của đơn vị:" & Me.cbDonvi.Value.ToString() & " từ ngày: " & ngay.ToString() & " đến ngày: " & DenNgayD.Day.ToString() + "/" + DenNgayD.Month.ToString() + "/" + DenNgayD.Year.ToString() & " đúng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                obj.ChonBang = 23
                                obj.DonVi = Me.cbDonvi.Value
                                tableP = Me.b.LoadDS(obj)

                                If tableP.Rows.Count > 0 Then

                                    Dim SqlParam As SqlParameter() = {New SqlParameter("@LoaiPhep", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                                        New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
                                    SqlParam(0).Value = obj.LoaiPhep
                                    SqlParam(1).Value = obj.TuNgay
                                    SqlParam(2).Value = obj.DonVi
                                    SqlParam(3).Value = obj.DenNgay


                                    Dim tblXoaPhepToanDV As DataTable
                                    tblXoaPhepToanDV = Me.b.XoaPhep("SP_NHANVIENNGHIPHEP_XOA_TOANDV ", SqlParam)

                                    If tblXoaPhepToanDV.Rows(0).Item(0).ToString = "OK" Then
                                        For i = 0 To tableP.Rows.Count - 1
                                            MANV = tableP.Rows(i).Item("NV_MA").ToString()
                                            ngaybd = tableP.Rows(i).Item("NP_TuNgay").ToString()
                                            ngaykt = tableP.Rows(i).Item("NP_DenNgay").ToString()
                                            MaPhep = tableP.Rows(i).Item("NP_MA").ToString()
                                            CongTyDuyet = tableP.Rows(i).Item("NP_CONGTYDUYET").ToString()
                                            xinconnuoi = tableP.Rows(i).Item("NP_XINCONNUOI").ToString()
                                            GhiChu = tableP.Rows(i).Item("NP_GHICHU").ToString()

                                            BackupThaoTac(MANV, ngaybd, ngaykt, Me.cbDonvi.Value.ToString(), MaPhep, GhiChu, CongTyDuyet, xinconnuoi, obj, ThemSua, False)
                                        Next
                                        MessageBox.Show("Xóa phép đơn vị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        GoTo Label_0274
                                    Else
                                        MessageBox.Show("" & tblXoaPhepToanDV.Rows(0).Item(0).ToString & ". Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    End If
                                End If
                            Else
                                Me.methodLoad()
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Không được phép xóa toàn đơn vị loại phép là Thai Sản.", "Thông báo", MessageBoxButtons.OK)
                            Me.methodLoad()
                            Exit Sub
                        End If

                    End If
                End If
                ''ko cho xoa nhieu dong nua ma cho xoa don vi

            End If
Label_0274:
            LayThongTin()
            Me.methodLoad()
            Me.txtManv_p.Clear()
            Me.txtGhichu.Clear()
            Me.dtpTungay.Value = Now()
            Me.dtpDenngay.Value = Now()
            txtManv_p.Focus()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub Luu(ByVal MaNV As String)
        Dim Table, TableTemp As DataTable
        obj.Setnull()
        Dim Tungay As String = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim Denngay As String = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()
        Dim DonVi As String
        Dim tungaycu_roll As String
        Me.b = New clsBKiemTraPhepNam
        obj.ChonBang = 3 ''load thong tin don vi neu nv thoi viec thi lay dvluong 
        obj.MANV = MaNV ''con lam viec thi lay dvdd, kem theo ngayvao,ngaythoiviec=null
        Table = Me.b.LoadDS(obj)
        DonVi = Table.Rows(0).Item("DV_MA").ToString()

        obj.setvalue(MaNV, Tungay, Denngay, DonVi, Me.cbLoaiphep.Value.ToString(), Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
        ''-------------- khi them lay gia tri setvalue = setbackvalue
        obj.setbackvalue(MaNV, Tungay, Denngay, DonVi, Me.cbLoaiphep.Value.ToString(), Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
        tungaycu_roll = Tungay
        If Me.cbLoaiphep.Value.ToString() = "TS" Then
            Me.LuuDuLieu(obj)
            BackupThaoTac(MaNV, Tungay, Denngay, DonVi, Me.cbLoaiphep.Value.ToString(), Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked, obj, ThemSua, False)
            LuuDuLieuNuoiCon(obj)
            If Me.Flag_NC AndAlso Flag_CapNhat Then
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Flag_CapNhat = False Then
                MessageBox.Show("Không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            TinhSoLanTS(obj.MANV)
            Me.methodLoad()
        Else
            '' luu doi voi phep binh thuong
            Me.LuuDuLieu(obj)
            BackupThaoTac(MaNV, Tungay, Denngay, DonVi, Me.cbLoaiphep.Value.ToString(), Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked, obj, ThemSua, False)

        End If
        ''goi refesh ben kiem tra phep nam
        LayThongTin()
        obj.TuNgay = Tungay
        obj.DenNgay = Denngay
        obj.CONGTYDUYET = Me.chkCongTyDuyet.Checked
        obj.LoaiPhep = Me.cbLoaiphep.Value.ToString()
        Me.NgayHT()
        obj.NGAYNHAP = Me.NgayHienTai
        If ThemSua = 1 Then ''cap nhat lai ngay sua phep
            Me.b.Capnhat(obj)
        End If
    End Sub
    Public Sub LuuDuLieu(ByVal obj As objKiemTraPhepNam)
        Me.b = New clsBKiemTraPhepNam
        Try
            If Me.chkDonvi.Checked = True Then
            Else
            End If

            Me.Flag_CapNhat = Me.b.InsertInfo(obj)
            If Flag_CapNhat Then
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongbaoLoi(exception.Message)
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub BackupThaoTac(ByVal sothe As String, ByVal tungay As String, ByVal denngay As String, ByVal donvi As String, ByVal loaiphep As String, ByVal ghichu As String, ByVal congtyduyet As Boolean, ByVal xinconnuoi As Boolean, ByVal obj_moi As objKiemTraPhepNam, ByVal iThemSua As Integer, ByVal bNhom As Boolean)
        Try
            Dim listpar As New ArrayList(1)
            Dim b As New clsBKiemTraPhepNam
            Dim ngaysanh As String
            Dim tamNC12 As DataTable
            Dim dulieucu As String = "sothe = " & sothe & ",tungay=" & tungay & " ,denngay=" & denngay & " ,donvi=" & donvi & " ,loaiphep=" & loaiphep & " ,ghichu=" & ghichu & " ,congtyduyet=" & congtyduyet & ", xinconnuoi=" & xinconnuoi
            Dim dulieumoi As String = "sothe = " & sothe & ",tungay=" & obj_moi.TuNgay & " ,denngay=" & obj_moi.DenNgay & " ,loaiphep=" & obj_moi.LoaiPhep & " ,ghichu=" & obj_moi.GhiChu & " ,congtyduyet=" & obj_moi.CONGTYDUYET & ", xinconnuoi=" & obj_moi.XINCONNUOI
            Dim chuoithaotac As String = ""
            Me.NgayHT()
            ''============= thao tac tren don vi/cong ty ==============
            listpar.Add(New SqlParameter("@ThoiDiem", Me.obj.Thoigian))

            If bNhom Then
                If iThemSua = 0 Then
                    chuoithaotac = "thao tác nhóm: " & dulieumoi
                End If
            Else
                ''============= trang thai them moi ==============
                If iThemSua = 0 Then
                    chuoithaotac = dulieumoi
                End If
                If iThemSua = 1 Then
                    chuoithaotac = dulieumoi & " ;du lieu cu: " & dulieucu
                End If
                If iThemSua = 2 Then
                    chuoithaotac = dulieucu
                End If
            End If
            listpar.Add(New SqlParameter("@HanhDong", chuoithaotac))
            listpar.Add(New SqlParameter("@GiaTri", iThemSua.ToString()))
            listpar.Add(New SqlParameter("@Ten_DangNhap", d.obj_D.TenDangNhap.ToString()))
            Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
            listpar.Clear()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub BackupThaoTacOM(ByVal sothe As String, ByVal tungay As String, ByVal denngay As String, ByVal donvi As String, ByVal loaiphep As String, ByVal ghichu As String, ByVal congtyduyet As Boolean, ByVal xinconnuoi As Boolean, ByVal obj_moi As objKiemTraPhepNam, ByVal iThemSua As Integer, ByVal bNhom As Boolean, ByVal TINH As String, ByVal QUANHUYEN As String, ByVal XA As String)
        Try
            Dim listpar As New ArrayList(1)
            Dim b As New clsBKiemTraPhepNam
            Dim ngaysanh As String
            Dim tamNC12 As DataTable
            Dim dulieucu As String = "sothe = " & sothe & ",tungay=" & tungay & " ,denngay=" & denngay & " ,donvi=" & donvi & " ,loaiphep=" & loaiphep & " ,ghichu=" & ghichu & " ,congtyduyet=" & congtyduyet & ", xinconnuoi=" & xinconnuoi & ", tinh=" & TINH & ", quanhuyen=" & QUANHUYEN & ", xa=" & XA
            Dim dulieumoi As String = "sothe = " & sothe & ",tungay=" & obj_moi.TuNgay & " ,denngay=" & obj_moi.DenNgay & " ,loaiphep=" & obj_moi.LoaiPhep & " ,ghichu=" & obj_moi.GhiChu & " ,congtyduyet=" & obj_moi.CONGTYDUYET & ", xinconnuoi=" & obj_moi.XINCONNUOI & ", tinh=" & TINH & ", quanhuyen=" & QUANHUYEN & ", xa=" & XA
            Dim chuoithaotac As String = ""
            Me.NgayHT()
            ''============= thao tac tren don vi/cong ty ==============
            listpar.Add(New SqlParameter("@ThoiDiem", Me.obj.Thoigian))

            If bNhom Then
                If iThemSua = 0 Then
                    chuoithaotac = "thao tác nhóm: " & dulieumoi
                End If
            Else
                ''============= trang thai them moi ==============
                If iThemSua = 0 Then
                    chuoithaotac = dulieumoi
                End If
                If iThemSua = 1 Then
                    chuoithaotac = dulieumoi & " ;du lieu cu: " & dulieucu
                End If
                If iThemSua = 2 Then
                    chuoithaotac = dulieucu
                End If
            End If
            listpar.Add(New SqlParameter("@HanhDong", chuoithaotac))
            listpar.Add(New SqlParameter("@GiaTri", iThemSua.ToString()))
            listpar.Add(New SqlParameter("@Ten_DangNhap", d.obj_D.TenDangNhap.ToString()))
            Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
            listpar.Clear()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub LuuDuLieuNuoiCon(ByVal obj As objKiemTraPhepNam)
        Me.b = New clsBKiemTraPhepNam
        Try
            Flag_NC = Me.b.InsertInfoNuoiCon(obj)
            ''TINH SO LAN TS
            TinhSoLanTS(obj.MANV)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongbaoLoi(exception.Message)
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtManv_p.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                If Me.txtManv.Text = "" Then
                    Me.txtManv.Text = Me.txtManv_p.Text
                End If
                If Me.chDonvi.Checked Then
                    If Not activeRow.Cells.Item("DV_MA").Value Is Nothing Then
                        Me.cbDonvi.Value = activeRow.Cells.Item("DV_MA").Value.ToString
                    Else
                        Me.cbDonvi.Value = ""

                    End If
                    Me.btSua.Enabled = False
                    Me.btnXoaNhom.Enabled = True
                Else
                    Me.btSua.Enabled = True
                    Me.btnXoaNhom.Enabled = False
                End If
                Me.dtpTungay.Enabled = False
            End If
            Me.dtpTungay.Text = activeRow.Cells.Item("NP_TuNgay").Value.ToString
            Me.dtpDenngay.Text = activeRow.Cells.Item("NP_DenNgay").Value.ToString
            Me.dtpDenNgaySua.Text = activeRow.Cells.Item("NP_DenNgay").Value.ToString
            Me.cbLoaiphep.Value = activeRow.Cells.Item("NP_Ma").Value.ToString
            Me.chkCongTyDuyet.Checked = activeRow.Cells.Item("NP_CONGTYDUYET").Value.ToString
            Me.chkXinConNuoi.Checked = activeRow.Cells.Item("NP_XINCONNUOI").Value.ToString
            Me.txtGhichu.Text = activeRow.Cells.Item("NP_GhiChu").Value.ToString
            Me.txtNgaynhapphepHT.Text = activeRow.Cells.Item("NP_NGAYNHAPPHEP").Value.ToString
            If Me.cbLoaiphep.Value.ToString().Equals("OM") = True Then
                Me.cbTinhThanhQQ.Text = activeRow.Cells.Item("TT_TEN").Value.ToString
                Me.cbQuanHuyenQQ.Text = activeRow.Cells.Item("QH_TEN").Value.ToString
                Me.cbXaQQ.Text = activeRow.Cells.Item("XP_TEN").Value.ToString
            End If

            Me.btnXoa.Enabled = True
            ' Me.btnThem.Enabled = False
            Dim dv_ma As String = activeRow.Cells.Item("DV_MA").Value.ToString

            If activeRow.Cells.Item("DV_MA").Value.ToString = "BGD" Or activeRow.Cells.Item("DV_MA").Value.ToString = "BGDX" Or dv_ma.Substring(0, 2) = "DT" Then
                Me.btnXoa.Enabled = False

                Me.btSua.Enabled = False
            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Function KiemTra(ByVal MaNV As String) As Boolean
        Dim Table As DataTable
        obj.MANV = MaNV
        Dim ngaytv As String
        Me.b = New clsBKiemTraPhepNam
        If Me.txtManv_p.Text = "" Then
            Exit Function
        End If
        'Kiem tra ma nhan vien: neu nam trong thoi viec thi khong cho them sua xoa phep ===========================
        obj.ChonBang = 3
        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count <= 0 Then
            MessageBox.Show("Mã nhân viên chưa đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End If

        'Kiem tra phep nam nhan vien =====================
        Dim SoNgayCL As Integer
        SoNgayCL = Me.KiemTraPhepNam(MaNV)
        Dim SongayXNghi As Integer
        SongayXNghi = DateDiff(DateInterval.Day, Me.dtpTungay.Value.Date, Me.dtpDenngay.Value.Date) + 1

        If SoNgayCL < SongayXNghi And Me.cbLoaiphep.Value.ToString() = "P" Then
            MessageBox.Show("Nhân viên " + Me.txtManv_p.Text.ToString() + " không còn đủ " + SongayXNghi.ToString() + " ngày phép năm để nghỉ.Chuyển sang bù phép", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        'Kiem tra ngay nay da cho nghi chua ==============
        ''ngay sua: 16/12/2013,21/01/2014
        ''nguoi sua: Tran
        ''noi dung: Kiem tra phep long nhau = thu tuc
        Dim TNgay, DNgay As Date
        Dim tungay, denngay As String
        TNgay = Me.dtpTungay.Value
        DNgay = Me.dtpDenngay.Value
        tungay = TNgay.Year.ToString() + "/" + TNgay.Month.ToString() + "/" + TNgay.Day.ToString()
        denngay = DNgay.Year.ToString() + "/" + DNgay.Month.ToString() + "/" + DNgay.Day.ToString()
        obj.MANV = MaNV
        obj.TuNgay = tungay
        obj.DenNgay = denngay
        If KiemtraPhepLongNhau(MaNV, tungay, denngay, "THEM") = False Then
            MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        Else
            Return True
        End If
    End Function
    Function KiemTraPhepNam(ByVal MaNV As String) As Integer
        Dim Table As DataTable
        Dim pn_ntruoc, pn_nnay, pn_nangnhoc, pn_tren5nam, songaydanghi As Integer
        Dim SongayCL As Integer
        obj.ChonBang = 1
        obj.MANV = MaNV
        obj.NAM = Now().Year.ToString()
        Me.b = New clsBKiemTraPhepNam

        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count > 0 Then
            pn_ntruoc = Val(Table.Rows(0).Item("PN_Songaynamtruoc").ToString())
            pn_nnay = Val(Table.Rows(0).Item("PN_Songaynamnay").ToString())
            pn_nangnhoc = Val(Table.Rows(0).Item("PN_NangnhocDH").ToString())
            pn_tren5nam = Val(Table.Rows(0).Item("PN_PhepTren5Nam").ToString())
        Else
            pn_ntruoc = 0
            pn_nnay = 0
            pn_nangnhoc = 0
            pn_tren5nam = 0
        End If

        obj.ChonBang = 2
        Table = Me.b.LoadDS(obj)
        If Table.Rows.Count > 0 Then
            songaydanghi = Val(Table.Rows(0).Item("SONGAYDANGHI").ToString())
            SongayCL = (pn_ntruoc + pn_nnay + pn_nangnhoc + pn_tren5nam) - songaydanghi
        Else
            songaydanghi = 0
            SongayCL = (pn_ntruoc + pn_nnay + pn_nangnhoc + pn_tren5nam)
        End If

        Return SongayCL
    End Function
    Private Sub dtpTungay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTungay.ValueChanged
        Me.dtpDenngay.Value = Me.dtpTungay.Value
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange ' thay thế sự kiện click để tránh đụng khi check 
        ThemMoi()
        If Me.chkDonvi.Checked Then
            ''lay don vi o luoi len
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            'Dim celllic As UltraGridCell
            'Dim cell As String = celllic.Column.ToString()

            Dim i As Integer
            Dim tableDV As DataTable
            If Not activeRow Is Nothing Then
                If activeRow.Index <> -1 Then
                    If Not Me.dgrBC.ActiveRow.Cells.Item("DV_MA").Value Is Nothing And Me.dgrBC.ActiveRow.Cells.Item("DV_MA").Value.ToString() <> "" Then
                        For i = 0 To Me.cbDonvi.Items.Count - 1
                            If cbDonvi.Items(i).DataValue.ToString() = dgrBC.ActiveRow.Cells.Item("DV_MA").Value.ToString() Then
                                Me.cbDonvi.SelectedIndex = i
                                Me.dtpTungay.Focus()
                                Exit For
                            End If
                        Next
                    Else
                        ''neu don vi la trong o luoi thi tim don vi theo so the
                        obj.ChonBang = 3
                        obj.MANV = Me.dgrBC.ActiveRow.Cells.Item("NV_MA").Value.ToString()
                        tableDV = Me.b.LoadDS(obj)
                        If tableDV.Rows.Count > 0 Then
                            ''neu khong co thoi viec thi chon
                            If lblThongtinthoiviec.Visible = False Then
                                For i = 0 To Me.cbDonvi.Items.Count - 1
                                    If cbDonvi.Items(i).DataValue.ToString() = tableDV.Rows(0).Item("DV_MA").ToString() Then
                                        Me.cbDonvi.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If
        'End If
    End Sub




    'Private Sub dgrBC_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgrBC.CellChange
    '    If (e.Cell.Column.ToString) <> "CHON" Then

    '    Else

    '    End If
    'End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Select Case Me.UltraTabControl1.SelectedTab.Index
            Case 0
                bChonDonViDD = True
                Me.ChonDong()
                Me.HieuChinh()
            Case 1

        End Select

    End Sub
    Private Function KiemTraNuoiCon12Thang(ByVal Manv As String) As Boolean
        Dim b As New clsBKiemTraPhepNam
        Dim tam As DataTable
        NgayHT()
        obj.ChonBang = 17
        obj.MANV = Manv
        obj.NGAYCHAMCONG = Me.NgayCC
        Try
            If b.LoadDS(obj).Rows.Count > 0 Then
                tam = b.LoadDS(obj)
                ''dang cham cong khong the sua doi phep
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi:" & ex.Message(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function
    Private Function KiemTraCoNgaySanh(ByVal Manv As String, ByVal sTungay As String) As Boolean
        Dim b As New clsBKiemTraPhepNam
        Dim tam As DataTable
        NgayHT()
        obj.ChonBang = 21
        obj.MANV = Manv
        obj.TuNgay = sTungay
        Try
            If b.LoadDS(obj).Rows.Count > 0 Then
                tam = b.LoadDS(obj)
                ''da co ngay sanh khong the xoa phep
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi:" & ex.Message(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function
    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        ThemSua = 1
        Dim mesger As String = ""
        ''====================== bat trang thai tim kiem theo don vi dieu dong ===========''
        Me.bChonDonViDD = True

        If Me.chkDonvi.Checked Then
            MessageBox.Show("Không thể sửa phép toàn đơn vị hoặc công ty.", "Thông Báo", MessageBoxButtons.OK)
            Exit Sub
        End If
        ' If MessageBox.Show("Bạn muốn sửa thông tin nghỉ phép của nhân viên đã chọn?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Dim flagCN, xinconnuoicu As Boolean
        Dim phepcu, phepmoi, ghichu_cu, congtyduyetcu As String
        ''========== lay gia tri ngay tren dtppicker
        Dim Tungay As String = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim Denngay As String = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()
        Me.b = New clsBKiemTraPhepNam
        phepcu = Me.dgrBC.ActiveRow.Cells("NP_MA").Value.ToString()
        congtyduyetcu = Me.dgrBC.ActiveRow.Cells("NP_CONGTYDUYET").Value
        xinconnuoicu = Me.dgrBC.ActiveRow.Cells("NP_XINCONNUOI").Value
        'If Me.dgrBC.ActiveRow.Cells("NP_XINCONNUOI").Value <> "" Then
        '    xinconnuoicu = Me.dgrBC.ActiveRow.Cells("NP_XINCONNUOI").Value
        'Else
        '    xinconnuoicu = False
        'End If
        phepmoi = Me.cbLoaiphep.Value.ToString()
        ''------------------- khoi tao cac gia tri ban dau -----------------
        obj.Setnull()
        '' ------------ lay cac gia tri cu tu luoi --------
        Dim tngay, tungayl, ngaybd_luoi As String ''tu ngay lay tu luoi
        Dim dngay, denngayl, dngaysua As String ''den ngay lay tu luoi
        Dim ngaybd, ngaykt, tungayluoi As Date
        ngaybd = Me.dtpTungay.Value
        ngaykt = Me.dtpDenngay.Value
        tngay = ngaybd.Year.ToString() + "-" + ngaybd.Month.ToString() + "-" + ngaybd.Day.ToString()
        dngay = ngaykt.Year.ToString() + "-" + ngaykt.Month.ToString() + "-" + ngaykt.Day.ToString()
        dngaysua = Me.dtpDenNgaySua.Value.Year.ToString() + "/" + Me.dtpDenNgaySua.Value.Month.ToString() + "/" + Me.dtpDenNgaySua.Value.Day.ToString()
        ''------------- lay gia tri cu tai dong active
        tungayl = Me.dgrBC.ActiveRow.Cells("NP_TUNGAY").Value.ToString()
        denngayl = Me.dgrBC.ActiveRow.Cells("NP_DENNGAY").Value.ToString()
        ghichu_cu = Me.dgrBC.ActiveRow.Cells("NP_GHICHU").Value.ToString()


        ''lay dong cu (dang active de sua)
        obj.setbackvalue(Me.dgrBC.ActiveRow.Cells("NV_MA").Value.ToString(), tungayl, denngayl, Me.dgrBC.ActiveRow.Cells("DV_MA").Value.ToString(), Me.dgrBC.ActiveRow.Cells("NP_MA").Value.ToString(), Me.dgrBC.ActiveRow.Cells("NP_GHICHU").Value.ToString(), Me.dgrBC.ActiveRow.Cells("NP_CONGTYDUYET").Value.ToString(), Me.dgrBC.ActiveRow.Cells("NP_XINCONNUOI").Value)
        ''lay dong cu de kiem tra du lieu
        ''=========== 17-09-2013 ====== ''
        tungayluoi = Convert.ToDateTime(Me.dgrBC.ActiveRow.Cells("NP_TUNGAY").Value)
        ngaybd_luoi = tungayluoi.Year.ToString() + "-" + tungayluoi.Month.ToString() + "-" + tungayluoi.Day.ToString()
        ''-------------------- kiem tra du lieu dau vao --------------
        If Me.cbLoaiphep.Text = "" Then
            MessageBox.Show("Bạn đã không chọn loại phép!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Me.dtpTungay.Value.ToString() = "" Then
            MessageBox.Show("Bạn đã không chọn thời gian bắt đầu nghỉ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Me.dtpDenngay.Value.ToString() = "" Then
            MessageBox.Show("Bạn đã không chọn thời gian kết thúc nghỉ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If ngaykt < ngaybd Then
            MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '' thời gian cập nhật k quá 2 tháng, ngày lể
        Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@LoaiPhep", SqlDbType.NVarChar, 50), _
                                                                New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
        SqlParam(0).Value = obj.MANV
        SqlParam(1).Value = Tungay
        SqlParam(2).Value = phepmoi
        SqlParam(3).Value = Denngay
        Dim tblKiemtraphep As DataTable
        tblKiemtraphep = Me.b.PhepLongNhau("SP_NHANVIENNGHIPHEP_KIEMTRANGAYNHAP", SqlParam)
        If tblKiemtraphep.Rows(0).Item(0).ToString <> "OK" Then
            MessageBox.Show(tblKiemtraphep.Rows(0).Item(0).ToString,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
        End If
        ''khong sua phep toan don vi /CTY
        ''----------- tu phep khac --> TS
        If (phepmoi = "TS" And phepmoi <> phepcu) Then
            ''====================== kiem tra bang dl mang thai co khop so dong khong? ====================
            ''------------ neu thoi gian nghi co dag cham cong nuoi con thi khong cho sua
            If KiemTraCoNgaySanh(Me.txtManv_p.Text, ngaybd_luoi) Then
                MessageBox.Show("Số thẻ này đã nhập ngày sanh, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                ' End If
                ' If KiemTraNuoiCon12Thang(Me.txtManv_p.Text) Then
                'MessageBox.Show("Số thẻ này đang chấm công nuôi con, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Exit Sub
            Else
                ''=========== kiem tra phep long nhau ============
                If KiemtraPhepLongNhau(Me.txtManv_p.Text, tngay, dngay, dngaysua) = False Then
                    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else
                    obj.setvalue(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)

                    If Me.b.UpdateInfoNuoiCon(obj) = False Then
                        MessageBox.Show("Thao tác cập nhật thất bại .", "Thông báo")
                        Exit Sub
                    Else
                        Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                             New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                        SqlParam1(0).Value = obj.MANV
                        SqlParam1(1).Value = obj.TuNgay
                        SqlParam1(2).Value = obj.DenNgay
                        SqlParam1(3).Value = obj.DonVi
                        SqlParam1(4).Value = obj.LoaiPhep
                        SqlParam1(5).Value = obj.GhiChu
                        SqlParam1(6).Value = obj.CONGTYDUYET
                        SqlParam1(7).Value = obj.XINCONNUOI
                        Dim tblsuaPhep As DataTable
                        tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                        If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                            mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                            BackupThaoTac(Me.txtManv_p.Text, tungayl, denngayl, Me.cbDonvi.Value, phepcu, ghichu_cu, congtyduyetcu, xinconnuoicu, obj, ThemSua, False)
                            flagCN = True
                        Else
                            mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                            flagCN = False
                        End If
                    End If
                End If

                GoTo LoadDS
            End If
        End If
        ''-------- cap nhat ngay khong thay doi phep (TS)
        If phepmoi = "TS" And phepmoi = phepcu Then
            ''====================== kiem tra bang dl mang thai co khop so dong khong? ====================
            If KiemTraCoNgaySanh(Me.txtManv_p.Text, ngaybd_luoi) Then
                MessageBox.Show("Số thẻ này đã nhập ngày sanh, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                'End If
                'If KiemTraNuoiCon12Thang(Me.txtManv_p.Text) Then
                'MessageBox.Show("Số thẻ này đang chấm công nuôi con, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Exit Sub
            Else
                ''============ truong hop nay khong kiem tra phep long nhau ============
                'If KiemtraPhepLongNhau(Me.txtManv_p.Text, tngay, dngay) = False Then
                '    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                obj.setvalue(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
                'BackupThaoTac(2)
                obj.ChonBang = 7
                If Me.b.UpdateInfoNuoiCon(obj) = False Then
                    MessageBox.Show("Thao tác cập nhật thất bại .", "Thông báo")
                    Exit Sub
                Else
                    Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                            New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                            New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                            New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                            New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                            New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                            New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                          New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                    SqlParam1(0).Value = obj.MANV
                    SqlParam1(1).Value = obj.TuNgay
                    SqlParam1(2).Value = obj.DenNgay
                    SqlParam1(3).Value = obj.DonVi
                    SqlParam1(4).Value = obj.LoaiPhep
                    SqlParam1(5).Value = obj.GhiChu
                    SqlParam1(6).Value = obj.CONGTYDUYET
                    SqlParam1(7).Value = obj.XINCONNUOI
                    Dim tblsuaPhep As DataTable
                    tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                    If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                        mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                        BackupThaoTac(Me.txtManv_p.Text, tungayl, denngayl, Me.cbDonvi.Value, phepcu, ghichu_cu, congtyduyetcu, xinconnuoicu, obj, ThemSua, False)
                        TinhSoLanTS(obj.MANV)
                        flagCN = True
                    Else
                        mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                        flagCN = False
                    End If
                End If
                GoTo LoadDS
            End If
        End If
        ''-------- cap nhat ngay khong thay doi phep (phep khac)
        If phepmoi <> "TS" And phepmoi = phepcu And phepmoi <> "OM" And phepcu <> "OM" Then
            obj.ChonBang = 7
            obj.setvalue(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
            ''============= 21/01/2014 ========== 
            ''=============== kiem tra ngay chu nhat ==============
            If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                ''=============== kiem tra phep long nhau ==============
                If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else
                    Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                               New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                    SqlParam1(0).Value = obj.MANV
                    SqlParam1(1).Value = obj.TuNgay
                    SqlParam1(2).Value = obj.DenNgay
                    SqlParam1(3).Value = obj.DonVi
                    SqlParam1(4).Value = obj.LoaiPhep
                    SqlParam1(5).Value = obj.GhiChu
                    SqlParam1(6).Value = obj.CONGTYDUYET
                    SqlParam1(7).Value = obj.XINCONNUOI
                    Dim tblsuaPhep As DataTable
                    tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                    If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                        mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                        flagCN = True
                    Else
                        mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                        flagCN = False
                    End If
                End If
            End If
            GoTo LoadDS
        End If
        ''---------------------------------begin OM ------------------------------------''
        If phepmoi = "OM" And phepmoi = phepcu Then
            obj.ChonBang = 7
            'MessageBox.Show("Tinh " & Me.cbTinhThanhQQ.Value.ToString & "\nQuan huyen : " & Me.cbQuanHuyenQQ.Value.ToString & "\nXa phuong: " & Me.cbXaQQ.Value.ToString)
            obj.setvalueOM(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked, Me.cbTinhThanhQQ.Value.ToString(), Me.cbQuanHuyenQQ.Value.ToString(), Me.cbXaQQ.Value.ToString())
            ''============= 21/01/2014 ========== 
            ''=============== kiem tra ngay chu nhat ==============
            If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                ''=============== kiem tra phep long nhau ==============
                If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else
                    Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                               New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit), _
                                                               New SqlParameter("@TT_MA", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@QH_MA", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@XP_MA", SqlDbType.NVarChar, 50)}
                    SqlParam1(0).Value = obj.MANV
                    SqlParam1(1).Value = obj.TuNgay
                    SqlParam1(2).Value = obj.DenNgay
                    SqlParam1(3).Value = obj.DonVi
                    SqlParam1(4).Value = obj.LoaiPhep
                    SqlParam1(5).Value = obj.GhiChu
                    SqlParam1(6).Value = obj.CONGTYDUYET
                    SqlParam1(7).Value = obj.XINCONNUOI
                    SqlParam1(8).Value = obj.TTQQ
                    SqlParam1(9).Value = obj.QHQQ
                    SqlParam1(10).Value = obj.XAQQ
                    Dim tblsuaPhep As DataTable
                    tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_3", SqlParam1)
                    If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                        mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                        flagCN = True
                    Else
                        mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                        flagCN = False
                    End If
                End If
            End If
            GoTo LoadDS
        End If

        ''-------------------------Từ phép ốm chuyển sang các phép khác--------------''
        If phepcu = "OM" And phepmoi <> phepcu Then
            obj.ChonBang = 7
            'MessageBox.Show("Tinh " & Me.cbTinhThanhQQ.Value.ToString & "\nQuan huyen : " & Me.cbQuanHuyenQQ.Value.ToString & "\nXa phuong: " & Me.cbXaQQ.Value.ToString)
            obj.setvalueOM2(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
            ''============= 18/01/2020 ========== 
            ''=============== kiem tra ngay chu nhat ==============
            If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                ''=============== kiem tra phep long nhau ==============
                If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else
                    Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                               New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                               New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                    SqlParam1(0).Value = obj.MANV
                    SqlParam1(1).Value = obj.TuNgay
                    SqlParam1(2).Value = obj.DenNgay
                    SqlParam1(3).Value = obj.DonVi
                    SqlParam1(4).Value = obj.LoaiPhep
                    SqlParam1(5).Value = obj.GhiChu
                    SqlParam1(6).Value = obj.CONGTYDUYET
                    SqlParam1(7).Value = obj.XINCONNUOI
                    Dim tblsuaPhep As DataTable
                    tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_4", SqlParam1)
                    If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                        mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                        flagCN = True
                    Else
                        mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                        flagCN = False
                    End If
                End If
            End If
            GoTo LoadDS
        End If
        ''---------------------------------end OM ------------------------------------''


        '' ------ chuyen phep cu dang la TS sang phep loai khac
        If phepmoi <> "TS" And phepmoi <> phepcu And phepmoi <> "OM" And phepcu <> "OM" Then
            ''neu phep cu la TS
            If phepcu = "TS" Then
                If KiemTraCoNgaySanh(Me.txtManv_p.Text, ngaybd_luoi) Then
                    MessageBox.Show("Số thẻ này đã nhập ngày sanh, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                    'End If

                    'If KiemTraNuoiCon12Thang(Me.txtManv_p.Text) Then
                    ' 'MessageBox.Show("Số thẻ này đang chấm công nuôi con, không thể sửa phép.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ' Exit Sub
                Else
                    obj.ChonBang = 16
                    obj.setvalue(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
                    ''kiem tra co dl TS khong, neu co thi xac nhan xoa
                    Dim table As DataTable = Me.b.LoadDS(obj)
                    If table.Rows.Count > 0 Then
                        If MessageBox.Show("Số thẻ này có dữ liệu TS, Xóa dữ liệu TS và cập nhật phép mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                                MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            Else
                                ''=============== kiem tra phep long nhau ==============
                                If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                                    MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Exit Sub
                                Else


                                    If Me.b.DeleteInfoNuoiCon(obj) = False Then
                                        MessageBox.Show("Thao tác cập nhật thất bại .", "Thông báo")
                                        Exit Sub
                                    Else
                                        Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                                  New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                                  New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                                        SqlParam1(0).Value = obj.MANV
                                        SqlParam1(1).Value = obj.TuNgay
                                        SqlParam1(2).Value = obj.DenNgay
                                        SqlParam1(3).Value = obj.DonVi
                                        SqlParam1(4).Value = obj.LoaiPhep
                                        SqlParam1(5).Value = obj.GhiChu
                                        SqlParam1(6).Value = obj.CONGTYDUYET
                                        SqlParam1(7).Value = obj.XINCONNUOI
                                        Dim tblsuaPhep As DataTable
                                        tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                                        If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                                            mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                                            flagCN = True
                                        Else
                                            mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                                            flagCN = False
                                        End If
                                        obj.ChonBang = 7
                                        TinhSoLanTS(obj.MANV)

                                    End If

                                End If
                            End If
                        Else
                            mesger = "Bạn đã hủy xóa dữ liệu Thai Sản"
                            flagCN = False
                        End If
                    Else
                        obj.ChonBang = 7
                        If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                            MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        Else
                            ''=============== kiem tra phep long nhau ==============
                            If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                                MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                Exit Sub
                            Else
                                Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                              New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                                SqlParam1(0).Value = obj.MANV
                                SqlParam1(1).Value = obj.TuNgay
                                SqlParam1(2).Value = obj.DenNgay
                                SqlParam1(3).Value = obj.DonVi
                                SqlParam1(4).Value = obj.LoaiPhep
                                SqlParam1(5).Value = obj.GhiChu
                                SqlParam1(6).Value = obj.CONGTYDUYET
                                SqlParam1(7).Value = obj.XINCONNUOI
                                Dim tblsuaPhep As DataTable
                                tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                                If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                                    mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                                    flagCN = True
                                Else
                                    mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                                    flagCN = False
                                End If
                            End If
                        End If
                    End If
                    GoTo LoadDS
                End If
            Else
                '' phep cu <> TS: chuyen tu phep nay sang phep khac ma cac phep kla TS
                obj.ChonBang = 7
                obj.setvalue(Me.txtManv_p.Text, Tungay, Denngay, Me.cbDonvi.Value, Me.cbLoaiphep.Value, Me.txtGhichu.Text.ToString(), Me.chkCongTyDuyet.Checked, Me.chkXinConNuoi.Checked)
                If KiemtraNgayCN(Tungay, Denngay) = False And (Me.cbLoaiphep.Value.ToUpper() = "P" Or cbLoaiphep.Value.ToUpper() = "R") Then
                    MessageBox.Show("Khoảng thời gian đã chọn có chứa ngày chủ nhật. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    ''=============== kiem tra phep long nhau ==============
                    If KiemtraPhepLongNhau(Me.txtManv_p.Text, Tungay, Denngay, dngaysua) = False Then
                        MessageBox.Show("Nhân viên " + obj.MANV + " đã được nhập phép, vui lòng kiểm tra khoảng thời gian cho nghỉ. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Exit Sub
                    Else
                        Dim SqlParam1 As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@Denngay", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@DonVi", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@NP_MA", SqlDbType.NVarChar, 50), _
                                                              New SqlParameter("@NP_GHICHU", SqlDbType.NVarChar, 500), _
                                                              New SqlParameter("@NP_CONGTYDUYET", SqlDbType.NVarChar, 50), _
                                                             New SqlParameter("@NP_XINCONNUOI", SqlDbType.Bit)}
                        SqlParam1(0).Value = obj.MANV
                        SqlParam1(1).Value = obj.TuNgay
                        SqlParam1(2).Value = obj.DenNgay
                        SqlParam1(3).Value = obj.DonVi
                        SqlParam1(4).Value = obj.LoaiPhep
                        SqlParam1(5).Value = obj.GhiChu
                        SqlParam1(6).Value = obj.CONGTYDUYET
                        SqlParam1(7).Value = obj.XINCONNUOI
                        Dim tblsuaPhep As DataTable
                        tblsuaPhep = Me.b.SuaPhep("SP_NHANVIENNGHIPHEP_SUAMOI_2", SqlParam1)
                        If tblsuaPhep.Rows(0).Item(0).ToString = "OK" Then
                            mesger = "Sửa thành công nhân viên " & obj.MANV & " thành từ ngày : " & ngaybd + " đến: " + ngaykt + ""
                            flagCN = True
                        Else
                            mesger = "" & tblsuaPhep.Rows(0).Item(0).ToString & " Kiểm tra và thực hiện lại."""
                            flagCN = False
                        End If
                    End If
                End If
                GoTo LoadDS
            End If
            'End If
LoadDS:
            If flagCN = True Then
                MessageBox.Show(mesger)
                BackupThaoTac(Me.txtManv_p.Text, tungayl, denngayl, Me.cbDonvi.Value, phepcu, ghichu_cu, congtyduyetcu, xinconnuoicu, obj, ThemSua, False)
                If phepcu = "OM" And phepmoi = "OM" Then
                    BackupThaoTacOM(Me.txtManv_p.Text, tungayl, denngayl, Me.cbDonvi.Value, phepcu, ghichu_cu, congtyduyetcu, xinconnuoicu, obj, ThemSua, False, Me.cbTinhThanhQQ.Value.ToString, Me.cbQuanHuyenQQ.Value.ToString, Me.cbXaQQ.Value.ToString)
                End If
                Me.NgayHT()
                obj.NGAYNHAP = Me.NgayHienTai
                ' Me.b.Capnhat(obj)

                LayThongTin()
                Me.methodLoad()
                Me.txtManv_p.Clear()
                Me.txtGhichu.Clear()
                Me.dtpTungay.Value = Now()
                Me.dtpDenngay.Value = Now()
                cbLoaiphep.Value = "P"
                txtManv_p.Focus()
            Else
                MessageBox.Show(mesger)
            End If
        Else
            '  MessageBox.Show("Bạn đã hủy cập nhật phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub chkDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonvi.CheckedChanged
        ''chon nhap phep cho toan don vi
        Me.dgrBC.DataSource = Nothing
        If Me.chkDonvi.Checked Then
            Me.txtManv_p.Clear()
            Me.txtManv_p.Enabled = False
            Me.chDonvi.Checked = True
            Me.chDonvi.Enabled = True
            Me.chDonvi.Checked = True
            Me.btSua.Enabled = False
            ''lay don vi o luoi len
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            Dim i As Integer
            Dim tableDV As DataTable
            If Not activeRow Is Nothing Then
                If activeRow.Index <> -1 Then
                    HieuChinh()
                    If Not Me.dgrBC.ActiveRow.Cells.Item("DV_MA").Value Is Nothing And Me.dgrBC.ActiveRow.Cells.Item("DV_MA").Value.ToString() <> "" Then
                        For i = 0 To Me.cbDonvi.Items.Count - 1
                            If cbDonvi.Items(i).DataValue.ToString() = dgrBC.ActiveRow.Cells.Item("DV_MA").Value.ToString() Then
                                Me.cbDonvi.SelectedIndex = i
                            End If
                        Next
                    Else
                        ''neu don vi la trong o luoi thi tim don vi theo so the
                        obj.ChonBang = 3
                        obj.MANV = Me.dgrBC.ActiveRow.Cells.Item("NV_MA").Value.ToString()
                        tableDV = Me.b.LoadDS(obj)
                        If tableDV.Rows.Count > 0 Then
                            ''neu khong co thoi viec thi chon
                            If lblThongtinthoiviec.Visible = False Then
                                For i = 0 To Me.cbDonvi.Items.Count - 1
                                    If cbDonvi.Items(i).DataValue.ToString() = tableDV.Rows(0).Item("DV_MA").ToString() Then
                                        Me.cbDonvi.SelectedIndex = i

                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
            ''trang thai them moi cua don vi
            Me.txtGhichu.Clear()
        Else
            Me.cbDonvi.ReadOnly = True
            Me.txtManv_p.Enabled = True
            Me.chDonvi.Checked = False
        End If
    End Sub
    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If Not Me.cbDonvi.Value Is Nothing And Me.chkDonvi.Checked Then
            TongSoDonvi(cbDonvi.Value.ToString())
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        dgrBC.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        With dgrBC.DisplayLayout
            For I As Integer = 1 To .Bands(0).Columns.Count - 1
                dgrBC.DisplayLayout.Bands(0).Columns(I).CellActivation = Activation.NoEdit
            Next

            .Bands(0).Columns("DV_MA").Hidden = True  '' cột này thực tế là cột đơn vị điều động, chỉ lấy để lưu vào csdl
        End With
    End Sub
    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UltraTabControl1.SelectedTabChanged
        Select Case Me.UltraTabControl1.SelectedTab.Index

            Case 0
                ''======= nhap phep ========''
                QuyenTruyCap()
                Me.dgrBC.DataSource = Nothing
                Me.XpCaption2.Text = "Danh sách CB-CNV nghỉ phép"
                Me.btnThem.Enabled = False
                Me.btnXoa.Enabled = False
                Me.btSua.Enabled = False
                Me.ButtonItem2.Visible = False
                Me.ButtonItem2.Enabled = False
            Case 1
                Me.btnThem.Enabled = False
                Me.btnXoa.Enabled = False
                Me.btSua.Enabled = False
                Me.UltraToolbarsManager1.Tools(0).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(1).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(2).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(3).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(4).SharedProps.Visible = False
                Me.UltraToolbarsManager1.Tools(5).SharedProps.Visible = False
                Me.ButtonItem2.Visible = True
                Me.ButtonItem2.Enabled = True
                ''==============================
                Me.dgrBC.DataSource = Nothing
                Me.XoaDieuKhien()
                Me.XpCaption2.Text = "Thông tin nghỉ phép OM-CO"
            Case Else

        End Select
    End Sub
    Private Sub LayThongTinNghiO_CO()
        Dim TableOM, TableCO, TableDV, TableCVDBL As DataTable
        Dim obj As New objKiemTraPhepNam
        Me.b = New clsBKiemTraPhepNam

        obj.ChonBang = 28
        obj.MANV = Me.txtManvTab2.Text.ToString()
        obj.NAMBD = Me.cboNamTab2.Text.ToString()
        '========== phep OM ==========''
        TableOM = Me.b.TongSoNgayPhep(obj, "OM")
        TableCO = Me.b.TongSoNgayPhep(obj, "CO")
        '========== phep CO ==========''
        Me.lblGhichu.Text = ""


        If TableOM.Rows.Count > 0 Then
            Me.txtSongaynghiOMTab2.Text = TableOM.Rows(0).Item("SONGAY").ToString()
        Else
            Me.txtSongaynghiOMTab2.Clear()
        End If

        If TableCO.Rows.Count > 0 Then
            Me.txtSongaynghiCOTab2.Text = TableCO.Rows(0).Item("SONGAY").ToString()
        Else
            Me.txtSongaynghiCOTab2.Clear()
        End If

        'Lay thong tin trong bang st_nhanvien=================
        obj.ChonBang = 29
        TableDV = Me.b.LoadDS(obj)
        If TableDV.Rows.Count > 0 Then
            Me.txtHotenTab2.Text = TableDV.Rows(0).Item("NV_TEN").ToString()
            Me.txtNgayvaoTab2.Text = TableDV.Rows(0).Item("NV_NGAYVAO").ToString()

            ''===============an hien textbox don vi cu ===========
            If TableDV.Rows(0).Item("DV_MA").ToString() = TableDV.Rows(0).Item("DV_MA_").ToString() Then
                Me.lblDonvicu.Visible = False
                Me.txtDonviCuTab2.Visible = False
            Else
                Me.lblDonvicu.Visible = True
                Me.txtDonviCuTab2.Visible = True
            End If
            Me.chkNghiviecTab2.Checked = False
            ''================= xet trang thai dieu dong ============
            If TableDV.Rows(0).Item("IT_DDNGHIVIEC") = True Then
                '' the hien 2 don vi: dv_ma va dv_ma_
                Me.cboDonviTab2.Text = TableDV.Rows(0).Item("DV_MA").ToString()
                Me.txtDonviCuTab2.Text = TableDV.Rows(0).Item("DV_MA_").ToString()
            Else
                Me.cboDonviTab2.Text = TableDV.Rows(0).Item("DV_MA_").ToString()
                Me.txtDonviCuTab2.Text = TableDV.Rows(0).Item("DV_MA").ToString()
            End If
            ''================= trang thai nghi viec ============
            If TableDV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString() <> "" Then
                Me.lblGhichu.Visible = True
                Me.lblGhichu.Text = "Số thẻ: " & Me.txtManvTab2.Text & " thôi việc ngày: " & TableDV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                Me.chkNghiviecTab2.Checked = True
            End If
            ''================= cong viec ngay max cua dbl trong 1 nam ============
            obj.ChonBang = 33
            obj.NAM = Me.cboNamTab2.Text.ToString()
            obj.MANV = Me.txtManvTab2.Text.ToString()
            TableCVDBL = Me.b.LoadDS(obj)
            If TableCVDBL.Rows.Count > 0 Then
                Me.txtCVHT.Text = TableCVDBL.Rows(0).Item("CV_TEN").ToString()
                If Convert.ToBoolean(TableCVDBL.Rows(0).Item("CV_DOCHAI")) Then
                    Me.chkNNDH.Checked = True
                Else
                    Me.chkNNDH.Checked = False
                End If
            Else
                Me.txtCVHT.Text = ""
                Me.chkNNDH.Checked = False
            End If
        Else
            MessageBox.Show("Số thẻ: " & Me.txtManvTab2.Text & " không tìm thấy trong hồ sơ nhân sự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            XoaDieuKhien()
        End If
        If Me.cboNamTab2.Text.ToString() <> "" And Me.txtManvTab2.Text.ToString() <> "" Then
            Me.XpCaption2.Text = " Thông tin nghỉ phép OM-CO của số thẻ: " & Me.txtManvTab2.Text & " năm " & Me.cboNamTab2.Text
            TinhSoNgayPhepO_Co(Me.txtManvTab2.Text.Trim(), Me.cboNamTab2.Text.ToString())
            SoNgayNghiTT_TheoChamCong(txtManvTab2.Text.Trim(), Me.cboNamTab2.Text.ToString())
            Me.methodLoad1()
        End If
    End Sub
    Private Sub CapNhatSoNgayChuNhat(ByVal sNV_Ma As String, ByVal sNam As String, ByVal sLoaiphep As String)
        Dim i As Integer
        Dim tblPhepTrongNam, tblTongPhepOM, tblTongPhepCO As DataTable
        Dim obj As New objKiemTraPhepNam
        Dim b As New clsBKiemTraPhepNam
        Dim sTungay, sDenNgay As String
        Dim dTungay, dDenNgay As Date
        obj.ChonBang = 30
        obj.MANV = sNV_Ma
        obj.NAM = sNam
        obj.LoaiPhep = sLoaiphep
        Dim listpar As New ArrayList(3)

        tblPhepTrongNam = Me.b.TongSoNgayPhep(obj, sLoaiphep)
        If tblPhepTrongNam.Rows.Count > 0 Then
            For i = 0 To tblPhepTrongNam.Rows.Count - 1
                dTungay = tblPhepTrongNam.Rows(i).Item("NP_TUNGAY")
                sTungay = dTungay.Year.ToString() + "/" + dTungay.Month.ToString() + "/" + dTungay.Day.ToString()
                dDenNgay = tblPhepTrongNam.Rows(i).Item("NP_DENNGAY")
                sDenNgay = dDenNgay.Year.ToString() + "/" + dDenNgay.Month.ToString() + "/" + dDenNgay.Day.ToString()

                listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
                listpar.Add(New SqlParameter("@TUNGAY", sTungay))
                listpar.Add(New SqlParameter("@DENNGAY", sDenNgay))
                Me.b.GoiThuTuc("SP_CAPNHATSONGAYCN_OM_CO", listpar)
                listpar.Clear()
            Next
        End If
    End Sub
    Private Sub TinhSoNgayPhepO_Co(ByVal sNV_Ma As String, ByVal sNam As String)
        Dim tblTongPhepOM, tblTongPhepCO As DataTable
        Dim obj As New objKiemTraPhepNam
        Dim b As New clsBKiemTraPhepNam
        Dim listpar As New ArrayList(3)

        CapNhatSoNgayChuNhat(sNV_Ma, sNam, "OM")
        ''======= tinh tong so ngay nghi phep OM =======''
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        listpar.Add(New SqlParameter("@NAM", sNam))
        listpar.Add(New SqlParameter("@LOAIPHEP", "OM"))
        tblTongPhepOM = Me.b.TinhPhepCoOm("SP_TONGSONGAYNGHIPHEPTRONGNAM", listpar)
        listpar.Clear()
        If tblTongPhepOM.Rows.Count > 0 Then
            If CInt(tblTongPhepOM.Rows(0).Item("TONGCONG")) <> 0 Then
                Me.txtSongaynghiOMTab2.Text = CInt(tblTongPhepOM.Rows(0).Item("TONGCONG"))
            Else
                Me.txtSongaynghiOMTab2.Text = ""
            End If

        Else
            Me.txtSongaynghiOMTab2.Text = ""
        End If
        ''======= tinh tong so ngay nghi phep CO =======''
        CapNhatSoNgayChuNhat(sNV_Ma, sNam, "CO")

        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        listpar.Add(New SqlParameter("@NAM", sNam))
        listpar.Add(New SqlParameter("@LOAIPHEP", "CO"))
        tblTongPhepCO = Me.b.TinhPhepCoOm("SP_TONGSONGAYNGHIPHEPTRONGNAM", listpar)
        listpar.Clear()
        If tblTongPhepCO.Rows.Count > 0 Then
            If CInt(tblTongPhepCO.Rows(0).Item("TONGCONG")) <> 0 Then
                Me.txtSongaynghiCOTab2.Text = CInt(tblTongPhepCO.Rows(0).Item("TONGCONG"))
            Else
                Me.txtSongaynghiCOTab2.Text = ""
            End If
        Else
            Me.txtSongaynghiCOTab2.Text = ""
        End If
    End Sub
    Private Sub SoNgayNghiTT_TheoChamCong(ByVal sNV_Ma As String, ByVal sNam As String)
        Dim tblPhepOMTheoCong, tblPhepCOTheoCong As DataTable
        'So ngay nghi thuc te phep OM theo cham cong
        obj.ChonBang = 31
        obj.MANV = sNV_Ma
        obj.NAM = sNam

        tblPhepOMTheoCong = Me.b.TongSoNgayPhep(obj, "OM")
        If tblPhepOMTheoCong.Rows.Count > 0 Then
            Me.txtDaNghiTTTab2_OM.Text = Convert.ToDouble(tblPhepOMTheoCong.Rows(0).Item("TONGCONG"))
        Else
            Me.txtDaNghiTTTab2_OM.Text = ""
        End If
        'So ngay nghi thuc te phep OM theo cham cong
        tblPhepCOTheoCong = Me.b.TongSoNgayPhep(obj, "CO")
        If tblPhepCOTheoCong.Rows.Count > 0 Then
            Me.txtDaNghiTTTab2_CO.Text = Convert.ToDouble(tblPhepCOTheoCong.Rows(0).Item("TONGCONG"))
        Else
            Me.txtDaNghiTTTab2_CO.Text = ""
        End If
    End Sub
    Private Sub txtManvTab2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManvTab2.TextChanged
        If Me.txtManvTab2.Text.Trim.Length = 6 Then
            Me.LayThongTinNghiO_CO()
        End If

    End Sub
    Private Sub cboNamTab2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNamTab2.SelectedIndexChanged
        If Me.txtManvTab2.Text.Trim.Length = 6 Then
            Me.LayThongTinNghiO_CO()
        End If
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub cbLoaiphep_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLoaiphep.ValueChanged
        If cbLoaiphep.Value = "P" Then
            chkCongTyDuyet.Enabled = True
            chkCongTyDuyet.Checked = False
        Else
            chkCongTyDuyet.Enabled = False
            chkCongTyDuyet.Checked = False
        End If
        If cbLoaiphep.Value = "TS" Then
            chkXinConNuoi.Enabled = True
            chkXinConNuoi.Checked = False
        Else
            chkXinConNuoi.Enabled = False
            chkXinConNuoi.Checked = False
        End If

        If cbLoaiphep.Value = "OM" Then
            cbTinhThanhQQ.Visible = True
            cbQuanHuyenQQ.Visible = True
            cbXaQQ.Visible = True
            lbtinh.Visible = True
            lbhuyen.Visible = True
            lbxa.Visible = True
        Else
            cbTinhThanhQQ.Visible = False
            cbQuanHuyenQQ.Visible = False
            cbXaQQ.Visible = False
            lbtinh.Visible = False
            lbhuyen.Visible = False
            lbxa.Visible = False
        End If

    End Sub

    Private Sub chkDonvi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDonvi.Click

    End Sub

    Private Sub chkDonvi_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDonvi.ClientSizeChanged

    End Sub

    Private Sub btnXoaNhom_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaNhom.Activate
        If Me.chkDonvi.Checked And Me.chDonvi.Checked Then
            dgrBC.UpdateData()
            ThemSua = 2
            Dim ts As Integer = 0
            Dim h As Integer = 0
            Dim i As Integer = 0
            Dim manvxoanhom, MaPhepxoanhom, ctyduyetxoanhom, ghichuxoanhom, xinconnuoixoanhom As String
            ' Dim i As Integer
            Dim ngaybdxoanhom, ngayktxoanhom As Date
            While h <= Me.dgrBC.Rows.Count - 1
                If dgrBC.Rows(h).Cells("CHON").Value = True Then
                    ts = ts + 1
                End If
                h = h + 1
            End While
            If ts <= 0 Then
                MessageBox.Show("Vui lòng check chọn ít nhất 1 dòng để xoá nhóm !")
                Exit Sub
            Else
                If (MessageBox.Show(("Bạn có chắc muốn xoá những dòng được chọn không ?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    While i <= Me.dgrBC.Rows.Count - 1
                        If dgrBC.Rows(i).Cells("CHON").Value = True Then

                            manvxoanhom = dgrBC.Rows(i).Cells("NV_MA").Value.ToString
                            MaPhepxoanhom = dgrBC.Rows(i).Cells("NP_Ma").Value.ToString
                            ngaybdxoanhom = StringType.FromObject(dgrBC.Rows(i).Cells("NP_TuNgay").Value)
                            obj.TuNgay = ngaybdxoanhom.Year.ToString() + "/" + ngaybdxoanhom.Month.ToString() + "/" + ngaybdxoanhom.Day.ToString()
                            ngayktxoanhom = StringType.FromObject(dgrBC.Rows(i).Cells("NP_DenNgay").Value)
                            obj.DenNgay = ngayktxoanhom.Year.ToString() + "/" + ngayktxoanhom.Month.ToString() + "/" + ngayktxoanhom.Day.ToString()
                            ctyduyetxoanhom = dgrBC.Rows(i).Cells("NP_CONGTYDUYET").Value
                            xinconnuoixoanhom = dgrBC.Rows(i).Cells("NP_XINCONNUOI").Value
                            ghichuxoanhom = dgrBC.Rows(i).Cells("NP_GhiChu").Value.ToString()

                            ' obj.setbackvalue(manvxoanhom, obj.TuNgay, obj.DenNgay, donvil, obj.LoaiPhep, ghichul, obj.CONGTYDUYET)
                            If MaPhepxoanhom = "TS" Then
                                If KiemTraCoNgaySanh(manvxoanhom, obj.TuNgay) Then ' if có ngày sanh rồi thì k xó dc
                                    'bỏ qua k xó
                                Else 'xoá TS và cập nhật giờ chấm công lại bên vr machine
                                    Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                    New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                    New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
                                    SqlParam(0).Value = manvxoanhom
                                    SqlParam(1).Value = obj.TuNgay
                                    SqlParam(2).Value = obj.DenNgay
                                    Dim tblXoaPhep As DataTable
                                    tblXoaPhep = Me.b.XoaPhep("SP_NHANVIENNGHIPHEP_XOA_TS", SqlParam)
                                    If tblXoaPhep.Rows(0).Item(0).ToString = "OK" Then
                                        BackupThaoTac(manvxoanhom, ngaybdxoanhom.ToString(), ngayktxoanhom.ToString(), Me.cbDonvi.Value.ToString(), MaPhepxoanhom, ghichuxoanhom, ctyduyetxoanhom, xinconnuoixoanhom, obj, ThemSua, False)
                                    End If

                                End If
                            Else 'xoá phép bình thường
                                Dim SqlParam As SqlParameter() = {New SqlParameter("@MANV", SqlDbType.NVarChar, 50), _
                                                                   New SqlParameter("@TuNgay", SqlDbType.NVarChar, 50), _
                                                                   New SqlParameter("@DenNgay", SqlDbType.NVarChar, 50)}
                                SqlParam(0).Value = manvxoanhom
                                SqlParam(1).Value = obj.TuNgay
                                SqlParam(2).Value = obj.DenNgay
                                Dim tblXoaPhep As DataTable
                                tblXoaPhep = Me.b.XoaPhep("SP_NHANVIENNGHIPHEP_XOA ", SqlParam)
                                If tblXoaPhep.Rows(0).Item(0).ToString = "OK" Then
                                    BackupThaoTac(manvxoanhom, ngaybdxoanhom.ToString(), ngayktxoanhom.ToString(), Me.cbDonvi.Value.ToString(), MaPhepxoanhom, ghichuxoanhom, ctyduyetxoanhom, xinconnuoixoanhom, obj, ThemSua, False)
                                End If

                            End If
                            ' BackupThaoTac(manvxoanhom, ngaybdxoanhom, ngayktxoanhom, Me.cbDonvi.Value.ToString(), MaPhepxoanhom, ghichuxoanhom, ctyduyetxoanhom, obj, ThemSua, False)

                        End If
                        i = i + 1
                    End While
                    MessageBox.Show("Đã xoá thành công!")
                End If
            End If
            Me.methodLoad()
            Me.txtManv_p.Clear()
            Me.txtGhichu.Clear()
            Me.dtpTungay.Value = Now()
            Me.dtpDenngay.Value = Now()
            txtManv_p.Focus()
        Else
        End If

    End Sub
    'Private Sub chuyendoingay()
    '    dTuNgay = Date.Parse(Me.dtpTungay.Value)
    '    sTuNgay = dTuNgay.Year.ToString() + "/" + dTuNgay.Month.ToString() + "/" + dTuNgay.Day.ToString()


    'End Sub

    Private Sub txtManvTab2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManvTab2.ValueChanged

    End Sub

    Private Sub cbTinhThanhQQ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTinhThanhQQ.ValueChanged
        'Chon Nganh
        On Error Resume Next
        If Me.cbTinhThanhQQ.Text = "" Then
            Me.cbQuanHuyenQQ.Items.Clear()
            Me.cbQuanHuyenQQ.Text = ""
            Exit Sub
        Else
            obj.ChonBang = 611
            obj.TinhThanh = Me.cbTinhThanhQQ.Value
            obj.ID = Me.cbTinhThanhQQ.Value
            Me.cbQuanHuyenQQ.DataSource = Me.b.LoadDS(obj)
            Me.cbQuanHuyenQQ.DisplayMember() = "QH_TEN"
            Me.cbQuanHuyenQQ.ValueMember() = "QH_MA"
            Me.cbQuanHuyenQQ.Text = ""
            Me.cbQuanHuyenQQ.SelectedIndex = 0
            If Me.cbQuanHuyenQQ.Text <> "" Then
                obj.ChonBang = 612
                obj.TinhThanh = Me.cbTinhThanhQQ.Value
                obj.ID = Me.cbQuanHuyenQQ.Value
                Me.cbXaQQ.DataSource = Me.b.LoadDS(obj)
                Me.cbXaQQ.DisplayMember = "XP_TEN"
                Me.cbXaQQ.ValueMember = "XP_MA"
                Me.cbXaQQ.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cbQuanHuyenQQ_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbQuanHuyenQQ.ValueChanged
        'Chon Nganh
        On Error Resume Next
        If Me.cbQuanHuyenQQ.Text = "" Then
            Me.cbXaQQ.Items.Clear()
            Me.cbXaQQ.Text = ""
            Exit Sub
        Else
            obj.ChonBang = 612
            obj.TinhThanh = Me.cbTinhThanhQQ.Value
            obj.ID = Me.cbQuanHuyenQQ.Value
            Me.cbXaQQ.DataSource = Me.b.LoadDS(obj)
            Me.cbXaQQ.DisplayMember() = "XP_TEN"
            Me.cbXaQQ.ValueMember() = "XP_MA"

            If Me.b.LoadDS(obj).Rows.Count = 0 Then
                Me.cbXaQQ.DataSource = Nothing
                Me.cbXaQQ.Text = ""
            Else
                Me.cbXaQQ.Text = ""
                Me.cbXaQQ.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btbc_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim BinhbauDataTable As New DataTable()
        'Dim ChitietDataTable As New DataTable()
        'Dim DS_Thongkephepom As New DataSet()
        'obj.ChonBang = 71
        'BinhbauDataTable = Me.b.LoadDS(obj)
        'If Not BinhbauDataTable Is Nothing Then
        '    DS_Thongkephepom.Tables.Add(BinhbauDataTable)
        'End If

        'obj.ChonBang = 81
        'ChitietDataTable = Me.b.LoadDS(obj)
        'If Not ChitietDataTable Is Nothing Then
        '    DS_Thongkephepom.Tables.Add(ChitietDataTable)
        'End If

        ' ''=================================================================================================================

        'Dim relBinhbauchitiet As New DataRelation("Thongkephepom", BinhbauDataTable.Columns("NV_MA"), ChitietDataTable.Columns("NV_MA"), False)
        'DS_Thongkephepom.Relations.Add(relBinhbauchitiet)

        '' bind DataSet to UltraGrid
        'Me.dgrBC.DataSource = Nothing
        'Me.dgrBC.DataSource = DS_Thongkephepom

        'Me.reportID = "BBNTAY"
        'Dim strArray As String() = New String() {nam, Donvi}
        'Me.para = strArray
        'Me.issysReport = True
        'Me.Refresh()


        ''======================================
        'Dim report As New FrmReport
        ' ''neu chon tct thi M
        'Dim TuThang As Date = Me.dtpTungay.Value.ToString()
        'Dim TuThangMT As String = TuThang.Month.ToString()
        'Dim TuNamMT As String = TuThang.Year.ToString()
        'Dim ngaydauthang As String = TuNamMT + "-" + TuThangMT + "-" + "01"

        'Dim DenThang As Date = Me.dtpDenthang15h30.Value.ToString()
        'Dim DenThangMT As String = DenThang.Month.ToString()
        'Dim DenNamMT As String = DenThang.Year.ToString()
        'Dim ngaycuoi As String = GetEnday_InMonth(DenThangMT).ToString()
        'Dim ngaycuoithang As String = DenNamMT + "-" + DenThangMT + "-" + ngaycuoi

        ''format string sang date 
        'Dim thangbd As String
        'Dim bd, kt As Date
        'obj.NgayDauThang = ngaydauthang
        'Me.dtpNgay1.Text = obj.NgayDauThang
        'bd = CDate(dtpNgay1.Value)
        'kt = CDate(Me.dtpDenthang15h30.Value)
        'If obj.Xuong = "TCT" Then
        '    report.reportID = "MT0311"
        '    Dim strArray As String() = New String() {"TCT", ngaydauthang, ngaycuoithang, sTenNguoiBaoCao}
        '    report.para = strArray
        'Else
        '    report.reportID = "MT0311"
        '    Dim strArray As String() = New String() {obj.Xuong, ngaydauthang, ngaycuoithang, sTenNguoiBaoCao}
        '    report.para = strArray
        'End If
        'report.issysReport = True
        'report.Show()
    End Sub


    Private Sub ButtonItem2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Activate

        Dim obj As New objKiemTraPhepNam
        Dim report As New FrmReport
        obj.Setnull()
        If Me.UltraTabControl1.ActiveTab.Index = 1 Then

            Dim strNam As String = cbNamThongKe.Text
            If (Not cbNamThongKe.ValueMember Is Nothing) AndAlso cbNamThongKe.Text <> "" Then
                obj.NAM = strNam
                If cbThongKe.SelectedValue = 0 Then
                    report.reportID = "TKOMH"
                    Dim strArray As String() = New String() {obj.NAM}
                    report.para = strArray
                End If
                If cbThongKe.SelectedIndex = 1 Then
                    report.reportID = "TKOMX"
                    Dim strArray As String() = New String() {obj.NAM}
                    report.para = strArray
                End If
                If cbThongKe.SelectedIndex = 2 Then
                    report.reportID = "DSOM"
                    Dim strArray As String() = New String() {obj.NAM}
                    report.para = strArray
                End If
            End If
            report.issysReport = True
            report.Show()
        Else
            MessageBox.Show("Vui lòng chọn tab ""Kiểm tra số ngày phép OM-CO"" để sử dụng chức năng này!", "Cảnh báo")
        End If

        
    End Sub
    Dim Tabletemp As DataTable
    Dim c As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    
    Private Sub UltraTabPageControl3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl3.Paint

    End Sub

    Private Sub rptToKhaiThue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label27.Click

    End Sub

    Private Sub chkCongTyDuyet_CheckedChanged(sender As Object, e As EventArgs) Handles chkCongTyDuyet.CheckedChanged

    End Sub
End Class