Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Infragistics.Win.UltraWinToolbars

Public Class frmMain
    Friend WithEvents b As clsBMain
    Public tennguoidung As String
  
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)

        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                SetTrangThaiMo()
            Else
                SetTrangThaiDong()
                SetTrangThaiMoTheoQuyen()
            End If
        End If
    End Sub


    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub SetTrangThaiMo()

        btnChamCong.Enabled = True
        btndanhgiahieuquacongviec.Enabled = True
        btnKeToan.Enabled = True
        btnNhanSu.Enabled = True
        btnTuyenDung.Enabled = True
    End Sub
    Private Sub SetTrangThaiDong()

        btnChamCong.Enabled = False
        btndanhgiahieuquacongviec.Enabled = False
        btnKeToan.Enabled = False
        btnNhanSu.Enabled = False
        btnTuyenDung.Enabled = False
    End Sub
    Private Sub SetTrangThaiMoTheoQuyen()
        Dim obj As New objMain
        obj.ChonBang = 3
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        Dim table As DataTable
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        Dim i As Integer = 0

        While i < table.Rows.Count
            If table.Rows(i).Item(0).ToString() = "NHANSU" Then
                btnNhanSu.Enabled = True
            ElseIf table.Rows(i).Item(0).ToString() = "TINHLUONG" Then
                btnKeToan.Enabled = True
            ElseIf table.Rows(i).Item(0).ToString() = "CHAMCONG" Then
                btnChamCong.Enabled = True
            ElseIf table.Rows(i).Item(0).ToString() = "TUYENDUNG" Then
                btnTuyenDung.Enabled = True
            ElseIf table.Rows(i).Item(0).ToString() = "DANHGIA" Then
                btndanhgiahieuquacongviec.Enabled = True
            End If
            i = i + 1
        End While
    End Sub

    Private Sub btnNhanSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNhanSu.Click
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoMain(frm, "NHANSU")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Nhân Sự"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            Else
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoTheoQuyenMain(frm, "NHANSU")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Nhân Sự"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            End If
        End If
    End Sub
    Private Sub SetTrangThaiMoMain(ByRef frm As frmMainMain, ByVal NhomDM As String)
        Dim obj As New objMain
        obj.ChonBang = 22
        obj.NhomDM = NhomDM
        Dim table As DataTable
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        Dim i As Integer = 0
        On Error Resume Next

        While i < table.Rows.Count
            'Hien thi toolbar=======================

            frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Visible = True
            'Hien thi Explorebar====================
            Dim j As Integer = 0
            While j < frm.UltraExplorerBar1.Groups.Count
                Dim k As Integer = 0
                While k < frm.UltraExplorerBar1.Groups(j).Items.Count
                    If (StringType.StrCmp(frm.UltraExplorerBar1.Groups.Item(j).Items(k).Key.ToString(), table.Rows(i).Item(0).ToString(), False) = 0) Then
                        frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = True
                    End If
                    k = k + 1
                End While
                j = j + 1
            End While

            Dim CC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnChamCong")
            Dim iCC As Integer = 0
            While iCC < CC.Tools.Count
                If table.Rows(i).Item(0).ToString() = CC.Tools(iCC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnChamCong").SharedProps.Visible = True
                End If
                iCC = iCC + 1
            End While
            Dim NS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnNhanSu")
            Dim iNS As Integer = 0
            While iNS < NS.Tools.Count

                If table.Rows(i).Item(0).ToString() = NS.Tools(iNS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnNhanSu").SharedProps.Visible = True
                End If
                iNS = iNS + 1
            End While
            Dim BC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocao")
            Dim iBC As Integer = 0
            While iBC < BC.Tools.Count

                If table.Rows(i).Item(0).ToString() = BC.Tools(iBC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                'If BC.Tools(iBC).Key.ToString() = "mnBaocaochamcong" Then
                '    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                'End If
                iBC = iBC + 1
            End While
            Dim DM As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnDanhmuc")
            Dim iDM As Integer = 0
            While iDM < DM.Tools.Count
                If table.Rows(i).Item(0).ToString() = DM.Tools(iDM).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnDanhmuc").SharedProps.Visible = True
                End If
                iDM = iDM + 1
            End While
            Dim TL As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnTinhluong")
            Dim iTL As Integer = 0
            While iTL < TL.Tools.Count

                If table.Rows(i).Item(0).ToString() = TL.Tools(iTL).Key.ToString() Then

                    frm.UltraToolbarsManager1.Tools("mnTinhluong").SharedProps.Visible = True
                End If
                iTL = iTL + 1
            End While

            Dim TKTS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeThaiSan")
            Dim iTKTS As Integer = 0
            While iTKTS < TKTS.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKTS.Tools(iTKTS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeThaiSan").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKTS = iTKTS + 1
            End While
            Dim BB As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBinhbau")
            Dim iBB As Integer = 0
            While iBB < BB.Tools.Count

                If table.Rows(i).Item(0).ToString() = BB.Tools(iBB).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBinhbau").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnNhanSu").SharedProps.Visible = True
                End If
                iBB = iBB + 1
            End While

            Dim BCTH As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaoCaoTongHop")
            Dim iBCTH As Integer = 0
            While iBCTH < BCTH.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCTH.Tools(iBCTH).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaoCaoTongHop").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCTH = iBCTH + 1
            End While


            Dim BCHD As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnTongHopBaoCaoHDLD")
            Dim iBCHD As Integer = 0
            While iBCHD < BCHD.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCHD.Tools(iBCHD).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnTongHopBaoCaoHDLD").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCHD = iBCHD + 1
            End While


            Dim BCNS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocaonhansu")
            Dim iBCNS As Integer = 0
            While iBCNS < BCNS.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCNS.Tools(iBCNS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocaonhansu").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCNS = iBCNS + 1
            End While

            Dim BCCC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocaochamcong")
            Dim iBCCC As Integer = 0
            While iBCCC < BCCC.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCCC.Tools(iBCCC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCCC = iBCCC + 1
            End While
            Dim TKGC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongkegiocong")
            Dim iTKGC As Integer = 0
            While iTKGC < TKGC.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGC.Tools(iTKGC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongkegiocong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGC = iTKGC + 1
            End While

            Dim TKGCTC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeGioCongTieuChuan")
            Dim iTKGCTC As Integer = 0
            While iTKGCTC < TKGCTC.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGCTC.Tools(iTKGCTC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeGioCongTieuChuan").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGCTC = iTKGCTC + 1
            End While
            Dim TKGCCT As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeGioCongChiTiet")
            Dim iTKGCCT As Integer = 0
            While iTKGCCT < TKGCCT.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGCCT.Tools(iTKGCCT).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeGioCongChiTiet").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGCCT = iTKGCCT + 1
            End While

           

            i = i + 1
        End While
        


    End Sub

    Private Sub SetTrangThaiKhoaMain(ByRef frm As frmMainMain)
        Dim obj As New objMain
        obj.ChonBang = 2
        Dim table As DataTable
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        'Hien thi toolbar=======================
        frm.UltraToolbarsManager1.Tools("mnChamCong").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnNhanSu").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnDanhmuc").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnTinhluong").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnThongKeThaiSan").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnBinhbau").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnTongHopBaoCaoHDLD").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnBaoCaoTongHop").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnBaocaonhansu").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnThongkegiocong").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnThongKeGioCongTieuChuan").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnThongKeGioCongChiTiet").SharedProps.Visible = False
        frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = False

        Dim i As Integer = 0
        While i < table.Rows.Count
            On Error Resume Next
            frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Visible = False
            i = i + 1
        End While
        'Hien thi Explorebar====================
        Dim j As Integer = 0
        While j < frm.UltraExplorerBar1.Groups.Count
            Dim k As Integer = 0
            While k < frm.UltraExplorerBar1.Groups(j).Items.Count
                frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = False
                k = k + 1
            End While
            j = j + 1
        End While
        frm.UltraExplorerBar1.Groups.Item("mnHethong").Items("1mnThoat").Visible = True
    End Sub

    Private Sub SetTrangThaiMoTheoQuyenMain(ByRef frm As frmMainMain, ByVal NhomDM As String)
        Dim obj As New objMain
        obj.ChonBang = 33
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.NhomDM = NhomDM
        Dim table As DataTable
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        Dim i As Integer = 0
        On Error Resume Next

        While i < table.Rows.Count
            'Hien thi toolbar=======================
            frm.UltraToolbarsManager1.Tools(table.Rows(i).Item(0).ToString()).SharedProps.Visible = True
            'Hien thi Explorebar====================
            Dim j As Integer = 0
            While j < frm.UltraExplorerBar1.Groups.Count
                Dim k As Integer = 0
                While k < frm.UltraExplorerBar1.Groups(j).Items.Count
                    If (StringType.StrCmp(frm.UltraExplorerBar1.Groups.Item(j).Items(k).Key.ToString(), table.Rows(i).Item(0).ToString(), False) = 0) Then
                        frm.UltraExplorerBar1.Groups.Item(j).Items(k).Visible = True
                    End If
                    k = k + 1
                End While
                j = j + 1
            End While

            Dim CC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnChamCong")
            Dim iCC As Integer = 0
            While iCC < CC.Tools.Count
                If table.Rows(i).Item(0).ToString() = CC.Tools(iCC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnChamCong").SharedProps.Visible = True
                End If
                iCC = iCC + 1
            End While
            Dim NS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnNhanSu")
            Dim iNS As Integer = 0
            While iNS < NS.Tools.Count

                If table.Rows(i).Item(0).ToString() = NS.Tools(iNS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnNhanSu").SharedProps.Visible = True
                End If
                iNS = iNS + 1
            End While
            Dim BC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocao")
            Dim iBC As Integer = 0
            While iBC < BC.Tools.Count

                If table.Rows(i).Item(0).ToString() = BC.Tools(iBC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                'If BC.Tools(iBC).Key.ToString() = "mnBaocaochamcong" Then
                '    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                'End If
                iBC = iBC + 1
            End While
            Dim DM As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnDanhmuc")
            Dim iDM As Integer = 0
            While iDM < DM.Tools.Count
                If table.Rows(i).Item(0).ToString() = DM.Tools(iDM).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnDanhmuc").SharedProps.Visible = True
                End If
                iDM = iDM + 1
            End While
            Dim TL As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnTinhluong")
            Dim iTL As Integer = 0
            While iTL < TL.Tools.Count

                If table.Rows(i).Item(0).ToString() = TL.Tools(iTL).Key.ToString() Then

                    frm.UltraToolbarsManager1.Tools("mnTinhluong").SharedProps.Visible = True
                End If
                iTL = iTL + 1
            End While

            Dim TKTS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeThaiSan")
            Dim iTKTS As Integer = 0
            While iTKTS < TKTS.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKTS.Tools(iTKTS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeThaiSan").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKTS = iTKTS + 1
            End While
            Dim BB As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBinhbau")
            Dim iBB As Integer = 0
            While iBB < BB.Tools.Count

                If table.Rows(i).Item(0).ToString() = BB.Tools(iBB).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBinhbau").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnNhanSu").SharedProps.Visible = True
                End If
                iBB = iBB + 1
            End While

            Dim BCTH As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaoCaoTongHop")
            Dim iBCTH As Integer = 0
            While iBCTH < BCTH.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCTH.Tools(iBCTH).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaoCaoTongHop").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCTH = iBCTH + 1
            End While

            Dim BCHD As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnTongHopBaoCaoHDLD")
            Dim iBCHD As Integer = 0
            While iBCHD < BCHD.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCHD.Tools(iBCHD).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnTongHopBaoCaoHDLD").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCHD = iBCHD + 1
            End While

            Dim BCNS As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocaonhansu")
            Dim iBCNS As Integer = 0
            While iBCNS < BCNS.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCNS.Tools(iBCNS).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocaonhansu").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCNS = iBCNS + 1
            End While

            Dim BCCC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnBaocaochamcong")
            Dim iBCCC As Integer = 0
            While iBCCC < BCCC.Tools.Count

                If table.Rows(i).Item(0).ToString() = BCCC.Tools(iBCCC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iBCCC = iBCCC + 1
            End While
            Dim TKGC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongkegiocong")
            Dim iTKGC As Integer = 0
            While iTKGC < TKGC.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGC.Tools(iTKGC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongkegiocong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGC = iTKGC + 1
            End While

            Dim TKGCTC As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeGioCongTieuChuan")
            Dim iTKGCTC As Integer = 0
            While iTKGCTC < TKGCTC.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGCTC.Tools(iTKGCTC).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeGioCongTieuChuan").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGCTC = iTKGCTC + 1
            End While
            Dim TKGCCT As PopupMenuTool = frm.UltraToolbarsManager1.Tools("mnThongKeGioCongChiTiet")
            Dim iTKGCCT As Integer = 0
            While iTKGCCT < TKGCCT.Tools.Count

                If table.Rows(i).Item(0).ToString() = TKGCCT.Tools(iTKGCCT).Key.ToString() Then
                    frm.UltraToolbarsManager1.Tools("mnThongKeGioCongChiTiet").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocaochamcong").SharedProps.Visible = True
                    frm.UltraToolbarsManager1.Tools("mnBaocao").SharedProps.Visible = True
                End If
                iTKGCCT = iTKGCCT + 1
            End While


            i = i + 1
        End While
    End Sub

    Private Sub btnKeToan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeToan.Click
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoMain(frm, "TINHLUONG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Tính Lương"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            Else
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoTheoQuyenMain(frm, "TINHLUONG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Tính Lương"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            End If
        End If
    End Sub

    Private Sub btnChamCong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChamCong.Click
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoMain(frm, "CHAMCONG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Chấm Công"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            Else
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoTheoQuyenMain(frm, "CHAMCONG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Chấm Công"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            End If
        End If
    End Sub






    Private Sub btnTuyenDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTuyenDung.Click
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoMain(frm, "TUYENDUNG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Tuyển Dụng"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            Else
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoTheoQuyenMain(frm, "TUYENDUNG")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Tuyển Dụng"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            End If
        End If
    End Sub

    Private Sub btndanhgiahieuquacongviec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndanhgiahieuquacongviec.Click
        Dim obj As New objMain
        obj.ChonBang = 1
        Dim table As DataTable
        obj.TenDangNhap = MAIN.userclient.ToLower().ToString()
        obj.MatKhau = MAIN.PassLogin.ToLower().ToString()
        Me.b = New clsBMain
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            If table.Rows(0).Item("Admin") = True Then
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoMain(frm, "DANHGIA")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Đánh Giá Hiệu Quả Công Việc"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            Else
                Dim frm As New frmMainMain
                Me.SetTrangThaiKhoaMain(frm)
                Me.SetTrangThaiMoTheoQuyenMain(frm, "DANHGIA")
                frm.stbUser.Text = "Người dùng: " & MAIN.userclient.ToLower().ToString()
                frm.Text = "Đánh Giá Hiệu Quả Công Việc"
                Me.tennguoidung = frm.stbUser.Text
                frm.Show()
                'Me.Hide()
            End If
        End If
    End Sub
End Class