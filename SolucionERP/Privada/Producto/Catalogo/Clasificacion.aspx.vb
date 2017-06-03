Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Clasificacion"
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
        Dim NegocioClasificacion As New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        Dim Tabla As New DataTable
        EntidadClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioClasificacion.Consultar(EntidadClasificacion)
        Tabla = EntidadClasificacion.TablaConsulta
        GVClasificacion.Columns.Clear()
        GVClasificacion.DataSource = Tabla
        GVClasificacion.AutoGenerateColumns = False
        GVClasificacion.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVClasificacion.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVClasificacion, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVClasificacion, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVClasificacion, New BoundField(), "Estado", "Estado")
        GVClasificacion.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdClasificacion.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioClasificacion As New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        If TBIdClasificacion.Text Is String.Empty Then
            EntidadClasificacion.IdClasificacion = 0
        Else
            EntidadClasificacion.IdClasificacion = CInt(TBIdClasificacion.Text)
        End If
        EntidadClasificacion.Descripcion = TBDescripcion.Text
        EntidadClasificacion.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioClasificacion.Guardar(EntidadClasificacion)
        Consultar()
        TBIdClasificacion.Text = ""
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

    Protected Sub GVClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVClasificacion.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdClasificacion.Text = Tabla.Rows(GVClasificacion.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVClasificacion.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVClasificacion.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVClasificacion.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class