Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Referencia"
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
        Dim NegocioTipoReferencia As New Negocio.TipoReferencia()
        Dim EntidadTipoReferencia As New Entidad.TipoReferencia()
        Dim Tabla As New DataTable
        EntidadTipoReferencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoReferencia.Consultar(EntidadTipoReferencia)
        Tabla = EntidadTipoReferencia.TablaConsulta
        GVTipoReferencia.Columns.Clear()
        GVTipoReferencia.DataSource = Tabla
        GVTipoReferencia.AutoGenerateColumns = False
        GVTipoReferencia.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoReferencia.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoReferencia, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoReferencia, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoReferencia, New BoundField(), "Estado", "Estado")
        GVTipoReferencia.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoReferencia.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoReferencia As New Negocio.TipoReferencia()
        Dim EntidadTipoReferencia As New Entidad.TipoReferencia()
        If TBIdTipoReferencia.Text Is String.Empty Then
            EntidadTipoReferencia.IdTipoReferencia = 0
        Else
            EntidadTipoReferencia.IdTipoReferencia = CInt(TBIdTipoReferencia.Text)
        End If
        EntidadTipoReferencia.Descripcion = TBDescripcion.Text
        EntidadTipoReferencia.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoReferencia.Guardar(EntidadTipoReferencia)
        Consultar()
        TBIdTipoReferencia.Text = ""
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

    Protected Sub GVTipoReferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoReferencia.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoReferencia.Text = Tabla.Rows(GVTipoReferencia.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoReferencia.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoReferencia.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoReferencia.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class