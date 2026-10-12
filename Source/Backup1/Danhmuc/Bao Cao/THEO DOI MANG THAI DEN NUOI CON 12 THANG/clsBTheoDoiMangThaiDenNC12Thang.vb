Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBTheoDoiMangThaiDenNC12Thang
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDTheoDoiMangThaiDenNC12Thang
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function LoadDS(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Return Me.d.UpdateInfo(obj)
    End Function
    Public Function DeleteInfo(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    Public Function InsertNgayKhamMoiSua(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Return Me.d.InsertNgayKhamMoiSua(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function LoadTruyVan(ByVal m_sSP_Name As String)
        Me.d.GoiThuTuc_Loaddulieu(m_sSP_Name)
    End Function
    Public Function GoiThuTucLoadDS(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTucLoadDS(m_sSP_Name, m_listpar)
    End Function

    ' Fields
    Friend WithEvents d As clsDTheoDoiMangThaiDenNC12Thang
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
