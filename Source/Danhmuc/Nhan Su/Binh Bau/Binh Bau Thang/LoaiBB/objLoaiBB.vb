Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objLoaiBB
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Function setvalue(ByVal bang As Integer) As Boolean
        Dim flag As Boolean
        Me.ChonBang = bang
        Return flag
    End Function
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property
    ' Fields
    Public m_iChonbang As Integer
End Class
