Imports OpenCvSharp

Module ModCornerDetect

    Private src_gray As New Mat()
    Private MyWindow As Window

    Sub CornerDetectTest()

        Dim src As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadiusRotated.jpg", ImreadModes.Color)

        'Cv2.PyrDown(src, src)

        Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY)

        Cv2.Blur(src_gray, src_gray, New Size(3, 3))

        Dim corners As Point2f() = Cv2.GoodFeaturesToTrack(src_gray, 50, 0.04, 50, New Mat, 10, True, 0.04)

        MyWindow = New Window("Find Corners", WindowMode.AutoSize)

        MyWindow.Image = src

        For i As Integer = 0 To corners.Length - 1

            Dim currentCorner As Point = corners(i)

            Cv2.Circle(src, currentCorner, 3, Scalar.Red, -1)

        Next


        MyWindow.ShowImage(src)

        Cv2.WaitKey(0)

    End Sub


End Module
