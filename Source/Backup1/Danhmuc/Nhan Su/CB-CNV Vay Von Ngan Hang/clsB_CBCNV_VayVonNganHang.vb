Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsB_CBCNV_VayVonNganHang
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsD_CBCNV_VayVonNganHang
    End Sub
    Public Function LoadDS(ByVal obj As Obj_CBCNV_VayVonNganHang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function InsertInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        obj.ChonBang = 3
        ''========= KIEM TRA KHOA CHINH =========
        Dim ngayvay As Date = Convert.ToDateTime(obj.NGAYBD)
        Dim ngay As String = ngayvay.Day.ToString() + "/" + ngayvay.Month.ToString() + "/" + ngayvay.Year.ToString()
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj)
        Else
            MessageBox.Show("Số thẻ:" & obj.NV_MA & " đã vay vốn ngày: " & ngay & ", không thêm được. Vui lòng nhập lại!")
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại số thẻ này, Không thêm được.")
        End If
        Return False
    End Function
    Public Function UpdateInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        obj.ChonBang = 3
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            '' khong co
            Return False
        Else
            Return Me.d.UpdateInfo(obj)
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
    End Function
    Public Function DeleteInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    ' Fields
    Friend WithEvents d As clsD_CBCNV_VayVonNganHang

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
