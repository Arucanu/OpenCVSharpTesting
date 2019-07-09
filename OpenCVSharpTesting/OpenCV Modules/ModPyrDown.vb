Imports OpenCvSharp

Module ModPyrDown

    Sub PyrDownTest()

        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\faces.png"

        Dim img As Mat = Cv2.ImRead(imgPath, ImreadModes.Unchanged)

        Cv2.NamedWindow("Example (original)", WindowMode.AutoSize)
        Cv2.NamedWindow("Example (resized)", WindowMode.AutoSize)

        Cv2.ImShow("Example (original)", img)

        Dim imgOut As New Mat

        Cv2.PyrDown(img, imgOut)

        Cv2.ImShow("Example (resized)", imgOut)

        Cv2.WaitKey(0)

    End Sub

End Module