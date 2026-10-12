<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKeGioTangCaNam
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btXemBCPRExcel = New System.Windows.Forms.Button
        Me.btnXemPromaz = New System.Windows.Forms.Button
        Me.btXem = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptChamcong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1070, 401)
        Me.Panel2.TabIndex = 3
        '
        'rptChamcong
        '
        Me.rptChamcong.ActiveViewIndex = -1
        Me.rptChamcong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptChamcong.DisplayGroupTree = False
        Me.rptChamcong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptChamcong.Location = New System.Drawing.Point(0, 0)
        Me.rptChamcong.Name = "rptChamcong"
        Me.rptChamcong.SelectionFormula = ""
        Me.rptChamcong.Size = New System.Drawing.Size(1070, 401)
        Me.rptChamcong.TabIndex = 1
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btXemBCPRExcel)
        Me.Panel4.Controls.Add(Me.btnXemPromaz)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Controls.Add(Me.dtpNgay)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1070, 89)
        Me.Panel4.TabIndex = 1
        '
        'btXemBCPRExcel
        '
        Me.btXemBCPRExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXemBCPRExcel.ForeColor = System.Drawing.Color.Blue
        Me.btXemBCPRExcel.Location = New System.Drawing.Point(484, 29)
        Me.btXemBCPRExcel.Name = "btXemBCPRExcel"
        Me.btXemBCPRExcel.Size = New System.Drawing.Size(168, 25)
        Me.btXemBCPRExcel.TabIndex = 14
        Me.btXemBCPRExcel.Text = "Xem Khu B"
        Me.btXemBCPRExcel.UseVisualStyleBackColor = True
        '
        'btnXemPromaz
        '
        Me.btnXemPromaz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXemPromaz.ForeColor = System.Drawing.Color.Blue
        Me.btnXemPromaz.Location = New System.Drawing.Point(310, 29)
        Me.btnXemPromaz.Name = "btnXemPromaz"
        Me.btnXemPromaz.Size = New System.Drawing.Size(168, 25)
        Me.btnXemPromaz.TabIndex = 14
        Me.btnXemPromaz.Text = "Xem Khu A"
        Me.btnXemPromaz.UseVisualStyleBackColor = True
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(181, 29)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(123, 25)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Toàn Công Ty"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(100, 30)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(34, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1070, 89)
        Me.Panel1.TabIndex = 2
        '
        'frmThongKeGioTangCaNam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1070, 490)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmThongKeGioTangCaNam"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Chấm Công"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnXemPromaz As System.Windows.Forms.Button
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btXemBCPRExcel As System.Windows.Forms.Button
    Private WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
