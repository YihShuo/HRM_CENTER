Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class clsLanguage


    ' Chung
    'Dieu kien loc
    'Tuan
    Public Shared Function Tuan() As String
        Return "Tuần :"
    End Function
    Public Shared Function TuanTaiwan() As String
        Return "星期 :"
    End Function
    'Nam
    Public Shared Function Nam() As String
        Return "Năm :"
    End Function
    Public Shared Function NamTaiwan() As String
        Return "年度 :"
    End Function
    'Ngay
    'Don vi
    Public Shared Function Donvi() As String
        Return "Đơn Vị :"
    End Function
    Public Shared Function DonviTaiwan() As String
        Return "單位 :"
    End Function
    'Nganh
    'Cap nhat
    Public Shared Function CapNhat() As String
        Return "Cập Nhật"
    End Function
    Public Shared Function CapNhatTaiwan() As String
        Return "更新 "
    End Function
    'Xuat E
    Public Shared Function XuatE() As String
        Return "Xuất Excell"
    End Function
    Public Shared Function XuatETaiwan() As String
        Return "Excell"
    End Function


    'Tieu de
    'Thong ke chi tiet gio cong
    Public Shared Function ThongKeChiTietGioCong() As String
        Return "Thống Kê Chi Tiết Giờ Công"
    End Function
    Public Shared Function ThongKeChiTietGioCongTaiwan() As String
        Return "工時明細統計表"
    End Function
    'Thong ke gio cong
    Public Shared Function ThongKeGioCong() As String
        Return "Thống Kê Giờ Công"
    End Function
    Public Shared Function ThongKeGioCongTaiwan() As String
        Return "工時統計表 "
    End Function
    'Thong ke gio cong theo xuong
    Public Shared Function ThongKeGioCongTheoXuong() As String
        Return "Thống Kê Giờ Công Theo Xưởng"
    End Function
    Public Shared Function ThongKeGioCongTheoXuongTaiwan() As String
        Return " 工時統計匯總表"
    End Function
    'Thong ke gio cong theo don vi
    Public Shared Function ThongKeGioCongTheoDonVi() As String
        Return "Thống Kê Giờ Công Theo Đơn Vị"
    End Function
    Public Shared Function ThongKeGioCongTheoDonViTaiwan() As String
        Return "按單位人員工時統計匯總表 "
    End Function
    'Thong ke chi tiet gio cong khac thuong
    Public Shared Function ThongKeChiTietGioCongKhacThuong() As String
        Return "Thống Kê Chi Tiết Giờ Công Khác Thường"
    End Function
    Public Shared Function ThongKeChiTietGioCongKhacThuongTaiwan() As String
        Return "人員工時異常統計明細表  "
    End Function
    'Thong ke gio cong khac thuong
    Public Shared Function ThongKeGioCongKhacThuong() As String
        Return "Thống Kê Giờ Công Khác Thường"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongTaiwan() As String
        Return "人員工時異常統計匯總表  "
    End Function
    'Thong ke gio cong khac thuong theo don vi
    Public Shared Function ThongKeGioCongKhacThuongTheoDV() As String
        Return "Thống Kê Giờ Công Khác Thường Theo Đơn Vị"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongTheoDVTaiwan() As String
        Return "按單位人員工時異常統計匯總表  "
    End Function




    ' Luoi DS
    'danh sach gio cong
    Public Shared Function Danhsachgiocong() As String
        Return "Danh Sách Giờ Công"
    End Function
    Public Shared Function DanhsachgiocongTaiwan() As String
        Return "名單"
    End Function
    'danh sach gio cong vuot qua
    Public Shared Function Danhsachgiocongvuotqua() As String
        Return "Danh Sách Giờ Công Vượt Quá"
    End Function
    Public Shared Function DanhsachgiocongvuotquaTaiwan() As String
        Return "超過名單"
    End Function



    'Report
    '1 Thong ke chi tiet gio cong
    Public Shared Function ThongKeChiTietGioCongNgay() As String
        Return "Thống Kê Chi Tiết Giờ Công Ngày"
    End Function
    Public Shared Function ThongKeChiTietGioCongNgayTaiwan() As String
        Return "越南億春員工工時異常統計明細日報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongTuan() As String
        Return "Thống Kê Chi Tiết Giờ Công Tuần"
    End Function
    Public Shared Function ThongKeChiTietGioCongTuanTaiwan() As String
        Return "越南億春員工工時異常統計明細周報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongThang() As String
        Return "Thống Kê Chi Tiết Giờ Công Tháng"
    End Function
    Public Shared Function ThongKeChiTietGioCongThangTaiwan() As String
        Return "越南億春員工工時異常統計明細月報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongNam() As String
        Return "Thống Kê Chi Tiết Giờ Công Năm"
    End Function
    Public Shared Function ThongKeChiTietGioCongNamTaiwan() As String
        Return "越南億春員工加班工時異常統計明細年報表"
    End Function


    '2 Thong ke chi tiet gio cong khac thuong
    Public Shared Function ThongKeChiTietGioCongKhacThuongNgay() As String
        Return "Thống Kê Chi Tiết Giờ Công Khác Thường Ngày"
    End Function
    Public Shared Function ThongKeChiTietGioCongKhacThuongNgayTaiwan() As String
        Return "越南億春員工工時異常統計明細日報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongKhacThuongTuan() As String
        Return "Thống Kê Chi Tiết Giờ Công Khác Thường Tuần"
    End Function
    Public Shared Function ThongKeChiTietGioCongKhacThuongTuanTaiwan() As String
        Return "越南億春員工工時異常統計明細周報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongKhacThuongThang() As String
        Return "Thống Kê Chi Tiết Giờ Công Khác Thường Tháng"
    End Function
    Public Shared Function ThongKeChiTietGioCongKhacThuongThangTaiwan() As String
        Return "越南億春員工工時異常統計明細月報表"
    End Function

    Public Shared Function ThongKeChiTietGioCongKhacThuongNam() As String
        Return "Thống Kê Chi Tiết Giờ Công Khác Thường Năm"
    End Function
    Public Shared Function ThongKeChiTietGioCongKhacThuongNamTaiwan() As String
        Return "越南億春員工加班工時異常統計明細年報表"
    End Function

    '3 Thong ke gio cong hang ngay cua cac don vi
    Public Shared Function ThongKeGioCongHangNgayTheoDV() As String
        Return "Thống Kê Giờ Công Ngày Theo Đơn Vị"
    End Function
    Public Shared Function ThongKeGioCongHangNgayTheoDVTaiwan() As String
        Return " Chưa biết  "
    End Function



    '4 Thong ke gio cong khac thuong theo don vi
    Public Shared Function ThongKeGioCongKhacThuongNgayDV() As String
        Return "Thống Kê Giờ Công Khác Thường Ngày"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongNgayDVTaiwan() As String
        Return " Chưa biết  "
    End Function

    Public Shared Function ThongKeGioCongKhacThuongTuanDV() As String
        Return "Thống Kê Giờ Công Khác Thường Tuần"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongTuanDVTaiwan() As String
        Return " Chưa biết  "
    End Function

    Public Shared Function ThongKeGioCongKhacThuongThangDV() As String
        Return "Thống Kê Giờ Công Khác Thường Tháng"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongThangDVTaiwan() As String
        Return " Chưa biết  "
    End Function

    Public Shared Function ThongKeGioCongKhacThuongNamDV() As String
        Return "Thống Kê Giờ Công Khác Thường Năm"
    End Function
    Public Shared Function ThongKeGioCongKhacThuongNamDVTaiwan() As String
        Return " Chưa biết  "
    End Function


    '5 Thong ke gio cong theo xuong
    Public Shared Function ThongKeGioCongNgayX() As String
        Return "Thống Kê Giờ Công Ngày"
    End Function
    Public Shared Function ThongKeGioCongNgayXTaiwan() As String
        Return "越南億春員工工時異常統計日匯總表"
    End Function

    Public Shared Function ThongKeGioCongTuanX() As String
        Return "Thống Kê Giờ Công Tuần"
    End Function
    Public Shared Function ThongKeGioCongTuanXTaiwan() As String
        Return "越南億春員工工時異常統計周報表"
    End Function

    Public Shared Function ThongKeGioCongThangX() As String
        Return "Thống Kê Giờ Công Tháng"
    End Function
    Public Shared Function ThongKeGioCongThangXTaiwan() As String
        Return "越南億春員工工時異常統計月匯總表"
    End Function

    Public Shared Function ThongKeGioCongNamX() As String
        Return "Thống Kê Giờ Công Năm"
    End Function
    Public Shared Function ThongKeGioCongNamXTaiwan() As String
        Return "越南億春員工加班工時統計年報表"
    End Function

    Public Shared Function TongQuat() As String
        Return " Tổng Quát"
    End Function

    Public Shared Function TongQuatTaiwan() As String
        Return " 全部"
    End Function

    Public Shared Function QT_Truoc7h() As String
        Return " Quẹt thẻ trước 7h"
    End Function

    Public Shared Function QT_Truoc7hTaiwan() As String
        Return " 提前刷卡"
    End Function

    Public Shared Function QT_Tre7h30() As String
        Return " Quẹt thẻ trễ 7h30'"
    End Function

    Public Shared Function QT_Tre7h30Taiwan() As String
        Return " 遲到刷卡"
    End Function

    Public Shared Function Ngay() As String
        Return "Chọn Ngày"
    End Function

    Public Shared Function NgayTaiwan() As String
        Return " 挑選日期"
    End Function

    Public Shared Function XemBaoCao() As String
        Return " Xem báo cáo"
    End Function

    Public Shared Function XemBaoCaoTaiwan() As String
        Return " 看報表"
    End Function

    Public Shared Function DieuKienThongKe() As String
        Return " Điều kiện thống kê"
    End Function

    Public Shared Function DieuKienThongKeTaiwan() As String
        Return " 統計條件"
    End Function

    Public Shared Function ThongKeLenCaSaiQuiDinh() As String
        Return " Thống kê lên ca sai qui định"
    End Function

    Public Shared Function ThongKeLenCaSaiQuiDinhTaiwan() As String
        Return " 上班異常統計"
    End Function

    Public Shared Function DanhMucThongKe() As String
        Return " Danh mục thống kê "
    End Function

    Public Shared Function DanhMucThongKeTaiwan() As String
        Return " 統計名目 "
    End Function

    Public Shared Function KiemTraGioQuetthe() As String
        Return " Kiểm tra giờ quẹt thẻ"
    End Function

    Public Shared Function KiemTraGioQuettheTaiwan() As String
        Return " 檢查刷卡時間"
    End Function

    Public Shared Function Xuong() As String
        Return " Xưởng"
    End Function

    Public Shared Function XuongTaiwan() As String
        Return " 廠別"
    End Function

    Public Shared Function Nganh() As String
        Return " Ngành"
    End Function

    Public Shared Function NganhTaiwan() As String
        Return " 部門"
    End Function

    Public Shared Function ThongKeTheoXuong() As String
        Return " Thống kê theo xưởng"
    End Function

    Public Shared Function ThongKeTheoXuongTaiwan() As String
        Return " 按廠別統計"
    End Function

    Public Shared Function ThongKeTheoNganh() As String
        Return " Thống kê theo ngành"
    End Function

    Public Shared Function ThongKeTheoNganhTaiwan() As String
        Return " 按部門統計"
    End Function

    Public Shared Function DieuKienLoc() As String
        Return " Điều kiện lọc"
    End Function

    Public Shared Function DieuKienLocTaiwan() As String
        Return " 挑選條件"
    End Function

    Public Shared Function ThongKeChucVuNhanVienCongTy() As String
        Return " Thống kê chức vụ nhân viên công ty"
    End Function

    Public Shared Function ThongKeChucVuNhanVienCongTyTaiwan() As String
        Return " 億春人員職務統計"
    End Function

    Public Shared Function ThongKeChucVu() As String
        Return " Thống kê chức vụ"
    End Function

    Public Shared Function ThongKeChucVuTaiwan() As String
        Return " 職務統計"
    End Function


    Public Shared Function ThongKeGioiTinhNhanVienCongTy() As String
        Return " Thống kê giới tính nhân viên công ty"
    End Function

    Public Shared Function ThongKeGioiTinhNhanVienCongTyTaiwan() As String
        Return " 億春人員性別統計"
    End Function

    Public Shared Function ThongKeGioiTinhNhanVien() As String
        Return " Thống kê giới tính nhân viên "
    End Function

    Public Shared Function ThongKeGioiTinhNhanVienTaiwan() As String
        Return " 人員性別統計"
    End Function

    Public Shared Function ThongKeHocVan() As String
        Return " Thống kê học vấn"
    End Function


    Public Shared Function ThongKeHocVanTaiwan() As String
        Return " 學歷統計"
    End Function

    Public Shared Function ThongKeHocVanNhanVienCongTy() As String
        Return " Thống kê học vấn nhân viên công ty"
    End Function

    Public Shared Function ThongKeHocVanNhanVienCongTyTaiwan() As String
        Return " 億春人員學歷統計"
    End Function

    Public Shared Function ThongKeThamNien() As String
        Return " Thống kê thâm niên"
    End Function


    Public Shared Function ThongKeThamNienTaiwan() As String
        Return " 年資統計"
    End Function

    Public Shared Function ThongKeThamNienNhanVienCongTy() As String
        Return " Thống kê thâm niên nhân viên công ty"
    End Function

    Public Shared Function ThongKeThamNienNhanVienCongTyTaiwan() As String
        Return " 億春人員年資統計"
    End Function

    Public Shared Function ThongKeTuoiNhanVienCongTy() As String
        Return " Thống kê tuổi nhân viên công ty"
    End Function

    Public Shared Function ThongKeTuoiNhanVienCongTyTaiwan() As String
        Return " 億春人員年度統計"
    End Function

    Public Shared Function ThongKeTuoi() As String
        Return " Thống kê tuổi "
    End Function

    Public Shared Function ThongKeTuoiTaiwan() As String
        Return " 年度統計"
    End Function

    Public Shared Function ThongKeMayChamCong() As String
        Return " Thống kê máy chấm công"
    End Function

    Public Shared Function ThongKeMayChamCongTaiwan() As String
        Return " 刷卡機統計"
    End Function

    Public Shared Function ThongTinMayChamCong() As String
        Return " Thông tin máy chấm công"
    End Function

    Public Shared Function ThongTinMayChamCongTaiwan() As String
        Return " 刷卡機情況"
    End Function

    Public Shared Function SoMay() As String
        Return " Số máy"
    End Function


    Public Shared Function SoMayTaiwan() As String
        Return " 機號"
    End Function

    Public Shared Function TenMay() As String
        Return " Tên máy"
    End Function

    Public Shared Function TenMayTaiwan() As String
        Return " 機名"
    End Function

    Public Shared Function DiaChiIP() As String
        Return " Địa chỉ IP"
    End Function

    Public Shared Function DiaChiIPTaiwan() As String
        Return " IP地址"
    End Function

    Public Shared Function GiaoThuc() As String
        Return " Giao thức"
    End Function

    Public Shared Function GiaoThucTaiwan() As String
        Return " 通訊協定"
    End Function

    Public Shared Function SoCong() As String
        Return " Số cổng"
    End Function

    Public Shared Function SoCongTaiwan() As String
        Return " 埠號"
    End Function

    Public Shared Function ViTri() As String
        Return " Vị trí"
    End Function


    Public Shared Function ViTriTaiwan() As String
        Return " 位置"
    End Function

    Public Shared Function TinhTrangSuDung() As String
        Return " Tình trạng sử dụng"
    End Function

    Public Shared Function TinhTrangSuDungTaiwan() As String
        Return " 使用狀況"
    End Function

    Public Shared Function GhiChu() As String
        Return " Ghi chú"
    End Function

    Public Shared Function GhiChuTaiwan() As String
        Return " 備註"
    End Function

    Public Shared Function Them() As String
        Return " Thêm"
    End Function

    Public Shared Function ThemTaiwan() As String
        Return " 新增"
    End Function

    Public Shared Function Xoa() As String
        Return " Xóa"
    End Function

    Public Shared Function XoaTaiwan() As String
        Return " 刪除"
    End Function

    Public Shared Function Sua() As String
        Return " Sửa"
    End Function

    Public Shared Function SuaTaiwan() As String
        Return " 修改"
    End Function

    Public Shared Function Luu() As String
        Return " Lưu"
    End Function

    Public Shared Function LuuTaiwan() As String
        Return " 存檔"
    End Function

    Public Shared Function In_() As String
        Return " In"
    End Function

    Public Shared Function In_Taiwan() As String
        Return " 列印"
    End Function

    Public Shared Function ThongKeTheoKhuVucNhanVienCongTy() As String
        Return " Thống kê theo khu vực nhân viên công ty"
    End Function

    Public Shared Function ThongKeTheoKhuVucNhanVienCongTy_Taiwan() As String
        Return " 億春人員地區統計"
    End Function

    Public Shared Function ThongKeKhuVuc() As String
        Return " Thống kê khu vực "
    End Function

    Public Shared Function ThongKeKhuVuc_Taiwan() As String
        Return " 地區統計 "
    End Function

    Public Shared Function ThongKeBenhNgheNghiep() As String
        Return " Thống kê bệnh nghề nghiệp "
    End Function
    Public Shared Function ThongKeBenhNgheNghiep_Taiwan() As String
        Return " 職業病人員統計 "
    End Function
    Public Shared Function ThongKeTheoDonVi() As String
        Return " Thống kê theo đơn vị "
    End Function
    Public Shared Function ThongKeTheoDonVi_Taiwan() As String
        Return " 職業病單位人員統計 "
    End Function
    Public Shared Function ThamNien() As String
        Return " Thâm Niên "
    End Function
    Public Shared Function ThamNien_Taiwan() As String
        Return " 年度 "
    End Function
    Public Shared Function SoLanKham() As String
        Return " Số Lần Khám "
    End Function
    Public Shared Function SoLanKham_Taiwan() As String
        Return " 檢查數次 "
    End Function
    Public Shared Function KetQuaHoHap() As String
        Return " Kết Quả Hô Hấp "
    End Function
    Public Shared Function KetQuaHoHap_Taiwan() As String
        Return " 呼吸結果 "
    End Function
    Public Shared Function KetQuaThinhLuc() As String
        Return " Kết Quả Tính Lực "
    End Function
    Public Shared Function KetQuaThinhLuc_Taiwan() As String
        Return " 聽力結果 "
    End Function
    Public Shared Function NhanVienKhongMacBenh() As String
        Return " Nhân viên không mắc bệnh "
    End Function
    Public Shared Function NhanVienKhongMacBenh_Taiwan() As String
        Return " 無職業病人員統計 "
    End Function

    Public Shared Function Xem() As String
        Return " Xem "
    End Function

    Public Shared Function Xem_Taiwan() As String
        Return " 看"
    End Function
  

End Class
