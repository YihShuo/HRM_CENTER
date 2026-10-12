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
Public Class frmDienBienLuong

    Private Sub btXemreport_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemreport.Activate
        Dim sKhu As String = ""
        Dim strArray As String()
        Dim report As New FrmReport
        If Me.radTCT.Checked Then
            sKhu = "TCT"
        End If

        If Me.radKhuA.Checked Then
            sKhu = "A"
        End If

        If Me.radKhuB.Checked Then
            sKhu = "B"
        End If

        If Me.chkDV.Checked = False And Me.chkDBL.Checked = False Then ''THEODOIDIENBIENLUONG.rpt
            Select Case sKhu
                Case "A" 'loc nhu toan cong ty ma gioi han lai KHUA
                    Me.ReportID = "705"
                    strArray = New String() {Me.dtpThang.Text, sKhu}
                Case "B"  'loc nhu toan cong ty ma gioi han lai KHUB
                    Me.ReportID = "705"
                    strArray = New String() {Me.dtpThang.Text, sKhu}
                Case "TCT"
                    Me.ReportID = "688"  'Toan cong ty
                    strArray = New String() {Me.dtpThang.Text}
                Case Else
                    Me.ReportID = "688"  'Toan cong ty
                    strArray = New String() {Me.dtpThang.Text}
            End Select


        ElseIf Me.chkDV.Checked = False And Me.chkDBL.Checked = True Then  ''THEODOIDIENBIENLUONGTHEONGAY

            Select Case sKhu
                Case "A" 'loc nhu toan cong ty ma gioi han lai KHUA
                    Me.ReportID = "706"
                    strArray = New String() {Me.dtpThang.Text, sKhu}
                Case "B"  'loc nhu toan cong ty ma gioi han lai KHUB
                    Me.ReportID = "706"
                    strArray = New String() {Me.dtpThang.Text, sKhu}
                Case "TCT"
                    Me.ReportID = "693"  'Toan cong ty
                    strArray = New String() {Me.dtpThang.Text}
                Case Else
                    Me.ReportID = "693"  'Toan cong ty
                    strArray = New String() {Me.dtpThang.Text}
            End Select


        ElseIf Me.chkDV.Checked = True And Me.chkDBL.Checked = False Then   ''THEODOIDIENBIENLUONGDONVI.rpt

            If Me.cbDonvi.Text = "" Then
                MessageBox.Show("Vui lòng chọn đơn vị để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.ReportID = "687"  'Toan cong ty
            strArray = New String() {Me.dtpThang.Text, Me.cbDonvi.Text}


        ElseIf Me.chkDV.Checked = True And Me.chkDBL.Checked = True Then  ''THEODOIDIENBIENLUONGDONVITHEONGAY.rpts
            If Me.cbDonvi.Text = "" Then
                MessageBox.Show("Vui lòng chọn đơn vị để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.ReportID = "694"  'Toan cong ty
            strArray = New String() {Me.dtpThang.Text, Me.cbDonvi.Text}
        End If

        report.reportID = Me.ReportID
        report.para = strArray
        report.issysReport = True
        report.Refresh()
        report.Update()
        report.Show()

    End Sub
    Dim flag As Boolean
    Dim obj As New objDienBienLuong
    Dim Table As String
    Dim Path As String
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim ReportID As String
    Friend WithEvents d As clsDDienBienLuong  ' Nested Types
    Friend WithEvents b As clsBDienBienLuong
    Private Sub frmDienBienLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDonvi()
        Me.cbDonvi.Enabled = False
        Me.radTCT.Checked = True
    End Sub
    Private Sub LoadDonvi()
        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBDienBienLuong
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.DisplayMember() = "DV_MA"
        Me.cbDonvi.ValueMember() = "DV_MA"
        'Chon Don Vi dau tien trong combo
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        'Me.cbDonvi.Enabled = False
    End Sub
    Private Sub THEODOIDIENBIENLUONG(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        'grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/DienBienLuong.xml"), typeControl.Grid, "coldgrhoso")
        Me.GridView()
    End Sub
    Private Sub GridView()
        For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.HAlign.Center
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
        ''==========================
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("MA").Header.Caption = "Số Thẻ"
            .Columns("TEN").Header.Caption = "Họ Tên"
            .Columns("DONVI").Header.Caption = "Đơn Vị"
            .Columns("CHUCVU").Header.Caption = "Chức vụ"
            .Columns("CONGVIEC").Header.Caption = "Công việc"
            .Columns("NGAYVAO").Header.Caption = "Ngày Vào"
            .Columns("NGAYKY").Header.Caption = "Ngày Ký"
            .Columns("NNDH").Header.Caption = "NNDH"

            .Columns("NGAYMOI").Header.Caption = "Ngày Mới"
            .Columns("NGAYCU").Header.Caption = "Ngày Cũ"

            .Columns("LUONGMOI").Header.Caption = "Lương Mới"
            .Columns("LUONGCU").Header.Caption = "Lương Cũ"
            ''============= các khoản trợ cấp ===============''
            .Columns("TROCAPTCCVMOI").Header.Caption = "TROCAPTCCVMOI"
            .Columns("TROCAPTCCVCU").Header.Caption = "TROCAPTCCVCU"

            .Columns("TROCAPCBTSMOI").Header.Caption = "TROCAPCBTSMOI"
            .Columns("TROCAPCBTSCU").Header.Caption = "TROCAPCBTSCU"

            .Columns("TROCAPCBVPMOI").Header.Caption = "TROCAPCBVPMOI"
            .Columns("TROCAPCBVPCU").Header.Caption = "TROCAPCBVPCU"

            .Columns("TROCAPCMNVMOI").Header.Caption = "TROCAPCMNVMOI"
            .Columns("TROCAPCMNVCU").Header.Caption = "TROCAPCMNVCU"

            .Columns("TROCAPUDMAYMOI").Header.Caption = "TROCAPUDMAYMOI"
            .Columns("TROCAPUDMAYCU").Header.Caption = "TROCAPUDMAYCU"

            .Columns("TROCAPThoRapMOI").Header.Caption = "TROCAPThoRapMOI"
            .Columns("TROCAPThoRapCU").Header.Caption = "TROCAPThoRapCU"

            .Columns("TROCAPQAQIPMOI").Header.Caption = "TROCAPQAQIPMOI"
            .Columns("TROCAPQAQIPCU").Header.Caption = "TROCAPQAQIPCU"

            .Columns("TROCAPHSEMOI").Header.Caption = "TROCAPHSEMOI"
            .Columns("TROCAPHSECU").Header.Caption = "TROCAPHSECU"

            .Columns("TROCAPNNMOI").Header.Caption = "TROCAPNNMOI"
            .Columns("TROCAPNNCU").Header.Caption = "TROCAPNNCU"

            .Columns("TROCAPDQTVMOI").Header.Caption = "TCDQTVMOI"
            .Columns("TROCAPDQTVCU").Header.Caption = "TCDQTVCU"

            .Columns("TROCAPPCCCMOI").Header.Caption = "TCPCCCMOI"
            .Columns("TROCAPPCCCCU").Header.Caption = "TCPCCCCU"

            .Columns("QDMOI").Header.Caption = "QDMOI"
            .Columns("QDCU").Header.Caption = "QDCU"

            .Columns("HESOMOI").Header.Caption = "HESOMOI"
            .Columns("HESOCU").Header.Caption = "HESOCU"
            ''-------- DƯA VAO DONG MOI TRUONG MOI CU
            .Columns("TCMOITRUONGMOI").Header.Caption = "TCMOITRUONGMOI"
            .Columns("TCMOITRUONGCU").Header.Caption = "TCMOITRUONGCU"

            

            ''----------------------------------------------------------------
            .Columns("TONGPCDONGBHMOI").Header.Caption = "TONGPCDONGBHMOI"
            .Columns("TONGPCDONGBHCU").Header.Caption = "TONGPCDONGBHCU"

            .Columns("TONGPCKHONGDONGBH").Header.Caption = "TONGPCKHONGDONGBH"

            .Columns("TEN").Width = 150
            .Columns("DONVI").Width = 150
            .Columns("CONGVIEC").Width = 500
            .Columns("NGAYVAO").Width = 100
            .Columns("NGAYKY").Width = 100
            .Columns("NGAYVAO").Format = "dd/MM/yyyy"
            .Columns("NGAYKY").Format = "dd/MM/yyyy"

            Me.dgrBC.DisplayLayout.Bands(0).Columns("TEN").CellAppearance.TextVAlign = Infragistics.Win.HAlign.Left
            Me.dgrBC.DisplayLayout.Bands(0).Columns("DONVI").CellAppearance.TextVAlign = Infragistics.Win.HAlign.Left
            Me.dgrBC.DisplayLayout.Bands(0).Columns("CONGVIEC").CellAppearance.TextVAlign = Infragistics.Win.HAlign.Left
            .Columns("TEN").Width = 150
            .Columns("DONVI").Width = 150
            .Columns("CONGVIEC").Width = 500

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
        band.Layout.Override.ColumnSizingArea = ColumnSizingArea.EntireColumn
        band.Layout.Override.RowSizing = RowSizing.AutoFree
        band.Layout.Override.CellMultiLine = DefaultableBoolean.False
        band.ColHeaderLines = 1

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing
    End Sub
    Private Sub chkDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDV.CheckedChanged
        If Me.chkDV.Checked = True Then
            Me.cbDonvi.Enabled = True
            ''===================
            Me.radTCT.Enabled = False
            Me.radKhuA.Enabled = False
            Me.radKhuB.Enabled = False
             
        Else
            Me.cbDonvi.Enabled = False
            Me.radTCT.Enabled = True
            Me.radKhuA.Enabled = True
            Me.radKhuB.Enabled = True
            LoadDonvi()
        End If
    End Sub

    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        If Me.chkDV.Checked = False And Me.chkDBL.Checked = False Then
            Dim THEODOIDIENBIENLUONG_ As DataTable
            Dim ngay As Date = Me.dtpThang.Value
            obj.NGAY = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            Dim listpar As New ArrayList(1)
            listpar.Clear()
            listpar.Add(New SqlParameter("@NGAY", obj.NGAY))
            If Me.radTCT.Checked Then
                THEODOIDIENBIENLUONG_ = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONG_S", listpar)
            End If
            If Me.radKhuA.Checked Then
                THEODOIDIENBIENLUONG_ = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONG_KHUA_S", listpar)
            End If

            If Me.radKhuB.Checked Then
                THEODOIDIENBIENLUONG_ = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONG_KHUB_S", listpar)
            End If

            THEODOIDIENBIENLUONG(THEODOIDIENBIENLUONG_)

        ElseIf Me.chkDV.Checked = False And Me.chkDBL.Checked = True Then

            Dim THEODOIDIENBIENLUONGTHEONGAY As DataTable
            Dim ngay As Date = Me.dtpThang.Value
            obj.NGAY = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            Dim listpar As New ArrayList(1)
            listpar.Add(New SqlParameter("@NGAY", obj.NGAY))

            If Me.radTCT.Checked Then
                THEODOIDIENBIENLUONGTHEONGAY = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONGTHEONGAY_S", listpar)
            End If
            If Me.radKhuA.Checked Then
                THEODOIDIENBIENLUONGTHEONGAY = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONGTHEONGAY_KHUA_S", listpar)
            End If

            If Me.radKhuB.Checked Then
                THEODOIDIENBIENLUONGTHEONGAY = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONGTHEONGAY_KHUB_S", listpar)
            End If

            listpar.Clear()
            THEODOIDIENBIENLUONG(THEODOIDIENBIENLUONGTHEONGAY)

        ElseIf Me.chkDV.Checked = True And Me.chkDBL.Checked = False Then
            Dim THEODOIDIENBIENLUONGDONVI As DataTable
            Dim ngay As Date = Me.dtpThang.Value
            obj.NGAY = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            obj.DonVi = Me.cbDonvi.Value
            Dim listpar As New ArrayList(1)
            listpar.Add(New SqlParameter("@NGAY", obj.NGAY))
            listpar.Add(New SqlParameter("@DONVI", obj.DonVi))
            THEODOIDIENBIENLUONGDONVI = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONGDONVI_S", listpar)
            listpar.Clear()
            THEODOIDIENBIENLUONG(THEODOIDIENBIENLUONGDONVI)
        ElseIf Me.chkDV.Checked = True And Me.chkDBL.Checked = True Then

            Dim THEODOIDIENBIENLUONGDONVITHEONGAY As DataTable
            Dim ngay As Date = Me.dtpThang.Value
            obj.NGAY = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            obj.DonVi = Me.cbDonvi.Value
            Dim listpar As New ArrayList(1)
            listpar.Add(New SqlParameter("@NGAY", obj.NGAY))
            listpar.Add(New SqlParameter("@DONVI", obj.DonVi))
            THEODOIDIENBIENLUONGDONVITHEONGAY = Me.b.GoiThuTucLoadDS("SP_THEODOIDIENBIENLUONGDONVITHEONGAY_S", listpar)
            listpar.Clear()
            THEODOIDIENBIENLUONG(THEODOIDIENBIENLUONGDONVITHEONGAY)
        End If
    End Sub

    Private Sub chkNgayVao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDBL.CheckedChanged
        If Me.chkDBL.Checked = True Then
            If Me.chkDV.Checked = True Then
                Me.radTCT.Enabled = False
                Me.radKhuA.Enabled = False
                Me.radKhuB.Enabled = False
            Else
                Me.radTCT.Enabled = True
                Me.radKhuA.Enabled = True
                Me.radKhuB.Enabled = True
            End If
            Me.dgrBC.DataSource = Nothing
        Else
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub
    
    Sub BtXemreportActivate(sender As Object, e As EventArgs)
    End Sub
    
  
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands.Item(0).Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
            e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
            e.Layout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Left
        Next
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, SaveFileDialog1.FileName.ToString)
            MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class