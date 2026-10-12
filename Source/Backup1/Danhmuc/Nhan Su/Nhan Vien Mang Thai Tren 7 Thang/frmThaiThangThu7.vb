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

Public Class frmThaiThangThu7
    Inherits Form
    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThaiThangThu7))
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool1")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool1")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuThem")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSua")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuXoa")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuLuu")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuIn")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuThem")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSua")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuXoa")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuLuu")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuIn")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dtpDN = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtpNBD = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.chkTN = New System.Windows.Forms.CheckBox
        Me.chkDV = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbodonvixemluoi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.btE = New Infragistics.Win.Misc.UltraButton
        Me.btXemluoi = New Infragistics.Win.Misc.UltraButton
        Me.grbDieukienloc = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkDonViThai = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbDonViThai = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraDateTimeEditor2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraDateTimeEditor1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btXemToanCTy = New Infragistics.Win.Misc.UltraButton
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btXemTungDonVi = New Infragistics.Win.Misc.UltraButton
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkdvT = New System.Windows.Forms.CheckBox
        Me.dtpthangT = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btET = New Infragistics.Win.Misc.UltraButton
        Me.btXemluoiT = New Infragistics.Win.Misc.UltraButton
        Me.cbdvT = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnXoa = New TD.SandBar.ButtonItem
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.btSua = New TD.SandBar.ButtonItem
        Me.btnIn = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtpDenNgayThai = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtpNgaybatdau = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btHuyHet = New Infragistics.Win.Misc.UltraButton
        Me.btHuy = New Infragistics.Win.Misc.UltraButton
        Me.btChonHet = New Infragistics.Win.Misc.UltraButton
        Me.btChon = New Infragistics.Win.Misc.UltraButton
        Me.txtTongchon = New System.Windows.Forms.TextBox
        Me.txtTongkchon = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.clbNhanvienchon = New System.Windows.Forms.CheckedListBox
        Me.clbNhanvien = New System.Windows.Forms.CheckedListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btUncheckall = New Infragistics.Win.Misc.UltraButton
        Me.btCheckall = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btUncheckallnvc = New Infragistics.Win.Misc.UltraButton
        Me.btCheckallnvc = New Infragistics.Win.Misc.UltraButton
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.dtpDN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpNBD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbodonvixemluoi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDieukienloc.SuspendLayout()
        CType(Me.cbDonViThai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDateTimeEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDateTimeEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.dtpthangT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbdvT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.dtpDenNgayThai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpNgaybatdau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Controls.Add(Me.grbDieukienloc)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(802, 232)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.dtpDN)
        Me.UltraGroupBox2.Controls.Add(Me.dtpNBD)
        Me.UltraGroupBox2.Controls.Add(Me.chkTN)
        Me.UltraGroupBox2.Controls.Add(Me.chkDV)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.cbodonvixemluoi)
        Me.UltraGroupBox2.Controls.Add(Me.btE)
        Me.UltraGroupBox2.Controls.Add(Me.btXemluoi)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(314, 217)
        Me.UltraGroupBox2.TabIndex = 5
        Me.UltraGroupBox2.Text = "Xem Chi Tiết "
        '
        'dtpDN
        '
        Me.dtpDN.Location = New System.Drawing.Point(97, 59)
        Me.dtpDN.Name = "dtpDN"
        Me.dtpDN.Size = New System.Drawing.Size(182, 26)
        Me.dtpDN.TabIndex = 16
        '
        'dtpNBD
        '
        Me.dtpNBD.Location = New System.Drawing.Point(97, 22)
        Me.dtpNBD.Name = "dtpNBD"
        Me.dtpNBD.Size = New System.Drawing.Size(182, 26)
        Me.dtpNBD.TabIndex = 15
        '
        'chkTN
        '
        Me.chkTN.AutoSize = True
        Me.chkTN.Location = New System.Drawing.Point(7, 28)
        Me.chkTN.Name = "chkTN"
        Me.chkTN.Size = New System.Drawing.Size(91, 21)
        Me.chkTN.TabIndex = 20
        Me.chkTN.Text = "Từ Ngày :"
        Me.chkTN.UseVisualStyleBackColor = True
        '
        'chkDV
        '
        Me.chkDV.AutoSize = True
        Me.chkDV.Location = New System.Drawing.Point(6, 108)
        Me.chkDV.Name = "chkDV"
        Me.chkDV.Size = New System.Drawing.Size(80, 21)
        Me.chkDV.TabIndex = 19
        Me.chkDV.Text = "Đơn Vị :"
        Me.chkDV.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Đến Ngày :"
        '
        'cbodonvixemluoi
        '
        Me.cbodonvixemluoi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbodonvixemluoi.Location = New System.Drawing.Point(97, 105)
        Me.cbodonvixemluoi.Name = "cbodonvixemluoi"
        Me.cbodonvixemluoi.Size = New System.Drawing.Size(182, 26)
        Me.cbodonvixemluoi.TabIndex = 18
        '
        'btE
        '
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.ForeColor = System.Drawing.Color.Blue
        Me.btE.Appearance = Appearance2
        Me.btE.Location = New System.Drawing.Point(182, 155)
        Me.btE.Name = "btE"
        Me.btE.Size = New System.Drawing.Size(114, 30)
        Me.btE.TabIndex = 13
        Me.btE.Text = "Xuất Excel"
        '
        'btXemluoi
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Me.btXemluoi.Appearance = Appearance1
        Me.btXemluoi.Location = New System.Drawing.Point(24, 155)
        Me.btXemluoi.Name = "btXemluoi"
        Me.btXemluoi.Size = New System.Drawing.Size(141, 30)
        Me.btXemluoi.TabIndex = 14
        Me.btXemluoi.Text = "Xem Danh Sách"
        '
        'grbDieukienloc
        '
        Me.grbDieukienloc.Controls.Add(Me.chkDonViThai)
        Me.grbDieukienloc.Controls.Add(Me.cbDonViThai)
        Me.grbDieukienloc.Controls.Add(Me.UltraDateTimeEditor2)
        Me.grbDieukienloc.Controls.Add(Me.UltraDateTimeEditor1)
        Me.grbDieukienloc.Controls.Add(Me.UltraGroupBox3)
        Me.grbDieukienloc.Controls.Add(Me.UltraGroupBox4)
        Me.grbDieukienloc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDieukienloc.Location = New System.Drawing.Point(323, 3)
        Me.grbDieukienloc.Name = "grbDieukienloc"
        Me.grbDieukienloc.Size = New System.Drawing.Size(449, 217)
        Me.grbDieukienloc.TabIndex = 4
        Me.grbDieukienloc.Text = "Điều Kiện Lọc Và Xem Báo Cáo"
        '
        'chkDonViThai
        '
        Me.chkDonViThai.AutoSize = True
        Me.chkDonViThai.ForeColor = System.Drawing.Color.Blue
        Me.chkDonViThai.Location = New System.Drawing.Point(192, 117)
        Me.chkDonViThai.Name = "chkDonViThai"
        Me.chkDonViThai.Size = New System.Drawing.Size(80, 21)
        Me.chkDonViThai.TabIndex = 12
        Me.chkDonViThai.Text = "Đơn Vị :"
        Me.chkDonViThai.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(15, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Đến Ngày :"
        '
        'cbDonViThai
        '
        Me.cbDonViThai.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonViThai.Location = New System.Drawing.Point(274, 114)
        Me.cbDonViThai.Name = "cbDonViThai"
        Me.cbDonViThai.Size = New System.Drawing.Size(136, 26)
        Me.cbDonViThai.TabIndex = 10
        '
        'UltraDateTimeEditor2
        '
        Me.UltraDateTimeEditor2.Location = New System.Drawing.Point(274, 88)
        Me.UltraDateTimeEditor2.Name = "UltraDateTimeEditor2"
        Me.UltraDateTimeEditor2.Size = New System.Drawing.Size(136, 26)
        Me.UltraDateTimeEditor2.TabIndex = 2
        '
        'UltraDateTimeEditor1
        '
        Me.UltraDateTimeEditor1.Location = New System.Drawing.Point(274, 61)
        Me.UltraDateTimeEditor1.Name = "UltraDateTimeEditor1"
        Me.UltraDateTimeEditor1.Size = New System.Drawing.Size(136, 26)
        Me.UltraDateTimeEditor1.TabIndex = 2
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.btXemToanCTy)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(6, 36)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(165, 153)
        Me.UltraGroupBox3.TabIndex = 13
        Me.UltraGroupBox3.Text = "Báo Cáo Toàn Cty"
        '
        'btXemToanCTy
        '
        Appearance21.FontData.BoldAsString = "True"
        Appearance21.ForeColor = System.Drawing.Color.Blue
        Me.btXemToanCTy.Appearance = Appearance21
        Me.btXemToanCTy.Location = New System.Drawing.Point(15, 78)
        Me.btXemToanCTy.Name = "btXemToanCTy"
        Me.btXemToanCTy.Size = New System.Drawing.Size(132, 29)
        Me.btXemToanCTy.TabIndex = 1
        Me.btXemToanCTy.Text = "Xem Tổng Quát"
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Controls.Add(Me.Label7)
        Me.UltraGroupBox4.Controls.Add(Me.Label6)
        Me.UltraGroupBox4.Controls.Add(Me.btXemTungDonVi)
        Me.UltraGroupBox4.ForeColor = System.Drawing.Color.Firebrick
        Me.UltraGroupBox4.Location = New System.Drawing.Point(177, 36)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(264, 153)
        Me.UltraGroupBox4.TabIndex = 13
        Me.UltraGroupBox4.Text = "Báo Cáo Từng Đơn Vị"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(21, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 17)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Từ Ngày :"
        '
        'btXemTungDonVi
        '
        Appearance20.FontData.BoldAsString = "True"
        Appearance20.ForeColor = System.Drawing.Color.Blue
        Me.btXemTungDonVi.Appearance = Appearance20
        Me.btXemTungDonVi.Location = New System.Drawing.Point(97, 114)
        Me.btXemTungDonVi.Name = "btXemTungDonVi"
        Me.btXemTungDonVi.Size = New System.Drawing.Size(136, 25)
        Me.btXemTungDonVi.TabIndex = 1
        Me.btXemTungDonVi.Text = "Xem Báo Cáo"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox5)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(802, 232)
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Controls.Add(Me.Label5)
        Me.UltraGroupBox5.Controls.Add(Me.chkdvT)
        Me.UltraGroupBox5.Controls.Add(Me.dtpthangT)
        Me.UltraGroupBox5.Controls.Add(Me.btET)
        Me.UltraGroupBox5.Controls.Add(Me.btXemluoiT)
        Me.UltraGroupBox5.Controls.Add(Me.cbdvT)
        Me.UltraGroupBox5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox5.Location = New System.Drawing.Point(4, 3)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(783, 231)
        Me.UltraGroupBox5.TabIndex = 6
        Me.UltraGroupBox5.Text = "Xem Chi Tiết Giờ Công"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(55, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Ngày :"
        '
        'chkdvT
        '
        Me.chkdvT.AutoSize = True
        Me.chkdvT.ForeColor = System.Drawing.Color.Blue
        Me.chkdvT.Location = New System.Drawing.Point(23, 72)
        Me.chkdvT.Name = "chkdvT"
        Me.chkdvT.Size = New System.Drawing.Size(80, 21)
        Me.chkdvT.TabIndex = 12
        Me.chkdvT.Text = "Đơn Vị :"
        Me.chkdvT.UseVisualStyleBackColor = True
        '
        'dtpthangT
        '
        Me.dtpthangT.Location = New System.Drawing.Point(107, 40)
        Me.dtpthangT.Name = "dtpthangT"
        Me.dtpthangT.Size = New System.Drawing.Size(182, 26)
        Me.dtpthangT.TabIndex = 15
        '
        'btET
        '
        Appearance18.FontData.BoldAsString = "True"
        Appearance18.ForeColor = System.Drawing.Color.Blue
        Me.btET.Appearance = Appearance18
        Me.btET.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D
        Me.btET.Location = New System.Drawing.Point(205, 114)
        Me.btET.Name = "btET"
        Me.btET.Size = New System.Drawing.Size(113, 27)
        Me.btET.TabIndex = 13
        Me.btET.Text = "Xuất Excel"
        '
        'btXemluoiT
        '
        Appearance19.FontData.BoldAsString = "True"
        Appearance19.ForeColor = System.Drawing.Color.Blue
        Me.btXemluoiT.Appearance = Appearance19
        Me.btXemluoiT.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D
        Me.btXemluoiT.Location = New System.Drawing.Point(50, 114)
        Me.btXemluoiT.Name = "btXemluoiT"
        Me.btXemluoiT.Size = New System.Drawing.Size(133, 27)
        Me.btXemluoiT.TabIndex = 14
        Me.btXemluoiT.Text = "Xem Danh Sách"
        '
        'cbdvT
        '
        Me.cbdvT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbdvT.Location = New System.Drawing.Point(107, 70)
        Me.cbdvT.Name = "cbdvT"
        Me.cbdvT.Size = New System.Drawing.Size(182, 26)
        Me.cbdvT.TabIndex = 10
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(812, 282)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(812, 258)
        Me.grpDetail.TabIndex = 5
        '
        'UltraTabControl1
        '
        Appearance9.BackColor = System.Drawing.Color.White
        Me.UltraTabControl1.Appearance = Appearance9
        Me.UltraTabControl1.CausesValidation = False
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(806, 255)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Thống Kê Nhân Viên Mang Thai Trên 7 Tháng"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Giờ Công Nhân Viên Mang Thai Trên 7 Tháng"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab3})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(802, 232)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(812, 24)
        Me.XpCaption1.TabIndex = 4
        Me.XpCaption1.Text = "Chi Tiết Tình Hình Nhân Viên Mang Thai Trên 7 Tháng"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "0.add.ico")
        Me.ImageList1.Images.SetKeyName(1, "1.xoa.ico")
        Me.ImageList1.Images.SetKeyName(2, "2.note.ico")
        Me.ImageList1.Images.SetKeyName(3, "3.PRINTER.ico")
        Me.ImageList1.Images.SetKeyName(4, "4.save.ico")
        Me.ImageList1.Images.SetKeyName(5, "5.a91.ico")
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 290)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(812, 364)
        Me.pnlList.TabIndex = 5
        '
        'dgrBC
        '
        Me.UltraToolbarsManager1.SetContextMenuUltra(Me.dgrBC, "PopupMenuTool1")
        Appearance10.BackColor = System.Drawing.Color.White
        Me.dgrBC.DisplayLayout.Appearance = Appearance10
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(812, 306)
        Me.dgrBC.TabIndex = 8
        Me.dgrBC.Text = "LƯỚI LỌC DỮ LIỆU"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(812, 58)
        Me.pnlButton.TabIndex = 7
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnXoa, Me.btnLuu, Me.btSua, Me.btnIn})
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(812, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnXoa
        '
        Me.btnXoa.ImageIndex = 1
        Me.btnXoa.Text = "Xóa"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 4
        Me.btnLuu.Text = "Lưu"
        '
        'btSua
        '
        Me.btSua.ImageIndex = 2
        Me.btSua.Text = "Sửa"
        '
        'btnIn
        '
        Me.btnIn.ImageIndex = 3
        Me.btnIn.Text = "Excel"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(812, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh mục tình hình nhân viên mang thai trên 7 tháng"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(818, 657)
        Me.UltraGroupBox1.TabIndex = 7
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 282)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 7
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        Me.UltraToolbarsManager1.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager1.ImageListSmall = Me.ImageList1
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.FloatingLocation = New System.Drawing.Point(372, 326)
        UltraToolbar1.FloatingSize = New System.Drawing.Size(102, 42)
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool1})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        PopupMenuTool2.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3, ButtonTool4, ButtonTool5})
        Appearance13.Image = 0
        ButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance13
        ButtonTool6.SharedProps.Caption = "Thêm"
        Appearance14.Image = 1
        ButtonTool7.SharedProps.AppearancesSmall.Appearance = Appearance14
        ButtonTool7.SharedProps.Caption = "Sửa"
        Appearance15.Image = 2
        ButtonTool8.SharedProps.AppearancesSmall.Appearance = Appearance15
        ButtonTool8.SharedProps.Caption = "Xóa"
        Appearance16.Image = 3
        ButtonTool9.SharedProps.AppearancesSmall.Appearance = Appearance16
        ButtonTool9.SharedProps.Caption = "Lưu"
        Appearance17.Image = 4
        ButtonTool10.SharedProps.AppearancesSmall.Appearance = Appearance17
        ButtonTool10.SharedProps.Caption = "In"
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool2, ButtonTool6, ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool10})
        Me.UltraToolbarsManager1.Visible = False
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.dtpDenNgayThai)
        Me.UltraTabPageControl1.Controls.Add(Me.dtpNgaybatdau)
        Me.UltraTabPageControl1.Controls.Add(Me.cbDonvi)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(802, 356)
        '
        'dtpDenNgayThai
        '
        Me.dtpDenNgayThai.Location = New System.Drawing.Point(405, 27)
        Me.dtpDenNgayThai.Name = "dtpDenNgayThai"
        Me.dtpDenNgayThai.Size = New System.Drawing.Size(144, 21)
        Me.dtpDenNgayThai.TabIndex = 10
        '
        'dtpNgaybatdau
        '
        Me.dtpNgaybatdau.Location = New System.Drawing.Point(405, 3)
        Me.dtpNgaybatdau.Name = "dtpNgaybatdau"
        Me.dtpNgaybatdau.Size = New System.Drawing.Size(144, 21)
        Me.dtpNgaybatdau.TabIndex = 10
        '
        'cbDonvi
        '
        Me.cbDonvi.Location = New System.Drawing.Point(73, 16)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(144, 21)
        Me.cbDonvi.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.AliceBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(327, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Đến Ngày :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.AliceBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(326, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Bắt Đầu Từ :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.AliceBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Đơn Vị :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btHuyHet)
        Me.GroupBox1.Controls.Add(Me.btHuy)
        Me.GroupBox1.Controls.Add(Me.btChonHet)
        Me.GroupBox1.Controls.Add(Me.btChon)
        Me.GroupBox1.Controls.Add(Me.txtTongchon)
        Me.GroupBox1.Controls.Add(Me.txtTongkchon)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.clbNhanvienchon)
        Me.GroupBox1.Controls.Add(Me.clbNhanvien)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 308)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh Sách Nhân Viên"
        '
        'btHuyHet
        '
        Appearance11.ForeColor = System.Drawing.Color.Blue
        Me.btHuyHet.Appearance = Appearance11
        Me.btHuyHet.Location = New System.Drawing.Point(312, 221)
        Me.btHuyHet.Name = "btHuyHet"
        Me.btHuyHet.Size = New System.Drawing.Size(56, 29)
        Me.btHuyHet.TabIndex = 17
        Me.btHuyHet.Text = "<<"
        '
        'btHuy
        '
        Appearance12.ForeColor = System.Drawing.Color.Blue
        Me.btHuy.Appearance = Appearance12
        Me.btHuy.Location = New System.Drawing.Point(312, 191)
        Me.btHuy.Name = "btHuy"
        Me.btHuy.Size = New System.Drawing.Size(56, 29)
        Me.btHuy.TabIndex = 17
        Me.btHuy.Text = "<"
        '
        'btChonHet
        '
        Appearance3.ForeColor = System.Drawing.Color.Blue
        Me.btChonHet.Appearance = Appearance3
        Me.btChonHet.Location = New System.Drawing.Point(312, 135)
        Me.btChonHet.Name = "btChonHet"
        Me.btChonHet.Size = New System.Drawing.Size(56, 29)
        Me.btChonHet.TabIndex = 17
        Me.btChonHet.Text = ">>"
        '
        'btChon
        '
        Appearance4.ForeColor = System.Drawing.Color.Blue
        Me.btChon.Appearance = Appearance4
        Me.btChon.Location = New System.Drawing.Point(312, 104)
        Me.btChon.Name = "btChon"
        Me.btChon.Size = New System.Drawing.Size(56, 29)
        Me.btChon.TabIndex = 17
        Me.btChon.Text = ">"
        '
        'txtTongchon
        '
        Me.txtTongchon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTongchon.Location = New System.Drawing.Point(405, 69)
        Me.txtTongchon.Name = "txtTongchon"
        Me.txtTongchon.Size = New System.Drawing.Size(62, 22)
        Me.txtTongchon.TabIndex = 9
        '
        'txtTongkchon
        '
        Me.txtTongkchon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTongkchon.Location = New System.Drawing.Point(47, 69)
        Me.txtTongkchon.Name = "txtTongkchon"
        Me.txtTongkchon.Size = New System.Drawing.Size(62, 22)
        Me.txtTongkchon.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(399, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Tổng Nhân Viên Được Chọn"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(42, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Tổng Nhân Viên Không Chọn"
        '
        'clbNhanvienchon
        '
        Me.clbNhanvienchon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbNhanvienchon.FormattingEnabled = True
        Me.clbNhanvienchon.Location = New System.Drawing.Point(401, 100)
        Me.clbNhanvienchon.Name = "clbNhanvienchon"
        Me.clbNhanvienchon.Size = New System.Drawing.Size(237, 155)
        Me.clbNhanvienchon.TabIndex = 7
        '
        'clbNhanvien
        '
        Me.clbNhanvien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbNhanvien.FormattingEnabled = True
        Me.clbNhanvien.Location = New System.Drawing.Point(47, 100)
        Me.clbNhanvien.Name = "clbNhanvien"
        Me.clbNhanvien.Size = New System.Drawing.Size(237, 155)
        Me.clbNhanvien.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btUncheckall)
        Me.GroupBox2.Controls.Add(Me.btCheckall)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(291, 279)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'btUncheckall
        '
        Appearance5.ForeColor = System.Drawing.Color.Blue
        Me.btUncheckall.Appearance = Appearance5
        Me.btUncheckall.Location = New System.Drawing.Point(160, 241)
        Me.btUncheckall.Name = "btUncheckall"
        Me.btUncheckall.Size = New System.Drawing.Size(87, 29)
        Me.btUncheckall.TabIndex = 17
        Me.btUncheckall.Text = "Hủy Chọn"
        '
        'btCheckall
        '
        Appearance6.ForeColor = System.Drawing.Color.Blue
        Me.btCheckall.Appearance = Appearance6
        Me.btCheckall.Location = New System.Drawing.Point(49, 241)
        Me.btCheckall.Name = "btCheckall"
        Me.btCheckall.Size = New System.Drawing.Size(87, 29)
        Me.btCheckall.TabIndex = 17
        Me.btCheckall.Text = "Chọn Hết"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btUncheckallnvc)
        Me.GroupBox4.Controls.Add(Me.btCheckallnvc)
        Me.GroupBox4.Location = New System.Drawing.Point(374, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(291, 279)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        '
        'btUncheckallnvc
        '
        Appearance7.ForeColor = System.Drawing.Color.Blue
        Me.btUncheckallnvc.Appearance = Appearance7
        Me.btUncheckallnvc.Location = New System.Drawing.Point(163, 241)
        Me.btUncheckallnvc.Name = "btUncheckallnvc"
        Me.btUncheckallnvc.Size = New System.Drawing.Size(87, 29)
        Me.btUncheckallnvc.TabIndex = 17
        Me.btUncheckallnvc.Text = "Hủy Chọn"
        '
        'btCheckallnvc
        '
        Appearance8.ForeColor = System.Drawing.Color.Blue
        Me.btCheckallnvc.Appearance = Appearance8
        Me.btCheckallnvc.Location = New System.Drawing.Point(42, 241)
        Me.btCheckallnvc.Name = "btCheckallnvc"
        Me.btCheckallnvc.Size = New System.Drawing.Size(87, 29)
        Me.btCheckallnvc.TabIndex = 17
        Me.btCheckallnvc.Text = "Chọn Hết"
        '
        'frmThaiThangThu7
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(818, 657)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.KeyPreview = True
        Me.Name = "frmThaiThangThu7"
        Me.ShowIcon = False
        Me.Text = "Danh Sách mang thai trên 7 tháng"
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.dtpDN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpNBD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbodonvixemluoi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grbDieukienloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDieukienloc.ResumeLayout(False)
        Me.grbDieukienloc.PerformLayout()
        CType(Me.cbDonViThai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDateTimeEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDateTimeEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        Me.UltraGroupBox5.PerformLayout()
        CType(Me.dtpthangT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbdvT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.dtpDenNgayThai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpNgaybatdau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/ThaiThangThu7.xml"
        obj.Table = "IT_THAITHANGTHU7"
        obj.ID = Me.cbDonvi.Text
        obj.ChonBang = 4
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrthaithangthu7")
    End Sub
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmThaiThangThu7_Load)
        Me.InitializeComponent()
    End Sub
    Private Sub frmThaiThangThu7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnLuu.Enabled = False
        Me.btnXoa.Enabled = False
        Me.btSua.Enabled = False
        'Load Don Vi bao cao
        obj.ChonBang = 7
        Me.b = New clsBThaiThangThu7
        Me.cbodonvixemluoi.DataSource = Me.b.LoadDS(obj)
        Me.cbodonvixemluoi.Enabled = False
        'Me.cbodonvixemluoi.Text = Me.cbodonvixemluoi.Items(0).ToString()
        Me.cbodonvixemluoi.Enabled = False
        Me.dtpDN.Enabled = False
        Me.dtpNBD.Enabled = False

        obj.ChonBang = 7
        Me.b = New clsBThaiThangThu7
        Me.cbDonViThai.DataSource = Me.b.LoadDS(obj)
        Me.cbDonViThai.Enabled = False
        Me.cbDonViThai.Text = Me.cbDonViThai.Items(0).ToString()

        obj.ChonBang = 7
        Me.b = New clsBThaiThangThu7
        Me.cbdvT.DataSource = Me.b.LoadDS(obj)
        Me.cbdvT.Enabled = False
        Me.cbdvT.Text = Me.cbdvT.Items(0).ToString()
        Me.btnXoa.Enabled = False
        Me.btSua.Enabled = False
        Me.cbDonViThai.Enabled = False
        Me.cbdvT.Enabled = False
    End Sub
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub
    Public Sub LuuDuLieu()
        Dim TABLE As New DataTable
        Dim nRow As Integer = 0
        Dim manv As String
        Dim donvi As String
        Dim ngaybd As Date
        ngaybd = Me.dtpNgaybatdau.Value
        Dim ngay As String = ngaybd.Year.ToString() + "/" + ngaybd.Month.ToString() + "/" + ngaybd.Day.ToString()

        Dim dngay As Date
        dngay = Me.dtpDenNgayThai.Value
        Dim denngay As String = dngay.Year.ToString() + "/" + dngay.Month.ToString() + "/" + dngay.Day.ToString()

        ' Duyet tung nhan vien trong checklistbox
        If Me.clbNhanvienchon.Items.Count = 0 Then
            MessageBox.Show("Bạn chưa chọn nhân viên")
            Exit Sub
        End If
        nRow = 0
        While nRow < clbNhanvienchon.Items.Count
            If Me.clbNhanvienchon.CheckedItems.IndexOf(Me.clbNhanvienchon.Items.Item(nRow)) <> -1 Then
                'SET VALUES 
                obj.Setnull()
                manv = Me.clbNhanvienchon.Items.Item(nRow).ToString 'ma nhan vien trong checklist box
                donvi = Me.cbDonvi.Text

                obj.setvalue("", "IT_THAITHANGTHU7", donvi, manv, ngay, denngay, 0)
                'XOA HANG TRONG BANG
                Dim i As Integer
                i = 0
                ' neu trong luoi co nhan vien
                If Me.dgrBC.Rows.Count > 0 Then
                    Dim flag As Boolean
                    flag = False
                    ' Duyet nhan vien trong luoi
                    While i <= (Me.dgrBC.Rows.Count - 1)
                        Dim manv_grid As String ' ma nhan vien trong datagrid
                        Dim tungay_grid As String
                        Dim denngay_grid As String
                        ngay = Me.dtpNgaybatdau.Text
                        denngay = Me.dtpDenNgayThai.Text
                        manv_grid = Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value
                        tungay_grid = Me.dgrBC.Rows.Item(i).Cells.Item("BATDAUTU").Value
                        denngay_grid = Me.dgrBC.Rows.Item(i).Cells.Item("DENNGAY").Value

                        If manv = manv_grid And ngay = tungay_grid And denngay = denngay_grid Then ' neu manv cua check list box bang voi ma nv trong luoi thi bien la true
                            flag = True
                            Exit While
                        End If
                        i = i + 1
                    End While 'Thoat khoi vong lap trong luoi
                    'Neu bien co la true thi ko cho chen
                    If flag = True Then
                        If MessageBox.Show("Nhân Viên " & Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value & " Đã Có Bạn Muốn Cập Nhật Lại Không?", "Nhân Viên Đã Tồn Tại", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            Me.b = New clsBThaiThangThu7
                            Me.b.UpdateInfo(obj)
                            Me.methodLoad()
                            MessageBox.Show("Cập Nhật Thành Công")
                        Else
                        End If
                    Else ' chen vao luoi
                        If dngay <= ngaybd Then
                            MessageBox.Show("Bạn phải nhập đến ngày lớn hơn ngày bắt đầu")
                            Exit Sub
                        Else
                            Me.b = New clsBThaiThangThu7
                            Me.b.InsertInfo(obj)
                            Me.methodLoad()
                            MessageBox.Show("Đã lưu dữ liệu")
                        End If
                    End If

                Else ' neu trong luoi chua co nhan vien thi chen
                    If dngay <= ngaybd Then
                        MessageBox.Show("Bạn phải nhập đến ngày lớn hơn ngày bắt đầu")
                        Exit Sub
                    Else
                        Me.b = New clsBThaiThangThu7
                        Me.b.InsertInfo(obj)
                        Me.methodLoad()
                        MessageBox.Show("Đã lưu dữ liệu")
                    End If
                End If
                nRow = nRow + 1
            Else
                nRow = nRow + 1
            End If
        End While 'Thoat khoi vong lap trong check list box
        Dim Row As Integer = 0
        Row = 0
        While Row < clbNhanvienchon.Items.Count
            If Me.clbNhanvienchon.CheckedItems.IndexOf(Me.clbNhanvienchon.Items.Item(Row)) <> -1 Then
                Me.clbNhanvienchon.SetItemChecked(Row, False)
            End If
            Row = Row + 1
        End While
        Me.dtpNgaybatdau.Text = Now
        Me.dtpDenNgayThai.Text = Now

    End Sub
    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jFunction As New objThaiThangThu7
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim ma As String
                Dim tungay As Date
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        ma = StringType.FromObject(activeRow.Cells.Item("NV_MA").Value)
                        tungay = StringType.FromObject(activeRow.Cells.Item("BATDAUTU").Value)
                        Dim tngay As String = tungay.Year.ToString() + "/" + tungay.Month.ToString() + "/" + tungay.Day.ToString()
                        jFunction.ID = ma
                        jFunction.NGAY = tngay
                        If jFunction.ID = ma And jFunction.NGAY = tungay Then
                            If (MessageBox.Show(("Bạn có muốn xóa nhân viên có mã: " & ma & " và ngày " & tngay & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo(jFunction) Then
                                    'MessageBox.Show("Đã xóa thành công")
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không được xóa nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                'Return
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nhân viên đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    ma = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("NV_MA").Value)
                    tungay = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("BATDAUTU").Value)
                    Dim tngay As String = tungay.Year.ToString() + "/" + tungay.Month.ToString() + "/" + tungay.Day.ToString()
                    jFunction.ID = ma
                    jFunction.NGAY = tngay
                    If Me.b.DeleteInfo(jFunction) Then
                        'MessageBox.Show("Đã xóa thành công")
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:
            jFunction.Setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jFunction)
            Me.methodLoad()
            MessageBox.Show("Đã xóa thành công")
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
        Me.clbNhanvienchon.Items.Clear()
        txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
    End Sub
    Private Sub btXemToanCTy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemToanCTy.Click
        Select Case UltraTabControl1.SelectedTab.Index
            Case 0
                Dim report As New FrmReport
                Me.ReportID = "562"
                report.reportID = Me.ReportID
                Dim strArray As String() = New String() {}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Case 1
        End Select
    End Sub
    Private Sub TrangThaiDieuKien()
        Select Case UltraTabControl1.SelectedTab.Index
            Case 0
                Me.TrangThaiDieuKienXem()
            Case 1
                Me.TrangThaiDieuKienXem()
        End Select
    End Sub
    Public Sub TrangThaiDieuKienXem()

        Select Case UltraTabControl1.SelectedTab.Index
            Case 0
                Me.btnXoa.Enabled = False
                Me.btnLuu.Enabled = False
                Me.btnIn.Enabled = False
                Me.btSua.Enabled = False
            Case 1
                Me.btnXoa.Enabled = False
                Me.btnLuu.Enabled = False
                Me.btnIn.Enabled = False
                Me.btSua.Enabled = False
        End Select
    End Sub
    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UltraTabControl1.SelectedTabChanged
        Me.TrangThaiDieuKien()
        Select Case UltraTabControl1.SelectedTab.Index
           
            Case 0
                Me.dgrBC.Show()
                Me.dgrBC.DataSource = Nothing
                Me.chkTN.Checked = False
                Me.chkDV.Checked = False
                Me.chkDonViThai.Checked = False
            Case 1
                Me.dgrBC.Show()
                Me.dgrBC.DataSource = Nothing
                Me.chkdvT.Checked = False
        End Select
    End Sub
    Private Sub chkDonViThai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonViThai.CheckedChanged
        If Me.chkDonViThai.Checked = True Then
            Me.cbDonViThai.Enabled = True
        Else
            Me.cbDonViThai.Enabled = False
        End If
    End Sub
    Private Sub btXemTungDonVi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemTungDonVi.Click
        Select Case UltraTabControl1.SelectedTab.Index
            Case 0
                Dim report As New FrmReport
                Me.ReportID = "563"
                report.reportID = Me.ReportID
                Dim strArray As String() = New String() {Me.cbDonViThai.Text, Me.chkDonViThai.Checked, Me.UltraDateTimeEditor1.Text, Me.UltraDateTimeEditor2.Text}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Case 1
        End Select
    End Sub
    Friend WithEvents d As clsDThaiThangThu7
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim flag As Boolean
    ' Fields
    Friend WithEvents b As clsBThaiThangThu7
    Friend WithEvents btnIn As ButtonItem
    Friend WithEvents btnLuu As ButtonItem
    Friend WithEvents btnXoa As ButtonItem
    Friend WithEvents dgrBC As UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pnlButton As Panel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents pnlList As Panel
    Friend WithEvents splDetail As CollapsibleSplitter
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents UltraGroupBox1 As UltraGroupBox
    Friend WithEvents UltraToolbarsManager1 As UltraToolbarsManager
    Friend WithEvents XpCaption1 As XPCaption
    Friend WithEvents XpCaption2 As XPCaption
    Private components As System.ComponentModel.IContainer
    Public ThemSua As Integer

    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btSua As TD.SandBar.ButtonItem
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtpDN As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpNBD As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents chkTN As System.Windows.Forms.CheckBox
    Friend WithEvents chkDV As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbodonvixemluoi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btE As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btXemluoi As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grbDieukienloc As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkDonViThai As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbDonViThai As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraDateTimeEditor2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btXemTungDonVi As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraDateTimeEditor1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btXemToanCTy As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkdvT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpthangT As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btET As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btXemluoiT As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cbdvT As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents dtpDenNgayThai As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpNgaybatdau As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btHuyHet As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btHuy As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btChonHet As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btChon As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtTongchon As System.Windows.Forms.TextBox
    Friend WithEvents txtTongkchon As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents clbNhanvienchon As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbNhanvien As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btUncheckall As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btCheckall As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btUncheckallnvc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btCheckallnvc As Infragistics.Win.Misc.UltraButton
    Dim obj As New objThaiThangThu7
    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/ThaiThangThu7_Luoi.xml"
        obj.ChonBang = 8
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrthaithangthu7")
    End Sub
    Public Sub methodLoad3()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/ThaiThangThu7_Luoi.xml"
        'TU NGAY
        Dim NGAY As Date
        Dim NGAY2 As String
        NGAY = Me.dtpNBD.Text
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2
        'DEN NGAY
        Dim NGAY3 As Date
        Dim NGAY4 As String
        NGAY3 = Me.dtpDN.Text
        NGAY4 = NGAY3.Year.ToString() + "/" + NGAY3.Month.ToString() + "/" + NGAY3.Day.ToString()
        obj.DENNGAY = NGAY4

        obj.ChonBang = 9
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrthaithangthu7")
    End Sub
    Public Sub methodLoad4()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/ThaiThangThu7_Luoi.xml"
        'TU NGAY
        Dim NGAY As Date
        Dim NGAY2 As String
        NGAY = Me.dtpNBD.Text
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2
        'DEN NGAY
        Dim NGAY3 As Date
        Dim NGAY4 As String
        NGAY3 = Me.dtpDN.Text
        NGAY4 = NGAY3.Year.ToString() + "/" + NGAY3.Month.ToString() + "/" + NGAY3.Day.ToString()
        obj.DENNGAY = NGAY4
        ' DON VI
        obj.DonVi = Me.cbodonvixemluoi.Text

        obj.ChonBang = 10
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrthaithangthu7")
    End Sub
    Public Sub methodLoad5()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/ThaiThangThu7_Luoi.xml"
        obj.DonVi = Me.cbodonvixemluoi.Text
        obj.ChonBang = 11
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrthaithangthu7")
    End Sub
    Private Sub chkTN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTN.CheckedChanged
        If Me.chkTN.Checked = True Then
            Me.dtpNBD.Enabled = True
            Me.dtpDN.Enabled = True
        Else
            Me.dtpNBD.Enabled = False
            Me.dtpDN.Enabled = False
            Me.dtpNBD.Text = Now
            Me.dtpDN.Text = Now

        End If
    End Sub
    Private Sub chkDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDV.CheckedChanged
        If Me.chkDV.Checked = True Then
            Me.cbodonvixemluoi.Enabled = True
        Else
            Me.cbodonvixemluoi.Enabled = False
        End If
    End Sub
    Private Sub btXemluoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemluoi.Click
        Select Case UltraTabControl1.SelectedTab.Index
            Case 0
                If Me.chkDV.Checked = True And Me.chkTN.Checked = True Then
                    Me.methodLoad4()
                ElseIf Me.chkDV.Checked = False And Me.chkTN.Checked = False Then
                    Me.methodLoad2()
                ElseIf Me.chkDV.Checked = True And Me.chkTN.Checked = False Then
                    Me.methodLoad5()
                ElseIf Me.chkDV.Checked = False And Me.chkTN.Checked = True Then
                    Me.methodLoad3()
                End If
            Case 1
        End Select
    End Sub
    Private Sub btE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btE.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub chkdvT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdvT.CheckedChanged
        If Me.chkdvT.Checked = True Then
            Me.cbdvT.Enabled = True
        Else
            Me.cbdvT.Enabled = False
        End If
    End Sub
    Public Sub methodLoad7()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/GioCongThaiDuoi7Thang_Luoi.xml"
        obj.THANG = Month(Me.dtpthangT.Text)
        Dim NGAY As Date = Me.dtpthangT.Text
        Dim NGAY2 As String
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2

        obj.ChonBang = 12
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Public Sub methodLoad6()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThaiThangThu7
        Me.Path = "/layout/GioCongThaiDuoi7Thang_Luoi.xml"

        obj.THANG = Month(Me.dtpthangT.Text)
        Dim NGAY As Date = Me.dtpthangT.Text
        Dim NGAY2 As String
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2

        obj.DonVi = Me.cbdvT.Text
        obj.ChonBang = 13
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub btXemluoiT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemluoiT.Click
        Select Case UltraTabControl1.SelectedTab.Index
            Case 1
                If Me.chkdvT.Checked = True Then
                    Me.methodLoad6()
                Else
                    Me.methodLoad7()
                End If
        End Select
    End Sub
    Private Sub btET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btET.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        Me.Sua()
    End Sub
    Public Sub Sua()
        Dim TABLE As New DataTable
        Dim nRow As Integer = 0
        Dim manv As String
        Dim donvi As String
        Dim ngaybd As Date
        ngaybd = Me.dtpNgaybatdau.Value
        Dim ngay As String = ngaybd.Year.ToString() + "/" + ngaybd.Month.ToString() + "/" + ngaybd.Day.ToString()

        Dim dngay As Date
        dngay = Me.dtpDenNgayThai.Value
        Dim denngay As String = dngay.Year.ToString() + "/" + dngay.Month.ToString() + "/" + dngay.Day.ToString()


        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
            donvi = activeRow.Cells.Item("DV_MA").Value.ToString
            Dim tungay_grid1 As Date
            Dim denngay_grid1 As Date
            Dim tungay_grid2 As String
            Dim denngay_grid2 As String

            obj.NGAY = ngay
            obj.DENNGAY = denngay

            manv = activeRow.Cells.Item("NV_MA").Value.ToString

            tungay_grid1 = activeRow.Cells.Item("BATDAUTU").Value.ToString
            tungay_grid2 = tungay_grid1.Year.ToString() + "/" + tungay_grid1.Month.ToString() + "/" + tungay_grid1.Day.ToString()

            denngay_grid1 = activeRow.Cells.Item("DENNGAY").Value.ToString
            denngay_grid2 = denngay_grid1.Year.ToString() + "/" + denngay_grid1.Month.ToString() + "/" + denngay_grid1.Day.ToString()

            obj.TUNGAYLUOI = tungay_grid2
            obj.DENNGAYLUOI = denngay_grid2
        End If
        obj.setvalue("", "IT_THAITHANGTHU7", donvi, manv, ngay, denngay, 0)
        Me.b = New clsBThaiThangThu7
        Me.b.UpdateInfo(obj)
        Me.methodLoad()
        MessageBox.Show("Cập Nhật Thành Công")


        Dim Row As Integer = 0
        Row = 0
        While Row < clbNhanvienchon.Items.Count
            If Me.clbNhanvienchon.CheckedItems.IndexOf(Me.clbNhanvienchon.Items.Item(Row)) <> -1 Then
                Me.clbNhanvienchon.SetItemChecked(Row, False)
            End If
            Row = Row + 1
        End While
        Me.dtpNgaybatdau.Text = Now
        Me.dtpDenNgayThai.Text = Now
    End Sub
    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.HieuChinh()
        Me.DieuKienClick()
    End Sub
    Public Sub DieuKienDClick()
        Me.cbDonvi.Enabled = True
        Me.dtpNgaybatdau.Value = Now
        txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
        Me.btnLuu.Enabled = True
        Me.btnXoa.Enabled = False
        Me.btSua.Enabled = False
    End Sub
    Public Sub DieuKienClick()
        Me.clbNhanvien.Items.Clear()
        Me.cbDonvi.Enabled = False
        txtTongkchon.Text = Me.clbNhanvien.Items.Count()
        txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
        Me.btnLuu.Enabled = False
        Me.btnXoa.Enabled = False
        Me.btSua.Enabled = False
    End Sub
    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.DieuKienDClick()
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim ma As String
            Dim list_nv As CheckedListBox
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.cbDonvi.Text = activeRow.Cells.Item("DV_MA").Value.ToString
                Me.dtpNgaybatdau.Text = activeRow.Cells.Item("BATDAUTU").Value.ToString
                Me.dtpDenNgayThai.Text = activeRow.Cells.Item("DENNGAY").Value.ToString

                ma = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.clbNhanvienchon.Items.Clear()
                Me.clbNhanvienchon.Items.Add(ma)
                If Me.clbNhanvienchon.CheckedItems.IndexOf(Me.clbNhanvienchon.Items.Item(0)) = -1 Then
                    Me.clbNhanvienchon.SetItemChecked(0, True)
                End If
            End If
            Me.flag = 1
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
End Class


