Public Class clsBChucVu

    Public Event _errorRaise As _errorRaiseEventHandler

    Public Sub New()
        Me.d = New clsDChucVu
    End Sub

    Public Function LoadDS(ByVal obj As objChucVu) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Friend WithEvents d As clsDChucVu

    Public Delegate Sub _errorRaiseEventHandler(ByVal message As String)

End Class
