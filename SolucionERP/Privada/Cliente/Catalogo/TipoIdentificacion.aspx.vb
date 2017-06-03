Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Identificacion"
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
        Dim NegocioTipoIdentificacion As New Negocio.TipoIdentificacion()
        Dim EntidadTipoIdentificacion As New Entidad.TipoIdentificacion()
        Dim Tabla As New DataTable
        EntidadTipoIdentificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoIdentificacion.Consultar(EntidadTipoIdentificacion)
        Tabla = EntidadTipoIdentificacion.TablaConsulta
        GVTipoIdentificacion.Columns.Clear()
        GVTipoIdentificacion.DataSource = Tabla
        GVTipoIdentificacion.AutoGenerateColumns = False
        GVTipoIdentificacion.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoIdentificacion.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIdentificacion, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIdentificacion, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoIdentificacion, New BoundField(), "Estado", "Estado")
        GVTipoIdentificacion.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoIdentificacion.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoIdentificacion As New Negocio.TipoIdentificacion()
        Dim EntidadTipoIdentificacion As New Entidad.TipoIdentificacion()
        If TBIdTipoIdentificacion.Text Is String.Empty Then
            EntidadTipoIdentificacion.IdTipoIdentificacion = 0
        Else
            EntidadTipoIdentificacion.IdTipoIdentificacion = CInt(TBIdTipoIdentificacion.Text)
        End If
        EntidadTipoIdentificacion.Descripcion = TBDescripcion.Text
        EntidadTipoIdentificacion.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoIdentificacion.Guardar(EntidadTipoIdentificacion)
        Consultar()
        TBIdTipoIdentificacion.Text = ""
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

    Protected Sub GVTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoIdentificacion.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoIdentificacion.Text = Tabla.Rows(GVTipoIdentificacion.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoIdentificacion.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoIdentificacion.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoIdentificacion.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class