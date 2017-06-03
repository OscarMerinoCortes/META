Imports System.Web.UI.MasterPage
Imports System.Data
Imports Operacion.Configuracion.Constante
Imports System.Web.UI.DataVisualization.Charting

Public Class WucConsultarProductoPerfil
    Inherits UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MultiView1.SetActiveView(View1)
        End If

    End Sub

    Public Sub Abrir(ByVal IdProducto As Integer, ByVal Producto As String)
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.PerfilProducto()
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadProducto.IdProducto = IdProducto
        LBTitulo.Text = Producto
        NegocioProducto.ObtenerPerfil(EntidadProducto)

        'GVCompra.Columns.Clear()
        'GVCompra.DataSource = EntidadProducto.TablaCompra
        'GVCompra.AutoGenerateColumns = True
        'GVCompra.AllowSorting = False
        'GVCompra.DataBind()

        CHCompra.DataSource = EntidadProducto.TablaCompra
        CHCompra.Series.Clear()

        For i = 0 To EntidadProducto.TablaCompra.Rows.Count - 1
            Try
                CHCompra.Series.Add(CStr(EntidadProducto.TablaCompra.Columns(i + 1).ColumnName))
                CHCompra.Series(i).XValueMember = "Mes"
                CHCompra.Series(i).YValueMembers = CStr(EntidadProducto.TablaCompra.Columns(i + 1).ColumnName)
                CHCompra.Series(i).IsValueShownAsLabel = True
            Catch ex As Exception
            End Try
        Next

        For Each cs As Series In CHCompra.Series
            cs.ChartType = SeriesChartType.Column
        Next

        CHCompra.DataBind()

        'GVVenta.Columns.Clear()
        'GVVenta.DataSource = EntidadProducto.TablaVenta
        'GVVenta.AutoGenerateColumns = True
        'GVVenta.AllowSorting = False
        'GVVenta.DataBind()

        CHVenta.DataSource = EntidadProducto.TablaVenta
        CHVenta.Series.Clear()

        For i = 0 To EntidadProducto.TablaVenta.Rows.Count - 1
            Try
                CHVenta.Series.Add(CStr(EntidadProducto.TablaVenta.Columns(i + 1).ColumnName))
                CHVenta.Series(i).XValueMember = "Mes"
                CHVenta.Series(i).YValueMembers = CStr(EntidadProducto.TablaVenta.Columns(i + 1).ColumnName)
                CHVenta.Series(i).IsValueShownAsLabel = True
            Catch ex As Exception
            End Try
        Next

        For Each cs As Series In CHVenta.Series
            cs.ChartType = SeriesChartType.Column
        Next

        CHVenta.DataBind()



        'GVExistencia.Columns.Clear()
        'GVExistencia.DataSource = EntidadProducto.TablaExistencia
        'GVExistencia.AutoGenerateColumns = True
        'GVExistencia.AllowSorting = False
        'GVExistencia.DataBind()

        CHExistencia.DataSource = EntidadProducto.TablaExistencia
        CHExistencia.Series.Clear()

        ' For i = 0 To EntidadProducto.TablaExistencia.Rows.Count - 1
        Try
            CHExistencia.Series.Add(CStr(EntidadProducto.TablaExistencia.Rows(0).Item("Almacen")))
            CHExistencia.Series(0).XValueMember = "Almacen"
            CHExistencia.Series(0).YValueMembers = "Cantidad"
            CHExistencia.Series(0).IsValueShownAsLabel = True
        Catch ex As Exception
        End Try
        'Next

        For Each cs As Series In CHExistencia.Series
            cs.ChartType = SeriesChartType.Column
        Next

        CHExistencia.DataBind()


        GVProveedor.Columns.Clear()
        GVProveedor.DataSource = EntidadProducto.TablaProveedor
        GVProveedor.AutoGenerateColumns = True
        GVProveedor.AllowSorting = False
        GVProveedor.DataBind()

        MPEConsultarProductoDetalle.Show()
    End Sub

    Protected Sub IBTNCerrar_OnClick(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        'LimpiarConsulta()
        'MPEConsultarProducto.Hide()
    End Sub

    Protected Sub BTNCerrarBusqueda_Click(sender As Object, e As EventArgs)
        MPEConsultarProductoDetalle.Hide()
    End Sub
End Class
