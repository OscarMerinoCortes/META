Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Private TablaOrdenCompra As New DataTable()
    Private VistaOrdenCompra As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte Orden de Compra"
            LlenarDDs()
            divAvanzado.Visible = False
            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
        Else
            TablaOrdenCompra = CType(Session("TablaOrdenCompra"), DataTable)
            VistaOrdenCompra = CType(Session("VistaOrdenCompra"), DataView)
        End If
    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.IdProceso = CType(IIf(IsNumeric(TBOrden.Text), TBOrden.Text, -1), Integer)
        EntidadOrdenCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadOrdenCompra.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        EntidadOrdenCompra.IdSubclasificacion = CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadOrdenCompra.IdTipoPrioridad = CType(DDPrioridad.SelectedValue, Integer)
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadOrdenCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadOrdenCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        TBFechaInicio.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioOrdenCompra.ReporteOrdenCompra(EntidadOrdenCompra)
        TablaOrdenCompra = EntidadOrdenCompra.TablaConsulta
        GVOrden.DataSource = TablaOrdenCompra
        GVOrden.AutoGenerateColumns = False
        GVOrden.AllowSorting = True
        GVOrden.Columns.Clear()
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "ID", "IdOrden")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "ID Detalle", "IdOrdenDetalle")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Cantidad", "Cantidad")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Proveedor", "Proveedor")     
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Estado", "TipoSolicitudEstado")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Fecha", "Fecha")
        GVOrden.DataBind()
        Session("TablaOrdenCompra") = TablaOrdenCompra
        Session("VistaOrdenCompra") = VistaOrdenCompra
        LBCantidadBusqueda.Text = "Ordenes: " + (TablaOrdenCompra.Rows.Count - 1).ToString()
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
        TablaOrdenCompra = CType(Session("TablaOrdenCompra"), DataTable)
        VistaOrdenCompra = CType(Session("VistaOrdenCompra"), DataView)
        If TablaOrdenCompra IsNot Nothing Then
            Dim FileResponse As String = ""
            If TablaOrdenCompra.Rows.Count > 0 Then
                FileResponse = Cuadricula.ExportarTabla(TablaOrdenCompra, False,
                                                              "Id,Id Detalle,Codigo,Producto,Cantidad,Total,Proveedor,Estado,Fecha",
                                                              "IdOrden,IdOrdenDetalle,IdProductoCorto,Producto,Cantidad,Total,Proveedor,TipoSolicitudEstado,Fecha,")


                Dim Region As String = Request.QueryString("Region")
                Response.AddHeader("Content-disposition", "attachment; filename=ReporteOrdenCompra" + Now.ToString("ddMMyy") + ".csv")
                Response.ContentType = "text/csv"
                Response.Write(FileResponse)
                Response.End()
            End If
        Else
            Exit Sub
        End If
    End Sub
    Protected Sub SortRecords(sender As Object, e As GridViewSortEventArgs) Handles GVOrden.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaOrdenCompra"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVOrden.DataSource = Vista
        GVOrden.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub MostrarTabla(EntidadOrdenCompra As Entidad.ReporteProcesoCompra)
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        NegocioOrdenCompra.ReporteOrdenCompra(EntidadOrdenCompra)
        TablaOrdenCompra = EntidadOrdenCompra.TablaConsulta
        If TablaOrdenCompra.Rows.Count = 1 Then
            TablaOrdenCompra.Clear()
        End If
        GVOrden.DataSource = TablaOrdenCompra
        GVOrden.AutoGenerateColumns = False
        GVOrden.AllowSorting = True
        GVOrden.Columns.Clear()
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "ID", "IdOrden")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "ID Detalle", "IdOrdenDetalle")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Cantidad", "Cantidad", "{0:N}")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Total", "Total", "{0:C}")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Proveedor", "Proveedor")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Estado", "TipoSolicitudEstado")
        Cuadricula.AgregarColumna(GVOrden, New BoundField(), "Fecha", "Fecha")
        GVOrden.DataBind()
        Session("TablaOrdenCompra") = TablaOrdenCompra
        Session("VistaOrdenCompra") = VistaOrdenCompra
        LBCantidadBusqueda.Text = "Ordenes: " + (TablaOrdenCompra.Rows.Count - 1).ToString()
    End Sub

    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdAlmacen = -1
        EntidadOrdenCompra.IdClasificacion = -1
        EntidadOrdenCompra.IdSubclasificacion = -1
        EntidadOrdenCompra.IdTipoPrioridad = -1
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = -1
        EntidadOrdenCompra.FechaInicio = Now
        EntidadOrdenCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadOrdenCompra)
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdAlmacen = -1
        EntidadOrdenCompra.IdClasificacion = -1
        EntidadOrdenCompra.IdSubclasificacion = -1
        EntidadOrdenCompra.IdTipoPrioridad = -1
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = -1
        EntidadOrdenCompra.FechaInicio = fechainicio
        EntidadOrdenCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadOrdenCompra)
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdAlmacen = -1
        EntidadOrdenCompra.IdClasificacion = -1
        EntidadOrdenCompra.IdSubclasificacion = -1
        EntidadOrdenCompra.IdTipoPrioridad = -1
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = -1
        EntidadOrdenCompra.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadOrdenCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadOrdenCompra)
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdAlmacen = -1
        EntidadOrdenCompra.IdClasificacion = -1
        EntidadOrdenCompra.IdSubclasificacion = -1
        EntidadOrdenCompra.IdTipoPrioridad = -1
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = -1
        EntidadOrdenCompra.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadOrdenCompra.FechaFin = Now
        TBFechaInicio.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        MostrarTabla(EntidadOrdenCompra)
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        LlenarSolicitudes()
    End Sub
    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        Imprimir()
    End Sub
    Private Sub Imprimir()
        Dim objFSO, objTextFile
        Dim sRead, sReadLine, sReadAll
        Const ForReading = 1
        objFSO = CreateObject("Scripting.FileSystemObject")
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\Compra\Reportes\ReporteOrdenCompra.html", ForReading)
        ' Use different methods to read contents of file. ï»¿

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        'Session("i") = 1

        'Dim ventaNegocio As New Negocio.Venta
        Dim compraNegocio As New Negocio.OrdenCompra
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaOrdenCompra"), DataTable)
        'ventaNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        compraNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        Session("HMTLImprimir") = cadena
        'Dim ruta = Server.MapPath("~") + "Imprimir\Imprimir.aspx"
        'Dim abrir As String = "window.open(""" + ruta + """, '_newtab');"
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), abrir, True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "abrirImprimir()", True)
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "Prueba", "abrirImprimir()", True)
        'Response.Redirect("~/Imprimir/Imprimir.aspx")
        'MVVenta.SetActiveView(ContenidoPrinicpal)
    End Sub
End Class