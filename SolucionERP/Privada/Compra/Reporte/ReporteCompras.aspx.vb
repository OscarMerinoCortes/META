Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Public Overridable Property HorizontalAlign As HorizontalAlign
    Private TablaCompra As New DataTable()
    Private VistaCompra As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte de Compra"
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
        Dim NegocioCompra As New Negocio.Compra()
        Dim EntidadCompra As New Entidad.ReporteProcesoCompra()
        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)

        EntidadCompra.IdProveedor = IdProveedor
        EntidadCompra.IdSolicitudEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        TBFechaInicio.Text = EntidadCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadCompra.FechaFin.ToString("dd/MM/yyyy")
        EntidadCompra.Identificador = 1
        NegocioCompra.ReporteCompra(EntidadCompra)

        TablaCompra = EntidadCompra.TablaConsulta
        GVCompra.DataSource = TablaCompra
        GVCompra.AutoGenerateColumns = False
        GVCompra.AllowSorting = True
        GVCompra.Columns.Clear()

        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID Compra", "IdCompra")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "ID Proveedor", "IdPersona")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Proveedor", "Proveedor")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "SubTotal", "SubTotal")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Interes Credito %", "InteresCredito")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "IVA", "IVA")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Cargos", "Cargos")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Total", "Total")
        Cuadricula.AgregarColumna(GVCompra, New BoundField(), "Fecha", "Fecha", , Type.GetType("System.Date"))
        GVCompra.DataBind()
        Session("TablaCompra") = TablaCompra
        Session("VistaCompra") = VistaCompra
    End Sub
    Private Sub LlenarDDs()


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


    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        LlenarSolicitudes()
    End Sub
    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click
        TablaCompra = CType(Session("TablaCompra"), DataTable)
        VistaCompra = CType(Session("VistaCompra"), DataView)
        If TablaCompra IsNot Nothing Then
            Dim FileResponse As String = ""
            If TablaCompra.Rows.Count > 0 Then
                FileResponse = Cuadricula.ExportarTabla(TablaCompra, False,
                                                                   "IdCompra,Id Proveedor,Proveedor ,SubTotal,Interes Credito,IVA,Cargos,Total,Fecha",
                                                                   "IdCompra,IdPersona,Proveedor,SubTotal,InteresCredito,IVA,Cargos,Total,Fecha,")


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

End Class