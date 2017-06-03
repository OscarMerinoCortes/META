Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Documento"
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
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub
    Public Sub Consultar()
        Dim NegocioTipoDocumento As New Negocio.TipoDocumento()
        Dim EntidadTipoDocumento As New Entidad.TipoDocumento()
        Dim Tabla As New DataTable
        EntidadTipoDocumento.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoDocumento.Consultar(EntidadTipoDocumento)
        Tabla = EntidadTipoDocumento.TablaConsulta
        GVTipoDocumento.Columns.Clear()
        GVTipoDocumento.DataSource = Tabla
        GVTipoDocumento.AutoGenerateColumns = False
        GVTipoDocumento.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoDocumento.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDocumento, New BoundField(), "ID", "IdTipoDocumento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDocumento, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoDocumento, New BoundField(), "Estado", "Estado")
        GVTipoDocumento.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoDocumento.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoDocumento As New Negocio.TipoDocumento()
        Dim EntidadTipoDocumento As New Entidad.TipoDocumento()
        EntidadTipoDocumento.IdTipoDocumento = IIf(TBIdTipoDocumento.Text Is String.Empty, 0, TBIdTipoDocumento.Text)
        EntidadTipoDocumento.Descripcion = TBDescripcion.Text
        EntidadTipoDocumento.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoDocumento.Guardar(EntidadTipoDocumento)
        Consultar()
        SeleccionarView(0)
        TBIdTipoDocumento.Text = EntidadTipoDocumento.IdTipoDocumento
        'TBDescripcion.Text = ""
        'DDEstado.SelectedValue = 1
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub

    Protected Sub GVImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoDocumento.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoDocumento.Text = Tabla.Rows(GVTipoDocumento.SelectedIndex).Item("IdTipoDocumento")
        TBDescripcion.Text = Tabla.Rows(GVTipoDocumento.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoDocumento.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoDocumento.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class