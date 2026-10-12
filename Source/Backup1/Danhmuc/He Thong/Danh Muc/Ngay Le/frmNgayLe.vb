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

Public Class frmNgayLe
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New Obj_Thang

    ' Methods
    Public Sub New()
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        'Định dạng UltraGird---------------
        clsTools.GridTheme1(Me.dgrBC)
        '---------------
        If Me.UltraTabControl1.SelectedTab.Index = 0 Then
            obj.ChonBang = 1
            Me.b = New ClsB_Thang
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/H_Thang.xml"), typeControl.Grid, "coldgrchucvu")
            Me.dgrBC = DirectCast(dgrBC, UltraGrid)
            Me.XpCaption2.Text = "Danh Sách Tháng"
            If (Me.dgrBC.Rows.Count > 0) Then
                Me.dgrBC.Rows.Item(0).Selected = True
                Me.dgrBC.Rows(0).Activated = True
                Me.HieuChinh()
            End If
        ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
            obj.ChonBang = 2
            Me.b = New ClsB_Thang
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/H_Le.xml"), typeControl.Grid, "coldgrchucvu")
            Me.dgrBC = DirectCast(dgrBC, UltraGrid)
            Me.XpCaption2.Text = "Danh Sách Ngày Lễ"
            If (Me.dgrBC.Rows.Count > 0) Then
                Me.dgrBC.Rows.Item(0).Selected = True
                Me.dgrBC.Rows(0).Activated = True
                Me.HieuChinh()
            End If
        End If
    End Sub

    Public Sub HieuChinh()
        Dim grid As New clsTformatGrid
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow

        If Me.UltraTabControl1.SelectedTab.Index = 0 Then
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.dtpMa.Text = activeRow.Cells.Item("T_MA").Value.ToString
                Me.dtpMa.Enabled = False
                Me.dtpTuNgay.Text = activeRow.Cells.Item("T_TUNGAY").Value.ToString
                Me.dtpTuNgay.Enabled = False
                Me.dtpDenNgay.Text = activeRow.Cells.Item("T_DENNGAY").Value.ToString
                Me.dtpDenNgay.Enabled = False
                Me.txtSoNgayCong.Text = activeRow.Cells.Item("T_SONGAYCONG").Value.ToString
                Me.txtSoNgayCong.Enabled = False
                Me.dtpTuNgay.Focus()
                Me.ThemSua = 1
            End If
        ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.dtpNgay.Text = activeRow.Cells.Item("LE_NGAY").Value.ToString
                Me.dtpNgay.ReadOnly = True
                Me.txtTen.Text = activeRow.Cells.Item("LE_TEN").Value.ToString
                Me.txtTen.Enabled = False
                Me.txtTen.Focus()
                Me.ThemSua = 1
            End If
        End If
        Me.btnLuu.Enabled = False
        Me.btnXoa.Enabled = True
    End Sub

    Public Sub ThemMoi()
        If Me.UltraTabControl1.SelectedTab.Index = 0 Then
            obj.ChonBang = 1
            Me.b = New ClsB_Thang
            Me.dtpMa.Value = Now
            Me.dtpTuNgay.Value = Now
            Me.dtpDenNgay.Value = Now
            Me.txtSoNgayCong.Clear()
            Me.dtpMa.Enabled = True
            Me.dtpTuNgay.Enabled = False
            Me.dtpDenNgay.Enabled = False
            Me.txtTen.Enabled = True
            Me.dtpMa.Focus()
            Me.ThemSua = 0
        ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
            obj.ChonBang = 2
            Me.b = New ClsB_Thang
            Me.dtpNgay.Value = Now
            Me.txtTen.Clear()
            Me.dtpNgay.ReadOnly = False
            Me.txtTen.Enabled = True
            Me.dtpNgay.Focus()
            Me.ThemSua = 0
        End If
        Me.btnLuu.Enabled = True
        Me.btnXoa.Enabled = False
    End Sub
    Public Sub SoNgayCong()
        Dim thang As String = Me.dtpDenNgay.Value.Month.ToString()
        Dim songay As String
        Dim songaycn As String

        Select Case thang
            Case "1", "3", "5", "7", "8", "10", "12" : songay = 31
            Case "4", "6", "9", "11" : songay = 30
            Case "2"
                If Me.dtpDenNgay.Value.Year Mod 4 = 0 Then
                    songay = 29
                Else
                    songay = 28
                End If
        End Select
        Dim tungay, denngay As String
        tungay = Me.dtpTuNgay.Value.Year.ToString + "-" + Me.dtpTuNgay.Value.Month.ToString + "-" + Me.dtpTuNgay.Value.Day.ToString
        denngay = Me.dtpDenNgay.Value.Year.ToString + "-" + Me.dtpDenNgay.Value.Month.ToString + "-" + Me.dtpDenNgay.Value.Day.ToString
        obj.TUNGAY = tungay
        obj.DENNGAY = denngay
        obj.ChonBang = 3
        Dim TableA As DataTable
        TableA = Me.b.LoadDS(obj)
        Me.txtSoNgayCong.Text = songay - TableA.Rows(0).Item("SOCN")


    End Sub
  
    Public Sub LuuDuLieu()
        Dim jthang As New Obj_Thang

        If Me.UltraTabControl1.SelectedTab.Index = 0 Then
            jthang.ChonBang = 1
            jthang.setvalue(Me.dtpMa.Text, Me.dtpTuNgay.Text, Me.dtpDenNgay.Text, Me.txtSoNgayCong.Text)

            If Not jthang.KtMa Then
                MessageBox.Show("Chưa nhập mã tháng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.dtpMa.Focus()
            Else
                Me.b = New ClsB_Thang
                Try
                    Dim tu, den As Date
                    tu = Me.dtpTuNgay.Value
                    den = Me.dtpDenNgay.Value
                    Dim tungay, denngay As String
                    tungay = tu.Year.ToString() + "-" + tu.Month.ToString() + "-" + tu.Day.ToString()
                    denngay = den.Year.ToString() + "-" + den.Month.ToString() + "-" + den.Day.ToString()
                    jthang.TUNGAY = tungay
                    jthang.DENNGAY = denngay
                    If Me.b.CapNhat(jthang, Me.ThemSua) Then
                        MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        jthang.setnull()
                        obj.ChonBang = 1
                        'Me.dgrBC.DataSource = Me.b.LoadDS(jthang)
                        Me.methodLoad()
                    Else
                        Me.dtpMa.Focus()
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    clsTools.thongbaoLoi(exception.Message)
                    ProjectData.ClearProjectError()
                End Try
            End If
        ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
            jthang.ChonBang = 2
            jthang.setvalue_Ngay(Me.dtpNgay.Text, Me.txtTen.Text)
            If Not jthang.KtNgay Then
                MessageBox.Show("Chưa nhập Ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.dtpMa.Focus()
            Else
                Me.b = New ClsB_Thang
                Try
                    Dim NGAY As Date
                    NGAY = Me.dtpNgay.Value
                    jthang.NGAY = NGAY.Year.ToString + "-" + NGAY.Month.ToString + "-" + NGAY.Day.ToString
                    If Me.b.CapNhat1(jthang, Me.ThemSua) Then
                        MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        jthang.setnull()
                        jthang.ChonBang = 2
                        'Me.dgrBC.DataSource = Me.b.LoadDS(jthang)
                        Me.methodLoad()
                    Else
                        Me.dtpMa.Focus()
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    clsTools.thongbaoLoi(exception.Message)
                    ProjectData.ClearProjectError()
                End Try
            End If
        End If
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jthang As New Obj_Thang
            If Me.UltraTabControl1.SelectedTab.Index = 0 Then
                obj.ChonBang = 1
                If (Me.dgrBC.Selected.Rows.Count > 0) Then
                    Dim str As String
                    If (Me.dgrBC.Selected.Rows.Count = 1) Then
                        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                        If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                            str = StringType.FromObject(activeRow.Cells.Item("T_MA").Value)
                            jthang.MATHANG = str
                            If (MessageBox.Show(("Bạn có muốn xóa tháng có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo(jthang) Then
                                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            Else
                                MessageBox.Show("Không được xóa mã tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                        Return
                    End If
                    If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " tháng đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                        Return
                    End If
                    Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num2)
                        str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("T_MA").Value)
                        jthang.MATHANG = str
                        If Me.b.DeleteInfo(jthang) Then
                        Else
                            MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                        i += 1
                    Loop
                End If
            ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
                obj.ChonBang = 2
                If (Me.dgrBC.Selected.Rows.Count > 0) Then
                    Dim str As Date
                    If (Me.dgrBC.Selected.Rows.Count = 1) Then
                        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                        If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                            str = StringType.FromObject(activeRow.Cells.Item("LE_NGAY").Value)
                            jthang.NGAY = str.Year.ToString + "-" + str.Month.ToString + "-" + str.Day.ToString
                            If (MessageBox.Show(("Bạn có muốn xóa ngày lễ có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo1(jthang) Then
                                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            Else
                                MessageBox.Show("Không được xóa mã  ngày lễ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                        Return
                    End If
                    If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " ngày lễ đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                        Return
                    End If
                    Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num2)
                        str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("LE_NGAY").Value)
                        jthang.NGAY = str.Year.ToString + "-" + str.Month.ToString + "-" + str.Day.ToString
                        If Me.b.DeleteInfo1(jthang) Then
                        Else
                            MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                        i += 1
                    Loop
                End If
            End If
Label_0274:
            jthang.setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jthang)
            Me.methodLoad()

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub


    Friend WithEvents b As ClsB_Thang

    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.HieuChinh()
        Me.btnXoa.Enabled = True
        Me.btnThem.Enabled = True
    End Sub

    Private Sub btnThem_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemMoi()
    End Sub

    Private Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        Me.ThemMoi()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
        Me.methodLoad()
    End Sub
    Private Sub frmNgayLe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.methodLoad()
    End Sub

    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UltraTabControl1.SelectedTabChanged
        Me.methodLoad()
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel File(*.xls)|*.xls|All Filss(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub dtpDenNgay_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDenNgay.ValueChanged
        Me.SoNgayCong()
    End Sub

    Private Sub dtpMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpMa.ValueChanged
        'DatePart(DateInterval.Weekday, ngaybatdau)
        'DateDiff(DateInterval., ngaybatdau, ngayketthuc)
        'dateadd(DateInterval.Day ,
        Dim ngaydau As String
        ngaydau = dtpMa.Value.Year.ToString() + "/" + dtpMa.Value.Month.ToString() + "/" + "1"
        Me.dtpTuNgay.Value = ngaydau
        '-----
        Dim thang As String = Me.dtpMa.Value.Month.ToString()
        Dim songay As String
        Dim songaycn As String

        Select Case thang
            Case "1", "3", "5", "7", "8", "10", "12" : songay = 31
            Case "4", "6", "9", "11" : songay = 30
            Case "2"
                If Me.dtpMa.Value.Year Mod 4 = 0 Then
                    songay = 29
                Else
                    songay = 28
                End If
        End Select
        Dim ngaycuoi As String
        ngaycuoi = dtpMa.Value.Year.ToString() + "/" + dtpMa.Value.Month.ToString() + "/" + songay.ToString
        Me.dtpDenNgay.Value = ngaycuoi
        obj.TUNGAY = ngaydau
        obj.DENNGAY = ngaycuoi
        obj.ChonBang = 3
        Dim TableA As DataTable
        TableA = Me.b.LoadDS(obj)
        Me.txtSoNgayCong.Text = songay - TableA.Rows(0).Item("SOCN")


    End Sub
    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim report As New FrmReport

        If Me.UltraTabControl1.SelectedTab.Index = 0 Then
            report.reportID = "1068"
            'Dim strArray As String() = New String() {Me.txtMaNganh.Text}
            'report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.UltraTabControl1.SelectedTab.Index = 1 Then
            report.reportID = "1071"
            'Dim strArray As String() = New String() {Me.txtMaNganh.Text}
            'report.para = strArray
            report.issysReport = True
            report.Show()
        End If
    End Sub
End Class