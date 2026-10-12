Public Class clsBGioiTinh

    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDGioiTinh
    End Sub

    Public Function LoadDS(ByVal obj As objGioiTinh) As DataTable
        Return Me.d.LoadDS(obj)
    End Function


    ' Fields
    Friend WithEvents d As clsDGioiTinh

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)


End Class
