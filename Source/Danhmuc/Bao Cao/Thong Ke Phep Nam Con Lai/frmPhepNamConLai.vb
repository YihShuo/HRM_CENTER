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
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System.Data
Imports System.Resources
Imports TD.SandBar
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction


Public Class frmPhepNamConLai
    Dim obj As New ObjPhepNamConLai
    Friend WithEvents b As ClsB_PhepNamConLai
    Public reportID As String
    Public para As Object()
    Public issysReport As Boolean
    Public sortAtt As String()
    Dim Path As String

    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmPhepNamConLai_Load)
        Me.InitializeComponent()
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhepNamConLai
        Me.Path = "\Layout\PhepNamConLai.xml"
        obj.ChonBang = 5
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrchucvu")
    End Sub

    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhepNamConLai
        Me.Path = "\Layout\PhepNamConLai.xml"
        obj.ChonBang = 6
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrchucvu")
    End Sub

    Private Sub frmPhepNamConLai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.methodLoad()
    End Sub

    Private Sub cbNam_BeforeDropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbNam.BeforeDropDown
        obj.ChonBang = 7
        Me.b = New ClsB_PhepNamConLai
        Me.cbNam.DataSource = Me.b.LoadDS(obj)
        Me.cbNam.DisplayMember() = "PN_NAM"
        Me.cbNam.ValueMember() = "PN_NAM"
        Me.cbNam.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub cbXuong_BeforeDropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbXuong.BeforeDropDown
        obj.ChonBang = 8
        Me.b = New ClsB_PhepNamConLai
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.DisplayMember() = "X_MA_"
        Me.cbXuong.ValueMember() = "X_MA_"
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub cbXuong_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbXuong.ValueChanged
        'Khi chọn Xưởng --> Đơn Vị sẽ tự Load lên, 
        obj.XUONG = Me.cbXuong.Value
        obj.ChonBang = 9
        Me.b = New ClsB_PhepNamConLai
        Me.cbDonVi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonVi.DisplayMember() = "DV_MA"
        Me.cbDonVi.ValueMember() = "DV_MA"
        Me.cbDonVi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        cbDonVi.Text = ""
    End Sub

    Private Sub btnXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemBaoCao.Activate
        Dim report As New FrmReport

        If Me.cbNam.Text <> "" And Me.cbXuong.Text = "" And Me.cbDonVi.Text = "" Then
            Me.reportID = "1001"
            report.reportID = Me.reportID
            Dim strArray As String() = New String() {Me.cbNam.Text}
            report.para = strArray
            report.issysReport = True
            MessageBox.Show("Mở báo cáo theo Năm ?!")
            report.Show()
            Me.cbNam.Text = ""

        ElseIf Me.cbNam.Text <> "" And Me.cbXuong.Text <> "" And Me.cbDonVi.Text = "" Then
            Me.reportID = "1002"
            report.reportID = Me.reportID
            Dim strArray As String() = New String() {Me.cbNam.Text, Me.cbXuong.Text}
            report.para = strArray
            report.issysReport = True
            MessageBox.Show("Mở báo cáo theo Năm, Xưởng?!")
            report.Show()
            Me.cbNam.Text = ""
            Me.cbXuong.Text = ""

        ElseIf Me.cbNam.Text <> "" And Me.cbXuong.Text <> "" And Me.cbDonVi.Text <> "" Then
            Me.reportID = "1003"
            report.reportID = Me.reportID
            Dim strArray As String() = New String() {Me.cbNam.Text, Me.cbXuong.Text, Me.cbDonVi.Text}
            report.para = strArray
            report.issysReport = True
            MessageBox.Show("Mở báo cáo theo Năm, Xưởng, Đơn Vị?!")
            report.Show()
            Me.cbNam.Text = ""
            Me.cbXuong.Text = ""
            Me.cbDonVi.Text = ""

        ElseIf Me.cbNam.Text = "" And (Me.cbXuong.Text = "" Or Me.cbXuong.Text <> "") And (Me.cbDonVi.Text = "" Or Me.cbDonVi.Text <> "") Then
            MessageBox.Show("Vui lòng chọn Năm để xem báo cáo!", "Thông Báo")
            Me.cbNam.Focus()
        End If

    End Sub

    Friend WithEvents rptHHHD As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class