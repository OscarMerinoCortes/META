Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Registro"
            'Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            TBFechaInicioConsultar.Text = CDate(Date.FromOADate(1 / 1 / 1990)).ToString("dd/MM/yyyy")
            TBFechaFinConsultar.Text = CDate(Now).ToString("dd/MM/yyyy")

            DDGeneroConsulta.Items.Add(New ListItem("MASCULINO", "1"))
            DDGeneroConsulta.Items.Add(New ListItem("FEMENINO", "2"))

            DDTipoPersonaConsulta.Items.Add(New ListItem("FISICA", "1"))
            DDTipoPersonaConsulta.Items.Add(New ListItem("MORAL", "2"))
            SeleccionarView(0)
        End If
    End Sub
    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            Consultar()
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub
    Public Sub Consultar()
        Dim NegocioCredito As New Negocio.Credito()
        Dim EntidadCredito As New Entidad.Credito()
        Dim TablaEvaluacion As New DataTable



        EntidadCredito.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadCredito.IdCredito = IIf(TBIdPersonaConsultar.Text Is String.Empty, 0, TBIdPersonaConsultar.Text)
        EntidadCredito.Nombre = TBNombreClienteConsultar.Text
        EntidadCredito.FechaCreacion = CDate(TBFechaInicioConsultar.Text)
        EntidadCredito.FechaActualizacion = CDate(TBFechaFinConsultar.Text)
        EntidadCredito.IdTipoGenero = DDGeneroConsulta.SelectedValue
        EntidadCredito.IdTipoPersona = DDTipoPersonaConsulta.SelectedValue
        NegocioCredito.Consultar(EntidadCredito)
        TablaEvaluacion = EntidadCredito.TablaConsulta
        GVRegistro.Columns.Clear()
        GVRegistro.DataSource = TablaEvaluacion
        GVRegistro.AutoGenerateColumns = False
        GVRegistro.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVRegistro.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRegistro, New BoundField(), "ID Cliente", "ID Cliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRegistro, New BoundField(), "Nombre Cliente", "Nombre Cliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRegistro, New BoundField(), "Estado Credito", "Estado Credito")
        GVRegistro.DataBind()
        Session("TablaEvaluacion") = TablaEvaluacion
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdCredito.Text = ""
        TBFechaApertura.Text = ""
        TBFechaVencimiento.Text = ""
        TBMonto.Text = ""
        DDEstado.SelectedValue = "1"
        wucConsultarPersona1.Nuevo()
        wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioCredito As New Negocio.Credito()
        Dim EntidadCredito As New Entidad.Credito()
        If TBIdCredito.Text Is String.Empty Then
            EntidadCredito.IdCredito = 0
        Else
            EntidadCredito.IdCredito = CInt(TBIdCredito.Text)
        End If

        Dim IdPersona = 0
        Dim Equivalencia = ""
        Dim Nombre = ""

        wucConsultarPersona1.ObtenerPersona(IdPersona, Equivalencia, Nombre)

        If IdPersona = 0 Then
            Exit Sub
        Else
            EntidadCredito.IdPersonaSolicitante = IdPersona
        End If

        If TBFechaApertura.Text Is String.Empty Then
            Exit Sub
        Else
            EntidadCredito.FechaApertura = CDate(TBFechaApertura.Text)
        End If
        EntidadCredito.FechaVencimiento = CDate(TBFechaVencimiento.Text)
        If TBMonto.Text Is String.Empty Then
            Exit Sub
        Else
            EntidadCredito.Monto = CDbl(TBMonto.Text)
        End If
        EntidadCredito.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadCredito.IdEstadoCredito = 3
        NegocioCredito.Guardar(EntidadCredito)
        TBIdCredito.Text = EntidadCredito.IdCredito
        SeleccionarView(0)
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVRegistro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVRegistro.SelectedIndexChanged
        Dim TablaEvaluacion As New DataTable
        TablaEvaluacion = Session("TablaEvaluacion")
        TBIdCredito.Text = TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("Credito")        
        TBFechaApertura.Text = TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("Fecha Apertura")
        TBFechaVencimiento.Text = TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("Fecha Vencimiento")
        TBMonto.Text = TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("Monto")
        DDEstado.Text = TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("IdEstado")

        wucConsultarPersona1.AsignarPersona(TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("ID Cliente"), "",
                                            TablaEvaluacion.Rows(GVRegistro.SelectedIndex).Item("Nombre Cliente"))

        wucDatosAuditoria1.SeleccionarIndice(TablaEvaluacion.Rows(GVRegistro.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class