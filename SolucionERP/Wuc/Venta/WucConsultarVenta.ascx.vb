Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class WucConsultarVenta
    Inherits UserControl
    Private TablaConsultarVenta As New DataTable()
    Public Event Seleccionado As EventHandler
    Public Event Cancelado As EventHandler
    Public Shared Property IdVenta As Integer
    Public Shared Property IdTipoVenta As TipoVenta

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session.Remove("TablaBuscarVenta")
        End If
        LBCantidadBusqueda.Text = "Ventas: 0"
    End Sub
    Public Sub Inicializar()
        LlenarDDs()
        LimpiarConsulta()
    End Sub

    Private Sub LlenarDDs()
        ' --------------------------- ---- Venta ---- ---------------------------
        Dim NegocioTipoVenta = New Negocio.TipoVenta()
        Dim EntidadTipoVenta As New Entidad.TipoVenta()
        EntidadTipoVenta.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoVenta.Consultar(EntidadTipoVenta)
        EntidadTipoVenta.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        DDVenta.DataSource = EntidadTipoVenta.TablaConsulta
        DDVenta.DataValueField = "ID"
        DDVenta.DataTextField = "Descripcion"
        DDVenta.DataBind()
        ' --------------------------- ---- Venta Estado ---- ---------------------------
        Dim NegocioTipoVentaEstado = New Negocio.TipoVentaEstado()
        Dim EntidadTipoVentaEstado As New Entidad.TipoVentaEstado()
        EntidadTipoVentaEstado.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoVentaEstado.Consultar(EntidadTipoVentaEstado)
        EntidadTipoVentaEstado.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        DDVentaEstado.DataSource = EntidadTipoVentaEstado.TablaConsulta
        DDVentaEstado.DataValueField = "ID"
        DDVentaEstado.DataTextField = "Descripcion"
        DDVentaEstado.DataBind()
    End Sub

    Private Sub LimpiarConsulta()
        Try
            Session.Remove("TablaBuscarVenta")
            GVBusquedaVenta.DataSource = Nothing
            GVBusquedaVenta.DataBind()
        Catch ex As Exception
        End Try
        divAvanzado.Visible = False
        IdVenta = 0
        IdTipoVenta = TipoVenta.Ninguno
        TBLVFolio.Text = ""
        TBVendedor.Text = ""
        DDVenta.SelectedValue = -1
        DDVentaEstado.SelectedValue = -1
        TBFechaInicio.Text = Now.Date.AddDays(-1).ToString("dd/MM/yyyy")
        TBFechaFin.Text = Now.Date.ToString("dd/MM/yyyy")
    End Sub
    Protected Sub BTNVCancelar_Click(sender As Object, e As EventArgs)
        LimpiarConsulta()
        RaiseEvent Cancelado(New Object, New EventArgs)
    End Sub
    Protected Sub GVBusquedaVenta_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    Protected Sub BTNSeleccionar_Click1(sender As Object, e As EventArgs)
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaBuscarVenta"), DataTable)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVBusquedaVenta.SelectedIndex = gvrFilaActual.RowIndex
        IdVenta = CInt(Tabla.Rows(GVBusquedaVenta.SelectedIndex).Item("IdVenta"))
        Dim venta As String = Tabla.Rows(GVBusquedaVenta.SelectedIndex).Item("Venta")
        If venta = "CONTADO" Then
            IdTipoVenta = TipoVenta.Contado
        ElseIf venta = "CREDITO" Then
            IdTipoVenta = TipoVenta.Credito
        ElseIf venta = "APARTADO" Then
            IdTipoVenta = TipoVenta.Apartado
        End If
        RaiseEvent Seleccionado(New Object, New EventArgs)
        Session.Remove("TablaBuscarVenta")
    End Sub
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = Now
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1

        'Obtener primer dia de la semana en este caso domingo
        Dim diaSemana As DateTime = Now.AddDays(-1)
        While diaSemana.DayOfWeek <> DayOfWeek.Sunday
            diaSemana = diaSemana.AddDays(-1)
        End While

        EntidadReporteVenta.FechaCreacion = diaSemana
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = CDate("01/" + Now.Date.ToString("MM/yyyy"))
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = CDate("01/01/" + Now.Date.ToString("yyyy"))
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = TBLVFolio.Text
        EntidadReporteVenta.IdVendedor = 0
        If IsNumeric(TBVendedor.Text) Then
            EntidadReporteVenta.IdVendedor = CInt(TBVendedor.Text)
        End If
        EntidadReporteVenta.IdVentaEstado = DDVentaEstado.SelectedValue
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = DDVenta.SelectedValue
        EntidadReporteVenta.FechaCreacion = CDate(TBFechaInicio.Text)
        EntidadReporteVenta.FechaActualizacion = CDate(TBFechaFin.Text)
        Consultar(EntidadReporteVenta)
    End Sub
    Private Sub Consultar(EntidadReporteVenta As Entidad.Venta)
        Dim NegocioReporteVenta As New Negocio.Venta
        Dim TablaConsulta As New DataTable
        EntidadReporteVenta.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioReporteVenta.VentaObtener(EntidadReporteVenta)
        TablaConsulta = EntidadReporteVenta.TablaConsulta
        GVBusquedaVenta.DataSource = TablaConsulta
        GVBusquedaVenta.DataBind()
        Session("TablaBuscarVenta") = TablaConsulta
        LBCantidadBusqueda.Text = "Ventas: " + TablaConsulta.Rows.Count.ToString()
    End Sub
End Class
