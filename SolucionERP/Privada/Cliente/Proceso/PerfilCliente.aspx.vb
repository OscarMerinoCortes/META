Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Perfil Cliente"
            TBFechaInicioConsultar.Text = CDate(Now).ToString("dd/MM/yyyy")
            TBFechaFinConsultar.Text = CDate(Now).ToString("dd/MM/yyyy")

            DDGeneroConsulta.Items.Add(New ListItem("TODO", -1))
            DDGeneroConsulta.Items.Add(New ListItem("MASCULINO", 1))
            DDGeneroConsulta.Items.Add(New ListItem("FEMENINO", 2))
            DDGeneroConsulta.SelectedIndex = -1

            DDTipoPersonaConsulta.Items.Add(New ListItem("TODO", -1))
            DDTipoPersonaConsulta.Items.Add(New ListItem("FISICA", 1))
            DDTipoPersonaConsulta.Items.Add(New ListItem("MORAL", 2))
            DDTipoPersonaConsulta.SelectedIndex = -1

            DDEstadoConsulta.Items.Add(New ListItem("TODO", -1))
            DDEstadoConsulta.Items.Add(New ListItem("ACTIVO", 1))
            DDEstadoConsulta.Items.Add(New ListItem("INACTIVO", 2))
            DDEstadoConsulta.SelectedIndex = -1
            MultiView1.SetActiveView(View1)
        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        Dim Tabla As New DataTable
        EntidadPersona.IdPersona = IIf(TBIdPersonaConsultar.Text Is String.Empty, 0, TBIdPersonaConsultar.Text)
        EntidadPersona.Equivalencia = IIf(TBEquivalenciaConsultar.Text Is String.Empty, "0", TBEquivalenciaConsultar.Text)
        EntidadPersona.PrimerNombre = TBNombreClienteConsultar.Text
        EntidadPersona.FechaCreacion = TBFechaInicioConsultar.Text
        EntidadPersona.FechaActualizacion = TBFechaFinConsultar.Text
        EntidadPersona.IdTipoGenero = DDGeneroConsulta.SelectedValue
        EntidadPersona.IdTipoPersona = DDTipoPersonaConsulta.SelectedValue
        EntidadPersona.IdEstado = DDEstadoConsulta.SelectedValue
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioPersona.ObtenerFiltro(EntidadPersona)
        Tabla = EntidadPersona.TablaConsulta
        GVPersona.Columns.Clear()
        GVPersona.DataSource = Tabla
        GVPersona.AutoGenerateColumns = False
        GVPersona.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPersona.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "ID Cliente", "Id")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Nombre Cliente", "NombreCliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Fecha Nacimiento", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Estado", "TipoEstado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Genero", "Genero")
        GVPersona.DataBind()
        Session("Tabla") = Tabla
        ' MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub GVPerfilCliente_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVPerfilCliente.Sorting
        Dim Tabla As New DataTable
        Tabla = Session("TablaConsulta")
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVPerfilCliente.DataSource = Vista
        GVPerfilCliente.DataBind()
    End Sub

    Protected Sub GVPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPersona.SelectedIndexChanged
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPerfilPersona As New Entidad.Persona()
        Dim TablaConsulta As New DataTable
        EntidadPerfilPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioPersona.PerfilPersona(EntidadPerfilPersona)
        TablaConsulta = EntidadPerfilPersona.TablaConsulta
        GVPerfilCliente.Columns.Clear()
        GVPerfilCliente.DataSource = TablaConsulta
        GVPerfilCliente.AutoGenerateColumns = False
        GVPerfilCliente.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPerfilCliente.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "ID", "idPerfilCliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Credito", "Credito")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Fecha", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Monto", "Monto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Saldo Vigente", "SaldoVigente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "SaldoVencido", "SaldoVencido")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Dias Vencidos", "DiasVencidos")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPerfilCliente, New BoundField(), "Estado", "Estado")
        GVPerfilCliente.DataBind()
        Session("TablaConsulta") = TablaConsulta
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
End Class