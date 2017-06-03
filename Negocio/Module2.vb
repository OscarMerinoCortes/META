Module Module2

    Public Sub AddRul(ByRef ResRul As String, ByRef ComRul As String, ByVal MenRul As String)
        If ComRul Then
            ResRul = ResRul + Chr(13) + MenRul
        End If
    End Sub

    Public Function ArrBus(ByRef ArrayVal As Array, ByRef ArrayCod As Array, ByVal CodBus As String)
        If Array.IndexOf(ArrayCod, CodBus) <> -1 Then
            Return ArrayVal(Array.IndexOf(ArrayCod, CodBus))
        End If
    End Function

    Public Sub Indice(ByRef DAArrDat() As String, ByVal DSEleAgre As String)
        If Array.IndexOf(DAArrDat, DSEleAgre) = -1 Then
            ReDim DAArrDat(DAArrDat.Length + 1)
            DAArrDat.SetValue(DSEleAgre, DAArrDat.Length - 1)
            Array.Sort(DAArrDat)
        End If
    End Sub

    Public Function SiAlguno(ByVal DAArrDat() As String, ByVal DSCadBus As String) As Boolean
        If Array.IndexOf(DAArrDat, DSCadBus) = -1 Then
            SiAlguno = False
        Else
            SiAlguno = True
        End If
    End Function

    Public Function SiTodos(ByVal DAArrDat() As String, ByVal DSCadBus As String) As Boolean
        SiTodos = True
        Dim DINumRen As Integer = 0
        For DINumRen = 0 To DAArrDat.Length - 1
            If DAArrDat(DINumRen) <> DSCadBus Then
                SiTodos = False
                Exit For
            End If
        Next
    End Function
End Module
