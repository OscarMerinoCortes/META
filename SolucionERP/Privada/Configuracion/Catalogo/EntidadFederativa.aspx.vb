Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Entidad Federativa"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            ''Consulta a la tabla pais para DDPais del catalogo Ciudad
            Dim tabla = New DataTable
            Dim NegocioPais As New Negocio.Pais()
            Dim EntidadPais As New Entidad.Pais()
            Dim tarjeta As New Entidad.Tarjeta()
            EntidadPais.Tarjeta = tarjeta
            EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioPais.Consultar(EntidadPais)
            DDPais.DataSource = EntidadPais.TablaConsulta
            DDPais.DataValueField = "ID"
            DDPais.DataTextField = "Descripcion"
            DDPais.DataBind()
            DDPais.SelectedValue = 1
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
    Private Sub Consultar()
        Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
        Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()

        Dim Tabla As New DataTable
        EntidadEntidadFederativa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioEntidadFederativa.Consultar(EntidadEntidadFederativa)
        Tabla = EntidadEntidadFederativa.TablaConsulta
        GVEntidadFederativa.Columns.Clear()
        GVEntidadFederativa.DataSource = Tabla
        GVEntidadFederativa.AutoGenerateColumns = False
        GVEntidadFederativa.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVEntidadFederativa.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVEntidadFederativa, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEntidadFederativa, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEntidadFederativa, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEntidadFederativa, New BoundField(), "Pais", "Pais")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVEntidadFederativa, New BoundField(), "Estado", "Estado")

        GVEntidadFederativa.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdEntidadFederativa.Text = ""
        TBDescripcion.Text = ""
        DDPais.SelectedValue = 1
        TBEquivalencia.Text = ""
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
        Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()
        If TBIdEntidadFederativa.Text Is String.Empty Then
            EntidadEntidadFederativa.IdEntidadFederativa = 0
        Else
            EntidadEntidadFederativa.IdEntidadFederativa = CInt(TBIdEntidadFederativa.Text)
        End If
        EntidadEntidadFederativa.Descripcion = TBDescripcion.Text
        EntidadEntidadFederativa.IdPais = CInt(DDPais.SelectedValue)
        EntidadEntidadFederativa.Equivalencia = TBEquivalencia.Text
        EntidadEntidadFederativa.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioEntidadFederativa.Guardar(EntidadEntidadFederativa)
        wucDatosAuditoria1.Guardar(EntidadEntidadFederativa)
        TBIdEntidadFederativa.Text = EntidadEntidadFederativa.IdEntidadFederativa
        SeleccionarView(1)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
    End Sub
    'Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
    '    MultiView1.SetActiveView(View1)
    'End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVEntidadFederativa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEntidadFederativa.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdEntidadFederativa.Text = Tabla.Rows(GVEntidadFederativa.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVEntidadFederativa.SelectedIndex).Item("Descripcion")
        DDPais.SelectedValue = Tabla.Rows(GVEntidadFederativa.SelectedIndex).Item("IdPais")
        TBEquivalencia.Text = Tabla.Rows(GVEntidadFederativa.SelectedIndex).Item("Equivalencia")
        DDEstado.SelectedValue = Tabla.Rows(GVEntidadFederativa.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVEntidadFederativa.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class