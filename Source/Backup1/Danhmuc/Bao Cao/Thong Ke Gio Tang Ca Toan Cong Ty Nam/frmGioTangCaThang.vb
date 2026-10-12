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
Imports System.DBNull
Imports System.Drawing.Bitmap
Imports System.Configuration
Imports Infragistics.Win.UltraWinTree
Imports System.Data.SqlClient
Imports System.IO
Imports Infragistics.Excel

Public Class frmGiotangcathang

#Region "Biến toàn cục"
    ''Biến lựa chọn bảng quẹt thẻ ngoài giờ hay trong giờ
    Public Tenbang As String
    'Biến phân quyền nút xem rad tăng ca ngoài giờ
    Dim Them As Boolean = False
    Dim Sua As Boolean = False
    Dim Xoa As Boolean = False
    Dim Xem As Boolean = False
    ''=============================
    Dim Tabletemp As DataTable
    Dim PATH As String = ""
    Public obj As New objGiotangcathang
    Public TrongQuyDinh As Boolean = True
    Public Theothang As Boolean = True
    Public ChonDD As Boolean = False
    Public ChonTongDonvi As Boolean = False
    Public ChonTongNhanvien As Boolean = False
    Friend WithEvents d As clsDGiotangcathang ' Nested Types
    Friend WithEvents b As clsBGiotangcathang
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim dNgaydd, dTuNgay, dDenNgay As Date
    Dim sTuNgay, sDenNgay, sNgaydd As String
    Public ngaydiemdanh As String
    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim k As Integer = 1
    Dim tsdv As Integer = 0
    Public sLoginTime As String = ""
    ''=============================
    Public Tabledv As DataTable
    Public TabledvNhomXuong As New DataTable()
    Public Tabletk As DataTable
    Public DonVi As String = ""
#End Region

    Public Sub QuyenTruyCap()
        If Them And Sua And Xoa Then
            Me.RadNgoaiQD.Visible = True
            Me.RadTrongNgoaiQD.Visible = True
            Me.radNgoaiQD_DV.Visible = True
            Me.radNgoaiQD_DV.Location = New System.Drawing.Point(502, 49)
            Me.radTrongQD_DV.Location = New System.Drawing.Point(390, 49)
            Me.Panel2.Location = New System.Drawing.Point(82, 46)
            ''========hien rad ngoai quy dinh tab 2 ========

            RadTrongQD.Location = New System.Drawing.Point(6, 45)
            RadNgoaiQD.Location = New System.Drawing.Point(116, 45)
            chkBTTC.Location = New System.Drawing.Point(825, 45)
            Panel1.Location = New System.Drawing.Point(375, 45)
            Panel3.Location = New System.Drawing.Point(558, 44)
        Else
            Me.RadNgoaiQD.Visible = False
            Me.RadTrongNgoaiQD.Visible = False
            ''========an rad ngoai quy dinh tab 2 ========
            Me.radNgoaiQD_DV.Visible = False
            ''========== dời các đối tượng lại gần nhau =======''
            chkBTTC.Location = New System.Drawing.Point(580, 45)
            Panel1.Location = New System.Drawing.Point(116, 45)
            Panel3.Location = New System.Drawing.Point(445, 44)
        End If
    End Sub
    Private Sub Load_Combo()
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBGiotangcathang
        obj.ChonBang = 1
        Tabletemp = Me.b.LoadDS(obj)
        Tabletemp.Rows.Add("TCT")
        Tabletemp.Rows.Add("KHUA")
        Tabletemp.Rows.Add("KHUB")
        Tabletemp.Rows.Add("KHUDVC")
        Me.cboXuong.DataSource = Tabletemp
        Me.cboXuong.DisplayMember() = "X_MA_"
        Me.cboXuong.ValueMember() = "X_MA_"
        Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        If Tabletemp.Rows.Count > 0 Then
            Me.cboXuong.SelectedIndex = 0
        Else
            Me.cboXuong.Enabled = False
            Exit Sub
        End If
    End Sub
    Private Sub XetPhanQuyen()
        ''================= XET TRANG THAI PHAN QUYEN THEM XOA SUA ============
        ''Ngay sua: 11/10/2013
        ''nguoi sua: Trân
        ''noi dung: phan quyen them xoa sua = quyền xem nút tang ca ngoai gio
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.ChonBang = 67
        Dim TQuyenTruyCap, TUser As New DataTable
        TUser = Me.b.LoadDS(obj)
        If TUser.Rows.Count > 0 Then
            obj.ChonBang = 68
            TQuyenTruyCap = Me.b.LoadDS(obj)
            If TQuyenTruyCap.Rows.Count > 0 Then
                ''======================== xet trang thai la admin thi bo qua ==============''
                If Convert.ToBoolean(TUser.Rows(0).Item("admin")) Then
                    Them = True
                    Sua = True
                    Xoa = True
                    ''gan mac dinh admin dc xem
                Else
                    If TQuyenTruyCap.Rows(0).Item("Them").ToString() = "" Then
                        Them = False
                    Else
                        Them = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Them"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Sua").ToString() = "" Then
                        Sua = False
                    Else
                        Sua = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Sua"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Xoa").ToString() = "" Then
                        Xoa = False
                    Else
                        Xoa = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Xoa"))
                    End If
                    QuyenTruyCap()
                End If
            Else
                Them = False
                Sua = False
                Xoa = False
            End If

        Else
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Them = False
            Sua = False
            Xoa = False
            Exit Sub
        End If
    End Sub
    Private Sub frmGioTangCaThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Combo()
        XetPhanQuyen()
        Me.chkGioTangCa.Checked = True ''======= mặc định
        radTangCaChiTiet_DV.Checked = True
    End Sub
    Private Sub btnXem_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Me.b = New clsBGiotangcathang
        Dim songaycuoithang_thangbd As Integer
        Me.DonVi = Me.cboXuong.Value.ToString()
        ChonDD = False
        Dim strDV_MA = ""

        Me.XpCaption2.Text = ""
        If LayThamSo() Then

            obj.TUNGAY = CDate(Me.dtpTungay.Value).Year.ToString() + "/" + CDate(Me.dtpTungay.Value).Month.ToString() + "/" + CDate(Me.dtpTungay.Value).Day.ToString()
            obj.DENNGAY = CDate(Me.dtpDenngay.Value).Year.ToString() + "/" + CDate(Me.dtpDenngay.Value).Month.ToString() + "/" + CDate(Me.dtpDenngay.Value).Day.ToString()

            songaycuoithang_thangbd = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Me.dtpTungay.Value))).Day
            obj.NGAYBD_THANGBD = CDate(Me.dtpTungay.Value).Day
            obj.NGAYKT_THANGBD = songaycuoithang_thangbd ''============ tự tính

            obj.NGAYBD_THANGKT = 1
            obj.NGAYKT_THANGKT = CDate(Me.dtpDenngay.Value).Day
            obj.THANGBD = CDate(Me.dtpTungay.Value).Month.ToString()
            obj.THANGKT = CDate(Me.dtpDenngay.Value).Month.ToString()
            obj.Nam = CDate(Me.dtpDenngay.Value).Year

            If obj.THANGBD = obj.THANGKT Then
                obj.CHONCUNGTHANG = 1
            Else
                obj.CHONCUNGTHANG = 0
            End If

            obj.ChonXuong = Me.cboXuong.Value
            Select Case cboXuong.Value
                Case "KHUA", "KHUB", "KHUDVC"
                    obj.ChonBang = 15
                    obj.ChonKhu = 1
                    If Me.cboXuong.Value = "KHUA" Then
                        obj.KHU = "A"
                    End If

                    If Me.cboXuong.Value = "KHUB" Then
                        obj.KHU = "B"
                    End If

                    If Me.cboXuong.Value = "KHUDVC" Then
                        obj.KHU = "DVC"
                    End If
                Case "TCT"
                    obj.ChonBang = 10
                    obj.ChonXuong = "TCT"
                    obj.ChonKhu = 0
                    obj.KHU = ""
                Case Else
                    obj.ChonKhu = 0
                    obj.ChonBang = 17
                    obj.ChonXuong = Me.cboXuong.Value
                    obj.DONVI = Me.cboXuong.Value
                    obj.KHU = ""
            End Select

            Me.Tabledv = Me.b.LoadDS(obj)
            Me.Tabletk = New DataTable()

            If Me.RadTrongQD.Checked Then
                Me.ProgressBar1.Visible = False
                ProgressBar.Visible = True
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Style = ProgressBarStyle.Marquee

                If Me.chkGioTangCa.Checked Then
                    obj.ChonBang = 18
                    TaidulieuTrongQuyDinh_BangChiTiet()
                End If

                If Me.Chktheothang.Checked Then
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar.Visible = False
                    obj.ChonBang = 19
                    TaidulieuTrongQuyDinh_BangChiTietTheoTungThang()
                End If

                If Me.chkTongTheodonvi.Checked Then
                    obj.ChonBang = 20
                    TaidulieuTrongQuyDinh_BangTong()
                End If
            End If

            ''=========== Ngoai gio 
            If Me.RadNgoaiQD.Checked Or Me.RadTrongNgoaiQD.Checked Then
                Me.ProgressBar1.Visible = True
                Me.ProgressBar.Visible = False

                If Me.chkGioTangCa.Checked Then
                    'Me.Tabledv = Me.b.LoadDS(obj)
                    TaidulieuNgoaiQuyDinh_BangChiTiet(obj.ChonKhu, obj.KHU, obj.ChonXuong)
                End If


                If Me.Chktheothang.Checked Then
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar.Visible = False
                    ' Me.Tabledv = Me.b.LoadDS(obj)
                    TaidulieuNgoaiQuyDinh_BangChiTietTheoTungThang(obj.ChonXuong, obj.KHU)
                End If

                If Me.chkTongTheodonvi.Checked Then
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar.Visible = False
                    ' Me.Tabledv = Me.b.LoadDS(obj)
                    TaidulieuNgoaiQuyDinh_BangTong(obj.KHU)
                End If
            End If

            'If Me.RadTrongNgoaiQD.Checked Then
            '    Me.ProgressBar1.Visible = True
            '    Me.ProgressBar.Visible = False

            '    If Me.chkGioTangCa.Checked Then
            '        'TaidulieuNgoaiQuyDinh_BangChiTiet()
            '    End If

            '    If Me.chkTongTheodonvi.Checked Then
            '        taidulieuTrongNgoaiQuyDinh()
            '    End If
            'End If
        End If
    End Sub
    Public Sub taidulieuTrongNgoaiQuyDinh()
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1
        Me.TextBox1.Visible = True

        For i = 0 To Me.Tabledv.Rows.Count - 1
            Me.laytext2(i)
            Me.TextBox1.Refresh()
            Try
                Application.DoEvents()
                tblTemp = Me.GoiThuTuc(Me.Tabledv.Rows(i).Item(0).ToString(), ChonDD)
                Me.Tabletk.Merge(tblTemp)
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                MessageBox.Show(exception3, "lỗi")
            End Try
            If Me.Tabledv.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Step = (100 * i) / tsdv
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If
        Next
        Me.TextBox1.Visible = False
        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        LoadGridView_TongTheoDonvi()
    End Sub

    Private Sub LoadGridView_Giotangca()
        Dim chuoitieude As String = "Danh sách chi tiết tổng giờ công "
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            With Me.dgrBC.DisplayLayout.Bands(0)

                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next
                Select Case Me.UltraTabControl1.SelectedTab.Index
                    Case 0
                        ''=========== 
                        'If Me.RadNgoaiQD.Checked Or Me.chkBTTC.Checked = False Then
                        '    .Columns("TONGBT").Hidden = True
                        'Else
                        '    .Columns("TONGBT").Hidden = False
                        'End If

                        .Columns("STT").Width = 100
                        If Me.RadTrongQD.Checked Then
                            If Me.chkBTTC.Checked Then
                                .Columns("TONGBT").Hidden = False
                            Else
                                .Columns("TONGBT").Hidden = True
                            End If


                            chuoitieude = chuoitieude + "trong quy định "
                        End If

                        If Me.RadNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + "ngoài quy định "
                            .Columns("TONGBT").Hidden = False
                        End If

                        If Me.RadTrongNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + "trong + ngoài quy định "
                            

                        End If
                        If Me.chkGioTangCa.Checked Then

                            .Columns("TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                            .Columns("DONVI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                            .Columns("CV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                            .Columns("XUONG").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                            '.Columns("NGAYVAO").Format = "dd/MM/yyyy"
                            .Columns("SOTHE").Header.Caption = "Số thẻ"
                            .Columns("TEN").Header.Caption = "Họ tên"
                            .Columns("DONVI").Header.Caption = "Đơn vị"
                            .Columns("NGAYVAO").Header.Caption = "Ngày vào"
                            .Columns("CV_TEN").Header.Caption = "Công việc"
                            .Columns("XUONG").Header.Caption = "Xưởng"

                            If Me.RadTrongNgoaiQD.Checked Then
                                .Columns("BT_TRONGGIO").Header.Caption = "Tổng BT"
                                .Columns("TC_TRONGGIO").Header.Caption = "Tổng Tăng Ca (trong giờ)"
                                .Columns("TC_NGOAIGIO").Header.Caption = "Tổng Tăng Ca (ngoài giờ)"
                                .Columns("BT_TRONGGIO").Header.VisiblePosition = 7
                                .Columns("TC_TRONGGIO").Header.VisiblePosition = 8
                                .Columns("TC_NGOAIGIO").Header.VisiblePosition = 9
                            Else
                                .Columns("TONGBT").Header.Caption = "Tổng BT"
                                .Columns("TONGTC").Header.Caption = "Tổng Tăng Ca"


                                .Columns("TONGBT").Header.VisiblePosition = 7
                                .Columns("TONGTC").Header.VisiblePosition = 8

                            End If

                            .Columns("STT").Header.VisiblePosition = 0
                            .Columns("TEN").Header.VisiblePosition = 1
                            .Columns("SOTHE").Header.VisiblePosition = 2
                            .Columns("DONVI").Header.VisiblePosition = 3
                            .Columns("NGAYVAO").Header.VisiblePosition = 4
                            .Columns("CV_TEN").Header.VisiblePosition = 5
                            .Columns("XUONG").Header.VisiblePosition = 6

                            .Columns("SOTHE").Width = 100
                            .Columns("TEN").Width = 200
                            .Columns("DONVI").Width = 150
                            .Columns("NGAYVAO").Width = 150
                            .Columns("CV_TEN").Width = 150
                            .Columns("XUONG").Width = 100



                            'Me.dgrBC.DisplayLayout.Bands(0).Columns("XUONG").SortIndicator = SortIndicator.Ascending
                            'Me.dgrBC.DisplayLayout.Bands(0).SortedColumns.Add("DONVI", False, False)


                        End If


                    Case 1

                        If Me.radNgoaiQD_DV.Checked Then

                            .Columns("TONGBT").Hidden = True
                        Else

                            .Columns("TONGBT").Hidden = False
                        End If
                End Select

                Me.XpCaption2.Text = chuoitieude + " theo " + Me.cboXuong.Text

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
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
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
    Private Sub LoadGridView_TongTheoDonvi()
        Dim chuoitieude As String = "Danh sách tổng giờ công theo đơn vị "
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            With Me.dgrBC.DisplayLayout.Bands(0)
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next
                Select Case Me.UltraTabControl1.SelectedTab.Index
                    Case 0
                        If Me.RadTrongQD.Checked Then
                            chuoitieude = chuoitieude + " trong quy định "
                        End If

                        If Me.RadNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + " ngoài quy định "
                        End If

                        If Me.RadTrongNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + " trong + ngoài quy định "
                        End If
                        .Columns("STT").Width = 100
                        If Me.chkTongTheodonvi.Checked Then
                            .Columns("DONVI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                            .Columns("XUONG").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                            .Columns("DONVI").Header.Caption = "Đơn vị"
                            .Columns("XUONG").Header.Caption = "Xưởng"
                           
                            .Columns("DONVI").Width = 150
                            .Columns("XUONG").Width = 100

                            .Columns("STT").Header.VisiblePosition = 0
                            .Columns("DONVI").Header.VisiblePosition = 1
                            .Columns("XUONG").Header.VisiblePosition = 2

                            If Me.RadTrongNgoaiQD.Checked Then
                                .Columns("BT_TRONGGIO").Header.Caption = "Tổng BT"
                                .Columns("TC_TRONGGIO").Header.Caption = "Tổng Tăng Ca (trong giờ)"
                                .Columns("TC_NGOAIGIO").Header.Caption = "Tổng Tăng Ca (ngoài giờ)"

                                .Columns("BT_TRONGGIO").Header.VisiblePosition = 3
                                .Columns("TC_TRONGGIO").Header.VisiblePosition = 4
                                .Columns("TC_NGOAIGIO").Header.VisiblePosition = 5
                            Else
                                .Columns("TONGBT").Header.Caption = "Tổng BT"
                                .Columns("TONGTC").Header.Caption = "Tổng Tăng Ca"

                                .Columns("TONGBT").Header.VisiblePosition = 3
                                .Columns("TONGTC").Header.VisiblePosition = 4
                                If chkBTTC.Checked Then
                                    .Columns("TONGBT").Hidden = False
                                Else
                                    .Columns("TONGBT").Hidden = True
                                End If
                            End If
                          

                           
                        End If


                        ''=========== 
                        If Me.RadNgoaiQD.Checked Or Me.chkBTTC.Checked = False Then
                            .Columns("TONGBT").Hidden = True
                        Else
                            .Columns("TONGBT").Hidden = False
                        End If
                    Case 1
                        If Me.radNgoaiQD_DV.Checked Then
                            .Columns("TONGBT").Hidden = True
                        Else
                            .Columns("TONGBT").Hidden = False
                        End If
                End Select

                Me.XpCaption2.Text = chuoitieude + " theo " + Me.cboXuong.Text
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
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
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
    Private Sub LoadGridView_TheoThang()
        Dim chuoitieude As String = "Danh sách chi tiết tổng giờ công theo tháng "
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColSwapping = AllowColSwapping.NotAllowed
            Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColMoving = AllowColMoving.NotAllowed

            With Me.dgrBC.DisplayLayout.Bands(0)

                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                    If i >= 8 Then
                        .Columns(i).Width = 100
                    End If
                Next
                Select Case Me.UltraTabControl1.SelectedTab.Index
                    Case 0
                        ''=========== 
                        If Me.RadTrongQD.Checked Then
                            chuoitieude = chuoitieude + " trong giờ"
                        End If

                        If Me.RadNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + " ngoài giờ"
                        End If

                        If Me.RadTrongNgoaiQD.Checked Then
                            chuoitieude = chuoitieude + " trong + ngoài giờ"
                        End If

                        .Columns("TEN").Header.VisiblePosition = 1
                        .Columns("SOTHE").Header.VisiblePosition = 2
                        .Columns("DONVI").Header.VisiblePosition = 3
                        .Columns("NGAYVAO").Header.VisiblePosition = 4
                        .Columns("CV_TEN").Header.VisiblePosition = 5
                        .Columns("NV_GIOITINH").Header.VisiblePosition = 6

                        .Columns("NAM").Header.VisiblePosition = 7
                        .Columns("XUONG").Header.VisiblePosition = 8

                        .Columns("TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                        .Columns("DONVI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                        .Columns("CV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                        .Columns("XUONG").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                        .Columns("NGAYVAO").Format = "dd/MM/yyyy"

                        .Columns("STT").Header.Caption = "STT" & Chr(10) & "次序"
                        .Columns("SOTHE").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                        .Columns("TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                        .Columns("DONVI").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                        .Columns("NGAYVAO").Header.Caption = "NGÀY VÀO" & Chr(10) & "進廠日期"
                        .Columns("CV_TEN").Header.Caption = "CÔNG VIỆC" & Chr(10) & "工作"
                        .Columns("NV_GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                        .Columns("NAM").Header.Caption = "Năm"
                        .Columns("XUONG").Header.Caption = "Xưởng"

                        .Columns("SOTHE").Width = 100
                        .Columns("TEN").Width = 250
                        .Columns("DONVI").Width = 100
                        .Columns("NGAYVAO").Width = 100
                        .Columns("CV_TEN").Width = 100
                        .Columns("NAM").Width = 100
                        .Columns("NV_GIOITINH").Width = 100
                        .Columns("XUONG").Width = 100

                        .Columns("NAM").Hidden = True
                        .Columns("XUONG").Hidden = True
                        If Me.RadNgoaiQD.Checked Then
                            .Columns("TONGGTC").Width = 120
                            .Columns("TONGGTC").Header.Caption = "TỔNG GIỜ TĂNG CA" & Chr(10) & "總加班工時"


                            .Columns("TC1").Header.VisiblePosition = 8

                            .Columns("TC2").Header.VisiblePosition = 9

                            .Columns("TC3").Header.VisiblePosition = 10

                            .Columns("TC4").Header.VisiblePosition = 11

                            .Columns("TC5").Header.VisiblePosition = 12



                            .Columns("TC6").Header.VisiblePosition = 13

                            .Columns("TC7").Header.VisiblePosition = 14

                            .Columns("TC8").Header.VisiblePosition = 15

                            .Columns("TC9").Header.VisiblePosition = 16

                            .Columns("TC10").Header.VisiblePosition = 17

                            .Columns("TC11").Header.VisiblePosition = 18

                            .Columns("TC12").Header.VisiblePosition = 19
                        Else
                            .Columns("DV_MA").Hidden = True
                            .Columns("TONGGBT").Width = 120
                            .Columns("TONGGTC").Width = 120
                            .Columns("TONGGBT").Header.Caption = "TỔNG GIỜ BÌNH THƯỜNG"
                            .Columns("TONGGTC").Header.Caption = "TỔNG GIỜ TĂNG CA" & Chr(10) & "總加班工時"

                            .Columns("BT1").Header.Caption = "Bình thường T1"
                            .Columns("BT2").Header.Caption = "Bình thường T2"
                            .Columns("BT3").Header.Caption = "Bình thường T3"
                            .Columns("BT4").Header.Caption = "Bình thường T4"
                            .Columns("BT5").Header.Caption = "Bình thường T5"
                            .Columns("BT6").Header.Caption = "Bình thường T6"
                            .Columns("BT7").Header.Caption = "Bình thường T7"
                            .Columns("BT8").Header.Caption = "Bình thường T8"
                            .Columns("BT9").Header.Caption = "Bình thường T9"
                            .Columns("BT10").Header.Caption = "Bình thường T10"
                            .Columns("BT11").Header.Caption = "Bình thường T11"
                            .Columns("BT12").Header.Caption = "Bình thường T12"

                            .Columns("BT1").Tag = "1"
                            .Columns("BT2").Tag = "2"
                            .Columns("BT3").Tag = "3"
                            .Columns("BT4").Tag = "4"
                            .Columns("BT5").Tag = "5"
                            .Columns("BT6").Tag = "6"
                            .Columns("BT7").Tag = "7"
                            .Columns("BT8").Tag = "8"
                            .Columns("BT9").Tag = "9"
                            .Columns("BT10").Tag = "10"
                            .Columns("BT11").Tag = "11"
                            .Columns("BT12").Tag = "12"

                            ''=====================================
                            .Columns("BT1").Header.Tag = "BT"
                            .Columns("BT2").Header.Tag = "BT"
                            .Columns("BT3").Header.Tag = "BT"
                            .Columns("BT4").Header.Tag = "BT"
                            .Columns("BT5").Header.Tag = "BT"
                            .Columns("BT6").Header.Tag = "BT"
                            .Columns("BT7").Header.Tag = "BT"
                            .Columns("BT8").Header.Tag = "BT"
                            .Columns("BT9").Header.Tag = "BT"
                            .Columns("BT10").Header.Tag = "BT"
                            .Columns("BT11").Header.Tag = "BT"
                            .Columns("BT12").Header.Tag = "BT"

                            If Me.chkBTTC.Checked Then
                                .Columns("BT1").Hidden = False
                                .Columns("BT2").Hidden = False
                                .Columns("BT3").Hidden = False
                                .Columns("BT4").Hidden = False
                                .Columns("BT5").Hidden = False
                                .Columns("BT6").Hidden = False
                                .Columns("BT7").Hidden = False
                                .Columns("BT8").Hidden = False
                                .Columns("BT9").Hidden = False
                                .Columns("BT10").Hidden = False
                                .Columns("BT11").Hidden = False
                                .Columns("BT12").Hidden = False
                                .Columns("TONGGBT").Hidden = False


                            Else
                                Me.dgrBC.DisplayLayout.Bands.Item(0).ColHeaderLines = 2
                                .Columns("BT1").Hidden = True
                                .Columns("BT2").Hidden = True
                                .Columns("BT3").Hidden = True
                                .Columns("BT4").Hidden = True
                                .Columns("BT5").Hidden = True
                                .Columns("BT6").Hidden = True
                                .Columns("BT7").Hidden = True
                                .Columns("BT8").Hidden = True
                                .Columns("BT9").Hidden = True
                                .Columns("BT10").Hidden = True
                                .Columns("BT11").Hidden = True
                                .Columns("BT12").Hidden = True
                                .Columns("TONGGBT").Hidden = True
                            End If

                            .Columns("BT1").Header.VisiblePosition = 8
                            .Columns("TC1").Header.VisiblePosition = 9
                            .Columns("BT2").Header.VisiblePosition = 10
                            .Columns("TC2").Header.VisiblePosition = 11
                            .Columns("BT3").Header.VisiblePosition = 12
                            .Columns("TC3").Header.VisiblePosition = 13
                            .Columns("BT4").Header.VisiblePosition = 14
                            .Columns("TC4").Header.VisiblePosition = 15
                            .Columns("BT5").Header.VisiblePosition = 16
                            .Columns("TC5").Header.VisiblePosition = 17


                            .Columns("BT6").Header.VisiblePosition = 18
                            .Columns("TC6").Header.VisiblePosition = 19
                            .Columns("BT7").Header.VisiblePosition = 20
                            .Columns("TC7").Header.VisiblePosition = 21
                            .Columns("BT8").Header.VisiblePosition = 22
                            .Columns("TC8").Header.VisiblePosition = 23
                            .Columns("BT9").Header.VisiblePosition = 24
                            .Columns("TC9").Header.VisiblePosition = 25
                            .Columns("BT10").Header.VisiblePosition = 26
                            .Columns("TC10").Header.VisiblePosition = 27
                            .Columns("BT11").Header.VisiblePosition = 28
                            .Columns("TC11").Header.VisiblePosition = 29
                            .Columns("BT12").Header.VisiblePosition = 30
                            .Columns("TC12").Header.VisiblePosition = 31
                        End If


                        .Columns("TC1").Header.Caption = "THÁNG 1" & Chr(10) & "月份"
                        .Columns("TC2").Header.Caption = "THÁNG 2" & Chr(10) & "月份"
                        .Columns("TC3").Header.Caption = "THÁNG 3" & Chr(10) & "月份"
                        .Columns("TC4").Header.Caption = "THÁNG 4" & Chr(10) & "月份"
                        .Columns("TC5").Header.Caption = "THÁNG 5" & Chr(10) & "月份"
                        .Columns("TC6").Header.Caption = "THÁNG 6" & Chr(10) & "月份"
                        .Columns("TC7").Header.Caption = "THÁNG 7" & Chr(10) & "月份"
                        .Columns("TC8").Header.Caption = "THÁNG 8" & Chr(10) & "月份"
                        .Columns("TC9").Header.Caption = "THÁNG 9" & Chr(10) & "月份"
                        .Columns("TC10").Header.Caption = "THÁNG 10" & Chr(10) & "月份"
                        .Columns("TC11").Header.Caption = "THÁNG 11" & Chr(10) & "月份"
                        .Columns("TC12").Header.Caption = "THÁNG 12" & Chr(10) & "月份"

                        ''================= gán tag để ẩn theo tháng kết thúc ====================


                        .Columns("TC1").Tag = "1"
                        .Columns("TC2").Tag = "2"
                        .Columns("TC3").Tag = "3"
                        .Columns("TC4").Tag = "4"
                        .Columns("TC5").Tag = "5"
                        .Columns("TC6").Tag = "6"
                        .Columns("TC7").Tag = "7"
                        .Columns("TC8").Tag = "8"
                        .Columns("TC9").Tag = "9"
                        .Columns("TC10").Tag = "10"
                        .Columns("TC11").Tag = "11"
                        .Columns("TC12").Tag = "12"


                        ''=====================================
                        .Columns("TC1").Header.Tag = "TC"
                        .Columns("TC2").Header.Tag = "TC"
                        .Columns("TC3").Header.Tag = "TC"
                        .Columns("TC4").Header.Tag = "TC"
                        .Columns("TC5").Header.Tag = "TC"
                        .Columns("TC6").Header.Tag = "TC"
                        .Columns("TC7").Header.Tag = "TC"
                        .Columns("TC8").Header.Tag = "TC"
                        .Columns("TC9").Header.Tag = "TC"
                        .Columns("TC10").Header.Tag = "TC"
                        .Columns("TC11").Header.Tag = "TC"
                        .Columns("TC12").Header.Tag = "TC"



                        .Columns("TEN").Header.VisiblePosition = 1
                        .Columns("SOTHE").Header.VisiblePosition = 2
                        .Columns("DONVI").Header.VisiblePosition = 3
                        .Columns("NGAYVAO").Header.VisiblePosition = 4
                        .Columns("CV_TEN").Header.VisiblePosition = 5
                        .Columns("NV_GIOITINH").Header.VisiblePosition = 6
                        .Columns("NAM").Header.VisiblePosition = 7
                        .Columns("XUONG").Header.VisiblePosition = 8







                        ''============ XÉT ẨN CỘT ============''
                        Dim thangketthuc As String = CDate(Me.dtpDenngay.Value).Month.ToString()
                        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            If Me.RadNgoaiQD.Checked Then
                            Else
                                If .Columns(i).Header.Tag.ToString() = "BT" Then
                                    If CInt(.Columns(i).Tag) > thangketthuc Then
                                        .Columns(i).Hidden = True
                                    End If
                                End If
                            End If


                            If .Columns(i).Header.Tag.ToString() = "TC" Then
                                If CInt(.Columns(i).Tag) > thangketthuc Then
                                    .Columns(i).Hidden = True
                                End If
                            End If
                        Next

                    Case 1
                        If Me.radNgoaiQD_DV.Checked Then
                            .Columns("TONGBT").Hidden = True
                        Else
                            .Columns("TONGBT").Hidden = False
                        End If
                End Select


                Me.XpCaption2.Text = chuoitieude + " theo " + Me.cboXuong.Text
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
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(2)
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
    Private Function LayThamSo() As Boolean
        If CDate(Me.dtpDenngay.Value).Year.ToString() <> CDate(dtpTungay.Value).Year.ToString() Then
            MessageBox.Show("Vui lòng chọn thống kê trong năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If

        If Me.dtpDenngay.Value < dtpTungay.Value Then
            MessageBox.Show("Vui lòng chọn thời gian kết thúc >= thời gian bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If Me.RadTrongQD.Checked = False AndAlso Me.RadNgoaiQD.Checked = False AndAlso Me.RadTrongNgoaiQD.Checked = False Then
            MessageBox.Show("Vui lòng chọn trong quy định hay ngoài quy định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If Me.cboXuong.Value Is Nothing Then
            MessageBox.Show("Vui lòng chọn xưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        If Me.Chktheothang.Checked Then
            If Me.dtpTungay.Value.Year.ToString() <> Me.dtpDenngay.Value.Year.ToString() Then
                MessageBox.Show("Vui lòng chọn cùng năm khi thống kê theo tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
                Exit Function
            End If
        End If
        If Me.Chktheothang.Checked = False AndAlso Me.chkTongTheodonvi.Checked = False AndAlso Me.chkGioTangCa.Checked = False Then
            MessageBox.Show("Vui lòng chọn thống kê giờ tăng ca, thống kê tăng ca theo tháng hoặc tổng theo đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        ''-------- GIOI HAN CHON NAM CU ==========
        If CDate(Me.dtpTungay.Value).Year.ToString() < Year(Now().Date) Then
            '' ---------- NGAY BD <> 1, NGAY KT <> NGAY CUOI THANG 
        End If
        Return True
    End Function
    Private Function GoiThuTucThongKeGioCong_NgoaiQD(ByVal sXuong As String, ByVal sKhu As String) As DataTable

        Dim dtTable As DataTable
        dTuNgay = Me.dtpTungay.Value
        dDenNgay = Me.dtpDenngay.Value

        sTuNgay = dTuNgay.Year.ToString() + "-" + dTuNgay.Month.ToString() + "-" + dTuNgay.Day.ToString()
        sDenNgay = dDenNgay.Year.ToString() + "-" + dDenNgay.Month.ToString() + "-" + dDenNgay.Day.ToString()

        Select Case sKhu
            Case ""
                Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                  New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                  New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuong(0).Value = sXuong
                SqlParamXuong(1).Value = CDate(sTuNgay)
                SqlParamXuong(2).Value = CDate(sDenNgay)
                SqlParamXuong(3).Value = 0

                If Me.chkGioTangCa.Checked Then
                    ''============= tổng gio công theo số thẻ: NGOÀI GIỜ ============
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_XUONG_MOI", SqlParamXuong)

                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_TRONGNGOAIGIO_XUONG_MOI_S", SqlParamXuong)
                    End If
                End If

                If Me.chkTongTheodonvi.Checked Then
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_XUONG_MOI", SqlParamXuong)

                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_TRONGNGOAIGIO_XUONG_MOI_S", SqlParamXuong)
                    End If
                End If

                If Me.Chktheothang.Checked Then
                    ''============= tổng gio công só thẻ theo từng tháng ============
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_DONVI_THEOTHANG_XUONG_MOI_S", SqlParamXuong)

                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_THEOTHANG_TRONGGIONGOAIGIO_XUONG", SqlParamXuong)
                    End If
                End If


            Case Else
                Dim SqlParamXuongKhu As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                              New SqlParameter("@KHU", SqlDbType.NVarChar, 50), _
                                              New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                              New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                              New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuongKhu(0).Value = sXuong
                SqlParamXuongKhu(1).Value = sKhu
                SqlParamXuongKhu(2).Value = CDate(sTuNgay)
                SqlParamXuongKhu(3).Value = CDate(sDenNgay)
                SqlParamXuongKhu(4).Value = 0


                If Me.chkGioTangCa.Checked Then
                    ''============= tổng gio công theo số thẻ: NGOÀI GIỜ ============
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_KHU_S", SqlParamXuongKhu)
                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        ''============= tổng gio công theo số thẻ: TRONG + NGOÀI GIỜ ============
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_TRONGNGOAIGIO_KHU_S", SqlParamXuongKhu)
                    End If
                End If

                If Me.chkTongTheodonvi.Checked Then
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_KHU_S", SqlParamXuongKhu)

                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_TRONGNGOAIGIO_KHU_S", SqlParamXuongKhu)
                    End If
                End If

                If Me.Chktheothang.Checked Then
                    ''============= tổng gio công só thẻ theo từng tháng ============
                    If Me.RadNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_DONVI_THEOTHANG_KHU_S", SqlParamXuongKhu)

                    ElseIf Me.RadTrongNgoaiQD.Checked Then
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_THEOTHANG_TRONGGIONGOAIGIO_KHU_S", SqlParamXuongKhu)
                    End If
                End If
        End Select
        Return dtTable
    End Function
    Public Sub laytext2(ByVal dong As Integer)
        If Me.cboXuong.Value.ToString() = "TCT" Then
            Me.TextBox1.Text = "Đang thống kê xưởng :" & Me.Tabledv.Rows(dong).Item(0).ToString() & " hãy đợi một tí bạn nhé"
        Else
            Me.TextBox1.Text = "Đang thống kê đơn vị :" & Me.Tabledv.Rows(dong).Item(0).ToString() & " hãy đợi một tí bạn nhé"
        End If
    End Sub

    Public Sub TaidulieuNgoaiQuyDinh_BangTong(ByVal sKhu As String)
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()

        Me.TextBox1.Visible = True

        For i = 0 To Me.Tabledv.Rows.Count - 1
            Me.laytext2(i)
            Me.TextBox1.Refresh()
            Try
                Application.DoEvents()
                tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString(), sKhu)
                If Not tblTemp Is Nothing Then
                    Me.Tabletk.Merge(tblTemp)
                End If
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                MessageBox.Show(exception3, "lỗi")
            End Try

            If Me.Tabledv.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Step = (100 * i) / tsdv
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If
        Next
        Me.TextBox1.Visible = False

        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        LoadGridView_TongTheoDonvi()
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)


        'Try
        '    Application.DoEvents()
        '    tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString())
        '    If Not tblTemp Is Nothing Then
        '        Me.Tabletk.Merge(tblTemp)
        '    End If



    End Sub

    Public Sub TaidulieuTrongQuyDinh_BangTong()
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()

        Try
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
            tblTemp = Me.b.LoadTruyVanThongKeGioCong(obj)
            If Not tblTemp Is Nothing Then
                Me.Tabletk.Merge(tblTemp)
            End If


        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception3, "lỗi")
        End Try

        Me.ProgressBar.Value = 100

        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        LoadGridView_TongTheoDonvi()
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)
    End Sub
    Public Sub TaidulieuTrongQuyDinh_BangChiTiet()
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()
        Try
            Application.DoEvents()
            tblTemp = Me.b.LoadTruyVanThongKeGioCong(obj)
            If Not tblTemp Is Nothing Then
                Me.Tabletk.Merge(tblTemp)
            End If
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception3, "lỗi")
        End Try
        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        LoadGridView_Giotangca()
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)
    End Sub
    Public Sub TaidulieuNgoaiQuyDinh_BangChiTiet(ByVal iChonKhu As Integer, ByVal sKhu As String, ByVal sXuong As String)
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()

        Me.TextBox1.Visible = True

        For i = 0 To Me.Tabledv.Rows.Count - 1
            Me.laytext2(i)
            Me.TextBox1.Refresh()
            Try
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()
            
                tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString(), sKhu)


                If Not tblTemp Is Nothing Then
                    Me.Tabletk.Merge(tblTemp)
                End If
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                MessageBox.Show(exception3, "lỗi")
            End Try

            If Me.Tabledv.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Step = (100 * i) / tsdv
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If
        Next
        Me.TextBox1.Visible = False

        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        LoadGridView_Giotangca()
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)
    End Sub
    Public Sub TaidulieuNgoaiQuyDinh_BangChiTietTheoTungThang(ByVal sXuong As String, ByVal sKhu As String)
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()

        Me.TextBox1.Visible = True


        'Select Me.cboXuong.Value
        '    Case "TCT"
        '        tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString(), sKhu)
        '        If Not tblTemp Is Nothing Then
        '            Me.Tabletk.Merge(tblTemp)
        '        End If
        '    Case "KHUA", "KHUB", "KHUDVC"
        '        tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString(), sKhu)
        '        If Not tblTemp Is Nothing Then
        '            Me.Tabletk.Merge(tblTemp)
        '        End If
        '    Case Else
        For i = 0 To Me.Tabledv.Rows.Count - 1
            Me.laytext2(i)
            Me.TextBox1.Refresh()
            Try
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()

                tblTemp = Me.GoiThuTucThongKeGioCong_NgoaiQD(Me.Tabledv.Rows(i).Item(0).ToString(), sKhu)
                If Not tblTemp Is Nothing Then
                    Me.Tabletk.Merge(tblTemp)
                End If
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                MessageBox.Show(exception3, "lỗi")
            End Try

            If Me.Tabledv.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Step = (100 * i) / tsdv
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If
        Next
        'End Select


        Me.TextBox1.Visible = False

        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        LoadGridView_TheoThang()
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)
    End Sub
    Public Sub TaidulieuTrongQuyDinh_BangChiTietTheoTungThang()
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1

        tblTemp = New DataTable()
        tblTemp.Clear()

        Me.TextBox1.Visible = True

        Select Case Me.cboXuong.Value
            Case "TCT"
                tblTemp = Me.b.LoadTruyVanThongKeGioCong(obj)
                If Not tblTemp Is Nothing Then
                    Me.Tabletk.Merge(tblTemp)
                End If
            Case "KHUA", "KHUB", "KHUDVC"
                tblTemp = Me.b.LoadTruyVanThongKeGioCong(obj)
                If Not tblTemp Is Nothing Then
                    Me.Tabletk.Merge(tblTemp)
                End If
            Case Else
                For i = 0 To Me.Tabledv.Rows.Count - 1
                    Me.laytext2(i)
                    Me.TextBox1.Refresh()
                    Try
                        System.Threading.Thread.Sleep(100)
                        Application.DoEvents()
                        If Me.RadTrongQD.Checked Then
                            tblTemp = Me.b.LoadTruyVanThongKeGioCong(obj)
                        End If

                        If Not tblTemp Is Nothing Then
                            Me.Tabletk.Merge(tblTemp)
                        End If
                    Catch exception3 As Exception
                        ProjectData.SetProjectError(exception3)
                        Dim exception2 As Exception = exception3
                        MessageBox.Show(exception3, "lỗi")
                    End Try

                    If Me.Tabledv.Rows.Count > 1 Then
                        Me.ProgressBar1.Value = (100 * i) / tsdv
                        Me.ProgressBar1.Step = (100 * i) / tsdv
                        Me.ProgressBar1.PerformStep()
                    Else
                        Me.ProgressBar1.Value = 100
                    End If
                Next
        End Select
        
        Me.TextBox1.Visible = False

        If Me.Tabletk.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Me.Tabletk
        Else
            Me.dgrBC.DataSource = Nothing
        End If
        LoadGridView_TheoThang()
        Me.ProgressBar.Style = ProgressBarStyle.Blocks
        Me.ProgressBar.Value = 100
        MessageBox.Show("Đã thống kê xong.", "Thông báo", MessageBoxButtons.OK)
    End Sub
    Private Function getExcelFileName() As String
        Dim folder As New DirectoryInfo(Application.ExecutablePath)
        Dim filename As String

        For i As Integer = 0 To Integer.MaxValue
            filename = folder.Parent.FullName + "\Export" + i.ToString() + ".xls"
            If Not File.Exists(filename) Then
                Exit For
            End If
        Next i

        Return filename
    End Function

    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Dim myWorkbook As New Workbook
        Dim myWorksheet As Worksheet
        Dim sNgaybatdau, sNgayketthuc As String
        Dim chuoitieude As String = ""
        If Chktheothang.Checked Then
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'get a filename for the xls file

           

                Me.dtpTungay.CustomFormat = "dd/MM/yyyy"
                Me.dtpDenngay.CustomFormat = "dd/MM/yyyy"
           
                Select Case cboXuong.Value
                    Case "KHUA"
                        chuoitieude = "TỔNG GIỜ TĂNG CA CÁC XƯỞNG KHU A TỪ NGÀY " & Me.dtpTungay.Text & " ĐẾN NGÀY " & Me.dtpDenngay.Text & Chr(10)
                        Me.dtpTungay.CustomFormat = "yyyy/MM/dd"
                        Me.dtpDenngay.CustomFormat = "yyyy/MM/dd"
                        chuoitieude = chuoitieude & "從" & Me.dtpTungay.Text & "至 " & Me.dtpDenngay.Text & " KHU A 廠加班工時匯總表 "
                    Case "KHUB"
                        chuoitieude = "TỔNG GIỜ TĂNG CA CÁC XƯỞNG KHU B TỪ NGÀY " & Me.dtpTungay.Text & " ĐẾN NGÀY " & Me.dtpDenngay.Text & Chr(10)
                        Me.dtpTungay.CustomFormat = "yyyy/MM/dd"
                        Me.dtpDenngay.CustomFormat = "yyyy/MM/dd"
                        chuoitieude = chuoitieude & "從" & Me.dtpTungay.Text & "至 " & Me.dtpDenngay.Text & " KHU B 廠加班工時匯總表 "

                    Case "TCT"
                        chuoitieude = "TỔNG GIỜ TĂNG CA CÁC XƯỞNG TỪ NGÀY " & Me.dtpTungay.Text & " ĐẾN NGÀY " & Me.dtpDenngay.Text & Chr(10)
                        Me.dtpTungay.CustomFormat = "yyyy/MM/dd"
                        Me.dtpDenngay.CustomFormat = "yyyy/MM/dd"
                        chuoitieude = chuoitieude & "從" & Me.dtpTungay.Text & "至 " & Me.dtpDenngay.Text & " 廠加班工時匯總表 "

                    Case Else
                        chuoitieude = "TỔNG GIỜ TĂNG CA XƯỞNG " & Me.cboXuong.Value & " TỪ NGÀY " & Me.dtpTungay.Text & " ĐẾN NGÀY " & Me.dtpDenngay.Text & Chr(10)
                        Me.dtpTungay.CustomFormat = "yyyy/MM/dd"
                        Me.dtpDenngay.CustomFormat = "yyyy/MM/dd"
                        chuoitieude = chuoitieude & "從" & Me.dtpTungay.Text & "至 " & Me.dtpDenngay.Text & " " & Me.cboXuong.Value & " 廠加班工時匯總表 "

                End Select
                Me.dtpTungay.CustomFormat = "dd/MM/yyyy"
                Me.dtpDenngay.CustomFormat = "dd/MM/yyyy"
                Dim filename = getExcelFileName()
                'create a new workbook
                myWorksheet = myWorkbook.Worksheets.Add("THONGKEGIOTANGCA")
                Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("THONGKEGIOTANGCA")
                'add a header to the worksheet
                myWorksheet.Rows(0).Cells(0).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(0).Cells(0).Value = chuoitieude
                myWorksheet.Rows(0).Cells(0).CellFormat.Font.Height = 300
                myWorksheet.Rows(0).Height = 800

                myWorksheet.Rows(0).Cells(0).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(0).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(0).Cells(0).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(0).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(0).Cells(0).CellFormat.WrapText = ExcelDefaultableBoolean.True

         
                'modify the format of the date column
                'For i As Integer = 3 To 3 + Me.dgrBC.Rows.Count - 1
                '    myWorksheet.Rows(i).Cells(2).CellFormat.FormatString = "mm.dd.yyyy"
                'Next i

                For i As Integer = 0 To Me.dgrBC.Rows.Count - 1
                    myWorksheet.Rows(i).Cells(4).CellFormat.FormatString = "mm/dd/yyyy"
                Next

                'Export the data
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 1, 0)

                Dim tongsocotVisible As Integer = 0

                For i As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    If dgrBC.DisplayLayout.Bands(0).Columns(i).Hidden = False Then
                        tongsocotVisible = tongsocotVisible + 1
                    End If

                Next
                For i As Integer = 0 To tongsocotVisible - 1
                    myWorksheet.Rows(1).Cells(i).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Next


                sheet.MergedCellsRegions.Add(0, 0, 0, tongsocotVisible - 1)

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub Laybangdulieu()
        Dim chuoidd As String = " theo điểm danh"
        Dim chuoitam As String = " Danh sách giờ công"
        Dim nam As String = obj.Nam.ToString()
        Dim chonXuong, chuoitieude As String
        If Me.cboXuong.Value = "TCT" Then
            chonXuong = " toàn công ty"
        Else
            chonXuong = " xưởng " + Me.cboXuong.Value.ToString()
        End If
        If Me.RadTrongQD.Checked Then
            chonXuong = chonXuong + " trong quy định "
        ElseIf Me.RadNgoaiQD.Checked Then
            chonXuong = chonXuong + " ngoài quy định "
        Else
            chonXuong = chonXuong + " trong + ngoài quy định"
        End If

        ''====== chọn xem theo tháng =====''
        If Me.Chktheothang.Checked = True AndAlso Me.chkTongTheodonvi.Checked = False AndAlso Me.chkGioTangCa.Checked = False Then
            If Me.RadTrongNgoaiQD.Checked Then
                If Me.chkBTTC.Checked = True Then
                    ''GIO BT + TANG CA THEO TUNG THANG TRONG NGOAIGIO(BT1,TC1,...)
                    'Me.PATH = "/layout/Giotangcatoancongty_trongngoaiquydinh_theothang.xml"
                    'chuoitieude = chuoitam + " bình thường và tăng ca theo từng tháng " + chonXuong
                    chuoitieude = chuoitam + " công theo tháng xưởng - " + chonXuong
                Else
                    ''TANG CA THEO TUNG THANG TRONG NGOAIGIO(TC1,...)
                    'Me.PATH = "/layout/Giotangcatoancongty_trongngoaiquydinh_theothang_angiobinhthuong.xml"
                    'chuoitieude = chuoitam + " bình thường và tăng ca theo từng tháng " + chonXuong
                    chuoitieude = chuoitam + " công theo tháng xưởng - " + chonXuong
                End If
            Else
                ''========== chon trong quy dinh =========''
                If Me.RadTrongQD.Checked Then
                    If Me.chkBTTC.Checked = True Then
                        ''GIO BT + TANG CA THEO TUNG THANG (BT1,TC1,...)
                        'Me.PATH = "/layout/Giotangcatoancongty_tt_tqd.xml"
                        chuoitieude = chuoitam + " công theo từng tháng " + chonXuong
                        LoadGridView_TheoThang()
                    Else
                        ''TANG CA THEO TUNG THANG (TC2,TC2,...)
                        'Me.PATH = "/layout/Giotangcatoancongty_tt_nqd.xml"
                        chuoitieude = chuoitam + " tăng ca theo từng tháng " + chonXuong
                        LoadGridView_TheoThang()
                    End If
                Else ''========== chon ngoai quy dinh =========''
                    ''TANG CA THEO TUNG THANG (TC2,TC2,...)
                    'Me.PATH = "/layout/Giotangcatoancongty_tt_nqd.xml"
                    chuoitieude = chuoitam + " tăng ca theo từng tháng " + chonXuong
                End If
            End If
        End If

        ''====== chọn xem theo tổng đơn vị =====''
        If Me.chkTongTheodonvi.Checked = True AndAlso Me.Chktheothang.Checked = False AndAlso Me.chkGioTangCa.Checked = False Then
            If Me.chkBTTC.Checked = True Then
                ''GIO BT + TANG CA THEO TUNG THANG (BT1,TC1,...)
                'Me.PATH = "/layout/Giotangcatoancongty_tqd_tongtangcadv.xml"
                chuoitieude = " Danh sách tổng giờ công theo đơn vị của" + chonXuong
            Else
                If Me.RadTrongQD.Checked Then
                    ''========= trong quy dinh ========''
                    If Me.chkBTTC.Checked = True Then
                        '' LAY TONG THEO TUNG DON VI: TRONG GIO(TONGBT,TONGTC)
                        'Me.PATH = "/layout/Giotangcatoancongty_tqd_tongtangcadv.xml"
                        chuoitieude = " Danh sách tổng giờ  bình thường và tổng giờ tăng ca theo đơn vị của" + chonXuong
                    Else
                        'Me.PATH = "/layout/Giotangcatoancongty_tqd_tongtangcadv.xml"
                        chuoitieude = " Danh sách tổng giờ tăng ca theo đơn vị của " + chonXuong
                        LoadGridView_TongTheoDonvi()
                    End If
                ElseIf Me.RadNgoaiQD.Checked Then
                    ''========= ngoai quy dinh ========''
                    'Me.PATH = "/layout/Giotangcatoancongty_nqd_tongtangca.xml"
                    chuoitieude = " Danh sách tổng giờ tăng ca theo đơn vị của " + chonXuong

                ElseIf Me.RadTrongNgoaiQD.Checked Then
                    ''========= trong + ngoai quy dinh ========''
                    'Me.PATH = "/layout/Giotangcatoancongty_trongngoaiquydinh_tongtangcadv.xml"
                    chuoitieude = " Danh sách tổng giờ tăng ca theo đơn vị của " + chonXuong
                End If

            End If
        End If
        ''======== mặc định không chọn tính giờ tổng bt, tổng tca từng nhân viên
        If (Me.Chktheothang.Checked = False AndAlso Me.chkTongTheodonvi.Checked = False AndAlso Me.chkGioTangCa.Checked = False) Or Me.chkGioTangCa.Checked Then
            If Me.chkBTTC.Checked = True Then
                ''GIO BT + TANG CA THEO TUNG NHAN VIEN (so the,ten,donvi,...,tong bt,tong tc)
                'Me.PATH = "/layout/GiotangcatoancongtyHienCotBT.xml"
                chuoitieude = chuoitam + " bình thường và tăng ca theo trong khoảng thời gian: " + Me.dtpTungay.Text.ToString() + " đến " + Me.dtpDenngay.Text.ToString() + chonXuong
                LoadGridView_Giotangca()




            Else
                ''======== chi lay gio tang ca ======''
                If Me.RadTrongQD.Checked Then
                    '' LAY TONG TANG CA THEO TUNG NHANVIEN (so the,ten,donvi,...,tong tc)
                    LoadGridView_Giotangca()
                    'Me.PATH = "/layout/GiotangcatoancongtyDefault.xml"
                    chuoitieude = chuoitam + " bình thường và tăng ca theo trong khoảng thời gian: " + Me.dtpTungay.Text.ToString() + " đến " + Me.dtpDenngay.Text.ToString() + chonXuong

                ElseIf Me.RadNgoaiQD.Checked Then
                    'Me.PATH = "/layout/Giotangcatoancongty_nqd_tongtangca.xml"
                    'Me.PATH = "/layout/GiotangcatoancongtyDefault.xml"
                    chuoitieude = chuoitam + " tăng ca trong khoảng thời gian: " + Me.dtpTungay.Text.ToString() + " đến " + Me.dtpDenngay.Text.ToString() + chonXuong
                    LoadGridView_Giotangca()
                ElseIf Me.RadTrongNgoaiQD.Checked Then
                    ''========= trong + ngoai quy dinh ========''
                    'Me.PATH = "/layout/Giotangcatoancongty_trongngoaiquydinh_tongtangca.xml"
                    chuoitieude = " Danh sách tổng giờ tăng ca theo đơn vị của " + chonXuong
                End If
            End If
        End If

        ''===== nếu chọn điểm danh =========
        If Me.ChonDD Then
            chuoitieude = chuoitieude + chuoidd
        Else
            chuoitieude = chuoitieude
        End If
        Me.XpCaption2.Text = chuoitieude
    End Sub
    Private Sub RadTrongNgoaiQD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadTrongNgoaiQD.CheckedChanged
        If Me.RadTrongNgoaiQD.Checked Then
            Me.chkBTTC.Visible = False
            Me.btnXemDiemDanh.Visible = False
            Me.chkBTTC.Checked = False
            Me.Chktheothang.Enabled = False
            Me.Chktheothang.Checked = False
        Else
            Me.chkBTTC.Visible = True
            Me.btnXemDiemDanh.Visible = True
            Me.Chktheothang.Enabled = True
        End If
    End Sub
    Private Sub RadNgoaiQD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadNgoaiQD.CheckedChanged
        If Me.RadNgoaiQD.Checked Then
            Me.chkBTTC.Visible = False
        Else
            Me.chkBTTC.Visible = True
        End If
    End Sub
    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UltraTabControl1.SelectedTabChanged
        Select Case Me.UltraTabControl1.SelectedTab.Index
            Case 0
                Me.btnXem.Visible = True
                btnXemDiemDanh.Visible = True
                btnThongkeXuong.Visible = False
                Me.XpCaption1.Text = "Thống kê giờ công toàn công ty "
            Case 1
                Me.btnXem.Visible = False
                btnXemDiemDanh.Visible = False
                btnThongkeXuong.Visible = True
                Me.XpCaption1.Text = "Thống kê giờ công nhóm xưởng"
        End Select
    End Sub
    Private Sub chkBTTC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBTTC.CheckedChanged
        ''=========== LOAD LẠI GRID VIEW CÓ CỘT GIỜ BINH THUONG THI HIỆN LÊN ================
        Select Case Me.UltraTabControl1.SelectedTab.Index
            Case 0

                If Me.RadTrongQD.Checked Or Me.RadTrongNgoaiQD.Checked Then
                    ''=========== xet loai bao cao ===========''
                    If Me.chkGioTangCa.Checked Then
                        LoadGridView_Giotangca()
                    End If

                    If Me.chkTongTheodonvi.Checked Then
                        LoadGridView_TongTheoDonvi()
                    End If

                    If Me.Chktheothang.Checked Then
                        LoadGridView_TheoThang()
                    End If
                Else

                End If

            Case 1
        End Select

    End Sub
    Private Sub btnThongkeXuong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThongkeXuong.Activate
        Dim listpar As New ArrayList(4)
        Dim listpar1 As New ArrayList(3)
        Dim tblDonviNhomXuong As DataTable
        Dim obj As New objGiotangcathang
        Me.b = New clsBGiotangcathang
        Dim sTenThutuc As String = ""
        Dim sKhu As String

        Dim i As Integer
        If Me.dtpDenngay_DV.Value.ToString() < Me.dtpTuNgay_DV.Value.ToString() Then
            MessageBox.Show("Thời gian kết thúc phải >= thời gian bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If Me.radA1A2.Checked Then
                obj.ChonBang = 13
                sTenThutuc = "SP_DSNHANVIENNHOMXUONG_DDGIAM"
                sKhu = ""
            End If

            If Me.radNhomA.Checked Then
                obj.ChonBang = 15
                sTenThutuc = "SP_DSNHANVIENNHOMXUONG_DDGIAM_NHOMA"
                sKhu = "A"
            End If

            If Me.radNhomB.Checked Then
                obj.ChonBang = 15
                sTenThutuc = "SP_DSNHANVIENNHOMXUONG_DDGIAM_NHOMB"
                sKhu = "B"
            End If

            If Me.radNhomDVC.Checked Then
                obj.ChonBang = 15
                sTenThutuc = "SP_DSNHANVIENNHOMXUONG_DDGIAM_NHOMDVC"
                sKhu = "DVC"
            End If

            obj.DONVI = Me.DonVi
            obj.ChonXuong = obj.DONVI
            obj.KHU = sKhu

            tblDonviNhomXuong = Me.b.LoadDS(obj)

            Me.TabledvNhomXuong = tblDonviNhomXuong

            dTuNgay = Me.dtpTuNgay_DV.Value
            dDenNgay = Me.dtpDenngay_DV.Value

            sTuNgay = dTuNgay.Year.ToString() + "-" + dTuNgay.Month.ToString() + "-" + dTuNgay.Day.ToString()
            sDenNgay = dDenNgay.Year.ToString() + "-" + dDenNgay.Month.ToString() + "-" + dDenNgay.Day.ToString()

            ''============ xoa bang tam ========''
            Me.b.GoiThuTucKhongThamSo("SP_XOADSNHANVIENNHOMXUONG")
            ''=========== LAY SỐ LƯỢNG DDGIAM THEO TỪNG KHU: A1A2, KHU A, KHUB ======================''
            Application.DoEvents()
            listpar1.Add(New SqlParameter("@NGAYBD", sTuNgay))
            listpar1.Add(New SqlParameter("@NGAYKT", sDenNgay))
            Me.b.GoiThuTuc(sTenThutuc, listpar1)
            listpar1.Clear()
            ''========= CẬP NHẬT TÊN ĐƠN VỊ, XƯỞNG, ĐƠN VỊ CŨ CHO DS DDGIAM =====''
            Me.b.GoiThuTucKhongThamSo("SP_CAPNHATXUONG_GIOCONGNHOMXUONG")
            listpar1.Clear()
            Me.taidulieunhomxuong(sKhu)
        End If
    End Sub
    Public Sub taidulieunhomxuong(ByVal sKhu As String)
        Dim tsdv As Integer = 0
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim TableGioCong As New DataTable()
        Dim tblTam As New DataTable
        Dim tblTamDDGiam As New DataTable
        TableGioCong.Clear()
        TableGioCong.Columns.Add("STT", GetType(Integer))
        TableGioCong.Columns("STT").AutoIncrement = True
        TableGioCong.Columns("STT").AutoIncrementSeed = 1

        tsdv = Me.TabledvNhomXuong.Rows.Count
        Try
            If Me.radTangCaChiTiet_DV.Checked Then
                For i = 0 To Me.TabledvNhomXuong.Rows.Count - 1
                    tblTam = GoiThuTucThongKeTheoNhomXuong(TabledvNhomXuong.Rows(i).Item(0).ToString(), sKhu)
                    tblTamDDGiam = GoiThuTucThongKeTheoNhomXuongDDGiam(TabledvNhomXuong.Rows(i).Item(0).ToString(), sKhu)
                    TableGioCong.Merge(tblTam, True)
                    TableGioCong.Merge(tblTamDDGiam, True)
                    Me.ProgressBar2.Value = (100 * i) / tsdv
                    Me.ProgressBar2.Step = (100 * i) / tsdv
                    Me.ProgressBar2.PerformStep()
                Next
            End If

            If Me.radTangCaTong_DV.Checked Then
                ''======số giảm + số lượng xưởng gom lại trong thủ tục tính tổng =====''
                For i = 0 To Me.TabledvNhomXuong.Rows.Count - 1
                    tblTamDDGiam = GoiThuTucThongKeTheoNhomXuongDDGiam(TabledvNhomXuong.Rows(i).Item(0).ToString(), sKhu)
                    TableGioCong.Merge(tblTamDDGiam, True)
                    Me.ProgressBar2.Value = (100 * i) / tsdv
                    Me.ProgressBar2.Step = (100 * i) / tsdv
                    Me.ProgressBar2.PerformStep()
                Next

            End If
        Catch exception3 As Exception
            MessageBox.Show(exception3, "lỗi")
        End Try

        Dim grid As New clsTformatGrid
        If TableGioCong Is Nothing Then
        Else
            Dim stringSort As String = "XUONG ASC"
            TableGioCong.DefaultView.Sort = stringSort
            Me.dgrBC.DataSource = TableGioCong
            LoadGridView_GioCongNhomXuong()
        End If
    End Sub
    Private Sub LoadGridView_GioCongNhomXuong()
        Dim chuoitieude As String = ""
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            With Me.dgrBC.DisplayLayout.Bands(0)
                chuoitieude = "Danh sách giờ công theo nhóm xưởng :"
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Header.Tag = ""
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                Next
                Me.XpCaption2.Text = ""
                Select Case Me.UltraTabControl1.SelectedTab.Index
                    Case 0


                    Case 1
                        If Me.radA1A2.Checked Then
                            chuoitieude = chuoitieude + Me.radA1A2.Text
                        End If

                        If Me.radNhomA.Checked Then
                            chuoitieude = chuoitieude + " khu A "
                        End If

                        If Me.radNhomB.Checked Then
                            chuoitieude = chuoitieude + " khu B "
                        End If

                        If Me.radNhomDVC.Checked Then
                            chuoitieude = chuoitieude + " khu DVC "
                        End If


                        If Me.radTangCaChiTiet_DV.Checked Then

                            chuoitieude = chuoitieude + " trong giờ"
                            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                            .Columns("TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                            .Columns("TEN").Header.Caption = "Họ tên"
                            .Columns("SOTHE").Header.Caption = "Số thẻ"
                            .Columns("DONVI").Header.Caption = "Đơn vị"
                            .Columns("XUONG").Header.Caption = "Xưởng"
                            .Columns("NGAYVAO").Header.Caption = "Ngày vào"
                            .Columns("CV_TEN").Header.Caption = "Công việc"
                            .Columns("NAM").Header.Caption = "Năm"

                            .Columns("TONGBT").Header.Caption = "Tổng BT"
                            .Columns("TONGTC").Header.Caption = "Tổng Tăng Ca"
                            .Columns("DONVI").Width = 150
                            .Columns("XUONG").Width = 100

                            .Columns("STT").Header.VisiblePosition = 0
                            .Columns("TEN").Header.VisiblePosition = 1
                            .Columns("SOTHE").Header.VisiblePosition = 2
                            .Columns("DONVI").Header.VisiblePosition = 3
                            .Columns("NGAYVAO").Header.VisiblePosition = 4
                            .Columns("CV_TEN").Header.VisiblePosition = 5

                            .Columns("NAM").Header.VisiblePosition = 6
                            .Columns("XUONG").Header.VisiblePosition = 7
                            .Columns("TONGBT").Header.VisiblePosition = 8
                            .Columns("TONGTC").Header.VisiblePosition = 9

                            If Me.radTangCaChiTiet_DV.Checked Then
                                .Columns("STT").Hidden = True
                            Else
                                .Columns("STT").Hidden = False
                            End If
                        Else
                            chuoitieude = chuoitieude + " ngoài giờ"
                            If Me.radTangCaChiTiet_DV.Checked Then
                                .Columns("STT").Hidden = True
                                chuoitieude = chuoitieude + " bảng chi tiết "
                            Else
                                chuoitieude = chuoitieude + " bảng tổng "
                                .Columns("STT").Hidden = False
                                .Columns("TONGBT").Hidden = True
                                .Columns("XUONG").Header.Caption = "Xưởng"
                                .Columns("DONVI").Header.Caption = "Đơn vị"
                                .Columns("TONGBT").Header.Caption = "Tổng BT"
                                .Columns("TONGTC").Header.Caption = "Tổng Tăng Ca"
                            End If
                        End If
                End Select


                Me.XpCaption2.Text = chuoitieude
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
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(2)
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
    Private Function GoiThuTucThongKeTheoNhomXuong(ByVal donvitrongxuong As String, ByVal sKhu As String) As DataTable
        Dim dtTable As DataTable

        dTuNgay = Me.dtpTuNgay_DV.Value
        dDenNgay = Me.dtpDenngay_DV.Value

        sTuNgay = dTuNgay.Year.ToString() + "-" + dTuNgay.Month.ToString() + "-" + dTuNgay.Day.ToString()
        sDenNgay = dDenNgay.Year.ToString() + "-" + dDenNgay.Month.ToString() + "-" + dDenNgay.Day.ToString()
        sNgaydd = dNgaydd.Year.ToString() + "-" + dNgaydd.Month.ToString() + "-" + dNgaydd.Day.ToString()

        Select Case sKhu
            Case ""
                Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                  New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                  New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuong(0).Value = donvitrongxuong
                SqlParamXuong(1).Value = CDate(sTuNgay)
                SqlParamXuong(2).Value = CDate(sDenNgay)
                If Me.radTrongQD_DV.Checked Then
                    SqlParamXuong(3).Value = 1
                Else
                    SqlParamXuong(3).Value = 0
                End If
                dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_XUONG_MOI", SqlParamXuong)

            Case Else
                Dim SqlParamXuongKhu As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                  New SqlParameter("@KHU", SqlDbType.NVarChar, 50), _
                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                  New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                  New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuongKhu(0).Value = donvitrongxuong
                SqlParamXuongKhu(1).Value = sKhu
                SqlParamXuongKhu(2).Value = CDate(sTuNgay)
                SqlParamXuongKhu(3).Value = CDate(sDenNgay)
                If Me.radTrongQD_DV.Checked Then
                    SqlParamXuongKhu(4).Value = 1
                Else
                    SqlParamXuongKhu(4).Value = 0
                End If
                dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_KHU_S", SqlParamXuongKhu)
        End Select
        Return dtTable
    End Function
    Private Function GoiThuTucThongKeTheoNhomXuongDDGiam(ByVal donvitrongxuong As String, ByVal sKhu As String) As DataTable
        Dim dtTable As DataTable

        dTuNgay = Me.dtpTuNgay_DV.Value
        dDenNgay = Me.dtpDenngay_DV.Value

        sTuNgay = dTuNgay.Year.ToString() + "-" + dTuNgay.Month.ToString() + "-" + dTuNgay.Day.ToString()
        sDenNgay = dDenNgay.Year.ToString() + "-" + dDenNgay.Month.ToString() + "-" + dDenNgay.Day.ToString()
        sNgaydd = dNgaydd.Year.ToString() + "-" + dNgaydd.Month.ToString() + "-" + dNgaydd.Day.ToString()

        Select sKhu
            Case ""

                Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@XUONG", SqlDbType.NVarChar, 50), _
                                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                  New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                  New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuong(0).Value = donvitrongxuong
                SqlParamXuong(1).Value = CDate(sTuNgay)
                SqlParamXuong(2).Value = CDate(sDenNgay)
                If Me.radTrongQD_DV.Checked Then
                    SqlParamXuong(3).Value = 1
                Else
                    SqlParamXuong(3).Value = 0
                End If


                If Me.radTangCaChiTiet_DV.Checked Then
                    dtTable = Me.b.ThongKeGioCong("SP_THONGKECONG_THEODONVI_MOI", SqlParamXuong)
                Else
                    dtTable = Me.b.ThongKeGioCong("SP_THONGKECONG_THEODONVI_BANGTONG_MOI", SqlParamXuong)
                End If

            Case Else

                Dim SqlParamXuongKhu As SqlParameter() = {New SqlParameter("@XUONG", SqlDbType.NVarChar, 50), _
                                                  New SqlParameter("@KHU", SqlDbType.NVarChar, 50), _
                                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                  New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                  New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamXuongKhu(0).Value = donvitrongxuong
                SqlParamXuongKhu(1).Value = sKhu
                SqlParamXuongKhu(2).Value = CDate(sTuNgay)
                SqlParamXuongKhu(3).Value = CDate(sDenNgay)
                If Me.radTrongQD_DV.Checked Then
                    SqlParamXuongKhu(4).Value = 1
                Else
                    SqlParamXuongKhu(4).Value = 0
                End If

                If Me.radTangCaChiTiet_DV.Checked Then
                    dtTable = Me.b.ThongKeGioCong("SP_THONGKECONG_THEODONVI_KHU_S", SqlParamXuongKhu)
                Else
                    dtTable = Me.b.ThongKeGioCong("SP_THONGKECONG_THEODONVI_BANGTONG_KHU_S", SqlParamXuongKhu)
                End If
        End Select

        Return dtTable
    End Function

    Private Sub btnXemDiemDanh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemDiemDanh.Activate
        Dim obj As New objGiotangcathang
        Me.b = New clsBGiotangcathang
        ChonDD = False
        Dim frm As New frmNgayDiemDanh
        frm.ShowDialog()
        If frm.btOK Then
            'kiem tra ngay do co diem danh khong : LAY don vi KB, CNM
            obj.ChonBang = 66
            obj.Ngay = frm.dtpNgay.Value.Year.ToString() + "/" + frm.dtpNgay.Value.Month.ToString() + "/" + frm.dtpNgay.Value.Day.ToString()
            Me.ngaydiemdanh = obj.Ngay
            If b.LoadDS(obj).Rows.Count <= 0 OrElse b.LoadDS(obj) Is Nothing Then
                MessageBox.Show("Không tìm thấy dữ liệu điểm danh ngày này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                ChonDD = True
            End If

            If Me.cboXuong.Value Is Nothing Then
                Exit Sub
            Else
                Me.DonVi = Me.cboXuong.Value.ToString()
            End If
            If Me.DonVi = "TCT" Then
                obj.ChonBang = 10

            Else
                obj.ChonBang = 14
                obj.DONVI = Me.DonVi
            End If
            Laybangdulieu()
            Me.Tabledv = Me.b.LoadDS(obj)
            Me.taidulieudiemdanh()

            Dim grid As New clsTformatGrid
            Dim dgrBC As Object = Me.dgrBC

            If Me.Tabletk.Rows.Count > 0 Then
                Me.dgrBC.DataSource = Me.Tabletk
                grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrgiotangca")
            Else
                Me.dgrBC.DataSource = Nothing
            End If
            MessageBox.Show("Đã thống kê theo bảng điểm danh xong.", "Thông báo", MessageBoxButtons.OK)

        End If
    End Sub
    Public Sub taidulieudiemdanh()
        tsdv = Me.Tabledv.Rows.Count
        Me.b = New clsBGiotangcathang
        Me.d = New clsDGiotangcathang
        Dim tblTemp As DataTable
        'Me.TableGioCong = New DataTable()
        Me.Tabletk = New DataTable()
        Me.Tabletk.Clear()
        Me.Tabletk.Columns.Add("STT", GetType(Integer))
        Me.Tabletk.Columns("STT").AutoIncrement = True
        Me.Tabletk.Columns("STT").AutoIncrementSeed = 1
        Me.TextBox1.Visible = True

        For i = 0 To Me.Tabledv.Rows.Count - 1
            Me.laytext2(i)
            Me.TextBox1.Refresh()
            Try
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()
                tblTemp = Me.GoiThuTuc(Me.Tabledv.Rows(i).Item(0).ToString(), ChonDD)
                Me.Tabletk.Merge(tblTemp)
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                MessageBox.Show(exception3, "lỗi")
            End Try
            If Me.Tabledv.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Step = (100 * i) / tsdv
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If


        Next
        Me.TextBox1.Visible = False



    End Sub
    Private Function GoiThuTuc(ByVal donvitrongxuong As String, ByVal bChonDD As Boolean) As DataTable
        Dim dtTable As DataTable
        Dim dtTableTrong As DataTable
        Dim dtTableNgoai As DataTable
        dTuNgay = Me.dtpTungay.Value
        dDenNgay = Me.dtpDenngay.Value

        sTuNgay = dTuNgay.Year.ToString() + "-" + dTuNgay.Month.ToString() + "-" + dTuNgay.Day.ToString()
        sDenNgay = dDenNgay.Year.ToString() + "-" + dDenNgay.Month.ToString() + "-" + dDenNgay.Day.ToString()
        If ngaydiemdanh <> "" Then
            sNgaydd = CDate(Me.ngaydiemdanh).Year.ToString() + "-" + CDate(Me.ngaydiemdanh).Month.ToString() + "-" + CDate(Me.ngaydiemdanh).Day.ToString()
        End If

        dtTable = New DataTable()
        dtTable.Clear()

        'dtTable.Clear()
        'dtTableTrong.Clear()
        'dtTableNgoai.Clear()
        If Me.chkTongTheodonvi.Checked Then
            ''========= tổng theo từng đơnvi ==================''
            If bChonDD = False Then

                If Me.RadTrongNgoaiQD.Checked Then
                    If Me.cboXuong.Value.ToString() = "TCT" Then
                        Dim SqlParamTrNgoaiXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                                       New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                                       New SqlParameter("@NGAYKT", SqlDbType.Date)}
                        SqlParamTrNgoaiXuong(0).Value = donvitrongxuong
                        SqlParamTrNgoaiXuong(1).Value = CDate(sTuNgay)
                        SqlParamTrNgoaiXuong(2).Value = CDate(sDenNgay)

                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_TRONGNGOAIGIO_XUONG_MOI", SqlParamTrNgoaiXuong)
                    Else
                        Dim SqlParamTrNgoaiDonvi As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                    New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                    New SqlParameter("@NGAYKT", SqlDbType.Date)}
                        SqlParamTrNgoaiDonvi(0).Value = donvitrongxuong
                        SqlParamTrNgoaiDonvi(1).Value = CDate(sTuNgay)
                        SqlParamTrNgoaiDonvi(2).Value = CDate(sDenNgay)
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_TRONGNGOAIGIO_XUONG_MOI", SqlParamTrNgoaiDonvi)
                    End If
                Else
                    If Me.cboXuong.Value.ToString() = "TCT" Then
                        ''=============== tham số xưởng =====''
                        Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                         New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                         New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                         New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamXuong(0).Value = donvitrongxuong
                        SqlParamXuong(1).Value = CDate(sTuNgay)
                        SqlParamXuong(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamXuong(3).Value = 1
                        Else
                            SqlParamXuong(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_XUONG_MOI", SqlParamXuong)
                    Else
                        ''=============== tham số đơn vị =====''
                        Dim SqlParamDonvi As SqlParameter() = {New SqlParameter("@DV_MA", SqlDbType.NVarChar, 50), _
                                                        New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                        New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                        New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamDonvi(0).Value = donvitrongxuong
                        SqlParamDonvi(1).Value = CDate(sTuNgay)
                        SqlParamDonvi(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamDonvi(3).Value = 1
                        Else
                            SqlParamDonvi(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVI_MOI", SqlParamDonvi)

                    End If
                End If
            Else
                ''======= tổng đơn vị theo điểm danh ====''
                ''============ tham số điểm danh =======''
                Dim SqlParamDiemDanh As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                       New SqlParameter("@NGAYDD", SqlDbType.Date), _
                                                       New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                       New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                       New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                SqlParamDiemDanh(0).Value = donvitrongxuong
                SqlParamDiemDanh(1).Value = CDate(sNgaydd)
                SqlParamDiemDanh(2).Value = CDate(sTuNgay)
                SqlParamDiemDanh(3).Value = CDate(sDenNgay)

                If Me.RadTrongQD.Checked Then
                    SqlParamDiemDanh(4).Value = 1
                Else
                    SqlParamDiemDanh(4).Value = 0
                End If
                dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_DONVIDD_MOI", SqlParamDiemDanh)
            End If

        ElseIf Me.Chktheothang.Checked = False AndAlso Me.chkGioTangCa.Checked = True Then
            ''========= tổng theo từng số thẻ ==================''
            If bChonDD = False Then
                If Me.RadTrongNgoaiQD.Checked Then
                    Dim c_dataSetGioCong As New DataSet()
                    If Me.cboXuong.Value.ToString() = "TCT" Then
                        Dim SqlParamTrNgoaiXuong1 As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                                       New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                                       New SqlParameter("@NGAYKT", SqlDbType.Date)}

                        SqlParamTrNgoaiXuong1(0).Value = donvitrongxuong
                        SqlParamTrNgoaiXuong1(1).Value = CDate(sTuNgay)
                        SqlParamTrNgoaiXuong1(2).Value = CDate(sDenNgay)
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_TRONGNGOAIGIO_XUONG_MOI", SqlParamTrNgoaiXuong1)

                        ''=============================
                        'Dim SqlParamTrNgoaiXuong2 As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                        '                       New SqlParameter("@NGAYBD", SqlDbType.Date), _
                        '                       New SqlParameter("@NGAYKT", SqlDbType.Date), _
                        '                       New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        'SqlParamTrNgoaiXuong2(0).Value = donvitrongxuong
                        'SqlParamTrNgoaiXuong2(1).Value = CDate(sTuNgay)
                        'SqlParamTrNgoaiXuong2(2).Value = CDate(sDenNgay)
                        'SqlParamTrNgoaiXuong2(3).Value = 0

                        'dtTableNgoai = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_XUONG_MOI1", SqlParamTrNgoaiXuong2)

                        'If Not dtTableTrong Is Nothing Then
                        '    c_dataSetGioCong.Tables.Add(dtTableTrong)
                        'End If

                        'If Not dtTableNgoai Is Nothing Then
                        '    c_dataSetGioCong.Tables.Add(dtTableNgoai)
                        'End If

                        'Dim relGioCong As New DataRelation("GioCongTrongNgoai", dtTableTrong.Columns("SOTHE"), dtTableNgoai.Columns("SOTHE"), False)
                        'c_dataSetGioCong.Relations.Add(relGioCong)

                        'Dim da As New SqlDataAdapter
                        'Dim [set] As DataSet
                        'dtTable = New DataTable()
                        'dtTable.Clear()

                        ''[set] = New DataSet
                        ''da.Fill(c_dataSetGioCong)

                        'dtTable = c_dataSetGioCong.Tables(0)
                        'c_dataSetGioCong.Tables(0).Columns.Add(dtTableNgoai.Columns("TONGTC1"))
                        ''dtTable.Merge(dtTableTrong, True)
                        ''dtTable.Merge(dtTableNgoai, True)
                        'Me.dgrBC.DataSource = c_dataSetGioCong
                    Else
                        Dim SqlParamTrNgoaiDonvi As SqlParameter() = {New SqlParameter("@DV_MA", SqlDbType.NVarChar, 50), _
                                                  New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                  New SqlParameter("@NGAYKT", SqlDbType.Date)}
                        SqlParamTrNgoaiDonvi(0).Value = donvitrongxuong
                        SqlParamTrNgoaiDonvi(1).Value = CDate(sTuNgay)
                        SqlParamTrNgoaiDonvi(2).Value = CDate(sDenNgay)
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_TRONGNGOAIGIO_DONVI_MOI", SqlParamTrNgoaiDonvi)
                    End If
                Else
                    If Me.cboXuong.Value.ToString() = "TCT" Then
                        ''=============== tham số xưởng =====''
                        Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                         New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                         New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                         New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamXuong(0).Value = donvitrongxuong
                        SqlParamXuong(1).Value = CDate(sTuNgay)
                        SqlParamXuong(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamXuong(3).Value = 1
                        Else
                            SqlParamXuong(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_XUONG_MOI", SqlParamXuong)

                    Else
                        Dim SqlParamDonvi As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                        New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                        New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                        New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamDonvi(0).Value = donvitrongxuong
                        SqlParamDonvi(1).Value = CDate(sTuNgay)
                        SqlParamDonvi(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamDonvi(3).Value = 1
                        Else
                            SqlParamDonvi(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NV_XUONG_MOI", SqlParamDonvi)
                    End If
                End If
            Else
                If Me.cboXuong.Value.ToString() = "TCT" Then
                    Dim SqlParamDiemDanh As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                      New SqlParameter("@NGAYDD", SqlDbType.Date), _
                                      New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                      New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                      New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                    SqlParamDiemDanh(0).Value = donvitrongxuong
                    SqlParamDiemDanh(1).Value = CDate(sNgaydd)
                    SqlParamDiemDanh(2).Value = CDate(sTuNgay)
                    SqlParamDiemDanh(3).Value = CDate(sDenNgay)

                    If Me.RadTrongQD.Checked Then
                        SqlParamDiemDanh(4).Value = 1
                    Else
                        SqlParamDiemDanh(4).Value = 0
                    End If
                    dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NVDD_MOI", SqlParamDiemDanh)

                Else
                    Dim SqlParamDiemDanh As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                      New SqlParameter("@NGAYDD", SqlDbType.Date), _
                                      New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                      New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                      New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                    SqlParamDiemDanh(0).Value = donvitrongxuong
                    SqlParamDiemDanh(1).Value = CDate(sNgaydd)
                    SqlParamDiemDanh(2).Value = CDate(sTuNgay)
                    SqlParamDiemDanh(3).Value = CDate(sDenNgay)

                    If Me.RadTrongQD.Checked Then
                        SqlParamDiemDanh(4).Value = 1
                    Else
                        SqlParamDiemDanh(4).Value = 0
                    End If
                    dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_TONG_NVDD_XUONG_MOI", SqlParamDiemDanh)

                End If

            End If
        Else
            ''========= tổng theo từng tháng ==================''
            If bChonDD = False Then
                If Me.RadTrongNgoaiQD.Checked Then
                    Dim SqlParamTrNgoaiDonvi As SqlParameter() = {New SqlParameter("@DV_MA", SqlDbType.NVarChar, 50), _
                                                 New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                 New SqlParameter("@NGAYKT", SqlDbType.Date)}
                    SqlParamTrNgoaiDonvi(0).Value = donvitrongxuong
                    SqlParamTrNgoaiDonvi(1).Value = CDate(sTuNgay)
                    SqlParamTrNgoaiDonvi(2).Value = CDate(sDenNgay)

                    dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_THEOTHANG_TRONGGIONGOAIGIO_DONVI_MOI", SqlParamTrNgoaiDonvi)
                Else
                    If Me.cboXuong.Value.ToString() = "TCT" Then
                        Dim SqlParamXuong As SqlParameter() = {New SqlParameter("@X_MA", SqlDbType.NVarChar, 50), _
                                                      New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                      New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                      New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamXuong(0).Value = donvitrongxuong
                        SqlParamXuong(1).Value = CDate(sTuNgay)
                        SqlParamXuong(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamXuong(3).Value = 1
                        Else
                            SqlParamXuong(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_DONVI_THEOTHANG_XUONG_MOI", SqlParamXuong)
                    Else
                        Dim SqlParamDonvi As SqlParameter() = {New SqlParameter("@DV_MA", SqlDbType.NVarChar, 50), _
                                                        New SqlParameter("@NGAYBD", SqlDbType.Date), _
                                                        New SqlParameter("@NGAYKT", SqlDbType.Date), _
                                                        New SqlParameter("@CHONTRONGQUYDINH", SqlDbType.Bit)}
                        SqlParamDonvi(0).Value = donvitrongxuong
                        SqlParamDonvi(1).Value = CDate(sTuNgay)
                        SqlParamDonvi(2).Value = CDate(sDenNgay)

                        If Me.RadTrongQD.Checked Then
                            SqlParamDonvi(3).Value = 1
                        Else
                            SqlParamDonvi(3).Value = 0
                        End If
                        dtTable = Me.b.ThongKeGioCong("SP_GIOTANGCATHANG_DONVI_THEOTHANG_MOI", SqlParamDonvi)
                    End If
                End If
            Else
                'dtTable = Me.b.GoiThuTucThongKeGioCong("SP_GIOTANGCATHANG_DONVIDD_THEOTHANG_MOI", listpar)
            End If

        End If

        Return dtTable
    End Function
End Class