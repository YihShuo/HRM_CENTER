<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChamCongMain_mss
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
        Me.btnDong = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lsbThongbao = New System.Windows.Forms.ListBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDong
        '
        Me.btnDong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDong.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnDong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDong.Location = New System.Drawing.Point(334, 146)
        Me.btnDong.Name = "btnDong"
        Me.btnDong.Size = New System.Drawing.Size(95, 26)
        Me.btnDong.TabIndex = 3
        Me.btnDong.Text = "Đóng"
        Me.btnDong.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lsbThongbao)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 138)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'lsbThongbao
        '
        Me.lsbThongbao.ForeColor = System.Drawing.Color.Blue
        Me.lsbThongbao.FormattingEnabled = True
        Me.lsbThongbao.Location = New System.Drawing.Point(6, 12)
        Me.lsbThongbao.Name = "lsbThongbao"
        Me.lsbThongbao.ScrollAlwaysVisible = True
        Me.lsbThongbao.Size = New System.Drawing.Size(414, 121)
        Me.lsbThongbao.TabIndex = 0
        '
        'frmChamCongMain_mss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 177)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDong)
        Me.MaximizeBox = False
        Me.Name = "frmChamCongMain_mss"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông báo"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDong As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents lsbThongbao As System.Windows.Forms.ListBox
End Class
