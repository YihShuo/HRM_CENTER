<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaiting_giotangcathang
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
        Me.Percentcomplete = New Infragistics.Win.UltraWinProgressBar.UltraProgressBar
        Me.TextBox1 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Percentcomplete
        '
        Me.Percentcomplete.Location = New System.Drawing.Point(25, 12)
        Me.Percentcomplete.Name = "Percentcomplete"
        Me.Percentcomplete.Size = New System.Drawing.Size(579, 25)
        Me.Percentcomplete.TabIndex = 1
        Me.Percentcomplete.Text = "[Formatted]"
        Me.Percentcomplete.UseWaitCursor = True
        '
        'TextBox1
        '
        Me.TextBox1.AutoSize = True
        Me.TextBox1.Location = New System.Drawing.Point(22, 55)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(13, 13)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "a"
        '
        'TextBox2
        '
        Me.TextBox2.AutoSize = True
        Me.TextBox2.Location = New System.Drawing.Point(310, 55)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(13, 13)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "b"
        '
        'frmWaiting_giotangcathang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 73)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Percentcomplete)
        Me.MaximumSize = New System.Drawing.Size(649, 111)
        Me.Name = "frmWaiting_giotangcathang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "vui lòng đợi một tí"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Percentcomplete As Infragistics.Win.UltraWinProgressBar.UltraProgressBar
    Friend WithEvents TextBox1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.Label
End Class
