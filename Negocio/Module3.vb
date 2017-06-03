Imports System.IO
Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module3
    Public Sub Leer(ByVal PSNomArc As String, ByRef PAConSis As Array)
        Dim DSStrRea As StreamReader
        Dim DSImpStr As String
        Dim DIConRen As Integer = 0
        Try
            DSStrRea = File.OpenText(PSNomArc)
            DSImpStr = DSStrRea.ReadLine()
            While Not DSImpStr Is Nothing
                PAConSis(DIConRen) = DSImpStr
                DIConRen += 1
                DSImpStr = DSStrRea.ReadLine()
            End While
        Catch exc As Exception
            MsgBox("Error al Leer el Archivo" + exc.Message)
        Finally
            If Not DSStrRea Is Nothing Then
                DSStrRea.Close()
            End If
        End Try
    End Sub

    Public Sub Escribir(ByVal PSNomArc As String, ByRef PAConSis As Array)
        Dim DSStrWri As StreamWriter
        Dim DSTxtArc As String
        Dim DIRenArr As Integer
        DSTxtArc = PAConSis(0)
        For DIRenArr = 1 To 9
            DSTxtArc = DSTxtArc + Chr(13) + PAConSis(DIRenArr)
        Next DIRenArr
        Try
            File.Delete(PSNomArc)
            DSStrWri = File.CreateText(PSNomArc)
            DSStrWri.Write(DSTxtArc)
            DSStrWri.Flush()
        Catch exc As Exception
            MsgBox("Error al Escribir el Archivo" + exc.Message)
        Finally
            If Not DSStrWri Is Nothing Then
                DSStrWri.Close()
            End If
        End Try
    End Sub

    Public Sub EscribirLog(ByVal PSNomArc As String, ByRef PSMenErr As String)
        Dim DSStrRea As StreamReader
        Dim DSStrWri As StreamWriter
        Dim DSTxtArc As String = ""
        Try
            If File.Exists(PSNomArc) Then
                DSStrRea = File.OpenText(PSNomArc)
                DSTxtArc = DSStrRea.ReadToEnd()
                DSStrRea.Close()
            End If

            DSStrWri = File.CreateText(PSNomArc)
            DSStrWri.Write(DSTxtArc & PSMenErr & Environment.NewLine)
            DSStrWri.Flush()
        Catch exc As Exception
            MsgBox("Error al Escribir el Archivo " + exc.Message)
        Finally
            If Not DSStrWri Is Nothing Then
                DSStrWri.Close()
            End If
        End Try
    End Sub


    Public Function Vacio(ByVal DSValCad As String) As Boolean
        If Trim(DSValCad) = Space(0) Then
            Vacio = True
        Else
            Vacio = False
        End If
        Return Vacio
    End Function

    Public Function AgregarAst(ByVal DSValCad As String) As String
        AgregarAst = DSValCad.Replace("***", "")
        AgregarAst = Trim(DSValCad) + " ***"
        Return AgregarAst
    End Function

    Public Function QuitarAst(ByVal DSValCad As String) As String
        QuitarAst = DSValCad.Replace("***", "")
        Return QuitarAst
    End Function

    '    Public Sub MsgErrSQL(ByVal expSql As SqlException)
    '        Dim DFMsgErr As New FMSGERR()
    '        SSMsgPro = ErrorSQL(expSql.Number, expSql.Procedure.ToString) + Chr(13) + "Detalle: " + expSql.Message
    '        DFMsgErr.Show()
    '    End Sub

    '    Public Function ErrorSQL(ByVal DINumErr As String, ByVal DSNomPro As String) As String
    '        SSErrGen = True
    '        If Array.IndexOf(SACodErr, DINumErr) = -1 Then
    '            ErrorSQL = "Error: " + DINumErr + Chr(13) + "Descripcion: Desconocida" + Chr(13) + "Procedimiento: " + DSNomPro
    '        Else
    '            ErrorSQL = "Error: " + DINumErr + Chr(13) + "Descripcion: " + ArrBus(SAValErr, SACodErr, DINumErr) + Chr(13) + "Procedimiento: " + DSNomPro
    '        End If
    '        Return ErrorSQL
    '    End Function

    '    Public Sub MsgErrSis(ByRef DSNumErr As String, ByRef DSDesErr As String, ByRef DSDetErr As String)
    '        MessageBox.Show("Error: " + DSNumErr + Chr(13) + "Descripcion: " + DSDesErr + Chr(13) + "Detalle: " + DSDetErr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Sub

    '    Public Function SepararCadena(ByVal DSValCad As String) As String
    '        Dim DILonCad As Integer = Len(DSValCad)
    '        Dim DINumCad As Integer = 0
    '        Dim DSCadRes As String = ""
    '        For DINumCad = 1 To DILonCad
    '            If (Not IsNumeric(Mid(DSValCad, DINumCad, 1))) And Mid(DSValCad, DINumCad, 1) <> " " Then
    '                DSCadRes = DSCadRes & Mid(DSValCad, DINumCad, 1)
    '            End If
    '        Next
    '        Return DSCadRes
    '    End Function
    '    Public Function SepararNCadena(ByVal DSValCad As String) As String
    '        Dim DILonCad As Integer = Len(DSValCad)
    '        Dim DINumCad As Integer = 0
    '        Dim DSCadRes As String = ""
    '        For DINumCad = 1 To DILonCad
    '            If IsNumeric(Mid(DSValCad, DINumCad, 1)) Then
    '                DSCadRes = DSCadRes & Mid(DSValCad, DINumCad, 1)
    '            End If
    '        Next
    '        Return DSCadRes
    '    End Function
End Module
