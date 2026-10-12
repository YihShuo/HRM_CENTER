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
Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.OleDb
''Người tạo: Quyến
''Ngày tạo: năm 2012
''Nội dung tạo: Lưu trữ hồ sơ tuyển dụng
''Người hiệu chỉnh: Trân
''Ngày hiệu chỉnh: 23/10/2014
''Nội dung hiệu chỉnh: Bổ sung chức năng cho phép nhập năm sinh

Public Class frmTieuChiSanLoc
    Dim flag As Boolean
    Dim flaggrid As Boolean
    Public trangthai As Integer
    Dim obj As New objTieuChiSanLoc
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDTieuChiSanLoc  ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim bNamSinh As Boolean = False
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBTieuChiSanLoc
        Me.Path = "/layout/TIEUCHISANLOC.xml"
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub

    Private Sub frmTieuChiSanLoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.flaggrid = False Then
            Me.methodLoad()

            ' load hoc van
            obj.ChonBang = 2
            Me.b = New clsBTieuChiSanLoc
            Me.cboHocVan.DataSource = Me.b.LoadDS(obj)
            Me.cboHocVan.ValueMember() = "HV_MA"
            Me.cboHocVan.DisplayMember() = "HV_Ten"
            Me.cboHocVan.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

            ' load chuyen mon
            obj.ChonBang = 3
            Me.b = New clsBTieuChiSanLoc
            Me.cbChuyenMon.DataSource = Me.b.LoadDS(obj)
            Me.cbChuyenMon.ValueMember() = "CM_MA"
            Me.cbChuyenMon.DisplayMember() = "CM_Ten"
            Me.cbChuyenMon.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

            ' load chung chi khac
            obj.ChonBang = 4
            Me.b = New clsBTieuChiSanLoc
            Me.cbChungChiK.DataSource = Me.b.LoadDS(obj)
            Me.cbChungChiK.ValueMember() = "CC_MA"
            Me.cbChungChiK.DisplayMember() = "CC_TEN"
            'Me.cbChungChiK.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            ' load ky nang
            obj.ChonBang = 5
            Me.b = New clsBTieuChiSanLoc
            Me.cbKyNang.DataSource = Me.b.LoadDS(obj)
            Me.cbKyNang.ValueMember() = "KN_MA"
            Me.cbKyNang.DisplayMember() = "KN_TEN"
            'Me.cbKyNang.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            ' load ngoai ngu
            obj.ChonBang = 6
            Me.b = New clsBTieuChiSanLoc
            Me.cbNgoaiNgu.DataSource = Me.b.LoadDS(obj)
            Me.cbNgoaiNgu.ValueMember() = "NN_MA"
            Me.cbNgoaiNgu.DisplayMember() = "NN_Ten"
            Me.cbNgoaiNgu.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            ' load tin hoc
            obj.ChonBang = 7
            Me.b = New clsBTieuChiSanLoc
            Me.cbTinHoc.DataSource = Me.b.LoadDS(obj)
            Me.cbTinHoc.ValueMember() = "TH_MA"
            Me.cbTinHoc.DisplayMember() = "TH_Ten"
            Me.cbTinHoc.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
            Me.An()

            Me.btSua.Enabled = False
            Me.btLuu.Enabled = False
            Me.btXoa.Enabled = False
            Me.TangSoThe()
            Me.btTCSL.Visible = False
            ''=============
            dtpNgaysinh.Format = DateTimePickerFormat.Custom
            Me.chkNamsinh.Checked = False
        End If
    End Sub
    Public Sub Hien()
        Me.chkLDPT.Enabled = True
        Me.chkNVCM.Enabled = True
        Me.chkDat.Enabled = True
        Me.chkChuaPV.Enabled = True
        Me.radNam.Enabled = True
        Me.radNu.Enabled = True
        Me.txtMaHS.Enabled = True
        Me.txtHoTen.Enabled = True
        Me.dtpNgaysinh.Enabled = True
        Me.dtpNgayNopHS.Enabled = True
        Me.txtDTDD.Enabled = True
        Me.txtNhaRieng.Enabled = True
        Me.txtDiaChi.Enabled = True
        Me.txtEmail.Enabled = True
        Me.txtFace.Enabled = True
        Me.txtSoCMND.Enabled = True

        Me.cboHocVan.Enabled = True
        Me.cbChuyenMon.Enabled = True
        Me.cbChungChiK.Enabled = True
        Me.txtKinhNghiem.Enabled = True
        Me.cbKyNang.Enabled = True
        Me.txtToChat.Enabled = True
        Me.txtHoatDongXH.Enabled = True
        Me.cbNgoaiNgu.Enabled = True
        Me.cbTinHoc.Enabled = True
        Me.txtHoTen1.Enabled = True
        Me.txtQuanHe1.Enabled = True
        Me.txtDienThoai1.Enabled = True
        Me.txtHoTen2.Enabled = True
        Me.txtQuanHe2.Enabled = True
        Me.txtDienThoai2.Enabled = True
        Me.txtDVGioiThieu.Enabled = True
        Me.txtMucLuong.Enabled = True
        Me.txtViTri.Enabled = True
        Me.txtSoDiem.Enabled = True
        Me.txtCVViet.Enabled = True
        Me.txtCVAnh.Enabled = True
        Me.txtCVHoa.Enabled = True
        ''============
        Me.chkNamsinh.Enabled = True
    End Sub
    Public Sub An()
        Me.chkLDPT.Enabled = False
        Me.chkNVCM.Enabled = False
        Me.txtMaHS.Enabled = False
        Me.txtHoTen.Enabled = False
        Me.dtpNgaysinh.Enabled = False
        Me.dtpNgayNopHS.Enabled = False
        Me.txtDTDD.Enabled = False
        Me.txtNhaRieng.Enabled = False
        Me.txtDiaChi.Enabled = False
        Me.txtEmail.Enabled = False
        Me.txtFace.Enabled = False
        Me.txtSoCMND.Enabled = False


        Me.cboHocVan.Enabled = False
        Me.cbChuyenMon.Enabled = False
        Me.cbChungChiK.Enabled = False
        Me.txtKinhNghiem.Enabled = False
        Me.cbKyNang.Enabled = False
        Me.txtToChat.Enabled = False
        Me.txtHoatDongXH.Enabled = False
        Me.cbNgoaiNgu.Enabled = False
        Me.cbTinHoc.Enabled = False
        Me.txtHoTen1.Enabled = False
        Me.txtQuanHe1.Enabled = False
        Me.txtDienThoai1.Enabled = False
        Me.txtHoTen2.Enabled = False
        Me.txtQuanHe2.Enabled = False
        Me.txtDienThoai2.Enabled = False
        Me.txtDVGioiThieu.Enabled = False
        Me.txtMucLuong.Enabled = False
        Me.txtViTri.Enabled = False
        Me.txtSoDiem.Enabled = False

        Me.chkDat.Enabled = False
        Me.chkChuaPV.Enabled = False
        Me.radNam.Enabled = False
        Me.radNu.Enabled = False
        Me.txtCVViet.Enabled = False
        Me.txtCVAnh.Enabled = False
        Me.txtCVHoa.Enabled = False
        '================
        Me.chkNamsinh.Enabled = False

    End Sub
    Public Sub Clear()
        Me.chkLDPT.Checked = False
        Me.chkNVCM.Checked = False
        Me.txtHoTen.Clear()
        Me.dtpNgaysinh.Text = Now
        ''========
        Me.chkNamsinh.Checked = False
        Me.dtpNgayNopHS.Text = Now
        Me.txtDTDD.Clear()
        Me.txtNhaRieng.Clear()
        Me.txtDiaChi.Clear()
        Me.txtEmail.Clear()
        Me.txtFace.Clear()
        Me.txtSoCMND.Clear()
        Me.cboHocVan.Clear()
        Me.cbChuyenMon.Clear()
        Me.cbChungChiK.Clear()
        Me.txtKinhNghiem.Clear()
        Me.cbKyNang.Clear()
        Me.txtToChat.Clear()
        Me.txtHoatDongXH.Clear()
        Me.cbNgoaiNgu.Clear()
        Me.cbTinHoc.Clear()
        Me.txtHoTen1.Clear()
        Me.txtQuanHe1.Clear()
        Me.txtDienThoai1.Clear()
        Me.txtHoTen2.Clear()
        Me.txtQuanHe2.Clear()
        Me.txtDienThoai2.Clear()
        Me.txtDVGioiThieu.Clear()
        Me.txtMucLuong.Clear()
        Me.txtViTri.Clear()
        Me.txtSoDiem.Clear()
        Me.chkChuaPV.Checked = False
        Me.chkDat.Checked = False
        Me.txtCVViet.Clear()
        Me.txtCVAnh.Clear()
        Me.txtCVHoa.Clear()
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
    Dim oldRow As Integer = 0
    Private Sub btThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThem.Activate
        If Me.flaggrid = False Then
            Me.Hien()
            Me.trangthai = 1
            Me.Clear()
            Me.btLuu.Enabled = True
            Me.btSua.Enabled = False
            Me.btXoa.Enabled = False
            Me.txtMaHS.ReadOnly = False
        End If
    End Sub
    Public Sub TangSoThe()
        obj.ChonBang = 9
        Dim Temp1 As New DataTable
        Me.b = New clsBTieuChiSanLoc
        Temp1 = Nothing
        Temp1 = Me.b.LoadDS(obj)
        If Temp1.Rows.Count > 0 Then
            Dim MANVTEMP As String
            If Temp1.Rows(0).Item("MAHS") Is DBNull.Value Then
                Me.txtMaHS.Text = "0000"
            Else
                MANVTEMP = Temp1.Rows(0).Item("MAHS")

                For i As Integer = 1 To 4
                    If (MANVTEMP.Length < 3) Then
                        MANVTEMP = "0" + MANVTEMP
                    End If
                Next
                Me.txtMaHS.Text = MANVTEMP
            End If
        Else
            Exit Sub
        End If
        'If Temp1.Rows.Count > 0 Then
        '    Dim MANVTEMP As String
        '    MANVTEMP = Temp1.Rows(0).Item("MAHS")
        '    If Len(MANVTEMP) = 1 Then
        '        Me.txtMaHS.Text = "000" + MANVTEMP
        '    End If
        '    If Len(MANVTEMP) = 2 Then
        '        Me.txtMaHS.Text = "00" + MANVTEMP
        '    End If
        '    If Len(MANVTEMP) = 3 Then
        '        Me.txtMaHS.Text = "0" + MANVTEMP
        '    End If
        '    If Len(MANVTEMP) = 4 Then
        '        Me.txtMaHS.Text = MANVTEMP
        '    End If

        'Else
        '    Exit Sub
        'End If
    End Sub
    Public filecv_viet As String
    Public filecv_cu_viet As String
    Public content_viet As Byte()
    Public filecv_anh As String
    Public filecv_cu_anh As String
    Public content_anh As Byte()
    Public filecv_hoa As String
    Public filecv_cu_hoa As String
    Public content_hoa As Byte()
    Protected Shared Function ReadFileToByteArray(ByVal fileName As String) As Byte()
        If fileName.ToString() <> "" Then
            Dim fileStream As New FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)
            Dim len As Long
            len = fileStream.Length
            Dim fileAsByte As [Byte]() = New [Byte](len - 1) {}
            fileStream.Read(fileAsByte, 0, fileAsByte.Length)
            Dim memoryStream As New MemoryStream(fileAsByte)
            Return memoryStream.ToArray()
        End If
    End Function
    Public Sub Luu()
        Dim nhanvien_cm As Boolean
        If Me.chkNVCM.Checked = True Then
            nhanvien_cm = True
        Else
            nhanvien_cm = False
        End If
        Dim laodong_pt As Boolean
        If Me.chkLDPT.Checked = True Then
            laodong_pt = True
        Else
            laodong_pt = False
        End If
        Dim mahs As String
        If Me.txtMaHS.Text = "" Then
            MessageBox.Show("Bạn phải nhập mã hồ sơ")
            Me.txtMaHS.Focus()
            Exit Sub
            mahs = ""
        Else
            mahs = Me.txtMaHS.Text.Trim()
        End If

        Dim ngayN As Date

        Dim ngaynop As String
        If Me.dtpNgayNopHS.Text.ToString() <> "" Then
            ngayN = Me.dtpNgayNopHS.Text
            ngaynop = ngayN.Year.ToString() + "/" + ngayN.Month.ToString() + "/" + ngayN.Day.ToString()
        Else
            ngaynop = ""
        End If

        Dim ten As String
        If Me.txtHoTen.Text = "" Then
            ten = ""
        Else
            ten = Me.txtHoTen.Text.Trim()
        End If
        Dim gioitinh As Integer
        gioitinh = Me.radNam.Checked
        gioitinh = Me.radNu.Checked

        ''======= cho phép lưu năm sinh =========''
        Dim chonnamsinh As Integer
        If Me.chkNamsinh.Checked Then
            chonnamsinh = 1
        Else
            chonnamsinh = 0
        End If

        Dim namS As String
        Dim ngayS As Date
        Dim ngaysinh As String

        If chonnamsinh = 1 Then
            namS = Me.dtpNgaysinh.Text
            ngaysinh = namS + "/" + "01" + "/" + "01"
        Else
            ngayS = Me.dtpNgaysinh.Text
            ngaysinh = ngayS.Year.ToString() + "/" + ngayS.Month.ToString() + "/" + ngayS.Day.ToString()
        End If

        Dim dtdidong As String
        If Me.txtDTDD.Text = "" Then
            dtdidong = ""
        Else
            dtdidong = Me.txtDTDD.Text.Trim()
        End If

        Dim dtnha As String
        If Me.txtNhaRieng.Text = "" Then
            dtnha = ""
        Else
            dtnha = Me.txtNhaRieng.Text.Trim()
        End If

        Dim diachi As String
        If Me.txtDiaChi.Text = "" Then
            diachi = ""
        Else
            diachi = Me.txtDiaChi.Text.Trim()
        End If

        Dim email As String
        If Me.txtEmail.Text = "" Then
            email = ""
        Else
            email = Me.txtEmail.Text.Trim()
        End If

        Dim face As String
        If Me.txtFace.Text = "" Then
            face = ""
        Else
            face = Me.txtFace.Text.Trim()
        End If

        Dim cmnd As String
        If Me.txtSoCMND.Text = "" Then
            cmnd = ""
        Else
            cmnd = Me.txtSoCMND.Text.Trim()
        End If

        Dim hocvan As String
        If Me.cboHocVan.Text = "" Then
            hocvan = ""
        Else
            hocvan = Me.cboHocVan.Value
        End If
        Dim chuyenmon As String
        If Me.cbChuyenMon.Text = "" Then
            chuyenmon = ""
        Else
            chuyenmon = Me.cbChuyenMon.Value
        End If
        Dim chungchik As String
        If Me.cbChungChiK.Text = "" Then
            chungchik = ""
        Else
            chungchik = Me.cbChungChiK.Value
        End If
        Dim kinhnghiem As String
        If Me.txtKinhNghiem.Text = "" Then
            kinhnghiem = ""
        Else
            kinhnghiem = Me.txtKinhNghiem.Text.Trim()
        End If
        Dim kynang As String
        If Me.cbKyNang.Text = "" Then
            kynang = ""
        Else
            kynang = Me.cbKyNang.Value
        End If
        Dim tochat As String
        If Me.txtToChat.Text = "" Then
            tochat = ""
        Else
            tochat = Me.txtToChat.Text.Trim()
        End If

        Dim hoatdongxh As String
        If Me.txtHoatDongXH.Text = "" Then
            hoatdongxh = ""
        Else
            hoatdongxh = Me.txtHoatDongXH.Text.Trim()
        End If
        Dim ngoaingu As String
        If Me.cbNgoaiNgu.Text = "" Then
            ngoaingu = ""
        Else
            ngoaingu = Me.cbNgoaiNgu.Value
        End If

        Dim tinhoc As String

        If Me.cbTinHoc.Text = "" Then
            tinhoc = ""
        Else
            tinhoc = Me.cbTinHoc.Value
        End If

        Dim ketqua As Boolean
        If Me.chkDat.Checked = True Then
            ketqua = True
        Else
            ketqua = False
        End If
        Dim chuapv As Boolean
        If Me.chkChuaPV.Checked = True Then
            chuapv = True
        Else
            chuapv = False
        End If
        Dim sodiem As String
        If Me.txtSoDiem.Text = "" Then
            sodiem = ""
        Else
            sodiem = Me.txtSoDiem.Text.Trim()
        End If

        Dim hoten1 As String
        If Me.txtHoTen1.Text = "" Then
            hoten1 = ""
        Else
            hoten1 = Me.txtHoTen1.Text.Trim()
        End If
        Dim quanhe1 As String
        If Me.txtQuanHe1.Text = "" Then
            quanhe1 = ""
        Else
            quanhe1 = Me.txtQuanHe1.Text.Trim()
        End If
        Dim dt1 As String
        If Me.txtDienThoai1.Text = "" Then
            dt1 = ""
        Else
            dt1 = Me.txtDienThoai1.Text.Trim()
        End If
        Dim hoten2 As String
        If Me.txtHoTen2.Text = "" Then
            hoten2 = ""
        Else
            hoten2 = Me.txtHoTen2.Text.Trim()
        End If
        Dim quanhe2 As String
        If Me.txtQuanHe2.Text = "" Then
            quanhe2 = ""
        Else
            quanhe2 = Me.txtQuanHe2.Text.Trim()
        End If
        Dim dt2 As String
        If Me.txtDienThoai2.Text = "" Then
            dt2 = ""
        Else
            dt2 = Me.txtDienThoai2.Text.Trim()
        End If

        Dim dvgioithieu As String
        If Me.txtDVGioiThieu.Text = "" Then
            dvgioithieu = ""
        Else
            dvgioithieu = Me.txtDVGioiThieu.Text.Trim()
        End If
        Dim mucluongmm As Double
        If Me.txtMucLuong.Text = "" Then
            mucluongmm = 0
        Else
            mucluongmm = Convert.ToDouble(Me.txtMucLuong.Text.Trim())
        End If
        Dim vitri As String
        If Me.txtViTri.Text = "" Then
            vitri = ""
        Else
            vitri = Me.txtViTri.Text.Trim()
        End If

        If Me.txtCVViet.Text.Trim <> "" Then
            filecv_viet = IO.Path.GetFileName(txtCVViet.Text.ToString())
        Else
            filecv_viet = ""
        End If

        If Me.txtCVAnh.Text.Trim <> "" Then
            filecv_anh = IO.Path.GetFileName(txtCVAnh.Text.ToString())
        Else
            filecv_anh = ""
        End If

        If Me.txtCVHoa.Text.Trim <> "" Then
            filecv_hoa = IO.Path.GetFileName(txtCVHoa.Text.ToString())
        Else
            filecv_hoa = ""
        End If
        If Me.trangthai = 1 Then
            ' kiem tra xem co ho so nay chua
            obj.ChonBang = 8
            Dim Temp As New DataTable
            Me.b = New clsBTieuChiSanLoc
            Temp = Nothing
            obj.MAHS = Me.txtMaHS.Text.Trim()
            obj.SoCMND = Me.txtSoCMND.Text.Trim()
            Temp = Me.b.LoadDS(obj)
            Dim FLAG As Boolean = 0

            If Temp.Rows.Count > 0 Then
                FLAG = True
            Else
                FLAG = False
            End If
            If FLAG = True Then
                ''' neu co roi thi hien thong bao len va lay thong tin len form hoi xem co muon cap nhat lai k
                MessageBox.Show("Hồ sơ này đã có trong bảng tiêu chí sàn lọc")
                Exit Sub
            Else
                ' neu chua co thi them moi vao
                obj.Setnull()
                obj.setvalue(nhanvien_cm, laodong_pt, mahs, ngaynop, ten, gioitinh, ngaysinh, chonnamsinh, dtdidong, dtnha, diachi, email, face, cmnd, hocvan, chuyenmon, chungchik, kinhnghiem, kynang, tochat, hoatdongxh, ngoaingu, tinhoc, ketqua, chuapv, sodiem, hoten1, quanhe1, dt1, hoten2, quanhe2, dt2, dvgioithieu, mucluongmm, vitri, 0)
                obj.ChonBang = 1
                Me.b = New clsBTieuChiSanLoc
                Me.b.InsertInfo(obj)
                obj.MAHS = mahs
                If Me.txtCVViet.Text <> "" Then
                    content_viet = ReadFileToByteArray(filecv_viet)
                    Me.b.SaveContentToDB(obj, content_viet, filecv_viet)
                End If

                If Me.txtCVAnh.Text <> "" Then
                    content_anh = ReadFileToByteArray(filecv_anh)
                    Me.b.SaveContentToDB2(obj, content_anh, filecv_anh)
                End If

                If Me.txtCVHoa.Text <> "" Then
                    content_hoa = ReadFileToByteArray(filecv_hoa)
                    Me.b.SaveContentToDB3(obj, content_hoa, filecv_hoa)
                End If
                Me.methodLoad()
                Me.trangthai = 1
                MessageBox.Show("Đã thêm dữ liệu")
            End If

        ElseIf trangthai = 0 Then
            ' cho sua thong tin ho so
            ' neu chua co thi them moi vao
            ' khai bao cac tham so
            If Me.chkNVCM.Checked = True Then
                nhanvien_cm = True
            Else
                nhanvien_cm = False
            End If
            If Me.chkLDPT.Checked = True Then
                laodong_pt = True
            Else
                laodong_pt = False
            End If
            If Me.txtMaHS.Text = "" Then
                mahs = ""
            Else
                mahs = Me.txtMaHS.Text.Trim()
            End If

            If Me.txtHoTen.Text = "" Then
                ten = ""
            Else
                ten = Me.txtHoTen.Text.Trim()
            End If
            gioitinh = Me.radNam.Checked
            gioitinh = Me.radNu.Checked

            ''======= cho phép lưu năm sinh =========''

            If Me.chkNamsinh.Checked Then
                chonnamsinh = 1
            Else
                chonnamsinh = 0
            End If

            Dim namS1 As String
            Dim ngayS1 As Date


            If chonnamsinh = 1 Then
                namS1 = Me.dtpNgaysinh.Text
                ngaysinh = namS + "/" + "01" + "/" + "01"
            Else
                ngayS1 = Me.dtpNgaysinh.Text
                ngaysinh = ngayS1.Year.ToString() + "/" + ngayS1.Month.ToString() + "/" + ngayS1.Day.ToString()
            End If


            If Me.txtDTDD.Text = "" Then
                dtdidong = ""
            Else
                dtdidong = Me.txtDTDD.Text.Trim()
            End If

            If Me.txtNhaRieng.Text = "" Then
                dtnha = ""
            Else
                dtnha = Me.txtNhaRieng.Text.Trim()
            End If
            If Me.txtDiaChi.Text = "" Then
                diachi = ""
            Else
                diachi = Me.txtDiaChi.Text.Trim()
            End If

            If Me.txtEmail.Text = "" Then
                email = ""
            Else
                email = Me.txtEmail.Text.Trim()
            End If

            If Me.txtFace.Text = "" Then
                face = ""
            Else
                face = Me.txtFace.Text.Trim()
            End If

            If Me.txtSoCMND.Text = "" Then
                cmnd = ""
            Else
                cmnd = Me.txtSoCMND.Text.Trim()
            End If
            If Me.cboHocVan.Text = "" Then
                hocvan = ""
            Else
                hocvan = Me.cboHocVan.Value
            End If

            If Me.cbChuyenMon.Text = "" Then
                chuyenmon = ""
            Else
                chuyenmon = Me.cbChuyenMon.Value
            End If

            If Me.cbChungChiK.Text = "" Then
                chungchik = ""
            Else
                chungchik = Me.cbChungChiK.Value
            End If

            If Me.txtKinhNghiem.Text = "" Then
                kinhnghiem = ""
            Else
                kinhnghiem = Me.txtKinhNghiem.Text.Trim()
            End If

            If Me.cbKyNang.Text = "" Then
                kynang = ""
            Else
                kynang = Me.cbKyNang.Value
            End If

            If Me.txtToChat.Text = "" Then
                tochat = ""
            Else
                tochat = Me.txtToChat.Text.Trim()
            End If

            If Me.txtHoatDongXH.Text = "" Then
                hoatdongxh = ""
            Else
                hoatdongxh = Me.txtHoatDongXH.Text.Trim()
            End If

            If Me.cbNgoaiNgu.Text = "" Then
                ngoaingu = ""
            Else
                ngoaingu = Me.cbNgoaiNgu.Value
            End If

            If Me.cbTinHoc.Text = "" Then
                tinhoc = ""
            Else
                tinhoc = Me.cbTinHoc.Value
            End If

            If Me.chkDat.Checked = True Then
                ketqua = True
            Else
                ketqua = False
            End If
            If Me.chkChuaPV.Checked = True Then
                chuapv = True
            Else
                chuapv = False
            End If
            If Me.txtSoDiem.Text = "" Then
                sodiem = ""
            Else
                sodiem = Me.txtSoDiem.Text.Trim()
            End If
            If Me.txtHoTen1.Text = "" Then
                hoten1 = ""
            Else
                hoten1 = Me.txtHoTen1.Text.Trim()
            End If

            If Me.txtQuanHe1.Text = "" Then
                quanhe1 = ""
            Else
                quanhe1 = Me.txtQuanHe1.Text.Trim()
            End If

            If Me.txtDienThoai1.Text = "" Then
                dt1 = ""
            Else
                dt1 = Me.txtDienThoai1.Text.Trim()
            End If

            If Me.txtHoTen2.Text = "" Then
                hoten2 = ""
            Else
                hoten2 = Me.txtHoTen2.Text.Trim()
            End If

            If Me.txtQuanHe2.Text = "" Then
                quanhe2 = ""
            Else
                quanhe2 = Me.txtQuanHe2.Text.Trim()
            End If

            If Me.txtDienThoai2.Text = "" Then
                dt2 = ""
            Else
                dt2 = Me.txtDienThoai2.Text.Trim()
            End If

            If Me.txtDVGioiThieu.Text = "" Then
                dvgioithieu = ""
            Else
                dvgioithieu = Me.txtDVGioiThieu.Text.Trim()
            End If
            If Me.txtMucLuong.Text = "" Then
                mucluongmm = ""
            Else
                mucluongmm = Convert.ToDouble(Me.txtMucLuong.Text.Trim())
            End If
            If Me.txtViTri.Text = "" Then
                vitri = ""
            Else
                vitri = Me.txtViTri.Text.Trim()
            End If
            obj.Setnull()
            obj.setvalue(nhanvien_cm, laodong_pt, mahs, ngaynop, ten, gioitinh, ngaysinh, chonnamsinh, dtdidong, dtnha, diachi, email, face, cmnd, hocvan, chuyenmon, chungchik, kinhnghiem, kynang, tochat, hoatdongxh, ngoaingu, tinhoc, ketqua, chuapv, sodiem, hoten1, quanhe1, dt1, hoten2, quanhe2, dt2, dvgioithieu, mucluongmm, vitri, 0)
            obj.ChonBang = 1
            Me.b = New clsBTieuChiSanLoc
            Me.b.UpdateInfo(obj)
            If filecv_cu_viet = "" Then
                If filecv_viet = "" Then
                Else
                    content_viet = ReadFileToByteArray(filecv_viet)
                    Me.b.SaveContentToDB(obj, content_viet, filecv_viet)
                End If
            Else
                obj.ChonBang = 3
                Me.b.UpdateInfo(obj)
                If filecv_viet = "" Then
                Else
                    content_viet = ReadFileToByteArray(filecv_viet)
                    Me.b.SaveContentToDB(obj, content_viet, filecv_viet)
                End If
            End If

            '' anh
            If filecv_cu_anh = "" Then
                If filecv_anh = "" Then
                Else
                    content_anh = ReadFileToByteArray(filecv_anh)
                    Me.b.SaveContentToDB2(obj, content_anh, filecv_anh)
                End If
            Else
                obj.ChonBang = 4
                Me.b.UpdateInfo(obj)
                If filecv_anh = "" Then
                Else
                    content_anh = ReadFileToByteArray(filecv_anh)
                    Me.b.SaveContentToDB2(obj, content_anh, filecv_anh)
                End If
            End If
            ''' hoa
            If filecv_cu_hoa = "" Then
                If filecv_hoa = "" Then
                Else
                    content_hoa = ReadFileToByteArray(filecv_hoa)
                    Me.b.SaveContentToDB3(obj, content_hoa, filecv_hoa)
                End If
            Else
                obj.ChonBang = 5
                Me.b.UpdateInfo(obj)
                If filecv_hoa = "" Then
                Else
                    content_hoa = ReadFileToByteArray(filecv_hoa)
                    Me.b.SaveContentToDB3(obj, content_hoa, filecv_hoa)
                End If
            End If
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.methodLoad()
            Me.trangthai = 0
        End If

    End Sub

    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        If Me.flaggrid = False Then
            Me.trangthai = 0
            Me.Hien()
            Me.txtMaHS.Enabled = False
            Me.btLuu.Enabled = True
        End If
    End Sub

    Private Sub btLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuu.Activate
        If Me.flaggrid = False Then
            Me.Luu()
            Me.TangSoThe()
        End If
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                If activeRow.Cells.Item("NV_CM").Value.ToString = Nothing Then
                    Me.chkNVCM.Checked = False
                ElseIf activeRow.Cells.Item("NV_CM").Value.ToString = True Then
                    Me.chkNVCM.Checked = True
                Else
                    Me.chkNVCM.Checked = False
                End If
                If activeRow.Cells.Item("LDPT").Value.ToString = Nothing Then
                    Me.chkLDPT.Checked = False
                ElseIf activeRow.Cells.Item("LDPT").Value.ToString = True Then
                    Me.chkLDPT.Checked = True
                Else
                    Me.chkLDPT.Checked = False
                End If
                Me.txtMaHS.ReadOnly = True
                Me.txtMaHS.Text = activeRow.Cells.Item("MAHS").Value.ToString
                Me.dtpNgayNopHS.Text = activeRow.Cells.Item("NGAYNOP").Value.ToString
                Me.txtHoTen.Text = activeRow.Cells.Item("TEN").Value.ToString
                ''========= hien thi nam sinh hoac ngay sinh=======''
                Me.chkNamsinh.Checked = Convert.ToBoolean(activeRow.Cells.Item("NV_NAMSINH").Value)
                If Convert.ToBoolean(activeRow.Cells.Item("NV_NAMSINH").Value) = False Then
                    Me.dtpNgaysinh.Text = activeRow.Cells.Item("NGAYSINH").Value.ToString
                    dtpNgaysinh.CustomFormat = "dd/MM/yyyy"
                Else
                    Me.dtpNgaysinh.Value = activeRow.Cells.Item("NGAYSINHTT").Value.ToString
                    dtpNgaysinh.CustomFormat = "yyyy"
                End If


                Me.txtDTDD.Text = activeRow.Cells.Item("DTDD").Value.ToString
                Me.txtNhaRieng.Text = activeRow.Cells.Item("DTNR").Value.ToString
                Me.txtDiaChi.Text = activeRow.Cells.Item("DIACHI").Value.ToString
                Me.txtEmail.Text = activeRow.Cells.Item("EMAIL").Value.ToString
                Me.txtFace.Text = activeRow.Cells.Item("FACE").Value.ToString
                Me.txtSoCMND.Text = activeRow.Cells.Item("CMND").Value.ToString
                Me.cboHocVan.Text = activeRow.Cells.Item("HV_MA").Value.ToString
                Me.cbChuyenMon.Value = activeRow.Cells.Item("CM_MA").Value.ToString
                Me.cbChungChiK.Value = activeRow.Cells.Item("CC_MA").Value.ToString
                Me.txtKinhNghiem.Text = activeRow.Cells.Item("KINHNGHIEM").Value.ToString
                Me.cbKyNang.Value = activeRow.Cells.Item("KN_MA").Value.ToString
                Me.txtToChat.Text = activeRow.Cells.Item("TOCHAT").Value.ToString
                Me.txtHoatDongXH.Text = activeRow.Cells.Item("HOATDONGXH").Value.ToString
                Me.cbNgoaiNgu.Value = activeRow.Cells.Item("NN_MA").Value.ToString
                Me.cbTinHoc.Value = activeRow.Cells.Item("TH_MA").Value.ToString
                Me.txtSoDiem.Text = activeRow.Cells.Item("SODIEMDAT").Value.ToString
                Me.txtHoTen1.Text = activeRow.Cells.Item("HOTEN1").Value.ToString
                Me.txtQuanHe1.Text = activeRow.Cells.Item("QUANHE1").Value.ToString
                Me.txtDienThoai1.Text = activeRow.Cells.Item("DIENTHOAI1").Value.ToString
                Me.txtHoTen2.Text = activeRow.Cells.Item("HOTEN2").Value.ToString
                Me.txtQuanHe2.Text = activeRow.Cells.Item("QUANHE2").Value.ToString
                Me.txtDienThoai2.Text = activeRow.Cells.Item("DIENTHOAI2").Value.ToString
                Me.txtDVGioiThieu.Text = activeRow.Cells.Item("DVGIOITHIEU").Value.ToString
                Me.txtMucLuong.Text = activeRow.Cells.Item("MUCLUONGMM").Value.ToString
                Me.txtViTri.Text = activeRow.Cells.Item("VITRI").Value.ToString
                filecv_cu_viet = activeRow.Cells.Item("FILE_CV1").Value.ToString
                Me.txtCVViet.Text = activeRow.Cells.Item("FILE_CV1").Value.ToString

                filecv_cu_anh = activeRow.Cells.Item("FILE_CV2").Value.ToString
                Me.txtCVAnh.Text = activeRow.Cells.Item("FILE_CV2").Value.ToString

                filecv_cu_hoa = activeRow.Cells.Item("FILE_CV3").Value.ToString
                Me.txtCVHoa.Text = activeRow.Cells.Item("FILE_CV3").Value.ToString

                If activeRow.Cells.Item("GIOITINH").Value.ToString = "Nam" Then
                    Me.radNam.Checked = True
                ElseIf activeRow.Cells.Item("GIOITINH").Value.ToString = "Nữ" Then
                    Me.radNam.Checked = False
                    Me.radNu.Checked = True
                Else
                    Me.radNam.Checked = False
                End If

                If activeRow.Cells.Item("KETQUA").Value.ToString = Nothing Then
                    Me.chkDat.Checked = False
                ElseIf activeRow.Cells.Item("KETQUA").Value.ToString = True Then
                    Me.chkDat.Checked = True
                Else
                    Me.chkDat.Checked = False
                End If

                If activeRow.Cells.Item("CHUAPV").Value.ToString = Nothing Then
                    Me.chkChuaPV.Checked = False
                ElseIf activeRow.Cells.Item("CHUAPV").Value.ToString = True Then
                    Me.chkChuaPV.Checked = True
                Else
                    Me.chkChuaPV.Checked = False
                End If
            End If
            Me.flag = 1
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(3).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(4).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(5).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(7).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(8).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(9).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(10).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(11).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(12).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(13).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(14).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(15).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(16).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(17).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(18).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(19).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(20).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(21).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(22).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(23).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(24).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(25).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(26).CellActivation = Activation.NoEdit
        'e.Layout.Bands(0).Columns(27).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(28).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(29).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(30).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(31).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(32).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(33).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(34).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(35).CellActivation = Activation.NoEdit

        e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        If Me.flaggrid = False Then
            Me.An()
            Me.ChonDong()
            Me.HieuChinh()
            Me.btSua.Enabled = True
            Me.btThem.Enabled = False
            Me.btLuu.Enabled = False
            Me.btXoa.Enabled = True
        End If
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jTieuChi As New objTieuChiSanLoc
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim ma As String
                Dim moiqh As String
                Dim STT As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        ma = StringType.FromObject(activeRow.Cells.Item("MAHS").Value)
                        jTieuChi.MAHS = ma
                        If jTieuChi.MAHS = ma Then
                            If (MessageBox.Show(("Bạn có muốn xóa hồ sơ : " & ma & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo(jTieuChi) Then
                                    MessageBox.Show("Đã xóa thành công")
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không được xóa nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                'Return
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nhân viên đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    'ma = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("NV_MA").Value)
                    'moiqh = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("MA_QH").Value)
                    'STT = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("STT").Value)
                    'If Me.b.DeleteInfo(jFunction) Then
                    '    MessageBox.Show("Đã xóa thành công")
                    'Else
                    '    MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    'End If
                    'i += 1
                Loop
            End If
Label_0274:
            jTieuChi.Setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jTieuChi)
            Me.methodLoad()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        If Me.flaggrid = False Then
            Me.XoaDuLieu()
            Me.Clear()
        End If
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        If Me.flaggrid = False Then
            Me.btThem.Enabled = True
            Me.btSua.Enabled = False
            Me.btXoa.Enabled = False
            Me.Clear()
            Me.TangSoThe()
        End If

    End Sub

    Private Sub txtSoCMND_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoCMND.KeyPress
        'If Convert.ToInt32(e.KeyChar) <> 8 Then
        '    If Not Information.IsNumeric(e.KeyChar) Then
        '        e.KeyChar = ""
        '    End If
        'End If
    End Sub

    Private Sub txtMucLuong_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMucLuong.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtDTDD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDTDD.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtNhaRieng_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNhaRieng.ValueChanged

    End Sub

    Private Sub txtNhaRieng_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNhaRieng.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtSoCMND_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoCMND.ValueChanged
        If Me.txtSoCMND.TextLength = 9 Or Me.txtSoCMND.TextLength = 12 Then
            obj.ChonBang = 10
            Dim Temp3 As New DataTable
            Me.b = New clsBTieuChiSanLoc
            Temp3 = Nothing
            obj.SoCMND = Me.txtSoCMND.Text.Trim()
            Temp3 = Me.b.LoadDS(obj)
            Dim CO As String

            If Temp3.Rows.Count > 0 Then ' co so cm trong bang nhan vien
                ' Kiem tra so cm
                CO = 1 ' CO SO CM
            Else
                CO = 0
            End If
            If CO = 1 Then
                obj.ChonBang = 11
                Dim Temp4 As New DataTable
                Me.b = New clsBTieuChiSanLoc
                Temp4 = Nothing
                obj.SoCMND = Me.txtSoCMND.Text.Trim()
                Temp4 = Me.b.LoadDS(obj)

                obj.ChonBang = 12
                Dim Temp5 As New DataTable
                Me.b = New clsBTieuChiSanLoc
                Temp5 = Nothing
                obj.SoCMND = Me.txtSoCMND.Text.Trim()
                Temp5 = Me.b.LoadDS(obj)

                Dim SOLAN As Integer
                SOLAN = Temp5.Rows(0).Item("SOLAN")
                Dim SOTHE As String
                Dim NGAYVAO As String
                Dim THOIVIEC As Integer
                Dim LAMVIEC As String
                If Temp4.Rows(0).Item("NV_THOIVIEC").ToString <> "" Then
                    If Temp4.Rows(0).Item("NV_THOIVIEC").ToString = True Then
                        THOIVIEC = 1
                    Else
                        THOIVIEC = 0
                    End If
                Else
                    THOIVIEC = 0
                End If

                If THOIVIEC = 1 Then
                    LAMVIEC = " đã thôi việc"
                Else
                    LAMVIEC = " đang làm việc"
                End If
                SOTHE = Temp4.Rows(0).Item("NV_MA")
                NGAYVAO = Temp4.Rows(0).Item("NV_NGAYVAO")
                MessageBox.Show("Hồ sơ này đã vào công ty " & SOLAN & " lần có số thẻ " & SOTHE & " vào ngày " & NGAYVAO & " " & LAMVIEC & "")
            End If
        End If
    End Sub
    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New clsBTieuChiSanLoc
        Me.Path = "/layout/TIEUCHISANLOC.xml"
        obj.ChonBang = 13
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        'grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub
    Private Sub btDanhSachCVCT_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDanhSachCVCT.Activate
        Me.dgrBC.DataSource = Nothing
        Me.methodLoad2()
        Me.btDanhSachCVCT.Visible = False
        Me.btTCSL.Visible = True
        Me.btThem.Enabled = False
        Me.btSua.Enabled = False
        Me.btXoa.Enabled = False
        flaggrid = True
    End Sub

    Private Sub btTCSL_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTCSL.Activate
        Me.dgrBC.DataSource = Nothing
        Me.methodLoad()
        Me.btDanhSachCVCT.Visible = True
        Me.btTCSL.Visible = False
        Me.btThem.Enabled = True
        flaggrid = False
    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub Format_NamSinh()
        dtpNgaysinh.Format = DateTimePickerFormat.Custom

        If Me.dtpNgaysinh.Text.ToString() <> "" Then
            If Me.chkNamsinh.Checked Then
                Me.dtpNgaysinh.CustomFormat = "yyyy"
                Me.lblNgaysinh.Text = "Năm sinh :"
                bNamSinh = True
                dtpNgaysinh.ShowUpDown = True
            Else
                bNamSinh = False
                Me.dtpNgaysinh.CustomFormat = "dd/MM/yyyy"
                Me.lblNgaysinh.Text = "Ngày sinh :"
                dtpNgaysinh.ShowUpDown = False
            End If
        Else
            Me.chkNamsinh.Checked = False
            Me.dtpNgaysinh.CustomFormat = "dd/MM/yyyy"
            Me.lblNgaysinh.Text = "Ngày sinh :"
            dtpNgaysinh.ShowUpDown = False
            bNamSinh = False
        End If
    End Sub

    Private Sub chkNamsinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNamsinh.CheckedChanged
        Format_NamSinh()
    End Sub

    Private Sub btOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpen.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.Title = "Select File"
        If DialogResult.Cancel = OpenFileDialog1.ShowDialog() Then
            Return
        End If
        Me.txtCVViet.Text = OpenFileDialog1.FileName.ToString
    End Sub

    Private Sub dgrBC_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        
    End Sub
    Public Sub PopulateData(ByVal mactrinhdt As String)
        Dim fileName As String = String.Empty
        Dim content As Byte() = Nothing
        Dim sqlCommand As SqlCommand = Nothing
        Dim dataSet As DataSet = Nothing
        Dim sqlDataAdapter As SqlDataAdapter = Nothing
        Dim sqlDataReader As SqlDataReader = Nothing
        Dim currencyManager As CurrencyManager
        Dim flag As Boolean
        Try
            If Me.b.d.conn.State = ConnectionState.Closed Then
                Me.b.d.conn.Open()
            End If
            Dim sql As String = "Select FILE_CV1,NOIDUNGFILE_CV1 from IT_TIEUCHISANLOC WHERE MAHS ='" & mactrinhdt & "'"
            sqlCommand = New SqlCommand(sql, Me.b.d.conn)

            sqlDataReader = sqlCommand.ExecuteReader()
            '' mo ket noi: kiem tra noi dung path file & noi dung file co luu vao DB chua
            '' sau do doc nguoc tung byte noi dung 
            While sqlDataReader.Read()
                fileName = DirectCast(sqlDataReader.GetString(0), String)
                If IsDBNull(sqlDataReader.GetValue(1)) Then
                    MessageBox.Show("Không thể đọc nội dung file này, hãy kiểm tra file và đường dẫn.", "Thông báo lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    content = DirectCast(sqlDataReader.GetValue(1), Byte())
                End If
                Exit While
            End While

            '' tao path luu tam: C:\Documents and Settings\welcome\Local Settings\Temp\Test may cua ng.dung
            Dim di As New DirectoryInfo(IO.Path.GetTempPath() & "\Test")
            If di.Exists = False Then
                di.Create()
            End If

            ''Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Append)
            Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Create)

            fs.Write(content, 0, System.Convert.ToInt32(content.Length))
            fs.Seek(0, SeekOrigin.Begin)
            fs.Close()
            Dim psi As New ProcessStartInfo(di.ToString() & "\" & fileName)
            Process.Start(psi)
            sqlDataReader.Close()
        Catch ex As Exception
            MessageBox.Show("File " & fileName & " hiện đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.b.d.conn.Close()
        Finally
        End Try
    End Sub
    Public Sub PopulateData2(ByVal mactrinhdt As String)
        Dim fileName As String = String.Empty
        Dim content As Byte() = Nothing
        Dim sqlCommand As SqlCommand = Nothing
        Dim dataSet As DataSet = Nothing
        Dim sqlDataAdapter As SqlDataAdapter = Nothing
        Dim sqlDataReader As SqlDataReader = Nothing
        Dim currencyManager As CurrencyManager
        Dim flag As Boolean
        Try
            If Me.b.d.conn.State = ConnectionState.Closed Then
                Me.b.d.conn.Open()
            End If
            Dim sql As String = "Select FILE_CV2,NOIDUNGFILE_CV2 from IT_TIEUCHISANLOC WHERE MAHS ='" & mactrinhdt & "'"
            sqlCommand = New SqlCommand(sql, Me.b.d.conn)

            sqlDataReader = sqlCommand.ExecuteReader()
            '' mo ket noi: kiem tra noi dung path file & noi dung file co luu vao DB chua
            '' sau do doc nguoc tung byte noi dung 
            While sqlDataReader.Read()
                fileName = DirectCast(sqlDataReader.GetString(0), String)
                If IsDBNull(sqlDataReader.GetValue(1)) Then
                    MessageBox.Show("Không thể đọc nội dung file này, hãy kiểm tra file và đường dẫn.", "Thông báo lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    content = DirectCast(sqlDataReader.GetValue(1), Byte())
                End If
                Exit While
            End While

            '' tao path luu tam: C:\Documents and Settings\welcome\Local Settings\Temp\Test may cua ng.dung
            Dim di As New DirectoryInfo(IO.Path.GetTempPath() & "\Test")
            If di.Exists = False Then
                di.Create()
            End If

            ''Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Append)
            Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Create)

            fs.Write(content, 0, System.Convert.ToInt32(content.Length))
            fs.Seek(0, SeekOrigin.Begin)
            fs.Close()
            Dim psi As New ProcessStartInfo(di.ToString() & "\" & fileName)
            Process.Start(psi)
            sqlDataReader.Close()
        Catch ex As Exception
            MessageBox.Show("File " & fileName & " hiện đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.b.d.conn.Close()
        Finally
        End Try
    End Sub
    Public Sub PopulateData3(ByVal mactrinhdt As String)
        Dim fileName As String = String.Empty
        Dim content As Byte() = Nothing
        Dim sqlCommand As SqlCommand = Nothing
        Dim dataSet As DataSet = Nothing
        Dim sqlDataAdapter As SqlDataAdapter = Nothing
        Dim sqlDataReader As SqlDataReader = Nothing
        Dim currencyManager As CurrencyManager
        Dim flag As Boolean
        Try
            If Me.b.d.conn.State = ConnectionState.Closed Then
                Me.b.d.conn.Open()
            End If
            Dim sql As String = "Select FILE_CV3,NOIDUNGFILE_CV3 from IT_TIEUCHISANLOC WHERE MAHS ='" & mactrinhdt & "'"
            sqlCommand = New SqlCommand(sql, Me.b.d.conn)

            sqlDataReader = sqlCommand.ExecuteReader()
            '' mo ket noi: kiem tra noi dung path file & noi dung file co luu vao DB chua
            '' sau do doc nguoc tung byte noi dung 
            While sqlDataReader.Read()
                fileName = DirectCast(sqlDataReader.GetString(0), String)
                If IsDBNull(sqlDataReader.GetValue(1)) Then
                    MessageBox.Show("Không thể đọc nội dung file này, hãy kiểm tra file và đường dẫn.", "Thông báo lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    content = DirectCast(sqlDataReader.GetValue(1), Byte())
                End If
                Exit While
            End While

            '' tao path luu tam: C:\Documents and Settings\welcome\Local Settings\Temp\Test may cua ng.dung
            Dim di As New DirectoryInfo(IO.Path.GetTempPath() & "\Test")
            If di.Exists = False Then
                di.Create()
            End If

            ''Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Append)
            Dim fs As New FileStream(di.ToString() & "\" & fileName, FileMode.Create)

            fs.Write(content, 0, System.Convert.ToInt32(content.Length))
            fs.Seek(0, SeekOrigin.Begin)
            fs.Close()
            Dim psi As New ProcessStartInfo(di.ToString() & "\" & fileName)
            Process.Start(psi)
            sqlDataReader.Close()
        Catch ex As Exception
            MessageBox.Show("File " & fileName & " hiện đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.b.d.conn.Close()
        Finally
        End Try
    End Sub
    Private Sub btOpen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpen2.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.Title = "Select File"
        If DialogResult.Cancel = OpenFileDialog1.ShowDialog() Then
            Return
        End If
        Me.txtCVAnh.Text = OpenFileDialog1.FileName.ToString
    End Sub

    Private Sub btOpen3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpen3.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.Title = "Select File"
        If DialogResult.Cancel = OpenFileDialog1.ShowDialog() Then
            Return
        End If
        Me.txtCVHoa.Text = OpenFileDialog1.FileName.ToString
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "FILE_CV1"
                    If activeCell.Row.Cells("FILE_CV1").Value.ToString() = Nothing Then
                        MessageBox.Show("Nhân viên này chưa có file CV Việt!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If (MessageBox.Show(("Bạn có muốn mở file: " & activeCell.Row.Cells("FILE_CV1").Value.ToString() & " không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                            ''goi ham
                            ' ''HIEN THI FILE VA PATH KHAO SAT
                            '' Dim dataRowView As DataRowView = DirectCast(currencyManager.Current, DataRowView)
                            obj.MAHS = activeCell.Row.Cells("MAHS").Value.ToString()
                            Me.PopulateData(obj.MAHS)
                        End If
                    End If
                Case "FILE_CV2"
                    If activeCell.Row.Cells("FILE_CV2").Value.ToString() = Nothing Then
                        MessageBox.Show("Nhân viên này chưa có file CV Anh!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If (MessageBox.Show(("Bạn có muốn mở file: " & activeCell.Row.Cells("FILE_CV2").Value.ToString() & " không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                            ' ''HIEN THI FILE VA PATH KHAO SAT
                            '' Dim dataRowView As DataRowView = DirectCast(currencyManager.Current, DataRowView)
                            obj.MAHS = activeCell.Row.Cells("MAHS").Value.ToString()
                            Me.PopulateData2(obj.MAHS)
                        End If
                    End If
                Case "FILE_CV3"
                    If activeCell.Row.Cells("FILE_CV3").Value.ToString() = Nothing Then
                        MessageBox.Show("Nhân viên này chưa có file CV Hoa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If (MessageBox.Show(("Bạn có muốn mở file: " & activeCell.Row.Cells("FILE_CV3").Value.ToString() & " không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                            ' ''HIEN THI FILE VA PATH KHAO SAT
                            '' Dim dataRowView As DataRowView = DirectCast(currencyManager.Current, DataRowView)
                            obj.MAHS = activeCell.Row.Cells("MAHS").Value.ToString()
                            Me.PopulateData3(obj.MAHS)
                        End If
                    End If
            End Select

        End If
    End Sub
End Class