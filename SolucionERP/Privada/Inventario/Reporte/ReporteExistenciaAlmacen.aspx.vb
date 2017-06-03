Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Existencias por Almacen"
            'DDEstado
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))            
            DDEstado.SelectedValue = 1
            ' --------------------------- ---- Clasificacion ---- ---------------------------
            Dim NegocioClasificacion = New Negocio.Clasificacion()
            Dim EntidadClasificacion As New Entidad.Clasificacion()
            EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioClasificacion.Consultar(EntidadClasificacion)
            EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
            DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
            DDClasificacion.DataValueField = "ID"
            DDClasificacion.DataTextField = "Descripcion"
            DDClasificacion.DataBind()
            DDClasificacion.SelectedValue = -1
            ' --------------------------- ---- Subclasificacion ---- ---------------------------
            ConsultaSubclasificaciones()
            '--------------------------- ---- Sucursal -------------------------------
            'Dim tabla = New DataTable
            'Dim NegocioSucursal As New Negocio.Sucursal()
            'Dim EntidadSucursal As New Entidad.Sucursal()
            'Dim tarjeta As New Tarjeta()
            'EntidadSucursal.Tarjeta = tarjeta
            'EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaBasica
            'NegocioSucursal.Consultar(EntidadSucursal)
            'DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            'DDSucursal.DataValueField = "ID"
            'DDSucursal.DataTextField = "Descripcion"
            'DDSucursal.DataBind()
            'DDSucursal.Items.Add(New ListItem("TODO", -1))
            'DDSucursal.SelectedValue = -1
            '-------------------------------ALMACEN.----------------------------------------
            ConsultaAlmacen()
            MultiView1.SetActiveView(View1)
        Else
        End If
    End Sub
    Private Sub ConsultaAlmacen()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()  
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda        
        NegocioAlmacen.Consultar(EntidadAlmacen)        
        DDAlmacen.Items.Clear()
        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"
        DDAlmacen.DataBind()
        DDAlmacen.SelectedValue = 1
        tablaAlmacen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacen") = tablaAlmacen
    End Sub
    Private Sub ConsultaSubclasificaciones()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        If DDClasificacion.SelectedValue = -1 Then
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        Else
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId
        End If
        EntidadSubclasificacion.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
        If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
            DDSubClasificacion.Items.Clear()
            DDSubClasificacion.Items.Add(New ListItem("TODO", "-1"))
        Else
            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1)
            DDSubClasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubClasificacion.DataValueField = "ID"
            DDSubClasificacion.DataTextField = "Descripcion"
        End If
        DDSubClasificacion.DataBind()
        DDSubClasificacion.SelectedValue = -1
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioReporteExistencia As New Negocio.ReporteExistenciaAlmacen()
        Dim EntidadReporteExistencia As New Entidad.ReporteExistenciaAlmacen()
        Dim TablaConsulta As New DataTable
        Dim TablaAlmacen As New DataTable
        TablaAlmacen = Session("tablaAlmacen")        
        EntidadReporteExistencia.Id = -1
        EntidadReporteExistencia.IdSucursal = TablaAlmacen.Rows(DDAlmacen.SelectedIndex).Item("IdSucursal")
        EntidadReporteExistencia.Producto = TBDescripcion.Text
        EntidadReporteExistencia.IdAlmacen = DDAlmacen.SelectedValue
        EntidadReporteExistencia.IdClasificacion = DDClasificacion.SelectedValue
        EntidadReporteExistencia.IdSubClasificacion = DDSubClasificacion.SelectedValue
        EntidadReporteExistencia.IdEstado = 1
        EntidadReporteExistencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteExistencia.ReporteExistenciaAlmacen(EntidadReporteExistencia)
        TablaConsulta = EntidadReporteExistencia.TablaConsulta

        '
        GVReporteExistencia.Columns.Clear()
        GVReporteExistencia.DataSource = TablaConsulta
        GVReporteExistencia.AutoGenerateColumns = True
        GVReporteExistencia.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True

        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "ID", "ID")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Id Producto", "IdProducto")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Descripcion", "Descripcion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Existencia", "CantidadSistema")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Sucursal", "Sucursal")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Almacen", "Almacen")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Clasificacion", "Clasificacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "SubClasificacion", "SubClasificacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Estado", "Estado")
        'GVReporteExistencia.Columns.Add(Columna)
        GVReporteExistencia.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub


    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaReporteExistenciaAlmacen As New DataTable()
        'Dim NegocioReporteExistencia As New Negocio.ReporteExistenciaAlmacen()
        'Dim EntidadReporteExistencia As New Entidad.ReporteExistenciaAlmacen()

        'If TBId.Text Is String.Empty Then
        '    EntidadReporteExistencia.Id = -1
        'Else
        '    EntidadReporteExistencia.Id = TBId.Text
        'End If
        'EntidadReporteExistencia.IdSucursal = DDSucursal.SelectedValue
        'EntidadReporteExistencia.Producto = TBDescripcion.Text
        'EntidadReporteExistencia.IdAlmacen = DDAlmacen.SelectedValue
        'EntidadReporteExistencia.IdClasificacion = DDClasificacion.SelectedValue
        'EntidadReporteExistencia.IdSubClasificacion = DDSubClasificacion.SelectedValue
        'EntidadReporteExistencia.IdEstado = DDEstado.SelectedValue
        'EntidadReporteExistencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        'NegocioReporteExistencia.ReporteExistenciaAlmacen(EntidadReporteExistencia)
        'TablaReporteExistenciaAlmacen = EntidadReporteExistencia.TablaConsulta
        TablaReporteExistenciaAlmacen = Session("TablaConsulta")

        Dim COLUMNA As String = ""
        Dim TOTAL As Integer = TablaReporteExistenciaAlmacen.Columns.Count - 1
        'Recorre columnas
        For index = 0 To TOTAL
            COLUMNA = COLUMNA + TablaReporteExistenciaAlmacen.Columns(index).ToString() + ","
        Next

        Dim FileResponse As String = ""
        FileResponse = Cuadricula.ExportarTabla(TablaReporteExistenciaAlmacen, False, COLUMNA, COLUMNA)

        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteExistencia.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVReporteExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVReporteExistencia.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioReporteExistenciaAlmacen As New Negocio.ReporteExistenciaAlmacen()
        Dim EntidadReporteExistenciaAlmacen As New Entidad.ReporteExistenciaAlmacen()
        Tabla = CType(Session("TablaConsulta"), DataTable)
        wucConProDet.IdProducto = CStr(Tabla.Rows(GVReporteExistencia.SelectedIndex).Item("IdProducto"))
        wucConProDet.ObtenerInformacion()
    End Sub
    Protected Sub DDSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSucursal.SelectedIndexChanged
        ConsultaAlmacen()
    End Sub
    Protected Sub DDClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacion.SelectedIndexChanged
        ConsultaSubclasificaciones()
    End Sub
End Class