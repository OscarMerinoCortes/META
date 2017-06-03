Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Municipio"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            'Consulta a la tabla pais para DDPais del catalogo Ciudad
            Dim tabla = New DataTable
            Dim NegocioPais As New Negocio.Pais()
            Dim EntidadPais As New Entidad.Pais()
            Dim tarjeta As New Entidad.Tarjeta()
            EntidadPais.Tarjeta = tarjeta
            EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioPais.Consultar(EntidadPais)
            DDPais.DataSource = EntidadPais.TablaConsulta
            DDPais.DataValueField = "Id"
            DDPais.DataTextField = "Descripcion"
            DDPais.DataBind()
            DDPais.SelectedValue = 1
            ''Consulta a la tabla pais para DDEntidad Federativa del catalogo Ciudad
            Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
            Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()
            'EntidadEntidadFederativa.Tarjeta = tarjeta
            EntidadEntidadFederativa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioEntidadFederativa.Consultar(EntidadEntidadFederativa)
            DDEntidadFederativa.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntidadFederativa.DataValueField = "ID"
            DDEntidadFederativa.DataTextField = "Descripcion"
            DDEntidadFederativa.DataBind()
            DDEntidadFederativa.SelectedValue = 8

            DDEntidadFederativa1.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntidadFederativa1.DataValueField = "ID"
            DDEntidadFederativa1.DataTextField = "Descripcion"
            DDEntidadFederativa1.DataBind()
            DDEntidadFederativa1.SelectedValue = 8
            DDEntidadFederativa1.Items.Add(New ListItem("TODOS", "-1"))
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
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()

        Dim Tabla As New DataTable
        EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadMunicipio.IdEntidadFederativa = DDEntidadFederativa1.SelectedValue
        NegocioMunicipio.Consultar(EntidadMunicipio)
        Tabla = EntidadMunicipio.TablaConsulta
        GVMunicipio.Columns.Clear()
        GVMunicipio.DataSource = Tabla
        GVMunicipio.AutoGenerateColumns = False
        GVMunicipio.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVMunicipio.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVMunicipio, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMunicipio, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMunicipio, New BoundField(), "Entidad Federativa", "EntidadFederativa")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMunicipio, New BoundField(), "Pais", "Pais")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMunicipio, New BoundField(), "Estado", "Estado")

        GVMunicipio.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdMunicipio.Text = ""
        TBDescripcion.Text = ""
        DDPais.SelectedValue = 1
        DDEntidadFederativa.SelectedValue = 8
        TBEquivalencia.Text = ""
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()
        If TBIdMunicipio.Text Is String.Empty Then
            EntidadMunicipio.IdMunicipio = 0
        Else
            EntidadMunicipio.IdMunicipio = CInt(TBIdMunicipio.Text)
        End If
        EntidadMunicipio.Descripcion = TBDescripcion.Text
        EntidadMunicipio.IdPais = CInt(DDPais.SelectedValue)
        EntidadMunicipio.IdEntidadFederativa = CInt(DDEntidadFederativa.SelectedValue)
        EntidadMunicipio.Equivalencia = TBEquivalencia.Text
        EntidadMunicipio.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioMunicipio.Guardar(EntidadMunicipio)
        wucDatosAuditoria1.Guardar(EntidadMunicipio)
        TBIdMunicipio.Text = EntidadMunicipio.IdMunicipio
        SeleccionarView(1)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub
    Protected Sub GVMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVMunicipio.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdMunicipio.Text = Tabla.Rows(GVMunicipio.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVMunicipio.SelectedIndex).Item("Descripcion")
        DDPais.Text = Tabla.Rows(GVMunicipio.SelectedIndex).Item("IdPais")
        DDEntidadFederativa.Text = Tabla.Rows(GVMunicipio.SelectedIndex).Item("IdEntidadFederativa")
        TBEquivalencia.Text = Tabla.Rows(GVMunicipio.SelectedIndex).Item("Equivalencia")
        DDEstado.SelectedValue = Tabla.Rows(GVMunicipio.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVMunicipio.SelectedIndex))
        SeleccionarView(1)
    End Sub

    'Protected Sub DDPaisMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPaisMunicipio.SelectedIndexChanged
    '    ''Consulta a la tabla Entidad Federativa
    '    Dim tabla = New DataTable
    '    Dim NegocioEntidadFed As New Negocio.EntidadFederativa()
    '    Dim EntidadEntidadFed As New Entidad.EntidadFederativa()
    '    Dim tarjeta As New Entidad.Tarjeta()
    '    EntidadEntidadFed.Tarjeta = tarjeta
    '    EntidadEntidadFed.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
    '    EntidadEntidadFed.IdPaisEntFed = DDPaisMunicipio.SelectedValue
    '    NegocioEntidadFed.Consultar(EntidadEntidadFed)
    '    DDEntFedMunicipio.DataSource = EntidadEntidadFed.TablaConsulta
    '    DDEntFedMunicipio.DataValueField = "IdEntFed"
    '    DDEntFedMunicipio.DataTextField = "DesEntFed"
    '    DDEntFedMunicipio.DataBind()
    '    'DDEntFedMunicipio.SelectedValue = 1
    '    MultiView1.SetActiveView(View1)
    'End Sub
    'Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
    '    MultiView1.SetActiveView(View1)
    'End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub DDEntidadFederativa1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEntidadFederativa1.SelectedIndexChanged

    End Sub
End Class