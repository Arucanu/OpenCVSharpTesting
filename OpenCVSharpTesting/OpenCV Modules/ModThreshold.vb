Imports OpenCvSharp

Module ModThreshold
    Sub ThresholdTest()
        Dim t As New TestCode()
        t.function()
    End Sub

    ' I did not want to use a lot of static objects so, I put the code
    ' in a user definite class. The code is derived from:
    ' http://docs.opencv.org/2.4/doc/tutorials/imgproc/threshold/threshold.html
    ' This code shows how to program multiple CvTrackbar controls.

    Private Class TestCode
        Private max_BINARY_value As Integer = 255
        Private CvTrackbarValue As CvTrackbar
        Private CvTrackbarType As CvTrackbar
        Private src_gray As New Mat()
        Private dst As New Mat()
        Private MyWindow As Window

        Public Sub [function]()
            Dim threshold_value As Integer = 0
            Dim threshold_type As Integer = 3
            Dim max_value As Integer = 255
            Dim max_type As Integer = 4

            Dim trackbar_type As String = "Type: " & vbLf & " 0: Binary " & vbLf & " 1: Binary Inverted " & vbLf & " 2: Truncate " & vbLf & " 3: To Zero " & vbLf & " 4: To Zero Inverted"
            Dim trackbar_value As String = "Value"

            ' Load an image
            Dim src As New Mat(AppDomain.CurrentDomain.BaseDirectory & "\Resources\Test1.tiff", ImreadModes.Color)

            ' Convert the image to Gray
            Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY)

            ' Create output window
            MyWindow = New Window("Track", WindowMode.AutoSize)

            ' Whenever the user changes the value of any of the Trackbars,
            ' the function Threshold_Demo is called. I needed a common global
            ' window object for Threshold_Demo and Function to prevent a
            ' internal null reference.
            CvTrackbarType = MyWindow.CreateTrackbar(trackbar_type, threshold_type, max_type, AddressOf Threshold_Demo)

            CvTrackbarValue = MyWindow.CreateTrackbar(trackbar_value, threshold_value, max_value, AddressOf Threshold_Demo)

            ' Call the function to initialize
            Threshold_Demo(0, 0)

            ' Wait until user presses escape
            While True

                Dim c As Integer = Cv2.WaitKey(20)

                If c = 27 Then
                    Exit While
                End If

            End While
        End Sub

        Private Sub Threshold_Demo(pos As Integer, userdata As Object)
            ' 0: Binary
            '               1: Binary Inverted
            '               2: Threshold Truncated
            '               3: Threshold to Zero
            '               4: Threshold to Zero Inverted
            '             


            Cv2.Threshold(src_gray, dst, CvTrackbarValue.Pos, max_BINARY_value, DirectCast(CvTrackbarType.Pos, ThresholdTypes))

            Cv2.PyrDown(dst, dst)

            MyWindow.Image = dst

        End Sub
    End Class

End Module