Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Autorizar"
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            LlenarDropDownLists()
            SeleccionarView(0)
        End If
    End Sub
    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then        
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        ElseIf v = 1 Then
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        Else
            MultiView1.SetActiveView(VNuevo)
            IBTGuardar.Visible = True
        End If
    End Sub
    Public Sub LlenarDropDownLists()
        'DD ESTADO CREDITO
        Dim NegocioCredito As New Negocio.Credito()
        Dim EntidadCredito As New Entidad.Credito()
        EntidadCredito.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioCredito.Consultar(EntidadCredito)
        DDEstado2.DataSource = EntidadCredito.TablaConsulta
        DDEstado2.DataValueField = "Id"
        DDEstado2.DataTextField = "Descripcion"
        DDEstado2.DataBind()
        DDEstado2.Items.Add(New ListItem("TODOS", -1))
        DDEstado2.SelectedValue = -1
    End Sub
    Public Sub ConsultarPendientes()
        Dim NegocioCredito As New Negocio.Credito()
        Dim EntidadCredito As New Entidad.Credito()
        Dim TablaAutorizar As New DataTable
        EntidadCredito.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadCredito.IdEstadoCredito = 3
        NegocioCredito.Consultar(EntidadCredito)
        TablaAutorizar = EntidadCredito.TablaConsulta
        GVEvaluado.Columns.Clear()
        GVEvaluado.DataSource = TablaAutorizar
        GVEvaluado.AutoGenerateColumns = False
        GVEvaluado.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVEvaluado.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEvaluado, New BoundField(), "ID Cliente", "ID Cliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEvaluado, New BoundField(), "Nombre Cliente", "Nombre Cliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEvaluado, New BoundField(), "Estado Credito", "Estado Credito")
        GVEvaluado.DataBind()
        Session("TablaAutorizar") = TablaAutorizar
        SeleccionarView(0)
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdCredito.Text = ""
        wucConsultarPersona1.Nuevo()
        TBFechaApertura.Text = ""
        TBFechaVencimiento.Text = ""
        TBMonto.Text = ""
        DDEstado.SelectedValue = "1"
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
        EntidadCredito.IdEstadoCredito = 4
        NegocioCredito.Guardar(EntidadCredito)        
        TBIdCredito.Text = EntidadCredito.IdCredito
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
        LlenarDropDownLists()
        Try
            Dim TablaEvaluacion = CType(Session("TablaEvaluacion"), DataTable)
            TablaEvaluacion.Rows.Clear()
            GVAutorizar.DataBind()
            Session("TablaEvaluacion") = TablaEvaluacion
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVEvaluado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEvaluado.SelectedIndexChanged
        Dim TablaAutorizar As New DataTable
        TablaAutorizar = Session("TablaAutorizar")
        wucConsultarPersona1.AsignarPersona(TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("ID Cliente"), "",
                                            TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("Nombre Cliente"))
        TBIdCredito.Text = TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("Credito")
        TBFechaApertura.Text = TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("Fecha Apertura")
        TBFechaVencimiento.Text = TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("Fecha Vencimiento")
        TBMonto.Text = TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("Monto")
        DDEstado.Text = TablaAutorizar.Rows(GVEvaluado.SelectedIndex).Item("IdEstado")
        SeleccionarView(1)
    End Sub

    Protected Sub GVAutorizar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVAutorizar.SelectedIndexChanged
        Dim TablaEvaluacion As New DataTable
        TablaEvaluacion = Session("TablaEvaluacion")
        TBIdCredito.Text = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("IdCredito")
        Dim equivalencia = ""
        Try
            equivalencia = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("Equivalencia")
        Catch ex As Exception
        End Try
        wucConsultarPersona1.AsignarPersona(TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("IDClienteCredito"), equivalencia,
                                            TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("NombreCliente"))
        TBFechaApertura.Text = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("FechaApertura")
        TBFechaVencimiento.Text = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("FechaVencimiento")
        TBMonto.Text = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("Monto")
        DDEstado.Text = TablaEvaluacion.Rows(GVAutorizar.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(TablaEvaluacion.Rows(GVAutorizar.SelectedIndex))
        GVAutorizar.Visible = False
        SeleccionarView(1)
    End Sub

    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        
    End Sub

    Protected Sub IBTConsultar0_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar0.Click
        Dim NegocioCredito As New Negocio.Credito()
        Dim EntidadCredito As New Entidad.Credito()
        Dim TablaEvaluacion As New DataTable
        TablaEvaluacion = Session("TablaEvaluacion")
        EntidadCredito.IdEstado2 = DDEstado2.SelectedValue
        If TBId.Text Is String.Empty Then
            EntidadCredito.Id = -1
        Else
            EntidadCredito.Id = CInt(TBId.Text)
        End If
        EntidadCredito.Nombre = TBNombre.Text
        NegocioCredito.Obtener(EntidadCredito)
        TablaEvaluacion = EntidadCredito.TablaCredito
        GVAutorizar.Columns.Clear()
        GVAutorizar.DataSource = TablaEvaluacion
        GVAutorizar.AutoGenerateColumns = False
        GVAutorizar.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVAutorizar.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAutorizar, New BoundField(), "ID Cliente", "IDClienteCredito")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAutorizar, New BoundField(), "Nombre Cliente", "NombreCliente")
        GVAutorizar.DataBind()
        GVAutorizar.Visible = True
        Session("TablaEvaluacion") = TablaEvaluacion
        SeleccionarView(0)
    End Sub
End Class