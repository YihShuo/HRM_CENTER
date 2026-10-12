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
Public Class frmTieuChuan_
    Dim Tabletemp As DataTable
    Friend WithEvents b As New clsBTieuChuan
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.b = New clsBTieuChuan
        If Me.cbTieuChuan.Text = "" Then
            MessageBox.Show("Bạn phải chọn loại tiêu chuẩn")
        Else

            'Load danh sach nhan vien theo don vi
            If Me.cbTieuChuan.Text = "Tiêu chuẩn 1" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhTieuChuan1()

                obj.ChonBang = 1
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu1(Me.Tabletemp)
            End If
            If Me.cbTieuChuan.Text = "Tiêu chuẩn 2" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                Me.TinhTieuChuan2()

                obj.ChonBang = 2
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu2(Me.Tabletemp)
            End If
            If Me.cbTieuChuan.Text = "Tiêu chuẩn 3" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhTieuChuan3()
                obj.ChonBang = 3
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu3(Me.Tabletemp)
            End If
            If Me.cbTieuChuan.Text = "Tiêu chuẩn 4" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                Me.TinhTieuChuan4()
                obj.ChonBang = 4
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu4(Me.Tabletemp)
            End If
            If Me.cbTieuChuan.Text = "Tiêu chuẩn xuất sắc" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                Me.TinhTieuChuanXS()
                obj.ChonBang = 5
                Me.Tabletemp = Me.b.LoadDS(obj)
                LocdulieuXS(Me.Tabletemp)
            End If
        End If
    End Sub
    Dim oldRow As Integer = 0
    Public Shared obj As New objTieuChuan
    Public Sub TinhTieuChuan1()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_TIEUCHUAN1", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhTieuChuan2()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_TIEUCHUAN2", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhTieuChuan3()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_TIEUCHUAN3", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhTieuChuan4()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_TIEUCHUAN4", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhTieuChuanXS()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_TIEUCHUANXS", listpar)
        listpar.Clear()
    End Sub
    Private Sub Locdulieu1(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TieuChuan1.xml"), typeControl.Grid, "TieuChuan1")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Private Sub Locdulieu2(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TieuChuan2.xml"), typeControl.Grid, "TieuChuan2")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Private Sub Locdulieu3(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TieuChuan3.xml"), typeControl.Grid, "TieuChuan3")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Private Sub Locdulieu4(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TieuChuan4.xml"), typeControl.Grid, "TieuChuan4")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Private Sub LocdulieuXS(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TieuChuanXS.xml"), typeControl.Grid, "TieuChuanSX")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub frmTieuChuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbThongKeTC.Visible = False
        Dim nam As Integer
        Dim NGAY As Date = Now
        nam = Convert.ToInt32(NGAY.Year.ToString())
        For nam = 2011 To nam
            Me.cbNam.Items.Add(nam.ToString)
        Next
    End Sub

    Private Sub cbNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNam.SelectedIndexChanged
        Dim thang As Integer
        Me.cbTuNgay.Items.Clear()
        Me.cbDenNgay.Items.Clear()
        For thang = 1 To 12
            Me.cbTuNgay.Items.Add(Microsoft.VisualBasic.Right("0" & thang.ToString, 2) & "-" & cbNam.Text)
            Me.cbDenNgay.Items.Add(Microsoft.VisualBasic.Right("0" & thang.ToString, 2) & "-" & cbNam.Text)
        Next
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        If Me.cbTieuChuan.Text <> "" And Me.cbNam.Text <> "" And Me.cbTuNgay.Text <> "" And Me.cbDenNgay.Text <> "" Then
            Me.Tim()
        End If
    End Sub

    Private Sub cbTieuChuan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTieuChuan.SelectedIndexChanged
        Me.dgrBC.DataSource = Nothing
        Me.txtSonhanvien.Text = ""
    End Sub

    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        Dim nam As String
        nam = Microsoft.VisualBasic.Right(Me.cbDenNgay.Text, 4)
        Dim report As New FrmReport
        If Me.cbTieuChuan.Text = "Tiêu chuẩn 1" Then
            report.reportID = "987"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        End If
        If Me.cbTieuChuan.Text = "Tiêu chuẩn 2" Then

            report.reportID = "988"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        End If
        If Me.cbTieuChuan.Text = "Tiêu chuẩn 3" Then
            report.reportID = "989"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        End If
        If Me.cbTieuChuan.Text = "Tiêu chuẩn 4" Then
            report.reportID = "990"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        End If
        If Me.cbTieuChuan.Text = "Tiêu chuẩn xuất sắc" Then
            report.reportID = "991"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        End If
        report.issysReport = True
        report.Show()
    End Sub
    Private Sub lbThongKeTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbThongKeTC.Click
        Dim report As New FrmReport
        report.reportID = "993"
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub lbThongKeBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim report As New FrmReport
        report.reportID = "992"
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class