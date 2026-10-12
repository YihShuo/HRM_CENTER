<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSomay12
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
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.btHuy = New System.Windows.Forms.Button
        Me.btOK = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdSomay2 = New System.Windows.Forms.RadioButton
        Me.rdSomay1 = New System.Windows.Forms.RadioButton
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.btHuy)
        Me.UltraTabPageControl1.Controls.Add(Me.btOK)
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(381, 105)
        '
        'btHuy
        '
        Me.btHuy.Location = New System.Drawing.Point(296, 74)
        Me.btHuy.Name = "btHuy"
        Me.btHuy.Size = New System.Drawing.Size(75, 23)
        Me.btHuy.TabIndex = 1
        Me.btHuy.Text = "Hủy"
        Me.btHuy.UseVisualStyleBackColor = True
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(215, 74)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 1
        Me.btOK.Text = "OK"
        Me.btOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdSomay2)
        Me.GroupBox1.Controls.Add(Me.rdSomay1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thay thế số máy"
        '
        'rdSomay2
        '
        Me.rdSomay2.AutoSize = True
        Me.rdSomay2.Location = New System.Drawing.Point(113, 24)
        Me.rdSomay2.Name = "rdSomay2"
        Me.rdSomay2.Size = New System.Drawing.Size(88, 17)
        Me.rdSomay2.TabIndex = 1
        Me.rdSomay2.TabStop = True
        Me.rdSomay2.Text = "QT Số Máy 2"
        Me.rdSomay2.UseVisualStyleBackColor = True
        '
        'rdSomay1
        '
        Me.rdSomay1.AutoSize = True
        Me.rdSomay1.Location = New System.Drawing.Point(14, 24)
        Me.rdSomay1.Name = "rdSomay1"
        Me.rdSomay1.Size = New System.Drawing.Size(88, 17)
        Me.rdSomay1.TabIndex = 0
        Me.rdSomay1.TabStop = True
        Me.rdSomay1.Text = "QT Số Máy 1"
        Me.rdSomay1.UseVisualStyleBackColor = True
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(385, 128)
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thay thế số máy"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(381, 105)
        '
        'frmSomay12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(385, 128)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSomay12"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thay The So May"
        Me.TopMost = True
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdSomay2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdSomay1 As System.Windows.Forms.RadioButton
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents btHuy As System.Windows.Forms.Button
End Class
