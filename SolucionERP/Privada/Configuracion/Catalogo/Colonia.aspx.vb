Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Colonia"
            'Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            ''Pais
            Dim tabla = New DataTable
            Dim NegocioPais As New Negocio.Pais()
            Dim EntidadPais As New Entidad.Pais()
            Dim tarjeta As New Entidad.Tarjeta()
            EntidadPais.Tarjeta = tarjeta
            EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioPais.Consultar(EntidadPais)
            DDPaisColonia.DataSource = EntidadPais.TablaConsulta
            DDPaisColonia.DataValueField = "ID"
            DDPaisColonia.DataTextField = "Descripcion"
            DDPaisColonia.DataBind()
            DDPaisColonia.SelectedValue = 1
            ' Entidad Federativa 
            Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
            Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()
            EntidadEntidadFederativa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioEntidadFederativa.Consultar(EntidadEntidadFederativa)
            DDEntFedColonia.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntFedColonia.DataValueField = "Id"
            DDEntFedColonia.DataTextField = "Descripcion"
            DDEntFedColonia.DataBind()
            DDEntFedColonia.SelectedValue = 1

            DDEntidadFederativaColonia.DataSource = EntidadEntidadFederativa.TablaConsulta
            DDEntidadFederativaColonia.DataValueField = "Id"
            DDEntidadFederativaColonia.DataTextField = "Descripcion"
            DDEntidadFederativaColonia.DataBind()
            DDEntidadFederativaColonia.SelectedValue = 8
            'Municipio
            Dim NegocioMunicipio As New Negocio.Municipio()
            Dim EntidadMunicipio As New Entidad.Municipio()
            EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioMunicipio.Consultar(EntidadMunicipio)
            DDMunColonia.DataSource = EntidadMunicipio.TablaConsulta
            DDMunColonia.DataValueField = "Id"
            DDMunColonia.DataTextField = "Descripcion"
            DDMunColonia.DataBind()
            DDMunColonia.SelectedValue = 1

            DDMunicipioColonia.DataSource = EntidadMunicipio.TablaConsulta
            DDMunicipioColonia.DataValueField = "Id"
            DDMunicipioColonia.DataTextField = "Descripcion"
            DDMunicipioColonia.DataBind()
            DDMunicipioColonia.SelectedValue = 1

            'Ciudad
            Dim NegocioCiudad As New Negocio.Ciudad()
            Dim EntidadCiudad As New Entidad.Ciudad()
            EntidadCiudad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioCiudad.Consultar(EntidadCiudad)
            DDCiudadColonia.DataSource = EntidadCiudad.TablaConsulta
            DDCiudadColonia.DataValueField = "Id"
            DDCiudadColonia.DataTextField = "Descripcion"
            DDCiudadColonia.DataBind()
            DDCiudadColonia.SelectedValue = 1

            DDCiudadColonia1.DataSource = EntidadCiudad.TablaConsulta
            DDCiudadColonia1.DataValueField = "Id"
            DDCiudadColonia1.DataTextField = "Descripcion"
            DDCiudadColonia1.DataBind()
            DDCiudadColonia1.Items.Add(New ListItem("TODOS", "-1"))
            DDCiudadColonia1.SelectedValue = 1
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
    Private Sub Consultar()
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        Dim Tabla As New DataTable
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        EntidadColonia.IdMunColonia = DDMunicipioColonia.SelectedValue
        EntidadColonia.IdEntFedColonia = DDEntidadFederativaColonia.SelectedValue
        EntidadColonia.IdCiudadColonia = DDCiudadColonia1.SelectedValue
        NegocioColonia.Consultar(EntidadColonia)
        Tabla = EntidadColonia.TablaConsulta
        GVColonia.Columns.Clear()
        GVColonia.DataSource = Tabla
        GVColonia.AutoGenerateColumns = False
        GVColonia.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVColonia.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "ID", "IdColonia") 'IdColonia
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Descripcion", "DesColonia") 'DesColonia
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Ciudad", "Ciudad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Municipio", "Municipio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Entidad Federativa", "EntidadFederativa")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Pais", "Pais")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Codigo Postal", "CPColonia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVColonia, New BoundField(), "Estado", "Estado")
        GVColonia.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdColonia.Text = ""
        TBDesColonia.Text = ""
        DDCiudadColonia.SelectedValue = 1
        DDMunColonia.SelectedValue = 1
        DDEntFedColonia.SelectedValue = 1
        DDPaisColonia.SelectedValue = 1
        TBCPColonia.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        If TBIdColonia.Text Is String.Empty Then
            EntidadColonia.IdColonia = 0
        Else
            EntidadColonia.IdColonia = CInt(TBIdColonia.Text)
        End If
        EntidadColonia.DescripcionColonia = TBDesColonia.Text
        EntidadColonia.IdCiudadColonia = CInt(DDCiudadColonia.SelectedValue)
        EntidadColonia.IdMunColonia = CInt(DDMunColonia.SelectedValue)
        EntidadColonia.IdEntFedColonia = CInt(DDEntFedColonia.SelectedValue)
        EntidadColonia.IdPaisColonia = CInt(DDPaisColonia.SelectedValue)
        EntidadColonia.CPColonia = TBCPColonia.Text
        EntidadColonia.IdEstadoColonia = CInt(DDEstado.SelectedValue)
        NegocioColonia.Guardar(EntidadColonia)
        wucDatosAuditoria1.Guardar(EntidadColonia)
        TBIdColonia.Text = EntidadColonia.IdColonia
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub

    'Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
    '    MultiView1.SetActiveView(View1)
    'End Sub

    Protected Sub GVColonia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVColonia.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdColonia.Text = Tabla.Rows(GVColonia.SelectedIndex).Item("IdColonia") 'IdColonia
        TBDesColonia.Text = Tabla.Rows(GVColonia.SelectedIndex).Item("DesColonia") 'DesColonia
        DDCiudadColonia.SelectedValue = Tabla.Rows(GVColonia.SelectedIndex).Item("IdCiudadColonia")
        DDMunColonia.SelectedValue = Tabla.Rows(GVColonia.SelectedIndex).Item("IdMunicipioColonia")
        DDEntFedColonia.SelectedValue = Tabla.Rows(GVColonia.SelectedIndex).Item("IdEntFedColonia")
        DDPaisColonia.SelectedValue = Tabla.Rows(GVColonia.SelectedIndex).Item("IdPaisColonia")
        TBCPColonia.Text = Tabla.Rows(GVColonia.SelectedIndex).Item("CPColonia")
        DDEstado.SelectedValue = Tabla.Rows(GVColonia.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVColonia.SelectedIndex))
        SeleccionarView(1)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub DDEntidadFederativaColonia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEntidadFederativaColonia.SelectedIndexChanged
        Dim TablaMunicipio As New DataTable
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()
        EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadMunicipio.IdEntidadFederativa = DDEntidadFederativaColonia.SelectedValue
        NegocioMunicipio.Consultar(EntidadMunicipio)
        TablaMunicipio = EntidadMunicipio.TablaConsulta
        DDMunicipioColonia.DataSource = TablaMunicipio
        DDMunicipioColonia.DataValueField = "ID"
        DDMunicipioColonia.DataTextField = "Descripcion"
        DDMunicipioColonia.DataBind()
        DDMunicipioColonia.Items.Add(New ListItem("TODOS", "-1"))
        DDMunicipioColonia.SelectedValue = -1

        Dim TablaCiudad As New DataTable
        Dim NegocioCiudad As New Negocio.Ciudad
        Dim EntidadCiudad As New Entidad.Ciudad
        EntidadCiudad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadCiudad.IdMunCiudad = DDMunicipioColonia.SelectedValue
        NegocioCiudad.Consultar(EntidadCiudad)
        TablaCiudad = EntidadCiudad.TablaConsulta
        DDCiudadColonia1.DataSource = TablaCiudad
        DDCiudadColonia1.DataValueField = "ID"
        DDCiudadColonia1.DataTextField = "Descripcion"
        DDCiudadColonia1.DataBind()
        DDCiudadColonia1.Items.Add(New ListItem("TODOS", "-1"))
        DDCiudadColonia1.SelectedValue = -1

    End Sub

    Protected Sub DDMunicipioColonia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDMunicipioColonia.SelectedIndexChanged
        Dim TablaCiudad As New DataTable
        Dim NegocioCiudad As New Negocio.Ciudad
        Dim EntidadCiudad As New Entidad.Ciudad
        EntidadCiudad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadCiudad.IdMunCiudad = DDMunicipioColonia.SelectedValue
        NegocioCiudad.Consultar(EntidadCiudad)
        TablaCiudad = EntidadCiudad.TablaConsulta
        DDCiudadColonia1.DataSource = TablaCiudad
        DDCiudadColonia1.DataValueField = "ID"
        DDCiudadColonia1.DataTextField = "Descripcion"
        DDCiudadColonia1.DataBind()
        DDCiudadColonia1.Items.Add(New ListItem("TODOS", "-1"))
        DDCiudadColonia1.SelectedValue = -1
    End Sub
End Class