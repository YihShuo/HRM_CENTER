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
Imports TongHop.frmChamcongMain

Public Class frmVaora

    Private Sub frmVaora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Cama tu bang st_gioquetthe
        If TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca HC" Then
            Me.rdCaHC.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca01" Then
            Me.rdCa0.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca02" Then
            Me.rdCa02.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca03" Then
            Me.rdCa03.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 1" Then
            Me.rdCa1.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 2" Then
            Me.rdCa2.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 3" Then
            Me.rdCa3.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 4" Then
            Me.rdCa4.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 5" Then
            Me.rdCa5.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 6" Then
            Me.rdCa6.Checked = True
        ElseIf TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 7" Then
            Me.rdCa7.Checked = True
        Else
            Me.rdCaHC.Checked = True
        End If
    End Sub

    Private Sub btDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Click
        TongHop.frmChamcongMain.objChamCong.FlagChamCong = False
        Me.Close()
    End Sub

    Private Sub btChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btChon.Click
        If Me.txtGioratay.Text = "" And Me.txtGiovaotay.Text = "" And (Me.chkDiTre.Checked = True Or Me.chkSaiQD.Checked = True) Then
            MessageBox.Show("Bạn chưa nhập giờ vào giờ ra")
            Exit Sub
        End If

        TongHop.frmChamcongMain.objChamCong.FlagChamVaoRa = True
        'Set CA_Ma
        If Me.rdCaHC.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca HC"
        End If
        If Me.rdCa0.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca01"
        End If

        If Me.rdCa02.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca02"
        End If

        If Me.rdCa03.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca03"
        End If

        If Me.rdCa1.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 1"
        End If
        If Me.rdCa2.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 2"
        End If
        If Me.rdCa3.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 3"
        End If
        If Me.rdCa4.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 4"
        End If
        If Me.rdCa5.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 5"
        End If
        If Me.rdCa6.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 6"
        End If
        If Me.rdCa7.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.CA_Ma = "Ca 7"
        End If
        If Me.chkDiTre.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.DITRE = 1
        Else
            TongHop.frmChamcongMain.objChamCong.DITRE = 0
        End If

        If Me.chkSaiQD.Checked = True Then
            TongHop.frmChamcongMain.objChamCong.SAIQD = 1
        Else
            TongHop.frmChamcongMain.objChamCong.SAIQD = 0
        End If
        'Set GioVaoTay va GioRaTay
        'MessageBox.Show(TongHop.frmChamcongMain.objChamCong.NgayChamCong.ToString)
        If Me.txtGiovaotay.Text = "" Then
            TongHop.frmChamcongMain.objChamCong.GioVaoTay = "NULL"
        Else
            TongHop.frmChamcongMain.objChamCong.GioVaoTay = "'" + Me.txtGiovaotay.Text + "'"
        End If

        If Me.txtGioratay.Text = "" Then
            TongHop.frmChamcongMain.objChamCong.GioRaTay = "NULL"
        Else
            TongHop.frmChamcongMain.objChamCong.GioRaTay = "'" + Me.txtGioratay.Text + "'"
        End If

        Me.Close()
    End Sub

    Private Sub chkSaiQD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSaiQD.CheckedChanged
        If Me.chkSaiQD.Checked = True Then
            Me.chkDiTre.Checked = False

        End If
    End Sub

    Private Sub chkDiTre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiTre.CheckedChanged
        If Me.chkDiTre.Checked = True Then
            Me.chkSaiQD.Checked = False
        End If
    End Sub
End Class