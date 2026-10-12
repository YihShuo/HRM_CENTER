Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class ObjThongKeTheomqh

    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MQH = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Property MQH() As String
        Get
            Return Me.m_sMQH
        End Get
        Set(ByVal Value As String)
            Me.m_sMQH = Value
        End Set
    End Property
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property
    
    '' Fields
    Public m_sMQH As String
    Public m_iChonbang As Integer
    


End Class
