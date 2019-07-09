Imports OpenCvSharp
Imports System.Math

Module ModHoughCircles

    Sub HoughCirclesTest()

        Cv2.UseOptimized()

        Dim srcPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\punchedHolesCarpetNoFlash.jpg"

        Dim src As Mat
        Dim image As New Mat

        src = Cv2.ImRead(srcPath, ImreadModes.Unchanged)

        If src.Empty Then

            Console.WriteLine("Could Not load" + src.ToString)
            Exit Sub

        End If

        'Cv2.PyrDown(src, src)
        Cv2.PyrDown(src, src)
        Cv2.CvtColor(src, image, ColorConversionCodes.BGR2GRAY)
        'Cv2.Threshold(image, image, 160, 255, ThresholdTypes.Tozero)
        Cv2.GaussianBlur(image, image, New Size(5, 5), 0, 0)
        'Cv2.GaussianBlur(image, image, New Size(5, 5), 0, 0)
        'Cv2.GaussianBlur(image, image, New Size(5, 5), 0, 0)

        Cv2.ImShow("image", image)

        Dim circles As CircleSegment()

        circles = Cv2.HoughCircles(image, HoughMethods.Gradient, 4, 150, 160, 100, 20, 40)

        If circles.Length > 0 Then

            For i As Integer = 0 To circles.Length() - 1

                Cv2.Circle(src, Round(circles(i).Center.X), Round(circles(i).Center.Y), Round(circles(i).Radius), New Scalar(0, 0, 255), 2, LineTypes.AntiAlias)

            Next

            Cv2.ImShow("Hough Circles Test", src)

            Cv2.WaitKey(0)

        Else

            Console.WriteLine("Could not find circles in image!")
            Console.ReadKey()

        End If


    End Sub

End Module