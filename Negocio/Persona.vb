Public Class Persona
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadPersona As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosPersona As New Datos.Persona()
        DatosPersona.Consultar(EntidadPersona)
    End Sub
    Public Sub ConsultarProveedor(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim DatosPersona As New Datos.Persona()
        DatosPersona.ConsultarProveedor(EntidadPersona)
    End Sub

    Public Sub Guardar(ByRef EntidadPersona As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadPersona1 As New Entidad.Persona()
        Dim DatosPersona As New Datos.Persona()
        EntidadPersona1 = EntidadPersona
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadPersona1.IdTipoPersona), "El Campo [Tipo Persona] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.PrimerNombre), "El Campo [Nombre] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.ApellidoPaterno), "El Campo [Apellido Paterno] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.ApellidoMaterno), "El Campo [Apellido Materno] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.FechaNacimiento), "El Campo [Fecha Nacimineto] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.IdTipoGenero), "El Campo [Genero] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.IdTipoEstadoCivil), "El Campo [Estado Civil] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPersona1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadPersona1.IdUsuarioCreacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioCreacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPersona1.FechaCreacion = Now
            EntidadPersona1.IdUsuarioActualizacion = 1
            'EntidadPersona1.Tarjeta.IdUsuario
            'EntidadPersona1.UsuarioActualizacion = EntidadPersona1.Tarjeta.Username.ToUpper()
            EntidadPersona1.FechaActualizacion = Now
            If EntidadPersona1.IdPersona = 0 Then
                DatosPersona.Insertar(EntidadPersona1)
            Else
                DatosPersona.Actualizar(EntidadPersona1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadPersona As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosPersona As New Datos.Persona()
        DatosPersona.Obtener(EntidadPersona)
    End Sub
    Public Sub VentaObtener(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim DatosPersona As New Datos.Persona()
        DatosPersona.VentaObtener(EntidadPersona)
    End Sub
    Public Sub ReportePersona(ByRef EntidadReportePersona As Entidad.ReportePersona)
        Dim DatosReportePersona As New Datos.Persona()
        DatosReportePersona.ReportePersona(EntidadReportePersona)
    End Sub
    Public Sub PerfilPersona(ByRef EntidadPerfilPersona As Entidad.EntidadBase)
        Dim DatosPerfilPersona As New Datos.Persona
        DatosPerfilPersona.PerfilPersona(EntidadPerfilPersona)
    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim DatosEntidadPersona As New Datos.Persona
        DatosEntidadPersona.ObtenerFiltro(EntidadPersona)
    End Sub
End Class
