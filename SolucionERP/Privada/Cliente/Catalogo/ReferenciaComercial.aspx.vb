Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Referencia Comercial"
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
    Protected Sub GVReferenciaComercial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVReferenciaComercial.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdReferenciaComercial.Text = Tabla.Rows(GVReferenciaComercial.SelectedIndex).Item("ID")
        TBReferenciaComercial.Text = Tabla.Rows(GVReferenciaComercial.SelectedIndex).Item("Descripcion")
        TBDomicilio.Text = Tabla.Rows(GVReferenciaComercial.SelectedIndex).Item("Domicilio")
        TBTelefono.Text = Tabla.Rows(GVReferenciaComercial.SelectedIndex).Item("Telefono")
        DDEstado.SelectedValue = Tabla.Rows(GVReferenciaComercial.SelectedIndex).Item("idEstado")

        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVReferenciaComercial.SelectedIndex))
        SeleccionarView(1)
    End Sub
    Public Sub Consultar()
        Dim NegocioReferenciaComercial As New Negocio.ReferenciaComercial()
        Dim EntidadReferenciaComercial As New Entidad.ReferenciaComercial()
        Dim Tabla As New DataTable
        EntidadReferenciaComercial.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioReferenciaComercial.Consultar(EntidadReferenciaComercial)
        Tabla = EntidadReferenciaComercial.TablaConsulta
        GVReferenciaComercial.Columns.Clear()
        GVReferenciaComercial.DataSource = Tabla
        GVReferenciaComercial.AutoGenerateColumns = False
        GVReferenciaComercial.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVReferenciaComercial.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReferenciaComercial, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReferenciaComercial, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReferenciaComercial, New BoundField(), "Domicilio", "Domicilio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReferenciaComercial, New BoundField(), "Telefono", "Telefono")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReferenciaComercial, New BoundField(), "Estado", "Estado")
        GVReferenciaComercial.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdReferenciaComercial.Text = ""
        TBReferenciaComercial.Text = ""
        TBDomicilio.Text = ""
        TBTelefono.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioReferenciaComercial As New Negocio.ReferenciaComercial()
        Dim EntidadReferenciaComercial As New Entidad.ReferenciaComercial()
        If TBIdReferenciaComercial.Text Is String.Empty Then
            EntidadReferenciaComercial.IdReferenciaComercial = 0
        Else
            EntidadReferenciaComercial.IdReferenciaComercial = CInt(TBIdReferenciaComercial.Text)
        End If
        EntidadReferenciaComercial.Descripcion = TBReferenciaComercial.Text
        EntidadReferenciaComercial.Domicilio = TBDomicilio.Text
        EntidadReferenciaComercial.Telefono = TBTelefono.Text
        EntidadReferenciaComercial.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioReferenciaComercial.Guardar(EntidadReferenciaComercial)
        Consultar()
        TBIdReferenciaComercial.Text = ""
        TBReferenciaComercial.Text = ""
        TBDomicilio.Text = ""
        TBTelefono.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
End Class