Imports OpenCvSharp

Module ModIntro

    Sub IntroTest()

        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadius.jpg"

        Dim img As Mat = Cv2.ImRead(imgPath, ImreadModes.Unchanged)

        If img.Empty = False Then

            Cv2.NamedWindow("Example1", WindowMode.AutoSize)

            Cv2.PyrDown(img, img)
            Cv2.PyrDown(img, img)
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY)
            'Cv2.Threshold(image, image, 160, 255, ThresholdTypes.Tozero)
            Cv2.GaussianBlur(img, img, New Size(5, 5), 0, 0)

            Cv2.ImShow("Example1", img)

            Cv2.WaitKey(0)

            Cv2.DestroyWindow("Example1")

        End If

    End Sub

End Module
