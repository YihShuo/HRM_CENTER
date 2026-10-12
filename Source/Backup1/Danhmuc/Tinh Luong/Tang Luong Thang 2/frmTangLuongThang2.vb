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
Public Class frmTangLuongThang2
    Dim Tabletemp As DataTable
    Friend WithEvents b As New clsBTangLuongThang2
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Shared obj As New objTangLuongThang2
    Dim TableND As DataTable
    Private Sub frmTangLuongThang2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
                Me.btXem.Visible = True
                Me.btCapNhatVaoBangTangLuong.Visible = True
                Me.btXemDBL.Visible = False
                Me.btXemBC.Visible = False
                Me.btLuu.Visible = False
                Me.btXemHDLD.Visible = False
                Me.btCapNhatDBL.Visible = False
                Me.btCapNhatHDLD.Visible = False
                Me.btXuatExcel.Enabled = True

                Dim obj As New objTangLuongThang2
                Me.b = New clsBTangLuongThang2
                Dim nguoidung As String = MAIN.userclient.ToLower()
                obj.NGUOIDUNG = nguoidung
                If nguoidung = "admin" Then
                    Me.radToanCty.Checked = True
                End If
                obj.MA_DM = "1" + Me.Name
                obj.ChonBang = 13
                Me.TableND = Me.b.LoadDS(obj)
                Dim KHUA As Boolean
                Dim KHUB As Boolean
                If Me.TableND.Rows.Count > 0 Then
                    KHUA = TableND.Rows(0).Item("KHUA").ToString
                    KHUB = TableND.Rows(0).Item("KHUB").ToString
                    If KHUA = True And KHUB = False Then
                        Me.radA.Checked = True
                    ElseIf KHUA = False And KHUB = True Then
                        Me.radB.Checked = True
                    ElseIf KHUA = True And KHUB = True Then
                        Me.radToanCty.Checked = True
                    Else
                        Me.radToanCty.Checked = True
                    End If
                Else
                    Me.radToanCty.Checked = True
                End If

        End Select
    End Sub
    Private Sub LocdulieuTangLuongEdit(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/SuaLuongThang2.xml"), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub LocDSTangLuong(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/DanhSachTangLuong.xml"), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub LocdulieuHDLD(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/DanhSachHDLD.xml"), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub LocdulieuDBL(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/DanhSachDBL.xml"), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        Dim TableDanhSachTangLuong As DataTable
        Select Case tabTangLuong.SelectedTab.Index
            Case 0 '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim listpar As New ArrayList(1)
                If Me.radA.Checked = True Then
                    obj.NGAY = Me.dtpNgay.Value
                    listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                    TableDanhSachTangLuong = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONG_SA", listpar)
                End If
                If Me.radB.Checked = True Then
                    obj.NGAY = Me.dtpNgay.Value
                    listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                    TableDanhSachTangLuong = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONG_SB", listpar)
                End If
                If Me.radToanCty.Checked = True Then
                    obj.NGAY = Me.dtpNgay.Value
                    listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                    TableDanhSachTangLuong = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONG_S", listpar)
                End If
                listpar.Clear()
                LocDSTangLuong(TableDanhSachTangLuong)
            Case 1 '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If (cbDonVi.Text <> "") Then
                    Dim TableTangLuong As New DataTable
                    Dim listpar As New ArrayList(2)
                    obj.NAM = Me.cbNamThang.Text
                    obj.DONVI = Me.cbDonVi.Value
                    If Me.chkTangThamNien.Checked = True Then
                        obj.LOAITL = "TN"
                    Else
                        obj.LOAITL = "TT"
                    End If

                    If Me.radA1.Checked = True Then
                        listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                        listpar.Add(New SqlParameter("@DV_MA", obj.DONVI))
                        listpar.Add(New SqlParameter("@LOAI_TL", obj.LOAITL))
                        TableTangLuong = Me.b.GoiThuTucLoadDS("SP_TANGLUONG_SA", listpar)
                    End If
                    If Me.radB1.Checked = True Then
                        listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                        listpar.Add(New SqlParameter("@DV_MA", obj.DONVI))
                        listpar.Add(New SqlParameter("@LOAI_TL", obj.LOAITL))
                        TableTangLuong = Me.b.GoiThuTucLoadDS("SP_TANGLUONG_SB", listpar)
                    End If
                    If Me.radToanCty1.Checked = True Then
                        listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                        listpar.Add(New SqlParameter("@DV_MA", obj.DONVI))
                        listpar.Add(New SqlParameter("@LOAI_TL", obj.LOAITL))
                        TableTangLuong = Me.b.GoiThuTucLoadDS("SP_TANGLUONG_S", listpar)
                    End If

                    listpar.Clear()
                    LocdulieuTangLuongEdit(TableTangLuong)
                    Me.btLuu.Enabled = True
                Else
                    MessageBox.Show("Bạn chưa chọn đơn vị", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Case 2 '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        End Select
    End Sub

    Private Sub tabTangLuong_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabTangLuong.SelectedTabChanged
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
                Me.btXem.Visible = True
                Me.btCapNhatVaoBangTangLuong.Visible = True
                Me.btXemDBL.Visible = False
                Me.btXemBC.Visible = False
                Me.btLuu.Visible = False
                Me.btXemHDLD.Visible = False
                Me.btCapNhatDBL.Visible = False
                Me.btCapNhatHDLD.Visible = False
                Me.btXuatExcel.Enabled = True
            Case 1
                Me.btXem.Visible = True
                Me.btCapNhatVaoBangTangLuong.Visible = False
                Me.btXemDBL.Visible = False
                Me.btXemBC.Visible = True
                Me.btLuu.Visible = True
                Me.btXemHDLD.Visible = False
                Me.btCapNhatDBL.Visible = False
                Me.btCapNhatHDLD.Visible = False
                Me.btXuatExcel.Enabled = True


                Me.cbDonVi.Text = ""
                obj.ChonBang = 1
                Me.b = New clsBTangLuongThang2
                Me.cbNamThang.DataSource = Me.b.LoadDS(obj)
                Me.cbNamThang.DisplayMember = "T_MA"

                Dim nguoidung As String = MAIN.userclient.ToLower()
                obj.NGUOIDUNG = nguoidung
                If nguoidung = "admin" Then
                    Me.radToanCty1.Checked = True
                End If
                obj.MA_DM = "1" + Me.Name
                obj.ChonBang = 13
                Me.TableND = Me.b.LoadDS(obj)
                Dim KHUA As Boolean
                Dim KHUB As Boolean
                If Me.TableND.Rows.Count > 0 Then
                    KHUA = TableND.Rows(0).Item("KHUA").ToString
                    KHUB = TableND.Rows(0).Item("KHUB").ToString
                    If KHUA = True And KHUB = False Then
                        Me.radA1.Checked = True
                        obj.ChonBang = 5
                        Me.b = New clsBTangLuongThang2
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("TCTA", "全部公司Toàn khu A")
                        Me.cbDonVi.DataSource = Me.Tabletemp
                        Me.cbDonVi.SelectedIndex = 0
                        Me.dgrBC.DataSource = Nothing
                    ElseIf KHUA = False And KHUB = True Then
                        Me.radB1.Checked = True
                        obj.ChonBang = 6
                        Me.b = New clsBTangLuongThang2
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("TCTB", "全部公司Toàn khu B")
                        Me.cbDonVi.DataSource = Me.Tabletemp
                        Me.cbDonVi.SelectedIndex = 0
                        Me.dgrBC.DataSource = Nothing
                    ElseIf KHUA = True And KHUB = True Then
                        Me.radToanCty1.Checked = True
                        obj.ChonBang = 2
                        Me.b = New clsBTangLuongThang2
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                        Me.cbDonVi.DataSource = Me.Tabletemp
                        Me.cbDonVi.SelectedIndex = 0
                        Me.dgrBC.DataSource = Nothing
                    Else
                        Me.radToanCty1.Checked = True
                        obj.ChonBang = 2
                        Me.b = New clsBTangLuongThang2
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                        Me.cbDonVi.DataSource = Me.Tabletemp
                        Me.cbDonVi.SelectedIndex = 0
                        Me.dgrBC.DataSource = Nothing
                    End If
                Else
                    Me.radToanCty1.Checked = True
                End If
                
            Case 2

                obj.ChonBang = 1
                Me.b = New clsBTangLuongThang2
                Me.cbNamThang2.DataSource = Me.b.LoadDS(obj)
                Me.cbNamThang2.DisplayMember = "T_MA"


                Me.btXem.Visible = False
                Me.btCapNhatVaoBangTangLuong.Visible = False
                Me.btXemDBL.Visible = True
                Me.btXemBC.Visible = False
                Me.btLuu.Visible = False
                Me.btXemHDLD.Visible = True
                Me.btCapNhatDBL.Visible = True
                Me.btCapNhatHDLD.Visible = True
                Me.btXuatExcel.Enabled = True
                Me.dgrBC.DataSource = Nothing


                Dim nguoidung As String = MAIN.userclient.ToLower()
                obj.NGUOIDUNG = nguoidung
                If nguoidung = "admin" Then
                    Me.radToanCty2.Checked = True
                End If
                obj.MA_DM = "1" + Me.Name
                obj.ChonBang = 13
                Me.TableND = Me.b.LoadDS(obj)
                Dim KHUA As Boolean
                Dim KHUB As Boolean
                If Me.TableND.Rows.Count > 0 Then
                    KHUA = TableND.Rows(0).Item("KHUA").ToString
                    KHUB = TableND.Rows(0).Item("KHUB").ToString
                    If KHUA = True And KHUB = False Then
                        Me.radA2.Checked = True
                    ElseIf KHUA = False And KHUB = True Then
                        Me.radB2.Checked = True
                    ElseIf KHUA = True And KHUB = True Then
                        Me.radToanCty2.Checked = True
                    Else
                        Me.radToanCty2.Checked = True
                    End If
                    Me.radToanCty2.Checked = True
                End If
                
        End Select
    End Sub

    Private Sub cbNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
                Me.dgrBC.DataSource = Nothing
                Me.btXem.Enabled = True
                Me.btCapNhatVaoBangTangLuong.Enabled = True
            Case 1
        End Select
    End Sub


    Private Sub btXuatExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXuatExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btCapNhatML_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemDBL.Activate
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
            Case 1
            Case 2
                Dim TableDBL As DataTable
                Dim listpar As New ArrayList(1)
                If Me.radA2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableDBL = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGDBL_SA", listpar)
                    listpar.Clear()
                    LocdulieuDBL(TableDBL)
                End If
                If Me.radB2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableDBL = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGDBL_SB", listpar)
                    listpar.Clear()
                    LocdulieuDBL(TableDBL)
                End If
                If Me.radToanCty2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableDBL = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGDBL_S", listpar)
                    listpar.Clear()
                    LocdulieuDBL(TableDBL)
                End If
        End Select
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
                e.Layout.Bands(0).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
                Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(0)
                On Error Resume Next
                e.Layout.Bands(0).Summaries.RemoveAt(0)
                Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed

                Me.dgrBC.Text = "Danh Sách Tăng Lương"

                e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"
                e.Layout.AddNewBox.Hidden = True
                e.Layout.AddNewBox.Prompt = "Thêm mới"
                e.Layout.Bands(0).AddButtonCaption = "Nhân viên"
                'Sort
                e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle

                'Filter
                e.Layout.Override.FilterUIType = FilterUIType.FilterRow
                e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
                e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
                e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
                e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
                e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
                e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
                e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
                e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
                'Column Chooser

                e.Layout.Override.RowSelectors = DefaultableBoolean.True
                e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
            Case 1
                e.Layout.Bands(0).Columns("1").CellAppearance.Image = 2
                e.Layout.Bands(0).Columns("1").CellActivation() = Activation.NoEdit
                'e.Layout.AutoFitColumns = True
                e.Layout.Bands(0).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
                'Sumary
                'e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True
                Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(0)
                On Error Resume Next
                e.Layout.Bands(0).Summaries.RemoveAt(0)
                Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed

                Me.dgrBC.Text = "Cập Nhật Danh Sách Tăng Lương"
                e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"
                e.Layout.AddNewBox.Hidden = False
                e.Layout.AddNewBox.Prompt = "Thêm mới"
                e.Layout.Bands(0).AddButtonCaption = "Nhân viên"
                'Sort
                e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle

                'Filter
                e.Layout.Override.FilterUIType = FilterUIType.FilterRow
                e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
                e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
                e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
                e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
                e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
                e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
                e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
                e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
                'Column Chooser

                e.Layout.Override.RowSelectors = DefaultableBoolean.True
                e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
        End Select
    End Sub
    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim TONGLUONGCU As Double
            Dim TONGLUONGMOI As Double
            Dim TONGCL As Double
        End If
    End Sub
    Private Sub dgrBC_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgrBC.MouseUp
        Select Case tabTangLuong.SelectedTab.Index

            Case 0
            Case 1
                Dim i As Integer
                For i = 0 To Me.dgrBC.Rows.Count - 1

                    Me.dgrBC.Rows(i).Update()
                Next
        End Select
    End Sub
    Private Sub dgrBC_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgrBC.AfterCellUpdate
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
            Case 1
                Dim i As Integer
                If e.Cell.Column.Index < 50 Then
                    For i = 0 To 32
                        If e.Cell.Row.Index = -1 Then Exit Sub
                        If i <> e.Cell.Column.Index Then
                            dgrBC.Rows(e.Cell.Row.Index).Cells("FLAG").Value = True
                        End If
                    Next
                End If
        End Select
    End Sub
    Private Sub Luudulieu()
        Dim obj As New objTangLuongThang2
        dgrBC.PerformAction(ExitEditMode, False, False)
        Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
        Dim i As Integer = 0
        'I. Vòng lập duyệt từng nhân viên==========================
        While (i <= num2)
            ' LAY GIA TRI CUA TUNG COT VA LUU VAO DU LIEU
            ' TINH LAI TONG LUONG VA CHENH LECH NEU CO
            Dim hoten As String
            Dim donvi As String
            Dim ngayvao As Date
            Dim bacluongcu As String
            Dim THANG As String
            Dim hesocu As String
            Dim bacluongmoi As String
            Dim hesomoi As String

            Dim DHNN As Boolean
            Dim KHCC As Boolean

            Dim TCHTNGCU As String
            Dim TCHTNGMOI As String
            Dim TCDQTVCU As String
            Dim TCDQTVMOI As String
            Dim TCPCCCCU As String
            Dim TCPCCCMOI As String

            If Me.dgrBC.Rows.Item(i).Cells.Item("NV_TEN").Value.ToString = "" Then
                hoten = ""
            Else
                hoten = Me.dgrBC.Rows.Item(i).Cells.Item("NV_TEN").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("DV_MA").Value.ToString = "" Then
                donvi = ""
            Else
                donvi = Me.dgrBC.Rows.Item(i).Cells.Item("DV_MA").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("NV_NGAYVAO").Value.ToString = "" Then
                ngayvao = ""
            Else
                ngayvao = Me.dgrBC.Rows.Item(i).Cells.Item("NV_NGAYVAO").Value
            End If
            Dim ngayvao1 As String
            ngayvao1 = ngayvao.Year.ToString() + "/" + ngayvao.Month.ToString() + "/" + ngayvao.Day.ToString()
            If Me.dgrBC.Rows.Item(i).Cells.Item("T_MA").Value.ToString = "" Then
                THANG = ""
            Else
                THANG = Me.dgrBC.Rows.Item(i).Cells.Item("T_MA").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("BACLUONGCU").Value.ToString = "" Then
                bacluongcu = ""
            Else
                bacluongcu = Me.dgrBC.Rows.Item(i).Cells.Item("BACLUONGCU").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("HESOCU").Value.ToString = "" Then
                hesocu = ""
            Else
                hesocu = Me.dgrBC.Rows.Item(i).Cells.Item("HESOCU").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("BACLUONGMOI").Value.ToString = "" Then
                bacluongmoi = ""
            Else
                bacluongmoi = Me.dgrBC.Rows.Item(i).Cells.Item("BACLUONGMOI").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("HESOMOI").Value.ToString = "" Then
                hesomoi = ""
            Else
                hesomoi = Me.dgrBC.Rows.Item(i).Cells.Item("HESOMOI").Value
            End If
            Dim MA As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value.ToString = "" Then
                MA = ""
            Else
                MA = Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value
            End If
            Dim LUONGCBMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("LUONGCBMOI").Value.ToString() = "" Then
                LUONGCBMOI = ""
            Else
                LUONGCBMOI = Me.dgrBC.Rows.Item(i).Cells.Item("LUONGCBMOI").Value
            End If

            Dim TCCMMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCCMMOI").Value.ToString() = "" Then
                TCCMMOI = ""
            Else
                TCCMMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCCMMOI").Value
            End If
            Dim TCCVMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCCVMOI").Value.ToString() = "" Then
                TCCVMOI = ""
            Else
                TCCVMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCCVMOI").Value
            End If
            Dim TCNNMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCNNMOI").Value.ToString() = "" Then
                TCNNMOI = ""
            Else
                TCNNMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCNNMOI").Value
            End If

            Dim TCUDMAYMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCUDMAYMOI").Value.ToString() = "" Then
                TCUDMAYMOI = ""
            Else
                TCUDMAYMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCUDMAYMOI").Value
            End If

            Dim TCQAQIPMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCQAQIPMOI").Value.ToString() = "" Then
                TCQAQIPMOI = ""
            Else
                TCQAQIPMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCQAQIPMOI").Value
            End If
            Dim TCTHORAPMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCTHORAPMOI").Value.ToString() = "" Then
                TCTHORAPMOI = ""
            Else
                TCTHORAPMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCTHORAPMOI").Value
            End If
            Dim TCHSEMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCHSEMOI").Value.ToString() = "" Then
                TCHSEMOI = ""
            Else
                TCHSEMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCHSEMOI").Value
            End If
            Dim TCCBVPMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCCBVPMOI").Value.ToString() = "" Then
                TCCBVPMOI = ""
            Else
                TCCBVPMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCCBVPMOI").Value
            End If

            Dim TCCBTSMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCCBTSMOI").Value.ToString() = "" Then
                TCCBTSMOI = ""
            Else
                TCCBTSMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCCBTSMOI").Value
            End If
            Dim TCKHACMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCKHACMOI").Value.ToString() = "" Then
                TCKHACMOI = ""
            Else
                TCKHACMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCKHACMOI").Value
            End If
            Dim TCHMPTMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCHMPTMOI").Value.ToString() = "" Then
                TCHMPTMOI = ""
            Else
                TCHMPTMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCHMPTMOI").Value
            End If
            Dim TCHOTRODONGPHUCMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCHOTRODONGPHUCMOI").Value.ToString() = "" Then
                TCHOTRODONGPHUCMOI = ""
            Else
                TCHOTRODONGPHUCMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCHOTRODONGPHUCMOI").Value
            End If
            Dim TCCHAMLOGIADINHMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCCHAMLOGIADINHMOI").Value.ToString() = "" Then
                TCCHAMLOGIADINHMOI = ""
            Else
                TCCHAMLOGIADINHMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCCHAMLOGIADINHMOI").Value
            End If
            Dim TCBBTHANGMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCBBTHANGMOI").Value.ToString() = "" Then
                TCBBTHANGMOI = ""
            Else
                TCBBTHANGMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCBBTHANGMOI").Value
            End If
            Dim TCBBNMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCBBNMOI").Value.ToString() = "" Then
                TCBBNMOI = ""
            Else
                TCBBNMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCBBNMOI").Value
            End If
            Dim TCMOITRUONGMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TCMOITRUONGMOI").Value.ToString() = "" Then
                TCMOITRUONGMOI = ""
            Else
                TCMOITRUONGMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCMOITRUONGMOI").Value
            End If

            Dim TONGLUONGMOI As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TONGLUONGMOI").Value.ToString() = "" Then
                TONGLUONGMOI = ""
            Else
                TONGLUONGMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TONGLUONGMOI").Value
            End If

            Dim TONGCL As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TONGCL").Value.ToString() = "" Then
                TONGCL = ""
            Else
                TONGCL = Me.dgrBC.Rows.Item(i).Cells.Item("TONGCL").Value
            End If

            Dim BANGLUONG As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("BANGLUONG").Value.ToString() = "" Then
                BANGLUONG = ""
            Else
                BANGLUONG = Me.dgrBC.Rows.Item(i).Cells.Item("BANGLUONG").Value
            End If

            Dim NGACH As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("NGACH").Value.ToString() = "" Then
                NGACH = ""
            Else
                NGACH = Me.dgrBC.Rows.Item(i).Cells.Item("NGACH").Value
            End If

            Dim TENBAC As String
            If Me.dgrBC.Rows.Item(i).Cells.Item("TENBAC").Value.ToString() = "" Then
                TENBAC = ""
            Else
                TENBAC = Me.dgrBC.Rows.Item(i).Cells.Item("TENBAC").Value
            End If

            DHNN = Me.dgrBC.Rows.Item(i).Cells.Item("DHNN").Value
            KHCC = Me.dgrBC.Rows.Item(i).Cells.Item("KHCC").Value

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCHTNGCU").Value.ToString() = "" Then
                TCHTNGCU = ""
            Else
                TCHTNGCU = Me.dgrBC.Rows.Item(i).Cells.Item("TCHTNGCU").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCHTNGMOI").Value.ToString() = "" Then
                TCHTNGMOI = ""
            Else
                TCHTNGMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCHTNGMOI").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCDQTVCU").Value.ToString() = "" Then
                TCDQTVCU = ""
            Else
                TCDQTVCU = Me.dgrBC.Rows.Item(i).Cells.Item("TCDQTVCU").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCDQTVMOI").Value.ToString() = "" Then
                TCDQTVMOI = ""
            Else
                TCDQTVMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCDQTVMOI").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCPCCCCU").Value.ToString() = "" Then
                TCPCCCCU = ""
            Else
                TCPCCCCU = Me.dgrBC.Rows.Item(i).Cells.Item("TCPCCCCU").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("TCPCCCMOI").Value.ToString() = "" Then
                TCPCCCMOI = ""
            Else
                TCPCCCMOI = Me.dgrBC.Rows.Item(i).Cells.Item("TCPCCCMOI").Value
            End If

            obj.Setnull()
            'CAP NHAT VAO BANG IT_BANGLUONGTHANG0109
            If MA = "" Then
                Exit While
            Else
                obj.NV_MA = MA
            End If
            obj.HOTEN = hoten
            obj.DONVINV = donvi
            obj.NGAYVAO = ngayvao1
            obj.THANGNAM = THANG
            obj.BACLUONGMOI = bacluongmoi
            obj.HESOMOI = hesomoi
            obj.LUONGCBMOI = LUONGCBMOI
            obj.TCCMMOI = TCCMMOI
            obj.TCCVMOI = TCCVMOI
            obj.TCNNMOI = TCNNMOI
            obj.TCUDMAYMOI = TCUDMAYMOI
            obj.TCQAQIPMOI = TCQAQIPMOI
            obj.TCTHORAPMOI = TCTHORAPMOI
            obj.TCHSEMOI = TCHSEMOI
            obj.TCCBVPMOI = TCCBVPMOI
            obj.TCCBTSMOI = TCCBTSMOI
            obj.TCKHACMOI = TCKHACMOI
            obj.TCHMPTMOI = TCHMPTMOI
            obj.TCHOTRODONGPHUCMOI = TCHOTRODONGPHUCMOI
            obj.TCCHAMLOGIADINHMOI = TCCHAMLOGIADINHMOI
            obj.TCBBTHANGMOI = TCBBTHANGMOI
            obj.TCBBNMOI = TCBBNMOI
            obj.TCMOITRUONGMOI = TCMOITRUONGMOI
            obj.TONGLUONGMOI = TONGLUONGMOI
            obj.TONGCL = TONGCL
            obj.BANGLUONG = BANGLUONG
            obj.NGACH = NGACH
            obj.TENBAC = TENBAC

            obj.DHNN = DHNN
            obj.KHCC = KHCC
            obj.TCHTNGCU = TCHTNGCU
            obj.TCHTNGMOI = TCHTNGMOI
            obj.TCDQTVCU = TCDQTVCU
            obj.TCDQTVMOI = TCDQTVMOI
            obj.TCPCCCCU = TCPCCCCU
            obj.TCPCCCMOI = TCPCCCMOI


            Dim ngaytao As String
            Dim nguoitao As String
            Dim ngaycn As String
            Dim nguoicn As String
            nguoitao = MAIN.userclient
            nguoicn = MAIN.userclient
            Dim ngaycn1 As DateTime = Now()
            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
            Dim ngaytao1 As DateTime = Now()
            ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString
            obj.NGUOITAO = nguoitao
            obj.NGAYTAO = ngaytao
            obj.NGAYCN = ngaycn
            obj.NGUOICN = nguoicn


            'obj.TONGCL = Convert.ToDouble(Convert.ToDouble(TONGLUONGMOI) - Convert.ToDouble(TONGLUONGCU))
            obj.setvalue(obj.NV_MA, obj.HOTEN, obj.DONVINV, obj.NGAYVAO, obj.THANGNAM, obj.BACLUONGMOI, obj.HESOMOI, obj.LUONGCBMOI, TCCMMOI, TCCVMOI, TCNNMOI, TCUDMAYMOI, TCQAQIPMOI, TCTHORAPMOI, TCHSEMOI, TCCBVPMOI, TCCBTSMOI, TCKHACMOI, TCHMPTMOI, TCHOTRODONGPHUCMOI, TCCHAMLOGIADINHMOI, TCBBTHANGMOI, TCBBNMOI, TCMOITRUONGMOI, TONGLUONGMOI, TONGCL, obj.BANGLUONG, obj.NGACH, obj.TENBAC, obj.DHNN, obj.KHCC, obj.TCHTNGCU, obj.TCHTNGMOI, obj.TCDQTVCU, obj.TCDQTVMOI, obj.TCPCCCCU, obj.TCPCCCMOI)
            'obj.setvalue(obj.NV_MA, obj.HOTEN, obj.DONVINV, obj.NGAYVAO, obj.THANGNAM, obj.BACLUONGCU, obj.HESOCU, obj.LUONGCBCU, obj.TCCMCU, obj.TCCVCU, obj.TCNNCU, obj.TCUDMAYCU, obj.TCQAQIPCU, obj.TCTHORAPCU, obj.TCHSECU, obj.TCCBVPCU, obj.TCCBTSCU, obj.TCKHACCU, obj.TCHMPTCU, obj.TCHOTRODONGPHUCCU, obj.TCCHAMLOGIADINHCU, obj.TCBBTHANGCU, obj.TCBBNCU, obj.TCMOITRUONGCU, obj.TONGLUONGCU, obj.BACLUONGMOI, obj.HESOMOI, obj.LUONGCBMOI, obj.TCCMMOI, obj.TCCVMOI, obj.TCNNMOI, obj.TCUDMAYMOI, obj.TCQAQIPMOI, obj.TCTHORAPMOI, obj.TCHSEMOI, obj.TCCBVPMOI, obj.TCCBTSMOI, obj.TCKHACMOI, obj.TCHMPTMOI, obj.TCHOTRODONGPHUCMOI, obj.TCCHAMLOGIADINHMOI, obj.TCBBTHANGMOI, obj.TCBBNMOI, obj.TCMOITRUONGMOI, obj.TONGLUONGMOI, obj.TONGCL, obj.BANGLUONG, obj.NGACH, obj.TENBAC)
            Dim bFLAG As Boolean = StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("FLAG").Value)
            If bFLAG = True Then
                ' KIEM TRA XEM SO THE NAY DÃ XO TRONG BANG DO  CHUA
                obj.NV_MA = MA
                obj.NAM = Me.cbNamThang.Text.Trim()
                obj.ChonBang = 17 'Ktra MaNV co trong bangIT_BANGLUONGTHANG0109 chua
                Dim Temp As New DataTable
                Me.b = New clsBTangLuongThang2
                Temp = Nothing
                Temp = Me.b.LoadDS(obj)

                If Temp.Rows.Count > 0 Then
                    'NEU CO ROI THI CAP NHAT
                    ' NEU CO CHINH SUA THI CAP NHAT VAO
                    obj.NV_MA = MA
                    obj.NAM = Me.cbNamThang.Text.Trim()
                    obj.ChonBang = 1
                    Me.b.UpdateInfo(obj)
                    '' CAP NHAT TONG LUONG CU, TONG LUONG MOI, TONG CHENH LECH
                    obj.ChonBang = 2
                    Me.b.UpdateInfo(obj)
                Else
                    'CHUA CO THI THEM MOI VAO
                    ' NEU CO CHINH SUA THI CAP NHAT VAO
                    obj.NV_MA = MA
                    obj.NAM = Me.cbNamThang.Text.Trim()
                    obj.ChonBang = 1
                    Me.b.InsertInfo(obj)
                End If
            End If
            i += 1
        End While
        Dim TableTangLuong As DataTable
        obj.NAM = Me.cbNamThang.Text
        obj.DONVI = Me.cbDonVi.Value
        Dim listpar As New ArrayList(3)
        listpar.Add(New SqlParameter("@T_MA", obj.NAM))
        listpar.Add(New SqlParameter("@DV_MA", obj.DONVI))
        If Me.chkTangThamNien.Checked = True Then
            obj.LOAITL = "TN"
        Else
            obj.LOAITL = "TT"
        End If

        listpar.Add(New SqlParameter("@LOAI_TL", obj.LOAITL))

        TableTangLuong = Me.b.GoiThuTucLoadDS("SP_TANGLUONG_S", listpar)
        listpar.Clear()
        LocdulieuTangLuongEdit(TableTangLuong)
        MessageBox.Show("Bạn đã cập nhật thành công")
    End Sub
    Private Sub btLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuu.Activate
        Select Case tabTangLuong.SelectedTab.Index

            Case 0
            Case 1
                Me.Luudulieu()
        End Select

    End Sub

    Private Sub cbDonVi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonVi.ValueChanged
        Select Case tabTangLuong.SelectedTab.Index
            Case 0
            Case 1
                Me.btXem.Enabled = True
                'Me.btXemDBL.Enabled = False
                Me.btLuu.Enabled = False
                Me.btXemBC.Enabled = True
                Me.btXuatExcel.Enabled = True
                Me.dgrBC.DataSource = Nothing
        End Select
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        'Dim obj As New objTinhLuong
                        obj.Setnull()
                        obj.ChonBang = 1
                        obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        obj.THANGNAM = Me.cbNamThang.Text
                        Me.b.DeleteInfo(obj)


                        Dim TableTangLuong As DataTable
                        obj.NAM = Me.cbNamThang.Text
                        obj.DONVI = Me.cbDonVi.Value
                        If Me.chkTangThamNien.Checked Then
                            obj.LOAITL = "TN"
                        Else
                            obj.LOAITL = "TT"
                        End If
                        Dim listpar As New ArrayList(1)
                        listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                        listpar.Add(New SqlParameter("@DV_MA", obj.DONVI))
                        listpar.Add(New SqlParameter("@LOAI_TL", obj.LOAITL))
                        TableTangLuong = Me.b.GoiThuTucLoadDS("SP_TANGLUONG_S", listpar)
                        listpar.Clear()
                        LocdulieuTangLuongEdit(TableTangLuong)
                    End If
            End Select
        End If
    End Sub
    Dim ReportID As String
    Private Sub btXemBC_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Activate
        Select Case tabTangLuong.SelectedTab.Index
            Case 0

            Case 1
                Dim report As New FrmReport
                Dim DONVI As String
                If Me.cbNamThang.Text <> "" And Me.chkTangThamNien.Checked = False Then
                    If Me.cbDonVi.Value = "TCT" Then
                        Me.ReportID = "695_" 'DieuchinhluongTCT.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    ElseIf Me.cbDonVi.Value = "TCTA" Then
                        Me.ReportID = "695A" 'DieuchinhluongTCTA.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    ElseIf Me.cbDonVi.Value = "TCTB" Then
                        Me.ReportID = "695B" 'DieuchinhluongTCTB.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    Else
                        DONVI = Me.cbDonVi.Value
                        Me.ReportID = "695" 'Dieuchinhluong.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text, DONVI}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    End If
                Else
                    If Me.cbDonVi.Value = "TCT" Then
                        Me.ReportID = "695_TN" 'DieuchinhluongTCT_TN.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text, "TN"}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    ElseIf Me.cbDonVi.Value = "TCTA" Then
                        Me.ReportID = "695ATN" 'DieuchinhluongTCTA_TN.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text, "TN"}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    ElseIf Me.cbDonVi.Value = "TCTB" Then
                        Me.ReportID = "695BTN" 'DieuchinhluongTCTB_TN.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text, "TN"}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    Else
                        DONVI = Me.cbDonVi.Value
                        Me.ReportID = "695TN" 'DieuchinhluongTN.rpt
                        report.reportID = Me.ReportID
                        Dim strArray As String() = New String() {Me.cbNamThang.Text, DONVI, "TN"}
                        report.para = strArray
                        report.issysReport = True
                        report.Show()
                    End If
                End If

        End Select
    End Sub

    Private Sub dgrBC_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgrBC.CellChange
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim LUONGCBCU As Double
            Dim TCCMCU As Double
            Dim TCCVCU As Double
            Dim TCNNCU As Double
            Dim TCUDMAYCU As Double
            Dim TCQAQIPCU As Double
            Dim TCTHORAPCU As Double
            Dim TCHSECU As Double
            Dim TCCBVPCU As Double
            Dim TCCBTSCU As Double
            Dim TCKHACCU As Double
            Dim TCHMPTCU As Double
            Dim TCHOTRODONGPHUCCU As Double
            Dim TCCHAMLOGIADINHCU As Double
            Dim TCBBTHANGCU As Double
            Dim TCBBNCU As Double
            Dim TCMOITRUONGCU As Double
            Dim TONGLUONGCU As Double

            Dim LUONGCBMOI As Double
            Dim TCCMMOI As Double
            Dim TCCVMOI As Double
            Dim TCNNMOI As Double
            Dim TCUDMAYMOI As Double
            Dim TCQAQIPMOI As Double
            Dim TCTHORAPMOI As Double
            Dim TCHSEMOI As Double
            Dim TCCBVPMOI As Double
            Dim TCCBTSMOI As Double
            Dim TCKHACMOI As Double
            Dim TCHMPTMOI As Double
            Dim TCHOTRODONGPHUCMOI As Double
            Dim TCCHAMLOGIADINHMOI As Double
            Dim TCBBTHANGMOI As Double
            Dim TCBBNMOI As Double
            Dim TCMOITRUONGMOI As Double
            Dim TONGLUONGMOI As Double
            Dim TONGCL As Double

            Select Case ColA
                Case "NV_Ma"
                    If e.Cell.Row.Index = -1 Then Exit Sub
                    ' TRANG THAI KHI NHAP VAO SO THE TREN LUOI
                    Dim ma As String = dgrBC.Rows(e.Cell.Row.Index).Cells("NV_MA").Text
                    'DUYET LUOI CUA DON VI NAY NEU DA CO SO THE NAY ROI THI THONG BAO LEN CON KHONG THI THOI
                    Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
                    Dim i As Integer = 0
                    'I. Vòng lập duyệt từng nhân viên==========================
                    While (i < num2)
                        Dim MALUOI As String = Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Text
                        If MALUOI.Length = 5 And ma.Length = 5 Then
                            If ma = MALUOI Then
                                MessageBox.Show("Số thẻ " & MALUOI & " này đã có trong danh sách tăng lương")
                                Exit Sub
                            Else

                            End If
                        End If
                        i += 1
                    End While

                    If ma.Length = 5 Then
                        'LAY THONG TIN NHAN VIEN LEN
                        obj.NV_MA = ma
                        obj.NAM = Me.cbNamThang.Text
                        obj.DONVI = Me.cbDonVi.Value
                        obj.ChonBang = 19
                        Me.Tabletemp = Me.b.LoadDS(obj)
                        If Tabletemp.Rows.Count > 0 Then
                            Dim TEN As String
                            Dim NGAYVAO As Date = Me.Tabletemp.Rows(0).Item("NV_NGAYVAO").ToString()
                            Dim NGAY As String = NGAYVAO.Day.ToString() + "/" + NGAYVAO.Month.ToString() + "/" + NGAYVAO.Year.ToString()
                            Dim DONVI As String
                            Dim THANG As String
                            TEN = Me.Tabletemp.Rows(0).Item("NV_TEN").ToString()
                            DONVI = Me.Tabletemp.Rows(0).Item("DV_MA").ToString()
                            THANG = Me.Tabletemp.Rows(0).Item("T_MA").ToString()

                            dgrBC.Rows(e.Cell.Row.Index).Cells("NV_TEN").Value = TEN
                            dgrBC.Rows(e.Cell.Row.Index).Cells("DV_MA").Value = DONVI
                            dgrBC.Rows(e.Cell.Row.Index).Cells("NV_NGAYVAO").Value = NGAY
                            dgrBC.Rows(e.Cell.Row.Index).Cells("T_MA").Value = THANG
                        Else
                            MessageBox.Show("Không có nhân viên " & ma & " trong đơn vị này")
                        End If
                    End If

                Case "BACLUONGMOI"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' TRANG THAI KHI NHAP VAO BAC LUONG moi HIEN THI HE SO, MUC LUONG, PHU CAP
                    If e.Cell.Row.Index = -1 Then Exit Sub
                    Dim BLMOI As String = dgrBC.Rows(e.Cell.Row.Index).Cells("BACLUONGMOI").Text
                    If BLMOI = "" Then
                        Exit Sub
                    Else
                        If BLMOI.Length = 5 Or BLMOI.Length = 6 Then
                            obj.ChonBang = 21
                            obj.BACLUONGMOI = BLMOI
                            Tabletemp = Nothing
                            Me.Tabletemp = Me.b.LoadDS(obj)
                            If Tabletemp.Rows.Count > 0 Then
                                Dim HESOM As String
                                Dim MUCLUONGM As String
                                Dim PCM As String
                                Dim BANGLUONG As String
                                Dim NGACH As String
                                Dim BAC As String
                                HESOM = Me.Tabletemp.Rows(0).Item("B_HSLUONG").ToString()
                                LUONGCBMOI = Me.Tabletemp.Rows(0).Item("B_MUCLUONG").ToString()
                                TCCMMOI = Me.Tabletemp.Rows(0).Item("B_PCCM").ToString()

                                dgrBC.Rows(e.Cell.Row.Index).Cells("HESOMOI").Value = HESOM
                                dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value = LUONGCBMOI
                                dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value = TCCMMOI

                                TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                                TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                                TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                                TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                                TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                                TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                                TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                                TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                                TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                                TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                                TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                                TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                                TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                                TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                                TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                                TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                                dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                                TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                                dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                                
                            Else
                                MessageBox.Show("Không có bậc lương " & BLMOI & " này trong dữ liệu")
                            End If
                        End If
                    End If
                Case "TCCMMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Text
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value = 0
                        End If
                    End If
                Case "TCCVMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Text
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value = 0
                        End If
                    End If
                Case "TCNNMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Text
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value = 0
                        End If
                    End If
                Case "TCUDMAYMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Text
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value = 0
                        End If
                    End If
                Case "TCQAQIPMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Text
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value = 0
                        End If
                    End If
                Case "TCTHORAPMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Text
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value = 0
                        End If
                    End If
                Case "TCHSEMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Text
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value = 0
                        End If
                    End If
                Case "TCCBVPMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Text
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value = 0
                        End If
                    End If
                Case "TCCBTSMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Text
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value = 0
                        End If
                    End If
                Case "TCKHACMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Text
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value = 0
                        End If
                    End If
                Case "TCHMPTMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Text
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value = 0
                        End If
                    End If
                Case "TCHOTRODONGPHUCMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Text
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value = 0
                        End If
                    End If
                Case "TCCHAMLOGIADINHMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Text
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value = 0
                        End If
                    End If
                Case "TCBBTHANGMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Text
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value = 0
                        End If
                    End If
                Case "TCBBNMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Text
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value = 0
                        End If
                    End If
                Case "TCMOITRUONGMOI"
                    If dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Text <> "" Then
                        If IsNumber(dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Text) = True Then
                            LUONGCBMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("LUONGCBMOI").Value
                            TCCMMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCMMOI").Value
                            TCCVMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCVMOI").Value
                            TCNNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCNNMOI").Value
                            TCUDMAYMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCUDMAYMOI").Value
                            TCQAQIPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCQAQIPMOI").Value
                            TCTHORAPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCTHORAPMOI").Value
                            TCHSEMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHSEMOI").Value
                            TCCBVPMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBVPMOI").Value
                            TCCBTSMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCBTSMOI").Value
                            TCKHACMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCKHACMOI").Value
                            TCHMPTMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHMPTMOI").Value
                            TCHOTRODONGPHUCMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCHOTRODONGPHUCMOI").Value
                            TCCHAMLOGIADINHMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCCHAMLOGIADINHMOI").Value
                            TCBBTHANGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBTHANGMOI").Value
                            TCBBNMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCBBNMOI").Value
                            TCMOITRUONGMOI = dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Text
                            TONGLUONGMOI = Convert.ToDouble(Convert.ToDouble(LUONGCBMOI) + Convert.ToDouble(TCCMMOI) + Convert.ToDouble(TCCVMOI) + Convert.ToDouble(TCNNMOI) + Convert.ToDouble(TCUDMAYMOI) + Convert.ToDouble(TCQAQIPMOI) + Convert.ToDouble(TCTHORAPMOI) + Convert.ToDouble(TCHSEMOI) + Convert.ToDouble(TCCBVPMOI) + Convert.ToDouble(TCCBTSMOI) + Convert.ToDouble(TCKHACMOI) + Convert.ToDouble(TCHMPTMOI) + Convert.ToDouble(TCHOTRODONGPHUCMOI) + Convert.ToDouble(TCCHAMLOGIADINHMOI) + Convert.ToDouble(TCBBTHANGMOI) + Convert.ToDouble(TCBBNMOI) + Convert.ToDouble(TCMOITRUONGMOI))
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGMOI").Value = TONGLUONGMOI
                            TONGCL = TONGLUONGMOI - Convert.ToDouble(dgrBC.Rows(e.Cell.Row.Index).Cells("TONGLUONGCU").Value)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TONGCL").Value = TONGCL
                        Else
                            MessageBox.Show("Bạn chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgrBC.Rows(e.Cell.Row.Index).Cells("TCMOITRUONGMOI").Value = 0
                        End If
                    End If
            End Select
        End If
    End Sub
    Public Function IsNumber(ByVal chuoi As String) As Boolean
        Dim flag As Boolean = False
        Dim i As Integer = 0
        While i <= chuoi.Length - 1
            If Char.IsDigit(chuoi(i)) = True Then
                flag = True
            Else
                flag = False
                GoTo Lap
            End If
            i = i + 1
        End While
Lap:    If flag = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btCapNhatVaoBangTangLuong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatVaoBangTangLuong.Activate
        Dim listpar As New ArrayList(1)
        If Me.radA.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu khu A vào bảng tăng lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                obj.NGAY = Me.dtpNgay.Value
                listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                Me.b.GoiThuTuc("SP_DANHSACHTANGLUONG_IA", listpar)
                listpar.Clear()
                MessageBox.Show("Cập nhật thành công")
            End If
        End If
        If Me.radB.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu khu B vào bảng tăng lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                obj.NGAY = Me.dtpNgay.Value
                listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                Me.b.GoiThuTuc("SP_DANHSACHTANGLUONG_IB", listpar)
                listpar.Clear()
                MessageBox.Show("Cập nhật thành công")
            End If
        End If
        If Me.radToanCty.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu toàn công ty vào bảng tăng lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                obj.NGAY = Me.dtpNgay.Value
                listpar.Add(New SqlParameter("@Ngay", obj.NGAY))
                Me.b.GoiThuTuc("SP_DANHSACHTANGLUONG_I", listpar)
                listpar.Clear()
                MessageBox.Show("Cập nhật thành công")
            End If
        End If
       
    End Sub

    Private Sub btXemHDLD_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemHDLD.Activate
        Select Case tabTangLuong.SelectedTab.Index
            Case 0

            Case 1
            Case 2
                Dim TableHDLD As DataTable
                Dim listpar As New ArrayList(1)
                If Me.radA2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableHDLD = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGHDLD_SA", listpar)
                    listpar.Clear()
                    LocdulieuHDLD(TableHDLD)
                End If
                If Me.radB2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableHDLD = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGHDLD_SB", listpar)
                    listpar.Clear()
                    LocdulieuHDLD(TableHDLD)
                End If
                If Me.radToanCty2.Checked = True Then
                    obj.THANGNAM = Me.cbNamThang2.Text
                    listpar.Add(New SqlParameter("@T_MA", obj.THANGNAM))
                    TableHDLD = Me.b.GoiThuTucLoadDS("SP_DANHSACHTANGLUONGHDLD_S", listpar)
                    listpar.Clear()
                    LocdulieuHDLD(TableHDLD)
                End If

        End Select
    End Sub

    Private Sub btCapNhatHDLD_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatHDLD.Activate

        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString
        obj.NGUOITAO = nguoitao
        obj.NGAYTAO = ngaytao
        obj.NGAYCN = ngaycn
        obj.NGUOICN = nguoicn
        If Me.radA2.Checked = True Then
            If MessageBox.Show("Bạn có muốn cập nhật dữ liệu khu A vào hợp đồng lao động không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra để lưu lại dữ liệu vào bảng tạm
                obj.NAM = Me.cbNamThang2.Text
                Dim listpar As New ArrayList(1)
                listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                Me.b.GoiThuTuc("SP_HDLDLOG_IA", listpar)
                listpar.Clear()

                Dim TABLEKT As DataTable
                obj.ChonBang = 7
                Me.b = New clsBTangLuongThang2
                TABLEKT = Me.b.LoadDS(obj)
                If TABLEKT.Rows.Count > 0 Then
                    obj.NAM = Me.cbNamThang2.Text
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_CAPNHATHDLD_UA", listpar1)
                    listpar1.Clear()

                End If
                MessageBox.Show("Cập nhật thành công")

            End If
        End If
        If Me.radB2.Checked = True Then
            If MessageBox.Show("Bạn có muốn cập nhật dữ liệu khu B vào hợp đồng lao động không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra để lưu lại dữ liệu vào bảng tạm
                obj.NAM = Me.cbNamThang2.Text
                Dim listpar As New ArrayList(1)
                listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                Me.b.GoiThuTuc("SP_HDLDLOG_IB", listpar)
                listpar.Clear()

                Dim TABLEKT As DataTable
                obj.ChonBang = 8
                Me.b = New clsBTangLuongThang2
                TABLEKT = Me.b.LoadDS(obj)
                If TABLEKT.Rows.Count > 0 Then
                    obj.NAM = Me.cbNamThang2.Text
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_CAPNHATHDLD_UB", listpar1)
                    listpar1.Clear()

                End If
                MessageBox.Show("Cập nhật thành công")
            End If
        End If
        If Me.radToanCty2.Checked = True Then
            If MessageBox.Show("Bạn có muốn cập nhật dữ liệu toàn bộ vào hợp đồng lao động không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra để lưu lại dữ liệu vào bảng tạm
                obj.NAM = Me.cbNamThang2.Text
                Dim listpar As New ArrayList(1)
                listpar.Add(New SqlParameter("@T_MA", obj.NAM))
                Me.b.GoiThuTuc("SP_HDLDLOG_I", listpar)
                listpar.Clear()

                Dim TABLEKT As DataTable
                obj.ChonBang = 3
                Me.b = New clsBTangLuongThang2
                TABLEKT = Me.b.LoadDS(obj)
                If TABLEKT.Rows.Count > 0 Then
                    obj.NAM = Me.cbNamThang2.Text
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_CAPNHATHDLD_U", listpar1)
                    listpar1.Clear()

                End If
                MessageBox.Show("Cập nhật thành công")

            End If
        End If
    
    End Sub

    Private Sub btCapNhatDBL_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatDBL.Activate
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString
        obj.NGUOITAO = nguoitao
        obj.NGAYTAO = ngaytao
        obj.NGAYCN = ngaycn
        obj.NGUOICN = nguoicn
        If Me.radA2.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu khu A vào bảng diễn biến lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra xem dbl đó có chua
                obj.NAM = Me.cbNamThang2.Text
                Dim TABLEKTDBL As DataTable
                obj.ChonBang = 9
                Me.b = New clsBTangLuongThang2
                TABLEKTDBL = Me.b.LoadDS(obj)
                If TABLEKTDBL Is Nothing Or TABLEKTDBL.Rows.Count = 0 Then
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_INSERTDBL_IA", listpar1)
                    listpar1.Clear()
                    MessageBox.Show("Cập nhật thành công")
                Else
                    MessageBox.Show("Dữ liệu đã có")
                    Exit Sub
                End If

            End If
        End If
        If Me.radB2.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu khu B vào bảng diễn biến lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra xem dbl đó có chua
                obj.NAM = Me.cbNamThang2.Text
                Dim TABLEKTDBL As DataTable
                obj.ChonBang = 10
                Me.b = New clsBTangLuongThang2
                TABLEKTDBL = Me.b.LoadDS(obj)
                If TABLEKTDBL Is Nothing Or TABLEKTDBL.Rows.Count = 0 Then
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_INSERTDBL_IB", listpar1)
                    listpar1.Clear()
                    MessageBox.Show("Cập nhật thành công")
                Else
                    MessageBox.Show("Dữ liệu đã có")
                    Exit Sub
                End If
            End If
        End If
        If Me.radToanCty2.Checked = True Then
            If MessageBox.Show("Bạn có muốn chuyển dữ liệu toàn bộ vào bảng diễn biến lương không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                ' kiểm tra xem dbl đó có chua
                obj.NAM = Me.cbNamThang2.Text
                Dim TABLEKTDBL As DataTable
                obj.ChonBang = 4
                Me.b = New clsBTangLuongThang2
                TABLEKTDBL = Me.b.LoadDS(obj)
                If TABLEKTDBL Is Nothing Or TABLEKTDBL.Rows.Count = 0 Then
                    Dim listpar1 As New ArrayList(1)
                    listpar1.Add(New SqlParameter("@T_MA", obj.NAM))
                    listpar1.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
                    listpar1.Add(New SqlParameter("@NGAYTAO", obj.NGAYTAO))
                    Me.b.GoiThuTuc("SP_INSERTDBL_I", listpar1)
                    listpar1.Clear()
                    MessageBox.Show("Cập nhật thành công")
                Else
                    MessageBox.Show("Dữ liệu đã có")
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Dim TableDanhSachTangLuong As DataTable
    Private Sub radA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radA.CheckedChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub radB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radB.CheckedChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub radToanCty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radToanCty.CheckedChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub radA1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radA1.CheckedChanged
        obj.ChonBang = 5
        Me.b = New clsBTangLuongThang2
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCTA", "全部公司Toàn khu A")
        Me.cbDonVi.DataSource = Me.Tabletemp
        Me.cbDonVi.SelectedIndex = 0
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub radB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radB1.CheckedChanged
        obj.ChonBang = 6
        Me.b = New clsBTangLuongThang2
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCTB", "全部公司Toàn khu B")
        Me.cbDonVi.DataSource = Me.Tabletemp
        Me.cbDonVi.SelectedIndex = 0
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub radToanCty1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radToanCty1.CheckedChanged
        obj.ChonBang = 2
        Me.b = New clsBTangLuongThang2
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonVi.DataSource = Me.Tabletemp
        Me.cbDonVi.SelectedIndex = 0
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As TD.SandBar.ToolBarItemEventArgs) Handles ToolBar1.ButtonClick

    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged

    End Sub

    Private Sub cbNamThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNamThang.SelectedIndexChanged

    End Sub
End Class