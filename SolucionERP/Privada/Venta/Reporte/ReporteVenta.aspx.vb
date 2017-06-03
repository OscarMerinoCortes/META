Imports System.Data
Imports Comun.Presentacion
Imports Entidad
Imports Operacion.Configuracion.Constante
Imports TipoCaja = Negocio.TipoCaja
Imports TipoUsuario = Negocio.TipoUsuario
Imports TipoVenta = Negocio.TipoVenta

Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Venta"
            divAvanzado.Visible = False
            ''DDTipo
            'DDTipo.Items.Add(New ListItem("RESUMIDO POR VENTA", 1))
            'DDTipo.Items.Add(New ListItem("DETALLADO POR VENTA", 2))
            'DDTipo.SelectedValue = 1
            'DDVentaEstado
            Dim NegocioReporteVenta As New Negocio.ReporteVenta()
            Dim EntidadReporteVenta As New Entidad.ReporteVenta()
            Dim tarjeta As New Tarjeta()
            EntidadReporteVenta.Tarjeta = tarjeta
            EntidadReporteVenta.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioReporteVenta.Consultar(EntidadReporteVenta)
            DDVentaEstado.DataSource = EntidadReporteVenta.TablaConsulta
            DDVentaEstado.DataValueField = "ID"
            DDVentaEstado.DataTextField = "Descripcion"
            DDVentaEstado.DataBind()
            DDVentaEstado.Items.Add(New ListItem("TODOS", -1))
            DDVentaEstado.SelectedValue = -1
            'Fechas
            TBFechaInicio.Text = "01/01/2016"
            TBFechaFin.Text = DateTime.Now.ToString("dd/MM/yyyy")
            'DDSucursal
            Dim tabla = New DataTable
            Dim NegocioSucursal As New Negocio.Sucursal()
            Dim EntidadSucursal As New Entidad.Sucursal()
            EntidadSucursal.Tarjeta = tarjeta
            EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaDetallada
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            DDSucursal.DataValueField = "ID"
            DDSucursal.DataTextField = "Descripcion"
            DDSucursal.DataBind()
            DDSucursal.Items.Add(New ListItem("TODOS", -1))
            DDSucursal.SelectedValue = -1

            'DDVenta---
            Dim NegocioTipoVenta As New TipoVenta()
            Dim EntidadTipoVenta As New Entidad.TipoVenta()
            EntidadTipoVenta.Tarjeta = tarjeta
            EntidadTipoVenta.Tarjeta.Consulta = Consulta.ConsultaDetallada
            NegocioTipoVenta.Consultar(EntidadTipoVenta)
            DDVenta.DataSource = EntidadTipoVenta.TablaConsulta
            DDVenta.DataValueField = "ID"
            DDVenta.DataTextField = "Descripcion"
            DDVenta.DataBind()
            DDVenta.Items.Add(New ListItem("TODOS", -1))
            DDVenta.SelectedValue = -1
            MultiView1.SetActiveView(View1)
        Else
        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs)
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = TBLVFolio.Text
        EntidadReporteVenta.IdVendedor = 0
        If IsNumeric(TBVendedor.Text) Then
            EntidadReporteVenta.IdVendedor = CInt(TBVendedor.Text)
        End If
        EntidadReporteVenta.IdVentaEstado = DDVentaEstado.SelectedValue
        EntidadReporteVenta.IdSucursal = CInt(DDSucursal.SelectedValue)
        EntidadReporteVenta.IdTipoVenta = DDVenta.SelectedValue
        EntidadReporteVenta.FechaCreacion = CDate(TBFechaInicio.Text)
        EntidadReporteVenta.FechaActualizacion = CDate(TBFechaFin.Text)
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaConsulta"), DataTable)
        Dim FileResponse As String = ""
        FileResponse = Cuadricula.ExportarTabla(Tabla, False, _
                                                           "ID, Folio, Fecha, Cliente, Vendedor, Sucursal, Tipo Venta, Estado Venta, Subtotal, Descuento, Cargo, Total", _
                                                          "IdVenta, Folio, Fecha, Cliente, Vendedor, Sucursal, Venta, Estado, Subtotal, Descuento, Cargo, Total,")
        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteVenta.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub
    Protected Sub SortRecords(sender As Object, e As GridViewSortEventArgs) Handles GVReporteVenta.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaConsulta"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVReporteVenta.DataSource = Vista
        GVReporteVenta.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        Imprimir()
    End Sub
    Private Sub Imprimir()
        Dim objFSO, objTextFile
        Dim sRead, sReadLine, sReadAll
        Const ForReading = 1
        objFSO = CreateObject("Scripting.FileSystemObject")
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\Venta\Reportes\ReporteVenta.html", ForReading)
        ' Use different methods to read contents of file. ï»¿

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        'Session("i") = 1

        Dim ventaNegocio As New Negocio.Venta
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaConsulta"), DataTable)
        ventaNegocio.ProcesarImprimirReporte(Tabla, cadena, 2)
        Session("HMTLImprimir") = cadena
        'Dim ruta = Server.MapPath("~") + "Imprimir\Imprimir.aspx"
        'Dim abrir As String = "window.open(""" + ruta + """, '_newtab');"
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), abrir, True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "abrirImprimir()", True)
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "Prueba", "abrirImprimir()", True)
        'Response.Redirect("~/Imprimir/Imprimir.aspx")
        'MVVenta.SetActiveView(ContenidoPrinicpal)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVBusquedaVenta_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub Consultar(EntidadReporteVenta As Venta)
        Dim NegocioReporteVenta As New Negocio.Venta
        Dim TablaConsulta As New DataTable
        EntidadReporteVenta.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioReporteVenta.VentaObtener(EntidadReporteVenta)
        TablaConsulta = EntidadReporteVenta.TablaConsulta
        GVReporteVenta.DataSource = TablaConsulta
        GVReporteVenta.DataBind()
        Session("TablaConsulta") = TablaConsulta
        LBCantidadBusqueda.Text = "Ventas: " + TablaConsulta.Rows.Count.ToString()
    End Sub

    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = Now
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1

        'Obtener primer dia de la semana en este caso domingo
        Dim diaSemana As DateTime = Now.AddDays(-1)
        While diaSemana.DayOfWeek <> DayOfWeek.Sunday
            diaSemana = diaSemana.AddDays(-1)
        End While

        EntidadReporteVenta.FechaCreacion = diaSemana
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = CDate("01/" + Now.Date.ToString("MM/yyyy"))
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        divAvanzado.Visible = False
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = ""
        EntidadReporteVenta.IdVendedor = 0
        EntidadReporteVenta.IdVentaEstado = -1
        EntidadReporteVenta.IdSucursal = -1
        EntidadReporteVenta.IdTipoVenta = -1
        EntidadReporteVenta.FechaCreacion = CDate("01/01/" + Now.Date.ToString("yyyy"))
        EntidadReporteVenta.FechaActualizacion = Now
        Consultar(EntidadReporteVenta)
    End Sub
    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Dim EntidadReporteVenta As New Entidad.Venta()
        EntidadReporteVenta.Folio = TBLVFolio.Text
        EntidadReporteVenta.IdVendedor = 0
        If IsNumeric(TBVendedor.Text) Then
            EntidadReporteVenta.IdVendedor = CInt(TBVendedor.Text)
        End If
        EntidadReporteVenta.IdVentaEstado = DDVentaEstado.SelectedValue
        EntidadReporteVenta.IdSucursal = CInt(DDSucursal.SelectedValue)
        EntidadReporteVenta.IdTipoVenta = DDVenta.SelectedValue
        EntidadReporteVenta.FechaCreacion = CDate(TBFechaInicio.Text)
        EntidadReporteVenta.FechaActualizacion = CDate(TBFechaFin.Text)
        Consultar(EntidadReporteVenta)
    End Sub
End Class