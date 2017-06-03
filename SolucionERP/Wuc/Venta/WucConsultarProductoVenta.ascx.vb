Imports System.Data
Imports Operacion.Configuracion.Constante

' ReSharper disable once CheckNamespace
Partial Class WucConsultarProductoVenta
    Inherits UserControl
    Private TablaConsultarProducto As New DataTable()
    Public Event Seleccionado As EventHandler
    Public Event Cancelado As EventHandler
    Public Shared Property IdProductoCorto As String
    Public Shared Property BusquedaSucursal As Boolean
    Public Shared Property IdAlmacen As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub
    Public Sub Buscar(texto As String, almacen As Integer)
        TBXCodigo.Text = texto
        IdAlmacen = almacen
        BuscarProducto()
    End Sub

    Public Sub LimpiarConsulta()
        Try
            IdProductoCorto = ""
            ' IdAlmacen = 0
            TBXCodigo.Text = ""
            Dim TablaConsulta As DataTable = CType(ViewState("TablaBuscarProducto"), DataTable)
            TablaConsulta.Rows.Clear()
            GVBusquedaProducto.DataSource = TablaConsulta
            GVBusquedaProducto.DataBind()
            ViewState("TablaBuscarProducto") = TablaConsulta
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BTNBuscar_Click(sender As Object, e As EventArgs)
        BusquedaSucursal = False
        BuscarProducto()
    End Sub

    Protected Sub BTNVCancelar_Click(sender As Object, e As EventArgs)
        LimpiarConsulta()
        RaiseEvent Cancelado(New Object, New EventArgs)
    End Sub
    Protected Sub GVBusquedaProducto_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    Protected Sub BTNSeleccionar_Click1(sender As Object, e As EventArgs)
        Dim Tabla As New DataTable
        Tabla = CType(ViewState("TablaBuscarProducto"), DataTable)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVBusquedaProducto.SelectedIndex = gvrFilaActual.RowIndex
        IdProductoCorto = CStr(Tabla.Rows(GVBusquedaProducto.SelectedIndex).Item("Codigo"))
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub
    Protected Sub BTNSeleccionar2_Click1(sender As Object, e As EventArgs)
        Dim Tabla = CType(ViewState("TablaBuscarProducto"), DataTable)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVBusquedaProductoSucursal.SelectedIndex = gvrFilaActual.RowIndex
        IdProductoCorto = CStr(Tabla.Rows(GVBusquedaProductoSucursal.SelectedIndex).Item("Id Corto"))
        IdAlmacen = CInt(Tabla.Rows(GVBusquedaProductoSucursal.SelectedIndex).Item("IdAlmacen"))
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub


    Private Sub BuscarProducto()
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()
        EntidadConsultarProducto.Descripcion = TBXCodigo.Text
        EntidadConsultarProducto.IdAlmacen = IdAlmacen
        If BusquedaSucursal Then
            EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorFiltro
            NegocioConsultarProducto.VentaObtener(EntidadConsultarProducto)
            If EntidadConsultarProducto.TablaConsulta.Rows.Count = 0 Then
                EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorDescripcion
                NegocioConsultarProducto.VentaObtener(EntidadConsultarProducto)
                TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
                GVBusquedaProducto.DataSource = TablaConsultarProducto
                GVBusquedaProducto.DataBind()
                GVBusquedaProductoSucursal.Visible = False
                GVBusquedaProducto.Visible = True
                'LBMensaje.Text = "Sin existencias en ninguna sucursal"
            Else
                TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
                GVBusquedaProductoSucursal.DataSource = TablaConsultarProducto
                GVBusquedaProductoSucursal.DataBind()
                GVBusquedaProductoSucursal.Visible = True
                GVBusquedaProducto.Visible = False
            End If
        Else
            EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorDescripcion
            NegocioConsultarProducto.VentaObtener(EntidadConsultarProducto)
            TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
            GVBusquedaProducto.DataSource = TablaConsultarProducto
            GVBusquedaProducto.DataBind()
            GVBusquedaProductoSucursal.Visible = False
            GVBusquedaProducto.Visible = True
            'LBMensaje.Text = "Sin coincidencia de productos"
        End If
        LBCantidadBusqueda.Text = "   Productos: " + TablaConsultarProducto.Rows.Count.ToString()
        ViewState("TablaBuscarProducto") = EntidadConsultarProducto.TablaConsulta
    End Sub

    Protected Sub BTNVerExistencia_OnClick(sender As Object, e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVBusquedaProducto.SelectedIndex = gvrFilaActual.RowIndex
        Dim Tabla = CType(ViewState("TablaBuscarProducto"), DataTable)
        IdProductoCorto = CStr(Tabla.Rows(GVBusquedaProducto.SelectedIndex).Item("Codigo"))
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()
        EntidadConsultarProducto.Descripcion = IdProductoCorto
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorFiltro
        NegocioConsultarProducto.VentaObtener(EntidadConsultarProducto)
        TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
        GVBusquedaProductoSucursal.DataSource = TablaConsultarProducto
        GVBusquedaProductoSucursal.DataBind()
        GVBusquedaProductoSucursal.Visible = True
        GVBusquedaProducto.Visible = False
        ViewState("TablaBuscarProducto") = EntidadConsultarProducto.TablaConsulta
    End Sub
End Class
