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
Public Class frmChamCom
    Dim Tabletemp As DataTable
    Dim TabletempDV As DataTable
    Dim TableND As DataTable
    Friend WithEvents b As clsBChamCom
    Public bLoad As Boolean = False
    Public fWaiting As frmWaiting_GC
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.b = New clsBChamCom
        Dim NgayCC As Date
        NgayCC = Me.dtpNgay.Value
        Dim obj As New objChamCom
        obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
        obj.Nam = NgayCC.Year.ToString()
        obj.Thang = NgayCC.Month.ToString()

        Dim tamDVNghiViec As DataTable

        If Me.radKhuA.Checked Then
            obj.ChonKhu = "CHONRADIOKHUA"
        End If

        If Me.radKhuB.Checked Then
            obj.ChonKhu = "CHONRADIOKHUB"
        End If
        If Me.radKhuDVC.Checked Then
            obj.ChonKhu = "CHONRADIODVC"
        End If
        If Me.radTCT.Checked Then
            obj.ChonKhu = "CHONRADIOTCT"
        End If
        



        Select Case Me.cbDonvi.Value
            Case "KHUA", "KHUB", "KHUDVC", "TCT"
                fWaiting = frmWaiting_GC.ShowProgress(Me)

            Case Else

        End Select


        If Me.cbDonvi.SelectedIndex <> -1 Then
            obj.DonVi = Me.cbDonvi.Value.ToString()
            obj.ChonBang = 20
            tamDVNghiViec = Me.b.LoadDS(obj)

            If tamDVNghiViec.Rows.Count > 0 Then
                ''==== lọc danh sách đơn vị loại nghỉ việc chọn theo cột DV_MA 
                obj.LoaiDonViNghiViec = 1
            Else
                obj.LoaiDonViNghiViec = 0
            End If

            'Don Vi Checked
            If Me.rdDonvi.Checked = True Then
                obj.ChonBang = 2
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            Else
                If Me.rdDonviNV.Checked = True Then
                    obj.ChonBang = 4
                    Me.Tabletemp = Me.b.LoadDS(obj)
                    Locdulieu(Me.Tabletemp)
                End If
            End If
        Else
            obj.ChonBang = 3
            Me.Tabletemp = Me.b.LoadDS(obj)
        End If

        Select Case cbDonvi.Value
            Case "KHUA", "KHUB", "KHUDVC", "TCT"

                fWaiting.CloseProgress()
                Me.cbDonvi.DroppedDown = False
            Case Else
                If Me.rdDonviNV.Checked = True Then
                    btGioTangCaDV.PerformClick()
                End If

                If Me.rdDonvi.Checked = True Then
                    Me.btGioTangCa.PerformClick()
                End If
        End Select
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Try
            Dim grid As New clsTformatGrid
            Me.dgrBC.DataSource = TableDS
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ChamCom.xml"), typeControl.Grid, "coldgrChamcongmain")
            Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
            band.Layout.Bands(0).Summaries.Clear()
            Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns("NV_TEN")
            band.Layout.Bands(0).Summaries.Clear()
            Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng số :", SummaryType.Count, columnToSummarize)
            summary.Appearance.TextHAlign = HAlign.Right
            band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            band.SummaryFooterCaption = "Tổng số: "
            band = Nothing

            Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
            If TableDS.Rows.Count > 0 Then
                If TableDS.Rows.Count < oldRow Then
                    Exit Sub
                Else
                    Me.dgrBC.Rows(oldRow).Activated = True
                End If
            End If
        Catch ex As Exception
        Finally

        End Try
        
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

    Private Sub ChonDongCu()
        If Me.dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        End If
    End Sub

    Dim oldRow As Integer = 0
    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        If bLoad Then
            Me.oldRow = 0
            Me.Tim()
        End If
    
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If bLoad Then
            'If Me.rdDonvi.Checked = True Then
            Me.oldRow = 0
            Me.Tim()
            'End If
        End If
       
    End Sub

    Private Sub linkChamComTay_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkChamComTay.LinkClicked
        Dim report As New frmReportChamCong
        report.LoaiReport = 4
        report.Show()
    End Sub

    Private Sub linkChamCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkChamCom.LinkClicked
        Dim report As New frmBangChamCom
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub linkChamComTuDong_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkChamComTuDong.LinkClicked
        If (MessageBox.Show(("Bạn có chắc đã chấm công rồi chưa?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            ChamComTuDong()
        End If
    End Sub
    Public Shared obj As New objChamCom
    Private Sub ChamComTuDong()
        Dim listpar As New ArrayList(1)

        Dim NGAY As Date
        NGAY = dtpNgay.Text
        Dim ngaycc As String = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        If Me.radKhuA.Checked = True Then
            obj.ChonKhu = "A"
        End If
        If Me.radKhuB.Checked = True Then
            obj.ChonKhu = "B"
        End If
        If Me.radKhuDVC.Checked = True Then
            obj.ChonKhu = "DVC"
        End If
     
        If NGAY < Now.Date Then
            obj.NgayChamCong = ngaycc
            listpar.Add(New SqlParameter("@Ngay", obj.NgayChamCong))
            listpar.Add(New SqlParameter("@KHU", obj.ChonKhu))
            Me.b.GoiThuTuc("SP_CHAMCOM_TUDONG1", listpar)
            listpar.Clear()
            MessageBox.Show("Đã chấm cơm khu " + obj.ChonKhu + " thành công")
        Else
            MessageBox.Show("Ngày chấm cơm phải nhỏ hơn ngày hiện tại")
        End If

    End Sub

    Private Sub rdDonviNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonviNV.CheckedChanged
        If bLoad Then
            If Me.rdDonviNV.Checked = True Then
                Me.oldRow = 0
                Me.Tim()
            End If
        End If
    
    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        If bLoad Then
            If Me.rdDonvi.Checked = True Then
                Me.oldRow = 0
                Me.Tim()
            End If
        End If
        
    End Sub

    Private Sub frmChamCom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
        Me.b = New clsBChamCom
        Dim i As Integer
        Dim obj As New objChamCom
        obj.ChonBang = 1
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0
        bLoad = True
        Me.radTCT.Checked = True
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("GIOVAOTAY").Header.Appearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("GIORATAY").Header.Appearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("GIOVAOTAY").CellAppearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("GIORATAY").CellAppearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("CC_SUATAN").Header.Appearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("CC_SUATAN").Header.Appearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("TONGGIOTC").CellAppearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("CHENHLECH").CellAppearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0


        Dim i As Integer
        For i = 0 To 21
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
        e.Layout.Bands(0).Columns("3").Hidden = False

    End Sub
    Private Sub EditChamCom()
        'Load nhan vien co ma so tai ngay cham cong
        Dim ngaycn As String
        Dim nguoicn As String
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

        obj.NGAYCN = ngaycn
        obj.NGUOICN = nguoicn

        obj.ChonBang = 5
        Me.b = New clsBChamCom
        Me.Tabletemp = Me.b.LoadDS(obj)
        If Me.Tabletemp.Rows.Count > 0 Then
            obj.ChonBang = 2
            Me.b.UpdateInfo(obj)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        Dim frm As New frmBuaAn
                        frm.ShowDialog()
                        If frm.radTuDong.Checked = True And Me.chkThang.Checked = False Then
                            If (MessageBox.Show(("Bạn có muốn cập nhật suất ăn không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                Me.dgrBC.UpdateData()
                                obj.Setnull()
                                obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                                obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                                CapNhatCom()
                                Dim ngaycn As String
                                Dim nguoicn As String
                                nguoicn = MAIN.userclient
                                Dim ngaycn1 As DateTime = Now()
                                ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                                obj.NGAYCN = ngaycn
                                obj.NGUOICN = nguoicn
                                obj.ChonBang = 4
                                Me.b.UpdateInfo(obj)
                       
                                MessageBox.Show("Đã cập nhật thành công")
                                Me.Tim()
                                Me.ChonDongCu()
                            Else
                                Exit Sub
                            End If
                        ElseIf frm.radSoBuaan.Checked = True And Me.chkThang.Checked = False Then
                            Me.dgrBC.UpdateData()

                            obj.ChamCom = frm.txtSoBuaAn.Text
                            obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                            obj.CA_Ma = activeCell.Row.Cells.Item("MACA").Text

                            EditChamCom()
                            MessageBox.Show("Đã cập nhật thành công")
                            Me.Tim()
                            Me.ChonDongCu()
                        ElseIf frm.radSoBuaan.Checked = True And Me.chkThang.Checked = True Then
                            Dim ngay1 As Date
                            Dim ngay2 As Date
                            Me.dgrBC.UpdateData()
                            obj.ChamCom = frm.txtSoBuaAn.Text
                            obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                            obj.CA_Ma = activeCell.Row.Cells.Item("MACA").Text
                            ngay1 = ngaydt
                            ngay2 = ngayct
                            While ngay1 <= ngay2
                                Dim ngaychunhat As Integer
                                Dim ngay As String
                                ngaychunhat = Microsoft.VisualBasic.DatePart(DateInterval.Weekday, ngay1)
                                If ngaychunhat <> 1 Then
                                    ngay = ngay1.Year.ToString() + "/" + ngay1.Month.ToString() + "/" + ngay1.Day.ToString()
                                    obj.Ngay = ngay
                                    EditChamCom()
                                End If
                                ngay1 = DateAdd(DateInterval.Day, 1, ngay1)
                            End While
                            MessageBox.Show("Đã cập nhật thành công")
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
                    End If
                Case "3"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                            Dim obj As New objChamCom
                            obj.Setnull()
                            obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                            obj.ChonBang = 1
                            Me.b.DeleteInfo(obj)
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
                    End If
               
            End Select
        End If
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
    Public Sub CapNhatCom()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@Ngay", obj.Ngay))
        listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
        Me.b.GoiThuTuc("SP_CAPNHATSUATAN", listpar)
        listpar.Clear()
    End Sub
    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click

        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Dim frm As New frmBuaAn
            frm.ShowDialog()
            If frm.radTuDong.Checked = True And Me.chkThang.Checked = False Then
                If (MessageBox.Show(("Bạn có muốn cập nhật suất ăn không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.dgrBC.UpdateData()
                    obj.Setnull()
                    obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim i As Integer = 0
                    While i <= Me.dgrBC.Rows.Count - 1
                        If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                            obj.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                            CapNhatCom()
                            Dim ngaycn As String
                            Dim nguoicn As String
                            nguoicn = MAIN.userclient
                            Dim ngaycn1 As DateTime = Now()
                            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                            obj.NGAYCN = ngaycn
                            obj.NGUOICN = nguoicn
                            obj.ChonBang = 4
                            Me.b.UpdateInfo(obj)
                        End If
                        i = i + 1
                    End While
                    MessageBox.Show("Đã cập nhật thành công")
                    Me.Tim()
                    Me.ChonDongCu()
                Else
                    Exit Sub
                End If
            ElseIf frm.radSoBuaan.Checked = True And Me.chkThang.Checked = False Then
                Me.dgrBC.UpdateData()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        obj.ChamCom = frm.txtSoBuaAn.Text
                        obj.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        obj.CA_Ma = Me.dgrBC.Rows(i).Cells("MACA").Text

                        EditChamCom()
                    End If
                    i = i + 1
                End While
                MessageBox.Show("Đã cập nhật thành công")
                Me.Tim()
                Me.ChonDongCu()
            ElseIf frm.radSoBuaan.Checked = True And Me.chkThang.Checked = True Then
                Me.dgrBC.UpdateData()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        obj.ChamCom = frm.txtSoBuaAn.Text
                        obj.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        obj.CA_Ma = Me.dgrBC.Rows(i).Cells("MACA").Text
                        Dim ngay1 As Date
                        Dim ngay2 As Date
                        ngay1 = ngaydt
                        ngay2 = ngayct
                        While ngay1 <= ngay2
                            Dim ngaychunhat As Integer
                            Dim ngay As String
                            ngaychunhat = Microsoft.VisualBasic.DatePart(DateInterval.Weekday, ngay1)
                            If ngaychunhat <> 1 Then
                                ngay = ngay1.Year.ToString() + "/" + ngay1.Month.ToString() + "/" + ngay1.Day.ToString()
                                obj.Ngay = ngay
                                EditChamCom()
                            End If
                            ngay1 = DateAdd(DateInterval.Day, 1, ngay1)
                        End While
                    End If
                    i = i + 1
                End While
                MessageBox.Show("Đã cập nhật thành công")
                Me.Tim()
                Me.ChonDongCu()
            End If
        End If
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else

            Dim frm As New frmBuaAn
            frm.ShowDialog()
            If frm.radTuDong.Checked = True And Me.chkThang.Checked = False Then
                If (MessageBox.Show(("Bạn có muốn cập nhật suất ăn không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.dgrBC.UpdateData()
                    obj.Setnull()
                    obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim i As Integer = 0
                    While i <= Me.dgrBC.Rows.Count - 1
                        obj.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        CapNhatCom()
                        Dim ngaycn As String
                        Dim nguoicn As String
                        nguoicn = MAIN.userclient
                        Dim ngaycn1 As DateTime = Now()
                        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                        obj.NGAYCN = ngaycn
                        obj.NGUOICN = nguoicn
                        obj.ChonBang = 4
                        Me.b.UpdateInfo(obj)
                        i = i + 1
                    End While
                    MessageBox.Show("Đã cập nhật thành công")
                    Me.Tim()
                    Me.ChonDongCu()
                Else
                    Exit Sub
                End If
            ElseIf frm.radSoBuaan.Checked = True And Me.chkThang.Checked = False Then
                Me.dgrBC.UpdateData()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    obj.ChamCom = frm.txtSoBuaAn.Text
                    obj.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    obj.CA_Ma = Me.dgrBC.Rows(i).Cells("MACA").Text

                    EditChamCom()
                    i = i + 1
                End While
                MessageBox.Show("Đã cập nhật thành công")
                Me.Tim()
                Me.ChonDongCu()
            End If
        End If
    End Sub
    Dim ngaydt As Date
    Dim ngayct As Date
    Private Sub chkThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThang.CheckedChanged
        If Me.chkThang.Checked = True Then
            Dim TableThang As New DataTable()
            Dim thang As String
            Dim nam As String
           
            thang = Month(Me.dtpNgay.Value)
            nam = Year(Me.dtpNgay.Value)
            obj.ChonBang = 16
            If Len(thang) = 1 Then
                thang = "0" + thang
            Else
                thang = thang
            End If
            obj.Thang = thang + "-" + nam
            Me.b = New clsBChamCom
            TableThang = Me.b.LoadDS(obj)
            If TableThang.Rows.Count > 0 Then
                ngaydt = TableThang.Rows(0).Item("T_TUNGAY").ToString
                ngayct = TableThang.Rows(0).Item("T_DENNGAY").ToString
            End If
        End If
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub lnkLayDuLieu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLayDuLieu.LinkClicked
        obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                   If Me.radKhuA.Checked = True Then
            obj.ChonKhu = "A"
        End If
        If Me.radKhuB.Checked = True Then
            obj.ChonKhu = "B"
        End If
        If Me.radKhuDVC.Checked = True Then
            obj.ChonKhu = "DVC"
        End If
        If (MessageBox.Show(("Bạn có muốn lấy dữ liệu khu " + obj.ChonKhu + " ngày " + obj.Ngay + " không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            Dim ngaycn As String
            Dim nguoicn As String
            nguoicn = MAIN.userclient
            Dim ngaycn1 As DateTime = Now()
            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

            obj.NGAYCN = ngaycn
            obj.NGUOICN = nguoicn
            Dim TableKhongAnCom As New DataTable()
            obj.ChonBang = 17
            Me.b = New clsBChamCom
            TableKhongAnCom = Me.b.LoadDS(obj)
            If TableKhongAnCom.Rows.Count > 0 Then
                obj.ChonBang = 3
                Me.b.UpdateInfo(obj)
                MessageBox.Show("Đã cập nhật thành công")
            End If
        Else

            Exit Sub
        End If
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        If bLoad Then
            Dim obj As New objChamCom
            Me.b = New clsBChamCom
            oldRow = 0
            Tabletemp = Nothing
            If Me.radKhuA.Checked Then
                obj.ChonBang = 21
                Me.Tabletemp = Me.b.LoadDS(obj)
                Me.Tabletemp.Rows.Add("KHUA", "Toàn bộ khu A")
                Me.cbDonvi.DataSource = Me.Tabletemp

                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        End If
       
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        If bLoad Then


            Dim obj As New objChamCom
            Me.b = New clsBChamCom
            oldRow = 0
            Tabletemp = Nothing
            If Me.radKhuB.Checked Then
                obj.ChonBang = 22
                Me.Tabletemp = Me.b.LoadDS(obj)

                Me.Tabletemp.Rows.Add("KHUB", "Toàn bộ khu B")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.SelectedIndex = 0
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        End If
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        If bLoad Then
            Dim obj As New objChamCom
            Me.b = New clsBChamCom
            oldRow = 0
            Tabletemp = Nothing
            If Me.radTCT.Checked Then
                obj.ChonBang = 1
                Me.Tabletemp = Me.b.LoadDS(obj)
                Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        End If
    End Sub

    Private Sub radKhuDVC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuDVC.CheckedChanged
        If bLoad Then
            Dim obj As New objChamCom
            Me.b = New clsBChamCom
            oldRow = 0
            Tabletemp = Nothing
            If Me.radKhuDVC.Checked Then
                obj.ChonBang = 23
                Me.Tabletemp = Me.b.LoadDS(obj)
                Me.Tabletemp.Rows.Add("KHUDVC", "Toàn bộ khu DVC")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        End If
    End Sub
End Class