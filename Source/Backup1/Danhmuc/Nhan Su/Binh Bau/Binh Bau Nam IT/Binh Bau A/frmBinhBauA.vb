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
Imports TongHop.frmMainMain
Imports TongHop.MAIN

Public Class frmBinhBauA
    Dim Tabletemp As DataTable
    Public nguoidung As String
    Friend WithEvents b As New clsBBinhBauA
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Private Sub Tim()
        Dim BinhbauDataTable As New DataTable()
        Dim ChitietDataTable As New DataTable()
        Dim c_dataSet_BinhbauChitiet As New DataSet()
        Me.Tabletemp = Nothing
        Me.b = New clsBBinhBauA
        obj.NAM = Me.cbNam.Text
        If Me.cbBinhBau.Text = "" Then
            MessageBox.Show("Bạn phải chọn loại bình bầu")
        Else

            'Load danh sach nhan vien theo don vi
            If Me.cbBinhBau.Text = "A" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauA()
                Me.Tabletemp = Nothing
                obj.ChonBang = 1
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "ANEW" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauANEW()
                Me.Tabletemp = Nothing
                obj.ChonBang = 2
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "C" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauC()
                Me.Tabletemp = Nothing
                obj.ChonBang = 3
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "CNEW" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauCNEW()
                Me.Tabletemp = Nothing
                obj.ChonBang = 4
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "OX" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauOX()
                Me.Tabletemp = Nothing
                obj.ChonBang = 5
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "B" Then

                obj.NAM = Me.cbNam.Text
                obj.TUNGAY = Me.cbTuNgay.Text
                obj.DENNGAY = Me.cbDenNgay.Text
                'Me.TinhBinhBauB()
                Me.Tabletemp = Nothing
                obj.ChonBang = 6
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "Toàn bộ" And Me.chkChiTiet.Checked = True Then
                If Me.cbNam.Text <> "" And Me.cbDenNgay.Text <> "" Then
                    'Me.b = New clsBBinhBauA
                    Me.dgrBC.DataSource = Nothing
                    Me.txtSonhanvien.Text = ""
                    obj.NAM = Me.cbNam.Text
                    obj.DENNGAY = Me.cbDenNgay.Text
                    Me.TinhBinhBauChiTiet()
                End If
                If Me.radTCT.Checked = True Then
                    obj.ChonBang = 7
                End If
                If Me.radKhuA.Checked = True Then
                    obj.ChonBang = 77
                End If
                If Me.radKhuB.Checked = True Then
                    obj.ChonBang = 777
                End If
                BinhbauDataTable = Me.b.LoadDS(obj)
                If Not BinhbauDataTable Is Nothing Then
                    c_dataSet_BinhbauChitiet.Tables.Add(BinhbauDataTable)
                End If

                obj.ChonBang = 8
                ChitietDataTable = Me.b.LoadDS(obj)
                If Not ChitietDataTable Is Nothing Then
                    c_dataSet_BinhbauChitiet.Tables.Add(ChitietDataTable)
                End If

                ''=================================================================================================================

                Dim relBinhbauchitiet As New DataRelation("Binhbauchitiet", BinhbauDataTable.Columns("NV_MA"), ChitietDataTable.Columns("NV_MA"), False)
                c_dataSet_BinhbauChitiet.Relations.Add(relBinhbauchitiet)

                ' bind DataSet to UltraGrid
                Me.dgrBC.DataSource = Nothing
                Me.dgrBC.DataSource = c_dataSet_BinhbauChitiet
            End If
            If Me.cbBinhBau.Text = "Toàn bộ" And Me.chkChiTiet.Checked = False And Me.chkThaiSan.Checked = False And Me.radTCT.Checked = True Then
                Me.Tabletemp = Nothing
                obj.ChonBang = 7
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "Toàn bộ" And Me.chkChiTiet.Checked = False And Me.chkThaiSan.Checked = False And Me.radKhuA.Checked = True Then
                Me.Tabletemp = Nothing
                obj.ChonBang = 77
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "Toàn bộ" And Me.chkChiTiet.Checked = False And Me.chkThaiSan.Checked = False And Me.radKhuB.Checked = True Then
                Me.Tabletemp = Nothing
                obj.ChonBang = 777
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
            If Me.cbBinhBau.Text = "Toàn bộ" And Me.chkChiTiet.Checked = False And Me.chkThaiSan.Checked = True Then
                Me.Tabletemp = Nothing
                obj.ChonBang = 13
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
        End If
    End Sub
    Dim oldRow As Integer = 0
    Public Shared obj As New objBinhBauA
    Public Sub TinhBinhBauA()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUA", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhBinhBauANEW()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUANEW", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhBinhBauC()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUC", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhBinhBauCNEW()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUCNEW", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhBinhBauOX()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUOX", listpar)
        listpar.Clear()
    End Sub
    Public Sub TinhBinhBauB()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@TUNGAY", obj.TUNGAY))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUB", listpar)
        listpar.Clear()
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/BinhBauA.xml"), typeControl.Grid, "coldgrbinhbauthang")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        If Me.cbBinhBau.Text <> "" And Me.cbNam.Text <> "" And Me.cbTuNgay.Text <> "" And Me.cbDenNgay.Text <> "" Then
            Me.Tim()
        End If
    End Sub
    Dim TableDV As DataTable
    Private Sub frmBinhBauA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nam As Integer
        Dim NGAY As Date = Now
        nam = Convert.ToInt32(NGAY.Year.ToString())
        For nam = 2011 To nam
            Me.cbNam.Items.Add(nam.ToString)
        Next
        nguoidung = Microsoft.VisualBasic.StrConv(MAIN.userclient, 1)
        'LOAD ĐON VI
        obj.ChonBang = 11
        Me.b = New clsBBinhBauA
        Me.TableDV = Me.b.LoadDS(obj)
        Me.cbDonvi.DataSource = Me.TableDV
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.ValueMember = "DV_MA"

        Me.cbDonvi.Enabled = False

        obj.ChonBang = 12
        Me.b = New clsBBinhBauA
        Me.TableDV = Me.b.LoadDS(obj)
        Me.cbXuong.DataSource = Me.TableDV
        Me.cbXuong.DisplayMember = "X_MA_"
        Me.cbXuong.ValueMember = "X_MA_"

        Me.cbXuong.Enabled = False

    End Sub

    Private Sub cbNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNam.SelectedIndexChanged
        Dim thang As Integer
        Me.cbTuNgay.Items.Clear()
        Me.cbDenNgay.Items.Clear()
        For thang = 1 To 12
            Me.cbTuNgay.Items.Add(Microsoft.VisualBasic.Right("0" & thang.ToString, 2) & "-" & cbNam.Text)
            Me.cbDenNgay.Items.Add(Microsoft.VisualBasic.Right("0" & thang.ToString, 2) & "-" & cbNam.Text)
        Next
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        'Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        Me.SaveFileDialog1.Filter() = "Excel Files (*.xlsx)|*.xlsx|Excel 97-2003 Files (*.xls)|*.xls|All Files (*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub cbBinhBau_ValueMemberChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBinhBau.ValueMemberChanged, cbDonvi.ValueMemberChanged, cbXuong.ValueMemberChanged

    End Sub

    Private Sub cbBinhBau_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBinhBau.SelectedIndexChanged, cbDonvi.SelectedIndexChanged, cbXuong.SelectedIndexChanged
        Me.dgrBC.DataSource = Nothing
        Me.txtSonhanvien.Text = ""
        'If Me.cbBinhBau.Text = "Toàn bộ" Then
        '    Me.chkChiTiet.Enabled = True
        'Else
        '    Me.chkChiTiet.Enabled = False
        'End If
        If Me.cbBinhBau.Text = "A" Then
            Me.chkChiTiet.Checked = False
        End If
        If Me.cbBinhBau.Text = "ANEW" Then
            Me.chkChiTiet.Checked = False
        End If
        If Me.cbBinhBau.Text = "C" Then
            Me.chkChiTiet.Checked = False
        End If
        If Me.cbBinhBau.Text = "CNEW" Then
            Me.chkChiTiet.Checked = False
        End If
        If Me.cbBinhBau.Text = "OX" Then
            Me.chkChiTiet.Checked = False
        End If
        If Me.cbBinhBau.Text = "B" Then
            Me.chkChiTiet.Checked = False
        End If
    End Sub

    Public Sub TinhBinhBauChiTiet()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NAM_", obj.NAM))
        listpar.Add(New SqlParameter("@DENNGAY", obj.DENNGAY))
        Me.b.GoiThuTuc("SP_BINHBAUCT", listpar)
        listpar.Clear()
    End Sub
    Private Sub chkChiTiet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChiTiet.CheckedChanged
        Me.dgrBC.DataSource = Nothing
        If Me.chkChiTiet.Checked = True Then
            Me.chkThaiSan.Checked = False
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.AutoFitColumns = True
        'e.Layout.Bands(0).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
        'e.Layout.Bands(1).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
        'Sumary
        'e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True
        'Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(0)
        On Error Resume Next
        ''e.Layout.Bands(0).Summaries.RemoveAt(0)
        'Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)

        Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(0)
        e.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        ''e.SummaryFooterCaption = "Tổng số: "

        summary.Appearance.TextHAlign = HAlign.Right
        e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        Me.dgrBC.Text = "Thống kê bình bầu năm"
        'e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"
        'e.Layout.AddNewBox.Hidden = False
        'e.Layout.AddNewBox.Prompt = "Thêm mới"
        'Sort
        e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle

        'Filter
        e.Layout.Override.FilterUIType = FilterUIType.FilterRow
        e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        'e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        'Column Chooser

        e.Layout.Override.RowSelectors = DefaultableBoolean.True
        e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

        With Me.dgrBC.DisplayLayout

            ' set Layout properties
            .AutoFitColumns = True
            .Bands(0).Columns(0).Header.Caption = "STT"
            .Bands(0).Columns(0).Width = 150
            .Bands(0).Columns(1).Header.Caption = "Họ và tên"
            .Bands(0).Columns(1).Width = 250
            .Bands(0).Columns(2).Header.Caption = "Ngày Vào"
            .Bands(0).Columns(2).Format = "dd/MM/yyyy"
            .Bands(0).Columns(2).Width = 160
            .Bands(0).Columns(3).Header.Caption = "Nam"
            .Bands(0).Columns(3).Width = 80
            .Bands(0).Columns(4).Header.Caption = "Nữ"
            .Bands(0).Columns(4).Width = 80
            .Bands(0).Columns(5).Header.Caption = "Số thẻ"
            .Bands(0).Columns(5).Width = 130
            .Bands(0).Columns(6).Header.Caption = "Đơn vị"
            .Bands(0).Columns(6).Width = 160
            .Bands(0).Columns(7).Header.Caption = "Ngày sinh"
            .Bands(0).Columns(7).Format = "dd/MM/yyyy"
            .Bands(0).Columns(7).Width = 160
            .Bands(0).Columns(8).Header.Caption = "Số tháng"
            .Bands(0).Columns(9).Header.Caption = "BB Năm"
            .Bands(0).Columns(10).Header.Caption = "A"
            .Bands(0).Columns(11).Header.Caption = "B"
            .Bands(0).Columns(12).Header.Caption = "C"
            .Bands(0).Columns(13).Header.Caption = "D"
            .Bands(0).Columns(14).Header.Caption = "OX"
            .Bands(0).Columns(15).Header.Caption = "HS"
            .Bands(0).Columns(16).Header.Caption = "OO"
            .Bands(0).Columns(17).Header.Caption = "RO"
            .Bands(0).Columns(18).Header.Caption = "CO"
            .Bands(0).Columns(19).Header.Caption = "O"
            .Bands(0).Columns(20).Header.Caption = "OTC"
            .Bands(0).Columns(21).Header.Caption = "P"
            .Bands(0).Columns(22).Header.Caption = "KT"
            .Bands(0).Columns(23).Header.Caption = "R"
            .Bands(0).Columns(24).Header.Caption = "S"
            .Bands(0).Columns(25).Header.Caption = "NO"
            .Bands(0).Columns(26).Header.Caption = "KHHGD"
            .Bands(0).Columns(27).Header.Caption = "QS"
            .Bands(0).Columns(28).Header.Caption = "TS"
            .Bands(0).Columns(29).Header.Caption = "TNLĐ"
            .Bands(0).Columns(30).Header.Caption = "DQ"
            .Bands(0).Columns(31).Header.Caption = "DS"
            .Bands(0).Columns(32).Header.Caption = "ST"
            Dim i As Integer
            For i = 0 To 31
                .Bands(0).Columns(i).CellActivation = Activation.NoEdit
            Next
            .Bands(1).Columns(1).Hidden = True
            'Show Hide
        End With
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        Select Case e.Row.Band.Index
            Case 0 ' bands(0) =======================================================

                e.Row.Cells("STT").Value = e.Row.Index + 1
                e.Row.Update()

            Case 1 ' bands(1) =======================================================
                e.Row.Cells("STT").Value = e.Row.Index + 1
                e.Row.Update()
        End Select
    End Sub

    Private Sub lbBBCB_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim report As New FrmReport
        If Me.chkChiTiet.Checked = False Then
            report.reportID = "98611"
        Else
            report.reportID = "98511"
            Dim strArray As String() = New String() {Me.cbTuNgay.Text, Me.cbDenNgay.Text}
            report.para = strArray
        End If
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub lbBBCNV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim report As New FrmReport
        If Me.chkChiTiet.Checked = False Then
            report.reportID = "9866"
        Else
            report.reportID = "9855"
            Dim strArray As String() = New String() {Me.cbTuNgay.Text, Me.cbDenNgay.Text}
            report.para = strArray
        End If
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub lbBBTH_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbBBTH.LinkClicked
        Dim nam As String
        nam = Microsoft.VisualBasic.Right(Me.cbDenNgay.Text, 4)
        Dim report As New FrmReport

        '' TOAN CTY
        If Me.chkChiTiet.Checked = False And chkXuong.Checked = False And Me.radTCT.Checked = True Then
            report.reportID = "985TB"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = False And Me.radTCT.Checked = True Then
            report.reportID = "985CT"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = True And Me.cbXuong.Text <> "" And Me.radTCT.Checked = True Then
            report.reportID = "985CTDV"
            Dim strArray As String() = New String() {Me.cbXuong.Text, nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = False And chkXuong.Checked = True And Me.cbXuong.Text <> "" Then
            MessageBox.Show("Bạn phải check vào bình bầu chi tiết", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        End If
        '' KHU A

        If Me.chkChiTiet.Checked = False And chkXuong.Checked = False And Me.radKhuA.Checked = True Then
            report.reportID = "985TBA"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = False And Me.radKhuA.Checked = True Then
            report.reportID = "985CTA"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = True And Me.cbXuong.Text <> "" And Me.radKhuA.Checked = True Then
            report.reportID = "985CTDVA"
            Dim strArray As String() = New String() {Me.cbXuong.Text, nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = False And chkXuong.Checked = True And Me.cbXuong.Text <> "" Then
            MessageBox.Show("Bạn phải check vào bình bầu chi tiết", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        End If

        '' KHU B
        If Me.chkChiTiet.Checked = False And chkXuong.Checked = False And Me.radKhuB.Checked = True Then
            report.reportID = "985TBB"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = False And Me.radKhuB.Checked = True Then
            report.reportID = "985CTB"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkXuong.Checked = True And Me.cbXuong.Text <> "" And Me.radKhuB.Checked = True Then
            report.reportID = "985CTDVB"
            Dim strArray As String() = New String() {Me.cbXuong.Text, nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = False And chkXuong.Checked = True And Me.cbXuong.Text <> "" Then
            MessageBox.Show("Bạn phải check vào bình bầu chi tiết", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        End If
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub lbCapNhatBBNam_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbCapNhatBBNam.LinkClicked
        If (MessageBox.Show(("Bạn có chắc muốn cập nhật vào bảng bình bầu năm không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            If Me.cbNam.Text <> "" Then
                'kiem tra coi da co nam do trong bang do chua
                obj.ChonBang = 9
                obj.NAM = Me.cbNam.Text
                Me.b = New clsBBinhBauA
                Me.Tabletemp = Me.b.LoadDS(obj)
                If Tabletemp.Rows.Count > 0 Then
                    If (MessageBox.Show(("Bình bầu năm " & obj.NAM & " đã có. Bạn có tiếp tục cập nhật không"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                        obj.ChonBang = 1
                        obj.NAM = Me.cbNam.Text
                        Me.b = New clsBBinhBauA
                        Me.b.DeleteInfo(obj)

                        obj.ChonBang = 10
                        obj.NAM = Me.cbNam.Text
                        Me.b = New clsBBinhBauA
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        MessageBox.Show("Đã cập nhật thành công")
                    End If
                Else
                    obj.ChonBang = 10
                    obj.NAM = Me.cbNam.Text
                    Me.b = New clsBBinhBauA
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    MessageBox.Show("Đã cập nhật thành công")
                End If
            End If
        End If
    End Sub

    Private Sub btTinhBinhBau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'obj.NAM = Me.cbNam.Text
        'obj.TUNGAY = Me.cbTuNgay.Text
        'obj.DENNGAY = Me.cbDenNgay.Text
        'If Me.cbNam.Text <> "" And Me.cbTuNgay.Text <> "" And Me.cbDenNgay.Text <> "" Then
        '    If (MessageBox.Show(("Bạn có chắc muốn tính bình bầu không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
        '        If Me.cbBinhBau.Text = "A" Then
        '            Me.TinhBinhBauA()
        '            MessageBox.Show("Đã tính bình bầu A")
        '        End If
        '        If Me.cbBinhBau.Text = "ANEW" Then
        '            Me.TinhBinhBauANEW()
        '            MessageBox.Show("Đã tính bình bầu A NEW")
        '        End If
        '        If Me.cbBinhBau.Text = "C" Then
        '            Me.TinhBinhBauC()
        '            MessageBox.Show("Đã tính bình bầu C")
        '        End If
        '        If Me.cbBinhBau.Text = "CNEW" Then
        '            Me.TinhBinhBauCNEW()
        '            MessageBox.Show("Đã tính bình bầu C NEW")
        '        End If
        '        If Me.cbBinhBau.Text = "OX" Then
        '            Me.TinhBinhBauOX()
        '            MessageBox.Show("Đã tính bình bầu OX")
        '        End If
        '        If Me.cbBinhBau.Text = "B" Then
        '            Me.TinhBinhBauB()
        '            MessageBox.Show("Đã tính bình bầu B")
        '        End If
        '    Else
        '        Exit Sub
        '    End If
        'Else
        '    MessageBox.Show("Bạn phải nhập đầy đủ thông tin : năm, từ ngày, đến ngày")
        '    Exit Sub
        'End If
    End Sub

    Private Sub chkDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonvi.CheckedChanged
        If Me.chkDonvi.Checked = False Then
            Me.cbDonvi.Enabled = False
        Else
            Me.cbDonvi.Enabled = True
            Me.chkXuong.Checked = False
        End If
    End Sub

    Private Sub linkBBTS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'Dim report As New FrmReport
        'If Me.chkChiTiet.Checked = False Then
        '    report.reportID = "BBTS"
        'Else
        '    report.reportID = "BBTSCT"
        '    Dim strArray As String() = New String() {Me.cbTuNgay.Text, Me.cbDenNgay.Text}
        '    report.para = strArray
        'End If
        'report.issysReport = True
        'report.Show()
    End Sub

    Private Sub linkBBTHTS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkBBTHTS.LinkClicked
        Dim nam As String
        nam = Microsoft.VisualBasic.Right(Me.cbDenNgay.Text, 4)
        Dim report As New FrmReport
        If Me.chkChiTiet.Checked = False And chkDonvi.Checked = False Then
            report.reportID = "BBTHTS"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkDonvi.Checked = False Then
            report.reportID = "BBCTTS"
            Dim strArray As String() = New String() {nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = False And chkDonvi.Checked = True And Me.cbDonvi.Text <> "" Then
            report.reportID = "BBTHTSDV"
            Dim strArray As String() = New String() {Me.cbDonvi.Text, nam}
            report.para = strArray
        ElseIf Me.chkChiTiet.Checked = True And chkDonvi.Checked = True And Me.cbDonvi.Text <> "" Then
            report.reportID = "BBCTTSDV"
            Dim strArray As String() = New String() {Me.cbDonvi.Text, nam}
            report.para = strArray
        End If
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub chkXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXuong.CheckedChanged
        If Me.chkXuong.Checked = True Then
            Me.cbXuong.Enabled = True
            Me.chkDonvi.Checked = False
        Else
            Me.cbXuong.Enabled = False
        End If
    End Sub

    Private Sub chkThaiSan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThaiSan.CheckedChanged
        Me.dgrBC.DataSource = Nothing
    End Sub
End Class