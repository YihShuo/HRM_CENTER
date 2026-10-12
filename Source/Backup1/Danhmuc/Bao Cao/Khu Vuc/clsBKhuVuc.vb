Public Class clsBKhuVuc

    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDKhuVuc
    End Sub

    ' Fields
    Friend WithEvents d As clsDKhuVuc

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Public Function LoadDS(ByVal obj As objKhuVuc) As DataTable
        Return Me.d.LoadDL(obj)
    End Function

End Class
