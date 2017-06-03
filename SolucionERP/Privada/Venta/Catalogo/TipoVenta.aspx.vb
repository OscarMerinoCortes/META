Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Venta"
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
        Dim NegocioTipoVenta As New Negocio.TipoVenta()
        Dim EntidadTipoVenta As New Entidad.TipoVenta()
        Dim Tabla As New DataTable
        EntidadTipoVenta.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoVenta.Consultar(EntidadTipoVenta)
        Tabla = EntidadTipoVenta.TablaConsulta
        GVTipoVenta.Columns.Clear()
        GVTipoVenta.DataSource = Tabla
        GVTipoVenta.AutoGenerateColumns = False
        GVTipoVenta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoVenta.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoVenta, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoVenta, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoVenta, New BoundField(), "Estado", "Estado")
        GVTipoVenta.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoVenta.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoVenta As New Negocio.TipoVenta()
        Dim EntidadTipoVenta As New Entidad.TipoVenta()
        If TBIdTipoVenta.Text Is String.Empty Then
            EntidadTipoVenta.IdTipoVenta = 0
        Else
            EntidadTipoVenta.IdTipoVenta = CInt(TBIdTipoVenta.Text)
        End If
        EntidadTipoVenta.Descripcion = TBDescripcion.Text
        EntidadTipoVenta.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoVenta.Guardar(EntidadTipoVenta)
        Consultar()
        TBIdTipoVenta.Text = ""
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

    Protected Sub GVTipoVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoVenta.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoVenta.Text = Tabla.Rows(GVTipoVenta.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoVenta.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoVenta.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoVenta.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class