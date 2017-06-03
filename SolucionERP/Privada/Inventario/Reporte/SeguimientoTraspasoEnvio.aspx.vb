Imports System.Collections.ObjectModel
Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Seguimiento de traspaso y envío"
            divAvanzado.Visible = False
            ConsultaAlmacenPendienteOrigen()
            ConsultaAlmacenPendienteDestino()

            DDEstatus.Items.Add(New ListItem("PENDIENTE", 1))
            DDEstatus.Items.Add(New ListItem("ENTREGADO", 2))
            DDEstatus.Items.Add(New ListItem("CANCELADO", 3))
            DDEstatus.Items.Add(New ListItem("TODOS", -1))
            DDEstatus.SelectedValue = 1

            TBFechaInicioPendiente.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFinPendiente.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
        End If
    End Sub
    Protected Sub ConsultaAlmacenPendienteOrigen()
        Dim tablaAlmacenOrigen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()     
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)        
        DDAlmacenOrigenPendiente.Items.Clear()
        DDAlmacenOrigenPendiente.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenOrigenPendiente.DataValueField = "ID"
        DDAlmacenOrigenPendiente.DataTextField = "Descripcion"
        DDAlmacenOrigenPendiente.DataBind()     
        tablaAlmacenOrigen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenOrigen") = tablaAlmacenOrigen    
    End Sub
    Protected Sub ConsultaAlmacenPendienteDestino()
        Dim tablaAlmacenDestino = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()      
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda       
        NegocioAlmacen.Consultar(EntidadAlmacen)    
        DDAlmacenDestinoPendiente.Items.Clear()
        DDAlmacenDestinoPendiente.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenDestinoPendiente.DataValueField = "ID"
        DDAlmacenDestinoPendiente.DataTextField = "Descripcion"
        DDAlmacenDestinoPendiente.DataBind()
        DDAlmacenDestinoPendiente.SelectedValue = 1
        tablaAlmacenDestino = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenDestino") = tablaAlmacenDestino     
    End Sub
    Protected Sub Consultar()    
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario.IdAlmacenOrigen = CType(DDAlmacenOrigenPendiente.SelectedValue, Integer)
        EntidadMovimientoInventario.IdAlmacenDestino = CType(DDAlmacenDestinoPendiente.SelectedValue, Integer)
        EntidadMovimientoInventario.Estatus = CType(DDEstatus.SelectedValue, Integer)
        EntidadMovimientoInventario.FechaInicio = CDate(TBFechaInicioPendiente.Text)
        EntidadMovimientoInventario.FechaFin = CDate(TBFechaFinPendiente.Text)
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaSolicitudDetalle = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()        
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
    End Sub  

    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaSolicitudDetalle As New DataTable()
        TablaSolicitudDetalle = Session("TablaSolicitudDetalle")
        Dim FileResponse As String = ""
        Dim Datos As String = "Id,Codigo,Producto,Almacen Origen,Almacen Destino,Cantidad,Estado,Fecha,"
        Dim Datos2 As String = "IdEntrega,IdProductoCorto,Descripcion,AlmacenOrigen,AlmacenDestino,Cantidad,Estatus,Fecha,"
        FileResponse = Cuadricula.ExportarTabla(TablaSolicitudDetalle, False, Datos, Datos2)
        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteMovimiento.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub
    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As New DataTable
        Dim tablaAlmacenDestino As New DataTable
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigenPendiente.SelectedValue
        EntidadMovimientoInventario.IdAlmacenDestino = DDAlmacenDestinoPendiente.SelectedValue
        EntidadMovimientoInventario.Estatus = DDEstatus.SelectedValue
        EntidadMovimientoInventario.FechaInicio = CDate(fechainicio)
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaSolicitudDetalle = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As New DataTable
        Dim tablaAlmacenDestino As New DataTable
        EntidadMovimientoInventario.IdAlmacenOrigen = -1 'DDAlmacenOrigenPendiente.SelectedValue      
        EntidadMovimientoInventario.IdAlmacenDestino = -1 'DDAlmacenDestinoPendiente.SelectedValue
        EntidadMovimientoInventario.Estatus = -1 'DDEstatus.SelectedValue
        EntidadMovimientoInventario.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaSolicitudDetalle = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As New DataTable
        Dim tablaAlmacenDestino As New DataTable
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdAlmacenDestino = -1
        EntidadMovimientoInventario.Estatus = -1
        EntidadMovimientoInventario.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaSolicitudDetalle = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As New DataTable
        Dim tablaAlmacenDestino As New DataTable
        tablaAlmacenOrigen = Session("tablaAlmacenOrigen")
        tablaAlmacenDestino = Session("tablaAlmacenDestino")
        EntidadMovimientoInventario.IdSucursalOrigen = tablaAlmacenOrigen.Rows(DDAlmacenOrigenPendiente.SelectedIndex).Item("IdSucursal")
        EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigenPendiente.SelectedValue
        EntidadMovimientoInventario.IdSucursalDestino = tablaAlmacenDestino.Rows(DDAlmacenDestinoPendiente.SelectedIndex).Item("IdSucursal")
        EntidadMovimientoInventario.IdAlmacenDestino = DDAlmacenDestinoPendiente.SelectedValue
        EntidadMovimientoInventario.Estatus = DDEstatus.SelectedValue
        EntidadMovimientoInventario.FechaInicio = Now
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaSolicitudDetalle = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
    End Sub

    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Consultar()
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
End Class