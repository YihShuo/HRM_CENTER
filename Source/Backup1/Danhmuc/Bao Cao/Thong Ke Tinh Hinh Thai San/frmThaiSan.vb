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
Public Class frmThaiSan

    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmThaiSan_Load)
        Me.InitializeComponent()
    End Sub
    Private Sub frmThaiSan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        obj.ChonBang = 2
        'Load Don Vi
        Me.b = New clsBThaiSan
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.Enabled = False
        'Chon Don Vi dau tien trong combo
        Me.cbDonvi.Text = Me.cbDonvi.Items(0).ToString()
        clsTools.GridTheme1(Me.dgrBC)

    End Sub

    Private Sub btXemBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Click
        ' Xem bao cao tung don vi
        Dim report As New FrmReport
        Me.ReportID = "556"
        report.reportID = Me.ReportID
        Dim strArray As String() = New String() {Me.chkDonVi.Checked, Me.cbDonvi.Text}
        report.para = strArray
        report.issysReport = True
        report.Show()

    End Sub

    Private Sub chkDonVi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonVi.CheckedChanged
        If Me.chkDonVi.Checked = True Then
            Me.cbDonvi.Enabled = True
        Else
            Me.cbDonvi.Enabled = False
        End If

    End Sub

    Private Sub btBCToanCongTy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBCToanCongTy.Click
        'Xem bao cao toan cong ty
        Dim report As New FrmReport
        Me.ReportID = "559"
        report.reportID = Me.ReportID
        Dim strArray As String() = New String() {}
        report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    'Khai bao bien toan cuc
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Dim obj As New objThaiSan
End Class