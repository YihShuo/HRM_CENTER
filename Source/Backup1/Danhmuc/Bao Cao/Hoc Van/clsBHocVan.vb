Public Class clsBHocVan

    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDHocVan
    End Sub

    Public Function LoadDS(ByVal obj As objHocVan) As DataTable
        Return Me.d.LoadDS(obj)
    End Function


    ' Fields
    Friend WithEvents d As clsDHocVan

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)


End Class
