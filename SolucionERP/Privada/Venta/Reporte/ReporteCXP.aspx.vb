Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Private TablaCompra As New DataTable()
    Private VistaCompra As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de CXP"
            LlenarDDs()

            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)

        Else
            TablaCompra = CType(Session("TablaCompra"), DataTable)
            VistaCompra = CType(Session("VistaCompra"), DataView)
        End If
    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()


        Dim IdPersona As Integer
        IdPersona = 0
        Dim Equivalencia As String
        Dim Nombre As String
        wucConProv.ObtenerPersona(IdPersona, Equivalencia, Nombre)
        EntidadCCP.IdPersona = IdPersona
        EntidadCCP.IdEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadCCP.IdTipoCCP = 2
        EntidadCCP.FechaExpedicion = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadCCP.FechaVencimiento = Comprobacion.ValidaFechaInicio(TBFechaFin.Text)

        NegocioCCP.ReporteCCP(EntidadCCP)
        TablaCompra = EntidadCCP.TablaConsulta
        GVCompra.DataSource = TablaCompra
        GVCompra.AutoGenerateColumns = False
        GVCompra.AllowSorting = True
        GVCompra.Columns.Clear()
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID", "IdCCP")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Fecha", "FechaExpedicion")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IdProveedor", "IdPersona")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Nombre", "Nombre")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Subtotal", "Monto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IVA", "IVA")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cargos", "Cargos")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Estado", "Estado")
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
    End Sub
    Private Sub LlenarDDs()

        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        'Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        'Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        'EntidadTipoPrioridad.Tarjeta.Consulta = Consulta.ConsultaBasica
        'NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        'EntidadTipoPrioridad.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        'DDPrioridad.DataSource = EntidadTipoPrioridad.TablaConsulta
        'DDPrioridad.DataValueField = "ID"
        'DDPrioridad.DataTextField = "Descripcion"
        'DDPrioridad.DataBind()
        'DDPrioridad.SelectedValue = "-1"

        ' --------------------------- ---- Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoVentaEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoVentaEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        EntidadTipoSolicitudEstado.TablaConsulta.Rows.Add(-1, "TODO")
        DDEstado.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        DDEstado.DataValueField = "ID"
        DDEstado.DataTextField = "Descripcion"
        DDEstado.DataBind()
        DDEstado.SelectedValue = "-1"

        ' --------------------------- ---- Almacen ---- ---------------------------
        'Dim NegocioAlmacen = New Negocio.Almacen()
        'Dim EntidadAlmacen As New Entidad.Almacen()
        'EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBasica
        'NegocioAlmacen.Consultar(EntidadAlmacen)
        'EntidadAlmacen.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, "TODO")
        'DDDestino.DataSource = EntidadAlmacen.TablaConsulta
        'DDDestino.DataValueField = "ID"
        'DDDestino.DataTextField = "Descripcion"
        'DDDestino.DataBind()
        'DDDestino.SelectedValue = "-1"

        ' --------------------------- ---- Clasificacion ---- ---------------------------
        'Dim NegocioClasificacion = New Negocio.Clasificacion()
        'Dim EntidadClasificacion As New Entidad.Clasificacion()
        'EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        'NegocioClasificacion.Consultar(EntidadClasificacion)
        'EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        'DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        'DDClasificacion.DataValueField = "ID"
        'DDClasificacion.DataTextField = "Descripcion"
        'DDClasificacion.DataBind()
        'DDClasificacion.SelectedValue = "-1"

        '  ConsultaSubclasificaciones()
    End Sub
    'Protected Sub DDClasificacion_TextChanged(sender As Object, e As EventArgs) Handles DDClasificacion.TextChanged
    '    ConsultaSubclasificaciones()
    'End Sub
    'Private Sub ConsultaSubclasificaciones()
    '    Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
    '    Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
    '    If DDClasificacion.SelectedValue = -1 Then
    '        EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
    '    Else
    '        EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId

    '    End If
    '    EntidadSubclasificacion.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
    '    NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
    '    If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
    '        DDSubclasificacion.Items.Clear()
    '        DDSubclasificacion.Items.Add(New ListItem("TODO", "-1"))
    '    Else
    '        If EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica Then
    '            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, -1, "TODO")
    '        Else
    '            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1, "TODO")
    '        End If
    '        DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
    '        DDSubclasificacion.DataValueField = "ID"
    '            DDSubclasificacion.DataTextField = "Descripcion"
    '        End If
    '        DDSubclasificacion.DataBind()
    '    DDSubclasificacion.SelectedValue = "-1"
    'End Sub
    'Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
    '    LlenarSolicitudes()
    'End Sub
    Protected Sub IBTReporte_Click(sender As Object, e As ImageClickEventArgs) Handles IBTReporte.Click
        TablaCompra = CType(Session("TablaCompra"), DataTable)
        VistaCompra = CType(Session("VistaCompra"), DataView)
        Dim FileResponse As String = ""
        If TablaCompra.Rows.Count > 0 Then
            If TablaCompra.Columns.Count = 9 Then
                FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                                       "Id,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado,",
                                                              "IdCCP,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado,")
            Else
                FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                              "Id,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado,",
                                                              "IdCCP,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado,")
            End If
            Dim Region As String = Request.QueryString("Region")
            Response.AddHeader("Content-disposition", "attachment; filename=ReporteCompra" + Now.ToString("ddMMyy") + ".csv")
            Response.ContentType = "text/csv"
            Response.Write(FileResponse)
            Response.End()
        End If
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
    End Sub
    Protected Sub SortRecords(sender As Object, e As GridViewSortEventArgs) Handles GVCompra.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaCompra"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVCompra.DataSource = Vista
        GVCompra.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        LlenarSolicitudes()
    End Sub
End Class