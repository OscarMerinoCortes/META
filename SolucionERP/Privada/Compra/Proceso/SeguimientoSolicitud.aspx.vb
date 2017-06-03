Imports System.Collections.ObjectModel
Imports System.Data
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Web.Services

Partial Class _Default
    Inherits Page
    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Autorizacion de solicitud de compra"
            LlenarDDs()
            TBFechaInicio.Text = "01/01/1900"
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
            divAvanzado.Visible = False
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
        End If
    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = CType(IIf(IsNumeric(TBSolicitud.Text), TBSolicitud.Text, -1), Integer)
        EntidadSolicitudCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadSolicitudCompra.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdSubclasificacion = CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdTipoPrioridad = CType(DDPrioridad.SelectedValue, Integer)
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdSolicitudEstado = CType(DDEstado.SelectedValue, Integer)
        EntidadSolicitudCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadSolicitudCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioSolicitudCompra.ObtenerSolicitud(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
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
        DDEstado.SelectedValue = 1 'Solicitado
        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda
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
    Protected Sub GVICantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        Dim TBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim Cantidad As TextBox = CType(sender, TextBox)
        If IsNumeric(Cantidad.Text) Then
            GuardaFila(index, Cantidad.Text, CType(TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado"), Integer))
        End If
    End Sub

    Private Sub GuardaFila(index As Integer, cantidad As String, idEstado As Integer)
        Try
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            Dim validar As Integer
            validar = 0
            If idEstado = 3 And (TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 1 Or TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 4) Then 'si el estado es solicitado o en espera
                validar = 1
            End If
            If idEstado = 4 And (TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 1) Then 'si el estado es solicitado
                validar = 1
            End If
            If idEstado = 5 And (TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 4 Or TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 3 Or TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado") = 1) Then 'si el estado es en espera o autorizado o en solicitado
                validar = 1
            End If
            If validar = 1 Then
                Dim nSolicitudCompra = New Negocio.SolicitudCompra()
                Dim eSolicitudCompra = New Entidad.SolicitudCompra()
                'Se usa la clase de solicitud de compra para enviar los datos de solicitud detalle y asi no tener que crear otra clase
                eSolicitudCompra.IdSolicitudCompra = CType(TablaSolicitudDetalle.Rows(index).Item("IdSolicitudDetalle"), Integer)
                If cantidad <> "" Then
                    eSolicitudCompra.IdEstado = CType(cantidad, Integer)
                Else
                    eSolicitudCompra.IdEstado = CType(TablaSolicitudDetalle.Rows(index).Item("Cantidad"), Integer)
                End If
                eSolicitudCompra.IdTipoSolicitudEstado = idEstado
                eSolicitudCompra.Descripcion = ""
                'If CType(TablaSolicitudDetalle.Rows(index).Item("IdTipoSolicitudEstado"), Integer) <> idEstado Then
                nSolicitudCompra.ActualizarSolicitudDetalle(eSolicitudCompra)
            End If
            DDEstado.SelectedValue = 1 'Consulta los solicitados
            LlenarSolicitudes()
        Catch ex As Exception
        End Try
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
            Try
                EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, -1, "TODO")
            Catch ex As Exception
                EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1, "TODO")
            End Try

            DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubclasificacion.DataValueField = "ID"
            DDSubclasificacion.DataTextField = "Descripcion"
        End If
        DDSubclasificacion.DataBind()
        DDSubclasificacion.SelectedValue = "-1"

    End Sub

    Protected Sub BTNAutorizarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GuardaFila(i, "", 3)
        Next
    End Sub

    Protected Sub BTNAutorizar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        GuardaFila(index, "", 3)
    End Sub

    Protected Sub BTNEsperaTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GuardaFila(i, "", 4)
        Next
    End Sub

    Protected Sub BTNEspera_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        GuardaFila(index, "", 4)
    End Sub

    Protected Sub BTNRechazarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GuardaFila(i, "", 5)
        Next
    End Sub

    Protected Sub BTNRechazar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        GuardaFila(index, "", 5)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs) Handles BTNAvanzado.Click
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        LlenarSolicitudes()
    End Sub
    Protected Sub LlenarSolicitudPrioridad(EntidadSolicitudCompra As Entidad.ReporteProcesoCompra)
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        NegocioSolicitudCompra.ObtenerSolicitud(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta
        GVSolicitud.DataSource = TablaSolicitudDetalle
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
    End Sub
    Protected Sub BTNBaja_Click(sender As Object, e As EventArgs) Handles BTNBaja.Click
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = 1 'baja
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdSolicitudEstado = 1 'Solicitado
        EntidadSolicitudCompra.FechaInicio = CDate("01/01/1900")
        EntidadSolicitudCompra.FechaFin = CDate(Now)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudPrioridad(EntidadSolicitudCompra)
    End Sub
    Protected Sub BTNMedia_Click(sender As Object, e As EventArgs) Handles BTNMedia.Click
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = 2 'media
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdSolicitudEstado = 1 'Solicitado
        EntidadSolicitudCompra.FechaInicio = CDate("01/01/1900")
        EntidadSolicitudCompra.FechaFin = CDate(Now)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudPrioridad(EntidadSolicitudCompra)
    End Sub
    Protected Sub BTNAlta_Click(sender As Object, e As EventArgs) Handles BTNAlta.Click
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = 3 'alta
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdSolicitudEstado = 1 'Solicitado
        EntidadSolicitudCompra.FechaInicio = CDate("01/01/1900")
        EntidadSolicitudCompra.FechaFin = CDate(Now)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudPrioridad(EntidadSolicitudCompra)
    End Sub
    Protected Sub BTNTodo_Click(sender As Object, e As EventArgs) Handles BTNTodo.Click
        divAvanzado.Visible = False
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1 'TODO
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdSolicitudEstado = 1 'Solicitado
        EntidadSolicitudCompra.FechaInicio = CDate("01/01/1900")
        EntidadSolicitudCompra.FechaFin = CDate(Now)
        TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudPrioridad(EntidadSolicitudCompra)
    End Sub
End Class