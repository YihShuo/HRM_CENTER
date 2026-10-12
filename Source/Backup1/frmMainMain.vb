Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinListView.UltraListViewItem
Imports Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn
Imports Infragistics.Win.AutoCompleteMode
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Globalization
Imports TongHop.MAIN

Public Class frmMainMain

    Public Shared objchucnangah As New objNguoiDung

    Private Sub frmMainMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'Me.ControlBox = False
        Me.stbLoginTime.Text = ("Đăng nhập lúc: " & StringType.FromDate(DateAndTime.Now))
        Me.Timer1.Start()
        Me.TrangThaiButton_ToiLui()
    End Sub

    Function HienForm_Mdichilren_DaCo(ByVal Key As String) As Integer
        Dim i As Integer = 0
        While i < Me.cbForm.Items.Count
            If (StringType.StrCmp(Me.cbForm.Items(i).DataValue.ToString(), Key, False) = 0) Then
                Dim form As Form
                For Each form In Me.MdiChildren
                    If (StringType.StrCmp(form.Name.ToString, Key, False) = 0) Then
                        form.BringToFront()
                        Me.stbChildForm.Text = "Màn hình: " & Me.cbForm.Items(i).DisplayText.ToString()
                        Me.cbForm.Text = Me.cbForm.Items(i).DisplayText.ToString()
                    End If
                Next
                Return 1
            End If
            i = i + 1
        End While
        Return 0
    End Function

    Public Sub RemoveItemCb_Form(ByVal From_Name As String)
        Me.ActiveMdiChild.Close()
        Dim i As Integer = 0
        While i < Me.cbForm.Items.Count
            If (StringType.StrCmp(Me.cbForm.Items(i).DataValue.ToString(), From_Name, False) = 0) Then
                Me.cbForm.Items.RemoveAt(i)
                If i > 0 Then
                    Me.cbForm.SelectedIndex = i - 1
                Else
                    Me.cbForm.SelectedIndex = 0
                End If
                Exit Sub
            End If
            i = i + 1
        End While
    End Sub

    Private Sub HienForm_Mdichilren(ByRef frm As Form, ByVal FormName As String, ByVal FormText As String)
        If frm.Name = "frmCapNhatHoSoNhanSu" Then
            Me.Panel2.Hide()

        Else
            Me.Panel2.Show()
        End If
       
        Me.cbForm.Items.Add(FormName, FormText)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.MdiParent = Me
        frm.Show()
        frm.Dock = DockStyle.Fill
        Me.stbChildForm.Text = "Màn hình: " & FormText
        Me.cbForm.Text = FormText
    End Sub

    Private Sub HienForm_New(ByRef frm As Form, ByVal FormName As String, ByVal FormText As String)
        frm.Show()
        frm.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub DangNhapLai()
        If MessageBox.Show("Bạn có chắc chắn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.ExitThread()
            Application.Restart()
        End If
    End Sub

    Private Sub CallForm(ByVal Key As String)
        'Noi form len tren cung nhung form da duoc mo======================================================
        If Me.HienForm_Mdichilren_DaCo(Key) = 1 Then
            Exit Sub
        End If

        'Mo form chua duoc chon=============================================================================
        If (StringType.StrCmp(Key, "frmNguoiDung", False) = 0) Then
            Dim frm As New frmNguoiDung
            Me.HienForm_Mdichilren(frm, Key, "Người Dùng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCaDacBiet", False) = 0) Then
            Dim frm As New frmCaDacBiet
            Me.HienForm_Mdichilren(frm, Key, "Ca Đặc Biệt")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChamcongMain", False) = 0) Then
            Dim frm As New frmChamcongMain
            Me.HienForm_Mdichilren(frm, Key, "Chấm Công Máy")
            ' them moi ngay 25 thang 11 nam 2020
        ElseIf (StringType.StrCmp(Key, "frmdangnhaplai", False) = 0) Then
            DangNhapLai()
        ElseIf (StringType.StrCmp(Key, "frmChamCongTay", False) = 0) Then
            Dim frm As New frmChamCongTay
            Me.HienForm_Mdichilren(frm, Key, "Chấm Công")

            '======================================================\\\\\'
        ElseIf (StringType.StrCmp(Key, "frmChamCom", False) = 0) Then
            Dim frm As New frmChamCom
            Me.HienForm_Mdichilren(frm, Key, "Chấm Cơm")
            '======================================================
        ElseIf (StringType.StrCmp(Key, "frmBangCongKhoaSo", False) = 0) Then
            Dim frm As New frmBangCongKhoaSo
            Me.HienForm_Mdichilren(frm, Key, "Bảng công khóa sổ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "FrmThongKeTheomqh", False) = 0) Then
            Dim frm As New FrmThongKeTheomqh
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Theo Mối Quan Hệ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhamBenhNgheNghiep", False) = 0) Then
            Dim frm As New frmKhamBenhNgheNghiep
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Bệnh Nghề Nghiệp")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhuNuMangThai_KThai", False) = 0) Then
            Dim frm As New frmPhuNuMangThai_KThai
            Me.HienForm_Mdichilren(frm, Key, "Phụ Nữ Mang Thai Khám Thai")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhuNuMangThaiKThaiYte", False) = 0) Then
            Dim frm As New frmPhuNuMangThaiKThaiYte
            Me.HienForm_Mdichilren(frm, Key, "Theo dõi lao động nữ mang thai")
            '===============================================================================
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhuNuHanhKinh", False) = 0) Then
            Dim frm As New frmPhuNuHanhKinh
            Me.HienForm_Mdichilren(frm, Key, "Theo dõi lao động nữ nghỉ hành kinh")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTheodoiNVNghiTS", False) = 0) Then
            Dim frm As New frmTheodoiNVNghiTS
            Me.HienForm_Mdichilren(frm, Key, "Theo Dõi Nhân Viên Nghỉ Thai Sản")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCNNghiKhongPhepTheoThang", False) = 0) Then
            Dim frm As New frmDanhSachCNNghiKhongPhepTheoThang
            Me.HienForm_Mdichilren(frm, Key, "Danh Sách Công Nhân Viên Nghỉ Không Phép Theo Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBaoCaoTongHop", False) = 0) Then
            Dim frm As New frmBaoCaoTongHop
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo tổng hợp")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachThongKeNgayCong", False) = 0) Then
            Dim frm As New frmDanhSachThongKeNgayCong
            Me.HienForm_Mdichilren(frm, Key, "Danh sách thống kê ngày công")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinhLuong", False) = 0) Then
            Dim frm As New frmTinhLuong
            Me.HienForm_Mdichilren(frm, Key, "Tính Lương Ngoài Giờ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinhLuong13", False) = 0) Then
            Dim frm As New frmTinhLuong13
            Me.HienForm_Mdichilren(frm, Key, "Tính Thưởng Tháng 13")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTienVuotSanLuong", False) = 0) Then
            Dim frm As New frmTienVuotSanLuong
            Me.HienForm_Mdichilren(frm, Key, "Tiền Vượt Sản Lượng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapnhatMSTSTK", False) = 0) Then
            Dim frm As New frmCapnhatMSTSTK
            Me.HienForm_Mdichilren(frm, Key, "Cập nhật mã số thuế, số tài khoản")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatNVNgoaiNguPhienDich", False) = 0) Then
            Dim frm As New frmCapNhatNVNgoaiNguPhienDich
            Me.HienForm_Mdichilren(frm, Key, "Cập nhật nhân viên ngoại ngữ - phiên dịch")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhenThuong", False) = 0) Then
            Dim frm As New frmKhenThuong
            Me.HienForm_Mdichilren(frm, Key, "Quá Trình Khen Thưởng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinhLuongChinh", False) = 0) Then
            Dim frm As New frmTinhLuongChinh
            Me.HienForm_Mdichilren(frm, Key, "Tính Lương Chính")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinhLuongChinh_BangGop", False) = 0) Then
            Dim frm As New frmTinhLuongChinh_BangGop
            Me.HienForm_Mdichilren(frm, Key, "Tính Lương Chính (Bảng Gộp)")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTraCuuNhanhNV", False) = 0) Then
            Dim frm As New frmTraCuuNhanhNV
            Me.HienForm_Mdichilren(frm, Key, "Tra cứu")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatHoSoNhanSu", False) = 0) Then
            Dim frm As New frmCapNhatHoSoNhanSu
            Me.HienForm_Mdichilren(frm, Key, "Cập Nhật Hồ Sơ Nhân Sự")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatHoSoQuanHe", False) = 0) Then
            Dim frm As New frmCapNhatHoSoQuanHe
            Me.HienForm_Mdichilren(frm, Key, "Cập Nhật Hồ Sơ Nhân Viên Quan Hệ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmMayChamCong", False) = 0) Then
            Dim frm As New frmMayChamCong
            Me.HienForm_Mdichilren(frm, Key, "Máy Quẹt Thẻ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChuyenDonVi", False) = 0) Then
            Dim frm As New frmChuyenDonVi
            Me.HienForm_Mdichilren(frm, Key, "Cập Nhật Chuyển Đơn Vị")

        ElseIf (StringType.StrCmp(Key, "frmChuyenDVExcell", False) = 0) Then
            Dim frm As New frmChuyenDVExcell
            Me.HienForm_Mdichilren(frm, Key, "Chuyển đơn vị trong Excel")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmLyLichNhanVien", False) = 0) Then
            Dim frm As New frmLyLichNhanVien
            Me.HienForm_Mdichilren(frm, Key, "Lý lịch nhân viên")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTheoDoiLuongBB_NVTV", False) = 0) Then
            Dim frm As New frmTheoDoiLuongBB_NVTV
            Me.HienForm_Mdichilren(frm, Key, "Theo Dõi Lương , Bình Bầu CNV Thôi Việc")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBinhBauThang", False) = 0) Then
            Dim frm As New frmBinhBauThang
            Me.HienForm_Mdichilren(frm, Key, "Bình bầu tháng")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKyHDSau1Thang", False) = 0) Then
            Dim frm As New frmKyHDSau1Thang
            Me.HienForm_Mdichilren(frm, Key, "Ký Hợp Đồng Lao Động Sau 1 Tháng")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBinhBauNam_", False) = 0) Then
            Dim frm As New frmBinhBauNam_
            Me.HienForm_Mdichilren(frm, Key, "Bình bầu năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTieuChuan_", False) = 0) Then
            Dim frm As New frmTieuChuan_
            Me.HienForm_Mdichilren(frm, Key, "Xếp loại tiêu chuẩn")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTangLuongThang2", False) = 0) Then
            Dim frm As New frmTangLuongThang2
            Me.HienForm_Mdichilren(frm, Key, "Tăng lương tháng 2")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTheoDoiMangThaiDenNC12Thang", False) = 0) Then
            Dim frm As New frmTheoDoiMangThaiDenNC12Thang
            Me.HienForm_Mdichilren(frm, Key, "Theo dõi mang thai đến 12 tháng")

            '============================================================================hơp===
        ElseIf (StringType.StrCmp(Key, "frmThongKeDanhSachCanBo", False) = 0) Then
            Dim frm As New frmThongKeDanhSachCanBo
            Me.HienForm_Mdichilren(frm, Key, "Thống kê danh sách cán bộ theo công việc")

            '============================================================================hơp===
        ElseIf (StringType.StrCmp(Key, "frmBinhBauChucVu", False) = 0) Then
            Dim frm As New frmBinhBauChucVu
            Me.HienForm_Mdichilren(frm, Key, "Bình bầu chức vụ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBinhBauA", False) = 0) Then
            Dim frm As New frmBinhBauA
            Me.HienForm_Mdichilren(frm, Key, "Bình bầu cuối năm")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhMucQLMTCV_PTCV", False) = 0) Then
            Dim frm As New frmDanhMucQLMTCV_PTCV
            Me.HienForm_Mdichilren(frm, Key, "Danh mục nhóm MTCV_PTCV")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKinhNghiemLamViec", False) = 0) Then
            Dim frm As New frmKinhNghiemLamViec
            Me.HienForm_Mdichilren(frm, Key, "Kinh nghiệm làm việc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatNhomCV_MTCV_PTCV", False) = 0) Then
            Dim frm As New frmCapNhatNhomCV_MTCV_PTCV
            Me.HienForm_Mdichilren(frm, Key, "Cập nhật nhóm công việc MTCV_PTCV")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGioVaoRa", False) = 0) Then
            Dim frm As New frmGioVaoRa
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo giờ vào ra")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmVangMat", False) = 0) Then
            Dim frm As New frmVangMat
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo danh sách vắng mặt")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmVeSom", False) = 0) Then
            Dim frm As New frmVeSom
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo danh sách về sớm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDiTre", False) = 0) Then
            Dim frm As New frmDiTre
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo danh sách đi trễ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKyNang", False) = 0) Then
            Dim frm As New frmKyNang
            Me.HienForm_Mdichilren(frm, Key, "Kỹ năng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChungChiK", False) = 0) Then
            Dim frm As New frmChungChiK
            Me.HienForm_Mdichilren(frm, Key, "Chứng chỉ khác")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDSCNVKhongQuetTheVaoRa", False) = 0) Then
            Dim frm As New frmDSCNVKhongQuetTheVaoRa
            Me.HienForm_Mdichilren(frm, Key, "Danh sách CB_CNV không quét thẻ vào ra")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThoiViec", False) = 0) Then
            Dim frm As New frmThoiViec
            Me.HienForm_Mdichilren(frm, Key, "Thôi Việc")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTieuChiSanLoc", False) = 0) Then
            Dim frm As New frmTieuChiSanLoc
            Me.HienForm_Mdichilren(frm, Key, "Tiêu Chí Sàn Lọc")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCBCNV_VayVonNganHang", False) = 0) Then
            Dim frm As New frmCBCNV_VayVonNganHang
            Me.HienForm_Mdichilren(frm, Key, "Vay vốn ngân hàng")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeLuongTTGT", False) = 0) Then
            Dim frm As New frmThongKeLuongTTGT
            Me.HienForm_Mdichilren(frm, Key, "Thống kê lương công nhân trực tiếp và gián tiếp")



            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKePhepThang", False) = 0) Then
            Dim frm As New frmThongKePhepThang
            Me.HienForm_Mdichilren(frm, Key, "Thống kê phép tháng")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachNVChuaCoThe", False) = 0) Then
            Dim frm As New frmDanhSachNVChuaCoThe
            Me.HienForm_Mdichilren(frm, Key, "Báo cáo danh sách chưa có thẻ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNuoiConDuoi6Tuoi", False) = 0) Then
            Dim frm As New frmNuoiConDuoi6Tuoi
            Me.HienForm_Mdichilren(frm, Key, "Trợ cấp nuôi con nhỏ dưới 6 tuổi")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatNhaXuong", False) = 0) Then
            Dim frm As New frmCapNhatNhaXuong
            Me.HienForm_Mdichilren(frm, Key, "Cập Nhật Đơn Vị Nhà Xưởng")

            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmThaiThangThu7", False) = 0) Then
            '    Dim frm As New frmThaiThangThu7
            '    Me.HienForm_Mdichilren(frm, Key, "Nhân Viên Mang Thai Trên 7 Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDaoTao", False) = 0) Then
            Dim frm As New frmDaoTao
            Me.HienForm_Mdichilren(frm, Key, "Quá Trình Đào Tạo")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCongTac", False) = 0) Then
            Dim frm As New frmCongTac
            Me.HienForm_Mdichilren(frm, Key, "Quá Trình Công Tác")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmQuaTrinhDieuDong", False) = 0) Then
            Dim frm As New frmQuaTrinhDieuDong
            Me.HienForm_Mdichilren(frm, Key, "Quá Trình Điều Động Nhân Viên")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDiemDanhHangNgay", False) = 0) Then
            Dim frm As New frmDiemDanhHangNgay
            Me.HienForm_Mdichilren(frm, Key, "Điểm Danh Hằng Ngày")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmHDLD", False) = 0) Then
            Dim frm As New frmHDLD
            Me.HienForm_Mdichilren(frm, Key, "Hợp Đồng Lao Động")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frm_nghiop", False) = 0) Then
            Dim frm As New frm_nghiop
            Me.HienForm_Mdichilren(frm, Key, "Nhân viên nghỉ không phép(O) trong tháng")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKiemTraCMND", False) = 0) Then
            Dim frm As New frmKiemTraCMND
            Me.HienForm_Mdichilren(frm, Key, "Kiểm Tra Số CMND")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBangThongKeKyLuat", False) = 0) Then
            Dim frm As New frmBangThongKeKyLuat
            Me.HienForm_Mdichilren(frm, Key, "Bảng Thống Kê Kỷ Luật")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChuaKyHDLD", False) = 0) Then
            Dim frm As New frmChuaKyHDLD
            Me.HienForm_Mdichilren(frm, Key, "Chưa Ký Hợp Đồng Lao Động")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeHD", False) = 0) Then
            Dim frm As New frmThongKeHD
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Hợp Đồng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "TongSoNguoi", False) = 0) Then
            Dim frm As New TongSoNguoi
            Me.HienForm_Mdichilren(frm, Key, "Tổng Số Người Trong Đơn Vị Theo Bảng Điểm Danh")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmBaocaochitietgiocong", False) = 0) Then
            '    Dim frm As New frmBaocaochitietgiocong
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Chi Tiết Giờ Công")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmBaocaogioconghangngay", False) = 0) Then
            '    Dim frm As New frmBaocaogioconghangngay
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giờ Công Theo Đơn Vị")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmBaocaogiocongxuong", False) = 0) Then
            '    Dim frm As New frmBaocaogiocongxuong
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giờ Công Bảng Tổng Theo Xưởng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGiotangcathang", False) = 0) Then
            Dim frm As New frmGiotangcathang
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giờ Tăng Ca Toàn Công Ty Năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCTKhacThuong_Ngay", False) = 0) Then
            Dim frm As New frmCTKhacThuong_Ngay
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Chi Tiết Giờ Công Khác Thường Ngày")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhacThuongTuan", False) = 0) Then
            Dim frm As New frmKhacThuongTuan
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Chi Tiết Giờ Công Khác Thường Tuần")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGioCongVuotQua_Thang", False) = 0) Then
            Dim frm As New frmGioCongVuotQua_Thang
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giờ Công Vượt Quá Trong Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTieuchuan", False) = 0) Then
            Dim frm As New frmTieuChuan_
            Me.HienForm_Mdichilren(frm, Key, "Xếp Loại Tiêu Chuẩn")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhepNam", False) = 0) Then
            Dim frm As New frmPhepNam
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Phép Năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGioCongTieuChuanThang", False) = 0) Then
            Dim frm As New frmGioCongTieuChuanThang
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giờ Công Tiêu Chuẩn Theo Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeNghiPhep", False) = 0) Then
            Dim frm As New frmThongKeNghiPhep
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Nghỉ Phép")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDocHaiNangNhoc", False) = 0) Then
            Dim frm As New frmDocHaiNangNhoc
            Me.HienForm_Mdichilren(frm, Key, "Công Nhân Sản Xuất Thuộc Loại Độc Hại Nặng Nhọc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCongViec", False) = 0) Then
            Dim frm As New frmDanhSachCongViec
            Me.HienForm_Mdichilren(frm, Key, "Danh Sách Phiên Dịch - Cán Bộ - CB_CNV Ký HDLD")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDSCNKhongNghi", False) = 0) Then
            Dim frm As New frmDSCNKhongNghi
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê DSCN Không Nghỉ Phép Trong Năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBaoCaoGioVaoRa", False) = 0) Then
            Dim frm As New frmBaoCaoGioVaoRa
            Me.HienForm_Mdichilren(frm, Key, "Báo Cáo Giờ Vào Ra")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTongHopComThang", False) = 0) Then
            Dim frm As New frmTongHopComThang
            Me.HienForm_Mdichilren(frm, Key, "Tổng Hợp Cơm Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNhanVienKyLuatNghiKhongPhep", False) = 0) Then
            Dim frm As New frmNhanVienKyLuatNghiKhongPhep
            Me.HienForm_Mdichilren(frm, Key, "Nhân Viên Nghĩ Không Phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeDanhSachCB_CNVBiKyLuat", False) = 0) Then
            Dim frm As New frmThongKeDanhSachCB_CNVBiKyLuat
            Me.HienForm_Mdichilren(frm, Key, "Danh Sách CB-CNV Bị Kỷ Luật")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhamSK", False) = 0) Then
            Dim frm As New frmKhamSK
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Khám Sức Khỏe")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmQTSaiQuiDinh", False) = 0) Then
            Dim frm As New frmQTSaiQuiDinh
            Me.HienForm_Mdichilren(frm, Key, "Quẹt Thẻ Sai Qui Định Bảng Chi Tiết")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmQTSaiQuiDinhBangTong", False) = 0) Then
            Dim frm As New frmQTSaiQuiDinhBangTong
            Me.HienForm_Mdichilren(frm, Key, "Quẹt Thẻ Sai Qui Định Bảng Tổng")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmQTKhacThuongLC_Thang", False) = 0) Then
            '    Dim frm As New frmQTKhacThuongLC_Thang
            '    Me.HienForm_Mdichilren(frm, Key, "Quẹt Thẻ Sao Qui Định Bảng Tổng Tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKiemTraPhepNam", False) = 0) Then
            Dim frm As New frmKiemTraPhepNam
            Me.HienForm_Mdichilren(frm, Key, "Nghỉ Phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmSoNguoiTrongCongTy", False) = 0) Then
            Dim frm As New frmSoNguoiTrongCongTy
            Me.HienForm_Mdichilren(frm, Key, "Kiểm Tra Số Người Trong Công Ty")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanToc", False) = 0) Then
            Dim frm As New frmDanToc
            Me.HienForm_Mdichilren(frm, Key, "Dân Tộc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmQuocTich", False) = 0) Then
            Dim frm As New frmQuocTich
            Me.HienForm_Mdichilren(frm, Key, "Quốc Tịch")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinhThanh", False) = 0) Then
            Dim frm As New frmTinhThanh
            Me.HienForm_Mdichilren(frm, Key, "Tỉnh Thành")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTonGiao", False) = 0) Then
            Dim frm As New frmTonGiao
            Me.HienForm_Mdichilren(frm, Key, "Tôn Giáo")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChuyenMon", False) = 0) Then
            Dim frm As New frmChuyenMon
            Me.HienForm_Mdichilren(frm, Key, "Trình Độ Chuyên Môn")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNgoaiNgu", False) = 0) Then
            Dim frm As New frmNgoaiNgu
            Me.HienForm_Mdichilren(frm, Key, "Trình Độ Ngoại Ngữ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTinHoc", False) = 0) Then
            Dim frm As New frmTinHoc
            Me.HienForm_Mdichilren(frm, Key, "Trình Độ Tin Học")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmLoaiThoiViec", False) = 0) Then
            Dim frm As New frmLoaiThoiViec
            Me.HienForm_Mdichilren(frm, Key, "Loại Thôi Việc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNghiPhep", False) = 0) Then
            Dim frm As New frmNghiPhep
            Me.HienForm_Mdichilren(frm, Key, "Loại Nghỉ Phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmLoaiBinhBau", False) = 0) Then
            Dim frm As New frmLoaiBinhBau
            Me.HienForm_Mdichilren(frm, Key, "Loại Bình Bầu")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKyLuat", False) = 0) Then
            Dim frm As New frmKyLuat
            Me.HienForm_Mdichilren(frm, Key, "Kỷ Luật")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNguyenNhanKyLuat", False) = 0) Then
            Dim frm As New frmNguyenNhanKyLuat
            Me.HienForm_Mdichilren(frm, Key, "Nguyên Nhân Kỷ Luật")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmLoaiHopDong", False) = 0) Then
            Dim frm As New frmLoaiHopDong
            Me.HienForm_Mdichilren(frm, Key, "Loại Hợp Đồng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChucVuDM", False) = 0) Then
            Dim frm As New frmChucVuDM
            Me.HienForm_Mdichilren(frm, Key, "Chức Vụ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCongViec", False) = 0) Then
            Dim frm As New frmCongViec
            Me.HienForm_Mdichilren(frm, Key, "Công Việc")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmGioiTinh", False) = 0) Then
            '    Dim frm As New frmGioiTinh
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Giới Tính")
            '    '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmHocVan", False) = 0) Then
            '    Dim frm As New frmHocVan
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Học Vấn")
            '    '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmKhuVuc", False) = 0) Then
            '    Dim frm As New frmKhuVuc
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Khu Vực")
            '    '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmThamNien", False) = 0) Then
            '    Dim frm As New frmThamNien
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Thâm Niên")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCNNghiKPTheoNam", False) = 0) Then
            Dim frm As New frmDanhSachCNNghiKPTheoNam
            Me.HienForm_Mdichilren(frm, Key, "Danh Sách CN Nghĩ Không Phép Theo Năm")

            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmTuoi", False) = 0) Then
            '    Dim frm As New frmTuoi
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Tuổi")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCaLamViec", False) = 0) Then
            Dim frm As New frmCaLamViec
            Me.HienForm_Mdichilren(frm, Key, "Ca Làm Việc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmNgayLe", False) = 0) Then
            Dim frm As New frmNgayLe
            Me.HienForm_Mdichilren(frm, Key, "Ngày lễ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmHocVanDM", False) = 0) Then
            Dim frm As New frmHocVanDM
            Me.HienForm_Mdichilren(frm, Key, "Trình Độ Học Vấn")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmChucVu", False) = 0) Then
            '    Dim frm As New frmChucVu
            '    Me.HienForm_Mdichilren(frm, Key, "Thống Kê Chức Vụ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhenThuongDM", False) = 0) Then
            Dim frm As New frmKhenThuongDM
            Me.HienForm_Mdichilren(frm, Key, "Khen Thưởng")
            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmDieuChinhLuong", False) = 0) Then
            '    Dim frm As New frmDieuChinhLuong
            '    Me.HienForm_Mdichilren(frm, Key, "Điều Chỉnh Lương")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDBLuong", False) = 0) Then
            Dim frm As New frmDBLuong
            Me.HienForm_Mdichilren(frm, Key, "Diễn Biến Lương")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDSCongNhanMay", False) = 0) Then
            Dim frm As New frmDSCongNhanMay
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Danh Sách Công Nhân May")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCongViecNNDH", False) = 0) Then
            Dim frm As New frmCongViecNNDH
            Me.HienForm_Mdichilren(frm, Key, "Theo Dõi Công Việc Nặng Nhọc Độc Hại")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "ThoiViecKhongThamGiaBHTN", False) = 0) Then
            Dim frm As New ThoiViecKhongThamGiaBHTN
            Me.HienForm_Mdichilren(frm, Key, "Tính trợ cấp thôi việc")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhepNamConLai", False) = 0) Then
            Dim frm As New frmPhepNamConLai
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Phép Năm Còn Lại")

            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmLuongThang", False) = 0) Then
            '    Dim frm As New frmLuongThang
            '    Me.HienForm_Mdichilren(frm, Key, "Lương tháng 1, 2")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmChuyenDV", False) = 0) Then
            Dim frm As New frmChuyenDV
            Me.HienForm_Mdichilren(frm, Key, "Chuyển Đơn Vị")

            '===============================================================================
            'ElseIf (StringType.StrCmp(Key, "frmTKCongViecHDLD", False) = 0) Then
            '    Dim frm As New frmTKCongViecHDLD
            '    Me.HienForm_Mdichilren(frm, Key, "Thống kê công việc HDLD")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBaoCaoGioCongNgay", False) = 0) Then
            Dim frm As New frmBaoCaoGioCongNgay
            Me.HienForm_Mdichilren(frm, Key, "Thống kê giờ công tuần")
            '=============================================================================== 
        ElseIf (StringType.StrCmp(Key, "FrmBaoCaoSLTongPhanComCuoiThang", False) = 0) Then
            Dim frm As New FrmBaoCaoSLTongPhanComCuoiThang
            Me.HienForm_New(frm, Key, "Báo cáo số lượng tổng phần cơm cuối tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDienBienLuong", False) = 0) Then
            Dim frm As New frmDienBienLuong
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Diễn Biến Lương")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDBLPromaz", False) = 0) Then
            Dim frm As New frmDBLPromaz
            Me.HienForm_Mdichilren(frm, Key, "Diễn Biến Lương Promaz")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhoaSoLuong", False) = 0) Then
            Dim frm As New frmKhoaSoLuong
            Me.HienForm_Mdichilren(frm, Key, "Khóa Sổ Lương")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTamUng", False) = 0) Then
            Dim frm As New frmTamUng
            Me.HienForm_Mdichilren(frm, Key, "Tạm Ứng")
        ElseIf (StringType.StrCmp(Key, "frmXinDiKhamBenh", False) = 0) Then
            Dim frm As New frmXinDiKhamBenh
            Me.HienForm_Mdichilren(frm, Key, "Xin đi khám chữa bệnh")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThueTNCN", False) = 0) Then
            Dim frm As New frmThueTNCN
            Me.HienForm_Mdichilren(frm, Key, "Thuế TNCN")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmHieuChinhLuong", False) = 0) Then
            Dim frm As New frmHieuChinhLuong
            Me.HienForm_Mdichilren(frm, Key, "Hiệu Chỉnh Lương")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhoanCongKhac", False) = 0) Then
            Dim frm As New frmKhoanCongKhac
            Me.HienForm_Mdichilren(frm, Key, "Khoản Cộng Khác")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhoanTruKhac", False) = 0) Then
            Dim frm As New frmKhoanTruKhac
            Me.HienForm_Mdichilren(frm, Key, "Khoản Trừ Khác")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThuongABC", False) = 0) Then
            Dim frm As New frmThuongABC
            Me.HienForm_Mdichilren(frm, Key, "Tiền Thưởng ABC")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhongHuongPC", False) = 0) Then
            Dim frm As New frmKhongHuongPC
            Me.HienForm_Mdichilren(frm, Key, "CB.CNV Không hưởng phụ cấp")


            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmPhuCapKhac", False) = 0) Then
            Dim frm As New frmPhuCapKhac
            Me.HienForm_Mdichilren(frm, Key, "Phụ Cấp Khác")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeCN_TT_GT", False) = 0) Then
            Dim frm As New frmThongKeCN_TT_GT
            Me.HienForm_Mdichilren(frm, Key, "Thống Kê Công Nhân Làm Việc Trực Tiếp Và Gián Tiếp")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmXaPhuong", False) = 0) Then
            Dim frm As New frmXaPhuong
            Me.HienForm_Mdichilren(frm, Key, "Xã Phường")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmquanhuyen", False) = 0) Then
            Dim frm As New frmquanhuyen
            Me.HienForm_Mdichilren(frm, Key, "Quận Huyện")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCapNhatSoSoBH", False) = 0) Then
            Dim frm As New frmCapNhatSoSoBH
            Me.HienForm_Mdichilren(frm, Key, "Cập nhật số sổ bảo hiểm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmKhoanTruMobivi", False) = 0) Then
            Dim frm As New frmKhoanTruMobivi
            Me.HienForm_Mdichilren(frm, Key, "Khoản thu Mobivi")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "ThamGiaBHXH", False) = 0) Then
            Dim frm As New ThamGiaBHXH
            Me.HienForm_New(frm, Key, "Tham gia BHXH")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTraCuuThongTinThamGiaBH", False) = 0) Then
            Dim frm As New frmTraCuuThongTinThamGiaBH
            Me.HienForm_Mdichilren(frm, Key, "Tra cứu thông tin để tham gia BHXH-BHYT")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmCamKetCaNhanChuaDenMucChiuThue", False) = 0) Then
            Dim frm As New frmCamKetCaNhanChuaDenMucChiuThue
            Me.HienForm_Mdichilren(frm, Key, "Bảng Cam Kết Thu Nhập Chưa Đến Mức Chịu Thuế")
            '===============================================================================

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmToKhaiThue", False) = 0) Then
            Dim frm As New frmtokhaithue
            Me.HienForm_Mdichilren(frm, Key, "Tờ Khai Thuế")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmQuyetdinhTV", False) = 0) Then
            Dim frm As New frmQuyetdinhTV
            Me.HienForm_Mdichilren(frm, Key, "Quyết định thôi việc")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmcapnhatqdtv", False) = 0) Then
            Dim frm As New frmcapnhatqdtv
            Me.HienForm_Mdichilren(frm, Key, "Cập nhật quyết định thôi việc")

            '===============================================================================

        ElseIf (StringType.StrCmp(Key, "frmBangTheoDoiNgayPhepCuaCBCNV", False) = 0) Then
            Dim frm As New frmBangTheoDoiNgayPhepCuaCBCNV
            Me.HienForm_New(frm, Key, "Bảng Theo Dõi Ngày Phép Của CB-CNV")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCBCNVDonVi", False) = 0) Then
            Dim frm As New frmDanhSachCBCNVDonVi
            Me.HienForm_New(frm, Key, "Danh Sách CBCNV")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeSoNgayNghi", False) = 0) Then
            Dim frm As New frmThongKeSoNgayNghi
            Me.HienForm_New(frm, Key, "Thống Kê Số Ngày Nghỉ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeSoNgayNghiDonVi", False) = 0) Then
            Dim frm As New frmThongKeSoNgayNghiDonVi
            Me.HienForm_New(frm, Key, "Thống Kê Số Ngày Nghỉ Đơn Vị")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmReportHDLD", False) = 0) Then
            Dim frm As New frmReportHDLD
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Ký Hợp Đồng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeTheoTinhThanhVaDoTuoi", False) = 0) Then
            Dim frm As New frmThongKeTheoTinhThanhVaDoTuoi
            Me.HienForm_New(frm, Key, "Thống Kê Theo Tỉnh Thành Và Độ Tuổi")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBaoCaoMucLuong", False) = 0) Then
            Dim frm As New frmBaoCaoMucLuong
            Me.HienForm_New(frm, Key, "Báo Cáo Mức Lương CB-CNV")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCBCNVTheoChucVu", False) = 0) Then
            Dim frm As New frmDanhSachCBCNVTheoChucVu
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Theo Chức Vụ")


        ElseIf (StringType.StrCmp(Key, "frmDanhSachCB_CNVBinhBauNam", False) = 0) Then
            Dim frm As New frmDanhSachCB_CNVBinhBauNam
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Bình Bầu Năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachNhanVienTrungTuyen", False) = 0) Then
            Dim frm As New frmDanhSachNhanVienTrungTuyen
            Me.HienForm_New(frm, Key, "Danh Sách Nhân Viên Trúng Tuyển")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachNhanVienTheoTrinhDo", False) = 0) Then
            Dim frm As New frmDanhSachNhanVienTheoTrinhDo
            Me.HienForm_New(frm, Key, "Danh Sách Nhân Viên Theo Trình Độ")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachNhanVienThoiViec", False) = 0) Then
            Dim frm As New frmDanhSachNhanVienThoiViec
            Me.HienForm_New(frm, Key, "Danh Sách Nhân Viên Thôi Việc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCBCNVChuyenDonVi", False) = 0) Then
            Dim frm As New frmDanhSachCBCNVChuyenDonVi
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Chuyển Đơn Vị")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCBCNVNghiPhep", False) = 0) Then
            Dim frm As New frmDanhSachCBCNVNghiPhep
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Nghỉ Phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmSoYeuLyLich", False) = 0) Then
            Dim frm As New frmSoYeuLyLich
            Me.HienForm_New(frm, Key, "Sơ Yếu Lý Lịch CB-CNV")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCBCNVDongBHXH", False) = 0) Then
            Dim frm As New frmDanhSachCBCNVDongBHXH
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Đóng BHXH")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachHetHangHDKyLai", False) = 0) Then
            Dim frm As New frmDanhSachHetHangHDKyLai
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV Hết Hạng HD Ký Lại")

        ElseIf (StringType.StrCmp(Key, "frmDSLaoDongNghiKhongPhep", False) = 0) Then
            Dim frm As New frmGioCongTieuChuanThang
            Me.HienForm_New(frm, Key, "Danh Sách Lao Động Nghỉ Không Phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTheoDoiTienDoThucHienKyLuat", False) = 0) Then
            Dim frm As New frmTheoDoiTienDoThucHienKyLuat
            Me.HienForm_New(frm, Key, "Theo dõi tiến độ thực hiện kỷ luật")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeNguyenNhanKyLuat", False) = 0) Then
            Dim frm As New frmThongKeNguyenNhanKyLuat
            Me.HienForm_New(frm, Key, "Thống kê nguyên nhân kỷ luật")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmSoLuongKyLuat", False) = 0) Then
            Dim frm As New frmSoLuongKyLuat
            Me.HienForm_New(frm, Key, "Số lượng kỷ luật")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongkecongnhandilamvangmat", False) = 0) Then
            Dim frm As New frmThongkecongnhandilamvangmat
            Me.HienForm_Mdichilren(frm, Key, "Thống kê công nhân đi làm và vắng mặt")



            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmDanhSachCB_CNVhethanHDLD", False) = 0) Then
            Dim frm As New frmDanhSachCB_CNVhethanHDLD
            Me.HienForm_New(frm, Key, "Danh Sách CB-CNV hết hạn hợp động")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeTinhHinhNghiViec", False) = 0) Then
            Dim frm As New frmThongKeTinhHinhNghiViec
            Me.HienForm_New(frm, Key, "Thống Kê Tình Hình Nghỉ Việc")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeSoNgayNghiOMCOTrongNam", False) = 0) Then
            Dim frm As New frmThongKeSoNgayNghiOMCOTrongNam
            Me.HienForm_New(frm, Key, "Thống kê số ngày nghỉ ốm-con ốm trong năm")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGioCongTieuChuanThang_", False) = 0) Then
            Dim frm As New frmGioCongTieuChuanThang
            Me.HienForm_Mdichilren(frm, Key, "Thống kê giờ công tiêu chuẩn theo tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeGioTangCaNam", False) = 0) Then
            Dim frm As New frmThongKeGioTangCaNam
            Me.HienForm_New(frm, Key, "Thống kê giờ tăng ca toàn công ty")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKePNMTTheoThang", False) = 0) Then
            Dim frm As New frmThongKePNMTTheoThang
            Me.HienForm_Mdichilren(frm, Key, "Thống kê phụ nữ mang thai theo tháng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeGioTangCaXuongNam", False) = 0) Then
            Dim frm As New frmThongKeGioTangCaXuongNam
            Me.HienForm_Mdichilren(frm, Key, "Thống kê tổng giờ tăng ca các xưởng")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmGioCongHangNgayDonVi", False) = 0) Then
            Dim frm As New frmGioCongHangNgayDonVi
            Me.HienForm_Mdichilren(frm, Key, "Giờ công hằng ngày đơn vị")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeCoCongCoPhep", False) = 0) Then
            Dim frm As New frmThongKeCoCongCoPhep
            Me.HienForm_Mdichilren(frm, Key, "Thống kê có công có phép")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeTroCapThoRap", False) = 0) Then
            Dim frm As New frmThongKeTroCapThoRap
            Me.HienForm_Mdichilren(frm, Key, "Thống kê thợ rập - mức tay nghề")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeTroCapUDMay", False) = 0) Then
            Dim frm As New frmThongKeTroCapUDMay
            Me.HienForm_Mdichilren(frm, Key, "Thống kê công nhân may - mức tay nghề")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmTKSOLUONGKYHDLD", False) = 0) Then
            Dim frm As New frmTKSOLUONGKYHDLD
            Me.HienForm_Mdichilren(frm, Key, "Thống kê Thời hạn HĐ - ThamGia BH")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeSoLaoDongDangNCNho", False) = 0) Then
            Dim frm As New frmThongKeSoLaoDongDangNCNho
            Me.HienForm_Mdichilren(frm, Key, "Thống kê lao động đang nuôi con nhỏ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeDanhSachCanBoThang", False) = 0) Then
            Dim frm As New frmThongKeDanhSachCanBoThang
            Me.HienForm_Mdichilren(frm, Key, "Thống kê cán bộ")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeTroCapNgoaiNgu", False) = 0) Then
            Dim frm As New frmThongKeTroCapNgoaiNgu
            Me.HienForm_Mdichilren(frm, Key, "Thống kê phiên dịch")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmThongKeSLCVNNHD", False) = 0) Then
            Dim frm As New frmThongKeSLCVNNHD
            Me.HienForm_Mdichilren(frm, Key, "Thống kê số lượng CV NHĐH")

            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "frmBCGioCongTieuChuanThang", False) = 0) Then
            Dim frm As New frmBCGioCongTieuChuanThang
            Me.HienForm_Mdichilren(frm, Key, "Thống kê giờ công tiêu chuẩn adidas")
            '===============================================================================

        ElseIf (StringType.StrCmp(Key, "frmCapNhatKhamChuaBenh", False) = 0) Then
            Dim frm As New frmCapNhatKhamChuaBenh
            Me.HienForm_Mdichilren(frm, Key, "Cập Nhật Khám Chữa Bệnh")
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "Anh", False) = 0) Then
            Lang = "en-US"
            setCulture(Lang)
        ElseIf (StringType.StrCmp(Key, "Viet", False) = 0) Then
            Lang = "vi-VN"
            setCulture(Lang)
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "btLuilai", False) = 0) Then
            Me.Lui()
        ElseIf (StringType.StrCmp(Key, "btDitoi", False) = 0) Then
            Me.Ditoi()
        ElseIf (StringType.StrCmp(Key, "btTrangchu", False) = 0) Then
            Me.Trangchu()
            '===============================================================================
        ElseIf (StringType.StrCmp(Key, "mnThoat_activeMdifom", False) = 0) Then
            If Me.MdiChildren.Length > 0 Then
                Me.RemoveItemCb_Form(Me.ActiveMdiChild.Name.ToString())
            Else
                Me.Thoat()
            End If
        ElseIf (StringType.StrCmp(Key, "mnThoat", False) = 0) Then
            Me.Thoat()
        End If
    End Sub
    Dim culture As CultureInfo = CultureInfo.CurrentCulture
    Dim rm As New ResourceManager("TongHop.MyResource", GetType(frmMainMain).Assembly)
    Private Sub setCulture(ByVal cultureName As String)
        On Error Resume Next
        culture = CultureInfo.CreateSpecificCulture(cultureName)
        Dim i As Integer = 0
        While i < UltraToolbarsManager1.Tools.Count
            UltraToolbarsManager1.Tools(i).SharedProps.Caption = rm.GetString(UltraToolbarsManager1.Tools(i).Key.ToString, culture)
            i = i + 1
        End While
        Dim j1 As Integer = 0
        While j1 < UltraExplorerBar1.Groups.Count
            UltraExplorerBar1.Groups.Item(j1).Text = rm.GetString(UltraExplorerBar1.Groups.Item(j1).Key.ToString, culture)
            Dim k As Integer = 0
            While k < UltraExplorerBar1.Groups(j1).Items.Count
                UltraExplorerBar1.Groups.Item(j1).Items(k).Text = rm.GetString(UltraExplorerBar1.Groups.Item(j1).Items(k).Key.ToString, culture)
                k = k + 1
            End While
            j1 = j1 + 1
        End While

    End Sub
    Private Sub Lui()
        Dim index As Integer
        index = Me.cbForm.SelectedIndex
        If index > 0 Then
            Me.cbForm.SelectedIndex = index - 1
        End If
    End Sub

    Private Sub Ditoi()
        Dim index As Integer
        index = Me.cbForm.SelectedIndex
        If index < Me.cbForm.Items.Count - 1 Then
            Me.cbForm.SelectedIndex = index + 1            
        End If
    End Sub

    Private Sub Trangchu()
        If Me.HienForm_Mdichilren_DaCo("frmChamcongMain") = 1 Then
            Exit Sub
        Else
            Dim frm As New frmChamcongMain
            Me.HienForm_Mdichilren(frm, "frmChamcongMain", "Chấm Công Máy")
        End If
        If Me.HienForm_Mdichilren_DaCo("frmChamCongTay") = 1 Then
            Exit Sub
        Else
            Dim frm As New frmChamCongTay
            Me.HienForm_Mdichilren(frm, "frmChamCongTay", "Chấm Công Tay")
        End If
       
    End Sub

    Private Sub Thoat()
        If MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub frmMainMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Application.Exit()
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Me.CallForm(e.Tool.Key.Substring(1).ToString)
    End Sub

    Private Sub UltraExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles UltraExplorerBar1.ItemClick
        Me.CallForm(e.Item.Key.Substring(1).ToString)
    End Sub

    Private Sub cbForm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbForm.ValueChanged
        If Me.MdiChildren.Length > 0 Then
            Dim form As Form
            For Each form In Me.MdiChildren
                If (StringType.StrCmp(form.Name.ToString, Me.cbForm.Value.ToString(), False) = 0) Then
                    form.BringToFront()
                    Me.stbChildForm.Text = "Màn hình: " & Me.cbForm.Text
                    GoTo tt
                End If
            Next
        End If
tt:
        Me.TrangThaiButton_ToiLui()
    End Sub

    Private Sub TrangThaiButton_ToiLui()
        'MessageBox.Show(Me.cbForm.SelectedIndex.ToString)
        If Me.cbForm.Items.Count <= 1 Then
            Me.UltraToolbarsManager1.Tools("1btLuilai").SharedProps.Enabled = False
            Me.UltraToolbarsManager1.Tools("1btDitoi").SharedProps.Enabled = False
        ElseIf Me.cbForm.SelectedIndex > 0 And Me.cbForm.SelectedIndex < Me.cbForm.Items.Count - 1 Then
            Me.UltraToolbarsManager1.Tools("1btLuilai").SharedProps.Enabled = True
            Me.UltraToolbarsManager1.Tools("1btDitoi").SharedProps.Enabled = True
        ElseIf Me.cbForm.SelectedIndex = 0 Then
            Me.UltraToolbarsManager1.Tools("1btLuilai").SharedProps.Enabled = False
            Me.UltraToolbarsManager1.Tools("1btDitoi").SharedProps.Enabled = True
        ElseIf Me.cbForm.SelectedIndex = Me.cbForm.Items.Count - 1 Then
            Me.UltraToolbarsManager1.Tools("1btLuilai").SharedProps.Enabled = True
            Me.UltraToolbarsManager1.Tools("1btDitoi").SharedProps.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.stbTimer.Text = StringType.FromDate(DateAndTime.Now)
        Me.s = StringType.FromInteger(Me.stbLoginTime.Text.IndexOf(":"))
        Me.s = Me.stbLoginTime.Text.Substring(CInt(Math.Round(CDbl((DoubleType.FromString(Me.s) + 1)))))
        Me.stbTime.Text = DateType.FromString(Me.stbTimer.Text).Subtract(DateType.FromString(Me.s)).ToString
    End Sub
    Public s As String

    Private Sub StatusBar1_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar1.PanelClick

    End Sub
End Class
