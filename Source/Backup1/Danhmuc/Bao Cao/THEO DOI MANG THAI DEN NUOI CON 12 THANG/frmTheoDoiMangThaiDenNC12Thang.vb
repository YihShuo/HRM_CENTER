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
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Diagnostics
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports ADODB
Imports System.Data.SqlClient.SqlBulkCopy
'Imports microsoft.office.Interop.excel
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Public Class frmTheoDoiMangThaiDenNC12Thang
    Public obj As New ObjTheoDoiMangThaiDenNC12Thang
    Dim Table, Path As String
    Friend WithEvents d As New clsDTheoDoiMangThaiDenNC12Thang   ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public tbl_DulieuK_Hle As New DataTable
    Dim i As Integer
    Public sChuoi As String = ""
    Private Sub Tinh_KhamThai()
        i = 0
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            listpar1.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGAYKTHAI_KMAX", listpar) ''tinh cho lan mang thai max
            'Me.b.GoiThuTuc("SP_TINHSOLANTS", listpar1)   '' TINH SO LAN THAI SAN
            listpar.Clear()
            listpar1.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub LayDS()
        i = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGAYDS_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_SayThai()
        i = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            'obj.Ngaymangthai = Me.dgrBC.Rows(i).Cells("BDAU_MANGTHAI").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_SoLanMT()
        i = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_TINHSOLANMT", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_SoLanTS()
        i = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_TINHSOLANTS", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Public Sub LoadDSMangThai_BanDau(ByVal sXuong As String, ByVal bNamBd As Boolean, ByVal bNamKt As Boolean, ByVal sNambd As String, ByVal sNamkt As String)
        Dim tblQTMT As DataTable
        Dim sNV_Ma As String
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Dim listpar As New ArrayList(3)
        i = 0

        If bNamBd Then
            If bNamKt Then
                sNamkt = sNamkt
            Else
                sNamkt = sNambd
            End If
        Else
            sNambd = ""
            sNamkt = ""
        End If
        listpar.Add(New SqlParameter("@XUONG", sXuong))
        listpar.Add(New SqlParameter("@NAMBD", sNambd))
        listpar.Add(New SqlParameter("@NAMKT", sNamkt))
        tblQTMT = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_ALL_CAPNHATCHITRA", listpar)
        listpar.Clear()
        '========== duyet table tinh say thai, kham thai , duong suc =========''
        Me.dgrBC.DataSource = tblQTMT
        Tinh_SoLanMT()
        Tinh_SoLanTS()
        Tinh_SayThai()
        Tinh_KhamThai()
        LayDS()
    End Sub
    Public Sub LoadDSMangThaiTheoXuong()
        Dim grid As New clsTformatGrid
        Dim Table As New DataTable
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@XUONG", Me.cbXuong.Value.ToString()))
        Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_XUONG", listpar)
        Me.dgrBC.DataSource = Table
        sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên " & CDate(Me.dtpNam.Value).Year.ToString()
        Select Case Me.cbXuong.Value.ToString().ToUpper()
            Case "KHUA"
                Me.XpCaption2.Text = sChuoi & " khu A"
            Case "KHUB"
                Me.XpCaption2.Text = sChuoi & " khu B"
            Case "KHUDVC"
                Me.XpCaption2.Text = sChuoi & " khu DVC"
            Case Else
                Me.XpCaption2.Text = sChuoi & " xưởng " & Me.cbXuong.Value.ToString()
        End Select
    End Sub
    Public Sub LoadDSMangThaiTheoNam()
        Dim grid As New clsTformatGrid
        Dim Table As New DataTable
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Dim listpar As New ArrayList(3)
        listpar.Add(New SqlParameter("@TUNAM", CDate(Me.dtpNam.Value).Year))
        If Me.chkDenNam.Checked And Me.dtpDenNam.Text.ToString() <> "" Then
            listpar.Add(New SqlParameter("@DENNAM", CDate(Me.dtpDenNam.Value).Year))
            sChuoi = " đến năm "
        Else
            listpar.Add(New SqlParameter("@DENNAM", CDate(Me.dtpNam.Value).Year))
        End If

        'If radKhuA.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_KHUA", listpar)
        'End If
        'If radKhuB.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_KHUB", listpar)
        'End If
        'If radKhuDVC.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_KHUDVC", listpar)
        'End If
        'If radTCT.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM", listpar)
        'End If
        Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM", listpar)
        Me.dgrBC.DataSource = Table
        Dim dgrBC As Object = Me.dgrBC

        If sChuoi <> "" Then
            sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên năm " & CDate(Me.dtpNam.Value).Year.ToString() & sChuoi
        Else
            sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên năm " & CDate(Me.dtpNam.Value).Year.ToString()
        End If
        Select Case Me.cbXuong.Value.ToString().ToUpper()
            Case "KHUA"
                Me.XpCaption2.Text = sChuoi & " khu A"
            Case "KHUB"
                Me.XpCaption2.Text = sChuoi & " khu B"
            Case "KHUDVC"
                Me.XpCaption2.Text = sChuoi & " khu DVC"
            Case Else
                Me.XpCaption2.Text = sChuoi & " xưởng " & Me.cbXuong.Value.ToString()
        End Select
    End Sub
    Public Sub LoadDSMangThaiST_All()
        Dim grid As New clsTformatGrid
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        'Me.Path = "/layout/QuatrinhmangthaidennuoiconST.xml"
        Me.dgrBC.DataSource = Me.d.GoiThuTuc_Loaddulieu("SP_QTMANGTHAINUOICON_ALL_ST")
        Dim dgrBC As Object = Me.dgrBC
        'grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Select Case Me.cbXuong.Value.ToString().ToUpper()
            Case "KHUA"
                Me.XpCaption2.Text = sChuoi & " khu A"
            Case "KHUB"
                Me.XpCaption2.Text = sChuoi & " khu B"
            Case "KHUDVC"
                Me.XpCaption2.Text = sChuoi & " khu DVC"
            Case Else
                Me.XpCaption2.Text = sChuoi & " xưởng " & Me.cbXuong.Value.ToString()
        End Select
    End Sub
    Public Sub LoadDSMangThaiST_Xuong()
        Dim grid As New clsTformatGrid
        Dim Table As New DataTable
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        'Me.Path = "/layout/QuatrinhmangthaidennuoiconST.xml"
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@XUONG", Me.cbXuong.Value.ToString()))
        Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_ALL_ST_XUONG", listpar)
        Me.dgrBC.DataSource = Table
        Dim dgrBC As Object = Me.dgrBC
        sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên (toàn bộ sảy thai)"
        Select Case Me.cbXuong.Value.ToString().ToUpper()
            Case "KHUA"
                Me.XpCaption2.Text = sChuoi & " khu A"
            Case "KHUB"
                Me.XpCaption2.Text = sChuoi & " khu B"
            Case "KHUDVC"
                Me.XpCaption2.Text = sChuoi & " khu DVC"
            Case Else
                Me.XpCaption2.Text = sChuoi & " xưởng " & Me.cbXuong.Value.ToString()
        End Select
        'grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub
    Public Sub LoadDSMangThaiTheoNamXuong()
        Dim grid As New clsTformatGrid
        Dim Table As New DataTable
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Me.Path = "/layout/Quatrinhmangthaidennuoicon.xml"

        Dim listpar As New ArrayList(3)
        listpar.Clear()
        listpar.Add(New SqlParameter("@TUNAM", CDate(Me.dtpNam.Value).Year))
        If Me.chkDenNam.Checked And Me.dtpDenNam.Text.ToString() <> "" Then
            sChuoi = " đến năm " & Me.dtpDenNam.Text.ToString()
            listpar.Add(New SqlParameter("@DENNAM", CDate(Me.dtpDenNam.Value).Year))
        Else
            listpar.Add(New SqlParameter("@DENNAM", CDate(Me.dtpNam.Value).Year))
        End If

        'listpar.Add(New SqlParameter("@XUONG", Me.cbXuong.Value.ToString()))
        'If radKhuA.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG_KHUA", listpar)
        'End If
        'If radKhuB.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG_KHUB", listpar)
        'End If
        'If radKhuDVC.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG_KHUDVC", listpar)
        'End If
        'If radTCT.Checked Then
        '    Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG", listpar)
        'End If

        'Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG", listpar)

        listpar.Add(New SqlParameter("@XUONG", Me.cbXuong.Value.ToString()))
        Table = Me.b.GoiThuTucLoadDS("SP_QTMANGTHAINUOICON_TUNAMDENNAM_XUONG", listpar)

        Me.dgrBC.DataSource = Table
        If sChuoi <> "" Then
            sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên năm " & CDate(Me.dtpNam.Value).Year.ToString() & sChuoi
        Else
            sChuoi = "Chu kỳ thai sản của cán bộ công nhân viên năm " & CDate(Me.dtpNam.Value).Year.ToString()
        End If
        Select Case Me.cbXuong.Value.ToString().ToUpper()
            Case "KHUA"
                Me.XpCaption2.Text = sChuoi & " khu A"
            Case "KHUB"
                Me.XpCaption2.Text = sChuoi & " khu B"
            Case "KHUDVC"
                Me.XpCaption2.Text = sChuoi & " khu DVC"
            Case Else
                Me.XpCaption2.Text = sChuoi & " xưởng " & Me.cbXuong.Value.ToString()
        End Select
    End Sub
    Private Sub LoadGridView_QTMT()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

                Next

                .Columns("TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("CONGVIEC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DONVI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("CHUCVU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("LOAICV").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left


                .Columns("STT").Header.Caption = "STT"
                .Columns("MA").Header.Caption = "Số Thẻ"
                .Columns("TEN").Header.Caption = "Họ tên"

                .Columns("CONGVIEC").Header.Caption = "Công việc"
                .Columns("DONVI").Header.Caption = "Đơn vị"
                .Columns("CHUCVU").Header.Caption = "Chức vụ"

                .Columns("NGAYVAO").Header.Caption = "Ngày vào"
                .Columns("BDAU_MANGTHAI").Header.Caption = "Ngày mang thai"
                .Columns("LAN1").Header.Caption = "KThai lần 1"
                .Columns("LAN2").Header.Caption = "KThai lần 2"
                .Columns("LAN3").Header.Caption = "KThai lần 3"
                .Columns("LAN4").Header.Caption = "KThai lần 4"
                .Columns("LAN5").Header.Caption = "KThai lần 5"

                .Columns("SLCHITRA").Header.Caption = "Số lần chi trả"
                .Columns("VE_15H30").Header.Caption = "Về 15h30"
                .Columns("DUSINH").Header.Caption = "Dự sinh"

                .Columns("BDTHAIT7").Header.Caption = "Bắt đầu thai tháng thứ 7"
                .Columns("KTTHAIT7").Header.Caption = "Kết thúc thai tháng thứ 7"
                .Columns("SONGAYT7").Header.Caption = "Số ngày mang thai tháng thứ 7"

                .Columns("BDTS").Header.Caption = "Bắt đầu nghỉ TS"
                .Columns("KTTS").Header.Caption = "Kết thúc nghỉ TS"
                .Columns("SONGAYTS").Header.Caption = "Số ngày nghỉ TS"

                .Columns("NGAYSANH").Header.Caption = "Ngày sanh"
                .Columns("BDNC").Header.Caption = "Bắt đầu nuôi con"
                .Columns("KTNC").Header.Caption = "Kết thúc nuôi con"
                .Columns("SONGAYNC").Header.Caption = "Số ngày nuôi con"
                .Columns("LOAICV").Header.Caption = "Loại công việc"

                .Columns("CTLAN1").Header.Caption = "Chi trả lần 1"
                .Columns("CTLAN2").Header.Caption = "Chi trả lần 2"
                .Columns("CTLAN3").Header.Caption = "Chi trả lần 3"
                .Columns("CTLAN4").Header.Caption = "Chi trả lần 4"
                .Columns("CTLAN5").Header.Caption = "Chi trả lần 5"

                .Columns("BD_DUONGSUC").Header.Caption = "BĐ dưỡng sức"
                .Columns("KT_DUONGSUC").Header.Caption = "KT dưỡng sức"
                .Columns("SNDS").Header.Caption = "Số ngày dưỡng sức"

                .Columns("MA").Width = 100
                .Columns("TEN").Width = 180
                .Columns("CONGVIEC").Width = 100
                .Columns("DONVI").Width = 100
                .Columns("CHUCVU").Width = 180


                .Columns("NGAYVAO").Width = 100
                .Columns("BDAU_MANGTHAI").Width = 100
                .Columns("LAN1").Width = 100
                .Columns("LAN2").Width = 100
                .Columns("LAN3").Width = 100
                .Columns("LAN4").Width = 100
                .Columns("LAN5").Width = 100

                .Columns("SLCHITRA").Width = 100
                .Columns("VE_15H30").Width = 100
                .Columns("DUSINH").Width = 100

                .Columns("BDTHAIT7").Width = 150
                .Columns("KTTHAIT7").Width = 150
                .Columns("SONGAYT7").Width = 100

                .Columns("BDTS").Width = 150
                .Columns("KTTS").Width = 150
                .Columns("SONGAYTS").Width = 100

                .Columns("NGAYSANH").Width = 100
                .Columns("BDNC").Width = 100
                .Columns("KTNC").Width = 100
                .Columns("SONGAYNC").Width = 100
                .Columns("LOAICV").Width = 100

                .Columns("CTLAN1").Width = 100
                .Columns("CTLAN2").Width = 100
                .Columns("CTLAN3").Width = 100
                .Columns("CTLAN4").Width = 100
                .Columns("CTLAN5").Width = 100

                .Columns("BD_DUONGSUC").Width = 100
                .Columns("KT_DUONGSUC").Width = 100
                .Columns("SNDS").Width = 100

                If Me.chkST.Checked Then
                    .Columns("CTLAN1").Header.Caption = "Chi trả lần 1"
                    .Columns("CTLAN2").Header.Caption = "Chi trả lần 2"
                    .Columns("CTLAN3").Header.Caption = "Chi trả lần 3"

                    .Columns("BD_DUONGSUC").Width = 100
                    .Columns("KT_DUONGSUC").Width = 100
                    .Columns("SNDS").Width = 100
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


                'Column Chooser
                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
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
    Public Sub LoadTrangThaiChiTraKhamThai()
        Dim grid As New clsTformatGrid
        Dim i As Integer = 0
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        If Me.dgrBC.DataSource Is Nothing Then
            Exit Sub
        Else
            While i <= Me.dgrBC.Rows.Count - 1
                If Convert.ToBoolean(Me.dgrBC.Rows(i).Cells("CTLAN1").Value) = True Then
                    Me.dgrBC.Rows(i).Cells("LAN1").Appearance.BackColor = Color.Red
                End If
                If Convert.ToBoolean(Me.dgrBC.Rows(i).Cells("CTLAN2").Value) = True Then
                    Me.dgrBC.Rows(i).Cells("LAN2").Appearance.BackColor = Color.Red
                End If
                If Convert.ToBoolean(Me.dgrBC.Rows(i).Cells("CTLAN3").Value) = True Then
                    Me.dgrBC.Rows(i).Cells("LAN3").Appearance.BackColor = Color.Red
                End If
                If Convert.ToBoolean(Me.dgrBC.Rows(i).Cells("CTLAN4").Value) = True Then
                    Me.dgrBC.Rows(i).Cells("LAN4").Appearance.BackColor = Color.Red
                End If
                If Convert.ToBoolean(Me.dgrBC.Rows(i).Cells("CTLAN5").Value) = True Then
                    Me.dgrBC.Rows(i).Cells("LAN5").Appearance.BackColor = Color.Red
                End If

                i = i + 1
            End While
        End If
    End Sub
    Private Sub KiemTraDlHopLe()
        Dim grid As New clsTformatGrid
        obj.ChonBang = 6
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Me.Path = "/layout/Quatrinhmangthaidennuoicon.xml"
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.XpCaption2.Text = "Quá trình mang thai đến nuôi con dưới 12 tháng của cán bộ công nhân viên  "
    End Sub
    Private Sub ClearThongtin()
        Me.txtSothe.Clear()
        Me.txtHoTen.Clear()
        Me.txtDonvi.Clear()
        Me.txtSolanMT.Clear()
        Me.dtpKTLan1.Text = ""
        Me.dtpKTLan2.Text = ""
        Me.dtpKTLan3.Text = ""
        Me.dtpKTLan4.Text = ""
        Me.dtpKTLan5.Text = ""
        Me.dtpNgaymangthai.Value = Now()
        Me.txtXuong.Clear()
        Me.chkST.Checked = False
        Me.chkChitra1.Checked = False
        Me.chkChitra2.Checked = False
        Me.chkChitra3.Checked = False
        Me.chkChitra4.Checked = False
        Me.chkChitra5.Checked = False
        Me.chkCNSothe.Checked = True
        Me.txtSothe.Enabled = True
    End Sub
    Private Sub LoadXuong()
        Dim tableXuong As New DataTable
        Dim i As Integer = 0
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        obj.ChonBang = 19
        tableXuong = Me.b.LoadDS(obj)
        tableXuong.Rows.Add("TCT", "全部公司 Toàn công ty")

        tableXuong.Rows.Add("KHUA", "Khu A")
        tableXuong.Rows.Add("KHUB", "Khu B")
        tableXuong.Rows.Add("KHUDVC", "Khu DVC")

        If tableXuong.Rows.Count > 0 Then
            Me.cbXuong.DataSource = tableXuong
            Me.cbXuong.ValueMember() = "X_MA_"
            Me.cbXuong.DisplayMember() = "X_TEN"
            Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        End If
    End Sub
    Private Sub frmTheoDoiMangThaiDenNC12Thang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadXuong()
        Me.chkChitra1.Enabled = False
        Me.chkChitra2.Enabled = False
        Me.chkChitra3.Enabled = False
        Me.chkChitra4.Enabled = False
        Me.chkChitra5.Enabled = False
        Me.dtpNam.Enabled = False
        Me.chkDenNam.Checked = False
        Me.dtpDenNam.Enabled = False
        Me.chkDenNam.Enabled = False
    End Sub
    Dim oldRow As Integer = 0
    Dim ReportID As String
    Friend WithEvents b As clsBTheoDoiMangThaiDenNC12Thang
    Private Sub MethodLoad()
        If Me.chkLayST.Checked = False Then
            LoadDSMangThai_BanDau(Me.cbXuong.Value.ToString(), Me.chkNamMT.Checked, Me.chkDenNam.Checked, CDate(Me.dtpNam.Value).Year.ToString(), CDate(Me.dtpDenNam.Value).Year.ToString())
            If Me.radXuong.Checked AndAlso Me.chkNamMT.Checked = False Then
                ''============ theo xưởng hoặc khu =============''
                LoadDSMangThaiTheoXuong()
            End If
            If (Me.radXuong.Checked AndAlso Me.cbXuong.Value <> "TCT") AndAlso Me.chkNamMT.Checked Then
                ''============ theo xưởng hoặc khu + năm =============''
                LoadDSMangThaiTheoNamXuong()
            End If
            If (Me.radXuong.Checked = False AndAlso Me.chkNamMT.Checked) Or (Me.radXuong.Checked AndAlso Me.cbXuong.Value = "TCT" AndAlso Me.chkNamMT.Checked) Then
                LoadDSMangThaiTheoNam()    ''============ theo TCT
            End If

        Else
            ''============ quá trình mang thai theo ds sảy thai ==========''
            If Me.cbXuong.Value = "TCT" Or Me.radXuong.Checked = False Then
                LoadDSMangThai_BanDau(Me.cbXuong.Value.ToString(), Me.chkNamMT.Checked, Me.chkDenNam.Checked, CDate(Me.dtpNam.Value).Year.ToString(), CDate(Me.dtpDenNam.Value).Year.ToString())
                If (MessageBox.Show(("Bạn có chắc là chọn lấy toàn bộ dữ liệu sảy thai? " & Chr(10) & ChrW(13) & ".Chọn Yes nếu đồng ý, chọn No để bỏ qua."), "Chú ý:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.XpCaption2.Text = "Danh sách quá trình mang thai đến nuôi con của công nhân viên (sảy thai toàn bộ)"
                    LoadDSMangThaiST_All()
                Else
                    Me.dgrBC.DataSource = Nothing
                End If
            Else
                Select Case Me.cbXuong.Value.ToString()
                    Case "KHUA"
                        Me.XpCaption2.Text = "Danh sách quá trình mang thai đến nuôi con của công nhân viên theo khu A"
                    Case "KHUB"
                        Me.XpCaption2.Text = "Danh sách quá trình mang thai đến nuôi con của công nhân viên theo khu B"
                    Case "KHUDVC"
                        Me.XpCaption2.Text = "Danh sách quá trình mang thai đến nuôi con của công nhân viên theo khu DVC"
                    Case Else
                        Me.XpCaption2.Text = "Danh sách quá trình mang thai đến nuôi con của công nhân viên theo xưởng:" & Me.cbXuong.Text.ToString()
                End Select
                LoadDSMangThai_BanDau(Me.cbXuong.Value.ToString(), Me.chkNamMT.Checked, Me.chkDenNam.Checked, CDate(Me.dtpNam.Value).Year.ToString(), CDate(Me.dtpDenNam.Value).Year.ToString())
                LoadDSMangThaiST_Xuong()
            End If
        End If
        LoadTrangThaiChiTraKhamThai() ''======= tô màu các ô đã chi trả khám thai =======''
        LoadGridView_QTMT()
    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate

        If (Me.chkNamMT.Checked And Me.dtpNam.Text.ToString() = "") Or (Me.chkDenNam.Checked And Me.dtpDenNam.Text.ToString() = "") Or (Me.chkDenNam.Checked And Me.dtpDenNam.Enabled And CInt(Me.dtpDenNam.Text) < CInt(Me.dtpNam.Text)) Then
            MessageBox.Show("Hãy chọn năm để lọc dữ liệu.Năm kết thúc phải >= năm bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If (Me.cbXuong.Text = "" And Me.radXuong.Checked) Then
            MessageBox.Show("Bạn hãy chọn xưởng hoặc toàn công ty")
            Exit Sub
        Else
            MethodLoad()

        End If

    End Sub
    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub AnHienControl()
        Me.chkST.Enabled = False
        Me.chkST.Checked = False
        Me.dtpKTLan1.Enabled = False
        Me.dtpKTLan2.Enabled = False
        Me.dtpKTLan3.Enabled = False
        Me.dtpKTLan4.Enabled = False
        Me.dtpKTLan5.Enabled = False
        Me.txtSolanMT.Enabled = False
        Me.txtDonvi.Enabled = False
        Me.txtHoTen.Enabled = False
        Me.txtXuong.Enabled = False
        Me.dtpKTLan1.Appearance.ForeColor = Color.Black
        Me.dtpKTLan2.Appearance.ForeColor = Color.Black
        Me.dtpKTLan3.Appearance.ForeColor = Color.Black
        Me.dtpKTLan4.Appearance.ForeColor = Color.Black
        Me.dtpKTLan5.Appearance.ForeColor = Color.Black
    End Sub
    Private Sub Thongtin_mt_kthai()
        Dim solanmt As Integer
        Dim Lan1, Lan2, Lan3, Lan4, Lan5, ngaymt As Date
        Dim tableMT, tableLanKT, tableThongtin, tableLanST As DataTable
        obj.NV_MA = Me.txtSothe.Text
        obj.ChonBang = 6
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        tableThongtin = Me.b.LoadDS(obj)
        If tableThongtin.Rows.Count > 0 Then
            Me.txtHoTen.Text = tableThongtin.Rows(0).Item("HOTEN").ToString()
            Me.txtDonvi.Text = tableThongtin.Rows(0).Item("DONVI").ToString()
            Me.txtXuong.Text = tableThongtin.Rows(0).Item("XUONG").ToString()
            Me.txtSolanMT.Text = tableThongtin.Rows(0).Item("SLMT").ToString()
        Else
            Me.txtHoTen.Text = ""
            Me.txtDonvi.Text = ""
            Me.txtXuong.Text = ""
            Me.txtSolanMT.Text = ""
        End If
        Layngaymangthai() ''LAY NGAY MANG THAI DO VAO COMBO
        Kiemtra_SayThai_NV() ''CHECK ST
        If Me.dtpNgaymangthai.Text = "" Then
            Exit Sub
        Else
            ngaymt = Me.dtpNgaymangthai.Text
            obj.Ngaymangthai = Me.Ngaythangnamhople(ngaymt)
            obj.ChonBang = 15
            tableLanST = Me.b.LoadDS(obj)
            If tableLanST.Rows.Count > 0 Then
                chkST.Checked = True
            Else
                chkST.Checked = False
            End If
            ''HIEN THI NGAY MANG THAI MIN LEN COMBO --CAC LAN MANGTHAI DUOC TINH DUA VAO NGAY HIEN THI
            Tinhkhamthai_NV() ''TINH MANG THAI LAI 
            obj.ChonBang = 8
            tableMT = Me.b.LoadDS(obj)
            tableLanKT = Me.b.LoadDS(obj)
            If tableLanKT.Rows.Count > 0 Then
                If tableLanKT.Rows(0).Item("LAN1").ToString() <> "" Then
                    Me.dtpKTLan1.Text = tableLanKT.Rows(0).Item("LAN1").ToString()
                Else
                    Me.dtpKTLan1.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN2").ToString() <> "" Then
                    Me.dtpKTLan2.Text = tableLanKT.Rows(0).Item("LAN2").ToString()
                Else
                    Me.dtpKTLan2.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN3").ToString() <> "" Then
                    Me.dtpKTLan3.Text = tableLanKT.Rows(0).Item("LAN3").ToString()
                Else
                    Me.dtpKTLan3.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN4").ToString = Nothing Then
                    Me.dtpKTLan4.Text = ""
                Else
                    Me.dtpKTLan4.Text = tableLanKT.Rows(0).Item("LAN4").ToString
                End If

                If tableLanKT.Rows(0).Item("LAN5").ToString() <> "" Then
                    Me.dtpKTLan5.Text = tableLanKT.Rows(0).Item("lan5").ToString()
                Else
                    Me.dtpKTLan5.Text = ""
                End If
            Else
                Me.dtpKTLan1.Text = ""
                Me.dtpKTLan2.Text = ""
                Me.dtpKTLan3.Text = ""
                Me.dtpKTLan4.Text = ""
                Me.dtpKTLan5.Text = ""
            End If
        End If
        ThongtinChiTra()
    End Sub
    Private Sub Layngaymangthai()
        Dim tableNgaymt As DataTable
        Dim i As Integer
        obj.NV_MA = Me.txtSothe.Text
        obj.ChonBang = 12
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        tableNgaymt = Me.b.LoadDS(obj)
        If tableNgaymt.Rows.Count > 0 Then
            Me.dtpNgaymangthai.DataSource = tableNgaymt
            Me.dtpNgaymangthai.Text = tableNgaymt.Rows(0).Item(0).ToString()
        Else
            Me.dtpNgaymangthai.Text = ""

            Me.dtpNgaymangthai.Enabled = False
            MessageBox.Show("Số thẻ" & Me.txtSothe.Text & " không tìm thấy trong chương trình mang thai ", "Thông báo ")
            Me.ClearThongtin()
        End If
    End Sub
    Private Sub Clear()
        Me.dtpNgaymangthai.DataSource = Nothing
        Me.dtpNgaymangthai.Clear()
        Me.dtpKTLan1.Value = ""
        Me.dtpKTLan2.Value = ""
        Me.dtpKTLan3.Value = ""
        Me.dtpKTLan4.Value = ""
        Me.dtpKTLan5.Value = ""
        Me.txtDonvi.Text = ""
        Me.txtHoTen.Text = ""
        Me.txtXuong.Text = ""
        Me.txtSolanMT.Text = ""
        Me.chkChitra1.Checked = False
        Me.chkChitra2.Checked = False
        Me.chkChitra3.Checked = False
        Me.chkChitra4.Checked = False
        Me.chkChitra5.Checked = False
        Me.chkST.Checked = False
    End Sub
    Private Sub ThongtinChiTra()
        Dim tableChiTra As DataTable
        If Me.dtpNgaymangthai.Text <> "" Then
            Dim ngaymt As Date = Me.dtpNgaymangthai.Text
            obj.NV_MA = Me.txtSothe.Text
            obj.Ngaymangthai = Ngaythangnamhople(ngaymt)
            If obj.Ngaymangthai <> "" Then
                obj.ChonBang = 16
                tableChiTra = Me.b.LoadDS(obj)
                If tableChiTra.Rows.Count > 0 Then
                    If tableChiTra.Rows(0).Item("CHITRAL1").ToString() = "True" Then
                        Me.chkChitra1.Checked = True
                    Else
                        Me.chkChitra1.Checked = False
                    End If

                    If tableChiTra.Rows(0).Item("CHITRAL2").ToString() = "True" Then
                        Me.chkChitra2.Checked = True
                    Else
                        Me.chkChitra2.Checked = False
                    End If

                    If tableChiTra.Rows(0).Item("CHITRAL3").ToString() = "True" Then
                        Me.chkChitra3.Checked = True
                    Else
                        Me.chkChitra3.Checked = False
                    End If

                    If tableChiTra.Rows(0).Item("CHITRAL4").ToString() = "True" Then
                        Me.chkChitra4.Checked = True
                    Else
                        Me.chkChitra4.Checked = False
                    End If

                    If tableChiTra.Rows(0).Item("CHITRAL5").ToString() = "True" Then
                        Me.chkChitra5.Checked = True
                    Else
                        Me.chkChitra5.Checked = False
                    End If

                Else
                    Me.chkChitra1.Checked = False
                    Me.chkChitra2.Checked = False
                    Me.chkChitra3.Checked = False
                    Me.chkChitra4.Checked = False
                    Me.chkChitra5.Checked = False
                End If
            Else
                Me.chkChitra1.Checked = False
                Me.chkChitra2.Checked = False
                Me.chkChitra3.Checked = False
                Me.chkChitra4.Checked = False
                Me.chkChitra5.Checked = False
            End If
        Else
            Exit Sub
        End If
    End Sub
    Private Sub txtSothe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSothe.TextChanged
        Clear()
        If Me.txtSothe.TextLength = 6 Then
            AnHienControl()
            Thongtin_mt_kthai()
        End If
    End Sub
    Public Function Ngaythangnamhople(ByVal ngay As Date) As String
        'ngay = String.Format("MM/dd/yyyy", ngay)
        Dim ngayhople As String = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
        Return ngayhople
    End Function
    Private Sub chkChitra1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChitra1.CheckedChanged
        If Me.chkChitra1.Checked Then
            Me.dtpKTLan1.Appearance.BackColorDisabled = Color.GreenYellow
            Me.dtpKTLan1.Appearance.ForeColorDisabled = Color.Blue
        End If
        If Me.chkChitra1.Checked = False Then
            Me.dtpKTLan1.Appearance.BackColorDisabled = Color.Transparent
            Me.dtpKTLan1.Appearance.ForeColorDisabled = Color.Black
        End If
    End Sub
    Private Sub chkChitra2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChitra2.CheckedChanged
        If Me.chkChitra2.Checked Then
            Me.dtpKTLan2.Appearance.BackColorDisabled = Color.GreenYellow
            Me.dtpKTLan2.Appearance.ForeColorDisabled = Color.Blue
        End If
        If Me.chkChitra2.Checked = False Then
            Me.dtpKTLan2.Appearance.BackColorDisabled = Color.Transparent
            Me.dtpKTLan2.Appearance.ForeColorDisabled = Color.Black
        End If
    End Sub
    Private Sub chkChitra3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChitra3.CheckedChanged
        If Me.chkChitra3.Checked Then
            Me.dtpKTLan3.Appearance.BackColorDisabled = Color.GreenYellow
            Me.dtpKTLan3.Appearance.ForeColorDisabled = Color.Blue
        End If
        If Me.chkChitra3.Checked = False Then
            Me.dtpKTLan3.Appearance.BackColorDisabled = Color.Transparent
            Me.dtpKTLan3.Appearance.ForeColorDisabled = Color.Black
        End If
    End Sub
    Private Sub chkChitra4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChitra4.CheckedChanged
        If Me.chkChitra4.Checked Then
            Me.dtpKTLan4.Appearance.BackColorDisabled = Color.GreenYellow
            Me.dtpKTLan4.Appearance.ForeColorDisabled = Color.Blue
        End If
        If Me.chkChitra4.Checked = False Then
            Me.dtpKTLan4.Appearance.BackColorDisabled = Color.Transparent
            Me.dtpKTLan4.Appearance.ForeColorDisabled = Color.Black
        End If
    End Sub
    Private Sub chkChitra5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChitra5.CheckedChanged
        If Me.chkChitra5.Checked Then
            Me.dtpKTLan5.Appearance.BackColorDisabled = Color.GreenYellow
            Me.dtpKTLan5.Appearance.ForeColorDisabled = Color.Blue
        End If
        If Me.chkChitra5.Checked = False Then
            Me.dtpKTLan5.Appearance.BackColorDisabled = Color.Transparent
            Me.dtpKTLan5.Appearance.ForeColorDisabled = Color.Black
        End If
    End Sub
    Private Function TinhChiTra() As Integer
        Dim solan As Integer = 0
        If Me.chkChitra1.Checked Then
            solan = solan + 1
            obj.Chitra1 = 1
        Else
            obj.Chitra1 = 0
        End If
        If Me.chkChitra2.Checked Then
            solan = solan + 1
            obj.Chitra2 = 1
        Else
            obj.Chitra2 = 0
        End If
        If Me.chkChitra3.Checked Then
            solan = solan + 1
            obj.Chitra3 = 1
        Else
            obj.Chitra3 = 0
        End If
        If Me.chkChitra4.Checked Then
            solan = solan + 1
            obj.Chitra4 = 1
        Else
            obj.Chitra4 = 0
        End If
        If Me.chkChitra5.Checked Then
            solan = solan + 1
            obj.Chitra5 = 1
        Else
            obj.Chitra5 = 0
        End If
        Return solan
    End Function
    Private Sub bntCapnhatChitra_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntCapnhatChitra.Activate
          Select Me.tabPhuNuKT.SelectedTab.Index
            Case 0
            Case 1
                If dtpNgaymangthai.Text <> "" Then
                    Dim ngaymt As Date = dtpNgaymangthai.Text
                    If (MessageBox.Show(("Bạn đồng ý cập nhật chi trả " & TinhChiTra().ToString() & " lần cho số thẻ " & Me.txtSothe.Text & " hay không? "), "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Cancel) Then
                        obj.Setnull()
                        obj.NV_MA = Me.txtSothe.Text
                        obj.Ngaymangthai = ngaymt.Year.ToString() + "-" + ngaymt.Month.ToString() + "-" + ngaymt.Day.ToString()
                        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
                        obj.ChonBang = 1

                        If Me.chkChitra1.Checked Then
                            obj.Chitra1 = 1
                        Else
                            obj.Chitra1 = 0
                        End If

                        If Me.chkChitra2.Checked Then
                            obj.Chitra2 = 1
                        Else
                            obj.Chitra2 = 0
                        End If

                        If Me.chkChitra3.Checked Then
                            obj.Chitra3 = 1
                        Else
                            obj.Chitra3 = 0
                        End If

                        If Me.chkChitra4.Checked Then
                            obj.Chitra4 = 1
                        Else
                            obj.Chitra4 = 0
                        End If

                        If Me.chkChitra5.Checked Then
                            obj.Chitra5 = 1
                        Else
                            obj.Chitra5 = 0
                        End If
                        Me.b.UpdateInfo(obj)
                        Me.dgrBC.UpdateData()
                        MessageBox.Show("Đã cập nhật chi trả xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If Me.dgrBC.DataSource Is Nothing Then
                            Exit Sub
                        Else
                            ''============== load lai theo tab1 đã chọn,load lại tô màu dòng đang active ================
                            Dim dong As Integer = Me.dgrBC.ActiveRow.Index
                            If dong = -1 Then
                                Exit Sub
                            Else

                                Me.ChonDongCu()
                                If Me.dgrBC.Rows(dong).Cells("CTLAN1").Value.ToString() = "1" Then
                                    Me.dgrBC.Rows(dong).Cells("LAN1").Appearance.BackColor = Color.Red
                                End If
                                If Me.dgrBC.Rows(dong).Cells("CTLAN2").Value.ToString() = "1" Then
                                    Me.dgrBC.Rows(dong).Cells("LAN2").Appearance.BackColor = Color.Red
                                End If
                                If Me.dgrBC.Rows(dong).Cells("CTLAN3").Value.ToString() = "1" Then
                                    Me.dgrBC.Rows(dong).Cells("LAN3").Appearance.BackColor = Color.Red
                                End If
                                If Me.dgrBC.Rows(dong).Cells("CTLAN4").Value.ToString() = "1" Then
                                    Me.dgrBC.Rows(dong).Cells("LAN4").Appearance.BackColor = Color.Red
                                End If
                                If Me.dgrBC.Rows(dong).Cells("CTLAN5").Value.ToString() = "1" Then
                                    Me.dgrBC.Rows(dong).Cells("LAN5").Appearance.BackColor = Color.Red
                                End If
                                MethodLoad()
                            End If

                        End If
                    Else
                    End If
                Else
                    MessageBox.Show("Vui lòng chọn số thẻ, ngày mang thai để cập nhật chi trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
        End Select
    End Sub
    Private Sub LoaddsChitra()
        Dim i, socot, ct1, ct2, ct3, ct4, ct5 As Integer
        Dim tbl As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        Me.Path = "/layout/QTMT_NC_NhapChiTra.xml"
        obj.ChonBang = 11
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        ''hien thi luoi che do edit cac lan chi tra
        'socot = Me.dgrBC.Rows(0).Cells.Count
        'ct1 = Me.dgrBC.Rows(0).Cells.IndexOf(dgrBC.Rows(0).Cells("CTLAN1"))
        'Me.dgrBC.Rows(0).Cells.Item(ct1).Activation = Activation.AllowEdit
    End Sub
    Private Sub Tinhkhamthai_NV()
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        obj.NV_MA = Me.txtSothe.Text
        listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
        listpar1.Add(New SqlParameter("@NV_MA", obj.NV_MA))
        Me.b.GoiThuTuc("SP_LAYNGAYKTHAI_KMAX", listpar)
        Me.b.GoiThuTuc("SP_TINHSOLANTS", listpar1)
        listpar.Clear()
        listpar1.Clear()
    End Sub
    Private Sub Kiemtra_SayThai_NV()
        Dim listpar As New ArrayList(1)
        obj.NV_MA = Me.txtSothe.Text
        listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
        Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub ChonDongCu()
        If dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        Else
            Exit Sub
        End If
    End Sub
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub dtpNgaymangthai_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles dtpNgaymangthai.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub
    Private Sub chkCNSothe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCNSothe.CheckedChanged
        If Me.chkCNSothe.Checked Then
            Me.txtSothe.Enabled = True
            Me.dtpNgaymangthai.Enabled = True
            Me.chkChitra1.Enabled = True
            Me.chkChitra2.Enabled = True
            Me.chkChitra3.Enabled = True
            Me.chkChitra4.Enabled = True
            Me.chkChitra5.Enabled = True
        Else
            Me.txtSothe.Enabled = False
            Me.chkChitra1.Enabled = False
            Me.chkChitra2.Enabled = False
            Me.chkChitra3.Enabled = False
            Me.chkChitra4.Enabled = False
            Me.chkChitra5.Enabled = False
        End If
    End Sub
    Private Sub dtpNgaymangthai_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgaymangthai.TextChanged
        If dtpNgaymangthai.Text <> "" Then
            
            Dim ngaymt As Date = Me.dtpNgaymangthai.Text

            Dim tableLanKT As DataTable
            Dim tableLanST As DataTable
            Kiemtra_SayThai_NV()
            ''hien thi say thai
            obj.NV_MA = Me.txtSothe.Text
            obj.Ngaymangthai = Ngaythangnamhople(ngaymt)
            obj.ChonBang = 15
            tableLanST = Me.b.LoadDS(obj)
            If tableLanST.Rows.Count > 0 Then
                chkST.Checked = True
            Else
                chkST.Checked = False
            End If
            ''HIEN THI THONG TIN CHI TRA
            ThongtinChiTra()
            Tinhkhamthai_NV()
            ''hien thi ngay kham thai
            obj.ChonBang = 14
            tableLanKT = Me.b.LoadDS(obj)
            If tableLanKT.Rows.Count > 0 Then
                If tableLanKT.Rows(0).Item("LAN1").ToString() <> "" Then
                    Me.dtpKTLan1.Text = tableLanKT.Rows(0).Item("LAN1").ToString()
                Else
                    Me.dtpKTLan1.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN2").ToString() <> "" Then
                    Me.dtpKTLan2.Text = tableLanKT.Rows(0).Item("LAN2").ToString()
                Else
                    Me.dtpKTLan2.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN3").ToString() <> "" Then
                    Me.dtpKTLan3.Text = tableLanKT.Rows(0).Item("LAN3").ToString()
                Else
                    Me.dtpKTLan3.Value = ""
                End If

                If tableLanKT.Rows(0).Item("LAN4").ToString = Nothing Then
                    Me.dtpKTLan4.Text = ""
                Else
                    Me.dtpKTLan4.Text = tableLanKT.Rows(0).Item("LAN4").ToString
                End If

                If tableLanKT.Rows(0).Item("LAN5").ToString() <> "" Then
                    Me.dtpKTLan5.Text = tableLanKT.Rows(0).Item("lan5").ToString()
                Else
                    Me.dtpKTLan5.Text = ""
                End If
            Else
                Me.dtpKTLan1.Text = ""
                Me.dtpKTLan2.Text = ""
                Me.dtpKTLan3.Text = ""
                Me.dtpKTLan4.Text = ""
                Me.dtpKTLan5.Text = ""
            End If
        Else
        End If
    End Sub
    Private Sub tabPhuNuKT_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabPhuNuKT.SelectedTabChanged
        ''KHI CHANGE TAB CHON DONG ACTIVE THI LAY THONG TIN LEN
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0

                bntCapnhatChitra.Enabled = False
                Me.XpCaption2.Text = "Chu kỳ thai sản cán bộ công nhân viên"
            Case 1

                bntCapnhatChitra.Enabled = True
                If Me.dgrBC.DataSource Is Nothing Then
                Else
                    Dim tableChiTra As DataTable
                    Dim dong As Integer
                    If dgrBC.Rows.Count = 0 Then
                        Exit Sub
                    Else
                        Me.XpCaption2.Text = "Cập nhật chi trả bảo hiểm cho các lần khám thai"
                        ' Me.ChonDong()
                        obj.NV_MA = Me.dgrBC.ActiveRow.Cells("MA").Text.ToString()
                        Me.txtSothe.Text = obj.NV_MA

                        For i = 0 To Me.dtpNgaymangthai.Items.Count - 1
                            If dtpNgaymangthai.Items(i).DataValue.ToString() = CDate(Me.dgrBC.ActiveRow.Cells("BDAU_MANGTHAI").Value) Then
                                Me.dtpNgaymangthai.SelectedIndex = i
                                Me.dtpNgaymangthai.Focus()
                                Exit For
                            End If
                        Next

                        Dim ngaymt As Date = Me.dgrBC.ActiveRow.Cells("BDAU_MANGTHAI").Text
                        obj.Ngaymangthai = Me.Ngaythangnamhople(ngaymt)

                        If obj.Ngaymangthai <> "" Then
                            obj.ChonBang = 16
                            tableChiTra = Me.b.LoadDS(obj)
                            If tableChiTra.Rows.Count > 0 Then
                                If tableChiTra.Rows(0).Item("CHITRAL1").ToString() = "True" Then
                                    Me.chkChitra1.Checked = True
                                Else
                                    Me.chkChitra1.Checked = False
                                End If

                                If tableChiTra.Rows(0).Item("CHITRAL2").ToString() = "True" Then
                                    Me.chkChitra2.Checked = True
                                Else
                                    Me.chkChitra2.Checked = False
                                End If

                                If tableChiTra.Rows(0).Item("CHITRAL3").ToString() = "True" Then
                                    Me.chkChitra3.Checked = True
                                Else
                                    Me.chkChitra3.Checked = False
                                End If

                                If tableChiTra.Rows(0).Item("CHITRAL4").ToString() = "True" Then
                                    Me.chkChitra4.Checked = True
                                Else
                                    Me.chkChitra4.Checked = False
                                End If

                                If tableChiTra.Rows(0).Item("CHITRAL5").ToString() = "True" Then
                                    Me.chkChitra5.Checked = True
                                Else
                                    Me.chkChitra5.Checked = False
                                End If
                            Else
                                Me.chkChitra1.Checked = False
                                Me.chkChitra2.Checked = False
                                Me.chkChitra3.Checked = False
                                Me.chkChitra4.Checked = False
                                Me.chkChitra5.Checked = False
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub
    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Dim i As Integer
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                bntCapnhatChitra.Enabled = False
                If Me.chkLayST.Checked Then
                    Me.XpCaption2.Text = "Chu kỳ thai sản cán bộ công nhân viên (sảy thai toàn bộ)"

                Else
                    Me.XpCaption2.Text = "Chu kỳ thai sản cán bộ công nhân viên"

                End If

                ''refresh luoi

                If Me.dgrBC.DataSource Is Nothing Then
                    Exit Sub
                Else
                    Dim dong As Integer = Me.dgrBC.ActiveRow.Index

                    If dong = -1 Then
                        Exit Select
                    Else

                        'While i <= Me.dgrBC.Rows.Count - 1
                        '    If Me.dgrBC.Rows(i).Cells("CTLAN1").Value.ToString() = "1" Then
                        '        Me.dgrBC.Rows(i).Cells("LAN1").Appearance.BackColor = Color.Red
                        '    End If
                        '    If Me.dgrBC.Rows(i).Cells("CTLAN2").Value.ToString() = "1" Then
                        '        Me.dgrBC.Rows(i).Cells("LAN2").Appearance.BackColor = Color.Red
                        '    End If
                        '    If Me.dgrBC.Rows(i).Cells("CTLAN3").Value.ToString() = "1" Then
                        '        Me.dgrBC.Rows(i).Cells("LAN3").Appearance.BackColor = Color.Red
                        '    End If
                        '    If Me.dgrBC.Rows(i).Cells("CTLAN4").Value.ToString() = "1" Then
                        '        Me.dgrBC.Rows(i).Cells("LAN4").Appearance.BackColor = Color.Red
                        '    End If
                        '    If Me.dgrBC.Rows(i).Cells("CTLAN5").Value.ToString() = "1" Then
                        '        Me.dgrBC.Rows(i).Cells("LAN5").Appearance.BackColor = Color.Red
                        '    End If
                        '    i = i + 1
                        'End While
                    End If
                End If
            Case 1
                bntCapnhatChitra.Enabled = True
                Me.txtSothe.Enabled = False
                If Me.dgrBC.DataSource Is Nothing Then
                Else

                    Dim tableChiTra As DataTable
                    Dim dong As Integer = Me.dgrBC.ActiveRow.Index
                    If dong = -1 Then
                        Exit Select
                    Else

                        Dim ngaymt As Date = Me.dgrBC.Rows(dong).Cells("BDAU_MANGTHAI").Value

                        Me.XpCaption2.Text = "Cập nhật chi trả bảo hiểm cho các lần khám thai"
                        ' Me.ChonDong()
                        obj.NV_MA = Me.dgrBC.Rows(dong).Cells("MA").Text.ToString()
                        Me.txtSothe.Text = obj.NV_MA
                        If Me.dgrBC.Rows(dong).Cells("BDAU_MANGTHAI").Text <> Me.dtpNgaymangthai.Text Then

                            For i = 0 To Me.dtpNgaymangthai.Items.Count - 1
                                If dtpNgaymangthai.Items(i).DataValue.ToString() = Me.dgrBC.Rows(dong).Cells("BDAU_MANGTHAI").Value Then
                                    Me.dtpNgaymangthai.SelectedIndex = i
                                    Me.dtpNgaymangthai.Focus()
                                    Exit For
                                End If
                            Next

                            'Me.dtpNgay.Value = CDate(Me.dgrBC.Rows(dong).Cells("BDAU_MANGTHAI").Value)
                            'Me.dtpNgaymangthai.Text = Me.dtpNgay.Value

                            obj.Ngaymangthai = Me.Ngaythangnamhople(ngaymt)
                            If obj.Ngaymangthai <> "" Then
                                obj.ChonBang = 16
                                tableChiTra = Me.b.LoadDS(obj)
                                If tableChiTra.Rows.Count > 0 Then
                                    If tableChiTra.Rows(0).Item("CHITRAL1").ToString() = "True" Then
                                        Me.chkChitra1.Checked = True
                                        Me.dgrBC.Rows(dong).Cells("LAN1").Appearance.BackColor = Color.Red
                                    Else
                                        Me.chkChitra1.Checked = False
                                    End If

                                    If tableChiTra.Rows(0).Item("CHITRAL2").ToString() = "True" Then
                                        Me.chkChitra2.Checked = True
                                        Me.dgrBC.Rows(dong).Cells("LAN2").Appearance.BackColor = Color.Red
                                    Else
                                        Me.chkChitra2.Checked = False
                                    End If

                                    If tableChiTra.Rows(0).Item("CHITRAL3").ToString() = "True" Then
                                        Me.chkChitra3.Checked = True
                                        Me.dgrBC.Rows(dong).Cells("LAN3").Appearance.BackColor = Color.Red
                                    Else
                                        Me.chkChitra3.Checked = False
                                    End If

                                    If tableChiTra.Rows(0).Item("CHITRAL4").ToString() = "True" Then
                                        Me.chkChitra4.Checked = True
                                        Me.dgrBC.Rows(dong).Cells("LAN4").Appearance.BackColor = Color.Red
                                    Else
                                        Me.chkChitra4.Checked = False
                                    End If

                                    If tableChiTra.Rows(0).Item("CHITRAL5").ToString() = "True" Then
                                        Me.chkChitra5.Checked = True
                                        Me.dgrBC.Rows(dong).Cells("LAN5").Appearance.BackColor = Color.Red
                                    Else
                                        Me.chkChitra5.Checked = False
                                    End If
                                    While i <= Me.dgrBC.Rows.Count - 1
                                        If Me.dgrBC.Rows(i).Cells("CTLAN1").Value.ToString() = "1" Then
                                            Me.dgrBC.Rows(i).Cells("LAN1").Appearance.BackColor = Color.Red
                                        End If
                                        If Me.dgrBC.Rows(i).Cells("CTLAN2").Value.ToString() = "1" Then
                                            Me.dgrBC.Rows(i).Cells("LAN2").Appearance.BackColor = Color.Red
                                        End If
                                        If Me.dgrBC.Rows(i).Cells("CTLAN3").Value.ToString() = "1" Then
                                            Me.dgrBC.Rows(i).Cells("LAN3").Appearance.BackColor = Color.Red
                                        End If
                                        If Me.dgrBC.Rows(i).Cells("CTLAN4").Value.ToString() = "1" Then
                                            Me.dgrBC.Rows(i).Cells("LAN4").Appearance.BackColor = Color.Red
                                        End If
                                        If Me.dgrBC.Rows(i).Cells("CTLAN5").Value.ToString() = "1" Then
                                            Me.dgrBC.Rows(i).Cells("LAN5").Appearance.BackColor = Color.Red
                                        End If
                                        i = i + 1
                                    End While
                                Else
                                    Me.chkChitra1.Checked = False
                                    Me.chkChitra2.Checked = False
                                    Me.chkChitra3.Checked = False
                                    Me.chkChitra4.Checked = False
                                    Me.chkChitra5.Checked = False
                                End If
                            End If
                        End If
                        ' ''doi qua lai giua cac Tab reset lai
                        'Me.dgrBC.DataSource = Nothing
                        'Me.dgrBC.Show()
                    End If
                End If
        End Select
    End Sub
    Private Sub bntCNTuExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntCNTuExcel.Click
        Dim pathFile As String
        Dim wb As Microsoft.Office.Interop.Excel.Workbook
        ''xoa bang tam

        obj.ChonBang = 1
        Me.b.DeleteInfo(obj)
        Me.OpenFile.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            pathFile = Me.OpenFile.FileName
        Else
            MessageBox.Show("Chưa chọn đường dẫn file excel!", "Không chọn import từ file excel")
            Exit Sub
        End If
        Dim dbexcel As ADODB.Connection, rsexcel As ADODB.Recordset
        Dim db As ADODB.Connection, rs As ADODB.Recordset
        dbexcel = New ADODB.Connection
        dbexcel.Provider = "Microsoft.Jet.OLEDB.4.0"
        dbexcel.ConnectionString = "Data Source='" + pathFile + "';Extended Properties=Excel 8.0"
        dbexcel.Open()
        rsexcel = New ADODB.Recordset
        rsexcel.Open("select * from [sheet1$]", dbexcel)
        If rsexcel.RecordCount = 0 Then
            MessageBox.Show("Sheet 1 file excel không có dữ liệu!", "Thông báo không chứa dữ liệu yêu cầu")
            Exit Sub
        End If
        ''khong tim thay trong file sheet1

        db = New ADODB.Connection
        db.Provider = "SQLOLEDB.1"
        Dim clsConnectD As New clsDTheoDoiMangThaiDenNC12Thang
        clsConnectD.connectDB()
        db.ConnectionString = clsConnectD.connectString()
        db.Open()
        ''db.ConnectionString = Application.CommonAppDataPath.ToString()


        rs = New ADODB.Recordset
        rs.Open("IT_CHITRAPNMT", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim tablet As DataTable
        ''=============== khoi tao datatable chua ds khong dung =========================
        Dim column1 As New DataColumn
        Dim column2 As New DataColumn
        Dim column3 As New DataColumn
        Dim column4 As New DataColumn
        Dim column5 As New DataColumn
        tbl_DulieuK_Hle.Columns.Clear()
        tbl_DulieuK_Hle.Columns.Add(column1)
        tbl_DulieuK_Hle.Columns.Add(column2)
        tbl_DulieuK_Hle.Columns.Add(column3)
        tbl_DulieuK_Hle.Columns.Add(column4)
        tbl_DulieuK_Hle.Columns.Add(column5)

        tbl_DulieuK_Hle.Columns(0).ColumnName = "SOTHE"
        tbl_DulieuK_Hle.Columns(1).ColumnName = "NGAYKHAM"
        tbl_DulieuK_Hle.Columns(2).ColumnName = "SOTIEN"
        tbl_DulieuK_Hle.Columns(3).ColumnName = "NGAYKHAMDOILAI"
        tbl_DulieuK_Hle.Columns(4).ColumnName = "STT"

        tbl_DulieuK_Hle.Columns(0).DataType = Type.GetType("System.String")
        tbl_DulieuK_Hle.Columns(1).DataType = Type.GetType("System.String")
        tbl_DulieuK_Hle.Columns(2).DataType = Type.GetType("System.String")
        tbl_DulieuK_Hle.Columns(3).DataType = Type.GetType("System.DateTime")
        tbl_DulieuK_Hle.Columns(4).DataType = Type.GetType("System.String")
        ''===================================================================================
        While Not rsexcel.EOF
            rs.AddNew()

            If String.IsNullOrEmpty(rsexcel.Fields("NGAYKHAM").Value.ToString()) Then
                ''ngay cap nhat: 17-08-2013
                ''nguoi cap nhat: Tran
                ''noi dung cap nhat: khong hop du lieu ngay kham
                ''======================== lay dong khong hop le vao table tam ========================
                Dim dr As DataRow

                dr = tbl_DulieuK_Hle.NewRow()
                dr.Item("SOTHE") = rsexcel.Fields("SOTHE").Value.ToString()
                dr.Item("NGAYKHAM") = rsexcel.Fields("NGAYKHAM").Value.ToString()
                dr.Item("SOTIEN") = rsexcel.Fields("SOTIEN").Value.ToString()
                dr.Item("NGAYKHAMDOILAI") = Now.Date
                dr.Item("STT") = ""
                tbl_DulieuK_Hle.Rows.Add(dr)
                ''bo cap nhat vao bang tam vi sai dinh dang
                rs.CancelUpdate()
                rsexcel.MoveNext()
                j = j + 1
                tablet = tbl_DulieuK_Hle
            Else
                rs.Fields("NV_MA").Value = Trim(rsexcel.Fields("SOTHE").Value)
                rs.Fields("NGAYKHAM").Value = Trim(rsexcel.Fields("NGAYKHAM").Value)
                If String.IsNullOrEmpty(rsexcel.Fields("SOTIEN").Value.ToString()) Then
                    rs.Fields("SOTIEN").Value = 0
                Else
                    rs.Fields("SOTIEN").Value = Trim(rsexcel.Fields("SOTIEN").Value)
                End If
                rs.Update()
                rsexcel.MoveNext()
                i = i + 1
            End If
        End While
        rsexcel.Close()
        dbexcel.Close()
        If j = 0 Then
            MsgBox("Đã sao chép xong dữ liệu thành công " & i & " dòng ", , "thông báo")

        Else
            MsgBox("Đã sao chép xong dữ liệu thành công " & i & " dòng và " & j & " dòng không hợp lệ ", , "thông báo")

        End If
        '' mo souce sao chép
        Dim frm As New frmLocExcel
        frm.tbleChiTraKDung = tbl_DulieuK_Hle
        frm.ShowDialog()
        If frm.chon Then
            If Me.radXuong.Checked Then
                If Me.cbXuong.Text = "" Then
                    'LoadDSMangThai()
                Else
                    obj.Xuong = Me.cbXuong.Value
                    LoadDSMangThaiTheoXuong()
                    'LoadDSKhamThai()
                End If
            End If
        End If
    End Sub
    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        Me.cbXuong.Enabled = Me.radXuong.Checked
    End Sub
    Private Sub chkNamMT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNamMT.CheckedChanged
        If chkNamMT.Checked Then
            Me.dtpNam.Enabled = True
            Me.chkDenNam.Enabled = True
        Else
            Me.dtpNam.Enabled = False
            Me.chkDenNam.Enabled = False
        End If
    End Sub
    Private Sub chkDenNam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDenNam.CheckedChanged
        Me.dtpDenNam.Enabled = Me.chkDenNam.Checked
    End Sub

End Class