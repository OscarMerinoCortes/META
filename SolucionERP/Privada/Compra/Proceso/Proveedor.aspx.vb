Imports System.Data
Imports Comun.Presentacion
Imports System.Collections.ObjectModel
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page

    Dim TipoAntiguedad As Integer
    Public TablaIdentificacion As New DataTable()
    Public VistaIdentificacion As New DataView()
    Public TablaContacto As New DataTable()
    Public VistaContacto As New DataView()
    Public TablaDireccion As New DataTable()
    Public VistaDireccion As New DataView()
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
    Public TablaProducto As New DataTable()
    Public VistaProducto As New DataView()

    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Registro de Proveedor"


            'DDTipoPersona.Items.Add(New ListItem("FISICA", 1))
            'DDTipoPersona.Items.Add(New ListItem("MORAL", 2))
            'DDTipoPersona.SelectedIndex = 0


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
            Dim TablaTM As New DataTable
            Dim NegocioTipoMedio As New Negocio.TipoMedio()
            Dim EntidadTipoMedio As New Entidad.TipoMedio()
            EntidadTipoMedio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoMedio.Consultar(EntidadTipoMedio)
            TablaTM = EntidadTipoMedio.TablaConsulta
            DDTipoContacto.DataSource = TablaTM
            DDTipoContacto.DataValueField = "ID"
            DDTipoContacto.DataTextField = "Descripcion"
            DDTipoContacto.DataBind()



            '===================================================Contacto=========================================================
            TablaContacto.Columns.Clear()
            TablaContacto.Columns.Add(New DataColumn("IdProveedorContacto", Type.GetType("System.Int32")))
            TablaContacto.Columns.Add(New DataColumn("IdTipoContacto", Type.GetType("System.Int32")))
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

            '===================================================Productos=========================================================
            TablaProducto.Columns.Clear()
            TablaProducto.Columns.Add(New DataColumn("IdProveedor_Producto", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("Producto", Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Precio", Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaProducto.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaProducto = TablaProducto.DefaultView
            VistaProducto.RowFilter = "IdEstado=1"

            'GVProductos.Columns.Clear()
            'GVProductos.DataSource = TablaProducto
            'GVProductos.AutoGenerateColumns = False
            'GVProductos.AllowSorting = True

            'Dim Columna5 As New CommandField()
            'Columna5.HeaderText = ""
            'Columna5.HeaderText = "Seleccionar"
            'Columna5.SelectText = "Seleccionar"
            'Columna5.ButtonType = ButtonType.Link
            'Columna5.ShowSelectButton = True
            'GVProductos.Columns.Add(Columna5)
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductos, New BoundField(), "IdProducto", "IdProducto")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductos, New BoundField(), "Producto", "Producto")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductos, New BoundField(), "Precio", "Precio")
            'GVProductos.DataBind()

            Session("TablaProducto") = TablaProducto
            Session("VistaProducto") = VistaProducto



            '====================================================Domicilio========================================================
            TablaDireccion.Columns.Clear()
            TablaDireccion.Columns.Add(New DataColumn("IdProveedorDomicilio", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("Calle", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdPais", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("Pais", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdEntidadFederativa", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("EntidadFederativa", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdMunicipio", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("Municipio", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdLocalidad", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("Localidad", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdColonia", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("Colonia", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("NumeroInterior", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("NumeroExterior", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("CP", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaDireccion.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))
            TablaDireccion.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))

            VistaDireccion = TablaDireccion.DefaultView
            VistaDireccion.RowFilter = "IdEstado=1"

            GVDomicilio.Columns.Clear()
            GVDomicilio.DataSource = TablaDireccion
            GVDomicilio.AutoGenerateColumns = False
            GVDomicilio.AllowSorting = True

            Dim Columna3 As New CommandField()
            Columna3.HeaderText = ""
            Columna3.HeaderText = "Seleccionar"
            Columna3.SelectText = "Seleccionar"
            Columna3.ButtonType = ButtonType.Link
            Columna3.ShowSelectButton = True
            GVDomicilio.Columns.Add(Columna3)
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Calle", "Calle")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Colonia", "Colonia")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Municipio", "Municipio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Entidad Federativa", "EntidadFederativa")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVDomicilio, New BoundField(), "Pais", "Pais")
            GVMedio.DataBind()

            Session("TablaDireccion") = TablaDireccion
            Session("VistaDireccion") = VistaDireccion


            Nuevo()
            MultiView1.SetActiveView(View1)
            Productos.Visible = True
            wucDatosAuditoria1.Visible = False
            wucConsultarProducto1.Visible = True
            BTNAceptarProducto.Visible=True
        Else
            TablaIdentificacion = Session("TablaIdentificacion")
            VistaIdentificacion = Session("VistaIdentificacion")
            TablaContacto = Session("TablaContacto")
            VistaContacto = Session("VistaContacto")
            TablaDireccion = Session("TablaDireccion")
            VistaDireccion = Session("VistaDireccion")
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
            TablaProducto = Session("TablaProducto")
            VistaProducto = Session("VistaProducto")

            ListaEstado = CType(Session("ListaEstado"), ObservableCollection(Of Entidad.TipoSolicitudEstado))
            ListaPrioridad = CType(Session("ListaPrioridad"), ObservableCollection(Of Entidad.TipoPrioridad))
        End If
        AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub
    Private Sub AgregarProductos()
        TablaProducto = CType(Session("TablaProducto"), DataTable)
        VistaProducto = CType(Session("VistaProducto"), DataView)
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto1.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaProducto.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaProducto.NewRow()
                RenglonAInsertar("IdProveedor_Producto") = 0   'IIf(TBIdProveedor.Text Is String.Empty, 0, TBIdProveedor.Text)
                RenglonAInsertar("IdProducto") = producto.IdProducto
                RenglonAInsertar("IdProductoCorto") = producto.IdProductoCorto
                RenglonAInsertar("Producto") = producto.Producto
                RenglonAInsertar("Precio") = CType(TBPrecio.Text, Double)
                RenglonAInsertar("IdEstado") = 1
                RenglonAInsertar("IdActualizar") = 1
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = CDate(Now)
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = CDate(Now)

                TablaProducto.Rows.Add(RenglonAInsertar)
            Else

            End If
        Next
        Session("TablaProducto") = TablaProducto
        Session("VistaProducto") = VistaProducto
        GVProductos.DataSource = VistaProducto
        GVProductos.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVProductos.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProducto.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProducto.Rows(Index).Item("Precio")
        Next
        wucConsultarProducto1.RegresarFoco()
    End Sub
    Public Sub Nuevo()
        TBIdProveedor.Text = ""
        TBEquivalencia.Text = ""
        TBRazonSocial.Text = ""
        TBRFC.Text = ""
        TBPrimerNombre.Text = ""
        TBSegundoNombre.Text = ""
        TBApellidoPaterno.Text = ""
        TBApellidoMaterno.Text = ""
        TBObservaciones.Text = ""
        TBLimiteCredito.Text = ""
        TBPrecio.Text = ""
        DDEstado.SelectedIndex = 0
        'wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False

        '----------------Contacto----------------
        DDTipoContacto.SelectedIndex = 0
        TBContacto.Text = ""
        '----------------Domicilio----------------

        TBCalle.Text = ""
        TBDomicilioNumeroExterior.Text = ""
        TBDomicilioNumeroInterior.Text = ""

        TBDomicilioCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedIndex = 0
        DDDomMunicipio.SelectedIndex = 0
        '----------------Producto----------------
        'TBIdProducto.Text = ""

        '----------------Para limpiar los Gridview ----------------
        LimpiarTablas()
    End Sub
    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle


        TablaContacto.Rows.Clear()
        VistaContacto.Table.Rows.Clear()
        GVMedio.DataBind()
        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        ControlesContacto(False)

        TablaDireccion.Rows.Clear()
        VistaDireccion.Table.Rows.Clear()
        GVDomicilio.DataBind()
        Session("TablaDireccion") = TablaDireccion
        Session("VistaDireccion") = VistaDireccion


        TablaProducto.Rows.Clear()
        VistaProducto.Table.Rows.Clear()
        GVProductos.DataBind()
        Session("TablaProducto") = TablaProducto
        Session("VistaProducto") = VistaProducto



    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioProveedor As New Negocio.Proveedor()
        Dim EntidadProveedor As New Entidad.Proveedor()
        EntidadProveedor.TablaProducto = TablaProducto
        EntidadProveedor.TablaContacto = TablaContacto
        EntidadProveedor.IdProveedor = IIf(TBIdProveedor.Text Is String.Empty, 0, TBIdProveedor.Text)
        EntidadProveedor.Equivalencia = TBEquivalencia.Text.ToUpper
        EntidadProveedor.IdTipoPersona = 2
        EntidadProveedor.RazonSocial = TBRazonSocial.Text.ToUpper
        EntidadProveedor.PrimerNombre = TBPrimerNombre.Text.ToUpper
        EntidadProveedor.SegundoNombre = TBSegundoNombre.Text.ToUpper
        EntidadProveedor.ApellidoPaterno = TBApellidoPaterno.Text.ToUpper
        EntidadProveedor.ApellidoMaterno = TBApellidoMaterno.Text.ToUpper
        EntidadProveedor.RFC = TBRFC.Text.ToUpper
        EntidadProveedor.Observacion = TBObservaciones.Text.ToUpper
        EntidadProveedor.LimiteCredito = IIf(TBLimiteCredito.Text Is String.Empty, 0, TBLimiteCredito.Text)
        EntidadProveedor.IdEstado = DDEstado.SelectedValue

        EntidadProveedor.TablaDireccion = TablaDireccion

        NegocioProveedor.Guardar(EntidadProveedor)
        TBIdProveedor.Text = EntidadProveedor.IdProveedor
        Nuevo()
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioProveedor As New Negocio.Proveedor()
        Dim EntidadProveedor As New Entidad.Proveedor()
        Dim Tabla As New DataTable
        
        EntidadProveedor.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioProveedor.Consultar(EntidadProveedor)
        Tabla = EntidadProveedor.TablaConsulta
        GVProveedor.Columns.Clear()
        GVProveedor.DataSource = Tabla
        GVProveedor.AutoGenerateColumns = False
        GVProveedor.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Eliminar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVProveedor.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Razon Social", "RazonSocial")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Representante", "Representante")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Estado", "Estado")
        GVProveedor.DataBind()
        Session("Tabla") = Tabla
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVProveedor.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim TablaDetalle As New DataTable
        Dim NegocioProveedor As New Negocio.Proveedor()
        Dim EntidadPersona As New Entidad.Proveedor()
        Tabla = Session("Tabla")
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        EntidadPersona.IdProveedor = Tabla.Rows(GVProveedor.SelectedIndex).Item("ID")
        NegocioProveedor.Consultar(EntidadPersona)
        TablaDetalle = EntidadPersona.TablaConsulta
        TBIdProveedor.Text = TablaDetalle.Rows(0).Item("ID")
        TBEquivalencia.Text = TablaDetalle.Rows(0).Item("Equivalencia")
        TBRazonSocial.Text = TablaDetalle.Rows(0).Item("RazonSocial")
        TBRFC.Text = TablaDetalle.Rows(0).Item("RFC")
        TBPrimerNombre.Text = TablaDetalle.Rows(0).Item("PrimerNombre")
        TBSegundoNombre.Text = TablaDetalle.Rows(0).Item("SegundoNombre")
        TBApellidoPaterno.Text = TablaDetalle.Rows(0).Item("ApellidoPaterno")
        TBApellidoMaterno.Text = TablaDetalle.Rows(0).Item("ApellidoMaterno")
        TBLimiteCredito.Text = CDbl(TablaDetalle.Rows(0).Item("LimiteCredito"))
        TBObservaciones.Text = TablaDetalle.Rows(0).Item("Observacion")
        DDEstado.SelectedValue = TablaDetalle.Rows(0).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(TablaDetalle.Rows(0))

        '========================================Contacto============================================
        Dim TablaContacto As New DataTable()
        NegocioProveedor.Obtener(EntidadPersona)
        TablaContacto = EntidadPersona.TablaContacto
        VistaContacto = TablaContacto.DefaultView
        VistaContacto.RowFilter = "idEstado=1"

        Session("TablaContacto") = TablaContacto
        Session("VistaContacto") = VistaContacto
        GVMedio.DataSource = VistaContacto
        GVMedio.DataBind()

        ControlesContacto(False)
        '========================================Domicilio============================================
        Dim TablaDireccion As New DataTable()

        TablaDireccion = EntidadPersona.TablaDireccion
        VistaDireccion = TablaDireccion.DefaultView
        VistaDireccion.RowFilter = "idEstado=1"

        Session("TablaDireccion") = TablaDireccion
        Session("VistaDireccion") = VistaDireccion
        GVDomicilio.DataSource = VistaDireccion
        GVDomicilio.DataBind()

        PanelDomicilio.Visible = False
        GVDomicilio.Visible = True

        '========================================Producto============================================
        Dim TablaProducto As New DataTable()

        TablaProducto = EntidadPersona.TablaProducto
        VistaProducto = TablaProducto.DefaultView
        VistaProducto.RowFilter = "idEstado=1"

        Session("TablaProducto") = TablaProducto
        Session("VistaProducto") = VistaProducto
        GVProductos.DataSource = VistaProducto
        GVProductos.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVProductos.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProducto.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProducto.Rows(Index).Item("Precio")
        Next
        MultiView1.SetActiveView(View1)
    End Sub
#Region "LOL"


#Region "Contacto========================================================================="
    Protected Sub BTNMedio_Click(sender As Object, e As EventArgs) Handles BTNMedio.Click
        TBIdMedio.Text = 0
        TBIdMedio.Visible = False
        DDTipoContacto.SelectedIndex = 0
        ControlesContacto(True)
    End Sub

    Protected Sub BTNCancelarMedio_Click(sender As Object, e As EventArgs) Handles BTNCancelarMedio.Click
        TBIdMedio.Text = ""
        DDTipoContacto.SelectedIndex = 0
        TBContacto.Text = ""
        ControlesContacto(False)
    End Sub

    Protected Sub BTNAceptarMedio_Click(sender As Object, e As EventArgs) Handles BTNAceptarMedio.Click
        TablaContacto = Session("TablaContacto")
        VistaContacto = Session("VistaContacto")
        Dim EntidadProveedor As New Entidad.Proveedor()
        Dim bandera As Boolean = True
        For Each fila As DataRow In TablaContacto.Rows
            If fila.Item("IdTipoContacto").ToString() = DDTipoContacto.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next
        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaContacto.NewRow()
            RenglonAInsertar("IdProveedorContacto") = Int32.Parse(TBIdMedio.Text)
            RenglonAInsertar("IdTipoContacto") = DDTipoContacto.SelectedValue
            RenglonAInsertar("Contacto") = TBContacto.Text.ToUpper()
            RenglonAInsertar("TipoContacto") = DDTipoContacto.SelectedItem.Text
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

            DDTipoContacto.SelectedIndex = 0
            TBIdMedio.Text = ""
            TBContacto.Text = ""
            ControlesContacto(False)
        End If
    End Sub
    Protected Sub GVMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVMedio.SelectedIndexChanged
        PanelMedio.Visible = True
        Dim TablaContacto As New DataTable
        TablaContacto = Session("TablaContacto")
        TBIdMedio.Text = TablaContacto.Rows(GVMedio.SelectedIndex).Item("IdProveedorContacto")
        DDTipoContacto.SelectedValue = TablaContacto.Rows(GVMedio.SelectedIndex).Item("IdTipoContacto")
        TBContacto.Text = TablaContacto.Rows(GVMedio.SelectedIndex).Item("Contacto")
        ControlesContacto(True)
    End Sub

    Protected Sub BTNActualizarMedio_Click(sender As Object, e As EventArgs) Handles BTNActualizarMedio.Click
        TablaContacto = Session("TablaContacto")
        VistaContacto = Session("VistaContacto")
        'actualizar renglon
        Dim Renglon As Integer = GVMedio.SelectedIndex
        VistaContacto(Renglon).Item("IdProveedorContacto") = Int32.Parse(TBIdMedio.Text)
        VistaContacto(Renglon).Item("IdTipoContacto") = DDTipoContacto.SelectedValue
        VistaContacto(Renglon).Item("Contacto") = TBContacto.Text.ToUpper()
        VistaContacto(Renglon).Item("TipoContacto") = DDTipoContacto.SelectedItem.Text
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
        If VistaContacto(Renglon).Item("IdProveedorContacto") = 0 Then
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

        TBCalle.Text = ""
        TBDomicilioNumeroExterior.Text = ""
        TBDomicilioNumeroInterior.Text = ""

        TBDomicilioCodigoPostal.Text = ""
        DDPais.SelectedIndex = 0
        DDEntidadFederativa.SelectedValue = 8
        DDDomMunicipio.SelectedIndex = 20

        DDDomColonia.SelectedIndex = 0
        TBIdDomicilio.Visible = False
        ControlesDomicilio(True)
    End Sub
    Protected Sub BTNAceptarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNAceptarDomicilio.Click
        TablaDireccion = Session("TablaDireccion")
        VistaDireccion = Session("VistaDireccion")
        Dim EntidadPersona As New Entidad.Proveedor()
        Dim bandera As Boolean = True
        If bandera Then
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaDireccion.NewRow()
            RenglonAInsertar("IdProveedorDomicilio") = TBIdDomicilio.Text

            RenglonAInsertar("Calle") = TBCalle.Text
            RenglonAInsertar("IdPais") = DDPais.SelectedValue
            RenglonAInsertar("Pais") = DDPais.SelectedItem.Text
            RenglonAInsertar("IdEntidadFederativa") = DDEntidadFederativa.SelectedValue
            RenglonAInsertar("EntidadFederativa") = DDEntidadFederativa.SelectedItem.Text
            RenglonAInsertar("IdMunicipio") = DDDomMunicipio.SelectedValue
            RenglonAInsertar("Municipio") = DDDomMunicipio.SelectedItem.Text
            RenglonAInsertar("IdLocalidad") = 1 'DDDomLocalidad.SelectedValue
            'RenglonAInsertar("Localidad") = 1
            RenglonAInsertar("IdColonia") = DDDomColonia.SelectedValue
            RenglonAInsertar("Colonia") = DDDomColonia.SelectedItem.Text
            RenglonAInsertar("NumeroExterior") = TBDomicilioNumeroExterior.Text
            RenglonAInsertar("NumeroInterior") = TBDomicilioNumeroInterior.Text
            RenglonAInsertar("CP") = TBDomicilioCodigoPostal.Text

            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = 1
            RenglonAInsertar("idActualizar") = 1
            TablaDireccion.Rows.Add(RenglonAInsertar)

            Session("TablaDireccion") = TablaDireccion
            Session("VistaDireccion") = VistaDireccion
            GVDomicilio.DataSource = VistaDireccion
            GVDomicilio.DataBind()

            'limpiar Identificacion

            TBIdDomicilio.Text = ""
            TBCalle.Text = ""
            TBDomicilioNumeroExterior.Text = ""
            TBDomicilioNumeroInterior.Text = ""
            TBDomicilioCodigoPostal.Text = ""
            DDPais.SelectedIndex = 0
            DDEntidadFederativa.SelectedIndex = 0
            DDDomMunicipio.SelectedIndex = 0
            'DDDomLocalidad.SelectedIndex = 0
            DDDomColonia.SelectedIndex = 0
            ControlesDomicilio(False)
        End If
    End Sub
    Protected Sub BTNActualizarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNActualizarDomicilio.Click
        TablaDireccion = Session("TablaDireccion")
        VistaDireccion = Session("VistaDireccion")

        Dim Renglon As Integer = GVDomicilio.SelectedIndex
        VistaDireccion(Renglon).Item("IdProveedorDomicilio") = TBIdDomicilio.Text
        VistaDireccion(Renglon).Item("Calle") = TBCalle.Text
        VistaDireccion(Renglon).Item("NumeroExterior") = TBDomicilioNumeroExterior.Text
        VistaDireccion(Renglon).Item("NumeroInterior") = TBDomicilioNumeroInterior.Text
        VistaDireccion(Renglon).Item("CP") = TBDomicilioCodigoPostal.Text
        VistaDireccion(Renglon).Item("Pais") = DDPais.SelectedItem.Text
        VistaDireccion(Renglon).Item("EntidadFederativa") = DDEntidadFederativa.SelectedItem.Text
        VistaDireccion(Renglon).Item("Municipio") = DDDomMunicipio.SelectedItem.Text
        'VistaDireccion(Renglon).Item("Localidad") = 1 'DDDomLocalidad.SelectedValue
        VistaDireccion(Renglon).Item("Colonia") = DDDomColonia.SelectedItem.Text
        VistaDireccion(Renglon).Item("IdEstado") = 1
        VistaDireccion(Renglon).Item("idActualizar") = 1 'Si   

        Session("TablaDireccion") = TablaDireccion
        Session("VistaDireccion") = VistaDireccion
        GVDomicilio.DataSource = VistaDireccion
        GVDomicilio.DataBind()

        'limpiar controles 
        TBIdDomicilio.Text = 0

        TBCalle.Text = ""
        TBDomicilioNumeroExterior.Text = ""
        TBDomicilioNumeroInterior.Text = ""

        TBDomicilioCodigoPostal.Text = ""
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

        TablaDireccion = Session("TablaDireccion")
        VistaDireccion = Session("VistaDireccion")

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

        TBIdDomicilio.Text = VistaDireccion(Renglon).Item("IdProveedorDomicilio")

        TBCalle.Text = VistaDireccion(Renglon).Item("Calle")
        TBDomicilioNumeroExterior.Text = VistaDireccion(Renglon).Item("NumeroExterior")
        TBDomicilioNumeroInterior.Text = VistaDireccion(Renglon).Item("NumeroInterior")
        TBDomicilioCodigoPostal.Text = VistaDireccion(Renglon).Item("CP")
        DDPais.SelectedValue = VistaDireccion(Renglon).Item("IdPais")
        DDEntidadFederativa.SelectedValue = VistaDireccion(Renglon).Item("IdEntidadFederativa")
        DDDomMunicipio.SelectedValue = VistaDireccion(Renglon).Item("IdMunicipio")
        'DDDomLocalidad.SelectedValue = VistaDireccion(Renglon).Item("Localidad")
        DDDomColonia.SelectedValue = VistaDireccion(Renglon).Item("IdColonia")

        ControlesDomicilio(True)
        TBIdDomicilio.Visible = False
    End Sub
    Protected Sub BTNEliminarDomicilio_Click(sender As Object, e As EventArgs) Handles BTNEliminarDomicilio.Click
        TablaDireccion = Session("TablaDireccion")
        VistaDireccion = Session("VistaDireccion")

        'actualizar renglon
        Dim Renglon As Integer = GVDomicilio.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaDireccion(Renglon).Item("IdProveedorDomicilio") = 0 Then
            VistaDireccion(Renglon).Delete()
        Else
            VistaDireccion(Renglon).Item("idActualizar") = 1 'Si   
            VistaDireccion(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        Session("TablaDireccion") = TablaDireccion
        Session("VistaDireccion") = VistaDireccion
        GVDomicilio.DataSource = VistaDireccion
        GVDomicilio.DataBind()

        ControlesDomicilio(False)
    End Sub
    Protected Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNCancelar.Click
        TBIdDomicilio.Text = 0

        TBCalle.Text = ""
        TBDomicilioNumeroExterior.Text = ""
        TBDomicilioNumeroInterior.Text = ""

        TBDomicilioCodigoPostal.Text = ""
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
#Region "sin utilizar"
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
        TBDomicilioCodigoPostal.Text = ""
    End Sub

    'Protected Sub DDDomLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDDomLocalidad.SelectedIndexChanged

    'End Sub
#End Region

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
        TBDomicilioCodigoPostal.Text = TablaColonia.Rows(0).Item("CodigoPostal")
        DDDomMunicipio.SelectedIndex = (TablaColonia.Rows(0).Item("IdMunicipio") - 1)
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
        GVProveedor.Columns.Clear()
        GVProveedor.DataSource = Tabla
        GVProveedor.AutoGenerateColumns = False
        GVProveedor.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVProveedor.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "ID Cliente", "Id")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Nombre Cliente", "NombreCliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Fecha Nacimiento", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Estado", "TipoEstado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Genero", "Genero")
        GVProveedor.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub TBDomicilioCodigoPostal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TablaColonia As New DataTable
        Dim NegocioColonia As New Negocio.Colonia()
        Dim EntidadColonia As New Entidad.Colonia()
        EntidadColonia.CPColonia = TBDomicilioCodigoPostal.Text
        EntidadColonia.IdColonia = DDDomColonia.SelectedValue
        EntidadColonia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioColonia.Consultar(EntidadColonia)
        TablaColonia = EntidadColonia.TablaConsulta
        DDDomColonia.DataSource = TablaColonia
        DDDomColonia.DataValueField = "ID"
        DDDomColonia.DataTextField = "Descripcion"
        DDDomColonia.DataBind()
        DDDomMunicipio.SelectedValue = TablaColonia.Rows(0).Item("IdMunicipio")
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub

    Protected Sub BTNProducto_Click(sender As Object, e As EventArgs) Handles BTNProducto.Click
        wucConsultarProducto1.Visible = True
        'TBIdProducto.Text = 0
        TBPrecio.Text = 0
        BTNAceptarProducto.Enabled = True
        'BTNEliminarProducto.Enabled = False
        ' BTNActualizarProducto.Enabled = False
        ControlesProducto(True)
    End Sub
    Private Sub ControlesProducto(control As Boolean)
        If control Then
            Productos.Visible = True
            GVProductos.Visible = True
        Else
            Productos.Visible = False
            GVProductos.Visible = True
        End If
    End Sub
    'Protected Sub BTNCancelarProducto_Click(sender As Object, e As EventArgs) Handles BTNCancelarProducto.Click
    '    wucConsultarProducto1.AsignarProducto(0, 0, "")
    '    TBPrecio.Text = "0"
    '    TBIdProducto.Text = 0
    '    ControlesProducto(True)
    'End Sub
    'Protected Sub BTNEliminarProducto_Click(sender As Object, e As EventArgs) Handles BTNEliminarProducto.Click
    '    TablaProducto = Session("TablaProducto")
    '    VistaProducto = Session("VistaProducto")

    '    'actualizar renglon
    '    Dim Renglon As Integer = GVProductos.SelectedIndex
    '    'si es nuevo eliminar del datatable
    '    If VistaProducto(Renglon).Item("IdProveedor_Producto") = 0 Then
    '        VistaProducto(Renglon).Delete()
    '    Else
    '        VistaProducto(Renglon).Item("idActualizar") = 1 'Si   
    '        VistaProducto(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
    '    End If

    '    Session("TablaProducto") = TablaProducto
    '    Session("VistaProducto") = VistaProducto
    '    GVProductos.DataSource = VistaProducto
    '    GVProductos.DataBind()
    '    wucConsultarProducto1.AsignarProducto(0, 0, "")
    '    TBPrecio.Text = "0"
    '    TBIdProducto.Text = 0
    '    ControlesProducto(True)
    'End Sub
    Protected Sub BTNAceptarProducto_Click(sender As Object, e As EventArgs) Handles BTNAceptarProducto.Click
        'TablaProducto = Session("TablaProducto")
        'VistaProducto = Session("VistaProducto")
        'Dim bandera As Boolean = True
        'If bandera Then
        '    Dim IdProducto = 0
        '    Dim IdProductoCorto = ""
        '    Dim Descripcion = ""

        '    wucConsultarProducto1.ObtenerProducto(IdProducto, IdProductoCorto, Descripcion)
        '    Dim RenglonAInsertar As DataRow
        '    RenglonAInsertar = TablaProducto.NewRow()


        '    RenglonAInsertar("IdProveedor_Producto") = Int32.Parse(TBIdProducto.Text)
        '    RenglonAInsertar("IdProducto") = IdProducto
        '    RenglonAInsertar("IdProductoCorto") = IdProductoCorto
        '    RenglonAInsertar("Producto") = Descripcion
        '    RenglonAInsertar("Precio") = CType(TBPrecio.Text, Double)
        '    RenglonAInsertar("IdEstado") = 1
        '    RenglonAInsertar("IdActualizar") = 1
        '    RenglonAInsertar("IdUsuarioCreacion") = 1
        '    RenglonAInsertar("FechaCreacion") = CDate(Now)
        '    RenglonAInsertar("IdUsuarioActualizacion") = 1
        '    RenglonAInsertar("FechaActualizacion") = CDate(Now)

        '    TablaProducto.Rows.Add(RenglonAInsertar)

        '    Session("TablaProducto") = TablaProducto
        '    Session("VistaProducto") = VistaProducto
        '    GVProductos.DataSource = VistaProducto
        '    GVProductos.DataBind()

        '    'limpiar Identificacion
        '    wucConsultarProducto1.AsignarProducto(0, 0, "")
        '    TBPrecio.Text = ""
        '    TBIdProducto.Text = ""
        'End If
        'ControlesProducto(True)
        wucConsultarProducto1.Nuevo()
        wucConsultarProducto1.RegresarFoco()
    End Sub
    Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        'GVCompraDetalle.SelectedIndex = gvrFilaActual.RowIndex

        'TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)

        'wucConsultarProducto1.AsignarProducto(CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdProducto"), Integer),
        '                                      CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdProductoCorto"), String),
        '                                       CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("Producto"), String))



        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVProductos.SelectedIndex = gvrFilaActual.RowIndex

        TablaProducto = CType(Session("TablaProducto"), DataTable)

        wucConsultarProducto1.AsignarProducto(CType(TablaProducto.Rows(GVProductos.SelectedIndex).Item("IdProducto"), Integer),
                                              CType(TablaProducto.Rows(GVProductos.SelectedIndex).Item("IdProductoCorto"), String),
                                               CType(TablaProducto.Rows(GVProductos.SelectedIndex).Item("Producto"), String))

        ' TBCantidadDetalle.Text = CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("Cantidad"), String)
        'TBPrecioUnitario.Text = CDbl(CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("PrecioUnitario"), String))
        ' DDAlmacen.SelectedValue = CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdAlmacen"), String)

        BTNAceptarProducto.Enabled = True
        'BTNEliminarProducto.Enabled = True
        ' BTNActualizarProducto.Enabled = True

        ControlesProducto(True)
    End Sub

    'Protected Sub GVProductos_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GVProductos.SelectedIndexChanged
    '    Productos.Visible = True
    '    Dim TablaProductos As New DataTable
    '    TablaProductos = Session("TablaProducto")
    '    TBIdProducto.Text = TablaProductos.Rows(GVProductos.SelectedIndex).Item("IdProveedor_Producto")
    '    wucConsultarProducto1.AsignarProducto(CType(TablaProductos.Rows(GVProductos.SelectedIndex).Item("IdProducto"), Integer),
    '                                          CType(TablaProductos.Rows(GVProductos.SelectedIndex).Item("IdProductoCorto"), String),
    '                                           CType(TablaProductos.Rows(GVProductos.SelectedIndex).Item("Producto"), String))
    '    TBPrecio.Text = TablaProductos.Rows(GVProductos.SelectedIndex).Item("Precio")

    '    BTNAceptarProducto.Enabled = True
    '    BTNEliminarProducto.Enabled = True
    '    BTNActualizarProducto.Enabled = True
    '    ControlesProducto(True)
    'End Sub
    'Protected Sub BTNActualizarProducto_Click(sender As Object, e As EventArgs) Handles BTNActualizarProducto.Click
    '    TablaProducto = Session("TablaProducto")
    '    VistaProducto = Session("VistaProducto")


    '    Dim IdProducto = 0
    '    Dim IdProductoCorto = ""
    '    Dim Descripcion = ""

    '    wucConsultarProducto1.ObtenerProducto(IdProducto, IdProductoCorto, Descripcion)
    '    Dim Renglon As Integer = GVProductos.SelectedIndex
    '    VistaProducto(Renglon).Item("IdProducto") = IdProducto
    '    VistaProducto(Renglon).Item("IdProductoCorto") = IdProductoCorto
    '    VistaProducto(Renglon).Item("Producto") = Descripcion
    '    VistaProducto(Renglon).Item("Precio") = CType(TBPrecio.Text, Double)
    '    VistaProducto(Renglon).Item("IdEstado") = 1
    '    VistaProducto(Renglon).Item("idActualizar") = 1 'Si

    '    Session("TablaProducto") = TablaProducto
    '    Session("VistaProducto") = VistaProducto
    '    GVProductos.DataSource = VistaProducto
    '    GVProductos.DataBind()

    '    'limpiar controles 
    '    TBPrecio.Text = 0

    '    ControlesProducto(True)

    'End Sub
    Protected Sub GVIPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaProducto = CType(Session("TablaProducto"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBPrecio1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBPrecio1.Text) Then
            If TBPrecio1.Text > 0 Then

            Else
                TBPrecio1.Text = 1
            End If
            actualizarrenglon(TablaProducto, index, TBPrecio1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVProductos.Rows(index)
            Dim NuevoRow As DataRow = TablaProducto.NewRow()
            CType(MiDataRow.FindControl("TBGVPrecio"), TextBox).Text = TablaProducto.Rows(index).Item("Precio")
        End If

        Session("TablaProducto") = TablaProducto
        Session("VistaProducto") = VistaProducto
        GVProductos.DataSource = VistaProducto
        GVProductos.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVProductos.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProducto.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProducto.Rows(Index2).Item("Precio")
        Next
    End Sub
    Private Sub actualizarrenglon(ByRef TablaProducto As DataTable, ByVal index As Integer, ByVal Precio1 As Double)
        Dim precio As Double = TablaProducto.Rows(index).Item("Precio")
        If Precio1 > 0 Then
            TablaProducto.Rows(index).Item("Precio") = Precio1
            TablaProducto.Rows(index).Item("idActualizar") = 1
            TablaProducto.Rows(index).Item("IdEstado") = 1
            TablaProducto.AcceptChanges()
        Else
            TablaProducto.Rows(index).Item("Precio") = precio
            TablaProducto.AcceptChanges()
        End If
    End Sub
    Protected Sub BTNEliminarProducto_Click1(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex

        TablaProducto = Session("TablaProducto")
        VistaProducto = Session("VistaProducto")

        ''actualizar renglon
        ''Dim Renglon As Integer = GVSolicitudDetalle.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If VistaProducto(Renglon).Item("IdProveedor_Producto") = 0 Then
                VistaProducto(Renglon).Delete()
            Else
                VistaProducto(Renglon).Item("idActualizar") = 1 'Si   
                VistaProducto(Renglon).Item("IdEstado") = 2
            End If

            Session("TablaProducto") = TablaProducto
            Session("VistaProducto") = VistaProducto


            GVProductos.DataSource = VistaProducto
            GVProductos.DataBind()
            Dim Index As Integer
            For Each MiDataRow2 As GridViewRow In GVProductos.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaProducto.NewRow()
                CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProducto.Rows(Index).Item("Precio")
            Next
        End If
    End Sub
End Class