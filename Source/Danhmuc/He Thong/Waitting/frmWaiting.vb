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
Imports System.Timers




Public Class frmWaiting
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmWaiting_Load)
        Me.InitializeComponent()
    End Sub

    Private Sub frmWaiting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Bang = 4 Then
            Me.Percentcomplete.Visible = False
            Me.PictureBox1.Visible = True
        Else
            Me.PictureBox1.Visible = False
        End If

        Me.Timer1.Start()
    End Sub

    'Cap Nhat Gio Cong Tang Ca Toan Cong Ty Nam 2009 Tay-------------------------------
    Private Sub CapNhatGioCongToanCongTy()
        Me.Percentcomplete.Value = 0
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting

        'Xoa du lieu cu
        obj.ChonBang = 3
        obj.ID = Me.ID_DonVi
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach cap nhat
        obj.ChonBang = 1
        obj.ID = Me.ID_DonVi
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen du lieu moi
        Dim i As Integer = 0
        While i <= RowCount
            listpar.Add(New SqlParameter("@X_MA_", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NV_TEN", TableNVXuong.Rows(i).Item("HOTEN")))
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b.GoiThuTuc("JELL_SP_GIOTANGCA_THANG_MOTNAM", listpar)
            listpar.Clear()

            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap Nhat Gio Cong Tang Ca Toan Cong Ty Nam 2009 Tay-------------------------------
    Private Sub CapNhatGioCongToanCongTyTay()
        Me.Percentcomplete.Value = 0
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting

        'Xoa du lieu cu
        obj.ChonBang = 33
        obj.ID = Me.ID_DonVi
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach cap nhat
        obj.ChonBang = 1
        obj.ID = Me.ID_DonVi
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen du lieu moi
        Dim i As Integer = 0
        While i <= RowCount
            listpar.Add(New SqlParameter("@X_MA_", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NV_TEN", TableNVXuong.Rows(i).Item("HOTEN")))
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b.GoiThuTuc("JELL_SP_GIOTANGCA_THANG_MOTNAM_TAY", listpar)
            listpar.Clear()

            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap Nhat Weekly Overtimes Hours -------------------------------
    Private Sub CapNhatWeeklyOvertimes()
        Me.Percentcomplete.Value = 0
        Dim listpar As New ArrayList(5)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting


        'Xoa du lieu cu trong bang
        obj.Setnull()
        obj.ChonBang = 4
        obj.Nam = Me.ID_Nam
        obj.Thang = Me.ID_Thang
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach nhan vien duoc dua vao bang
        obj.Setnull()
        obj.ChonBang = 8
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen du lieu moi vao bang
        Dim i As Integer = 0
        While i <= RowCount
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NV_TEN", TableNVXuong.Rows(i).Item("HOTEN")))
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            Application.DoEvents()
            Me.b.GoiThuTuc("JELL_SP_GIOCONGTUAN_TRONGTHANG", listpar)
            listpar.Clear()

            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Tai du lieu vao bang goc -------------------------------
    Private Sub LoadData()
        Me.Percentcomplete.Value = 0
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa Bang Goc Ngay 
        obj.ChonBang = 2
        obj.NamThangNgay = ID_NamThangNgay
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Ngay cap nhat=========================
        'Dim Ngaytaidl As Date
        'Ngaytaidl = ID_NamThangNgay
        Me.lbNgay.Text = "Đang tải dữ liệu ngày: " & obj.NamThangNgay

        'Danh sach can cap nhat
        obj.ChonBang = 1
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang Goc
        Dim i As Integer = 0
        While i <= RowCount
            listpar.Add(New SqlParameter("@NTN", Me.ID_NamThangNgay))
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NV_TEN", TableNVXuong.Rows(i).Item("HOTEN")))
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            Application.DoEvents()
            Me.b.GoiThuTuc("JELL_SP_GIOCONGTANGCA_NGAY_TOANCONGTY", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat gio cong khac thuong tuan
    Private Sub CapNhatGioCongKhacThuongTuan()
        Dim listpar As New ArrayList(2)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu o tuan id_tuan va nam is_nam 
        obj.ChonBang = 5
        obj.Nam = Me.ID_Nam
        obj.Tuan = Me.ID_Tuan
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        ' ''Danh sach can cap nhat
        ''obj.ChonBang = 25
        ''Me.b = New clsBWaiting
        ''TableNVXuong = Me.b.LoadDS(obj)

        ''Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        ' ''MessageBox.Show(RowCount)

        ' ''Chen Du Lieu Vao Bang Goc
        ''Dim i As Integer = 0
        ''While i <= RowCount
        'listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
        'listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
        ''listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
        'Application.DoEvents()
        'Me.b.GoiThuTuc("JELL_SP_CAPNHATKHACTHUONGTUAN", listpar)

        'listpar.Clear()
        ''Me.Percentcomplete.Value = (100 * i) / RowCount
        ''Me.Percentcomplete.Update()
        ''i = i + 1
        ''End While
        ''Cap nhat vao bang
        listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
        listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
        Application.DoEvents()
        Me.b.GoiThuTuc("JELL_SP_CAPNHATKHACTHUONGTUAN", listpar)
   
    End Sub

    'Cap nhat chi tiet gio cong ngay
    Private Sub CapNhatChiTietGioCongNgay()
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 6
        obj.Ngay = Me.ID_Ngay
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)


        'Danh sach can cap nhat
        obj.ChonBang = 8
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NGAY", Me.ID_Ngay))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATCHITIETGIOCONG_NGAY", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While

    End Sub

    'Cap nhat chi tiet gio cong TUAN
    Private Sub CapNhatChiTietGioCongTuan()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 7
        obj.Tuan = Me.ID_Tuan
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 8
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATCHITIETGIOCONG_TUAN", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap nhat chi tiet gio cong THANG
    Private Sub CapNhatChiTietGioCongThang()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 9
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 8
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATCHITIETGIOCONG_THANG", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat chi tiet gio cong Nam
    Private Sub CapNhatChiTietGioCongNam()
        Dim listpar As New ArrayList(2)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 10
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 8
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@NV_MA", TableNVXuong.Rows(i).Item("MASO")))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATCHITIETGIOCONG_NAM", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat gio cong theo Donvi Ngay
    Private Sub CapNhatGioCongTheoDonVi_Ngay()
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 11
        obj.Ngay = Me.ID_Ngay
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 12
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@NGAY", Me.ID_Ngay))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEO_DV_NGAY", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap nhat gio cong theo Donvi Thang
    Private Sub CapNhatGioCongTheoDonVi_Thang()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 18
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach don vi can cap nhat
        obj.ChonBang = 12
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEO_DV_THANG", listpar)
            listpar.Clear()

            'Hien thi thanh trang thai
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap nhat gio cong theo Donvi Nam
    Private Sub CapNhatGioCongTheoDonVi_Nam()
        Dim listpar As New ArrayList(2)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 19
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach don vi can cap nhat
        obj.ChonBang = 12
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEO_DV_NAM", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap nhat gio cong theo Donvi Tuan
    Private Sub CapNhatGioCongTheoDonVi_Tuan()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 20
        obj.Tuan = Me.ID_Tuan
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach don vi can cap nhat
        obj.ChonBang = 12
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@DV_MA", TableNVXuong.Rows(i).Item("DONVI")))
            listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEO_DV_TUAN", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat gio cong theo xuong_ngay
    Private Sub CapNhatGioCongTheoXuong_Ngay()
        Dim listpar As New ArrayList(4)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 13
        obj.Ngay = Me.ID_Ngay
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 14
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@NGAY", Me.ID_Ngay))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEOXUONG_NGAY", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat gio cong theo xuong_tuan
    Private Sub CapNhatGioCongTheoXuong_Tuan()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 15
        obj.Tuan = Me.ID_Tuan
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 14
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEOXUONG_TUAN", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub


    'Cap nhat gio cong theo xuong_thang
    Private Sub CapNhatGioCongTheoXuong_Thang()
        Dim listpar As New ArrayList(3)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 16
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 14
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEOXUONG_THANG", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    'Cap nhat gio cong theo xuong_Nam
    Private Sub CapNhatGioCongTheoXuong_Nam()
        Dim listpar As New ArrayList(2)

        Dim TableNVXuong As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.Setnull()
        obj.ChonBang = 17
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 14
        Me.b = New clsBWaiting
        TableNVXuong = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableNVXuong.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableNVXuong.Rows(i).Item("XUONG")))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("JELL_SP_CAPNHATGIOCONGTHEOXUONG_NAM", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    Private Sub CapNhatGioCongTieuChuanThang()

        Dim listpar As New ArrayList(2)

        Dim TableTHANG As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.ChonBang = 21
        obj.Nam = Me.ID_Nam
        obj.Thang = Me.ID_Thang
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 22
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        TableTHANG = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableTHANG.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            Dim MA As String = TableTHANG.Rows(i).Item("NV_MA").ToString()
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            listpar.Add(New SqlParameter("@MANV", MA))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("Q_SP_GCTCTHANG2", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub
   
    Private Sub BAOBIEUPTTKKHONGPHEPTUAN()
        Dim listpar As New ArrayList(2)
        Dim TableTUAN As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.ChonBang = 26
        obj.Nam = Me.ID_Nam
        obj.Tuan = Me.ID_Tuan
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 27
        obj.Tuan = Me.ID_Tuan
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        TableTUAN = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableTUAN.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableTUAN.Rows(i).Item("X_MA_")))
            listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("Q_SP_BAOBIEUPTTKKHONGPHEPCUACACDONVI_TUAN", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub
    'Cap nhat gio cong khac thuong tuan
    Private Sub CapNhatGioCongTieuChuanTuan()
        Dim listpar As New ArrayList(2)

        Dim TableTUAN As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.ChonBang = 23
        obj.Nam = Me.ID_Nam
        obj.Tuan = Me.ID_Tuan
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 24
        obj.Tuan = Me.ID_Tuan
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        TableTUAN = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableTUAN.Rows.Count - 1

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            Dim MA As String = TableTUAN.Rows(i).Item("NV_Ma").ToString()
            listpar.Add(New SqlParameter("@TUAN", Me.ID_Tuan))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            listpar.Add(New SqlParameter("@MANV", MA))
            Application.DoEvents()
            Me.b = New clsBWaiting
            ' GOI THU TUC
            Me.b.GoiThuTuc("Q_SP_GCTCTUAN2", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    Private Sub PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG_THANG()
        Dim listpar As New ArrayList(2)

        Dim TableTHANG As New DataTable
        Dim obj As New objWaiting
        obj.Setnull()

        'Xoa du lieu cu
        obj.ChonBang = 28
        obj.Nam = Me.ID_Nam
        obj.Thang = Me.ID_Thang
        Me.b = New clsBWaiting
        Me.b.LoadDS(obj)

        'Danh sach can cap nhat
        obj.ChonBang = 29
        obj.Thang = Me.ID_Thang
        obj.Nam = Me.ID_Nam
        Me.b = New clsBWaiting
        TableTHANG = Me.b.LoadDS(obj)

        Dim RowCount As Integer = TableTHANG.Rows.Count - 1
        'MessageBox.Show(RowCount)

        'Chen Du Lieu Vao Bang 
        Dim i As Integer = 0
        While i <= RowCount
            'Cap nhat vao bang
            listpar.Add(New SqlParameter("@XUONG", TableTHANG.Rows(i).Item("X_MA_")))
            listpar.Add(New SqlParameter("@THANG", Me.ID_Thang))
            listpar.Add(New SqlParameter("@NAM", Me.ID_Nam))
            Application.DoEvents()
            Me.b = New clsBWaiting
            Me.b.GoiThuTuc("Q_SP_PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG_THANG", listpar)

            listpar.Clear()
            Me.Percentcomplete.Value = (100 * i) / RowCount
            Me.Percentcomplete.Update()
            i = i + 1
        End While
    End Sub

    Public Bang As Integer
    Public flagUpdate As Boolean
    Friend WithEvents b As clsBWaiting

    'Cap Nhat Gio Cong Tang Ca Toan Cong Ty Nam 2009
    Public ID_DonVi As String
    Public ID_Nam As Integer
    Public NGAY As Date
    'Cap Nhat Weekly overtimes
    Public ID_Thang As Integer

    'Tai du lieu vao bang goc
    Public ID_NamThangNgay As String

    'Cap nhat gio cong khac thuong tuan
    Public ID_Tuan As Integer

    'Cap nhat gio cong ngay
    Public ID_Ngay As Integer


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Timer1.Stop()
        Select Case Bang
            Case 1 : Me.CapNhatGioCongToanCongTy()
            Case 2 : Me.CapNhatWeeklyOvertimes()
            Case 3 : Me.LoadData()
            Case 4 : Me.CapNhatGioCongKhacThuongTuan()
            Case 5 : Me.CapNhatChiTietGioCongNgay()
            Case 6 : Me.CapNhatChiTietGioCongTuan()
            Case 7 : Me.CapNhatChiTietGioCongThang()
            Case 8 : Me.CapNhatChiTietGioCongNam()
            Case 9 : Me.CapNhatGioCongTheoDonVi_Ngay()            
            Case 10 : Me.CapNhatGioCongTheoXuong_Ngay()
            Case 11 : Me.CapNhatGioCongTheoXuong_Tuan()
            Case 12 : Me.CapNhatGioCongTheoXuong_Thang()
            Case 13 : Me.CapNhatGioCongTheoXuong_Nam()
            Case 14 : Me.CapNhatGioCongTheoDonVi_Thang()
            Case 15 : Me.CapNhatGioCongTheoDonVi_Nam()
            Case 16 : Me.CapNhatGioCongTheoDonVi_Tuan()
            Case 17 : Me.CapNhatGioCongTieuChuanThang()
            Case 18 : Me.CapNhatGioCongTieuChuanTuan()
            Case 19 : Me.BAOBIEUPTTKKHONGPHEPTUAN()
            Case 20 : Me.PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG_THANG()
            Case 21 : Me.CapNhatGioCongToanCongTyTay()

        End Select
        Me.Close()
    End Sub

    Private Sub Percentcomplete_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Percentcomplete.ValueChanged

    End Sub
End Class




