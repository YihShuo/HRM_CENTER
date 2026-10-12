<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LoaiBB
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
        Me.btDong = New System.Windows.Forms.Button
        Me.btChon = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbLoaiBB = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'btDong
        '
        Me.btDong.ForeColor = System.Drawing.Color.Blue
        Me.btDong.Location = New System.Drawing.Point(173, 36)
        Me.btDong.Name = "btDong"
        Me.btDong.Size = New System.Drawing.Size(82, 33)
        Me.btDong.TabIndex = 5
        Me.btDong.Text = "Đóng"
        Me.btDong.UseVisualStyleBackColor = True
        '
        'btChon
        '
        Me.btChon.ForeColor = System.Drawing.Color.Blue
        Me.btChon.Location = New System.Drawing.Point(87, 36)
        Me.btChon.Name = "btChon"
        Me.btChon.Size = New System.Drawing.Size(82, 33)
        Me.btChon.TabIndex = 6
        Me.btChon.Text = "Chọn"
        Me.btChon.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(4, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Loại bình bầu :"
        '
        'cbLoaiBB
        '
        Me.cbLoaiBB.FormattingEnabled = True
        Me.cbLoaiBB.Location = New System.Drawing.Point(87, 11)
        Me.cbLoaiBB.Name = "cbLoaiBB"
        Me.cbLoaiBB.Size = New System.Drawing.Size(168, 21)
        Me.cbLoaiBB.TabIndex = 7
        '
        'frm_LoaiBB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(262, 75)
        Me.Controls.Add(Me.cbLoaiBB)
        Me.Controls.Add(Me.btDong)
        Me.Controls.Add(Me.btChon)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_LoaiBB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_LoaiBB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btDong As System.Windows.Forms.Button
    Friend WithEvents btChon As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbLoaiBB As System.Windows.Forms.ComboBox
End Class
