Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Listado de Existencias por Sucursal"
            'DDSucursal
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

            'DDEstado
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.Items.Add(New ListItem("TODOS", -1))
            DDEstado.SelectedValue = -1

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
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioReporteEmpresa As New Negocio.ReporteExistenciaEmpresa()
        Dim EntidadReportEmpresa As New Entidad.ReporteExistenciaEmpresa()
        Dim TablaConsulta As New DataTable

        If TBId.Text Is String.Empty Then
            EntidadReportEmpresa.Id = -1 'todos
        Else
            EntidadReportEmpresa.Id = CInt(TBId.Text)
        End If
        EntidadReportEmpresa.IdSucursal = -1
        EntidadReportEmpresa.Descripcion = ""
        EntidadReportEmpresa.IdAlmacen = -1
        EntidadReportEmpresa.IdClasificacion = DDClasificacion.SelectedValue
        EntidadReportEmpresa.IdSubClasificacion = DDSubClasificacion.SelectedValue
        EntidadReportEmpresa.IdEstado = -1

        NegocioReporteEmpresa.ReporteListadoAlmacen(EntidadReportEmpresa)
        TablaConsulta = EntidadReportEmpresa.TablaConsulta

        GVReporteExistencia.Columns.Clear()
        GVReporteExistencia.DataSource = TablaConsulta
        GVReporteExistencia.AutoGenerateColumns = False
        GVReporteExistencia.AllowSorting = True 
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Id Producto", "IdProducto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Clasificacion", "Clasificacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "SubClasificacion", "SubClasificacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Almacen", "Almacen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Existencia", "Existencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteExistencia, New BoundField(), "Estado", "Estado")

        GVReporteExistencia.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaReporteExistenciaEmpresa As New DataTable()
        TablaReporteExistenciaEmpresa = Session("TablaConsulta")


        Dim FileResponse As String = ""

        FileResponse = Cuadricula.ExportarTabla(TablaReporteExistenciaEmpresa, False,
                                                           "Id Producto, Codigo, Descripcion,Clasificacion,SubClasificacion,Almacen,Existencia,Estado",
                                                           "IdProducto, Codigo, Descripcion, Clasificacion,SubClasificacion,Almacen,Existencia,Estado,")

        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteExistencia.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub DDClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacion.SelectedIndexChanged
        ConsultaSubclasificaciones()
    End Sub
End Class