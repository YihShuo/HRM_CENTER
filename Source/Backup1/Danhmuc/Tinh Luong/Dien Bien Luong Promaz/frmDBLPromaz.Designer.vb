<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBLPromaz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBLPromaz))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lbDblCty = New System.Windows.Forms.Label
        Me.radThang = New System.Windows.Forms.RadioButton
        Me.radNam = New System.Windows.Forms.RadioButton
        Me.radA = New System.Windows.Forms.RadioButton
        Me.radB = New System.Windows.Forms.RadioButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.radToanCty = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dtpNgaybatdau = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbToanbo = New System.Windows.Forms.Label
        Me.lbNhom = New System.Windows.Forms.Label
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnIn = New TD.SandBar.ButtonItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.UltraGroupBox3)
        Me.Panel2.Controls.Add(Me.radA)
        Me.Panel2.Controls.Add(Me.radB)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.radToanCty)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lbToanbo)
        Me.Panel2.Controls.Add(Me.lbNhom)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(958, 470)
        Me.Panel2.TabIndex = 4
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.lbDblCty)
        Me.UltraGroupBox3.Controls.Add(Me.radThang)
        Me.UltraGroupBox3.Controls.Add(Me.radNam)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(299, 3)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(414, 23)
        Me.UltraGroupBox3.TabIndex = 22
        '
        'lbDblCty
        '
        Me.lbDblCty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDblCty.AutoSize = True
        Me.lbDblCty.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbDblCty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDblCty.Location = New System.Drawing.Point(6, 1)
        Me.lbDblCty.Name = "lbDblCty"
        Me.lbDblCty.Size = New System.Drawing.Size(228, 16)
        Me.lbDblCty.TabIndex = 10
        Me.lbDblCty.Text = "Xem Diễn Biến Lương Toàn Công Ty:"
        '
        'radThang
        '
        Me.radThang.AutoSize = True
        Me.radThang.Checked = True
        Me.radThang.ForeColor = System.Drawing.Color.Blue
        Me.radThang.Location = New System.Drawing.Point(235, 3)
        Me.radThang.Name = "radThang"
        Me.radThang.Size = New System.Drawing.Size(87, 17)
        Me.radThang.TabIndex = 1
        Me.radThang.TabStop = True
        Me.radThang.Text = "Trong Tháng"
        Me.radThang.UseVisualStyleBackColor = True
        '
        'radNam
        '
        Me.radNam.AutoSize = True
        Me.radNam.ForeColor = System.Drawing.Color.Blue
        Me.radNam.Location = New System.Drawing.Point(328, 2)
        Me.radNam.Name = "radNam"
        Me.radNam.Size = New System.Drawing.Size(78, 17)
        Me.radNam.TabIndex = 2
        Me.radNam.Text = "Trong Năm"
        Me.radNam.UseVisualStyleBackColor = True
        '
        'radA
        '
        Me.radA.AutoSize = True
        Me.radA.Location = New System.Drawing.Point(14, 4)
        Me.radA.Name = "radA"
        Me.radA.Size = New System.Drawing.Size(54, 17)
        Me.radA.TabIndex = 8
        Me.radA.TabStop = True
        Me.radA.Text = "Khu A"
        Me.radA.UseVisualStyleBackColor = True
        '
        'radB
        '
        Me.radB.AutoSize = True
        Me.radB.Location = New System.Drawing.Point(74, 4)
        Me.radB.Name = "radB"
        Me.radB.Size = New System.Drawing.Size(54, 17)
        Me.radB.TabIndex = 7
        Me.radB.TabStop = True
        Me.radB.Text = "Khu B"
        Me.radB.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 106)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(934, 352)
        Me.Panel4.TabIndex = 4
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance4.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(934, 352)
        Me.dgrBC.TabIndex = 2
        '
        'radToanCty
        '
        Me.radToanCty.AutoSize = True
        Me.radToanCty.Location = New System.Drawing.Point(134, 4)
        Me.radToanCty.Name = "radToanCty"
        Me.radToanCty.Size = New System.Drawing.Size(68, 17)
        Me.radToanCty.TabIndex = 6
        Me.radToanCty.TabStop = True
        Me.radToanCty.Text = "Toàn Cty"
        Me.radToanCty.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dtpNgaybatdau)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(12, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(933, 55)
        Me.Panel3.TabIndex = 1
        '
        'dtpNgaybatdau
        '
        Me.dtpNgaybatdau.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgaybatdau.CustomFormat = "MM-yyyy"
        Me.dtpNgaybatdau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgaybatdau.Location = New System.Drawing.Point(52, 18)
        Me.dtpNgaybatdau.Name = "dtpNgaybatdau"
        Me.dtpNgaybatdau.Size = New System.Drawing.Size(117, 22)
        Me.dtpNgaybatdau.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(175, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Đơn vị"
        '
        'cbDonvi
        '
        Me.cbDonvi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(224, 18)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(703, 24)
        Me.cbDonvi.TabIndex = 4
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ngày"
        '
        'lbToanbo
        '
        Me.lbToanbo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbToanbo.AutoSize = True
        Me.lbToanbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbToanbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbToanbo.Location = New System.Drawing.Point(883, 4)
        Me.lbToanbo.Name = "lbToanbo"
        Me.lbToanbo.Size = New System.Drawing.Size(59, 16)
        Me.lbToanbo.TabIndex = 0
        Me.lbToanbo.Text = "Toàn bộ"
        '
        'lbNhom
        '
        Me.lbNhom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNhom.AutoSize = True
        Me.lbNhom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbNhom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNhom.Location = New System.Drawing.Point(833, 4)
        Me.lbNhom.Name = "lbNhom"
        Me.lbNhom.Size = New System.Drawing.Size(44, 16)
        Me.lbNhom.TabIndex = 0
        Me.lbNhom.Text = "Nhóm"
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnIn})
        Me.ToolBar1.Guid = New System.Guid("ab002a63-4662-40c9-b9a7-6743bf17514c")
        Me.ToolBar1.ImageList = Me.ImageList
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(933, 26)
        Me.ToolBar1.TabIndex = 3
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnIn
        '
        Me.btnIn.ImageIndex = 3
        Me.btnIn.Text = "In"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolBar1)
        Me.Panel1.Location = New System.Drawing.Point(13, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(933, 24)
        Me.Panel1.TabIndex = 23
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "0.add.ico")
        Me.ImageList.Images.SetKeyName(1, "1.xoa.ico")
        Me.ImageList.Images.SetKeyName(2, "2.note.ico")
        Me.ImageList.Images.SetKeyName(3, "3.PRINTER.ico")
        Me.ImageList.Images.SetKeyName(4, "4.save.ico")
        Me.ImageList.Images.SetKeyName(5, "5.a91.ico")
        '
        'frmDBLPromaz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 470)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmDBLPromaz"
        Me.Text = "frmDBLPromaz"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbToanbo As System.Windows.Forms.Label
    Friend WithEvents lbNhom As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents dtpNgaybatdau As System.Windows.Forms.DateTimePicker
    Friend WithEvents radA As System.Windows.Forms.RadioButton
    Friend WithEvents radB As System.Windows.Forms.RadioButton
    Friend WithEvents radToanCty As System.Windows.Forms.RadioButton
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbDblCty As System.Windows.Forms.Label
    Friend WithEvents radThang As System.Windows.Forms.RadioButton
    Friend WithEvents radNam As System.Windows.Forms.RadioButton
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btnIn As TD.SandBar.ButtonItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
End Class
