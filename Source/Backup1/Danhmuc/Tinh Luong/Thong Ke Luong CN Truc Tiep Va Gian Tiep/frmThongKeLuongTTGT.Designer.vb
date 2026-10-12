<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKeLuongTTGT
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.radLTX = New System.Windows.Forms.RadioButton
        Me.radLTDV = New System.Windows.Forms.RadioButton
        Me.radLTCX = New System.Windows.Forms.RadioButton
        Me.radLCX = New System.Windows.Forms.RadioButton
        Me.radLTCDV = New System.Windows.Forms.RadioButton
        Me.radLCDV = New System.Windows.Forms.RadioButton
        Me.btXem = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.rptBangLuong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 203)
        Me.Panel1.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.radLTX)
        Me.Panel4.Controls.Add(Me.radLTDV)
        Me.Panel4.Controls.Add(Me.radLTCX)
        Me.Panel4.Controls.Add(Me.radLCX)
        Me.Panel4.Controls.Add(Me.radLTCDV)
        Me.Panel4.Controls.Add(Me.radLCDV)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Controls.Add(Me.dtpNgay)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1019, 203)
        Me.Panel4.TabIndex = 1
        '
        'radLTX
        '
        Me.radLTX.AutoSize = True
        Me.radLTX.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLTX.ForeColor = System.Drawing.Color.Blue
        Me.radLTX.Location = New System.Drawing.Point(240, 163)
        Me.radLTX.Name = "radLTX"
        Me.radLTX.Size = New System.Drawing.Size(445, 22)
        Me.radLTX.TabIndex = 11
        Me.radLTX.TabStop = True
        Me.radLTX.Text = "Bảng lương tổng hợp công nhân trực tiếp và gián tiếp theo xưởng"
        Me.radLTX.UseVisualStyleBackColor = True
        '
        'radLTDV
        '
        Me.radLTDV.AutoSize = True
        Me.radLTDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLTDV.ForeColor = System.Drawing.Color.Blue
        Me.radLTDV.Location = New System.Drawing.Point(240, 70)
        Me.radLTDV.Name = "radLTDV"
        Me.radLTDV.Size = New System.Drawing.Size(530, 22)
        Me.radLTDV.TabIndex = 11
        Me.radLTDV.TabStop = True
        Me.radLTDV.Text = "Bảng lương chi tiết lương tổng hợp công nhân trực tiếp và gián tiếp theo đơn vị"
        Me.radLTDV.UseVisualStyleBackColor = True
        '
        'radLTCX
        '
        Me.radLTCX.AutoSize = True
        Me.radLTCX.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLTCX.ForeColor = System.Drawing.Color.Blue
        Me.radLTCX.Location = New System.Drawing.Point(240, 133)
        Me.radLTCX.Name = "radLTCX"
        Me.radLTCX.Size = New System.Drawing.Size(435, 22)
        Me.radLTCX.TabIndex = 10
        Me.radLTCX.TabStop = True
        Me.radLTCX.Text = "Bảng lương tăng ca công nhân trực tiếp và gián tiếp theo xưởng"
        Me.radLTCX.UseVisualStyleBackColor = True
        '
        'radLCX
        '
        Me.radLCX.AutoSize = True
        Me.radLCX.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLCX.ForeColor = System.Drawing.Color.Blue
        Me.radLCX.Location = New System.Drawing.Point(240, 102)
        Me.radLCX.Name = "radLCX"
        Me.radLCX.Size = New System.Drawing.Size(422, 22)
        Me.radLCX.TabIndex = 9
        Me.radLCX.TabStop = True
        Me.radLCX.Text = "Bảng lương chính công nhân trực tiếp và gián tiếp theo xưởng"
        Me.radLCX.UseVisualStyleBackColor = True
        '
        'radLTCDV
        '
        Me.radLTCDV.AutoSize = True
        Me.radLTCDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLTCDV.ForeColor = System.Drawing.Color.Blue
        Me.radLTCDV.Location = New System.Drawing.Point(240, 41)
        Me.radLTCDV.Name = "radLTCDV"
        Me.radLTCDV.Size = New System.Drawing.Size(520, 22)
        Me.radLTCDV.TabIndex = 10
        Me.radLTCDV.TabStop = True
        Me.radLTCDV.Text = "Bảng lương chi tiết lương tăng ca công nhân trực tiếp và gián tiếp theo đơn vị"
        Me.radLTCDV.UseVisualStyleBackColor = True
        '
        'radLCDV
        '
        Me.radLCDV.AutoSize = True
        Me.radLCDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLCDV.ForeColor = System.Drawing.Color.Blue
        Me.radLCDV.Location = New System.Drawing.Point(240, 11)
        Me.radLCDV.Name = "radLCDV"
        Me.radLCDV.Size = New System.Drawing.Size(467, 22)
        Me.radLCDV.TabIndex = 9
        Me.radLCDV.TabStop = True
        Me.radLCDV.Text = "Bảng chi tiết lương chính công nhân trực tiếp và gián tiếp theo đơn vị"
        Me.radLCDV.UseVisualStyleBackColor = True
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(139, 158)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(95, 35)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(128, 71)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(62, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'rptBangLuong
        '
        Me.rptBangLuong.ActiveViewIndex = -1
        Me.rptBangLuong.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptBangLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptBangLuong.DisplayGroupTree = False
        Me.rptBangLuong.Location = New System.Drawing.Point(-3, 209)
        Me.rptBangLuong.Name = "rptBangLuong"
        Me.rptBangLuong.SelectionFormula = ""
        Me.rptBangLuong.Size = New System.Drawing.Size(1019, 461)
        Me.rptBangLuong.TabIndex = 1
        Me.rptBangLuong.ViewTimeSelectionFormula = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptBangLuong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1019, 634)
        Me.Panel2.TabIndex = 11
        '
        'frmThongKeLuongTTGT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 634)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmThongKeLuongTTGT"
        Me.Text = "frmThongKeLuongTTGT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rptBangLuong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents radLTDV As System.Windows.Forms.RadioButton
    Friend WithEvents radLTCDV As System.Windows.Forms.RadioButton
    Friend WithEvents radLCDV As System.Windows.Forms.RadioButton
    Friend WithEvents radLTX As System.Windows.Forms.RadioButton
    Friend WithEvents radLTCX As System.Windows.Forms.RadioButton
    Friend WithEvents radLCX As System.Windows.Forms.RadioButton
End Class
