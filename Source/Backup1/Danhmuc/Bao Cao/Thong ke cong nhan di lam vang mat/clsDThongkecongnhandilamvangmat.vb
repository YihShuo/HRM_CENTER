
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongkecongnhandilamvangmat
    Inherits DALSQL
    Public Function LoadDanhSach(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
    End Function
End Class
