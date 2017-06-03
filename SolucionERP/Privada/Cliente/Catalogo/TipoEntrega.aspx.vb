Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Entrega"
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
        Dim NegocioTipoEntrega As New Negocio.TipoEntrega()
        Dim EntidadTipoEntrega As New Entidad.TipoEntrega()
        Dim Tabla As New DataTable
        EntidadTipoEntrega.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoEntrega.Consultar(EntidadTipoEntrega)
        Tabla = EntidadTipoEntrega.TablaConsulta
        GVTipoEntrega.Columns.Clear()
        GVTipoEntrega.DataSource = Tabla
        GVTipoEntrega.AutoGenerateColumns = False
        GVTipoEntrega.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoEntrega.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEntrega, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEntrega, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEntrega, New BoundField(), "Estado", "Estado")
        GVTipoEntrega.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoEntrega.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoEntrega As New Negocio.TipoEntrega()
        Dim EntidadTipoEntrega As New Entidad.TipoEntrega()
        If TBIdTipoEntrega.Text Is String.Empty Then
            EntidadTipoEntrega.IdTipoEntrega = 0
        Else
            EntidadTipoEntrega.IdTipoEntrega = CInt(TBIdTipoEntrega.Text)
        End If
        EntidadTipoEntrega.Descripcion = TBDescripcion.Text
        EntidadTipoEntrega.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoEntrega.Guardar(EntidadTipoEntrega)
        Consultar()
        TBIdTipoEntrega.Text = ""
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

    Protected Sub GVTipoEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoEntrega.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoEntrega.Text = Tabla.Rows(GVTipoEntrega.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoEntrega.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoEntrega.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoEntrega.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class