Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Existencias por Producto"
            '--------------------------- ---- Sucursal -------------------------------
            Dim tabla = New DataTable
            Dim NegocioSucursal As New Negocio.Sucursal()
            Dim EntidadSucursal As New Entidad.Sucursal()
            Dim tarjeta As New Tarjeta()
            EntidadSucursal.Tarjeta = tarjeta
            EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            DDSucursal.DataValueField = "ID"
            DDSucursal.DataTextField = "Descripcion"
            DDSucursal.DataBind()
            DDSucursal.Items.Add(New ListItem("TODO", -1))
            DDSucursal.SelectedValue = -1
            '-------------------------------ALMACEN.----------------------------------------
            ConsultaAlmacen()

            'DDEstado
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            'DDEstado.Items.Add(New ListItem("TODOS", -1))
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

            MultiView1.SetActiveView(View1)
        Else

        End If
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
    Private Sub ConsultaAlmacen()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        'If DDSucursal.SelectedValue = -1 Then
        '    EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBasica
        'Else
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        'End If
        'EntidadAlmacen.IdSucursal = CType(DDSucursal.SelectedValue, Integer)
        NegocioAlmacen.Consultar(EntidadAlmacen)
        'If EntidadAlmacen.TablaConsulta.Rows.Count = 0 Then
        '    DDAlmacen.Items.Clear()
        '    DDAlmacen.Items.Add(New ListItem("TODOS", -1))
        'Else
        DDAlmacen.Items.Clear()
        'EntidadAlmacen.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1, "TODO")
        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"
        'End If
        DDAlmacen.DataBind()
        DDAlmacen.SelectedValue = 1
        tablaAlmacen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacen") = tablaAlmacen
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioReporteEmpresa As New Negocio.ReporteExistenciaEmpresa()
        Dim EntidadReportEmpresa As New Entidad.ReporteExistenciaEmpresa()
        Dim TablaConsulta As New DataTable
        Dim tablaAlmacen As New DataTable
        tablaAlmacen = Session("tablaAlmacen")        
        EntidadReportEmpresa.Id = -1
        EntidadReportEmpresa.IdSucursal = tablaAlmacen.Rows(DDAlmacen.SelectedIndex).Item("IdSucursal")
        EntidadReportEmpresa.IdAlmacen = DDAlmacen.SelectedValue
        EntidadReportEmpresa.IdClasificacion = DDClasificacion.SelectedValue
        EntidadReportEmpresa.IdSubClasificacion = DDSubClasificacion.SelectedValue
        EntidadReportEmpresa.IdEstado = 1

        EntidadReportEmpresa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteEmpresa.ReporteExistenciaEmpresa(EntidadReportEmpresa)
        TablaConsulta = EntidadReportEmpresa.TablaConsulta

        GVReporteExistencia.Columns.Clear()
        GVReporteExistencia.DataSource = TablaConsulta
        GVReporteExistencia.AutoGenerateColumns = False
        GVReporteExistencia.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        Columna.HeaderStyle.CssClass = "Ocultar"
        Columna.ItemStyle.CssClass = "Ocultar"
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Id Producto", "IdProducto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Existencia", "ExistenciaTotal")
        GVReporteExistencia.Columns.Add(Columna)
        'GVReporteExistencia.Columns("").ItemStyle.CssClass = "Ocultar"


        GVReporteExistencia.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaReporteExistenciaEmpresa As New DataTable()
        Dim NegocioReporteExistenciaEmpresa As New Negocio.ReporteExistenciaEmpresa()
        Dim EntidadReporteExistenciaEmpresa As New Entidad.ReporteExistenciaEmpresa()

        If TBId.Text Is String.Empty Then
            EntidadReporteExistenciaEmpresa.Id = 0
        Else
            EntidadReporteExistenciaEmpresa.Id = TBId.Text
        End If
        EntidadReporteExistenciaEmpresa.IdSucursal = CType(DDSucursal.SelectedValue, Integer)
        EntidadReporteExistenciaEmpresa.IdAlmacen = CType(DDAlmacen.SelectedValue, Integer)
        EntidadReporteExistenciaEmpresa.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        EntidadReporteExistenciaEmpresa.IdSubClasificacion = CType(DDSubClasificacion.SelectedValue, Integer)
        EntidadReporteExistenciaEmpresa.IdEstado = CType(DDEstado.SelectedValue, Integer)

        NegocioReporteExistenciaEmpresa.ReporteExistenciaEmpresa(EntidadReporteExistenciaEmpresa)
        TablaReporteExistenciaEmpresa = EntidadReporteExistenciaEmpresa.TablaConsulta

        Dim FileResponse As String = ""

        FileResponse = Cuadricula.ExportarTabla(TablaReporteExistenciaEmpresa, False,
                                                           "Id Producto, Codigo, Descripcion, Existencia",
                                                           "IdProducto, Codigo, Descripcion, ExistenciaTotal,")

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