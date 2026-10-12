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
Imports System.DBNull
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Public Class frmCongViecNNDH
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBCongViecNNDH
        Me.Path = "/layout/CongViecNNDH.xml"
        obj.ChonBang = 14
        obj.DonVi = Me.cboNam.Value
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub

    Friend WithEvents b As clsBCongViecNNDH
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim Path As String
    Dim obj As New objCongViecNNDH
    Dim Tabletemp As DataTable
    Public Sub LuuDuLieu()
        Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
        Dim i As Integer = 0
        dgrBC.PerformAction(ExitEditMode, False, False)
        'I. Vòng lập duyệt từng nhân viên==========================
        While (i <= num2)
            'MessageBox.Show(Me.dgrBC.Rows.Item(i).Cells.Item("THANG1").Value)
            Dim THANG1 As String
            Dim THANG2 As String
            Dim THANG3 As String
            Dim THANG4 As String
            Dim THANG5 As String
            Dim THANG6 As String
            Dim THANG7 As String
            Dim THANG8 As String
            Dim THANG9 As String
            Dim THANG10 As String
            Dim THANG11 As String
            Dim THANG12 As String

            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim MA As String = StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value)
            Dim NAM As String = StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("NAM").Value)
            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG1").Value) = True Then
                THANG1 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG1").Value) = Nothing Then
                THANG1 = 0
            Else
                THANG1 = 0
            End If
            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG2").Value) = True Then
                THANG2 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG2").Value) = Nothing Then
                THANG2 = 0
            Else
                THANG2 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG3").Value) = True Then
                THANG3 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG3").Value) = Nothing Then
                THANG3 = 0
            Else
                THANG3 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG4").Value) = True Then
                THANG4 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG4").Value) = Nothing Then
                THANG4 = 0
            Else
                THANG4 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG5").Value) = True Then
                THANG5 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG5").Value) = Nothing Then
                THANG5 = 0
            Else
                THANG5 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG6").Value) = True Then
                THANG6 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG6").Value) = Nothing Then
                THANG6 = 0
            Else
                THANG6 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG7").Value) = True Then
                THANG7 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG7").Value) = Nothing Then
                THANG7 = 0
            Else
                THANG7 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG8").Value) = True Then
                THANG8 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG8").Value) = Nothing Then
                THANG8 = 0
            Else
                THANG8 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG9").Value) = True Then
                THANG9 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG9").Value) = Nothing Then
                THANG9 = 0
            Else
                THANG9 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG10").Value) = True Then
                THANG10 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG10").Value) = Nothing Then
                THANG10 = 0
            Else
                THANG10 = 0
            End If
            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG11").Value) = True Then
                THANG11 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG11").Value) = Nothing Then
                THANG11 = 0
            Else
                THANG11 = 0
            End If

            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG12").Value) = True Then
                THANG12 = 1
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("THANG12").Value) = Nothing Then
                THANG12 = 0
            Else
                THANG12 = 0
            End If
            Dim bFLAG As Boolean
            If StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("FLAG").Value) = False Then
                bFLAG = False
            ElseIf StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("FLAG").Value) = Nothing Then
                bFLAG = False
            Else
                bFLAG = StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("FLAG").Value)
            End If

            If bFLAG = True Then
                ' TA LUU DU LIEU
                ' KIEM TRA TRONG BANG IT_CONGVIECPTTT: bang nay luu du lieu cvnndh tung thang
                Dim TEMP As DataTable
                TEMP = Nothing
                obj.ChonBang = 15
                obj.MaNV = MA
                Me.b = New clsBCongViecNNDH
                TEMP = Me.b.LoadDS(obj)
                If TEMP.Rows.Count > 0 Then
                    obj.Setnull()
                    obj.setvalue(MA, NAM, THANG1, THANG2, THANG3, THANG4, THANG5, THANG6, THANG7, THANG8, THANG9, THANG10, THANG11, THANG12, 0)

                    obj.ChonBang = 0
                    Me.b = New clsBCongViecNNDH
                    Me.b.UpdateInfo(obj)
                Else
                    obj.Setnull()
                    obj.setvalue(MA, NAM, THANG1, THANG2, THANG3, THANG4, THANG5, THANG6, THANG7, THANG8, THANG9, THANG10, THANG11, THANG12, 0)

                    obj.ChonBang = 0
                    Me.b = New clsBCongViecNNDH
                    Me.b.InsertInfo(obj)
                End If
            Else
                obj.Setnull()
                obj.setvalue(MA, NAM, THANG1, THANG2, THANG3, THANG4, THANG5, THANG6, THANG7, THANG8, THANG9, THANG10, THANG11, THANG12, 0)

                obj.ChonBang = 0
                Me.b = New clsBCongViecNNDH
                Me.b.UpdateInfo(obj)
            End If
            i = i + 1
        End While
        MessageBox.Show("Đã Lưu Dữ Liệu")
    End Sub

    Private Sub cboDonVi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.methodLoad()
    End Sub

    Private Sub btChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim b As New clsBCongViecNNDH
        Dim obj As New objCongViecNNDH
        If Me.cbThang.Text = "Tháng 1" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG1").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG1").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 2" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG2").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG2").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 3" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG3").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG3").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 4" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG4").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG4").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 5" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG5").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG5").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 6" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG6").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG6").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 7" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG7").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG7").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 8" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG8").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG8").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 9" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG9").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG9").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 10" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG10").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG10").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 11" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG11").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG11").Value = -1
                End If
                i += 1
            End While
        End If
        If Me.cbThang.Text = "Tháng 12" Then
            dgrBC.PerformAction(ExitEditMode, False, False)
            Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
            Dim i As Integer = 0
            While (i <= num2)
                If Me.dgrBC.Rows.Item(i).Cells.Item("THANG12").Value <> -1 Then
                    Me.dgrBC.Rows.Item(i).Cells.Item("THANG12").Value = -1
                End If
                i += 1
            End While
        End If
    End Sub
    Private Sub Hienthithang(ByVal sNam As Integer)
        Dim i As Integer
        For i = 1 To 12
            If i < 10 Then
                Me.cbThang.Items.Add("0" & i.ToString() & "-" & sNam.ToString())
            Else
                Me.cbThang.Items.Add(i.ToString() & "-" & sNam.ToString())
            End If
        Next
    End Sub

    Private Sub frmCongViecNNDH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objCongViecNNDH
        obj.ChonBang = 13
        Me.b = New clsBCongViecNNDH
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cboNam.DataSource = Me.Tabletemp
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cboNam.DataSource = Me.Tabletemp
        Me.cboNam.DisplayMember() = "TEN_DV"
        Me.cboNam.ValueMember() = "DV_MA"
        Me.cboNam.SelectedIndex = 0
        Me.btChon.Enabled = False
        Me.btHuy.Enabled = False
        ''============= load thang theo năm 
        Me.cboNam.Items.Clear()
        cboNam.Items.Add("2013")
        cboNam.Items.Add("2012")
        cboNam.Items.Add("2011")
    End Sub

    Private Sub cbThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Not Me.cbThang.Value Is Nothing Then
        '    Me.btChon.Enabled = True
        '    Me.btHuy.Enabled = True
        'Else
        '    MessageBox.Show("Vui lòng chọn năm.", "Thông báo", MessageBoxButtons.OK)
        '    Me.btChon.Enabled = False
        '    Me.btHuy.Enabled = False
        'End If

    End Sub
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        With dgrBC.DisplayLayout
            Dim i As Integer
            For i = 0 To 2
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            Next i
        End With
    End Sub

    Private Sub btLayDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLayDuLieu.Click
        ''================ kiem tra trang thai Flag duoc phep cap nhat ===================''

    End Sub

    Private Sub cboNam_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNam.ValueChanged
        If Not Me.cboNam.Value Is Nothing Then
            Hienthithang(Convert.ToInt32(Me.cboNam.Value))
        End If
    End Sub
    Private Sub tabCVNNDH_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabCVNNDH.SelectedTabChanged
        Select Case Me.tabCVNNDH.SelectedTab.Index
            Case 0
                Me.btLuu.Visible = True
            Case 1
                Me.btLuu.Visible = False
        End Select

    End Sub
End Class