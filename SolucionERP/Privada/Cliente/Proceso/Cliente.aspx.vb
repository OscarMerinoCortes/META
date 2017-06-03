Imports System.Data
Partial Class _Default
    Inherits Page

    Dim TipoAntiguedad As Integer
    Public TablaIdentificacion As New DataTable()
    Public VistaIdentificacion As New DataView()
    Public TablaContacto As New DataTable()
    Public VistaContacto As New DataView()
    Public TablaDomicilio As New DataTable()
    Public VistaDomicilio As New DataView()
    Public TablaEmpleo As New DataTable()
    Public VistaEmpleo As New DataView()
    Public TablaReferencia As New DataTable()
    Public VistaReferencia As New DataView()
    Public TablaLineaCredito As New DataTable()
    Public VistaLineaCredito As New DataView()
    Public TablaIndicador As New DataTable()
    Public VistaIndicador As New DataView()
    Public TablaConyugue As New DataTable()
    Public VistaConyugue As New DataView()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Registro de Cliente"
            wucDatosAuditoria1.Visible = False
            ControlPais.Visible = False
            ControlEntidadFederativa.Visible = False

            DDTipoPersona.Items.Add(New ListItem("FISICA", 1))
            DDTipoPersona.Items.Add(New ListItem("MORAL", 2))
            DDTipoPersona.SelectedIndex = 0

            DDGenero.Items.Add(New ListItem("MASCULINO", 1))
            DDGenero.Items.Add(New ListItem("FEMENINO", 2))
            DDGenero.SelectedIndex = 0

            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedIndex = 0

            '====================================================================
            TBFechaInicioConsultar.Text = CDate(Date.FromOADate(1 / 1 / 1990)).ToString("dd/MM/yyyy")
            TBFechaFinConsultar.Text = CDate(Now).ToString("dd/MM/yyyy")

            DDGeneroConsulta.Items.Add(New ListItem("TODO", -1))
            DDGeneroConsulta.Items.Add(New ListItem("MASCULINO", 1))
            DDGeneroConsulta.Items.Add(New ListItem("FEMENINO", 2))
            DDGeneroConsulta.SelectedIndex = -1

            DDTipoPersonaConsulta.Items.Add(New ListItem("TODO", -1))
            DDTipoPersonaConsulta.Items.Add(New ListItem("FISICA", 1))
            DDTipoPersonaConsulta.Items.Add(New ListItem("MORAL", 2))
            DDTipoPersonaConsulta.SelectedIndex = -1

            DDEstadoConsulta.Items.Add(New ListItem("TODO", -1))
            DDEstadoConsulta.Items.Add(New ListItem("ACTIVO", 1))
            DDEstadoConsulta.Items.Add(New ListItem("INACTIVO", 2))
            DDEstadoConsulta.SelectedIndex = -1


            '=====================================================================
            Dim TablaPais As New DataTable
            Dim NegocioPais As New Negocio.Pais()
            Dim EntidadPais As New Entidad.Pais()
            EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioPais.Consultar(EntidadPais)
            TablaPais = EntidadPais.TablaConsulta
            DDPais.DataSource = TablaPais
            DDPais.DataValueField = "ID"
            DDPais.DataTextField = "Descripcion"
            DDPais.DataBind()
            DDPais.SelectedIndex = 0


            Dim TablaEntidadFederativa As New DataTable
            Dim NegocioEntidadFederativa As New Negocio.EntidadFederativa()
            Dim EntidadEntidadFederativa As New Entidad.EntidadFederativa()
            EntidadEntidadFederativa.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
            EntidadEntidadFederativa.IdPais = DDPais.SelectedValue
            NegocioEntidadFederativa.Consultar(EntidadEntidadFederativa)
            TablaEntidadFederativa = EntidadEntidadFederativa.TablaConsulta
            DDEntidadFederativa.DataSource = TablaEntidadFederativa
            DDEntidadFederativa.DataValueField = "ID"
            DDEntidadFederativa.DataTextField = "Descripcion"
            DDEntidadFederativa.DataBind()
            DDEntidadFederativa.SelectedIndex = 7

            Dim TablaMunicipio As New DataTable
            Dim NegocioMunicipio As New Negocio.Municipio()
            Dim EntidadMunicipio As New Entidad.Municipio()
            EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
            EntidadMunicipio.IdEntidadFederativa = DDEntidadFederativa.SelectedValue
            NegocioMunicipio.Consultar(EntidadMunicipio)
            TablaMunicipio = EntidadMunicipio.TablaConsulta
            DDDomMunicipio.DataSource = TablaMunicipio
            DDDomMunicipio.DataValueField = "ID"
            DDDomMunicipio.DataTextField = "Descripcion"
            DDDomMunicipio.DataBind()
            DDDomMunicipio.SelectedIndex = 20

            Dim TablaColonia As New DataTable
            Dim NegocioColonia As New Negocio.Colonia()
            Dim EntidadColonia As New Entidad.Colonia()
            EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
            NegocioColonia.Consultar(EntidadColonia)
            TablaColonia = EntidadColonia.TablaConsulta
            DDDomColonia.DataSource = TablaColonia
            DDDomColonia.DataValueField = "IdColonia"
            DDDomColonia.DataTextField = "DesColonia"
            DDDomColonia.DataBind()
            DDDomColonia.SelectedIndex = 0

            'DDDomLocalidad.Items.Add(New ListItem("Delicias", 1))
            'DDDomLocalidad.Items.Add(New ListItem("Meoqui", 2))
            'DDDomLocalidad.Items.Add(New ListItem("Saucillo", 3))
            'DDDomLocalidad.Items.Add(New ListItem("Naica", 4))
            'DDDomLocalidad.SelectedIndex = 0
            '=====================================================================

            DDGeneroConyugue.Items.Add(New ListItem("MASCULINO", 1))
            DDGeneroConyugue.Items.Add(New ListItem("FEMENINO", 2))
            DDGeneroConyugue.SelectedValue = 2


            DDEstadoConyugue.Items.Add(New ListItem("ACTIVO", 1))
            DDEstadoConyugue.Items.Add(New ListItem("INACTIVO", 2))
            DDEstadoConyugue.SelectedIndex = 0

            Dim TablaTEC As New DataTable
            Dim NegocioEstadoCivil As New Negocio.TipoEstadoCivil()
            Dim EntidadEstadoCivil As New Entidad.TipoEstadoCivil()
            EntidadEstadoCivil.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioEstadoCivil.Consultar(EntidadEstadoCivil)
            TablaTEC = EntidadEstadoCivil.TablaConsulta
            DDEstadoCivil.DataSource = TablaTEC
            DDEstadoCivil.DataValueField = "ID"
            DDEstadoCivil.DataTextField = "Descripcion"
            DDEstadoCivil.DataBind()

            DDEstCivConyugue.DataSource = TablaTEC
            DDEstCivConyugue.DataValueField = "ID"
            DDEstCivConyugue.DataTextField = "Descripcion"
            DDEstCivConyugue.DataBind()

            Dim TablaTI As New DataTable
            Dim NegocioTipoIdentificacion As New Negocio.TipoIdentificacion()
            Dim EntidadTipoIdentificacion As New Entidad.TipoIdentificacion()
            EntidadTipoIdentificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoIdentificacion.Consultar(EntidadTipoIdentificacion)
            TablaTI = EntidadTipoIdentificacion.TablaConsulta
            DDTipoIdentificacion.DataSource = TablaTI
            DDTipoIdentificacion.DataValueField = "ID"
            DDTipoIdentificacion.DataTextField = "Descripcion"
            DDTipoIdentificacion.DataBind()

            Dim TablaTM As New DataTable
            Dim NegocioTipoMedio As New Negocio.TipoMedio()
            Dim EntidadTipoMedio As New Entidad.TipoMedio()
            EntidadTipoMedio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoMedio.Consultar(EntidadTipoMedio)
            TablaTM = EntidadTipoMedio.TablaConsulta
            DDTipoMedio.DataSource = TablaTM
            DDTipoMedio.DataValueField = "ID"
            DDTipoMedio.DataTextField = "Descripcion"
            DDTipoMedio.DataBind()

            Dim TablaTD As New DataTable
            Dim NegocioTipoDomicilio As New Negocio.TipoDomicilio()
            Dim EntidadTipoDomicilio As New Entidad.TipoDomicilio()
            EntidadTipoDomicilio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoDomicilio.Consultar(EntidadTipoDomicilio)
            TablaTD = EntidadTipoDomicilio.TablaConsulta
            DDTipoDomicilio.DataSource = TablaTD
            DDTipoDomicilio.DataValueField = "ID"
            DDTipoDomicilio.DataTextField = "Descripcion"
            DDTipoDomicilio.DataBind()

            Dim TablaTE As New DataTable
            Dim NegocioTipoEmpleo As New Negocio.TipoEmpleo()
            Dim EntidadTipoEmpleo As New Entidad.TipoEmpleo()
            EntidadTipoEmpleo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoEmpleo.Consultar(EntidadTipoEmpleo)
            TablaTE = EntidadTipoEmpleo.TablaConsulta
            DDTipoEmpleos.DataSource = TablaTE
            DDTipoEmpleos.DataValueField = "ID"
            DDTipoEmpleos.DataTextField = "Descripcion"
            DDTipoEmpleos.DataBind()

            Dim TablaTR As New DataTable
            Dim NegocioTipoReferencia As New Negocio.TipoReferencia()
            Dim EntidadTipoReferencia As New Entidad.TipoReferencia()
            EntidadTipoReferencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoReferencia.Consultar(EntidadTipoReferencia)
            TablaTR = EntidadTipoReferencia.TablaConsulta
            DDTipoReferencia.DataSource = TablaTR
            DDTipoReferencia.DataValueField = "ID"
            DDTipoReferencia.DataTextField = "Descripcion"
            DDTipoReferencia.DataBind()

            Dim TablaTIn As New DataTable
            Dim NegocioTipoIndicador As New Negocio.TipoIndicador()
            Dim EntidadTipoIndicador As New Entidad.TipoIndicador()
            EntidadTipoIndicador.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoIndicador.Consultar(EntidadTipoIndicador)
            TablaTIn = EntidadTipoIndicador.TablaConsulta
            DDTipoIndicador.DataSource = TablaTIn
            DDTipoIndicador.DataValueField = "ID"
            DDTipoIndicador.DataTextField = "Descripcion"
            DDTipoIndicador.DataBind()

            'Dim TablaTP As New DataTable
            'Dim NegocioTipoDomicilio As New Negocio.TipoDomicilio()
            'Dim EntidadTipoDomicilio As New Entidad.TipoDomicilio()
            'EntidadTipoDomicilio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            'NegocioTipoDomicilio.Consultar(EntidadTipoDomicilio)
            'TablaTD = EntidadTipoDomicilio.TablaConsulta
            'DDTipoDomicilio.DataSource = TablaTD
            'DDTipoDomicilio.DataValueField = "ID"
            'DDTipoDomicilio.DataTextField = "Descripcion"
            'DDTipoDomicilio.DataBind()
            '================================================Identificacion=============================================
            TablaIdentificacion.Columns.Clear()
            TablaIdentificacion.Columns.Add(New DataColumn("IdPersonaIdentificacion", Type.GetType("System.Int32")))
            TablaIdentificacion.Columns.Add(New DataColumn("IdTipoIdentificacion", Type.GetType("System.Int32")))
            TablaIdentificacion.Columns.Add(New DataColumn("ClaveIdentificacion", Type.GetType("System.String")))
            TablaIdentificacion.Columns.Add(New DataColumn("TipoIdentificacion", Type.GetType("System.String")))
            TablaIdentificacion.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaIdentificacion.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaIdentificacion.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaIdentificacion.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaIdentificacion.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaIdentificacion.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaIdentificacion = TablaIdentificacion.DefaultView
            VistaIdentificacion.RowFilter = "IdEstado=1"

            GVIdentificacion.Columns.Clear()
            GVIdentificacion.DataSource = TablaIdentificacion
            GVIdentificacion.AutoGenerateColumns = False
            GVIdentificacion.AllowSorting = True

            Dim Columna1 As New CommandField()
            Columna1.HeaderText = ""
            Columna1.HeaderText = "Seleccionar"
            Columna1.SelectText = "Seleccionar"
            Columna1.ButtonType = ButtonType.Link
            Columna1.ShowSelectButton = True
            GVIdentificacion.Columns.Add(Columna1)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVIdentificacion, New BoundField(), "Clave Identificacion", "ClaveIdentificacion")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVIdentificacion, New BoundField(), "Tipo Identificacion", "TipoIdentificacion")
            GVIdentificacion.DataBind()

            Session("TablaIdentificacion") = TablaIdentificacion
            Session("VistaIdentificacion") = VistaIdentificacion
            '===================================================Contacto=========================================================
            TablaContacto.Columns.Clear()
            TablaContacto.Columns.Add(New DataColumn("IdPersonaMedio", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("IdTipoMedio", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("Contacto", Type.GetType("System.String")))
            TablaContacto.Columns.Add(New DataColumn("TipoContacto", Type.GetType("System.String")))
            TablaContacto.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaContacto.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaContacto.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaContacto = TablaContacto.DefaultView
            VistaContacto.RowFilter = "IdEstado=1"

            GVMedio.Columns.Clear()
            GVMedio.DataSource = TablaContacto
            GVMedio.AutoGenerateColumns = False
            GVMedio.AllowSorting = True

            Dim Columna2 As New CommandField()
            Columna2.HeaderText = ""
            Columna2.HeaderText = "Seleccionar"
            Columna2.SelectText = "Seleccionar"
            Columna2.ButtonType = ButtonType.Link
            Columna2.ShowSelectButton = True
            GVMedio.Columns.Add(Columna2)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVMedio, New BoundField(), "Contacto", "Contacto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVMedio, New BoundField(), "Tipo Contacto", "TipoContacto")
            GVMedio.DataBind()

            Session("TablaContacto") = TablaContacto
            Session("VistaContacto") = VistaContacto
            '====================================================Domicilio========================================================
            TablaDomicilio.Columns.Clear()
            TablaDomicilio.Columns.Add(New DataColumn("IdPersonaDomicilio", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("IdTipoDomicilio", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Calle", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("Telefono", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("Antiguedad", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("TipoAntiguedad", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Propietario", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("Pais", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Estado", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Municipio", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Localidad", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("Colonia", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("NumeroInterior", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("NumeroExterior", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("CP", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("TipoDomicilio", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaDomicilio.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))
            TablaDomicilio.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))

            VistaDomicilio = TablaDomicilio.DefaultView
            VistaDomicilio.RowFilter = "IdEstado=1"

            GVDomicilio.Columns.Clear()
            GVDomicilio.DataSource = TablaDomicilio
            GVDomicilio.AutoGenerateColumns = False
            GVDomicilio.AllowSorting = True

            Dim Columna3 As New CommandField()
            Columna3.HeaderText = ""
            Columna3.HeaderText = "Seleccionar"
            Columna3.SelectText = "Seleccionar"
            Columna3.ButtonType = ButtonType.Link
            Columna3.ShowSelectButton = True
            GVDomicilio.Columns.Add(Columna3)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Municipio", "Municipio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Colonia", "Colonia")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Calle", "Calle")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Telefono", "Telefono")
            GVMedio.DataBind()

            Session("TablaDomicilio") = TablaDomicilio
            Session("VistaDomicilio") = VistaDomicilio
            '====================================================Empleos========================================================
            TablaEmpleo.Columns.Clear()
            TablaEmpleo.Columns.Add(New DataColumn("IdPersonaEmpleo", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("IdTipoEmpleo", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("Ocupacion", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("Empresa", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("Antiguedad", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("Domicilio", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("Telefono", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaEmpleo.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaEmpleo.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaEmpleo = TablaEmpleo.DefaultView
            VistaEmpleo.RowFilter = "IdEstado=1"

            GVEmpleo.Columns.Clear()
            GVEmpleo.DataSource = TablaEmpleo
            GVEmpleo.AutoGenerateColumns = False
            GVEmpleo.AllowSorting = True

            Dim Columna4 As New CommandField()
            Columna4.HeaderText = ""
            Columna4.HeaderText = "Seleccionar"
            Columna4.SelectText = "Seleccionar"
            Columna4.ButtonType = ButtonType.Link
            Columna4.ShowSelectButton = True
            GVEmpleo.Columns.Add(Columna4)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVEmpleo, New BoundField(), "Ocupacion", "Ocupacion")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVEmpleo, New BoundField(), "Empresa", "Empresa")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVEmpleo, New BoundField(), "Telefono", "Telefono")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVEmpleo, New BoundField(), "Direccion", "Domicilio")
            GVEmpleo.DataBind()

            Session("TablaEmpleo") = TablaEmpleo
            Session("VistaEmpleo") = VistaEmpleo

            '====================================================Referencia========================================================
            TablaReferencia.Columns.Clear()
            TablaReferencia.Columns.Add(New DataColumn("IdPersonaReferencia", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("IdTipoReferencia", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("NombreReferencia", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("Ocupacion", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("Empresa", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("Antiguedad", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("Domicilio", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("Telefono", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaReferencia.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaReferencia.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaReferencia = TablaReferencia.DefaultView
            VistaReferencia.RowFilter = "IdEstado=1"

            GVReferencia.Columns.Clear()
            GVReferencia.DataSource = TablaReferencia
            GVReferencia.AutoGenerateColumns = False
            GVReferencia.AllowSorting = True

            Dim Columna5 As New CommandField()
            Columna5.HeaderText = ""
            Columna5.HeaderText = "Seleccionar"
            Columna5.SelectText = "Seleccionar"
            Columna5.ButtonType = ButtonType.Link
            Columna5.ShowSelectButton = True
            GVReferencia.Columns.Add(Columna5)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVReferencia, New BoundField(), "Ocupacion", "Ocupacion")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVReferencia, New BoundField(), "Nombre", "NombreReferencia")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVReferencia, New BoundField(), "Empresa", "Empresa")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVReferencia, New BoundField(), "Telefono", "Telefono")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVReferencia, New BoundField(), "Direccion", "Domicilio")
            GVReferencia.DataBind()

            Session("TablaReferencia") = TablaReferencia
            Session("VistaReferencia") = VistaReferencia
            '====================================================Linea credito========================================================
            TablaLineaCredito.Columns.Clear()
            TablaLineaCredito.Columns.Add(New DataColumn("IdPersonaLineaCredito", Type.GetType("System.Int32")))
            TablaLineaCredito.Columns.Add(New DataColumn("Fecha", Type.GetType("System.String")))
            TablaLineaCredito.Columns.Add(New DataColumn("Credito", Type.GetType("System.String")))
            TablaLineaCredito.Columns.Add(New DataColumn("Monto", Type.GetType("System.Int32")))
            TablaLineaCredito.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaLineaCredito.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaLineaCredito.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaLineaCredito.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaLineaCredito.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaLineaCredito.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaLineaCredito = TablaLineaCredito.DefaultView
            VistaLineaCredito.RowFilter = "IdEstado=1"

            GVLineaCredito.Columns.Clear()
            GVLineaCredito.DataSource = TablaEmpleo
            GVLineaCredito.AutoGenerateColumns = False
            GVLineaCredito.AllowSorting = True

            Dim Columna6 As New CommandField()
            Columna6.HeaderText = ""
            Columna6.HeaderText = "Seleccionar"
            Columna6.SelectText = "Seleccionar"
            Columna6.ButtonType = ButtonType.Link
            Columna6.ShowSelectButton = True
            GVLineaCredito.Columns.Add(Columna6)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVLineaCredito, New BoundField(), "Credito", "Credito")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVLineaCredito, New BoundField(), "Monto", "Monto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVLineaCredito, New BoundField(), "Fecha", "Fecha")
            GVLineaCredito.DataBind()

            Session("TablaLineaCredito") = TablaLineaCredito
            Session("VistaLineaCredito") = VistaLineaCredito

            '====================================================Indicadores========================================================
            TablaIndicador.Columns.Clear()
            TablaIndicador.Columns.Add(New DataColumn("IdPersonaIndicador", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("IdTipoIndicador", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("TipoIndicador", Type.GetType("System.String")))
            TablaIndicador.Columns.Add(New DataColumn("Monto", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaIndicador.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaIndicador.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaIndicador.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaIndicador = TablaIndicador.DefaultView
            VistaIndicador.RowFilter = "IdEstado=1"

            GVIndicador.Columns.Clear()
            GVIndicador.DataSource = TablaIndicador
            GVIndicador.AutoGenerateColumns = False
            GVIndicador.AllowSorting = True

            Dim Columna7 As New CommandField()
            Columna7.HeaderText = ""
            Columna7.HeaderText = "Seleccionar"
            Columna7.SelectText = "Seleccionar"
            Columna7.ButtonType = ButtonType.Link
            Columna7.ShowSelectButton = True
            GVIndicador.Columns.Add(Columna7)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVIndicador, New BoundField(), "Monto", "Monto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVIndicador, New BoundField(), "Tipo Indicador", "TipoIndicador")
            GVIndicador.DataBind()

            Session("TablaIndicador") = TablaIndicador
            Session("VistaIndicador") = VistaIndicador
            '===================================================Conyugue==========================================================
            TablaConyugue.Columns.Clear()
            TablaConyugue.Columns.Add(New DataColumn("IdPersonaConyugue", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("IdPersona", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("Equivalencia", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("IdTipoPersona", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("RazonSocial", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("PrimerNombre", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("SegundoNombre", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("ApellidoPaterno", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("ApellidoMaterno", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("FechaNacimiento", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("IdTipoGenero", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("IdTipoEstadoCivil", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("idUsuarioCreacion", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("idUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("Observaciones", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("DescripcionEstado", Type.GetType("System.String")))
            TablaConyugue.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))
            TablaConyugue.Columns.Add(New DataColumn("NombreConyugue", Type.GetType("System.String")))

            VistaConyugue = TablaConyugue.DefaultView
            VistaConyugue.RowFilter = "IdEstado=1"

            GVConyugue.Columns.Clear()
            GVConyugue.DataSource = TablaConyugue
            GVConyugue.AutoGenerateColumns = False
            GVConyugue.AllowSorting = True

            Dim Columna8 As New CommandField()
            Columna8.HeaderText = ""
            Columna8.HeaderText = "Seleccionar"
            Columna8.SelectText = "Seleccionar"
            Columna8.ButtonType = ButtonType.Link
            Columna8.ShowSelectButton = True
            GVConyugue.Columns.Add(Columna8)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVConyugue, New BoundField(), "Nombre Conyugue", "NombreConyugue")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVConyugue, New BoundField(), "Estado", "DescripcionEstado")
            GVConyugue.DataBind()

            Session("TablaConyugue") = TablaConyugue
            Session("VistaConyugue") = VistaConyugue

            '=============================================================================================================


            Nuevo()
            MultiView1.SetActiveView(View1)
        Else
            TablaIdentificacion = Session("TablaIdentificacion")
            VistaIdentificacion = Session("VistaIdentificacion")
            TablaContacto = Session("TablaContacto")
            VistaContacto = Session("VistaContacto")
            TablaDomicilio = Session("TablaDomicilio")
            VistaDomicilio = Session("VistaDomicilio")
            TablaEmpleo = Session("TablaEmpleo")
            VistaEmpleo = Session("VistaEmpleo")
            TablaReferencia = Session("TablaReferencia")
            VistaReferencia = Session("VistaReferencia")
            TablaLineaCredito = Session("TablaLineaCredito")
            VistaLineaCredito = Session("VistaLineaCredito")
            TablaIndicador = Session("TablaIndicador")
            VistaIndicador = Session("VistaIndicador")
            TablaConyugue = Session("TablaConyugue")
            VistaConyugue = Session("VistaConyugue")
        End If
    End Sub

    Public Sub Nuevo()
        TBIdPersona.Text = ""
        TBEquivalencia.Text = ""
        DDTipoPersona.SelectedIndex = 0
        TBRazonSocial.Text = ""
        TBNombre.Text = ""
        TBSegundoNombre.Text = ""
        TBAPaterno.Text = ""
        TBAMaterno.Text = ""
        TBFecha.Text = ""
        DDGenero.SelectedIndex = 0
        DDEstadoCivil.SelectedIndex = 0
        TBObservaciones.Text = ""
        DDEstado.SelectedIndex = 0
        wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False
        '----------------Identificacion----------------
        DDTipoIdentificacion.SelectedIndex = 0
        TBNumIdentificacion.Text = ""
        PAIdentificacion.Visible = False
        '----------------Contacto----------------
        DDTipoMedio.SelectedIndex = 0
        TBValorMedio.Text = ""
        '----------------Domicilio----------------
        DDTipoDomicilio.SelectedIndex = 0
        TBCalle.Text = ""
        TBDomNumExterior.Text = ""
        TBDomNumInterior.Text = ""
        TBDomTelefono.Text = ""
        TBDomAntiguedad.Text = ""
        TBDomPropietario.Text = ""
        TBDomCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedIndex = 0
        DDDomMunicipio.SelectedIndex = 0
        'DDDomLocalidad.SelectedIndex = 0
        '----------------Empleo--------------------
        DDTipoEmpleos.SelectedIndex = 0
        TBEmpOcupacion.Text = ""
        TBEmpEmpresa.Text = ""
        TBEmpAntiguedad.Text = ""
        TBEmpDomicilio.Text = ""
        TBEmpTelefono.Text = ""
        '----------------Referencia----------------
        TBIdPersonaEmpleo.Text = 0
        DDTipoEmpleos.SelectedIndex = 0
        TBEmpOcupacion.Text = ""
        TBEmpEmpresa.Text = ""
        TBEmpAntiguedad.Text = ""
        TBEmpDomicilio.Text = ""
        TBEmpTelefono.Text = ""
        '----------------Linea de Credito----------------
        TBFechaLineaCredito.Text = ""
        TBLineaCredito.Text = ""
        TBMontoLineaCredito.Text = ""
        '----------------Indicadores----------------
        DDTipoIndicador.SelectedIndex = 0
        TBMontoIndicador.Text = ""
        TBIdPersona.Text = ""
        '----------------------limpiar Conyugue--------------------
        TBIdPersonaConyugue.Text = ""
        TBIdPerConyugue.Text = ""
        TBPriNomConyugue.Text = ""
        TBSegNomConyugue.Text = ""
        TBApePatConyugue.Text = ""
        TBApeMatConyugue.Text = ""
        TBFechaConyugue.Text = ""
        DDGeneroConyugue.SelectedIndex = 0
        DDEstCivConyugue.SelectedIndex = 0
        DDEstadoConyugue.SelectedIndex = 0
        '----------------Para limpiar los Gridview ----------------
        LimpiarTablas()
    End Sub
    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle
        TablaIdentificacion.Rows.Clear()
        VistaIdentificacion.Table.Rows.Clear()
        GVIdentificacion.DataBind()
        Session("TablaIdentificacion") = TablaIdentificacion
        Session("VistaIdentificacion") = VistaIdentificacion
        ControlesIdentificacion(False)

        TablaContacto.Rows.Clear()
        VistaContacto.Table.Rows.Clear()
        GVMedio.DataBind()
        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        ControlesContacto(False)

        TablaDomicilio.Rows.Clear()
        VistaDomicilio.Table.Rows.Clear()
        GVDomicilio.DataBind()
        Session("TablaDomicilio") = TablaDomicilio
        Session("VistaDomicilio") = VistaDomicilio

        TablaEmpleo.Rows.Clear()
        VistaEmpleo.Table.Rows.Clear()
        GVEmpleo.DataBind()
        Session("TablaEmpleo") = TablaEmpleo
        Session("VistaEmpleo") = VistaEmpleo

        TablaReferencia.Rows.Clear()
        VistaReferencia.Table.Rows.Clear()
        GVReferencia.DataBind()
        Session("TablaReferencia") = TablaReferencia
        Session("VistaReferencia") = VistaReferencia

        TablaLineaCredito.Rows.Clear()
        VistaLineaCredito.Table.Rows.Clear()
        GVLineaCredito.DataBind()
        Session("TablaLineaCredito") = TablaLineaCredito
        Session("VistaLineaCredito") = VistaLineaCredito

        TablaIndicador.Rows.Clear()
        VistaIndicador.Table.Rows.Clear()
        GVIndicador.DataBind()
        Session("TablaIndicador") = TablaIndicador
        Session("VistaIndicador") = VistaIndicador

        TablaConyugue.Rows.Clear()
        VistaConyugue.Table.Rows.Clear()
        GVConyugue.DataBind()
        Session("TablaConyugue") = TablaConyugue
        Session("VistaConyugue") = VistaConyugue
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        If TBIdPersona.Text Is String.Empty Then
            EntidadPersona.IdPersona = 0
        Else
            EntidadPersona.IdPersona = CInt(TBIdPersona.Text)
        End If
        EntidadPersona.Equivalencia = TBEquivalencia.Text
        EntidadPersona.IdTipoPersona = DDTipoPersona.SelectedValue
        EntidadPersona.RazonSocial = TBRazonSocial.Text
        EntidadPersona.PrimerNombre = TBNombre.Text
        EntidadPersona.SegundoNombre = TBSegundoNombre.Text
        EntidadPersona.ApellidoPaterno = TBAPaterno.Text
        EntidadPersona.ApellidoMaterno = TBAMaterno.Text
        If TBFecha.Text Is String.Empty Then
            EntidadPersona.FechaNacimiento = "01/01/1990"
        Else
            EntidadPersona.FechaNacimiento = TBFecha.Text
        End If
        EntidadPersona.IdTipoGenero = DDGenero.SelectedValue
        EntidadPersona.IdTipoEstadoCivil = DDEstadoCivil.SelectedValue
        EntidadPersona.IdEstado = DDEstado.SelectedValue
        EntidadPersona.Observaciones = TBObservaciones.Text
        EntidadPersona.TablaIdentificacion = TablaIdentificacion
        EntidadPersona.TablaContacto = TablaContacto
        EntidadPersona.TablaDomicilio = TablaDomicilio
        EntidadPersona.TablaEmpleo = TablaEmpleo
        EntidadPersona.TablaReferencia = TablaReferencia
        EntidadPersona.TablaLineaCredito = TablaLineaCredito
        EntidadPersona.TablaIndicador = TablaIndicador
        EntidadPersona.TablaConyugue = TablaConyugue
        NegocioPersona.Guardar(EntidadPersona)
        TBIdPersona.Text = EntidadPersona.IdPersona
        Nuevo()
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPersona.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim TablaDetalle As New DataTable
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        Tabla = Session("Tabla")
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadPersona.IdPersona = Tabla.Rows(GVPersona.SelectedIndex).Item("Id")
        NegocioPersona.Consultar(EntidadPersona)
        TablaDetalle = EntidadPersona.TablaConsulta



        TBIdPersona.Text = TablaDetalle.Rows(0).Item("ID Cliente")

        TBEquivalencia.Text = TablaDetalle.Rows(0).Item("Equivalencia")
        DDTipoPersona.SelectedValue = TablaDetalle.Rows(0).Item("Tipo Persona")
        TBRazonSocial.Text = TablaDetalle.Rows(0).Item("Razon Social")
        TBNombre.Text = TablaDetalle.Rows(0).Item("Nombre")
        TBSegundoNombre.Text = TablaDetalle.Rows(0).Item("Segundo Nombre")
        TBAPaterno.Text = TablaDetalle.Rows(0).Item("Apellido Paterno")
        TBAMaterno.Text = TablaDetalle.Rows(0).Item("Apellido Materno")
        TBFecha.Text = TablaDetalle.Rows(0).Item("Fecha Nacimineto")
        DDGenero.SelectedValue = TablaDetalle.Rows(0).Item("Genero")
        DDEstadoCivil.SelectedValue = TablaDetalle.Rows(0).Item("Estado Civli")
        TBObservaciones.Text = TablaDetalle.Rows(0).Item("Observaciones")
        DDEstado.SelectedValue = TablaDetalle.Rows(0).Item("Estado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(TablaDetalle.Rows(0))
        '=======================================Identificacion=========================================
        Dim TablaIdentificacion As New DataTable()
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadPersona.IdPersona = TBIdPersona.Text
        NegocioPersona.Obtener(EntidadPersona)

        TablaIdentificacion = EntidadPersona.TablaIdentificacion
        VistaIdentificacion = TablaIdentificacion.DefaultView
        VistaIdentificacion.RowFilter = "idEstado=1"

        Session("TablaIdentificacion") = TablaIdentificacion
        Session("VistaIdentificacion") = VistaIdentificacion
        GVIdentificacion.DataSource = VistaIdentificacion
        GVIdentificacion.DataBind()

        ControlesIdentificacion(False)
        '=======================================Conyugue=========================================
        Dim TablaConyugue As New DataTable()

        TablaConyugue = EntidadPersona.TablaConyugue
        VistaConyugue = TablaConyugue.DefaultView
        VistaConyugue.RowFilter = "idEstado=1"
        If TablaConyugue.Rows.Count > 0 Then
            AccordionPane0.Visible = True
        End If
        Session("TablaConyugue") = TablaConyugue
        Session("VistaConyugue") = VistaConyugue
        GVConyugue.DataSource = VistaConyugue
        GVConyugue.DataBind()

        PAConyugue.Visible = False
        GVConyugue.Visible = True
        '========================================Contacto============================================
        Dim TablaContacto As New DataTable()

        TablaContacto = EntidadPersona.TablaContacto
        VistaContacto = TablaContacto.DefaultView
        VistaContacto.RowFilter = "idEstado=1"

        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        GVMedio.DataSource = VistaContacto
        GVMedio.DataBind()

        ControlesContacto(False)
        '========================================Domicilio============================================
        Dim TablaDomicilio As New DataTable()

        TablaDomicilio = EntidadPersona.TablaDomicilio
        VistaDomicilio = TablaDomicilio.DefaultView
        VistaDomicilio.RowFilter = "idEstado=1"

        Session("TablaDomicilio") = TablaDomicilio
        Session("VistaDomicilio") = VistaDomicilio
        GVDomicilio.DataSource = VistaDomicilio
        GVDomicilio.DataBind()

        PanelDomicilio.Visible = False
        GVDomicilio.Visible = True
        '========================================Empleo============================================
        Dim TablaEmpleo As New DataTable()

        TablaEmpleo = EntidadPersona.TablaEmpleo
        VistaEmpleo = TablaEmpleo.DefaultView
        VistaEmpleo.RowFilter = "idEstado=1"

        Session("TablaEmpleo") = TablaEmpleo
        Session("VistaEmpleo") = VistaEmpleo
        GVEmpleo.DataSource = VistaEmpleo
        GVEmpleo.DataBind()

        PanelEmpleo.Visible = False
        GVEmpleo.Visible = True
        '========================================Referencia============================================
        Dim TablaReferencia As New DataTable()

        TablaReferencia = EntidadPersona.TablaReferencia
        VistaReferencia = TablaReferencia.DefaultView
        VistaReferencia.RowFilter = "idEstado=1"

        Session("TablaReferencia") = TablaReferencia
        Session("VistaReferencia") = VistaReferencia
        GVReferencia.DataSource = VistaReferencia
        GVReferencia.DataBind()

        PanelReferencia.Visible = False
        GVReferencia.Visible = True
        '========================================Linea Credito============================================
        Dim TablaLineaCredito As New DataTable()

        TablaLineaCredito = EntidadPersona.TablaLineaCredito
        VistaLineaCredito = TablaLineaCredito.DefaultView
        VistaLineaCredito.RowFilter = "idEstado=1"

        Session("TablaLineaCredito") = TablaLineaCredito
        Session("VistaLineaCredito") = VistaLineaCredito
        GVLineaCredito.DataSource = VistaLineaCredito
        GVLineaCredito.DataBind()

        PanelReferencia.Visible = False
        GVReferencia.Visible = True
        '========================================Indicador============================================
        Dim TablaIndicador As New DataTable()

        TablaIndicador = EntidadPersona.TablaIndicador
        VistaIndicador = TablaIndicador.DefaultView
        VistaIndicador.RowFilter = "idEstado=1"

        Session("TablaIndicador") = TablaIndicador
        Session("VistaIndicador") = VistaIndicador
        GVIndicador.DataSource = VistaIndicador
        GVIndicador.DataBind()

        PanelIndicadores.Visible = False
        GVIndicador.Visible = True

        MultiView1.SetActiveView(View1)
    End Sub
#Region "LOL"
#Region "Identificacion================================================================================"
    Protected Sub BTNuevaIdentificacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNuevaIdentificacion.Click
        TBIdIdentificacion.Text = 0
        DDTipoIdentificacion.SelectedIndex = 0
        TBNumIdentificacion.Text = ""

        ControlesIdentificacion(True)
    End Sub
    Protected Sub BTNCancelarIdentificacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNCancelarIdentificacion.Click
        DDTipoIdentificacion.SelectedIndex = 0
        TBNumIdentificacion.Text = ""
        ControlesIdentificacion(False)
    End Sub
    Protected Sub GVIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVIdentificacion.SelectedIndexChanged
        PAIdentificacion.Visible = True
        TBIdIdentificacion.Visible = False
        Dim TablaIdentificacion As New DataTable
        TablaIdentificacion = Session("TablaIdentificacion")
        TBIdIdentificacion.Text = TablaIdentificacion.Rows(GVIdentificacion.SelectedIndex).Item("IdPersonaIdentificacion")
        DDTipoIdentificacion.SelectedValue = TablaIdentificacion.Rows(GVIdentificacion.SelectedIndex).Item("IdTipoIdentificacion")
        TBNumIdentificacion.Text = TablaIdentificacion.Rows(GVIdentificacion.SelectedIndex).Item("ClaveIdentificacion")

        ControlesIdentificacion(True)
    End Sub


    Protected Sub BTNAceptarIdentificacion_Click(sender As Object, e As EventArgs) Handles BTNAceptarIdentificacion.Click
        TablaIdentificacion = Session("TablaIdentificacion")
        VistaIdentificacion = Session("VistaIdentificacion")

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaIdentificacion.Rows
            If fila.Item("IdTipoIdentificacion").ToString() = DDTipoIdentificacion.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaIdentificacion.NewRow()
            RenglonAInsertar("IdPersonaIdentificacion") = Int32.Parse(TBIdIdentificacion.Text)
            RenglonAInsertar("IdTipoIdentificacion") = DDTipoIdentificacion.SelectedValue
            RenglonAInsertar("ClaveIdentificacion") = TBNumIdentificacion.Text.ToUpper()
            RenglonAInsertar("TipoIdentificacion") = DDTipoIdentificacion.SelectedItem.Text
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaIdentificacion.Rows.Add(RenglonAInsertar)

            Session("TablaIdentificacion") = TablaIdentificacion
            Session("VistaIdentificacion") = VistaIdentificacion
            GVIdentificacion.DataSource = VistaIdentificacion
            GVIdentificacion.DataBind()

            'limpiar Identificacion
            ControlesIdentificacion(False)
            DDTipoIdentificacion.SelectedIndex = 0
            TBIdIdentificacion.Text = 0
            TBNumIdentificacion.Text = ""

        End If
    End Sub

    Protected Sub BTNActualizarIdentificacion_Click(sender As Object, e As EventArgs) Handles BTNActualizarIdentificacion.Click
        TablaIdentificacion = Session("TablaIdentificacion")
        VistaIdentificacion = Session("VistaIdentificacion")

        'actualizar renglon
        Dim Renglon As Integer = GVIdentificacion.SelectedIndex
        VistaIdentificacion(Renglon).Item("IdPersonaIdentificacion") = Int32.Parse(TBIdIdentificacion.Text)
        VistaIdentificacion(Renglon).Item("IdTipoIdentificacion") = DDTipoIdentificacion.SelectedValue
        VistaIdentificacion(Renglon).Item("ClaveIdentificacion") = TBNumIdentificacion.Text.ToUpper()
        VistaIdentificacion(Renglon).Item("TipoIdentificacion") = DDTipoIdentificacion.SelectedItem.Text
        VistaIdentificacion(Renglon).Item("IdUsuarioCreacion") = 1
        VistaIdentificacion(Renglon).Item("FechaCreacion") = Now
        VistaIdentificacion(Renglon).Item("IdUsuarioActualizacion") = 1
        VistaIdentificacion(Renglon).Item("FechaActualizacion") = Now
        VistaIdentificacion(Renglon).Item("idEstado") = 1
        VistaIdentificacion(Renglon).Item("idActualizar") = 1

        Session("TablaIdentificacion") = TablaIdentificacion
        Session("VistaIdentificacion") = VistaIdentificacion
        GVIdentificacion.DataSource = VistaIdentificacion
        GVIdentificacion.DataBind()

        ControlesIdentificacion(False)
        'limpiar controles 
        'PAIdentificacion.Visible = False
        'TBIdIdentificacion.Text = 0
        'TBNumeroIdentificacion.Text = ""
        'BTAceptarIdentificacion.Visible = False
        'BTCancelarIdentificacion.Visible = False
        'BTActualizarIdentificacion.Visible = False
        'BTEliminarIdentificacion.Visible = False
        'BTNuevaIdentificacion.Visible = True
    End Sub

    Protected Sub BTNEliminarIdentificacion_Click(sender As Object, e As EventArgs) Handles BTNEliminarIdentificacion.Click
        TablaIdentificacion = Session("TablaIdentificacion")
        VistaIdentificacion = Session("VistaIdentificacion")

        'actualizar renglon
        Dim Renglon As Integer = GVIdentificacion.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaIdentificacion(Renglon).Item("IdPersonaIdentificacion") = 0 Then
            VistaIdentificacion(Renglon).Delete()
        Else
            VistaIdentificacion(Renglon).Item("idActualizar") = 1 'Si   
            VistaIdentificacion(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaIdentificacion") = TablaIdentificacion
        Session("VistaIdentificacion") = VistaIdentificacion
        GVIdentificacion.DataSource = VistaIdentificacion
        GVIdentificacion.DataBind()


        ControlesIdentificacion(False)
        'limpiar controles 
        'PAIdentificacion.Visible = False
        'TBIdIdentificacion.Text = 0
        'TBNumeroIdentificacion.Text = ""
        'BTAceptarIdentificacion.Visible = False
        'BTCancelarIdentificacion.Visible = False
        'BTActualizarIdentificacion.Visible = False
        'BTEliminarIdentificacion.Visible = False
        'BTNuevaIdentificacion.Visible = True
    End Sub
    Private Sub ControlesIdentificacion(control As Boolean)
        If control Then
            PAIdentificacion.Visible = True
            GVIdentificacion.Visible = False
        Else
            PAIdentificacion.Visible = False
            GVIdentificacion.Visible = True
        End If
    End Sub
#End Region

#Region "Contacto========================================================================="
    Protected Sub BTNMedio_Click(sender As Object, e As EventArgs) Handles BTNMedio.Click
        TBIdMedio.Text = 0
        TBIdMedio.Visible = False
        DDTipoMedio.SelectedIndex = 0
        ControlesContacto(True)
    End Sub

    Protected Sub BTNCancelarMedio_Click(sender As Object, e As EventArgs) Handles BTNCancelarMedio.Click
        TBIdMedio.Text = ""
        DDTipoMedio.SelectedIndex = 0
        TBValorMedio.Text = ""
        ControlesContacto(False)
    End Sub

    Protected Sub BTNAceptarMedio_Click(sender As Object, e As EventArgs) Handles BTNAceptarMedio.Click
        TablaContacto = Session("TablaContacto")
        VistaContacto = Session("VistaContacto")
        Dim EntidadPersona As New Entidad.Persona()

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaContacto.Rows
            If fila.Item("IdTipoMedio").ToString() = DDTipoMedio.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaContacto.NewRow()
            RenglonAInsertar("IdPersonaMedio") = Int32.Parse(TBIdMedio.Text)
            RenglonAInsertar("IdTipoMedio") = DDTipoMedio.SelectedValue
            RenglonAInsertar("Contacto") = TBValorMedio.Text.ToUpper()
            RenglonAInsertar("TipoContacto") = DDTipoMedio.SelectedItem.Text
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaContacto.Rows.Add(RenglonAInsertar)

            Session("TablaContacto") = TablaContacto
            Session("VistaContacto") = VistaContacto
            GVMedio.DataSource = VistaContacto
            GVMedio.DataBind()

            'limpiar Identificacion

            DDTipoMedio.SelectedIndex = 0
            TBIdMedio.Text = ""
            TBValorMedio.Text = ""
            ControlesContacto(False)
        End If
    End Sub
    Protected Sub GVMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVMedio.SelectedIndexChanged
        PanelMedio.Visible = True
        Dim TablaContacto As New DataTable
        TablaContacto = Session("TablaContacto")
        TBIdMedio.Text = TablaContacto.Rows(GVMedio.SelectedIndex).Item("IdPersonaMedio")
        DDTipoMedio.SelectedValue = TablaContacto.Rows(GVMedio.SelectedIndex).Item("IdTipomedio")
        TBValorMedio.Text = TablaContacto.Rows(GVMedio.SelectedIndex).Item("Contacto")
        ControlesContacto(True)
    End Sub

    Protected Sub BTNActualizarMedio_Click(sender As Object, e As EventArgs) Handles BTNActualizarMedio.Click
        TablaContacto = Session("TablaContacto")
        VistaContacto = Session("VistaContacto")

        'actualizar renglon
        Dim Renglon As Integer = GVMedio.SelectedIndex
        VistaContacto(Renglon).Item("IdPersonaMedio") = Int32.Parse(TBIdMedio.Text)
        VistaContacto(Renglon).Item("IdTipoMedio") = DDTipoMedio.SelectedValue
        VistaContacto(Renglon).Item("Contacto") = TBValorMedio.Text.ToUpper()
        VistaContacto(Renglon).Item("TipoContacto") = DDTipoMedio.SelectedItem.Text
        VistaContacto(Renglon).Item("IdUsuarioCreacion") = 1
        VistaContacto(Renglon).Item("FechaCreacion") = Now
        VistaContacto(Renglon).Item("IdUsuarioActualizacion") = 1
        VistaContacto(Renglon).Item("FechaActualizacion") = Now
        VistaContacto(Renglon).Item("idEstado") = 1
        VistaContacto(Renglon).Item("idActualizar") = 1

        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        GVMedio.DataSource = VistaContacto
        GVMedio.DataBind()

        ControlesContacto(False)
        'limpiar controles 
        'PAIdentificacion.Visible = False
        'TBIdIdentificacion.Text = 0
        'TBNumeroIdentificacion.Text = ""
        'BTAceptarIdentificacion.Visible = False
        'BTCancelarIdentificacion.Visible = False
        'BTActualizarIdentificacion.Visible = False
        'BTEliminarIdentificacion.Visible = False
        'BTNuevaIdentificacion.Visible = True
    End Sub

    Protected Sub BTNEliminarMedio_Click(sender As Object, e As EventArgs) Handles BTNEliminarMedio.Click
        TablaContacto = Session("TablaContacto")
        VistaContacto = Session("VistaContacto")

        'actualizar renglon
        Dim Renglon As Integer = GVMedio.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaContacto(Renglon).Item("IdPersonaMedio") = 0 Then
            VistaContacto(Renglon).Delete()
        Else
            VistaContacto(Renglon).Item("idActualizar") = 1 'Si   
            VistaContacto(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        GVMedio.DataSource = VistaContacto
        GVMedio.DataBind()

        ControlesContacto(False)
        'limpiar controles 
        'PAIdentificacion.Visible = False
        'TBIdIdentificacion.Text = 0
        'TBNumeroIdentificacion.Text = ""
        'BTAceptarIdentificacion.Visible = False
        'BTCancelarIdentificacion.Visible = False
        'BTActualizarIdentificacion.Visible = False
        'BTEliminarIdentificacion.Visible = False
        'BTNuevaIdentificacion.Visible = True
    End Sub
    Private Sub ControlesContacto(control As Boolean)
        If control Then
            PanelMedio.Visible = True
            GVMedio.Visible = False
        Else
            PanelMedio.Visible = False
            GVMedio.Visible = True
        End If
    End Sub
#End Region

#Region "Domicilio==============================================================="
    Protected Sub BTNDomicilio_Click(sender As Object, e As EventArgs) Handles BTNDomicilio.Click
        TBIdDomicilio.Text = 0
        DDTipoDomicilio.SelectedIndex = 0
        TBCalle.Text = ""
        TBDomNumExterior.Text = ""
        TBDomNumInterior.Text = ""
        TBDomTelefono.Text = ""
        TBDomAntiguedad.Text = ""
        TBDomPropietario.Text = ""
        TBDomCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedValue = 8
        DDDomMunicipio.SelectedIndex = 20
        'DDDomLocalidad.SelectedIndex = 0
        DDDomColonia.SelectedIndex = 0
        TBIdDomicilio.Visible = False
        ControlesDomicilio(True)
    End Sub
    Protected Sub BTNAceptarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNAceptarDomicilio.Click
        TablaDomicilio = Session("TablaDomicilio")
        VistaDomicilio = Session("VistaDomicilio")
        Dim EntidadPersona As New Entidad.Persona()

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaDomicilio.Rows
            If fila.Item("IdTipoDomicilio").ToString() = DDTipoDomicilio.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If

        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaDomicilio.NewRow()
            RenglonAInsertar("IdPersonaDomicilio") = TBIdDomicilio.Text
            RenglonAInsertar("IdTipoDomicilio") = DDTipoDomicilio.SelectedValue
            RenglonAInsertar("Calle") = TBCalle.Text
            RenglonAInsertar("Telefono") = TBDomTelefono.Text
            RenglonAInsertar("Propietario") = TBDomPropietario.Text
            RenglonAInsertar("Antiguedad") = TBDomAntiguedad.Text
            'tipoantiguedad
            If RBAnos.Checked = True Then
                TipoAntiguedad = 1
            End If
            If RBMeses.Checked = True Then
                TipoAntiguedad = 2
            End If
            If RBDias.Checked = True Then
                TipoAntiguedad = 3
            End If
            RenglonAInsertar("TipoAntiguedad") = TipoAntiguedad
            'tipoantiguedad
            RenglonAInsertar("Pais") = DDPais.SelectedValue
            RenglonAInsertar("Estado") = DDEstado.SelectedValue
            RenglonAInsertar("Municipio") = DDDomMunicipio.SelectedValue
            RenglonAInsertar("Localidad") = 1 'DDDomLocalidad.SelectedValue
            RenglonAInsertar("Colonia") = DDDomColonia.SelectedValue
            RenglonAInsertar("NumeroInterior") = TBDomNumExterior.Text
            RenglonAInsertar("NumeroExterior") = TBDomNumInterior.Text
            RenglonAInsertar("CP") = TBDomCodigoPostal.Text
            RenglonAInsertar("TipoDomicilio") = DDTipoDomicilio.SelectedItem.Text
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaDomicilio.Rows.Add(RenglonAInsertar)

            Session("TablaDomicilio") = TablaDomicilio
            Session("VistaDomicilio") = VistaDomicilio
            GVDomicilio.DataSource = VistaDomicilio
            GVDomicilio.DataBind()

            'limpiar Identificacion
            DDTipoDomicilio.SelectedIndex = 0
            TBIdDomicilio.Text = ""
            TBCalle.Text = ""
            TBDomNumExterior.Text = ""
            TBDomNumInterior.Text = ""
            TBDomTelefono.Text = ""
            TBDomAntiguedad.Text = ""
            TBDomPropietario.Text = ""
            TBDomCodigoPostal.Text = ""
            DDPais.SelectedIndex = 0
            DDEntidadFederativa.SelectedIndex = 0
            DDDomMunicipio.SelectedIndex = 0
            'DDDomLocalidad.SelectedIndex = 0
            DDDomColonia.SelectedIndex = 0
            ControlesDomicilio(False)
        End If
    End Sub
    Protected Sub BTNActualizarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNActualizarDomicilio.Click
        TablaDomicilio = Session("TablaDomicilio")
        VistaDomicilio = Session("VistaDomicilio")

        Dim Renglon As Integer = GVDomicilio.SelectedIndex
        VistaDomicilio(Renglon).Item("IdPersonaDomicilio") = TBIdDomicilio.Text
        VistaDomicilio(Renglon).Item("IdTipoDomicilio") = DDTipoDomicilio.SelectedValue
        VistaDomicilio(Renglon).Item("Calle") = TBCalle.Text
        VistaDomicilio(Renglon).Item("NumeroExterior") = TBDomNumExterior.Text
        VistaDomicilio(Renglon).Item("NumeroInterior") = TBDomNumInterior.Text
        VistaDomicilio(Renglon).Item("Telefono") = TBDomTelefono.Text
        VistaDomicilio(Renglon).Item("Antiguedad") = TBDomAntiguedad.Text
        If RBAnos.Checked = True Then
            TipoAntiguedad = 1
        End If
        If RBMeses.Checked = True Then
            TipoAntiguedad = 2
        End If
        If RBDias.Checked = True Then
            TipoAntiguedad = 3
        End If
        VistaDomicilio(Renglon).Item("TipoAntiguedad") = TipoAntiguedad
        VistaDomicilio(Renglon).Item("Propietario") = TBDomPropietario.Text
        VistaDomicilio(Renglon).Item("CP") = TBDomCodigoPostal.Text
        VistaDomicilio(Renglon).Item("Pais") = DDPais.SelectedValue
        VistaDomicilio(Renglon).Item("Estado") = DDEntidadFederativa.SelectedValue
        VistaDomicilio(Renglon).Item("Municipio") = DDDomMunicipio.SelectedValue
        VistaDomicilio(Renglon).Item("Localidad") = 1 'DDDomLocalidad.SelectedValue
        VistaDomicilio(Renglon).Item("Colonia") = DDDomColonia.SelectedValue
        VistaDomicilio(Renglon).Item("IdEstado") = 1
        VistaDomicilio(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaDomicilio") = TablaDomicilio
        Session("VistaDomicilio") = VistaDomicilio
        GVDomicilio.DataSource = VistaDomicilio
        GVDomicilio.DataBind()

        'limpiar controles 
        TBIdDomicilio.Text = 0
        DDTipoDomicilio.SelectedIndex = 0
        TBCalle.Text = ""
        TBDomNumExterior.Text = ""
        TBDomNumInterior.Text = ""
        TBDomTelefono.Text = ""
        TBDomAntiguedad.Text = ""
        TBDomPropietario.Text = ""
        TBDomCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedIndex = 0

        DDDomMunicipio.SelectedIndex = 20


        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadColonia.IdMunColonia = DDDomMunicipio.SelectedValue
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "ID"
        DDDomColonia.DataTextField = "Descripcion"
        DDDomColonia.DataBind()


        TBIdDomicilio.Visible = False
        ControlesDomicilio(False)

    End Sub
    Protected Sub GVDomicilio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDomicilio.SelectedIndexChanged
        PanelDomicilio.Visible = True

        TablaDomicilio = Session("TablaDomicilio")
        VistaDomicilio = Session("VistaDomicilio")

        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "IdColonia"
        DDDomColonia.DataTextField = "DesColonia"
        DDDomColonia.DataBind()
        'DDDomLocalidad.SelectedIndex = 0
        DDDomColonia.SelectedIndex = 0
        Dim Renglon As Integer = GVDomicilio.SelectedIndex

        TBIdDomicilio.Text = VistaDomicilio(Renglon).Item("IdPersonaDomicilio")
        DDTipoDomicilio.SelectedValue = VistaDomicilio(Renglon).Item("IdTipoDomicilio")
        TBCalle.Text = VistaDomicilio(Renglon).Item("Calle")
        TBDomNumExterior.Text = VistaDomicilio(Renglon).Item("NumeroExterior")
        TBDomNumInterior.Text = VistaDomicilio(Renglon).Item("NumeroInterior")
        TBDomTelefono.Text = VistaDomicilio(Renglon).Item("Telefono")
        TBDomAntiguedad.Text = VistaDomicilio(Renglon).Item("Antiguedad")
        'Antiguedad-----------
        If VistaDomicilio(Renglon).Item("TipoAntiguedad") = 1 Then
            RBAnos.Checked = True
            RBMeses.Checked = False
            RBDias.Checked = False
        End If
        If VistaDomicilio(Renglon).Item("TipoAntiguedad") = 2 Then
            RBAnos.Checked = False
            RBMeses.Checked = True
            RBDias.Checked = False
        End If
        If VistaDomicilio(Renglon).Item("TipoAntiguedad") = 3 Then
            RBAnos.Checked = False
            RBMeses.Checked = False
            RBDias.Checked = True
        End If


        TBDomPropietario.Text = VistaDomicilio(Renglon).Item("Propietario")
        TBDomCodigoPostal.Text = VistaDomicilio(Renglon).Item("CP")
        DDPais.SelectedValue = VistaDomicilio(Renglon).Item("Pais")
        DDEntidadFederativa.SelectedValue = VistaDomicilio(Renglon).Item("Estado")
        DDDomMunicipio.SelectedValue = VistaDomicilio(Renglon).Item("Municipio")
        'DDDomLocalidad.SelectedValue = VistaDomicilio(Renglon).Item("Localidad")
        DDDomColonia.SelectedValue = VistaDomicilio(Renglon).Item("Colonia")

        ControlesDomicilio(True)
        TBIdDomicilio.Visible = False
    End Sub
    Protected Sub BTNEliminarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNEliminarDomicilio.Click
        TablaDomicilio = Session("TablaDomicilio")
        VistaDomicilio = Session("VistaDomicilio")

        'actualizar renglon
        Dim Renglon As Integer = GVDomicilio.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaDomicilio(Renglon).Item("IdPersonaDomicilio") = 0 Then
            VistaDomicilio(Renglon).Delete()
        Else
            VistaDomicilio(Renglon).Item("idActualizar") = 1 'Si   
            VistaDomicilio(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaDomicilio") = TablaDomicilio
        Session("VistaDomicilio") = VistaDomicilio
        GVDomicilio.DataSource = VistaDomicilio
        GVDomicilio.DataBind()

        ControlesDomicilio(False)
    End Sub
    Protected Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNCancelar.Click
        TBIdDomicilio.Text = 0
        DDTipoDomicilio.SelectedIndex = 0
        TBCalle.Text = ""
        TBDomNumExterior.Text = ""
        TBDomNumInterior.Text = ""
        TBDomTelefono.Text = ""
        TBDomAntiguedad.Text = ""
        TBDomPropietario.Text = ""
        TBDomCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedIndex = 0
        DDDomMunicipio.SelectedIndex = 0
        'DDDomLocalidad.SelectedIndex = 0
        DDDomColonia.SelectedIndex = 0
        TBIdDomicilio.Visible = False
        ControlesDomicilio(False)
    End Sub
    Private Sub ControlesDomicilio(control As Boolean)
        If control Then
            PanelDomicilio.Visible = True
            GVDomicilio.Visible = False
        Else
            PanelDomicilio.Visible = False
            GVDomicilio.Visible = True
        End If
    End Sub
#End Region

#Region "Empleo================================================================"
    Protected Sub BTNEmpleo_Click(sender As Object, e As EventArgs) Handles BTNEmpleo.Click
        TBIdPersonaEmpleo.Text = 0
        DDTipoEmpleos.SelectedIndex = 0
        TBEmpOcupacion.Text = ""
        TBEmpEmpresa.Text = ""
        TBEmpAntiguedad.Text = ""
        TBEmpDomicilio.Text = ""
        TBEmpTelefono.Text = ""

        ControlesEmpleo(True)
    End Sub
    Protected Sub BTNAceptarEmpleo_Click(sender As Object, e As EventArgs) Handles BTNAceptarEmpleo.Click
        TablaEmpleo = Session("TablaEmpleo")
        VistaEmpleo = Session("VistaEmpleo")
        Dim EntidadPersona As New Entidad.Persona()

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaEmpleo.Rows
            If fila.Item("IdTipoEmpleo").ToString() = DDTipoEmpleos.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaEmpleo.NewRow()
            RenglonAInsertar("IdPersonaEmpleo") = Int32.Parse(TBIdPersonaEmpleo.Text)
            RenglonAInsertar("IdTipoEmpleo") = DDTipoEmpleos.SelectedValue
            RenglonAInsertar("Ocupacion") = TBEmpOcupacion.Text.ToUpper()
            RenglonAInsertar("Empresa") = TBEmpEmpresa.Text.ToUpper()
            RenglonAInsertar("Antiguedad") = Int32.Parse(TBEmpAntiguedad.Text)
            RenglonAInsertar("Domicilio") = TBEmpDomicilio.Text
            RenglonAInsertar("Telefono") = TBEmpTelefono.Text
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaEmpleo.Rows.Add(RenglonAInsertar)

            Session("TablaEmpleo") = TablaEmpleo
            Session("VistaEmpleo") = VistaEmpleo
            GVEmpleo.DataSource = VistaEmpleo
            GVEmpleo.DataBind()

            'limpiar Identificacion
            TBIdPersonaEmpleo.Text = ""
            DDTipoEmpleos.SelectedIndex = 0
            TBEmpOcupacion.Text = ""
            TBEmpEmpresa.Text = ""
            TBEmpAntiguedad.Text = ""
            TBEmpDomicilio.Text = ""
            TBEmpTelefono.Text = ""
            ControlesEmpleo(False)
        End If

    End Sub
    Protected Sub GVEmpleo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEmpleo.SelectedIndexChanged
        PanelEmpleo.Visible = True

        TablaEmpleo = Session("TablaEmpleo")
        VistaEmpleo = Session("VistaEmpleo")

        Dim Renglon As Integer = GVEmpleo.SelectedIndex

        TBIdPersonaEmpleo.Text = VistaEmpleo(Renglon).Item("IdPersonaEmpleo")
        DDTipoEmpleos.SelectedValue = VistaEmpleo(Renglon).Item("IdTipoEmpleo")
        TBEmpOcupacion.Text = VistaEmpleo(Renglon).Item("Ocupacion")
        TBEmpEmpresa.Text = VistaEmpleo(Renglon).Item("Empresa")
        TBEmpAntiguedad.Text = VistaEmpleo(Renglon).Item("Antiguedad")
        TBEmpDomicilio.Text = VistaEmpleo(Renglon).Item("Domicilio")
        TBEmpTelefono.Text = VistaEmpleo(Renglon).Item("Telefono")
        TBIdDomicilio.Visible = False

        ControlesEmpleo(True)
    End Sub
    Protected Sub BTNActualizarEmpleo_Click(sender As Object, e As EventArgs) Handles BTNActualizarEmpleo.Click
        TablaEmpleo = Session("TablaEmpleo")
        VistaEmpleo = Session("VistaEmpleo")

        Dim Renglon As Integer = GVEmpleo.SelectedIndex
        VistaEmpleo(Renglon).Item("IdPersonaEmpleo") = Int32.Parse(TBIdPersonaEmpleo.Text)
        VistaEmpleo(Renglon).Item("IdTipoEmpleo") = DDTipoEmpleos.SelectedValue
        VistaEmpleo(Renglon).Item("Ocupacion") = TBEmpOcupacion.Text.ToUpper()
        VistaEmpleo(Renglon).Item("Empresa") = TBEmpEmpresa.Text.ToUpper()
        VistaEmpleo(Renglon).Item("Antiguedad") = Int32.Parse(TBEmpAntiguedad.Text)
        VistaEmpleo(Renglon).Item("Domicilio") = TBEmpDomicilio.Text
        VistaEmpleo(Renglon).Item("Telefono") = TBEmpTelefono.Text
        VistaEmpleo(Renglon).Item("IdEstado") = 1
        VistaEmpleo(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaEmpleo") = TablaEmpleo
        Session("VistaEmpleo") = VistaEmpleo
        GVEmpleo.DataSource = VistaEmpleo
        GVEmpleo.DataBind()

        'limpiar controles Empleo 
        TBIdPersonaEmpleo.Text = ""
        DDTipoEmpleos.SelectedIndex = 0
        TBEmpOcupacion.Text = ""
        TBEmpEmpresa.Text = ""
        TBEmpAntiguedad.Text = ""
        TBEmpDomicilio.Text = ""
        TBEmpTelefono.Text = ""
        ControlesEmpleo(False)
    End Sub
    Protected Sub BTNEliminarEmpleo_Click(sender As Object, e As EventArgs) Handles BTNEliminarEmpleo.Click
        TablaEmpleo = Session("TablaEmpleo")
        VistaEmpleo = Session("VistaEmpleo")

        'actualizar renglon
        Dim Renglon As Integer = GVEmpleo.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaEmpleo(Renglon).Item("IdPersonaEmpleo") = 0 Then
            VistaEmpleo(Renglon).Delete()
        Else
            VistaEmpleo(Renglon).Item("idActualizar") = 1 'Si   
            VistaEmpleo(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaEmpleo") = TablaEmpleo
        Session("VistaEmpleo") = VistaEmpleo
        GVEmpleo.DataSource = VistaEmpleo
        GVEmpleo.DataBind()
        ControlesEmpleo(False)
    End Sub
    Protected Sub BTNCancelarEmpleo_Click(sender As Object, e As EventArgs) Handles BTNCancelarEmpleo.Click
        TBIdPersonaEmpleo.Text = 0
        DDTipoEmpleos.SelectedIndex = 0
        TBEmpOcupacion.Text = ""
        TBEmpEmpresa.Text = ""
        TBEmpAntiguedad.Text = ""
        TBEmpDomicilio.Text = ""
        TBEmpTelefono.Text = ""
        ControlesEmpleo(False)
    End Sub

    Private Sub ControlesEmpleo(control As Boolean)
        If control Then
            PanelEmpleo.Visible = True
            GVEmpleo.Visible = False
        Else
            PanelEmpleo.Visible = False
            GVEmpleo.Visible = True
        End If
    End Sub
#End Region

#Region "Referencias==================================================================================="
    Protected Sub BTNReferencia_Click(sender As Object, e As EventArgs) Handles BTNReferencia.Click
        TBIdPersonaReferencia.Text = 0
        DDTipoReferencia.SelectedIndex = 0
        TBRefNombre.Text = ""
        TBRefOcupacion.Text = ""
        TBRefEmpresa.Text = ""
        TBRefAntiguedad.Text = ""
        TBRefTelCel.Text = ""
        TBRefDomicilio.Text = ""
        ControlesReferencia(True)
    End Sub
    Protected Sub BTNAceptarReferencia_Click(sender As Object, e As EventArgs) Handles BTNAceptarReferencia.Click
        TablaReferencia = Session("TablaReferencia")
        VistaReferencia = Session("VistaReferencia")
        Dim EntidadPersona As New Entidad.Persona()

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaReferencia.Rows
            If fila.Item("IdTipoReferencia").ToString() = DDTipoReferencia.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaReferencia.NewRow()
            RenglonAInsertar("IdPersonaReferencia") = Int32.Parse(TBIdPersonaReferencia.Text)
            RenglonAInsertar("IdTipoReferencia") = DDTipoReferencia.SelectedValue
            RenglonAInsertar("NombreReferencia") = TBRefNombre.Text.ToUpper()
            RenglonAInsertar("Ocupacion") = TBRefOcupacion.Text.ToUpper()
            RenglonAInsertar("Empresa") = TBRefEmpresa.Text.ToUpper()
            RenglonAInsertar("Antiguedad") = Int32.Parse(TBRefAntiguedad.Text)
            RenglonAInsertar("Domicilio") = TBRefDomicilio.Text
            RenglonAInsertar("Telefono") = TBRefTelCel.Text
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaReferencia.Rows.Add(RenglonAInsertar)

            Session("TablaReferencia") = TablaReferencia
            Session("VistaReferencia") = VistaReferencia
            GVReferencia.DataSource = VistaReferencia
            GVReferencia.DataBind()

            'limpiar Referencia
            TBIdPersonaReferencia.Text = ""
            DDTipoReferencia.SelectedIndex = 0
            TBRefNombre.Text = ""
            TBRefOcupacion.Text = ""
            TBRefEmpresa.Text = ""
            TBRefAntiguedad.Text = ""
            TBRefDomicilio.Text = ""
            TBRefTelCel.Text = ""
            ControlesReferencia(False)
        End If
    End Sub
    Protected Sub GVReferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVReferencia.SelectedIndexChanged
        PanelReferencia.Visible = True

        TablaReferencia = Session("TablaReferencia")
        VistaReferencia = Session("VistaReferencia")

        Dim Renglon As Integer = GVReferencia.SelectedIndex

        TBIdPersonaReferencia.Text = VistaReferencia(Renglon).Item("IdPersonaReferencia")
        DDTipoReferencia.SelectedValue = VistaReferencia(Renglon).Item("IdTipoReferencia")
        TBRefNombre.Text = VistaReferencia(Renglon).Item("NombreReferencia")
        TBRefOcupacion.Text = VistaReferencia(Renglon).Item("Ocupacion")
        TBRefEmpresa.Text = VistaReferencia(Renglon).Item("Empresa")
        TBRefAntiguedad.Text = VistaReferencia(Renglon).Item("Antiguedad")
        TBRefDomicilio.Text = VistaReferencia(Renglon).Item("Domicilio")
        TBRefTelCel.Text = VistaReferencia(Renglon).Item("Telefono")
        ControlesReferencia(True)
    End Sub
    Protected Sub BTNActualizarReferencia_Click(sender As Object, e As EventArgs) Handles BTNActualizarReferencia.Click
        TablaReferencia = Session("TablaReferencia")
        VistaReferencia = Session("VistaReferencia")

        Dim Renglon As Integer = GVReferencia.SelectedIndex
        VistaReferencia(Renglon).Item("IdPersonaReferencia") = Int32.Parse(TBIdPersonaReferencia.Text)
        VistaReferencia(Renglon).Item("IdTipoReferencia") = DDTipoReferencia.SelectedValue
        VistaReferencia(Renglon).Item("NombreReferencia") = TBRefNombre.Text.ToUpper()
        VistaReferencia(Renglon).Item("Ocupacion") = TBRefOcupacion.Text.ToUpper()
        VistaReferencia(Renglon).Item("Empresa") = TBRefEmpresa.Text.ToUpper()
        VistaReferencia(Renglon).Item("Antiguedad") = Int32.Parse(TBRefAntiguedad.Text)
        VistaReferencia(Renglon).Item("Domicilio") = TBRefDomicilio.Text
        VistaReferencia(Renglon).Item("Telefono") = TBRefTelCel.Text
        VistaReferencia(Renglon).Item("IdEstado") = 1
        VistaReferencia(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaReferencia") = TablaReferencia
        Session("VistaReferencia") = VistaReferencia
        GVReferencia.DataSource = VistaReferencia
        GVReferencia.DataBind()

        'limpiar controles Referencia 
        TBIdPersonaReferencia.Text = ""
        DDTipoReferencia.SelectedIndex = 0
        TBRefNombre.Text = ""
        TBRefOcupacion.Text = ""
        TBRefEmpresa.Text = ""
        TBRefAntiguedad.Text = ""
        TBRefDomicilio.Text = ""
        TBRefTelCel.Text = ""
        ControlesReferencia(False)
    End Sub
    Protected Sub BTNEliminarReferencia_Click(sender As Object, e As EventArgs) Handles BTNEliminarReferencia.Click
        TablaReferencia = Session("TablaReferencia")
        VistaReferencia = Session("VistaReferencia")

        'actualizar renglon
        Dim Renglon As Integer = GVReferencia.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaReferencia(Renglon).Item("IdPersonaReferencia") = 0 Then
            VistaReferencia(Renglon).Delete()
        Else
            VistaReferencia(Renglon).Item("idActualizar") = 1 'Si   
            VistaReferencia(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaReferencia") = TablaReferencia
        Session("VistaReferencia") = VistaReferencia
        GVReferencia.DataSource = VistaReferencia
        GVReferencia.DataBind()
        ControlesReferencia(False)
    End Sub
    Protected Sub BTNCancelarReferencia_Click(sender As Object, e As EventArgs) Handles BTNCancelarReferencia.Click
        TBIdPersonaReferencia.Text = 0
        DDTipoReferencia.SelectedIndex = 0
        TBRefNombre.Text = ""
        TBRefOcupacion.Text = ""
        TBRefEmpresa.Text = ""
        TBRefAntiguedad.Text = ""
        TBRefTelCel.Text = ""
        TBRefDomicilio.Text = ""
        ControlesReferencia(False)
    End Sub
    Private Sub ControlesReferencia(control As Boolean)
        If control Then
            PanelReferencia.Visible = True
            GVReferencia.Visible = False
        Else
            PanelReferencia.Visible = False
            GVReferencia.Visible = True
        End If
    End Sub
#End Region

#Region "Linea de Credito============================================================================="
    Protected Sub BTNLineaCredito_Click(sender As Object, e As EventArgs) Handles BTNLineaCredito.Click
        TBIdPersonaLineaCredito.Text = 0
        TBFechaLineaCredito.Text = ""
        TBLineaCredito.Text = ""
        TBMontoLineaCredito.Text = ""
        ControlesLineaCredito(True)
    End Sub
    Protected Sub BTNAceptarLineaCredito_Click(sender As Object, e As EventArgs) Handles BTNAceptarLineaCredito.Click
        TablaLineaCredito = Session("TablaLineaCredito")
        VistaLineaCredito = Session("VistaLineaCredito")
        Dim EntidadPersona As New Entidad.Persona()

        Dim RenglonAInsertar As DataRow
        RenglonAInsertar = TablaLineaCredito.NewRow()
        RenglonAInsertar("IdPersonaLineaCredito") = Int32.Parse(TBIdPersonaLineaCredito.Text)
        RenglonAInsertar("Fecha") = TBFechaLineaCredito.Text
        RenglonAInsertar("Credito") = TBLineaCredito.Text.ToUpper()
        RenglonAInsertar("Monto") = Int32.Parse(TBMontoLineaCredito.Text)
        RenglonAInsertar("IdUsuarioCreacion") = 1
        RenglonAInsertar("FechaCreacion") = Now
        RenglonAInsertar("IdUsuarioActualizacion") = 1
        RenglonAInsertar("FechaActualizacion") = CDate(Now)
        RenglonAInsertar("idEstado") = 1
        RenglonAInsertar("idActualizar") = 1
        TablaLineaCredito.Rows.Add(RenglonAInsertar)

        Session("TablaLineaCredito") = TablaLineaCredito
        Session("VistaLineaCredito") = VistaLineaCredito
        GVLineaCredito.DataSource = VistaLineaCredito
        GVLineaCredito.DataBind()

        'limpiar Referencia
        TBIdPersonaLineaCredito.Text = ""
        TBFechaLineaCredito.Text = ""
        TBLineaCredito.Text = ""
        TBMontoLineaCredito.Text = ""
        ControlesLineaCredito(False)
    End Sub
    Protected Sub GVLineaCredito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVLineaCredito.SelectedIndexChanged

        TablaLineaCredito = Session("TablaLineaCredito")
        VistaLineaCredito = Session("VistaLineaCredito")

        Dim Renglon As Integer = GVLineaCredito.SelectedIndex

        TBIdPersonaLineaCredito.Text = VistaLineaCredito(Renglon).Item("IdPersonaLineaCredito")
        TBFechaLineaCredito.Text = VistaLineaCredito(Renglon).Item("Fecha")
        TBLineaCredito.Text = VistaLineaCredito(Renglon).Item("Credito")
        TBMontoLineaCredito.Text = VistaLineaCredito(Renglon).Item("Monto")
        ControlesLineaCredito(True)
    End Sub
    Protected Sub BTNActualizarLineaCredito_Click(sender As Object, e As EventArgs) Handles BTNActualizarLineaCredito.Click
        TablaLineaCredito = Session("TablaLineaCredito")
        VistaLineaCredito = Session("VistaLineaCredito")

        Dim Renglon As Integer = GVLineaCredito.SelectedIndex
        VistaLineaCredito(Renglon).Item("IdPersonaLineaCredito") = TBIdPersonaLineaCredito.Text
        VistaLineaCredito(Renglon).Item("Fecha") = TBFechaLineaCredito.Text
        VistaLineaCredito(Renglon).Item("Credito") = TBLineaCredito.Text.ToUpper()
        VistaLineaCredito(Renglon).Item("Monto") = TBMontoLineaCredito.Text
        VistaLineaCredito(Renglon).Item("IdEstado") = 1
        VistaLineaCredito(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaLineaCredito") = TablaLineaCredito
        Session("VistaLineaCredito") = VistaLineaCredito
        GVLineaCredito.DataSource = VistaLineaCredito
        GVLineaCredito.DataBind()
        TBIdPersonaLineaCredito.Text = 0
        TBFechaLineaCredito.Text = ""
        TBLineaCredito.Text = ""
        TBMontoLineaCredito.Text = ""
        ControlesLineaCredito(False)
    End Sub
    Protected Sub BTNEliminarLineaCredito_Click(sender As Object, e As EventArgs) Handles BTNEliminarLineaCredito.Click
        TablaLineaCredito = Session("TablaLineaCredito")
        VistaLineaCredito = Session("VistaLineaCredito")

        'actualizar renglon
        Dim Renglon As Integer = GVLineaCredito.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaLineaCredito(Renglon).Item("IdPersonaLineaCredito") = 0 Then
            VistaLineaCredito(Renglon).Delete()
        Else
            VistaLineaCredito(Renglon).Item("idActualizar") = 1 'Si   
            VistaLineaCredito(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaLineaCredito") = TablaLineaCredito
        Session("VistaLineaCredito") = VistaLineaCredito
        GVLineaCredito.DataSource = VistaLineaCredito
        GVLineaCredito.DataBind()
        ControlesLineaCredito(False)
    End Sub
    Protected Sub BTNCancelarLineaCredito_Click(sender As Object, e As EventArgs) Handles BTNCancelarLineaCredito.Click
        TBIdPersonaLineaCredito.Text = ""
        TBFechaLineaCredito.Text = ""
        TBLineaCredito.Text = ""
        TBMontoLineaCredito.Text = ""
        ControlesLineaCredito(False)
    End Sub
    Private Sub ControlesLineaCredito(control As Boolean)
        If control Then
            PanelLineaCredito.Visible = True
            GVLineaCredito.Visible = False
        Else
            PanelLineaCredito.Visible = False
            GVLineaCredito.Visible = True
        End If
    End Sub
#End Region

#Region "Indicador=========================================================================="
    Protected Sub BTNIndicador_Click(sender As Object, e As EventArgs) Handles BTNIndicador.Click
        TBIdPersonaIndicador.Text = 0
        DDTipoIndicador.SelectedIndex = 0
        TBMontoIndicador.Text = ""
        ControlesIndicador(True)
    End Sub
    Protected Sub BTNAceptarIndicador_Click(sender As Object, e As EventArgs) Handles BTNAceptarIndicador.Click
        TablaIndicador = Session("TablaIndicador")
        VistaIndicador = Session("VistaIndicador")
        Dim EntidadPersona As New Entidad.Persona()

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaIndicador.Rows
            If fila.Item("IdTipoIndicador").ToString() = DDTipoIndicador.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaIndicador.NewRow()
            RenglonAInsertar("IdPersonaIndicador") = Int32.Parse(TBIdPersonaIndicador.Text)
            RenglonAInsertar("IdTipoIndicador") = DDTipoReferencia.SelectedValue
            RenglonAInsertar("TipoIndicador") = DDTipoIndicador.SelectedItem.Text
            RenglonAInsertar("Monto") = Int32.Parse(TBMontoIndicador.Text)
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaIndicador.Rows.Add(RenglonAInsertar)

            Session("TablaIndicador") = TablaIndicador
            Session("VistaReferencia") = VistaIndicador
            GVIndicador.DataSource = VistaIndicador
            GVIndicador.DataBind()

            'limpiar Indicador
            TBIdPersonaIndicador.Text = 0
            DDTipoIndicador.SelectedIndex = 0
            TBMontoIndicador.Text = ""
            ControlesIndicador(False)
        End If
    End Sub
    Protected Sub GVIndicador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVIndicador.SelectedIndexChanged
        PanelIndicadores.Visible = True
        TablaIndicador = Session("TablaIndicador")
        VistaIndicador = Session("VistaIndicador")
        Dim Renglon As Integer = GVIndicador.SelectedIndex
        TBIdPersonaIndicador.Text = VistaIndicador(Renglon).Item("IdPersonaIndicador")
        DDTipoIndicador.SelectedValue = VistaIndicador(Renglon).Item("IdTipoIndicador")
        TBMontoIndicador.Text = VistaIndicador(Renglon).Item("Monto")
        ControlesIndicador(True)
    End Sub
    Protected Sub BTNActualizarIndicador_Click(sender As Object, e As EventArgs) Handles BTNActualizarIndicador.Click
        TablaIndicador = Session("TablaIndicador")
        VistaIndicador = Session("VistaIndicador")

        Dim Renglon As Integer = GVIndicador.SelectedIndex
        VistaIndicador(Renglon).Item("IdPersonaIndicador") = Int32.Parse(TBIdPersonaIndicador.Text)
        VistaIndicador(Renglon).Item("IdTipoIndicador") = DDTipoIndicador.SelectedValue
        VistaIndicador(Renglon).Item("Monto") = Double.Parse(TBMontoIndicador.Text)
        VistaIndicador(Renglon).Item("IdEstado") = 1
        VistaIndicador(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaIndicador") = TablaIndicador
        Session("VistaIndicador") = VistaIndicador
        GVIndicador.DataSource = VistaIndicador
        GVIndicador.DataBind()

        'limpiar controles Indicador
        TBIdPersonaIndicador.Text = 0
        DDTipoIndicador.SelectedIndex = 0
        TBMontoIndicador.Text = ""
        ControlesIndicador(False)
    End Sub
    Protected Sub BTNEliminarIndicador_Click(sender As Object, e As EventArgs) Handles BTNEliminarIndicador.Click
        TablaIndicador = Session("TablaIndicador")
        VistaIndicador = Session("VistaIndicador")
        'actualizar renglon
        Dim Renglon As Integer = GVIndicador.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaIndicador(Renglon).Item("IdPersonaIndicador") = 0 Then
            VistaIndicador(Renglon).Delete()
        Else
            VistaIndicador(Renglon).Item("idActualizar") = 1 'Si   
            VistaIndicador(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If
        Session("TablaIndicador") = TablaIndicador
        Session("VistaIndicador") = VistaIndicador
        GVIndicador.DataSource = VistaIndicador
        GVIndicador.DataBind()
        ControlesIndicador(False)
    End Sub
    Protected Sub BTNCancelarIndicador_Click(sender As Object, e As EventArgs) Handles BTNCancelarIndicador.Click
        TBIdPersonaIndicador.Text = ""
        DDTipoIndicador.SelectedIndex = 0
        TBMontoIndicador.Text = ""
        ControlesIndicador(False)
    End Sub
    Private Sub ControlesIndicador(control As Boolean)
        If control Then
            PanelIndicadores.Visible = True
            GVIndicador.Visible = False
        Else
            PanelIndicadores.Visible = False
            GVIndicador.Visible = True
        End If
    End Sub
#End Region

    Protected Sub DDEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEstadoCivil.SelectedIndexChanged
        If DDEstadoCivil.SelectedItem.Text = "CASADO" Then
            DDEstCivConyugue.SelectedValue = DDEstadoCivil.SelectedValue
            AccordionPane0.Visible = True
        Else
            AccordionPane0.Visible = False
        End If
    End Sub

    Protected Sub BTNConyugue_Click(sender As Object, e As EventArgs) Handles BTNConyugue.Click
        TBIdPersonaConyugue.Text = 0
        PAConyugue.Visible = True

    End Sub
#Region "sin utilizar"
    Protected Sub DDTipoMedio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDTipoMedio.SelectedIndexChanged
    End Sub

    Protected Sub DDPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPais.SelectedIndexChanged

    End Sub

    Protected Sub DDEntidadFederativa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDEntidadFederativa.SelectedIndexChanged
        Dim TablaMunicipio As New DataTable
        Dim NegocioMunicipio As New Negocio.Municipio()
        Dim EntidadMunicipio As New Entidad.Municipio()
        EntidadMunicipio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadMunicipio.IdEntidadFederativa = DDEntidadFederativa.SelectedValue
        NegocioMunicipio.Consultar(EntidadMunicipio)
        TablaMunicipio = EntidadMunicipio.TablaConsulta
        DDDomMunicipio.DataSource = TablaMunicipio
        DDDomMunicipio.DataValueField = "ID"
        DDDomMunicipio.DataTextField = "Descripcion"
        DDDomMunicipio.DataBind()
        DDDomMunicipio.SelectedIndex = 0

        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadColonia.IdMunColonia = DDDomMunicipio.SelectedValue
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "ID"
        DDDomColonia.DataTextField = "Descripcion"
        DDDomColonia.DataBind()
        DDDomColonia.SelectedIndex = 0
    End Sub

    Protected Sub DDDomMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDDomMunicipio.SelectedIndexChanged
        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadColonia.IdMunColonia = DDDomMunicipio.SelectedValue
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "ID"
        DDDomColonia.DataTextField = "Descripcion"
        DDDomColonia.DataBind()
        DDDomColonia.SelectedIndex = 0
        TBDomCodigoPostal.Text = ""
    End Sub

    'Protected Sub DDDomLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDDomLocalidad.SelectedIndexChanged

    'End Sub
#End Region
    Protected Sub DDGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDGenero.SelectedIndexChanged
        If DDGenero.SelectedItem.Text = "MASCULINO" Then
            DDGeneroConyugue.SelectedItem.Text = "FEMENINO"
        Else
            DDGeneroConyugue.SelectedItem.Text = "MASCULINO"
        End If
    End Sub
    Protected Sub DDDomColonia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDDomColonia.SelectedIndexChanged
        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        ' If TBDomCodigoPostal.Text Is String.Empty Then
        EntidadColonia.CPColonia = -1
        ' Else
        '    EntidadColonia.CPColonia = TBDomCodigoPostal.Text
        ' End If
        EntidadColonia.IdColonia = DDDomColonia.SelectedValue
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        TBDomCodigoPostal.Text = TablaColonia.Rows(0).Item("CodigoPostal")
        DDDomMunicipio.SelectedIndex = (TablaColonia.Rows(0).Item("IdMunicipio") - 1)
    End Sub

    Protected Sub DDTipoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipoPersona.SelectedIndexChanged
        If DDTipoPersona.SelectedItem.Text = "MORAL" Then
            TBRazonSocial.Enabled = True
            TBNombre.Enabled = False
            TBSegundoNombre.Enabled = False
            TBAPaterno.Enabled = False
            TBAMaterno.Enabled = False
        Else
            TBRazonSocial.Enabled = False
            TBNombre.Enabled = True
            TBSegundoNombre.Enabled = True
            TBAPaterno.Enabled = True
            TBAMaterno.Enabled = True
        End If
    End Sub

    Protected Sub BTNAceptarConyugue_Click(sender As Object, e As EventArgs) Handles BTNAceptarConyugue.Click
        TablaConyugue = Session("TablaConyugue")
        VistaConyugue = Session("VistaConyugue")
        Dim EntidadPersona As New Entidad.Persona()

        Dim RenglonAInsertar As DataRow
        RenglonAInsertar = TablaConyugue.NewRow()
        RenglonAInsertar("IdPersonaConyugue") = Int32.Parse(TBIdPersonaConyugue.Text)
        If TBIdPerConyugue.Text Is String.Empty Then
            RenglonAInsertar("IdPersona") = 0
        Else
            RenglonAInsertar("IdPersona") = Int32.Parse(TBIdPerConyugue.Text)
        End If
        RenglonAInsertar("Equivalencia") = TBEquivalenciaConyugue.Text
        RenglonAInsertar("IdTipoPersona") = DDTipoPersona.Text
        RenglonAInsertar("IdTipoPersona") = DDTipoPersona.Text
        RenglonAInsertar("RazonSocial") = TBRazonSocial.Text
        RenglonAInsertar("PrimerNombre") = TBPriNomConyugue.Text
        RenglonAInsertar("SegundoNombre") = TBSegNomConyugue.Text
        RenglonAInsertar("ApellidoPaterno") = TBApePatConyugue.Text
        RenglonAInsertar("ApellidoMaterno") = TBApeMatConyugue.Text
        RenglonAInsertar("FechaNacimiento") = TBFechaConyugue.Text
        If TBSegNomConyugue.Text Is String.Empty Then
            RenglonAInsertar("NombreConyugue") = TBPriNomConyugue.Text.ToUpper() + " " + TBApePatConyugue.Text.ToUpper() + " " + TBApeMatConyugue.Text.ToUpper()
        Else
            RenglonAInsertar("NombreConyugue") = TBPriNomConyugue.Text.ToUpper() + " " + TBSegNomConyugue.Text.ToUpper() + " " + TBApePatConyugue.Text.ToUpper() + " " + TBApeMatConyugue.Text.ToUpper()
        End If
        RenglonAInsertar("IdTipoGenero") = DDGeneroConyugue.Text
        RenglonAInsertar("IdTipoEstadoCivil") = DDEstCivConyugue.Text
        RenglonAInsertar("IdUsuarioCreacion") = 1
        RenglonAInsertar("FechaCreacion") = Now
        RenglonAInsertar("IdUsuarioActualizacion") = 1
        RenglonAInsertar("FechaActualizacion") = CDate(Now)
        RenglonAInsertar("DescripcionEstado") = DDEstadoConyugue.SelectedItem.Text
        RenglonAInsertar("Observaciones") = ""
        RenglonAInsertar("idEstado") = DDEstadoConyugue.SelectedValue
        RenglonAInsertar("idActualizar") = 1
        TablaConyugue.Rows.Add(RenglonAInsertar)

        Session("TablaConyugue") = TablaConyugue
        Session("VistaConyugue") = VistaConyugue
        GVConyugue.DataSource = VistaConyugue
        GVConyugue.DataBind()

        'limpiar Conyugue
        PAConyugue.Visible = False
    End Sub

    Protected Sub GVConyugue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConyugue.SelectedIndexChanged
        PAConyugue.Visible = True
        TBIdIdentificacion.Visible = True
        Dim TablaConyugue As New DataTable
        TablaConyugue = Session("TablaConyugue")
        TBIdPersonaConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("IdPersonaConyugue")
        TBIdPerConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("IdPersona")
        TBPriNomConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("PrimerNombre")
        TBSegNomConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("SegundoNombre")
        TBApePatConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("ApellidoPaterno")
        TBApeMatConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("ApellidoMaterno")
        TBFechaConyugue.Text = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("FechaNacimiento")
        DDGeneroConyugue.SelectedValue = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("IdTipoGenero")
        DDEstCivConyugue.SelectedValue = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("IdTipoEstadoCivil")
        DDEstadoConyugue.SelectedValue = TablaConyugue.Rows(GVConyugue.SelectedIndex).Item("IdEstado")
    End Sub

    Protected Sub BTNActualizarConyugue_Click(sender As Object, e As EventArgs) Handles BTNActualizarConyugue.Click
        TablaConyugue = Session("TablaConyugue")
        VistaConyugue = Session("VistaConyugue")

        Dim Renglon As Integer = GVConyugue.SelectedIndex
        VistaConyugue(Renglon).Item("IdPersonaConyugue") = TBIdPersonaConyugue.Text
        VistaConyugue(Renglon).Item("IdPersona") = TBIdPerConyugue.Text
        If TBSegNomConyugue Is String.Empty Then
            VistaConyugue(Renglon).Item("NombreConyugue") = TBPriNomConyugue.Text.ToUpper() + " " + TBApePatConyugue.Text.ToUpper() + " " + TBApeMatConyugue.Text.ToUpper()
        Else
            VistaConyugue(Renglon).Item("NombreConyugue") = TBPriNomConyugue.Text.ToUpper() + " " + TBSegNomConyugue.Text.ToUpper() + " " + TBApePatConyugue.Text.ToUpper() + " " + TBApeMatConyugue.Text.ToUpper()
        End If
        VistaConyugue(Renglon).Item("PrimerNombre") = TBPriNomConyugue.Text
        VistaConyugue(Renglon).Item("SegundoNombre") = TBSegNomConyugue.Text
        VistaConyugue(Renglon).Item("ApellidoPaterno") = TBApePatConyugue.Text
        VistaConyugue(Renglon).Item("ApellidoMaterno") = TBApeMatConyugue.Text
        VistaConyugue(Renglon).Item("FechaNacimiento") = TBFechaConyugue.Text
        VistaConyugue(Renglon).Item("IdTipoGenero") = DDGeneroConyugue.SelectedValue
        VistaConyugue(Renglon).Item("IdTipoEstadoCivil") = DDEstCivConyugue.SelectedValue
        VistaConyugue(Renglon).Item("IdEstado") = 1
        VistaConyugue(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaConyugue") = TablaConyugue
        Session("VistaConyugue") = VistaConyugue
        GVConyugue.DataSource = VistaConyugue
        GVConyugue.DataBind()

        TBIdPersonaConyugue.Text = 0
        TBIdPerConyugue.Text = ""
        TBPriNomConyugue.Text = ""
        TBSegNomConyugue.Text = ""
        TBApePatConyugue.Text = ""
        TBApeMatConyugue.Text = ""
        TBFechaConyugue.Text = ""
        DDGeneroConyugue.SelectedIndex = 0
        DDEstCivConyugue.SelectedIndex = 0
        DDEstadoConyugue.SelectedIndex = 0
        PAConyugue.Visible = False
    End Sub

    Protected Sub MultiView1_ActiveViewChanged(sender As Object, e As EventArgs) Handles MultiView1.ActiveViewChanged

    End Sub

    'Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    Dim Tabla As New DataTable
    '    GridView1.PageIndex = e.NewPageIndex
    '    Tabla = Session("Tabla")
    '    GridView1.DataSource = Tabla
    '    GridView1.DataBind()
    'End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub IBTRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
#End Region
    Protected Sub IMBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IMBTConsultar.Click
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        Dim Tabla As New DataTable
        EntidadPersona.IdPersona = IIf(TBIdPersonaConsultar.Text Is String.Empty, 0, TBIdPersonaConsultar.Text)
        EntidadPersona.Equivalencia = IIf(TBEquivalenciaConsultar.Text Is String.Empty, "0", TBEquivalenciaConsultar.Text)
        EntidadPersona.PrimerNombre = TBNombreClienteConsultar.Text
        EntidadPersona.FechaCreacion = TBFechaInicioConsultar.Text
        EntidadPersona.FechaActualizacion = TBFechaFinConsultar.Text
        EntidadPersona.IdTipoGenero = DDGeneroConsulta.SelectedValue
        EntidadPersona.IdTipoPersona = DDTipoPersonaConsulta.SelectedValue
        EntidadPersona.IdEstado = DDEstadoConsulta.SelectedValue
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioPersona.ObtenerFiltro(EntidadPersona)
        Tabla = EntidadPersona.TablaConsulta
        GVPersona.Columns.Clear()
        GVPersona.DataSource = Tabla
        GVPersona.AutoGenerateColumns = False
        GVPersona.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPersona.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "ID Cliente", "Id")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Nombre Cliente", "NombreCliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Fecha Nacimiento", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Estado", "TipoEstado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersona, New BoundField(), "Genero", "Genero")
        GVPersona.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub TBDomicilioCodigoPostal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.CPColonia = TBDomCodigoPostal.Text
        EntidadColonia.IdColonia = DDDomColonia.SelectedValue
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "ID"
        DDDomColonia.DataTextField = "Descripcion"
        DDDomColonia.DataBind()
        DDDomMunicipio.SelectedIndex = (TablaColonia.Rows(0).Item("IdMunicipio") - 1)
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub
    Protected Sub RBAnos_CheckedChanged(sender As Object, e As EventArgs) Handles RBAnos.CheckedChanged
        If RBAnos.Checked = True Then
            TipoAntiguedad = 1
        End If
    End Sub
    Protected Sub RBMeses_CheckedChanged(sender As Object, e As EventArgs) Handles RBMeses.CheckedChanged
        If RBMeses.Checked = True Then
            TipoAntiguedad = 2
        End If
    End Sub
    Protected Sub RBDias_CheckedChanged(sender As Object, e As EventArgs) Handles RBDias.CheckedChanged
        If RBAnos.Checked = True Then
            TipoAntiguedad = 3
        End If
    End Sub

    Protected Sub BTNConsultarConyugue_Click(sender As Object, e As EventArgs) Handles BTNConsultarConyugue.Click

    End Sub
End Class