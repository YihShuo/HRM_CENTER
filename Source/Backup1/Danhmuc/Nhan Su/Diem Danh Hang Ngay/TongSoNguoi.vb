
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
Public Class TongSoNguoi
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.TongSoNguoi_Load)
        Me.InitializeComponent()
    End Sub

    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Me.methodLoad()
    End Sub

    Private Sub TongSoNguoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objDiemDanhHangNgay
        obj.ChonBang = 80
        obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "-" + Me.dtpNgay.Value.Month.ToString() + "-" + Me.dtpNgay.Value.Day.ToString()
        Me.b = New clsBDiemDanhHangNgay

        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/TongSoNguoi.xml"), typeControl.Grid, "coldgrchucvu")
    End Sub
    Friend WithEvents b As clsBDiemDanhHangNgay

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class