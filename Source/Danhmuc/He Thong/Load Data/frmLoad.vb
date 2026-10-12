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
Imports System.Data.SqlClient

Public Class frmLoad

    Private Sub frmLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoad.Click
        Dim ngay As Date
        ngay = Me.dtpNgayLoad.Value
        Dim NamThangNgay As String = ngay.Year().ToString() + "/" + ngay.Month().ToString() + "/" + ngay.Day().ToString()

        Dim frm As New frmWaiting
        frm.Bang = 3
        frm.ID_NamThangNgay = NamThangNgay
        frm.ShowDialog()

    End Sub

    Private Sub lBangluong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lBangluong.Click
        
    End Sub

    Private Sub btTaidulieuthang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTaidulieuthang.Click
        Dim ngay As Date
        ngay = Me.dtpNgayLoad.Value

        Dim songaytrongthang As Integer = Me.SoNgay(ngay.Month, ngay.Year)
        Dim i As Integer = 1
        While i <= songaytrongthang
            Dim NamThangNgay As String = ngay.Year().ToString() + "/" + ngay.Month().ToString() + "/" + i.ToString()
            If NamThangNgay <= Now Then
                Dim frm As New frmWaiting
                frm.Bang = 3
                frm.ID_NamThangNgay = NamThangNgay
                frm.ShowDialog()
            End If
            i = i + 1
        End While
    End Sub

    Function SoNgay(ByVal Thang As Integer, ByVal Nam As Integer) As Integer
        Dim songay_cuathang As Integer = 0

        Select Case Thang
            Case 1, 3, 5, 7, 8, 10, 12
                songay_cuathang = 31
            Case 4, 6, 9, 11
                songay_cuathang = 30
            Case 2
                If (Nam Mod 4) = 0 Then
                    songay_cuathang = 29
                Else
                    songay_cuathang = 28
                End If
        End Select

        Return songay_cuathang
    End Function
End Class