Imports OpenCvSharp

Module ModReadVideo

    Sub ReadVideoTest()

        Dim capPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\tree.avi"

        Cv2.NamedWindow("Example3", WindowMode.AutoSize)

        Dim cap As New VideoCapture

        cap.Open(capPath)

        Dim frame As New Mat

        While (True)

            cap.Read(frame)

            If (frame.Empty()) Then

                Return

            End If

            Cv2.ImShow("Example3", frame)

            Cv2.WaitKey(33)

        End While


    End Sub

End Module
