Imports System.Data

Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Subclasificacion"
            'Consultar()
            ConsultarClasificacion()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDClasificacion.SelectedValue = "1"
            DDEstado.SelectedValue = "1"

            DDEstadoConsultar.Items.Add(New ListItem("TODOS", "-1"))
            DDEstadoConsultar.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstadoConsultar.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstadoConsultar.SelectedValue = "-1"
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

    Private Sub ConsultarClasificacion()
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        DDClasificacion.DataValueField = "ID"
        DDClasificacion.DataTextField = "Descripcion"
        DDClasificacion.DataBind()


        DDClasificacionConsultar.DataSource = EntidadClasificacion.TablaConsulta
        DDClasificacionConsultar.DataValueField = "ID"
        DDClasificacionConsultar.DataTextField = "Descripcion"
        DDClasificacionConsultar.DataBind()
        DDClasificacionConsultar.Items.Add(New ListItem("TODOS", "-1"))
        DDClasificacionConsultar.SelectedValue = "-1"
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSubclasificacion.SelectedIndexChanged
        Dim Tabla = Session("Tabla")
        TBIdSubclasificacion.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("ID"), String)
        TBDescripcion.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Descripcion"), String)
        DDClasificacion.SelectedValue = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("IdClasificacion"), String)
        TBGanancia.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Ganancia"), Double)
        CBGanancia.Checked = IIf(CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Porcentaje"), Integer) = 1, True, False)
        DDEstado.SelectedValue = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("IdEstado"), String)
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVSubclasificacion.SelectedIndex))
        SeleccionarView(1)
    End Sub
    Public Sub Consultar()
        Dim NegocioSubclasificacion = New Negocio.Subclasificacion()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim Tabla As New DataTable
        EntidadSubclasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        EntidadSubclasificacion.IdSubclasificacion = IIf(TBIdSubclasificacionConsultar.Text Is String.Empty, 0, TBIdSubclasificacionConsultar.Text)
        EntidadSubclasificacion.Descripcion = IIf(TBDescripcionSubclasificacionConsultar.Text Is String.Empty, "", TBDescripcionSubclasificacionConsultar.Text)
        EntidadSubclasificacion.IdClasificacion = DDClasificacionConsultar.SelectedValue
        EntidadSubclasificacion.IdEstado = DDEstadoConsultar.SelectedValue
        NegocioSubclasificacion.ObtenerFiltro(EntidadSubclasificacion)
        Tabla = EntidadSubclasificacion.TablaConsulta
        GVSubclasificacion.Columns.Clear()
        GVSubclasificacion.DataSource = Tabla
        GVSubclasificacion.AutoGenerateColumns = False
        GVSubclasificacion.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVSubclasificacion.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Clasificacion", "Clasificacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Subclasificacion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Estado", "Estado")
        GVSubclasificacion.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdSubclasificacion.Text = ""
        TBDescripcion.Text = ""
        DDClasificacion.SelectedValue = "1"
        DDEstado.SelectedValue = "1"
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        EntidadSubclasificacion.IdSubclasificacion = CInt(IIf(TBIdSubclasificacion.Text Is String.Empty, 0, TBIdSubclasificacion.Text))
        EntidadSubclasificacion.Descripcion = TBDescripcion.Text
        EntidadSubclasificacion.Ganancia = CDbl(TBGanancia.Text)
        EntidadSubclasificacion.Porcentaje = IIf(CBGanancia.Checked = True, 1, 0)
        EntidadSubclasificacion.IdClasificacion = CInt(DDClasificacion.SelectedValue)
        EntidadSubclasificacion.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioSubclasificacion.Guardar(EntidadSubclasificacion)
        Consultar()
        TBIdSubclasificacion.Text = ""
        TBDescripcion.Text = ""
        TBGanancia.Text = ""
        CBGanancia.Checked = False
        DDEstado.SelectedValue = "1"
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx") ''codigo
    End Sub
End Class