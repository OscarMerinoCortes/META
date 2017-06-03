Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Usuario"
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
            If TBIdTipoUsuario.Text = "1" Then
                IBTGuardar.Enabled = False
            Else
                IBTGuardar.Enabled = True
            End If
        End If
    End Sub

    Public Sub Consultar()
        Dim NegocioTipoUsuario As New Negocio.TipoUsuario()
        Dim EntidadTipoUsuario As New Entidad.TipoUsuario()
        Dim Tabla As New DataTable
        EntidadTipoUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoUsuario.Consultar(EntidadTipoUsuario)
        Tabla = EntidadTipoUsuario.TablaConsulta
        GVTipoUsuario.Columns.Clear()
        GVTipoUsuario.DataSource = Tabla
        GVTipoUsuario.AutoGenerateColumns = False
        GVTipoUsuario.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoUsuario.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoUsuario, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoUsuario, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoUsuario, New BoundField(), "Estado", "Estado")
        GVTipoUsuario.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoUsuario.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoUsuario As New Negocio.TipoUsuario()
        Dim EntidadTipoUsuario As New Entidad.TipoUsuario()
        If TBIdTipoUsuario.Text Is String.Empty Then
            EntidadTipoUsuario.IdTipoUsuario = 0
        Else
            EntidadTipoUsuario.IdTipoUsuario = CInt(TBIdTipoUsuario.Text)
        End If
        EntidadTipoUsuario.TipoUsuario = TBDescripcion.Text
        EntidadTipoUsuario.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoUsuario.Guardar(EntidadTipoUsuario)
        Consultar()
        TBIdTipoUsuario.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedIndex = 0
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub GVTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoUsuario.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoUsuario.Text = Tabla.Rows(GVTipoUsuario.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoUsuario.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoUsuario.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoUsuario.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class