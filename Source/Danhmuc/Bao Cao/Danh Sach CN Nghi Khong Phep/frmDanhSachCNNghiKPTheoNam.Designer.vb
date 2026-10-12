<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachCNNghiKPTheoNam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhSachCNNghiKPTheoNam))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.bntXem = New Infragistics.Win.Misc.UltraButton
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.dtpNam = New System.Windows.Forms.DateTimePicker
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(421, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Danh Sách Công Nhân Nghỉ Không Phép Theo Năm"
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
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(759, 379)
        Me.dgrBC.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(4, 121)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(761, 381)
        Me.Panel4.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(768, 497)
        Me.Panel2.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox3.Controls.Add(Me.bntXem)
        Me.GroupBox3.Controls.Add(Me.btExcel)
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Controls.Add(Me.dtpNam)
        Me.GroupBox3.Controls.Add(Me.cbXuong)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(761, 92)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Điều kiện lọc dữ liệu"
        '
        'bntXem
        '
        Me.bntXem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bntXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntXem.Location = New System.Drawing.Point(425, 19)
        Me.bntXem.Name = "bntXem"
        Me.bntXem.Size = New System.Drawing.Size(83, 25)
        Me.bntXem.TabIndex = 19
        Me.bntXem.Text = "Xem"
        '
        'btExcel
        '
        Me.btExcel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(425, 49)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(83, 25)
        Me.btExcel.TabIndex = 18
        Me.btExcel.Text = "Xuất Excel"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(56, 48)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(262, 19)
        Me.ProgressBar1.TabIndex = 17
        '
        'dtpNam
        '
        Me.dtpNam.CustomFormat = "yyyy"
        Me.dtpNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNam.Location = New System.Drawing.Point(246, 21)
        Me.dtpNam.Name = "dtpNam"
        Me.dtpNam.Size = New System.Drawing.Size(72, 20)
        Me.dtpNam.TabIndex = 16
        '
        'cbXuong
        '
        Me.cbXuong.Location = New System.Drawing.Point(56, 20)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(144, 22)
        Me.cbXuong.TabIndex = 15
        Me.cbXuong.ValueMember = "X_MA_"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Xưởng"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Năm"
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'frmDanhSachCNNghiKPTheoNam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(768, 497)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmDanhSachCNNghiKPTheoNam"
        Me.Text = "Danh Sach CN Nghi Khong Phep"
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents dtpNam As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bntXem As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
End Class
