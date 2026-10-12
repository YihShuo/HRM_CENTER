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
Public Class frmBangLuongChinh
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmBangLuongChinh_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
    Private Sub LoadCombo()

        Dim obj As New objChamcongMain
        Me.b = New clsBChamcongMain

        ''------------load combo don vi 
        If Me.rdDonvi.Checked Then
            obj.ChonBang = 1
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.SelectedIndex = 0
            ''--------------------
            Me.cbDonvi.Visible = True
            Me.cboXuong.Visible = False
        End If

        ''------------load combo xuong 
        If Me.rdXuong.Checked Then
            obj.ChonBang = 13
            Me.TabletempXuong = Me.b.LoadDS(obj)
            'Me.TabletempXuong.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cboXuong.DataSource = Me.TabletempXuong
            Me.cboXuong.SelectedIndex = 0
            ''--------------------
            Me.cboXuong.Visible = True
            Me.cbDonvi.Visible = False

        End If
      
    End Sub
    Private Sub rdXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdXuong.CheckedChanged
        LoadCombo()
    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        LoadCombo()
    End Sub
    Private Sub frmBangLuongChinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdDonvi.Checked = True
        Me.dtpNgay.Value = Now

        If Me.LoaiReport = 1 Then
            Me.Text = "Report bảng lương"
            'Me.rdXuong.Visible = True
            'Me.rdXuong.Location = New System.Drawing.Point(9, 19)
            'Me.rdDonvi.Location = New System.Drawing.Point(74, 18)
            'Me.cbDonvi.Size = New System.Drawing.Point(302, 24)
            'Me.cboXuong.Size = New System.Drawing.Point(302, 24)
            'Me.GroupBox1.Location = New System.Drawing.Point(149, 13)
            'Me.btXem.Location = New System.Drawing.Point(605, 24)
            'Me.GroupBox1.Size = New System.Drawing.Size(450, 50)
        End If
        If Me.LoaiReport = 2 Then
            Me.Text = "Report phiếu lương cá nhân"
            'Me.rdXuong.Visible = False
            'Me.rdDonvi.Location = New System.Drawing.Point(9, 19)
            'Me.cbDonvi.Size = New System.Drawing.Point(302, 24)
            'Me.cbDonvi.Location = New System.Drawing.Point(74, 14)
            'Me.GroupBox1.Location = New System.Drawing.Point(149, 13)
            'Me.GroupBox1.Size = New System.Drawing.Size(382, 50)
            'Me.btXem.Location = New System.Drawing.Point(531, 24)
        End If
        LoadCombo()
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

        'Report cham cong thang
        Dim dv_ma, xuong As String
        Dim THANG As String = Me.dtpNgay.Text

        If Me.LoaiReport = 1 Then
            Me.Text = "Report bảng lương"
            Me.rdXuong.Visible = True

            'Chon rdDonvi
            '  Me.reportID = "99988"

         
            If Me.rdDonvi.Checked Then
                Me.reportID = "99988"
                dv_ma = Me.cbDonvi.Value.ToString()

                Dim strArray As String() = New String() {THANG, dv_ma}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If

            If Me.rdXuong.Checked Then
                Me.reportID = "BL99988"
                xuong = Me.cboXuong.Value.ToString()

                Dim strArray As String() = New String() {THANG, xuong}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If

            'If (dv_ma <> "") Then
            '    Dim strArray As String() = New String() {THANG, dv_ma}
            '    Me.para = strArray
            '    Me.issysReport = True
            '    Me.Refresh()
            '    Exit Sub
            'End If
            'MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            'Chon rdNghiviec
            'If Me.rdDonviNV.Checked = True Or Me.rdDonviNV01.Checked = True Then
            '    Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
            '    Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
            '    Dim ngayNV As Date = "15" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
            '    Dim NV As String = ""

            '    If Me.rdDonviNV.Checked = True Then
            '        NV = "NV"
            '    ElseIf Me.rdDonviNV01.Checked = True Then
            '        NV = "NV01"
            '    End If

            '    If Me.rpmoi = 1 Then
            '        Me.reportID = "9001"
            '    Else
            '        Me.reportID = "3011"
            '    End If

            '    Dim strArray As String() = New String() {Tungay, Denngay, NV, ngayNV}
            '    Me.para = strArray
            '    Me.issysReport = True
            '    Me.Refresh()
            '    Exit Sub
            'End If
            'Chon rdNghiviec

        End If
        'PL_99977

        If Me.LoaiReport = 2 Then
            'Me.btnXemPromaz.Enabled = True
            Me.Text = "Report phiếu lương cá nhân"
            If Me.rdDonvi.Checked Then
                Me.reportID = "99977"
                THANG = Me.dtpNgay.Text
                dv_ma = Me.cbDonvi.Value.ToString()

                If (dv_ma <> "" And dv_ma <> "TCT") Then
                    Dim strArray As String() = New String() {THANG, dv_ma}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                    Exit Sub
                End If
                MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)

            End If

            If Me.rdXuong.Checked Then
                Me.reportID = "PL99977"
                THANG = Me.dtpNgay.Text
                xuong = Me.cboXuong.Value.ToString()

                If (xuong <> "" And dv_ma <> "TCT") Then
                    Dim strArray As String() = New String() {THANG, xuong}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                    Exit Sub
                End If
                MessageBox.Show("Bạn phải chọn một xưởng cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)

            End If
        End If

    End Sub
    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Dim TabletempXuong As DataTable
    Dim b As clsBChamcongMain
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
End Class