Imports OpenCvSharp

Module ModVideoReadWrite

    Sub VideoReadWriteTest()

        Cv2.NamedWindow("Example Original", WindowMode.AutoSize)
        Cv2.NamedWindow("Example Log_Polar", WindowMode.AutoSize)

        Dim videoPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\SampleVideo_720x480_2mb.mp4"
        Dim writeVideoPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\SampleVideoLogPolar_720x480_2mb.mp4"

        Dim cap As New VideoCapture(videoPath)

        Dim fps As Double = cap.Get(CaptureProperty.Fps)

        Dim frameDelay As Integer = Math.Round(1000 / fps)

        Dim size As New Size(cap.Get(CaptureProperty.FrameWidth), cap.Get(CaptureProperty.FrameHeight))

        Dim writer As New VideoWriter

        writer.Open(writeVideoPath, FourCC.MJPG, fps, size)

        Dim logpolar_frame As New Mat
        Dim bgr_frame As New Mat

        While True

            cap.Read(bgr_frame)

            If (bgr_frame.Empty()) Then

                Return

            End If

            Cv2.ImShow("Example Original", bgr_frame)

            Cv2.LogPolar(bgr_frame, logpolar_frame, New Point2f(bgr_frame.Cols / 2, bgr_frame.Rows / 2), 40, InterpolationFlags.WarpFillOutliers)

            Cv2.ImShow("Example Log_Polar", logpolar_frame)

            writer.Write(logpolar_frame)

            Cv2.WaitKey(frameDelay)

        End While

    End Sub

End Module
