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
Imports TongHop.frmDBLuong
Public Class frmDBLPromaz
    Dim Tabletemp As DataTable
    Dim TableND As DataTable
    Dim Tabletemp1 As New DataTable
    Dim Tabletemp2 As New DataTable
    Dim Tabletemp3 As New DataTable
    Private Sub frmDBLPromaz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim obj As New objDBLPromaz
        Me.b = New clsBDBLPromaz
        Dim nguoidung As String = MAIN.userclient.ToLower()
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.NGUOIDUNG = nguoidung

        If nguoidung = "admin" Then
            Me.radToanCty.Checked = True
            obj.ChonBang = 1
            GoTo LAP
        End If
        obj.MA_DM = "1" + Me.Name
        obj.ChonBang = 13

        Me.TableND = Me.b.LoadDS(obj)
        Dim KHUA As Boolean
        Dim KHUB As Boolean
        KHUA = TableND.Rows(0).Item("KHUA").ToString
        KHUB = TableND.Rows(0).Item("KHUB").ToString
        If KHUA = True And KHUB = False Then
            Me.radA.Checked = True
            obj.ChonBang = 14
            GoTo LAP
        ElseIf KHUA = False And KHUB = True Then
            Me.radB.Checked = True
            obj.ChonBang = 15
            GoTo LAP
        ElseIf KHUA = True And KHUB = True Then
            Me.radToanCty.Checked = True
            obj.ChonBang = 1
            GoTo LAP
        Else
            obj.ChonBang = 1
            GoTo LAP
        End If
LAP:
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.Value = Me.Tabletemp.Rows(1).Item("DV_MA").ToString()
        Me.Tim()
    End Sub
    Friend WithEvents b As clsBDBLPromaz
    Friend WithEvents d As New clsDDBLPromaz
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim flag As Boolean
    Public Shared obj As New objDBLPromaz
    Public Shared DBL As Boolean = False
    Dim Table As String
    Dim Path As String
    Private Sub Tim()
        Dim obj As New objDBLPromaz
        Me.b = New clsBDBLPromaz
        Dim tblDVNghiviec As DataTable
        obj.ChonBang = 20
        tblDVNghiviec = Me.b.LoadDS(obj)

        If Me.cbDonvi.Value <> "" Then
            If Me.cbDonvi.Value = "TCT" Then
                Me.Tabletemp = Nothing

                obj.DONVI = Me.cbDonvi.Value
                obj.ChonBang = 44
                Dim ngay As Date = Me.dtpNgaybatdau.Value
                Dim ngay2 As String
                ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
                obj.NGAY = ngay2
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            Else
                If tblDVNghiviec Is Nothing Then
                ElseIf tblDVNghiviec.Rows.Count <= 0 Then
                Else
                    For i As Integer = 0 To tblDVNghiviec.Rows.Count - 1
                        If tblDVNghiviec.Rows(i).Item("DV_MA").ToString() = Me.cbDonvi.Value.ToString() Then
                            obj.CHONDONVINGHIVIEC = 1
                            Exit For
                        Else
                            obj.CHONDONVINGHIVIEC = 0
                        End If
                    Next
                End If

                Me.Tabletemp = Nothing
                obj.DONVI = Me.cbDonvi.Value
                obj.ChonBang = 4
                Dim ngay As Date = Me.dtpNgaybatdau.Value
                Dim ngay2 As String
                ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
                obj.NGAY = ngay2
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            End If
        End If
    End Sub
    Private Sub XuatDblThang() 'Andrew 

        Me.Tabletemp = Nothing
        If Me.radThang.Checked = True Then
            obj.ChonBang = 45
            Dim ngay As Date = Me.dtpNgaybatdau.Value
            Dim ngay2 As String
            ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            obj.NGAY = ngay2
            Me.Tabletemp = Me.b.LoadDS(obj)

        ElseIf Me.radNam.Checked = True Then
            obj.ChonBang = 46
            Dim ngay As Date = Me.dtpNgaybatdau.Value
            Dim ngay2 As String
            ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            obj.NGAY = ngay2
            Me.Tabletemp = Me.b.LoadDS(obj)
        End If
        Locdulieu(Me.Tabletemp)
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ITDIENBIENLUONG.xml"), typeControl.Grid, "coldgrfunction")
        If TableDS.Rows.Count > 0 Then
            If TableDS.Rows.Count < oldRow Then
                Exit Sub
            Else
                Me.dgrBC.Rows(oldRow).Activated = True
            End If
        End If
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 10
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
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
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub

    Dim oldRow As Integer = 0

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
    Public Sub HieuChinh()
        Dim frm As New frmNhapDBLuong
        obj.ChonBang = 3
        obj.MANV = frm.obj.MANV
        obj.NGAY = frm.obj.NGAY
        Dim Temp As New DataTable
        Me.b = New clsBDBLPromaz
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)

        Dim flag As Boolean
        flag = False

        If Temp.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = True Then
            frm.txtLuong.Text = Temp.Rows(0).Item("DBL_LUONGCB")
            frm.txtSoqd.Text = Temp.Rows(0).Item("DBL_SOQUYETDINH")
            frm.txtPhucap.Text = Temp.Rows(0).Item("DBL_PHUCAP")
            frm.txtPhuCapKhac.Text = Temp.Rows(0).Item("DBL_PhuCapKhac")
            frm.txtTroCapCV.Text = Temp.Rows(0).Item("DBL_TrocapCV")
            frm.txtTroCapUDMay.Text = Temp.Rows(0).Item("DBL_TrocapUDMAY")
            frm.txtTroCapCMNV.Text = Temp.Rows(0).Item("DBL_TrocapCMNV")
            frm.txtTroCapNN.Text = Temp.Rows(0).Item("DBL_TrocapNN")
            frm.txtTrocapHMPT.Text = Temp.Rows(0).Item("DBL_TrocapHMPT")
            frm.txtTCMT.Text = Temp.Rows(0).Item("TCMT")
            frm.txtTroCapQLSX.Text = Temp.Rows(0).Item("DBL_TroCapQLSX")
            frm.txtTroCapCBVP.Text = Temp.Rows(0).Item("DBL_TroCapCBVP")
            frm.txtTroCapBBNT.Text = Temp.Rows(0).Item("DBL_TroCapBBNT")
            frm.txtTroCapBBHT.Text = Temp.Rows(0).Item("DBL_TroCapBBHT")
            frm.txtTroCapBBTHANG.Text = Temp.Rows(0).Item("DBL_TroCapBBTHANG")
            frm.txtTroCapCLGD.Text = Temp.Rows(0).Item("DBL_TroCapCLGD")
            frm.txtTroCapHTDP.Text = Temp.Rows(0).Item("DBL_TroCapHTDP")
            frm.txtTroCapQAQIP.Text = Temp.Rows(0).Item("DBL_TroCapQAQIP")
            frm.txtTrocapThoRap.Text = Temp.Rows(0).Item("DBL_TrocapThoRap")
            frm.txtTrocapHSE.Text = Temp.Rows(0).Item("DBL_TrocapHSE")
            frm.txtHeso.Text = Temp.Rows(0).Item("DBL_HESO")
            frm.cbCongViec.Text = Temp.Rows(0).Item("CV_MA")
            frm.cbChucVu.Text = Temp.Rows(0).Item("CVU_MA")
            If Temp.Rows(0).Item("DHNN") = 1 Then
                frm.chkDHNN.Checked = True
            Else
                frm.chkDHNN.Checked = False
            End If
            If Temp.Rows(0).Item("DBL_KHONGHUONGCHUYENCAN") = 1 Then
                frm.chkKhongCC.Checked = True
            Else
                frm.chkKhongCC.Checked = False
            End If
        End If
    End Sub
    Public frm1 As New frmNhapDBLuong
    Public NgayHienTai As String = ""
    Public state As Integer
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        onerowonclick = True
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As Integer = (activeCell.Column.Index)
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim temp As DataTable
            Select Case ColA
                Case 0
                    DBL = True
                    frm1.MA = activeCell.Row.Cells.Item("MA").Text
                    frm1.NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()
                    frm1.txtLuong.Text = activeCell.Row.Cells.Item("LUONG").Text
                    frm1.txtSoqd.Text = activeCell.Row.Cells.Item("SOQD").Text
                    frm1.txtPhucap.Text = activeCell.Row.Cells.Item("PHUCAP").Text
                    frm1.txtPhuCapKhac.Text = activeCell.Row.Cells.Item("PhuCapKhac").Text
                    frm1.txtTroCapCV.Text = activeCell.Row.Cells.Item("TroCapCV").Text
                    frm1.txtTroCapUDMay.Text = activeCell.Row.Cells.Item("TroCapUDMay").Text
                    frm1.txtTroCapCMNV.Text = activeCell.Row.Cells.Item("TroCapCMNV").Text
                    frm1.txtTroCapNN.Text = activeCell.Row.Cells.Item("TroCapNN").Text
                    frm1.txtTrocapHMPT.Text = activeCell.Row.Cells.Item("TrocapHMPT").Text
                    frm1.txtTCMT.Text = activeCell.Row.Cells.Item("TCMT").Text
                    frm1.txtTroCapQLSX.Text = activeCell.Row.Cells.Item("TroCapQLSX").Text
                    frm1.txtTroCapCBVP.Text = activeCell.Row.Cells.Item("TroCapCBVP").Text
                    frm1.txtTroCapBBNT.Text = activeCell.Row.Cells.Item("TroCapBBNT").Text
                    frm1.txtTroCapBBHT.Text = activeCell.Row.Cells.Item("TroCapBBHT").Text
                    frm1.txtTroCapBBTHANG.Text = activeCell.Row.Cells.Item("TroCapBBTHANG").Text
                    frm1.txtTroCapCLGD.Text = activeCell.Row.Cells.Item("TroCapCLGD").Text
                    frm1.txtTroCapHTDP.Text = activeCell.Row.Cells.Item("TroCapHTDP").Text
                    frm1.txtTroCapQAQIP.Text = activeCell.Row.Cells.Item("TroCapQAQIP").Text
                    frm1.txtTrocapThoRap.Text = activeCell.Row.Cells.Item("TrocapThoRap").Text
                    frm1.txtTrocapHSE.Text = activeCell.Row.Cells.Item("TrocapHSE").Text

                    If IsDBNull(activeCell.Row.Cells.Item("PHUCLOI").Text) Or activeCell.Row.Cells.Item("PHUCLOI").Text = "" Then
                        frm1.txtPhucloi.Text = ""
                    Else
                        frm1.txtPhucloi.Text = activeCell.Row.Cells.Item("PHUCLOI").Text
                    End If

                    If IsDBNull(activeCell.Row.Cells.Item("Hotrongoaigio").Text) Or activeCell.Row.Cells.Item("Hotrongoaigio").Text = "" Then
                        frm1.txtHotrongoaigio.Text = ""
                    Else
                        frm1.txtHotrongoaigio.Text = activeCell.Row.Cells.Item("Hotrongoaigio").Text
                    End If

                    If IsDBNull(activeCell.Row.Cells.Item("DQTV").Text) Or activeCell.Row.Cells.Item("DQTV").Text = "" Then
                        frm1.txtDQTV.Text = ""
                    Else
                        frm1.txtDQTV.Text = activeCell.Row.Cells.Item("DQTV").Text
                    End If

                    If IsDBNull(activeCell.Row.Cells.Item("PCCC").Text) Or activeCell.Row.Cells.Item("PCCC").Text = "" Then
                        frm1.txtPCCC.Text = ""
                    Else
                        frm1.txtPCCC.Text = activeCell.Row.Cells.Item("PCCC").Text
                    End If

                    frm1.txtHeso.Text = activeCell.Row.Cells.Item("HESO").Text
                    If Microsoft.VisualBasic.IsDBNull(activeCell.Row.Cells.Item("DHNN").Value) Then
                    Else
                        If activeCell.Row.Cells.Item("DHNN").Value = 0 Then
                            frm1.chkDHNN.Checked = False
                        Else
                            frm1.chkDHNN.Checked = True
                        End If
                    End If
                    If Microsoft.VisualBasic.IsDBNull(activeCell.Row.Cells.Item("LDCM").Value) Then
                    Else

                        If activeCell.Row.Cells.Item("LDCM").Value = 0 Then
                            frm1.chkLaoDongCM.Checked = False
                        Else
                            frm1.chkLaoDongCM.Checked = True
                        End If
                    End If

                    If Microsoft.VisualBasic.IsDBNull(activeCell.Row.Cells.Item("DBL_KHONGHUONGCHUYENCAN").Value) Then
                    Else

                        If activeCell.Row.Cells.Item("DBL_KHONGHUONGCHUYENCAN").Value = 0 Then
                            frm1.chkKhongCC.Checked = False
                        Else
                            frm1.chkKhongCC.Checked = True
                        End If
                    End If
                    obj.ChonBang = 10
                    obj.MANV = activeCell.Row.Cells.Item("MA").Text
                    Me.b = New clsBDBLPromaz
                    temp = Nothing
                    temp = Me.b.LoadDS(obj)

                    Dim flag As Boolean
                    flag = False

                    If temp.Rows.Count > 0 Then
                        flag = True
                    Else
                        flag = False
                    End If
                    If flag = True Then
                        frm1.cbCongViec.Text = temp.Rows(0).Item("CV_MA")
                        frm1.cbChucVu.Text = temp.Rows(0).Item("CVU_MA")
                        If temp.Rows(0).Item("DHNN") = 0 Then
                            frm1.chkDHNN.Checked = False
                        Else
                            frm1.chkDHNN.Checked = True
                        End If
                        frm1.ShowDialog()
                        If frm1.obj.FlagChamCong = True Then
                            frm1.MA = activeCell.Row.Cells.Item("MA").Text
                            XetTangLuong()
                        End If
                        Me.Tim()
                        Me.ChonDongCu()
                    Else
                        frm1.cbCongViec.Text = ""
                        frm1.ShowDialog()
                        If frm1.obj.FlagChamCong = True Then
                            XetTangLuong()
                        End If
                        Me.Tim()
                        Me.ChonDongCu()
                    End If

                Case 2
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        Dim obj As New objDBLPromaz
                        obj.Setnull()
                        obj.MANV = activeCell.Row.Cells.Item("MA").Text
                        obj.NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()

                        obj.ChonBang = 1
                        Me.b = New clsBDBLPromaz
                        Me.b.DeleteInfo(obj)
                        SetValDel()
                        Me.Tim()
                        Me.ChonDongCu()
                    End If

                Case 9, 10

            End Select
        End If
    End Sub
    Public Sub NgayHT()
        Me.b = New clsBDBLPromaz
        Dim tableNgay As DataTable
        Dim ngayt As Date
        Dim ngay As Date
        obj.ChonBang = 18
        tableNgay = Me.b.LoadDS(obj)
        If tableNgay.Rows.Count > 0 Then
            NgayHienTai = tableNgay.Rows(0).Item("NGAY").ToString()
            obj.Thoigian = tableNgay.Rows(0).Item("NGAY").ToString()
        Else
            Me.NgayHienTai = Now().ToString("dd-MM-yyyy")
            obj.Thoigian = Now().ToString("dd-MM-yyyy")
        End If
    End Sub
    Public Sub BackupThaoTac(ByVal nhom As Boolean, ByVal state As Integer, ByVal obj_moi As objDBLPromaz, ByVal manhanvien As String, ByVal ngay As String, ByVal hs As String, ByVal l As String, ByVal pc As String, ByVal cv As String, ByVal cvu As String, ByVal pDHNN As Integer, ByVal pLDCM As Integer, ByVal m_PhuCapKhac As String, ByVal m_TrocapCV As String, ByVal m_TrocapUDMAY As String, ByVal m_TrocapCMNV As String, ByVal m_TrocapNN As String, ByVal m_TrocapHMPT As String, ByVal m_TrocapMT As String, ByVal m_TroCapQLSX As String, ByVal m_TroCapCBVP As String, ByVal m_TroCapBBNT As String, ByVal m_TroCapBBHT As String, ByVal m_TroCapBBTHANG As String, ByVal m_TroCapCLGD As String, ByVal m_TroCapHTDP As String, ByVal m_TroCapQAQIP As String, ByVal m_TrocapThoRap As String, ByVal m_TrocapHSE As String, ByVal pKHONGCC As Integer, ByVal m_Phucloi As String, ByVal m_Hotrobenngoai As String, ByVal m_DQTV As String, ByVal m_PCCC As String)
        Try
            Dim listpar As New ArrayList(1)
            Dim b As New clsBDBLPromaz

            Dim tamNC12 As DataTable
            Dim dulieucu As String = "NV_MA = " & manhanvien & ",NGAY=" & ngay & " ,HESO=" & hs & " ,LUONG=" & l & " ,PHUCAP=" & pc & " ,CVIEC=" & cv & " ,CVU=" & cvu & ", DHNN=" & pDHNN & ",LDCM=" & pLDCM & " ,PCKHAC=" & m_PhuCapKhac & " ,TCCVIEC=" & m_TrocapCV & " ,UDMAY=" & m_TrocapUDMAY & " ,CMNV=" & m_TrocapCMNV & " ,NN=" & m_TrocapNN & ",HMPT=" & m_TrocapHMPT & " ,MTr=" & m_TrocapMT & " ,QLSX=" & m_TroCapQLSX & " ,CBVP=" & m_TroCapCBVP & " ,BBNT=" & m_TroCapBBNT & ",BBHT=" & m_TroCapBBHT & " ,BBTHANG=" & m_TroCapBBTHANG & " ,CLGD=" & m_TroCapCLGD & " ,HTDP=" & m_TroCapHTDP & ", QAQIP=" & m_TroCapQAQIP & ",THORAP=" & m_TrocapThoRap & " ,HSE=" & m_TrocapHSE & " ,KHONGHUONGCC=" & pKHONGCC & " ,PHUCLOI=" & m_Phucloi & " ,HTNG=" & m_Hotrobenngoai & " ,DQTV=" & m_DQTV & " ,PCCC=" & m_PCCC
            Dim dulieumoi As String = "NV_MA = " & manhanvien & ",NGAY=" & obj_moi.NGAY & " ,HESO=" & obj_moi.HESO & " ,LUONG=" & obj_moi.LUONG & " ,PHUCAP=" & obj_moi.PhuCap & " ,CVIEC=" & obj_moi.CongViec & " ,CVU=" & obj_moi.ChucVu & ", DHNN=" & obj_moi.DHNN & ",LDCM=" & obj_moi.LDCM & " ,PCKHAC=" & obj_moi.PhuCapKhac & " ,TCCVIEC=" & obj_moi.TrocapCV & " ,UDMAY=" & obj_moi.TrocapUDMAY & " ,CMNV=" & obj_moi.TrocapCMNV & " ,NN=" & obj_moi.TrocapNN & ",HMPT=" & obj_moi.TrocapHMPT & " ,MTr=" & obj_moi.TrocapMT & " ,QLSX=" & obj_moi.TroCapQLSX & " ,CBVP=" & obj_moi.TroCapCBVP & " ,BBNT=" & obj_moi.TroCapBBNT & ",BBHT=" & obj_moi.TroCapBBHT & " ,BBTHANG=" & obj_moi.TroCapBBTHANG & " ,CLGD=" & obj_moi.TroCapCLGD & " ,HTDP=" & obj_moi.TroCapHTDP & ", QAQIP=" & obj_moi.TroCapQAQIP & ",THORAP=" & obj_moi.TrocapThoRap & " ,HSE=" & obj_moi.TrocapHSE & " ,KHONGHUONGCC=" & obj_moi.KHONGCC & " ,PHUCLOI=" & obj_moi.PHUCLOI & " ,HTNG=" & obj_moi.HOTRONGOAIGIO & " ,DQTV=" & m_DQTV & " ,PCCC=" & m_PCCC
            Dim chuoithaotac As String = ""
            Me.NgayHT()
            ''============= thao tac tren don vi/cong ty ==============
            listpar.Add(New SqlParameter("@ThoiDiem", obj.Thoigian))

            If nhom Then
                If state = 0 Then
                    chuoithaotac = "thao tác nhóm: " & dulieumoi
                End If
            Else
                ''============= trang thai them moi ==============
                dulieumoi = "ST_DIENBIENLUONG:" & dulieumoi
                If state = 0 Then
                    chuoithaotac = dulieumoi
                End If
                If state = 1 Then
                    chuoithaotac = dulieumoi & " ;du lieu cu: " & dulieucu
                End If
                If state = 2 Then
                    chuoithaotac = dulieucu
                End If
            End If
            'MessageBox.Show("Gia tri:" & state.ToString() & "Ten dang nhap: " & d.obj_D.TenDangNhap.ToString())
            listpar.Add(New SqlParameter("@HanhDong", chuoithaotac))
            listpar.Add(New SqlParameter("@GiaTri", state.ToString()))
            listpar.Add(New SqlParameter("@Ten_DangNhap", d.obj_D.TenDangNhap.ToString()))
            Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
            listpar.Clear()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        onerowonclick = False
        Me.dgrBC.UpdateData()
        obj.Setnull()

        Dim frm As New frmNhapDBLuong
        frm.ShowDialog()
        If frm.obj.FlagChamCong = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    frm.obj.MANV = Me.dgrBC.Rows(i).Cells("MA").Text
                    frm.obj.NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()

                    Dim MA As String
                    Dim LUONG As String
                    Dim SOQD As String
                    Dim PC As String
                    Dim HS As String
                    Dim NGAY As Date
                    Dim congviec As String
                    Dim chucvu As String
                    Dim dh As Integer
                    Dim CM As Integer
                    Dim khonghcc As Integer
                    Dim PhuCapKhac As String
                    Dim TrocapCV As String
                    Dim TrocapUDMAY As String
                    Dim TrocapCMNV As String
                    Dim TrocapNN As String
                    Dim TrocapHMPT As String
                    Dim TrocapMT As String
                    Dim TroCapQLSX As String
                    Dim TroCapCBVP As String
                    Dim TroCapBBNT As String
                    Dim TroCapBBHT As String
                    Dim TroCapBBTHANG As String
                    Dim TroCapCLGD As String
                    Dim TroCapHTDP As String
                    Dim TroCapQAQIP As String
                    Dim TrocapThoRap As String
                    Dim TrocapHSE As String
                    Dim Phucloi As String
                    Dim Hotrongoaigio As String
                    Dim DQTV As String
                    Dim PCCC As String


                    MA = frm.obj.MANV
                    obj.NGAY = frm.obj.NGAY
                    LUONG = obj.LUONG
                    SOQD = obj.SoQD
                    PC = obj.PhuCap
                    HS = obj.HESO

                    PhuCapKhac = obj.PhuCapKhac
                    TrocapCV = obj.TrocapCV
                    TrocapUDMAY = obj.TrocapUDMAY
                    TrocapCMNV = obj.TrocapCMNV
                    TrocapNN = obj.TrocapNN
                    TrocapHMPT = obj.TrocapHMPT
                    TrocapMT = obj.TrocapMT
                    TroCapQLSX = obj.TroCapQLSX
                    TroCapCBVP = obj.TroCapCBVP
                    TroCapBBNT = obj.TroCapBBNT
                    TroCapBBHT = obj.TroCapBBHT
                    TroCapBBTHANG = obj.TroCapBBTHANG
                    TroCapCLGD = obj.TroCapCLGD
                    TroCapHTDP = obj.TroCapHTDP
                    TroCapQAQIP = obj.TroCapQAQIP
                    TrocapThoRap = obj.TrocapThoRap
                    TrocapHSE = obj.TrocapHSE
                    Phucloi = obj.PHUCLOI
                    Hotrongoaigio = obj.HOTRONGOAIGIO
                    DQTV = obj.DQTV
                    PCCC = obj.PCCC

                    If frm.cbCongViec.Text = "" Then
                        MessageBox.Show("Bạn phải cập nhật công việc bên hồ sơ nhân sự", "Thông báo", MessageBoxButtons.OK)
                        Exit Sub
                    Else
                        congviec = frm.cbCongViec.SelectedValue
                    End If
                    chucvu = frm.cbChucVu.SelectedValue
                    dh = frm.DHNN
                    obj.DHNN = dh
                    CM = frm.LDCM
                    obj.LDCM = CM
                    khonghcc = frm.khongcc
                    obj.KHONGCC = khonghcc
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


                    obj.Setnull()
                    obj.setvalue(MA, obj.NGAY, SOQD, HS, LUONG, PC, congviec, chucvu, dh, CM, 0, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)

                    obj.ChonBang = 1
                    obj.NGUOITAO = nguoitao
                    obj.NGAYTAO = ngaytao
                    Me.b = New clsBDBLPromaz
                    Me.b.InsertInfo(obj)
                    BackupThaoTac(True, 0, obj, MA, obj.NGAY, HS, LUONG, PC, congviec, chucvu, dh, CM, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
                End If
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub
    Private Sub XetTangLuong()
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        Dim MA As String
        Dim LUONG As String
        Dim SOQD As String
        Dim PC As String
        Dim HS As String
        Dim NGAY As String
        Dim congviec As String
        Dim chucvu As String
        Dim dh As Integer
        Dim CM As Integer
        Dim khonghcc As Integer
        Dim PhuCapKhac As String
        Dim TrocapCV As String
        Dim TrocapUDMAY As String
        Dim TrocapCMNV As String
        Dim TrocapNN As String
        Dim TrocapHMPT As String
        Dim TrocapMT As String
        Dim TroCapQLSX As String
        Dim TroCapCBVP As String
        Dim TroCapBBNT As String
        Dim TroCapBBHT As String
        Dim TroCapBBTHANG As String
        Dim TroCapCLGD As String
        Dim TroCapHTDP As String
        Dim TroCapQAQIP As String
        Dim TrocapThoRap As String
        Dim TrocapHSE As String
        Dim Phucloi As String
        Dim Hotrongoaigio As String
        Dim DQTV As String
        Dim PCCC As String

        MA = frm1.MA
        NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()
        LUONG = obj.LUONG
        SOQD = obj.SoQD
        PC = obj.PhuCap
        HS = obj.HESO

        PhuCapKhac = obj.PhuCapKhac
        TrocapCV = obj.TrocapCV
        TrocapUDMAY = obj.TrocapUDMAY
        TrocapCMNV = obj.TrocapCMNV
        TrocapNN = obj.TrocapNN
        TrocapHMPT = obj.TrocapHMPT
        TrocapMT = obj.TrocapMT
        TroCapQLSX = obj.TroCapQLSX
        TroCapCBVP = obj.TroCapCBVP
        TroCapBBNT = obj.TroCapBBNT
        TroCapBBHT = obj.TroCapBBHT
        TroCapBBTHANG = obj.TroCapBBTHANG
        TroCapCLGD = obj.TroCapCLGD
        TroCapHTDP = obj.TroCapHTDP
        TroCapQAQIP = obj.TroCapQAQIP
        TrocapThoRap = obj.TrocapThoRap
        TrocapHSE = obj.TrocapHSE
        Phucloi = obj.PHUCLOI
        Hotrongoaigio = obj.HOTRONGOAIGIO
        DQTV = obj.DQTV
        PCCC = obj.PCCC

        If obj.CongViec = "" Then
            MessageBox.Show("Bạn phải cập nhật công việc bên hồ sơ nhân sự", "Thông báo", MessageBoxButtons.OK)
            Exit Sub
        Else
            congviec = obj.CongViec
        End If

        chucvu = obj.ChucVu
        dh = frm1.DHNN
        obj.DHNN = dh
        CM = frm1.LDCM
        obj.LDCM = CM
        khonghcc = frm1.khongcc
        obj.KHONGCC = khonghcc

        obj.ChonBang = 3
        obj.NGAY = NGAY
        obj.MANV = MA
        Dim Temp As New DataTable
        Me.b = New clsBDBLPromaz
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)

        Dim flag As Boolean
        flag = False

        If Temp.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString

        If flag = True Then

            If (MessageBox.Show(("Nhân viên này đã có, Bạn có muốn cập nhật lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                'Me.HieuChinh()
                obj.Setnull()
                obj.setvalue(MA, obj.NGAY, SOQD, HS, LUONG, PC, congviec, chucvu, dh, CM, 0, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)

                obj.ChonBang = 1
                obj.NGUOICN = nguoicn
                obj.NGAYCN = ngaycn
                Me.b = New clsBDBLPromaz
                Me.b.UpdateInfo(obj)
                BackupThaoTac(False, 1, obj, MA, obj.NGAY, HS, LUONG, PC, congviec, chucvu, dh, CM, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
                MessageBox.Show("Cập nhật thành công")
            Else
                Exit Sub
            End If
        Else

            If (MessageBox.Show(("Nhân viên này chưa có, Bạn có muốn thêm không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.Setnull()
                obj.setvalue(MA, obj.NGAY, SOQD, HS, LUONG, PC, congviec, chucvu, dh, CM, 0, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
                obj.ChonBang = 1
                obj.NGUOITAO = nguoitao
                obj.NGAYTAO = ngaytao
                Me.b = New clsBDBLPromaz
                Me.b.InsertInfo(obj)
                BackupThaoTac(False, 0, obj, MA, obj.NGAY, HS, LUONG, PC, congviec, chucvu, dh, CM, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
                MessageBox.Show("Thêm thành công")
            Else
                Exit Sub
            End If

        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub
    Private Sub SetValDel()
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        Dim MA As String
        Dim LUONG As String
        Dim SOQD As String
        Dim PC As String
        Dim HS As String
        Dim NGAY As String
        Dim congviec As String
        Dim chucvu As String
        Dim dh As Integer
        Dim CM As Integer
        Dim khonghcc As Integer
        Dim PhuCapKhac As String
        Dim TrocapCV As String
        Dim TrocapUDMAY As String
        Dim TrocapCMNV As String
        Dim TrocapNN As String
        Dim TrocapHMPT As String
        Dim TrocapMT As String
        Dim TroCapQLSX As String
        Dim TroCapCBVP As String
        Dim TroCapBBNT As String
        Dim TroCapBBHT As String
        Dim TroCapBBTHANG As String
        Dim TroCapCLGD As String
        Dim TroCapHTDP As String
        Dim TroCapQAQIP As String
        Dim TrocapThoRap As String
        Dim TrocapHSE As String
        Dim Phucloi As String
        Dim Hotrongoaigio As String
        Dim DQTV As String
        Dim PCCC As String

        MA = frm1.MA
        NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()
        LUONG = obj.LUONG
        SOQD = obj.SoQD
        PC = obj.PhuCap
        HS = obj.HESO

        PhuCapKhac = obj.PhuCapKhac
        TrocapCV = obj.TrocapCV
        TrocapUDMAY = obj.TrocapUDMAY
        TrocapCMNV = obj.TrocapCMNV
        TrocapNN = obj.TrocapNN
        TrocapHMPT = obj.TrocapHMPT
        TrocapMT = obj.TrocapMT
        TroCapQLSX = obj.TroCapQLSX
        TroCapCBVP = obj.TroCapCBVP
        TroCapBBNT = obj.TroCapBBNT
        TroCapBBHT = obj.TroCapBBHT
        TroCapBBTHANG = obj.TroCapBBTHANG
        TroCapCLGD = obj.TroCapCLGD
        TroCapHTDP = obj.TroCapHTDP
        TroCapQAQIP = obj.TroCapQAQIP
        TrocapThoRap = obj.TrocapThoRap
        TrocapHSE = obj.TrocapHSE
        Phucloi = obj.PHUCLOI
        Hotrongoaigio = obj.HOTRONGOAIGIO
        DQTV = obj.DQTV
        PCCC = obj.PCCC
        congviec = obj.CongViec
        chucvu = obj.ChucVu
        dh = frm1.DHNN
        obj.DHNN = dh
        CM = frm1.LDCM
        obj.LDCM = CM
        khonghcc = frm1.khongcc
        obj.KHONGCC = khonghcc
        obj.NGAY = NGAY
        obj.MANV = MA
        obj.setvalue(MA, obj.NGAY, SOQD, HS, LUONG, PC, congviec, chucvu, dh, CM, 0, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
        BackupThaoTac(False, 2, obj, MA, obj.NGAY, HS, LUONG, PC, congviec, chucvu, dh, CM, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
    End Sub
    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        onerowonclick = False
        Me.dgrBC.UpdateData()
        obj.Setnull()

        Dim frm As New frmNhapDBLuong
        frm.ShowDialog()
        If frm.obj.FlagChamCong = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1

                frm.obj.MANV = Me.dgrBC.Rows(i).Cells("MA").Text
                frm.obj.NGAY = Me.dtpNgaybatdau.Value.Year.ToString() + "/" + Me.dtpNgaybatdau.Value.Month.ToString() + "/" + Me.dtpNgaybatdau.Value.Day.ToString()
                'Goi ham cham cong (SP_CHAMCONGN)

                Dim MA As String
                Dim LUONG As String
                Dim SOQD As String
                Dim PC As String
                Dim HS As String
                Dim NGAY As Date
                Dim congviec As String
                Dim chucvu As String
                Dim dh As Integer
                Dim CM As Integer
                Dim khonghcc As Integer
                Dim PhuCapKhac As String
                Dim TrocapCV As String
                Dim TrocapUDMAY As String
                Dim TrocapCMNV As String
                Dim TrocapNN As String
                Dim TrocapHMPT As String
                Dim TrocapMT As String
                Dim TroCapQLSX As String
                Dim TroCapCBVP As String
                Dim TroCapBBNT As String
                Dim TroCapBBHT As String
                Dim TroCapBBTHANG As String
                Dim TroCapCLGD As String
                Dim TroCapHTDP As String
                Dim TroCapQAQIP As String
                Dim TrocapThoRap As String
                Dim TrocapHSE As String
                Dim Phucloi As String
                Dim Hotrongoaigio As String
                Dim DQTV As String
                Dim PCCC As String

                MA = frm.MA
                obj.NGAY = frm.NGAY
                LUONG = obj.LUONG
                SOQD = obj.SoQD
                PC = obj.PhuCap
                HS = obj.HESO

                PhuCapKhac = obj.PhuCapKhac
                TrocapCV = obj.TrocapCV
                TrocapUDMAY = obj.TrocapUDMAY
                TrocapCMNV = obj.TrocapCMNV
                TrocapNN = obj.TrocapNN
                TrocapHMPT = obj.TrocapHMPT
                TrocapMT = obj.TrocapMT
                TroCapQLSX = obj.TroCapQLSX
                TroCapCBVP = obj.TroCapCBVP
                TroCapBBNT = obj.TroCapBBNT
                TroCapBBHT = obj.TroCapBBHT
                TroCapBBTHANG = obj.TroCapBBTHANG
                TroCapCLGD = obj.TroCapCLGD
                TroCapHTDP = obj.TroCapHTDP
                TroCapQAQIP = obj.TroCapQAQIP
                TrocapThoRap = obj.TrocapThoRap
                TrocapHSE = obj.TrocapHSE
                Phucloi = obj.PHUCLOI
                Hotrongoaigio = obj.Hotrongoaigio
                DQTV = obj.DQTV
                PCCC = obj.PCCC

                If frm.cbCongViec.Text = "" Then
                    MessageBox.Show("Bạn phải cập nhật công việc bên hồ sơ nhân sự", "Thông báo", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    congviec = frm.cbCongViec.SelectedValue
                End If
                chucvu = frm.cbChucVu.SelectedValue
                dh = frm.DHNN
                obj.DHNN = dh
                CM = frm.LDCM
                obj.LDCM = CM
                khonghcc = frm.khongcc
                obj.KHONGCC = khonghcc
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

                obj.Setnull()
                obj.setvalue(MA, obj.NGAY, SOQD, HS, LUONG, PC, congviec, chucvu, dh, CM, 0, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)

                obj.ChonBang = 1
                obj.NGUOITAO = nguoitao
                obj.NGAYTAO = ngaytao
                Me.b = New clsBDBLPromaz
                Me.b.InsertInfo(obj)
                BackupThaoTac(True, 0, obj, MA, obj.NGAY, HS, LUONG, PC, congviec, chucvu, dh, CM, PhuCapKhac, TrocapCV, TrocapUDMAY, TrocapCMNV, TrocapNN, TrocapHMPT, TrocapMT, TroCapQLSX, TroCapCBVP, TroCapBBNT, TroCapBBHT, TroCapBBTHANG, TroCapCLGD, TroCapHTDP, TroCapQAQIP, TrocapThoRap, TrocapHSE, khonghcc, Phucloi, Hotrongoaigio, DQTV, PCCC)
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub dtpNgaybatdau_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgaybatdau.ValueChanged
        Me.Tim()
    End Sub

    Private Sub radA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radA.CheckedChanged
        Dim obj As New objDBLPromaz
        Me.b = New clsBDBLPromaz
        oldRow = 0
        If Me.radA.Checked = True Then
            obj.ChonBang = 14
            Me.Tabletemp1 = Me.b.LoadDS(obj)
            Me.cbDonvi.DataSource = Me.Tabletemp1
            Me.cbDonvi.SelectedIndex = 1
            Me.cbDonvi.Value = Me.Tabletemp1.Rows(1).Item("DV_MA").ToString()
            Me.Tim()
        Else
            Me.cbDonvi.DataSource = Nothing
        End If
    End Sub

    Private Sub radB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radB.CheckedChanged
        Dim obj As New objDBLPromaz
        Me.b = New clsBDBLPromaz
        oldRow = 0
        If Me.radB.Checked = True Then
            obj.ChonBang = 15
            Me.Tabletemp2 = Me.b.LoadDS(obj)
            Me.cbDonvi.DataSource = Me.Tabletemp2
            Me.cbDonvi.SelectedIndex = 1
            Me.cbDonvi.Value = Me.Tabletemp2.Rows(1).Item("DV_MA").ToString()
            Me.Tim()
        Else
            Me.cbDonvi.DataSource = Nothing
        End If
    End Sub

    Private Sub radToanCty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radToanCty.CheckedChanged
        Dim obj As New objDBLPromaz
        Me.b = New clsBDBLPromaz
        oldRow = 0
        If Me.radToanCty.Checked = True Then
            obj.ChonBang = 1
            Me.Tabletemp3 = Me.b.LoadDS(obj)
            Me.cbDonvi.DataSource = Me.Tabletemp3
            Me.cbDonvi.SelectedIndex = 1
            Me.cbDonvi.Value = Me.Tabletemp3.Rows(1).Item("DV_MA").ToString()
            Me.Tim()
        Else
            Me.cbDonvi.DataSource = Nothing
        End If
    End Sub

    Private Sub lbDblCty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDblCty.Click
        XuatDblThang()
    End Sub

    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter.Export(Me.dgrBC, Me.SaveFileDialog.FileName)
            Process.Start(Me.SaveFileDialog.FileName)
        End If
    End Sub
End Class