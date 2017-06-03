Imports System.Data
Imports Operacion.Configuracion.Constante
Imports TipoVenta = Operacion.Configuracion.Constante.TipoVenta
Imports TipoVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Web.Services

' ReSharper disable once CheckNamespace
Partial Class _Default
    Inherits Page
#Region "Variables locales"
    Private Shared _venta As New Entidad.Venta
    Private Shared _calendario As New Entidad.Calendario
    Private Shared _usuario As New Entidad.Usuario
    Private Shared _Periodo As New Entidad.Periodo
    Private Shared ReadOnly _listaPlazos As New ObservableCollection(Of Entidad.TipoPlazo)
    'Private Shared ReadOnly _listaCargos As New ObservableCollection(Of Entidad.Cargo)
    Private Shared ReadOnly _listaPeriodos As New ObservableCollection(Of Entidad.Periodo)
    Private Shared ReadOnly _listaPromocion As New ObservableCollection(Of Entidad.VentaPromocion)
    'Private Shared ReadOnly _listaPersonaDireccion As New ObservableCollection(Of Entidad.PersonaDomicilio)
    Private Shared ReadOnly _listaTipoEntrega As New ObservableCollection(Of Entidad.TipoEntrega)
    Private Shared ReadOnly listaCalculoPlazo As New List(Of Entidad.CalculoPlazo)
    Private Shared _busquedaProducto As New Entidad.Producto
    Private Shared _busquedaAval As Boolean
    Private Shared plazoCreditoManual As Boolean
    Private Shared plazoContadoManual As Boolean
    Private Shared _ventaNueva As Boolean
    'Private Shared _calculaInteresContado As Boolean
    Private Shared _Interes As Entidad.Interes
    Public Shared _cantidadCambio As Integer
    Public Shared _cantidadCodigo As String

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim OrigenVenta As Boolean = False
            OrigenVenta = CBool(Session("OrigenVenta"))
            If OrigenVenta Then 'Si estas siendo redirigido desde registro de cliente
                RecargarVenta()
            Else
                _venta.IdTipoVenta = TipoVenta.Credito
                IniciarVenta()
                MVVenta.SetActiveView(ContenidoPrinicpal)
            End If
        Else
            TabName.Value = Request.Form(TabName.UniqueID)
        End If
        AddHandler wucConPrd.Seleccionado, New EventHandler(AddressOf BusquedaProductoSeleccionado)
        AddHandler wucConPrd.Cancelado, New EventHandler(AddressOf BusquedaProductoCancelado)
        AddHandler WucBuscarPersona1.Seleccionado, New EventHandler(AddressOf BusquedaPersonaSeleccionado)
        AddHandler WucBuscarPersona1.Cancelado, New EventHandler(AddressOf BusquedaProductoCancelado)
        AddHandler WucBuscarVenta.Seleccionado, New EventHandler(AddressOf BusquedaVentaSeleccionado)
        AddHandler WucBuscarVenta.Cancelado, New EventHandler(AddressOf BusquedaProductoCancelado)
        AddHandler WucBuscarVenta.Cancelado, New EventHandler(AddressOf BusquedaProductoCancelado)
        AddHandler WucAviso1.Cancelado, New EventHandler(AddressOf BusquedaProductoCancelado)
        AddHandler WucAviso1.Pendiente, New EventHandler(AddressOf AvisoPendiente)
        Session.Remove("_venta")
        Session.Remove("IdPersona")
        Session.Remove("OrigenVenta")
        Session.Remove("Aval")
    End Sub
    Private Sub RecargarVenta()
        MostrarUsuario()
        ObtenerDatosParametro()
        _venta = Session("_venta")
        NuevaVenta(_venta.IdTipoVenta)
        _venta = Session("_venta")
        CType(Master.FindControl("LBVCambiar"), Label).Text = "- " + _venta.IdTipoVenta.ToString().ToUpper()
        TBLVFolio.Text = "Folio: " + _venta.Folio
        If _venta.FolioFisico.Length > 1 Then
            TBFolio2.Text = _venta.FolioFisico
            LBFolio2.Text = "Folio Fisico: " + _venta.FolioFisico
        End If
        'ClienteNombre(_venta.Persona)
        'ClienteSaldo(_venta.SaldoDisponible)
        'ClienteDomicilio(_venta.DomicilioEntrega)
        'ClienteTelefono(_venta.Identificacion)
        LBPLPlazoContado.Text = _venta.Credito.PlazoContado
        LBPLPlazoCredito.Text = _venta.Credito.PlazoCredito
        LBPeriodo1.Text = _venta.Credito.Periodo
        LBPeriodo2.Text = _venta.Credito.Periodo
        LBXPCEAnticipo.Text = String.Format("{0:c}", _venta.Credito.Anticipo)
        AvalDatos(_venta.Credito.IdAval, _venta.Credito.Aval, _venta.Credito.AvalDomicilio, _venta.Credito.AvalTelefono, 0)

        MostrarProductosVenta()
        DesactivaInteraccion()
        MostrarCargos()
        MostrarBotones()
        ActivaInteraccion()

        For Each detalle In _venta.Detalle
            For Each descuento In From descuento1 In _venta.Descuento Where detalle.IdProducto = descuento1.IdProducto
                detalle.Promocion = descuento.Observacion
            Next
            For Each obsequio In From obsequio1 In _venta.Obsequio Where detalle.IdProducto = obsequio1.IdProducto
                detalle.Promocion = obsequio.Observacion
            Next
        Next

        CalculaTodo()
        If _venta.IdTipoVenta = TipoVenta.Contado Then
            VerVentaContado()
        ElseIf _venta.IdTipoVenta = TipoVenta.Credito Then
            VerVentaCredito()
        ElseIf _venta.IdTipoVenta = TipoVenta.Apartado Then
            VerVentaApartado()
        End If

        If CBool(Session("Aval")) Then
            _venta.Credito.IdAval = CInt(Session("IdPersona"))
        Else
            _venta.IdPersona = CInt(Session("IdPersona"))
        End If
        If _venta.IdPersona > 1 Or _venta.Credito.IdAval > 1 Then
            TBXCodigo.Text = CStr(Session("IdPersona"))
            BuscarPersona()
        End If

        MVVenta.SetActiveView(ContenidoPrinicpal)
        'Session.Remove("_venta")
        'Session.Remove("IdPersona")
        'Session.Remove("OrigenVenta")
        'Session.Remove("Aval")
    End Sub
    Private Sub MostrarUsuario()
        Try
            Dim tarjeta As New Entidad.Tarjeta
            tarjeta = CType(Session("Tarjeta"), Entidad.Tarjeta)

            Dim entidadUsuario As New Entidad.Usuario
            Dim negocioUsuario As New Negocio.Usuario
            entidadUsuario.IdUsuario = tarjeta.IdUsuario
            negocioUsuario.ConsultarVenta(entidadUsuario)

            _usuario.IdUsuario = tarjeta.IdUsuario
            _usuario.PrimerNombre = entidadUsuario.PrimerNombre
            _usuario.SegundoNombre = entidadUsuario.SegundoNombre
            _usuario.ApellidoPaterno = entidadUsuario.ApellidoPaterno
            _usuario.ApellidoMaterno = entidadUsuario.ApellidoMaterno
            _usuario.IdSucursal = tarjeta.IdSucursal
            _usuario.Sucursal = tarjeta.Sucursal
            _usuario.IdAlmacen = 2
            _usuario.Almacen = "MATRIZ"

            CType(Master.FindControl("LBMUsuario"), Label).Text = tarjeta.Username
            CType(Master.FindControl("LBMUsuarioCompleto"), Label).Text = _usuario.PrimerNombre + _usuario.SegundoNombre + _usuario.ApellidoPaterno
            CType(Master.FindControl("LBMUsuarioCorreo"), Label).Text = _usuario.Correo
        Catch ex As Exception
            Response.Redirect("/Account/Login.aspx")
        End Try
    End Sub

    Private Sub IniciarVenta()
        'Este evento se produce despues de logearse
        'Si no se cancelo el seleccionar un tipo de venta se carga nueva venta y se le envia el tipo de la venta
        MostrarUsuario()
        ObtenerDatosParametro()
        Select Case _venta.IdTipoVenta
            Case TipoVenta.Ninguno
                'Salir de la venta
            Case Else
                NuevaVenta(_venta.IdTipoVenta)
                'por ultimo hacemos visible la ventana de venta
        End Select
    End Sub

    Private Sub ObtenerDatosParametro()
        _Periodo = New Entidad.Periodo
        _Periodo.IdPeriodo = 1

        _calendario.IdCalendario = 1
        'Llenar/actualizar tipo calendario
        Dim EntidadTipoCalendario As New Entidad.Calendario()
        Dim NegocioTipoCalendario As New Negocio.Calendario()
        EntidadTipoCalendario.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoCalendario.Consultar(EntidadTipoCalendario)
        Dim TablaPl = EntidadTipoCalendario.TablaConsulta
        Dim listaCalendario As List(Of DataRow) = TablaPl.AsEnumerable().ToList()
        For Each rw As DataRow In listaCalendario
            If _calendario.IdCalendario = rw.ItemArray(0) Then
                _calendario.Descripcion = CStr(rw.ItemArray(1))
                _calendario.Mes = CInt(rw.ItemArray(2))
                _calendario.Ano = CInt(rw.ItemArray(3))
                _calendario.Observacion = CStr(rw.ItemArray(4))
            End If
        Next

        'Dim EntidadParametro As New Entidad.Para()
        'Dim NegocioParametro As New Negocio.Calendario()
        'EntidadTipoCalendario.Tarjeta.Consulta = Consulta.ConsultaBasica
        'NegocioTipoCalendario.Consultar(EntidadTipoCalendario)
        'Dim TablaPl = EntidadTipoCalendario.TablaConsulta
        'Dim listaCalendario As List(Of DataRow) = TablaPl.AsEnumerable().ToList()
        'For Each rw As DataRow In listaCalendario
        '    If _calendario.IdCalendario = rw.ItemArray(0) Then
        '        _calendario.Descripcion = CStr(rw.ItemArray(1))
        '        _calendario.Mes = CInt(rw.ItemArray(2))
        '        _calendario.Ano = CInt(rw.ItemArray(3))
        '        _calendario.Observacion = CStr(rw.ItemArray(4))
        '    End If
        'Next

    End Sub

#Region "Funciones de limpia o reinicio"
    Private Sub NuevaVenta(ByVal PtipoVenta As TipoVenta)
        _venta = New Entidad.Venta()
        _venta.Cargo = New ObservableCollection(Of Entidad.VentaCargo)
        _venta.Descuento = New ObservableCollection(Of Entidad.VentaDescuento)
        _venta.Detalle = New ObservableCollection(Of Entidad.VentaDetalle)
        _venta.Credito = New Entidad.VentaCredito()
        _venta.Obsequio = New ObservableCollection(Of Entidad.VentaObsequio)
        _venta.IdEstado = 1
        _venta.Credito.IdEstado = 1

        _listaPromocion.Clear()
        MostrarPromociones()
        MostrarCargos()

        _ventaNueva = True
        _venta.IdTipoVenta = PtipoVenta
        BTNVReimprimir.Visible = False
        BTNVCancelar.Visible = False
        _busquedaAval = False

        'Condicion si es venta credito
        Select Case PtipoVenta
            Case TipoVenta.Credito
                VerVentaCredito()
                ActualizaLLenaComboxBox()
                ClienteNombre("")
                TBXPCEAnticipo.Text = ""
                TBLPCCOImporte.Text = String.Format("{0:c}", 0)
                TBLPCCRImporte.Text = String.Format("{0:c}", 0)
                TBLPCCOTotal.Text = String.Format("{0:c}", 0)
                TBLPCCRTotal.Text = String.Format("{0:c}", 0)
                TBLPCFInicioCon.Text = Now.Date.ToString("dd/MM/yyyy")
                TBLPCFInicioCre.Text = Now.Date.ToString("dd/MM/yyyy")
                TBLPCFFin.Text = Now.Date.ToString("dd/MM/yyyy")
                TBLPCFFinCorto.Text = Now.Date.ToString("dd/MM/yyyy")
                TBLPCCONoPeriodo.Text = "0"
                TBLPCCRNoPeriodo.Text = "0"
                TBXPCEAnticipo.Text = String.Format("{0:c}", 0)
                LimpiarTotales()
                plazoCreditoManual = False
                plazoContadoManual = False

                If _listaPlazos.Count > 0 Then
                    CBPLPlazoContado.SelectedIndex = 0
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                If _listaPlazos.Count > 0 Then
                    CBPLPlazoCredito.SelectedIndex = 1
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                If _listaPeriodos.Count > 0 Then
                    DDPeriodo1.SelectedIndex = 0
                    DDPeriodo2.SelectedIndex = 0
                    _Periodo = _listaPeriodos(0)
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                ConsultaInteres()
                MostrarPlazosPeriodo()
                CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Credito
            Case TipoVenta.Contado
                VerVentaContado()
                CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Contado
            Case TipoVenta.Apartado
                VerVentaApartado()

                ActualizaLLenaComboxBox()
                ClienteNombre("")
                TBXPCEAnticipo.Text = ""
                TBLPCFInicioCon.Text = Now.Date.ToString("dd/MM/yyyy")
                TBLPCFFinCorto.Text = Now.Date.ToString("dd/MM/yyyy")
                TBXPCEAnticipo.Text = String.Format("{0:c}", 0)
                LimpiarTotales()
                plazoCreditoManual = False
                plazoContadoManual = False

                If _listaPlazos.Count > 0 Then
                    CBPLPlazoContado.SelectedIndex = 0
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                If _listaPlazos.Count > 0 Then
                    CBPLPlazoCredito.SelectedIndex = 1
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                If _listaPeriodos.Count > 0 Then
                    DDPeriodo1.SelectedIndex = 0
                    DDPeriodo2.SelectedIndex = 0
                    _Periodo = _listaPeriodos(0)
                Else
                    'Mostrar mensaje de error al cargar plazos de contado
                End If

                ConsultaInteres()
                MostrarPlazosPeriodo()
                CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Apartado
        End Select

        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False

        ClienteSaldo(0)
        ClienteDomicilio("")
        ClienteTelefono("")
        AvalDatos(0, "", "", "", 0)
        _venta.FolioFisico = ""

        LBPLPlazoContado.Text = ""
        LBPLPlazoCredito.Text = ""
        LBPeriodo1.Text = ""
        LBPeriodo2.Text = ""
        LBXPCEAnticipo.Text = ""

        BTNVReimprimir.Visible = False
        BTNVCancelar.Visible = False
        MostrarProductosVenta()
        ActivaInteraccion()
        TBXCodigo.Focus()
        _venta.IdVentaEstado = TipoVentaEstado.ACTIVO
        TBLEstadoVenta.Text = TipoVentaEstado.ACTIVO.ToString()

        _venta.IdSucursal = _usuario.IdSucursal
        _venta.Sucursal = _usuario.Sucursal
        _venta.IdAlmacen = _usuario.IdAlmacen
        _venta.Almacen = _usuario.Almacen
        _venta.IdVendedor = _usuario.IdUsuario
        _venta.Vendedor = _usuario.PrimerNombre + " " + _usuario.ApellidoPaterno + " " + _usuario.ApellidoMaterno
        GVVentaDetalle.Columns(2).Visible = False
        MostrarBotones()
        GenerarFolio()
        ObtenerCargos()
        TBXCodigo.Text = "1"
        BuscarPersona()
    End Sub

    Private Sub ClienteNombre(texto As String)
        If texto = "" Then
            LNBTNNuevoCliente.Text = " Nuevo"
            LNBTNNuevoClientexs.Text = " Nuevo"
            spnbtnnuevocliente.CssClass = "fa fa-plus"
        Else
            LNBTNNuevoCliente.Text = " Editar"
            LNBTNNuevoClientexs.Text = " Editar"
            spnbtnnuevocliente.CssClass = "fa fa-pencil"
        End If
        TBLCNombre.Text = texto
        TBLCNombrexs.Text = texto
        _venta.Persona = texto
    End Sub

    Private Sub TablaPromociones(tabla As DataTable)
        GVPromociones.DataSource = tabla
        GVPromociones.AutoGenerateColumns = False
        GVPromociones.AllowSorting = False
        GVPromociones.DataBind()
    End Sub

    Private Sub ClienteSaldo(saldo As Double)
        TBLCSaldo.Text = String.Format("{0:c}", saldo)
        TBLCSaldoxs.Text = String.Format("{0:c}", saldo)
        _venta.SaldoDisponible = saldo
    End Sub

    Private Sub ClienteDomicilio(texto As String)
        TBLCDomicilio.Text = texto
        TBLCDomicilioxs.Text = texto
        LBLCDomicilio.Text = texto
        LBLCDomicilioxs.Text = texto
        _venta.DomicilioEntrega = texto
    End Sub

    Private Sub ClienteTelefono(texto As String)
        TBLCTelefono.Text = texto
        TBLCTelefonoxs.Text = texto
        _venta.Identificacion = texto
    End Sub

    Private Sub MostrarBotones()
        If _venta.IdVentaEstado = 6 Or Not _ventaNueva Then

        Else
            If _venta.IdTipoVenta = TipoVenta.Contado Then
                If _venta.Detalle.Count > 0 Then
                    BTNVFinalizar.Visible = True
                    BTNVPendiente.Visible = True
                    'BTNVCancelar.Visible = True
                Else
                    BTNVFinalizar.Visible = False
                    BTNVPendiente.Visible = False
                    ' BTNVCancelar.Visible = False
                End If
            ElseIf _venta.IdTipoVenta = TipoVenta.Credito Or _venta.IdTipoVenta = TipoVenta.Apartado Then
                If _venta.Detalle.Count > 0 And _venta.IdPersona > 1 Then
                    BTNVFinalizar.Visible = True
                    BTNVPendiente.Visible = True
                    ' BTNVCancelar.Visible = True
                Else
                    BTNVFinalizar.Visible = False
                    BTNVPendiente.Visible = False
                    'BTNVCancelar.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub AvalDatos(id As Integer, nombre As String, domicilio As String, telefono As String, saldo As Double)
        LBLANombre.Text = nombre
        LBLANombrexs.Text = nombre
        LBLADomicilio.Text = domicilio
        LBLADomicilioxs.Text = domicilio
        LBLATelefono.Text = telefono
        LBLATelefonoxs.Text = telefono
        LBLASaldo.Text = String.Format("{0:c}", saldo)
        LBLASaldoxs.Text = String.Format("{0:c}", saldo)
        _venta.Credito.IdAval = id
        _venta.Credito.Aval = nombre
        _venta.Credito.AvalDomicilio = domicilio
        _venta.Credito.AvalTelefono = telefono

        If nombre = "" Then
            LNBTNNuevoAval.Text = " Nuevo"
            LNBTNNuevoAvalxs.Text = " Nuevo"
            spnbtnnuevoaval.CssClass = "fa fa-plus"
        Else
            LNBTNNuevoAval.Text = " Editar"
            LNBTNNuevoAvalxs.Text = " Editar"
            spnbtnnuevoaval.CssClass = "fa fa-pencil"
        End If
    End Sub

    Private Sub ConsultaInteres()
        _Interes = New Entidad.Interes()
        Try
            Dim EntidadInteres As New Entidad.Interes()
            Dim NegocioInteres As New Negocio.Interes()
            EntidadInteres.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioInteres.Consultar(EntidadInteres)
            _Interes.Interes = CDbl(EntidadInteres.TablaConsulta.Rows(0).Item("Impuesto"))
            _Interes.IVA = CDbl(EntidadInteres.TablaConsulta.Rows(1).Item("Impuesto"))

        Catch ex As Exception
            _Interes.Interes = 0
            _Interes.IVA = 0
        End Try
    End Sub
#End Region

    Private Sub MostrarProductosVenta()
        Try
            'Dim ind = 0
            'For Each MiDataRow As GridViewRow In GVVentaDetalle.Rows
            '    If _venta.Detalle(ind).DescuentoCredito > 0 Then
            '        CType(MiDataRow.FindControl("LBTotal"), Label).Visible = False
            '    End If
            '    ind += 1
            'Next

            Dim cantidad = _venta.Detalle.Sum(Function(producto) producto.Cantidad)
            LBVentaDetalleProductos.Text = "Productos: " + cantidad.ToString()
            LBVentaDetalleProductosxs.Text = cantidad.ToString()
            GVVentaDetalle.DataSource = _venta.Detalle
            GVVentaDetalle.DataBind()
        Catch ex As Exception
            LBVentaDetalleProductos.Text = "Productos: 0"
            LBVentaDetalleProductosxs.Text = "0"
            GVVentaDetalle.DataSource = Nothing
            GVVentaDetalle.DataBind()
        End Try
    End Sub
    Private Sub MostrarPlazosPeriodo()
        Try
            CBPLPlazoCredito.DataSource = _listaPlazos
            CBPLPlazoCredito.DataBind()
            CBPLPlazoContado.DataSource = _listaPlazos
            CBPLPlazoContado.DataBind()

            DDPeriodo1.DataSource = _listaPeriodos
            DDPeriodo1.DataBind()
            DDPeriodo2.DataSource = _listaPeriodos
            DDPeriodo2.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ActualizaVentaDetalle(index As Integer)
        'Obtenemos la cantidad del producto detalle
        Dim cantidad = _venta.Detalle(index).Cantidad
        '' If _venta.IdTipoVenta = TipoVenta.Credito Then
        ''=================================================== CREDITO ==================================================================================================================
        'la siguiente bandera se usa para saber si el producto actual es de obsequio o tiene cantidad de obsequio
        Dim cargoObsequio As Double = 0
        'Obtenemos el total de cargo que se le va a sumar al producto que da el obsequio
        For i = 0 To _venta.Obsequio.Count - 1
            If _venta.Obsequio(i).IdProducto = _venta.Detalle(index).IdProducto Then
                For j = 0 To _venta.Obsequio(i).Detalle.Count - 1
                    cargoObsequio += _venta.Obsequio(i).Detalle(j).Total
                Next
                _venta.Obsequio(i).Cargo = cargoObsequio
            End If
        Next

        Dim cantidadObsequio = 0
        For i = 0 To _venta.Obsequio.Count - 1
            For j = 0 To _venta.Obsequio(i).Detalle.Count - 1
                If _venta.Obsequio(i).Detalle(j).IdProducto = _venta.Detalle(index).IdProducto Then
                    cantidadObsequio += _venta.Obsequio(i).Detalle(j).CantidadRegalada
                End If
            Next
        Next

        Dim quitar = False
        If _venta.IdTipoVenta = TipoVenta.Apartado Then
            If cantidadObsequio > 0 Then
                QuitarObsequio(index)
                quitar = True
            End If
        End If
        If Not quitar Then
            _venta.Detalle(index).DescuentoContado = 0
            _venta.Detalle(index).DescuentoCredito = 0
            _venta.Detalle(index).DescuentoPorcentaje = 0

            If _venta.IdTipoVenta = TipoVenta.Credito Then
                _venta.Detalle(index).SubtotalContado = ((cantidad - cantidadObsequio) * _venta.Detalle(index).PrecioContado) + cargoObsequio
                _venta.Detalle(index).SubtotalCredito = ((cantidad - cantidadObsequio) * _venta.Detalle(index).PrecioCredito) + cargoObsequio
            Else
                _venta.Detalle(index).SubtotalCredito = ((cantidad - cantidadObsequio) * _venta.Detalle(index).PrecioBase) + cargoObsequio
            End If
            For i = 0 To _venta.Descuento.Count - 1
                If _venta.Descuento(i).IdProducto = _venta.Detalle(index).IdProducto Then
                    If _venta.Descuento(i).Descuento > 0 Or _venta.Descuento(i).DescuentoPorcentaje > 0 Then
                        If _venta.Descuento(i).IdTipoDescuento = 0 Then
                            _venta.Detalle(index).DescuentoCredito = CInt(_venta.Descuento(i).Descuento)
                            _venta.Detalle(index).DescuentoContado = CInt(_venta.Descuento(i).Descuento)
                            _venta.Detalle(index).DescuentoPorcentaje = (_venta.Descuento(i).Descuento * 100) / _venta.Detalle(index).SubtotalCredito
                        Else
                            _venta.Detalle(index).DescuentoCredito = CInt((_venta.Descuento(i).DescuentoPorcentaje * _venta.Detalle(index).SubtotalCredito) / 100)
                            _venta.Detalle(index).DescuentoContado = CInt((_venta.Descuento(i).DescuentoPorcentaje * _venta.Detalle(index).SubtotalContado) / 100)
                            _venta.Detalle(index).DescuentoPorcentaje = _venta.Descuento(i).DescuentoPorcentaje

                            If _venta.IdTipoVenta = TipoVenta.Credito Then
                                _venta.Descuento(i).Descuento = CInt((_venta.Descuento(i).DescuentoPorcentaje * _venta.Detalle(index).SubtotalCredito) / 100)
                            Else
                                _venta.Descuento(i).Descuento = CInt((_venta.Descuento(i).DescuentoPorcentaje * _venta.Detalle(index).SubtotalContado) / 100)
                            End If
                        End If
                    End If
                End If
            Next

            _venta.Detalle(index).TotalCredito = CInt(_venta.Detalle(index).SubtotalCredito)
            _venta.Detalle(index).TotalContado = CInt(_venta.Detalle(index).SubtotalContado)
        End If
    End Sub

    Private Function AgregaFilaVenta() As Entidad.VentaDetalle
        'Declaramos el objeto de venta detalle llamado fila
        Dim Fila As New Entidad.VentaDetalle
        'Llenamos o inicializamos fila y tambien _ventaCredito.VentaDetalle
        Fila.IdProducto = _busquedaProducto.IdProducto
        Fila.IdProductoCorto = _busquedaProducto.IdProductoCorto
        Fila.Producto = _busquedaProducto.Descripcion
        Fila.PrecioBase = _busquedaProducto.PrecioBase
        Fila.CantidadInventario = _busquedaProducto.Cantidad
        Fila.Cantidad = 1
        Fila.DescuentoPorcentaje = 0
        Fila.DescuentoContado = 0
        Fila.DescuentoCredito = 0
        Fila.Ganancia = _busquedaProducto.Ganancia
        Fila.TotalContado = Fila.PrecioBase
        Fila.SubtotalContado = Fila.PrecioBase
        Fila.IdAlmacen = _busquedaProducto.IdAlmacen
        Fila.Almacen = _busquedaProducto.Almacen
        Fila.VentaExistenciaCero = _busquedaProducto.VentaExistenciaCero
        Fila.IdEstado = 1
        Return Fila
    End Function

    Private Sub SeleccionarBusqueda()
        'Primero hay que comprobar si el producto agregado no esta ya agregado
        'de ser asi solo aumentamos la cantidad del producto
        Dim agrega = False
        Try
            If _venta.IdAlmacen <> _busquedaProducto.IdAlmacen Then
                GVVentaDetalle.Columns(2).Visible = True
            End If
            For i = 0 To _venta.Detalle.Count - 1
                If _venta.Detalle(i).IdProducto = _busquedaProducto.IdProducto And _venta.Detalle(i).IdAlmacen = _busquedaProducto.IdAlmacen Then
                    If _venta.Detalle(i).Cantidad < _venta.Detalle(i).CantidadInventario Or _venta.Detalle(i).VentaExistenciaCero = 1 Then
                        If _venta.Detalle(i).PrecioCredito <= 0 Then
                            CalculaTodo()
                        End If
                        agrega = True
                        GVVentaDetalle.SelectedIndex = i
                        _venta.Detalle(i).Cantidad += 1
                        ActualizaVentaDetalle(i)
                        Try
                            GVVentaDetalle.SelectedIndex = i
                            TBXCodigo.Focus()
                        Catch ex As Exception
                        End Try
                    Else
                        WucAviso1.MostrarAviso("", "CANTIDAD SOLICITADA MAYOR A LA EXISTENCIA", TipoAviso.Aviso)
                        MVVenta.SetActiveView(ContenidoAviso)
                        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
                        CType(Master.FindControl("LBVCambiar"), Label).Visible = True
                        CType(Master.FindControl("LBVCambiar"), Label).Text = "AVISO"
                        agrega = True
                    End If
                    MostrarTotalVenta()
                End If
            Next
        Catch ex As Exception
        End Try
        'si no existe ya en la tabla entonces lo agregamos
        'Nota: el metodo ActualizaVentaDetalleCredito ya contiene el metodo de CalculaPreciosCredito por eso es que arriba no lo lleba y aqui si
        If Not agrega Then
            _venta.Detalle.Add(AgregaFilaVenta())
            CalculaTodo()
            Try
                GVVentaDetalle.SelectedIndex = GVVentaDetalle.Rows.Count - 1
                TBXCodigo.Focus()
            Catch ex As Exception
            End Try
        End If

        'If Not _venta.IdTipoVenta = TipoVenta.Apartado Then
        BuscarPromocion(_busquedaProducto.IdProducto, _busquedaProducto.IdProductoCorto, _busquedaProducto.Descripcion)
        'End If

        'Si ya se encuentra agregado un cliente hacemos visibles los botones de finalizar y pendiente
        MostrarBotones()
        MostrarProductosVenta()
    End Sub
    '#End Region

    Private Sub FuncionF10()
        IniciarVenta()
        MostrarTotalVenta()
        'NuevaVentaAviso()
    End Sub

    Private Sub CalculaPreciosCredito()
        'Calculamos los plazos en base a los productos
        CalculaPlazos()
        'Comprobamos que la venta tenga minimo un producto y que la venta sea de tipo credito
        If _venta.Detalle.Count > 0 Then
            'Obtenemos el tiempo del sistema y si la venta es precargada le pasamos las fechas guardadas
            If _ventaNueva Then
                Dim tiempo As Date = Now.Date
                Dim tiempoCredito As Date
                Dim tiempoContado As Date
                _venta.Credito.FechaInicio = tiempo
                'le agregamos al tiempo de credito los plazos calculados anteriormente 

                If _calendario.Mes = 0 Then
                    tiempoCredito = Now.Date.AddMonths(_venta.Credito.PlazoCreditoCantidad)
                    tiempoContado = Now.Date.AddMonths(_venta.Credito.PlazoContadoCantidad)
                Else
                    tiempoCredito = Now.Date.AddDays(_venta.Credito.PlazoCreditoCantidad * _calendario.Mes)
                    tiempoContado = Now.Date.AddDays(_venta.Credito.PlazoContadoCantidad * _calendario.Mes)
                End If

                _venta.Credito.FechaFinCredito = tiempoCredito
                'le agregamos al tiempo de contado los plazos calculados anteriormente 
                _venta.Credito.FechaFinContado = tiempoContado
                AgregarGraciExtra()
            End If
            'lo reflejamos al usuario
            TBLPCFInicioCon.Text = _venta.Credito.FechaInicio.ToShortDateString()
            TBLPCFInicioCre.Text = _venta.Credito.FechaInicio.ToShortDateString()
            'lo reflejamos al usuario
            TBLPCFFin.Text = _venta.Credito.FechaFinCredito.ToShortDateString()
            'lo reflejamos al usuario
            TBLPCFFinCorto.Text = _venta.Credito.FechaFinContado.ToShortDateString()
            'ahora obtenemos la diferencia en dias de la fecha de contado y de credito
            Dim difCredito = _venta.Credito.FechaFinCredito.Subtract(Now.Date.AddDays(_venta.Credito.Gracia))
            Dim difContado = _venta.Credito.FechaFinContado.Subtract(Now.Date.AddDays(_venta.Credito.Gracia))
            'obtenemos la equivalencia si es dia,semana,mes del periodo seleccionado
            Dim tipoPeriodo = _Periodo.Equivalencia.ToLower()
            'obtenemos la cantidad de periodos equivalente por ejemplo si el periodo lo registraron como bimestral
            'tuvieron que poner equivalente a mes y su cantidad 2 por lo que sabemos que el periodo es equivalente a dos meses
            Dim cantidadPeriodo = _Periodo.Cantidad
            If tipoPeriodo = "dia" Then
                TBLPCCRNoPeriodo.Text = CInt(difCredito.TotalDays / cantidadPeriodo).ToString()
                TBLPCCONoPeriodo.Text = CInt(difContado.TotalDays / cantidadPeriodo).ToString()
                _venta.Credito.PeriodoCredito = CInt(difCredito.TotalDays / cantidadPeriodo).ToString()
                _venta.Credito.PeriodoContado = CInt(difContado.TotalDays / cantidadPeriodo).ToString()
            ElseIf tipoPeriodo = "semana" Then
                TBLPCCRNoPeriodo.Text = CInt(difCredito.TotalDays / (cantidadPeriodo * 7)).ToString()
                TBLPCCONoPeriodo.Text = CInt(difContado.TotalDays / (cantidadPeriodo * 7)).ToString()
                _venta.Credito.PeriodoCredito = CInt(difCredito.TotalDays / (cantidadPeriodo * 7)).ToString()
                _venta.Credito.PeriodoContado = CInt(difCredito.TotalDays / (cantidadPeriodo * 7)).ToString()
            ElseIf tipoPeriodo = "quincena" Then
                TBLPCCRNoPeriodo.Text = CInt(difCredito.TotalDays / (cantidadPeriodo * 15)).ToString()
                TBLPCCONoPeriodo.Text = CInt(difContado.TotalDays / (cantidadPeriodo * 15)).ToString()
                _venta.Credito.PeriodoCredito = CInt(difCredito.TotalDays / (cantidadPeriodo * 15)).ToString()
                _venta.Credito.PeriodoContado = CInt(difContado.TotalDays / (cantidadPeriodo * 15)).ToString()
            ElseIf tipoPeriodo = "mes" Then
                TBLPCCRNoPeriodo.Text = CInt(difCredito.TotalDays / (cantidadPeriodo * 30)).ToString()
                TBLPCCONoPeriodo.Text = CInt(difContado.TotalDays / (cantidadPeriodo * 30)).ToString()
            End If

            'Calculamos el plazo mas indicado asi como los precios dependiendo de el plazo
            CalculaPrecios()

            'Refleja los totales de la venta
            MostrarTotalVenta()

            'Refleja los totales de la venta
            MostrarProductosVenta()
        Else
            LimpiarCredito()
            MostrarTotalVenta()
            MostrarProductosVenta()
        End If
    End Sub

    Private Sub AgregarGraciExtra()
        Dim extra = 0
        Dim gracia = 0
        For i = 0 To _venta.Descuento.Count - 1
            If _venta.Descuento(i).Gracia > 0 Then
                If _venta.Descuento(i).IdTipoGracia = 0 Then
                    If _venta.Descuento(i).Gracia > gracia Then
                        gracia = _venta.Descuento(i).Gracia
                    End If
                Else
                    If _venta.Descuento(i).Gracia * 30 > gracia Then
                        gracia = _venta.Descuento(i).Gracia * 30
                    End If
                End If
            End If
        Next
        For i = 0 To _venta.Descuento.Count - 1
            If _venta.Descuento(i).Extra > 0 Then
                If _venta.Descuento(i).IdTipoGracia = 0 Then
                    If _venta.Descuento(i).Extra > extra Then
                        extra = _venta.Descuento(i).Extra
                    End If
                Else
                    If _venta.Descuento(i).Extra * 30 > extra Then
                        extra = _venta.Descuento(i).Extra * 30
                    End If
                End If
            End If
        Next
        _venta.Credito.Gracia = gracia
        _venta.Credito.Extra = extra
        _venta.Credito.FechaInicio = _venta.Credito.FechaInicio.AddDays(gracia)
        ObtenerPrimerDiaSemana(_venta.Credito.FechaInicio)
        _venta.Credito.FechaFinContado = _venta.Credito.FechaFinContado.AddDays(extra + gracia)
        _venta.Credito.FechaFinCredito = _venta.Credito.FechaFinCredito.AddDays(extra + gracia)
    End Sub

    Private Sub ObtenerPrimerDiaSemana(ByRef diaSemana As DateTime)
        diaSemana = diaSemana.AddDays(1)
        While diaSemana.DayOfWeek <> DayOfWeek.Monday
            diaSemana = diaSemana.AddDays(1)
        End While
    End Sub

    Private Sub CalculaPreciosContado()
        'Comprobamos que la venta tenga minimo un producto y que la venta sea de tipo credito
        If _venta.Detalle.Count > 0 Then
            'Mostramos el total de contado
            For i = 0 To _venta.Detalle.Count - 1
                ActualizaVentaDetalle(i)
                If _venta.Detalle(i).Promocion = Nothing Then
                    _venta.Detalle(i).Promocion = ""
                End If

                If _venta.Detalle(i).DescuentoCredito > 0 Or _venta.Detalle(i).Promocion.Length > 0 Then
                    _venta.Detalle(i).PromocionBoolean = True
                Else
                    _venta.Detalle(i).PromocionBoolean = False
                End If
            Next
        Else
            MostrarBotones()
        End If
        MostrarProductosVenta()
        MostrarTotalVenta()
    End Sub

    Private Sub CalculaPreciosApartado()
        'Comprobamos que la venta tenga minimo un producto y que la venta sea de tipo credito
        If _venta.Detalle.Count > 0 Then
            'Mostramos el total de contado
            For i = 0 To _venta.Detalle.Count - 1
                _venta.Detalle(i).PromocionBoolean = False
                ActualizaVentaDetalle(i)
            Next
            ActualizaFechaApartado()
        Else
            MostrarBotones()
        End If
        MostrarProductosVenta()
        MostrarTotalVenta()
    End Sub

    Private Sub ActualizaFechaApartado()
        If _ventaNueva Then
            Dim tiempo As Date = Now.Date
            Dim tiempoContado As Date
            _venta.Credito.FechaInicio = tiempo
            _venta.Credito.IdPlazoContado = CBPLPlazoContado.SelectedValue
            _venta.Credito.PlazoContado = CBPLPlazoContado.SelectedItem.Text

            For Each plazoCantidad In _listaPlazos
                If plazoCantidad.IdTipoPlazo = _venta.Credito.IdPlazoContado Then
                    _venta.Credito.PlazoContadoCantidad = plazoCantidad.Plazo
                End If
            Next

            tiempoContado = Now.Date.AddMonths(_venta.Credito.PlazoContadoCantidad)
            _venta.Credito.FechaFinContado = tiempoContado
        End If
        'lo reflejamos al usuario
        TBLPCFInicioCon.Text = _venta.Credito.FechaInicio.ToShortDateString()
        TBLPCFFinCorto.Text = _venta.Credito.FechaFinContado.ToShortDateString()
    End Sub

    Private Sub CalculaPlazos()
        '=========================================== Funcionamiento ================================================='
        ' Este metodo funciona en tres partes:
        '   Primero.- Busca y obtiene los plazos registrados de cada producto que estan en la venta actual
        '   Segundo.- En base a los plasos comprueba cual es el mejor de credito y el de contado y los indica en los combobox
        '=========================================== Funcionamiento ================================================='

        ':::::::::::::::::::::::::: Primera parte ::::::::::::::::::::::::::'
        'Declaramos la variables necesarias
        listaCalculoPlazo.Clear()
        'Si el plazo de contado y de credito estan manuales no es necesario hacer consulta por lo que nos evitamos esa carga al servidor
        If Not plazoCreditoManual Or Not plazoContadoManual Then
            Dim EntidadPrecio As New Entidad.Precio()
            Dim NegocioPrecio As New Negocio.Precio()
            EntidadPrecio.Tarjeta.Consulta = Consulta.ConsultaBasica
            'Empesamos a recorrer prodcuto por producto de la venta
            For i = 0 To _venta.Detalle.Count - 1
                'Hacemos una consulta basica del producto_precio ya que esta tabla contiene los plazos del producto
                EntidadPrecio.IdProducto = _venta.Detalle(i).IdProducto
                NegocioPrecio.Obtener(EntidadPrecio)
                Dim TablaPE = EntidadPrecio.TablaConsulta
                'Variable temporal que contiene el mejor plazo de contado y de credito
                Dim calculoPlazo = New Entidad.CalculoPlazo()
                'Variable temporal que contiene el formato para sacar fila por fila el contenido de la consulta
                Dim listaPrecio As List(Of DataRow) = TablaPE.AsEnumerable().ToList()
                'Variable necesaria para asignar el plazo de contado
                Dim chico = True
                'Empezamos a recorrer la lista obtenida de el datatable de la consulta
                For Each rw As DataRow In listaPrecio
                    'Si el plazo de credito esta manual entonces no hacemos la comparacion
                    If Not plazoCreditoManual Then
                        'Si el plazo de esta fila es mayor a cero (no es riguroso contado)
                        'Y si el el plazo que tenemos actualmente en este producto es menor al de la fila quiere decir
                        'que el plazo de credito no es el mejor y almacenamos el de la fila quitando el actual
                        If rw.ItemArray(3) > 0 And calculoPlazo.PlazoCredito < rw.ItemArray(3) Then
                            calculoPlazo.IdPlazoCredito = rw.ItemArray(1)
                            calculoPlazo.Credito = rw.ItemArray(2)
                            calculoPlazo.PlazoCredito = rw.ItemArray(3)
                            If IsNumeric(rw.ItemArray(4)) Then
                                calculoPlazo.TotalCredito = rw.ItemArray(4)
                            End If
                        End If
                    End If
                    'Si el plazo contado esta manual no hacemos la comparacion
                    If Not plazoContadoManual Then
                        'Si el plazo de esta fila es mayor a cero (no es riguroso contado)
                        'Y si la variable chico es verdadera (la primera vez que empezamos a recorrer cada prodcuto lo es)
                        'ya que la siguiente comparacion es de que si el plazo actual es mayor al de la fila quiere decir
                        'que el de la fila es el mas adecuado para el de contado, pero si no usamos la variable chico esto nunca se cumpliria 
                        'ya que el plazo de contado siempre tendria cero
                        If rw.ItemArray(3) > 0 And (chico Or calculoPlazo.PlazoContado > rw.ItemArray(3)) Then
                            calculoPlazo.IdPlazoContado = rw.ItemArray(1)
                            calculoPlazo.Contado = rw.ItemArray(2)
                            calculoPlazo.PlazoContado = rw.ItemArray(3)
                            If IsNumeric(rw.ItemArray(4)) Then
                                calculoPlazo.TotalContado = rw.ItemArray(4)
                            End If
                            chico = False
                        End If
                    End If
                Next
                'Agregamos el id del prodcuto al claculo que hicimos
                calculoPlazo.IdProducto = _venta.Detalle(i).IdProducto
                'Y le agregamos un nuevo objeto de CalculoPlazo a la lista listaCalculoPlazo, se le debe de agregar uno nuevo como se hace ya que
                'si solo se agregara calculoPlazo al volver a hacer el recorrido esta perderia todos sus valores y por consiguiente el contenido del
                'listaCalculoPlazo tambien lo aria
                listaCalculoPlazo.Add(New Entidad.CalculoPlazo(calculoPlazo.IdPlazoCredito,
                                                               calculoPlazo.IdPlazoContado,
                                                               calculoPlazo.Credito,
                                                               calculoPlazo.Contado,
                                                               calculoPlazo.PlazoCredito,
                                                               calculoPlazo.PlazoContado,
                                                               calculoPlazo.TotalCredito,
                                                               calculoPlazo.TotalContado,
                                                               calculoPlazo.IdProducto))
            Next
        End If

        If listaCalculoPlazo.Count = 1 Then
            If listaCalculoPlazo(0).PlazoContado = 0 And listaCalculoPlazo(0).PlazoCredito = 0 Then
                plazoContadoManual = True
                plazoCreditoManual = True
            End If
        End If

        ':::::::::::::::::::::::::: Segunda parte ::::::::::::::::::::::::::'
        'Lo siguiente es calcular de los plazos obtenidos de cada producto cual es el mas adecuado para el de credito y el de contado esto para llegar a un solo
        'plazo de credito y de contado, los metodos son iguales que los de arriba solo que usando la lista listaCalculoPlazo y no consultando al servidor
        Dim primero = True

        For Each producto In listaCalculoPlazo
            If Not plazoCreditoManual Then
                If producto.PlazoCredito > 0 And _venta.Credito.PlazoCreditoCantidad < producto.PlazoCredito Then
                    _venta.Credito.IdPlazoCredito = producto.IdPlazoCredito
                    CBPLPlazoCredito.SelectedValue = producto.IdPlazoCredito.ToString()
                    _venta.Credito.PlazoCreditoCantidad = producto.PlazoCredito
                End If
            Else
                _venta.Credito.PlazoCreditoCantidad = _listaPlazos(CBPLPlazoCredito.SelectedIndex).Plazo
            End If
            If Not plazoContadoManual Then
                If producto.PlazoContado > 0 And (primero Or (_venta.Credito.PlazoContadoCantidad < producto.PlazoContado)) Then
                    _venta.Credito.IdPlazoContado = producto.IdPlazoContado
                    CBPLPlazoContado.SelectedValue = producto.IdPlazoContado.ToString()
                    _venta.Credito.PlazoContadoCantidad = producto.PlazoContado
                    primero = False
                End If
            Else
                _venta.Credito.PlazoContadoCantidad = _listaPlazos(CBPLPlazoContado.SelectedIndex).Plazo
            End If
        Next

        'aqui lo que hacemos es simplemente reflejar en los combobox si no estan manuales cual es el mejor
        'plazo calculado de credito y de contado en base a los productos agregados para la venta
        If plazoCreditoManual Then
            _venta.Credito.IdPlazoCredito = _listaPlazos(CBPLPlazoCredito.SelectedIndex).IdTipoPlazo
            _venta.Credito.PlazoCreditoCantidad = _listaPlazos(CBPLPlazoCredito.SelectedIndex).Plazo
        Else
            CBPLPlazoCredito.SelectedValue = _venta.Credito.IdPlazoCredito.ToString()
        End If
        If plazoContadoManual Then
            _venta.Credito.IdPlazoContado = _listaPlazos(CBPLPlazoContado.SelectedIndex).IdTipoPlazo
            _venta.Credito.PlazoContadoCantidad = _listaPlazos(CBPLPlazoContado.SelectedIndex).Plazo
        Else
            CBPLPlazoContado.SelectedValue = _venta.Credito.IdPlazoContado.ToString()
        End If
        _venta.Credito.PlazoCredito = CBPLPlazoCredito.SelectedItem.Text
        _venta.Credito.PlazoContado = CBPLPlazoContado.SelectedItem.Text
    End Sub

    Private Sub CalculaPrecios()
        'calcular el precio de cada producto en base al mejor plazo credito y contado o en base al de los combobox si es que estan manual
        Dim index = 0
        _venta.Credito.Subtotal = 0
        _venta.Subtotal = 0
        For index = 0 To _venta.Detalle.Count - 1
            Dim producto = _venta.Detalle(index)
            'Calculamos el precio de credito y de contado
            Dim precioCredito As Double = 0
            Dim precioContado As Double = 0
            Dim calculaPrecio = True
            For Each plazos In From plazos1 In listaCalculoPlazo Where (plazos1.IdProducto = producto.IdProducto And plazos1.IdPlazoCredito = _venta.Credito.IdPlazoCredito And plazos1.IdPlazoContado = _venta.Credito.IdPlazoContado)
                precioCredito = plazos.TotalCredito
                precioContado = plazos.TotalContado
                calculaPrecio = False
            Next
            If calculaPrecio Then
                precioCredito = PrecioCalculado(producto.IdProducto, 0)
                precioContado = PrecioCalculado(producto.IdProducto, 1)
            End If
            'Acumulamos los totales
            _venta.Credito.Subtotal += precioCredito
            _venta.Subtotal += precioContado
            'Actualizamos los precios
            _venta.Detalle(index).PrecioCredito = precioCredito
            _venta.Detalle(index).PrecioContado = precioContado
            'Y por ultimo actualizamos los precios segun cantidades y descuentos
            ActualizaVentaDetalle(index)

            If _venta.Detalle(index).Promocion = Nothing Then
                _venta.Detalle(index).Promocion = ""
            End If

            If _venta.Detalle(index).DescuentoCredito > 0 Or _venta.Detalle(index).Promocion.Length > 0 Then
                _venta.Detalle(index).PromocionBoolean = True
            Else
                _venta.Detalle(index).PromocionBoolean = False
            End If
        Next
    End Sub

    Private Sub MostrarTotalVenta()
        '============================================================== LEER =========================================================
        ' En la venta a credito las variables _venta.subtotal y _venta.total son los totales de credito, mientras que las variables ==
        ' _venta.Credito.Subtotal y _venta.credito.total son los totales de contado ==================================================
        ' En la venta a contado las variables _venta.subtotal y _venta.total son los totales de contado, por lo que _venta.credito no
        ' se toca para nada
        '============================================================== LEER =========================================================
        _venta.Total = 0
        _venta.Subtotal = 0
        _venta.CargoMonto = 0
        _venta.DescuentoMonto = 0
        _venta.DescuentoPorcentaje = 0
        _venta.Credito.Subtotal = 0
        _venta.Credito.Total = 0

        If _venta.IdTipoVenta = TipoVenta.Credito Then
            For Each producto In _venta.Detalle
                _venta.Credito.Total += producto.TotalContado
                _venta.Total += producto.TotalCredito
                _venta.DescuentoMonto += producto.DescuentoCredito
                _venta.DescuentoPorcentaje += producto.DescuentoPorcentaje
                _venta.Subtotal += producto.SubtotalCredito
                _venta.Credito.Subtotal += producto.SubtotalContado
            Next
        ElseIf _venta.IdTipoVenta = TipoVenta.Contado Or _venta.IdTipoVenta = TipoVenta.Apartado Then
            For Each producto In _venta.Detalle
                _venta.Total += producto.TotalCredito
                _venta.DescuentoMonto += producto.DescuentoCredito
                _venta.DescuentoPorcentaje += producto.DescuentoPorcentaje
                _venta.Subtotal += producto.SubtotalCredito
            Next
        End If

        _venta.Credito.Total = _venta.Credito.Total - _venta.Credito.Anticipo
        _venta.Total = _venta.Total - _venta.Credito.Anticipo

        If Not _venta.IdTipoVenta = TipoVenta.Apartado Then
            For Each cargo In _venta.Cargo
                If cargo.IdTipo = 2 And cargo.Activo Then
                    If cargo.TipoMonto = 0 Then
                        _venta.CargoMonto += cargo.Monto
                        cargo.Total = cargo.Monto
                    Else
                        _venta.CargoMonto += _venta.Total * (cargo.Monto / 100)
                        cargo.Total = _venta.Total * (cargo.Monto / 100)
                    End If
                Else
                    If cargo.TipoMonto = 0 Then
                        cargo.Total = cargo.Monto
                    Else
                        cargo.Total = _venta.Total * (cargo.Monto / 100)
                    End If
                End If
                cargo.Total = CInt(cargo.Total)
                MostrarCargos()
            Next
        Else
            _venta.DescuentoMonto = 0
        End If

        _venta.Subtotal = CInt(_venta.Subtotal)
        _venta.DescuentoMonto = CInt(_venta.DescuentoMonto)
        _venta.CargoMonto = CInt(_venta.CargoMonto)

        _venta.Credito.Total = _venta.Credito.Total - _venta.DescuentoMonto + _venta.CargoMonto
        _venta.Total = _venta.Total - _venta.DescuentoMonto + _venta.CargoMonto

        Dim totalContado = CInt(_venta.Credito.Total)
        Dim totalCredito = CInt(_venta.Total)

        Try
            _venta.Credito.ImporteContado = CInt(_venta.Credito.Total / _venta.Credito.PeriodoContado)
        Catch ex As Exception
            _venta.Credito.ImporteContado = 0
        End Try
        Try
            _venta.Credito.ImporteCredito = CInt(_venta.Total / _venta.Credito.PeriodoCredito)

        Catch ex As Exception
            _venta.Credito.ImporteCredito = 0
        End Try

        'Dim subtotalContado = importeContado * (_venta.Credito.PeriodoContado - 1)
        'Dim subtotalCredito = importeCredito * (_venta.Credito.PeriodoCredito - 1)
        _venta.Credito.Total = totalContado
        _venta.Total = totalCredito

        'se lo feflejamos al usuario
        TBLPCCRImporte.Text = String.Format("{0:c}", _venta.Credito.ImporteCredito)
        TBLPCCOImporte.Text = String.Format("{0:c}", _venta.Credito.ImporteContado)
        If _venta.IdTipoVenta = TipoVenta.Credito Then
            TBLPCCRTotal.Text = String.Format("{0:c}", _venta.Total)
            TBLPCCOTotal.Text = String.Format("{0:c}", _venta.Credito.Total)
            _venta.Credito.IdPeriodo = CInt(DDPeriodo1.SelectedValue)
            _venta.Credito.Periodo = DDPeriodo1.SelectedItem.Text
        End If
        TBLTSubtotal.Text = String.Format("{0:c}", _venta.Subtotal)
        TBLTTotal.Text = String.Format("{0:c}", _venta.Total)
        LBTabTotal.Text = "TOTAL: " + String.Format("{0:c}", _venta.Total)
        TBLTDescuento.Text = String.Format("{0:c}", _venta.DescuentoMonto)
        TBLTImpuesto.Text = String.Format("{0:c}", _venta.CargoMonto)

        TBLTSubtotalxs.Text = String.Format("{0:c}", _venta.Subtotal)
        TBLTotalxs.Text = String.Format("{0:c}", _venta.Total)
        TBLTDescuentoxs.Text = String.Format("{0:c}", _venta.DescuentoMonto)
        TBLTImpuestoxs.Text = String.Format("{0:c}", _venta.CargoMonto)
    End Sub

    Private Function PrecioCalculado(ByVal idProdcuto As Integer, ByVal tipoCalculo As Integer) As Double
        'En este metodo lo que hacemos es calcular el precio en base al plazo escogido
        Dim precio As Double = 0
        Dim precioReturn As Double = 0
        'primero obtenemos el precio de acuerdo al del prodcuto que se le esta pidiendo a este metodo
        For Each ventaDetalle In From ventaDetalle1 In _venta.Detalle Where ventaDetalle1.IdProducto = idProdcuto
            precio = ventaDetalle.PrecioBase
        Next
        '' LO DE ARRIBA ES IGUAL A ESTO QUE ESTA COMENTADO
        'For Each ventaDetalle In _venta.Detalle
        '    If ventaDetalle.IdProducto = idProdcuto Then
        '        precio = ventaDetalle.PrecioBase
        '    End If
        'Next

        'Declaramos y asignamos las variables necesarias
        Dim margen = _Interes.Interes
        Dim Iva = _Interes.IVA
        'si el tipoCalculo = 0 calculamos y devolvemos el precio calculado de credito si no el de contado
        If _calendario.Ano = 0 Then
            _calendario.Ano = _venta.Credito.FechaInicio.Subtract(_venta.Credito.FechaInicio.AddMonths(12)).Days
        End If
        If tipoCalculo = 0 Then
            If _calendario.Mes = 0 Then
                _calendario.Mes = _venta.Credito.FechaInicio.Subtract(_venta.Credito.FechaFinCredito).Days / _venta.Credito.PlazoCreditoCantidad
            End If
            precioReturn = precio + ((((precio * ((margen * 12) / 100)) / _calendario.Ano) * _calendario.Mes) * _venta.Credito.PlazoCreditoCantidad)
            ''precioReturn = precio * (((margen / 100) * _venta.Credito.PlazoCreditoCantidad) + 1)
        Else
            'Si se va a agregar interes al precio contado o no
            If _calendario.Mes = 0 Then
                _calendario.Mes = _venta.Credito.FechaInicio.Subtract(_venta.Credito.FechaFinContado).Days / _venta.Credito.PlazoCreditoCantidad
            End If
            precioReturn = precio + ((((precio * ((margen * 12) / 100)) / _calendario.Ano) * _calendario.Mes) * _venta.Credito.PlazoContadoCantidad)
        End If
        Return precioReturn
    End Function

#Region "Botones de Venta"
    Private Sub BTNVNuevo_Click(sender As Object, e As EventArgs) Handles BTNVNuevo.Click
        FuncionF10()
    End Sub

    Private Sub BTNVBuscar_Click(sender As Object, e As EventArgs) Handles BTNVBuscar.Click
        FuncionF11()
    End Sub

    Private Sub BTNVFinalizar_Click(sender As Object, e As EventArgs) Handles BTNVFinalizar.Click
        If _venta.IdTipoVenta = TipoVenta.Credito And _venta.SaldoDisponible < _venta.Total Then
            WucAviso1.MostrarAviso("", "El cliente no cuenta con saldo disponible suficiente", TipoAviso.Advertencia)
            MVVenta.SetActiveView(ContenidoAviso)
            CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
            CType(Master.FindControl("LBVCambiar"), Label).Visible = True
            CType(Master.FindControl("LBVCambiar"), Label).Text = "AVISO"
        Else
            _venta.IdVentaEstado = TipoVentaEstado.ACTIVO
            FinalizarVenta()
        End If
    End Sub
    Private Sub BTNVPendiente_Click(sender As Object, e As EventArgs) Handles BTNVPendiente.Click
        _venta.IdVentaEstado = TipoVentaEstado.PENDIENTE
        FinalizarVenta()
    End Sub

    Private Sub BTNVReimprimir_Click(sender As Object, e As EventArgs) Handles BTNVReimprimir.Click
        Imprimir()
    End Sub

    Private Sub BTNVCancelar_Click(sender As Object, e As EventArgs) Handles BTNVCancelar.Click
        _venta.IdVentaEstado = TipoVentaEstado.CANCELADO
        FinalizarVenta()
    End Sub
#End Region

    Private Sub ActualizaLLenaComboxBox()
        'LLenar/actualizar combobox tipo de entrega
        Dim EntidadTipoEntrega As New Entidad.TipoEntrega()
        Dim NegocioTipoEntrega As New Negocio.TipoEntrega()
        EntidadTipoEntrega.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoEntrega.Consultar(EntidadTipoEntrega)
        Dim TablaCE = EntidadTipoEntrega.TablaConsulta
        _listaTipoEntrega.Clear()
        Dim listaTipoEntrega As List(Of DataRow) = TablaCE.AsEnumerable().ToList()
        For Each rw As DataRow In listaTipoEntrega
            Dim Fila As New Entidad.TipoEntrega
            Fila.IdTipoEntrega = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(1)
            Fila.IdEstado = rw.ItemArray(2)
            _listaTipoEntrega.Add(Fila)
        Next
        Try
            'CBCDomicilioEntrega.SelectedIndex = 0
        Catch ex As Exception

        End Try

        'Llenar/actualizar tipo plazo
        Dim EntidadTipoPlazo As New Entidad.TipoPlazo()
        Dim NegocioTipoPlazo As New Negocio.TipoPlazo()
        EntidadTipoPlazo.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoPlazo.Consultar(EntidadTipoPlazo)
        Dim TablaPl = EntidadTipoPlazo.TablaConsulta
        _listaPlazos.Clear()
        Dim listaPlazo As List(Of DataRow) = TablaPl.AsEnumerable().ToList()
        For Each rw As DataRow In listaPlazo
            Dim Fila As New Entidad.TipoPlazo
            Fila.IdTipoPlazo = rw.ItemArray(0)
            Fila.Plazo = rw.ItemArray(1)
            Fila.Descripcion = rw.ItemArray(2)
            Fila.IdEstado = rw.ItemArray(3)
            _listaPlazos.Add(Fila)
        Next

        'Llenar/actualizar periodos
        Dim NegocioPeriodo As New Negocio.Periodo()
        Dim EntidadPeriodo As New Entidad.Periodo()
        EntidadPeriodo.Tarjeta.Consulta = Consulta.ConsultaDetallada
        NegocioPeriodo.Consultar(EntidadPeriodo)
        Dim TablaPe = EntidadPeriodo.TablaConsulta
        _listaPeriodos.Clear()
        Dim drlisst As List(Of DataRow) = TablaPe.AsEnumerable().ToList()
        For Each rw As DataRow In drlisst
            Dim Fila As New Entidad.Periodo
            Fila.IdPeriodo = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(1)
            Fila.Cantidad = rw.ItemArray(2)
            Fila.IdTipoEquivalenciaPeriodo = rw.ItemArray(3)
            Fila.Equivalencia = rw.ItemArray(4)
            Fila.IdEstado = rw.ItemArray(5)
            _listaPeriodos.Add(Fila)
        Next

    End Sub

    Private Sub LimpiarCredito()
        _listaPlazos.Clear()
        _listaPeriodos.Clear()
        MostrarProductosVenta()
        TBXPCEAnticipo.Text = ""
        TBLPCFInicioCon.Text = Now.ToShortDateString()
        TBLPCFInicioCre.Text = Now.ToShortDateString()
        TBLPCFFin.Text = Now.ToShortDateString()
        TBLPCFFinCorto.Text = Now.ToShortDateString()
        TBLPCCOImporte.Text = String.Format("{0:c}", 0)
        TBLPCCRImporte.Text = String.Format("{0:c}", 0)
        TBLPCCOTotal.Text = String.Format("{0:c}", 0)
        TBLPCCRTotal.Text = String.Format("{0:c}", 0)
        TBLPCCONoPeriodo.Text = 0
        TBLPCCRNoPeriodo.Text = 0


        _venta.Credito.Anticipo = 0
        _venta.Credito.FechaInicio = Now.ToShortDateString()
        _venta.Credito.FechaFinContado = Now.ToShortDateString()
        _venta.Credito.FechaFinCredito = Now.ToShortDateString()
        _venta.Credito.ImporteContado = 0
        _venta.Credito.ImporteContado = 0
        _venta.Credito.Total = 0
        _venta.Total = 0
        _venta.Credito.PeriodoContado = 0
        _venta.Credito.PeriodoCredito = 0
    End Sub

    Private Sub LimpiarTotales()
        TBLTDescuento.Text = String.Format("{0:c}", 0)
        'TBLTSuma.Text = String.Format("{0:c}", 0)
        TBLTSubtotal.Text = String.Format("{0:c}", 0)
        'TBLTGastoCobranza.Text = String.Format("{0:c}", 0)
        TBLTImpuesto.Text = String.Format("{0:c}", 0)
        TBLTDescuento.Text = String.Format("{0:c}", 0)
        TBLTTotal.Text = String.Format("{0:c}", 0)

        TBLTSubtotalxs.Text = String.Format("{0:c}", 0)
        TBLTotalxs.Text = String.Format("{0:c}", 0)
        TBLTDescuentoxs.Text = String.Format("{0:c}", 0)
        TBLTImpuestoxs.Text = String.Format("{0:c}", 0)
        LBTabTotal.Text = "TOTAL: " + String.Format("{0:c}", 0)
    End Sub

    Private Sub FinalizarVenta()
        If GVVentaDetalle.Rows.Count = 0 Then
            Return
        End If

        If _venta.IdTipoVenta = TipoVenta.Apartado Then
            Dim minimoAnticipo = CInt(_venta.Total / 5)
            If _venta.Credito.Anticipo < minimoAnticipo Then
                WucAviso1.MostrarAviso("AVISO", "TIENE QUE DARSE UN MÍNIMO DE: " + String.Format("{0:c}", minimoAnticipo) + _
                                       " PARA FINALIZAR VENTA DE APARTADO", TipoAviso.Aviso)
                MVVenta.SetActiveView(ContenidoAviso)
                CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
                CType(Master.FindControl("LBVCambiar"), Label).Visible = True
                CType(Master.FindControl("LBVCambiar"), Label).Text = "APARTADO"
                Return
            End If
        End If

        Dim descripcion = ""
        For Each detalle In _venta.Detalle
            If detalle.Producto.Length > 20 Then
                descripcion += detalle.Producto.Substring(0, 20) + ","
            Else
                descripcion += detalle.Producto + ","
            End If
        Next
        _venta.Descripcion = descripcion.Substring(0, descripcion.Length - 1)

        If _venta.IdTipoVenta = TipoVenta.Credito Then
            _venta.Credito.IdTipoCCP = 1
            _venta.Credito.IdEstado = 4
            _venta.Credito.IdTipoDocumento = 4
            _venta.Credito.Serie = ""
            _venta.Observacion = ""
        End If

        _venta.IdUsuarioCreacion = _usuario.IdUsuario
        _venta.IdUsuarioActualizacion = _usuario.IdUsuario
        _venta.FechaCreacion = Now
        _venta.FechaActualizacion = Now

        'If _venta.Credito.Aval <> "" Then
        '    _venta.Credito.IdAval = 0
        '    _venta.Credito.Aval = TBLANombre.Text
        '    _venta.Credito.AvalDomicilio = TBLADomicilio.Text
        '    _venta.Credito.AvalIdentificacion = TBLAIdentificacion.Text
        '    _venta.Credito.AvalTelefono = TBLATelefono.Text
        'End If

        _venta.Credito.IdCalendario = _calendario.IdCalendario
        _venta.FolioFisico = TBFolio2.Text

        'Dim avisoGuardando = New AvisoGuardando()
        'If _ventaCredito.IdVentaEstado = TipoVentaEstado.PENDIENTE Then
        '    avisoGuardando.MensajeAviso("Guardando Pendiente")
        'ElseIf _ventaCredito.IdVentaEstado = TipoVentaEstado.CANCELADO Then
        '    avisoGuardando.MensajeAviso("Cancelando Venta")
        'Else
        '    avisoGuardando.MensajeAviso("Finalizando Venta")
        'End If

        'avisoGuardando.Show()
        'avisoGuardando.Topmost = True

        _venta.IdTipoEntrega = 1

        If TBLCDomicilio.Text.Length = 0 Or TBLCDomicilioxs.Text.Replace(" ", "") = "" Or TBLCDomicilioxs.Text.ToUpper() = "SIN DOMICILIO REGISTRADO" Or TBLCDomicilioxs.Text.ToUpper() = "SIN DOMICILIO" Then
            TBLCDomicilioxs.Text = "EN SUCURSAL"
            _venta.DomicilioEntrega = "EN SUCURSAL"
        Else
            _venta.DomicilioEntrega = TBLCDomicilio.Text
        End If
        _venta.FechaCreacion = Now
        _venta.FechaActualizacion = Now

        If _venta.IdVentaEstado = TipoVentaEstado.CANCELADO Then
            _venta.IdEstado = 2
            _venta.Credito.IdEstado = 2
            For Each detalle In _venta.Detalle
                detalle.IdEstado = 2
            Next
            For Each cargo In _venta.Cargo
                cargo.IdEstado = 2
            Next
            For Each descuento In _venta.Descuento
                descuento.IdEstado = 2
            Next
            For Each obsequio In _venta.Obsequio
                obsequio.IdEstado = 2
                For Each obsequioDetalle In obsequio.Detalle
                    obsequioDetalle.IdEstado = 2
                Next
            Next
        End If

        Dim NegocioVenta As New Negocio.Venta()
        NegocioVenta.Guardar(_venta)
        If _venta.Tarjeta.Resultado = Resultado.Correcto Then
            If _venta.IdVentaEstado = TipoVentaEstado.PENDIENTE Then
                'avisoGuardando.Listo("Venta Guardada")
                WucAviso1.MostrarAviso("VENTA GUARDADA", "", TipoAviso.Guardar)
                MVVenta.SetActiveView(ContenidoAviso)
                CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
                CType(Master.FindControl("LBVCambiar"), Label).Visible = True
                CType(Master.FindControl("LBVCambiar"), Label).Text = "PENDIENTE"
            ElseIf _venta.IdVentaEstado = TipoVentaEstado.CANCELADO Then
                WucAviso1.MostrarAviso("VENTA CANCELADA", "", TipoAviso.Guardar)
                MVVenta.SetActiveView(ContenidoAviso)
                CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
                CType(Master.FindControl("LBVCambiar"), Label).Visible = True
                CType(Master.FindControl("LBVCambiar"), Label).Text = "CANCELADA"
            Else
                'avisoGuardando.Listo("Venta Finalizada")
                WucAviso1.MostrarAviso("VENTA FINALIZADA", "", TipoAviso.Guardar)
                MVVenta.SetActiveView(ContenidoAviso)
                CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
                CType(Master.FindControl("LBVCambiar"), Label).Visible = True
                CType(Master.FindControl("LBVCambiar"), Label).Text = "FINALIZADA"
                Imprimir()
            End If
            NuevaVenta(_venta.IdTipoVenta)
        ElseIf _venta.Tarjeta.Resultado = Resultado.Incorrecto Then
            WucAviso1.MostrarAviso("ERROR AL GUARDAR VENTA", _venta.Tarjeta.Excepcion, TipoAviso.Errorr)

            CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
            CType(Master.FindControl("LBVCambiar"), Label).Visible = True
            CType(Master.FindControl("LBVCambiar"), Label).Text = "ERROR"
            MVVenta.SetActiveView(ContenidoAviso)
        End If
    End Sub

    Private Sub GenerarFolio()
        Dim sucursal = ""
        If _usuario.IdSucursal < 10 Then
            sucursal = "0" + _usuario.IdSucursal.ToString()
        Else
            sucursal = _usuario.IdSucursal.ToString()
        End If

        Dim vendedor = ""
        If _usuario.IdUsuario < 10 Then
            vendedor = "0" + _usuario.IdUsuario.ToString()
        Else
            vendedor = _usuario.IdUsuario.ToString()
        End If

        Dim noventatemp As String = "1"
        Dim noventa As String = ""

        'Obtener nuevo idventa
        Dim EntidadVenta As New Entidad.Venta()
        Dim NegocioVenta As New Negocio.Venta()
        EntidadVenta.Tarjeta.Consulta = Consulta.Ninguno
        EntidadVenta.IdSucursal = _usuario.IdSucursal ''Sacado del login
        NegocioVenta.Consultar(EntidadVenta)
        Dim TablaCE = EntidadVenta.TablaConsulta
        Dim listaPersonaDireccion As List(Of DataRow) = TablaCE.AsEnumerable().ToList()
        For Each rw As DataRow In listaPersonaDireccion
            noventatemp = rw.ItemArray(0).ToString()
        Next

        If noventatemp.Length = 1 Then
            noventa = "000" + noventatemp
        ElseIf noventatemp.Length = 2 Then
            noventa = "00" + noventatemp
        ElseIf noventatemp.Length = 3 Then
            noventa = "0" + noventatemp
        Else
            noventa = noventatemp
        End If

        TBLVFolio.Text = "Folio: " + sucursal + vendedor + Now.ToString("ddMMyy") + noventa
        _venta.Folio = sucursal + vendedor + Now.ToString("ddMMyy") + noventa
    End Sub

    'Private Sub GVBTNDetalleProducto_Click(sender As Object, e As RoutedEventArgs)
    '    Dim DetalleProducto As New DetalleProducto(_busquedaProducto(GVBusquedaProducto.SelectedIndex).IdProducto,
    '                                               _busquedaProducto(GVBusquedaProducto.SelectedIndex).Descripcion)
    '    DetalleProducto.ShowDialog()
    'End Sub

    Private Sub BusquedaProductoCancelado(sender As Object, e As EventArgs)
        MVVenta.SetActiveView(ContenidoPrinicpal)

        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False
    End Sub
    Private Sub BusquedaProductoSeleccionado(sender As Object, e As EventArgs)
        TBXCodigo.Text = WucConsultarProductoVenta.IdProductoCorto
        MVVenta.SetActiveView(ContenidoPrinicpal)
        BuscarProducto(WucConsultarProductoVenta.IdAlmacen)

        QuitarPromocionRepetidaActiva()
        MostrarPromociones()

        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False
    End Sub

    Private Sub QuitarPromocionRepetidaActiva()
        ''================================================================================================
        ' Quitar primero las promociones repetidas
        Dim indices As New List(Of Integer)
        For i = 0 To _listaPromocion.Count - 1
            For j = i + 1 To _listaPromocion.Count - 1
                If _listaPromocion(i).Descripcion = _listaPromocion(j).Descripcion And i <> j Then
                    indices.Add(j)
                End If
            Next
        Next

        Dim iactual = 0
        For Each o In indices
            _listaPromocion.RemoveAt(o - iactual)
            iactual += 1
        Next

        ''================================================================================================
        ' Despues quitar las promociones activas
        indices.Clear()
        For i = 0 To _listaPromocion.Count - 1
            For Each p In From pObsequio In _venta.Obsequio Where pObsequio.Descripcion = _listaPromocion(i).Descripcion
                indices.Add(i)
            Next
            For Each p In From pDescuento In _venta.Descuento Where pDescuento.Descripcion = _listaPromocion(i).Descripcion
                indices.Add(i)
            Next
        Next

        iactual = 0
        For Each o In indices
            _listaPromocion.RemoveAt(o - iactual)
            iactual += 1
        Next
    End Sub

    Private Sub BusquedaPersonaSeleccionado(sender As Object, e As EventArgs)
        TBXCodigo.Text = WucConsultarPersonaVenta.IdPersonaCorto
        MVVenta.SetActiveView(ContenidoPrinicpal)
        BuscarPersona()

        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False
    End Sub

    Private Sub BuscarPersona()
        Dim EntidadConsultarPersona As New Entidad.Persona()
        Dim NegocioConsultarPersona As New Negocio.Persona()
        EntidadConsultarPersona.IdPersona = CType(TBXCodigo.Text, Integer)
        EntidadConsultarPersona.Tarjeta.Consulta = Consulta.ConsultaPorId
        NegocioConsultarPersona.VentaObtener(EntidadConsultarPersona)
        If CBool(Session("Aval")) Or _busquedaAval Then
            AvalDatos(EntidadConsultarPersona.IdPersona, _
                      CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Nombre")), _
                      CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Domicilio")), _
                      CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Telefono")), _
                      CDbl(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Saldo")))
            MVVenta.SetActiveView(ContenidoPrinicpal)
        Else
            _venta.IdPersona = EntidadConsultarPersona.IdPersona
            ClienteNombre(CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Nombre")))
            _venta.SaldoDisponible = CDbl(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Saldo"))
            ClienteSaldo(_venta.SaldoDisponible)
            ClienteDomicilio(CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Domicilio")))
            ClienteTelefono(CStr(EntidadConsultarPersona.TablaConsulta.Rows(0).Item("Telefono")))
            MVVenta.SetActiveView(ContenidoPrinicpal)
            MostrarBotones()
            ObtenerAval()
        End If
        _busquedaAval = False
        TBXCodigo.Text = ""
    End Sub

    Private Sub ObtenerAval()
        '===== consulta que obtiene el aval del cliente
        AvalDatos(0, "", "", "", 0)
    End Sub

    Private Sub FuncionF11()
        MVVenta.SetActiveView(ContenidoBuscarVenta)
        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
        CType(Master.FindControl("LBVCambiar"), Label).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Text = "BUSCAR"
        WucBuscarVenta.Inicializar()
    End Sub
    Protected Sub BTNBuscarProducto_Click(sender As Object, e As ImageClickEventArgs)
        BuscarProducto(0)

    End Sub

    Private Sub BuscarProducto(IdAlmacen As Integer)
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()
        EntidadConsultarProducto.Descripcion = TBXCodigo.Text
        If IdAlmacen > 0 Then
            EntidadConsultarProducto.IdAlmacen = IdAlmacen
        Else
            EntidadConsultarProducto.IdAlmacen = _venta.IdAlmacen
        End If
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorId
        NegocioConsultarProducto.VentaObtener(EntidadConsultarProducto)
        If EntidadConsultarProducto.TablaConsulta.Rows.Count = 1 Then
            Dim produ As Entidad.Producto
            produ = New Entidad.Producto()
            produ.IdProducto = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("ID"))
            produ.IdProductoCorto = CStr(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Id Corto"))
            produ.Descripcion = CStr(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Producto"))
            produ.IdClasificacion = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("IdClasificacion"))
            produ.Clasificacion = CStr(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Clasificacion"))
            produ.IdSubclasificacion = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("IdSubclasificacion"))
            produ.Subclasificacion = CStr(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Subclasificacion"))
            produ.PrecioBase = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("PrecioBase"))
            produ.Ganancia = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Ganancia"))
            produ.Porcentaje = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Porcentaje"))
            produ.Cantidad = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Cantidad"))
            produ.IdAlmacen = CInt(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("IdAlmacen"))
            produ.Almacen = CStr(EntidadConsultarProducto.TablaConsulta.Rows(0).Item("Almacen"))

            _busquedaProducto = produ

            SeleccionarBusqueda()
            'TablaPromociones
        Else
            wucConPrd.BusquedaSucursal = True
            wucConPrd.LimpiarConsulta()
            wucConPrd.Buscar(TBXCodigo.Text, EntidadConsultarProducto.IdAlmacen)
            MVVenta.SetActiveView(ContenidoBuscarProducto)
            CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
            CType(Master.FindControl("LBVCambiar"), Label).Visible = True
            CType(Master.FindControl("LBVCambiar"), Label).Text = "BUSCAR PRODUCTO"
        End If
        TBXCodigo.Text = ""
    End Sub

    Private Sub BuscarPromocion(IdProducto As Integer, IdProductoCorto As String, Producto As String)
        Dim EntidadConsultaPromocionDescuento As New Entidad.Promocion
        Dim NegocioConsultaPromocionDescuento As New Negocio.Promocion
        EntidadConsultaPromocionDescuento.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadConsultaPromocionDescuento.IdPromocion = IdProducto
        EntidadConsultaPromocionDescuento.IdSucursal = _venta.IdSucursal
        NegocioConsultaPromocionDescuento.ObtenerPromocion(EntidadConsultaPromocionDescuento)

        If EntidadConsultaPromocionDescuento.TablaConsulta.Rows.Count > 0 Then
            Dim promo As Entidad.VentaPromocion
            For ind = 0 To EntidadConsultaPromocionDescuento.TablaConsulta.Rows.Count - 1
                Dim fila = EntidadConsultaPromocionDescuento.TablaConsulta.Rows(ind)
                promo = New Entidad.VentaPromocion()

                promo.IdPromocion = CInt(fila("ID"))
                promo.IdProducto = IdProducto
                promo.IdProductoCorto = IdProductoCorto
                promo.IdTipoPromocion = CInt(fila("IdTipoPromocion"))
                promo.TipoDescuento = CInt(fila("TipoDescuento"))
                promo.Descuento = CDbl(fila("Descuento"))
                promo.IdTipoExtra = CInt(fila("IdTipoExtra"))
                promo.Extra = CInt(fila("Extra"))
                promo.IdTipoGracia = CInt(fila("IdTipoExtra"))
                promo.Gracia = CInt(fila("Extra"))
                promo.Descripcion = CStr(fila("Descripcion"))
                promo.DescripcionOriginal = CStr(fila("Descripcion"))
                promo.Observacion = CStr(fila("Observacion"))

                Dim promocion = ""
                Dim promocionProducto = ""
                If Producto.Length > 30 Then
                    promocionProducto = "El producto: " + Producto.Substring(0, 30) + "... tiene "
                Else
                    promocionProducto = "El producto: " + Producto + " tiene "
                End If

                If promo.IdTipoPromocion = 1 Then
                    If promo.Descuento > 0 Then
                        If promo.TipoDescuento = 0 Then
                            promocion += "$" + promo.Descuento.ToString() + " de descuento"
                        Else
                            promocion += promo.Descuento.ToString() + "% de descuento"
                        End If
                    End If

                    If promo.Gracia > 0 Then
                        promocion += ", "
                        If promo.IdTipoGracia = 0 Then
                            If promo.Gracia = 1 Then
                                promocion += promo.Gracia.ToString() + " dia adicional para empezar a pagar"
                            Else
                                promocion += promo.Gracia.ToString() + " dias adicionales para empezar a pagar"
                            End If
                        Else
                            If promo.Gracia = 1 Then
                                promocion += promo.Gracia.ToString() + " mes adicional para empezar a pagar"
                            Else
                                promocion += promo.Gracia.ToString() + " meses adicionales para empezar a pagar"
                            End If
                        End If
                    End If

                    If promo.Extra > 0 Then
                        promocion += ", "
                        If promo.IdTipoExtra = 0 Then
                            If promo.Extra = 1 Then
                                promocion += promo.Extra.ToString() + " dia adicional para pagar"
                            Else
                                promocion += promo.Extra.ToString() + " dias adicionales para pagar"
                            End If
                        Else
                            If promo.Extra = 1 Then
                                promocion += promo.Extra.ToString() + " mes adicional para pagar"
                            Else
                                promocion += promo.Extra.ToString() + " meses adicionales para pagar"
                            End If
                        End If
                    End If
                    promo.Descripcion = promocionProducto + promocion
                    promo.DescripcionDetalle = promocion
                Else
                    promo.Descripcion = promocionProducto + promocion + " obsequio de " + promo.Observacion + " sin costo"
                    promo.DescripcionDetalle = promocion + " obsequio de " + promo.Observacion + ", sin costo"
                End If

                _listaPromocion.Add(promo)
                'Agregar promocion automaticamente
                If ind = EntidadConsultaPromocionDescuento.TablaConsulta.Rows.Count - 1 Then
                    'If existePromocion Then
                    Try
                        For i = 0 To _listaPromocion.Count - 1
                            If _listaPromocion(i).IdPromocion = promo.IdPromocion Then
                                GVPromociones.SelectedIndex = i
                                AgregarPromocion()
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                End If
                ' End If
            Next
        End If
        MostrarPromociones()
    End Sub

    Protected Sub BTNDescuentoAgregar_Click(sender As Object, e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVPromociones.SelectedIndex = gvrFilaActual.RowIndex
        AgregarPromocion()
    End Sub

    Private Sub AgregarPromocion()
        If Not _venta.IdTipoVenta = TipoVenta.Apartado Then
            If GVPromociones.SelectedIndex > -1 Then
                Try
                    For i = 0 To _venta.Detalle.Count - 1
                        If _venta.Detalle(i).IdProducto = _listaPromocion(GVPromociones.SelectedIndex).IdProducto Then
                            _venta.Detalle(i).Promocion = _listaPromocion(GVPromociones.SelectedIndex).DescripcionDetalle
                        End If
                    Next
                    ComprobarDoblePromocion()
                    If _listaPromocion(GVPromociones.SelectedIndex).IdTipoPromocion = 1 Then
                        _venta.Descuento.Add(AgregarFilaDescuento())
                    Else
                        _venta.Obsequio.Add(AgregarFilaObsequio())
                    End If
                Catch ex As Exception
                    Dim e = ex.Message
                End Try

                CalculaTodo()
                Try
                    GVVentaDetalle.SelectedIndex = GVVentaDetalle.Rows.Count - 1
                    TBXCodigo.Focus()
                Catch ex As Exception
                End Try
                QuitarPromocionRepetidaActiva()
                MostrarPromociones()
                MostrarProductosVenta()
                MostrarTotalVenta()
            End If
            'MostrarProductosVenta()
        End If
    End Sub

    Private Function AgregarFilaObsequio() As Entidad.VentaObsequio
        ''Variable que se va a devolver
        Dim obsequio As New Entidad.VentaObsequio
        'Para no estar usando siempre GVPromociones.SelectedIndex
        Dim index = GVPromociones.SelectedIndex
        obsequio.IdPromocion = _listaPromocion(index).IdPromocion
        obsequio.IdProducto = _listaPromocion(index).IdProducto
        obsequio.IdProductoCorto = _listaPromocion(index).IdProductoCorto
        obsequio.Descripcion = _listaPromocion(index).Descripcion
        obsequio.Observacion = _listaPromocion(index).Observacion
        obsequio.DescripcionDetalle = _listaPromocion(index).DescripcionDetalle
        obsequio.DescripcionOriginal = _listaPromocion(index).DescripcionOriginal
        obsequio.IdTipoCargo = _listaPromocion(index).TipoDescuento
        obsequio.IdEstado = 1

        'Obstenemos la cantidad del producto que da el obsequio para este asignar la cantidad de regalo ajustada correctamente
        Dim cantidadProductoPadre = 0
        For Each producto In From producto1 In _venta.Detalle Where producto1.IdProducto = obsequio.IdProducto
            cantidadProductoPadre = producto.Cantidad
        Next

        'Si el cargo que se le va a aplicar al producto que da el obsequio es en monto o en porcentaje
        If _listaPromocion(index).TipoDescuento = 0 Then
            obsequio.Cargo = _listaPromocion(index).Descuento
            obsequio.CargoPorcentaje = 0
        Else
            obsequio.Cargo = 0
            obsequio.CargoPorcentaje = _listaPromocion(index).Descuento
        End If

        Dim existeDetalleObsequio = False
        For j = 0 To _venta.Obsequio.Count - 1
            If _venta.Obsequio(j).IdPromocion = obsequio.IdPromocion And _venta.Obsequio(j).IdProducto = obsequio.IdProducto Then
                existeDetalleObsequio = True
            End If
        Next

        If Not existeDetalleObsequio Then
            obsequio.Detalle = New ObservableCollection(Of Entidad.VentaObsequioDetalle)
        End If
        'Se realiza una consulta en la que se obtienen los productos que se van a regalar
        Dim NegocioVenta As New Negocio.Venta()
        Dim EntidadProducto As New Entidad.Producto()
        EntidadProducto.IdProducto = _listaPromocion(GVPromociones.SelectedIndex).IdProducto
        EntidadProducto.IdTipo = _listaPromocion(GVPromociones.SelectedIndex).IdPromocion
        EntidadProducto.IdSucursal = _venta.IdSucursal
        NegocioVenta.ObtenerObsequio(EntidadProducto)
        'Se procede a recorrer cada registro de los resultados
        For Each row In EntidadProducto.TablaConsulta.Rows
            Dim obsequioDetalle As New Entidad.VentaObsequioDetalle
            obsequioDetalle.IdProducto = CInt(row("ID"))
            obsequioDetalle.IdProductoCorto = CStr(row("ID Corto"))
            obsequioDetalle.Producto = CStr(row("Producto"))
            obsequioDetalle.PrecioBase = CDbl(row("PrecioBase"))
            obsequioDetalle.CantidadRegalada = CInt(row("Cantidad")) * cantidadProductoPadre
            obsequioDetalle.Ganancia = CDbl(row("Ganancia"))
            obsequioDetalle.CantidadRegalo = CInt(row("Cantidad"))
            obsequioDetalle.IdAlmacen = CInt(row("IdAlmacen"))
            obsequioDetalle.Almacen = CStr(row("Almacen"))
            obsequioDetalle.VentaExistenciaCero = CInt(row("IdPermitirVentaCeroExistencia"))
            obsequioDetalle.IdEstado = 1

            'De igual forma se obtiene el cargo que se le va a aplicar al prodcuto que da el obsequio pero esta vez por cada producto que se va a regalar
            If _listaPromocion(index).TipoDescuento = 0 Then
                obsequioDetalle.Total = obsequio.Cargo
            Else
                obsequioDetalle.Total = CDbl(row("PrecioBase")) * (obsequio.CargoPorcentaje / 100)
            End If
            'Esta bandera sirve para saber si el producto de obsequio ya esta agregado a la venta si es asi solo se agrega la cantidad de regalo
            Dim existeProducto = False
            For j = 0 To _venta.Detalle.Count - 1
                If _venta.Detalle(j).IdProducto = obsequioDetalle.IdProducto Then
                    _venta.Detalle(j).Cantidad += obsequioDetalle.CantidadRegalada
                    existeProducto = True
                End If
            Next
            'Si el producto de obsequio no esta agregado solo se agrega a la venta detalle
            If Not existeProducto Then
                Dim filaVentaDetalle As New Entidad.VentaDetalle
                filaVentaDetalle.IdProducto = obsequioDetalle.IdProducto
                filaVentaDetalle.IdProductoCorto = obsequioDetalle.IdProductoCorto
                filaVentaDetalle.Producto = obsequioDetalle.Producto
                filaVentaDetalle.PrecioBase = obsequioDetalle.PrecioBase
                filaVentaDetalle.CantidadInventario = CInt(row("CantidadInventario"))
                filaVentaDetalle.Cantidad = obsequioDetalle.CantidadRegalada
                filaVentaDetalle.DescuentoPorcentaje = 0
                filaVentaDetalle.DescuentoContado = 0
                filaVentaDetalle.DescuentoCredito = 0
                filaVentaDetalle.Ganancia = obsequioDetalle.Ganancia
                filaVentaDetalle.TotalContado = obsequioDetalle.PrecioBase
                filaVentaDetalle.SubtotalContado = obsequioDetalle.PrecioBase
                filaVentaDetalle.IdAlmacen = obsequioDetalle.IdAlmacen
                filaVentaDetalle.Almacen = obsequioDetalle.Almacen
                filaVentaDetalle.Promocion = ""
                filaVentaDetalle.VentaExistenciaCero = obsequioDetalle.VentaExistenciaCero
                _venta.Detalle.Add(filaVentaDetalle)
            End If
            obsequioDetalle.Total = obsequioDetalle.Total * obsequioDetalle.CantidadRegalada
            'Lo siguiente es solo agregar los detalles del producto a la tabla detalle del obsequio que se esta agregando
            If existeDetalleObsequio Then
                For j = 0 To _venta.Obsequio.Count - 1
                    If _venta.Obsequio(j).IdPromocion = obsequio.IdPromocion Then
                        For h = 0 To _venta.Obsequio(j).Detalle.Count - 1
                            If _venta.Obsequio(j).Detalle(h).IdProducto = obsequioDetalle.IdProducto Then
                                _venta.Obsequio(j).Detalle(h) = obsequioDetalle
                            End If
                        Next
                    End If
                Next
            Else
                obsequio.Detalle.Add(obsequioDetalle)
            End If
        Next
        TBXCodigo.Text = ""
        _listaPromocion.RemoveAt(index)
        Return obsequio
    End Function

    Private Function AgregarFilaDescuento() As Entidad.VentaDescuento
        Dim descuento As New Entidad.VentaDescuento
        Dim index = GVPromociones.SelectedIndex
        Dim promo As New Entidad.VentaPromocion
        descuento.IdPromocion = _listaPromocion(index).IdPromocion
        descuento.IdTipoDescuento = _listaPromocion(index).TipoDescuento
        If _listaPromocion(index).TipoDescuento = 0 Then
            descuento.Descuento = _listaPromocion(index).Descuento
            descuento.DescuentoPorcentaje = 0
        Else
            descuento.Descuento = 0
            descuento.DescuentoPorcentaje = _listaPromocion(index).Descuento
        End If
        descuento.Descripcion = _listaPromocion(index).Descripcion
        descuento.DescripcionDetalle = _listaPromocion(index).DescripcionDetalle
        descuento.DescripcionOriginal = _listaPromocion(index).DescripcionOriginal
        descuento.Observacion = _listaPromocion(index).Observacion
        descuento.Extra = _listaPromocion(index).Extra
        descuento.IdTipoExtra = _listaPromocion(index).IdTipoExtra
        descuento.Gracia = _listaPromocion(index).Gracia
        descuento.IdTipoGracia = _listaPromocion(index).IdTipoGracia
        descuento.IdProducto = _listaPromocion(index).IdProducto
        descuento.IdProductoCorto = _listaPromocion(index).IdProductoCorto
        descuento.IdEstado = 1
        _listaPromocion.RemoveAt(index)
        Return descuento
    End Function

    Private Sub ComprobarDoblePromocion()
        Dim index = GVPromociones.SelectedIndex
        Dim posicion = -1
        Dim descuento = False
        For j = 0 To _venta.Descuento.Count - 1
            If _venta.Descuento(j).IdProducto = _listaPromocion(index).IdProducto Then
                posicion = j
                descuento = True
            End If
        Next
        For j = 0 To _venta.Obsequio.Count - 1
            If _venta.Obsequio(j).IdProducto = _listaPromocion(index).IdProducto Then
                posicion = j
            End If
        Next
        If posicion > -1 Then
            Dim _promoRespaldo As New Entidad.VentaPromocion
            If descuento Then
                _promoRespaldo.IdPromocion = _venta.Descuento(posicion).IdPromocion
                _promoRespaldo.IdProducto = _venta.Descuento(posicion).IdProducto
                _promoRespaldo.IdProductoCorto = _venta.Descuento(posicion).IdProductoCorto
                _promoRespaldo.IdTipoPromocion = 1
                _promoRespaldo.TipoDescuento = _venta.Descuento(posicion).IdTipoDescuento
                If _venta.Descuento(posicion).IdTipoDescuento = 0 Then
                    _promoRespaldo.Descuento = _venta.Descuento(posicion).Descuento
                Else
                    _promoRespaldo.Descuento = _venta.Descuento(posicion).DescuentoPorcentaje
                End If
                _promoRespaldo.IdTipoExtra = _venta.Descuento(posicion).IdTipoExtra
                _promoRespaldo.Extra = _venta.Descuento(posicion).Extra
                _promoRespaldo.IdTipoGracia = _venta.Descuento(posicion).IdTipoExtra
                _promoRespaldo.Gracia = _venta.Descuento(posicion).Extra
                _promoRespaldo.Descripcion = _venta.Descuento(posicion).Descripcion
                _promoRespaldo.DescripcionDetalle = _venta.Descuento(posicion).DescripcionDetalle
                _promoRespaldo.DescripcionOriginal = _venta.Descuento(posicion).DescripcionOriginal
                _promoRespaldo.Observacion = _venta.Descuento(posicion).Observacion

                _venta.Descuento.RemoveAt(posicion)
            Else
                _promoRespaldo.IdPromocion = _venta.Obsequio(posicion).IdPromocion
                _promoRespaldo.IdProducto = _venta.Obsequio(posicion).IdProducto
                _promoRespaldo.IdProductoCorto = _venta.Obsequio(posicion).IdProductoCorto
                _promoRespaldo.IdTipoPromocion = 2
                _promoRespaldo.TipoDescuento = _venta.Obsequio(posicion).IdTipoCargo
                If _venta.Obsequio(posicion).IdTipoCargo = 0 Then
                    _promoRespaldo.Descuento = _venta.Obsequio(posicion).Cargo
                Else
                    _promoRespaldo.Descuento = _venta.Obsequio(posicion).CargoPorcentaje
                End If
                _promoRespaldo.Descripcion = _venta.Obsequio(posicion).Descripcion
                _promoRespaldo.DescripcionDetalle = _venta.Obsequio(posicion).DescripcionDetalle
                _promoRespaldo.DescripcionOriginal = _venta.Obsequio(posicion).DescripcionOriginal
                _promoRespaldo.Observacion = _venta.Obsequio(posicion).Observacion
                Dim posicionProductos As New List(Of Integer)
                For i = 0 To _venta.Detalle.Count - 1
                    For j = 0 To _venta.Obsequio.Count - 1
                        For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                            If _venta.Obsequio(j).Detalle(k).IdProducto = _venta.Detalle(i).IdProducto Then 'And _venta.Obsequio(j).Detalle(k).IdAlmacen = _venta.Detalle(i).IdAlmacen Then
                                _venta.Detalle(i).Cantidad -= _venta.Obsequio(j).Detalle(k).CantidadRegalada
                                If _venta.Detalle(i).Cantidad = 0 Then
                                    posicionProductos.Add(i)
                                End If
                            End If
                        Next
                    Next
                Next
                Dim elimina = 0
                For Each o In posicionProductos
                    _venta.Detalle.RemoveAt(o - elimina)
                    elimina += 1
                Next
                _venta.Obsequio.RemoveAt(posicion)
            End If
            _listaPromocion.Add(_promoRespaldo)
        End If
    End Sub

    Private Sub MostrarPromociones()
        Try
            LBPromociones.Text = _listaPromocion.Count.ToString()
            GVPromociones.DataSource = _listaPromocion
            GVPromociones.DataBind()
        Catch ex As Exception
            LBPromociones.Text = ""
            GVPromociones.DataSource = Nothing
            GVPromociones.DataBind()
        End Try
    End Sub

    Private Sub BusquedaVentaSeleccionado(sender As Object, e As EventArgs)
        _venta.Id = WucConsultarVenta.IdVenta
        _venta.IdTipoVenta = WucConsultarVenta.IdTipoVenta
        CargarVenta()
        CalculaTodo()
        If _venta.IdTipoVenta = TipoVenta.Contado Then
            VerVentaContado()
        ElseIf _venta.IdTipoVenta = TipoVenta.Credito Then
            VerVentaCredito()
        ElseIf _venta.IdTipoVenta = TipoVenta.Apartado Then
            VerVentaApartado()
        End If
        MVVenta.SetActiveView(ContenidoPrinicpal)
    End Sub

    Private Sub CargarVenta()
        Dim idVenta = _venta.Id
        NuevaVenta(_venta.IdTipoVenta)
        _venta.Id = idVenta
        Dim NegocioVenta As New Negocio.Venta()
        _venta.Tarjeta.Consulta = Consulta.ConsultaPorId
        NegocioVenta.Consultar(_venta)
        CType(Master.FindControl("LBVCambiar"), Label).Text = "- " + _venta.IdTipoVenta.ToString().ToUpper()
        TBLVFolio.Text = "Folio: " + _venta.Folio
        If _venta.FolioFisico.Length > 1 Then
            TBFolio2.Text = _venta.FolioFisico
            LBFolio2.Text = "Folio Fisico: " + _venta.FolioFisico
        End If
        ClienteNombre(_venta.Persona)
        ClienteSaldo(_venta.SaldoDisponible)
        ClienteDomicilio(_venta.DomicilioEntrega)
        ClienteTelefono(_venta.Identificacion)
        LBPLPlazoContado.Text = _venta.Credito.PlazoContado
        LBPLPlazoCredito.Text = _venta.Credito.PlazoCredito
        LBPeriodo1.Text = _venta.Credito.Periodo
        LBPeriodo2.Text = _venta.Credito.Periodo
        LBXPCEAnticipo.Text = String.Format("{0:c}", _venta.Credito.Anticipo)
        AvalDatos(_venta.Credito.IdAval, _venta.Credito.Aval, _venta.Credito.AvalDomicilio, _venta.Credito.AvalTelefono, 0)

        CargaMasDetallesVenta()
    End Sub

    Private Sub CargaMasDetallesVenta()
        _ventaNueva = False
        MostrarProductosVenta()
        DesactivaInteraccion()
        MostrarCargos()
        BTNVReimprimir.Visible = True
        If _venta.IdVentaEstado = 1 Then
            TBLEstadoVenta.Text = TipoVentaEstado.AUTORIZADO.ToString()
        ElseIf _venta.IdVentaEstado = 2 Then
            TBLEstadoVenta.Text = TipoVentaEstado.CANCELADO.ToString()
        ElseIf _venta.IdVentaEstado = 3 Then
            TBLEstadoVenta.Text = TipoVentaEstado.RECHAZADO.ToString()
        ElseIf _venta.IdVentaEstado = 4 Then
            TBLEstadoVenta.Text = TipoVentaEstado.ACTIVO.ToString()
            BTNVCancelar.Visible = True
        ElseIf _venta.IdVentaEstado = 5 Then
            TBLEstadoVenta.Text = TipoVentaEstado.LIQUIDADO.ToString()
        Else
            TBLEstadoVenta.Text = TipoVentaEstado.PENDIENTE.ToString()
            BTNVFinalizar.Visible = True
            BTNVPendiente.Visible = True
            BTNVCancelar.Visible = True
            BTNVReimprimir.Visible = False
            MostrarBotones()
            ActivaInteraccion()
        End If

        For Each detalle In _venta.Detalle
            For Each descuento In From descuento1 In _venta.Descuento Where detalle.IdProducto = descuento1.IdProducto
                detalle.Promocion = descuento.Observacion
            Next
            For Each obsequio In From obsequio1 In _venta.Obsequio Where detalle.IdProducto = obsequio1.IdProducto
                detalle.Promocion = obsequio.Observacion
            Next
        Next
    End Sub

    Protected Sub CBPEPeriodo_TextChanged(sender As Object, e As EventArgs)
        CalculaTodo()
    End Sub
    Protected Sub CBPLPlazoCredito_TextChanged(sender As Object, e As EventArgs)
        plazoCreditoManual = True
        If _venta.Detalle.Count > 0 Then
            CalculaTodo()
        End If
    End Sub
    Protected Sub CBPLPlazoContado_TextChanged(sender As Object, e As EventArgs)
        plazoContadoManual = True
        If _venta.Detalle.Count > 0 Then
            CalculaTodo()
        End If
    End Sub
    Protected Sub BTNBuscarPersona_Click(sender As Object, e As EventArgs) Handles IBTNBuscarPersonaxs.Click, IBTNBuscarPersona.Click
        _busquedaAval = False
        MVVenta.SetActiveView(ContenidoBuscarPersona)
        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
        CType(Master.FindControl("LBVCambiar"), Label).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Text = "BUSCAR PERSONA"
        WucBuscarPersona1.Buscar("")
    End Sub
    Protected Sub BTNABuscarPersona_Click(sender As Object, e As EventArgs) Handles IBTNABuscarPersonaxs.Click, IBTNABuscarPersona.Click
        If _venta.IdPersona > 1 Then
            _busquedaAval = True
            MVVenta.SetActiveView(ContenidoBuscarPersona)
            CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
            CType(Master.FindControl("LBVCambiar"), Label).Visible = True
            CType(Master.FindControl("LBVCambiar"), Label).Text = "BUSCAR AVAL"
            WucBuscarPersona1.Buscar("")
        End If
    End Sub
    Protected Sub BTNRegistrarPersona_Click(sender As Object, e As EventArgs) Handles IBTNRegistrarPersonaxs.Click, IBTNRegistrarPersona.Click
        Session("_venta") = _venta
        Session("OrigenVenta") = True
        Session("Aval") = False
        Session("IdPersona") = _venta.IdPersona
        Response.Redirect("~/Privada/Cliente/Proceso/RegistroPersonas.aspx")
    End Sub
    Protected Sub BTNARegistrarPersona_Click(sender As Object, e As EventArgs) Handles IBTNARegistrarPersonaxs.Click, IBTNARegistrarPersona.Click
        If _venta.IdPersona > 1 Then
            Session("_venta") = _venta
            Session("OrigenVenta") = True
            Session("Aval") = True
            Session("IdPersona") = _venta.IdPersona
            Response.Redirect("~/Privada/Cliente/Proceso/RegistroPersonas.aspx")
        End If
    End Sub
    Private Sub DesactivaInteraccion()
        TBXCodigo.Visible = False
        CBPLPlazoContado.Visible = False
        CBPLPlazoCredito.Visible = False
        LBPLPlazoContado.Visible = True
        LBPLPlazoCredito.Visible = True
        TBXPCEAnticipo.Visible = False
        LBXPCEAnticipo.Visible = True
        TBLCDomicilio.Enabled = False
        TBLCDomicilioxs.Enabled = False
        IBTNBuscarProducto.Visible = False
        IBTNBuscarPersona.Visible = False
        IBTNBuscarPersonaxs.Visible = False
        GVVentaDetalle.Columns(5).Visible = False
        DDPeriodo1.Visible = False
        DDPeriodo2.Visible = False
        LBPeriodo1.Visible = True
        LBPeriodo2.Visible = True
        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = False
        CType(Master.FindControl("LBVCambiar"), Label).Visible = True
        GVCargos.Columns(0).Visible = False
        TBLCDomicilio.Visible = False
        TBLCDomicilioxs.Visible = False
        TBFolio2.Visible = False
    End Sub
    Private Sub ActivaInteraccion()
        TBXCodigo.Visible = True
        CBPLPlazoContado.Visible = True
        CBPLPlazoCredito.Visible = True
        LBPLPlazoContado.Visible = False
        LBPLPlazoCredito.Visible = False
        TBXPCEAnticipo.Visible = True
        LBXPCEAnticipo.Visible = False
        TBLCDomicilio.Enabled = True
        TBLCDomicilioxs.Enabled = True
        IBTNBuscarProducto.Visible = True
        IBTNBuscarPersona.Visible = True
        IBTNBuscarPersonaxs.Visible = True
        GVVentaDetalle.Columns(5).Visible = True
        DDPeriodo1.Visible = True
        DDPeriodo2.Visible = True
        LBPeriodo1.Visible = False
        LBPeriodo2.Visible = False
        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False
        GVCargos.Columns(0).Visible = True
        LBFolio2.Visible = False
        TBFolio2.Visible = True
        TBLCDomicilio.Visible = True
        TBLCDomicilioxs.Visible = True
    End Sub
    Private Sub VerVentaContado()
        litabcontado.Visible = False
        litabcredito.Visible = False
        TBXPCEAnticipo.Visible = False
        litabaval.Visible = False
        litabavalxs.Visible = False
        litabcargo.Visible = True
        litabpromocion.Visible = True
        'CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Contado
        'If _venta.Persona = Nothing Or _venta.IdPersona = 1 Then
        '    ClienteNombre("Publico General")
        'End If
        MostrarBotones()
    End Sub
    Private Sub VerVentaCredito()
        litabcontado.Visible = True
        litabcredito.Visible = True
        TBXPCEAnticipo.Visible = True
        litabaval.Visible = True
        litabavalxs.Visible = True
        litabcargo.Visible = True
        litabpromocion.Visible = True
        divPeriodoContado.Visible = True
        divAbonoContado.Visible = True
        divTotalContado.Visible = True
        TBXPCEAnticipo.Text = "0"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "VentaCredito();", True)
        'CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Credito
        'If _venta.Persona = Nothing Or _venta.IdPersona = 1 Then
        '    ClienteNombre("")
        'End If
        MostrarBotones()
    End Sub
    Private Sub VerVentaApartado()
        litabcontado.Visible = True
        litabcredito.Visible = False
        litabaval.Visible = False
        litabavalxs.Visible = False
        litabcargo.Visible = False
        litabpromocion.Visible = False
        TBXPCEAnticipo.Visible = True
        divAbonoContado.Visible = False
        divPeriodoContado.Visible = False
        divTotalContado.Visible = False
        TBXPCEAnticipo.Text = "0"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "VentaApartado();", True)
        'CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Apartado
        'If _venta.Persona = Nothing Or _venta.IdPersona = 1 Then
        '    ClienteNombre("")
        'End If
        MostrarBotones()
    End Sub

    'Private Sub LlenarDDs()
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Try
    '        Dim NegocioTipoVenta As New Negocio.TipoVenta()
    '        Dim EntidadTipoVenta As New Entidad.TipoVenta()
    '        EntidadTipoVenta.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
    '        NegocioTipoVenta.Consultar(EntidadTipoVenta)

    '        For Each row In EntidadTipoVenta.TablaConsulta.Rows
    '            Select Case row("Descripcion").ToString.ToLower()
    '                Case "credito"
    '                    DDVCambiar.Items.Add(New ListItem("Venta a " + TipoVenta.Credito.ToString(), TipoVenta.Credito))
    '                Case "contado"
    '                    DDVCambiar.Items.Add(New ListItem("Venta a " + TipoVenta.Contado.ToString(), TipoVenta.Contado))
    '                Case "apartado"
    '                    DDVCambiar.Items.Add(New ListItem("Venta a " + TipoVenta.Apartado.ToString(), TipoVenta.Apartado))
    '            End Select
    '        Next
    '    Catch ex As Exception
    '        DDVCambiar.Items.Add(New ListItem("Error - Sin Tipo de Ventas"))
    '    End Try

    'End Sub

    Protected Sub TBXPCEAnticipo_OnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarAnticipo()
    End Sub

    <WebMethod>
    Public Shared Sub ActualizaCantidad(cantidad As String, codigo As String)
        '_venta.Detalle()
        If IsNumeric(cantidad) Then
            _cantidadCambio = CInt(cantidad)
            _cantidadCodigo = codigo
        End If
    End Sub

    Protected Sub BTNActualizaCantidad_Click(sender As Object, e As EventArgs)
        If _ventaNueva Then
            RecalculaCantidades()
            CalculaTodo()
        End If
    End Sub

    Private Sub RecalculaCantidades()
        For i = 0 To _venta.Detalle.Count - 1
            If _venta.Detalle(i).IdProductoCorto = _cantidadCodigo Then
                Dim cantidadRegalo = 0
                For j = 0 To _venta.Obsequio.Count - 1
                    For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                        If _venta.Obsequio(j).Detalle(k).IdProductoCorto = _cantidadCodigo Then
                            cantidadRegalo += _venta.Obsequio(j).Detalle(k).CantidadRegalada
                        End If
                    Next
                Next

                ' Dim diferenciaDetalleRegalo = CantidadRegalada - _venta.Detalle(i).Cantidad

                If _cantidadCambio > cantidadRegalo Then
                    If _cantidadCambio = 0 Then
                        EliminarProducto(i)
                    Else
                        If _cantidadCambio <= _venta.Detalle(i).CantidadInventario Or _venta.Detalle(i).VentaExistenciaCero = 1 Then
                            _venta.Detalle(i).Cantidad = _cantidadCambio
                        Else
                            _venta.Detalle(i).Cantidad = _venta.Detalle(i).CantidadInventario
                        End If
                    End If
                    ''Si es mayor hay que multiplicar los obsequios por la nueva cantidad del producto que da el obsequio
                    'por ejemplo un celular lg regala una memoria de 8gb, si modificas la cantidad del lg a 3 entonces por logica
                    'el obsequio deberian ser tambien 3 memorias
                    Dim diferencia = _cantidadCambio - cantidadRegalo
                    For j = 0 To _venta.Obsequio.Count - 1
                        If _cantidadCodigo = _venta.Obsequio(j).IdProductoCorto Then
                            For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                                _venta.Obsequio(j).Detalle(k).CantidadRegalada = _venta.Obsequio(j).Detalle(k).CantidadRegalo * diferencia
                                _venta.Obsequio(j).Detalle(k).Total = _venta.Obsequio(j).Detalle(k).PrecioBase * diferencia

                                For h = 0 To _venta.Detalle.Count - 1
                                    If _venta.Detalle(h).IdProducto = _venta.Obsequio(j).Detalle(k).IdProducto Then
                                        _venta.Detalle(h).Cantidad = _venta.Obsequio(j).Detalle(k).CantidadRegalada
                                    End If
                                Next
                            Next
                        End If
                    Next
                Else
                    _venta.Detalle(i).Cantidad = cantidadRegalo
                    If _venta.Detalle(i).Cantidad = 0 Then
                        EliminarProducto(i)
                        CalculaTodo()
                        MostrarPromociones()
                    End If
                End If
                Try
                    BuscarPromocion(_venta.Detalle(i).IdProducto, _venta.Detalle(i).IdProductoCorto, _venta.Detalle(i).Producto)
                Catch ex As Exception
                Finally
                    _cantidadCambio = 0
                    _cantidadCodigo = ""
                End Try
            End If
        Next
    End Sub

    Private Sub CalculaTodo()
        Select Case _venta.IdTipoVenta
            Case TipoVenta.Contado
                CalculaPreciosContado()
            Case TipoVenta.Credito
                CalculaPreciosCredito()
            Case TipoVenta.Apartado
                CalculaPreciosApartado()
        End Select
    End Sub

    Protected Sub BTNQuitarProducto_OnClick(sender As Object, e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        EliminarProducto(gvrFilaActual.RowIndex)
        CalculaTodo()
        MostrarPromociones()
    End Sub
    Private Sub EliminarProducto(index As Integer)
        'Primero obtenemos la posicion del producto que se esta eliminando para eliminar esa promocion del descuento
        'Eliminamos el registro del descuento correspondiente al producto que se esta eliminando
        QuitarDescuento(index)
        'Lo siguiente es obtener la lista de promociones que tiene el producto que se esta eliminando
        QuitarPromocion(index)
        'Obtenemos la posicion del obsequio activado correspondiente al producto que se va a eliminar
        'el producto se elimina aqui ya que los productos estan junto con los productos obsequio por lo que no se puede eliminar un producto si
        'este tiene uno igual que es de obsequio, y solo debe de cambiarse la cantidad 
        QuitarObsequio(index)
    End Sub

    Private Sub QuitarDescuento(index As Integer)
        Dim item = -1
        For i = 0 To _venta.Descuento.Count - 1
            If _venta.Descuento(i).IdProducto = _venta.Detalle(index).IdProducto Then
                item = i
            End If
        Next
        If item > -1 Then
            _venta.Descuento.RemoveAt(item)
        End If
    End Sub
    Private Sub QuitarObsequio(index As Integer)
        Dim posicion = -1
        For j = 0 To _venta.Obsequio.Count - 1
            If _venta.Detalle(index).IdProductoCorto = _venta.Obsequio(j).IdProductoCorto Then
                posicion = j
            End If
        Next
        'Lo siguiente es obtener las posiciones que se van a eliminar de los obsequios correspondiente al producto que se esta eliminando
        Dim posicionProductos As New List(Of Integer)
        posicionProductos.Clear()
        If posicion > -1 Then
            posicionProductos.Add(index)
            For i = 0 To _venta.Detalle.Count - 1
                For k = 0 To _venta.Obsequio(posicion).Detalle.Count - 1
                    If _venta.Obsequio(posicion).Detalle(k).IdProducto = _venta.Detalle(i).IdProducto Then
                        posicionProductos.Add(i)
                    End If
                Next
            Next
            Dim elimina = 0
            posicionProductos.Sort()
            For Each o In posicionProductos
                Dim cantidadRegalo = 0
                For j = 0 To _venta.Obsequio.Count - 1
                    For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                        If _venta.Obsequio(j).Detalle(k).IdProductoCorto = _venta.Detalle(o - elimina).IdProductoCorto Then
                            cantidadRegalo += _venta.Obsequio(j).Detalle(k).CantidadRegalada
                        End If
                    Next
                Next

                Dim diferencia = _venta.Detalle(o - elimina).Cantidad - cantidadRegalo
                If diferencia = 0 Or o = index Then
                    QuitarPromocion(o - elimina)
                    _venta.Detalle.RemoveAt(o - elimina)
                    elimina += 1
                Else
                    For j = 0 To _venta.Obsequio.Count - 1
                        For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                            If _venta.Detalle(o - elimina).IdProductoCorto = _venta.Obsequio(j).Detalle(k).IdProductoCorto Then
                                _venta.Obsequio(j).Detalle(k).CantidadRegalada = _venta.Obsequio(j).Detalle(k).CantidadRegalo * diferencia
                                _venta.Obsequio(j).Detalle(k).Total = _venta.Obsequio(j).Detalle(k).PrecioBase * diferencia
                                'Si el producto es parte de obsequio, ejemplo: 1 producto que estas comprando y el otro es un regalo de otro producto
                                For h = 0 To _venta.Detalle.Count - 1
                                    If _venta.Detalle(h).IdProducto = _venta.Obsequio(j).Detalle(k).IdProducto Then
                                        _venta.Detalle(h).Cantidad = _venta.Obsequio(j).Detalle(k).CantidadRegalada

                                    End If
                                Next
                            End If
                        Next
                    Next
                End If
            Next
            _venta.Obsequio.RemoveAt(posicion)
        Else
            Dim cantidadRegalo = 0
            For j = 0 To _venta.Obsequio.Count - 1
                For k = 0 To _venta.Obsequio(j).Detalle.Count - 1
                    If _venta.Obsequio(j).Detalle(k).IdProductoCorto = _venta.Detalle(index).IdProductoCorto Then
                        cantidadRegalo += _venta.Obsequio(j).Detalle(k).CantidadRegalada
                    End If
                Next
            Next

            If cantidadRegalo > 0 Then
                Dim diferencia = _venta.Detalle(index).Cantidad - cantidadRegalo
                If diferencia = 0 Or _venta.IdTipoVenta = TipoVenta.Apartado Then 'Si la diferencia es 0 entonces se esta eliminando el producto de la promocion
                    For i = 0 To _venta.Obsequio.Count - 1
                        For j = 0 To _venta.Obsequio(i).Detalle.Count - 1
                            If _venta.Detalle(index).IdProducto = _venta.Obsequio(i).Detalle(j).IdProducto Then
                                _venta.Obsequio(i).Detalle.RemoveAt(j)
                            End If
                        Next
                        'Si al eliminar el producto del obsequio y la pormocion se queda sin ningun obsequio se elimina tambien la promocion padre
                        If _venta.Obsequio(i).Detalle.Count = 0 Then
                            'Antes volvemos a poner la promocion en la lista de promociones
                            Dim _promoRespaldo As New Entidad.VentaPromocion
                            _promoRespaldo.IdPromocion = _venta.Obsequio(i).IdPromocion
                            _promoRespaldo.IdProducto = _venta.Obsequio(i).IdProducto
                            _promoRespaldo.IdProductoCorto = _venta.Obsequio(i).IdProductoCorto
                            _promoRespaldo.IdTipoPromocion = 2
                            _promoRespaldo.TipoDescuento = _venta.Obsequio(i).IdTipoCargo
                            If _venta.Obsequio(i).IdTipoCargo = 0 Then
                                _promoRespaldo.Descuento = _venta.Obsequio(i).Cargo
                            Else
                                _promoRespaldo.Descuento = _venta.Obsequio(i).CargoPorcentaje
                            End If
                            _promoRespaldo.Descripcion = _venta.Obsequio(i).Descripcion
                            _promoRespaldo.DescripcionDetalle = _venta.Obsequio(i).DescripcionDetalle
                            _promoRespaldo.DescripcionOriginal = _venta.Obsequio(i).DescripcionOriginal
                            _promoRespaldo.Observacion = _venta.Obsequio(i).Observacion
                            _venta.Obsequio.RemoveAt(i)
                            _listaPromocion.Add(_promoRespaldo)
                            For j = 0 To _venta.Detalle.Count - 1
                                _venta.Detalle(j).Promocion = ""
                            Next
                        End If
                    Next
                    If _venta.IdTipoVenta = TipoVenta.Apartado Then
                        If diferencia = 0 Then
                            _venta.Detalle.RemoveAt(index)
                        Else
                            _venta.Detalle(index).Cantidad = diferencia
                        End If
                    Else
                        _venta.Detalle.RemoveAt(index)
                    End If
                Else 'Si la diferencia es mayo entonces se esta borrando el producto que se esta comprando y se debe de dejar el de obsequio
                    _venta.Detalle(index).Cantidad = cantidadRegalo
                    _venta.Detalle(index).Promocion = ""
                End If
            Else
                _venta.Detalle.RemoveAt(index)
            End If
            'EliminarProducto(index)
            '_venta.Detalle.RemoveAt(index)
        End If
    End Sub

    Private Sub QuitarPromocion(index As Integer)
        Dim posicionProductos As New List(Of Integer)
        For i = 0 To _listaPromocion.Count - 1
            If _listaPromocion(i).IdProducto = _venta.Detalle(index).IdProducto Then
                posicionProductos.Add(i)
            End If
        Next
        'Esta variable se incrementa conforme eliminamos un registro eso para que si por ejemplo
        'se esta eliminando el registro 4 y el siguiente es el 3 no se elimine el ultimo registro si no el que antes
        ' de eliminar el 4
        Dim elimina = 0
        For Each o In posicionProductos
            _listaPromocion.RemoveAt(o - elimina)
            elimina += 1
        Next
    End Sub

    Protected Sub GVVentaDetalle_OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub BTNActualizarAnticipo_OnClick(sender As Object, e As EventArgs)
        ActualizarAnticipo()
    End Sub

    Private Sub ActualizarAnticipo()
        Dim anticipo As Double = 0
        If IsNumeric(TBXPCEAnticipo.Text) Then
            anticipo = CDbl(TBXPCEAnticipo.Text)
            If anticipo < _venta.Total Then
                If anticipo > 0 Then
                    _venta.Credito.Anticipo = anticipo
                Else
                    _venta.Credito.Anticipo = 0
                    TBXPCEAnticipo.Text = String.Format("{0:c}", 0)
                End If
            Else
                _venta.Credito.Anticipo = 0
                TBXPCEAnticipo.Text = String.Format("{0:c}", 0)
            End If
        Else
            _venta.Credito.Anticipo = 0
            TBXPCEAnticipo.Text = String.Format("{0:c}", 0)
        End If
        If _venta.Detalle.Count > 0 Then
            CalculaPreciosCredito()
        End If
    End Sub

    Protected Sub DDPeriodo1_OnTextChanged(sender As Object, e As EventArgs)
        If _venta.Detalle.Count > 0 Then
            _Periodo = _listaPeriodos(DDPeriodo1.SelectedIndex)
            CalculaTodo()
            DDPeriodo2.SelectedIndex = DDPeriodo1.SelectedIndex
        End If
    End Sub

    Protected Sub DDPeriodo2_OnTextChanged(sender As Object, e As EventArgs)
        If _venta.Detalle.Count > 0 Then
            _Periodo = _listaPeriodos(DDPeriodo2.SelectedIndex)
            CalculaTodo()
            DDPeriodo1.SelectedIndex = DDPeriodo2.SelectedIndex
        End If
    End Sub

    Private Sub ObtenerCargos()
        Dim NegocioTipoCargo = New Negocio.Cargo()
        Dim EntidadTipoCargo As New Entidad.Cargo()
        EntidadTipoCargo.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoCargo.ConsultarVenta(EntidadTipoCargo)
        _venta.Cargo.Clear()
        If EntidadTipoCargo.TablaConsulta.Rows.Count > 0 Then
            Dim cargo As Entidad.VentaCargo
            For ind = 0 To EntidadTipoCargo.TablaConsulta.Rows.Count - 1
                Dim fila = EntidadTipoCargo.TablaConsulta.Rows(ind)
                cargo = New Entidad.VentaCargo()

                cargo.Id = CInt(fila("ID"))
                'cargo.Equivalencia = CStr(fila("Equivalencia"))
                cargo.Cargo = CStr(fila("Descripcion"))
                cargo.Monto = CDbl(fila("Monto"))
                cargo.TipoMonto = CInt(fila("IdTipoMonto"))
                cargo.Activo = False
                If CInt(fila("IdAutomatico")) = 1 Then
                    cargo.Activo = True
                End If
                cargo.IdTipoCargoVenta = CInt(fila("IdTipoCargo"))
                cargo.TipoCargoVenta = CStr(fila("Cargo"))
                cargo.IdTipo = CInt(fila("IdTipo"))
                cargo.Total = 0
                cargo.IdEstado = CInt(fila("IdEstado"))

                _venta.Cargo.Add(cargo)
            Next
        End If
        MostrarCargos()
        'Dim index = 0
        'For Each MiDataRow As GridViewRow In GVCargos.Rows
        '    If _listaCargos(index).IdAutomatico = 1 And _venta.IdTipoVenta = TipoVenta.Credito Then
        '        CType(MiDataRow.FindControl("CBCargos"), CheckBox).Checked = True
        '        _listaCargos(index).Checked = False
        '    Else
        '        CType(MiDataRow.FindControl("CBCargos"), CheckBox).Checked = False
        '        _listaCargos(index).Checked = True
        '    End If
        '    index += 1
        'Next
    End Sub

    Private Sub MostrarCargos()
        LBCargos.Text = _venta.Cargo.Count.ToString()
        GVCargos.DataSource = _venta.Cargo
        GVCargos.DataBind()
        'Dim index = 0
        'For Each MiDataRow As GridViewRow In GVCargos.Rows
        '    If _listaCargos(index).Checked And _venta.IdTipoVenta = TipoVenta.Credito Then
        '        CType(MiDataRow.FindControl("CBCargos"), CheckBox).Checked = True
        '    Else
        '        CType(MiDataRow.FindControl("CBCargos"), CheckBox).Checked = False
        '    End If
        '    index += 1
        'Next
    End Sub

    Protected Sub CBCargos_OnCheckedChanged(sender As Object, e As EventArgs)
        Dim CBResponsable As CheckBox = CType(sender, CheckBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(CBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        _venta.Cargo(index).Activo = CBResponsable.Checked
        If _venta.Detalle.Count > 0 Then
            CalculaTodo()
        End If
    End Sub

    Protected Sub BTNActualizaCargos_OnClick(sender As Object, e As EventArgs)
        'If _venta.Detalle.Count > 0 Then
        '    CalculaTodo()
        'End If
    End Sub

    Private Sub AvisoPendiente(sender As Object, e As EventArgs)
        _venta.IdVentaEstado = TipoVentaEstado.PENDIENTE
        FinalizarVenta()
        MVVenta.SetActiveView(ContenidoPrinicpal)
        CType(Master.FindControl("DDVCambiar"), DropDownList).Visible = True
        CType(Master.FindControl("LBVCambiar"), Label).Visible = False
    End Sub

    Private Sub Imprimir()
        Dim objFSO, objTextFile
        Dim sRead, sReadLine, sReadAll
        Const ForReading = 1
        objFSO = CreateObject("Scripting.FileSystemObject")
        objTextFile = objFSO.OpenTextFile(Server.MapPath("~") + "Imprimir\Formatos\Venta\Proceso\VentaLM.html", ForReading)
        ' Use different methods to read contents of file. ï»¿

        sReadLine = objTextFile.ReadLine
        sReadLine = sReadLine.ToString().Replace("ï»¿", "")
        sRead = objTextFile.Read(4)
        sReadAll = objTextFile.ReadAll
        objTextFile.Close()
        'Session("i") = 1

        Dim ventaNegocio As New Negocio.Venta
        Dim cadena = (sReadLine + sRead + sReadAll).ToString()
        If Not _ventaNueva Then
            For Each cargo In _venta.Cargo
                cargo.Activo = True
            Next
        End If

        ventaNegocio.ProcesarImprimir(_venta, cadena, 2)
        Session("HMTLImprimir") = cadena
        'Dim ruta = Server.MapPath("~") + "Imprimir\Imprimir.aspx"
        'Dim abrir As String = "window.open(""" + ruta + """, '_newtab');"
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), abrir, True)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "abrirImprimir();", True)
        NuevaVenta(_venta.IdTipoVenta)
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "Prueba", "abrirImprimir();", True)
        'Response.Redirect("~/Imprimir/Imprimir.aspx")
        'MVVenta.SetActiveView(ContenidoPrinicpal)
    End Sub

    Protected Sub BTNCambiarVenta_Click(sender As Object, e As EventArgs)
        Try
            If CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Contado Then
                _venta.IdTipoVenta = TipoVenta.Contado
                LimpiarCredito()
                MostrarPromociones()
                CalculaPreciosContado()
                VerVentaContado()
            ElseIf CType(Master.FindControl("DDVCambiar"), DropDownList).SelectedValue = TipoVenta.Credito Then
                _venta.IdTipoVenta = TipoVenta.Credito
                ActualizaLLenaComboxBox()
                CBPLPlazoContado.SelectedIndex = 0
                CBPLPlazoCredito.SelectedIndex = 1
                plazoCreditoManual = False
                plazoContadoManual = False
                VerVentaCredito()
                MostrarPromociones()
                CalculaPreciosCredito()
            Else
                _venta.IdTipoVenta = TipoVenta.Apartado
                ActualizaLLenaComboxBox()
                CBPLPlazoContado.SelectedIndex = 0
                CBPLPlazoCredito.SelectedIndex = 1
                plazoCreditoManual = False
                plazoContadoManual = False
                VerVentaApartado()
                CalculaPreciosApartado()
            End If
        Catch ex As Exception
            Dim mensaje = ex.Message
            Dim a = mensaje
        End Try
    End Sub

End Class