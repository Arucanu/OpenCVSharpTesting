Imports OpenCvSharp

Module ModGetSetPixel

    Sub GetSetPixelTest()

        Dim imgPath As String = AppDomain.CurrentDomain.BaseDirectory & "\Resources\generatedGreyPanelVariousHoleRadius.jpg"

        Dim img As Mat = Cv2.ImRead(imgPath, ImreadModes.Unchanged)

        Dim x As Integer = 16
        Dim y As Integer = 32

        Dim intensity As Vec3b = img.At(Of Vec3b)(y, x)

        Console.WriteLine("blue: " + intensity.Item0.ToString)
        Console.WriteLine("green: " + intensity.Item1.ToString)
        Console.WriteLine("red: " + intensity.Item2.ToString)

        Cv2.NamedWindow("Example (original)", WindowMode.AutoSize)
        Cv2.NamedWindow("Example (pixel set)", WindowMode.AutoSize)

        Cv2.ImShow("Example (original)", img)

        intensity.Item0 = 0
        intensity.Item1 = 0
        intensity.Item2 = 255

        img.Set(y, x, intensity)

        x = 17
        y = 33

        img.Set(y, x, intensity)

        x = 18
        y = 34

        img.Set(y, x, intensity)

        Cv2.ImShow("Example (pixel set)", img)

        Cv2.WaitKey(0)

    End Sub

End Module