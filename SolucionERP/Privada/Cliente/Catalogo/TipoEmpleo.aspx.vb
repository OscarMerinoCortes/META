Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Empleo"
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
        Dim NegocioTipoEmpleo As New Negocio.TipoEmpleo()
        Dim EntidadTipoEmpleo As New Entidad.TipoEmpleo()
        Dim Tabla As New DataTable
        EntidadTipoEmpleo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoEmpleo.Consultar(EntidadTipoEmpleo)
        Tabla = EntidadTipoEmpleo.TablaConsulta
        GVTipoEmpleo.Columns.Clear()
        GVTipoEmpleo.DataSource = Tabla
        GVTipoEmpleo.AutoGenerateColumns = False
        GVTipoEmpleo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoEmpleo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEmpleo, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEmpleo, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoEmpleo, New BoundField(), "Estado", "Estado")
        GVTipoEmpleo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoEmpleo.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoEmpleo As New Negocio.TipoEmpleo()
        Dim EntidadTipoEmpleo As New Entidad.TipoEmpleo()
        If TBIdTipoEmpleo.Text Is String.Empty Then
            EntidadTipoEmpleo.IdTipoEmpleo = 0
        Else
            EntidadTipoEmpleo.IdTipoEmpleo = CInt(TBIdTipoEmpleo.Text)
        End If
        EntidadTipoEmpleo.Descripcion = TBDescripcion.Text
        EntidadTipoEmpleo.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoEmpleo.Guardar(EntidadTipoEmpleo)
        Consultar()
        TBIdTipoEmpleo.Text = ""
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

    Protected Sub GVTipoEmpleo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoEmpleo.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoEmpleo.Text = Tabla.Rows(GVTipoEmpleo.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoEmpleo.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoEmpleo.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoEmpleo.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class