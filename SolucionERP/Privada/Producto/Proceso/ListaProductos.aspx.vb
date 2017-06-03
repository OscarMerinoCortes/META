Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Lista de Productos"
            'DDSucursal
            Dim tabla = New DataTable
            Dim NegocioSucursal As New Negocio.Sucursal()
            Dim EntidadSucursal As New Entidad.Sucursal()
            Dim tarjeta As New Tarjeta()
            EntidadSucursal.Tarjeta = tarjeta
            EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaDetallada
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            DDSucursal.DataValueField = "ID"
            DDSucursal.DataTextField = "Descripcion"
            DDSucursal.DataBind()
            DDSucursal.Items.Add(New ListItem("TODOS", -1))
            DDSucursal.SelectedValue = -1

            'DDAlmacen
            Dim tablaAlmacen = New DataTable
            Dim NegocioAlmacen As New Negocio.Almacen()
            Dim EntidadAlmacen As New Entidad.Almacen()
            EntidadAlmacen.Tarjeta = tarjeta
            EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaDetallada
            NegocioAlmacen.Consultar(EntidadAlmacen)
            DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
            DDAlmacen.DataValueField = "ID"
            DDAlmacen.DataTextField = "Descripcion"
            DDAlmacen.DataBind()
            DDAlmacen.Items.Add(New ListItem("TODOS", -1))
            DDAlmacen.SelectedValue = -1

            'DDEstado
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.Items.Add(New ListItem("TODOS", -1))
            DDEstado.SelectedValue = -1

            ' --------------------------- ---- Clasificacion ---- ---------------------------
            Dim NegocioClasificacion = New Negocio.Clasificacion()
            Dim EntidadClasificacion As New Entidad.Clasificacion()
            EntidadClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioClasificacion.Consultar(EntidadClasificacion)
            DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
            DDClasificacion.DataValueField = "ID"
            DDClasificacion.DataTextField = "Descripcion"
            DDClasificacion.DataBind()
            DDClasificacion.Items.Add(New ListItem("TODOS", -1))
            DDClasificacion.SelectedValue = -1
            '--------------------------- ----SubClasificacion ---- ---------------------------
            Dim NegocioSubClasificacion = New Negocio.Subclasificacion()
            Dim EntidadSubClasificacion As New Entidad.Subclasificacion()
            EntidadSubClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioSubClasificacion.Consultar(EntidadSubClasificacion)
            DDSubClasificacion.DataSource = EntidadSubClasificacion.TablaConsulta
            DDSubClasificacion.DataValueField = "ID"
            DDSubClasificacion.DataTextField = "Descripcion"
            DDSubClasificacion.DataBind()
            DDSubClasificacion.Items.Add(New ListItem("TODOS", -1))
            DDSubClasificacion.SelectedValue = -1

            MultiView1.SetActiveView(View1)
        Else

        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioListaProductos As New Negocio.ListaProductos()
        Dim EntidadListaProductos As New Entidad.ListaProductos()
        Dim TablaConsulta As New DataTable

        If TBId.Text Is String.Empty Then
            EntidadListaProductos.Id = -1
        Else
            EntidadListaProductos.Id = CInt(TBId.Text)
        End If
        If TBCodigoCorto.Text Is String.Empty Then
            EntidadListaProductos.CodigoCorto = -1
        Else
            EntidadListaProductos.CodigoCorto = CInt(TBCodigoCorto.Text)
        End If
        EntidadListaProductos.Descripcion = TBDescripcion.Text
        EntidadListaProductos.IdSucursal = DDSucursal.SelectedValue
        EntidadListaProductos.IdAlmacen = DDAlmacen.SelectedValue
        EntidadListaProductos.IdClasificacion = DDClasificacion.SelectedValue
        EntidadListaProductos.IdSubClasificacion = DDSubClasificacion.SelectedValue
        EntidadListaProductos.IdEstado = DDEstado.SelectedValue
        NegocioListaProductos.Obtener(EntidadListaProductos)
        TablaConsulta = EntidadListaProductos.TablaConsulta

        GVListaProductos.Columns.Clear()
        GVListaProductos.DataSource = TablaConsulta
        GVListaProductos.AutoGenerateColumns = False
        GVListaProductos.AllowSorting = True

        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True


        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Id Corto", "CodigoCorto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Clasificacion", "Clasificacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "SubClasificacion", "SubClasificacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Sucursal", "Sucursal")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Almacen", "Almacen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Existencia", "Existencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Precio", "PrecioBase")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVListaProductos, New BoundField(), "Estado", "Estado")
        'GVReporteExistencia.Columns.Add(Columna)

        GVListaProductos.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub IBTReporte_Click(sender As Object, e As ImageClickEventArgs) Handles IBTReporte.Click
        'Dim TablaReporteExistenciaAlmacen As New DataTable()
        'Dim NegocioReporteExistenciaAlmacen As New Negocio.ReporteExistenciaAlmacen()
        'Dim EntidadReporteExistenciaAlmacen As New Entidad.ReporteExistenciaAlmacen()

        'If TBId.Text Is String.Empty Then
        '    EntidadReporteExistenciaAlmacen.Id = 0
        'Else
        '    EntidadReporteExistenciaAlmacen.Id = TBId.Text
        'End If
        'EntidadReporteExistenciaAlmacen.IdSucursal = CType(DDSucursal.SelectedValue, Integer)
        'EntidadReporteExistenciaAlmacen.IdAlmacen = CType(DDAlmacen.SelectedValue, Integer)
        'EntidadReporteExistenciaAlmacen.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        'EntidadReporteExistenciaAlmacen.IdSubClasificacion = CType(DDSubClasificacion.SelectedValue, Integer)
        'EntidadReporteExistenciaAlmacen.IdEstado = CType(DDEstado.SelectedValue, Integer)

        'NegocioReporteExistenciaAlmacen.ReporteExistenciaAlmacen(EntidadReporteExistenciaAlmacen)
        'TablaReporteExistenciaAlmacen = EntidadReporteExistenciaAlmacen.TablaConsulta

        'Dim FileResponse As String = ""

        'FileResponse = Cuadricula.ExportarTabla(TablaReporteExistenciaAlmacen, False, _
        '                                                   "Id, Id Producto, Descripcion, Existencia, Sucursal, Almacen, Clasificacion, SubClasificacion, Estado", _
        '                                                   "Id, IdProducto, Descripcion, CantidadSistema, Sucursal, Almacen, Clasificacion, SubClasificacion, Estado,")

        'Dim Region As String = Request.QueryString("Region")
        'Response.AddHeader("Content-disposition", "attachment; filename=ReporteExistencia.csv")
        'Response.ContentType = "text/csv"
        'Response.Write(FileResponse)
        'Response.End()
    End Sub

    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click

    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVReporteExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVListaProductos.SelectedIndexChanged
        '    Dim Tabla As New DataTable
        '    Dim NegocioReporteExistenciaAlmacen As New Negocio.ReporteExistenciaAlmacen()
        '    Dim EntidadReporteExistenciaAlmacen As New Entidad.ReporteExistenciaAlmacen()
        '    Tabla = CType(Session("TablaConsulta"), DataTable)
        '    wucConProDet.IdProducto = CStr(Tabla.Rows(GVReporteExistencia.SelectedIndex).Item("IdProducto"))
        '    wucConProDet.ObtenerInformacion()
    End Sub
End Class