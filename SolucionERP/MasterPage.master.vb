Imports System.Data
Imports System.Web.Services.Description

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private DsOpciones As New DataSet()
    Private DtOpciones, TablaMenuModulos, DtOpcionesFrecuentes, DtUrl As New DataTable()

    'Public Menus As New Menu()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Tarjeta As New Entidad.Tarjeta()
        If Session("Tarjeta") Is Nothing Then
            Response.Redirect("/Account/Login.aspx")
        End If

        If Not Page.IsPostBack Then
            'seguridad
            'Tarjeta = Session("Tarjeta")
            'seguridad


            form1.Attributes.Add("autocomplete", "off") 'para desactivar el autocompletado
            LlenarMenuModulos()
            ' Session("IdModulo") = Operacion.Configuracion.Constante.Modulo.Cliente 'Cambiar esta linea de codigo en un default.MasterPage como en quanto
        End If
        LlenarOpciones(Session("IdModulo"))
    End Sub

    Public Sub LlenarMenuModulos()
        Dim EntidadMenuModulo As New Entidad.MenuModulo()
        Dim NegocioMenuModulo As New Negocio.MenuModulo()
        Dim Tarjeta As New Entidad.Tarjeta()
        Tarjeta = Session("Tarjeta")
        EntidadMenuModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        EntidadMenuModulo.IdTipoUsuario = Tarjeta.IdTipoUsuario
        NegocioMenuModulo.Consultar(EntidadMenuModulo)
        TablaMenuModulos = EntidadMenuModulo.TablaConsulta

        'NegocioMenuModulo.Obtener(EntidadMenuModulo)
        'TablaMenuModulos = EntidadMenuModulo.TablaConsulta
        For Each MenuModuloDataRow As DataRow In TablaMenuModulos.Rows
            Dim MenuModuloItem As New MenuItem()
            MenuModuloItem.Text = TipoTitulo(MenuModuloDataRow("DescripcionModulo").ToString())
            MenuModuloItem.Value = MenuModuloDataRow("IdModulo").ToString()
            MenuModuloItem.ImageUrl = MenuModuloDataRow("ModuloImagen").ToString()
            If MenuModuloDataRow("IdModulo").ToString() = Session("Idmodulo") Then
                LBModulo.Text = MenuModuloDataRow("DescripcionModulo").ToString()
            End If
            'MenuModuloItem.ImageUrl = MenuModuloDataRow("modulo_imagen").ToString()
            MNModulo.Items().Add(MenuModuloItem)
        Next

    End Sub
    'ESTA FUNCION SIRVE PARA CAMBIAR LA DESCRIPCION DE UN TEXTO A MINUSCULAS DESPUES DE LA PRIMERA LETRA
    Public Shared Function TipoTitulo(ByVal DSTexto As String) As String
        DSTexto = StrConv(DSTexto, VbStrConv.ProperCase)
        If DSTexto.ToUpper = "IVA" Then DSTexto = "IVA"
        DSTexto = DSTexto.Replace("Cuentas Por", "C. por")
        'If DSTexto.ToUpper = "CRM" Then DSTexto = "CRM"
        'DSTexto.Replace(" De ", " de ")
        Return DSTexto
    End Function

    Protected Sub MNModulo_MenuItemClick(sender As Object, e As MenuEventArgs) Handles MNModulo.MenuItemClick
        Dim IdModulo = e.Item.Value
        'Cambiar a futuro con modalidad dinamica para cargar desde la base de datos----10-10-2016 para evitar el case
        Select Case IdModulo
            Case 3 'Inventario
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Privada/Inventario/GraficasInventario.aspx")
            Case 5 'Compras
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Privada/Compra/InicioCompra.aspx")
            Case 6 'Ventas
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Privada/Venta/InicioVenta.aspx")
            Case 10 'Cuentas Por Cobrar
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Privada/CuentaPorCobrar/InicioCXC.aspx")
            Case 11 'Cuentas Por Pagar
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Privada/CuentaPorPagar/InicioCXP.aspx")

            Case 10001
            Case Else
                LlenarOpciones(IdModulo)
                Session("IdModulo") = IdModulo
                LBModulo.Text = e.Item.Text & " "
                Response.Redirect("~/Inicio.aspx")
        End Select
    End Sub

    Public Shared Sub CargarArbol(ByVal DsOpciones As DataSet, ByRef oMenu As Menu)
        oMenu.Items.Clear()
        For Each oDataRow As DataRow In DsOpciones.Tables(0).Rows
            If oDataRow("DescripcionMenu") = "NINGUNO" Then
                Dim OMenuItem As New MenuItem()
                OMenuItem.Text = oDataRow("DescripcionMenu").ToString()
                OMenuItem.ImageUrl = oDataRow("Imagen").ToString()
                'oMenu.Items.Add(OMenuItem)
                CargaRecursiva(oDataRow, oMenu, OMenuItem)
            End If
        Next
    End Sub

    Public Shared Sub CargaRecursiva(ByVal oDataRow As DataRow, ByRef oMenu As Menu, ByRef OMenuItem As MenuItem)
        For Each oDataRow In oDataRow.GetChildRows("Relacion")
            Dim oChildItem As New MenuItem()
            oDataRow("DescripcionMenu") = TipoTitulo(oDataRow("DescripcionMenu"))
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" Iva", "  IVA")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" Ib", "  IB")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" Ii", "  II")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" Fira", "  FIRA")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" Cnbv", "  CNBV")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace(" De ", "  de ")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace("Fira", "FIRA")
            oDataRow("DescripcionMenu") = oDataRow("DescripcionMenu").Replace("Cnbv", "CNBV")
            oChildItem.Text = oDataRow("DescripcionMenu").ToString
            If oDataRow("Url").ToString() = "" Then
                OMenuItem.NavigateUrl = "~/Inicio.aspx"
                oChildItem.Selectable = False
            Else
                If Regex.IsMatch(oDataRow("Url").ToString(), "(.+/)*[A-z]+\.(aspx)") Then
                    OMenuItem.NavigateUrl = oDataRow("Url").ToString()
                Else
                    OMenuItem.NavigateUrl = "~/Inicio.aspx"
                End If
            End If
            If oDataRow("Imagen").ToString() <> "" Then
                OMenuItem.ImageUrl = oDataRow("Imagen").ToString()
            End If
            If OMenuItem.Text = "NINGUNO" Then
                oChildItem.ImageUrl = oDataRow("Imagen").ToString()
                oMenu.Items.Add(oChildItem)
            Else
                oChildItem.NavigateUrl = oDataRow("Url").ToString()
                OMenuItem.ChildItems.Add(oChildItem)
            End If
            CargaRecursiva(oDataRow, oMenu, oChildItem)
        Next
    End Sub
    Public Sub LlenarOpciones(IdModulo As Integer)
        Dim EntidadMenuModulo As New Entidad.MenuModulo()
        Dim NegocioMenuModulo As New Negocio.MenuModulo()
        Dim Tarjeta As New Entidad.Tarjeta()
        Tarjeta = Session("Tarjeta")
        EntidadMenuModulo.IdModulo = IdModulo
        EntidadMenuModulo.IdTipoUsuario = Tarjeta.IdTipoUsuario
        EntidadMenuModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMenuModulo.Consultar(EntidadMenuModulo)
        DtOpciones = EntidadMenuModulo.TablaConsulta
        MNOpcion.Items.Clear()
        DsOpciones.Relations.Clear()
        DsOpciones.Tables.Clear()
        DsOpciones.Tables.Add(DtOpciones)
        DsOpciones.Relations.Add("Relacion", DsOpciones.Tables(0).Columns("IdOpcion"), DsOpciones.Tables(0).Columns("IdOpcionPadre"))
        CargarArbol(DsOpciones, MNOpcion)
    End Sub

    Protected Sub LBCerrar_Click(sender As Object, e As EventArgs) Handles LBCerrar.Click
        Dim Tarjeta As New Entidad.Tarjeta()
        Dim EntidadSesion As New Entidad.Sesion()
        Tarjeta = Session("Tarjeta")
        EntidadSesion.IdSesion = Tarjeta.IdSesion



        'Dim ipv6 As System.Net.IPHostEntry
        'ipv6 = System.Net.Dns.GetHostEntry(My.Computer.Name)
        'EntidadSesion.IPV6 = ipv6.AddressList(0).ToString
        ''Dim localIp As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        'EntidadSesion.IPV4 = ipv6.AddressList(1).ToString
        'EntidadSesion.Latitud = 1
        'EntidadSesion.Longitud = 1
        'EntidadSesion.IdUsuario = 1 'Tarjeta.IdUsuario

        Seguridad.Autenticacion.Session.Cerrar(EntidadSesion)
        Response.Redirect("/Account/Login.aspx")

    End Sub
End Class

