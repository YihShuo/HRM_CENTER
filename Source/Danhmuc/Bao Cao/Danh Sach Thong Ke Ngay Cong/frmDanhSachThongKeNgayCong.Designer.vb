<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachThongKeNgayCong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhSachThongKeNgayCong))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnToanBo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnBoChon = New System.Windows.Forms.ToolStripMenuItem
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rptReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ProgressBar1 = New Infragistics.Win.UltraWinProgressBar.UltraProgressBar
        Me.btXemReport = New Infragistics.Win.Misc.UltraButton
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.btXem = New Infragistics.Win.Misc.UltraButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnToanBo, Me.mnBoChon})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 48)
        '
        'mnToanBo
        '
        Me.mnToanBo.Name = "mnToanBo"
        Me.mnToanBo.Size = New System.Drawing.Size(120, 22)
        Me.mnToanBo.Text = "Toàn Bộ"
        '
        'mnBoChon
        '
        Me.mnBoChon.Name = "mnBoChon"
        Me.mnBoChon.Size = New System.Drawing.Size(120, 22)
        Me.mnBoChon.Text = "Bỏ Chọn"
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
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 88)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(945, 498)
        Me.Panel4.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rptReport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(943, 496)
        Me.Panel1.TabIndex = 12
        '
        'rptReport
        '
        Me.rptReport.ActiveViewIndex = -1
        Me.rptReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptReport.DisplayGroupTree = False
        Me.rptReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptReport.Location = New System.Drawing.Point(0, 0)
        Me.rptReport.Name = "rptChamcong"
        Me.rptReport.SelectionFormula = ""
        Me.rptReport.Size = New System.Drawing.Size(941, 494)
        Me.rptReport.TabIndex = 2
        Me.rptReport.ViewTimeSelectionFormula = ""
        '
        'dgrBC
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Me.dgrBC.DisplayLayout.Appearance = Appearance1
        Appearance2.ForeColor = System.Drawing.Color.Red
        UltraGridBand1.Header.Appearance = Appearance2
        Me.dgrBC.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.Red
        Me.dgrBC.DisplayLayout.CaptionAppearance = Appearance3
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(943, 496)
        Me.dgrBC.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 589)
        Me.Panel2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Thông tin lọc dữ liệu:"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.btXemReport)
        Me.Panel3.Controls.Add(Me.btExcel)
        Me.Panel3.Controls.Add(Me.btXem)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.dtpDenNgay)
        Me.Panel3.Controls.Add(Me.dtpTuNgay)
        Me.Panel3.Location = New System.Drawing.Point(12, 23)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(945, 59)
        Me.Panel3.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(651, 15)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(173, 23)
        Me.ProgressBar1.TabIndex = 20
        Me.ProgressBar1.Text = "[Formatted]"
        '
        'btXemReport
        '
        Me.btXemReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btXemReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXemReport.Location = New System.Drawing.Point(454, 14)
        Me.btXemReport.Name = "btXemReport"
        Me.btXemReport.Size = New System.Drawing.Size(114, 25)
        Me.btXemReport.TabIndex = 6
        Me.btXemReport.Text = "Xem Report"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(575, 14)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(70, 25)
        Me.btExcel.TabIndex = 6
        Me.btExcel.Text = "Excel"
        '
        'btXem
        '
        Me.btXem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.Location = New System.Drawing.Point(381, 15)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(68, 25)
        Me.btXem.TabIndex = 6
        Me.btXem.Text = "Xem"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ ngày :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(188, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Đến ngày : "
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(266, 16)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(95, 22)
        Me.dtpDenNgay.TabIndex = 3
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(75, 17)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(95, 22)
        Me.dtpTuNgay.TabIndex = 2
        '
        'frmDanhSachThongKeNgayCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 589)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmDanhSachThongKeNgayCong"
        Me.Text = "frmDanhSachThongKeNgayCong"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnToanBo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnBoChon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btXemReport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btXem As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ProgressBar1 As Infragistics.Win.UltraWinProgressBar.UltraProgressBar
    Public WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents rptReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
