<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaiting
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
        Me.Percentcomplete = New Infragistics.Win.UltraWinProgressBar.UltraProgressBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbNgay = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Percentcomplete
        '
        Me.Percentcomplete.Location = New System.Drawing.Point(12, 29)
        Me.Percentcomplete.Name = "Percentcomplete"
        Me.Percentcomplete.Size = New System.Drawing.Size(456, 23)
        Me.Percentcomplete.TabIndex = 0
        Me.Percentcomplete.Text = "[Formatted]"
        Me.Percentcomplete.UseWaitCursor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(198, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.UseWaitCursor = True
        '
        'lbNgay
        '
        Me.lbNgay.AutoSize = True
        Me.lbNgay.Location = New System.Drawing.Point(12, 59)
        Me.lbNgay.Name = "lbNgay"
        Me.lbNgay.Size = New System.Drawing.Size(0, 13)
        Me.lbNgay.TabIndex = 2
        '
        'frmWaiting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(480, 81)
        Me.Controls.Add(Me.lbNgay)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Percentcomplete)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWaiting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waitting..."
        Me.TopMost = True
        Me.UseWaitCursor = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Percentcomplete As Infragistics.Win.UltraWinProgressBar.UltraProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbNgay As System.Windows.Forms.Label
End Class
