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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPhepNam
    Dim ReportID As String
    Public issysReport As Boolean
    Public para As Object()

    Public sortAtt As String()
    Public strFileName As String
    Private Sub Load_Combo()
        TrangThaiCheckKhu()
        Me.b = New clsBPhepNam
        obj.ChonBang = 1
        Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        Me.cboXuong.SelectedIndex = 0
        Me.cboXuong.ValueMember() = "X_MA_"
        Me.cboXuong.DisplayMember() = "X_TEN"
        Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 2
        Me.cboDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cboDonvi.SelectedIndex = 0
        Me.cboDonvi.ValueMember() = "DV_MA"
        Me.cboDonvi.DisplayMember() = "DV_MA"
        Me.cboDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Dim i As Integer = 2000
        For i = 2000 To 2030
            Me.cboNam.Items.Add(i)
        Next
        cboNam.Value = Now.Year.ToString()
    End Sub
    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất file excel xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Function GoiThuTuc(ByVal nam As String, ByVal khu As String) As DataTable
        Dim dtTable As DataTable
        If Me.chkTongQuat.Checked Then
            'dtTable = Me.d.ThuTucTongQuat("GETALL_PHEPNAMBANGTONG", nam)
            dtTable = Me.d.ThuTucTongQuat("[GETALL_PHEPNAMBANGTONG_2018]", nam, khu)
        Else
            dtTable = Me.d.ThuTucThongKe("SP_THONGKEPHEPNAMDV_TAM2018", nam, khu)

        End If
        Return dtTable
    End Function
    Public Shared obj As New objPhepNam
    Dim Path As String
    Public d As New clsDPhepNam    ' Nested Types
    Friend WithEvents b As clsBPhepNam
    Public DonVi As String = ""
    Public ChonBang As Integer = 0
    Private Sub frmPhepNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgrBC.BringToFront()
        Me.dgrBC.Visible = True
        Me.CrystalReportViewer1.Visible = False
        Load_Combo()
        Me.radDonvi.Checked = True
        Me.cboDonvi.Enabled = True
        Me.cboXuong.Enabled = False
        Me.rbtToanCongTy.Checked = True
        If rbtToanCongTy.Checked Then
            chkTongQuat.Enabled = True
            ckbChiTiet.Enabled = True
        End If
    End Sub
    Public Sub laytext1()
        If radToanKhu.Checked Then
            Me.frmwait.TextBox1.Text = "Toàn công ty             Tổng cộng có  " & Me.Tabledv.Rows.Count.ToString() & "  đơn vị"
        End If
        If radXuong.Checked Then
            Me.frmwait.TextBox1.Text = "Xưởng  " & Me.cboXuong.Value & "  Tổng cộng có  " & Me.Tabledv.Rows.Count.ToString() & "  đơn vị"
        End If
        If radDonvi.Checked Then
            Me.frmwait.TextBox1.Text = "Đơn vị  " & Me.cboDonvi.Value
        End If
    End Sub


   

    Public Sub laytext2(ByVal dong As Integer)
        Me.frmwait.TextBox2.Text = "Đang thống kê đơn vị :  " & Me.Tabledv.Rows(dong).Item(0).ToString() & "      hãy đợi một tí bạn nhé"
    End Sub

    Public Sub laytext3(ByVal dong As Integer)
        Me.frmwait.TextBox2.Text = "Đang thống kê đơn vị :  " & Me.Tabletk.Rows(dong).Item(0).ToString() & "      hãy đợi một tí bạn nhé"
    End Sub
    Public Sub taidulieu()
        Dim dtSet As New DataSet()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim tsdv As Integer = 0
        Dim Tabletam1 = New DataTable()
        Dim Tabletam2 = New DataTable()
        Dim tblTem As DataTable

        Me.Tabletk = New DataTable()

        'Me.Tabletk.Clear()
       
        Dim frmwaiting As frmWaitingPhepNam
        If Me.chkTongQuat.Checked Then
            Dim khu As String
            If rbtKhuA.Checked Then
                khu = "A"
            End If
            If rbtKhuB.Checked Then
                khu = "B"
            End If
            If rbtDonViChung.Checked Then
                khu = "DVC"
            End If
            If rbtToanCongTy.Checked Then
                khu = "TCT"
            End If

            
            frmwaiting = frmWaitingPhepNam.ShowProgress(Me)
            Me.ProgressBar1.Value = i
            tblTem = GoiThuTuc(Me.cboNam.Value, khu)
            Tabletk.Merge(tblTem)
            frmwaiting.CloseProgress()
            frmMainMain.BringToFront()

        Else
            Me.frmwait.Show()
            tsdv = Me.Tabledv.Rows.Count
            Me.laytext1()
            While i < Me.Tabledv.Rows.Count
                Me.laytext2(i)
                Me.frmwait.TextBox1.Refresh()
                Me.frmwait.TextBox2.Refresh()

                tblTem = GoiThuTuc(Me.cboNam.Value, Me.Tabledv.Rows(i).Item(0).ToString())
                If tblTem Is Nothing OrElse tblTem.Rows.Count > 0 Then
                    Tabletk.Merge(tblTem)
                End If

                Me.frmwait.Percentcomplete.Value = (100 * i) / tsdv
                Me.frmwait.Percentcomplete.Update()
                Me.ProgressBar1.Value = (100 * i) / tsdv
                Me.ProgressBar1.Update()
                i = i + 1
            End While
          

        End If
        Tabletk = Tabletk
        'Me.conn.Close()
        Me.ProgressBar1.Value = 100
        Me.frmwait.Percentcomplete.Value = 100
        Me.frmwait.Hide()

    End Sub
    Private Sub TrangThaiChonKhu()
        If rbtKhuA.Checked Then

        End If
    End Sub

    Public Sub GirdColor()
        Dim i As Integer
        For i = 0 To dgrBC.Rows.Count - 1
            If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TKA" Or dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TKB" Or dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TDVC" Then
                '' MÀU CELL
                Me.dgrBC.Rows(i).Cells("STT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T1").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T2").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T3").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T4").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T5").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T6").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T7").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T8").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T9").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T10").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T11").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T12").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("STT").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("STT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T1").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T1").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T2").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T2").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T3").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T3").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T4").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T4").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T5").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T5").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T6").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T6").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T7").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T7").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T8").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T8").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T9").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T9").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T10").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T10").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T11").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T11").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T12").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("T12").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.ForeColor = Color.Red
            End If
            If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "TCT" Then

                Me.dgrBC.Rows(i).Cells("STT").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T1").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T2").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T3").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T4").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T5").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T6").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T7").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T8").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T9").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T10").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T11").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("T12").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.BackColor = Color.Yellow
                Me.dgrBC.Rows(i).Cells("STT").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("STT").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TENXUONG").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T1").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T1").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T2").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T2").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T3").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T3").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T4").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T4").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T5").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T5").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T6").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T6").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T7").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T7").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T8").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T8").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T9").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T9").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T10").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T10").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T11").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T11").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("T12").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("T12").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TONG").Appearance.ForeColor = Color.Red
            End If
        Next

    End Sub


    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
      


        Me.dgrBC.BringToFront()
        Me.dgrBC.Visible = True
        Me.CrystalReportViewer1.Visible = False
        Dim strDV_MA = ""
        If rbtToanCongTy.Checked Then
            If Me.chkTongQuat.Checked Then
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM TOÀN CÔNG TY NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = ""
                obj.WaitingKhu = "Toàn công ty. "
                obj.Nam = cboNam.Value
            Else
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM TOÀN CÔNG TY NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
                'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
            End If
        End If


        If rbtKhuA.Checked Then
            If Me.chkTongQuat.Checked Then
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU A  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = ""
                obj.WaitingKhu = "Khu A. "
                obj.Nam = cboNam.Value


            Else
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU A  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND ST_DONVI .KHU = 'A' AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
                'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
            End If
        End If

        If rbtKhuB.Checked Then
            If Me.chkTongQuat.Checked Then
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU B  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = ""
                obj.WaitingKhu = "Khu B. "
                obj.Nam = cboNam.Value
            Else
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU B  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND ST_DONVI .KHU = 'B' AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA  "
                'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
                
            End If
        End If

        If rbtDonViChung.Checked Then

            If Me.chkTongQuat.Checked Then
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU DVC  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = ""
                obj.WaitingKhu = "Đơn Vị Chung. "
                obj.Nam = cboNam.Value
            Else
                Me.DonVi = "TCT"
                Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM KHU DVC  NĂM: " & Me.cboNam.Value.ToString()
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND ST_DONVI .KHU = 'DVC' AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA   "
                'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') ORDER BY DV_MA "
            End If
        End If

        If radXuong.Checked Then
            Dim khu As String
            If rbtKhuA.Checked Then
                khu = "A"
            ElseIf rbtKhuB.Checked Then
                khu = "B"
            ElseIf rbtDonViChung.Checked Then
                khu = "DVC"


            End If
            Me.DonVi = Me.cboXuong.Value
            Me.XpCaption2.Text = "THỐNG KÊ PHÉP XƯỞNG " & Me.cboXuong.Value.ToString() & " NĂM: " & Me.cboNam.Value.ToString()
            If rbtDonViChung.Checked Or rbtKhuA.Checked Or rbtKhuB.Checked Then
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND N_MA NOT IN ('BGD','CG') AND ST_DONVI.KHU = '" & khu & "' AND  X_MA_ = N'" & Me.cboXuong.Value & "'   ORDER BY DV_MA "
            Else
                strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND N_MA NOT IN ('BGD','CG')  AND  X_MA_ = N'" & Me.cboXuong.Value & "'   ORDER BY DV_MA "
            End If
            'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') AND  X_MA_ = N'" & Me.cboXuong.Value & "'   ORDER BY DV_MA "

        End If
        If radDonvi.Checked Then
            Me.DonVi = Me.cboDonvi.Value.ToString()
            strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB =0 AND N_MA NOT IN ('BGD','CG') AND  DV_MA = N'" & Me.cboDonvi.Value & "'   ORDER BY DV_MA "
            'strDV_MA = " SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB IS NULL AND N_MA NOT IN ('BGD','CG') AND  DV_MA = N'" & Me.cboDonvi.Value & "'   ORDER BY DV_MA "
            Me.XpCaption2.Text = "THỐNG KÊ PHÉP NĂM ĐƠN VỊ " & Me.cboDonvi.Value.ToString() & " NĂM: " & Me.cboNam.Value.ToString()
        End If
        Dim tsdv As Integer
        Dim i As Integer
        Dim pathXML As String
        Me.Tabledv = Me.b.LoadTruyVan(strDV_MA)
        Me.taidulieu()
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = Me.Tabletk
        If Me.Tabletk.Rows.Count > 0 Then
            If chkTongQuat.Checked Then
                pathXML = "/layout/ThongKePhepNam.xml"
                clsTools.GridTheme1(Me.dgrBC)
                Dim dgrBC As Object = Me.dgrBC

                grid.initControlXML((dgrBC), (Application.StartupPath & pathXML), typeControl.Grid, "coldgrNghiPhep")
                GirdColor()
            Else
                grid.initControlNoXML(dgrBC)
                ''GirdColor()
            End If
        End If
        Me.ProgressBar1.Value = 100
        MessageBox.Show("Tải dữ liệu thành công", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Dim frmwait As New frmWaiting_phepnam
    Public Tabletk As DataTable
    Public Tabledv As DataTable
    Private Sub LoadGridView()

        Dim i As Integer
        With Me.dgrBC.DisplayLayout.Bands(0)
            For i = 0 To .Columns.Count - 1
                .Columns(i).CellActivation() = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = VAlign.Middle
            Next
            If Me.chkTongQuat.Checked Then

                .Columns("STT").Header.Caption = "STT 次序"
                .Columns("STT").Width = 80
                .Columns("STT").Header.VisiblePosition = 1
                .Columns("TENXUONG").Header.Caption = "XƯỞNG 廠別"
                .Columns("TENXUONG").Width = 200
                .Columns("TENXUONG").Header.VisiblePosition = 2
                .Columns("T1").Header.Caption = "T1 月"
                .Columns("T1").Width = 50
                .Columns("T1").Header.VisiblePosition = 3

                .Columns("T2").Header.Caption = "T2 月"
                .Columns("T2").Width = 50
                .Columns("T2").Header.VisiblePosition = 4

                .Columns("T3").Header.Caption = "T3 月"
                .Columns("T3").Width = 50
                .Columns("T3").Header.VisiblePosition = 5

                .Columns("T4").Header.Caption = "T4 月"
                .Columns("T4").Width = 50
                .Columns("T4").Header.VisiblePosition = 6

                .Columns("T5").Header.Caption = "T5 月"
                .Columns("T5").Width = 50
                .Columns("T5").Header.VisiblePosition = 7

                .Columns("T6").Header.Caption = "T6 月"
                .Columns("T6").Width = 50
                .Columns("T6").Header.VisiblePosition = 8

                .Columns("T7").Header.Caption = "T7 月"
                .Columns("T7").Width = 50
                .Columns("T7").Header.VisiblePosition = 9

                .Columns("T8").Header.Caption = "T8 月"
                .Columns("T8").Width = 50
                .Columns("T8").Header.VisiblePosition = 10

                .Columns("T9").Width = 50
                .Columns("T9").Header.Caption = "T9 月"
                .Columns("T9").Header.VisiblePosition = 11

                .Columns("T10").Header.Caption = "T10 月"
                .Columns("T10").Width = 50
                .Columns("T10").Header.VisiblePosition = 12

                .Columns("T11").Header.Caption = "T11 月"
                .Columns("T11").Width = 50
                .Columns("T11").Header.VisiblePosition = 13

                .Columns("T12").Header.Caption = "T12 月"
                .Columns("T12").Width = 50
                .Columns("T12").Header.VisiblePosition = 14

                .Columns("TONG").Header.Caption = "TỔNG CỘNG 合計"
                .Columns("TONG").Width = 150
                .Columns("TONG").Header.VisiblePosition = 15

            Else
                .Columns("STT").Header.Caption = "STT 次序"
                .Columns("STT").Width = 80
                .Columns("STT").Header.VisiblePosition = 1


                .Columns("NV_TEN").Header.Caption = "HỌ TÊN 姓名"
                .Columns("NV_TEN").Width = 200
                .Columns("NV_TEN").Header.VisiblePosition = 2
                .Columns("NV_TEN").CellAppearance.TextHAlign = HAlign.Left

                .Columns("NV_MA").Header.Caption = "SỐ THẺ 工號"
                .Columns("NV_MA").Width = 100
                .Columns("NV_MA").Header.VisiblePosition = 3



                .Columns("DV_MA").Header.Caption = "ĐƠN VỊ 單位"
                .Columns("DV_MA").Width = 200
                .Columns("DV_MA").Header.VisiblePosition = 4
                .Columns("DV_MA").CellAppearance.TextHAlign = HAlign.Left

                .Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO 進廠日期"
                .Columns("NV_NGAYVAO").Width = 150
                .Columns("NV_NGAYVAO").Header.VisiblePosition = 5


                .Columns("PN_Songaynamtruoc").Header.Caption = "SN NĂM TRƯỚC 去年年假"
                .Columns("PN_Songaynamtruoc").Width = 150
                .Columns("PN_Songaynamtruoc").Header.VisiblePosition = 6

                .Columns("PN_Songaynamnay").Header.Caption = "SN NĂM NAY 今年年假"
                .Columns("PN_Songaynamnay").Width = 150
                .Columns("PN_Songaynamnay").Header.VisiblePosition = 7

                .Columns("PN_NangnhocDH").Header.Caption = "SN ĐỘC HẠI 繁重-毒害"
                .Columns("PN_NangnhocDH").Width = 180
                .Columns("PN_NangnhocDH").Header.VisiblePosition = 8

                .Columns("PN_PhepTren5Nam").Header.Caption = "PHÉP TRÊN 5 NĂM 5年以上"
                .Columns("PN_PhepTren5Nam").Width = 180
                .Columns("PN_PhepTren5Nam").Header.VisiblePosition = 9

                .Columns("PN_SothanglamNNDH").Hidden = True
                .Columns("TONGCONGPHEP").Header.Caption = "TỔNG PHÉP"
                .Columns("TONGCONGPHEP").Width = 180
                .Columns("TONGCONGPHEP").Header.VisiblePosition = 10


                .Columns("LAMTRON").Header.Caption = "TỔNG PHÉP LÀM TRÒN"
                .Columns("LAMTRON").Width = 180
                .Columns("LAMTRON").Header.VisiblePosition = 11

                .Columns("TONGCONG").Header.Caption = "TỔNG CỘNG 合計"
                .Columns("TONGCONG").Width = 80
                .Columns("TONGCONG").Header.VisiblePosition = 12


                .Columns("T1").Header.Caption = "T1 月"
                .Columns("T1").Width = 50
                .Columns("T1").Header.VisiblePosition = 13

                .Columns("T2").Header.Caption = "T2 月"
                .Columns("T2").Width = 50
                .Columns("T2").Header.VisiblePosition = 14

                .Columns("T3").Header.Caption = "T3 月"
                .Columns("T3").Width = 50
                .Columns("T3").Header.VisiblePosition = 15

                .Columns("T4").Header.Caption = "T4 月"
                .Columns("T4").Width = 50
                .Columns("T4").Header.VisiblePosition = 16

                .Columns("T5").Header.Caption = "T5 月"
                .Columns("T5").Width = 50
                .Columns("T5").Header.VisiblePosition = 17

                .Columns("T6").Header.Caption = "T6 月"
                .Columns("T6").Width = 50
                .Columns("T6").Header.VisiblePosition = 18

                .Columns("T7").Header.Caption = "T7 月"
                .Columns("T7").Width = 50
                .Columns("T7").Header.VisiblePosition = 19

                .Columns("T8").Header.Caption = "T8 月"
                .Columns("T8").Width = 50
                .Columns("T8").Header.VisiblePosition = 20

                .Columns("T9").Width = 50
                .Columns("T9").Header.Caption = "T9 月"
                .Columns("T9").Header.VisiblePosition = 21

                .Columns("T10").Header.Caption = "T10 月"
                .Columns("T10").Width = 50
                .Columns("T10").Header.VisiblePosition = 22

                .Columns("T11").Header.Caption = "T11 月"
                .Columns("T11").Width = 50
                .Columns("T11").Header.VisiblePosition = 23

                .Columns("T12").Header.Caption = "T12 月"
                .Columns("T12").Width = 50
                .Columns("T12").Header.VisiblePosition = 24
            End If

        End With
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout

        If ckbChiTiet.Checked Then


            Dim i As Integer
            For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                'If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
                e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
                'End If
            Next i
            '    e.Layout.Bands(0).Columns("DV_MA").CellAppearance.TextHAlign = HAlign.Left
            '    e.Layout.Bands(0).Columns("NV_TEN").CellAppearance.TextHAlign = HAlign.Left
            '    e.Layout.Bands(0).Columns("STT").Header.Caption = "STT 次序"
            '    e.Layout.Bands(0).Columns("STT").Width = 80
            '    e.Layout.Bands(0).Columns("NV_TEN").Header.Caption = "HỌ TÊN 姓名"
            '    e.Layout.Bands(0).Columns("NV_TEN").Width = 200
            '    e.Layout.Bands(0).Columns("NV_MA").Header.Caption = "SỐ THẺ 工號"
            '    e.Layout.Bands(0).Columns("NV_MA").Width = 100
            '    e.Layout.Bands(0).Columns("DV_MA").Header.Caption = "ĐƠN VỊ 單位"
            '    e.Layout.Bands(0).Columns("DV_MA").Width = 200
            '    e.Layout.Bands(0).Columns("NV_NGAYVAO").Header.Caption = "NGÀY VÀO 進廠日期"
            '    e.Layout.Bands(0).Columns("NV_NGAYVAO").Width = 150
            '    e.Layout.Bands(0).Columns("PN_Songaynamtruoc").Header.Caption = "SN NĂM TRƯỚC 去年年假"
            '    e.Layout.Bands(0).Columns("PN_Songaynamtruoc").Width = 150
            '    e.Layout.Bands(0).Columns("PN_Songaynamnay").Header.Caption = "SN NĂM NAY 今年年假"
            '    e.Layout.Bands(0).Columns("PN_Songaynamnay").Width = 150
            '    e.Layout.Bands(0).Columns("PN_NangnhocDH").Header.Caption = "SN ĐỘC HẠI 繁重-毒害"
            '    e.Layout.Bands(0).Columns("PN_NangnhocDH").Width = 180
            '    e.Layout.Bands(0).Columns("PN_PhepTren5Nam").Header.Caption = "PHÉP TRÊN 5 NĂM 5年以上"
            '    e.Layout.Bands(0).Columns("PN_PhepTren5Nam").Width = 180

            '    e.Layout.Bands(0).Columns("PN_SothanglamNNDH").Hidden = True
            '    e.Layout.Bands(0).Columns("TONGCONGPHEP").Header.Caption = "TỔNG PHÉP"
            '    e.Layout.Bands(0).Columns("TONGCONGPHEP").Width = 180

            '    e.Layout.Bands(0).Columns("LAMTRON").Header.Caption = "TỔNG PHÉP LÀM TRÒN"
            '    e.Layout.Bands(0).Columns("LAMTRON").Width = 180


            '    e.Layout.Bands(0).Columns("TONGCONG").Header.Caption = "TỔNG CỘNG 合計"
            '    e.Layout.Bands(0).Columns("TONGCONG").Width = 80
            '    e.Layout.Bands(0).Columns("T1").Header.Caption = "T1 月"
            '    e.Layout.Bands(0).Columns("T1").Width = 50
            '    e.Layout.Bands(0).Columns("T2").Header.Caption = "T2 月"
            '    e.Layout.Bands(0).Columns("T2").Width = 50
            '    e.Layout.Bands(0).Columns("T3").Header.Caption = "T3 月"
            '    e.Layout.Bands(0).Columns("T3").Width = 50
            '    e.Layout.Bands(0).Columns("T4").Header.Caption = "T4 月"
            '    e.Layout.Bands(0).Columns("T4").Width = 50
            '    e.Layout.Bands(0).Columns("T5").Header.Caption = "T5 月"
            '    e.Layout.Bands(0).Columns("T5").Width = 50
            '    e.Layout.Bands(0).Columns("T6").Header.Caption = "T6 月"
            '    e.Layout.Bands(0).Columns("T6").Width = 50
            '    e.Layout.Bands(0).Columns("T7").Header.Caption = "T7 月"
            '    e.Layout.Bands(0).Columns("T7").Width = 50
            '    e.Layout.Bands(0).Columns("T8").Header.Caption = "T8 月"
            '    e.Layout.Bands(0).Columns("T8").Width = 50
            '    e.Layout.Bands(0).Columns("T9").Header.Caption = "T9 月"
            '    e.Layout.Bands(0).Columns("T9").Width = 50
            '    e.Layout.Bands(0).Columns("T10").Header.Caption = "T10 月"
            '    e.Layout.Bands(0).Columns("T10").Width = 50
            '    e.Layout.Bands(0).Columns("T11").Header.Caption = "T11 月"
            '    e.Layout.Bands(0).Columns("T11").Width = 50
            '    e.Layout.Bands(0).Columns("T12").Header.Caption = "T12 月"
            '    e.Layout.Bands(0).Columns("T12").Width = 50
        End If

    End Sub
    'Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
    '    'e.Row.Cells("STT").Value = e.Row.Index + 1
    '    'e.Row.Update()
    'End Sub
    Private Sub cboNam_EditorSpinButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles cboNam.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select

    End Sub
    Private Sub LayThamSo()
        Dim khu As String
        If rbtKhuA.Checked Then
            khu = "A"
        ElseIf rbtKhuB.Checked Then
            khu = "B"
        ElseIf rbtDonViChung.Checked Then
            khu = "DVC"
        ElseIf rbtToanCongTy.Checked Then
            khu = "TCT"
        End If


        'Me.ReportID = "615" đang chạy thủ tục chưa chia khu
        Me.ReportID = "616" ' chạy proc chia khu
        Dim strArray As String() = New String() {Me.cboNam.Value, khu}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub
    Private Sub HienThiReport()
        Dim document As ReportDocument
        Dim report As New ClsBReport
        Try
            If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
                document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
            Else
                document = report.InitReport(Me.reportID)
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            Me.Close()
            ProjectData.ClearProjectError()
            Return
        End Try
        If Me.issysReport Then
            document = report.SetParameter(document, Me.para)
        End If
        Me.CrystalReportViewer1.ReportSource = document
    End Sub

    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        Me.cboXuong.Enabled = Me.radXuong.Checked
        Me.chkTongQuat.Checked = False
        Me.chkTongQuat.Enabled = False
        Me.ckbChiTiet.Checked = False
        Me.ckbChiTiet.Enabled = False
        Me.btnXemBC.Enabled = False
    End Sub

    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        Me.cboDonvi.Enabled = Me.radDonvi.Checked
        Me.chkTongQuat.Checked = False
        Me.chkTongQuat.Enabled = False
        Me.ckbChiTiet.Checked = False
        Me.ckbChiTiet.Enabled = False
        Me.btnXemBC.Enabled = False
    End Sub

    Private Sub radTongQuat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radToanKhu.CheckedChanged
        If Me.radToanKhu.Checked Then
            Me.cboDonvi.Enabled = False
            Me.cboXuong.Enabled = False
            Me.chkTongQuat.Enabled = True
            Me.chkTongQuat.Checked = True
            Me.ckbChiTiet.Enabled = True
            Me.btnXemBC.Enabled = True
        End If
    End Sub

    Private Sub btnXemBC_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemBC.Activate
        Me.CrystalReportViewer1.BringToFront()
        Me.CrystalReportViewer1.Visible = True
        Me.dgrBC.Visible = False
        LayThamSo()
        HienThiReport()
    End Sub

    Private Sub chkTong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTongQuat.CheckedChanged
        If Me.chkTongQuat.Checked Then

            Me.ckbChiTiet.Checked = False
            Me.btnXemBC.Enabled = True

        End If
    End Sub

    Private Sub rbtToanCongTy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtToanCongTy.CheckedChanged
        If rbtToanCongTy.Checked Then
            'GroupBox3.Enabled = False
            Me.radToanKhu.Enabled = False
            Me.radDonvi.Enabled = False
            Me.radXuong.Enabled = False
            Me.cboXuong.Enabled = False
            Me.cboDonvi.Enabled = False
           
            Me.ckbChiTiet.Enabled = True
            Me.radToanKhu.Checked = False
            Me.radDonvi.Checked = False
            Me.chkTongQuat.Enabled = True
            Me.ckbChiTiet.Enabled = True
            chkTongQuat.Checked = True

        Else
            Me.radToanKhu.Enabled = False
            Me.radDonvi.Enabled = True
            Me.radXuong.Enabled = True
            Me.cboXuong.Enabled = True
            Me.cboDonvi.Enabled = True
            Me.radToanKhu.Enabled = True
            Me.chkTongQuat.Checked = False
            Me.ckbChiTiet.Checked = False
            Me.radToanKhu.Checked = False
            If radToanKhu.Checked = False Then
                chkTongQuat.Enabled = False
                ckbChiTiet.Enabled = False
            Else
                chkTongQuat.Enabled = True
                ckbChiTiet.Enabled = True
            End If
        End If
    End Sub


    Private Sub ckbChiTiet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbChiTiet.CheckedChanged
        If ckbChiTiet.Checked Then
            chkTongQuat.Checked = False
            btnXemBC.Enabled = False
        End If
    End Sub



    Private Sub TrangThaiCheckKhu()
        If rbtKhuA.Checked Then
            obj.TinhTrangChonKhu = "A"
        End If
        If rbtKhuB.Checked Then
            obj.TinhTrangChonKhu = "B"
        End If
        If rbtDonViChung.Checked Then
            obj.TinhTrangChonKhu = "DVC"
        End If
        If rbtToanCongTy.Checked Then
            obj.TinhTrangChonKhu = "TCT"
        End If
    End Sub

   
    Private Sub rbtKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtKhuA.CheckedChanged
        radToanKhu.Checked = True
        Load_Combo()
    End Sub

    Private Sub rbtKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtKhuB.CheckedChanged
        radToanKhu.Checked = True
        Load_Combo()
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub rbtDonViChung_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDonViChung.CheckedChanged

        radToanKhu.Checked = True

        Load_Combo()
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
    End Sub
End Class