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
Imports TYXUAN_NS.clsLanguage
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO
Public Class frmBaoCaoTongHop
    Inherits Form
    Dim ReportID As String
    Dim sTuNgay, sDenNgay As String
    Public issysReport As Boolean
    Public para As Object()
    Public sortAtt As String()
    Public i As Integer
    Public tblThongKeXuong As New DataTable()
    Dim sTenDangNhap As String

    Private Sub cboLoaiBaocao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiBaocao.ValueChanged
        Me.cboMAXUONG.Visible = False
        Me.lblXuong.Visible = False
        Me.btnExcel.Enabled = False
        Me.lblTuNgay.Visible = True
        Me.lblDenNgay.Visible = True
        Me.dtpTuNgay.Visible = True
        Me.dtpDenNgay.Visible = True
        Me.chktntheoluong.Visible = False
        Me.dtpTuNgay.Enabled = True
        Me.dtpDenNgay.Enabled = True
        Me.dtpTuNgay.Value = Now().Date
        Me.dtpDenNgay.Value = Now().Date
        Me.chkKhongTinhCG_GD.Visible = False
        ''============= thống kê thành phần tôn giáo
        If cboLoaiBaocao.Value = "TKTG" Then
            Me.chkchitiet.Visible = True
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
        End If

        ''============= thống kê tuổi ,giới tính
        If cboLoaiBaocao.Value = "TKTUOIGT" Then
            Me.chkchitiet.Visible = True
            Me.chktntheoluong.Visible = False
            Me.chkchitiet.Checked = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''=============  thống kê trình độ học vấn
        If cboLoaiBaocao.Value = "TKTD" Then
            Me.chktntheoluong.Visible = False
            Me.chkchitiet.Visible = True
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
        End If

        ''=============  thống kê thâm niên
        If cboLoaiBaocao.Value = "TKTN" Then
            Me.chktntheoluong.Visible = False
            Me.chkchitiet.Visible = True
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
        End If

        ''=============  thống kê thâm niên thôi việc theo tháng

        If cboLoaiBaocao.Value = "TKTNTV_T" Then
            Me.chkchitiet.Visible = True
            Me.chktntheoluong.Visible = False
            Me.chkchitiet.Checked = True
            Me.chkthang.Visible = True
            Me.chkthang.Checked = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''=============  thống kê thâm niên thôi việc theo năm
        If cboLoaiBaocao.Value = "TKTNTV_N" Then
            Me.chkchitiet.Visible = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.chkthang.Visible = True
            Me.btnXem.Enabled = True
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon
        End If

        ''=============  thống kê phân bố công nhân trong và ngoài tỉnh
        If cboLoaiBaocao.Value = "TKTNGTINH" Then
            Me.chkchitiet.Visible = True
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''=============  thống kê nguyên nhân nghỉ việc mỗi tháng của các xưởng
        If cboLoaiBaocao.Value = "TKLDNGHIVIEC_T" Then
            Me.chktntheoluong.Visible = False
            Me.chkchitiet.Visible = True
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True

        End If

        ''=============  thống kê nguyên nhân nghỉ việc năm
        If cboLoaiBaocao.Value = "TKLDNGHIVIEC_N" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon

        End If

        ''============= tình hình lưu động nhân viên ở các xưởng
        If cboLoaiBaocao.Value = "TKTHLUUDONG" Then
            Me.chkchitiet.Visible = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''============= thống kê nghỉ việc theo tháng năm 2013
        If cboLoaiBaocao.Value = "TKNVTHEOTHANG" Then
            Me.chkchitiet.Visible = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon

        End If

        ''============= thống kê nghỉ việc theo điểm danh hàng ngày

        If cboLoaiBaocao.Value = "TKNVTHEODIEMDANH" Then
            Me.chkchitiet.Visible = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
            Me.lblXuong.Visible = True
            Me.cboMAXUONG.Visible = True
            Me.cboMAXUONG.SelectedIndex = 0
        End If

        ''============= thống kê công nhân may nghỉ việc

        If cboLoaiBaocao.Value = "TKCNMAYNGHIVIEC" Then
            Me.chkchitiet.Visible = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''============= Thống kê nghỉ không phép
        If cboLoaiBaocao.Value = "TKNGHIKHONGPHEP" Then
            Me.chkchitiet.Visible = True
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
            Me.btnXem.Enabled = True

        End If
        ''============= Bảng phân tích tỷ lệ nghỉ việc năm

        If cboLoaiBaocao.Value = "TKTYLENGHIVIECNAM" Then
            Me.chkchitiet.Visible = True
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon
            Me.btnXem.Enabled = True
            Me.btnExcel.Enabled = True
        End If

        If cboLoaiBaocao.Value = "TKTYLENGHIVIECNAM_CNTT" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True

            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon
            Me.btnXem.Enabled = True
        End If

        ''============= Bảng phân tích tỷ lệ nghỉ công nhân mới theo tháng
        If cboLoaiBaocao.Value = "TKTYLENGHIVIECCNM_THANG" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If

        ''============= Bảng phân tích tỷ lệ nghỉ việc theo độ tuổi năm
        If cboLoaiBaocao.Value = "TKTYLENGHIVIEC_DOTUOI" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.chktntheoluong.Visible = False
            Me.dtpDenNgay.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01" ''========set ngay 1/1 cua nam dang chon

        End If

        ''============= thống kê nghỉ việc không lý do loại OPKTRG trong điểm danh theo tháng, tổng số nghỉ từng ngày
        If cboLoaiBaocao.Value = "TKNGHIVIECKHONGLYDO" Then
            Me.chkchitiet.Visible = True
            Me.chkchitiet.Checked = False
            Me.chktntheoluong.Visible = False
            Me.chkthang.Visible = False
            Me.chkTinhCNM.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True

            Me.btnXem.Enabled = True
            Me.btnExcel.Enabled = True
            Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/" + CDate(Me.dtpDenNgay.Value).Month.ToString() + "/01" ''========set ngay 1/1 cua nam thang dang chon
        End If

        ''============= thống kê danh sách nghỉ việc chấm dứt-sa thải theo tháng 
        If cboLoaiBaocao.Value = "TKNGHIVIEC_GCDHD" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True

            Me.btnXem.Enabled = True
            Me.btnExcel.Enabled = True
            Me.chkKhongTinhCG_GD.Visible = True
        End If

        ''============ thống kê danh sách mang thai theo tháng
        If cboLoaiBaocao.Value = "TKDANHSACHMANGTHAI" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True

            Me.btnXem.Enabled = True
            Me.btnExcel.Enabled = True
            Me.chkKhongTinhCG_GD.Visible = False
        End If
        ''============ thống kê trợ cấp nuôi con dưới 6 tuổi
        If cboLoaiBaocao.Value = "TKTROCAPNUOICONDUOI6T" Then
            Me.chkchitiet.Visible = False
            Me.chkthang.Visible = False
            Me.chktntheoluong.Visible = False
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = True

            Me.btnXem.Enabled = True
            Me.btnExcel.Enabled = True
            Me.chkKhongTinhCG_GD.Visible = False
        End If
    End Sub
    Dim b As New clsBBaoCaoTongHop
    Function SoNgay(ByVal Thang As Integer, ByVal Nam As Integer) As Integer
        Dim songay_cuathang As Integer = 0

        Select Case Thang
            Case 1, 3, 5, 7, 8, 10, 12
                songay_cuathang = 31
            Case 4, 6, 9, 11
                songay_cuathang = 30
            Case 2
                If (Nam Mod 4) = 0 Then
                    songay_cuathang = 29
                Else
                    songay_cuathang = 28
                End If
        End Select

        Return songay_cuathang
    End Function
    Private Sub LoadCombo()
        Me.cboLoaiBaocao.Items.Add("TKTG", "Thống kê thành phần tôn giáo")
        Me.cboLoaiBaocao.Items.Add("TKTUOIGT", "Thống kê tuổi ,giới tính")
        Me.cboLoaiBaocao.Items.Add("TKTD", "Thống kê trình độ")
        Me.cboLoaiBaocao.Items.Add("TKTN", "Thống kê thâm niên")
        Me.cboLoaiBaocao.Items.Add("TKTNTV_T", "Thống kê thâm niên thôi việc theo tháng")
        Me.cboLoaiBaocao.Items.Add("TKTNTV_N", "Thống kê thâm niên thôi việc theo năm")

        Me.cboLoaiBaocao.Items.Add("TKTNGTINH", "Thống kê phân bố công nhân trong và ngoài tỉnh")
        Me.cboLoaiBaocao.Items.Add("TKLDNGHIVIEC_T", "Thống kê nguyên nhân nghỉ việc mỗi tháng của các xưởng")


        Me.cboLoaiBaocao.Items.Add("TKLDNGHIVIEC_N", "Thống kê nguyên nhân nghỉ việc năm")

        Me.cboLoaiBaocao.Items.Add("TKTHLUUDONG", "Tình hình lưu động nhân viên ở các xưởng")
        Me.cboLoaiBaocao.Items.Add("TKNVTHEOTHANG", "Thống kê nghỉ việc theo tháng năm 2013")

        Me.cboLoaiBaocao.Items.Add("TKNVTHEODIEMDANH", "Thống kê nghỉ việc theo điểm danh hàng ngày")
        Me.cboLoaiBaocao.Items.Add("TKCNMAYNGHIVIEC", "Thống kê công nhân may nghỉ việc")
        Me.cboLoaiBaocao.Items.Add("TKNGHIKHONGPHEP", "Thống kê nghỉ không phép")

        Me.cboLoaiBaocao.Items.Add("TKTYLENGHIVIECNAM", "Bảng phân tích tỷ lệ nghỉ việc năm")
        Me.cboLoaiBaocao.Items.Add("TKTYLENGHIVIECNAM_CNTT", "Bảng phân tích tỷ lệ công nhân trực tiếp nghỉ việc theo năm")

        Me.cboLoaiBaocao.Items.Add("TKTYLENGHIVIECCNM_THANG", "Bảng phân tích tỷ lệ nghỉ việc công nhân mới theo tháng")
        Me.cboLoaiBaocao.Items.Add("TKTYLENGHIVIEC_DOTUOI", "Bảng phân tích tỷ lệ nghỉ việc theo độ tuổi năm")
        Me.cboLoaiBaocao.Items.Add("TKNGHIVIECKHONGLYDO", "Thống kê số lao động nghỉ việc không lý do")
        Me.cboLoaiBaocao.Items.Add("TKNGHIVIEC_GCDHD", "Thống kê danh sách nghỉ việc giảm-chấm dứt hợp đồng")
        Me.cboLoaiBaocao.Items.Add("TKDANHSACHMANGTHAI", "Thống kê danh sách mang thai chi tiết theo tháng")
        Me.cboLoaiBaocao.Items.Add("TKTROCAPNUOICONDUOI6T", "Danh sách chi tiết trợ cấp con dưới 6 tuổi theo tháng")
        sTenDangNhap = frmDangNhap.txtTendangnhap.Text
    End Sub
    Private Sub frmBaoCaoTongHop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblXuong.Visible = False
        Me.chktntheoluong.Visible = False
        Me.chktntheoluong.Checked = False
        Me.chkthang.Visible = False
        Me.chkchitiet.Visible = False
        Me.cboMAXUONG.Visible = False
        Me.chkKhongTinhCG_GD.Visible = False
        Me.chkTinhCNM.Visible = False
        Me.radTCT.Checked = True
        LoadCombo()
    End Sub
    Private Sub dtpDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.dtpDenNgay.Value Is Nothing Then
            If cboLoaiBaocao.Value = "TKTNTV_N" Or cboLoaiBaocao.Value = "TKLDNGHIVIEC_N" Or cboLoaiBaocao.Value = "TKTYLENGHIVIECNAM" Or cboLoaiBaocao.Value = "TKTYLENGHIVIEC_DOTUOI" Or cboLoaiBaocao.Value = "TKNVTHEOTHANG" Or cboLoaiBaocao.Value = "TKTYLENGHIVIECNAM_CNTT" Then
                Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/01/01"
            End If

            If cboLoaiBaocao.Value = "TKNGHIVIECKHONGLYDO" Then
                Me.dtpTuNgay.Value = CDate(Me.dtpDenNgay.Value).Year.ToString() + "/" + CDate(Me.dtpDenNgay.Value).Month.ToString() + "/01" ''========set ngay 1/1 cua nam thang dang chon
            End If


        End If
    End Sub

    Private Sub methodLoad_TKDANHSACHMANGTHAI()
        Dim THANG As Integer
        THANG = Convert.ToInt32(CDate(Me.dtpDenNgay.Value).Month)
        Dim NAM As Integer
        NAM = Convert.ToInt32(CDate(Me.dtpDenNgay.Value).Year)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@THANG", THANG))
        listpar.Add(New SqlParameter("@NAM", NAM))

        If Me.radTCT.Checked Then
            tblTemp = Me.b.Load("SP_THONGKEDANHSACHCHITIET_THAISAN", listpar)
        End If
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub methodLoad_TKTROCAPNUOICONDUOI6T()
        Dim THANG As Integer
        THANG = Convert.ToInt32(CDate(Me.dtpDenNgay.Value).Month)
        Dim NAM As Integer
        NAM = Convert.ToInt32(CDate(Me.dtpDenNgay.Value).Year)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@THANG", THANG))
        listpar.Add(New SqlParameter("@NAM", NAM))

        If Me.radTCT.Checked Then
            tblTemp = Me.b.Load("SP_THONGKEDANHSACHCHITIET_TROCAPNUOICONDUOI6T", listpar)
        End If
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub

    Private Sub methodLoad_NghiKhongPhep()
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))

        If Me.radTCT.Checked Then
            'tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_S", listpar)
            If Me.chkchitiet.Checked Then
                tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_S_2018_chitiet", listpar)
            Else
                tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_S_2018", listpar)
            End If
        End If
        If Me.radKhuA.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_KHUA_S", listpar)
        End If
        If Me.radKhuB.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_KHUB_S", listpar)
        End If
        If Me.radDVC.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKENGHIKHONGPHEP_KHUDVC_S", listpar)
        End If
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub methodLoad_ThamnienthoiviecNam()
        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        listpar.Add(New SqlParameter("@nam", CDate(Me.dtpDenNgay.Value).Year.ToString()))
        If Me.radTCT.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIEC_NAM_S_TCT", listpar)
        End If
        If radKhuA.Checked Or radKhuB.Checked Or radDVC.Checked Then
            listpar.Add(New SqlParameter("@KHUU", khu.ToString))
            tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIEC_NAM_THEOKHU", listpar)
        End If
        'If Me.radKhuA.Checked Then
        'tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIEC_NAM_KHUA_S", listpar)
        'End If
        'If Me.radKhuB.Checked Then
        'tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIEC_NAM_KHUB_S", listpar)
        ' End If
        'If Me.radDVC.Checked Then
        'tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIEC_NAM_KHUDVC_S", listpar)
        'End If

        listpar.Clear()
        Dim dem As Integer


        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub



    Private Sub methodLoad_TKCNTrongNgoaiTinh()
        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        listpar.Clear()
        ''listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        listpar.Add(New SqlParameter("@KHU", khu))
        If chkchitiet.Checked = True Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKETRONGNGOAITINH_MOI_S_2018_chitiet", listpar)
        Else
            tblTemp = Me.b.Load("SP_BCTH_THONGKETRONGNGOAITINH_MOI_S_2018", listpar)
        End If

        listpar.Clear()
        Me.btnExcel.Enabled = True
        Dim dem As Integer
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            If chkchitiet.Checked = True Then
                LoadGridView_TKCNTRONGNGOAITINHChiTiet()
            Else
                LoadGridView_TKCNTRONGNGOAITINH()
                GirdColor()
            End If
        Else
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub methodLoad_TKCNTNGHITHEOXUONG()
        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        listpar.Add(New SqlParameter("@KHU", khu))
        If Me.chkchitiet.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKELYDONGHIVIEC_THANGMOI_S_2018_chitiet", listpar)
        Else
            tblTemp = Me.b.Load("SP_BCTH_THONGKELYDONGHIVIEC_THANGMOI_S_2018", listpar)
        End If
        listpar.Clear()
        Dim dem As Integer
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub

    ''cnm
    Private Sub methodLoad_TKCNMNGHIVIEC()
        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        listpar.Add(New SqlParameter("@KHU", khu))
        tblTemp = Me.b.Load("SP_BCTH_THONGKENGUYENNHANNGHIVIECCNM_N_S", listpar)
        listpar.Clear()
        Dim dem As Integer
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub

    '' Nghĩ việc năm 

    Private Sub methodLoad_TKNGHIVIECNAM()

        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        If khu <> "TCT" Then
            listpar.Clear()
            listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
            listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
            listpar.Add(New SqlParameter("@KHU", khu))
            'tblTemp = Me.b.Load("SP_BCTH_THONGKENGUYENNHANNGHIVIEC_N_KHU_S", listpar)
            tblTemp = Me.b.Load("SP_BCTH_THONGKENGUYENNHANNGHIVIEC_N_KHU_S_2018", listpar)
            listpar.Clear()
        Else
            listpar.Clear()
            listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
            listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
            ''listpar.Add(New SqlParameter("@KHU", khu))
            'tblTemp = Me.b.Load("SP_BCTH_THONGKENGUYENNHANNGHIVIEC_N_TCT", listpar)
            tblTemp = Me.b.Load("[SP_BCTH_THONGKENGUYENNHANNGHIVIEC_N_TCT_2018]", listpar)
            listpar.Clear()
        End If

        Dim dem As Integer
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub



    Private Sub TomauDongTong()
        For i = 0 To dgrBC.Rows.Count - 1
            For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                ''============
                Select Case Me.dgrBC.Rows(i).Cells("NHOM").Value.ToString()
                    Case "1"

                    Case "2", "4", "6"
                        Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Red
                    Case "7"
                        Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                End Select
            Next
        Next
    End Sub
    '------------
    Private Sub methodLoad_TKtinhinhPhanBoCN()
        Dim khu As String
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        If radKhuA.Checked Then
            khu = "A"

        ElseIf radKhuB.Checked Then
            khu = "B"
        ElseIf radDVC.Checked Then
            khu = "DVC"
        Else
            khu = "TCT"
        End If
        Dim ngay As Date
        Dim songaytrongthang As Integer
        Dim denngay_tnay As String
        Dim denngay_ttruoc As String
        Dim tungay_tnay As String
        Dim tungay_ttruoc As String
        ngay = Me.dtpDenNgay.Value
        If ngay.Month() >= 2 Then
            songaytrongthang = Me.SoNgay(ngay.Month, ngay.Year)
            denngay_tnay = ngay.Year().ToString() + "/" + ngay.Month().ToString() + "/" + songaytrongthang.ToString()

            songaytrongthang = Me.SoNgay(ngay.Month - 1, ngay.Year)
            denngay_ttruoc = ngay.Year().ToString() + "/" + (ngay.Month() - 1).ToString() + "/" + songaytrongthang.ToString()

            tungay_tnay = Me.dtpDenNgay.Value.Year().ToString() + "/" + ngay.Month().ToString() + "/" + "1"
            tungay_ttruoc = Me.dtpDenNgay.Value.Year().ToString() + "/" + (ngay.Month() - 1).ToString() + "/" + "1"

            'strArray = New String() {denngay_tnay, denngay_ttruoc, tungay_tnay, tungay_ttruoc}
        End If

        If ngay.Month() = 1 Then
            songaytrongthang = Me.SoNgay(ngay.Month, ngay.Year)
            denngay_tnay = ngay.Year().ToString() + "/" + ngay.Month().ToString() + "/" + songaytrongthang.ToString()

            songaytrongthang = Me.SoNgay(12, ngay.Year - 1)
            denngay_ttruoc = (ngay.Year() - 1).ToString() + "/" + "12" + "/" + songaytrongthang.ToString()

            tungay_tnay = Me.dtpDenNgay.Value.Year().ToString() + "/" + ngay.Month().ToString() + "/" + "1"
            tungay_ttruoc = (ngay.Year() - 1).ToString() + "/" + "12" + "/" + "1"

            'strArray = New String() {denngay_tnay, denngay_ttruoc, tungay_tnay, tungay_ttruoc}


        End If


        listpar.Clear()
        listpar.Add(New SqlParameter("@denngay_tnay", denngay_tnay.ToString))
        listpar.Add(New SqlParameter("@denngay_ttruoc", denngay_ttruoc))
        listpar.Add(New SqlParameter("@tungay_tnay", tungay_tnay))
        listpar.Add(New SqlParameter("@tungay_ttruoc", tungay_ttruoc))
        listpar.Add(New SqlParameter("@KHU", khu))
        tblTemp = Me.b.Load("SP_BCTH_THONGKELUUDONGNHANVIEN_S", listpar)
        listpar.Clear()
        Dim dem As Integer
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub

    Private Sub TomauDongTong1()
        For i = 0 To dgrBC.Rows.Count - 1
            For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                ''============
                Select Case Me.dgrBC.Rows(i).Cells("NHOM").Value.ToString()
                    Case "1"

                    Case "2", "4", "6"
                        Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Red
                    Case "7"
                        Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                End Select
            Next
        Next
    End Sub
    Private Sub methodLoad_NghiViecCDHD_Sathai()
        Dim listpar As New ArrayList(3)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        listpar.Add(New SqlParameter("@khongtinhCGGD", Me.chkKhongTinhCG_GD.Checked))

        If Me.radTCT.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIEC_CHAMDUTSATHAI_S", listpar)
        End If
        If Me.radKhuA.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIEC_CHAMDUTSATHAI_KHUA_S", listpar)
        End If
        If Me.radKhuB.Checked Then
            tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIEC_CHAMDUTSATHAI_KHUB_S", listpar)
        End If

        listpar.Clear()

        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
        End If
    End Sub
    Private Sub methodLoad_ThongKeTonGiao(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@ngay", CDate(Me.dtpDenNgay.Value)))
        Select Case sKhu
            Case "A", "B", "DVC"
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tblTemp = Me.b.Load("SP_BCTH_THONGKETONGIAO_MOI_KHU_S", listpar)
            Case "TCT"
                If chkchitiet.Checked = True Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETONGIAO_MOI_TCT_S_chitiet", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETONGIAO_MOI_TCT_S", listpar)
                End If

        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            If chkchitiet.Checked = True Then
                LoadGridView_ThongKeTonGiaoChiTiet()
            Else
                LoadGridView_ThongKeTonGiao()
            End If

            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub methodLoad_ThongKeTrinhDoHocVan(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@ngay", CDate(Me.dtpDenNgay.Value)))
        Select Case sKhu
            Case "A", "B", "DVC"
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tblTemp = Me.b.Load("SP_BCTH_THONGKETRINHDOHOCVAN_MOI_KHU_S", listpar)
            Case "TCT"
                If chkchitiet.Checked = True Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETRINHDOHOCVAN_MOI_TCT_S_chitiet", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETRINHDOHOCVAN_MOI_TCT_S", listpar)
                End If

        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            If chkchitiet.Checked = True Then
                LoadGridView_ThongKeTrinhDoHocVanChiTiet()
            Else
                LoadGridView_ThongKeTrinhDoHocVan()
            End If

            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub methodLoad_ThongKeThamNien(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@ngay", CDate(Me.dtpDenNgay.Value)))
        Select Case sKhu
            Case "A", "B", "DVC"
                listpar.Add(New SqlParameter("@KHU", sKhu))
                If chktntheoluong.Checked Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIEN_MOI_KHU_S_theoluong", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIEN_MOI_KHU_S", listpar)
                End If
            Case "TCT"
                If chktntheoluong.Checked Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIEN_MOI_TCT_S_theoluong", listpar)
                Else
                    If Me.chkchitiet.Checked Then
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIEN_MOI_TCT_S_chitiet", listpar)
                    Else
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIEN_MOI_TCT_S", listpar)
                    End If
                End If
        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            If chktntheoluong.Checked Then
                LoadGridView_ThongKeThamNienTheoLuong()
            Else

                If Me.chkchitiet.Checked Then
                    LoadGridView_ThongKeThamNienChiTiet()
                Else
                    LoadGridView_ThongKeThamNien()
                End If
            End If
            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub methodLoad_ThongKeThamNienThoiViec_Thang(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))
        Select Case sKhu
            Case "A", "B", "DVC"
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_KHU_S", listpar)
            Case "TCT"
                'tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_TCT_S", listpar)
                If Me.chkthang.Checked Then
                    If Me.chkchitiet.Checked Then
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_TCT_S_2018_NEW_chitiet", listpar)
                    Else
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_TCT_S_2018_NEW", listpar)
                    End If
                Else
                    If Me.chkchitiet.Checked Then
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_TCT_S_2018_chitiet", listpar)
                    Else
                        tblTemp = Me.b.Load("SP_BCTH_THONGKETHAMNIENTHOIVIECTHANG_TCT_S_2018", listpar)
                    End If
                End If
        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            LoadGridView_ThongKeThamNienThoiViec_Thang()
            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub methodLoad_ThongKeTuoiGioiTinh(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@ngay", CDate(Me.dtpDenNgay.Value)))
        Select Case sKhu
            Case "A", "B", "DVC"
                listpar.Add(New SqlParameter("@KHU", sKhu))
                If Me.chkchitiet.Checked Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETUOIGIOITINH_MOI_KHU_S", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETUOIGIOITINH_MOI_KHU_S", listpar)
                End If
            Case "TCT"

                If Me.chkchitiet.Checked Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETUOIGIOITINH_MOI_TCT_S_chitiet2019", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKETUOIGIOITINH_MOI_TCT_S", listpar)
                End If
        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
            LoadGridView_ThongKeTuoiGioiTinh()
            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub methodLoad_SoLaoDongNghiViecKLyDo(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@tungay", CDate(Me.dtpTuNgay.Value)))
        listpar.Add(New SqlParameter("@denngay", CDate(Me.dtpDenNgay.Value)))

        Select Case sKhu
            Case "A"
                tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_KHUA_MOI_S", listpar)
            Case "B"
                tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_KHUB_MOI_S", listpar)
            Case "DVC"
                tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_DVC_MOI_S", listpar)
            Case "TCT"
                If Me.chkchitiet.Checked Then
                    tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_MOI_S_chitiet", listpar)
                Else
                    tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_MOI_S", listpar)
                End If
            Case Else
                tblTemp = Me.b.Load("SP_BCTH_THONGKELAODONGNGHIVIECKHONGLYDO_MOI_S", listpar)
        End Select
        If tblTemp.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTemp
        Else
            MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub methodLoad_TyleNghiViec_Khu(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        ''===========
        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_D", listpar1)
        listpar1.Clear()

        For i = 1 To 12
            listpar1.Add(New SqlParameter("@THANG", i))
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I", listpar1)
            listpar1.Clear()
        Next

        For i = 1 To 12
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANG", i))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_THANG", listpar1)
            listpar1.Clear()
        Next

        obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_TCT", listpar1)
        listpar1.Clear()

        ''============== LẶP TỪNG XƯỞNG; TÁCH KHU A, KHU B ===============''
        Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
        If Me.radKhuA.Checked Then
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_TINHVP_S")
            If tblDMXuongKhuA.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
        End If

        If Me.radKhuB.Checked Then
            tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_S")
            If tblDMXuongKhuB.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
        End If
       

        'listpar2.Clear()
        'listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        'listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        'listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
        'listpar2.Add(New SqlParameter("@XUONGTENHOA", "TC合計"))
        'listpar2.Add(New SqlParameter("@KHU", "TC合計"))
        'tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

        If tblTemp.Rows.Count > 0 Then
            tblThongKeXuong.Merge(tblTemp)
        End If
        listpar2.Clear()
        Me.dgrBC.DataSource = tblThongKeXuong
    End Sub
    Private Sub methodLoad_TyleNghiViec_TCT()
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        ''===========
        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_D", listpar1)
        listpar1.Clear()

        For i = 1 To 12
            listpar1.Add(New SqlParameter("@THANG", i))
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I", listpar1)
            listpar1.Clear()
        Next

        For i = 1 To 12
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANG", i))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_THANG", listpar1)
            listpar1.Clear()
        Next

        obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_TCT", listpar1)
        listpar1.Clear()

        ''============== LẶP TỪNG XƯỞNG ===============''
        Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
        tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_S")

        If tblDMXuongKhuA.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If

        tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_S")
        If tblDMXuongKhuB.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If

        tblDMXuongKhoiVP = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHOIVP_S")
        If tblDMXuongKhoiVP.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhoiVP.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhoiVP.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If
        listpar2.Clear()
        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
        listpar2.Add(New SqlParameter("@XUONGTENHOA", "TC合計"))
        listpar2.Add(New SqlParameter("@KHU", "TC合計"))
        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

        If tblTemp.Rows.Count > 0 Then
            tblThongKeXuong.Merge(tblTemp)
        End If
        listpar2.Clear()
        Me.dgrBC.DataSource = tblThongKeXuong

    End Sub
    Private Sub methodLoad_TyleCNTTNghiViec_TCT()
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_D", listpar1)
        listpar1.Clear()
        ''============ 
        For i = 1 To 12
            listpar.Add(New SqlParameter("@THANG", i))
            listpar.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_MOI_I", listpar)
            listpar.Clear()
        Next

        ''===========
        For i = 1 To 12
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANG", i))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_CNTT_THANG_MOI", listpar1)
            listpar1.Clear()
        Next

        obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_CNTT_TCT", listpar1)
        listpar1.Clear()



        ''============== LẶP TỪNG XƯỞNG ===============''
        Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhuDVC, tblTemp, tblTemp1 As DataTable
        tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_MOI_S")

        If tblDMXuongKhuA.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If

        tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_S")
        If tblDMXuongKhuB.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If

        tblDMXuongKhuDVC = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUDVC_S")
        If tblDMXuongKhuDVC.Rows.Count > 0 Then
            For i As Integer = 0 To tblDMXuongKhuDVC.Rows.Count - 1
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString()))
                If tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString() = "TONGKHUDVC" Then
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                Else
                    listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString() & " 廠"))
                End If
                listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuDVC.Rows(i).Item("KHU").ToString()))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Next
        End If
        listpar2.Clear()
        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
        listpar2.Add(New SqlParameter("@XUONGTENHOA", "全廠合計 TC"))
        listpar2.Add(New SqlParameter("@KHU", "TC合計"))
        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

        If tblTemp.Rows.Count > 0 Then
            tblThongKeXuong.Merge(tblTemp)
        End If
        listpar2.Clear()
        Me.dgrBC.DataSource = tblThongKeXuong

    End Sub
    Private Sub methodLoad_TyleCNTTNghiViec_Khu(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_D", listpar1)
        listpar1.Clear()
        ''============ 
        For i = 1 To 12
            listpar.Add(New SqlParameter("@THANG", i))
            listpar.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_MOI_I", listpar)
            listpar.Clear()
        Next

        ''===========
        For i = 1 To 12
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANG", i))
            'If Me.radKhuA.Checked Then
            'Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_CNTT_THANG_KHUA", listpar1)
            'Else
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_CNTT_THANG", listpar1)
            'End If

            listpar1.Clear()
        Next

        obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_CNTT_TCT", listpar1)
        listpar1.Clear()



        ''============== LẶP TỪNG XƯỞNG, TÁCH KHU A,B ===============''
        Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhuDVC, tblTemp, tblTemp1 As DataTable

        If Me.radKhuA.Checked Then
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_MOI_S")
            If tblDMXuongKhuA.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
        End If

        If Me.radKhuB.Checked Then
            tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_MOI_S")
            If tblDMXuongKhuB.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
        End If

        If Me.radDVC.Checked Then
            tblDMXuongKhuDVC = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUDVC_S")
            If tblDMXuongKhuDVC.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuDVC.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString() = "TONGKHUDVC" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuDVC.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuDVC.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
        End If

        If tblTemp.Rows.Count > 0 Then
        ElseIf tblTemp Is Nothing Then
        Else
            tblThongKeXuong.Merge(tblTemp)
        End If
        listpar2.Clear()
        Me.dgrBC.DataSource = tblThongKeXuong

    End Sub
    Private Sub LoadGridView_TyleCNNVNghiViec()
        Try
        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                'Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.FromArgb(255, 255, 255)

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                    .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
                Next
                ''=============
                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
                .Columns("TIEUDE").Header.Caption = ""
                .Columns("LOAI").Hidden = True
                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                .Columns("TONG").Header.Caption = "NĂM" & Chr(10) & "年"
                .Columns("X_MA_").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                .Columns("XUONGTENHOA").MergedCellStyle = MergedCellStyle.Always
                .Columns("XUONGTENHOA").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

                .Columns("T1").Header.Caption = "THÁNG 1" & Chr(10) & "月份"
                .Columns("T2").Header.Caption = "THÁNG 2" & Chr(10) & "月份"
                .Columns("T3").Header.Caption = "THÁNG 3" & Chr(10) & "月份"
                .Columns("T4").Header.Caption = "THÁNG 4" & Chr(10) & "月份"
                .Columns("T5").Header.Caption = "THÁNG 5" & Chr(10) & "月份"
                .Columns("T6").Header.Caption = "THÁNG 6" & Chr(10) & "月份"
                .Columns("T7").Header.Caption = "THÁNG 7" & Chr(10) & "月份"
                .Columns("T8").Header.Caption = "THÁNG 8" & Chr(10) & "月份"
                .Columns("T9").Header.Caption = "THÁNG 9" & Chr(10) & "月份"
                .Columns("T10").Header.Caption = "THÁNG 10" & Chr(10) & "月份"
                .Columns("T11").Header.Caption = "THÁNG 11" & Chr(10) & "月份"
                .Columns("T12").Header.Caption = "THÁNG 12" & Chr(10) & "月份"

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
                band.Layout.Override.CellMultiLine = DefaultableBoolean.True
                band.ColHeaderLines = 2

                'band.Layout.Override.RowSelectors = DefaultableBoolean.True
                'band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
                'band.Layout.Bands(0).Summaries.Clear()
                'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                'summary.Appearance.TextHAlign = HAlign.Right
                'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                'band.SummaryFooterCaption = "Tổng số: "
                'band = Nothing
            End With
        Catch ex As Exception
        End Try
        If Me.dgrBC.Rows.Count > 0 Then
            Me.btnExcel.Enabled = True
            For i = 0 To dgrBC.Rows.Count - 1
                Select Case dgrBC.Rows(i).Cells("X_MA_").Value.ToString()
                    Case "TONGKHUA", "TONGKHUB"
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red



                        For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                            Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                                Case "1"
                                    Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.FromArgb(255, 51, 204)
                                Case "2"
                                Case "3"
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                                    Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Red
                                    Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Black
                                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Black
                            End Select

                        Next
                        Me.dgrBC.Rows(i).Cells("KHU").Appearance.BackColor = Color.FromArgb(255, 255, 255)
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False

                    Case "TCT"

                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                        For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                                Case "3"
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                            End Select
                            Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                        Next
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                    Case Else
                        Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                            Case "3"
                                For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                                Next
                        End Select

                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                End Select
                'Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                'Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.True
            Next
        End If
    End Sub
    Private Sub LoadGridView_NghiViecCDHD_Sathai()
        Try
            Me.XpCaption2.Text = "Thống kê nghỉ việc chấm dứt-sa thải"
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next
                .Columns("DVCU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("NV_Ten").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DV_MA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("LOAI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("STT").Header.Caption = "STT"
                .Columns("NV_MA").Header.Caption = "SỐ THẺ"
                .Columns("DVCU").Header.Caption = "ĐƠN VỊ CŨ"
                .Columns("DV_MA").Header.Caption = "ĐƠN VỊ HIỆN TẠI"
                .Columns("NV_Ten").Header.Caption = "HỌ TÊN"
                .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO"
                .Columns("NV_Ngaysinh").Header.Caption = "NGÀY SINH"
                .Columns("XUONGCU").Header.Caption = "XƯỞNG CŨ"
                .Columns("NGAY").Header.Caption = "NGÀY GIẢM"
                .Columns("GT").Header.Caption = "GIỚI TÍNH"
                .Columns("LOAI").Header.Caption = "LOẠI"

                .Columns("NV_Ngaysinh").Hidden = True
                .Columns("NV_NGAYVAO").Hidden = True
                .Columns("XUONGCU").Hidden = True

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
            End With
        Catch ex As Exception
        End Try
    End Sub

    '' Lưới ngang
    Private Sub LoadGridView_TKNGUYENNHANNGHIVIEC()


        Try
            Me.XpCaption2.Text = "Phân tích nguyên nhân nghĩ việc  "
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next




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
            End With
        Catch ex As Exception
        End Try
    End Sub


    Private Sub XuatExcel_NghiViecCDHD_Sathai()
        Try
            Dim myWorkbook As New Infragistics.Excel.Workbook
            Dim myWorksheet As Infragistics.Excel.Worksheet
            Dim sTungay, sDenNgay As String
            sTungay = CDate(Me.dtpTuNgay.Value).Day.ToString + "/" + CDate(Me.dtpTuNgay.Value).Month.ToString + "/" + CDate(Me.dtpTuNgay.Value).Year.ToString
            sDenNgay = CDate(Me.dtpDenNgay.Value).Day.ToString + "/" + CDate(Me.dtpDenNgay.Value).Month.ToString + "/" + CDate(Me.dtpDenNgay.Value).Year.ToString

            myWorksheet = myWorkbook.Worksheets.Add("NghiViecCDHD_Sathai")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("NghiViecCDHD_Sathai")

            myWorksheet.Rows(0).Cells(1).Value = "THỐNG KÊ DANH SÁCH LAO ĐỘNG NGHỈ VIỆC CHẤM DỨT HỢP ĐỒNG-SA THẢI " & Chr(10) & " TỪ " & sTungay & " ĐẾN " & sDenNgay
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            sheet.MergedCellsRegions.Add(0, 1, 0, 8)
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadGridView_NghiKhongPhep()
        Me.XpCaption2.Text = "Thống kê nghỉ không phép"
        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============
            If chkchitiet.Checked Then
                .Columns(3).Width = 100
                .Columns(1).Width = 250
                .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
            Else
                '.Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                ' .Columns("STT").Header.Caption = "STT"
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"



                .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                .Columns("DUOI2NGAY").Header.Caption = "DƯỚI 2 NGÀY"
                .Columns("TU2DEN5NGAY").Header.Caption = "TỪ 2 NGÀY-DƯỚI 5 NGÀY"
                .Columns("TREN5NGAY").Header.Caption = "5 NGÀY TRỞ LÊN"
                .Columns("X_MA_").Hidden = True
                '.Columns("STT").Hidden = True
                '.Columns("KHUSAPXEP").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub
    Private Sub LoadGridView_ThongKeTonGiao()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("CODOCGIAO").Header.Caption = "Cơ Đốc Giáo" & Chr(10) & "基督教"
            .Columns("HOAHAO").Header.Caption = "Hòa Hảo" & Chr(10) & "和好教"
            .Columns("TINLANH").Header.Caption = "Tin Lành" & Chr(10) & "耶穌教"
            .Columns("CAODAI").Header.Caption = "Cao Đài" & Chr(10) & "高台"
            .Columns("THIENCHUA").Header.Caption = "Thiên Chúa" & Chr(10) & "天主教"
            .Columns("PHAT").Header.Caption = "Phật" & Chr(10) & "佛教"
            .Columns("CONGGIAO").Header.Caption = "Công Giáo" & Chr(10) & "伊斯兰教"
            .Columns("HOIGIAO").Header.Caption = "Hồi Giáo" & Chr(10) & " "
            .Columns("THIENLAM").Header.Caption = "Thiền Lâm" & Chr(10) & " "
            .Columns("KHONG").Header.Caption = "Không" & Chr(10) & "無"
            .Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"
            '.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("NHOM").Hidden = True
            .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            TomauDongTong()
        End With
    End Sub
    Private Sub LoadGridView_ThongKeTuoiGioiTinh()
        If Me.chkchitiet.Checked Then
            DinhDangChung(4)
            With Me.dgrBC.DisplayLayout.Bands(0)
                If chkchitiet.Checked Then
                    .Columns(3).Width = 100
                    .Columns(1).Width = 250
                    .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                    .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                    .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                    .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                    .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                    .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                    .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                    .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
                Else
                    .Columns(1).Width = 150
                    .Columns(3).Width = 280
                    .Columns("NHAXUONG").Header.Caption = "Xưởng"
                    .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns("KHU").Header.Caption = "KHU"
                    .Columns("NV_MA").Header.Caption = "Số thẻ"
                    .Columns("NV_Ten").Header.Caption = "Họ tên"
                    .Columns("DV_MA").Header.Caption = "Đơn vị"
                    .Columns("GIOITINH").Header.Caption = "Giới tính"
                    .Columns("NHOMTUOI").Header.Caption = "Nhóm tuổi"
                    .Columns("TUOI").Header.Caption = "Tuổi"
                    'TomauDongTong()
                End If
                
            End With
        Else
            DinhDangChung(4)
            With Me.dgrBC.DisplayLayout.Bands(0)
                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
                .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                .Columns("NAM").Header.Caption = "NAM" & Chr(10) & "男"
                .Columns("NU").Header.Caption = "NỮ" & Chr(10) & "女"
                .Columns("TUOI18_20").Header.Caption = "18-20歲 TUỔI"
                .Columns("TUOI21_30").Header.Caption = "21-30歲TUỔI"
                .Columns("TUOI31_36").Header.Caption = "31-36歲TUỔI"
                .Columns("TREN_36").Header.Caption = "37歲以上TUỔI" & Chr(10) & "TRỞ LÊN"
                .Columns("TONGSO").Header.Caption = "TỔNG CỘNG" & Chr(10) & "合計 "
                '.Columns("KHU").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                .Columns("NHOM").Hidden = True
                .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                TomauDongTong()
            End With
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
        band.Layout.Override.CellMultiLine = DefaultableBoolean.True
        band.ColHeaderLines = 2

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
    Private Sub LoadGridView_ThongKeTrinhDoHocVan()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("THACSI").Header.Caption = "THẠC SĨ"
            .Columns("DAIHOC").Header.Caption = "ĐẠI HỌC TRỞ" & Chr(10) & "LÊN(16 NĂM)" & Chr(10) & "大學及以上" & Chr(10) & "(16年)"
            .Columns("CAODANG").Header.Caption = "CAO ĐẲNG" & Chr(10) & "(15 NĂM )" & Chr(10) & "專科(15年)"
            .Columns("TRUNGCAP").Header.Caption = "TRUNG CẤP(14 NĂM)" & Chr(10) & "中級(14年)"

            .Columns("THPT").Header.Caption = "TRUNG HỌC PT(12 NĂM)" & Chr(10) & "高中(12年)"
            .Columns("THCS").Header.Caption = "TRUNG HỌC CS(9 NĂM)" & Chr(10) & "初中(9年)"

            .Columns("HV_THAP").Header.Caption = "TIỂU HỌC(5 NĂM)" & Chr(10) & "小學(5年)"

            .Columns("GDTC_KTCN_SPSH").Header.Caption = "KHÁC" & Chr(10) & "其他学问"

            .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG" & Chr(10) & "合計 "
            '.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("NHOM").Hidden = True
            .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            TomauDongTong()
        End With
    End Sub
    Private Sub LoadGridView_ThongKeThamNien()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("CONGNHANMOI").Header.Caption = "CN MỚI" & Chr(10) & "未簽約"
            .Columns("THANG2_3").Header.Caption = "THÁNG 2-3" & Chr(10) & "個月"
            .Columns("THANG3_4").Header.Caption = "THÁNG 3-4" & Chr(10) & "個月"
            .Columns("THANG4_6").Header.Caption = "THÁNG 4-6" & Chr(10) & "個月"
            .Columns("THANG7_12").Header.Caption = "THÁNG 7-12" & Chr(10) & "個月"

            .Columns("NAM1_2").Header.Caption = "NĂM 1-2" & Chr(10) & "年"
            .Columns("NAM2_3").Header.Caption = "NĂM 2-3" & Chr(10) & "年"
            .Columns("NAM3_4").Header.Caption = "NĂM 3-4" & Chr(10) & "年"
            .Columns("NAM5_7").Header.Caption = "NĂM 5-7" & Chr(10) & "年"
            .Columns("NAM7_10").Header.Caption = "NĂM 7-10" & Chr(10) & "年"
            .Columns("TREN10NAM").Header.Caption = "> 10 NĂM" & Chr(10) & "年"
            .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG" & Chr(10) & "合計 "
            ''.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("NHOM").Hidden = True
            .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            TomauDongTong()
        End With
    End Sub

    Private Sub LoadGridView_ThongKeThamNienChiTiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_MA").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
            .Columns("NGAYDDG").Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "离职日期"
        End With
    End Sub
    Private Sub LoadGridView_TyleNghiViecChiTiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_MA").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("NV_GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
            .Columns("NGAYTHOIVIEC").Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "离职日期"
        End With
    End Sub
    Private Sub LoadGridView_TKCNTRONGNGOAITINHChiTiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_MA").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("NV_GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
            .Columns("NV_NGAYTV").Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "离职日期"
        End With
    End Sub

    Private Sub LoadGridView_ThongKeTonGiaoChiTiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_MA").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("NV_GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
            .Columns("NV_NGAYTV").Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "离职日期"
        End With
    End Sub

    Private Sub LoadGridView_ThongKeTrinhDoHocVanChiTiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_MA").Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("NV_GIOITINH").Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
            .Columns("NV_NGAYTV").Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "离职日期"
        End With
    End Sub

    Private Sub LoadGridView_ThongKeThamNienTheoLuong()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            '.Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"

            .Columns("CVU_TEN").Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
            .Columns("DUOI1NAM").Header.Caption = "< 1 NĂM" & Chr(10) & "<1年"
            .Columns("NAM_1").Header.Caption = "NĂM_1" & Chr(10) & "1年"
            .Columns("NAM_2").Header.Caption = "NĂM_2" & Chr(10) & "2年"
            .Columns("NAM_3").Header.Caption = "NĂM_3" & Chr(10) & "3年"
            .Columns("NAM_4").Header.Caption = "NĂM_4" & Chr(10) & "4年"
            .Columns("NAM_5").Header.Caption = "NĂM_5" & Chr(10) & "5年"
            .Columns("NAM_6").Header.Caption = "NĂM_6" & Chr(10) & "6年"
            .Columns("NAM_7").Header.Caption = "NĂM_7" & Chr(10) & "7年"
            .Columns("NAM_8").Header.Caption = "NĂM_8" & Chr(10) & "8年"
            .Columns("NAM_9").Header.Caption = "NĂM_9" & Chr(10) & "9年"
            .Columns("NAM_10").Header.Caption = "NĂM_10" & Chr(10) & "10年"
            .Columns("TREN10NAM").Header.Caption = ">10 NĂM" & Chr(10) & ">10年"
            .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG" & Chr(10) & "合計 "
            '.Columns("KHU").Hidden = True
            '.Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            '.Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("NHOM").Hidden = True
            .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            TomauDongTong()
        End With
    End Sub

    Private Sub LoadGridView_ThongKeThamNienThoiViec_Thang()
        DinhDangChung(4)
        If Me.chkthang.Checked Then
            If Me.chkchitiet.Checked Then
                With Me.dgrBC.DisplayLayout.Bands(0)
                    .Columns(3).Width = 100
                    .Columns(1).Width = 250
                    .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                    .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                    .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                    .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                    .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                    .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                    .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                    .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
                End With
            Else
                With Me.dgrBC.DisplayLayout.Bands(0)
                    .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns("KHU").Header.Caption = "Khu"
                    .Columns("X_MA_").Header.Caption = "Xưởng"
                    .Columns("CONGNHANMOI").Header.Caption = "Công nhân mới"
                    .Columns("DUOI6NGAY").Header.Caption = "Dưới 6 ngày"
                    .Columns("TU7_30NGAY").Header.Caption = "7-30 Ngày"
                    .Columns("TU31_60NGAY").Header.Caption = "31-60 Ngày"
                    .Columns("TREN60NGAY").Header.Caption = "Trên 60 Ngày"
                    .Columns("TONGCONG").Header.Caption = "Tổng cộng"
                    .Columns("NHOM").Hidden = True
                End With
            End If
        Else
            If Me.chkchitiet.Checked Then
                With Me.dgrBC.DisplayLayout.Bands(0)
                    .Columns(3).Width = 100
                    .Columns(1).Width = 250
                    .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                    .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                    .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                    .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                    .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                    .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                    .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                    .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
                End With
            Else
                With Me.dgrBC.DisplayLayout.Bands(0)
                    .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
                    .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                    .Columns("CNM").Header.Caption = "CNM" & Chr(10) & "新工人"
                    .Columns("TU6NGAY").Header.Caption = "< 6NGAY" & Chr(10) & "六天一下"
                    .Columns("TU7DEN30NGAY").Header.Caption = "< 1 THÁNG" & Chr(10) & "一個月內"
                    .Columns("THANG1_2").Header.Caption = "THÁNG 1-2" & Chr(10) & "個月"
                    .Columns("THANG2_3").Header.Caption = "THÁNG 2-3" & Chr(10) & "個月"
                    .Columns("THANG3_4").Header.Caption = "THÁNG 3-4" & Chr(10) & "個月"
                    .Columns("THANG4_7").Header.Caption = "THÁNG 4-7" & Chr(10) & "個月"
                    .Columns("THANG7_12").Header.Caption = "THÁNG 7-12" & Chr(10) & "個月"

                    .Columns("NAM1_2").Header.Caption = "NĂM 1-2" & Chr(10) & "年"
                    .Columns("NAM2_3").Header.Caption = "NĂM 2-3" & Chr(10) & "年"
                    .Columns("NAM3_4").Header.Caption = "NĂM 3-4" & Chr(10) & "年"
                    .Columns("NAM4_5").Header.Caption = "NĂM 4-5" & Chr(10) & "年"
                    .Columns("NAM5_6").Header.Caption = "NĂM 5-6" & Chr(10) & "年"
                    .Columns("NAM6_8").Header.Caption = "NĂM 6-8" & Chr(10) & "年"
                    .Columns("NAM8_10").Header.Caption = "NĂM 8-10" & Chr(10) & "年"
                    .Columns("TREN10NAM").Header.Caption = "> 10 NĂM" & Chr(10) & "年"
                    .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG" & Chr(10) & "合計 "
                    .Columns("SAPXEP").Hidden = True
                    .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                    .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                    .Columns("NHOM").Hidden = True
                    .Columns("NHOM").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                    TomauDongTong()
                End With
            End If
        End If
    End Sub
    Private Sub DinhDangChung(ByVal iCot As Integer)
        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
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
        band.Layout.Override.RowSizing = RowSizing.AutoFree
        band.Layout.Override.CellMultiLine = DefaultableBoolean.True
        band.ColHeaderLines = iCot

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
    End Sub
    Private Sub LoadGridView_TKCNTRONGNGOAITINH()

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============

            '.Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            '.Columns("STT").Header.Caption = "STT"
            .Columns("KHU_TW").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU_TW").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("KHU_TW").Width = 160




            .Columns("TENXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("TXVL").Header.Caption = "永隆 VL"
            .Columns("BINHTAN").Header.Caption = "平新縣BT "
            .Columns("BINHMINH").Header.Caption = "平明縣BM"
            .Columns("TRAON").Header.Caption = "茶溫縣TO"
            .Columns("TAMBINH").Header.Caption = "三平縣TB"
            .Columns("LONGHO").Header.Caption = "隆湖縣LH"
            .Columns("VUNGLIEM").Header.Caption = "永廉縣Vliem"
            .Columns("MANGTHIT").Header.Caption = "芒喜縣MT"
            .Columns("TC_TRONGTINH").Header.Caption = "TC合計"
            .Columns("DONGTHAP").Header.Caption = "同塔省DT"
            .Columns("TRAVINH").Header.Caption = "茶榮省TV"
            .Columns("CANTHO").Header.Caption = "芹苴市CT"


            .Columns("BENTRE").Header.Caption = "檳蜘省Btre"
            .Columns("TIENGIANG").Header.Caption = "前江省TG"

            .Columns("KHAC").Header.Caption = "其他 CL"
            .Columns("TC_NGOAITINH").Header.Caption = "TC 合計"
            .Columns("TC_TRONG_NGOAI_TINH").Header.Caption = "總合計"




            .Columns("TENXUONG").Width = 300
            .Columns("TXVL").Width = 110
            .Columns("BINHTAN").Width = 110
            .Columns("BINHMINH").Width = 110
            .Columns("TRAON").Width = 110
            .Columns("TAMBINH").Width = 110
            .Columns("LONGHO").Width = 110
            .Columns("VUNGLIEM").Width = 110
            .Columns("MANGTHIT").Width = 110
            .Columns("TC_TRONGTINH").Width = 110
            .Columns("DONGTHAP").Width = 110
            .Columns("TRAVINH").Width = 110
            .Columns("CANTHO").Width = 110


            .Columns("BENTRE").Width = 110
            .Columns("TIENGIANG").Width = 110

            .Columns("KHAC").Width = 110
            .Columns("TC_NGOAITINH").Width = 110
            .Columns("TC_TRONG_NGOAI_TINH").Width = 110


            '.Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"

            ' .Columns("X_MA_").Hidden = True
            '.Columns("STT").Hidden = True
            '.Columns("KHU").Hidden = True

            .Columns("KHU_TW").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU_TW").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub
    Private Sub LoadGridView_TKCNNGHIVIECTHEOXUONG()

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============
            If Me.chkchitiet.Checked Then
                .Columns(3).Width = 100
                .Columns(1).Width = 250
                .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
            Else
                '.Columns("THUTU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                ' .Columns("THUTU").Header.Caption = "STT"
                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
                .Columns("KHU").Width = 100
                '.Columns("THUTU").Width = 50
                .Columns("NHAXUONG").Width = 200




                .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                .Columns("BANVIEC_GD").Header.Caption = "Bận việc gia đình"
                .Columns("NUOI_CN").Header.Caption = "Nuôi con nhỏ "
                .Columns("DOICV_DIHOC").Header.Caption = "Đi học - thay đổi CV"
                .Columns("CVIEC_KPH").Header.Caption = "Bố trí CV KPH"
                .Columns("MAUTHUAN_CBQL").Header.Caption = "Mâu thuẫn CBQL"
                .Columns("SUCKHOE_KT").Header.Caption = "Sức khỏe KT - Chết"
                .Columns("HETHAN_HDLD").Header.Caption = "Hết hạn HĐ"
                .Columns("K_HAILONG_CDO_L").Header.Caption = "KHL_CDO_LƯƠNG"
                .Columns("SA_THAI").Header.Caption = "SA THẢI"
                .Columns("BOVIEC").Header.Caption = "BỎ VIỆC"
                .Columns("LYDO_KHAC").Header.Caption = "LÝ DO KHÁC"
                .Columns("TONG").Header.Caption = "TỔNG"

                '.Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"
                .Columns("X_MA_").Hidden = True
                '.Columns("STT").Hidden = True
                '.Columns("KHU").Hidden = True

                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub



    ''CNM
    Private Sub LoadGridView_TKCNM()

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============

            '.Columns("THUTU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            ' .Columns("THUTU").Header.Caption = "STT"
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("KHU").Width = 100
            '.Columns("THUTU").Width = 50
            .Columns("XUONGTIENHOA").Width = 200

            .Columns("X_MA_").Hidden = True


            .Columns("XUONGTIENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("TONGSN").Header.Caption = "Tổng số người總人數"
            .Columns("TONGNV").Header.Caption = "Tổng số nghỉ việc總離職人數"
            .Columns("TONGNV_CNM").Header.Caption = "Số công nhân mới nghỉ việc(Trong vòng 6 tháng)新工離職人數()(6個月內) "
            .Columns("TYLENGHIVIEC_CNM").Header.Caption = "Tỷ lệ CN mới nghỉ việc新工離職率"
            .Columns("TYLENGHIVIEC").Header.Caption = "Tổng tỷ lệ nghỉ(việc)總離職率("")"
            

            '.Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"
           
            '.Columns("STT").Hidden = True
            '.Columns("KHU").Hidden = True

            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub
    '----------
    Private Sub LoadGridView_TKphanBoCN()

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============

            '.Columns("THUTU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            ' .Columns("THUTU").Header.Caption = "STT"
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠區"
            .Columns("KHU").Width = 100
            '.Columns("THUTU").Width = 50
            .Columns("NHAXUONG").Width = 200




            .Columns("NHAXUONG").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("CVIEC_KTH").Header.Caption = "CVIEC_KTH"
            .Columns("NUOI_CN").Header.Caption = "NUOI_CN "
            .Columns("GDINH_DONCHIEC").Header.Caption = "GDINH_DONCHIEC"
            .Columns("SUCKHOE_KT").Header.Caption = "SUCKHOE_KT"
            .Columns("NGHI_BO_VIEC").Header.Caption = "NGHI_BO_VIEC"
            .Columns("HETHAN_HDLD").Header.Caption = "HETHAN_HDLD"
            .Columns("NVQS").Header.Caption = "NVQS"
            .Columns("SA_THAI").Header.Caption = "SA_THAI"
            .Columns("DI_HOC").Header.Caption = "DI_HOC"
            .Columns("LYDO_KHAC").Header.Caption = "LYDO_KHAC"
            .Columns("TONG").Header.Caption = "TONG"

            '.Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"
            .Columns("X_MA_").Hidden = True
            '.Columns("STT").Hidden = True
            '.Columns("KHU").Hidden = True

            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub


    Public Sub GirdColor()
        Dim i As Integer
        For i = 0 To dgrBC.Rows.Count - 1
            If dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "小計" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TC合計" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TỈ LỆ 比率" Then
                '' MÀU CELL

                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TXVL").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BINHTAN").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BINHMINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TRAON").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TAMBINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("LONGHO").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("VUNGLIEM").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("MANGTHIT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("DONGTHAP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TRAVINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("CANTHO").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BENTRE").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TIENGIANG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("KHAC").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.ForeColor = Color.Red

            End If
            If dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP.A 總公司分A廠" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP.B 總公司分B廠" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP總公司" Then
                '' MÀU CELL

                
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.FontData.Bold = DefaultableBoolean.True
                
            End If


            If dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TC合計" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TỈ LỆ 比率" Then

                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TXVL").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BINHTAN").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BINHMINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TRAON").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TAMBINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("LONGHO").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("VUNGLIEM").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("MANGTHIT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("DONGTHAP").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TRAVINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("CANTHO").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BENTRE").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TIENGIANG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("KHAC").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.BackColor = Color.Yellow
                
                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.BackColor = Color.Yellow
              
            End If
        Next

    End Sub
    Public Sub GirdColorNghiViec()
        If Me.chkchitiet.Checked Then

        Else
            Dim i As Integer
            For i = 0 To dgrBC.Rows.Count - 1
                If dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "小計" Or dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "TC合計" Then
                    '' MÀU CELL
                    Me.dgrBC.Rows(i).Cells("NHAXUONG").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("BANVIEC_GD").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("NUOI_CN").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("DOICV_DIHOC").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("CVIEC_KPH").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("MAUTHUAN_CBQL").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SUCKHOE_KT").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("HETHAN_HDLD").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("K_HAILONG_CDO_L").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SA_THAI").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("BOVIEC").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("LYDO_KHAC").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("TONG").Appearance.ForeColor = Color.Red

                End If
                If dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "VP.A 總公司分A廠" Or dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "VP.B 總公司分B廠" Or dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "VP總公司" Then
                    '' MÀU CELL


                    Me.dgrBC.Rows(i).Cells("NHAXUONG").Appearance.FontData.Bold = DefaultableBoolean.True

                End If


                If dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "TC合計" Then
                    ' Me.dgrBC.Rows(i).Cells("THUTU").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("NHAXUONG").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("BANVIEC_GD").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("NUOI_CN").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("DOICV_DIHOC").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("CVIEC_KPH").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("MAUTHUAN_CBQL").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("SUCKHOE_KT").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("HETHAN_HDLD").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("K_HAILONG_CDO_L").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("SA_THAI").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("BOVIEC").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("LYDO_KHAC").Appearance.BackColor = Color.Yellow
                    Me.dgrBC.Rows(i).Cells("TONG").Appearance.BackColor = Color.Yellow

                End If
            Next
        End If

    End Sub


    Public Sub GirdColornNghiViec()
        Dim i As Integer
        For i = 0 To dgrBC.Rows.Count - 1
            If dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "小計" Or dgrBC.Rows(i).Cells("NHAXUONG").Value.ToString() = "TC合計" Then
                '' MÀU CELL
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TXVL").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BINHTAN").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BINHMINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TRAON").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TAMBINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("LONGHO").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("VUNGLIEM").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("MANGTHIT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("DONGTHAP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TRAVINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("CANTHO").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("BENTRE").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TIENGIANG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("KHAC").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.ForeColor = Color.Red

            End If
            If dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP.A 總公司分A廠" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP.B 總公司分B廠" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "VP總公司" Then
                '' MÀU CELL


                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.FontData.Bold = DefaultableBoolean.True

            End If


            If dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TC合計" Or dgrBC.Rows(i).Cells("TENXUONG").Value.ToString() = "TỈ LỆ 比率" Then

                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("KHU_TW").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TXVL").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BINHTAN").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BINHMINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TRAON").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TAMBINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("LONGHO").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("VUNGLIEM").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("MANGTHIT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TC_TRONGTINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("DONGTHAP").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TRAVINH").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("CANTHO").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("BENTRE").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TIENGIANG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("KHAC").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TC_NGOAITINH").Appearance.BackColor = Color.Yellow

                Me.dgrBC.Rows(i).Cells("TC_TRONG_NGOAI_TINH").Appearance.BackColor = Color.Yellow

            End If
        Next

    End Sub

    Private Sub LoadGridView_Thamnienthoiviecnam()

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
            Next
            ''=============

            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("STT").Header.Caption = "STT"
            .Columns("KHUHIENTHI").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"



            .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

            .Columns("CNM").Header.Caption = "< 1 THÁNG " & Chr(10) & "一個月內("")"
            .Columns("T2_3").Header.Caption = "THÁNG 2-3 " & Chr(10) & "個月"
            .Columns("T4_6").Header.Caption = "THÁNG 4-6 " & Chr(10) & "個月"
            .Columns("T7_12").Header.Caption = "THÁNG 7-12 " & Chr(10) & "個月"
            .Columns("N1_2").Header.Caption = "NĂM " & Chr(10) & "1 ~ 2 年"
            .Columns("N2_3").Header.Caption = "NĂM " & Chr(10) & "2 ~ 3 年"
            .Columns("N3_4").Header.Caption = "NĂM " & Chr(10) & "3 ~ 4 年"
            .Columns("N4_5").Header.Caption = "NĂM " & Chr(10) & "4 ~ 5 年"
            .Columns("N5_6").Header.Caption = "NĂM " & Chr(10) & "5 ~ 6 年"
            .Columns("N6_8").Header.Caption = "NĂM " & Chr(10) & "6 ~ 8 年"
            .Columns("N8_10").Header.Caption = "NĂM " & Chr(10) & "8 ~ 10 年"
            .Columns("N_TREN10NAM").Header.Caption = "TRÊN 10 NĂM " & Chr(10) & "年"
            .Columns("TONGSO").Header.Caption = "TC " & Chr(10) & "合計"

            .Columns("X_MA_").Hidden = True
            .Columns("STT").Hidden = True
            .Columns("KHU").Hidden = True

            .Columns("KHUHIENTHI").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHUHIENTHI").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

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
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 2

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
    End Sub


    Private Sub LoadGridView_NghiViecKLyDo()
        Try
            Me.XpCaption2.Text = "Thống kê nghỉ việc không lý do"
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Dim cot_i As Integer
            cot_i = 1

            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
                Me.dgrBC.DisplayLayout.Override.NullText = "0" ''----------------------
                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

                    .Columns(i).Tag = ""

                    .Columns(i).Hidden = False

                    Dim ngayketthuc As String = CDate(Me.dtpDenNgay.Value).Day.ToString()


                    Try
                        If .Columns(i).Key.ToString() = "28" Or .Columns(i).Key.ToString() = "29" Or .Columns(i).Key.ToString() = "30" Or .Columns(i).Key.ToString() = "31" Then

                            If CInt(.Columns(i).Key.ToString()) > ngayketthuc Then
                                .Columns(i).Hidden = True
                            End If
                        End If
                        .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
                    Catch ex As Exception

                    End Try

                Next
                ''=============
                If Me.chkchitiet.Checked Then
                    .Columns(3).Width = 100
                    .Columns(1).Width = 250
                    .Columns(0).Header.Caption = "SỐ TT" & Chr(10) & "序號"
                    .Columns(1).Header.Caption = "HỌ TÊN" & Chr(10) & "姓名"
                    .Columns(2).Header.Caption = "SỐ THẺ" & Chr(10) & "工號"
                    .Columns(3).Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                    .Columns(4).Header.Caption = "NGÀY VÀO CÔNG TY" & Chr(10) & "入廠期"
                    .Columns(5).Header.Caption = "CHỨC VỤ" & Chr(10) & "職務"
                    .Columns(6).Header.Caption = "GIỚI TÍNH" & Chr(10) & "性別"
                    .Columns(7).Header.Caption = "NGÀY THÔI VIỆC" & Chr(10) & "離職日期"
                Else
                    '.Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    '.Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    '.Columns("STT").Header.Caption = "STT"
                    .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
                    '.Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                    .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                    '.Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                    .Columns("TONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                    .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                    .Columns("TONG").Header.Caption = "Tổng" & Chr(10) & ""
                    .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                    .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                    .Columns("X_MA_").Hidden = True
                    '.Columns("STT").Hidden = True
                    '.Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                    '.Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
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
                band.Layout.Override.CellMultiLine = DefaultableBoolean.True
                band.ColHeaderLines = 2

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

    Private Sub XuatExcel_DinhdangchungFooter(ByVal dongbt_Duyet As Integer, ByVal dongkt_Duyet As Integer, ByVal cotbt_Duyet As Integer, ByVal cotkt_Duyet As Integer, ByVal dongbt_ChuQuan As Integer, ByVal dongkt_ChuQuan As Integer, ByVal cotbt_ChuQuan As Integer, ByVal cotkt_ChuQuan As Integer, ByVal dongbt_LapBieu As Integer, ByVal dongkt_LapBieu As Integer, ByVal cotbt_LapBieu As Integer, ByVal cotkt_LapBieu As Integer, ByVal dongbd_Tennguoilap As Integer, ByVal dongkt_TenNguoiLap As Integer, ByVal cotbd_TenNguoiLap As Integer, ByVal cotkt_TenNguoiLap As Integer)

    End Sub

    Private Sub XuatExcel_DinhdangchungTieude(ByVal sTensheet As String, ByVal sTieuDeViet As String, ByVal sTieuDeHoa As String, ByVal vitridong As Integer, ByVal vitricotbd As Integer, ByVal vitricotkt As Integer)
        Dim sodong As Integer
        Dim socottong, cotan, i, cotShow As Integer
        Dim socotAn As Integer
        sodong = dgrBC.Rows.Count
        socottong = dgrBC.DisplayLayout.Bands(0).Columns.Count
        '' vì khi lên lưới một số cột ẩn nên phải đếm số cột ẩn loại ra để tiêu đề đúng vị trí 
        For i = 0 To socottong - 1
            If dgrBC.DisplayLayout.Bands(0).Columns.Item(i).Hidden = True Then
                socotAn += 1
            End If
        Next
        cotShow = socottong - socotAn
        Dim vitriChuQuan, viTriLapBieu, vitriTen, viTriIso, vitriDuyet As Integer
        If socottong > 4 Then
            If chkchitiet.Checked Then
                vitriChuQuan = 3
                viTriLapBieu = cotShow - 2
                vitriTen = viTriLapBieu
                viTriIso = viTriLapBieu + 1
                vitriDuyet = 1
            Else
                vitriChuQuan = cotShow / 2
                viTriLapBieu = cotShow - 2
                vitriTen = viTriLapBieu
                viTriIso = viTriLapBieu - 3
                vitriDuyet = 0

            End If
            
        Else
            vitriChuQuan = 1
            viTriLapBieu = 1
            vitriTen = 1
            viTriIso = 1
            vitriDuyet = 0
        End If
        Dim bienDuyet, bienIso, bienTen, bienChuQuan, bienLapBieu As String
        If socottong > 4 Then
            bienDuyet = "DUYỆT審核:"
            bienIso = "T-HR-101A/LD"
            bienTen = ""
            bienChuQuan = "CHỦ QUẢN主管"
            bienLapBieu = "LẬP BIỂU制表:"
        Else
            bienChuQuan = "CHỦ QUẢN主管                  LẬP BIỂU制表:"
            bienIso = "T-HR-101A/LD                                     "
        End If


        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            myWorksheet = myWorkbook.Worksheets.Add(sTensheet)
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets(sTensheet)
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            myWorksheet.Rows(1).Height = 800
            myWorksheet.Rows(0).Cells(1).Value = sTieuDeViet & Chr(10) & sTieuDeHoa

            If chkchitiet.Checked Then
                sheet.MergedCellsRegions.Add(0, vitricotbd, 0, socottong - 1)
            Else
                sheet.MergedCellsRegions.Add(0, vitricotbd, 0, socottong - 2)
            End If

            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, vitridong, vitricotbd)
           

            myWorksheet.Rows(sodong + 5).Cells(vitriDuyet).Value = bienDuyet
            myWorksheet.Rows(sodong + 5).Cells(vitriChuQuan).Value = bienChuQuan
            myWorksheet.Rows(sodong + 5).Cells(viTriLapBieu).Value = bienLapBieu

            myWorksheet.Rows(sodong + 9).Cells(viTriIso).Value = bienIso
            myWorksheet.Rows(sodong + 9).Cells(vitriTen).Value = bienTen



            myWorksheet.Rows(sodong + 5).Cells(vitriDuyet).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(sodong + 5).Cells(vitriChuQuan).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(sodong + 5).Cells(viTriLapBieu).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(sodong + 9).Cells(viTriIso).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(sodong + 9).Cells(vitriTen).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub



    Private Sub XuatExcel_NghiViecKLyDo()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            myWorksheet = myWorkbook.Worksheets.Add("TKLDNGHIKLYDO")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TKLDNGHIKLYDO")
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            myWorksheet.Rows(0).Cells(1).Value = "SỐ LAO ĐỘNG NGHỈ VIỆC KHÔNG LÝ DO" & Chr(10) & " "

            ''-------
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(1).Value = "XƯỞNG" & Chr(10) & "廠別"
            myWorksheet.Rows(1).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(1).Value = "XƯỞNG" & Chr(10) & "廠別"


            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(2).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).Value = "ĐƠN VỊ" & Chr(10) & "單位"

            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500

            myWorksheet.DisplayOptions.ShowZeroValues = False
            myWorksheet.Rows(1).Cells(3).Value = "Ngày"

            Dim songayketthuc As Integer
            songayketthuc = CDate(Me.dtpDenNgay.Value).Day

            Select Case songayketthuc
                Case 28
                    sheet.MergedCellsRegions.Add(0, 1, 0, 31)
                    sheet.MergedCellsRegions.Add(1, 1, 2, 1)
                    sheet.MergedCellsRegions.Add(1, 3, 1, 30)
                    sheet.MergedCellsRegions.Add(1, 2, 2, 2)
                    sheet.MergedCellsRegions.Add(1, 31, 2, 31)
                    myWorksheet.Rows(1).Cells(31).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(31).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(31).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(31).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(31).Value = "Tổng" & Chr(10) & ""
                    myWorksheet.Rows(1).Cells(31).CellFormat.FillPatternBackgroundColor = Color.White
                    myWorksheet.Rows(1).Cells(31).CellFormat.FillPatternForegroundColor = Color.White

                    myWorksheet.Rows(1).Cells(31).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(1).Cells(31).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(1).Cells(31).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(31).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(31).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(1).Cells(31).CellFormat.VerticalAlignment = VerticalCellAlignment.Center

                    For i = 3 To 31
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Height = 200
                        myWorksheet.Rows(1).Height = 500


                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternBackgroundColor = Color.White
                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternForegroundColor = Color.White

                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Height = 200

                        myWorksheet.Rows(1).Cells(i).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

                    Next
                Case 29

                    sheet.MergedCellsRegions.Add(0, 1, 0, 32)
                    sheet.MergedCellsRegions.Add(1, 1, 2, 1)
                    sheet.MergedCellsRegions.Add(1, 3, 1, 31)
                    sheet.MergedCellsRegions.Add(1, 2, 2, 2)
                    sheet.MergedCellsRegions.Add(1, 32, 2, 32)
                    myWorksheet.Rows(1).Cells(32).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(32).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(32).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(32).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(32).Value = "Tổng" & Chr(10) & ""
                    myWorksheet.Rows(1).Cells(32).CellFormat.FillPatternBackgroundColor = Color.White
                    myWorksheet.Rows(1).Cells(32).CellFormat.FillPatternForegroundColor = Color.White

                    myWorksheet.Rows(1).Cells(32).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(1).Cells(32).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(1).Cells(32).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(32).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(32).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(1).Cells(32).CellFormat.VerticalAlignment = VerticalCellAlignment.Center

                    For i = 3 To 32
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Height = 200
                        myWorksheet.Rows(1).Height = 500


                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternBackgroundColor = Color.White
                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternForegroundColor = Color.White

                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Height = 200

                        myWorksheet.Rows(1).Cells(i).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

                    Next
                Case 30

                    sheet.MergedCellsRegions.Add(0, 1, 0, 33)
                    sheet.MergedCellsRegions.Add(1, 1, 2, 1)
                    sheet.MergedCellsRegions.Add(1, 3, 1, 32)
                    sheet.MergedCellsRegions.Add(1, 2, 2, 2)
                    sheet.MergedCellsRegions.Add(1, 33, 2, 33)
                    myWorksheet.Rows(1).Cells(33).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(33).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(33).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(33).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(33).Value = "Tổng" & Chr(10) & ""
                    myWorksheet.Rows(1).Cells(33).CellFormat.FillPatternBackgroundColor = Color.White
                    myWorksheet.Rows(1).Cells(33).CellFormat.FillPatternForegroundColor = Color.White

                    myWorksheet.Rows(1).Cells(33).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(1).Cells(33).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(1).Cells(33).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(33).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(33).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(1).Cells(33).CellFormat.VerticalAlignment = VerticalCellAlignment.Center

                    For i = 3 To 33
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Height = 200
                        myWorksheet.Rows(1).Height = 500


                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternBackgroundColor = Color.White
                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternForegroundColor = Color.White

                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Height = 200

                        myWorksheet.Rows(1).Cells(i).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

                    Next

                Case 31
                    sheet.MergedCellsRegions.Add(0, 1, 0, 34)
                    sheet.MergedCellsRegions.Add(1, 1, 2, 1)
                    sheet.MergedCellsRegions.Add(1, 3, 1, 33)
                    sheet.MergedCellsRegions.Add(1, 2, 2, 2)
                    sheet.MergedCellsRegions.Add(1, 34, 2, 34)
                    myWorksheet.Rows(1).Cells(34).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(34).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(34).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(34).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(1).Cells(34).Value = "Tổng" & Chr(10) & ""
                    myWorksheet.Rows(1).Cells(34).CellFormat.FillPatternBackgroundColor = Color.White
                    myWorksheet.Rows(1).Cells(34).CellFormat.FillPatternForegroundColor = Color.White

                    myWorksheet.Rows(1).Cells(34).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(1).Cells(34).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(1).Cells(34).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(34).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(1).Cells(34).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(1).Cells(34).CellFormat.VerticalAlignment = VerticalCellAlignment.Center

                    For i = 3 To 34
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(1).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(1).Cells(i).CellFormat.Font.Height = 200
                        myWorksheet.Rows(1).Height = 500


                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternBackgroundColor = Color.White
                        myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternForegroundColor = Color.White

                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(3).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(3).Cells(i).CellFormat.Font.Height = 200

                        myWorksheet.Rows(1).Cells(i).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(1).Cells(i).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

                    Next

            End Select
            'sheet.MergedCellsRegions.Add(0, 1, 0, 34)
            'sheet.MergedCellsRegions.Add(1, 1, 2, 1)
            'sheet.MergedCellsRegions.Add(1, 3, 1, 33)
            'sheet.MergedCellsRegions.Add(1, 2, 2, 2)
            'sheet.MergedCellsRegions.Add(1, 34, 2, 34)

            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub XuatExcel_Thamnienthoiviecnam()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Dim sheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        myWorksheet = myWorkbook.Worksheets.Add("TKTNTV_NAM")
        sheet = myWorkbook.Worksheets("TKTNTV_NAM")
        If Me.radTCT.Checked Then
            myWorksheet.Rows(1).Cells(1).Value = "BẢNG PHÂN TÍCH NGHỈ VIỆC THEO THÂM NIÊN NĂM " & CDate(Me.dtpDenNgay.Text).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Text).Year.ToString() & " 年份各廠員工(按年資)離職分析圖表"
        End If

        If Me.radKhuA.Checked Then
            myWorksheet.Rows(1).Cells(1).Value = "BẢNG PHÂN TÍCH NGHỈ VIỆC THEO THÂM NIÊN NĂM KHU A " & CDate(Me.dtpDenNgay.Text).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Text).Year.ToString() & " 年份各廠員工(按年資)離職分析圖表"
        End If

        If Me.radKhuB.Checked Then
            myWorksheet.Rows(1).Cells(1).Value = "BẢNG PHÂN TÍCH NGHỈ VIỆC THEO THÂM NIÊN NĂM KHU B " & CDate(Me.dtpDenNgay.Text).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Text).Year.ToString() & " 年份各廠員工(按年資)離職分析圖表"
        End If

        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
        myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
        myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 300
        myWorksheet.Rows(1).Height = 800
        ''-------
        sheet.MergedCellsRegions.Add(1, 1, 1, 16)
        Try
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub XuatExcel_NghiKhongPhep()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Dim sheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        myWorksheet = myWorkbook.Worksheets.Add("TKNGHIKPHEP")
        sheet = myWorkbook.Worksheets("TKNGHIKPHEP")
        myWorksheet.Rows(1).Cells(1).Value = "THỐNG KÊ NGHỈ KHÔNG PHÉP " & Chr(10) & " TỪ NGÀY " & Me.dtpDenNgay.Text & " ĐẾN NGÀY " & Me.dtpDenNgay.Text

        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
        myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
        myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
        myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 300
        myWorksheet.Rows(1).Height = 800

        ''-------

        sheet.MergedCellsRegions.Add(1, 1, 1, 5)


        Try
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub XuatExcel_NghiViec()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Dim sheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            Select Case cboLoaiBaocao.Value
                Case "TKTYLENGHIVIECNAM_CNTT"
                    myWorksheet = myWorkbook.Worksheets.Add("TKCNTT_NGHIVIEC")
                    sheet = myWorkbook.Worksheets("TKCNTT_NGHIVIEC")
                    myWorksheet.Rows(0).Cells(1).Value = "BẢNG PHÂN TÍCH TỈ LỆ NGHỈ VIỆC LAO ĐỘNG LÀM VIỆC TRỰC TIẾP NĂM " & CDate(Me.dtpDenNgay.Value).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Value).Year.ToString() & " 年份各廠離職"
                Case "TKTYLENGHIVIECNAM"
                    myWorksheet = myWorkbook.Worksheets.Add("TKTYLE_NGHIVIEC")
                    sheet = myWorkbook.Worksheets("TKTYLE_NGHIVIEC")
                    myWorksheet.Rows(0).Cells(1).Value = "BẢNG PHÂN TÍCH TỈ LỆ NĂM " & CDate(Me.dtpDenNgay.Value).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Value).Year.ToString() & " 年份各廠離職"
            End Select


            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800

            ''-------

            sheet.MergedCellsRegions.Add(0, 1, 0, 16)

            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)

            For i As Integer = 0 To 16
                myWorksheet.Rows(2).Cells(i).CellFormat.FillPatternBackgroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(2).Cells(i).CellFormat.FillPattern = FillPatternStyle.None
            Next
            sheet.MergedCellsRegions.Add(2, 2, 2, 3)
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(1).Value = "DUYỆT審核:"
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(4).Value = "CHỦ QUẢN主管:"
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(14).Value = "LẬP BIỂU制表:"
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(14).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(dgrBC.Rows.Count + 5).Cells(14).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

            myWorksheet.Rows(dgrBC.Rows.Count + 8).Cells(14).Value = "Lê Vũ Quỳnh Giao"
            myWorksheet.Rows(dgrBC.Rows.Count + 8).Cells(14).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dgrBC.Rows.Count + 8).Cells(14).CellFormat.Font.Italic = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dgrBC.Rows.Count + 8).Cells(14).CellFormat.Alignment = HorizontalCellAlignment.Center

            myWorksheet.Rows(dgrBC.Rows.Count + 9).Cells(14).Value = "T-HR-103/LD"
            myWorksheet.Rows(dgrBC.Rows.Count + 9).Cells(14).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dgrBC.Rows.Count + 9).Cells(14).CellFormat.Alignment = HorizontalCellAlignment.Right
            sheet.MergedCellsRegions.Add(dgrBC.Rows.Count + 5, 1, dgrBC.Rows.Count + 5, 3)
            sheet.MergedCellsRegions.Add(dgrBC.Rows.Count + 5, 4, dgrBC.Rows.Count + 5, 13)
            sheet.MergedCellsRegions.Add(dgrBC.Rows.Count + 5, 14, dgrBC.Rows.Count + 5, 16)
            sheet.MergedCellsRegions.Add(dgrBC.Rows.Count + 8, 14, dgrBC.Rows.Count + 8, 16)
            sheet.MergedCellsRegions.Add(dgrBC.Rows.Count + 9, 14, dgrBC.Rows.Count + 9, 16)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        If cboLoaiBaocao.Value = "" Then
            MessageBox.Show("Chưa chọn loại thống kê ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboLoaiBaocao.Focus()
        Else
            Dim obj As New objBaoCaoTongHop
            If Me.dtpDenNgay.IsInEditMode() Then
                dtpDenNgay.Editor.ExitEditMode(True, True)
            End If
            Dim schuoitieude As String = "Thống kê "

            If Me.radKhuA.Checked Then
                obj.Chonkhu = "A"
            End If

            If Me.radKhuB.Checked Then
                obj.Chonkhu = "B"
            End If

            If Me.radDVC.Checked Then
                obj.Chonkhu = "DVC"
            End If

            If Me.radTCT.Checked Then
                obj.Chonkhu = "TCT"
            End If

            If Me.chkTinhCNM.Checked Then
                obj.TinhCNM = 1
            Else
                obj.TinhCNM = 0
            End If

            Me.XpCaption2.Text = schuoitieude + Me.cboLoaiBaocao.Text + " " + obj.Chonkhu

            Select Case cboLoaiBaocao.Value
                Case "TKTG"    '' thống kê tôn giáo
                    methodLoad_ThongKeTonGiao(obj.Chonkhu)

                Case "TKTUOIGT"  ''tuổi , giới tính

                    methodLoad_ThongKeTuoiGioiTinh(obj.Chonkhu)

                Case "TKTD"  ''trình độ học vấn
                    methodLoad_ThongKeTrinhDoHocVan(obj.Chonkhu)

                Case "TKTN" '' thống kê thâm niên
                    methodLoad_ThongKeThamNien(obj.Chonkhu)

                Case "TKTNTV_T" '' thâm niên thôi việc theo tháng

                    methodLoad_ThongKeThamNienThoiViec_Thang(obj.Chonkhu)

                Case "TKNGHIVIECKHONGLYDO"

                    methodLoad_SoLaoDongNghiViecKLyDo(obj.Chonkhu) ''trong thủ tục có tính đơn vị CNM
                    LoadGridView_NghiViecKLyDo()

                    ' Case "TKTYLENGHIVIECNAM_CNTT"
                    'Me.XpCaption2.Text = "Bảng thống kê tỷ lệ nghỉ việc lao động làm việc trực tiếp theo năm"
                    'If Me.radTCT.Checked Then
                    'methodLoad_TyleCNTTNghiViec_TCT()
                    ' Else
                    'methodLoad_TyleCNTTNghiViec_Khu(obj.Chonkhu)
                    ' End If
                    ' LoadGridView_TyleNghiViec()

                Case "TKTYLENGHIVIECNAM"
                    Me.XpCaption2.Text = "Bảng thống kê tỷ lệ nghỉ việc theo năm"
                    ''If Me.radTCT.Checked Then
                    'methodLoad_TyleNghiViec_TCT()
                    'Else
                    methodLoad_TyleNghiViec(obj.Chonkhu)
                    ' End If
                    If chkchitiet.Checked = True Then
                        LoadGridView_TyleNghiViecChiTiet()
                    Else
                        LoadGridView_TyleNghiViec()
                    End If

                Case "TKNGHIVIEC_GCDHD"
                    Me.XpCaption2.Text = "Thống kê danh sách nghỉ việc giảm-chấm dứt hợp đồng"
                    methodLoad_NghiViecCDHD_Sathai()
                    LoadGridView_NghiViecCDHD_Sathai()

                Case "TKNGHIKHONGPHEP"
                    Me.XpCaption2.Text = "Thống kê nghỉ không phép"
                    methodLoad_NghiKhongPhep()
                    If dgrBC.Rows.Count > 0 Then
                        LoadGridView_NghiKhongPhep()
                    End If


                Case "TKTNTV_N"
                    Me.XpCaption2.Text = "Thống kê thâm niên thôi việc theo năm"
                    methodLoad_ThamnienthoiviecNam()
                    LoadGridView_Thamnienthoiviecnam()

                Case "TKTNGTINH"
                    Me.XpCaption2.Text = "Thống kê tình hình phân bố cán bộ trong và ngoài tỉnh"
                    methodLoad_TKCNTrongNgoaiTinh()


                Case "TKLDNGHIVIEC_T"
                    Me.chkchitiet.Visible = True
                    Me.XpCaption2.Text = "Thống kê nguyên nhân nghĩ việc mỗi tháng của xưởng"
                    methodLoad_TKCNTNGHITHEOXUONG()
                    LoadGridView_TKCNNGHIVIECTHEOXUONG()
                    GirdColorNghiViec()

                Case "TKTHLUUDONG"
                    Me.XpCaption2.Text = "Thống kê tình hình phân bố công nhân"
                    methodLoad_TKtinhinhPhanBoCN()

                Case "TKTYLENGHIVIECNAM_CNTT"
                    Me.XpCaption2.Text = "Thống kê tỷ lệ nghĩ việc công nhân "
                    methodLoad_TyleCNTTNghiViec()
                    LoadGridView_TyleNghiViec()
                Case "TKLDNGHIVIEC_N"
                    Me.XpCaption2.Text = "Thống kê nguyên nhân nghĩ việc năm"
                    methodLoad_TKNGHIVIECNAM()
                    LoadGridView_TKNGUYENNHANNGHIVIEC()

                Case "TKTYLENGHIVIECCNM_THANG"
                    Me.XpCaption2.Text = "Thống kê số lượng nghỉ việc cnm theo tháng"
                    methodLoad_TKCNMNGHIVIEC()
                    LoadGridView_TKCNM()
                Case "TKDANHSACHMANGTHAI"
                    Me.XpCaption2.Text = "Thống kê danh sách mang thai chi tiết theo tháng"
                    methodLoad_TKDANHSACHMANGTHAI()
                    LoadGridView_MANGTHAI()
                Case "TKTROCAPNUOICONDUOI6T"
                    Me.XpCaption2.Text = "Danh sách chi tiết trợ cấp con dưới 6 tuổi theo tháng"
                    methodLoad_TKTROCAPNUOICONDUOI6T()
                    Try
                        LoadGridView_TROCAP6T()
                    Catch ex As Exception

                    End Try
            End Select

        End If

    End Sub
    Private Sub methodLoad_TyleNghiViec(ByVal sKhu As String)
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        Dim bChonTCT As Boolean

        If sKhu = "TCT" Then
            bChonTCT = True
        Else
            bChonTCT = False
        End If


        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        If chkchitiet.Checked = True Then
            listpar.Add(New SqlParameter("@ngay", CDate(Me.dtpDenNgay.Value)))
            tblThongKeXuong = Me.b.Load("SP_BCTH_PHANTICHTYLENGHIVIEC_CHITIET", listpar)
        Else

            ''===========
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_D", listpar1)
            listpar1.Clear()

            For i = 1 To 12
                listpar1.Add(New SqlParameter("@THANG", i))
                listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I", listpar1)
                listpar1.Clear()
            Next

            For i = 1 To 12
                listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar1.Add(New SqlParameter("@THANG", i))
                Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_THANG_MOI", listpar1)
                listpar1.Clear()
            Next

            obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_TCT", listpar1)
            listpar1.Clear()


            ''============== LẶP TỪNG XƯỞNG ===============''
            Dim tblTemp, tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongDVC As DataTable

            If bChonTCT Then
                tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_MOI_TINHCNM_S")
                If tblDMXuongKhuA.Rows.Count > 0 And sKhu = "TCT" Then
                    For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "A"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_MOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If

                tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_MOI_S")
                If tblDMXuongKhuB.Rows.Count > 0 And sKhu = "TCT" Then
                    For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "B"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_MOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If


                tblDMXuongDVC = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUDVC_S")
                If tblDMXuongDVC.Rows.Count > 0 And sKhu = "TCT" Then
                    For i As Integer = 0 To tblDMXuongDVC.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongDVC.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongDVC.Rows(i).Item("X_MA_").ToString() = "TONGKHUDVC" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongDVC.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "DVC"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If

                listpar2.Clear()
                listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
                listpar2.Add(New SqlParameter("@XUONGTENHOA", "TC合計"))
                listpar2.Add(New SqlParameter("@KHU", "TCT"))
                tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_MOI_S", listpar2)

                If tblTemp.Rows.Count > 0 Then
                    tblThongKeXuong.Merge(tblTemp)
                End If
                listpar2.Clear()
            Else
                '' theo khu ------------------------------------------------------------------
                tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_MOI_TINHCNM_S")
                If tblDMXuongKhuA.Rows.Count > 0 And sKhu = "A" Then
                    For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "A"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_MOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If




                tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_MOI_S")
                If tblDMXuongKhuB.Rows.Count > 0 And sKhu = "B" Then
                    For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "B"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_MOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If


                tblDMXuongDVC = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUDVC_S")
                If tblDMXuongDVC.Rows.Count > 0 And sKhu = "DVC" Then
                    For i As Integer = 0 To tblDMXuongDVC.Rows.Count - 1
                        listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                        listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                        listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongDVC.Rows(i).Item("X_MA_").ToString()))
                        If tblDMXuongDVC.Rows(i).Item("X_MA_").ToString() = "TONGKHUDVC" Then
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                        Else
                            listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongDVC.Rows(i).Item("X_MA_").ToString() & " 廠"))
                        End If
                        listpar2.Add(New SqlParameter("@KHU", "DVC"))
                        tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_LUOI_S", listpar2)

                        If tblTemp.Rows.Count > 0 Then
                            tblThongKeXuong.Merge(tblTemp)
                        End If
                        listpar2.Clear()
                    Next
                End If

            End If

        End If
        Me.dgrBC.DataSource = tblThongKeXuong

    End Sub
    Private Sub LoadGridView_MANGTHAI()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("KHU").Header.Caption = "KHU"
            .Columns("X_MA_").Header.Caption = "NHÀ XƯỞNG"

            .Columns("NV_MA").Header.Caption = "SỐ THẺ"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN NHÂN VIÊN"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ"
            .Columns("NGAYMANGTHAI").Header.Caption = "NGÀY MANG THAI"

            .Columns("NGAYVE15H30").Header.Caption = "NGÀY VỀ 15H30"
            .Columns("NGAYDUSINH").Header.Caption = "NGÀY DỰ SINH"
            .Columns("MANGTHAIDUOI7T").Header.Caption = "THAI DƯỚI 7 THÁNG"

            .Columns("MANGTHAITREN7T").Header.Caption = "THAI TRÊN 7 THÁNG"

            .Columns("NUOICONNHO").Header.Caption = "NUÔI CON NHỎ"

            .Columns("NGHITHAISAN").Header.Caption = "NGHỈ THAI SẢN"
            '.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("X_MA_").MergedCellStyle = MergedCellStyle.Always
            .Columns("X_MA_").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        End With
    End Sub
    Private Sub LoadGridView_TROCAP6T()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("KHU").Header.Caption = "KHU"
            .Columns("X_MA_").Header.Caption = "NHÀ XƯỞNG"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ"
            .Columns("DV_MA").Width = 150
            .Columns("NV_MA").Header.Caption = "SỐ THẺ"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN NHÂN VIÊN"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("NGAYSANHCON").Header.Caption = "NGÀY SINH CON"

            .Columns("NGAYHETHAN").Header.Caption = "NGÀY HẾT HẠN"
            .Columns("TUOI").Header.Caption = "TUỔI CON"
            .Columns("THANGTUOI").Header.Caption = "THÁNG TUỔI"

            .Columns("DENGHITHANGTRUOC").Header.Caption = "ĐỀ NGHỊ THÁNG TRƯỚC"
            .Columns("DENGHITHANGTRUOC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("TANGTHEM").Header.Caption = "TĂNG THÊM THÁNG NÀY"
            .Columns("TANGTHEM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            '.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("X_MA_").MergedCellStyle = MergedCellStyle.Always
            .Columns("X_MA_").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("DV_MA").MergedCellStyle = MergedCellStyle.Always
            .Columns("DV_MA").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        End With
    End Sub
    Private Sub LoadGridView_TyleNghiViec()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                'Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.FromArgb(255, 255, 255)

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1

                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Tag = ""
                    .Columns(i).Hidden = False
                    .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
                Next
                ''=============
                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
                .Columns("TIEUDE").Header.Caption = ""
                .Columns("LOAI").Hidden = True
                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
                .Columns("TONG").Header.Caption = "NĂM" & Chr(10) & "年"
                .Columns("X_MA_").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                .Columns("XUONGTENHOA").MergedCellStyle = MergedCellStyle.Always
                .Columns("XUONGTENHOA").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

                .Columns("T1").Header.Caption = "THÁNG 1" & Chr(10) & "月份"
                .Columns("T2").Header.Caption = "THÁNG 2" & Chr(10) & "月份"
                .Columns("T3").Header.Caption = "THÁNG 3" & Chr(10) & "月份"
                .Columns("T4").Header.Caption = "THÁNG 4" & Chr(10) & "月份"
                .Columns("T5").Header.Caption = "THÁNG 5" & Chr(10) & "月份"
                .Columns("T6").Header.Caption = "THÁNG 6" & Chr(10) & "月份"
                .Columns("T7").Header.Caption = "THÁNG 7" & Chr(10) & "月份"
                .Columns("T8").Header.Caption = "THÁNG 8" & Chr(10) & "月份"
                .Columns("T9").Header.Caption = "THÁNG 9" & Chr(10) & "月份"
                .Columns("T10").Header.Caption = "THÁNG 10" & Chr(10) & "月份"
                .Columns("T11").Header.Caption = "THÁNG 11" & Chr(10) & "月份"
                .Columns("T12").Header.Caption = "THÁNG 12" & Chr(10) & "月份"

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
                band.Layout.Override.CellMultiLine = DefaultableBoolean.True
                band.ColHeaderLines = 2

                'band.Layout.Override.RowSelectors = DefaultableBoolean.True
                'band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
                'band.Layout.Bands(0).Summaries.Clear()
                'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                'summary.Appearance.TextHAlign = HAlign.Right
                'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                'band.SummaryFooterCaption = "Tổng số: "
                'band = Nothing
            End With
        Catch ex As Exception
        End Try
        If Me.dgrBC.Rows.Count > 0 Then
            Me.btnExcel.Enabled = True
            For i = 0 To dgrBC.Rows.Count - 1
                Select Case dgrBC.Rows(i).Cells("X_MA_").Value.ToString()
                    Case "TONGKHUA", "TONGKHUB"
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red



                        For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                            Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                                Case "1"
                                    Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.FromArgb(255, 51, 204)
                                Case "2"
                                Case "3"
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                                    Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Red
                                    Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Black
                                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Black
                            End Select

                        Next
                        Me.dgrBC.Rows(i).Cells("KHU").Appearance.BackColor = Color.FromArgb(255, 255, 255)
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False

                    Case "TCT"

                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                        For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                                Case "3"
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                            End Select
                            Me.dgrBC.Rows(i).Cells(j).Appearance.BackColor = Color.FromArgb(217, 217, 217)
                        Next
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                    Case Else
                        Select Case Me.dgrBC.Rows(i).Cells("LOAI").Value.ToString()
                            Case "3"
                                For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.ForeColor = Color.Blue
                                    Me.dgrBC.Rows(i).Cells(j).Appearance.FontData.Bold = DefaultableBoolean.True
                                Next
                        End Select

                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                End Select
                'Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.ForeColor = Color.Black
                'Me.dgrBC.Rows(i).Cells("TIEUDE").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.True
            Next
        End If
    End Sub

    Private Sub methodLoad_TyleCNTTNghiViec()
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(2)
        Me.b = New clsBBaoCaoTongHop
        Dim obj As New objBaoCaoTongHop
        listpar1.Clear()
        listpar1.Clear()
        listpar2.Clear()
        tblThongKeXuong.Clear()

        Me.tblThongKeXuong = New DataTable()
        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_D", listpar1)
        listpar1.Clear()
        ''============ 
        For i = 1 To 12
            listpar.Add(New SqlParameter("@THANG", i))
            listpar.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_I", listpar)
            listpar.Clear()
        Next

        ''===========
        For i = 1 To 12
            listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar1.Add(New SqlParameter("@THANG", i))
            Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_TCT_CNTT_THANG", listpar1)
            listpar1.Clear()
        Next

        obj.ThangMax = CInt(CDate(Me.dtpDenNgay.Value).Month.ToString)

        listpar1.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
        listpar1.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
        Me.b.GoiThuTuc("SP_BCTH_PHANTICHTYLENGHIVIEC_I_KHU_CNTT_TCT", listpar1)
        listpar1.Clear()



        ''============== LẶP TỪNG XƯỞNG ===============''
        If radTCT.Checked Then
            Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_S")

            If tblDMXuongKhuA.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If

            tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_S")
            If tblDMXuongKhuB.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If

            tblDMXuongKhoiVP = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHOIVP_S")
            If tblDMXuongKhoiVP.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhoiVP.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhoiVP.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
            listpar2.Clear()
            listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
            listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
            listpar2.Add(New SqlParameter("@XUONGTENHOA", "全廠合計 TC"))
            listpar2.Add(New SqlParameter("@KHU", "TC合計"))
            tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

            If tblTemp.Rows.Count > 0 Then
                tblThongKeXuong.Merge(tblTemp)
            End If
            listpar2.Clear()
            Me.dgrBC.DataSource = tblThongKeXuong
        End If
        '======================================================
        If radKhuA.Checked Then
            Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_S")

            If tblDMXuongKhuA.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuA.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() = "TONGKHUA" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuA.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuA.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next

            End If
            listpar2.Clear()
            listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
            listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
            listpar2.Add(New SqlParameter("@XUONGTENHOA", "全廠合計 TC"))
            listpar2.Add(New SqlParameter("@KHU", "TC合計"))
            tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

            If tblTemp.Rows.Count > 0 Then
                tblThongKeXuong.Merge(tblTemp)
            End If
            listpar2.Clear()
            Me.dgrBC.DataSource = tblThongKeXuong
        End If
        '===========================================
        If radKhuB.Checked Then
            Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_S")

          

            tblDMXuongKhuB = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUB_TINHCNM_S")
            If tblDMXuongKhuB.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhuB.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhuB.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhuB.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
            listpar2.Clear()
            listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
            listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
            listpar2.Add(New SqlParameter("@XUONGTENHOA", "全廠合計 TC"))
            listpar2.Add(New SqlParameter("@KHU", "TC合計"))
            tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

            If tblTemp.Rows.Count > 0 Then
                tblThongKeXuong.Merge(tblTemp)
            End If
            listpar2.Clear()
            Me.dgrBC.DataSource = tblThongKeXuong
        End If
        ' ==================================
        If radDVC.Checked Then
            Dim tblDMXuongKhuA, tblDMXuongKhuB, tblDMXuongKhoiVP, tblTemp, tblTemp1 As DataTable
            tblDMXuongKhuA = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHUA_S")
            tblDMXuongKhoiVP = Me.b.GoiThuTucThongke("SP_DANHMUCXUONG_KHOIVP_S")
            If tblDMXuongKhoiVP.Rows.Count > 0 Then
                For i As Integer = 0 To tblDMXuongKhoiVP.Rows.Count - 1
                    listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
                    listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
                    listpar2.Add(New SqlParameter("@X_MA_", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString()))
                    If tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() = "TONGKHUB" Then
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", "小計"))
                    Else
                        listpar2.Add(New SqlParameter("@XUONGTENHOA", tblDMXuongKhoiVP.Rows(i).Item("X_MA_").ToString() & " 廠"))
                    End If
                    listpar2.Add(New SqlParameter("@KHU", tblDMXuongKhoiVP.Rows(i).Item("KHU").ToString()))
                    tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)

                    If tblTemp.Rows.Count > 0 Then
                        tblThongKeXuong.Merge(tblTemp)
                    End If
                    listpar2.Clear()
                Next
            End If
            listpar2.Clear()
            listpar2.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year.ToString))
            listpar2.Add(New SqlParameter("@THANGMAX", obj.ThangMax))
            listpar2.Add(New SqlParameter("@X_MA_", "TCT"))
            listpar2.Add(New SqlParameter("@XUONGTENHOA", "全廠合計 TC"))
            listpar2.Add(New SqlParameter("@KHU", "TC合計"))
            tblTemp = Me.b.GoiThuTucThongke("SP_BCTH_PHANTICHTYLENGHIVIEC_CNTT_S", listpar2)
            MessageBox.Show(obj.ThangMax)
            If tblTemp.Rows.Count > 0 Then
                tblThongKeXuong.Merge(tblTemp)
            End If
            listpar2.Clear()
            Me.dgrBC.DataSource = tblThongKeXuong
        End If
    End Sub
    Private Sub UltraGridExcelExporter1_CellExported(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs) Handles UltraGridExcelExporter1.CellExported
        Dim cell As UltraGridCell = e.GridRow.Cells(e.GridColumn)
        Dim mergedCells() As UltraGridCell = cell.GetMergedCells()

        If Not mergedCells Is Nothing Then

            Dim isFirstCell As Boolean = True
            For Each mergedCell As UltraGridCell In mergedCells
                If cell.Row.Index > mergedCell.Row.Index Then
                    isFirstCell = False
                    Return
                End If
            Next

            If isFirstCell Then
                Dim rowIndex, colIndex As Integer

                rowIndex = e.CurrentRowIndex
                colIndex = e.CurrentColumnIndex
                e.CurrentWorksheet.MergedCellsRegions.Add(rowIndex, colIndex, rowIndex + (mergedCells.Length - 1), colIndex)
            End If
        End If
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        Dim thang, nam As String
        Dim soluongcot As Integer = Me.dgrBC.DisplayLayout.Bands(0).Columns.Count
        'Dim soocotan As Integer = dgrBC.DisplayLayout.Bands(0).Columns.Count

        thang = CDate(Me.dtpDenNgay.Value).Month.ToString()
        nam = CDate(Me.dtpDenNgay.Value).Year.ToString()

        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case cboLoaiBaocao.Value
                
                Case "TKNGHIVIEC_GCDHD"
                    XuatExcel_NghiViecCDHD_Sathai()
                Case "TKLDNGHIVIEC_N"
                    XuatExcel_DinhdangchungTieude("NGHIVIECNAM", "BẢNG PHÂN TÍCH NGUYÊN NHÂN NGHỈ ViỆC THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份各廠員工離職原因分析表 ", 1, 0, soluongcot - 1)

                Case "TKLDNGHIVIEC_T"
                    XuatExcel_DinhdangchungTieude("NGHIVIECTHANG", "BẢNG PHÂN TÍCH NGUYÊN NHÂN NGHỈ VIỆC THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份各廠員工離職原因分析表 ", 1, 0, soluongcot - 1)
                Case "TKTNTV_T"
                    XuatExcel_DinhdangchungTieude("THAMNIENTHANG", "BẢNG PHÂN TÍCH THÂM NIÊN NGHỈ VIỆC THEO THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份各廠員工(按年資)離職分析圖表 ", 1, 0, soluongcot - 1)
                    'Thong ke ty le nghi viec
                Case "TKTYLENGHIVIECNAM"
                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("TYLENGHIVEC", "BẢNG PHÂN TÍCH TỈ LỆ NGHỈ VIỆC NĂM " & nam, nam & "年各廠離職率分析表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("TYLENGHIVEC", "BẢNG PHÂN TÍCH TỈ LỆ NGHỈ ViỆC THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份各廠離職率分析表 ", 1, 0, soluongcot - 1)
                    End If

                    'thong le nghi khong phep
                Case "TKNGHIKHONGPHEP"
                    If chkchitiet.Checked Then
                        XuatExcel_DinhdangchungTieude("TKNGHIKHONGPHEP_CHITIET", "THỐNG KÊ NGHỈ KHÔNG PHÉP THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份曠工人數統計表", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("TKNGHIKHONGPHEP", "THỐNG KÊ NGHỈ KHÔNG PHÉP THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份曠工人數統計表", 1, 0, soluongcot - 1)
                    End If

                    ' ty le nghi viec cong nhan moi
                Case "TKTYLENGHIVIECCNM_THANG"
                    XuatExcel_DinhdangchungTieude("NGHIVIECCNM", "BẢNG PHÂN TÍCH TỶ LỆ NGHỈ VIỆC CỦA CÔNG NHÂN MỚI THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份全廠新工離職率之分析 ", 1, 0, soluongcot - 1)
                    ' thong ke nghi viec khong ly do 
                Case "TKNGHIVIECKHONGLYDO"
                    XuatExcel_DinhdangchungTieude("TKNGHIVIECKHIONGLYDO", "SỐ LAO ĐỘNG NGHỈ VIỆC KHÔNG LÝ DO THÁNG " & thang & " NĂM " & nam, nam & " 年 " & thang & "月份無故離職人數統計表", 1, 0, soluongcot - 1)
                    ' thong ke cong nhan truc tiep nghi viec
                Case "TKTYLENGHIVIECNAM_CNTT"
                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("NGHIVIECTRUCTIEP_CHITIET", "BẢNG PHÂN TÍCH TỈ LỆ NGHỈ VIỆC NĂM " & nam, nam & "年各廠離職率分析表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("NGHIVIECTRUCTIEP", "BẢNG PHÂN TÍCH TỈ LỆ NGHỈ VIỆC LAO ĐỘNG LÀM VIỆC TRỰC TIẾP NĂM " & thang & " NĂM " & nam, nam & "年" & thang & " 年份各廠離職 ", 1, 0, soluongcot - 1)
                    End If
                    ' thong ke tinh hinh phan bo cong nhan trong va ngoai tinh
                Case "TKTNGTINH"
                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("THCNTNT_CHITIET", "BẢNG PHÂN BỐ TÌNH HÌNH CÔNG NHÂN TỶ BÁCH TRONG NGOÀI TỈNH THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏員工地區來源分佈狀況 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("THCNTNT", "BẢNG PHÂN BỐ TÌNH HÌNH CÔNG NHÂN TỶ BÁCH TRONG NGOÀI TỈNH THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏員工地區來源分佈狀況 ", 1, 0, soluongcot - 1)
                    End If

                    'thong ke ton giao
                Case "TKTG"
                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("TKTG_CHITIET", "BẢNG PHÂN TÍCH TÔN GIÁO THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏員工信仰宗教類別分析圖表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("TKTG", "BẢNG PHÂN TÍCH TÔN GIÁO THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏員工信仰宗教類別分析圖表 ", 1, 0, soluongcot - 1)
                    End If

                    ' pha tich tuoi
                Case "TKTUOIGT"
                    If chkchitiet.Checked Then
                        XuatExcel_DinhdangchungTieude("PTTUOI_CHITIET", "BẢNG PHÂN TÍCH TUỔI GIỚI TÍNH THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份年齡及性別結構分析圖表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("PTTUOI", "BẢNG PHÂN TÍCH TUỔI GIỚI TÍNH THÁNG  " & thang & " NĂM " & nam, nam & "年" & thang & " 月份年齡及性別結構分析圖表 ", 1, 0, soluongcot - 1)
                    End If


                    ' thong ke hoc van
                Case "TKTD"
                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("TKHV_CHITIET", "BẢNG PHÂN TÍCH TRÌNH ĐỘ HỌC VẤN THÁNG   " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏各廠員工學歷結構分析表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("TKHV", "BẢNG PHÂN TÍCH TRÌNH ĐỘ HỌC VẤN THÁNG   " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏各廠員工學歷結構分析表 ", 1, 0, soluongcot - 1)
                    End If

                    ' thong ke tham nien
                Case "TKTN"

                    If chkchitiet.Checked = True Then
                        XuatExcel_DinhdangchungTieude("TKTN_CHITIET", "BẢNG PHÂN TÍCH THÂM NIÊN CÔNG NHÂN TỶ BÁCH THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 月份億柏員工年資分析表 ", 1, 0, soluongcot - 1)
                    Else
                        XuatExcel_DinhdangchungTieude("TKTN", "BẢNG PHÂN TÍCH THÂM NIÊN THÁNG   " & thang & " NĂM " & nam, nam & "年" & thang & " 月份員工年資分析表 ", 1, 0, soluongcot - 1)
                    End If


                Case "TKTNTV_N"
                    XuatExcel_DinhdangchungTieude("TKTHAMNIEN", "BẢNG PHÂN TÍCH THÂM NIÊN THÁNG " & thang & " NĂM " & nam, nam & "年" & thang & " 億柏員工信仰宗教類別分析圖表 ", 2, 1, soluongcot - 1)
                    'XuatExcel_Thamnienthoiviecnam()
                Case "TKDANHSACHMANGTHAI"
                    XuatExcel_DinhdangchungTieude("DANHSACHMANGTHAI", "DANH SÁCH CÔNG NHÂN VIÊN MANG THAI THÁNG " & thang & " NĂM " & nam, "", 1, 0, soluongcot - 1)
                Case "TKTROCAPNUOICONDUOI6T"
                    XuatExcel_DinhdangchungTieude("TROCAPNUOICONDUOI6T", "DANH SÁCH CÔNG NHÂN VIÊN TRỢ CẤP NUÔI CON DƯỚI 6 TUỔI THÁNG " & thang & " NĂM " & nam, "", 1, 0, soluongcot - 1)
                Case Else
                    Me.UltraGridExcelExporter1.Export(Me.dgrBC, SaveFileDialog1.FileName.ToString)
                    MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select
        End If
    End Sub

   
  
 

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As TD.SandBar.ToolBarItemEventArgs) Handles ToolBar1.ButtonClick

    End Sub
End Class