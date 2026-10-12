Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTienVuotSanLuong
    Dim flag As Boolean

    Public sNV_MA As String
    Public sT_MA As String
    Public dSOTIEN As Double
    Public iCHONBANG As Integer
    Public Property NV_MA() As String
        Get
            Return Me.sNV_MA
        End Get
        Set(ByVal Value As String)
            Me.sNV_MA = Value
        End Set
    End Property
    Public Property T_MA() As String
        Get
            Return Me.sT_MA
        End Get
        Set(ByVal Value As String)
            Me.sT_MA = Value
        End Set
    End Property
    Public Property SOTIEN() As Double
        Get
            Return Me.dSOTIEN
        End Get
        Set(ByVal Value As Double)
            Me.dSOTIEN = Value
        End Set
    End Property
   
    Public Property CHONBANG() As Integer
        Get
            Return Me.iCHONBANG
        End Get
        Set(ByVal Value As Integer)
            Me.iCHONBANG = Value
        End Set
    End Property
End Class
