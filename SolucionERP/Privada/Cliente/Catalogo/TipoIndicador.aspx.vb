Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Indicador"
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
        Dim NegocioTipoIndicador As New Negocio.TipoIndicador()
        Dim EntidadTipoIndicador As New Entidad.TipoIndicador()
        Dim Tabla As New DataTable
        EntidadTipoIndicador.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoIndicador.Consultar(EntidadTipoIndicador)
        Tabla = EntidadTipoIndicador.TablaConsulta
        GVTipoIndicador.Columns.Clear()
        GVTipoIndicador.DataSource = Tabla
        GVTipoIndicador.AutoGenerateColumns = False
        GVTipoIndicador.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoIndicador.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIndicador, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIndicador, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIndicador, New BoundField(), "Estado", "Estado")
        GVTipoIndicador.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoIndicador.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoIndicador As New Negocio.TipoIndicador()
        Dim EntidadTipoIndicador As New Entidad.TipoIndicador()
        If TBIdTipoIndicador.Text Is String.Empty Then
            EntidadTipoIndicador.IdTipoIndicador = 0
        Else
            EntidadTipoIndicador.IdTipoIndicador = CInt(TBIdTipoIndicador.Text)
        End If
        EntidadTipoIndicador.Descripcion = TBDescripcion.Text
        EntidadTipoIndicador.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoIndicador.Guardar(EntidadTipoIndicador)
        Consultar()
        TBIdTipoIndicador.Text = ""
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

    Protected Sub GVTipoIndicador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoIndicador.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoIndicador.Text = Tabla.Rows(GVTipoIndicador.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoIndicador.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoIndicador.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoIndicador.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class