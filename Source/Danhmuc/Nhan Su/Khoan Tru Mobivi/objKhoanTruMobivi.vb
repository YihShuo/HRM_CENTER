Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objKhoanTruMobivi
    Dim flag As Boolean

    Public sNV_MA As String
    Public sT_MA As String
    Public dSOTIEN As Double
    Public bVUOT30 As Boolean
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
    Public Property VUOT30() As Boolean
        Get
            Return Me.bVUOT30
        End Get
        Set(ByVal Value As Boolean)
            Me.bVUOT30 = Value
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
    Public Overridable Function setnull()
        Me.NV_MA = ""
        Me.T_MA = ""
        Me.SOTIEN = 0
        Me.VUOT30 = True
        Me.CHONBANG = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal sNV_MA As String, ByVal sT_MA As String, ByVal dSOTIEN As Double, ByVal bVUOT30 As Boolean, ByVal iCHONBANG As Integer) As Boolean
        Me.NV_MA = sNV_MA
        Me.T_MA = sT_MA
        Me.SOTIEN = dSOTIEN
        Me.VUOT30 = bVUOT30
        Me.CHONBANG = iCHONBANG
        Return False
    End Function
End Class
