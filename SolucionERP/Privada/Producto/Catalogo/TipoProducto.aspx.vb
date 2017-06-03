Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Producto"
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
        Dim NegocioTipoProducto As New Negocio.TipoProducto()
        Dim EntidadTipoProducto As New Entidad.TipoProducto()
        Dim Tabla As New DataTable
        EntidadTipoProducto.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoProducto.Consultar(EntidadTipoProducto)
        Tabla = EntidadTipoProducto.TablaConsulta
        GVTipoProducto.Columns.Clear()
        GVTipoProducto.DataSource = Tabla
        GVTipoProducto.AutoGenerateColumns = False
        GVTipoProducto.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoProducto.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoProducto, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoProducto, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoProducto, New BoundField(), "Estado", "Estado")
        GVTipoProducto.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoProducto.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoProducto As New Negocio.TipoProducto()
        Dim EntidadTipoProducto As New Entidad.TipoProducto()
        If TBIdTipoProducto.Text Is String.Empty Then
            EntidadTipoProducto.IdTipoProducto = 0
        Else
            EntidadTipoProducto.IdTipoProducto = CInt(TBIdTipoProducto.Text)
        End If
        EntidadTipoProducto.Descripcion = TBDescripcion.Text
        EntidadTipoProducto.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoProducto.Guardar(EntidadTipoProducto)
        Consultar()
        TBIdTipoProducto.Text = ""
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

    Protected Sub GVTipoProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoProducto.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoProducto.Text = Tabla.Rows(GVTipoProducto.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoProducto.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoProducto.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoProducto.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class