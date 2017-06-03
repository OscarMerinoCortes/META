Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim ArrayHTML() As String
        'ReDim ArrayHTML(Session("Count"))
        Dim cadena = Session("HMTLImprimir")
        'Dim i As Integer = Session("i")
        Response.Clear()
        Response.ContentType = "text/HTML"
        Response.Write(cadena)
        'Session("i") = i + 1
        Response.End()
    End Sub
End Class