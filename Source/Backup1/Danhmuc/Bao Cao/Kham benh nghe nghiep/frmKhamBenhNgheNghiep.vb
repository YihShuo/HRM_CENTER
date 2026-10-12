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
Imports TongHop.clsTools
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Public Class frmKhamBenhNgheNghiep
    Public obj As New obj_KhamBenhNgheNghiep
    Public b As New ClassB_KhamBenhNgheNghiep
    Public Path As String
    Private Sub LoadXuong()
        obj.ChonBang = 1
        Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            Me.cboXuong.SelectedIndex = 0
        End If
    End Sub
    Private Sub Dieukhien()
        If Me.radXuong.Checked Then
            Me.cboXuong.Enabled = True
            obj.CHONXUONG = True
            obj.CHONTONGQUAT = False
        End If

        If Me.radTongquat.Checked Then
            obj.CHONTONGQUAT = True
            obj.CHONXUONG = False
            Me.cboXuong.Enabled = False
        End If

        If Me.radSuckhoe.Checked Then
            Me.chkHoHap.Enabled = False
            Me.chkThinhluc.Enabled = False
            Me.chkBenhSK.Enabled = True
            Me.chkCVNNDH.Enabled = True
            obj.KHAMSUCKHOE = 1
            obj.KHAMBENHNGHENGHIEP = 0
        End If
        If Me.radBenhNN.Checked Then
            Me.chkBenhSK.Enabled = False
            Me.chkCVNNDH.Enabled = False
            Me.chkCVNNDH.Checked = False
            Me.chkHoHap.Enabled = True
            Me.chkThinhluc.Enabled = True
            obj.KHAMBENHNGHENGHIEP = 1
            obj.KHAMSUCKHOE = 0
        End If

        If Me.radBenhPK.Checked Then
            obj.KHAMBENHNGHENGHIEP = 0
            obj.KHAMSUCKHOE = 0
            obj.KHAMSANKHOA = 1

            Me.chkBenhSK.Enabled = False
            Me.chkCVNNDH.Enabled = False
            Me.chkCVNNDH.Checked = False
            Me.chkHoHap.Enabled = False
            Me.chkThinhluc.Enabled = False

        End If
        If chkKhongBenh.Checked Then
            Me.chkBenhSK.Enabled = False
            Me.chkHoHap.Enabled = False
            Me.chkThinhluc.Enabled = False
        End If
        If chkTungay.Checked Then
            Me.dtpTungay.Enabled = True
        Else
            Me.dtpTungay.Enabled = False
            Me.dtpDenngay.Enabled = False
        End If
        If chkDenngay.Checked Then
            Me.dtpDenngay.Enabled = True
        Else
            Me.dtpDenngay.Enabled = False
        End If
        ''================ tab 2
        If chkDenngayk.Checked Then
            Me.dtpNgayktkham.Enabled = True
        Else
            Me.dtpNgayktkham.Enabled = False
        End If
    End Sub
    Private Sub Laythamso()
        Dim tngay, dngay As Date
        ''============ khoi tao cac gia tri ========
        obj.Setnull()
        Select Case radTongquat.Checked
            Case True  ''------------ xem công ty ---------
                obj.CHONTONGQUAT = 1
                ''============ tuy chon: KHÁM SỨC KHỎE ===========''
                If radSuckhoe.Checked Then
                    obj.KHAMSUCKHOE = 1
                    obj.KHAMBENHNGHENGHIEP = 0
                    obj.KHAMSANKHOA = 0

                    If chkBenhSK.Checked Then
                        obj.BENH_KHAMSK = 1
                    End If
                    If chkKhongBenh.Checked Then
                        obj.KHONGBENH_SK = 1
                    End If
                    If chkCVNNDH.Checked Then
                        obj.LV_NNDH = 1
                    End If
                End If
                ''============ tuy chon: KHÁM BỆNH NGHỀ NGHIỆP ===========''
                If radBenhNN.Checked Then
                    obj.KHAMBENHNGHENGHIEP = 1
                    obj.KHAMSUCKHOE = 0
                    obj.KHAMSANKHOA = 0

                    If chkKhongBenh.Checked Then
                        obj.KHONGBENH_NN = 1
                    End If
                    If chkHoHap.Checked Then
                        obj.BENH_HOHAP = 1
                    End If
                    If chkThinhluc.Checked Then
                        obj.BENH_THINHLUC = 1
                    End If
                End If

                ''============ tuy chon: KHÁM PHỤ KHOA ===========''
                If Me.radBenhPK.Checked Then

                    obj.KHAMBENHNGHENGHIEP = 0
                    obj.KHAMSUCKHOE = 0
                    obj.KHAMSANKHOA = 1
                    If Me.chkKhongBenh.Checked Then
                        obj.KHONGBENH_PHUKHOA = 1
                    End If
                End If

            Case False ''------------ xem theo xưởng ---------
                obj.CHONTONGQUAT = 0
                obj.CHONXUONG = 1
                ''============ tuy chon: KHÁM SỨC KHỎE ===========''
                If radSuckhoe.Checked Then
                    obj.KHAMSUCKHOE = 1
                    obj.KHAMBENHNGHENGHIEP = 0
                    obj.KHAMSANKHOA = 0

                    If chkBenhSK.Checked Then
                        obj.BENH_KHAMSK = 1
                    End If
                    If chkKhongBenh.Checked Then
                        obj.KHONGBENH_SK = 1
                    End If
                    If chkCVNNDH.Checked Then
                        obj.LV_NNDH = 1
                    End If
                End If
                ''============ tuy chon: KHÁM BỆNH NGHỀ NGHIỆP ===========''
                If radBenhNN.Checked Then
                    obj.KHAMBENHNGHENGHIEP = 1
                    obj.KHAMSUCKHOE = 0
                    If chkKhongBenh.Checked Then
                        obj.KHONGBENH_NN = 1
                    End If
                    If chkHoHap.Checked Then
                        obj.BENH_HOHAP = 1
                    End If
                    If chkThinhluc.Checked Then
                        obj.BENH_THINHLUC = 1
                    End If
                End If

                ''============ tuy chon: KHÁM PHỤ KHOA ===========''
                If Me.radBenhPK.Checked Then

                    obj.KHAMBENHNGHENGHIEP = 0
                    obj.KHAMSUCKHOE = 0
                    obj.KHAMSANKHOA = 1

                End If


        End Select

        If Me.chkTungay.Checked And (Not Me.dtpTungay.Value = Nothing) Then
            obj.CHON_TUNAM = True
            tngay = dtpTungay.Value
            obj.TUNAM = tngay.Year.ToString()
        Else
            obj.CHON_TUNAM = False
            obj.CHON_DENNAM = False
        End If
        If Me.chkDenngay.Checked And (Not Me.dtpDenngay.Value = Nothing) And Me.chkDenngay.Enabled = True Then
            obj.CHON_DENNAM = True
            dngay = dtpDenngay.Value
            obj.DENNAM = dngay.Year.ToString()
            'If Convert.ToInt32(obj.DENNAM) >= 2014 Then
            '    MessageBox.Show("Vui lòng chọn năm kết thúc nhỏ hơn 2014.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Else
            obj.CHON_DENNAM = False
        End If
    End Sub
    Private Function ThongBao() As Boolean
        If (Me.cboXuong.Text = "" Or Me.cboXuong.Value Is Nothing) And radXuong.Checked Then
            MessageBox.Show("Vui lòng chọn xưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (Me.chkTungay.Checked And Me.dtpTungay.Value = Nothing) Then
            MessageBox.Show("Vui lòng thời gian bắt đầu khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (Me.chkDenngay.Checked And Me.dtpDenngay.Value = Nothing) Then
            MessageBox.Show("Vui lòng thời gian kết thúc khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (Me.chkTungay.Checked And Not Me.dtpTungay.Value = Nothing) And (Me.chkDenngay.Checked And Not Me.dtpDenngay.Value = Nothing) And (Me.dtpDenngay.Value < Me.dtpTungay.Value) Then
            MessageBox.Show("Vui lòng thời gian kết thúc >= thời gian bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        ''===============dieu khien control tab 2 ================''
        If (Me.dtpNgaybdkham.Value = Nothing) Then
            MessageBox.Show("Vui lòng thời gian bắt đầu khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (Me.chkDenngayk.Checked And Me.dtpNgayktkham.Value = Nothing) Then
            MessageBox.Show("Vui lòng thời gian kết thúc khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (Me.chkDenngayk.Checked And Not Me.dtpNgayktkham.Value = Nothing) And (Not Me.dtpNgayktkham.Value = Nothing) And (Me.dtpNgayktkham.Value < Me.dtpNgaybdkham.Value) Then
            MessageBox.Show("Vui lòng thời gian kết thúc >= thời gian bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function
    Private Sub frmKhamBenhNgheNghiep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnBaocao.Visible = False
        LoadXuong()
        Me.radXuong.Checked = False
        Me.radTongquat.Checked = True
        Me.chkDenngay.Checked = False
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Select Case Me.tabKhamBenhNN.SelectedTab.Index
            Case 0
                ''============== xem danh sach kham benh ============== ''
                obj.XUONG = Me.cboXuong.Value
                If ThongBao() Then
                    Laythamso()
                    obj.ChonBang = 2
                    ''=================load len luoi =============''
                    Dim grid As New clsTformatGrid
                    Me.b = New ClassB_KhamBenhNgheNghiep
                    If obj.CHON_TUNAM Then
                        If Convert.ToInt32(obj.TUNAM) >= 2014 Then
                            Me.Path = "/layout/KhamBenhNgheNghiep_Mau2014.xml"
                        Else
                            Me.Path = "/layout/KhamBenhNgheNghiep.xml"
                        End If
                    Else
                        ''============= mặc định xem layout theo mẩu mới nhất ===========''
                        Me.Path = "/layout/KhamBenhNgheNghiep_Mau2014.xml"
                    End If
                    Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                    Dim dgrBC As Object = Me.dgrBC
                    grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrchucvu")
                End If
            Case 1
                ''=============== xem ket qua kham benh =================''
                Dim tngayk, dngayk As Date
                Dim chondenngay As Integer = 0
                If ThongBao() Then
                    obj.Setnull()
                    tngayk = Me.dtpNgaybdkham.Value
                    obj.TUNAM = tngayk.Year.ToString()
                    If chkDenngayk.Checked Then
                        dngayk = Me.dtpNgayktkham.Value
                        obj.DENNAM = dngayk.Year.ToString()
                        chondenngay = 1
                    End If
                    Dim grid As New clsTformatGrid
                    Me.b = New ClassB_KhamBenhNgheNghiep
                    Me.Path = "/layout/ThongKeKhamBenhNgheNghiep_Xuong.xml"

                    Me.dgrBC.DataSource = Me.b.ThongKeTheoXuong(obj, chondenngay)
                    Dim dgrBC As Object = Me.dgrBC
                    grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrchucvu")

                    ''=========== tinh tong cac cot can tinh ===================''
                    Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
                    band.Layout.Bands(0).Summaries.Clear()

                    Dim columnToSummarize1 As UltraGridColumn = band.Layout.Bands(0).Columns("BINHTHUONG")
                    Dim summary1 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng BT:", SummaryType.Sum, columnToSummarize1)
                    summary1.Appearance.TextHAlign = HAlign.Right
                    summary1.DisplayFormat = "Tổng BT = {0}"

                    Dim columnToSummarize2 As UltraGridColumn = band.Layout.Bands(0).Columns("GIAMHOHAP")
                    Dim summary2 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize2)
                    summary2.Appearance.TextHAlign = HAlign.Right
                    summary2.DisplayFormat = "Tổng Giảm Hô Hấp = {0}"

                    Dim columnToSummarize3 As UltraGridColumn = band.Layout.Bands(0).Columns("GIAMTHINHLUC")
                    Dim summary3 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize3)
                    summary3.Appearance.TextHAlign = HAlign.Right
                    summary3.DisplayFormat = "Tổng Giảm Thính Lực = {0}"

                    Dim columnToSummarize4 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGLOAIKSK")
                    Dim summary4 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize4)
                    summary4.Appearance.TextHAlign = HAlign.Right
                    summary4.DisplayFormat = "Tổng SL Khám SK = {0}"

                    Dim columnToSummarize5 As UltraGridColumn = band.Layout.Bands(0).Columns("TONGKBNN")
                    Dim summary5 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize5)
                    summary5.Appearance.TextHAlign = HAlign.Right
                    summary5.DisplayFormat = "Tổng SL Bệnh NN = {0}"

                    Dim columnToSummarize6 As UltraGridColumn = band.Layout.Bands(0).Columns("SL_CHUYENCV")
                    Dim summary6 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize6)
                    summary6.Appearance.TextHAlign = HAlign.Right
                    summary6.DisplayFormat = "Tổng SL Chuyển CV = {0}"

                    Dim columnToSummarize7 As UltraGridColumn = band.Layout.Bands(0).Columns("LOAI1")
                    Dim summary7 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize7)
                    summary7.Appearance.TextHAlign = HAlign.Right
                    summary7.DisplayFormat = "LOẠI 1 = {0}"

                    Dim columnToSummarize8 As UltraGridColumn = band.Layout.Bands(0).Columns("LOAI2")
                    Dim summary8 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize8)
                    summary8.Appearance.TextHAlign = HAlign.Right
                    summary8.DisplayFormat = "LOẠI 2 = {0}"

                    Dim columnToSummarize9 As UltraGridColumn = band.Layout.Bands(0).Columns("LOAI3")
                    Dim summary9 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize9)
                    summary9.Appearance.TextHAlign = HAlign.Right
                    summary9.DisplayFormat = "LOẠI 3 = {0}"

                    Dim columnToSummarize10 As UltraGridColumn = band.Layout.Bands(0).Columns("LOAI4")
                    Dim summary10 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize10)
                    summary10.Appearance.TextHAlign = HAlign.Right
                    summary10.DisplayFormat = "LOẠI 4 = {0}"

                    Dim columnToSummarize11 As UltraGridColumn = band.Layout.Bands(0).Columns("LOAI5")
                    Dim summary11 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize11)
                    summary11.Appearance.TextHAlign = HAlign.Right
                    summary11.DisplayFormat = "LOẠI 5 = {0}"

                    band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                    band.SummaryFooterCaption = "Tổng số: "
                End If
        End Select
    End Sub
    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        Dieukhien()
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer = 0
        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next
    End Sub
    Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        If Me.dgrBC.Rows.Count > 0 Then
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        Else
            MessageBox.Show("Không có dữ liệu trên lưới, không thể xuất Excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub chkTungay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTungay.CheckedChanged
        Dieukhien()
    End Sub
    Private Sub chkDenngay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDenngay.CheckedChanged
        Dieukhien()
    End Sub
    Private Sub radSuckhoe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSuckhoe.CheckedChanged
        Dieukhien()
    End Sub
    Private Sub radBenhNN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBenhNN.CheckedChanged
        Dieukhien()
    End Sub
    Private Sub chkKhongBenh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKhongBenh.CheckedChanged
        If Me.chkKhongBenh.Checked Then
            If radSuckhoe.Checked Then
                Me.chkBenhSK.Checked = False
                Me.chkBenhSK.Enabled = False
            End If
            If radBenhNN.Checked Then
                Me.chkHoHap.Checked = False
                Me.chkThinhluc.Checked = False
                Me.chkHoHap.Enabled = False
                Me.chkThinhluc.Enabled = False
                Me.chkBenhSK.Enabled = False
                Me.chkBenhSK.Checked = False
            End If
        Else
            If radBenhNN.Checked Then
                Me.chkBenhSK.Checked = False
                Me.chkBenhSK.Enabled = False
                Me.chkCVNNDH.Checked = False
                Me.chkCVNNDH.Enabled = False
                Me.chkHoHap.Enabled = True
                Me.chkThinhluc.Enabled = True
            End If
            If radSuckhoe.Checked Then
                Me.chkBenhSK.Checked = False
                Me.chkBenhSK.Enabled = True
                Me.chkCVNNDH.Checked = False
                Me.chkCVNNDH.Enabled = True
            End If
        End If
    End Sub
    Private Sub radTongquat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongquat.CheckedChanged
        If Me.radTongquat.Checked = False Then
            Me.radSuckhoe.Checked = False
            Me.radBenhNN.Checked = False
            ''=========== BO CHECK TAT CA DE CHON LAI ===============''
            Me.chkKhongBenh.Checked = False
            Me.chkBenhSK.Checked = False
            Me.chkCVNNDH.Checked = False
            Me.chkHoHap.Checked = False
            Me.chkThinhluc.Checked = False
        End If
    End Sub
    Private Sub chkDenngayk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDenngayk.CheckedChanged
        Dieukhien()
    End Sub

    Private Sub radBenhPK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBenhPK.CheckedChanged
        Dieukhien()
    End Sub
End Class