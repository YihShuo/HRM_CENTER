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
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO
Imports System.Windows.Forms.Application
Public Class frmThongKeTroCapHDLD
    Inherits Form
    Private Sub frmThongKeTroCapHDLD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCombo()
    End Sub
    Private Sub LoadCombo()
        Me.cboLoaiBaocao.Items.Add("TKTR", "Thống kê thợ rập, mức tay nghề") ''=== số 5
        Me.cboLoaiBaocao.Items.Add("TKUDM", "Thống kê công nhân may, mức tay nghề") ''=== số 6
        Me.cboLoaiBaocao.Items.Add("TKLOAIHD", "Thống kê HĐLĐ: số lượng, loại HĐLĐ, thời hạn HĐLĐ,Tham gia BH, CV NNĐH") ''=== số 7,8,11
        Me.cboLoaiBaocao.Items.Add("TKLDNCN", "Thống kê lao động đang nuôn con nhỏ") ''=== số 9
        Me.cboLoaiBaocao.Items.Add("TKSLCVU", "Thống kê cán bộ: số lượng, chức vụ") ''=== số 10
        Me.cboLoaiBaocao.Items.Add("TKNN", "Thống kê phiên dịch: số lượng, trình độ ngoại ngữ thông qua mức phụ cấp") ''=== số 12

    End Sub

    Private Sub btnBaocao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaocao.Activate
           Select cboLoaiBaocao.Value
            Case "TKTR"
                ''======== Thống kê thợ rập, mức tay nghề =============
                Dim frm As New frmThongKeTroCapThoRap
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmThongKeTroCapThoRap.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()
            Case "TKUDM"
                ''======== Thống kê công nhân may, mức tay nghề =============
                Dim frm As New frmThongKeTroCapUDMay
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmThongKeTroCapUDMay.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()
            Case "TKLOAIHD"
                ''======== Thống kê số lượng, loại HĐLĐ =============
                Dim frm As New frmTKSOLUONGKYHDLD
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmTKSOLUONGKYHDLD.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()


            Case "TKLDNCN"
                ''======== Thống kê lao động đang nuôn con nhỏ=============
                Dim frm As New frmThongKeSoLaoDongDangNCNho
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmThongKeSoLaoDongDangNCNho.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()
            Case "TKSLCVU"
                ''======== Thống kê cán bộ: số lượng, chức vụ =============
                Dim frm As New frmThongKeDanhSachCanBoThang
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmThongKeTroCapNgoaiNgu.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()
                'Case "TKCVNNDH"
                ''======== Thống kê số lượng, công việc NNĐH =============

            Case "TKNN"
                ''======== Thống kê số lượng, trợ cấp ngoại ngữ =============
                Dim frm As New frmThongKeTroCapNgoaiNgu
                Dim frmCollection = System.Windows.Forms.Application.OpenForms
                For i As Int16 = 0I To frmCollection.Count - 1I
                    If frmCollection.Item(i).Name = frm.Name Then
                        frmThongKeTroCapNgoaiNgu.StartPosition = FormStartPosition.WindowsDefaultLocation
                        frm.Select()
                        Exit Sub
                    End If
                Next i
                frm.Show()
        End Select

    End Sub
End Class