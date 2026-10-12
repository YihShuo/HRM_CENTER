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
Public Class frmThongKeNghiPhep
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmThongKeNghiPhep_Load)
        Me.InitializeComponent()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeNghiPhep
        Me.Path = "/layout/ThongKeNghiPhep.xml"
        Dim NGAY As Date
        NGAY = Me.cbNgaythangnam.Text
        Dim NGAY2 As String
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2
        obj.DonVi = Me.cbDonvi.Text
        obj.ChonBang = 3
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub frmThongKeNghiPhep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 2

        'Load Don Vi
        Me.b = New clsBThongKeNghiPhep
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)

        'Chon Don Vi dau tien trong combo
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        ' load chuc vu
        obj.ChonBang = 4

        'Load Don Vi
        Me.b = New clsBThongKeNghiPhep
        Me.cbChucVu.DataSource = Me.b.LoadDS(obj)
        Me.cbChucVu.DisplayMember() = "CVU_TEN"
        Me.cbChucVu.ValueMember() = "CVU_MA"

        'Chon Don Vi dau tien trong combo
        Me.cbChucVu.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest


        Me.cbDonvi.Enabled = False
        Me.cbChucVu.Enabled = False

        Me.btEx.Enabled = False
        Me.btXemBC.Enabled = False

    End Sub
   
    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeNghiPhep
        Me.Path = "/layout/ThongKeChucVu.xml"
        Dim NGAY As Date
        NGAY = Me.cbNgaythangnam.Text
        Dim NGAY2 As String
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2
        obj.ChucVu = Me.cbChucVu.Value
        obj.ChonBang = 5
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btXemBC_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Activate
        If Me.chkDV.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "500"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {"'" + Me.cbDonvi.Text + "'", Me.cbNgaythangnam.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
        If Me.chkCV.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "585"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNgaythangnam.Text, "'" + Me.cbChucVu.Value + "'"}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
        
    End Sub

    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    ' Khai bao bien toan cuc
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Dim obj As New objThongKeNghiPhep

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.methodLoad()
        Me.btEx.Enabled = True
        Me.btXemBC.Enabled = True
    End Sub
    Private Sub chkDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDV.CheckedChanged
        If Me.chkDV.Checked = True Then
            Me.chkCV.Checked = False
            Me.cbDonvi.Enabled = True
        Else
            Me.chkCV.Checked = True
            Me.cbChucVu.Enabled = True
            Me.cbDonvi.Enabled = False
            Me.cbDonvi.Clear()
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub
    Private Sub chkCV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCV.CheckedChanged
        If Me.chkCV.Checked = True Then
            Me.chkDV.Checked = False
            Me.cbChucVu.Enabled = True
        Else
            Me.chkDV.Checked = True
            Me.cbDonvi.Enabled = True
            Me.cbChucVu.Enabled = False
            Me.cbChucVu.Clear()
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub
    Private Sub cbChucVu_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChucVu.ValueChanged
        Me.methodLoad2()
        Me.btEx.Enabled = True
        Me.btXemBC.Enabled = True
    End Sub
End Class