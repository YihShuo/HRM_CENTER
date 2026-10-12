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
Imports TYXUAN_NS.clsLanguage

Public Class frmHocVan

    Inherits Form

    Dim ReportID As String
    Dim PATH As String
    Dim TABLE As String
    Dim chkStateXuong As Boolean
    Dim chkStateNganh As Boolean
    Dim btnStateXem As Boolean

    Public language As Integer

    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmHocVan_Load)
        Me.InitializeComponent()
    End Sub

    Private Sub frmHocVan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.language = 1) Then
            Me.VietNam()
        ElseIf (Me.language = 2) Then
            Me.TaiWan()
        End If

        Dim obj As New objHocVan
        obj.ChonBang = 1
        obj.Table = "JELL_DONVI"
        Me.b = New clsBHocVan
        Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        Me.radTongQuat.Checked = True
        Me.Trangthaidieukien()

    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objHocVan
        obj.Setnull()
        obj.Table = Me.TABLE
        '===========================================================
        If Me.radTongQuat.Checked = True Then
            obj.ChonBang = 2
        End If
        '===========================================================
        If Me.radXuong.Checked = True Then
            obj.ChonBang = 6
            If Me.cboXuong.Value <> "" Then
                obj.XUONG = Me.cboXuong.Value.ToString()
            Else
                MessageBox.Show("Hãy chọn Xưởng để xem!")
                Me.cboXuong.Focus()
                Exit Sub
            End If
        End If
        '===========================================================
        If Me.radNganh.Checked = True Then
            obj.ChonBang = 7
            If Me.cboXuong.Value <> "" And Me.cboNganh.Value <> "" Then
                obj.XUONG = Me.cboXuong.Value.ToString()
                obj.NGANH = Me.cboNganh.Value.ToString()
            End If
            If Me.cboXuong.Value = "" And Me.cboNganh.Value <> "" Then
                MessageBox.Show("Hãy chọn Xưởng để xem!")
                Me.cboXuong.Focus()
                Exit Sub
            End If
            If Me.cboXuong.Value <> "" And Me.cboNganh.Value = "" Then
                MessageBox.Show("Hãy chọn Ngành để xem!")
                Me.cboNganh.Focus()
                Exit Sub
            End If
            If Me.cboXuong.Value = "" And Me.cboNganh.Value = "" Then
                MessageBox.Show("Hãy chọn Xưởng, Ngành để xem!")
                Me.cboNganh.Focus()
                Exit Sub
            End If
        End If

        obj.NGAY = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrMayChamCong")
    End Sub

    Private Sub radTongQuat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongQuat.CheckedChanged
        Me.Trangthaidieukiencheck()
        If (Me.radTongQuat.Checked = True) Then


            Me.chkXuong.Checked = False
            Me.cboXuong.Text = ""
            Me.chkNganh.Checked = False
            Me.cboNganh.Text = ""

            Me.ReportID = "081"
            clsTools.GridTheme1(Me.dgrBC)
            Me.b = New clsBHocVan
            Me.PATH = "/layout/HocVan_1.xml"
            Me.TABLE = "VIEW_HOCVAN"
            'Me.methodLoad()
        End If
    End Sub

    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged

        Me.Trangthaidieukiencheck()
        If (Me.radXuong.Checked = True) Then

            Me.chkXuong.Checked = False
            Me.cboXuong.Text = ""
            Me.chkNganh.Checked = False
            Me.cboNganh.Text = ""

            Me.ReportID = "082"
            clsTools.GridTheme1(Me.dgrBC)
            Me.b = New clsBHocVan
            Me.PATH = "/layout/HocVan_2.xml"
            Me.TABLE = "VIEW_HOCVAN_2"
            'Me.methodLoad()

        End If
    End Sub

    Private Sub radNganh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNganh.CheckedChanged
        Me.Trangthaidieukiencheck()
        If (Me.radNganh.Checked = True) Then

            Me.chkXuong.Checked = False
            Me.cboXuong.Text = ""
            Me.chkNganh.Checked = False
            Me.cboNganh.Text = ""

            Me.ReportID = "083"
            clsTools.GridTheme1(Me.dgrBC)
            Me.b = New clsBHocVan
            Me.PATH = "/layout/HocVan_3.xml"
            Me.TABLE = "VIEW_HOCVAN_3"
            'Me.methodLoad()
        End If
    End Sub

    Public Sub Trangthaidieukien()
        Me.cboXuong.Enabled = chkStateXuong
        Me.cboNganh.Enabled = chkStateNganh
    End Sub

    Public Sub Trangthaidieukiencheck()
        If Me.radTongQuat.Checked = True Then
            Me.chkNganh.Enabled = False
            Me.chkXuong.Enabled = False
        End If

        If Me.radXuong.Checked = True Then
            Me.chkNganh.Enabled = False
            Me.chkXuong.Enabled = True
        End If

        If Me.radNganh.Checked = True Then
            Me.chkNganh.Enabled = True
            Me.chkXuong.Enabled = True
        End If

    End Sub

    Private Sub chkXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXuong.CheckedChanged
        If (Me.chkXuong.Checked = False) Then
            Me.cboXuong.Text = ""

            Dim obj As New objHocVan
            obj.Table = "VIEW_HOCVAN_3"
            Me.b = New clsBHocVan
            obj.ID = "xuongkhongbiet"
            Me.cboNganh.DataSource = Me.b.LoadDS(obj)
        Else
            If Me.cboXuong.Text <> "" Then
                Me.ChonNganh()
            End If
        End If

        chkStateXuong = Me.chkXuong.Checked
        Me.Trangthaidieukien()
    End Sub

    Private Sub chkNganh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNganh.CheckedChanged
        If (Me.chkNganh.Checked = False) Then
            Me.cboNganh.Text = ""
        End If
        chkStateNganh = Me.chkNganh.Checked
        Me.Trangthaidieukien()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        If (Me.radXuong.Checked = True) Then
            If (Me.chkXuong.Checked = True) Then
                If (Me.cboXuong.Text = "") Then
                    MessageBox.Show("Bạn chưa chọn Xưởng")
                    Me.cboXuong.Focus()
                    Return
                End If
            Else
                MessageBox.Show("Bạn hãy check vào Xưởng để chọn Xưởng xem báo cáo!")
                Exit Sub
            End If
        End If

        If (Me.radNganh.Checked = True) Then
            If (Me.chkXuong.Checked = True) Then
                If (Me.cboXuong.Text = "") Then
                    MessageBox.Show("Bạn chưa chọn Xưởng")
                    Exit Sub
                    Return
                End If
            Else
                MessageBox.Show("Bạn hãy check vào Xưởng để chọn Xưởng xem báo cáo!")
                Me.cboXuong.Focus()

            End If

            If (Me.chkNganh.Checked = True) Then
                If (Me.cboNganh.Text = "") Then
                    MessageBox.Show("Bạn chưa chọn Ngành")
                    Return
                End If
            Else
                MessageBox.Show("Bạn hãy check vào Ngành để chọn Ngành xem báo cáo!")
                Me.cboXuong.Focus()
                Exit Sub

            End If
        End If

        Dim report As New FrmReport
        'Ma so report
        report.reportID = Me.ReportID
        Dim strArray As String() = New String() {Me.dtpNgay.Value}

        If (Me.radNganh.Checked = True) Then
            strArray = New String() {Me.cboXuong.Text, Me.cboNganh.Text, Me.chkXuong.Checked, Me.chkNganh.Checked, Me.dtpNgay.Value}
        End If

        If (Me.radXuong.Checked = True) Then
            strArray = New String() {Me.cboXuong.Text, Me.chkXuong.Checked, Me.dtpNgay.Value}
        End If

        report.para = strArray

        report.issysReport = True
        report.Show()
    End Sub


    Public Sub VietNam()
        Me.XpCaption1.Text = clsLanguage.ThongKeHocVanNhanVienCongTy()
        Me.UltraTabControl1.Tabs(0).Text = clsLanguage.ThongKeHocVan()
        Me.GroupBox1.Text = clsLanguage.DieuKienThongKe()
        Me.GroupBox2.Text = clsLanguage.DieuKienLoc()
        Me.radTongQuat.Text = clsLanguage.TongQuat()
        Me.radXuong.Text = clsLanguage.ThongKeTheoXuong()
        Me.radNganh.Text = clsLanguage.ThongKeTheoNganh()
        Me.chkXuong.Text = clsLanguage.Xuong()
        Me.chkNganh.Text = clsLanguage.Nganh()
        Me.btnIn.Text = clsLanguage.XemBaoCao()
        Me.XpCaption2.Text = clsLanguage.DanhMucThongKe()
    End Sub

    Public Sub TaiWan()
        Me.XpCaption1.Text = clsLanguage.ThongKeHocVanNhanVienCongTyTaiwan()
        Me.UltraTabControl1.Tabs(0).Text = clsLanguage.ThongKeHocVanTaiwan()
        Me.GroupBox1.Text = clsLanguage.DieuKienThongKeTaiwan()
        Me.GroupBox2.Text = clsLanguage.DieuKienLocTaiwan()
        Me.radTongQuat.Text = clsLanguage.TongQuatTaiwan()
        Me.radXuong.Text = clsLanguage.ThongKeTheoXuongTaiwan()
        Me.radNganh.Text = clsLanguage.ThongKeTheoNganhTaiwan()
        Me.chkXuong.Text = clsLanguage.XuongTaiwan()
        Me.chkNganh.Text = clsLanguage.NganhTaiwan()
        Me.btnIn.Text = clsLanguage.XemBaoCaoTaiwan()
        Me.XpCaption2.Text = clsLanguage.DanhMucThongKeTaiwan()
    End Sub

    Private Sub ChonNganh()
        Dim obj As New objHocVan
        obj.Table = "JELL_DONVI"
        Me.cboNganh.Text = ""
        Me.b = New clsBHocVan
        obj.ID = Me.cboXuong.Text
        obj.ChonBang = 3
        Me.cboNganh.DataSource = Me.b.LoadDS(obj)
    End Sub

    Private Sub cboXuong_BeforeDropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboXuong.BeforeDropDown
        Dim obj As New objHocVan
        obj.ChonBang = 4
        obj.Table = "JELL_DONVI"
        Me.b = New clsBHocVan
        Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        Me.cboXuong.DisplayMember() = "X_MA_"
        Me.cboXuong.ValueMember() = "X_MA_"
        Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub cboXuong_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXuong.ValueChanged
        'Me.ChonNganh()
        Dim obj As New objHocVan
        obj.ChonBang = 5
        obj.XUONG = Me.cboXuong.Value
        obj.Table = "JELL_DONVI"
        Me.b = New clsBHocVan
        Me.cboNganh.DataSource = Me.b.LoadDS(obj)
        Me.cboNganh.DisplayMember() = "N_MA"
        Me.cboNganh.ValueMember() = "N_MA"
        Me.cboNganh.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub btnXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Click
        Me.methodLoad()
    End Sub
End Class