Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
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


Public Class frmBaocaochitietgiocong
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrKhacThuong")
    End Sub

    Public Sub Setchecknull()
        chStateNgay = False
        chStateXuong = False
        chStateDonvi = False
        chStateTuan = False
    End Sub

    Public Sub Trangthaidieukien()
        Me.cbNgaythangnam.Enabled = chStateNgay
        Me.cbXuong.Enabled = chStateXuong
        Me.cbDonvi.Enabled = chStateDonvi
        Me.txtTuan.Enabled = chStateTuan
        Me.txtNam.Enabled = chStateTuan
    End Sub

    Public Sub Trangthaidieukienbtcapnhat()
        Me.btCapnhatngay.Enabled = Me.chStateCapNhatNgay
        Me.btCapnhatthang.Enabled = Me.chStateCapNhatThang
        Me.btCapnhatTuan.Enabled = Me.chStateCapNhatTuan
        Me.btCapnhatnam.Enabled = Me.chStateCapNhatNam
    End Sub

    Public Sub Hiendieukientuan()
        Me.lbTuan.Visible = True
        Me.lbNam.Visible = True
        Me.txtNam.Visible = True
        Me.chbTuan.Visible = True
        Me.txtTuan.Visible = True

        Me.lbNgay.Visible = False
        Me.chbNgay.Visible = False
        Me.cbNgaythangnam.Visible = False
    End Sub

    Public Sub Andieukientuan()
        Me.lbTuan.Visible = False
        Me.lbNam.Visible = False
        Me.txtNam.Visible = False
        Me.chbTuan.Visible = False
        Me.txtTuan.Visible = False

        Me.lbNgay.Visible = True
        Me.chbNgay.Visible = True
        Me.cbNgaythangnam.Visible = True
    End Sub


    Public Function KiemTraThamSo() As Integer
        If Me.chbTuan.Visible = True And Me.chbTuan.Checked = True Then
            If Me.txtTuan.Text = "" Then
                Me.txtTuan.Focus()
                MessageBox.Show("Bạn Phải Nhập Vào Tuần")
                Return 1
            End If
            If Me.txtNam.Text = "" Then
                Me.txtNam.Focus()
                MessageBox.Show("Bạn Phải Nhập Vào Năm")
                Return 1
            End If
        End If
        Return 0
    End Function

    Public Language As Integer
    Dim ReportID As String
    Dim PATH As String
    Dim chStateNgay As Boolean
    Dim chStateTuan As Boolean
    Dim chStateXuong As Boolean
    Dim chStateDonvi As Boolean
    Dim chStateCapNhatNgay As Boolean
    Dim chStateCapNhatThang As Boolean
    Dim chStateCapNhatTuan As Boolean
    Dim chStateCapNhatNam As Boolean
    Dim obj As New objBaocaochitietgiocong
    Friend WithEvents b As clsBBaocaochitietgiocong

    Private Sub frmBaocaochitietgiocong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBBaocaochitietgiocong

        obj.Setnull()
        obj.ChonBang = 5
        obj.Table = "ST_NXUONG"
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)

        obj.Setnull()
        obj.ChonBang = 6
        obj.Table = "ST_DONVI"
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)


        Me.rdCTNgay.Checked = True

        'An hoac hien cac control dieu kien
        Me.Setchecknull()
        Me.Trangthaidieukien()

    End Sub

    Private Sub rdCTTuan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCTTuan.CheckedChanged
        Me.chStateCapNhatTuan = Me.rdCTTuan.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdCTTuan.Checked = True Then
            Me.Hiendieukientuan()
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False
            Me.chbDonvi.Checked = False
            Me.ReportID = "105"
            Me.PATH = "/layout/Thongke/Thongkechitietgiocong/ChiTietGioCongTuan.xml"

            obj.Table = "JELLTHONGKEGIOCONG_TUANNHANVIENTABLE"
            obj.ChonBang = 2

            Me.b = New clsBBaocaochitietgiocong
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdCTThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCTThang.CheckedChanged
        Me.chStateCapNhatThang = Me.rdCTThang.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdCTThang.Checked = True Then
            Me.Andieukientuan()
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False
            Me.chbDonvi.Checked = False

            Me.ReportID = "104"
            Me.PATH = "/layout/Thongke/Thongkechitietgiocong/ChiTietGioCongThang.xml"

            obj.Table = "JELLTHONGKEGIOCONG_THANGNHANVIENTABLE"
            obj.ChonBang = 3

            Me.b = New clsBBaocaochitietgiocong
            'Me.methodLoad()
        End If
    End Sub

   

  

    Private Sub chbTuan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTuan.CheckedChanged
        chStateTuan = Me.chbTuan.Checked
        If Me.chbTuan.Checked = False Then
            Me.txtTuan.Text = "01"
            Me.txtNam.Text = "2009"
        End If
        Me.Trangthaidieukien()
    End Sub

    Private Sub txtTuan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTuan.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub


    Private Sub txtNam_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNam.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

   
    Private Sub rdCTNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCTNgay.CheckedChanged
        Me.chStateCapNhatNgay = Me.rdCTNgay.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdCTNgay.Checked = True Then
            Me.Andieukientuan()
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False
            Me.chbDonvi.Checked = False

            Me.ReportID = "106"
            Me.PATH = "/layout/Thongke/Thongkechitietgiocong/ChiTietGioCongNgay.xml"

            obj.Table = "JELLTHONGKEGIOCONG_NGAYNHANVIENTABLE"
            obj.ChonBang = 1

            Me.b = New clsBBaocaochitietgiocong
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdCTNam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCTNam.CheckedChanged
        Me.chStateCapNhatNam = Me.rdCTNam.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdCTNam.Checked = True Then
            Me.Andieukientuan()
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False
            Me.chbDonvi.Checked = False

            Me.ReportID = "107"
            Me.PATH = "/layout/Thongke/Thongkechitietgiocong/ChiTietGioCongNam.xml"

            obj.Table = "JELLTHONGKEGIOCONG_NAMNHANVIENTABLE"
            obj.ChonBang = 4

            Me.b = New clsBBaocaochitietgiocong
            'Me.methodLoad()
        End If
    End Sub

    
    Private Sub chbNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgay.CheckedChanged
        chStateNgay = Me.chbNgay.Checked
        Me.Trangthaidieukien()
    End Sub

    Private Sub chbXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbXuong.CheckedChanged
        chStateXuong = Me.chbXuong.Checked
        Me.cbXuong.Focus()
        Me.Trangthaidieukien()
    End Sub

    Private Sub chbDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDonvi.CheckedChanged
        chStateDonvi = Me.chbDonvi.Checked
        Me.Trangthaidieukien()
    End Sub

    'Cap nhat gio cong ngay
    Private Sub btCapnhatngay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatngay.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một ngày để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value

        frm.ID_Ngay = Ngay.Day.ToString()
        frm.ID_Thang = Ngay.Month.ToString()
        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 5
        frm.ShowDialog()
        'Me.methodLoad()
    End Sub


    Private Sub btCapnhatTuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatTuan.Click
        If Me.chStateTuan = False Then
            MessageBox.Show("Bạn phải chọn một tuần của năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbTuan.Checked = True
            Me.txtTuan.Focus()
            Exit Sub
        Else
            If Me.txtTuan.Text = "" Or Me.txtNam.Text = "" Then
                MessageBox.Show("Bạn phải chọn một tuần của năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbTuan.Checked = True
                Me.txtTuan.Focus()
                Exit Sub
            End If
        End If

        Dim frm As New frmWaiting
        frm.ID_Tuan = Me.txtTuan.Value
        frm.ID_Nam = Me.txtNam.Value
        frm.Bang = 6

        frm.ShowDialog()
        'Me.methodLoad()
    End Sub

    Private Sub btCapnhatthang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatthang.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một tháng để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value

        frm.ID_Thang = Ngay.Month.ToString()
        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 7

        frm.ShowDialog()
        'Me.methodLoad()
    End Sub

    Private Sub btCapnhatnam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatnam.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value

        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 8

        frm.ShowDialog()
        'Me.methodLoad()
    End Sub


  
    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btXemBCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBCao.Activate
        Dim report As New FrmReport
        'Ma so report
        report.reportID = Me.ReportID

        If KiemTraThamSo() = 1 Then
            Exit Sub
        End If
        'Truyen tham so cho report 
        Dim strArray As String()

        If Me.rdCTNgay.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi}
        End If
        'Tuan------------------------------
        If Me.rdCTTuan.Checked = True Then
            strArray = New String() {Me.txtTuan.Text, Me.txtNam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateTuan, Me.chStateXuong, Me.chStateDonvi}
        End If
        'Thang------------------------------
        If Me.rdCTThang.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi}
        End If
        'Nam------------------------------
        If Me.rdCTNam.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi}
        End If

        report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    
   
    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        Me.methodLoad()
    End Sub
End Class