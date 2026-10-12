Public Class clsBTuoi
    Friend WithEvents d As clsDTuoi
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDTuoi
    End Sub

    Public Function LoadDS(ByVal obj As objTuoi) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
