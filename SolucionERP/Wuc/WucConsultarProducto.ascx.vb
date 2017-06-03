Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Data
Imports Operacion.Configuracion.Constante
Imports Datos
Imports Entidad

Partial Class WucConsultarProducto
    Inherits System.Web.UI.UserControl


    Public Event Seleccionado As EventHandler
    Public Shared IdProveedor As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MUWucConsultaProducto.SetActiveView(VWPrincipal)
        End If
        Test()
    End Sub
    Private Sub Buscar()
        LimpiarConsulta()
        'MUWucConsultaProducto.SetActiveView(VWMultiple)
    End Sub
    Public Sub MostrarColumnaPrecio()
        GVConsultarProducto.Columns(4).Visible = True
    End Sub
    Public Sub MostrarColumnaCantidad()
        GVConsultarProducto.Columns(3).Visible = True
    End Sub
    Public Sub MostrarColumnaSeleccionar()
        GVConsultarProducto.Columns(0).Visible = True
        GVConsultarProducto.Columns(5).Visible = False
        'BTNAceptarBusqueda.Visible = False
    End Sub
    Public Function ObtenerProductos() As ObservableCollection(Of Entidad.WucProductoSeleccion)
        ' AgregarProducto()
        Dim productosSeleccionados = Session("WucProductoSeleccionados")
        Try
            If productosSeleccionados = Nothing Then
                productosSeleccionados = New ObservableCollection(Of Entidad.WucProductoSeleccion)
            End If
        Catch ex As Exception
        End Try
        Return CType(productosSeleccionados, ObservableCollection(Of Entidad.WucProductoSeleccion))
    End Function
    Public Sub Nuevo()
        'TBIdProducto.Text = ""
        'TBIdProductoCorto.Text = ""
        'TBDescripcion.Text = ""
        BTBuscarProducto_Click()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)
    End Sub
    Public Sub ObtenerProducto(ByRef IdProducto As Integer, ByRef IdProductoCorto As String, ByRef Producto As String)
        'IdProducto = CInt(IIf(TBIdProducto.Text Is String.Empty, 0, TBIdProducto.Text))
        'IdProductoCorto = IIf(TBIdProductoCorto.Text Is String.Empty, 0, TBIdProductoCorto.Text)
        'Producto = IIf(TBDescripcion.Text Is String.Empty, "0", TBDescripcion.Text)
    End Sub
    Public Sub AsignarProducto(IdProducto As Integer, IdProductoCorto As String, Producto As String)
        'TBIdProducto.Text = CStr(IdProducto)
        'TBIdProductoCorto.Text = IdProductoCorto
        'TBDescripcion.Text = Producto
    End Sub
    'might as well be here
    Protected Sub BTBuscarProducto_Click()
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()

        Dim Indice As Integer
        Dim Texto As String
        Try

            Dim Limitador = "-------"
            Indice = TBBNombreProducto.value.IndexOf(Limitador) + 8
            Texto = TBBNombreProducto.value.Substring(Indice)
        Catch
            Indice = 0
            Texto = TBBNombreProducto.value
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

    Protected Sub GVBusquedaProducto_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub LimpiarConsulta()
        Try
            Dim productos = CType(Session("WucProductoSeleccion"), ObservableCollection(Of Entidad.WucProductoSeleccion))
            productos.Clear()
            Session("WucProductoSeleccion") = New ObservableCollection(Of Entidad.WucProductoSeleccion)()
            Dim productosSeleccionados = CType(Session("WucProductoSeleccionados"), ObservableCollection(Of Entidad.WucProductoSeleccion))
            productosSeleccionados.Clear()
            Session("WucProductoSeleccionados") = New ObservableCollection(Of Entidad.WucProductoSeleccion)()
            TBBNombreProducto.value = ""
            GVConsultarProducto.DataSource = productos
            GVConsultarProducto.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub TBIdProductoCorto_TextChanged(sender As Object, e As EventArgs) 'Handles TBIdProductoCorto.TextChanged
        'TBIdProducto.Text = "0"
        ObtenerProducto()
    End Sub

    Private Sub ObtenerProducto()
        'If IsNumeric(TBIdProducto.Text) Or TBIdProductoCorto.Text.Length > 1 Then
        Dim NegocioProducto = New Negocio.Producto()
            Dim EntidadProducto As New Entidad.Producto()
            EntidadProducto.Tarjeta.Consulta = Consulta.Ninguno
            'EntidadProducto.IdProducto = TBIdProducto.Text
            'EntidadProducto.IdProductoCorto = TBIdProductoCorto.Text
            EntidadProducto.Descripcion = ""
            NegocioProducto.Consultar(EntidadProducto)
            Dim TablaProducto As New DataTable()
            TablaProducto = EntidadProducto.TablaConsulta
            If EntidadProducto.TablaConsulta.Rows.Count > 0 Then
                Try
                    TablaProducto.Select()
                    Dim _listaProducto As List(Of DataRow) = TablaProducto.AsEnumerable().ToList()
                    For Each rw As DataRow In _listaProducto
                        'TBIdProducto.Text = rw.ItemArray(0)
                        'TBIdProductoCorto.Text = rw.ItemArray(1)
                        'TBDescripcion.Text = rw.ItemArray(2)
                    Next
                Catch ex As Exception
                    Dim a = ex.Message
                End Try
            Else
                'TBIdProducto.Text = "0"
                'TBIdProductoCorto.Text = ""
                'TBDescripcion.Text = ""
            End If
        'End If
    End Sub
    Protected Sub IBTNBuscarProducto_OnClick(sender As Object, e As ImageClickEventArgs) 'Handles ImageButton1.Click
        Buscar()
    End Sub

    Protected Sub TBIdProducto_TextChanged(sender As Object, e As EventArgs)
        'TBIdProductoCorto.Text = ""
        ObtenerProducto()
    End Sub
    Protected Sub BTNCancelarBusqueda_Click(sender As Object, e As EventArgs) Handles BTNCancelarBusqueda.Click
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)
    End Sub

    Protected Sub BTNAceptarBusqueda_Click(sender As Object, e As EventArgs) Handles BTNAceptarBusqueda.Click
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)
    End Sub
    Protected Sub Agregar_Click(sender As Object, e As EventArgs)
        'Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        'Dim index As Integer = gvrFilaActual.RowIndex
        'Dim productos = Session("WucProductoSeleccion")
        'Dim productosSeleccionados = Session("WucProductoSeleccionados")

        'Dim ind = 0
        'For Each MiDataRow As GridViewRow In GVConsultarProducto.Rows
        '    If ind = index Then
        '        Dim agregado = True
        '        Dim pos = 0
        '        For i = 0 To productosSeleccionados.Count - 1
        '            If productosSeleccionados(i).IdProducto = productos(index).IdProducto Then
        '                CType(MiDataRow.FindControl("IMAccion"), Image).ImageUrl = "~/Imagenes/IMPlus.png"
        '                pos = i
        '                agregado = False
        '            End If
        '        Next
        '        If agregado Then
        '            productosSeleccionados.Add(productos(index))
        '            CType(MiDataRow.FindControl("IMAccion"), Image).ImageUrl = "~/Imagenes/IMCross.png"
        '        Else
        '            productosSeleccionados.RemoveAt(pos)
        '        End If
        '    End If
        '    ind += 1
        'Next

        'Session("WucProductoSeleccionados") = productosSeleccionados
        BTBuscarProducto_Click()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)

    End Sub

    Protected Sub TXPrecio_TextChanged(sender As Object, e As EventArgs)
        Dim TBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim productos = Session("WucProductoSeleccion")
        Dim productosSeleccionados = Session("WucProductoSeleccionados")

        Dim Cantidad As TextBox = CType(sender, TextBox)

        If IsNumeric(Cantidad.Text) Then
            productos(index).Precio = CInt(Cantidad.Text)
            Dim ind = 0
            For Each MiDataRow As GridViewRow In GVConsultarProducto.Rows
                If ind = index Then
                    Dim agregado = True
                    Dim pos = 0
                    For i = 0 To productosSeleccionados.Count - 1
                        If productosSeleccionados(i).IdProducto = productos(index).IdProducto Then
                            agregado = False
                            pos = i
                        End If
                    Next
                    If agregado Then
                        productosSeleccionados.Add(productos(index))
                        CType(MiDataRow.FindControl("IMAccion"), Image).ImageUrl = "~/Imagenes/IMCross.png"
                    Else
                        productosSeleccionados(pos).Precio = CInt(Cantidad.Text)
                    End If
                End If
                ind += 1
            Next
        End If

        Session("WucProductoSeleccion") = productos
        Session("WucProductoSeleccionados") = productosSeleccionados
    End Sub

    Protected Sub TXCantidad_TextChanged(sender As Object, e As EventArgs)
        Dim TBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim productos = Session("WucProductoSeleccion")
        Dim productosSeleccionados = Session("WucProductoSeleccionados")

        Dim Cantidad As TextBox = CType(sender, TextBox)

        If IsNumeric(Cantidad.Text) Then
            productos(index).Cantidad = CInt(Cantidad.Text)
            Dim ind = 0
            For Each MiDataRow As GridViewRow In GVConsultarProducto.Rows
                If ind = index Then
                    Dim agregado = True
                    Dim pos = 0
                    For i = 0 To productosSeleccionados.Count - 1
                        If productosSeleccionados(i).IdProducto = productos(index).IdProducto Then
                            agregado = False
                            pos = i
                        End If
                    Next
                    If agregado Then
                        productosSeleccionados.Add(productos(index))
                        CType(MiDataRow.FindControl("IMAccion"), Image).ImageUrl = "~/Imagenes/IMCross.png"
                    Else
                        productosSeleccionados(pos).Cantidad = CInt(Cantidad.Text)
                    End If
                End If
                ind += 1
            Next
        End If

        Session("WucProductoSeleccion") = productos
        Session("WucProductoSeleccionados") = productosSeleccionados
    End Sub

    Protected Sub BTNSeleccionar_Click1(sender As Object, e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim productos As ObservableCollection(Of Entidad.WucProductoSeleccion) = CType(Session("WucProductoSeleccion"), ObservableCollection(Of Entidad.WucProductoSeleccion))
        'TBIdProducto.Text = productos(index).IdProducto.ToString()
        'TBIdProductoCorto.Text = productos(index).IdProductoCorto
        'TBDescripcion.Text = productos(index).Producto
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)
    End Sub

    Public Shared a() As String
    Public Shared b As String

    Public Function Test() As Array
        Dim EntidadProducto1 = New Entidad.Producto()
        EntidadProducto1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MMunozConnectionString").ToString())


        sqlcom1 = New SqlCommand("ERP_ConProDet", sqlcon1)
        sqldat1 = New SqlDataAdapter(sqlcom1)
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
        sqldat1.Fill(EntidadProducto1.TablaConsulta)

        Dim total As Integer

        total = EntidadProducto1.TablaConsulta.Rows.Count - 1
        ReDim a(0 To total)
        For i = 0 To total
            a(i) = "'" + EntidadProducto1.TablaConsulta.Rows(i)(1) + " ------- " + EntidadProducto1.TablaConsulta.Rows(i)(2) + "'"
        Next

        b = Join(a, ",")

        Return a

    End Function

    Public Sub AgregarProducto()
        BTBuscarProducto_Click()
        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MUWucConsultaProducto.SetActiveView(VWPrincipal)
    End Sub

    Public Sub RegresarFoco()
        TBBNombreProducto.Focus()
    End Sub

End Class


