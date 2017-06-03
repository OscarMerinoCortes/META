
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Data
Imports Operacion.Configuracion.Constante
Partial Class Wuc_EstadisticaProducto
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub
    Public Sub ImprimirTablas()
        Dim TablaCompra As New DataTable
        Dim VistaCompra As New DataView

        Dim TablaVenta As New DataTable
        Dim VistaVenta As New DataView

        Dim TablaSucursal As New DataTable
        Dim VistaSucursal As New DataView

        Dim TablaProveedores As New DataTable
        Dim VistaProveedores As New DataView

        TablaCompra = Session("TablaCompra")
        VistaCompra = Session("VistaCompra")
        GVCompra.DataSource = VistaCompra
        GVCompra.DataBind()

        TablaVenta = Session("TablaVenta")
        VistaVenta = Session("VistaVenta")
        GVVenta.DataSource = VistaVenta
        GVVenta.DataBind()

        TablaSucursal = Session("TablaSucursal")
        VistaSucursal = Session("VistaSucursal")
        GVExistencia.DataSource = VistaSucursal
        GVExistencia.DataBind()

        TablaProveedores = Session("TablaProveedores")
        VistaProveedores = Session("VistaProveedores")
        GVProveedores.DataSource = VistaProveedores
        GVProveedores.DataBind()
        PanelTablas.Visible = True
    End Sub

    Public Sub LimpiarTablas()
        PanelTablas.Visible = False
    End Sub
End Class
