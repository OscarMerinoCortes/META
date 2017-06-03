Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Forma de Pago"
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
        Dim NegocioFormaPago As New Negocio.FormaPago()
        Dim EntidadFormaPago As New Entidad.FormaPago()
        Dim Tabla As New DataTable
        EntidadFormaPago.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioFormaPago.Consultar(EntidadFormaPago)
        Tabla = EntidadFormaPago.TablaConsulta
        GVFormaPago.Columns.Clear()
        GVFormaPago.DataSource = Tabla
        GVFormaPago.AutoGenerateColumns = False
        GVFormaPago.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVFormaPago.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVFormaPago, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVFormaPago, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVFormaPago, New BoundField(), "Estado", "Estado")
        GVFormaPago.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdFormaPago.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioFormaPago As New Negocio.FormaPago()
        Dim EntidadFormaPago As New Entidad.FormaPago()
        If TBIdFormaPago.Text Is String.Empty Then
            EntidadFormaPago.IdFormaPago = 0
        Else
            EntidadFormaPago.IdFormaPago = CInt(TBIdFormaPago.Text)
        End If
        EntidadFormaPago.Descripcion = TBDescripcion.Text
        EntidadFormaPago.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioFormaPago.Guardar(EntidadFormaPago)
        Consultar()
        TBIdFormaPago.Text = ""
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

    Protected Sub GVFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVFormaPago.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdFormaPago.Text = Tabla.Rows(GVFormaPago.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVFormaPago.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVFormaPago.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVFormaPago.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class