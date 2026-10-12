Public Class clsReportStatus
    Public Event ProgressBarValue(ByVal val As Integer)
    Public Event ctrlVisible(ByVal v As Boolean)
    Public Event mCursor(ByVal myCursor As Windows.Forms.Cursor)
    Private t As System.Threading.Thread
    Private aborting As Boolean = True

    Public ReadOnly Property Running() As Boolean
        Get
            Return Not aborting
        End Get
    End Property

    Public Sub StartThread()
        If aborting Then
            aborting = False
            t = New System.Threading.Thread(AddressOf ReportStatus)
            t.Start()
        End If
    End Sub

    Public Sub StopThread()
        aborting = True
    End Sub

    Private Sub ReportStatus()
        Try
            Dim intPos As Integer = 0
            RaiseEvent mCursor(Cursors.WaitCursor)
            RaiseEvent ProgressBarValue(intPos)
            RaiseEvent ctrlVisible(True)

            Do Until Not Me.Running
                'Do Until intPos = 100
                RaiseEvent ProgressBarValue(intPos)
                System.Threading.Thread.Sleep(500)
                If intPos < 100 Then
                    intPos = intPos + 1
                Else
                    intPos = 1
                End If
                Application.DoEvents()
            Loop

            RaiseEvent ProgressBarValue(1)
            System.Threading.Thread.Sleep(300)
            RaiseEvent ctrlVisible(False)
            RaiseEvent mCursor(Cursors.Default)

        Catch ex As Exception
            RaiseEvent mCursor(Cursors.Default)
            MessageBox.Show(ex.Message)
            RaiseEvent ctrlVisible(False)
            Me.StopThread()
        End Try
    End Sub
End Class