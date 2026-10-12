Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Excel

Public Class frmThongKeSoNgayNghiOMCOTrongNam
    Dim i As Integer
    Public fWaiting As frmWaiting_PhepOMCO
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Public obj As New objThongKeSoNgayNghiOMCOTrongNam
    Private Sub btnTinhPhepOMCO_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhPhepOMCO.Activate
        Xoadulieuphepcu()
        Taidulieuphep_OMCO()
        LockButton(True)
        btnTinhPhepOMCO.Enabled = True
    End Sub
    Friend WithEvents b As clsBThongKeSoNgayNghiOMCOTrongNam
    Private Sub Xoadulieuphepcu()
        Dim listpar As New ArrayList(4)
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        listpar.Add(New SqlParameter("@NAM", Me.cboNam.Text))
        Try
            Me.b.GoiThuTuc("SP_DANHSACHNGHI_OM_CO_D", listpar)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show(exception.Message)
        End Try
        listpar.Clear()
    End Sub
    Private Sub Taidulieuphep_OMCO()
        Dim listpar As New ArrayList(4)
        Dim listpar1 As New ArrayList(2)
        Dim tbl As DataTable
        Dim obj As New objThongKeSoNgayNghiOMCOTrongNam
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        fWaiting = frmWaiting_PhepOMCO.ShowProgress(Me)

        listpar1.Add(New SqlParameter("@NAM", Me.cboNam.Text))
        tbl = Me.b.GoiThuTuc_LoadBang("SP_DANHSACHNGHI_OM_CO_S", listpar1).Tables(0)
        listpar1.Clear()
        If tbl.Rows.Count > 0 Then
            For i = 0 To tbl.Rows.Count - 1
                listpar.Add(New SqlParameter("@NV_MA", tbl.Rows(i).Item("NV_MA")))
                listpar.Add(New SqlParameter("@TNGAY", tbl.Rows(i).Item("NP_TUNGAY")))
                listpar.Add(New SqlParameter("@DNGAY", tbl.Rows(i).Item("NP_DENNGAY")))
                listpar.Add(New SqlParameter("@NP_MA", tbl.Rows(i).Item("NP_MA")))
                Try
                    Me.b.GoiThuTuc("SP_TACHSONGAYNGHIPHEP_OM_CO", listpar)
                Catch ex As Exception
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    MessageBox.Show(exception.Message)
                End Try
                listpar.Clear()
            Next



        End If
        fWaiting.CloseProgress()
        Me.BringToFront()
        frmMain.SendToBack()
        MessageBox.Show("Đã tải dữ liệu xong.", "Thông báo")


    End Sub
    Private Sub LoadAllCombo()
        Dim i As Integer
        Dim obj As New objThongKeSoNgayNghiOMCOTrongNam
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        For i = 2015 To 2020
            Me.cboNam.Items.Add(i)
        Next
        cboNam.Value = Now.Year.ToString()
        Me.cboLoaiPhep.Items.Add("OM", "Phép ốm")
        Me.cboLoaiPhep.Items.Add("CO", "Phép con ốm")
        Me.cboLoaiPhep.SelectedIndex = 0

        'obj.ChonBang = 1
        'Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        'Me.cboXuong.SelectedIndex = 0
        'Me.cboXuong.ValueMember() = "X_MA_"
        'Me.cboXuong.DisplayMember() = "X_TEN"
        'Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub
    Private Sub frmThongKeSoNgayNghiOMCOTrongNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAllCombo()
        Me.rbtTCT.Checked = True
        rbtChiTiet.Checked = True
        LockButton(False)

    End Sub

    ' Lock button để người dùng cập nhật dữ liệu trước khu xem báo cáo
    Public Function LockButton(ByVal f As Boolean) As Boolean
        btnExel.Enabled = f
        btnXem.Enabled = f
        btnXemBaoCao.Enabled = f
        btnTinhPhepOMCO.Enabled = Not f
    End Function
    Private Sub btnXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemBaoCao.Activate
        Me.rptTKPhepHuongBHXH.BringToFront()
        Me.rptTKPhepHuongBHXH.Visible = True
        Me.dgrBC.Visible = False
        Me.btnExel.Visible = False

        LayThamSo()
        HienThiReport()
    End Sub
    Private Function LoadDanhSachNghi_Co_Namchitiet(ByVal sNam As String, ByVal sKhu As String) As DataTable
        Dim obj As New objThongKeSoNgayNghiOMCOTrongNam
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        Dim listpar As New ArrayList(2)
        Dim tbl As DataTable
        listpar.Add(New SqlParameter("@NAM", Me.cboNam.Text))
        listpar.Add(New SqlParameter("@KHU", sKhu))

        Try
            tbl = Me.b.GoiThuTuc_LoadBang("SP_THONGKENGHI_CO_TRONGNAM_S_2018", listpar).Tables(0)
            listpar.Clear()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show(exception.Message)
            Return Nothing
        End Try
        Return tbl
    End Function
    Private Function LoadDanhSachNghi_OM_CO_NamTong(ByVal sNam As String, ByVal skhu As String) As DataTable
        Dim obj As New objThongKeSoNgayNghiOMCOTrongNam
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        Dim listpar As New ArrayList(5)
        Dim tbl As DataTable
        listpar.Add(New SqlParameter("@Nam", Me.cboNam.Text))
        listpar.Add(New SqlParameter("@LOAIPHEP", Me.cboLoaiPhep.Value.ToString()))
        listpar.Add(New SqlParameter("@KHU", skhu))

        Try
            tbl = Me.b.GoiThuTuc_LoadBang("SP_THONGKENGHIPHEP_OM_CO_TONG_2018", listpar).Tables(0)
            'tbl = Me.b.GoiThuTuc_LoadBang("SP_THONGKENGHIPHEP_OM_CO_TONG_NAM_DEMO", listpar).Tables(0)
            listpar.Clear()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show(exception.Message)
            Return Nothing
        End Try
        Return tbl
    End Function


    Private Function LoadDanhSachNghi_OM_NamChiTiet(ByVal sNam As String, ByVal sKhu As String) As DataTable
        Dim obj As New objThongKeSoNgayNghiOMCOTrongNam
        Me.b = New clsBThongKeSoNgayNghiOMCOTrongNam
        Dim listpar As New ArrayList(5)
        Dim tbl As DataTable
        listpar.Add(New SqlParameter("@Nam", Me.cboNam.Text))
        listpar.Add(New SqlParameter("@KHU", sKhu))


        Try
            tbl = Me.b.GoiThuTuc_LoadBang("SP_THONGKENGHI_OM_TRONGNAM_S_2018", listpar).Tables(0)
            'tbl = Me.b.GoiThuTuc_LoadBang("SP_THONGKENGHI_OM_TRONGNAM_S_NAMDEMO", listpar).Tables(0)
            listpar.Clear()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            MessageBox.Show(exception.Message)
            Return Nothing
        End Try
        Return tbl
    End Function

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
        Me.rptTKPhepHuongBHXH.ReportSource = document
    End Sub
    Private Sub LayThamSo()

        Dim khu As String
        If rbtKhuA.Checked Then
            khu = "A"
        End If
        If rbtKhuB.Checked Then
            khu = "B"
        End If
        If rbtDVC.Checked Then
            khu = "DVC"
        End If
        If rbtTCT.Checked Then
            khu = "TCT"
        End If
        If rbtTongThe.Checked Then
            Dim nam As String = cboNam.Text.ToString
            Dim loaiphep As String = cboLoaiPhep.Value.ToString

            reportID = "614"
            Dim strArray As String() = New String() {loaiphep, nam, khu}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()

            Exit Sub

        End If

        If rbtChiTiet.Checked Then
            Dim nam As String
            nam = Me.cboNam.Text
            If Me.cboLoaiPhep.Value = "OM" Then
                reportID = "NS_TKOM"
            Else
                reportID = "NS_TKCO"
            End If
            Dim strArray As String() = New String() {khu, nam}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub

        End If

    End Sub



    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Me.btnExel.Visible = True
        Dim khu As String
        If rbtKhuA.Checked Then
            khu = "A"
        End If
        If rbtKhuB.Checked Then
            khu = "B"
        End If
        If rbtDVC.Checked Then
            khu = "DVC"
        End If
        If rbtTCT.Checked Then
            khu = "TCT"
        End If
        If rbtChiTiet.Checked Then
            Dim grid As New clsTformatGrid
            Dim pathXML As String
            Me.dgrBC.BringToFront()
            Me.dgrBC.Visible = True
            Me.rptTKPhepHuongBHXH.Visible = False
            Select Case Me.cboLoaiPhep.Value
                Case "OM"
                    pathXML = "/layout/NghiOMTrongNam.xml"
                    Me.dgrBC.DataSource = LoadDanhSachNghi_OM_NamChiTiet(Me.cboNam.Text, khu)
                Case "CO"
                    pathXML = "/layout/NghiCOTrongNam.xml"
                    Me.dgrBC.DataSource = LoadDanhSachNghi_Co_Namchitiet(Me.cboNam.Text, khu)
            End Select
            clsTools.GridTheme1(Me.dgrBC)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & pathXML), typeControl.Grid, "coldgrNghiPhep")
        ElseIf rbtTongThe.Checked Then
            Dim grid As New clsTformatGrid
            Dim pathXML As String
            Me.dgrBC.BringToFront()
            Me.dgrBC.Visible = True
            Me.rptTKPhepHuongBHXH.Visible = False
            Select Case Me.cboLoaiPhep.Value
                Case "OM"
                    pathXML = "/layout/NghiOMCOXUONG.xml"
                    Me.dgrBC.DataSource = LoadDanhSachNghi_OM_CO_NamTong(Me.cboNam.Text, khu)
                    GirdColor()
                Case "CO"
                    pathXML = "/layout/NghiOMCOXUONG.xml"
                    Me.dgrBC.DataSource = LoadDanhSachNghi_OM_CO_NamTong(Me.cboNam.Text, khu)
                    GirdColor()
            End Select
            clsTools.GridTheme1(Me.dgrBC)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & pathXML), typeControl.Grid, "coldgrNghiPhep")
        End If
        MessageBox.Show("Tải dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)





    End Sub

    Public Sub GirdColor()
        Dim i As Integer
        For i = 0 To dgrBC.Rows.Count - 1
            If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TKA" Or dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TKB" Or dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TDVC" Then
                '' MÀU CELL
                Me.dgrBC.Rows(i).Cells("STT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T1").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T2").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T3").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T4").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T5").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T6").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T7").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T8").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T9").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T10").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T11").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T12").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("STT").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("STT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T1").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T1").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T2").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T2").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T3").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T3").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T4").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T4").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T5").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T5").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T6").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T6").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T7").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T7").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T8").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T8").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T9").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T9").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T10").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T10").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T11").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T11").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T12").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T12").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red
            End If
            If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TCT" Then

                Me.dgrBC.Rows(i).Cells("STT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T1").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T2").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T3").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T4").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T5").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T6").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T7").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T8").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T9").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T10").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T11").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T12").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("STT").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("STT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("XUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T1").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T1").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T2").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T2").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T3").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T3").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T4").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T4").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T5").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T5").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T6").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T6").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T7").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T7").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T8").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T8").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T9").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T9").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T10").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T10").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T11").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T11").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T12").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T12").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red
            End If
        Next

    End Sub
   

    Private Sub cboNam_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles cboNam.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub

    ' Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
    '   e.Row.Cells("STT").Value = e.Row.Index + 1
    'End Sub

    Private Sub btnExel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            'Process.Start(Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


End Class