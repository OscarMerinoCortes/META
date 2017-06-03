Namespace Configuracion

    Namespace Constante
        'para uso en VENTA ==============================================================
        Public Enum TipoVenta
            Credito = 1
            Contado = 2
            Apartado = 3
            Ninguno = 4
        End Enum
        Public Enum DasboardOpcion
            Grafica1 = 1
            Grafica2 = 2
            Grafica3 = 3
            Grafica4 = 4
            Grafica5 = 5
            Grafica6 = 6
        End Enum
        Public Enum TipoEntrega
            DelCliente = 1
            EnMano = 2
            ClientePasa = 3
        End Enum
        Public Enum TipoVentaEstado
            AUTORIZADO = 1
            CANCELADO = 2
            RECHAZADO = 3
            ACTIVO = 4
            LIQUIDADO = 5
            PENDIENTE = 6
        End Enum
        Public Enum Cantidad
            Ninguno = 1
            Agregar = 2
            Quitar = 3
            Descuento = 4
            Cantidad = 5
        End Enum
        Public Enum TipoBusqueda
            Cliente = 1
            Producto = 2
            Apartado = 3
            AgregaDescuento = 4
            AgregaCantidad = 5
            Venta = 5
        End Enum
        Public Enum Ventana
            VentanaInicio = 1
            VentanaBusquedaProducto = 2
            VentanaBusquedaCliente = 3
            VentanaBusquedaVenta = 4
            VentanaCredito = 5
            VentanaContado = 6
            VentanaAviso = 7
        End Enum
        '==============================================================================
        Public Class Formato
            Public Shared Miles As String = "#,###,##0.00"
            Public Shared Porcentaje As String = "##0.##%"
            Public Shared FechaCorta As String = "{0:d}"
            Public Shared Moneda As String = "$#,###,##0.00"
        End Class
        Public Enum Consulta
            Ninguno = 0
            ConsultaPorId = 1
            ConsultaBasica = 2
            ConsultaPorFecha = 3
            ConsultaPorIdPadre = 4
            InstrumentoDeCredito = 5
            ConsultaPorDescripcion = 6
            ConsultarPorIdPersona = 7
            ConsultarPorIdPersonas = 8
            ConsultaDetallada = 9
            ConsultaPorIdProducto = 10
            ConsultaDetalladaPorId = 11 'solo se usa en subclasificacion de RegistroProducto
            ConsultaPorFiltro = 12
            ConsultaProveedor = 13
            ConsultaProveedorIdPro = 14
            ConsultaProveedorIdPer = 15
            ConsultaBusqueda = 16
            ConsultaCXP = 17
            ConsultaPorNombreCompleto = 18
            ConsultaPorCantidad = 19
            ConsultaPorMonto = 20
            ConsultaPorAlmacen = 21
            ConsultaExcedentes = 22
            ConsultaFaltantes = 23
            ConsultaCompra = 24
            ConsultaVenta = 25
        End Enum

        Public Enum Estado
            Activo = 1
            Inactivo = 2
        End Enum
        Public Enum Modulo
            Cliente = 1
            Productos = 2
            Inventarios = 3
            Sucursales = 4
            Compras = 5
            Ventas = 6
            Caja = 7
            Seguridad = 8
            Configuracion = 9
        End Enum
        'seguridad======================================================
        Public Enum Opcion
            RegistroCliente = 5
            PerfilCliente = 6
            Registro = 7
            Autorizar = 8
            TipoDomicilio = 9
            TipoEmpleo = 10
            TipoEstadoCivil = 11
            TipoIdentificacion = 12
            TipoIdentificador = 13
            TipoMedio = 14
            TipoReferencia = 15
            ReferenciaComercial = 16
            ReporteClientes = 17
            FormaPago = 22
            Periodo = 23
            PlazoVencimiento = 24
            TipoVenta = 25
            ReporteVenta = 26
            Clasificacion = 31
            Subclasificacion = 32
            TipoPlazo = 33
            TipoProducto = 34
            RegistroProducto = 35
            TipoCaja = 40
            TipoLiquidacion = 41
            Caja = 42
            Almacen = 47
            Sucursal = 48
            Compra = 53
            OrdenCompra = 54
            SegimientoSolicitudCompra = 55
            SolicitudCompra = 56
            ReporteCompra = 57
            ReporteOrdenCompra = 58
            ReporteSolicitudCompra = 59
            SubtipoMovimientoInventario = 64
            MovimientoInventario = 65
            RegistroInventario = 66
            ReporteMovimientoInventario = 67
            Cargo = 72
            TipoUsuario = 73
            Usuario = 74
            Impuesto = 79
            Rutas = 80
            TipoCalendario = 81
            Unidades = 82
            Colonia = 83
            Ciudad = 84
            Municipio = 85
            EntidadFederativa = 86
            Pais = 87
            ReporteExistenciaAlmacen = 88
            ReporteExistenciaSucursal = 89
            Promocion = 90
            ArqueoCaja = 91
            ListaProducto = 92
            Descuento = 93
            Obsequio = 94
            Cliente = 95
            Proveedor = 96
            TipoDocumento = 97
            CalculoPlazo = 98
            SegimientoTraspaspEnvio = 99
            CuentasPorPagar = 100
            CuentasPorCobrar = 101
            Venta = 102
            ReporteCuentaPorCobrar = 103
            ReporteCuentaPorPagar = 104
            TipoCargoVenta = 105
            ReporteMovimientoCaja = 106
            SeguridadOpcion = 107
            SeguridadTransaccion = 108
            ReporteExistenciaPorProducto = 109
        End Enum
        Public Enum Transaccion
            Guardar = 1
            Actualizar = 2
            Consultar = 3
            Imprimir = 4
            Exportar = 5
            Importar = 6
            Cancelar = 7
            Aplicar = 8
        End Enum
        'seguridad======================================================
        Public Enum ProcesoFiltro
            Caja = 1
            Autorizar = 2
            PerfilCliente = 3
            Registro = 4
            RegistroPersona = 5
            SubtipoMovimientoInventario = 6
            MovimientoInventario = 7
            RegistroInventario = 8
            RegistroProducto = 9
            Usuario = 10
        End Enum

        Public Enum Capa
            Presentacion = 1
            Negocios = 2
            Datos = 3
            Seguridad = 4
        End Enum

        Public Enum Acceso
            Habilitado = 1
            Deshabilitado = 2
        End Enum
        Public Enum Estancia
            PorHabilitar = 3
            PorDeshabilitar = 4
        End Enum
        Public Enum Accion
            Guardar = 1
            Actualizar = 2
            Borrar = 3
            Consultar = 4
            Insertar = 5
            Importar = 6
            Generar = 7
            Ejecutar = 8
            Justificar = 9
            Abrir = 10
        End Enum
        Public Enum Divisa
            Peso = 1
            Dolares = 2
        End Enum
        Public Enum Resultado
            Correcto = 1
            Incorrecto = 2
            Advertencia = 3
        End Enum
        Public Enum TipoAbono
            Normal = 1
            Extraordinario = 2
            Adelantado = 3
        End Enum
    End Namespace
    Public Enum TipoPersona
        Fisica = 1
        Moral = 2
    End Enum
    Public Enum TipoUsuario
        Administrador = 1
        Cajera = 2
    End Enum

End Namespace
