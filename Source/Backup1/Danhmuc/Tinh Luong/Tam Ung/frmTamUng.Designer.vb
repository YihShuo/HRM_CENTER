<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTamUng
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTamUng))
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btCapnhat = New System.Windows.Forms.Button
        Me.lbDanhSachTU_X = New System.Windows.Forms.LinkLabel
        Me.btTamUngTongHop = New System.Windows.Forms.LinkLabel
        Me.lbDanhSachTU = New System.Windows.Forms.LinkLabel
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.rdDonvi = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbToanbo = New System.Windows.Forms.Label
        Me.lbNhom = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSonhanvien
        '
        Me.txtSonhanvien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Blue
        Me.txtSonhanvien.Location = New System.Drawing.Point(154, 580)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.btCapnhat)
        Me.Panel2.Controls.Add(Me.lbDanhSachTU_X)
        Me.Panel2.Controls.Add(Me.btTamUngTongHop)
        Me.Panel2.Controls.Add(Me.lbDanhSachTU)
        Me.Panel2.Controls.Add(Me.UltraButton1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSonhanvien)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lbToanbo)
        Me.Panel2.Controls.Add(Me.lbNhom)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(980, 614)
        Me.Panel2.TabIndex = 3
        '
        'btCapnhat
        '
        Me.btCapnhat.Location = New System.Drawing.Point(781, 574)
        Me.btCapnhat.Name = "btCapnhat"
        Me.btCapnhat.Size = New System.Drawing.Size(98, 25)
        Me.btCapnhat.TabIndex = 8
        Me.btCapnhat.Text = "Cập nhật đơn vị"
        Me.btCapnhat.UseVisualStyleBackColor = True
        '
        'lbDanhSachTU_X
        '
        Me.lbDanhSachTU_X.AutoSize = True
        Me.lbDanhSachTU_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDanhSachTU_X.ForeColor = System.Drawing.Color.Blue
        Me.lbDanhSachTU_X.Location = New System.Drawing.Point(381, 15)
        Me.lbDanhSachTU_X.Name = "lbDanhSachTU_X"
        Me.lbDanhSachTU_X.Size = New System.Drawing.Size(245, 17)
        Me.lbDanhSachTU_X.TabIndex = 7
        Me.lbDanhSachTU_X.TabStop = True
        Me.lbDanhSachTU_X.Text = "Danh Sách Tạm Ứng theo Xưởng"
        '
        'btTamUngTongHop
        '
        Me.btTamUngTongHop.AutoSize = True
        Me.btTamUngTongHop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTamUngTongHop.ForeColor = System.Drawing.Color.Blue
        Me.btTamUngTongHop.Location = New System.Drawing.Point(639, 15)
        Me.btTamUngTongHop.Name = "btTamUngTongHop"
        Me.btTamUngTongHop.Size = New System.Drawing.Size(191, 17)
        Me.btTamUngTongHop.TabIndex = 6
        Me.btTamUngTongHop.TabStop = True
        Me.btTamUngTongHop.Text = "Bảng Tạm Ứng Tổng Hợp"
        '
        'lbDanhSachTU
        '
        Me.lbDanhSachTU.AutoSize = True
        Me.lbDanhSachTU.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDanhSachTU.ForeColor = System.Drawing.Color.Blue
        Me.lbDanhSachTU.Location = New System.Drawing.Point(128, 15)
        Me.lbDanhSachTU.Name = "lbDanhSachTU"
        Me.lbDanhSachTU.Size = New System.Drawing.Size(247, 17)
        Me.lbDanhSachTU.TabIndex = 6
        Me.lbDanhSachTU.TabStop = True
        Me.lbDanhSachTU.Text = "Danh Sách Tạm Ứng theo Đơn Vị"
        '
        'UltraButton1
        '
        Me.UltraButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButton1.Location = New System.Drawing.Point(885, 580)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(83, 25)
        Me.UltraButton1.TabIndex = 5
        Me.UltraButton1.Text = "Đóng"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 88)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(956, 484)
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
        Me.dgrBC.Size = New System.Drawing.Size(954, 482)
        Me.dgrBC.TabIndex = 2
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tiền Tạm Ứng"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 583)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tổng số nhân viên"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dtpNgay)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Controls.Add(Me.rdDonvi)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(12, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(956, 48)
        Me.Panel3.TabIndex = 1
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(64, 16)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(106, 22)
        Me.dtpNgay.TabIndex = 10
        '
        'cbDonvi
        '
        Me.cbDonvi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(245, 14)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(572, 24)
        Me.cbDonvi.TabIndex = 4
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'rdDonvi
        '
        Me.rdDonvi.AutoSize = True
        Me.rdDonvi.Checked = True
        Me.rdDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDonvi.ForeColor = System.Drawing.Color.Blue
        Me.rdDonvi.Location = New System.Drawing.Point(176, 15)
        Me.rdDonvi.Name = "rdDonvi"
        Me.rdDonvi.Size = New System.Drawing.Size(74, 22)
        Me.rdDonvi.TabIndex = 3
        Me.rdDonvi.TabStop = True
        Me.rdDonvi.Text = "Đơn vị"
        Me.rdDonvi.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(4, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tháng :"
        '
        'lbToanbo
        '
        Me.lbToanbo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbToanbo.AutoSize = True
        Me.lbToanbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbToanbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbToanbo.Location = New System.Drawing.Point(902, 13)
        Me.lbToanbo.Name = "lbToanbo"
        Me.lbToanbo.Size = New System.Drawing.Size(63, 18)
        Me.lbToanbo.TabIndex = 0
        Me.lbToanbo.Text = "Toàn bộ"
        '
        'lbNhom
        '
        Me.lbNhom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNhom.AutoSize = True
        Me.lbNhom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbNhom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNhom.Location = New System.Drawing.Point(852, 13)
        Me.lbNhom.Name = "lbNhom"
        Me.lbNhom.Size = New System.Drawing.Size(49, 18)
        Me.lbNhom.TabIndex = 0
        Me.lbNhom.Text = "Nhóm"
        '
        'frmTamUng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 614)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTamUng"
        Me.Text = "frmTamUng"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents rdDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbToanbo As System.Windows.Forms.Label
    Friend WithEvents lbNhom As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbDanhSachTU As System.Windows.Forms.LinkLabel
    Friend WithEvents btTamUngTongHop As System.Windows.Forms.LinkLabel
    Friend WithEvents lbDanhSachTU_X As System.Windows.Forms.LinkLabel
    Friend WithEvents btCapnhat As System.Windows.Forms.Button
End Class
