Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objDSCNKhongNghi
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.Nam = 2009

        Return flag
    End Function

    Public Function setvalue(ByVal iChonBang As Integer, ByVal sNam As String) As Boolean
        Dim flag As Boolean

        Me.ChonBang = iChonBang
        Me.Nam = sNam

        Return flag
    End Function


    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonBang = Value
        End Set
    End Property

    Public Property Nam() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property

   

    '' Fields
    Public m_iChonBang As Integer
    Public m_sNam As String
    
End Class


