Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Plazo Vencimiento"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            wucDatosAuditoria1.Visible = False
            SeleccionarView(0)
        End If
    End Sub

    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            ''Consultar()
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub

    Public Sub Consultar()
        Dim NegocioPlazoVencimiento As New Negocio.PlazoVencimiento()
        Dim EntidadPlazoVencimiento As New Entidad.PlazoVencimiento()

        Dim Tabla As New DataTable
        EntidadPlazoVencimiento.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioPlazoVencimiento.Consultar(EntidadPlazoVencimiento)
        Tabla = EntidadPlazoVencimiento.TablaConsulta
        GVPlazoVencimiento.Columns.Clear()
        GVPlazoVencimiento.DataSource = Tabla
        GVPlazoVencimiento.AutoGenerateColumns = False
        GVPlazoVencimiento.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPlazoVencimiento.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "ID", "IdPlazoVencimiento")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Descripcion", "DescripcionPlazoVen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Maximo", "MaximoPlazoVen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Minimo", "MinimoPlazoVen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPlazoVencimiento, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")

        GVPlazoVencimiento.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdPlazoVencimiento.Text = ""
        TBDescripcion.Text = ""
        TBMaximo.Text = ""
        TBMinimo.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioPlazoVenciminto As New Negocio.PlazoVencimiento()
        Dim EntidadPlazoVencimiento As New Entidad.PlazoVencimiento()
        If TBIdPlazoVencimiento.Text Is String.Empty Then
            EntidadPlazoVencimiento.IdPlazoVencimiento = 0
        Else
            EntidadPlazoVencimiento.IdPlazoVencimiento = CInt(TBIdPlazoVencimiento.Text)
        End If
        EntidadPlazoVencimiento.DescripcionPlazoVen = TBDescripcion.Text
        EntidadPlazoVencimiento.MaximoPlazoVen = TBMaximo.Text.ToUpper()
        EntidadPlazoVencimiento.MinimoPlazoVen = TBMinimo.Text
        EntidadPlazoVencimiento.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioPlazoVenciminto.Guardar(EntidadPlazoVencimiento)
        TBIdPlazoVencimiento.Text = EntidadPlazoVencimiento.IdPlazoVencimiento
        TBIdPlazoVencimiento.Text = ""
        TBDescripcion.Text = ""
        TBMaximo.Text = ""
        TBMinimo.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVPlazoVencimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPlazoVencimiento.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdPlazoVencimiento.Text = Tabla.Rows(GVPlazoVencimiento.SelectedIndex).Item("IdPlazoVencimiento")
        TBDescripcion.Text = Tabla.Rows(GVPlazoVencimiento.SelectedIndex).Item("DescripcionPlazoVen")
        TBMaximo.Text = Tabla.Rows(GVPlazoVencimiento.SelectedIndex).Item("MaximoPlazoVen")
        TBMinimo.Text = Tabla.Rows(GVPlazoVencimiento.SelectedIndex).Item("MinimoPlazoVen")
        DDEstado.SelectedValue = Tabla.Rows(GVPlazoVencimiento.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVPlazoVencimiento.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class