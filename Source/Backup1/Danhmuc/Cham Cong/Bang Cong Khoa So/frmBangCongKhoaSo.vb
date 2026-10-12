Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinToolTip
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraMessageBox
Imports TongHop.clsTools
Public Class frmBangCongKhoaSo
    Public bLoad As Boolean = False
    Public fWaiting As frmWaiting_GC
    Dim Tabletemp As DataTable
    Dim Tabletemp1 As DataTable
    Dim TabletempDV As DataTable
    Dim TableND As DataTable
    Friend WithEvents b As clsBBangCongKhoaSo
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmBangCongKhoaSo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
        Me.b = New clsBBangCongKhoaSo
        Dim i As Integer
        Dim obj As New objBangCongKhoaSo

        Dim NgayCC As Date
        NgayCC = Me.dtpNgay.Value
        obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()

        obj.ChonBang = 9
        Me.Tabletemp1 = Me.b.LoadDS(obj)
        If Me.Tabletemp1.Rows.Count > 0 Then
            obj.ChonBang = 1
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.SelectedIndex = 0
            Me.cbDonvi.DisplayMember = "DV_TEN"
            Me.cbDonvi.ValueMember = "DV_MA"
        Else
            MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
        End If
        bLoad = True
        Me.radTCT.Checked = True
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.b = New clsBBangCongKhoaSo
        Dim NgayCC As Date
        NgayCC = Me.dtpNgay.Value
        Dim obj As New objBangCongKhoaSo
        obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
        obj.Nam = NgayCC.Year.ToString()
        obj.Thang = NgayCC.Month.ToString()

        Dim tamDVNghiViec As DataTable

        obj.ChonBang = 9
        Me.Tabletemp1 = Me.b.LoadDS(obj)
        If Me.Tabletemp1.Rows.Count > 0 Then
            If Me.radKhuA.Checked Then
                obj.ChonKhu = "CHONRADIOKHUA"
            End If

            If Me.radKhuB.Checked Then
                obj.ChonKhu = "CHONRADIOKHUB"
            End If

            If Me.radKhuDVC.Checked Then
                obj.ChonKhu = "CHONRADIOKHUDVC"
            End If
            If Me.radTCT.Checked Then
                obj.ChonKhu = "CHONRADIOTCT"
            End If

            Select Case Me.cbDonvi.Value
                Case "KHUA", "KHUB", "KHUDVC", "TCT"
                    fWaiting = frmWaiting_GC.ShowProgress(Me)
                Case Else
            End Select

            If Me.cbDonvi.SelectedIndex <> -1 Then
                obj.DonVi = Me.cbDonvi.Value.ToString()
                obj.ChonBang = 2
                tamDVNghiViec = Me.b.LoadDS(obj)

                If tamDVNghiViec.Rows.Count > 0 Then
                    ''==== lọc danh sách đơn vị loại nghỉ việc chọn theo cột DV_MA 
                    obj.LoaiDonViNghiViec = 1
                Else
                    obj.LoaiDonViNghiViec = 0
                End If
                obj.ChonBang = 3
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)

            Else
                obj.ChonBang = 5
                Me.Tabletemp = Me.b.LoadDS(obj)
            End If


            Select Case cbDonvi.Value
                Case "KHUA", "KHUB", "KHUDVC", "TCT"

                    fWaiting.CloseProgress()
                    Me.cbDonvi.DroppedDown = False
            End Select
        Else
            MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
            Me.dgrBC.DataSource = Nothing
            Me.cbDonvi.DataSource = Nothing
            Me.cbDonvi.Text = ""
        End If

        

    End Sub

    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        'Me.dgrBC.UpdateData()
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ChamCongMainKhoaSo.xml"), typeControl.Grid, "coldgrChamcongmainKhoaSo")

        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band.Layout.Bands(0).Summaries.Clear()

        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns("NV_TEN")
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng số :", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing

        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If bLoad Then
            If Me.cbDonvi.Text = "" Then
            Else
                Me.Tim()
            End If
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        If bLoad Then
            If Me.cbDonvi.Text = "" Then
                Dim obj As New objBangCongKhoaSo
                Me.b = New clsBBangCongKhoaSo
                Dim NgayCC As Date
                NgayCC = Me.dtpNgay.Value

                obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()

                obj.ChonBang = 9
                Me.Tabletemp1 = Me.b.LoadDS(obj)
                If Me.Tabletemp1.Rows.Count > 0 Then
                    Tabletemp = Nothing
                    If Me.radTCT.Checked Then
                        obj.ChonBang = 1
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                        Me.cbDonvi.DataSource = Me.Tabletemp
                        Me.cbDonvi.SelectedIndex = 1
                        Me.Tim()
                    ElseIf Me.radKhuA.Checked Then
                        obj.ChonBang = 6
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("KHUA", "Toàn bộ khu A")
                        Me.cbDonvi.DataSource = Me.Tabletemp
                        Me.cbDonvi.SelectedIndex = 1
                        Me.Tim()
                    ElseIf Me.radKhuB.Checked Then
                        obj.ChonBang = 7
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("KHUB", "Toàn bộ khu B")
                        Me.cbDonvi.DataSource = Me.Tabletemp
                        Me.cbDonvi.SelectedIndex = 1
                        Me.Tim()
                    ElseIf Me.radKhuDVC.Checked Then
                        obj.ChonBang = 8
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("KHUDVC", "全部公司Toàn bộ khu DVC")
                        Me.cbDonvi.DataSource = Me.Tabletemp
                        Me.cbDonvi.SelectedIndex = 1
                        Me.Tim()
                    Else
                        Me.cbDonvi.DataSource = Nothing
                        Me.cbDonvi.SelectedIndex = Nothing
                    End If
                Else
                    'MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
                    Me.dgrBC.DataSource = Nothing
                    Me.cbDonvi.DataSource = Nothing
                    Me.cbDonvi.Text = ""
                End If
            Else
                Me.Tim()
            End If
        End If
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        If bLoad Then


            Dim obj As New objBangCongKhoaSo
            Me.b = New clsBBangCongKhoaSo
            Dim NgayCC As Date
            NgayCC = Me.dtpNgay.Value

            obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()

            obj.ChonBang = 9
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            If Me.Tabletemp1.Rows.Count > 0 Then
                Tabletemp = Nothing
                If Me.radKhuA.Checked Then
                    obj.ChonBang = 6
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    Me.Tabletemp.Rows.Add("KHUA", "Toàn bộ khu A")
                    Me.cbDonvi.DataSource = Me.Tabletemp
                    Me.cbDonvi.SelectedIndex = 1
                    Me.Tim()
                Else
                    Me.cbDonvi.DataSource = Nothing
                    Me.cbDonvi.SelectedIndex = Nothing
                End If
            Else
                'MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
                Me.dgrBC.DataSource = Nothing
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.Text = ""
            End If
        End If
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        If bLoad Then
            Dim obj As New objBangCongKhoaSo
            Me.b = New clsBBangCongKhoaSo
            Dim NgayCC As Date
            NgayCC = Me.dtpNgay.Value
            obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
            obj.ChonBang = 9
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            If Me.Tabletemp1.Rows.Count > 0 Then
                Tabletemp = Nothing
                If Me.radKhuB.Checked Then
                    obj.ChonBang = 7
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    Me.Tabletemp.Rows.Add("KHUB", "Toàn bộ khu B")
                    Me.cbDonvi.DataSource = Me.Tabletemp
                    Me.cbDonvi.SelectedIndex = 1
                    Me.Tim()
                Else
                    Me.cbDonvi.DataSource = Nothing
                    Me.cbDonvi.SelectedIndex = Nothing
                End If
            Else
                'MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
                Me.dgrBC.DataSource = Nothing
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.Text = ""
            End If
        End If

    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        If bLoad Then
            Dim obj As New objBangCongKhoaSo
            Me.b = New clsBBangCongKhoaSo
            Dim NgayCC As Date
            NgayCC = Me.dtpNgay.Value

            obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
            obj.ChonBang = 9
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            If Me.Tabletemp1.Rows.Count > 0 Then
                Tabletemp = Nothing
                If Me.radTCT.Checked Then
                    obj.ChonBang = 1
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                    Me.cbDonvi.DataSource = Me.Tabletemp
                    Me.cbDonvi.SelectedIndex = 1
                    Me.Tim()
                Else
                    Me.cbDonvi.DataSource = Nothing
                    Me.cbDonvi.SelectedIndex = Nothing
                End If
            Else
                'MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
                Me.dgrBC.DataSource = Nothing
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.Text = ""
            End If
        End If
    End Sub

    Private Sub radKhuDVC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuDVC.CheckedChanged
        If bLoad Then
            Dim obj As New objBangCongKhoaSo
            Me.b = New clsBBangCongKhoaSo
            Dim NgayCC As Date
            NgayCC = Me.dtpNgay.Value

            obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
            obj.ChonBang = 9
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            If Me.Tabletemp1.Rows.Count > 0 Then
                Tabletemp = Nothing
                If Me.radKhuDVC.Checked Then
                    obj.ChonBang = 8
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    Me.Tabletemp.Rows.Add("KHUDVC", "全部公司Toàn bộ khu DVC")
                    Me.cbDonvi.DataSource = Me.Tabletemp
                    Me.cbDonvi.SelectedIndex = 1
                    Me.Tim()
                Else
                    Me.cbDonvi.DataSource = Nothing
                    Me.cbDonvi.SelectedIndex = Nothing
                End If
            Else
                'MessageBox.Show("Dữ liệu chưa được khóa sổ!!")
                Me.dgrBC.DataSource = Nothing
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.Text = ""
            End If
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim report As New frmReportBangCongKhoaSo
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim report As New frmBangCongKhoaSoNV
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub lnkBangChamCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBangChamCom.LinkClicked
        Dim report As New frmBangComKhoaSo
        report.LoaiReport = 1
        report.Show()
    End Sub
End Class