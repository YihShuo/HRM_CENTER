<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKhoanTruMobivi
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKhoanTruMobivi))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.btnLayDuLieu = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.lblThang = New Infragistics.Win.Misc.UltraLabel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.btnIn = New TD.SandBar.ButtonItem
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.UltraTabControl2.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabControl2
        '
        Me.UltraTabControl2.Controls.Add(Me.btnLayDuLieu)
        Me.UltraTabControl2.Controls.Add(Me.dtpNgay)
        Me.UltraTabControl2.Controls.Add(Me.lblThang)
        Me.UltraTabControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabControl2.Name = "UltraTabControl2"
        Me.UltraTabControl2.Size = New System.Drawing.Size(689, 131)
        '
        'btnLayDuLieu
        '
        Me.btnLayDuLieu.Location = New System.Drawing.Point(151, 62)
        Me.btnLayDuLieu.Name = "btnLayDuLieu"
        Me.btnLayDuLieu.Size = New System.Drawing.Size(135, 28)
        Me.btnLayDuLieu.TabIndex = 10
        Me.btnLayDuLieu.Text = "Lấy dữ liệu từ file Excel"
        Me.btnLayDuLieu.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(151, 24)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(135, 22)
        Me.dtpNgay.TabIndex = 9
        '
        'lblThang
        '
        Appearance17.ForeColor = System.Drawing.Color.Navy
        Appearance17.TextHAlignAsString = "Right"
        Appearance17.TextVAlignAsString = "Middle"
        Me.lblThang.Appearance = Appearance17
        Me.lblThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblThang.Location = New System.Drawing.Point(45, 25)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(100, 23)
        Me.lblThang.TabIndex = 0
        Me.lblThang.Text = "Tháng:"
        '
        'dgrBC
        '
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgrBC.DisplayLayout.Appearance = Appearance7
        Me.dgrBC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.dgrBC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.GroupByBox.Hidden = True
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.dgrBC.DisplayLayout.MaxColScrollRegions = 1
        Me.dgrBC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrBC.DisplayLayout.Override.ActiveCellAppearance = Appearance15
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgrBC.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.dgrBC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgrBC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgrBC.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgrBC.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance14.TextHAlignAsString = "Left"
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgrBC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.dgrBC.DisplayLayout.Override.RowAppearance = Appearance13
        Me.dgrBC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgrBC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance11
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 61)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(693, 46)
        Me.dgrBC.TabIndex = 3
        Me.dgrBC.Text = "UltraGrid1"
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(693, 27)
        Me.XpCaption1.TabIndex = 0
        Me.XpCaption1.Text = "Nhập Liệu"
        '
        'btnIn
        '
        Me.btnIn.ImageIndex = 3
        Me.btnIn.Text = "In"
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnIn})
        Me.ToolBar1.Guid = New System.Guid("ab002a63-4662-40c9-b9a7-6743bf17514c")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 35)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(693, 26)
        Me.ToolBar1.TabIndex = 2
        Me.ToolBar1.Text = "ToolBar1"
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
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveTextColor = System.Drawing.Color.Lime
        Me.XpCaption2.Location = New System.Drawing.Point(0, 8)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(693, 27)
        Me.XpCaption2.TabIndex = 1
        Me.XpCaption2.Text = "Danh Sách"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgrBC)
        Me.Panel2.Controls.Add(Me.ToolBar1)
        Me.Panel2.Controls.Add(Me.XpCaption2)
        Me.Panel2.Controls.Add(Me.splDetail)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(693, 107)
        Me.Panel2.TabIndex = 5
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.Panel1
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(0, 0)
        Me.splDetail.Name = "CollapsibleSplitter1"
        Me.splDetail.TabIndex = 0
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraTabControl1)
        Me.Panel1.Controls.Add(Me.XpCaption1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(693, 181)
        Me.Panel1.TabIndex = 4
        '
        'UltraTabControl1
        '
        Appearance1.BackColor = System.Drawing.Color.AliceBlue
        Appearance1.BackColor2 = System.Drawing.Color.AliceBlue
        Appearance1.ForeColor = System.Drawing.Color.Red
        Me.UltraTabControl1.Appearance = Appearance1
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabControl2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 27)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(693, 154)
        Me.UltraTabControl1.TabIndex = 1
        UltraTab1.TabPage = Me.UltraTabControl2
        UltraTab1.Text = "Thông Tin Nhập Liệu"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(689, 131)
        '
        'frmKhoanTruMobivi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 288)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmKhoanTruMobivi"
        Me.Text = "Khoản trừ Mobivi"
        Me.UltraTabControl2.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents btnIn As TD.SandBar.ButtonItem
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lblThang As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLayDuLieu As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
