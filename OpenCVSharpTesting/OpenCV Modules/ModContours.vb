Imports OpenCvSharp

Module ModContours

    Private maxBinaryValue As Integer = 255
    Private thresholdValue As Integer = 160
    Private src_gray As New Mat()
    Private src_gray2 As New Mat()
    Private src_binary As New Mat()
    Private src_binary2 As New Mat()
    Private MyWindow As Window

    Sub ContoursTest()


        Dim src As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk2_generatedGreyPanelSingleHoleRadiusRotated.jpg", ImreadModes.Color)
        Dim src2 As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\mk3_generatedGreyPanelVariousHoleShapes_CurvedSidesRotated.jpg", ImreadModes.Color)

        'Cv2.PyrDown(src, src)

        Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY)
        Cv2.CvtColor(src2, src_gray2, ColorConversionCodes.BGR2GRAY)

        'Cv2.Blur(src_gray, src_gray, New Size(3, 3))
        'Cv2.Blur(src_gray, src_gray, New Size(3, 3))

        MyWindow = New Window("Find Contours", WindowMode.AutoSize)

        Cv2.Threshold(src_gray, src_binary, thresholdValue, maxBinaryValue, ThresholdTypes.Binary)
        Cv2.Threshold(src_gray2, src_binary2, thresholdValue, maxBinaryValue, ThresholdTypes.Binary)

        Dim contours As Point()()
        Dim contours2 As Point()()
        Dim contours3 As Point()()

        contours = Cv2.FindContoursAsArray(src_binary, RetrievalModes.List, ContourApproximationModes.ApproxSimple)
        contours2 = Cv2.FindContoursAsArray(src_binary2, RetrievalModes.List, ContourApproximationModes.ApproxSimple)

        src_binary.SetTo(Scalar.Black)

        MyWindow.Image = src_binary

        If Not contours.Length = 0 Then

            Array.Resize(contours, contours.Length - 1)

        End If

        If Not contours2.Length = 0 Then

            Array.Resize(contours2, contours2.Length - 1)

        End If

        contours3 = {contours(contours.GetUpperBound(0)), contours2(contours2.GetUpperBound(0))}

        Console.WriteLine((contours.Length).ToString)
        Console.WriteLine((contours2.Length).ToString)
        Console.WriteLine((contours3.Length).ToString)

        'For i As Integer = 0 To contours.Length - 1

        '    Dim currentContour As Point() = contours(i)
        '    Dim currentContourMoment As Moments = Cv2.Moments(currentContour)
        '    Dim currentContourX As Integer = currentContourMoment.M10 / currentContourMoment.M00
        '    Dim currentContourY As Integer = currentContourMoment.M01 / currentContourMoment.M00
        '    Dim currentContourCentroid As Point = New Point(currentContourX, currentContourY)


        '    If i = contours.Length - 1 Then

        '        Dim area As Double = Cv2.ContourArea(currentContour)

        '    Else

        '        Cv2.Circle(src_binary, currentContourCentroid, 3, Scalar.White, -1)

        '    End If

        'Next

        'Cv2.DrawContours(src_binary, New List(Of Point())(New Point()() {contours(0), contours(contours.Length - 2)}), -1, Scalar.White)
        Cv2.DrawContours(src_binary, contours3, -1, Scalar.White)

        Dim similarity As Double

        Console.WriteLine(Environment.NewLine)

        'For i As Integer = 0 To contours.Length - 1

        '    contours3 = {contours(i), contours2(i)}

        '    similarity = Cv2.MatchShapes(contours3(0), contours3(1), ShapeMatchModes.I1)

        '    Console.WriteLine(similarity.ToString)

        'Next

        contours3 = {contours(contours.GetUpperBound(0)), contours2(contours2.GetUpperBound(0))}

        similarity = Cv2.MatchShapes(contours3(0), contours3(1), ShapeMatchModes.I1)

        Console.WriteLine(similarity.ToString)

        MyWindow.ShowImage(src_binary)

        Cv2.WaitKey(0)


    End Sub


End Module
