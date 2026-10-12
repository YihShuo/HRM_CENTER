Public Class clsBDanhSachThongKeNgayCong
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDDanhSachThongKeNgayCong
    End Sub

    ' Fields
    Friend WithEvents d As clsDDanhSachThongKeNgayCong

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Public Function LoadDS(ByVal obj As objDanhSachThongKeNgayCong) As DataTable
        Return Me.d.LoadDL(obj)
    End Function
    Public Function GoiThuTucLoadDS(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTucLoadDS(m_sSP_Name, m_listpar)
    End Function
End Class
