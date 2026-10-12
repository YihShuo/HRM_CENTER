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
Imports TongHop.frmBinhBauThang
Public Class frm_LoaiBB
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBLoaiBB
    Private Sub btChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btChon.Click
        TongHop.frmBinhBauThang.objBB.FlagTinhBinhBau = True
        If Me.cbLoaiBB.Text = "" Then
            TongHop.frmBinhBauThang.objBB.Binhbau = "NULL"
        Else
            TongHop.frmBinhBauThang.objBB.Binhbau = Me.cbLoaiBB.Text
        End If
        Me.Close()
    End Sub

    Private Sub btDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Click
        TongHop.frmBinhBauThang.objBB.FlagTinhBinhBau = False
        Me.Close()
    End Sub
    'Dim obj As objLoaiBB
    Private Sub frm_LoaiBB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objLoaiBB
        obj.ChonBang = 1
        Me.b = New clsBLoaiBB
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cbLoaiBB.DataSource = Me.Tabletemp
        Me.cbLoaiBB.ValueMember = "BB_MA"
    End Sub
End Class