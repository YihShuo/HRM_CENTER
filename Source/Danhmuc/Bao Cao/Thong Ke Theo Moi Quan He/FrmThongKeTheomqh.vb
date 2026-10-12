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

Public Class FrmThongKeTheomqh
    Inherits Form
    Dim obj As New ObjThongKeTheomqh
    Dim Tabletemp As DataTable
    Dim PATH As String = ""
    Friend WithEvents b As ClsBThongKeTheomqh

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub

    Private Sub dgrBC_mqh_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC_mqh.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub

    Private Sub FrmThongKeTheomqh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tolTip.SetToolTip(Me.cbMqh, "Click vào đây để chọn mối quan hệ ")
        obj.Setnull()
        clsTools.GridTheme1(Me.dgrBC_mqh)
        Me.b = New ClsBThongKeTheomqh
        obj.ChonBang = 1
        Tabletemp = Me.b.LoadDS(obj)
        Me.cbMqh.DataSource = Tabletemp
        Me.cbMqh.DisplayMember() = "MA_QH"
        Me.cbMqh.ValueMember() = "MA_QH"
        Me.cbMqh.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsBThongKeTheomqh
        obj.Setnull()
        clsTools.GridTheme1(Me.dgrBC_mqh)
        obj.ChonBang = 2
        obj.MQH = Me.cbMqh.Text
        Me.dgrBC_mqh.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC_mqh
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/Thongke/ThongKeTheoQuanHe/ThongKeTheoQuanHe.xml"), typeControl.Grid, "colthongketheomqh")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC_mqh, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnLocDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocDs.Click
        Me.methodLoad()
    End Sub
End Class