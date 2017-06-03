Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte Solicitud de Compra"
            LlenarDDs()
            divAvanzado.Visible = False
            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
        End If
    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioSolicitudCompra As New Negocio.SolicitudCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = CType(IIf(IsNumeric(TBSolicitud.Text), TBSolicitud.Text, -1), Integer)
        EntidadSolicitudCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadSolicitudCompra.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdSubclasificacion = CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdTipoPrioridad = CType(DDPrioridad.SelectedValue, Integer)
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadSolicitudCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadSolicitudCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioSolicitudCompra.ReporteSolicitudCompra(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.Columns.Clear()
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "ID", "IdSolicitud")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "ID Detalle", "IdSolicitudDetalle")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Cantidad", "Cantidad")       
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Estado", "TipoSolicitudEstado") 
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Fecha", "Fecha")
        GVSolicitud.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
        LBCantidadBusqueda.Text = "Solicitudes: " + (TablaSolicitudDetalle.Rows.Count).ToString()
    End Sub
    Private Sub LlenarDDs()
        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        EntidadTipoPrioridad.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        EntidadTipoPrioridad.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        DDPrioridad.DataSource = EntidadTipoPrioridad.TablaConsulta
        DDPrioridad.DataValueField = "ID"
        DDPrioridad.DataTextField = "Descripcion"
        DDPrioridad.DataBind()
        DDPrioridad.SelectedValue = "-1"

        ' --------------------------- ---- Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.Ninguno
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        EntidadTipoSolicitudEstado.TablaConsulta.Rows.Add(-1, "TODO")
        DDEstado.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        DDEstado.DataValueField = "ID"
        DDEstado.DataTextField = "Descripcion"
        DDEstado.DataBind()
        DDEstado.SelectedValue = "-1"

        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioAlmacen.Consultar(EntidadAlmacen)
        EntidadAlmacen.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, "TODO")
        DDDestino.DataSource = EntidadAlmacen.TablaConsulta
        DDDestino.DataValueField = "ID"
        DDDestino.DataTextField = "Descripcion"
        DDDestino.DataBind()
        DDDestino.SelectedValue = "-1"

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
        DDClasificacion.SelectedValue = "-1"

        ConsultaSubclasificaciones()
    End Sub
    Protected Sub DDClasificacion_TextChanged(sender As Object, e As EventArgs) Handles DDClasificacion.TextChanged
        ConsultaSubclasificaciones()
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
            DDSubclasificacion.Items.Clear()
            DDSubclasificacion.Items.Add(New ListItem("TODO", "-1"))
        Else
            If EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica Then
                EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, -1, "TODO")
            Else
                EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1, "TODO")
            End If
            DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubclasificacion.DataValueField = "ID"
            DDSubclasificacion.DataTextField = "Descripcion"
        End If
        DDSubclasificacion.DataBind()
        DDSubclasificacion.SelectedValue = "-1"
    End Sub  
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
        If TablaSolicitudDetalle IsNot Nothing Then
            Dim FileResponse As String = ""
            If TablaSolicitudDetalle.Rows.Count > 0 Then
                FileResponse = Cuadricula.ExportarTabla(TablaSolicitudDetalle, False,
                                                              "Id,Id Detalle,Codigo,Producto,Cantidad,Destino,Estado,Fecha",
                                                              "IdSolicitud,IdSolicitudDetalle,IdProductoCorto,Producto,Cantidad,Almacen,TipoSolicitudEstado,Fecha,")

            End If
            Dim Region As String = Request.QueryString("Region")
            Response.AddHeader("Content-disposition", "attachment; filename=ReporteSolicitudCompra" + Now.ToString("ddMMyy") + ".csv")
            Response.ContentType = "text/csv"
            Response.Write(FileResponse)
            Response.End()
        Else
            Exit Sub
        End If
    End Sub
    Protected Sub SortRecords(sender As Object, e As GridViewSortEventArgs) Handles GVSolicitud.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaSolicitudDetalle"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVSolicitud.DataSource = Vista
        GVSolicitud.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub MostrarTabla(EntidadSolicitudCompra As Entidad.ReporteProcesoCompra)
        Dim NegocioSolicitudCompra As New Negocio.SolicitudCompra()
        NegocioSolicitudCompra.ReporteSolicitudCompra(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.Columns.Clear()
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "ID", "IdSolicitud")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "ID Detalle", "IdSolicitudDetalle")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Estado", "TipoSolicitudEstado")
        Cuadricula.AgregarColumna(GVSolicitud, New BoundField(), "Fecha", "Fecha")
        GVSolicitud.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
        LBCantidadBusqueda.Text = "Solicitudes: " + (TablaSolicitudDetalle.Rows.Count).ToString()
    End Sub
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = -1
        EntidadSolicitudCompra.FechaInicio = Now
        EntidadSolicitudCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadSolicitudCompra)
    End Sub
    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = -1
        EntidadSolicitudCompra.FechaInicio = fechainicio
        EntidadSolicitudCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadSolicitudCompra)
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = -1
        EntidadSolicitudCompra.FechaInicio = CDate("01/" + Now.Date.ToString("MM/yyyy"))
        EntidadSolicitudCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadSolicitudCompra)
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = -1
        EntidadSolicitudCompra.FechaInicio = CDate("01/01/" + Now.Date.ToString("yyyy"))
        EntidadSolicitudCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadSolicitudCompra)
    End Sub
    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        LlenarSolicitudes()
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        Imprimir()
    End Sub
    Private Sub Imprimir()
        Dim objFSO, objTextFile
        Dim sRead, sReadLine, sReadAll
        Const ForReading = 1
        objFSO = CreateObject("Scripting.FileSystemObject")
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\Compra\Reportes\ReporteSolicitudCompra.html", ForReading)
        ' Use different methods to read contents of file. ï»¿

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        Dim compraNegocio As New Negocio.SolicitudCompra()
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaSolicitudDetalle"), DataTable)
        'ventaNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        compraNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        Session("HMTLImprimir") = cadena
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "abrirImprimir()", True)
    End Sub
End Class