<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportKhamSK
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
        Me.btXem = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txtSothe = New System.Windows.Forms.TextBox
        Me.lbSothe = New System.Windows.Forms.Label
        Me.cbbLoaiBC = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbbDot = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptKSK = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(525, 15)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(100, 25)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtSothe)
        Me.Panel4.Controls.Add(Me.lbSothe)
        Me.Panel4.Controls.Add(Me.cbbLoaiBC)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtNam)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cbbDot)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1070, 89)
        Me.Panel4.TabIndex = 1
        '
        'txtSothe
        '
        Me.txtSothe.Location = New System.Drawing.Point(63, 16)
        Me.txtSothe.Name = "txtSothe"
        Me.txtSothe.Size = New System.Drawing.Size(64, 20)
        Me.txtSothe.TabIndex = 21
        '
        'lbSothe
        '
        Me.lbSothe.AutoSize = True
        Me.lbSothe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSothe.ForeColor = System.Drawing.Color.Blue
        Me.lbSothe.Location = New System.Drawing.Point(3, 16)
        Me.lbSothe.Name = "lbSothe"
        Me.lbSothe.Size = New System.Drawing.Size(56, 16)
        Me.lbSothe.TabIndex = 20
        Me.lbSothe.Text = "Số thẻ:"
        '
        'cbbLoaiBC
        '
        Me.cbbLoaiBC.FormattingEnabled = True
        Me.cbbLoaiBC.Items.AddRange(New Object() {"Danh sách điểm danh khám sức khỏe định kỳ", "Kết quả khám sức khỏe định kỳ", "Thống kê tình hình khám sức khỏe", "Bảng khám sức khỏe cá nhân"})
        Me.cbbLoaiBC.Location = New System.Drawing.Point(263, 15)
        Me.cbbLoaiBC.Name = "cbbLoaiBC"
        Me.cbbLoaiBC.Size = New System.Drawing.Size(256, 21)
        Me.cbbLoaiBC.TabIndex = 19
        Me.cbbLoaiBC.Text = "Danh sách điểm danh khám sức khỏe định kỳ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(154, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Loại báo cáo:"
        '
        'txtNam
        '
        Me.txtNam.Location = New System.Drawing.Point(63, 49)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(64, 20)
        Me.txtNam.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(3, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Năm:"
        '
        'cbbDot
        '
        Me.cbbDot.FormattingEnabled = True
        Me.cbbDot.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbbDot.Location = New System.Drawing.Point(63, 15)
        Me.cbbDot.Name = "cbbDot"
        Me.cbbDot.Size = New System.Drawing.Size(64, 21)
        Me.cbbDot.TabIndex = 15
        Me.cbbDot.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Đợt:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptKSK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1070, 401)
        Me.Panel2.TabIndex = 5
        '
        'rptKSK
        '
        Me.rptKSK.ActiveViewIndex = -1
        Me.rptKSK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptKSK.DisplayGroupTree = False
        Me.rptKSK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptKSK.Location = New System.Drawing.Point(0, 0)
        Me.rptKSK.Name = "rptKSK"
        Me.rptKSK.SelectionFormula = ""
        Me.rptKSK.Size = New System.Drawing.Size(1070, 401)
        Me.rptKSK.TabIndex = 1
        Me.rptKSK.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1070, 89)
        Me.Panel1.TabIndex = 4
        '
        'frmReportKhamSK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1070, 490)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReportKhamSK"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Báo cáo khám sức khỏe"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents rptKSK As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbDot As System.Windows.Forms.ComboBox
    Friend WithEvents cbbLoaiBC As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbSothe As System.Windows.Forms.Label
    Friend WithEvents txtSothe As System.Windows.Forms.TextBox
End Class
