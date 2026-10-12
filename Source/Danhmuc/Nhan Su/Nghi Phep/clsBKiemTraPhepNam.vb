Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBKiemTraPhepNam
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler
    Public Flag_NuoiCon As Boolean
    ' Methods
    Public Sub New()
        Me.d = New clsDKiemTraPhepNam
    End Sub
    Public Function GoiThuTucHT(ByVal m_sSP_Name As String)
        Me.d.GoiThuTucHT(m_sSP_Name)
    End Function
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function Capnhat(ByVal obj As objKiemTraPhepNam) As Boolean
        Return Me.d.CapNhatThongTin(obj)
    End Function
    Public Function TinhPhepCoOm(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Dim tbl As DataTable
        tbl = Me.d.TinhphepCoOM(m_sSP_Name, m_listpar).Tables(0)
        Return tbl
    End Function
    Public Function DeleteInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        obj.ChonBang = 7
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            MessageBox.Show("Nhân viên " + obj.MANV + " không có trong danh sách không thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Return Me.d.DeleteInfo(obj)
        End If
    End Function
    Public Function DeleteInfoDV(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        flag = Me.d.DeleteInfoDV(obj)
        Return flag
    End Function
    ''' <summary>
    ''' hàm xóa tự động khi nhập phép TS mà số lần MT không kết nối số lần TS
    ''' </summary>

    Public Function DeleteAuTo(ByVal obj As objKiemTraPhepNam) As Boolean
        obj.ChonBang = 20
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            MessageBox.Show("Nhân viên " + obj.MANV + " không có trong danh sách không thể xóa. Vui lòng liên hệ IT.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Return Me.d.DeleteInfoAuto(obj)
        End If
    End Function
    Public Function DeleteInfoNuoiCon(ByVal obj As objKiemTraPhepNam) As Boolean
        Return Me.d.DeleteInfoNuoiCon(obj)
    End Function
    Public Function InsertInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        flag = Me.d.InsertInfo(obj)
        Return flag
    End Function
    Public Function InsertInfoDV(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        flag = Me.d.CapNhatDonvi(obj)
        Return flag
    End Function
    Public Function InsertInfoCTy(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        flag = Me.d.CapNhatCongTy(obj)
        Return flag
    End Function
    Public Function InsertInfoNuoiCon(ByVal obj As objKiemTraPhepNam) As Boolean
        ''kiem tra co nhap roi trong bang nuoi con khong
        obj.ChonBang = 15
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Dim flag As Boolean
            flag = Me.d.InsertNuoiCon12Thang(obj)
            Return flag
        Else
            MessageBox.Show("Số thẻ " + obj.MANV + " đã được nhập dữ liệu thai sản ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Function
    Public Function IsDeleteOK(ByVal obj As objKiemTraPhepNam) As Boolean
        Return True
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function PhepLongNhau(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Return Me.d.ThuTucKiemTraPhep(m_sSP_Name, listpar)
    End Function
    Public Function XoaPhep(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Return Me.d.XoaPhep(m_sSP_Name, listpar)
    End Function
    Public Function SuaPhep(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Return Me.d.SuaPhep(m_sSP_Name, listpar)
    End Function
    Public Function LoadDS(ByVal obj As objKiemTraPhepNam) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function TongSoNgayPhep(ByVal obj As objKiemTraPhepNam, ByVal sLoaiphep As String) As DataTable
        Return Me.d.SoNgayNghiPhep(obj, sLoaiphep)
    End Function
    Public Function UpdateInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        If ((Not table Is Nothing) AndAlso (table.Rows.Count <> 0)) Then
            Return Me.d.UpdateInfo(obj)
        Else
            MessageBox.Show("Không tồn tại Mã NV và nghỉ phép Từ Ngày này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Không tồn tại mã công việc chức vụ này, không sửa được.")
        End If
        Return False
    End Function
    Public Function UpdateInfoNuoiCon(ByVal obj As objKiemTraPhepNam) As Boolean
        ''kiem tra tu ngay co nhap roi trong bang nuoi con khong
        obj.ChonBang = 16
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            If MessageBox.Show("Số thẻ " + obj.MANV + " không có ngày bắt đầu trong dữ liệu thai sản. Cập nhật? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.InsertInfoNuoiCon(obj)
                Return True
            Else
                Return False
            End If
        Else
            Dim flag As Boolean
            flag = Me.d.UpdateInfoNuoiCon(obj)
            Return flag
        End If
    End Function

    ' Fields
    Friend WithEvents d As clsDKiemTraPhepNam

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class


