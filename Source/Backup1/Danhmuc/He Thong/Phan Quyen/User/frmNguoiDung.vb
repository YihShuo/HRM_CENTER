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
Imports TongHop.frmMainMain


Public Class frmNguoiDung
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmNguoiDung_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Public Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        If Me.btnSua.Enabled Then
            Me.showGroupinvi()
            Me.HieuChinh()
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtTendangnhap.Text = activeRow.Cells.Item("Ten_DangNhap").Value.ToString
                Me.txtMatkhau.Text = clsTools.Decrypt1(activeRow.Cells.Item("MK_DN").Value.ToString)
                Me.cbManv.Text = activeRow.Cells.Item("Ma_NV").Value.ToString
                Me.txtTennhanvien.Text = activeRow.Cells.Item("Ten_NV").Value.ToString
                Me.txtIp.Text = activeRow.Cells.Item("IP_Address").Value.ToString
                Me.chbAdmin.Checked = activeRow.Cells.Item("Admin").Value

                Me.txtTendangnhap.ReadOnly = True
                Me.ThemSua = 1
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub InitControl()
        Me.btnThem.Enabled = False
        Me.btnSua.Enabled = False
        Me.btnXoa.Enabled = False
        Me.btnLuu.Enabled = False
        'Me.UltraToolbarsManager1.Tools.Item("mnuThem").SharedProps.Enabled = Me.btnThem.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuSua").SharedProps.Enabled = Me.btnSua.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuXoa").SharedProps.Enabled = Me.btnXoa.Enabled
        'Me.UltraToolbarsManager1.Tools.Item("mnuLuu").SharedProps.Enabled = Me.btnLuu.Enabled
        Me.ThemSua = 0
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNguoiDung))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.btCapQuyenClient = New System.Windows.Forms.Button
        Me.btCapquyentruycap = New System.Windows.Forms.Button
        Me.chbAdmin = New System.Windows.Forms.CheckBox
        Me.txtIp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbManv = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTennhanvien = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtMatkhau = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTendangnhap = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnThem = New TD.SandBar.ButtonItem
        Me.btnSua = New TD.SandBar.ButtonItem
        Me.btnXoa = New TD.SandBar.ButtonItem
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cbManv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTennhanvien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatkhau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTendangnhap, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.btCapQuyenClient)
        Me.UltraTabPageControl1.Controls.Add(Me.btCapquyentruycap)
        Me.UltraTabPageControl1.Controls.Add(Me.chbAdmin)
        Me.UltraTabPageControl1.Controls.Add(Me.txtIp)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.cbManv)
        Me.UltraTabPageControl1.Controls.Add(Me.Label5)
        Me.UltraTabPageControl1.Controls.Add(Me.Label4)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTennhanvien)
        Me.UltraTabPageControl1.Controls.Add(Me.txtMatkhau)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTendangnhap)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(543, 176)
        '
        'btCapQuyenClient
        '
        Me.btCapQuyenClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCapQuyenClient.ForeColor = System.Drawing.Color.Blue
        Me.btCapQuyenClient.Location = New System.Drawing.Point(387, 84)
        Me.btCapQuyenClient.Name = "btCapQuyenClient"
        Me.btCapQuyenClient.Size = New System.Drawing.Size(152, 36)
        Me.btCapQuyenClient.TabIndex = 8
        Me.btCapQuyenClient.Text = "Cấp Quyền Client"
        Me.btCapQuyenClient.UseVisualStyleBackColor = True
        '
        'btCapquyentruycap
        '
        Me.btCapquyentruycap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCapquyentruycap.ForeColor = System.Drawing.Color.Blue
        Me.btCapquyentruycap.Location = New System.Drawing.Point(387, 42)
        Me.btCapquyentruycap.Name = "btCapquyentruycap"
        Me.btCapquyentruycap.Size = New System.Drawing.Size(152, 36)
        Me.btCapquyentruycap.TabIndex = 8
        Me.btCapquyentruycap.Text = "Cấp Quyền"
        Me.btCapquyentruycap.UseVisualStyleBackColor = True
        '
        'chbAdmin
        '
        Me.chbAdmin.AutoSize = True
        Me.chbAdmin.ForeColor = System.Drawing.Color.Blue
        Me.chbAdmin.Location = New System.Drawing.Point(387, 18)
        Me.chbAdmin.Name = "chbAdmin"
        Me.chbAdmin.Size = New System.Drawing.Size(62, 18)
        Me.chbAdmin.TabIndex = 7
        Me.chbAdmin.Text = "Addmin"
        Me.chbAdmin.UseVisualStyleBackColor = True
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(124, 123)
        Me.txtIp.MaxLength = 15
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(186, 20)
        Me.txtIp.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(52, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "IP Address :"
        '
        'cbManv
        '
        Me.cbManv.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbManv.Location = New System.Drawing.Point(124, 69)
        Me.cbManv.Name = "cbManv"
        Me.cbManv.Size = New System.Drawing.Size(186, 21)
        Me.cbManv.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(69, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tên NV :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(73, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Mã NV :"
        '
        'txtTennhanvien
        '
        Me.txtTennhanvien.Enabled = False
        Me.txtTennhanvien.Location = New System.Drawing.Point(124, 96)
        Me.txtTennhanvien.MaxLength = 50
        Me.txtTennhanvien.Name = "txtTennhanvien"
        Me.txtTennhanvien.Size = New System.Drawing.Size(186, 21)
        Me.txtTennhanvien.TabIndex = 4
        '
        'txtMatkhau
        '
        Me.txtMatkhau.Location = New System.Drawing.Point(124, 42)
        Me.txtMatkhau.MaxLength = 50
        Me.txtMatkhau.Name = "txtMatkhau"
        Me.txtMatkhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatkhau.Size = New System.Drawing.Size(186, 21)
        Me.txtMatkhau.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(15, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mật Khẩu  :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTendangnhap
        '
        Me.txtTendangnhap.Location = New System.Drawing.Point(124, 15)
        Me.txtTendangnhap.MaxLength = 50
        Me.txtTendangnhap.Name = "txtTendangnhap"
        Me.txtTendangnhap.Size = New System.Drawing.Size(186, 21)
        Me.txtTendangnhap.TabIndex = 1
        Me.tolTip.SetToolTip(Me.txtTendangnhap, "Mã ngày công")
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tên Đăng Nhập :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(553, 226)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(553, 202)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(547, 199)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết người dùng"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(543, 176)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(553, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin chi tiết người dùng"
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
        Me.pnlList.Location = New System.Drawing.Point(3, 234)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(553, 188)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(553, 124)
        Me.dgrBC.TabIndex = 1
        Me.dgrBC.Text = "UltraGrid1"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(553, 64)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnThem, Me.btnSua, Me.btnXoa, Me.btnLuu})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(553, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnThem
        '
        Me.btnThem.ImageIndex = 0
        Me.btnThem.Text = "Thêm"
        '
        'btnSua
        '
        Me.btnSua.ImageIndex = 2
        Me.btnSua.Text = "Sửa"
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
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(553, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh mục chi tiết người dùng"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(559, 425)
        Me.UltraGroupBox1.TabIndex = 14
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 226)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'frmNguoiDung
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(559, 425)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmNguoiDung"
        Me.ShowIcon = False
        Me.Text = "Danh sach nguoi dung"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cbManv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTennhanvien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatkhau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTendangnhap, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)

    End Sub

    Public Sub LuuDuLieu()
        Dim obj As New objNguoiDung
        'If (StringType.StrCmp(Me.txtTendangnhap.Text, "", False) = 0) Then
        '    MessageBox.Show("Bạn phải nhập (tên đăng nhập)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.txtTendangnhap.Focus()
        'ElseIf (StringType.StrCmp(Me.txtMatkhau.Text, "", False) = 0) Then
        '    MessageBox.Show("Bạn phải nhập (mật khẩu)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.txtMatkhau.Focus()
        'ElseIf (StringType.StrCmp(Me.txtTennhanvien.Text, "", False) = 0) Then
        '    MessageBox.Show("Bạn phải nhập (tên người dùng)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Me.txtTennhanvien.Focus()
        'Else
        obj.setvalue(Me.txtTendangnhap.Text, Me.txtMatkhau.Text, Me.cbManv.Text, Me.txtTennhanvien.Text, Me.txtIp.Text, Me.chbAdmin.CheckState)
        Me.b = New clsBNguoiDung
        Try
            If Me.b.CapNhat(obj, Me.ThemSua) Then
                MessageBox.Show("Đã lưu dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                obj.Setnull()
                obj.ChonBang = 1
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                If Me.btnThem.Enabled Then
                    Me.ThemMoi()
                End If
            Else
                Me.txtTendangnhap.Focus()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongbaoLoi(exception.Message)
            ProjectData.ClearProjectError()
        End Try
        'End If
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objNguoiDung
        obj.Setnull()
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NguoiDung.xml"), typeControl.Grid, "coldgrNguoiDung")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        If (Me.dgrBC.Rows.Count > 0) Then
            Me.dgrBC.Rows.Item(0).Selected = True
            Me.dgrBC.Rows(0).Activated = True

            Me.HieuChinh()
        End If
    End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub

    Public Sub ThemMoi()
        Me.b = New clsBNguoiDung

        Me.txtTendangnhap.Clear()
        Me.txtMatkhau.Clear()
        Me.cbManv.Clear()
        Me.txtTennhanvien.Clear()
        Me.txtIp.Clear()
        Me.chbAdmin.Checked = False

        Me.txtTendangnhap.ReadOnly = False
        Me.ThemSua = 0
    End Sub

    'Public Sub UltraToolbarsManager1_ToolClick(ByVal sender As Object, ByVal e As ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
    '    Dim key As String = e.Tool.Key
    '    If (StringType.StrCmp(key, "mnuThem", False) = 0) Then
    '        Me.btnThem_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuSua", False) = 0) Then
    '        Me.btnSua_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuXoa", False) = 0) Then
    '        Me.btnXoa_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuLuu", False) = 0) Then
    '        Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuIn", False) = 0) Then
    '        Me.btnIn_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    End If
    'End Sub

    Public Sub XoaDuLieu()
        Try
            Dim obj As New objNguoiDung
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                '1========Neu chi co mot dong duoc chon===============================
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        obj.TenDangNhap = StringType.FromObject(activeRow.Cells.Item("Ten_DangNhap").Value)
                        If Me.b.IsDeleteOK(obj) Then
                            If (MessageBox.Show("Bạn có muốn xoá dòng được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                If Me.b.DeleteInfo(obj) Then
                                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không thể xoá tên đăng nhập " + obj.TenDangNhap + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                    Return
                End If
                '2==============================================
                If (MessageBox.Show(("Bạn muốn xoá " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " dòng đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                '3==========Neu co nhieu dong duoc chon========================================
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    obj.Setnull()
                    obj.TenDangNhap = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("Ten_DangNhap").Value)
                    If Me.b.IsDeleteOK(obj) Then
                        If Me.b.DeleteInfo(obj) Then
                            'MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Else
                            MessageBox.Show("Xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                    Else
                        MessageBox.Show("Không thể xoá tên đăng nhập " + obj.TenDangNhap + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    i += 1
                Loop

            End If


Label_0274:

            Me.methodLoad()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub


    ' Fields
    Friend WithEvents b As clsBNguoiDung
    Friend WithEvents btnLuu As ButtonItem
    Friend WithEvents btnSua As ButtonItem
    Friend WithEvents btnThem As ButtonItem
    Friend WithEvents btnXoa As ButtonItem
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlButton As Panel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents pnlList As Panel
    Friend WithEvents splDetail As CollapsibleSplitter
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents txtTendangnhap As UltraTextEditor
    Friend WithEvents UltraGroupBox1 As UltraGroupBox
    Friend WithEvents UltraTabControl1 As UltraTabControl
    Friend WithEvents UltraTabPageControl1 As UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage1 As UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As XPCaption
    Friend WithEvents XpCaption2 As XPCaption
    Private components As System.ComponentModel.IContainer
    Friend WithEvents txtMatkhau As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTennhanvien As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbManv As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents chbAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btCapquyentruycap As System.Windows.Forms.Button
    Friend WithEvents btCapQuyenClient As System.Windows.Forms.Button
    Public ThemSua As Integer


    Private Sub frmNguoiDung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBNguoiDung
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Dim obj As New objNguoiDung
        obj.ChonBang = 2
        Me.b = New clsBNguoiDung
        Me.cbManv.DataSource = Me.b.LoadDS(obj)
        Me.methodLoad()
    End Sub

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.showGroupinvi()
        Me.ThemMoi()
    End Sub

    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.showGroupinvi()
        Me.HieuChinh()
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
        Me.methodLoad()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
        Me.HieuChinh()
    End Sub


    Private Sub cbManv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbManv.ValueChanged
        Dim obj As New objNguoiDung
        obj.ChonBang = 3
        obj.MaNV = Me.cbManv.Text

        Dim table As DataTable
        Me.b = New clsBNguoiDung
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            Me.txtTennhanvien.Text = table.Rows.Item(0).Item("NV_TEN").ToString
        Else
            Me.txtTennhanvien.Text = ""
        End If
    End Sub

    Private Sub btCapquyentruycap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapquyentruycap.Click
        Dim frm As New frmCapquyen
        frm.txtTendangnhap.Text = Me.txtTendangnhap.Text
        frm.txtManv.Text = Me.cbManv.Text
        frm.txtTennhanvien.Text = Me.txtTennhanvien.Text
        'frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frmNguoiDung_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub txtMatkhau_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatkhau.MouseLeave
        Me.txtMatkhau.PasswordChar() = "*"
    End Sub

    Private Sub txtMatkhau_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMatkhau.MouseMove
        Me.txtMatkhau.PasswordChar() = ""
    End Sub

    Private Sub btCapQuyenClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapQuyenClient.Click
        Dim frm As New frmCapQuyenClient
        frm.txtTendangnhap.Text = Me.txtTendangnhap.Text
        frm.txtManv.Text = Me.cbManv.Text
        frm.txtTennhanvien.Text = Me.txtTennhanvien.Text
        'frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl1.Paint

    End Sub

    Private Sub pnlList_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlList.Paint

    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout

    End Sub
End Class

