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
Public Class frmLocExcel
    Public obj As New ObjTheoDoiMangThaiDenNC12Thang
    Public b As New clsBTheoDoiMangThaiDenNC12Thang
    Public Path As String
    Public frmTheodoimangthainc As New frmTheoDoiMangThaiDenNC12Thang
    Public Shared tbleChiTraKDung As DataTable
    Public chon As Boolean
    Public FlagDsHl As Boolean = True
    Public tableDSKDung As DataTable
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        If (MessageBox.Show(("Bạn có muốn cập nhật thông tin chi trả ngày vào hệ thống? "), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            obj.ChonBang = 6
            If Me.b.UpdateInfo(obj) Then
                MessageBox.Show("Đã cập nhật thành công!")
                chon = True
            Else
                MessageBox.Show("Cập nhật không thành công!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error)
                chon = False
            End If
        End If
        ''HIEN THI NHUNG DONG KHONG CAP NHAT DO NGAY KHAM THAI KHONG DUNG
        TimNgayKhamThai()
    End Sub
    Private Sub TimNgayKhamThai()
        obj.ChonBang = 20
        ''CAP NHAT TRANG THAI NHUNG NGUOI KHONG TIM THAY NGAY KHAM THAI TRONG BANG PHEP 
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            obj.ChonBang = 7
            Me.b.UpdateInfo(obj)
            If (MessageBox.Show(("Hiển thị danh sách ngày khám thai không hợp lệ? "), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                ''hien thi danh sach các ngày khám thai khong tim thay trong chuong trinh nhap phep
                FlagDsHl = True
                Dim grid As New clsTformatGrid
                Dim Path As String
                Me.b = New clsBTheoDoiMangThaiDenNC12Thang
                obj.ChonBang = 20
                Me.XpCaption2.Text = "Danh sách ngày khám thai không được tìm thấy trong hệ thống."
                Me.Path = "/layout/ThongtinchitraExcel.xml"
                Me.dgrChiTra.DataSource = Me.b.LoadDS(obj)
                Dim dgrBC As Object = Me.dgrChiTra
                grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
            End If
        End If
    End Sub
    Private Sub dgrChiTra_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrChiTra.InitializeLayout
        Dim i As Integer
        Dim band As UltraGridBand = Me.dgrChiTra.DisplayLayout.Bands.Item(0)
        If Me.dgrChiTra.Rows.Count > 0 Then
            If Me.FlagDsHl Then
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
                Next
                dgrChiTra.DisplayLayout.Bands(0).Columns("NGAYKHAMDOILAI").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            Else
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
                    e.Layout.Bands(0).Columns("STT").Hidden = True
                Next
                e.Layout.Bands(0).Columns("NGAYKHAM").CellActivation = Activation.NoEdit
                e.Layout.Bands(0).Columns("NGAYKHAMDOILAI").CellActivation = Activation.AllowEdit
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
                band.Layout.Bands(0).Summaries.Clear()
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số dòng không hợp lệ: "
            End If
        End If
    End Sub
    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrChiTra.InitializeRow
        If Me.FlagDsHl Then
            e.Row.Cells("STT").Value = e.Row.Index + 1
            e.Row.Update()
        End If
    End Sub
    Private Sub HienDSDung()
        ''hien thi danh sach
        Dim grid As New clsTformatGrid
        Dim Path As String
        Me.b = New clsBTheoDoiMangThaiDenNC12Thang
        obj.ChonBang = 18
        Me.Path = "/layout/ThongtinchitraExcel.xml"
        Me.dgrChiTra.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrChiTra
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.FlagDsHl = True
    End Sub
    Private Sub HienDSKDung()
        ''hien thi dong khong hop le
        'tbleChiTraKDung.Columns.Add("STT", Type.GetType("System.String"))
        Me.dgrChiTra.DataSource = Me.tbleChiTraKDung
        tableDSKDung = tbleChiTraKDung
        Me.FlagDsHl = False
    End Sub
    Private Sub tabCapNhatChiTra_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabCapNhatChiTra.SelectedTabChanged
        Select Case Me.tabCapNhatChiTra.SelectedTab.Index
            Case 0
                ''---------- danh sach hop le ------------
                Me.dgrChiTra.DataSource = Nothing
                Me.btnCapnhatTam.Visible = False
                Me.btnLuu.Visible = True
                Me.btnSua.Visible = False
                HienDSDung()
                Me.FlagDsHl = True

            Case 1
                ''---------- danh sach khong hop le ------------
                Me.dgrChiTra.DataSource = Nothing
                Me.btnCapnhatTam.Visible = True
                Me.btnLuu.Visible = False
                Me.btnSua.Visible = True
                Me.FlagDsHl = False
                Me.HienDSKDung()
        End Select
    End Sub
    Private Sub frmLocExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''============ hop le thong tin so the co 5 so ================= ''
        Me.obj.ChonBang = 2
        Me.b.UpdateInfo(obj)
        Me.obj.ChonBang = 3
        Me.b.UpdateInfo(obj)
        Me.obj.ChonBang = 4
        Me.b.UpdateInfo(obj)
        Me.obj.ChonBang = 5
        Me.b.UpdateInfo(obj)
        Me.obj.ChonBang = 8
        Me.b.UpdateInfo(obj)
        HienDSDung()
    End Sub
    Private Sub btnCapnhatTam_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhatTam.Activate
        Dim ngaydoi As Date
        Dim i As Integer
        Dim sothe As String
        Dim ngaykh As String
        Dim sotien As Integer
        If (MessageBox.Show(("Bạn có muốn cập nhật lại các ngày chi trả vào danh sách hợp lệ? "), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            obj.ChonBang = 1
            ''duyet luoi danh sach ngay kham thai bo trong
            For i = 0 To tableDSKDung.Rows.Count - 1
                Try
                    sothe = tableDSKDung.Rows(i).Item("SOTHE").ToString()
                    ngaydoi = Convert.ToDateTime(tableDSKDung.Rows(i).Item("NGAYKHAMDOILAI").ToString())
                    ngaykh = ngaydoi.Year.ToString() + "-" + ngaydoi.Month.ToString() + "-" + ngaydoi.Day.ToString()
                    obj.NV_MA = sothe
                    obj.NgayKhamThaiDoi = ngaykh
                    obj.SoTienCT_CN = sotien
                    Me.b.InsertNgayKhamMoiSua(obj)
                Catch ex As Exception
                    MessageBox.Show("Không hiểu định dạng ngày tháng năm cột ngày khám đổi lại.")
                End Try
            Next
            MessageBox.Show("Đã cập nhật sang danh sách file Excel hợp lệ.")
            If Me.tabCapNhatChiTra.ActiveTab.Index <> -1 Then
                Select Case Me.tabCapNhatChiTra.SelectedTab.Index
                    Case 0
                        Me.HienDSDung()
                    Case 1
                        Me.dgrChiTra.DataSource = Nothing
                End Select
            End If

        End If
    End Sub
    Private Sub btnEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrChiTra, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class