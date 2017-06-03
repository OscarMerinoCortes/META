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
    Public Event Seleccionado As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MUWucConsulta.SetActiveView(VWProductos)
        End If
        LlenarArregloProductos()
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

        EntidadConsultarProducto.Descripcion = CStr(IIf(Texto = "", "", Texto
                                                        ))
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
        MUWucConsulta.SetActiveView(VWProductos)
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

    Public Sub BusquedaProducto()
        BusquedaProductoAlt()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MUWucConsulta.SetActiveView(VWProductos)
    End Sub

    '/////////////////////////////////////////////////////////////////

    Public Sub LlenarArregloProductos()
        Dim EntidadProducto1 = New Entidad.Producto()
        Dim NegocioProducto = New Negocio.Producto()
        EntidadProducto1.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioProducto.Consultar(EntidadProducto1)
        Dim TablaProducto As New DataTable()
        TablaProducto = EntidadProducto1.TablaConsulta
        Dim total As Integer
        total = TablaProducto.Rows.Count - 1
        ReDim ArregloProductos(0 To total)
        For i = 0 To total
            ArregloProductos(i) = "'" + TablaProducto.Rows(i)(1) + " ------- " + TablaProducto.Rows(i)(2) + "'"
        Next
        StringArregloProductos = Join(ArregloProductos, ",")

    End Sub



End Class
