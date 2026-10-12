Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Class frmStatus
    Inherits Form
    ' Methods
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal Fwidth As Integer, ByVal Fheight As Integer)
        Me.InitializeComponent()
        Dim size As New Size(Fwidth, Fheight)
        Me.Size = New System.Drawing.Size
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label
        Me.picLoad = New System.Windows.Forms.PictureBox
        CType(Me.picLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(0, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(280, 38)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picLoad
        '
        Me.picLoad.Location = New System.Drawing.Point(66, 0)
        Me.picLoad.Name = "picLoad"
        Me.picLoad.Size = New System.Drawing.Size(152, 16)
        Me.picLoad.TabIndex = 7
        Me.picLoad.TabStop = False
        '
        'frmStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(283, 60)
        Me.ControlBox = False
        Me.Controls.Add(Me.picLoad)
        Me.Controls.Add(Me.lblStatus)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status process"
        Me.TopMost = True
        CType(Me.picLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Overloads Sub Show(ByVal Message As String)
        Me.lblStatus.Text = Message
        Me.Show()
        Application.DoEvents()
    End Sub

    Public Overloads Sub ShowDialog(ByVal Message As String)
        Me.lblStatus.Text = Message
        Me.Show()
        Application.DoEvents()
    End Sub



    ' Fields
    Friend WithEvents lblStatus As Label
    Friend WithEvents picLoad As PictureBox
    Public components As IContainer
End Class


