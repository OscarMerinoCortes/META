Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class Wuc_WebUserControl
    Inherits System.Web.UI.UserControl
    Public Shared IdProveedor As Integer
    Public ArregloProductos() As String
    Public Shared StringArregloProductos As String
    Public total As Integer
    Public Paso As Integer
    Public Event Seleccionado As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'MUWucConsulta.SetActiveView(VWProductos)
        Else
            'Paso = 5 'Despues de postback
            'Session("Paso") = Paso
        End If
        'If Paso = 1 Then
        LlenarArregloProductos()
        'End If
        'If Paso = -1 Then 'cuando llega al evento
        '    AddHandler Seleccionado, New EventHandler(AddressOf AgregarProductos)
        'End If
    End Sub

    '//////////Espacio para implementacion del WUC por Productos//////////
    Public Sub RegresarFoco()
        TBBNombreProducto.Value = ""
        TBBNombreProducto.Focus()
    End Sub

    Public Sub BusquedaProductoAlt()
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()

        Dim Indice As Integer
        Dim Texto As String
        Try

            Dim Limitador = "-------"
            Indice = TBBNombreProducto.Value.IndexOf(Limitador) + 8
            Texto = TBBNombreProducto.Value.Substring(Indice)
        Catch
            Indice = 0
            Texto = TBBNombreProducto.Value
        End Try

        EntidadConsultarProducto.Descripcion = CStr(IIf(Texto = "", "", Texto))
        EntidadConsultarProducto.IdProducto = IdProveedor
        EntidadConsultarProducto.IdTipo = 2
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.Ninguno
        NegocioConsultarProducto.Consultar(EntidadConsultarProducto)
        Dim productosSeleccionados = Session("WucProductoSeleccionados")
        Dim productos = Session("WucProductoSeleccion")
        Try
            If productosSeleccionados = Nothing Then
                productosSeleccionados = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
        End Try

        Try
            If productos = Nothing Then
                productos = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
            productos.Clear()
        End Try

        Dim fila As Entidad.WucProductoSeleccion
        For Each row In EntidadConsultarProducto.TablaConsulta.Rows
            fila = New Entidad.WucProductoSeleccion
            fila.IdProductoCorto = CStr(row("ID Corto"))
            fila.IdProducto = CInt(row("ID"))
            fila.Producto = CStr(row("Descripcion"))
            fila.Cantidad = 1
            fila.Precio = 0
            productos.Add(fila)
            Exit For
        Next

        Session("WucProductoSeleccionados") = productos
        Session("WucProductoSeleccion") = productos

    End Sub

    Public Sub Nuevo()
        'TBIdProducto.Text = ""
        'TBIdProductoCorto.Text = ""
        'TBDescripcion.Text = ""
        BusquedaProductoAlt()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        'MUWucConsulta.SetActiveView(VWProductos)
    End Sub

    Public Sub LimpiarConsulta()
        Try
            Dim productos = CType(Session("WucProductoSeleccion"), ObservableCollection(Of Entidad.WucProductoSeleccion))
            productos.Clear()
            Session("WucProductoSeleccion") = New ObservableCollection(Of Entidad.WucProductoSeleccion)()
            Dim productosSeleccionados = CType(Session("WucProductoSeleccionados"), ObservableCollection(Of Entidad.WucProductoSeleccion))
            productosSeleccionados.Clear()
            Session("WucProductoSeleccionados") = New ObservableCollection(Of Entidad.WucProductoSeleccion)()
            TBBNombreProducto.Value = ""
        Catch ex As Exception
        End Try
    End Sub

    Public Function ObtenerProductos() As ObservableCollection(Of Entidad.WucProductoSeleccion)
        Dim productosSeleccionados = Session("WucProductoSeleccionados")
        Try
            If productosSeleccionados = Nothing Then
                productosSeleccionados = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
        End Try
        Return CType(productosSeleccionados, ObservableCollection(Of Entidad.WucProductoSeleccion))
    End Function
    Public Sub ObtenerProducto(ByRef IdProducto As Integer)
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()

        Dim Indice As Integer
        Dim Texto As String
        Try
            Dim Limitador = "-------"
            Indice = TBBNombreProducto.Value.IndexOf(Limitador) + 8
            Texto = TBBNombreProducto.Value.Substring(Indice)
        Catch
            Indice = 0
            Texto = TBBNombreProducto.Value
        End Try
        EntidadConsultarProducto.Descripcion = CStr(IIf(Texto = "", "", Texto))
        EntidadConsultarProducto.IdProducto = IdProveedor
        EntidadConsultarProducto.IdTipo = 2
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.Ninguno
        NegocioConsultarProducto.Consultar(EntidadConsultarProducto)
        Dim productosSeleccionados = Session("WucProductoSeleccionados")
        Dim productos = Session("WucProductoSeleccion")
        Try
            If productosSeleccionados = Nothing Then
                productosSeleccionados = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
        End Try
        Try
            If productos = Nothing Then
                productos = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
            productos.Clear()
        End Try

        Dim fila As Entidad.WucProductoSeleccion
        For Each row In EntidadConsultarProducto.TablaConsulta.Rows
            fila = New Entidad.WucProductoSeleccion
            fila.IdProductoCorto = CStr(row("ID Corto"))
            fila.IdProducto = CInt(row("ID"))
            fila.Producto = CStr(row("Descripcion"))
            fila.Cantidad = 1
            fila.Precio = 0
            productos.Add(fila)
            IdProducto = fila.IdProducto
            Exit For
        Next

        Session("WucProductoSeleccionados") = productos
        Session("WucProductoSeleccion") = productos

    End Sub
    Public Sub BusquedaProducto()
        BusquedaProductoAlt()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        'MUWucConsulta.SetActiveView(VWProductos)
    End Sub

    '/////////////////////////////////////////////////////////////////

    Public Sub LlenarArregloProductos()
        Dim EntidadProducto1 = New Entidad.Producto()
        EntidadProducto1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MMunozConnectionString").ToString())


        sqlcom1 = New SqlCommand("ERP_ConProDet", sqlcon1)
        sqldat1 = New SqlDataAdapter(sqlcom1)
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqldat1.Fill(EntidadProducto1.TablaConsulta)

        Dim total As Integer

        total = EntidadProducto1.TablaConsulta.Rows.Count - 1
        ReDim ArregloProductos(0 To total)
        For i = 0 To total
            ArregloProductos(i) = "'" + EntidadProducto1.TablaConsulta.Rows(i)(1) + " ------- " + EntidadProducto1.TablaConsulta.Rows(i)(2) + "'"
        Next

        StringArregloProductos = Join(ArregloProductos, ",")

    End Sub
    Protected Sub Nada()
        Paso = 9 'Numero Identificador del Evento
        Session("Paso") = Paso
    End Sub
    Public Sub Estadistica()
        'If Paso = 5 Then
        'Paso = -1
        BusquedaProductoAlt()
        AgregarProductos()
        'RaiseEvent Seleccionado(New Object, New EventArgs)
        'LimpiarConsulta()
        'MUWucConsulta.SetActiveView(VWProductos)
        ' End If
    End Sub
    Protected Sub AgregarProductos()
        Dim TablaCompra As New DataTable
        Dim VistaCompra As New DataView

        Dim TablaVenta As New DataTable
        Dim VistaVenta As New DataView

        Dim TablaSucursal As New DataTable
        Dim VistaSucursal As New DataView

        Dim TablaProveedores As New DataTable
        Dim VistaProveedores As New DataView
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = ObtenerProductos()
        For Each producto In productosSeleccionados
            If productosSeleccionados.Count > 0 Then
                'Compras
                Dim EntidadCompra = New Entidad.Compra
                Dim NegocioCompra = New Negocio.Compra
                EntidadCompra.IdProductoCorto = producto.IdProductoCorto
                EntidadCompra.FechaInicio = CDate(Now.AddYears(-3))
                EntidadCompra.FechaFin = CDate(Now.AddYears(1))
                NegocioCompra.WucEstadistica(EntidadCompra)
                TablaCompra = EntidadCompra.TablaConsulta
                'Ventas
                Dim EntidadVenta = New Entidad.Producto
                Dim NegocioVenta = New Negocio.Producto
                EntidadVenta.IdProductoCorto = producto.IdProductoCorto
                EntidadVenta.FechaInicio = CDate(Now.AddYears(-3))
                EntidadVenta.FechaFin = CDate(Now.AddYears(1))
                NegocioVenta.WucEstadisticaVenta(EntidadVenta)
                TablaVenta = EntidadVenta.TablaConsulta
                'Existencia
                Dim NegocioReporteExistencia As New Negocio.ReporteExistenciaAlmacen()
                Dim EntidadReporteExistencia As New Entidad.ReporteExistenciaAlmacen()
                EntidadReporteExistencia.IdProductoCorto = producto.IdProductoCorto
                EntidadReporteExistencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                NegocioReporteExistencia.ExistenciaSucursal(EntidadReporteExistencia)
                TablaSucursal = EntidadReporteExistencia.TablaConsulta
                'Proveedores
                Dim EntidadProveedor = New Entidad.Proveedor
                Dim NegocioProveedor = New Negocio.Proveedor
                EntidadProveedor.IdProductoCorto = producto.IdProductoCorto
                NegocioProveedor.WucEstadisticaProveedor(EntidadProveedor)
                TablaProveedores = EntidadProveedor.TablaConsulta
            End If
            VistaCompra = TablaCompra.DefaultView
            Session("TablaCompra") = TablaCompra
            Session("VistaCompra") = VistaCompra

            VistaVenta = TablaVenta.DefaultView
            Session("TablaVenta") = TablaVenta
            Session("VistaVenta") = VistaVenta

            VistaSucursal = TablaSucursal.DefaultView
            Session("TablaSucursal") = TablaSucursal
            Session("VistaSucursal") = VistaSucursal

            VistaProveedores = TablaProveedores.DefaultView
            Session("TablaProveedores") = TablaProveedores
            Session("VistaProveedores") = VistaProveedores
            'wucEstadistica1.ImprimirTablas()
        Next
    End Sub
End Class
