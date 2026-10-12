Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objReport

    '' Properties
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property


    '' Fields
    Public m_iChonbang As String
End Class
