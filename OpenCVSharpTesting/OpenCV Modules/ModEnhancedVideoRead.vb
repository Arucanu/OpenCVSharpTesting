Imports OpenCvSharp

Module ModEnhancedVideoRead


    Sub EnhancedVidReadTest()

        Dim t As New TestCode()
        t.function()

    End Sub


    Private Class TestCode

        Dim sliderPos As Integer = 0
        Dim capRun As Integer = 1
        Dim capDontSet As Integer = 0
        Dim cap As New VideoCapture
        Dim track As CvTrackbar
        Dim myWindow As Window

        Public Sub [function]()

            Dim capPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\test.avi"

            myWindow = New Window("Example2_4", WindowMode.AutoSize)

            cap.Open(capPath)

            Dim frames As Integer = cap.Get(CaptureProperty.FrameCount)
            Dim tmpw As Integer = cap.Get(CaptureProperty.FrameWidth)
            Dim tmph As Integer = cap.Get(CaptureProperty.FrameHeight)

            Console.Write("Video has " + frames.ToString + " frames of dimensions(" + tmpw.ToString + ", " + tmph.ToString + ")." + Environment.NewLine)

            track = myWindow.CreateTrackbar("Position", sliderPos, frames, AddressOf On_Trackbar_Slide)

            On_Trackbar_Slide(0, 0)

            Dim frame As New Mat
            Dim currentPos As Integer

            While (True)

                If capRun <> 0 Then

                    cap.Read(frame)

                    If (frame.Empty()) Then

                        Return

                    End If

                    currentPos = cap.Get(CaptureProperty.PosFrames)

                    capDontSet = 1

                    track.Pos = currentPos

                    myWindow.ShowImage(frame)

                    capRun -= 1

                End If

                currentPos = cap.Get(CaptureProperty.PosFrames)
                cap.Set(CaptureProperty.PosFrames, currentPos)

                Dim c As Integer = Cv2.WaitKey(10)

                If c.Equals(ConsoleKey.S) Then

                    capRun = 1
                    Console.Write("Single step, run = " + capRun.ToString + Environment.NewLine)

                ElseIf c.Equals(ConsoleKey.R) Then

                    capRun = -1
                    Console.Write("Run mode, run = " + capRun.ToString + Environment.NewLine)

                ElseIf c.Equals(ConsoleKey.Escape) Then

                    Return

                End If



            End While

        End Sub


        Private Sub On_Trackbar_Slide(pos As Integer, userData As Object)

            cap.Set(CaptureProperty.PosFrames, pos)

        End Sub


    End Class


End Module