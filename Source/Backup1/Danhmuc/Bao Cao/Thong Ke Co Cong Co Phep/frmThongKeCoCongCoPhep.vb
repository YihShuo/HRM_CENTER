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

Imports Microsoft.Win32
Imports System.IO
Imports Infragistics.Excel
Imports Infragistics
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient


Public Class frmThongKeCoCongCoPhep
    Dim myWorkbook As New Infragistics.Excel.Workbook
    Dim myWorksheet As Infragistics.Excel.Worksheet
    Dim b As clsBThongKeCoCongCoPhep
    Public sTuNgay, sDenNgay As String
    Private Sub frmThongKeCoCongCoPhep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblXuong As DataTable
        Dim obj As New objThongKeCoCongCoPhep
        Me.b = New clsBThongKeCoCongCoPhep

        Me.radTuNgay.Checked = True
        Dim ngaytam() As Date = D_C_Tuan(Me.dtpTuNgay.Value, 0) ''khong tinh chu nhat
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpTuNgay.Value)


        tblXuong = Me.b.ThongKe("SP_DANHMUCXUONG_S")

        'tblXuong.Rows.Add("KHUA")
        'tblXuong.Rows.Add("KHUB")
        'tblXuong.Rows.Add("TCT")
        Me.cbXuong.DataSource = tblXuong
        Me.cbXuong.DisplayMember() = "X_MA_"
        Me.cbXuong.ValueMember() = "X_MA_"
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        If tblXuong.Rows.Count > 0 Then
            Me.cbXuong.SelectedIndex = 0
        Else
            Me.cbXuong.Enabled = False
            Exit Sub
        End If
        Me.btnExcel.Enabled = False
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next
                ''=============

                .Columns("NV_MA").Header.Caption = "SỐ THẺ"
                .Columns("NV_Ten").Header.Caption = "HỌ TÊN"
                .Columns("DVTL").Header.Caption = "ĐƠN VỊ TL"
                .Columns("DVDD").Header.Caption = "ĐƠN VỊ ĐĐ"
                .Columns("GIOITINH").Header.Caption = "GIỚI TÍNH"
                .Columns("QT_NGAY").Header.Caption = "NGÀY"
                .Columns("QT_GIOVAOTAY").Header.Caption = "VÀO TAY"
                .Columns("QT_GIORATAY").Header.Caption = "RA TAY"
                .Columns("CA_MA").Header.Caption = "CA MÃ"
                .Columns("CC_GIOBINHTHUONG").Header.Caption = "GIÒ BÌNH THƯỜNG"
                .Columns("CC_GIOTANGCA").Header.Caption = "GIỜ TĂNG CA"
                .Columns("CC_HESONGAYCONG").Header.Caption = "HỆ SỐ NGÀY CÔNG"
                .Columns("NP_MA").Header.Caption = "NGHỈ PHÉP"
                .Columns("QT_NGAY").Format = "dd/MM/yyyy"
                '.Columns("QT_GIOVAOTAY").Format = "HH:mm:ss"
                '.Columns("QT_GIORATAY").Format = "HH:mm:ss"

                If Me.radDonviDD.Checked Then
                    .Columns("DVDD").Hidden = False
                    .Columns("DVTL").Hidden = True
                Else
                    .Columns("DVDD").Hidden = True
                    .Columns("DVTL").Hidden = False

                End If
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
                band.ColHeaderLines = 2
                'Column Chooser

                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(5)
                band.Layout.Bands(0).Summaries.Clear()
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số: "
                band = Nothing

            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Function ThongKeCoCongCoPhep_Tuan(ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal iTCT As Integer, ByVal iKhu As Integer, ByVal iXuong As Integer, ByVal sKhu As String, ByVal sXuong As String) As DataTable
        Dim tbltam As DataTable
        Dim i As Integer = 0
        Dim listpar As New ArrayList(2)
        Me.b = New clsBThongKeCoCongCoPhep


        Dim SqlParamTrNgoaiXuong As SqlParameter() = {New SqlParameter("@tungay", Data.SqlDbType.DateTime), _
                                                      New SqlParameter("@denngay", Data.SqlDbType.DateTime), _
                                                      New SqlParameter("@bTCT", Data.SqlDbType.Int), _
                                                      New SqlParameter("@bKhu", Data.SqlDbType.Int), _
                                                      New SqlParameter("@bXuong", Data.SqlDbType.Int), _
                                                      New SqlParameter("@KHU", Data.SqlDbType.NVarChar, 50), _
                                                      New SqlParameter("@X_MA_", Data.SqlDbType.NVarChar, 50)}
        SqlParamTrNgoaiXuong(0).Value = CDate(sTuNgay)
        SqlParamTrNgoaiXuong(1).Value = CDate(sDenNgay)
        SqlParamTrNgoaiXuong(2).Value = iTCT
        SqlParamTrNgoaiXuong(3).Value = iKhu
        SqlParamTrNgoaiXuong(4).Value = iXuong
        SqlParamTrNgoaiXuong(5).Value = sKhu
        SqlParamTrNgoaiXuong(6).Value = sXuong


        If Me.radDVTL.Checked Then
            If Me.chkKhongTinhLeCN.Checked Then
                tbltam = Me.b.ThongKe("SP_DSCOCONGCOPHEP_DVTL_KTINHCN_S", SqlParamTrNgoaiXuong)
            Else
                tbltam = Me.b.ThongKe("SP_DSCOCONGCOPHEP_DVTL_TINHCN_S", SqlParamTrNgoaiXuong)
            End If

        End If

        If Me.radDonviDD.Checked Then
            If Me.chkKhongTinhLeCN.Checked Then
                tbltam = Me.b.ThongKe("SP_DSCOCONGCOPHEP_DVDD_KTINHCN_S", SqlParamTrNgoaiXuong)
            Else
                tbltam = Me.b.ThongKe("SP_DSCOCONGCOPHEP_DVDD_TINHCN_S", SqlParamTrNgoaiXuong)
            End If
        End If


        Return tbltam

    End Function
    Private Function D_C_Tuan(ByVal NgayHT As Date, ByVal bTinhCN As Boolean) As Date()
        Dim ngay(1) As Date '0: Ngày đầu tuần; Ngày cuối tuần
        Select Case Weekday(NgayHT)
            Case 1 'Chủ nhật
                ngay(0) = NgayHT
                ngay(1) = DateAdd(DateInterval.Day, 6, NgayHT)
            Case 2
                ngay(0) = DateAdd(DateInterval.Day, -1, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 5, NgayHT)
            Case 3
                ngay(0) = DateAdd(DateInterval.Day, -2, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 4, NgayHT)
            Case 4
                ngay(0) = DateAdd(DateInterval.Day, -3, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 3, NgayHT)
            Case 5
                ngay(0) = DateAdd(DateInterval.Day, -4, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 2, NgayHT)
            Case 6
                ngay(0) = DateAdd(DateInterval.Day, -5, NgayHT)
                ngay(1) = DateAdd(DateInterval.Day, 1, NgayHT)
            Case 7 'Thứ bảy
                ngay(0) = DateAdd(DateInterval.Day, -6, NgayHT)
                ngay(1) = NgayHT
        End Select
        If bTinhCN = False Then
            ngay(0) = DateAdd(DateInterval.Day, 1, ngay(0))
        End If
        Return ngay
    End Function
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        Me.ProgressBar.Style = ProgressBarStyle.Marquee
        Me.TopMost = True
        Dim dNgaycuoithang As Date
        Dim sKhu, sXuong As String
        Dim obj As New objThongKeCoCongCoPhep
        Dim iTinhTCT, iTinhKhu, iTinhXuong As Integer
        If Me.cbXuong.Value Is Nothing Then
            sXuong = ""
        Else
            sXuong = Me.cbXuong.Value
        End If

        obj.setvalueChonThamSo(Me.radTCT.Checked, Me.radKhuA.Checked, Me.radKhuB.Checked, Me.radKhuDVC.Checked, Me.radXuong.Checked, sXuong)

        If Me.radTuNgay.Checked Then
            sTuNgay = CDate(Me.dtpTuNgay.Value).Year.ToString() + "/" + CDate(Me.dtpTuNgay.Value).Month.ToString() + "/" + CDate(Me.dtpTuNgay.Value).Day.ToString()
            sDenNgay = sTuNgay
            Me.XpCaption2.Text = "Danh sách có công có phép ngày " & Me.dtpTuNgay.Text
        End If
        If Me.radTuan.Checked Then
            sTuNgay = CDate(Me.txtNgaybd.Value).Year.ToString() + "/" + CDate(Me.txtNgaybd.Value).Month.ToString() + "/" + CDate(Me.txtNgaybd.Value).Day.ToString()
            sDenNgay = CDate(Me.txtNgaykt.Value).Year.ToString() + "/" + CDate(Me.txtNgaykt.Value).Month.ToString() + "/" + CDate(Me.txtNgaykt.Value).Day.ToString()
            Me.XpCaption2.Text = "Danh sách có công có phép tuần (" & Me.txtNgaybd.Text & "-" & Me.txtNgaykt.Text & ")"
        End If

        If Me.radThang.Checked Then
            sTuNgay = CDate(Me.dtpThang.Value).Year.ToString() + "/" + CDate(Me.dtpThang.Value).Month.ToString() + "/01"
            dNgaycuoithang = CDate(sTuNgay).AddMonths(1).AddDays(-1)
            sDenNgay = dNgaycuoithang.Year.ToString() + "/" + dNgaycuoithang.Month.ToString() + "/" + dNgaycuoithang.Day.ToString()
            Me.XpCaption2.Text = "Danh sách có công có phép tháng (01/" & CDate(Me.dtpThang.Value).Month.ToString() & "/" & CDate(Me.dtpThang.Value).Year.ToString() & "-" & dNgaycuoithang.Day.ToString() & "/" & CDate(Me.dtpThang.Value).Month.ToString() & "/" & CDate(Me.dtpThang.Value).Year.ToString() & ")"

        End If
        Me.dgrBC.DataSource = ThongKeCoCongCoPhep_Tuan(sTuNgay, sDenNgay, obj.ChonTCT, obj.ChonKhu, obj.ChonXuong, obj.KHU, obj.XUONG)

        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        LoadGridView()
        Me.btnExcel.Enabled = Me.dgrBC.Rows.Count > 0

    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Try
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ngaytam() As Date
        If Me.chkKhongTinhLeCN.Checked Then
            ngaytam = D_C_Tuan(Me.dtpTuNgay.Value, 0) ''khong tinh chu nhat
        Else
            ngaytam = D_C_Tuan(Me.dtpTuNgay.Value, 1) ''khong tinh chu nhat
        End If
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpTuNgay.Value)
    End Sub

    Private Sub chkKhongTinhLeCN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ngaytam() As Date
        If Me.chkKhongTinhLeCN.Checked Then
            ngaytam = D_C_Tuan(Me.dtpTuNgay.Value, 0) ''khong tinh chu nhat
        Else
            ngaytam = D_C_Tuan(Me.dtpTuNgay.Value, 1) ''khong tinh chu nhat
        End If
        Me.txtNgaybd.Text = ngaytam(0).ToShortDateString
        Me.txtNgaykt.Text = ngaytam(1).ToShortDateString
        Me.txtTuan.Text = DatePart(DateInterval.WeekOfYear, dtpTuNgay.Value)
    End Sub
 
End Class