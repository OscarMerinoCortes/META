Public Class Proveedor
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadProveedor As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosProveedor As New Datos.Proveedor()
        DatosProveedor.Consultar(EntidadProveedor)
    End Sub
    Public Sub ConsultarProveedor(ByRef EntidadProveedor As Entidad.EntidadBase)
        Dim DatosProveedor As New Datos.Proveedor()
        DatosProveedor.ConsultarProveedor(EntidadProveedor)
    End Sub
    Public Sub WucEstadisticaProveedor(ByRef EntidadProveedor As Entidad.EntidadBase)
        Dim DatosProveedor As New Datos.Proveedor()
        DatosProveedor.WucEstadistica(EntidadProveedor)
    End Sub

    Public Sub Guardar(ByRef EntidadProveedor As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadProveedor1 As New Entidad.Proveedor()
        Dim DatosProveedor As New Datos.Proveedor()
        EntidadProveedor1 = EntidadProveedor
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadProveedor1.RazonSocial), "El Campo [Razon Social] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadProveedor1.RFC), "El Campo [RFC] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadProveedor1.idUsuarioCreacion = 1
            'EntidadProveedor1.Tarjeta.IdUsuario
            'EntidadProveedor1.UsuarioCreacion = EntidadProveedor1.Tarjeta.Username.ToUpper()
            EntidadProveedor1.FechaCreacion = Now
            EntidadProveedor1.idUsuarioActualizacion = 1
            'EntidadProveedor1.Tarjeta.IdUsuario
            'EntidadProveedor1.UsuarioActualizacion = EntidadProveedor1.Tarjeta.Username.ToUpper()
            EntidadProveedor1.FechaActualizacion = Now
            If EntidadProveedor1.IdProveedor = 0 Then
                DatosProveedor.Insertar(EntidadProveedor1)
            Else
                DatosProveedor.Actualizar(EntidadProveedor1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadProveedor As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosProveedor As New Datos.Proveedor()
        DatosProveedor.Obtener(EntidadProveedor)
    End Sub
    Public Sub ReportePersona(ByRef EntidadProveedor As Entidad.ReportePersona)
        Dim DatosReportePersona As New Datos.Proveedor()
        DatosReportePersona.ReportePersona(EntidadProveedor)
    End Sub
    Public Sub PerfilPersona(ByRef EntidadProveedor As Entidad.EntidadBase)
        Dim DatosPerfilPersona As New Datos.Proveedor
        DatosPerfilPersona.PerfilPersona(EntidadProveedor)
    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadProveedor As Entidad.EntidadBase)
        Dim DatosEntidadPersona As New Datos.Proveedor
        DatosEntidadPersona.ObtenerFiltro(EntidadProveedor)
    End Sub
End Class
