Imports OpenCvSharp

Module ModBlur

    Sub BlurTest()

        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\faceTemplate.jpg"

        Dim img As Mat = Cv2.ImRead(imgPath, ImreadModes.Unchanged)

        Cv2.NamedWindow("Example Blur (in)", WindowMode.AutoSize)
        Cv2.NamedWindow("Example Blur (out)", WindowMode.AutoSize)

        Cv2.ImShow("Example Blur (in)", img)

        Dim imgOut As New Mat

        Dim kernelSize As Size

        kernelSize.Height = 5
        kernelSize.Width = 5

        Cv2.GaussianBlur(img, imgOut, kernelSize, 3, 3)
        Cv2.GaussianBlur(imgOut, imgOut, kernelSize, 3, 3)

        Cv2.ImShow("Example Blur (out)", imgOut)

        Cv2.WaitKey(0)

    End Sub

End Module
