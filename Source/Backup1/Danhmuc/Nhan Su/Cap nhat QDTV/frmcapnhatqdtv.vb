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

Public Class frmcapnhatqdtv
    Dim obj As New objcapnhatqdtv
    Dim flag As Boolean
    Public i As Integer
    Private Sub txtMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.ValueChanged
        If Me.txtMa.TextLength = 6 Then
            Dim Temp As New DataTable
            Me.b = New clsBcapnhatqdtv
            Temp = Nothing
            obj.setnull()
            obj.ChonBang = 1
            obj.MANV = Me.txtMa.Text
            Temp = Me.b.LoadDS(obj)
            If Temp.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
            If flag = True Then
                Me.txtMa.Text = Temp.Rows(0).Item("NV_MA").ToString
                Me.txtsoqd.Text = Temp.Rows(0).Item("SOQD").ToString

                Me.dtpNgay.Value = Temp.Rows(0).Item("TV_NGAYQD").ToString
                Me.btnLuu.Enabled = True
            Else
                MessageBox.Show("Nhân viên này không nằm trong danh sách thôi việc!", "Thông Báo")
                Me.txtMa.Focus()
                Me.btnLuu.Enabled = False
                Exit Sub
            End If
        ElseIf Me.txtMa.Text = "" Then

        End If
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate

        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        Dim obj As New objcapnhatqdtv
        Dim NGAY As Date
        Dim SOQD As String
        NGAY = Me.dtpNgay.Value
        SOQD = Me.txtsoqd.Text
        Dim dt As DateTime
        dt = DateTime.Parse(Me.dtpNgay.Value.Year.ToString + "-" + Me.dtpNgay.Value.month.ToString + "-" + Me.dtpNgay.Value.day.ToString)

        If Me.txtMa.Text.Trim() = "" Then
            MessageBox.Show("Chưa nhập số thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMa.Focus()
            Exit Sub
        End If
        obj.NGAY = NGAY
        obj.setvalue(Me.txtMa.Text, NGAY, SOQD)
        Try
            obj.setnull()
            obj.MANV = Me.txtMa.Text
            obj.SOQD = Me.txtsoqd.Text
            obj.NGAY = Me.dtpNgay.Value.Year.ToString + "-" + Me.dtpNgay.Value.month.ToString + "-" + Me.dtpNgay.Value.day.ToString
            obj.ChonBang = 2

            If Me.b.UpdateInfo(obj) Then
                MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không lưu được dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.methodLoad()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongbaoLoi(exception.Message)
            ProjectData.ClearProjectError()
        End Try

    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBcapnhatqdtv
        obj.MANV = Me.txtMa.Text
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        LoadGridView()
    End Sub

    Private Sub LoadGridView()
        DinhDangChung(2)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("NV_MA").Header.Caption = "Số thẻ" & Chr(10) & "工號"
            .Columns("SOQD").Header.Caption = "Số QĐ" & Chr(10) & " "
            .Columns("TV_NGAYTHOIVIEC").Header.Caption = "Ngày thôi việc" & Chr(10) & "離職日"
            .Columns("TV_NGAYQD").Header.Caption = "Ngày ra QĐ" & Chr(10) & " "
        End With
    End Sub
    Private Sub DinhDangChung(ByVal iCot As Integer)
        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
        End With

        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band.Layout.Override.FilterUIType = FilterUIType.FilterRow
        band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        band.Layout.Override.RowSizing = RowSizing.AutoFree
        band.Layout.Override.CellMultiLine = DefaultableBoolean.True
        band.ColHeaderLines = iCot

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
    End Sub

    Private Sub btnxem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxem.Activate
        Me.methodLoad()
    End Sub

    Private Sub btnex_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnex.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class