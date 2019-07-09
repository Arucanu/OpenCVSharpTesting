Module ModMain



    Sub Main()

        'ApproxPolyTest()       = 1
        'BilateralFilterTest()  = 2
        'BlurTest()             = 3
        'CannyTest()            = 4
        'ContoursTest()         = 5
        'CornerDetectTest()     = 6
        'EnhancedVidReadTest()  = 7
        'GetSetPixelTest()      = 8
        'HoughCirclesTest()     = 9
        'IntroTest()            = 10
        'PyrDownTest()          = 11
        'ReadVideoTest()        = 12
        'ThresholdTest()        = 13
        'VideoReadWriteTest()   = 14

        Dim testVal As Integer = 14

        Select Case testVal

            Case 1
                ApproxPolyTest()
            Case 2
                BilateralFilterTest()
            Case 3
                BlurTest()
            Case 4
                CannyTest()
            Case 5
                ContoursTest()
            Case 6
                CornerDetectTest()
            Case 7
                EnhancedVidReadTest()
            Case 8
                GetSetPixelTest()
            Case 9
                HoughCirclesTest
            Case 10
                IntroTest()
            Case 11
                PyrDownTest()
            Case 12
                ReadVideoTest()
            Case 13
                ThresholdTest()
            Case 14
                VideoReadWriteTest()
        End Select

    End Sub

End Module
