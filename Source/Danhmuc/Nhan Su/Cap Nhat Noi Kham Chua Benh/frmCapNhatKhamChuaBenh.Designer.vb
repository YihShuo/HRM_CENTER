<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapNhatKhamChuaBenh
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapNhatKhamChuaBenh))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btExcel = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.radNgayvao = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radKhuDVC = New System.Windows.Forms.RadioButton
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.dtpNgayvao = New System.Windows.Forms.DateTimePicker
        Me.cbNoiDKKCB = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.lnkDKKCB = New System.Windows.Forms.LinkLabel
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.radDonvi = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.lbNhom = New System.Windows.Forms.Label
        Me.lbToanBo = New System.Windows.Forms.Label
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbNoiDKKCB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Blue
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 488)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.XpCaption2)
        Me.Panel5.Controls.Add(Me.dgrBC)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 151)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(730, 299)
        Me.Panel5.TabIndex = 9
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(728, 34)
        Me.XpCaption2.TabIndex = 4
        Me.XpCaption2.Text = "Danh Sách"
        '
        'dgrBC
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgrBC.DisplayLayout.Appearance = Appearance1
        Me.dgrBC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgrBC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dgrBC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgrBC.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dgrBC.DisplayLayout.MaxColScrollRegions = 1
        Me.dgrBC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrBC.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgrBC.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dgrBC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgrBC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgrBC.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgrBC.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dgrBC.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgrBC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dgrBC.DisplayLayout.Override.RowAppearance = Appearance11
        Me.dgrBC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgrBC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(728, 297)
        Me.dgrBC.TabIndex = 0
        Me.dgrBC.Text = "UltraGrid1"
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtSonhanvien)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.btExcel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 450)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(730, 38)
        Me.Panel4.TabIndex = 8
        '
        'txtSonhanvien
        '
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Red
        Me.txtSonhanvien.Location = New System.Drawing.Point(145, 10)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tổng Nhân Viên :"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(669, 1)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(56, 29)
        Me.btExcel.TabIndex = 0
        Me.btExcel.Text = "Excel"
        Me.btExcel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkall)
        Me.Panel3.Controls.Add(Me.radNgayvao)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.dtpNgayvao)
        Me.Panel3.Controls.Add(Me.cbNoiDKKCB)
        Me.Panel3.Controls.Add(Me.lnkDKKCB)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Controls.Add(Me.radDonvi)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(730, 92)
        Me.Panel3.TabIndex = 5
        '
        'radNgayvao
        '
        Me.radNgayvao.AutoSize = True
        Me.radNgayvao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radNgayvao.Location = New System.Drawing.Point(445, 16)
        Me.radNgayvao.Name = "radNgayvao"
        Me.radNgayvao.Size = New System.Drawing.Size(90, 20)
        Me.radNgayvao.TabIndex = 7
        Me.radNgayvao.TabStop = True
        Me.radNgayvao.Text = "Ngày Vào:"
        Me.radNgayvao.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radKhuDVC)
        Me.GroupBox1.Controls.Add(Me.radTCT)
        Me.GroupBox1.Controls.Add(Me.radKhuB)
        Me.GroupBox1.Controls.Add(Me.radKhuA)
        Me.GroupBox1.Location = New System.Drawing.Point(439, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 39)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'radKhuDVC
        '
        Me.radKhuDVC.AutoSize = True
        Me.radKhuDVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuDVC.Location = New System.Drawing.Point(138, 14)
        Me.radKhuDVC.Name = "radKhuDVC"
        Me.radKhuDVC.Size = New System.Drawing.Size(79, 20)
        Me.radKhuDVC.TabIndex = 3
        Me.radKhuDVC.Text = "Khu DVC"
        Me.radKhuDVC.UseVisualStyleBackColor = True
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Checked = True
        Me.radTCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radTCT.Location = New System.Drawing.Point(223, 14)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(53, 20)
        Me.radTCT.TabIndex = 2
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "TCT"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuB.Location = New System.Drawing.Point(72, 14)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(60, 20)
        Me.radKhuB.TabIndex = 1
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuA.Location = New System.Drawing.Point(6, 14)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(60, 20)
        Me.radKhuA.TabIndex = 0
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'dtpNgayvao
        '
        Me.dtpNgayvao.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgayvao.Enabled = False
        Me.dtpNgayvao.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgayvao.Location = New System.Drawing.Point(541, 16)
        Me.dtpNgayvao.Name = "dtpNgayvao"
        Me.dtpNgayvao.Size = New System.Drawing.Size(85, 20)
        Me.dtpNgayvao.TabIndex = 5
        '
        'cbNoiDKKCB
        '
        Me.cbNoiDKKCB.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbNoiDKKCB.Location = New System.Drawing.Point(102, 51)
        Me.cbNoiDKKCB.Name = "cbNoiDKKCB"
        Me.cbNoiDKKCB.Size = New System.Drawing.Size(331, 21)
        Me.cbNoiDKKCB.TabIndex = 4
        '
        'lnkDKKCB
        '
        Me.lnkDKKCB.AutoSize = True
        Me.lnkDKKCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkDKKCB.Location = New System.Drawing.Point(7, 56)
        Me.lnkDKKCB.Name = "lnkDKKCB"
        Me.lnkDKKCB.Size = New System.Drawing.Size(85, 16)
        Me.lnkDKKCB.TabIndex = 3
        Me.lnkDKKCB.TabStop = True
        Me.lnkDKKCB.Text = "Nơi ĐK_KCB:"
        '
        'cbDonvi
        '
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Location = New System.Drawing.Point(102, 15)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(331, 21)
        Me.cbDonvi.TabIndex = 2
        '
        'radDonvi
        '
        Me.radDonvi.AutoSize = True
        Me.radDonvi.Checked = True
        Me.radDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDonvi.Location = New System.Drawing.Point(27, 16)
        Me.radDonvi.Name = "radDonvi"
        Me.radDonvi.Size = New System.Drawing.Size(68, 20)
        Me.radDonvi.TabIndex = 1
        Me.radDonvi.TabStop = True
        Me.radDonvi.Text = "Đơn Vị:"
        Me.radDonvi.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.XpCaption1)
        Me.Panel2.Controls.Add(Me.lbNhom)
        Me.Panel2.Controls.Add(Me.lbToanBo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(730, 59)
        Me.Panel2.TabIndex = 4
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(728, 34)
        Me.XpCaption1.TabIndex = 3
        Me.XpCaption1.Text = "Cập Nhật Khám Chữa Bệnh"
        '
        'lbNhom
        '
        Me.lbNhom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNhom.AutoSize = True
        Me.lbNhom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbNhom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNhom.Location = New System.Drawing.Point(597, 37)
        Me.lbNhom.Name = "lbNhom"
        Me.lbNhom.Size = New System.Drawing.Size(49, 18)
        Me.lbNhom.TabIndex = 1
        Me.lbNhom.Text = "Nhóm"
        '
        'lbToanBo
        '
        Me.lbToanBo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbToanBo.AutoSize = True
        Me.lbToanBo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbToanBo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbToanBo.Location = New System.Drawing.Point(652, 37)
        Me.lbToanBo.Name = "lbToanBo"
        Me.lbToanBo.Size = New System.Drawing.Size(65, 18)
        Me.lbToanBo.TabIndex = 2
        Me.lbToanBo.Text = "Toàn Bộ"
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(632, 19)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(81, 17)
        Me.chkall.TabIndex = 9
        Me.chkall.Text = "Chọn tất cả"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'frmCapNhatKhamChuaBenh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 488)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCapNhatKhamChuaBenh"
        Me.Text = "frmCapNhatKhamChuaBenh"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbNoiDKKCB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btExcel As System.Windows.Forms.Button
    Friend WithEvents lbToanBo As System.Windows.Forms.Label
    Friend WithEvents lbNhom As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents radDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents dtpNgayvao As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbNoiDKKCB As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lnkDKKCB As System.Windows.Forms.LinkLabel
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radKhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents radNgayvao As System.Windows.Forms.RadioButton
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
End Class
