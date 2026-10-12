<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinhLuong13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTinhLuong13))
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.lbBangThuong13 = New System.Windows.Forms.LinkLabel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dtpNam = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblDVXUONG = New System.Windows.Forms.Label
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblLuongThuongCaNhan = New System.Windows.Forms.LinkLabel
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.lbToanbo = New System.Windows.Forms.Label
        Me.lbNhom = New System.Windows.Forms.Label
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.rdDV = New System.Windows.Forms.RadioButton
        Me.rdXuong = New System.Windows.Forms.RadioButton
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance1.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 10.0!
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance1
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(786, 212)
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
        'lbBangThuong13
        '
        Me.lbBangThuong13.AutoSize = True
        Me.lbBangThuong13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBangThuong13.Location = New System.Drawing.Point(12, 29)
        Me.lbBangThuong13.Name = "lbBangThuong13"
        Me.lbBangThuong13.Size = New System.Drawing.Size(161, 18)
        Me.lbBangThuong13.TabIndex = 6
        Me.lbBangThuong13.TabStop = True
        Me.lbBangThuong13.Text = "Bảng Thưởng Tháng 13"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 111)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(788, 214)
        Me.Panel4.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.rdXuong)
        Me.Panel3.Controls.Add(Me.rdDV)
        Me.Panel3.Controls.Add(Me.dtpNam)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.lblDVXUONG)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Location = New System.Drawing.Point(12, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(788, 54)
        Me.Panel3.TabIndex = 1
        '
        'dtpNam
        '
        Me.dtpNam.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNam.CustomFormat = "yyyy"
        Me.dtpNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNam.Location = New System.Drawing.Point(82, 16)
        Me.dtpNam.Name = "dtpNam"
        Me.dtpNam.Size = New System.Drawing.Size(89, 22)
        Me.dtpNam.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Năm:"
        '
        'lblDVXUONG
        '
        Me.lblDVXUONG.AutoSize = True
        Me.lblDVXUONG.Location = New System.Drawing.Point(332, 23)
        Me.lblDVXUONG.Name = "lblDVXUONG"
        Me.lblDVXUONG.Size = New System.Drawing.Size(41, 13)
        Me.lblDVXUONG.TabIndex = 5
        Me.lblDVXUONG.Text = "Đơn vị:"
        '
        'cbDonvi
        '
        Me.cbDonvi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(379, 14)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(404, 24)
        Me.cbDonvi.TabIndex = 4
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.txtSonhanvien)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblLuongThuongCaNhan)
        Me.Panel2.Controls.Add(Me.lbBangThuong13)
        Me.Panel2.Controls.Add(Me.btExcel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lbToanbo)
        Me.Panel2.Controls.Add(Me.lbNhom)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(812, 367)
        Me.Panel2.TabIndex = 3
        '
        'txtSonhanvien
        '
        Me.txtSonhanvien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Blue
        Me.txtSonhanvien.Location = New System.Drawing.Point(154, 333)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 336)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Tổng số nhân viên"
        '
        'lblLuongThuongCaNhan
        '
        Me.lblLuongThuongCaNhan.AutoSize = True
        Me.lblLuongThuongCaNhan.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLuongThuongCaNhan.Location = New System.Drawing.Point(188, 29)
        Me.lblLuongThuongCaNhan.Name = "lblLuongThuongCaNhan"
        Me.lblLuongThuongCaNhan.Size = New System.Drawing.Size(226, 18)
        Me.lblLuongThuongCaNhan.TabIndex = 6
        Me.lblLuongThuongCaNhan.TabStop = True
        Me.lblLuongThuongCaNhan.Text = " PhiếuThưởng Tháng 13 Cá Nhân"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(717, 331)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(83, 25)
        Me.btExcel.TabIndex = 5
        Me.btExcel.Text = "Excel"
        '
        'lbToanbo
        '
        Me.lbToanbo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbToanbo.AutoSize = True
        Me.lbToanbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbToanbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbToanbo.Location = New System.Drawing.Point(734, 29)
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
        Me.lbNhom.Location = New System.Drawing.Point(684, 29)
        Me.lbNhom.Name = "lbNhom"
        Me.lbNhom.Size = New System.Drawing.Size(49, 18)
        Me.lbNhom.TabIndex = 0
        Me.lbNhom.Text = "Nhóm"
        '
        'rdDV
        '
        Me.rdDV.AutoSize = True
        Me.rdDV.Location = New System.Drawing.Point(238, 3)
        Me.rdDV.Name = "rdDV"
        Me.rdDV.Size = New System.Drawing.Size(59, 17)
        Me.rdDV.TabIndex = 12
        Me.rdDV.TabStop = True
        Me.rdDV.Text = "Đơn vị "
        Me.rdDV.UseVisualStyleBackColor = True
        '
        'rdXuong
        '
        Me.rdXuong.AutoSize = True
        Me.rdXuong.Location = New System.Drawing.Point(238, 26)
        Me.rdXuong.Name = "rdXuong"
        Me.rdXuong.Size = New System.Drawing.Size(56, 17)
        Me.rdXuong.TabIndex = 13
        Me.rdXuong.TabStop = True
        Me.rdXuong.Text = "Xưởng"
        Me.rdXuong.UseVisualStyleBackColor = True
        '
        'frmTinhLuong13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 367)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmTinhLuong13"
        Me.Text = "Tính Lương Tháng 13"
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents lbBangThuong13 As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbToanbo As System.Windows.Forms.Label
    Friend WithEvents lbNhom As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblDVXUONG As System.Windows.Forms.Label
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpNam As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblLuongThuongCaNhan As System.Windows.Forms.LinkLabel
    Friend WithEvents rdXuong As System.Windows.Forms.RadioButton
    Friend WithEvents rdDV As System.Windows.Forms.RadioButton
End Class
