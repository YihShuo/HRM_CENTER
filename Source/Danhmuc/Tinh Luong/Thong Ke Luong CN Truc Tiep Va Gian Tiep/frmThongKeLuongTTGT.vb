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
Public Class frmThongKeLuongTTGT
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmThongKeLuongTTGT_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
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
        Me.rptBangLuong.ReportSource = document
    End Sub

    Private Sub LayThamSo()


        If Me.radLCDV.Checked = True Then
            Me.LoaiReport = 1
            If Me.LoaiReport = 1 Then
                Me.Text = "Report thống kê lương chính theo đơn vị"
                Me.reportID = "LCDV"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLCDV.Checked = True Then
                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else
                    Exit Sub
                End If

            End If
        End If
        If Me.radLTCDV.Checked = True Then
            Me.LoaiReport = 2
            If Me.LoaiReport = 2 Then
                Me.Text = "Report thống kê lương tăng ca theo đơn vị"
                Me.reportID = "LTCDV"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLTCDV.Checked = True Then
                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else
                    Exit Sub
                End If

            End If
        End If

        If Me.radLTDV.Checked = True Then
            Me.LoaiReport = 3
            If Me.LoaiReport = 3 Then
                Me.Text = "Report thống kê lương tổng hợp theo đơn vị"
                Me.reportID = "LTDV"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLTDV.Checked = True Then

                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else

                    Exit Sub
                End If

            End If
        End If

        If Me.radLCX.Checked = True Then
            Me.LoaiReport = 4
            If Me.LoaiReport = 4 Then
                Me.Text = "Report thống kê lương chính theo xưởng"
                Me.reportID = "LCX"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLCX.Checked = True Then
                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else

                    Exit Sub
                End If

            End If
        End If
        If Me.radLTCX.Checked = True Then
            Me.LoaiReport = 5
            If Me.LoaiReport = 5 Then
                Me.Text = "Report thống kê lương tăng ca theo xưởng"
                Me.reportID = "LTCX"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLTCX.Checked = True Then
                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else
                    Exit Sub
                End If

            End If
        End If

        If Me.radLTX.Checked = True Then
            Me.LoaiReport = 6
            If Me.LoaiReport = 6 Then
                Me.Text = "Report thống kê lương tổng hợp theo xưởng"
                Me.reportID = "LTX"
                Dim THANG As String = Me.dtpNgay.Text
                If Me.radLTX.Checked = True Then
                    Dim strArray As String() = New String() {THANG}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                Else
                    Exit Sub
                End If

            End If
        End If
        
    End Sub
    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Dim b As clsBChamcongMain
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub frmThongKeLuongTTGT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.radLCDV.Checked = True Then
            Me.LoaiReport = 1
            If Me.LoaiReport = 1 Then
                Me.Text = "Report thống kê lương chính theo đơn vị"
            End If
        Else
            Exit Sub
        End If
        If Me.radLTCDV.Checked = True Then
            Me.LoaiReport = 2
            If Me.LoaiReport = 2 Then
                Me.Text = "Report thống kê lương tăng ca theo đơn vị"
            End If
        Else
            Exit Sub
        End If

        If Me.radLTDV.Checked = True Then
            Me.LoaiReport = 3
            If Me.LoaiReport = 3 Then
                Me.Text = "Report thống kê lương tổng hợp theo đơn vị"
            End If
        Else
            Exit Sub
        End If

        If Me.radLCX.Checked = True Then
            Me.LoaiReport = 4
            If Me.LoaiReport = 4 Then
                Me.Text = "Report thống kê lương chính theo xưởng"
            End If
        Else
            Exit Sub
        End If
        If Me.radLTCX.Checked = True Then
            Me.LoaiReport = 5
            If Me.LoaiReport = 5 Then
                Me.Text = "Report thống kê lương tăng ca theo xưởng"
            End If
        Else
            Exit Sub
        End If

        If Me.radLTX.Checked = True Then
            Me.LoaiReport = 6
            If Me.LoaiReport = 6 Then
                Me.Text = "Report thống kê lương tổng hợp theo xưởng"
            End If
        Else
            Exit Sub
        End If

    End Sub
End Class