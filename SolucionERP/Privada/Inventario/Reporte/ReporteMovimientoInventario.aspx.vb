Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Movimiento de Inventario "
            divAvanzado.Visible = False
            'DDSucursal ORIGEN
            Dim tabla = New DataTable
            Dim NegocioSucursal As New Negocio.Sucursal()
            Dim EntidadSucursal As New Entidad.Sucursal()
            EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursalOrigen.DataSource = EntidadSucursal.TablaConsulta
            DDSucursalOrigen.DataValueField = "ID"
            DDSucursalOrigen.DataTextField = "Descripcion"
            DDSucursalOrigen.DataBind()
            DDSucursalOrigen.Items.Add(New ListItem("TODOS", -1))
            DDSucursalOrigen.SelectedValue = -1
            ConsultaAlmacenOrigen()
            DDAlmacenOrigen.SelectedValue = -1
            'DDSucursalDestino
            DDSucursalDestino.DataSource = EntidadSucursal.TablaConsulta
            DDSucursalDestino.DataValueField = "ID"
            DDSucursalDestino.DataTextField = "Descripcion"
            DDSucursalDestino.DataBind()
            DDSucursalDestino.Items.Add(New ListItem("TODOS", -1))
            DDSucursalDestino.SelectedValue = -1
            ConsultaAlmacenDestino()
            DDAlmacenDestino.SelectedValue = -1
            'DDTipoMovimiento
            DDTipo.Items.Add(New ListItem("ENTRADA", 1))
            DDTipo.Items.Add(New ListItem("SALIDA", 2))
            DDTipo.Items.Add(New ListItem("TODOS", -1))
            DDTipo.SelectedValue = -1
            ObtenerSubtipo()
            'DDEstado
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.Items.Add(New ListItem("TODOS", -1))
            DDEstado.SelectedValue = -1
            'Fechas
            TBDe.Text = "01/01/2016"
            TBAl.Text = DateTime.Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
        Else

        End If
    End Sub
    Protected Sub ConsultaAlmacenOrigen()
        Dim tablaAlmacenOrigen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda       
        NegocioAlmacen.Consultar(EntidadAlmacen)     
        DDAlmacenOrigen.Items.Clear()
        DDAlmacenOrigen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenOrigen.DataValueField = "ID"
        DDAlmacenOrigen.DataTextField = "Descripcion"
        DDAlmacenOrigen.DataBind()
        DDAlmacenDestino.SelectedValue = 1
        tablaAlmacenOrigen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenOrigen") = tablaAlmacenOrigen
    End Sub
    Protected Sub ConsultaAlmacenDestino()
        Dim tablaAlmacenDestino = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda        
        NegocioAlmacen.Consultar(EntidadAlmacen)        
        DDAlmacenDestino.Items.Clear()
        DDAlmacenDestino.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenDestino.DataValueField = "ID"
        DDAlmacenDestino.DataTextField = "Descripcion"
        DDAlmacenDestino.DataBind()
        DDAlmacenDestino.SelectedValue = 1
        tablaAlmacenDestino = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenDestino") = tablaAlmacenDestino
    End Sub
    Protected Sub ObtenerSubtipo()
        Dim tabla = New DataTable
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tarjeta As New Entidad.Tarjeta()
        EntidadMovimientoInventario.Tarjeta = tarjeta
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
        EntidadMovimientoInventario.IdTipo = DDTipo.SelectedValue
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        DDSubTipo.DataSource = EntidadMovimientoInventario.TablaConsulta
        DDSubTipo.DataValueField = "Id"
        DDSubTipo.DataTextField = "Descripcion"
        DDSubTipo.DataBind()
        DDSubTipo.Items.Add(New ListItem("TODOS", -1))
        DDSubTipo.SelectedValue = -1
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaConsulta As New DataTable()
        TablaConsulta = Session("TablaConsulta")
        Dim FileResponse As String = ""
        Dim Datos As String = "Id Movimiento,Codigo,Producto,Cantidad,TipoMovimiento,SubTipoMovimiento,Sucursal Origen,Almacen Origen,Sucursal Destino,Almacen Destino,Estado,Observacion,Fecha,"
        Dim Datos2 As String = "IdInventarioMovimiento,Codigo,Descripcion,Cantidad,Tipo,SubTipo,SucursalOrigen,AlmacenOrigen,SucursalDestino,AlmacenDestino,Estado,Observacion,FechaCreacion,"
        FileResponse = Cuadricula.ExportarTabla(TablaConsulta, False, Datos, Datos2)
        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteMovimiento.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub
    Protected Sub DDTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipo.SelectedIndexChanged
        ObtenerSubtipo()
    End Sub
    Protected Sub DDSucursalOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSucursalOrigen.SelectedIndexChanged
        ConsultaAlmacenOrigen()
    End Sub
    Protected Sub DDSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSucursalDestino.SelectedIndexChanged
        ConsultaAlmacenDestino()
    End Sub

    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False        
        End If
        Dim NegocioReporteMovimientoInventario As New Negocio.ReporteMovimientoInventario()
        Dim EntidadReporteMovimientoInventario As New Entidad.ReporteMovimientoInventario()
        Dim TablaConsulta As New DataTable

        EntidadReporteMovimientoInventario.IdMovimiento = -1
        EntidadReporteMovimientoInventario.IdTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSubTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSucursalOrigen = -1
        EntidadReporteMovimientoInventario.IdAlmacenOrigen = -1
        EntidadReporteMovimientoInventario.IdSucursalDestino = -1
        EntidadReporteMovimientoInventario.IdAlmacenDestino = -1

        EntidadReporteMovimientoInventario.IdEstado = -1
        EntidadReporteMovimientoInventario.FechaInicio = Now
        EntidadReporteMovimientoInventario.FechaFin = Now

        EntidadReporteMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
        TablaConsulta = EntidadReporteMovimientoInventario.TablaConsulta

        GVReporteMovimientoInventario.Columns.Clear()
        GVReporteMovimientoInventario.DataSource = TablaConsulta
        GVReporteMovimientoInventario.AutoGenerateColumns = False
        GVReporteMovimientoInventario.AllowSorting = True

        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Id Movimiento", "IdInventarioMovimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Producto", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Tipo Movimiento", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "SubTipo de Movimiento", "SubTipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Origen", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Origen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Destino", "SucursalDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Destino", "AlmacenDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Fecha", "FechaCreacion")
        GVReporteMovimientoInventario.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False       
        End If
        Dim NegocioReporteMovimientoInventario As New Negocio.ReporteMovimientoInventario()
        Dim EntidadReporteMovimientoInventario As New Entidad.ReporteMovimientoInventario()
        Dim TablaConsulta As New DataTable
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While

        EntidadReporteMovimientoInventario.IdMovimiento = -1
        EntidadReporteMovimientoInventario.IdTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSubTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSucursalOrigen = -1
        EntidadReporteMovimientoInventario.IdAlmacenOrigen = -1
        EntidadReporteMovimientoInventario.IdSucursalDestino = -1
        EntidadReporteMovimientoInventario.IdAlmacenDestino = -1

        EntidadReporteMovimientoInventario.IdEstado = -1
        EntidadReporteMovimientoInventario.FechaInicio = CDate(fechainicio)
        EntidadReporteMovimientoInventario.FechaFin = Now

        EntidadReporteMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
        TablaConsulta = EntidadReporteMovimientoInventario.TablaConsulta

        GVReporteMovimientoInventario.Columns.Clear()
        GVReporteMovimientoInventario.DataSource = TablaConsulta
        GVReporteMovimientoInventario.AutoGenerateColumns = False
        GVReporteMovimientoInventario.AllowSorting = True

        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Id Movimiento", "IdInventarioMovimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Producto", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Tipo Movimiento", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "SubTipo de Movimiento", "SubTipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Origen", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Origen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Destino", "SucursalDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Destino", "AlmacenDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Fecha", "FechaCreacion")
        GVReporteMovimientoInventario.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False       
        End If
        Dim NegocioReporteMovimientoInventario As New Negocio.ReporteMovimientoInventario()
        Dim EntidadReporteMovimientoInventario As New Entidad.ReporteMovimientoInventario()
        Dim TablaConsulta As New DataTable
        Dim fechainicio As DateTime = Now

        EntidadReporteMovimientoInventario.IdMovimiento = -1
        EntidadReporteMovimientoInventario.IdTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSubTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSucursalOrigen = -1
        EntidadReporteMovimientoInventario.IdAlmacenOrigen = -1
        EntidadReporteMovimientoInventario.IdSucursalDestino = -1
        EntidadReporteMovimientoInventario.IdAlmacenDestino = -1

        EntidadReporteMovimientoInventario.IdEstado = -1
        EntidadReporteMovimientoInventario.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadReporteMovimientoInventario.FechaFin = Now

        EntidadReporteMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
        TablaConsulta = EntidadReporteMovimientoInventario.TablaConsulta

        GVReporteMovimientoInventario.Columns.Clear()
        GVReporteMovimientoInventario.DataSource = TablaConsulta
        GVReporteMovimientoInventario.AutoGenerateColumns = False
        GVReporteMovimientoInventario.AllowSorting = True

        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Id Movimiento", "IdInventarioMovimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Producto", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Tipo Movimiento", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "SubTipo de Movimiento", "SubTipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Origen", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Origen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Destino", "SucursalDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Destino", "AlmacenDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Fecha", "FechaCreacion")
        GVReporteMovimientoInventario.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False       
        End If
        Dim NegocioReporteMovimientoInventario As New Negocio.ReporteMovimientoInventario()
        Dim EntidadReporteMovimientoInventario As New Entidad.ReporteMovimientoInventario()
        Dim TablaConsulta As New DataTable
        Dim fechainicio As DateTime = Now

        EntidadReporteMovimientoInventario.IdMovimiento = -1
        EntidadReporteMovimientoInventario.IdTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSubTipoMovimiento = -1
        EntidadReporteMovimientoInventario.IdSucursalOrigen = -1
        EntidadReporteMovimientoInventario.IdAlmacenOrigen = -1
        EntidadReporteMovimientoInventario.IdSucursalDestino = -1
        EntidadReporteMovimientoInventario.IdAlmacenDestino = -1

        EntidadReporteMovimientoInventario.IdEstado = -1
        EntidadReporteMovimientoInventario.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadReporteMovimientoInventario.FechaFin = Now

        EntidadReporteMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
        TablaConsulta = EntidadReporteMovimientoInventario.TablaConsulta

        GVReporteMovimientoInventario.Columns.Clear()
        GVReporteMovimientoInventario.DataSource = TablaConsulta
        GVReporteMovimientoInventario.AutoGenerateColumns = False
        GVReporteMovimientoInventario.AllowSorting = True

        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Id Movimiento", "IdInventarioMovimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Producto", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Tipo Movimiento", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "SubTipo de Movimiento", "SubTipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Origen", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Origen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Destino", "SucursalDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Destino", "AlmacenDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Fecha", "FechaCreacion")
        GVReporteMovimientoInventario.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub

    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Dim NegocioReporteMovimientoInventario As New Negocio.ReporteMovimientoInventario()
        Dim EntidadReporteMovimientoInventario As New Entidad.ReporteMovimientoInventario()
        Dim TablaConsulta As DataTable
        Dim tablaAlmacenOrigen As New DataTable
        tablaAlmacenOrigen = Session("tablaAlmacenOrigen")
        Dim tablaAlmacenDestino As New DataTable
        tablaAlmacenDestino = Session("tablaAlmacenDestino")
        If TBID.Text Is String.Empty Then
            EntidadReporteMovimientoInventario.IdMovimiento = -1
        Else
            EntidadReporteMovimientoInventario.IdMovimiento = CInt(TBID.Text)
        End If
        EntidadReporteMovimientoInventario.IdTipoMovimiento = DDTipo.SelectedValue
        EntidadReporteMovimientoInventario.IdSubTipoMovimiento = DDSubTipo.SelectedValue
        EntidadReporteMovimientoInventario.IdSucursalOrigen = tablaAlmacenOrigen.Rows(DDAlmacenOrigen.SelectedIndex).Item("IdSucursal")
        EntidadReporteMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigen.SelectedValue
        EntidadReporteMovimientoInventario.IdSucursalDestino = tablaAlmacenDestino.Rows(DDAlmacenDestino.SelectedIndex).Item("IdSucursal")
        EntidadReporteMovimientoInventario.IdAlmacenDestino = DDAlmacenDestino.SelectedValue

        EntidadReporteMovimientoInventario.IdEstado = DDEstado.SelectedValue
        EntidadReporteMovimientoInventario.FechaInicio = CDate(TBDe.Text)
        EntidadReporteMovimientoInventario.FechaFin = CDate(TBAl.Text)

        EntidadReporteMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteMovimientoInventario.ReporteMovimientoInventario(EntidadReporteMovimientoInventario)
        TablaConsulta = EntidadReporteMovimientoInventario.TablaConsulta

        GVReporteMovimientoInventario.Columns.Clear()
        GVReporteMovimientoInventario.DataSource = TablaConsulta
        GVReporteMovimientoInventario.AutoGenerateColumns = False
        GVReporteMovimientoInventario.AllowSorting = True


        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Id Movimiento", "IdInventarioMovimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Producto", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Tipo Movimiento", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "SubTipo de Movimiento", "SubTipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Origen", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Origen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Sucursal Destino", "SucursalDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Almacen Destino", "AlmacenDestino")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteMovimientoInventario, New BoundField(), "Fecha", "FechaCreacion")
        GVReporteMovimientoInventario.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
End Class