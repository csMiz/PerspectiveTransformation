Public Class Form1

    Public SelectedPointIndex As Integer = -1
    Public ControlPoints(3) As PointF
    Public MouseDownFlag As Byte = 0
    Public SourcePos As Point

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'testM()
        'Return

        PSource.Image = New Bitmap(Application.StartupPath & "\test.jpg")
        ControlPoints(0) = New PointF(0, 800)
        ControlPoints(1) = New PointF(1000, 800)
        ControlPoints(2) = New PointF(0, 0)
        ControlPoints(3) = New PointF(1000, 0)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SelectedPointIndex = -1 Then
            PSource.Visible = False
        End If
        SelectedPointIndex += 1
        If SelectedPointIndex = 4 Then
            SelectedPointIndex = 0
        End If
        Call PaintTrans()

    End Sub

    Public Sub PaintTrans()
        Dim points(3) As KeyValuePair(Of PointF, PointF)
        points(0) = New KeyValuePair(Of PointF, PointF)(New PointF(0, 800), ControlPoints(0))
        points(1) = New KeyValuePair(Of PointF, PointF)(New PointF(1000, 800), ControlPoints(1))
        points(2) = New KeyValuePair(Of PointF, PointF)(New PointF(0, 0), ControlPoints(2))
        points(3) = New KeyValuePair(Of PointF, PointF)(New PointF(1000, 0), ControlPoints(3))
        Dim matrix As Double() = CalculateMatrix(points)
        Dim sourceImage As Bitmap = PSource.Image
        Dim transImage As New Bitmap(1000, 800)
        For j = 0 To 799
            For i = 0 To 999
                Dim tx As Double = matrix(0) * i + matrix(3) * j + matrix(6)
                Dim ty As Double = matrix(1) * i + matrix(4) * j + matrix(7)
                Dim tw As Double = matrix(2) * i + matrix(5) * j + 1
                Dim dx As Integer = CInt(tx / tw)
                Dim dy As Integer = CInt(ty / tw)
                If dx >= 0 AndAlso dx < 1000 AndAlso dy >= 0 AndAlso dy < 800 Then
                    transImage.SetPixel(dx, dy, sourceImage.GetPixel(i, j))
                End If
            Next
        Next
        P.Image = transImage
        P.Refresh()
        Debug.WriteLine("ok")
    End Sub

    Public Function CalculateMatrix(input() As KeyValuePair(Of PointF, PointF)) As Double()
        Dim x0 As Double = input(0).Key.X
        Dim y0 As Double = input(0).Key.Y
        Dim x1 As Double = input(0).Value.X
        Dim y1 As Double = input(0).Value.Y
        Dim x2 As Double = input(1).Key.X
        Dim y2 As Double = input(1).Key.Y
        Dim x3 As Double = input(1).Value.X
        Dim y3 As Double = input(1).Value.Y
        Dim x4 As Double = input(2).Key.X
        Dim y4 As Double = input(2).Key.Y
        Dim x5 As Double = input(2).Value.X
        Dim y5 As Double = input(2).Value.Y
        Dim x6 As Double = input(3).Key.X
        Dim y6 As Double = input(3).Key.Y
        Dim x7 As Double = input(3).Value.X
        Dim y7 As Double = input(3).Value.Y

        Dim args(71) As Double
        args(0) = x0
        args(1) = 0
        args(2) = -x0 * x1
        args(3) = y0
        args(4) = 0
        args(5) = -x1 * y0
        args(6) = 1
        args(7) = 0
        args(8) = x1

        args(9) = 0
        args(10) = x0
        args(11) = -x0 * y1
        args(12) = 0
        args(13) = y0
        args(14) = -y0 * y1
        args(15) = 0
        args(16) = 1
        args(17) = y1

        args(18) = x2
        args(19) = 0
        args(20) = -x2 * x3
        args(21) = y2
        args(22) = 0
        args(23) = -x3 * y2
        args(24) = 1
        args(25) = 0
        args(26) = x3

        args(27) = 0
        args(28) = x2
        args(29) = -x2 * y3
        args(30) = 0
        args(31) = y2
        args(32) = -y2 * y3
        args(33) = 0
        args(34) = 1
        args(35) = y3

        args(36) = x4
        args(37) = 0
        args(38) = -x4 * x5
        args(39) = y4
        args(40) = 0
        args(41) = -x5 * y4
        args(42) = 1
        args(43) = 0
        args(44) = x5

        args(45) = 0
        args(46) = x4
        args(47) = -x4 * y5
        args(48) = 0
        args(49) = y4
        args(50) = -y4 * y5
        args(51) = 0
        args(52) = 1
        args(53) = y5

        args(54) = x6
        args(55) = 0
        args(56) = -x6 * x7
        args(57) = y6
        args(58) = 0
        args(59) = -x7 * y6
        args(60) = 1
        args(61) = 0
        args(62) = x7

        args(63) = 0
        args(64) = x6
        args(65) = -x6 * y7
        args(66) = 0
        args(67) = y6
        args(68) = -y6 * y7
        args(69) = 0
        args(70) = 1
        args(71) = y7

        Dim matrix As Double() = Gauss_Jordan_Elimination(8, args)
        For j = 0 To 2
            For i = 0 To 2
                If i = 2 AndAlso j = 2 Then
                    Debug.Write("1")
                Else
                    Debug.Write(CSng(matrix(i + j * 3)) & " , ")
                End If
            Next
            Debug.Write(vbCrLf)
        Next

        Return matrix
    End Function

    Public Sub TestM()
        Dim points(3) As KeyValuePair(Of PointF, PointF)
        points(0) = New KeyValuePair(Of PointF, PointF)(New PointF(0, 1), New PointF(0, 1))
        points(1) = New KeyValuePair(Of PointF, PointF)(New PointF(1, 1), New PointF(0.5, 1))
        points(2) = New KeyValuePair(Of PointF, PointF)(New PointF(0, 0), New PointF(0, 0))
        points(3) = New KeyValuePair(Of PointF, PointF)(New PointF(1, 0), New PointF(1, 0))

        CalculateMatrix(points)

    End Sub

    Public Sub TestGE()
        Dim args(11) As Double
        args(0) = 1
        args(1) = 2
        args(2) = 3
        args(3) = 28
        args(4) = 2
        args(5) = 1
        args(6) = 1
        args(7) = 12
        args(8) = 4
        args(9) = 5
        args(10) = 2
        args(11) = 33
        Dim result As Double() = Gauss_Jordan_Elimination(3, args)
        Debug.Assert(CSng(result(0)) = 1 AndAlso CSng(result(1)) = 3 AndAlso CSng(result(2)) = 7)

        'For Each value As Double In result
        '    Debug.Write(value & " , ")
        'Next
        'Debug.Write(vbCrLf)

    End Sub

    Public Function Gauss_Jordan_Elimination(varCount As Integer, args() As Double) As Double()
        '读取系数
        Dim matrix_x As Integer = varCount + 1
        Dim matrix_y As Integer = varCount
        Dim equations(matrix_x - 1, matrix_y - 1) As Double
        Dim readIndex As Integer = 0
        For j = 0 To matrix_y - 1
            For i = 0 To matrix_x - 1
                equations(i, j) = args(readIndex)
                readIndex += 1
            Next
        Next
        '计算
        For totalLoopIndex = 0 To matrix_y - 2
            If equations(totalLoopIndex, totalLoopIndex) = 0 Then
                For elseLine = totalLoopIndex + 1 To matrix_y - 1
                    If equations(totalLoopIndex, elseLine) <> 0 Then
                        '交换两行
                        Dim tmpLine(matrix_x - 1) As Double
                        For i = 0 To matrix_x - 1
                            tmpLine(i) = equations(i, totalLoopIndex)
                        Next
                        For i = 0 To matrix_x - 1
                            equations(i, totalLoopIndex) = equations(i, elseLine)
                        Next
                        For i = 0 To matrix_x - 1
                            equations(i, elseLine) = tmpLine(i)
                        Next
                        Exit For
                    End If
                Next
            End If
            '系数归一
            For lineIndex = totalLoopIndex To matrix_y - 1
                Dim div As Double = equations(totalLoopIndex, lineIndex)
                If div <> 0 AndAlso div <> 1 Then
                    For factorIndex = totalLoopIndex To matrix_x - 1
                        equations(factorIndex, lineIndex) /= div
                    Next
                End If
            Next
            '消元
            For lineIndex = totalLoopIndex + 1 To matrix_y - 1
                If equations(totalLoopIndex, lineIndex) <> 0 Then
                    For factorIndex = totalLoopIndex To matrix_x - 1
                        equations(factorIndex, lineIndex) -= equations(factorIndex, totalLoopIndex)
                    Next
                End If
            Next
        Next

        Dim result(varCount - 1) As Double
        result(varCount - 1) = equations(matrix_x - 1, matrix_y - 1) / equations(matrix_x - 2, matrix_y - 1)
        For j = varCount - 2 To 0 Step -1
            Dim tmpValue As Double = equations(matrix_x - 1, j)
            For i = j + 1 To matrix_x - 2
                tmpValue -= equations(i, j) * result(i)
            Next
            result(j) = tmpValue
        Next

        Return result

    End Function

    Private Sub P_MouseDown(sender As Object, e As MouseEventArgs) Handles P.MouseDown
        MouseDownFlag = 1
        SourcePos = e.Location
    End Sub

    Private Sub P_MouseMove(sender As Object, e As MouseEventArgs) Handles P.MouseMove

    End Sub

    Private Sub P_MouseUp(sender As Object, e As MouseEventArgs) Handles P.MouseUp
        If MouseDownFlag = 1 Then
            MouseDownFlag = 0
            ControlPoints(SelectedPointIndex).X += (e.X - SourcePos.X)
            ControlPoints(SelectedPointIndex).Y += (e.Y - SourcePos.Y)
            Debug.WriteLine("Point" & SelectedPointIndex & ":(" & ControlPoints(SelectedPointIndex).X & " , " & ControlPoints(SelectedPointIndex).Y & ")")
        End If

    End Sub
End Class

