<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThongKeTheomqh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmThongKeTheomqh))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnExcel = New Infragistics.Win.Misc.UltraButton
        Me.btnLocDs = New Infragistics.Win.Misc.UltraButton
        Me.cbMqh = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btXoa = New TD.SandBar.ButtonItem
        Me.btThem = New TD.SandBar.ButtonItem
        Me.btThoat = New TD.SandBar.ButtonItem
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.tabTKgiocongxuong = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTenCN = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtMaCN = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.XpCaption3 = New SteepValley.Windows.Forms.XPCaption
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.dgrBC_mqh = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cbMqh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKgiocongxuong.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtTenCN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaCN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.dgrBC_mqh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(813, 82)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.btnExcel)
        Me.UltraGroupBox1.Controls.Add(Me.btnLocDs)
        Me.UltraGroupBox1.Controls.Add(Me.cbMqh)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(813, 82)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Nhập Liệu"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(523, 19)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(126, 34)
        Me.btnExcel.TabIndex = 8
        Me.btnExcel.Text = "Xuất ExCel"
        '
        'btnLocDs
        '
        Me.btnLocDs.Location = New System.Drawing.Point(347, 19)
        Me.btnLocDs.Name = "btnLocDs"
        Me.btnLocDs.Size = New System.Drawing.Size(126, 34)
        Me.btnLocDs.TabIndex = 7
        Me.btnLocDs.Text = "Lọc Danh Sách"
        '
        'cbMqh
        '
        Me.cbMqh.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbMqh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMqh.Location = New System.Drawing.Point(157, 25)
        Me.cbMqh.Name = "cbMqh"
        Me.cbMqh.Size = New System.Drawing.Size(144, 28)
        Me.cbMqh.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(11, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Chọn Quan Hệ :"
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btXoa, Me.btThem, Me.btThoat})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.Location = New System.Drawing.Point(2, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(634, 24)
        Me.ToolBar1.TabIndex = 16
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btXoa
        '
        Me.btXoa.ImageIndex = 1
        Me.btXoa.Text = "Xóa"
        '
        'btThem
        '
        Me.btThem.ImageIndex = 0
        Me.btThem.Text = "Thêm"
        '
        'btThoat
        '
        Me.btThoat.ImageIndex = 1
        Me.btThoat.Text = "Thoát"
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgrBC.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Appearance2.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 10.0!
        Appearance2.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance2
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 48)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(815, 395)
        Me.dgrBC.TabIndex = 15
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 24)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(815, 24)
        Me.XpCaption2.TabIndex = 12
        Me.XpCaption2.Text = "Danh sách  "
        '
        'tabTKgiocongxuong
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.tabTKgiocongxuong.Appearance = Appearance1
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTKgiocongxuong.Location = New System.Drawing.Point(0, 0)
        Me.tabTKgiocongxuong.Name = "tabTKgiocongxuong"
        Me.tabTKgiocongxuong.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTKgiocongxuong.Size = New System.Drawing.Size(200, 100)
        Me.tabTKgiocongxuong.TabIndex = 0
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(813, 398)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.txtTenCN)
        Me.UltraGroupBox2.Controls.Add(Me.txtMaCN)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(8, 5)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(620, 78)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.Text = "Nhập Liệu"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(63, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tên chi nhánh :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(66, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Mã chi nhánh :"
        '
        'txtTenCN
        '
        Me.txtTenCN.Location = New System.Drawing.Point(147, 47)
        Me.txtTenCN.Multiline = True
        Me.txtTenCN.Name = "txtTenCN"
        Me.txtTenCN.Size = New System.Drawing.Size(177, 21)
        Me.txtTenCN.TabIndex = 3
        '
        'txtMaCN
        '
        Me.txtMaCN.Location = New System.Drawing.Point(147, 22)
        Me.txtMaCN.MaxLength = 5
        Me.txtMaCN.Name = "txtMaCN"
        Me.txtMaCN.Size = New System.Drawing.Size(88, 21)
        Me.txtMaCN.TabIndex = 2
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(196, 77)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(815, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thống Kê Theo Quan Hệ"
        '
        'UltraTabControl1
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.Color.White
        Me.UltraTabControl1.Appearance = Appearance6
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 24)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(815, 103)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.UltraTabControl1.TabIndex = 8
        Appearance7.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance7.BackColor2 = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance7
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thông Tin Nhập Liệu"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(813, 82)
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Nothing
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(0, 127)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 9
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'XpCaption3
        '
        Me.XpCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption3.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption3.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption3.Location = New System.Drawing.Point(0, 135)
        Me.XpCaption3.Name = "XpCaption3"
        Me.XpCaption3.Size = New System.Drawing.Size(815, 24)
        Me.XpCaption3.TabIndex = 10
        Me.XpCaption3.Text = "Danh sách  "
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
        'dgrBC_mqh
        '
        Me.dgrBC_mqh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC_mqh.Location = New System.Drawing.Point(0, 159)
        Me.dgrBC_mqh.Name = "dgrBC_mqh"
        Me.dgrBC_mqh.Size = New System.Drawing.Size(815, 284)
        Me.dgrBC_mqh.TabIndex = 11
        '
        'FrmThongKeTheomqh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 443)
        Me.Controls.Add(Me.dgrBC_mqh)
        Me.Controls.Add(Me.XpCaption3)
        Me.Controls.Add(Me.splDetail)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.XpCaption1)
        Me.Name = "FrmThongKeTheomqh"
        Me.Text = "FrmThongKeTheomqh"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cbMqh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKgiocongxuong.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtTenCN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaCN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.dgrBC_mqh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btXoa As TD.SandBar.ButtonItem
    Friend WithEvents btThem As TD.SandBar.ButtonItem
    Friend WithEvents btThoat As TD.SandBar.ButtonItem
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents tabTKgiocongxuong As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTenCN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMaCN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents XpCaption3 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents cbMqh As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnLocDs As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dgrBC_mqh As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
End Class
