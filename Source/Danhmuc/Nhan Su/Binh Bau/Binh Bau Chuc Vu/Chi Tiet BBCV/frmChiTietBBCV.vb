
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinEditors
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports Infragistics
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinListView.UltraListViewItem
Imports Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn
Imports Infragistics.Win.AutoCompleteMode
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient.SqlParameter
Public Class frmChiTietBBCV
    Public FLAG As Integer

    Private Sub btDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Click
        Me.Close()
        Me.FLAG = 1
    End Sub
    Public mabb As String
    Public cvu As String
    Public tien As Double

    Private Sub btChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btChon.Click

        If Me.cbBinhBau.Text = "" Then
            mabb = ""
        Else
            mabb = Me.cbBinhBau.Value
        End If
        If Me.cbChucVu.Text = "" Then
            cvu = ""
        Else
            cvu = Me.cbChucVu.Value
        End If
        If Me.txtSoTien.Text = "" Then
            tien = ""
        Else
            tien = Me.txtSoTien.Text
        End If

        TongHop.frmBinhBauChucVu.obj.setvalue(mabb, cvu, tien, 0)
        Me.Close()
        Me.FLAG = 0
    End Sub
    Dim Tabletemp As DataTable
    Friend WithEvents b As clsBChiTietBBCV
    Public obj As New objChiTietBBCV
    Public frm As New frmBinhBauChucVu

    Private Sub frmChiTietBBCV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If frm.flagD = 0 Then
            'Me.cbBinhBau.Enabled = False
            Dim obj As New objChiTietBBCV
            obj.ChonBang = 4
            Me.b = New clsBChiTietBBCV
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.cbBinhBau.DataSource = Me.Tabletemp
            Me.cbBinhBau.ValueMember = "BB_MA"




            obj.ChonBang = 5
            Me.b = New clsBChiTietBBCV
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.cbChucVu.DataSource = Me.Tabletemp
            Me.cbChucVu.ValueMember = "CVU_MA"
        End If
    End Sub

    Private Sub cbBinhBau_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbBinhBau.BeforeDropDown
        If frm.flagD = 1 Then
            Me.cbBinhBau.Enabled = False
            Dim obj As New objChiTietBBCV
            obj.ChonBang = 4
            Me.b = New clsBChiTietBBCV
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.cbBinhBau.DataSource = Me.Tabletemp
            Me.cbBinhBau.ValueMember = "BB_MA"
        End If
    End Sub

    Private Sub cbChucVu_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbChucVu.BeforeDropDown
        If frm.flagD = 0 Then
            Dim obj As New objChiTietBBCV
            obj.ChonBang = 5
            Me.b = New clsBChiTietBBCV
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.cbChucVu.DataSource = Me.Tabletemp
            Me.cbChucVu.ValueMember = "CVU_MA"
        End If
    End Sub
End Class