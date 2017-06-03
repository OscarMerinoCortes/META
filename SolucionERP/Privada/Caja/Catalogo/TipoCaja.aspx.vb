Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Caja"
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
        Dim NegocioTipoCaja As New Negocio.TipoCaja()
        Dim EntidadTipoCaja As New Entidad.TipoCaja()
        Dim Tabla As New DataTable
        EntidadTipoCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoCaja.Consultar(EntidadTipoCaja)
        Tabla = EntidadTipoCaja.TablaConsulta
        GVTipoCaja.Columns.Clear()
        GVTipoCaja.DataSource = Tabla
        GVTipoCaja.AutoGenerateColumns = False
        GVTipoCaja.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoCaja.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCaja, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCaja, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoCaja, New BoundField(), "Estado", "Estado")
        GVTipoCaja.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoCaja.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoCaja As New Negocio.TipoCaja()
        Dim EntidadTipoCaja As New Entidad.TipoCaja()
        If TBIdTipoCaja.Text Is String.Empty Then
            EntidadTipoCaja.IdTipoCaja = 0
        Else
            EntidadTipoCaja.IdTipoCaja = CInt(TBIdTipoCaja.Text)
        End If
        EntidadTipoCaja.Descripcion = TBDescripcion.Text
        EntidadTipoCaja.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadTipoCaja.Equivalencia = ""
        NegocioTipoCaja.Guardar(EntidadTipoCaja)
        Consultar()
        TBIdTipoCaja.Text = ""
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
    Protected Sub GVTipoCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoCaja.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoCaja.Text = Tabla.Rows(GVTipoCaja.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoCaja.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoCaja.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoCaja.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class