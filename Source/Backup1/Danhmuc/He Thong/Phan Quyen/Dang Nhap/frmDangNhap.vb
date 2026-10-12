Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup

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
Imports TongHop.frmMainMain
Imports TongHop.MAIN

Public Class frmDangNhap
    Public tennguoidung As String
    Private Sub btDangnhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDangnhap.Click

        If Not loadServerCurr() Then
            Dim tdb As New FrmConnectDB
            tdb.ShowDialog()
            tdb = Nothing
            Interaction.MsgBox("Vui lòng khởi động lại chương trình", MsgBoxStyle.Information, "Thông báo")
            Application.Exit()
        Else
            Dim obj As New objDangNhap
            obj.ChonBang = 1
            Dim table As DataTable
            obj.setvalue(Me.txtTendangnhap.Text, clsTools.Encrypt1(Me.txtMatkhau.Text))
            MAIN.userclient = Me.txtTendangnhap.Text
            MAIN.PassLogin = clsTools.Encrypt1(Me.txtMatkhau.Text)
            Me.b = New clsBDangNhap
            table = Me.b.LoadDS(obj)
            If table.Rows.Count > 0 Then
                MAIN.USER_KT = False 'table.Rows(0).Item("USER_KT").ToString
                'MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMain
                '    'Me.SetTrangThaiMo(frm)
                '    'frm.stbUser.Text = "Người dùng: " & Me.txtTendangnhap.Text
                '    'Me.tennguoidung = frm.stbUser.Text
                '    frm.Show()
                '    Me.Hide()
                'Else
                '    Dim frm As New frmMain
                '    'Me.SetTrangThaiKhoa(frm)
                '    'Me.SetTrangThaiMoTheoQuyen(frm)
                '    'frm.stbUser.Text = "Người dùng: " & Me.txtTendangnhap.Text
                '    'Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                Me.Hide()
                ''  End If
            Else
                MessageBox.Show("Thông tin đăng nhập không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtMatkhau.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'Private Sub SetTrangThaiMo(ByRef frm As frmMainMain)
    '    Dim obj As New objDangNhap
    '    obj.ChonBang = 2
    '    Dim table As DataTable
    '    Me.b = New clsBDangNhap
    '    table = Me.b.LoadDS(obj)
    '    'Hien thi toolbar=======================
    '    Dim i As Integer = 0
    '    While i < table.Rows.Count
    '        On Error Resume Next
    '        frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Enabled = True
    '        i = i + 1
    '    End While
    '    'Hien thi Explorebar====================
    '    Dim j As Integer = 0
    '    While j < frm.UltraExplorerBar1.Groups.Count
    '        Dim k As Integer = 0
    '        While k < frm.UltraExplorerBar1.Groups(j).Items.Count
    '            frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = True
    '            k = k + 1
    '        End While
    '        j = j + 1
    '    End While

    'End Sub

    'Private Sub SetTrangThaiKhoa(ByRef frm As frmMainMain)
    '    Dim obj As New objDangNhap
    '    obj.ChonBang = 2
    '    Dim table As DataTable
    '    Me.b = New clsBDangNhap
    '    table = Me.b.LoadDS(obj)
    '    'Hien thi toolbar=======================
    '    Dim i As Integer = 0
    '    While i < table.Rows.Count
    '        On Error Resume Next
    '        frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Enabled = False
    '        i = i + 1
    '    End While
    '    'Hien thi Explorebar====================
    '    Dim j As Integer = 0
    '    While j < frm.UltraExplorerBar1.Groups.Count
    '        Dim k As Integer = 0
    '        While k < frm.UltraExplorerBar1.Groups(j).Items.Count
    '            frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = False
    '            k = k + 1
    '        End While
    '        j = j + 1
    '    End While
    '    frm.UltraExplorerBar1.Groups.Item("mnHethong").Items("1mnThoat").Visible = True
    'End Sub

    'Private Sub SetTrangThaiMoTheoQuyen(ByRef frm As frmMainMain)
    '    Dim obj As New objDangNhap
    '    obj.ChonBang = 3
    '    obj.TenDangNhap = Me.txtTendangnhap.Text
    '    Dim table As DataTable
    '    Me.b = New clsBDangNhap
    '    table = Me.b.LoadDS(obj)
    '    Dim i As Integer = 0
    '    On Error Resume Next

    '    While i < table.Rows.Count
    '        'Hien thi toolbar=======================
    '        frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Enabled = True
    '        'Hien thi Explorebar====================
    '        Dim j As Integer = 0
    '        While j < frm.UltraExplorerBar1.Groups.Count
    '            Dim k As Integer = 0
    '            While k < frm.UltraExplorerBar1.Groups(j).Items.Count
    '                If (StringType.StrCmp(frm.UltraExplorerBar1.Groups.Item(j).Items(k).Key.ToString(), table.Rows(i).Item(0).ToString(), False) = 0) Then
    '                    frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = True
    '                End If
    '                k = k + 1
    '            End While
    '            j = j + 1
    '        End While
    '        i = i + 1
    '    End While
    'End Sub

    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub

    Friend WithEvents b As clsBDangNhap


    Private Sub frmDangNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cbChinhanh.Text = "Tỷ Thạc"
        If Not loadServerCurr() Then
            Dim tdb As New FrmConnectDB
            tdb.ShowDialog()
            tdb = Nothing
            Interaction.MsgBox("Vui lòng khởi động lại chương trình", MsgBoxStyle.Information, "Thông báo")
            Application.Exit()
        Else
            Application.DoEvents()
            'Application.Run(New frmMainMain)
            Me.cbChinhanh.Text = "Tỷ Thạc"
            Me.cbChinhanh.Enabled = False
        End If
    End Sub

    Public AppExit As Boolean = False

    Private Sub cbChinhanh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChinhanh.SelectedIndexChanged
        'MAIN.DATABASE = Me.cbChinhanh.ValueMember.ToString
        'If Me.cbChinhanh.Text = "Tỷ Xuân" Then
        '    MAIN.DATABASE = "P0104-TYXUAN"
        '    'MAIN.DATABASE = "P0104-TYXUAN20102011"
        'End If
        'If Me.cbChinhanh.Text = "Đồng Tháp" Then
        '    MAIN.DATABASE = "P0104-DONGTHAP"
        'End If
    End Sub
End Class