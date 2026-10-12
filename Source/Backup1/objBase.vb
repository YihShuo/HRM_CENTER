Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objBase
    ' Methods
    Public Function KtghiChu() As Boolean
        Return (StringType.StrCmp(Me.GhiChu, "", False) <> 0)
    End Function

    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.Name, "", False) <> 0)
    End Function

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Name = ""
        Me.GhiChu = ""
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sName As String, ByVal m_snote As String) As Boolean
        Me.ID = m_sID
        Me.Name = m_sName
        If (Strings.Len(m_snote) < &HFF) Then
            Dim flag As Boolean
            Me.GhiChu = m_snote
            Return flag
        End If
        Interaction.MsgBox("Ghi ch" & ChrW(250) & " q" & ChrW(250) & "a d" & ChrW(224) & "i", MsgBoxStyle.OkOnly, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
        Return False
    End Function


    ' Properties
    Public Property GhiChu() As String
        Get
            Return Me.m_sNote
        End Get
        Set(ByVal Value As String)
            Me.m_sNote = Value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return Me.m_sName
        End Get
        Set(ByVal Value As String)
            Me.m_sName = Value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_sName As String
    Public m_sNote As String
End Class

