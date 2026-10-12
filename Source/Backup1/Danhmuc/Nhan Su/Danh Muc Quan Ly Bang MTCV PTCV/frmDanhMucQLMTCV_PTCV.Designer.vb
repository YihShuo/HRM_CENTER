<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhMucQLMTCV_PTCV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhMucQLMTCV_PTCV))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.chkTrucTiep = New System.Windows.Forms.CheckBox
        Me.chkTinhTrang = New System.Windows.Forms.CheckBox
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtGhiChu = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtMaNhomCV = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTenNhomCV = New System.Windows.Forms.TextBox
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pnlList = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnThem = New TD.SandBar.ButtonItem
        Me.btnSua = New TD.SandBar.ButtonItem
        Me.btnXoa = New TD.SandBar.ButtonItem
        Me.btXuatExcel = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txtGhiChu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaNhomCV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.chkTrucTiep)
        Me.UltraTabPageControl1.Controls.Add(Me.chkTinhTrang)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl1.Controls.Add(Me.txtGhiChu)
        Me.UltraTabPageControl1.Controls.Add(Me.txtMaNhomCV)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTenNhomCV)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(738, 146)
        '
        'chkTrucTiep
        '
        Me.chkTrucTiep.AutoSize = True
        Me.chkTrucTiep.ForeColor = System.Drawing.Color.Blue
        Me.chkTrucTiep.Location = New System.Drawing.Point(142, 99)
        Me.chkTrucTiep.Name = "chkTrucTiep"
        Me.chkTrucTiep.Size = New System.Drawing.Size(72, 18)
        Me.chkTrucTiep.TabIndex = 34
        Me.chkTrucTiep.Text = "Trực Tiếp"
        Me.chkTrucTiep.UseVisualStyleBackColor = True
        '
        'chkTinhTrang
        '
        Me.chkTinhTrang.AutoSize = True
        Me.chkTinhTrang.Checked = True
        Me.chkTinhTrang.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTinhTrang.Enabled = False
        Me.chkTinhTrang.ForeColor = System.Drawing.Color.Blue
        Me.chkTinhTrang.Location = New System.Drawing.Point(142, 124)
        Me.chkTinhTrang.Name = "chkTinhTrang"
        Me.chkTinhTrang.Size = New System.Drawing.Size(95, 18)
        Me.chkTinhTrang.TabIndex = 34
        Me.chkTinhTrang.Text = "Đang sử dụng"
        Me.chkTinhTrang.UseVisualStyleBackColor = True
        '
        'UltraLabel2
        '
        Appearance6.ForeColor = System.Drawing.Color.Blue
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UltraLabel2.Location = New System.Drawing.Point(7, 44)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(132, 17)
        Me.UltraLabel2.TabIndex = 11
        Me.UltraLabel2.Text = "Tên Nhóm Công Việc :"
        '
        'UltraLabel7
        '
        Appearance5.ForeColor = System.Drawing.Color.Blue
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance5
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UltraLabel7.Location = New System.Drawing.Point(7, 13)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(132, 19)
        Me.UltraLabel7.TabIndex = 11
        Me.UltraLabel7.Text = "Mã Nhóm Công Việc :"
        '
        'UltraLabel3
        '
        Appearance11.ForeColor = System.Drawing.Color.Blue
        Appearance11.TextHAlignAsString = "Center"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UltraLabel3.Location = New System.Drawing.Point(81, 72)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(59, 18)
        Me.UltraLabel3.TabIndex = 28
        Me.UltraLabel3.Text = "Ghi Chú :"
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Location = New System.Drawing.Point(142, 72)
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(244, 21)
        Me.txtGhiChu.TabIndex = 12
        '
        'txtMaNhomCV
        '
        Me.txtMaNhomCV.Location = New System.Drawing.Point(142, 12)
        Me.txtMaNhomCV.MaxLength = 100
        Me.txtMaNhomCV.Name = "txtMaNhomCV"
        Me.txtMaNhomCV.Size = New System.Drawing.Size(244, 21)
        Me.txtMaNhomCV.TabIndex = 12
        '
        'txtTenNhomCV
        '
        Me.txtTenNhomCV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenNhomCV.Location = New System.Drawing.Point(143, 39)
        Me.txtTenNhomCV.Multiline = True
        Me.txtTenNhomCV.Name = "txtTenNhomCV"
        Me.txtTenNhomCV.Size = New System.Drawing.Size(439, 27)
        Me.txtTenNhomCV.TabIndex = 29
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(754, 504)
        Me.UltraGroupBox1.TabIndex = 4
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.Panel1)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 206)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(748, 295)
        Me.pnlList.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgrBC)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 243)
        Me.Panel1.TabIndex = 7
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(748, 243)
        Me.dgrBC.TabIndex = 11
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(748, 52)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnThem, Me.btnSua, Me.btnXoa, Me.btXuatExcel})
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Guid = New System.Guid("ab002a63-4662-40c9-b9a7-6743bf17514c")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(748, 26)
        Me.ToolBar1.TabIndex = 31
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnThem
        '
        Me.btnThem.ImageIndex = 16
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
        'btXuatExcel
        '
        Me.btXuatExcel.ImageIndex = 9
        Me.btXuatExcel.Text = "Xuất Excel"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "doc excel.ico")
        Me.ImageList1.Images.SetKeyName(10, "Delete_16.ICO")
        Me.ImageList1.Images.SetKeyName(11, "quick info.ico")
        Me.ImageList1.Images.SetKeyName(12, "box_checked.ico")
        Me.ImageList1.Images.SetKeyName(13, "box_checked_all.ico")
        Me.ImageList1.Images.SetKeyName(14, "box_checked_all_over.ico")
        Me.ImageList1.Images.SetKeyName(15, "box_checked_over.ico")
        Me.ImageList1.Images.SetKeyName(16, "insert_nhom.ico")
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(748, 26)
        Me.XpCaption2.TabIndex = 30
        Me.XpCaption2.Text = "Danh Sách"
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 198)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.AutoScroll = True
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(748, 198)
        Me.pnlDetail.TabIndex = 1
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 26)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(748, 172)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Appearance1.BackColor = System.Drawing.Color.AliceBlue
        Me.UltraTabControl1.Appearance = Appearance1
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(742, 169)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 1
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thông tin chi tiết"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(738, 146)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(748, 26)
        Me.XpCaption1.TabIndex = 2
        Me.XpCaption1.Text = "Thông tin Danh mục quản lý MTCV, PTCV"
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        '_frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom
        '
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 504)
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.Name = "_frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom"
        Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(754, 0)
        '
        '_frmKhoanCongKhac_Toolbars_Dock_Area_Bottom
        '
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 504)
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.Name = "_frmKhoanCongKhac_Toolbars_Dock_Area_Bottom"
        Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(754, 0)
        '
        '_frmCVNhanVien_Toolbars_Dock_Area_Bottom
        '
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 504)
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.Name = "_frmCVNhanVien_Toolbars_Dock_Area_Bottom"
        Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(754, 0)
        '
        'frmDanhMucQLMTCV_PTCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 504)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me._frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._frmKhoanCongKhac_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._frmCVNhanVien_Toolbars_Dock_Area_Bottom)
        Me.Name = "frmDanhMucQLMTCV_PTCV"
        Me.Text = "frmDanhMucQLMTCV_PTCV"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txtGhiChu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaNhomCV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtMaNhomCV As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTenNhomCV As System.Windows.Forms.TextBox
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btnThem As TD.SandBar.ButtonItem
    Friend WithEvents btnSua As TD.SandBar.ButtonItem
    Friend WithEvents btnXoa As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents grpDetail As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents _frmBangThongKeKyLuat_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmKhoanCongKhac_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmCVNhanVien_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtGhiChu As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkTrucTiep As System.Windows.Forms.CheckBox
    Friend WithEvents chkTinhTrang As System.Windows.Forms.CheckBox
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btXuatExcel As TD.SandBar.ButtonItem
End Class
