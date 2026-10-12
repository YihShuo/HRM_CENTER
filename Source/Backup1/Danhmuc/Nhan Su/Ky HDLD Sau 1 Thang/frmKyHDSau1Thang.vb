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
Public Class frmKyHDSau1Thang

    Dim Tabletemp, Tabletemp1 As DataTable
    Friend WithEvents b As clsBKyHDSau1Thang
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim obj As New objKyHDSau1Thang
    Private Sub LoadDV()
        obj.ChonBang = 1
        Me.b = New clsBKyHDSau1Thang
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0
        'End If
    End Sub
    Private Sub LoadXuong()
        obj.ChonBang = 3
        Me.b = New clsBKyHDSau1Thang
        Me.Tabletemp1 = Me.b.LoadDS(obj)
        Me.Tabletemp1.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbXuong.DataSource = Me.Tabletemp1
        Me.cbXuong.SelectedIndex = 0
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.Tabletemp1 = Nothing
        Dim TNGAY As Date
        TNGAY = Me.dtpTuNgay.Value
        Dim TUNGAY As String
        TUNGAY = TNGAY.Year.ToString() + "/" + TNGAY.Month.ToString() + "/" + TNGAY.Day.ToString()
        Dim DNGAY As Date
        DNGAY = Me.dtpDenNgay.Value
        Dim DENNGAY As String
        DENNGAY = DNGAY.Year.ToString() + "/" + DNGAY.Month.ToString() + "/" + DNGAY.Day.ToString()

        ''xet dieu kien dang chon xuong hay don vi
        If Me.radDonvi.Checked Then
            'Load danh sach nhan vien theo don vi
            obj.ChonBang = 2
            Me.b = New clsBKyHDSau1Thang
            obj.DonVi = Me.cbDonvi.Value.ToString()
            obj.TUNGAY = TUNGAY
            obj.DENNGAY = DENNGAY
            Me.Tabletemp = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp)
        End If
        If Me.radXuong.Checked Then
            'Load danh sach nhan vien theo xuong
            obj.ChonBang = 4
            Me.b = New clsBKyHDSau1Thang
            obj.Xuong = Me.cbXuong.Value.ToString()
            obj.TUNGAY = TUNGAY
            obj.DENNGAY = DENNGAY
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp1)
        End If
        If Me.radKhu.Checked Then
            'Load danh sach nhan vien theo xuong
            obj.ChonBang = 5
            If Me.cbKhu.Value = "A" Then
                obj.ChonKhu = "A"
            ElseIf Me.cbKhu.Value = "B" Then
                obj.ChonKhu = "B"
            ElseIf Me.cbKhu.Value = "DVC" Then
                obj.ChonKhu = "DVC"
            Else
                obj.ChonKhu = "TCT"
            End If
            Me.b = New clsBKyHDSau1Thang
            obj.Xuong = Me.cbXuong.Value.ToString()
            obj.TUNGAY = TUNGAY
            obj.DENNGAY = DENNGAY
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp1)
        End If
    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/KYHDLDSAU1THANG.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 5
            e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If Me.cbDonvi.Text <> "" Then
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub

    Private Sub cbXuong_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbXuong.ValueChanged
        obj.Xuong = cbXuong.Value.ToString()
        If obj.Xuong <> "" Then
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub
    Private Sub dtpTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTuNgay.ValueChanged
        If obj.Xuong = "" Or obj.DonVi = "" Then
            Exit Sub
        Else
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub
    Private Sub dtpDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDenNgay.ValueChanged
        If obj.Xuong = "" Or obj.DonVi = "" Then
            Exit Sub
        Else
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub
    Private Sub ChonDongCu()
        If Me.oldRow > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        End If
    End Sub
    Public Sub LAYDULIEU()
   
        Dim TNGAY As Date
        Me.dtpTuNgay.Format = DateTimePickerFormat.Short
        TNGAY = Me.dtpTuNgay.Text
        Dim TUNGAY As String
        TUNGAY = TNGAY.Year.ToString() + "/" + TNGAY.Month.ToString() + "/" + TNGAY.Day.ToString()
        Dim DNGAY As Date
        Me.dtpDenNgay.Format = DateTimePickerFormat.Short
        DNGAY = Me.dtpDenNgay.Text
        Dim DENNGAY As String
        DENNGAY = DNGAY.Year.ToString() + "/" + DNGAY.Month.ToString() + "/" + DNGAY.Day.ToString()
        obj.TUNGAY = TUNGAY
        obj.DENNGAY = DENNGAY
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@Tungay", obj.TUNGAY))
        listpar.Add(New SqlParameter("@Denngay", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_XETNANGLUONG1THANG", listpar)
        listpar.Clear()
    End Sub
    Private Sub btLayDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLayDuLieu.Click
        If MessageBox.Show("Bạn có thật sự muốn lấy dữ liệu ?", "Thông báo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.LAYDULIEU()
            Tim()
        End If
    End Sub
    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    Dim ma As String = activeCell.Row.Cells.Item("NV_MA").Text
                    If MessageBox.Show("Bạn có thật sự muốn xóa nhân viên " & ma & " này không ?", "Thông báo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        obj.ChonBang = 1
                        Me.b.DeleteInfo(obj)
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub
    Dim ReportID As String
    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        If obj.DonVi = "TCT" Or obj.Xuong = "TCT" Then
            Dim report As New FrmReport
            Me.ReportID = "30556"
            Me.dtpTuNgay.Format = DateTimePickerFormat.Short
            Me.dtpDenNgay.Format = DateTimePickerFormat.Short
            Dim aTuNgay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
            Dim bDenNgay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {aTungay, bDenNgay}
            report.para = strArray
            report.issysReport = True
            report.Show()
        Else
            ''in theo don vi
            If Me.radDonvi.Checked Then
                Dim report As New FrmReport
                Me.ReportID = "30555"
                Me.dtpTuNgay.Format = DateTimePickerFormat.Short
                Me.dtpDenNgay.Format = DateTimePickerFormat.Short
                Dim a As String = Me.dtpTuNgay.Value.Day.ToString
                Dim aTuNgay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
                Dim bDenNgay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()
                Dim DONVI As String
                DONVI = Me.cbDonvi.Value.ToString()
                report.reportID = Me.ReportID
                Dim strArray As String() = New String() {aTuNgay, bDenNgay, DONVI}
                report.para = strArray
                report.issysReport = True
                report.Show()
            End If
            ''in theo xuong
            If Me.radXuong.Checked Then
                Dim report As New FrmReport
                Me.ReportID = "30557"
                Me.dtpTuNgay.Format = DateTimePickerFormat.Short
                Me.dtpDenNgay.Format = DateTimePickerFormat.Short
                Dim aTuNgay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
                Dim bDenNgay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()
                Dim XUONG As String
                XUONG = Me.cbXuong.Value.ToString()
                report.reportID = Me.ReportID
                Dim strArray As String() = New String() {aTuNgay, bDenNgay, XUONG}
                report.para = strArray
                report.issysReport = True
                report.Show()
            End If
            ''in theo KHU
            If Me.radKhu.Checked Then

                Dim report As New FrmReport
                Me.ReportID = "30557KHU"
                Dim aTuNgay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
                Dim bDenNgay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()
                Dim KHU As String
                KHU = Me.cbKhu.Value.ToString()
                If KHU = "TCT" Then
                    Me.ReportID = "30556"
                    report.reportID = Me.ReportID
                    Dim strArray As String() = New String() {aTuNgay, bDenNgay}
                    report.para = strArray
                    report.issysReport = True
                    report.Show()
                Else
                    report.reportID = Me.ReportID
                    Dim strArray As String() = New String() {aTuNgay, bDenNgay, KHU}
                    report.para = strArray
                    report.issysReport = True
                    report.Show()
                End If
            End If
        End If
    End Sub
    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        If Me.radDonvi.Checked Then
            Me.radXuong.Checked = False
            Me.cbXuong.Enabled = False
            Me.radKhu.Checked = False
            Me.cbKhu.Enabled = False
            Me.cbDonvi.Enabled = True
            ''neu co chon, chon lai thi load lai
            If Me.cbDonvi.Value <> "" Then
                Me.Tim()
            End If
        End If
    End Sub
    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        obj.Setnull()
        If Me.radXuong.Checked Then
            obj.Xuong = Me.cbXuong.Value.ToString()
            Me.radDonvi.Checked = False
            Me.cbDonvi.Enabled = False
            Me.radKhu.Checked = False
            Me.cbKhu.Enabled = False
            Me.cbXuong.Enabled = True
            ''neu co chon, chon lai thi load lai
            If obj.Xuong <> "" Then
                Me.Tim()
            End If

        End If
    End Sub
    Private Sub frmKyHDSau1Thang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Tabletemp2 = New DataTable
        Tabletemp2.Columns.Add("MA_KHU", GetType(String))
        Tabletemp2.Columns.Add("TEN_KHU", GetType(String))
        Tabletemp2.Rows.Add("A", "KHU A")
        Tabletemp2.Rows.Add("B", "KHU B")
        Tabletemp2.Rows.Add("DVC", "Đơn vị chung")
        Tabletemp2.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbKhu.DataSource = Tabletemp2
        Me.cbKhu.DisplayMember = "TEN_KHU"
        Me.cbKhu.ValueMember = "MA_KHU"
        Me.cbKhu.SelectedIndex = 0

        Me.dtpTuNgay.Value = Now
        Me.dtpDenNgay.Value = Now
        LoadDV()
        LoadXuong()
    End Sub

    Private Sub radKhu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhu.CheckedChanged

        If Me.radKhu.Checked Then
            Me.radXuong.Checked = False
            Me.cbXuong.Enabled = False
            Me.radDonvi.Checked = False
            Me.cbDonvi.Enabled = False
            Me.cbKhu.Enabled = True
            If Me.cbKhu.Value <> "" Then
                Me.Tim()
            End If
        End If
    End Sub

    Private Sub cbKhu_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKhu.ValueChanged
        If Me.radKhu.Checked Then
            Me.radXuong.Checked = False
            Me.cbXuong.Enabled = False
            Me.radDonvi.Checked = False
            Me.cbDonvi.Enabled = False
            Me.cbKhu.Enabled = True
            ''neu co chon, chon lai thi load lai
            If Me.cbKhu.Value <> "" Then
                Me.Tim()
            End If
        End If
    End Sub
End Class