<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachTamUng_X
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btXem = New System.Windows.Forms.Button
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.rptDSTamUng = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btXem)
        Me.GroupBox1.Controls.Add(Me.cbDonvi)
        Me.GroupBox1.Controls.Add(Me.dtpNgay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 50)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(152, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Xưởng :"
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(618, 11)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(95, 35)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(214, 16)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(398, 24)
        Me.cbDonvi.TabIndex = 7
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(72, 17)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'rptDSTamUng
        '
        Me.rptDSTamUng.ActiveViewIndex = -1
        Me.rptDSTamUng.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptDSTamUng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptDSTamUng.DisplayGroupTree = False
        Me.rptDSTamUng.Location = New System.Drawing.Point(0, 89)
        Me.rptDSTamUng.Name = "rptDSTamUng"
        Me.rptDSTamUng.SelectionFormula = ""
        Me.rptDSTamUng.Size = New System.Drawing.Size(1060, 529)
        Me.rptDSTamUng.TabIndex = 1
        Me.rptDSTamUng.ViewTimeSelectionFormula = ""
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1054, 83)
        Me.Panel4.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 83)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptDSTamUng)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 618)
        Me.Panel2.TabIndex = 9
        '
        'frmDanhSachTamUng_X
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 618)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmDanhSachTamUng_X"
        Me.Text = "Danh sách tạm ứng theo xưởng"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents rptDSTamUng As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
