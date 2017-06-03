Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Ciudad"
            'Consultar()
            wucDatosAuditoria1.Visible = True
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            'Consulta a la tabla pais para DDPais
            Dim tabla = New DataTable
            Dim NegocioPais As New Negocio.Pais()
            Dim EntidadPais As New Entidad.Pais()
            EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioPais.Consultar(EntidadPais)
            DDPaisCiudad.DataSource = EntidadPais.TablaConsulta
            DDPaisCiudad.DataValueField = "Id"
            DDPaisCiudad.DataTextField = "Descripcion"
            DDPaisCiudad.DataBind()
            DDPaisCiudad.SelectedValue = 1
            ' ''Consulta a la tabla Entidad Federativa para DDEntidad
            Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
            Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()
            EntidadEntidadFederativa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioEntidadFederativa.Consultar(EntidadEntidadFederativa)
            DDEntFedCiudad.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntFedCiudad.DataValueField = "Id"
            DDEntFedCiudad.DataTextField = "Descripcion"
            DDEntFedCiudad.DataBind()
            DDEntFedCiudad.SelectedValue = 1

            DDEntFedCiudad.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntFedCiudad.DataValueField = "Id"
            DDEntFedCiudad.DataTextField = "Descripcion"
            DDEntFedCiudad.DataBind()
            DDEntFedCiudad.SelectedValue = 8

            DDEntidadFederativaCiudad.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntidadFederativaCiudad.DataValueField = "Id"
            DDEntidadFederativaCiudad.DataTextField = "Descripcion"
            DDEntidadFederativaCiudad.DataBind()
            DDEntidadFederativaCiudad.SelectedValue = 8
            ' ''Consulta a la tabla Municipio para DDMunCiudad
            Dim NegocioMunicipio As New Negocio.Municipio()
            Dim EntidadMunicipio As New Entidad.Municipio()
            EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioMunicipio.Consultar(EntidadMunicipio)
            DDMunCiudad.DataSource = EntidadMunicipio.TablaConsulta
            DDMunCiudad.DataValueField = "Id"
            DDMunCiudad.DataTextField = "Descripcion"
            DDMunCiudad.DataBind()
            DDMunCiudad.SelectedValue = 1

            DDMunicipioCiudad.DataSource = EntidadMunicipio.TablaConsulta
            DDMunicipioCiudad.DataValueField = "Id"
            DDMunicipioCiudad.DataTextField = "Descripcion"
            DDMunicipioCiudad.DataBind()
            DDMunicipioCiudad.SelectedValue = 1
            DDMunicipioCiudad.Items.Add(New ListItem("TODOS", "-1"))

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
        Dim NegocioCiudad As New Negocio.Ciudad()
        Dim EntidadCiudad As New Entidad.Ciudad()
        Dim Tabla As New DataTable
        EntidadCiudad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadCiudad.IdEntFedCiudad = DDEntidadFederativaCiudad.SelectedValue
        EntidadCiudad.IdMunCiudad = DDMunicipioCiudad.SelectedValue
        NegocioCiudad.Consultar(EntidadCiudad)
        Tabla = EntidadCiudad.TablaConsulta
        GVCiudad.Columns.Clear()
        GVCiudad.DataSource = Tabla
        GVCiudad.AutoGenerateColumns = False
        GVCiudad.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVCiudad.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "ID", "IdCiudad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "Municipio", "Municipio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "Entidad Federativa", "EntidadFederativa")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "Pais", "Pais")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCiudad, New BoundField(), "Estado", "Estado")
        GVCiudad.DataBind()
        Session("Tabla") = Tabla
        wucDatosAuditoria1.Visible = True
        SeleccionarView(0)
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdCiudad.Text = ""
        TBDesCiudad.Text = ""
        DDPaisCiudad.SelectedValue = 1
        DDEntFedCiudad.SelectedValue = 1
        DDMunCiudad.SelectedValue = 1
        TBEquivalenciaCiudad.Text = ""
        wucDatosAuditoria1.Visible = False
        DDEstado.SelectedValue = 1
        SeleccionarView(1)

    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioCiudad As New Negocio.Ciudad()
        Dim EntidadCiudad As New Entidad.Ciudad()
        If TBIdCiudad.Text Is String.Empty Then
            EntidadCiudad.IdCiudad = 0
        Else
            EntidadCiudad.IdCiudad = CInt(TBIdCiudad.Text)
        End If
        EntidadCiudad.DescripcionCiudad = TBDesCiudad.Text
        EntidadCiudad.IdPaisCiudad = CInt(DDPaisCiudad.SelectedValue)
        EntidadCiudad.IdEntFedCiudad = CInt(DDEntFedCiudad.SelectedValue)
        EntidadCiudad.IdMunCiudad = CInt(DDMunCiudad.SelectedValue)
        EntidadCiudad.EquivalenciaCiudad = TBEquivalenciaCiudad.Text
        EntidadCiudad.IdEstadoCiudad = CInt(DDEstado.SelectedValue)
        NegocioCiudad.Guardar(EntidadCiudad)
        wucDatosAuditoria1.Guardar(EntidadCiudad)
        TBIdCiudad.Text = EntidadCiudad.IdCiudad
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
    End Sub

    Protected Sub GVCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCiudad.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdCiudad.Text = Tabla.Rows(GVCiudad.SelectedIndex).Item("IdCiudad")
        TBDesCiudad.Text = Tabla.Rows(GVCiudad.SelectedIndex).Item("Descripcion")
        DDPaisCiudad.SelectedValue = Tabla.Rows(GVCiudad.SelectedIndex).Item("IdPais")
        DDEntFedCiudad.SelectedValue = Tabla.Rows(GVCiudad.SelectedIndex).Item("IdEntidadFederativa")
        DDMunCiudad.SelectedValue = Tabla.Rows(GVCiudad.SelectedIndex).Item("IdMunicipio")
        TBEquivalenciaCiudad.Text = Tabla.Rows(GVCiudad.SelectedIndex).Item("Equivalencia")
        DDEstado.SelectedValue = Tabla.Rows(GVCiudad.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVCiudad.SelectedIndex))
        SeleccionarView(1)
    End Sub

    Protected Sub DDEntFedCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEntFedCiudad.SelectedIndexChanged
        Dim TablaMunicipio As New DataTable
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()
        EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadMunicipio.IdEntidadFederativa = DDEntFedCiudad.SelectedValue
        NegocioMunicipio.Consultar(EntidadMunicipio)
        TablaMunicipio = EntidadMunicipio.TablaConsulta
        DDMunCiudad.DataSource = TablaMunicipio
        DDMunCiudad.DataValueField = "ID"
        DDMunCiudad.DataTextField = "Descripcion"
        DDMunCiudad.DataBind()
        ' ''Consulta a la tabla Municipio
        'Dim tabla = New DataTable
        'Dim NegocioMunicipio As New Negocio.Municipio()
        'Dim EntidadMunicipio As New Entidad.Municipio()
        'Dim tarjeta As New Entidad.Tarjeta()
        'EntidadMunicipio.Tarjeta = tarjeta
        'EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        'EntidadMunicipio.IdEntFedMunicipio = DDEntFedCiudad.SelectedValue
        'NegocioMunicipio.Consultar(EntidadMunicipio)
        'DDMunCiudad.DataSource = EntidadMunicipio.TablaConsulta
        'DDMunCiudad.DataValueField = "IdMunicipio"
        'DDMunCiudad.DataTextField = "DesMunicipio"
        'DDMunCiudad.DataBind()
        ''DDEntFedMunicipio.SelectedValue = 1
        'MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub DDPaisCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPaisCiudad.SelectedIndexChanged
        ''Consulta a la tabla Entidad Federativa
        'Dim tabla = New DataTable
        'Dim NegocioEntidadFed As New Negocio.EntidadFederativa()
        'Dim EntidadEntidadFed As New Entidad.EntidadFederativa()
        'Dim tarjeta As New Entidad.Tarjeta()
        'EntidadEntidadFed.Tarjeta = tarjeta
        'EntidadEntidadFed.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        'EntidadEntidadFed.IdPais = DDPaisCiudad.SelectedValue
        'NegocioEntidadFed.Consultar(EntidadEntidadFed)
        'DDEntFedCiudad.DataSource = EntidadEntidadFed.TablaConsulta
        'DDEntFedCiudad.DataValueField = "IdEntFed"
        'DDEntFedCiudad.DataTextField = "DesEntFed"
        'DDEntFedCiudad.DataBind()
        'DDEntFedMunicipio.SelectedValue = 1
        'MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub DDEntidadFederativaCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEntidadFederativaCiudad.SelectedIndexChanged
        Dim TablaMunicipio As New DataTable
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()
        EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadMunicipio.IdEntidadFederativa = DDEntidadFederativaCiudad.SelectedValue
        NegocioMunicipio.Consultar(EntidadMunicipio)
        TablaMunicipio = EntidadMunicipio.TablaConsulta
        DDMunicipioCiudad.DataSource = TablaMunicipio
        DDMunicipioCiudad.DataValueField = "ID"
        DDMunicipioCiudad.DataTextField = "Descripcion"
        DDMunicipioCiudad.DataBind()
        DDMunicipioCiudad.Items.Add(New ListItem("TODOS", "-1"))
        DDMunicipioCiudad.SelectedValue = -1

    End Sub
End Class