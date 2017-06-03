Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Calendario"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            wucDatosAuditoria1.Visible = False
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
        Dim NegocioTipoCalendario As New Negocio.TipoCalendario()
        Dim EntidadTipoCalendario As New Entidad.TipoCalendario()
        Dim Tabla As New DataTable
        EntidadTipoCalendario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoCalendario.Consultar(EntidadTipoCalendario)
        Tabla = EntidadTipoCalendario.TablaConsulta
        GVTipoCalendario.Columns.Clear()
        GVTipoCalendario.DataSource = Tabla
        GVTipoCalendario.AutoGenerateColumns = False
        GVTipoCalendario.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoCalendario.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCalendario, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCalendario, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCalendario, New BoundField(), "Estado", "Estado")
        GVTipoCalendario.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoCalendario.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoCalendario As New Negocio.TipoCalendario()
        Dim EntidadTipoCalendario As New Entidad.TipoCalendario()
        If TBIdTipoCalendario.Text Is String.Empty Then
            EntidadTipoCalendario.IdTipoCalendario = 0
        Else
            EntidadTipoCalendario.IdTipoCalendario = CInt(TBIdTipoCalendario.Text)
        End If
        EntidadTipoCalendario.Descripcion = TBDescripcion.Text
        EntidadTipoCalendario.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoCalendario.Guardar(EntidadTipoCalendario)
        Consultar()
        TBIdTipoCalendario.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub GVTipoCalendario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoCalendario.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoCalendario.Text = Tabla.Rows(GVTipoCalendario.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoCalendario.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoCalendario.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoCalendario.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class