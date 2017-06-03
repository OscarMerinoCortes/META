Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Cargo"
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
        Dim NegocioCargo As New Negocio.Cargo()
        Dim EntidadCargo As New Entidad.Cargo()
        Dim Tabla As New DataTable
        EntidadCargo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCargo.Consultar(EntidadCargo)
        Tabla = EntidadCargo.TablaConsulta
        GVCargo.Columns.Clear()
        GVCargo.DataSource = Tabla
        GVCargo.AutoGenerateColumns = False
        GVCargo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVCargo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Estado", "Estado")
        GVCargo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdCargo.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioCargo As New Negocio.Cargo()
        Dim EntidadCargo As New Entidad.Cargo()
        If TBIdCargo.Text Is String.Empty Then
            EntidadCargo.IdCargo = 0
        Else
            EntidadCargo.IdCargo = CInt(TBIdCargo.Text)
        End If
        EntidadCargo.Descripcion = TBDescripcion.Text
        EntidadCargo.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioCargo.Guardar(EntidadCargo)
        Consultar()
        TBIdCargo.Text = ""
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

    Protected Sub GVCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCargo.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdCargo.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVCargo.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVCargo.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class