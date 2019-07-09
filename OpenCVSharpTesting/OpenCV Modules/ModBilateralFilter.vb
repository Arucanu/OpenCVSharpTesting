Imports OpenCvSharp

Module ModBilateralFilter

    Sub BilateralFilterTest()

        Cv2.UseOptimized()

        Dim t As New TestCode()

        t.[Function]()

    End Sub


    Private Class TestCode


        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\Bikesgray.jpg"

        Private srcGray As New Mat()
        Private srcFiltered As New Mat()
        Private dst As New Mat()
        Private detectedEdges As New Mat()

        Private edgeThresh As Integer = 1
        Private lowThreshold As Integer
        Private Const maxLowThreshold As Integer = 255

        Private minD As Integer
        Private minKernelSizeColour As Integer
        Private minKernelSizeSpace As Integer
        Private Const maxKernelSize As Integer = 255

        Private ratio As Integer = 3
        Private kernelSize As Integer = 3

        Private filteredWindow As Window
        Private Const filteredWindowName As String = "Bilateral"

        Private cannyWindow As Window
        Private Const cannyWindowName As String = "Canny"


        Private dTrack As CvTrackbar
        Private sigColourTrack As CvTrackbar
        Private sigSpaceTrack As CvTrackbar
        Private cannyTrack As CvTrackbar


        Public Sub [Function]()

            srcGray = Cv2.ImRead(imgPath, ImreadModes.Unchanged)

            ' Convert the image to Gray
            'Cv2.CvtColor(src, srcGray, ColorConversionCodes.BGR2GRAY)

            If srcGray.Empty() Then

                Return

            End If

            srcFiltered.Create(srcGray.Size(), srcGray.Type())
            dst.Create(srcGray.Size(), srcGray.Type())

            ' Create output window
            filteredWindow = New Window(filteredWindowName, WindowMode.AutoSize)

            dTrack = filteredWindow.CreateTrackbar("Neighbourhood:", minD, maxKernelSize, AddressOf CannyThreshold)

            sigColourTrack = filteredWindow.CreateTrackbar("Sigma Colour:", minKernelSizeColour, maxKernelSize, AddressOf CannyThreshold)

            sigSpaceTrack = filteredWindow.CreateTrackbar("Sigma Space:", minKernelSizeSpace, maxKernelSize, AddressOf CannyThreshold)


            cannyWindow = New Window(cannyWindowName, WindowMode.AutoSize)

            cannyTrack = cannyWindow.CreateTrackbar("Min Threshold:", lowThreshold, maxLowThreshold, AddressOf CannyThreshold)


            ' Call the function to initialize
            CannyThreshold(0, 0)

            Cv2.WaitKey(0)

        End Sub


        Private Sub CannyThreshold(pos As Integer, userdata As Object)

            minD = dTrack.Pos
            minKernelSizeColour = sigColourTrack.Pos
            minKernelSizeSpace = sigSpaceTrack.Pos

            Cv2.BilateralFilter(srcGray, srcFiltered, minD, minKernelSizeColour, minKernelSizeSpace)

            Cv2.ImShow(filteredWindowName, srcFiltered)

            lowThreshold = cannyTrack.Pos

            Cv2.Canny(srcFiltered, detectedEdges, lowThreshold, lowThreshold * ratio, kernelSize)

            dst.SetTo(Scalar.Black)

            srcGray.CopyTo(dst, detectedEdges)

            Cv2.ImShow(cannyWindowName, dst)

        End Sub


    End Class
End Module