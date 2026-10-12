<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoiDangKyKCB
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoiDangKyKCB))
        Dim SpinEditorButton1 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Dim SpinEditorButton2 As Infragistics.Win.UltraWinEditors.SpinEditorButton = New Infragistics.Win.UltraWinEditors.SpinEditorButton
        Me.btDong = New TD.SandBar.ButtonItem
        Me.btSua = New TD.SandBar.ButtonItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.bntKiemTraST = New TD.SandBar.ToolBar
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.btXoa = New TD.SandBar.ButtonItem
        Me.ButtonItem1 = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTen = New System.Windows.Forms.TextBox
        Me.txtMa = New System.Windows.Forms.TextBox
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpThangNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDonviNV = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.dtpThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btDong
        '
        Me.btDong.ImageIndex = 9
        Me.btDong.Text = "Thoát"
        '
        'btSua
        '
        Me.btSua.ImageIndex = 1
        Me.btSua.Tag = "19"
        Me.btSua.Text = "Sửa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(20, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tên bệnh viện :"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(936, 523)
        Me.UltraGroupBox1.TabIndex = 30
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC2)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 113)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(930, 407)
        Me.pnlList.TabIndex = 5
        '
        'dgrBC2
        '
        Me.dgrBC2.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance4.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC2.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.dgrBC2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag
        Me.dgrBC2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC2.ImageList = Me.si_Grid
        Me.dgrBC2.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC2.Name = "dgrBC2"
        Me.dgrBC2.Size = New System.Drawing.Size(930, 349)
        Me.dgrBC2.TabIndex = 8
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.bntKiemTraST)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(930, 58)
        Me.pnlButton.TabIndex = 7
        '
        'bntKiemTraST
        '
        Me.bntKiemTraST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntKiemTraST.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnLuu, Me.btSua, Me.btXoa, Me.btDong, Me.ButtonItem1})
        Me.bntKiemTraST.Dock = System.Windows.Forms.DockStyle.None
        Me.bntKiemTraST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntKiemTraST.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.bntKiemTraST.ImageList = Me.ImageList1
        Me.bntKiemTraST.Location = New System.Drawing.Point(1, 27)
        Me.bntKiemTraST.Name = "bntKiemTraST"
        Me.bntKiemTraST.Size = New System.Drawing.Size(928, 26)
        Me.bntKiemTraST.TabIndex = 17
        Me.bntKiemTraST.Text = "ToolBar1"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 4
        Me.btnLuu.Tag = "18"
        Me.btnLuu.Text = "Lưu"
        '
        'btXoa
        '
        Me.btXoa.ImageIndex = 2
        Me.btXoa.Tag = "20"
        Me.btXoa.Text = "Xóa"
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
        Me.ImageList1.Images.SetKeyName(10, "document_accept.png")
        '
        'XpCaption2
        '
        Me.XpCaption2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(930, 28)
        Me.XpCaption2.TabIndex = 16
        Me.XpCaption2.Text = "Danh sách nơi đăng ký khám chữa bệnh"
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 105)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 15
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlDetail.Controls.Add(Me.GroupBox1)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(930, 105)
        Me.pnlDetail.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTen)
        Me.GroupBox1.Controls.Add(Me.txtMa)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 77)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(23, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Mã bệnh viện :"
        '
        'txtTen
        '
        Me.txtTen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTen.HideSelection = False
        Me.txtTen.Location = New System.Drawing.Point(105, 46)
        Me.txtTen.Multiline = True
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(426, 23)
        Me.txtTen.TabIndex = 12
        '
        'txtMa
        '
        Me.txtMa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMa.HideSelection = False
        Me.txtMa.Location = New System.Drawing.Point(105, 19)
        Me.txtMa.Name = "txtMa"
        Me.txtMa.Size = New System.Drawing.Size(98, 21)
        Me.txtMa.TabIndex = 4
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(930, 28)
        Me.XpCaption1.TabIndex = 1
        Me.XpCaption1.Text = "Nơi đăng ký khám chữa bệnh"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Đơn vị"
        '
        'dtpThangNV
        '
        SpinEditorButton1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThangNV.ButtonsRight.Add(SpinEditorButton1)
        Me.dtpThangNV.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThangNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThangNV.Location = New System.Drawing.Point(154, 14)
        Me.dtpThangNV.Name = "dtpThangNV"
        Me.dtpThangNV.Size = New System.Drawing.Size(128, 21)
        Me.dtpThangNV.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Tháng tính:"
        '
        'cboDonviNV
        '
        Me.cboDonviNV.AlwaysInEditMode = True
        Me.cboDonviNV.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboDonviNV.DisplayMember = "DV_TEN"
        Me.cboDonviNV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDonviNV.Location = New System.Drawing.Point(343, 14)
        Me.cboDonviNV.Name = "cboDonviNV"
        Me.cboDonviNV.Size = New System.Drawing.Size(293, 22)
        Me.cboDonviNV.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue
        Me.cboDonviNV.TabIndex = 29
        Me.cboDonviNV.ValueMember = "DV_MA"
        '
        '_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom
        '
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 523)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Name = "_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom"
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(936, 0)
        '
        'dtpThang
        '
        SpinEditorButton2.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dtpThang.ButtonsRight.Add(SpinEditorButton2)
        Me.dtpThang.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.dtpThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.dtpThang.Location = New System.Drawing.Point(97, 12)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(128, 21)
        Me.dtpThang.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tháng:"
        '
        'frmNoiDangKyKCB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 523)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom)
        Me.Name = "frmNoiDangKyKCB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNoiDangKyKCB"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtpThangNV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDonviNV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btDong As TD.SandBar.ButtonItem
    Friend WithEvents btSua As TD.SandBar.ButtonItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents dgrBC2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents bntKiemTraST As TD.SandBar.ToolBar
    Friend WithEvents btnLuu As TD.SandBar.ButtonItem
    Friend WithEvents btXoa As TD.SandBar.ButtonItem
    Friend WithEvents ButtonItem1 As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents txtMa As System.Windows.Forms.TextBox
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpThangNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDonviNV As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents _frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents dtpThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
