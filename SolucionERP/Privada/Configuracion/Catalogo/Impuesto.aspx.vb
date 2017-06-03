Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Impuesto"
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
        Dim NegocioImpuesto As New Negocio.Impuesto()
        Dim EntidadImpuesto As New Entidad.Impuesto()
        Dim Tabla As New DataTable
        EntidadImpuesto.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioImpuesto.Consultar(EntidadImpuesto)
        Tabla = EntidadImpuesto.TablaConsulta
        GVImpuesto.Columns.Clear()
        GVImpuesto.DataSource = Tabla
        GVImpuesto.AutoGenerateColumns = False
        GVImpuesto.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVImpuesto.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVImpuesto, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVImpuesto, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVImpuesto, New BoundField(), "Impuesto", "Impuesto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVImpuesto, New BoundField(), "Estado", "Estado")
        GVImpuesto.DataBind()
        Session("Tabla") = Tabla
    End Sub
    Protected Sub nuevo()
        TBIdImpuesto.Text = ""
        TBDescripcion.Text = ""
        TBImpuesto.Text = ""
        DDEstado.SelectedValue = 1
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        nuevo()
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioImpuesto As New Negocio.Impuesto()
        Dim EntidadImpuesto As New Entidad.Impuesto()
        EntidadImpuesto.IdImpuesto = IIf(TBIdImpuesto.Text Is String.Empty, 0, TBIdImpuesto.Text)
        EntidadImpuesto.Descripcion = TBDescripcion.Text
        EntidadImpuesto.Impuesto = TBImpuesto.Text
        EntidadImpuesto.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioImpuesto.Guardar(EntidadImpuesto)
        Consultar()
        nuevo()
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub

    Protected Sub GVImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVImpuesto.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdImpuesto.Text = Tabla.Rows(GVImpuesto.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVImpuesto.SelectedIndex).Item("Descripcion")
        TBImpuesto.Text = CInt(Tabla.Rows(GVImpuesto.SelectedIndex).Item("Impuesto"))
        DDEstado.SelectedValue = Tabla.Rows(GVImpuesto.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVImpuesto.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class