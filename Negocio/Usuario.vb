Public Class Usuario
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadUsuario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosUsuario As New Datos.Usuario()
        DatosUsuario.Consultar(EntidadUsuario)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUsuario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosUsuario As New Datos.Usuario()
        Dim EntidadUsuario1 As New Entidad.Usuario()
        EntidadUsuario1 = EntidadUsuario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadUsuario1.Username), "El Campo [Username] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Abreviacion), "El Campo [Abreviacion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.PrimerNombre), "El Campo [Primer Nombre] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadUsuario1.SegundoNombre), "El Campo [Segundo Nombre] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.ApellidoPaterno), "El Campo [Apellido Paterno] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.ApellidoMaterno), "El Campo [Apellido Materno] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Dia), "El Campo [Dia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Mes), "El Campo [Mes] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Ano), "El Campo [Año] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.IdTipoUsuario), "El Campo [Tipo de Usuario] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadUsuario1.Clave), "El Campo [Contraseña] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Vigencia), "El Campo [Vigencia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Correo), "El Campo [Correo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.Telefono), "El Campo [Telefono] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUsuario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadUsuario1.IdUsuarioCreacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioCreacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadUsuario1.FechaCreacion = Now
            EntidadUsuario1.IdUsuarioActualizacion = 1
            'EntidadTipoProducto1.Tarjeta.IdUsuario
            'EntidadTipoProducto1.UsuarioActualizacion = EntidadTipoProducto.Tarjeta.Username.ToUpper()
            EntidadUsuario1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadUsuario1.IdUsuario), "El Campo [ID] esta Vacio")
            If EntidadUsuario1.IdUsuario > -1 Then
                DatosUsuario.Insertar(EntidadUsuario1)
            Else
                DatosUsuario.Actualizar(EntidadUsuario1)
            End If
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub

    Public Sub ConsultarVenta(ByRef entidadUsuario As Entidad.EntidadBase)
        Dim DatosUsuario As New Datos.Usuario()
        DatosUsuario.ConsultarVenta(entidadUsuario)
    End Sub
End Class
