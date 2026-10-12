Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win


Public Class frmBCGioCongTieuChuanThang
    Friend WithEvents c As clsBGioCongTieuChuanThang

    Private Sub LoadComBo()


        Me.c = New clsBGioCongTieuChuanThang
        Dim tableComBoBox As DataTable

        tableComBoBox = Me.c.GoiThuTuc_table("SP_GETDV_XUONG_GIOCONGTIEUCHUANADIDAS")
        tableComBoBox.Rows.Add(New Object() {"TB", "All/ Toàn bộ"})
        Me.CheckedListBox1.DataSource = tableComBoBox
        Me.CheckedListBox1.DisplayMember = "DV_TEN"
        Me.CheckedListBox1.ValueMember = "DV_MA"

        Me.CheckedListBox1.SelectedIndex = 0
        '  Me.CheckedListBox1.Items.Add(tableComBoBox.Rows(0).Item("DV_MA"))
        'CheckedListBox1.Items.Add("All/ Toàn bộ")
    End Sub
    Private Sub frmBangTheoDoiNgayPhepCuaCBCNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Text = Now
        LoadComBo()

    End Sub

    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        Me.LayThamSo()
        Me.HienThiReport()
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
        Me.rptChamcong.ReportSource = document
    End Sub
    Private Sub LayThamSo()
        Dim thang As String = Me.dtpNgay.Text
        Me.reportID = "GCTC_B"
        Dim strArray As String() = New String() {thang}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub
    Dim dacheck As Integer = 0
    Private Sub LayThamSo2()
        Dim donvi As String
        ' donvi = CheckedListBox1.SetItemChecked.ToString
        Dim thang As String = Me.dtpNgay.Text
        Dim Item As Object

        For Each Item In CheckedListBox1.CheckedItems
            donvi = donvi + "'" + Item.Item("DV_MA").ToString + "',"
            dacheck = dacheck + 1
        Next
        If dacheck > 0 Then
            donvi = donvi.Substring(0, donvi.Length - 1)
            Me.reportID = "GCTC_DS"
            Dim strArray As String() = New String() {thang, donvi}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        Else
            MessageBox.Show("Vui lòng check ít nhất 1 đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub CheckedListBox1_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck

        If e.Index = CheckedListBox1.Items.Count - 1 Then

            If e.NewValue = CheckState.Checked Then

                For idx As Integer = 1 To Me.CheckedListBox1.Items.Count - 2
                    CheckedListBox1.SetItemChecked(idx, True)
                Next

            ElseIf e.NewValue = CheckState.Unchecked Then

                For idx As Integer = 1 To Me.CheckedListBox1.Items.Count - 2
                    CheckedListBox1.SetItemChecked(idx, False)
                Next

            End If

        End If

    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.LayThamSo2()
        If dacheck > 0 Then
            Me.HienThiReport()
        End If

    End Sub
End Class