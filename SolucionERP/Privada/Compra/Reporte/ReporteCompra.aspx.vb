Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Protected TablaCompra As New DataTable()
    Protected VistaCompra As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Compra"
            LlenarDDs()

            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
            divAvanzado.Visible = False
        Else
            TablaCompra = CType(Session("TablaCompra"), DataTable)
            VistaCompra = CType(Session("VistaCompra"), DataView)
        End If
    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioCompra As New Negocio.Compra()
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        EntidadCompra.IdProceso = CType(IIf(IsNumeric(TBCompra.Text), TBCompra.Text, -1), Integer)
        EntidadCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadCompra.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        EntidadCompra.IdSubclasificacion = CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadCompra.IdTipoPrioridad = CType(DDPrioridad.SelectedValue, Integer)
        EntidadCompra.IdEstado = -1
        EntidadCompra.IdSolicitudEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        TBFechaInicio.Text = EntidadCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioCompra.ReporteCompra(EntidadCompra)
        TablaCompra = EntidadCompra.TablaConsulta
        GVCompra.DataSource = TablaCompra
        GVCompra.AutoGenerateColumns = False
        GVCompra.AllowSorting = True
        GVCompra.Columns.Clear()
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID", "IdCompra")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID Detalle", "IdCompraDetalle")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cantidad", "Cantidad")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Proveedor", "Proveedor")
        'Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Prioridad", "TipoPrioridad")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Estado", "TipoSolicitudEstado")
        'Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Usuario", "Usuario")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Fecha", "Fecha")
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
        LBCantidadBusqueda.Text = "Compras: " + TablaCompra.Rows.Count.ToString()
        LBCantidadBusqueda.Text = "Compras: " + (TablaCompra.Rows.Count - 1).ToString()
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
        TablaCompra = CType(Session("TablaCompra"), DataTable)
        VistaCompra = CType(Session("VistaCompra"), DataView)
        If TablaCompra IsNot Nothing Then
            Dim FileResponse As String = ""
            If TablaCompra.Rows.Count > 0 Then
                If TablaCompra.Columns.Count = 9 Then
                    FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                                       "Id,Tot. Productos, Tot. Cantidades,Total,Proveedor,Forma Pago,Fecha",
                                                                       "IdCompra,Productos,Cantidades,Total,Proveedor,FormaPago,Fecha")
                Else
                    FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                                  "Id,Id Detalle,Codigo,Producto,Cantidad,Total,Proveedor,Estado,Fecha",
                                                                  "IdCompra,IdCompraDetalle,IdProductoCorto,Producto,Cantidad,Total,Proveedor,TipoSolicitudEstado,Fecha,")
                End If
                Dim Region As String = Request.QueryString("Region")
                Response.AddHeader("Content-disposition", "attachment; filename=ReporteCompra" + Now.ToString("ddMMyy") + ".csv")
                Response.ContentType = "text/csv"
                Response.Write(FileResponse)
                Response.End()
            End If
        Else
            Exit Sub
        End If

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
    Protected Sub MostrarTabla(EntidadCompra As Entidad.ReporteProcesoCompra)
        Dim NegocioCompra As New Negocio.Compra()
        NegocioCompra.ReporteCompra(EntidadCompra)
        TablaCompra = EntidadCompra.TablaConsulta
        GVCompra.DataSource = TablaCompra
        GVCompra.AutoGenerateColumns = False
        GVCompra.AllowSorting = True
        GVCompra.Columns.Clear()
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID", "IdCompra")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID Detalle", "IdCompraDetalle")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Codigo", "IdproductoCorto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Producto", "Producto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Destino", "Almacen")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cantidad", "Cantidad")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Proveedor", "Proveedor")
        'Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Prioridad", "TipoPrioridad")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Estado", "TipoSolicitudEstado")
        'Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Usuario", "Usuario")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Fecha", "Fecha")
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
        LBCantidadBusqueda.Text = "Compras: " + (TablaCompra.Rows.Count - 1).ToString()
    End Sub
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        EntidadCompra.IdProceso = -1
        EntidadCompra.IdAlmacen = -1
        EntidadCompra.IdClasificacion = -1
        EntidadCompra.IdSubclasificacion = -1
        EntidadCompra.IdTipoPrioridad = -1
        EntidadCompra.IdEstado = -1
        EntidadCompra.IdSolicitudEstado = -1
        EntidadCompra.FechaInicio = Now
        EntidadCompra.FechaFin = Now
        MostrarTabla(EntidadCompra)
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        EntidadCompra.IdProceso = -1
        EntidadCompra.IdAlmacen = -1
        EntidadCompra.IdClasificacion = -1
        EntidadCompra.IdSubclasificacion = -1
        EntidadCompra.IdTipoPrioridad = -1
        EntidadCompra.IdEstado = -1
        EntidadCompra.IdSolicitudEstado = -1
        Dim diaSemana As DateTime = Now.AddDays(-1)
        While diaSemana.DayOfWeek <> DayOfWeek.Sunday
            diaSemana = diaSemana.AddDays(-1)
        End While
        EntidadCompra.FechaInicio = diaSemana
        EntidadCompra.FechaFin = Now
        MostrarTabla(EntidadCompra)
    End Sub
    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        EntidadCompra.IdProceso = -1
        EntidadCompra.IdAlmacen = -1
        EntidadCompra.IdClasificacion = -1
        EntidadCompra.IdSubclasificacion = -1
        EntidadCompra.IdTipoPrioridad = -1
        EntidadCompra.IdEstado = -1
        EntidadCompra.IdSolicitudEstado = -1
        EntidadCompra.FechaInicio = CDate("01/" + Now.Date.ToString("MM/yyyy"))
        EntidadCompra.FechaFin = Now
        MostrarTabla(EntidadCompra)
    End Sub
    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        EntidadCompra.IdProceso = -1
        EntidadCompra.IdAlmacen = -1
        EntidadCompra.IdClasificacion = -1
        EntidadCompra.IdSubclasificacion = -1
        EntidadCompra.IdTipoPrioridad = -1
        EntidadCompra.IdEstado = -1
        EntidadCompra.IdSolicitudEstado = -1
        EntidadCompra.FechaInicio = CDate("01/01/" + Now.Date.ToString("yyyy"))
        EntidadCompra.FechaFin = Now
        MostrarTabla(EntidadCompra)
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
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\Compra\Reportes\ReporteCompra.html", ForReading)
        ' Use different methods to read contents of file. ï»¿

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        'Session("i") = 1

        'Dim ventaNegocio As New Negocio.Venta
        Dim compraNegocio As New Negocio.Compra
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaCompra"), DataTable)
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