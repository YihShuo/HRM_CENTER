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
Imports System.Configuration
Public Class frmDanhSachCNNghiKPTheoNam
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDDanhSachCNNghiKPTheoNam
    Friend WithEvents b As clsBDanhSachCNNghiKPTheoNam
    Dim Tabletemp As DataTable
    Private Sub frmDanhSachCNNghiKPTheoNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblXuong As DataTable
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBDanhSachCNNghiKPTheoNam
        tblXuong = Me.b.ThongKe("SP_DANHMUCXUONG_S")

        tblXuong.Rows.Add("TAM")
        tblXuong.Rows.Add("KHUA")
        tblXuong.Rows.Add("KHUB")
        tblXuong.Rows.Add("KHUDVC")
        tblXuong.Rows.Add("TCT")

        Me.cbXuong.DataSource = tblXuong
        Me.cbXuong.DisplayMember() = "X_MA_"
        Me.cbXuong.ValueMember() = "X_MA_"
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.btExcel.Enabled = False
        Me.ProgressBar1.Style = ProgressBarStyle.Blocks
        Me.ProgressBar1.Value = 100
    End Sub
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    ''========== Bien dung chung de thong ke cho thanh tien trinh
    Public Tabletk As DataTable
    Public Delegate Sub _errorEventHandler(ByVal message As String)
    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
    
    
    Private Function ThongKeNghiKhongPhep_Khu(ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sKhu As String) As DataTable
        Dim tbltam As DataTable
        Dim listpar As New ArrayList(3)
        Me.b = New clsBDanhSachCNNghiKPTheoNam
        Select Case sKhu
            Case "TCT"

                Dim SqlParam As SqlParameter() = {New SqlParameter("@NGAYBD", Data.SqlDbType.DateTime), _
                     New SqlParameter("@NGAYKT", Data.SqlDbType.DateTime)}

                SqlParam(0).Value = CDate(sTuNgay)
                SqlParam(1).Value = CDate(sDenNgay)

                tbltam = Me.b.ThongKe("SP_THONGKENGHIKHONGPHEPNAM_TCT_S", SqlParam)

            Case "A", "B", "DVC"
                Dim SqlParam As SqlParameter() = {New SqlParameter("@NGAYBD", Data.SqlDbType.DateTime), _
                                              New SqlParameter("@NGAYKT", Data.SqlDbType.DateTime), _
                                              New SqlParameter("@KHU", Data.SqlDbType.NVarChar, 50)}
                SqlParam(0).Value = CDate(sTuNgay)
                SqlParam(1).Value = CDate(sDenNgay)
                SqlParam(2).Value = sKhu
                tbltam = Me.b.ThongKe("SP_THONGKENGHIKHONGPHEPNAM_KHU_S", SqlParam)
        End Select
        Return tbltam
    End Function
    Private Function ThongKeNghiKhongPhep_Xuong(ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sXuong As String) As DataTable
        Dim tbltam As DataTable
        Dim listpar As New ArrayList(3)
        Me.b = New clsBDanhSachCNNghiKPTheoNam

        Dim SqlParam As SqlParameter() = {New SqlParameter("@NGAYBD", Data.SqlDbType.DateTime), _
                                     New SqlParameter("@NGAYKT", Data.SqlDbType.DateTime), _
                                     New SqlParameter("@XUONG", Data.SqlDbType.NVarChar, 50)}
        SqlParam(0).Value = CDate(sTuNgay)
        SqlParam(1).Value = CDate(sDenNgay)
        SqlParam(2).Value = sXuong
        tbltam = Me.b.ThongKe("SP_THONGKENGHIKHONGPHEPNAM_XUONG_NAMHT_S", SqlParam)

        Return tbltam
    End Function
    Private Function ThongKeNghiKhongPhep_Xuong_(ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sXuong As String) As DataTable
        Dim tbltam As DataTable
        Dim listpar As New ArrayList(3)
        Me.b = New clsBDanhSachCNNghiKPTheoNam

        Dim SqlParam As SqlParameter() = {New SqlParameter("@NGAYBD", Data.SqlDbType.DateTime), _
                                     New SqlParameter("@NGAYKT", Data.SqlDbType.DateTime), _
                                     New SqlParameter("@XUONG", Data.SqlDbType.NVarChar, 50)}
        SqlParam(0).Value = CDate(sTuNgay)
        SqlParam(1).Value = CDate(sDenNgay)
        SqlParam(2).Value = sXuong
        tbltam = Me.b.ThongKe("SP_THONGKENGHIKHONGPHEPNAM_XUONG_NAMCU_S", SqlParam)

        Return tbltam
    End Function
    Public fWaiting As frmThongKeNghiODonvi
    Private Sub bntXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXem.Click
        Dim obj As New objDanhSachCNNghiKPTheoNam
        Dim grid As New clsTformatGrid
        Dim bChonKhu As Boolean = True
        Dim bChonNamcu As Boolean = False

        If Me.dtpNam.Value.ToString() = "" Then
            MessageBox.Show("Vui lòng chọn năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Me.cbXuong.Value = "" Then
            MessageBox.Show("Vui lòng chọn xem xưởng,khu hoặc công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim DenNgay As String
        Dim TuNgay As String = CDate(Me.dtpNam.Value).Year.ToString() + "/01/01"

      

        obj.XUONG = Me.cbXuong.Value
        Select Case obj.XUONG
            Case "TCT"
                obj.XUONG = "TCT"
                obj.KHU = "TCT"
                bChonKhu = True
            Case "KHUA"
                obj.XUONG = ""
                obj.KHU = "A"
                bChonKhu = True

            Case "KHUB"
                obj.XUONG = ""
                obj.KHU = "B"
                bChonKhu = True
            Case "KHUDVC"
                obj.XUONG = ""
                obj.KHU = "DVC"
                bChonKhu = True
            Case Else
                obj.XUONG = obj.XUONG
                obj.KHU = ""
                bChonKhu = False
        End Select

        fWaiting = frmThongKeNghiODonvi.ShowProgress(Me)
        Me.ProgressBar1.Style = ProgressBarStyle.Marquee

        If CDate(Me.dtpNam.Value).Year < CDate(Now()).Year Then
            DenNgay = CDate(Me.dtpNam.Value).Year.ToString() + "/12/31"
            bChonNamcu = True
        Else
            DenNgay = CDate(Me.dtpNam.Value).Year.ToString() + "/" + CDate(Now()).Month.ToString() + "/" + CDate(Now()).Day.ToString()
            bChonNamcu = False
        End If

        obj.NBD = TuNgay
        obj.NKT = DenNgay

        If bChonNamcu = False Then
            If bChonKhu Then
                Me.Tabletk = ThongKeNghiKhongPhep_Khu(obj.NBD, obj.NKT, obj.KHU)
            Else
                Me.Tabletk = ThongKeNghiKhongPhep_Xuong(obj.NBD, obj.NKT, obj.XUONG)
            End If
        Else
            If bChonKhu Then
                obj.ChonBang = 1
                Dim tblDV, tblTemp As DataTable
                Me.Tabletk = New DataTable()
                tblDV = Me.b.LoadDS(obj)

                For i As Integer = 0 To tblDV.Rows.Count - 1
                    obj.XUONG = tblDV.Rows(i).Item("X_MA_").ToString
                    tblTemp = ThongKeNghiKhongPhep_Xuong_(obj.NBD, obj.NKT, obj.XUONG)
                    If tblTemp Is Nothing Then
                    Else
                        Tabletk.Merge(tblTemp)
                    End If
                Next
            Else
                Me.Tabletk = ThongKeNghiKhongPhep_Xuong_(obj.NBD, obj.NKT, obj.XUONG)
            End If
        End If

        Me.dgrBC.DataSource = Me.Tabletk

        If Me.dgrBC.Rows.Count > 0 Then
            LoadGridView()
            Me.btExcel.Enabled = True
        Else
            Me.btExcel.Enabled = False
        End If

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlNoXML(dgrBC)
        fWaiting.CloseProgress()
        Me.ProgressBar1.Style = ProgressBarStyle.Blocks
        Me.ProgressBar1.Value = 100
        Me.BringToFront()
        frmMain.SendToBack()
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
                .Columns("NV_MA").Header.Caption = "SỐ THẺ"
                .Columns("NV_TEN").Header.Caption = "HỌ TÊN"
                .Columns("KHU").Header.Caption = "KHU"
                .Columns("DV_MA").Header.Caption = "ĐƠN VỊ"
                .Columns("X_MA_").Header.Caption = "XƯỞNG"
                .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG"
                .Columns("GHICHU").Header.Caption = "GHI CHÚ"

                .Columns("THANG1").Header.Caption = "THÁNG 1"
                .Columns("THANG2").Header.Caption = "THÁNG 2"
                .Columns("THANG3").Header.Caption = "THÁNG 3"
                .Columns("THANG4").Header.Caption = "THÁNG 4"
                .Columns("THANG5").Header.Caption = "THÁNG 5"

                .Columns("THANG6").Header.Caption = "THÁNG 6"
                .Columns("THANG7").Header.Caption = "THÁNG 7"
                .Columns("THANG8").Header.Caption = "THÁNG 8"
                .Columns("THANG9").Header.Caption = "THÁNG 9"
                .Columns("THANG10").Header.Caption = "THÁNG 10"
                .Columns("THANG11").Header.Caption = "THÁNG 11"
                .Columns("THANG12").Header.Caption = "THÁNG 12"
               

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
                band.ColHeaderLines = 1
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
End Class