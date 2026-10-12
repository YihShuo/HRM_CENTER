Public Class clsBThamNien

    Friend WithEvents d As clsDThamNien
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThamNien
    End Sub

    Public Function LoadDS(ByVal obj As objThamNien) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
