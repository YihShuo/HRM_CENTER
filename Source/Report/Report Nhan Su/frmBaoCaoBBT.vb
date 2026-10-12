Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic.CompilerServices
Public Class frmBaoCaoBBT

    Private Sub frmBaoCaoBBT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New objReport
        obj.ChonBang = 1

        Me.b = New ClsBReport
        Tabletemp = Me.b.LoadDS(obj)
    End Sub


    Private Sub btXem_Click(sender As Object, e As EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub LayThamSo()

        Me.reportID = "BCBBT"   'C_KEY trong SYS_BaoCao

        Dim thang As Date = Me.dtpThang.Value

        Dim strArray As String() = New String() {thang}

        Me.para = strArray
        Me.issysReport = True

    End Sub

    Private Sub HienThiReport()
        Dim document As ReportDocument
        Dim report As New ClsBReport
        Try
            If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
                document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
            Else
                document = report.InitReport(Me.reportID)
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            Me.Close()
            ProjectData.ClearProjectError()
            Return
        End Try
        If Me.issysReport Then
            document = report.SetParameter(document, Me.para)
        End If
        Me.crViewer.ReportSource = document
    End Sub

    Dim Tabletemp As DataTable
    Dim b As ClsBReport

    Public issysReport As Boolean
    Public para As Object()

    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub crViewer_Load(sender As Object, e As EventArgs) Handles crViewer.Load

    End Sub
End Class