Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Unidad"
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
        Dim NegocioUnidad As New Negocio.Unidad()
        Dim EntidadUnidad As New Entidad.Unidad()
        Dim Tabla As New DataTable
        EntidadUnidad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioUnidad.Consultar(EntidadUnidad)
        Tabla = EntidadUnidad.TablaConsulta
        GVUnidad.Columns.Clear()
        GVUnidad.DataSource = Tabla
        GVUnidad.AutoGenerateColumns = False
        GVUnidad.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVUnidad.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUnidad, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUnidad, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUnidad, New BoundField(), "Estado", "Estado")
        GVUnidad.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdUnidad.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioUnidad As New Negocio.Unidad()
        Dim EntidadUnidad As New Entidad.Unidad()
        If TBIdUnidad.Text Is String.Empty Then
            EntidadUnidad.IdUnidad = 0
        Else
            EntidadUnidad.IdUnidad = CInt(TBIdUnidad.Text)
        End If
        EntidadUnidad.Descripcion = TBDescripcion.Text
        EntidadUnidad.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioUnidad.Guardar(EntidadUnidad)
        Consultar()
        TBIdUnidad.Text = ""
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

    Protected Sub GVUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVUnidad.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdUnidad.Text = Tabla.Rows(GVUnidad.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVUnidad.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVUnidad.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVUnidad.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class