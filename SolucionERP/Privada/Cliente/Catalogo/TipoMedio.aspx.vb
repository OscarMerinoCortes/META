Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Medio"
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
        Dim NegocioTipoMedio As New Negocio.TipoMedio()
        Dim EntidadTipoMedio As New Entidad.TipoMedio()
        Dim Tabla As New DataTable
        EntidadTipoMedio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoMedio.Consultar(EntidadTipoMedio)
        Tabla = EntidadTipoMedio.TablaConsulta
        GVTipoMedio.Columns.Clear()
        GVTipoMedio.DataSource = Tabla
        GVTipoMedio.AutoGenerateColumns = False
        GVTipoMedio.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoMedio.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoMedio, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoMedio, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoMedio, New BoundField(), "Estado", "Estado")
        GVTipoMedio.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoMedio.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoMedio As New Negocio.TipoMedio()
        Dim EntidadTipoMedio As New Entidad.TipoMedio()
        If TBIdTipoMedio.Text Is String.Empty Then
            EntidadTipoMedio.IdTipoMedio = 0
        Else
            EntidadTipoMedio.IdTipoMedio = CInt(TBIdTipoMedio.Text)
        End If
        EntidadTipoMedio.Descripcion = TBDescripcion.Text
        EntidadTipoMedio.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoMedio.Guardar(EntidadTipoMedio)
        Consultar()
        TBIdTipoMedio.Text = ""
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

    Protected Sub GVTipoMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoMedio.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoMedio.Text = Tabla.Rows(GVTipoMedio.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoMedio.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoMedio.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoMedio.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class