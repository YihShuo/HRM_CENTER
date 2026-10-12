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
Imports Infragistics.Win.UltraMessageBox
Imports TongHop.clsTools

Public Class frmChamcongMain
    Public bLoad As Boolean = False
    Public fWaiting As frmWaiting_GC
    Public bVe15h30 As Boolean = False
    Dim Tabletemp1 As DataTable
    Dim ngayCT As String
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChamcongMain))
    Private Sub frmChamcongMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        Me.dtpNgay.Value = Now
        Me.b = New clsBChamcongMain
        Dim i As Integer
        Dim obj As New objChamcongMain
        obj.ChonBang = 1
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0
        bLoad = True
        Me.radTCT.Checked = True

        '' LẤY NGÀY ĐẦU THÁNG NGÀY CUỐI THÁNG

        Dim thang As String
        Dim thang2 As String
        Dim ngayht As String
        thang = Me.dtpNgay.Value.Month.ToString()
        If Len(thang) = 1 Then
            thang2 = "0" + thang
        Else
            thang2 = thang
        End If
        obj.ChonBang = 25
        obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
        ngayht = Me.dtpNgay.Value.Year.ToString() + "/" + thang2 + "/" + Me.dtpNgay.Value.Day.ToString()
        Me.Tabletemp1 = Me.b.LoadDS(obj)
        Me.ngayCT = Tabletemp1.Rows(0).Item("T_DENNGAY").ToString()
        If ngayht = Me.ngayCT.Trim() Then
            Me.linkKhoaBC.ForeColor = Color.Red
        Else
            Me.linkKhoaBC.ForeColor = Color.Blue
        End If


    End Sub
    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        If bLoad Then
            Me.oldRow = 0
            Dim thang As String
            Dim thang2 As String
            Dim ngayht As String
            thang = Me.dtpNgay.Value.Month.ToString()
            If Len(thang) = 1 Then
                thang2 = "0" + thang
            Else
                thang2 = thang
            End If
            Me.b = New clsBChamcongMain
            Dim obj As New objChamcongMain
            obj.ChonBang = 25
            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            ngayht = Me.dtpNgay.Value.Year.ToString() + "/" + thang2 + "/" + Me.dtpNgay.Value.Day.ToString()
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            Me.ngayCT = Tabletemp1.Rows(0).Item("T_DENNGAY").ToString()
            If ngayht = Me.ngayCT.Trim() Then
                Me.linkKhoaBC.ForeColor = Color.Red
            Else
                Me.linkKhoaBC.ForeColor = Color.Blue
            End If
            Me.Tim()
        End If
    End Sub
    Private Sub rdDonviNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonviNV.CheckedChanged
        If bLoad Then
            If Me.rdDonviNV.Checked = True Then
                Me.oldRow = 0
                Me.Tim()
            Else
                'Me.cbDonvi.Text = ""
            End If
        End If
    End Sub
    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        If bLoad Then
            If Me.rdDonvi.Checked = True Then
                Me.oldRow = 0
                Me.Tim()
            Else
                'Me.cbDonvi.Text = ""
            End If
        End If
    End Sub
    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If bLoad Then
            If Me.cbDonvi.Text = "" Then
            Else
                Me.oldRow = 0
                Me.Tim()
            End If
         
            ' Application.DoEvents()
        End If
    End Sub

    Private Sub lbCapnhatnghiphep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCapnhatnghiphep.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmCapnhatnghiphep
            frm.ShowDialog()
            If objChamCong.FlagChamCong = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    'Goi ham cap nhat nghi phep (SP_CAPNHATNGHIPHEP)
                    Capnhatphep()
                    Dim ngaycn As String
                    Dim nguoicn As String
                    nguoicn = MAIN.userclient
                    Dim ngaycn1 As DateTime = Now()
                    ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                    objChamCong.NGAYCN = ngaycn
                    objChamCong.NGUOICN = nguoicn
                    objChamCong.ChonBang = 5
                    Me.b.UpdateInfo(objChamCong)
                    i = i + 1
                End While
                Me.Tim()
            End If

        End If
    End Sub

    Private Sub Capnhatphep()
        Dim listpar As New ArrayList(1)
        objChamCong.NgayChamCong = objChamCong.TuNgay

        While objChamCong.NgayChamCong <= objChamCong.DenNgay
            listpar.Add(New SqlParameter("@Ngay", objChamCong.NgayChamCong))
            listpar.Add(New SqlParameter("@NV_MA", objChamCong.NV_MA))
            Me.b.GoiThuTuc("SP_CAPNHATNGHIPHEP", listpar)
            listpar.Clear()
            objChamCong.NgayChamCong = objChamCong.NgayChamCong.AddDays(1)
        End While
    End Sub
    Private Function Kiemrasaythaive15h30(ByVal sothe As String, ByVal sNgaychamcong As String) As DataTable
        Dim tbl As DataTable
        Dim listpar As New ArrayList(2)
        objChamCong.NgayChamCong = objChamCong.TuNgay
        Try
            listpar.Add(New SqlParameter("@NGAYCHAMCONG", sNgaychamcong))
            listpar.Add(New SqlParameter("@NV_MA", sothe))
            tbl = Me.b.Kiemtrasaythaive15h30("SP_KIEMTRASAYTHAI_VE15H30_SOTHE_S", listpar)
            listpar.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return tbl
    End Function

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Dim Tabletemp1530 As DataTable
        Dim Tabletemp1530_ As DataTable

        Dim sodongcove15h30 As Integer = 0
        If MAIN.USER_KT = True Then
            Exit Sub
        Else

            Me.dgrBC.UpdateData()
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()

            Dim sThongbao As String = ""
            Dim frmtb As New frmChamCongMain_mss
            Dim frm As New frmChamcongex
            frm.ShowDialog()
            If objChamCong.FlagChamCong = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        ' KIỂM TRA VỀ 15H30 NUÔI CON 12 THÁNG
                        objChamCong.ChonBang = 14
                        Tabletemp1530 = Me.b.LoadDS(objChamCong)

                        If Tabletemp1530.Rows.Count > 0 Then
                            sodongcove15h30 = sodongcove15h30 + 1
                            sThongbao = "Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (nuôi con nhỏ)."
                            frmtb.lsbThongbao.Items.Add(sThongbao)

                        Else

                        End If


                        Tabletemp1530_ = Me.Kiemrasaythaive15h30(objChamCong.NV_MA, objChamCong.Ngay)

                        If Tabletemp1530_.Rows.Count > 0 Then
                            Select Case Tabletemp1530_.Rows(0).Item("TINHST").ToString()
                                Case "1", "2"
                                    sThongbao = "Số thẻ  " + objChamCong.NV_MA + " về 15h30 (thai trên 7 tháng), sảy thai (" & Tabletemp1530_.Rows(0).Item("NP_TuNgay").ToString() & " đến " & Tabletemp1530_.Rows(0).Item("NP_DenNgay").ToString() & ")"
                                    frmtb.lsbThongbao.Items.Add(sThongbao)

                                Case Else
                                    sodongcove15h30 = sodongcove15h30 + 1
                                    sThongbao = "Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng)."
                                    frmtb.lsbThongbao.Items.Add(sThongbao)

                            End Select
                        Else

                        End If

                        If Tabletemp1530.Rows.Count > 0 Or Tabletemp1530_.Rows.Count > 0 Then
                            EditChamcong()
                            Dim ngaycn As String
                            Dim nguoicn As String
                            nguoicn = MAIN.userclient
                            Dim ngaycn1 As DateTime = Now()
                            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                            objChamCong.NGAYCN = ngaycn
                            objChamCong.NGUOICN = nguoicn
                            objChamCong.ChonBang = 5
                            Me.b.UpdateInfo(objChamCong)
                        Else
                            ''========truong hop binh thuong ===============''
                            EditChamcong()
                            Dim ngaycn As String
                            Dim nguoicn As String
                            nguoicn = MAIN.userclient
                            Dim ngaycn1 As DateTime = Now()
                            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                            objChamCong.NGAYCN = ngaycn
                            objChamCong.NGUOICN = nguoicn
                            objChamCong.ChonBang = 5
                            Me.b.UpdateInfo(objChamCong)
                        End If
                    End If
                    i = i + 1
                End While
            End If

            If objChamCong.FlagChamCong = True Then
                Me.Tim()
            End If
            If sodongcove15h30 > 0 Then
                frmtb.BringToFront()
                frmtb.Show()
            End If
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmChamcongex
            frm.ShowDialog()
            If objChamCong.FlagChamCong = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    'Goi ham cham cong (SP_CHAMCONGN)
                    EditChamcong()
                    Dim ngaycn As String
                    Dim nguoicn As String
                    nguoicn = MAIN.userclient
                    Dim ngaycn1 As DateTime = Now()
                    ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString

                    objChamCong.NGAYCN = ngaycn
                    objChamCong.NGUOICN = nguoicn
                    objChamCong.ChonBang = 5
                    Me.b.UpdateInfo(objChamCong)
                    i = i + 1
                End While
                Me.Tim()
            End If

            Me.ChonDongCu()
        End If
    End Sub

    Dim Tabletemp As DataTable
    Dim TabletempDV As DataTable
    Dim TableND As DataTable
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.b = New clsBChamcongMain
        Dim NgayCC As Date
        NgayCC = Me.dtpNgay.Value
        Dim obj As New objChamcongMain
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
            obj.ChonKhu = "CHONRADIOKHUDVC"
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
                    'btGioTangCaDV.PerformClick()
                End If

                If Me.rdDonvi.Checked = True Then
                    'Me.btGioTangCa.PerformClick()
                End If
        End Select


        '   Me.cbDonvi.DroppedDown = False
       
    End Sub

    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        'Me.dgrBC.UpdateData()
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ChamCongMain.xml"), typeControl.Grid, "coldgrChamcongmain")

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
    End Sub

    Friend WithEvents b As clsBChamcongMain
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Tabletemp1530 As DataTable
    Public Tabletemp1530_ As DataTable

    Private Sub dgrBC_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell

        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell

        Dim tblCaLamViec As DataTable
        Dim gioketthuca_min, gioketthuca_max As String ''16:30 - 16:45
        Dim gioketthuccamin_t7, gioketthuca_max_t7 As String  ''15:30 - 15:45
        Dim sogioketthucca, sophutketthucca_min, sophutketthucca_max As String
        Dim sogioketthucca_t7, sophutketthucca_t7_min, sophutketthucca_t7_max As String
        Dim sophutnhaptay, sogionhaptay, giora_nhaptay As String

        If Not activeCell Is Nothing Then
            Tabletemp1530 = Nothing
            Tabletemp1530_ = Nothing

            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)

            bVe15h30 = False
            Select Case ColA
                Case "1"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        objChamCong.Setnull()
                        objChamCong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()

                        If IsDBNull(activeCell.Row.Cells.Item("GIORATAY").Text) Or activeCell.Row.Cells.Item("GIORATAY").Text = "" Then
                            giora_nhaptay = ""
                        Else
                            giora_nhaptay = activeCell.Row.Cells.Item("GIORATAY").Text
                            ''======
                            If giora_nhaptay <> "" Then
                                sophutnhaptay = giora_nhaptay.Trim().Substring(4, 2)
                                sogionhaptay = giora_nhaptay.Trim().Substring(1, 2)

                            End If
                        End If

                        objChamCong.ChonBang = 16
                        objChamCong.CA_Ma = activeCell.Row.Cells.Item("MACA").Text

                        tblCaLamViec = Me.b.LoadDS(objChamCong)
                        If tblCaLamViec.Rows.Count > 0 Then
                            gioketthuca_min = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_BD").ToString()
                            gioketthuca_max = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_KT").ToString()
                            sogioketthucca = tblCaLamViec.Rows(0).Item("GIOKETTHUCCA").ToString()
                            sophutketthucca_min = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_MI").ToString()
                            sophutketthucca_max = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_MAX").ToString()
                            '' ===============================================
                            gioketthuccamin_t7 = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_BD_T7").ToString()
                            gioketthuca_max_t7 = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_KT_T7").ToString()
                            sogioketthucca_t7 = tblCaLamViec.Rows(0).Item("GIOKETTHUCCA_TTT7").ToString()
                            sophutketthucca_t7_min = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_TTT7MI").ToString()
                            sophutketthucca_t7_max = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_TTT7MAX").ToString()
                        End If


                        ' KIỂM TRA VỀ 15H30 nuoi con nho 12 thang 
                        objChamCong.ChonBang = 14
                        Tabletemp1530 = Me.b.LoadDS(objChamCong)

                        If Tabletemp1530.Rows.Count > 0 Then
                            bVe15h30 = True

                            Select Case giora_nhaptay
                                Case ""
                                    If MessageBox.Show("Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (nuôi con nhỏ) bạn có muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                        bVe15h30 = True
                                        GoTo chamcong
                                    Else
                                        GoTo khongchamcong
                                    End If
                                Case Else
                                    ''co nhap gio tay thi kiem gio tay
                                    If (sogionhaptay <> sogioketthucca_t7) Or (Not (sophutnhaptay >= sophutketthucca_t7_min And sophutnhaptay <= sophutketthucca_t7_max)) Then
                                        If MessageBox.Show("Số thẻ " + objChamCong.NV_MA + " đang về 15h30 (nuôi con nhỏ) .(Giờ ra tay nhập từ " + gioketthuccamin_t7 + " - " + gioketthuca_max_t7 & ")" & Chr(10) & Chr(13) & "Người này đã có giờ tay: " + giora_nhaptay.Trim() & ", bạn có muốn chấm công không ?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                            GoTo chamcong
                                        Else
                                            GoTo khongchamcong
                                        End If
                                    Else
                                        ''cham cong nuoi con 12 tháng có nhập giờ tay 
                                        If MessageBox.Show("Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (nuôi con nhỏ) bạn có muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                            bVe15h30 = True
                                            GoTo chamcong

                                        Else ''CHON KHONG CHAM CONG
                                            GoTo khongchamcong
                                        End If
                                    End If
                            End Select
                        End If

                        ' KIỂM TRA VỀ 15H30 thai thang t7: nếu tồn tại trong thai tháng t7 thì xét tiếp coi có sảy thai ko

                        Tabletemp1530_ = Me.Kiemrasaythaive15h30(objChamCong.NV_MA, objChamCong.Ngay)
                        If Tabletemp1530_.Rows.Count > 0 Then
                            Select Case Tabletemp1530_.Rows(0).Item("TINHST").ToString()
                                Case "1", "2"
                                    bVe15h30 = False
                                    Select Case giora_nhaptay
                                        Case ""
                                            If MessageBox.Show("Số thẻ  " + objChamCong.NV_MA + " về 15h30 (thai trên 7 tháng) sảy thai từ " & Tabletemp1530_.Rows(0).Item("NP_TuNgay").ToString() & " đến " & Tabletemp1530_.Rows(0).Item("NP_DenNgay").ToString() & ", bạn có muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                GoTo chamcong
                                            Else
                                                GoTo khongchamcong
                                            End If
                                        Case Else
                                            ''------co nhap gio tay: ko đc nhập 15h30
                                            If (sogionhaptay <> sogioketthucca) Or (Not (sophutnhaptay >= sophutketthucca_min And sophutnhaptay <= sophutketthucca_max)) Then
                                                If MessageBox.Show("Số thẻ " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng) sảy thai từ " & Tabletemp1530_.Rows(0).Item("NP_TuNgay").ToString() & Chr(10) & Chr(13) & "Giờ ra tay có thể nhập từ " + gioketthuca_min + " - " + gioketthuca_max & Chr(10) & Chr(13) & "Người này bạn đã nhập giờ ra tay " + giora_nhaptay.Trim() & ", bạn muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                    GoTo chamcong
                                                Else
                                                    GoTo khongchamcong
                                                End If
                                            Else
                                                If MessageBox.Show("Số thẻ " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng) sảy thai từ " & Tabletemp1530_.Rows(0).Item("NP_TuNgay").ToString() & Chr(10) & Chr(13) & "Giờ ra tay có thể nhập từ " + gioketthuca_min + " - " + gioketthuca_max & Chr(10) & Chr(13) & ", bạn muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                    GoTo chamcong
                                                Else
                                                    GoTo khongchamcong
                                                End If
                                            End If
                                    End Select

                                    ''========= CHẤM CÔNG TTT7
                                Case Else
                                    bVe15h30 = True
                                    Select Case giora_nhaptay
                                        Case ""
                                            If MessageBox.Show("Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng) bạn có muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                GoTo chamcong
                                            Else
                                                GoTo khongchamcong
                                            End If
                                        Case Else
                                            ''------co nhap gio tay: ko đc nhập 16h30
                                            If (sogionhaptay <> sogioketthucca_t7) Or (Not (sophutnhaptay >= sophutketthucca_t7_min And sophutnhaptay <= sophutketthucca_t7_max)) Then
                                                If MessageBox.Show("Số thẻ " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng) .(Giờ ra tay nhập từ " + gioketthuccamin_t7 + " - " + gioketthuca_max_t7 & ")" & Chr(10) & Chr(13) & "Người này đã có giờ tay: " + giora_nhaptay.Trim() & ", bạn có muốn chấm công không ?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                    GoTo chamcong
                                                Else
                                                    GoTo khongchamcong
                                                End If
                                            Else
                                                If MessageBox.Show("Số thẻ  " + objChamCong.NV_MA + " về 15h30 (thai trên 7 tháng) bạn có muốn chấm công không?", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                    GoTo chamcong  ''cham cong thai tháng t7 có nhập giờ tay 
                                                Else
                                                    GoTo khongchamcong
                                                End If
                                            End If
                                    End Select


                            End Select
                        End If

                        ''======== tr hop binh thuong hoặc chưa tới thai tháng thứ 7==========
                        Dim tblTemp As DataTable
                        objChamCong.ChonBang = 15
                        tblTemp = Me.b.LoadDS(objChamCong)

                        If Tabletemp1530.Rows Is Nothing And Tabletemp1530_ Is Nothing Then
                            If tblTemp.Rows.Count <= 0 OrElse tblTemp Is Nothing Then
                                bVe15h30 = False
                                GoTo chamcong
                            Else
                            End If

                        ElseIf Tabletemp1530.Rows.Count <= 0 And Tabletemp1530_.Rows.Count <= 0 Then
                            bVe15h30 = False
                            GoTo chamcong
                        Else

                        End If


chamcong:
                        Dim frm As New frmChamcongex
                        frm.ShowDialog()
                        If objChamCong.FlagChamCong = True Then
                            'Goi ham cham cong (SP_CHAMCONGN)
                            objChamCong.FlagChamCong = True
                            EditChamcong()
                            'objChamCong.ChonBang = 3
                            'Dim nguoicn As String
                            'Dim ngaycn As String
                            'nguoicn = MAIN.userclient
                            'Dim ngaycn1 As DateTime = Now()
                            'ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
                            'objChamCong.NGUOICN = nguoicn
                            'objChamCong.NGAYCN = ngaycn
                            'objChamCong.CHUOITHAOTAC = Me.b.d.ChuoiThaoTac.ToString()
                            'Me.b.InsertInfo(objChamCong)

                            Dim ngaycn As String
                            Dim nguoicn As String
                            nguoicn = MAIN.userclient
                            Dim ngaycn1 As DateTime = Now()
                            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
                            objChamCong.NGAYCN = ngaycn
                            objChamCong.NGUOICN = nguoicn
                            objChamCong.ChonBang = 5
                            Me.b.UpdateInfo(objChamCong)

                            Me.Tim()
                            Me.ChonDongCu()
                        Else
                            GoTo khongchamcong
                        End If

khongchamcong:

                        Me.ChonDongCu() ''CHON KHONG CHAM CONG
                        objChamCong.FlagChamCong = False
                        bVe15h30 = False
                    End If

                Case "3"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                            Dim obj As New objChamcongMain
                            Dim TableCN As New DataTable
                            obj.Setnull()
                            obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()


                            Dim ngaycn As String
                            Dim nguoicn As String
                            nguoicn = MAIN.userclient
                            Dim ngaycn1 As DateTime = Now()
                            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString


                            '' KIỂM TRA NGÀY CHỦ NHẬT
                            '' NẾU NGÀY CHỦ NHẬT THÌ CẬP NHẬT GIỜ VÀO RA VÀ GIỜ CÔNG
                            obj.ChonBang = 17
                            obj.NGAYCN = ngaycn
                            obj.NGUOICN = nguoicn
                            TableCN = Me.b.LoadDS(obj)
                            If TableCN.Rows(0).Item("CN").ToString = 1 Then
                                obj.ChonBang = 3
                                Me.b.UpdateInfo(obj)

                                obj.ChonBang = 4
                                Me.b.UpdateInfo(obj)
                            Else
                                obj.ChonBang = 1
                                Me.b.DeleteInfo(obj)
                            End If

                            Me.Tim()
                            Me.ChonDongCu()
                        End If
                    End If

                Case "GIOVAOTAY", "GIORATAY"

                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        objChamCong.Setnull()
                        objChamCong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        objChamCong.CA_Ma = activeCell.Row.Cells.Item("MACA").Text

                        Dim frm As New frmVaora
                        frm.ShowDialog()
                        If objChamCong.FlagChamVaoRa = True Then
                            ''=========== dang co gio tay bo gio thanh trong se ko kiem tra =============
                            If objChamCong.GioRaTay.Trim() = "NULL" Or objChamCong.GioRaTay.Trim() = "" Then
                                GoTo Chamvaora
                            End If

                            ''---- kiểm tra về 15h30 + say thai --------''
                            sophutnhaptay = objChamCong.GioRaTay.Trim().Substring(4, 2)
                            sogionhaptay = objChamCong.GioRaTay.Trim().Substring(1, 2)

                            objChamCong.ChonBang = 16
                            tblCaLamViec = Me.b.LoadDS(objChamCong)
                            If tblCaLamViec.Rows.Count > 0 Then
                                gioketthuca_min = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_BD").ToString()
                                gioketthuca_max = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_KT").ToString()
                                sogioketthucca = tblCaLamViec.Rows(0).Item("GIOKETTHUCCA").ToString()
                                sophutketthucca_min = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_MI").ToString()
                                sophutketthucca_max = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_MAX").ToString()
                                '' ===============================================
                                gioketthuccamin_t7 = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_BD_T7").ToString()
                                gioketthuca_max_t7 = tblCaLamViec.Rows(0).Item("CA_GIOKETTHUC_KT_T7").ToString()
                                sogioketthucca_t7 = tblCaLamViec.Rows(0).Item("GIOKETTHUCCA_TTT7").ToString()
                                sophutketthucca_t7_min = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_TTT7MI").ToString()
                                sophutketthucca_t7_max = tblCaLamViec.Rows(0).Item("PHUTKETTHUCCA_TTT7MAX").ToString()
                            End If

                            ' KIỂM TRA VỀ 15H30 nuoi con nho 12 thang 
                            objChamCong.ChonBang = 14
                            Tabletemp1530 = Me.b.LoadDS(objChamCong)

                            If Tabletemp1530.Rows.Count > 0 Then

                            End If

                            ' KIỂM TRA VỀ 15H30 thai tháng thứ 7

                            Tabletemp1530_ = Me.Kiemrasaythaive15h30(objChamCong.NV_MA, objChamCong.Ngay)

                            If Tabletemp1530_.Rows.Count > 0 Then
                                bVe15h30 = True
                                Select Case Tabletemp1530_.Rows(0).Item("TINHST").ToString()
                                    Case "1", "2"
                                    Case Else

                                End Select


                            ElseIf Tabletemp1530_.Rows.Count <= 0 Then
                                'bVe15h30 = False
                                'GoTo Chamvaora
                            End If
                            'Goi ham cham vao ra ()
Chamvaora:

                            Editvaora()
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
Khongchamvaora:
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub

    Private Sub EditChamcong()
        Dim listpar As New ArrayList(16)
        objChamCong.NgayChamCong = objChamCong.TuNgay

        While objChamCong.NgayChamCong <= objChamCong.DenNgay
            listpar.Add(New SqlParameter("@Ngay", objChamCong.NgayChamCong))
            listpar.Add(New SqlParameter("@NV_MA", objChamCong.NV_MA))
            listpar.Add(New SqlParameter("@CHK_Som", objChamCong.TinhTangCaSom))
            listpar.Add(New SqlParameter("@CHK_TINHDUCONG", objChamCong.LuonTinhDuCong))
            listpar.Add(New SqlParameter("@CHK_TINHTANGCA", objChamCong.TinhTangCa))
            listpar.Add(New SqlParameter("@CHK_TINHLAMDEM", objChamCong.TinhLamDemTuLuc))
            listpar.Add(New SqlParameter("@CHK_DUCONGKHIDU", objChamCong.TinhDuCongKhiDiDu))
            listpar.Add(New SqlParameter("@CHK_GIOIHANTANGCA", objChamCong.GioiHanTangCaToiDa))
            listpar.Add(New SqlParameter("@CHK_GIAILAOTANGCA", objChamCong.GiaiLaoTangCa))
            listpar.Add(New SqlParameter("@DUCONGKHIDU", objChamCong.sTinhDuCongKhiDiDu))
            listpar.Add(New SqlParameter("@GIOIHANTANGCA", objChamCong.sGioiHanTangCaToiDa))
            listpar.Add(New SqlParameter("@GIAILAOTANGCA", objChamCong.sGiaiLaoTangCa))
            listpar.Add(New SqlParameter("@TINHLAMDEM", "2000-01-01 " & objChamCong.sTinhLamDemTuLuc))
            listpar.Add(New SqlParameter("@HESONGAYCONG", objChamCong.HeSoNgayCong))
            listpar.Add(New SqlParameter("@CHK_DITRE", objChamCong.KhongTinhDiTre))
            listpar.Add(New SqlParameter("@CHK_QUEN", objChamCong.KhongTinhQuenQuetThe))
            listpar.Add(New SqlParameter("@CHK_LUONDITRE", objChamCong.LuonTinhDiTre))
            listpar.Add(New SqlParameter("@CHK_LUONQUENQT", objChamCong.LuonTinhQuenQuetThe))
            Me.b.GoiThuTuc("SP_CHAMCONGN", listpar)
            'Me.b.d.ChuoiThaoTac.ToString()
            listpar.Clear()
            objChamCong.NgayChamCong = objChamCong.NgayChamCong.AddDays(1)
        End While
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
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2


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

    End Sub
    Public Shared objChamCong As New objChamcongMain

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
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

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim report As New frmReportChamCong
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim report As New frmReportChamCong
        report.LoaiReport = 2
        report.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim report As New frmReportChamCong
        report.LoaiReport = 3
        report.Show()
    End Sub

    Private Sub lbNhomvaora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhomvaora.Click
        Dim sodongcove15h30 As Integer = 0
        Dim Tabletemp1530 As DataTable
        Dim Tabletemp1530_ As DataTable
        Dim sThongbao As String = ""
        Dim frmtb As New frmChamCongMain_mss


        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Me.dgrBC.UpdateData()
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
 
            Dim frm As New frmVaora
            frm.ShowDialog()
            If objChamCong.FlagChamVaoRa = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text

                        ' KIỂM TRA VỀ 15H30 NUÔI CON 12 THÁNG
                        objChamCong.ChonBang = 14
                        Tabletemp1530 = Me.b.LoadDS(objChamCong)

                        If Tabletemp1530.Rows.Count > 0 Then
                            sodongcove15h30 = sodongcove15h30 + 1
                            sThongbao = "Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (nuôi con nhỏ)."
                            frmtb.lsbThongbao.Items.Add(sThongbao)
                        Else

                        End If

                        ' KIỂM TRA VỀ 15H30 ttt7 + tt7 say thai
                        Tabletemp1530_ = Me.Kiemrasaythaive15h30(objChamCong.NV_MA, objChamCong.Ngay)
                        If Tabletemp1530_.Rows.Count > 0 Then
                            Select Case Tabletemp1530_.Rows(0).Item("TINHST").ToString()
                                Case "1", "2"
                                    sThongbao = "Số thẻ  " + objChamCong.NV_MA + " về 15h30 (thai trên 7 tháng), sảy thai (" & Tabletemp1530_.Rows(0).Item("NP_TuNgay").ToString() & " đến " & Tabletemp1530_.Rows(0).Item("NP_DenNgay").ToString() & ")"
                                    frmtb.lsbThongbao.Items.Add(sThongbao)


                                Case Else ''ttt7
                                    sodongcove15h30 = sodongcove15h30 + 1
                                    sThongbao = "Số thẻ  " + objChamCong.NV_MA + " đang về 15h30 (thai trên 7 tháng)."
                                    frmtb.lsbThongbao.Items.Add(sThongbao)

                            End Select
                        Else

                        End If

                        If Tabletemp1530.Rows.Count > 0 Or Tabletemp1530_.Rows.Count > 0 Then
                            Editvaora()
                        Else
                            ''========truong hop binh thuong ===============''
                            Editvaora()
                        End If

                    End If
                    i = i + 1
                End While


            End If

            If objChamCong.FlagChamVaoRa = True Then
                Me.Tim()
            End If
            If sodongcove15h30 > 0 Then
                frmtb.BringToFront()
                frmtb.Show()
            End If
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbToanbovaora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbovaora.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmVaora
            frm.ShowDialog()
            If objChamCong.FlagChamVaoRa = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    Editvaora()
                    i = i + 1
                End While
                Me.Tim()
            End If

            Me.ChonDongCu()
        End If
    End Sub

    Private Sub Editvaora()
        'Load nhan vien co ma so tai ngay cham cong
        objChamCong.ChonBang = 5
        Me.b = New clsBChamcongMain
        Me.Tabletemp = Me.b.LoadDS(objChamCong)

        Dim ngaycn As String
        Dim nguoicn As String
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString


        '' KIỂM TRA NGÀY CHỦ NHẬT
        '' NẾU NGÀY CHỦ NHẬT THÌ CẬP NHẬT GIỜ VÀO RA VÀ GIỜ CÔNG
        objChamCong.NGAYCN = ngaycn
        objChamCong.NGUOICN = nguoicn

        If objChamCong.DITRE = 1 Then
            If Me.Tabletemp.Rows.Count > 0 Then
                'Giữ lại giờ vào ra
                objChamCong.ChonBang = 1
                Me.b.UpdateInfo(objChamCong)
            End If
        End If
        If objChamCong.SAIQD = 1 Then
            If Me.Tabletemp.Rows.Count > 0 Then
                If (objChamCong.GioRaTay.Trim() = "NULL" Or objChamCong.GioRaTay.Trim() = "") And (objChamCong.GioVaoTay.Trim() <> "NULL" Or objChamCong.GioVaoTay.Trim() <> "") Then
                    objChamCong.ChonBang = 10
                    Me.b.UpdateInfo(objChamCong)

                    objChamCong.ChonBang = 6
                    Me.b.UpdateInfo(objChamCong)
                End If
                If (objChamCong.GioVaoTay.Trim() = "NULL" Or objChamCong.GioVaoTay.Trim() = "") And (objChamCong.GioRaTay.Trim() <> "NULL" Or objChamCong.GioRaTay.Trim() <> "") Then

                    objChamCong.ChonBang = 9
                    Me.b.UpdateInfo(objChamCong)

                    objChamCong.ChonBang = 7
                    Me.b.UpdateInfo(objChamCong)
                End If
            End If
        End If
        If objChamCong.SAIQD = 0 And objChamCong.DITRE = 0 Then
            If Me.Tabletemp.Rows.Count > 0 Then
                'MessageBox.Show("Update vaoratay vao bang st_gioquetthe")
                objChamCong.ChonBang = 1
                Me.b.UpdateInfo(objChamCong)
            Else
                'MessageBox.Show("insert vaoratay vao bang st_gioquetthe")
                objChamCong.ChonBang = 1
                Me.b.InsertInfo(objChamCong)
            End If
        End If

        objChamCong.ChonBang = 14
        Me.b.UpdateInfo(objChamCong)

    End Sub

    Private Sub LinkLabel4_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim report As New frmReportChamCong
        report.LoaiReport = 4
        report.Show()
    End Sub

    Private Sub btGioTangCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGioTangCa.Click
        If Me.rdDonvi.Checked = True Then
            Me.dgrBC.UpdateData()
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                'Dim ma As String = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objChamCong.ChonBang = 88
                Dim Temp As New DataTable
                Me.b = New clsBChamcongMain
                Temp = Nothing
                Dim NGAY As Date = Me.dtpNgay.Text
                objChamCong.DonVi = Me.cbDonvi.Value
                 

                objChamCong.Ngay = Microsoft.VisualBasic.Day(NGAY)
                objChamCong.Thang = Microsoft.VisualBasic.Month(NGAY)
                objChamCong.Nam = Microsoft.VisualBasic.Year(NGAY)

                objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                Temp = Me.b.LoadDS(objChamCong)
                If Temp.Rows.Count > 0 Then
                    Dim TONGGIOCONG As String = Temp.Rows(0).Item("TONGGIOCONG").ToString
                    Dim CHENHLECH As String = Temp.Rows(0).Item("CHENHLECH").ToString

                    objChamCong.TongGioCong = TONGGIOCONG
                    objChamCong.ChenhLech = CHENHLECH
                    ' XOA TRUOC
                    objChamCong.ChonBang = 2
                    Me.b.DeleteInfo(objChamCong)

                    objChamCong.ChonBang = 2
                    Me.b.InsertInfo(objChamCong)
                Else
                    Exit Sub
                End If
                i = i + 1
            End While
            Me.Tim()
        End If

    End Sub
    Private Sub linkChamCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim report As New frmBangChamCom
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub btGioTangCaDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGioTangCaDV.Click
        If Me.rdDonviNV.Checked = True Then
            Me.dgrBC.UpdateData()
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1

                objChamCong.ChonBang = 8
                Dim Temp As New DataTable
                Me.b = New clsBChamcongMain
                Temp = Nothing
                Dim NGAY As Date = Me.dtpNgay.Text
                objChamCong.DonVi = Me.cbDonvi.Value
 

                objChamCong.Ngay = Microsoft.VisualBasic.Day(NGAY)
                objChamCong.Thang = Microsoft.VisualBasic.Month(NGAY)
                objChamCong.Nam = Microsoft.VisualBasic.Year(NGAY)
                objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                Temp = Me.b.LoadDS(objChamCong)
                If Temp.Rows.Count > 0 Then
                    Dim TONGGIOCONG As String = Temp.Rows(0).Item("TONGGIOCONG").ToString
                    Dim CHENHLECH As String = Temp.Rows(0).Item("CHENHLECH").ToString

                    objChamCong.TongGioCong = TONGGIOCONG
                    objChamCong.ChenhLech = CHENHLECH
                    ' XOA TRUOC
                    objChamCong.ChonBang = 2
                    Me.b.DeleteInfo(objChamCong)

                    objChamCong.ChonBang = 2
                    Me.b.InsertInfo(objChamCong)
                Else
                    Exit Sub
                End If
                i = i + 1
            End While
            Me.Tim()
        End If
        'Me.Tim()
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        If bLoad Then
            Dim obj As New objChamcongMain
            Me.b = New clsBChamcongMain
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
            Dim obj As New objChamcongMain
            Me.b = New clsBChamcongMain
            oldRow = 0
            Tabletemp = Nothing
            If Me.radKhuB.Checked Then
                obj.ChonBang = 22
                Me.Tabletemp = Me.b.LoadDS(obj)
                Me.Tabletemp.Rows.Add("KHUB", "Toàn bộ khu B")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        End If
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        If bLoad Then
            Dim obj As New objChamcongMain
            Me.b = New clsBChamcongMain
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
            Dim obj As New objChamcongMain
            Me.b = New clsBChamcongMain
            oldRow = 0
            Tabletemp = Nothing
            If Me.radKhuDVC.Checked Then
                obj.ChonBang = 23
                Me.Tabletemp = Me.b.LoadDS(obj)
                Me.Tabletemp.Rows.Add("KHUDVC", "全部公司Toàn bộ khu DVC")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
            End If
        
        End If
    End Sub

    Private Sub lblLayDuLieuKCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLayDuLieuKCB.Click
        If (MessageBox.Show(("Bạn có muốn lấy dữ liệu không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            Dim obj As New objChamcongMain
            Dim TableTam As New DataTable

            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Me.b = New clsBChamcongMain
            obj.ChonBang = 24
            TableTam = Me.b.LoadDS(obj)
            If TableTam.Rows.Count > 0 Then
                Dim ngaycn As String
                Dim nguoicn As String
                nguoicn = MAIN.userclient
                Dim ngaycn1 As DateTime = Now()
                ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
                obj.NGAYCN = ngaycn
                obj.NGUOICN = nguoicn
                obj.ChonBang = 11
                Me.b.UpdateInfo(obj)

                obj.ChonBang = 12
                Me.b.UpdateInfo(obj)

                '' chấm công
                Dim i As Integer = 0
                While i <= TableTam.Rows.Count - 1
                    CHAMCONGKCB(TableTam.Rows(i).Item("NV_MA").ToString(), obj.Ngay)
                    i = i + 1
                End While
                MessageBox.Show("Lấy dữ liệu thành công")
            Else
                MessageBox.Show("Ngày này không có dữ liệu")
                Exit Sub
            End If

        End If
    End Sub
    Private Function CHAMCONGKCB(ByVal NV_MA As String, ByVal sNgaychamcong As String) As Boolean
        Dim tbl As DataTable
        Dim listpar As New ArrayList(2)
        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
        Try
            listpar.Add(New SqlParameter("@NV_MA", NV_MA))
            listpar.Add(New SqlParameter("@NGAY", sNgaychamcong))
            tbl = Me.b.Kiemtrasaythaive15h30("SP_CHAMCONGKCB_NHANVIEN", listpar)
            listpar.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function

    Private Sub linkKhoaBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkKhoaBC.Click
        Dim objdd As New objChamcongMain

        Dim ngay As String
        Dim nguoi As String
        nguoi = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngay = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        objdd.NGAYCN = ngay
        objdd.NGUOICN = nguoi

        Dim T_MA As String
        Dim thang2 As String
        Dim thang As Integer
        Dim nam As Integer

        thang = Month(Me.dtpNgay.Value)

        If Len(Convert.ToString(thang)) = 1 Then
            thang2 = "0" + Convert.ToString(thang)
        Else
            thang2 = thang
        End If
        nam = Year(Me.dtpNgay.Value)
        objdd.DNgay = Convert.ToString(nam) + "/" + thang2 + "/" + "01"

        T_MA = Convert.ToString(thang2) + "-" + Convert.ToString(nam)
        Dim ngay1 As Date
        ngay1 = Me.dtpNgay.Value
        Dim ngayselect As String = ngay1.Year.ToString() + "/" + ngay1.Month.ToString() + "/" + ngay1.Day.ToString()

        objdd.Ngay = ngayselect
        objdd.ChonBang = 84
        Dim temp As DataTable
        temp = Nothing
        temp = Me.b.LoadDS(objdd)
        If temp.Rows.Count > 0 Then
            MessageBox.Show("Dữ liệu tháng " + thang2 + " năm " + Convert.ToString(nam) + " đã có!!!", "Thông Báo", MessageBoxButtons.OK)
            Exit Sub
        Else
            If MessageBox.Show("Bạn có muốn khóa dữ liệu tháng " + thang2 + " năm " + Convert.ToString(nam) + " không?", "Thông Báo", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Me.b = New clsBChamcongMain
                objdd.ChonBang = 1313
                objdd.Ngay = ngayselect
                Me.b.UpdateInfo(objdd)
                MessageBox.Show("Khóa dữ liệu thành công")
            End If
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Dim i As Integer
        If Me.chkall.Checked Then
            While i <= Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells(1).Value = True
                i = i + 1
            End While
        Else
            While i <= Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells(1).Value = False
                i = i + 1
            End While
        End If
    End Sub
End Class

