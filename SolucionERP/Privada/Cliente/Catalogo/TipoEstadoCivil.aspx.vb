Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Estado Civil"
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
        Dim NegocioTipoEstadoCivil As New Negocio.TipoEstadoCivil()
        Dim EntidadTipoEstadoCivil As New Entidad.TipoEstadoCivil()
        Dim Tabla As New DataTable
        EntidadTipoEstadoCivil.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoEstadoCivil.Consultar(EntidadTipoEstadoCivil)
        Tabla = EntidadTipoEstadoCivil.TablaConsulta
        GVTipoEstadoCivil.Columns.Clear()
        GVTipoEstadoCivil.DataSource = Tabla
        GVTipoEstadoCivil.AutoGenerateColumns = False
        GVTipoEstadoCivil.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoEstadoCivil.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEstadoCivil, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEstadoCivil, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEstadoCivil, New BoundField(), "Estado", "Estado")
        GVTipoEstadoCivil.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoEstadoCivil.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoEstadoCivil As New Negocio.TipoEstadoCivil()
        Dim EntidadTipoEstadoCivil As New Entidad.TipoEstadoCivil()
        If TBIdTipoEstadoCivil.Text Is String.Empty Then
            EntidadTipoEstadoCivil.IdTipoEstadoCivil = 0
        Else
            EntidadTipoEstadoCivil.IdTipoEstadoCivil = CInt(TBIdTipoEstadoCivil.Text)
        End If
        EntidadTipoEstadoCivil.Descripcion = TBDescripcion.Text
        EntidadTipoEstadoCivil.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoEstadoCivil.Guardar(EntidadTipoEstadoCivil)
        Consultar()
        TBIdTipoEstadoCivil.Text = ""
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

    Protected Sub GVTipoEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoEstadoCivil.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoEstadoCivil.Text = Tabla.Rows(GVTipoEstadoCivil.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoEstadoCivil.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoEstadoCivil.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoEstadoCivil.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class