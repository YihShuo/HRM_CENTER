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
Public Class frmCapNhatKhamChuaBenh
    Dim TableTemp As DataTable
    Friend WithEvents b As clsBCapNhatKhamChuaBenh
    Dim oldRow As Integer = 0
    Public bLoad As Boolean = False
    Public Shared objnhom As New objCapNhatKhamChuaBenh
    Public fWaiting As frmWaiting_KCB

    Private Sub frmCapNhatKhamChuaBenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objCapNhatKhamChuaBenh

        obj.ChonBang = 1
        Me.b = New clsBCapNhatKhamChuaBenh
        Me.TableTemp = Me.b.LoadDS(obj)
        Me.cbNoiDKKCB.DataSource = Me.TableTemp
        Me.cbNoiDKKCB.DisplayMember = "TEN_KCB"
        Me.cbNoiDKKCB.SelectedIndex = 0


        obj.ChonBang = 2
        Me.b = New clsBCapNhatKhamChuaBenh
        Me.TableTemp = Me.b.LoadDS(obj)
        Me.TableTemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.TableTemp
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.SelectedIndex = 0
        bLoad = True
        Me.radTCT.Checked = True
        'Tim()
    End Sub

    Private Sub lnkDKKCB_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDKKCB.LinkClicked
        Dim frm As New frmNoiDK
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub Tim()
        Me.Tabletemp = Nothing
        Dim obj As New objCapNhatKhamChuaBenh

        If radKhuA.Checked Then
            obj.ChonKhu = "A"
        End If
        If radKhuB.Checked Then
            obj.ChonKhu = "B"
        End If
        If radKhuDVC.Checked Then
            obj.ChonKhu = "DVC"
        End If
        If radTCT.Checked Then
            obj.ChonKhu = "TCT"
        End If

        Select Case Me.cbDonvi.Value
            Case "KHUA", "KHUB", "KHUDVC", "TCT"
                fWaiting = frmWaiting_KCB.ShowProgress(Me)
            Case Else
        End Select

        If radDonvi.Checked Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                'Load danh sách nhân viên theo đơn vị
                obj.ChonBang = 8
                obj.MaDV = Me.cbDonvi.Value.ToString()
                
                Me.TableTemp = Me.b.LoadDS(obj)
                Locdulieu(Me.TableTemp)
            End If
        End If

        If radNgayvao.Checked Then
            obj.ChonBang = 9
            Dim Ngay As Date
            Ngay = dtpNgayvao.Value
            Dim sNgay As String
            sNgay = Ngay.Year.ToString + "-" + Ngay.Month.ToString + "-" + Ngay.Day.ToString
            obj.NGAY = sNgay

            Me.TableTemp = Me.b.LoadDS(obj)
            Locdulieu(Me.TableTemp)
        End If

        Select Case Me.cbDonvi.Value
            Case "KHUA", "KHUB", "KHUDVC", "TCT"
                fWaiting.CloseProgress()
                Me.cbDonvi.DroppedDown = False
            Case Else
        End Select
    End Sub

    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/CapNhatKhamChuaBenh.xml"), typeControl.Grid, "coldgrcongviec")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            If TableDS.Rows.Count < oldRow Then
                Exit Sub
            Else
                Me.dgrBC.Rows(oldRow).Activated = True
            End If
        End If
        Dim i As Integer
        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            'Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).Header.Appearance.ForeColor = Color.Blue
            'Me.dgrBC.DisplayLayout.Override.RowSizing = RowSizing.Free
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'auto canh chỉnh độ rộng các cột trên lưới
            'Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            'Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Next
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        If bLoad Then
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub

    Private Sub dtpNgayvao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgayvao.ValueChanged
        If bLoad Then
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub

    'Private Sub cbNoiDKKCB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNoiDKKCB.ValueChanged
    '    If bLoad Then
    '        Me.oldRow = 0
    '        Me.Tim()
    '    End If
    'End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        If bLoad Then
            Dim obj As New objCapNhatKhamChuaBenh
            Me.b = New clsBCapNhatKhamChuaBenh
            oldRow = 0
            TableTemp = Nothing
            If Me.radKhuA.Checked Then
                obj.ChonBang = 5
                Me.TableTemp = Me.b.LoadDS(obj)
                Me.TableTemp.Rows.Add("KHUA", "Toàn bộ khu A")
                Me.cbDonvi.DataSource = Me.TableTemp

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
            Dim obj As New objCapNhatKhamChuaBenh
            Me.b = New clsBCapNhatKhamChuaBenh
            oldRow = 0
            TableTemp = Nothing
            If Me.radKhuB.Checked Then
                obj.ChonBang = 6
                Me.TableTemp = Me.b.LoadDS(obj)

                Me.TableTemp.Rows.Add("KHUB", "Toàn bộ khu B")
                Me.cbDonvi.DataSource = Me.TableTemp
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
            Dim obj As New objCapNhatKhamChuaBenh
            Me.b = New clsBCapNhatKhamChuaBenh
            oldRow = 0
            TableTemp = Nothing
            If Me.radKhuDVC.Checked Then
                obj.ChonBang = 7
                Me.TableTemp = Me.b.LoadDS(obj)
                Me.TableTemp.Rows.Add("KHUDVC", "Toàn bộ khu DVC")
                Me.cbDonvi.DataSource = Me.TableTemp
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
            Dim obj As New objCapNhatKhamChuaBenh
            Me.b = New clsBCapNhatKhamChuaBenh
            oldRow = 0
            TableTemp = Nothing
            If Me.radTCT.Checked Then
                obj.ChonBang = 2
                Me.TableTemp = Me.b.LoadDS(obj)
                Me.TableTemp.Rows.Add("TCT", "全部公司Toàn công ty")
                Me.cbDonvi.DataSource = Me.TableTemp
                Me.cbDonvi.SelectedIndex = 1
                Me.Tim()
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.cbDonvi.SelectedIndex = Nothing
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

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 8
            If (i <> 2) Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
    End Sub

    'Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
    '    e.Row.Cells("STT").Value = e.Row.Index + 1
    '    e.Row.Update()
    'End Sub

    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
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

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            If MessageBox.Show("Bạn có muốn nhập nhóm nhân viên được chọn với nơi đăng ký khám chữa bệnh " + Me.cbNoiDKKCB.Value + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Me.dgrBC.UpdateData()
                objnhom.setnull()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(2).Value = True Then
                        objnhom.MaNV = Me.dgrBC.Rows(i).Cells("NV_Ma").Text
                        objnhom.MaKCB = Me.cbNoiDKKCB.Value
                        objnhom.ChonBang = 1

                        Dim ngaycn As DateTime = Now()
                        objnhom.NguoiCapNhat = MAIN.userclient
                        objnhom.NgayCapNhat = ngaycn.Year.ToString + "/" + ngaycn.Month.ToString + "/" + ngaycn.Day.ToString + " " + ngaycn.Hour.ToString + ":" + ngaycn.Minute.ToString + ":" + ngaycn.Second.ToString

                        Me.b.InsertInfo(objnhom)
                        Me.b.UpdateInfo(objnhom)
                    End If
                    i = i + 1
                End While
                Me.Tim()
                Me.ChonDongCu()
                MessageBox.Show("Cập nhật thành công")
            End If
        End If
    End Sub

    Private Sub lbToanBo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanBo.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            If MessageBox.Show("Bạn có muốn nhập nhóm nhân viên được chọn với nơi đăng ký khám chữa bệnh " + Me.cbNoiDKKCB.Value + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Me.dgrBC.UpdateData()
                objnhom.setnull()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objnhom.MaNV = Me.dgrBC.Rows(i).Cells("NV_Ma").Text
                    objnhom.MaKCB = Me.cbNoiDKKCB.Value
                    objnhom.ChonBang = 1

                    Dim ngaycn As DateTime = Now()
                    objnhom.NguoiCapNhat = MAIN.userclient
                    objnhom.NgayCapNhat = ngaycn.Year.ToString + "/" + ngaycn.Month.ToString + "/" + ngaycn.Day.ToString + " " + ngaycn.Hour.ToString + ":" + ngaycn.Minute.ToString + ":" + ngaycn.Second.ToString

                    Me.b.InsertInfo(objnhom)
                    Me.b.UpdateInfo(objnhom)
                    i = i + 1
                End While
                Me.Tim()
                Me.ChonDongCu()
                MessageBox.Show("Cập nhật thành công")
            End If
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

                        If MessageBox.Show("Bạn có muốn nhập nơi đăng ký khám chữa bệnh " + Me.cbNoiDKKCB.Value + " cho số thẻ  " + activeCell.Row.Cells.Item("NV_Ma").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                            objnhom.setnull()
                            objnhom.MaNV = activeCell.Row.Cells.Item("NV_Ma").Text
                            objnhom.MaKCB = Me.cbNoiDKKCB.Value
                            objnhom.ChonBang = 1

                            Dim ngaycn As DateTime = Now()
                            objnhom.NguoiCapNhat = MAIN.userclient
                            objnhom.NgayCapNhat = ngaycn.Year.ToString + "/" + ngaycn.Month.ToString + "/" + ngaycn.Day.ToString + " " + ngaycn.Hour.ToString + ":" + ngaycn.Minute.ToString + ":" + ngaycn.Second.ToString

                            Me.b.InsertInfo(objnhom)
                            Me.b.UpdateInfo(objnhom)
                            Me.Tim()
                            Me.ChonDongCu()
                            MessageBox.Show("Cập nhật thành công")
                        End If
                    End If
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_Ma").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        objnhom.setnull()
                        objnhom.MaNV = activeCell.Row.Cells.Item("NV_Ma").Text
                        objnhom.ChonBang = 1
                        Me.b.DeleteInfo(objnhom)
                        Me.Tim()
                        Me.ChonDongCu()
                        MessageBox.Show("Đã xóa thành công")
                    End If
            End Select
        End If
    End Sub

    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        If radDonvi.Checked Then
            cbDonvi.Enabled = True
            dtpNgayvao.Enabled = False
            Me.Tim()
        Else
            cbDonvi.Enabled = False
            dtpNgayvao.Enabled = True
            Me.Tim()
        End If
    End Sub

 
    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Dim i As Integer
        If Me.chkall.Checked Then
            While i <= Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells(2).Value = True
                i = i + 1
            End While
        Else
            While i <= Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells(2).Value = False
                i = i + 1
            End While
        End If
    End Sub
End Class