Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Rutas"
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
        Dim NegocioRuta As New Negocio.Rutas()
        Dim EntidadRuta As New Entidad.Rutas()
        Dim Tabla As New DataTable
        EntidadRuta.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioRuta.Consultar(EntidadRuta)
        Tabla = EntidadRuta.TablaConsulta
        GVRuta.Columns.Clear()
        GVRuta.DataSource = Tabla
        GVRuta.AutoGenerateColumns = False
        GVRuta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVRuta.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRuta, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRuta, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVRuta, New BoundField(), "Estado", "Estado")
        GVRuta.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdRuta.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioRuta As New Negocio.Rutas()
        Dim EntidadRuta As New Entidad.Rutas()
        If TBIdRuta.Text Is String.Empty Then
            EntidadRuta.IdRuta = 0
        Else
            EntidadRuta.IdRuta = CInt(TBIdRuta.Text)
        End If
        EntidadRuta.Descripcion = TBDescripcion.Text
        EntidadRuta.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioRuta.Guardar(EntidadRuta)
        Consultar()
        TBIdRuta.Text = ""
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

    Protected Sub GVRuta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVRuta.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdRuta.Text = Tabla.Rows(GVRuta.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVRuta.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVRuta.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVRuta.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class