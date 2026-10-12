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

Public Class frmPhuNuHanhKinh
    Inherits Form
    Public Shared objPNHK As New ObjPhuNuHanhKinh
    Public ngay As String
    Public bNhomToanbo As Integer = 0
    Dim Path As String
    Dim ReportID As String
    Dim i As Integer = 0
    ''=========== xét phân quyền chức năng khi lưu,chuyển dl hanh kinh ===''
    Public Them As Boolean = False
    Public Sua As Boolean = False
    Public Xoa As Boolean = False
    Public bAdmin As Boolean = False
    Public bQuyenKhuA As Boolean = False
    Public bQuyenKhuB As Boolean = False
    Public bQuyenChuyenDLHK As Boolean = False
    Public bQuyenChuyenDLHKNV As Boolean = False
    Public bClosing As Boolean = False
    Private Function KiemTraTrong() As Boolean
        If Me.dtpNgay.Text.ToString() = "" Or IsDate(Me.dtpNgay.Value) = False Then
            MessageBox.Show("Vui lòng chọn ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            Exit Function
        End If
        If Me.cboDonvi.Text.ToString() = "" And Me.radDV.Checked Then
            MessageBox.Show("Vui lòng chọn đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            Exit Function
        End If
        If Me.txtSothe.Text.ToString() = "" And Me.radSothe.Checked Then
            MessageBox.Show("Vui lòng nhập vào số thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            Exit Function
        End If
        Return False
    End Function
    Private Sub LoadAllCombo()
        Dim b As New clsBPhuNuHanhKinh
        Dim obj As New ObjPhuNuHanhKinh
        Dim thangnamhientai As String
        Me.b = New clsBPhuNuHanhKinh
        Dim tam, tamnv, thang, thangnv As DataTable
        If Now().Month < 10 Then
            thangnamhientai = "0" + Now().Month.ToString() + "/" + Now().Year.ToString()
        Else
            thangnamhientai = Now().Month.ToString() + "/" + Now().Year.ToString()
        End If

        obj.ChonBang = 1
        tam = Me.b.LoadDS(obj)
        'tam.Rows.Add("TCT", "Toàn công ty")
    
        If tam.Rows.Count > 0 Then
            Me.cboDonvi.DataSource = tam
            Me.cboDonvi.ValueMember = "DV_MA"
            Me.cboDonvi.DisplayMember = "DV_TEN"
            Me.cboDonvi.SelectedIndex = 0
        End If

        obj.ChonBang = 2
        tamnv = Me.b.LoadDS(obj)
        If tamnv.Rows.Count > 0 Then
            Me.cboDonviNV.DataSource = tamnv
            Me.cboDonviNV.ValueMember = "DV_MA"
            Me.cboDonviNV.DisplayMember = "DV_TEN"
            Me.cboDonviNV.SelectedIndex = 0
        End If
        cboDonviNV.DropDownStyle = DropDownStyle.DropDownList
        ''===========================
        thang = Me.b.LoadDanhmucThang("SP_ST_THANG_CHUYENDULIEU_S")
        If thang.Rows.Count > 0 Then
            Me.dtpThang.DataSource = thang
            'Me.dtpThang.SelectedIndex = 3
            For i = 0 To Me.dtpThang.Items.Count - 1
                If dtpThang.Items(i).DataValue.ToString() = thangnamhientai Then
                    Me.dtpThang.SelectedIndex = i
                    Me.dtpThang.Focus()
                    Exit For
                End If
            Next
           
        End If

        thangnv = Me.b.LoadDanhmucThang("SP_ST_THANG_CHUYENDULIEUNGHIVIEC_S")
        If thangnv.Rows.Count > 0 Then
            Me.dtpThangNV.DataSource = thangnv
            For i = 0 To Me.dtpThangNV.Items.Count - 1
                If dtpThangNV.Items(i).DataValue.ToString() = thangnamhientai Then
                    Me.dtpThangNV.SelectedIndex = i
                    Me.dtpThangNV.Focus()
                    Exit For
                End If
            Next

        End If


       
    End Sub
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub ChonDongCu()
        If Me.dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        End If

    End Sub
    Dim oldRow As Integer = 0
    Private Sub methodLoad()
        Dim listpar As New ArrayList(2)
        Dim temp As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Me.Path = "/layout/PhuNuHanhKinh.xml"
        objPNHK.Setnull()
        Me.btnLuu.Enabled = True
        Me.btnXoanhom.Enabled = True

        If Me.dtpNgay.Text <> "" And IsDate(Me.dtpNgay.Value) Then
            ngay = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Day.ToString()
        Else
            Exit Sub
        End If
        If Me.cboDonvi.Value <> "" And Me.radDV.Checked Then
            objPNHK.Donvi = Me.cboDonvi.Value
        End If

        If Me.txtSothe.Text.Trim() <> "" And Me.radSothe.Checked Then
            objPNHK.NV_MA = Me.txtSothe.Text.Trim()
        End If

        objPNHK.NgayNghiHanhKinh = ngay
        listpar.Add(New SqlParameter("@Ngay", objPNHK.NgayNghiHanhKinh))
        If Me.radSothe.Checked Then
            listpar.Add(New SqlParameter("@NV_MA", objPNHK.NV_MA))
            temp = Me.b.LoadDSNghiHanhKinh("SP_DSNGHIHANHKINH_SOTHE_S", listpar)
        ElseIf Me.radDV.Checked Then
            listpar.Add(New SqlParameter("@DV_MA", objPNHK.Donvi))
            temp = Me.b.LoadDSNghiHanhKinh("SP_DSNGHIHANHKINH_DONVI_S", listpar)
        Else
            temp = Nothing
        End If
        listpar.Clear()
        ''=============
        Me.dgrBC.DataSource = temp
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        If temp.Rows.Count > 0 Then
            QuyenTruyCap()
        Else
            Me.btnLuu.Visible = False
            Me.btnXoanhom.Visible = False
        End If
        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(4)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing

    End Sub
    Private Function KiemTraSoThe_DaNghi(ByVal sNV_Ma As String, ByVal sNgay As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@Ngay", sNgay))
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_SOTHENGHIHANHKINH_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''============ SỐ THẺ CÓ THÁNG MANG THAI NẰM TRONG THÁNG NẰM NGHỈ H.KINH CHƯA PHÁT SINH PHÉP SẢY THAI ==========''
    Private Function KiemTraSoThe_DangMangThai(ByVal sNV_Ma As String, ByVal sNgay As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@Ngay", sNgay))
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_SOTHEMANGTHAI_NGHIHANHKINH_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        Else
            If Convert.ToBoolean(tblTemp.Rows(0).Item("DANGMANGTHAI")) = False Then
                Return False
            Else
                Return True
            End If
        End If
    End Function
    Private Function KiemTraSoThe_DangNghiTS_DangNghiST(ByVal sNV_Ma As String, ByVal sNgay As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@Ngay", sNgay))
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_SOTHE_THAISAN_SAYTHAI_NGHIHANHKINH_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function KiemTraSoThe_DaTinhNghiHanhKinh(ByVal sNV_Ma As String, ByVal sNgay As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@Ngay", sNgay))
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_SOTHENGHIHANHKINH_DATINHGIO_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function KiemTraSoThe_DaNghiDuGioTrongThang(ByVal sNV_Ma As String, ByVal sNgay As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@Ngay", sNgay))
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_SOTHENGHIHANHKINH_DUGIO", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        ElseIf CDbl(tblTemp.Rows(0).Item("SOGIO")) < 1.5 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function KiemTraThangDaTinhGioNghiHanhKinh(ByVal sT_Ma As String)
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@T_MA", sT_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_DANHSACHNGHIHANHKINH_DATINHGIO_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        Else
            ''====== đã insert vào bảng IT_SOGIONGHIHANHKINH ==========
            Return True
        End If
    End Function
    Private Function KiemTraThangDaTinhGioNghiHanhKinhNV(ByVal sT_Ma As String, ByVal sDV_Ma As String) As DataTable
        Dim listpar As New ArrayList(2)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@T_MA", sT_Ma))
        listpar.Add(New SqlParameter("@DV_MA", sDV_Ma))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRA_DANHSACHNGHIHANHKINHNV_DATINHGIO_S", listpar)
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return Nothing
        Else
            ''====== đã insert vào bảng IT_SOGIONGHIHANHKINH ==========
            Return tblTemp
        End If
    End Function
    Private Function KiemTraNgayCuoiThangChuyenDuLieu(ByVal sNgay As String)
        Dim listpar As New ArrayList(1)
        Me.b = New clsBPhuNuHanhKinh
        Dim tblTemp As DataTable
        listpar.Add(New SqlParameter("@THANGCHUYENDULIEU", sNgay))
        tblTemp = Me.b.LoadDSNghiHanhKinh("SP_KIEMTRANGAYCUOITHANG_S", listpar)
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            Return False
        ElseIf Convert.ToBoolean(tblTemp.Rows(0).Item("CAPNHAT")) = False Then
            Return False
        Else
            Return True ''---- CUỐI THÁNG HOẶC 1 TÂY THÁNG SAU
        End If
    End Function
    Friend WithEvents b As clsBPhuNuHanhKinh

    Private Sub frmPhuNuHanhKinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radDV.Checked = True
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        'Me.dtpThang.CustomFormat = "MM/yyyy"
        LoadAllCombo()
        XetPhanQuyen()
        methodLoad()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        'e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
      

        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0
                e.Layout.Bands(0).Columns("2").CellAppearance.Image = 2
                Dim i As Integer
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    If i <> 0 Then
                        e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
                    End If
                Next i
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAY").Format = "dd/MM/yyyy"

            Case 1
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
                Next i
            Case 2
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
                Next i
        End Select

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Dim T_MA As String = ""
        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0
                Me.b = New clsBPhuNuHanhKinh
                i = 0
                objPNHK.Setnull()
                If KiemTraTrong() = False Then
                    ngay = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Day.ToString()
                    ' T_MA = CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString()
                    If CDate(Me.dtpNgay.Value).Month < 10 Then
                        T_MA = "0" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString()
                    Else

                        T_MA = CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString()
                    End If
                    'If KiemTraThangDaTinhGioNghiHanhKinh(Me.dtpThang.Text) = False Then
                    If KiemTraThangDaTinhGioNghiHanhKinh(T_MA) = False Then
                        ''========= thêm số thẻ ===========
                        If Me.radSothe.Checked Then
                            If (MessageBox.Show("Bạn muốn lưu số thẻ: " & Me.txtSothe.Text & " nghỉ hành kinh ngày: " & Me.dtpNgay.Text & " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                objPNHK.setvalue(Me.txtSothe.Text.Trim(), ngay)
                                If KiemTraSoThe_DaNghiDuGioTrongThang(Me.txtSothe.Text.Trim(), ngay) = False Then
                                    ''======= chưa nghỉ đủ 1.5 giờ  =============
                                    If KiemTraSoThe_DaNghi(Me.txtSothe.Text.Trim(), ngay) = False Then ''===== khóa chính
                                        ''======== kiểm mang thai- say thai - thai san ======''
                                        If KiemTraSoThe_DangNghiTS_DangNghiST(Me.txtSothe.Text.Trim(), ngay) = False And KiemTraSoThe_DangMangThai(Me.txtSothe.Text.Trim(), ngay) = False Then
                                            If Me.b.InsertInfo(objPNHK) Then
                                                MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Else
                                                MessageBox.Show("Không thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("Số thẻ " & Me.txtSothe.Text & " đang trong thời gian nghỉ thai sản- sảy thai hoặc đang mang thai tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Me.txtSothe.Clear()
                                            Me.txtSothe.Focus()
                                            Exit Sub
                                        End If
                                    Else
                                        MessageBox.Show("Số thẻ " & Me.txtSothe.Text & " đã nằm nghỉ ngày: " & Me.dtpNgay.Text & " bạn không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.txtSothe.Clear()
                                        Me.txtSothe.Focus()
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Số thẻ " & Me.txtSothe.Text & " đã nghỉ đủ 1.5h trong tháng: " & CDate(Me.dtpNgay.Value).Month.ToString() & " bạn không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Me.txtSothe.Clear()
                                    Me.txtSothe.Focus()
                                    Exit Sub
                                End If
                            Else
                                Exit Sub
                            End If
                        End If
                    Else
                        MessageBox.Show("Tháng này đã được cập nhật số giờ nghỉ hành kinh, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ''========= thêm nhóm đơn vị ===========
                    If Me.radDV.Checked Then
                        If KiemTraThangDaTinhGioNghiHanhKinh(Me.dtpThang.Text) = False Then
                            If (MessageBox.Show("Bạn muốn lưu các số thẻ đã chọn vào danh sách nghỉ hành kinh ngày: " & Me.dtpNgay.Text & " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                Me.dgrBC.UpdateData()
                                While i <= Me.dgrBC.Rows.Count - 1
                                    If Me.dgrBC.Rows(i).Cells("1").Value = True Then
                                        If KiemTraSoThe_DaNghiDuGioTrongThang(Me.dgrBC.Rows(i).Cells("NV_MA").Text.Trim(), ngay) = False Then
                                            If KiemTraSoThe_DaNghi(Me.dgrBC.Rows(i).Cells("NV_MA").Text.Trim(), ngay) = False And KiemTraSoThe_DangMangThai(Me.dgrBC.Rows(i).Cells("NV_MA").Text.Trim(), ngay) = False Then
                                                ''======== kiểm mang thai- say thai - thai san ======''
                                                If KiemTraSoThe_DangNghiTS_DangNghiST(Me.txtSothe.Text.Trim(), ngay) = False Then
                                                    ''====== chưa có thì thêm; có rồi bỏ qua =======''
                                                    objPNHK.setvalue(Me.dgrBC.Rows(i).Cells("NV_MA").Text.Trim(), ngay)
                                                    Me.b.InsertInfo(objPNHK)
                                                End If
                                            End If
                                            ''======= nghỉ đủ giờ không thêm =============
                                        Else
                                            MessageBox.Show("Danh sách bạn vừa chọn có người đã nghỉ đủ 1.5h, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            methodLoad()
                                            Exit Sub
                                        End If

                                    End If
                                    i = i + 1
                                End While
                                MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Tháng này đã được cập nhật số giờ nghỉ hành kinh, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub

                        End If ''===== end nhập nhóm đơn vị

                    End If
                End If ''==== end kiểm tra trống 
                methodLoad()
            Case 1
        End Select
    End Sub

    Private Sub cboDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDonvi.ValueChanged
        If bClosing = False Then
            Select Case Me.tabTraCuu.SelectedTab.Index
                Case 0

                    methodLoad()
                Case 1
                Case 2
            End Select
        End If
    End Sub
    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0

                methodLoad()

            Case 1
            Case 2
        End Select
    End Sub
    Private Sub XetPhanQuyen()
        objPNHK.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        objPNHK.ChonBang = 3
        Dim TQuyenTruyCap, TUser, TQuyenCapNhatHK, TQuyenCapNhatHKNV As New DataTable
        TUser = Me.b.LoadDS(objPNHK)
        If TUser.Rows.Count > 0 Then
            If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Then ''cac danh muc ko can nhap het cho admin
                Them = True
                Sua = True
                Xoa = True
                bAdmin = True
                bQuyenKhuA = True
                bQuyenKhuB = True
                bQuyenChuyenDLHK = True
                bQuyenChuyenDLHKNV = True
                ''gan mac dinh admin dc xem
                QuyenTruyCap()
            Else
                objPNHK.ChonBang = 4
                TQuyenTruyCap = Me.b.LoadDS(objPNHK)
                If TQuyenTruyCap.Rows.Count > 0 Then
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
                    If IsDBNull(TQuyenTruyCap.Rows(0).Item("KHUA")) = True Then
                        bQuyenKhuA = False
                    ElseIf Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("KHUA")) = True Then
                        bQuyenKhuA = True
                    Else
                        bQuyenKhuA = False
                    End If

                    If IsDBNull(TQuyenTruyCap.Rows(0).Item("KHUB")) = True Then
                        bQuyenKhuB = False
                    ElseIf Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("KHUB")) = True Then
                        bQuyenKhuB = True
                    Else
                        bQuyenKhuB = False
                    End If

                    objPNHK.ChonBang = 5
                    TQuyenCapNhatHK = Me.b.LoadDS(objPNHK)

                    If TQuyenCapNhatHK Is Nothing Then
                        bQuyenChuyenDLHK = False
                    ElseIf TQuyenCapNhatHK.Rows.Count <= 0 Then
                        bQuyenChuyenDLHK = False
                    Else
                        bQuyenChuyenDLHK = True
                    End If

                    objPNHK.ChonBang = 6
                    TQuyenCapNhatHKNV = Me.b.LoadDS(objPNHK)

                    If TQuyenCapNhatHKNV Is Nothing Then
                        bQuyenChuyenDLHKNV = False
                    ElseIf TQuyenCapNhatHKNV.Rows.Count <= 0 Then
                        bQuyenChuyenDLHKNV = False
                    Else
                        bQuyenChuyenDLHKNV = True
                    End If

                    QuyenTruyCap()
                Else
                    Them = False
                    Sua = False
                    Xoa = False
                    bAdmin = False
                    bQuyenKhuA = False
                    bQuyenKhuB = False
                    bQuyenChuyenDLHK = False
                    bQuyenChuyenDLHKNV = False
                    MessageBox.Show("Không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        Else
            Them = False
            Sua = False
            Xoa = False
            bAdmin = False
            bQuyenKhuA = False
            bQuyenKhuB = False
            bQuyenChuyenDLHK = False
            bQuyenChuyenDLHKNV = False
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Public Sub QuyenTruyCap()
        If bAdmin Then
            Select Case Me.tabTraCuu.SelectedTab.Index
                Case 0
                    Me.btnLuu.Visible = True
                    Me.btnXoanhom.Visible = True

                    Me.btnTinhSoGioHK.Visible = False
                    Me.btnXemchitiet.Visible = False

                    Me.btnTinhSoGioHKNV.Visible = False
                    Me.btnXemDSHKNV.Visible = False

                Case 1
                    Me.btnLuu.Visible = False
                    Me.btnXoanhom.Visible = False

                    Me.btnTinhSoGioHK.Visible = True
                    Me.btnXemchitiet.Visible = True

                    Me.btnTinhSoGioHKNV.Visible = False
                    Me.btnXemDSHKNV.Visible = False

                Case 2
                    Me.btnLuu.Visible = False
                    Me.btnXoanhom.Visible = False
                    Me.btnTinhSoGioHK.Visible = False
                    Me.btnXemchitiet.Visible = False
                    Me.btnTinhSoGioHKNV.Visible = True
                    Me.btnXemDSHKNV.Visible = True

            End Select
        Else
            Select Case Me.tabTraCuu.SelectedTab.Index
                Case 0
                    If Them And Sua And Xoa Then
                        Me.btnLuu.Visible = True
                        Me.btnXoanhom.Visible = True
                    Else
                        Me.btnLuu.Visible = False
                        Me.btnXoanhom.Visible = False
                    End If
                    Me.btnTinhSoGioHK.Visible = False
                    Me.btnXemchitiet.Visible = False
                    Me.btnTinhSoGioHKNV.Visible = False
                    Me.btnXemDSHKNV.Visible = False

                Case 1
                    If bQuyenChuyenDLHK Then
                        btnTinhSoGioHK.Visible = True
                    Else
                        btnTinhSoGioHK.Visible = False
                    End If

                    Me.btnLuu.Visible = False
                    Me.btnXoanhom.Visible = False
                    Me.btnXemchitiet.Visible = True

                    Me.btnTinhSoGioHKNV.Visible = False
                    Me.btnXemDSHKNV.Visible = False

                Case 2
                    If bQuyenChuyenDLHKNV Then
                        btnTinhSoGioHKNV.Visible = True
                    Else
                        btnTinhSoGioHKNV.Visible = False
                    End If

                    Me.btnLuu.Visible = False
                    Me.btnXoanhom.Visible = False
                    Me.btnTinhSoGioHK.Visible = False
                    Me.btnXemchitiet.Visible = False

                    Me.btnXemDSHKNV.Visible = True
            End Select
        End If
    End Sub
    Private Sub txtSothe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSothe.TextChanged
        If Me.txtSothe.Text.Trim().Length = 6 Then
            Me.btnLuu.Enabled = True
            Me.btnXoanhom.Enabled = True
            Dim listpar As New ArrayList(1)
            Me.b = New clsBPhuNuHanhKinh
            Dim tblTemp As DataTable
            listpar.Add(New SqlParameter("@NV_MA", txtSothe.Text.Trim()))
            tblTemp = Me.b.LoadDSNghiHanhKinh("SP_THONGTINSOTHE_S", listpar)
            If tblTemp.Rows.Count > 0 Then
                If Convert.ToBoolean(tblTemp.Rows(0).Item("GT")) Then
                    MessageBox.Show("Số thẻ này là nam, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSothe.SelectAll()
                    Me.btnLuu.Enabled = False
                    Me.btnXoanhom.Enabled = False
                End If
                If Convert.ToBoolean(tblTemp.Rows(0).Item("DDNV")) Or Convert.ToBoolean(tblTemp.Rows(0).Item("DVNV")) Then
                    MessageBox.Show("Số thẻ này đã nghỉ việc, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSothe.SelectAll()
                    Me.btnLuu.Enabled = False
                    Me.btnXoanhom.Enabled = False
                End If
                If Convert.ToBoolean(tblTemp.Rows(0).Item("DVDT")) Or Convert.ToBoolean(tblTemp.Rows(0).Item("DVCG")) Then
                    MessageBox.Show("Số thẻ này thuộc đơn vị đồng tháp, chuyên gia, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSothe.SelectAll()
                    Me.btnLuu.Enabled = False
                    Me.btnXoanhom.Enabled = False
                End If
                ''============= load lưới ========''
                Me.oldRow = 0
                methodLoad()
            End If
            QuyenTruyCap()
        End If

    End Sub

    Private Sub radSothe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSothe.CheckedChanged
        If Me.radSothe.Checked Then
            Me.txtSothe.Enabled = True
            Me.cboDonvi.Enabled = False
        End If

    End Sub

    Private Sub radDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDV.CheckedChanged
        If Me.radDV.Checked Then
            Me.cboDonvi.Enabled = True
            Me.txtSothe.Enabled = False
            Me.txtSothe.Clear()
            methodLoad()
        End If
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub dgrBC_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell
        activeCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim sThangNam As String
            Select Case ColA
                Case "2"
                    If Xoa Then
                        objPNHK.Setnull()
                        'KiemTraSoThe_DaTinhNghiHanhKinh
                        ngay = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Day.ToString()

                        If CDate(Me.dtpNgay.Value).Month < 10 Then
                            sThangNam = "0" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString()
                        Else
                            sThangNam = CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString()
                        End If

                        objPNHK.setvalue(activeCell.Row.Cells.Item("NV_MA").Text.Trim(), ngay)
                        If KiemTraThangDaTinhGioNghiHanhKinh(sThangNam) Then
                            MessageBox.Show("Không xóa được, số thẻ này đã tính giờ nghỉ hành kinh tháng: " & CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Year.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else
                            If (MessageBox.Show("Bạn xóa ngày nằm nghỉ hành kinh (" & Me.dtpNgay.Text & ") của số thẻ : " & activeCell.Row.Cells("NV_MA").Text.ToString() & " ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                ' ngay = CDate(activeCell.Row.Cells.Item("NGAY").Value).Year.ToString() + "/" + CDate(activeCell.Row.Cells.Item("NGAY").Value).Month.ToString() + "/" + CDate(activeCell.Row.Cells.Item("NGAY").Value).Day.ToString()

                                If Me.b.DeleteInfo(objPNHK) Then
                                    MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    MessageBox.Show("Không xóa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                methodLoad()
                            Else
                                Exit Sub
                            End If
                        End If
                    Else
                        MessageBox.Show("Bạn không có quyền xóa trong chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
            End Select
        End If
    End Sub
    Private Sub btnXoanhom_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoanhom.Activate
        If KiemTraThangDaTinhGioNghiHanhKinh(Me.dtpThang.Text) = False Then
            If (MessageBox.Show("Bạn xóa ngày nằm nghỉ hành kinh (" & Me.dtpNgay.Text & ") của các số thẻ đã chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                objPNHK.Setnull()
                Me.dgrBC.UpdateData()
                i = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells("1").Value = True Then
                        If dtpNgay.Text.Trim() <> "" And IsDate(dtpNgay.Value) Then
                            ngay = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(Me.dtpNgay.Value).Month.ToString() + "/" + CDate(Me.dtpNgay.Value).Day.ToString()
                            objPNHK.setvalue(Me.dgrBC.Rows(i).Cells("NV_MA").Text.Trim(), ngay)
                            Me.b.DeleteInfo(objPNHK)
                        End If
                    End If
                    i = i + 1
                End While
                methodLoad()
            End If
        Else
            MessageBox.Show("Tháng này đã được cập nhật số giờ nghỉ hành kinh, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub tabTraCuu_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabTraCuu.SelectedTabChanged
        Me.dgrBC.DataSource = Nothing
        QuyenTruyCap()

        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0
 
                Me.XpCaption2.Text = "Danh sách lao động nữ nghỉ hành kinh ngày:" & Me.dtpNgay.Text.ToString()
                methodLoad()

            Case 1
              
                Me.XpCaption2.Text = "Số giờ nghỉ hành kinh trong tháng:" & Me.dtpThang.Text.ToString()

            Case 2
                Me.XpCaption2.Text = "Số giờ nghỉ hành kinh đơn vị " & Me.cboDonviNV.Text & " trong tháng:" & Me.dtpThangNV.Text.ToString()
              

        End Select

    End Sub
    Private Sub TinhSayThai(ByVal sNam As String)
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        Dim temp As DataTable
        Dim i As Integer = 0

        listpar.Add(New SqlParameter("@NAM", sNam))
        temp = Me.b.LoadDSNghiHanhKinh("SP_DSMT_TINHSAYTHAI_THAISAN", listpar)
        listpar.Clear()
        If temp.Rows.Count > 0 Then
            ''============= TÍNH SẢY THAI- THAI SẢN =======''
            While i <= temp.Rows.Count - 1
                listpar1.Add(New SqlParameter("@NV_MA", temp.Rows(i).Item("NV_MA").ToString()))
                Me.b.GoiThuTucTinhToan("SP_LAYNGUOISAYTHAI_KMAX", listpar1)
                listpar1.Clear()
                i = i + 1
            End While
        End If
    End Sub
    Private Function KiemTraNhapNghiViec_HKNV(ByVal sTMa As String, ByVal sDV_Ma As String) As Boolean
        Dim listpar As New ArrayList(2)
        Dim temp As DataTable

        listpar.Add(New SqlParameter("@DV_MA", sDV_Ma))
        listpar.Add(New SqlParameter("@T_MA", sTMa))
        temp = Me.b.LoadDSNghiHanhKinh("SP_CHUYENDULIEUHKNV_NGHIVIEC_S", listpar)
        listpar.Clear()
        If temp.Rows.Count > 0 Then
            Return True
        ElseIf temp.Rows.Count <= 0 Then
            Return False
        Else
            Return False
        End If
    End Function
    Private Sub TinhSayThaiNV(ByVal sNam As String, ByVal sDV_Ma As String)
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(1)
        Dim temp As DataTable
        Dim i As Integer = 0

        listpar.Add(New SqlParameter("@NAM", sNam))
        listpar.Add(New SqlParameter("@DV_Ma", sDV_Ma))

        temp = Me.b.LoadDSNghiHanhKinh("SP_DSMT_TINHSAYTHAI_THAISAN_NV", listpar)
        listpar.Clear()
        If temp.Rows.Count > 0 Then
            ''============= TÍNH SẢY THAI- THAI SẢN =======''
            While i <= temp.Rows.Count - 1
                listpar1.Add(New SqlParameter("@NV_MA", temp.Rows(i).Item("NV_MA").ToString()))
                Me.b.GoiThuTucTinhToan("SP_LAYNGUOISAYTHAI_KMAX", listpar1)
                listpar1.Clear()
                i = i + 1
            End While
        End If
    End Sub
    Private Sub methodLoad1()
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        Dim temp As DataTable
        Dim tempNgaycuoithang As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Dim sNgaycuoithang As String
        Me.Path = "/layout/PhuNuHanhKinh_Sogionghi.xml"

        If Me.dtpThang.Text <> "" Then
            listpar.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
            tempNgaycuoithang = Me.b.LoadDSNghiHanhKinh("SP_LAYNGAYCUOITHANG_S", listpar)
            If tempNgaycuoithang.Rows.Count > 0 Then
                sNgaycuoithang = tempNgaycuoithang.Rows(0).Item("NGAYCUOITHANG").ToString()
            Else
                MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            listpar.Clear()


            ''=========== loc ds ========''
            listpar1.Add(New SqlParameter("@NGAYCUOITHANG", sNgaycuoithang))
            temp = Me.b.LoadDSNghiHanhKinh("SP_DSNGHIHANHKINH_CHUYENDULIEU_S", listpar1)
            If temp.Rows.Count > 0 Then
                ''=============
                Me.dgrBC.DataSource = temp
                Dim dgrBC As Object = Me.dgrBC
                grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
            Else

            End If
            listpar1.Clear()
        Else
            MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
    Private Sub methodLoad2()
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        Dim temp As DataTable
        Dim tempNgaycuoithang As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Dim sNgaycuoithang As String
        Me.Path = "/layout/PhuNuHanhKinh_DanhSachChiTiet.xml"

        If Me.dtpThang.Text <> "" Then
            ''=========== loc ds ========''
            listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
            temp = Me.b.LoadDSNghiHanhKinh("SP_DSNGHIHANHKINH_TRONGTHANG_S", listpar1)
            'If temp.Rows.Count > 0 Then
            ''=============
            Me.dgrBC.DataSource = temp
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
            'Else

            'End If
        Else
        MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
        End If
    End Sub
    Private Sub DanhSachHKNghiViec()
        Dim listpar1 As New ArrayList(1)
        Dim temp, tblTinhHKNV As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Dim sNgaycuoithang As String
        tblTinhHKNV = KiemTraThangDaTinhGioNghiHanhKinhNV(Me.dtpThangNV.Text, Me.cboDonviNV.Value)

        'If tblTinhHKNV Is Nothing Then
        '    MessageBox.Show("Đơn vị " & Me.cboDonviNV.Text & " chưa tính hành kinh nghỉ việc tháng " & Me.dtpThangNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.dgrBC.DataSource = Nothing
        '    Exit Sub
        'ElseIf tblTinhHKNV.Rows.Count <= 0 Then
        '    MessageBox.Show("Đơn vị " & Me.cboDonviNV.Text & " chưa tính hành kinh nghỉ việc tháng " & Me.dtpThangNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.dgrBC.DataSource = Nothing
        '    Exit Sub
        'Else
        If Me.dtpThangNV.Text <> "" Then
            listpar1.Clear()
            listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
            listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
            temp = Me.b.LoadDSNghiHanhKinh("SP_DSHANHKINHNGHIVIEC_S", listpar1)
            Me.XpCaption2.Text = "Danh sách hành kinh nghỉ việc đơn vị " & Me.cboDonviNV.Value & " tháng " & Me.dtpThangNV.Text
            Me.dgrBC.DataSource = temp
        Else
            MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'End If
    End Sub
    Private Sub ChuyenDuLieu()
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        Dim listpar2 As New ArrayList(1)
        Dim temp, tempNgaycuoithang As DataTable
        Dim flagCapnhat As Boolean
        Dim sT_Ma As String
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Dim sNgaycuoithang As String
        Me.Path = "/layout/PhuNuHanhKinh_Sogionghi.xml"

        If Me.dtpThang.Text <> "" Then
            'If CDate(Me.dtpThang.Value).Month.ToString() <= 9 Then
            '    sT_Ma = "0" + CDate(Me.dtpThang.Value).Month.ToString() + CDate(Me.dtpThang.Value).Year.ToString()
            'Else
            '    sT_Ma = CDate(Me.dtpThang.Value).Month.ToString() + CDate(Me.dtpThang.Value).Year.ToString()
            'End If

            listpar.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
            tempNgaycuoithang = Me.b.LoadDSNghiHanhKinh("SP_LAYNGAYCUOITHANG_S", listpar)
            If tempNgaycuoithang.Rows.Count > 0 Then
                sNgaycuoithang = tempNgaycuoithang.Rows(0).Item("NGAYCUOITHANG").ToString()
            Else
                MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            listpar.Clear()
            ''=========== tính danh sách đã nghỉ ========''
            listpar1.Add(New SqlParameter("@NGAYCUOITHANG", sNgaycuoithang))
            listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
            flagCapnhat = Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_CHUYENDULIEU_I", listpar1)
            listpar1.Clear()
            If flagCapnhat Then
                Application.DoEvents()
                Try
                    ''============= KST - KTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_KTT7T_KTS", listpar1)
                    listpar1.Clear()
                    ''============= KST - CTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_CTT7T_KTS", listpar1)
                    listpar1.Clear()
                    ''============= KST - KTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_KTT7T_CTS", listpar1)
                    listpar1.Clear()
                    ''============= KST - CTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_CTT7T_CTS", listpar1)
                    listpar1.Clear()
                    ''-----------------------SẢY THAI --------------------''
                    ''============= CST - KTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_KTT7T_KTS", listpar1)
                    listpar1.Clear()

                    ''============= CST - KTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_KTT7T_CTS", listpar1)
                    listpar1.Clear()
                    ''============= CST - CTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_CTT7T_CTS", listpar1)
                    listpar1.Clear()
                    ''============= CST - CTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_CTT7T_KTS", listpar1)
                    listpar1.Clear()
                    ''============ cập nhật ngoại lệ ===============''
                    'listpar1.Add(New SqlParameter("@T_MA", Me.dtpThang.Text))
                    'Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_CTT7T_KTS", listpar1)
                    'listpar1.Clear()
                    ''----------------------
                    MessageBox.Show("Đã cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex, "Thông báo lổi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Quá trình cập nhật bị lỗi, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
    Private Sub ChuyenDuLieuNV()
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(4)
        Dim listpar2 As New ArrayList(1)
        Dim temp, tempNgaycuoithang As DataTable
        Dim flagCapnhat As Boolean
        Dim sT_Ma As String
        Dim grid As New clsTformatGrid
        Me.b = New clsBPhuNuHanhKinh
        Dim sNgaycuoithang As String

        If Me.dtpThangNV.Text <> "" Then
            listpar.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
            tempNgaycuoithang = Me.b.LoadDSNghiHanhKinh("SP_LAYNGAYCUOITHANG_S", listpar)
            If tempNgaycuoithang.Rows.Count > 0 Then
                sNgaycuoithang = tempNgaycuoithang.Rows(0).Item("NGAYCUOITHANG").ToString()
            Else
                MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            listpar.Clear()
            ''=========== tính danh sách đã nghỉ ========''
            listpar1.Add(New SqlParameter("@NGAYCUOITHANG", sNgaycuoithang))
            listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
            listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
            listpar1.Add(New SqlParameter("@NGUOITAO", frmDangNhap.txtTendangnhap.Text.ToString))
            flagCapnhat = Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_CHUYENDULIEU_I_NGHIVIEC", listpar1)
            listpar1.Clear()
            If flagCapnhat Then
                Application.DoEvents()
                Try
                    ''============= KST - KTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_KTT7T_KTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''============= KST - CTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_CTT7T_KTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''============= KST - KTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_KTT7T_CTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''============= KST - CTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_KST_CTT7T_CTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''-----------------------SẢY THAI --------------------''
                    ''============= CST - KTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_KTT7T_KTS_NGHIVIEC", listpar1)
                    listpar1.Clear()

                    ''============= CST - KTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_KTT7T_CTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''============= CST - CTTT7-CTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_CTT7T_CTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    ''============= CST - CTTT7-KTS  ''=============
                    listpar1.Add(New SqlParameter("@T_MA", Me.dtpThangNV.Text))
                    listpar1.Add(New SqlParameter("@DV_MA", Me.cboDonviNV.Value))
                    Me.b.CapNhatSoGioNghiHanhKinh("SP_DSNGHIHANHKINH_DS_CST_CTT7T_KTS_NGHIVIEC", listpar1)
                    listpar1.Clear()
                    MessageBox.Show("Đã cập nhật hành kinh nghỉ việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex, "Thông báo lổi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Quá trình cập nhật bị lỗi, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Định dạng tháng năm trong máy tính bạn không đúng, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
    Private Sub btnTinhSoGioHK_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhSoGioHK.Activate
        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0

            Case 1

                If KiemTraThangDaTinhGioNghiHanhKinh(Me.dtpThang.Text) = False Then
                    If (KiemTraNgayCuoiThangChuyenDuLieu(Me.dtpThang.Text)) Then
                        If (MessageBox.Show("Bạn muốn cập nhật số giờ nghỉ hành kinh tháng: " & Me.dtpThang.Text & " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            TinhSayThai(Me.dtpThang.Text.Substring(3, 4))
                            ChuyenDuLieu()
                        End If
                    Else
                        If (MessageBox.Show("Hiện tại chưa đến ngày cuối tháng, bạn muốn cập nhật số giờ nghỉ hành kinh tháng: " & Me.dtpThang.Text & " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            TinhSayThai(Me.dtpThang.Text.Substring(3, 4))
                            ChuyenDuLieu()
                        End If
                    End If
                Else
                    MessageBox.Show("Tháng này đã được cập nhật số giờ nghỉ hành kinh, vui lòng liên hệ IT để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End Select
    End Sub
    Private Sub btnXemchitiet_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemchitiet.Activate
        Select Case Me.tabTraCuu.SelectedTab.Index
            Case 0

            Case 1
                Me.XpCaption2.Text = "Các ngày nghỉ hành kinh trong tháng:" & Me.dtpThang.Text.ToString()
                methodLoad2()
        End Select
    End Sub
    Private Sub cbThang_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles dtpThang.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub
    Private Sub btnXemDSHKNV_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemDSHKNV.Activate
           Select Me.tabTraCuu.SelectedTab.Index
            Case 0
            Case 1
            Case 2
                DanhSachHKNghiViec()
                GridView_HKNghiViec()
        End Select

    End Sub

  
    Private Sub dtpThangNV_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles dtpThangNV.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub

   
    Private Sub frmPhuNuHanhKinh_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        bClosing = True
    End Sub

    Private Sub btnTinhSoGioHKNV_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhSoGioHKNV.Activate
        Select Me.tabTraCuu.SelectedTab.Index
            Case 0

            Case 1
            Case 2
                ' Dim tblTinhHKNV As DataTable
                ' tblTinhHKNV = KiemTraThangDaTinhGioNghiHanhKinhNV(Me.dtpThangNV.Text, Me.cboDonviNV.Value)
                'If tblTinhHKNV Is Nothing Then
                If (MessageBox.Show("Bạn muốn tính hành kinh nghỉ việc tháng: " & Me.dtpThangNV.Text & " đơn vị" & Me.cboDonviNV.Text & " không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    'If KiemTraNhapNghiViec_HKNV(Me.dtpThangNV.Text, Me.cboDonviNV.Value) Then
                    '    MessageBox.Show("Đơn vị " & Me.cboDonviNV.Text & " đã có nhập người thôi việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'Else
                    TinhSayThaiNV(Me.dtpThangNV.Text.Substring(3, 4), Me.cboDonviNV.Value)
                    ChuyenDuLieuNV()
                    'End If

                    'End If

                    'ElseIf tblTinhHKNV.Rows.Count <= 0 Then
                    'If KiemTraNhapNghiViec_HKNV(Me.dtpThangNV.Text, Me.cboDonviNV.Value) Then
                    '    MessageBox.Show("Đơn vị " & Me.cboDonviNV.Text & " tháng " & Me.dtpThangNV.Text & " đã có nhập người thôi việc.Không thể cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'Else
                    'TinhSayThaiNV(Me.dtpThangNV.Text.Substring(3, 4), Me.cboDonviNV.Value)
                    'ChuyenDuLieuNV()
                    'End If
                    'Else
                    '    MessageBox.Show("Đơn vị " & Me.cboDonviNV.Text & " đã tính hành kinh nghỉ việc tháng " & Me.dtpThangNV.Text & " ngày " & tblTinhHKNV.Rows(0).Item("NGAYTAO").ToString() & " rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                End If
                DanhSachHKNghiViec()
                GridView_HKNghiViec()

        End Select
    End Sub
    Private Sub GridView_HKNghiViec()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next

                .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                .Columns("NV_MA").Header.Caption = "Số thẻ"
                .Columns("NV_TEN").Header.Caption = "Họ tên"
                .Columns("NAM").Header.Caption = "Năm"
                .Columns("DV_MA").Header.Caption = "Mã đơn vị"
                .Columns("THANG").Header.Caption = "Tháng"
                .Columns("TONGSOGIO").Header.Caption = "Tổng số giờ"
                .Columns("HIENTHI").Header.Caption = "Tổng số giờ thực tế"
                .Columns("TINHNGHIVIEC").Header.Caption = "Ghi chú"
                .Columns("NGAYTAO").Header.Caption = "Ngày tính"

                .Columns("NV_MA").Width = 100
                .Columns("NV_TEN").Width = 200
                .Columns("NAM").Width = 100
                .Columns("DV_MA").Width = 100
                .Columns("THANG").Width = 80
                .Columns("TONGSOGIO").Width = 100
                .Columns("HIENTHI").Width = 100
                .Columns("TINHNGHIVIEC").Width = 100
                .Columns("NGAYTAO").Width = 100
                .Columns("NGAYTAO").Hidden = True

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
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(4)
                band.Layout.Bands(0).Summaries.Clear()
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số: "
                Dim sntt As Integer = 0
                For i = 0 To Me.dgrBC.Rows.Count - 1
                    If CInt(dgrBC.Rows(i).Cells("HIENTHI").Value.ToString()) > 0 Then
                        sntt = sntt + 1
                    End If
                Next
                band.Layout.Bands(0).Summaries.Add("Summary", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Me.dgrBC.DisplayLayout.Bands(0).Columns("HIENTHI"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
                band.Layout.Bands(0).Summaries("Summary").DisplayFormat = "Tổng số người hưởng hk= {0}" + sntt.ToString()
                'band = Nothing
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class