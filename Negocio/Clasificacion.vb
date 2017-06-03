Public Class Clasificacion
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosClasificacion As New Datos.Clasificacion()
        DatosClasificacion.Consultar(EntidadClasificacion)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosClasificacion As New Datos.Clasificacion()
        Dim EntidadClasificacion1 As New Entidad.Clasificacion()
        EntidadClasificacion1 = EntidadClasificacion
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadClasificacion1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadClasificacion1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadClasificacion1.IdUsuarioCreacion = 1
            'EntidadClasificacion1.Tarjeta.IdUsuario
            'EntidadClasificacion1.UsuarioCreacion = EntidadClasificacion.Tarjeta.Username.ToUpper()
            EntidadClasificacion1.FechaCreacion = Now
            EntidadClasificacion1.IdUsuarioActualizacion = 1
            'EntidadClasificacion1.Tarjeta.IdUsuario
            'EntidadClasificacion1.UsuarioActualizacion = EntidadClasificacion.Tarjeta.Username.ToUpper()
            EntidadClasificacion1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadClasificacion1.IdClasificacion), "El Campo [ID] esta Vacio")
            If EntidadClasificacion1.IdClasificacion = 0 Then
                DatosClasificacion.Insertar(EntidadClasificacion1)
            Else
                DatosClasificacion.Actualizar(EntidadClasificacion1)
            End If
        End If
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosClasificacion As New Datos.Clasificacion()
        DatosClasificacion.Obtener(EntidadMenuModulo)
    End Sub
End Class
