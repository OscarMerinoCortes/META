Public Class Subclasificacion
    Implements ICatalogo


    Public Sub Consultar(ByRef EntidadSubclasificacion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosSubClasificaciones As New Datos.Subclasificacion()
        DatosSubClasificaciones.Consultar(EntidadSubclasificacion)
    End Sub

    Public Sub Guardar(ByRef EntidadSubclasificacion As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosSubclasificacion As New Datos.Subclasificacion()
        Dim EntidadSubClasificacion1 As New Entidad.Subclasificacion()
        EntidadSubClasificacion1 = EntidadSubclasificacion
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadSubClasificacion1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadSubClasificacion1.Ganancia), "El Campo [Ganancia] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadSubClasificacion1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadSubClasificacion1.idUsuarioCreacion = 1
            'EntidadSubClasificacion1.Tarjeta.IdUsuario
            'EntidadSubClasificacion1.UsuarioCreacion = EntidadSubClasificacion.Tarjeta.Username.ToUpper()
            EntidadSubClasificacion1.FechaCreacion = Now
            EntidadSubClasificacion1.idUsuarioActualizacion = 1
            'EntidadSubClasificacion1.Tarjeta.IdUsuario
            'EntidadSubClasificacion1.UsuarioActualizacion = EntidadSubClasificacion.Tarjeta.Username.ToUpper()
            EntidadSubClasificacion1.FechaActualizacion = Now
            If EntidadSubClasificacion1.IdSubclasificacion = 0 Then
                DatosSubclasificacion.Insertar(EntidadSubClasificacion1)
            Else
                DatosSubclasificacion.Actualizar(EntidadSubClasificacion1)
            End If
        End If
    End Sub

    Public Sub Obtener(ByRef Entidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadSubclasificacion As Entidad.EntidadBase)
        Dim DatosSubClasificaciones As New Datos.Subclasificacion()
        DatosSubClasificaciones.ObtenerFiltro(EntidadSubclasificacion)
    End Sub
End Class
