<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinhLuongChinh_BangGop
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdXuongDT = New System.Windows.Forms.RadioButton
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdXuongDC = New System.Windows.Forms.RadioButton
        Me.btXem = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.rptBangLuong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdXuongDT)
        Me.GroupBox1.Controls.Add(Me.dtpNgay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdXuongDC)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 46)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'rdXuongDT
        '
        Me.rdXuongDT.AutoSize = True
        Me.rdXuongDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdXuongDT.ForeColor = System.Drawing.Color.Blue
        Me.rdXuongDT.Location = New System.Drawing.Point(164, 16)
        Me.rdXuongDT.Name = "rdXuongDT"
        Me.rdXuongDT.Size = New System.Drawing.Size(128, 17)
        Me.rdXuongDT.TabIndex = 12
        Me.rdXuongDT.TabStop = True
        Me.rdXuongDT.Text = "Xưởng Đồng Tháp"
        Me.rdXuongDT.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(70, 13)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'rdXuongDC
        '
        Me.rdXuongDC.AutoSize = True
        Me.rdXuongDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdXuongDC.ForeColor = System.Drawing.Color.Blue
        Me.rdXuongDC.Location = New System.Drawing.Point(318, 16)
        Me.rdXuongDC.Name = "rdXuongDC"
        Me.rdXuongDC.Size = New System.Drawing.Size(82, 17)
        Me.rdXuongDC.TabIndex = 12
        Me.rdXuongDC.TabStop = True
        Me.rdXuongDC.Text = "Xưởng DC"
        Me.rdXuongDC.UseVisualStyleBackColor = True
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(442, 24)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(83, 35)
        Me.btXem.TabIndex = 14
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.rptBangLuong)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1137, 669)
        Me.Panel4.TabIndex = 17
        '
        'rptBangLuong
        '
        Me.rptBangLuong.ActiveViewIndex = -1
        Me.rptBangLuong.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptBangLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptBangLuong.DisplayGroupTree = False
        Me.rptBangLuong.Location = New System.Drawing.Point(0, 91)
        Me.rptBangLuong.Name = "rptBangLuong"
        Me.rptBangLuong.SelectionFormula = ""
        Me.rptBangLuong.Size = New System.Drawing.Size(1136, 577)
        Me.rptBangLuong.TabIndex = 17
        Me.rptBangLuong.ViewTimeSelectionFormula = ""
        '
        'frmTinhLuongChinh_BangGop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 669)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmTinhLuongChinh_BangGop"
        Me.Text = "frmTinhLuongChinh_BangGop"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdXuongDT As System.Windows.Forms.RadioButton
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdXuongDC As System.Windows.Forms.RadioButton
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rptBangLuong As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
