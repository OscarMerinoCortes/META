Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Protected TablaCompra As New DataTable()
    Protected VistaCompra As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Cuenta por cobrar"
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
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()
        Dim IdPersona As Integer
        IdPersona = 0
        Dim Equivalencia As String
        Dim Nombre As String
        wucConPer.ObtenerPersona(IdPersona, Equivalencia, Nombre)
        EntidadCCP.IdPersona = IdPersona
        EntidadCCP.IdEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadCCP.IdTipoCCP = 1
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
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IdPersona", "IdPersona")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Nombre", "Nombre")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Subtotal", "Monto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IVA", "IVA")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cargos", "Cargos")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Estado", "Estado")
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
        LBCantidadBusqueda.Text = "Cuentas por Cobrar: " + TablaCompra.Rows.Count.ToString()
        LBCantidadBusqueda.Text = "Cuentas por Cobrar: " + (TablaCompra.Rows.Count).ToString()
    End Sub
    Private Sub LlenarDDs()
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
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        TablaCompra = CType(Session("TablaCompra"), DataTable)
        VistaCompra = CType(Session("VistaCompra"), DataView)
        Dim FileResponse As String = ""
        If TablaCompra.Rows.Count > 0 Then
            If TablaCompra.Columns.Count = 9 Then
                FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                                       "Id,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado, ",
                                                              "IdCCP,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado, ")
            Else
                FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                              "Id,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado, ",
                                                              "IdCCP,FechaExpedicion,IdPersona,Nombre,Monto,IVA,Cargos,Total,Estado, ")
            End If
            Dim Region As String = Request.QueryString("Region")
            Response.AddHeader("Content-disposition", "attachment; filename=ReporteCompra" + Now.ToString("ddMMyy") + ".csv")
            Response.ContentType = "text/csv"
            Response.Write(FileResponse)
            Response.End()
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
    Protected Sub MostrarTabla(EntidadCCP As Entidad.CCP)
        Dim NegocioCCP As New Negocio.CCP()
        NegocioCCP.ReporteCCP(EntidadCCP)
        TablaCompra = EntidadCCP.TablaConsulta
        GVCompra.DataSource = TablaCompra
        GVCompra.AutoGenerateColumns = False
        GVCompra.AllowSorting = True
        GVCompra.Columns.Clear()
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID", "IdCCP")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Fecha", "FechaExpedicion")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IdPersona", "IdPersona")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Nombre", "Nombre")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Subtotal", "Monto")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IVA", "IVA")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cargos", "Cargos")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Estado", "Estado")
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
        LBCantidadBusqueda.Text = "Cuentas por Cobrar: " + (TablaCompra.Rows.Count).ToString()
    End Sub
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCCP As New Entidad.CCP()
        EntidadCCP.IdPersona = 0
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.IdEstado = -1
        EntidadCCP.FechaExpedicion = Now
        EntidadCCP.FechaVencimiento = Now
        MostrarTabla(EntidadCCP)
    End Sub
    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCCP As New Entidad.CCP()
        EntidadCCP.IdPersona = 0
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.IdEstado = -1
        Dim diaSemana As DateTime = Now.AddDays(-1)
        While diaSemana.DayOfWeek <> DayOfWeek.Sunday
            diaSemana = diaSemana.AddDays(-1)
        End While
        EntidadCCP.FechaExpedicion = diaSemana
        EntidadCCP.FechaVencimiento = Now
        MostrarTabla(EntidadCCP)
    End Sub
    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCCP As New Entidad.CCP()
        EntidadCCP.IdPersona = 0
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.IdEstado = -1
        EntidadCCP.FechaExpedicion = CDate("01/" + Now.Date.ToString("MM/yyyy"))
        EntidadCCP.FechaVencimiento = Now
        MostrarTabla(EntidadCCP)
    End Sub
    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadCCP As New Entidad.CCP()
        EntidadCCP.IdPersona = 0
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.IdEstado = -1
        EntidadCCP.FechaExpedicion = CDate("01/01/" + Now.Date.ToString("yyyy"))
        EntidadCCP.FechaVencimiento = Now
        MostrarTabla(EntidadCCP)
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
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\CXC\Reportes\ReporteCuentaPorCobrar.html", ForReading)

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        Dim ccpNegocio As New Negocio.CCP
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaCompra"), DataTable)
        ccpNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        Session("HMTLImprimir") = cadena
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "abrirImprimir()", True)
    End Sub
End Class