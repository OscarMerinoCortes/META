Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
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
        Dim NegocioTipoDescuento As New Negocio.TipoDescuento()
        Dim EntidadTipoDescuento As New Entidad.TipoDescuento()
        Dim Tabla As New DataTable
        EntidadTipoDescuento.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoDescuento.Consultar(EntidadTipoDescuento)
        Tabla = EntidadTipoDescuento.TablaConsulta
        GVTipoDescuento.Columns.Clear()
        GVTipoDescuento.DataSource = Tabla
        GVTipoDescuento.AutoGenerateColumns = False
        GVTipoDescuento.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoDescuento.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDescuento, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDescuento, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDescuento, New BoundField(), "Estado", "Estado")
        GVTipoDescuento.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoDescuento.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoDescuento As New Negocio.TipoDescuento()
        Dim EntidadTipoDescuento As New Entidad.TipoDescuento()
        If TBIdTipoDescuento.Text Is String.Empty Then
            EntidadTipoDescuento.IdTipoDescuento = 0
        Else
            EntidadTipoDescuento.IdTipoDescuento = CInt(TBIdTipoDescuento.Text)
        End If
        EntidadTipoDescuento.Descripcion = TBDescripcion.Text
        EntidadTipoDescuento.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoDescuento.Guardar(EntidadTipoDescuento)
        Consultar()
        TBIdTipoDescuento.Text = ""
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

    Protected Sub GVTipoDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoDescuento.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoDescuento.Text = Tabla.Rows(GVTipoDescuento.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoDescuento.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoDescuento.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoDescuento.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class