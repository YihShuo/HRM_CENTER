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

Public Class frmSoNguoiTrongCongTy

    Private Sub frmSoNguoiTrongCongTy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.methodLoad()
    End Sub

    Public Sub methodLoad()
        clsTools.GridTheme1(Me.dgrBC)
        Dim grid As New clsTformatGrid
        Dim obj As New objSoNguoiTrongCongTy
        Dim Table As DataTable
        Me.b = New clsBSoNguoiTrongCongTy
        obj.Setnull()

        obj.ChonBang = 1
        Table = Me.b.LoadDS(obj)
        Me.txtTong.Text = Table.Rows.Count.ToString()
        If Me.rdTongNV.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 2
        Table = Me.b.LoadDS(obj)
        Me.txtTongNV.Text = Table.Rows.Count.ToString()
        If Me.rdTongDVNV.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 3
        Table = Me.b.LoadDS(obj)
        Me.txtTongCG.Text = Table.Rows.Count.ToString()
        If Me.rdTongCG.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 4
        Table = Me.b.LoadDS(obj)
        Me.txtTongBGD.Text = Table.Rows.Count.ToString()
        If Me.rdTongBGD.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 5
        Table = Me.b.LoadDS(obj)
        Me.txtTongDT.Text = Table.Rows.Count.ToString()
        If Me.rdTongDT.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 6
        Table = Me.b.LoadDS(obj)
        Me.txtTongKB.Text = Table.Rows.Count.ToString()
        If Me.rdTongKB.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        obj.ChonBang = 7
        Table = Me.b.LoadDS(obj)
        Me.txtTongCNM.Text = Table.Rows.Count.ToString()
        If Me.rdTongCNM.Checked = True Then
            Me.dgrBC.DataSource = Table
        End If

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlNoXML((dgrBC))
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)

        Dim Tong, TongTru, TongCL As Integer
        Tong = Val(Me.txtTong.Text.ToString)
        TongTru = Val(Me.txtTongNV.Text.ToString()) + Val(Me.txtTongCG.Text.ToString()) + Val(Me.txtTongBGD.Text.ToString()) + Val(Me.txtTongDT.Text.ToString()) + Val(Me.txtTongKB.Text.ToString()) + Val(Me.txtTongCNM.Text.ToString())
        TongCL = Tong - TongTru
        Me.txtTongNVConLai.Text = TongCL.ToString()

    End Sub
    Friend WithEvents b As clsBSoNguoiTrongCongTy

    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        Me.methodLoad()
    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub rdTongNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongNV.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongDVNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongDVNV.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongCG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongCG.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongBGD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongBGD.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongDT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongDT.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongKB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongKB.CheckedChanged
        Me.methodLoad()
    End Sub

    Private Sub rdTongCNM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTongCNM.CheckedChanged
        Me.methodLoad()
    End Sub
End Class