
Partial Class MasterPageVenta
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'seguridad
            Dim Tarjeta As New Entidad.Tarjeta()
            'Tarjeta = Session("Tarjeta")
            If Session("Tarjeta") Is Nothing Then
                Response.Redirect("/Account/Login.aspx")
            Else
                Tarjeta = CType(Session("Tarjeta"), Entidad.Tarjeta)
            End If

            Try
                Dim NegocioTipoVenta As New Negocio.TipoVenta()
                Dim EntidadTipoVenta As New Entidad.TipoVenta()
                EntidadTipoVenta.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                NegocioTipoVenta.Consultar(EntidadTipoVenta)

                For Each row In EntidadTipoVenta.TablaConsulta.Rows
                    Select Case row("Descripcion").ToString.ToLower()
                        Case "credito"
                            DDVCambiar.Items.Add(New ListItem(Operacion.Configuracion.Constante.TipoVenta.Credito.ToString().ToUpper(), Operacion.Configuracion.Constante.TipoVenta.Credito))
                        Case "contado"
                            DDVCambiar.Items.Add(New ListItem(Operacion.Configuracion.Constante.TipoVenta.Contado.ToString().ToUpper(), Operacion.Configuracion.Constante.TipoVenta.Contado))
                        Case "apartado"
                            DDVCambiar.Items.Add(New ListItem(Operacion.Configuracion.Constante.TipoVenta.Apartado.ToString().ToUpper(), Operacion.Configuracion.Constante.TipoVenta.Apartado))
                    End Select
                Next
            Catch ex As Exception
                DDVCambiar.Items.Add(New ListItem("Error - Sin Tipo de Ventas"))
            End Try
            'seguridad
            'seguridad nombres y id
            'CType(Master.FindControl("LBMUsuarioCompleto"), Label).Text = "Alfredo Borrego Saenz"
            'CType(Master.FindControl("LBMUsuarioCorreo"), Label).Text = "aborrego@syseti.com"
            ' Session("IdModulo") = Operacion.Configuracion.Constante.Modulo.Cliente 'Cambiar esta linea de codigo en un default.MasterPage como en quanto
        End If
    End Sub
    Protected Sub LBCerrar_Click(sender As Object, e As EventArgs) Handles LBCerrar.Click
        Dim Tarjeta As New Entidad.Tarjeta()
        Dim EntidadSesion As New Entidad.Sesion()
        Tarjeta = Session("Tarjeta")
        EntidadSesion.IdSesion = Tarjeta.IdSesion
        Seguridad.Autenticacion.Session.Cerrar(EntidadSesion)
        Response.Redirect("/Account/Login.aspx")
    End Sub
End Class

