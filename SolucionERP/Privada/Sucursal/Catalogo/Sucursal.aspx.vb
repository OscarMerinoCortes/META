Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Sucursal"
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
        Dim NegocioSucursal As New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        Dim Tabla As New DataTable
        EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioSucursal.Consultar(EntidadSucursal)
        Tabla = EntidadSucursal.TablaConsulta
        GVSucursal.Columns.Clear()
        GVSucursal.DataSource = Tabla
        GVSucursal.AutoGenerateColumns = False
        GVSucursal.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVSucursal.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSucursal, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSucursal, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSucursal, New BoundField(), "Estado", "Estado")
        GVSucursal.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdSucursal.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioSucursal As New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        If TBIdSucursal.Text Is String.Empty Then
            EntidadSucursal.IdSucursal = 0
        Else
            EntidadSucursal.IdSucursal = CInt(TBIdSucursal.Text)
        End If
        EntidadSucursal.Descripcion = TBDescripcion.Text
        EntidadSucursal.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioSucursal.Guardar(EntidadSucursal)
        Consultar()
        TBIdSucursal.Text = ""
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

    Protected Sub GVSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSucursal.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdSucursal.Text = Tabla.Rows(GVSucursal.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVSucursal.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVSucursal.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVSucursal.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class