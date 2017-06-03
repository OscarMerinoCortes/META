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
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Caja"
            'Fechas
            'TBFechaInicio.Text = "01/01/2016"
            TBFechaInicio.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()
            TBFechaFin.Text = DateTime.Now.ToString("dd/MM/yyyy")
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
            BTNBuscar.Visible = False
            MultiView1.SetActiveView(View1)
        Else
        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        Dim TablaConsulta As New DataTable
        If TBIdCliente.Text Is String.Empty Then
            EntidadCaja.IdPersona = -1
        Else
            EntidadCaja.IdPersona = CType(TBIdCliente.Text, Integer)
        End If
        EntidadCaja.IdSucursal = CType(DDSucursal.SelectedValue, Integer)
        EntidadCaja.FechaInicio = TBFechaInicio.Text
        EntidadCaja.FechaFin = TBFechaFin.Text
        NegocioCaja.ReporteMovimientosCaja(EntidadCaja)
        TablaConsulta = EntidadCaja.TablaConsulta
        GVReporteCaja.Columns.Clear()
        GVReporteCaja.DataSource = TablaConsulta
        GVReporteCaja.AutoGenerateColumns = False
        GVReporteCaja.AllowSorting = True
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "ID", "ID")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Serie", "Serie")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Folio", "Folio")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Fecha", "Fecha", "{0:D}")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Nombre del Cliente", "Cliente")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Monto", "Monto", "{0:C}")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Estado", "Estado")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Venta", "TipoVenta")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Subtotal", "Subtotal", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Descuento", "Descuento", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Cargo", "Cargo", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Total", "Total", "{0:C}")
        GVReporteCaja.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        Dim TablaReporteCaja As New DataTable()
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        TablaReporteCaja = Session("TablaConsulta")    
        Dim FileResponse As String = ""
        FileResponse = Cuadricula.ExportarTabla(TablaReporteCaja, False, _
                                                           "ID, Id Cliente, Serie, Folio, Fecha, Nombre del Cliente, Monto, Estado", _
                                                          "ID, IDCliente, Serie, Folio, Fecha, Cliente, Monto, Estado,")
        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteVenta.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub
    Protected Sub SortRecords(sender As Object, e As GridViewSortEventArgs) Handles GVReporteCaja.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaConsulta"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVReporteCaja.DataSource = Vista
        GVReporteCaja.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub BTNHoy_Click1(sender As Object, e As EventArgs) Handles BTNHoy.Click
        AvanzadoVisible(0)
        Dim FechaInicio As DateTime = Now
        Dim FechaFin As DateTime = Now
        ObtenerRangoFechas(FechaInicio, FechaFin)
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs) Handles BTNSemana.Click
        AvanzadoVisible(0)
        Dim Resta As Integer = Weekday(Now) - 1 'obtener los dias que se llevan de la semana menos el actual
        Dim FechaInicio As Date = Now.AddDays(-(Resta)) 'restamos los dias de la semana del calculo anterior a la fecha actual para que me de la fecha con la que se inicio la semana
        ' Dim Semana As Integer = DatePart(DateInterval.WeekOfYear, Now, 0) ' me da el numero de la semana que va del año
        Dim Suma As Integer = 7 - Weekday(Now) 'obtenemos los dias que faltan para la culminacion de la semana
        Dim FechaFin As Date = Now.AddDays(Suma) 'sumamos los dias de la semana del calculo anterior a la fecha actual para que me de la fecha con la que se termina la semana
        ObtenerRangoFechas(FechaInicio, FechaFin)
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs) Handles BTNMes.Click
        AvanzadoVisible(0)
        Dim FechaInicio As DateTime = DateSerial(Year(Now), Month(Now) + 0, 1)
        Dim FechaFin As DateTime = DateSerial(Year(Now), Month(Now) + 1, 0)
        ObtenerRangoFechas(FechaInicio, FechaFin)
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs) Handles BTNAno.Click
        AvanzadoVisible(0)
        Dim FechaInicio As DateTime = New DateTime(Now.Year, 1, 1)
        Dim UltimoDiaAno As DateTime = New DateTime(Now.Year, 12, 1)
        Dim FechaFin As DateTime = DateSerial(Year(UltimoDiaAno), Month(UltimoDiaAno) + 1, 0)
        ObtenerRangoFechas(FechaInicio, FechaFin)

    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs) Handles BTNAvanzado.Click
        AvanzadoVisible(1)
    End Sub
    Public Sub ObtenerRangoFechas(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        Dim TablaConsulta As New DataTable
        If TBIdCliente.Text Is String.Empty Then
            EntidadCaja.IdPersona = -1
        Else
            EntidadCaja.IdPersona = CType(TBIdCliente.Text, Integer)
        End If
        EntidadCaja.IdSucursal = CType(DDSucursal.SelectedValue, Integer)
        EntidadCaja.FechaInicio = FechaInicio
        EntidadCaja.FechaFin = FechaFin
        NegocioCaja.ReporteMovimientosCaja(EntidadCaja)
        TablaConsulta = EntidadCaja.TablaConsulta
        GVReporteCaja.Columns.Clear()
        GVReporteCaja.DataSource = TablaConsulta
        GVReporteCaja.AutoGenerateColumns = False
        GVReporteCaja.AllowSorting = True
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "ID", "ID")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Serie", "Serie")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Folio", "Folio")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Fecha", "Fecha", "{0:D}")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Nombre del Cliente", "Cliente")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Monto", "Monto", "{0:C}")
        Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Estado", "Estado")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Venta", "TipoVenta")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Subtotal", "Subtotal", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Descuento", "Descuento", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Cargo", "Cargo", "{0:C}")
        'Cuadricula.AgregarColumna(GVReporteCaja, New BoundField(), "Total", "Total", "{0:C}")
        GVReporteCaja.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Public Sub AvanzadoVisible(Op As Integer)
        If Op = 0 Then
            RWAl.Visible = False
            RWDe.Visible = False
            RWSucursal.Visible = False
            BTNBuscar.Visible = False
        ElseIf Op = 1 Then
            RWAl.Visible = True
            RWDe.Visible = True
            RWSucursal.Visible = True
            BTNBuscar.Visible = True
        End If
    End Sub


    Protected Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click
        Dim FechaInicio As DateTime = TBFechaInicio.Text
        Dim FechaFin As DateTime = TBFechaFin.Text
        ObtenerRangoFechas(FechaInicio, FechaFin)
    End Sub
End Class