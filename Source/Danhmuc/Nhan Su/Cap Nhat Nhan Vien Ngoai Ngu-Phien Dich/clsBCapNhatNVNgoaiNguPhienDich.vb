Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBCapNhatNVNgoaiNguPhienDich
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDCapNhatNVNgoaiNguPhienDich
    End Sub
    Public Function LoadDS(ByVal obj As objCapNhatNVNgoaiNguPhienDich) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As objCapNhatNVNgoaiNguPhienDich) As Boolean
        Return Me.d.UpdateInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại số thẻ này, Không thêm được.")
        End If
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function ThongKeNNgu_Thang(ByVal m_sSP_Name As String, ByVal sLoaiNgoaiNgu As String, ByVal sNam As String) As DataTable
        Return Me.d.ThongKeNNgu_Thang(m_sSP_Name, sLoaiNgoaiNgu, sNam)
    End Function
    Public Function TinhNgoaiNguKhac(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.GoiThuTuc_TinhNgoaiNguKhac(m_sSP_Name)
    End Function
    Public Function KhoiTaoDL(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.KhoiTaoDL(m_sSP_Name)
    End Function
    Public Function TinhSoLuongPhanBoNN(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.TinhSoLuongBangPhanBo(m_sSP_Name)
    End Function
    Public Function LoadDS1(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.LoadDS1(m_sSP_Name)
    End Function
    Public Function GoiThuTucThongKe(ByVal m_sSP_Name As String, ByVal listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTucThongKe(m_sSP_Name, listpar)
    End Function
    Public Function TimNV(ByVal m_sSP_Name As String, ByVal NV_MA As String) As DataTable
        Return Me.d.TimNV(m_sSP_Name, NV_MA)
    End Function
    Public Function DanhSachNNgu_HienTai(ByVal m_sSP_Name As String, ByVal stungay As String, ByVal sdenngay As String) As DataTable
        Return Me.d.DanhSachNNgu_HienTai(m_sSP_Name, stungay, sdenngay)
    End Function
    Public Function DanhSachNNgu_ThoiViec(ByVal m_sSP_Name As String, ByVal stungay As String, ByVal sdenngay As String) As DataTable
        Return Me.d.DanhSachNNgu_ThoiViec(m_sSP_Name, stungay, sdenngay)
    End Function
    Public Function CapNhatTen_MaXuong(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.CapNhatTen_MaXuong(m_sSP_Name)
    End Function
    ' Fields
    Friend WithEvents d As clsDCapNhatNVNgoaiNguPhienDich

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

End Class
