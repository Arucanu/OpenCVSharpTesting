Imports OpenCvSharp

Module ModApproxPoly

    Private maxBinaryValue As Integer = 255
    Private thresholdValue As Integer = 160
    Private src_gray As New Mat()
    Private src_gray2 As New Mat()
    Private src_binary As New Mat()
    Private src_binary2 As New Mat()

    Sub ApproxPolyTest()


        Dim src As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadius.jpg", ImreadModes.Color)
        Dim src2 As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadiusRotated.jpg", ImreadModes.Color)

        'Cv2.PyrDown(src, src)

        Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY)
        Cv2.CvtColor(src2, src_gray2, ColorConversionCodes.BGR2GRAY)

        'Cv2.Blur(src_gray, src_gray, New Size(3, 3))
        'Cv2.Blur(src_gray, src_gray, New Size(3, 3))


        Cv2.Threshold(src_gray, src_binary, thresholdValue, maxBinaryValue, ThresholdTypes.Binary)
        Cv2.Threshold(src_gray2, src_binary2, thresholdValue, maxBinaryValue, ThresholdTypes.Binary)

        Dim contours As Point()()
        Dim contours2 As Point()()

        contours = Cv2.FindContoursAsArray(src_binary, RetrievalModes.List, ContourApproximationModes.ApproxSimple)
        contours2 = Cv2.FindContoursAsArray(src_binary2, RetrievalModes.List, ContourApproximationModes.ApproxSimple)

        If Not contours.Length = 0 Then

            Array.Resize(contours, contours.Length - 1)

        End If

        If Not contours2.Length = 0 Then

            Array.Resize(contours2, contours2.Length - 1)

        End If

        Dim contoursApprox As Point() = Cv2.ApproxPolyDP(contours(contours.GetUpperBound(0)), 20, True)
        Dim contours2Approx As Point() = Cv2.ApproxPolyDP(contours2(contours2.GetUpperBound(0)), 20, True)

        Cv2.DrawContours(src, New Point()() {contoursApprox}, -1, Scalar.Red)
        Cv2.DrawContours(src2, New Point()() {contours2Approx}, -1, Scalar.Red)

        Dim similarity As Double

        similarity = Cv2.MatchShapes(contoursApprox, contours2Approx, ShapeMatchModes.I1)

        Console.WriteLine(similarity.ToString)

        Cv2.ImShow("contour approx", src)
        Cv2.ImShow("contour2 approx", src2)

        Cv2.WaitKey(0)


    End Sub


End Module
