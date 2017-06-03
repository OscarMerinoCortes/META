Imports System.Data
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Partial Class _Inicio
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' CType(Master.FindControl("LBOpcion"), Label).Text = ""
            'Consultar()
            Session.Remove("Tarjeta")
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next
            HttpContext.Current.Response.Cookies.Clear()
            HttpContext.Current.Session.Clear()
            HttpContext.Current.Session.Abandon()
            Exit Sub
        End If
    End Sub

    Protected Sub IBTIniciar_Click(sender As Object, e As EventArgs) Handles IBTIniciar.Click
        Dim SeguridadUsuario As New Seguridad.Autenticacion.Usuario()
        Dim EntidadUsuario As New Entidad.Usuario()
        Dim Tarjeta As New Entidad.Tarjeta()
        'Dim Tabla As New DataTable
        ' EntidadUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        ' EntidadUsuario.Tarjeta.Username = TBUsuario.Text
        'EntidadUsuario.Tarjeta.Clave = TBContrasena.Text
        Using md5Hash As SHA512 = SHA512.Create()
            EntidadUsuario.Tarjeta.Username = Seguridad.Autenticacion.Usuario.GetSha512Hash(md5Hash, TBUsuario.Text)
            EntidadUsuario.Tarjeta.Clave = Seguridad.Autenticacion.Usuario.GetSha512Hash(md5Hash, TBContrasena.Text)
        End Using

        'Tabla = EntidadUsuario.TablaConsulta
        'If Tabla.Rows.Count = 0 Then
        If Not Seguridad.Autenticacion.Usuario.Validar(EntidadUsuario.Tarjeta) Then
            'Response.Redirect("Login.aspx")

            LBError.Visible = True
            TBUsuario.Text = ""
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next
            HttpContext.Current.Response.Cookies.Clear()
            HttpContext.Current.Session.Clear()
            HttpContext.Current.Session.Abandon()
            Exit Sub
        Else
            EntidadUsuario.Username = TBUsuario.Text

            Seguridad.Autenticacion.Usuario.Obtener(EntidadUsuario)
            If EntidadUsuario.IdUsuario = 0 Then
                For Each de As DictionaryEntry In HttpContext.Current.Cache
                    HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
                Next
                HttpContext.Current.Response.Cookies.Clear()
                HttpContext.Current.Session.Clear()
                HttpContext.Current.Session.Abandon()
                Response.Redirect("~/Account/Login.aspx")
                Exit Sub
            Else
                'Tarjeta.IdUsuario = EntidadUsuario.IdUsuario
                'Tarjeta.NombreUsuario = EntidadUsuario.PrimerNombre
                'Tarjeta.Username = TBUsuario.Text
                'Tarjeta.IdSucursal = EntidadUsuario.IdSucursal
                'Tarjeta.Sucursal = EntidadUsuario.Sucursal
                'Tarjeta.IdTipoUsuario = EntidadUsuario.IdTipoUsuario
                'LBError.Visible = False
                ''Dim LoginUser As String
                ''LoginUser = Tabla.Rows(0).Item("Username")
                'Session.Add("Tarjeta", Tarjeta)
                ''Sesion()
            End If
            Tarjeta.IdUsuario = EntidadUsuario.IdUsuario
            Tarjeta.NombreUsuario = EntidadUsuario.PrimerNombre
            Tarjeta.Username = TBUsuario.Text
            Tarjeta.IdSucursal = EntidadUsuario.IdSucursal
            Tarjeta.Sucursal = EntidadUsuario.Sucursal
            Tarjeta.IdTipoUsuario = EntidadUsuario.IdTipoUsuario
            Session.Add("Tarjeta", Tarjeta)
            Sesion()
            Response.Redirect("/Inicio.aspx")
        End If
    End Sub

    Public Sub Sesion()
        Try
            ' Dim NegocioSesion As New Negocio.Sesion()
            Dim EntidadSesion As New Entidad.Sesion
            Dim Tarjeta As New Entidad.Tarjeta()
            Tarjeta = Session("Tarjeta")
            'bit
            Dim ipv6 As System.Net.IPHostEntry
            ipv6 = System.Net.Dns.GetHostEntry(My.Computer.Name)
            EntidadSesion.IPV6 = ipv6.AddressList(0).ToString
            'Dim localIp As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            EntidadSesion.IPV4 = ipv6.AddressList(1).ToString
            EntidadSesion.Latitud = 1
            EntidadSesion.Longitud = 1
            EntidadSesion.IdUsuario = 1 'Tarjeta.IdUsuario
            'bit

            Seguridad.Autenticacion.Session.Abrir(EntidadSesion)
            Tarjeta.IdSesion = EntidadSesion.IdSesion
            'Seguridad.Autenticacion.Session.Cerrar(EntidadSesion)
            Session("Tarjeta") = Tarjeta
        Catch ex As Exception
        End Try
    End Sub



End Class
