<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaiting_phepnam
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
        Me.TextBox2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.Label
        Me.Percentcomplete = New Infragistics.Win.UltraWinProgressBar.UltraProgressBar
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.AutoSize = True
        Me.TextBox2.Location = New System.Drawing.Point(317, 53)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(0, 13)
        Me.TextBox2.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.AutoSize = True
        Me.TextBox1.Location = New System.Drawing.Point(29, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(0, 13)
        Me.TextBox1.TabIndex = 7
        '
        'Percentcomplete
        '
        Me.Percentcomplete.Location = New System.Drawing.Point(32, 10)
        Me.Percentcomplete.Name = "Percentcomplete"
        Me.Percentcomplete.Size = New System.Drawing.Size(579, 25)
        Me.Percentcomplete.TabIndex = 6
        Me.Percentcomplete.Text = "[Formatted]"
        Me.Percentcomplete.UseWaitCursor = True
        '
        'frmWaiting_phepnam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 77)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Percentcomplete)
        Me.Name = "frmWaiting_phepnam"
        Me.Text = "Waiting..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.Label
    Friend WithEvents Percentcomplete As Infragistics.Win.UltraWinProgressBar.UltraProgressBar
End Class
