Imports OpenCvSharp

Module ModCanny
    Sub CannyTest()
        Dim t As New TestCode()
        t.[Function]()
    End Sub


    Private Class TestCode


        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadius.jpg"

        Private srcGray As New Mat()
        Private dst As New Mat()
        Private detectedEdges As New Mat()

        Private edgeThresh As Integer = 1
        Private lowThreshold As Integer
        Private Const maxLowThreshold As Integer = 300
        Private ratio As Integer = 3
        Private kernelSize As Integer = 3

        Private namedWindow As Window
        Private Const windowName As String = "Edge Map"

        Private track As CvTrackbar


        Public Sub [Function]()

            srcGray = Cv2.ImRead(imgPath, ImreadModes.Unchanged)
            'Cv2.PyrDown(srcGray, srcGray)
            Cv2.PyrDown(srcGray, srcGray)

            ' Convert the image to Gray
            'Cv2.CvtColor(src, srcGray, ColorConversionCodes.BGR2GRAY)

            If srcGray.Empty() Then

                Return

            End If

            dst.Create(srcGray.Size(), srcGray.Type())

            ' Create output window
            namedWindow = New Window(windowName, WindowMode.AutoSize)

            namedWindow.CreateTrackbar("Min Threshold:", lowThreshold, maxLowThreshold, AddressOf CannyThreshold)

            ' Call the function to initialize
            CannyThreshold(0, 0)

            Cv2.WaitKey(0)

        End Sub


        Private Sub CannyThreshold(pos As Integer, userdata As Object)

            lowThreshold = pos

            srcGray.Blur(New Size(3, 3))

            Cv2.Canny(srcGray, detectedEdges, lowThreshold, lowThreshold * ratio, kernelSize)

            dst.SetTo(Scalar.Black)

            srcGray.CopyTo(dst, detectedEdges)

            Cv2.ImShow(windowName, dst)

        End Sub


    End Class
End Module
