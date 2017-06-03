Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.UI.DataVisualization.Charting
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "CargarGraficas(7);", True)
        Else
        End If
    End Sub

    <WebMethod()> _
    Public Shared Function Dashboard(opcion As Integer) As String
        Dim NegocioProducto As New Negocio.Dashboard()
        Dim EntidadProducto As New Entidad.Dashboard()
        EntidadProducto.Mes = Now.Date.ToString("MM")
        EntidadProducto.Anio = Now.Date.ToString("yyyy")
        Select Case Opcion
            Case 1
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica1
            Case 2
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica2
            Case 3
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica3
            Case 4
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica4
            Case 5
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica5
            Case Else
                EntidadProducto.DasboardOpcion = DasboardOpcion.Grafica6
        End Select
        NegocioProducto.ObtenerDashboardCaja(EntidadProducto)
        Select Case Opcion
            Case 1
                Return EntidadProducto.TablaGrafica1
            Case 2
                Return EntidadProducto.TablaGrafica2
            Case 3
                Return EntidadProducto.TablaGrafica3
            Case 4
                Return EntidadProducto.TablaGrafica4
            Case 5
                Return EntidadProducto.TablaGrafica5
            Case Else
                Return EntidadProducto.TablaGrafica6
        End Select
    End Function
End Class