<%@ WebHandler Language="VB" Class="Mantenedor_Sesiones" %>

Imports System
Imports System.Web

Public Class Mantenedor_Sesiones : Implements IHttpHandler, IRequiresSessionState
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "application/x-javascript"
        context.Response.Write("//")
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

End Class