Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Plazo"
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
        Dim NegocioTipoPlazo As New Negocio.TipoPlazo()
        Dim EntidadTipoPlazo As New Entidad.TipoPlazo()
        Dim Tabla As New DataTable
        EntidadTipoPlazo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoPlazo.Consultar(EntidadTipoPlazo)
        Tabla = EntidadTipoPlazo.TablaConsulta
        GVTipoPlazo.Columns.Clear()
        GVTipoPlazo.DataSource = Tabla
        GVTipoPlazo.AutoGenerateColumns = False
        GVTipoPlazo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoPlazo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoPlazo, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoPlazo, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoPlazo, New BoundField(), "Estado", "Estado")
        GVTipoPlazo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoPlazo.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoPlazo As New Negocio.TipoPlazo()
        Dim EntidadTipoPlazo As New Entidad.TipoPlazo()
        If TBIdTipoPlazo.Text Is String.Empty Then
            EntidadTipoPlazo.IdTipoPlazo = 0
        Else
            EntidadTipoPlazo.IdTipoPlazo = CInt(TBIdTipoPlazo.Text)
        End If
        EntidadTipoPlazo.Plazo = TBDescripcion.Text
        EntidadTipoPlazo.IdEstado = CInt(DDEstado.SelectedValue)
        'NegocioTipoPlazo.Guardar(EntidadTipoPlazo)
        Consultar()
        TBIdTipoPlazo.Text = ""
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

    Protected Sub GVTipoPlazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoPlazo.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoPlazo.Text = Tabla.Rows(GVTipoPlazo.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoPlazo.SelectedIndex).Item("Cantidad")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoPlazo.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoPlazo.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class