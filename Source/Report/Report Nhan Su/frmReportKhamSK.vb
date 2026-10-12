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

Public Class frmReportKhamSK



    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmReportKhamSK_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub frmReportKhamSK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbSothe.Visible = False
        txtSothe.Visible = False

        Label1.Visible = True
        Label2.Visible = True
        cbbDot.Visible = True
        txtNam.Visible = True
    End Sub


    Public issysReport As Boolean
    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Dim b As clsBChamcongMain
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String


    Private Sub txtNam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNam.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True ' nếu phím nhấn không phải là số hoặc phím     'control (nhấn "Backspace" để xóa số) -> thì beep cảnh báo và hủy sự kiện (không có phím được nhấn)
        End If
    End Sub

    Private Sub cbbLoaiBC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbLoaiBC.SelectedIndexChanged

        If cbbLoaiBC.SelectedIndex = 3 Then

            lbSothe.Visible = True
            txtSothe.Visible = True

            Label1.Visible = False
            Label2.Visible = False
            cbbDot.Visible = False
            txtNam.Visible = False
        Else
            lbSothe.Visible = False
            txtSothe.Visible = False

            Label1.Visible = True
            Label2.Visible = True
            cbbDot.Visible = True
            txtNam.Visible = True
        End If

    End Sub

    Public Sub KiemTraChiMucCBB(ByVal i As Integer)

        If i = 3 Then

            If Not (Char.IsNumber(txtSothe.Text)) Then
                MessageBox.Show("Vui lòng kiểm tra thông tin nhập liệu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                LayThamSo()
                HienThiReport()
            End If
        Else

            If Not (Char.IsNumber(txtNam.Text)) Then
                MessageBox.Show("Vui lòng kiểm tra thông tin nhập liệu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                LayThamSo()
                HienThiReport()
            End If


        End If


    End Sub

    
    Private Sub txtSothe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSothe.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True ' nếu phím nhấn không phải là số hoặc phím     'control (nhấn "Backspace" để xóa số) -> thì beep cảnh báo và hủy sự kiện (không có phím được nhấn)
        End If
    End Sub

    Private Sub LayThamSo()
        If cbbLoaiBC.SelectedIndex = 0 Then
            Me.reportID = "KSK_DD"
            Dim Dot As String = Me.cbbDot.Text.ToString()
            Dim Nam As Integer = Int32.Parse(txtNam.Text)
            Dim strArray As String() = New String() {Dot, Nam}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        ElseIf cbbLoaiBC.SelectedIndex = 1 Then
            Me.reportID = "KSK_KQ"
            Dim Dot As String = Me.cbbDot.Text.ToString()
            Dim Nam As Integer = Int32.Parse(txtNam.Text)
            Dim strArray As String() = New String() {Dot, Nam}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        ElseIf cbbLoaiBC.SelectedIndex = 2 Then
            Me.reportID = "KSK_TK"
            Dim Dot As String = Me.cbbDot.Text.ToString()
            Dim Nam As Integer = Int32.Parse(txtNam.Text)
            Dim strArray As String() = New String() {Dot, Nam}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        Else
            Me.reportID = "KSK_Canhan"
            Dim Sothe As String = Me.txtSothe.Text.ToString()
            Dim strArray As String() = New String() {Sothe}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
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
        Me.rptKSK.ReportSource = document
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click

        Me.KiemTraChiMucCBB(cbbLoaiBC.SelectedIndex)
    End Sub
End Class