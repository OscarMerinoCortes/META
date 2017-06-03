Public Class MenuModulo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosMenuModulo As New Datos.MenuModulo()
        DatosMenuModulo.Consultar(EntidadMenuModulo)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosMenuModulo As New Datos.MenuModulo()
        Dim EntidadMenuModulo1 As New Entidad.MenuModulo()
        EntidadMenuModulo1 = EntidadMenuModulo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadMenuModulo1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadMenuModulo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadMenuModulo1.idUsuarioCreacion = 1
            'EntidadClasificacion1.Tarjeta.IdUsuario
            'EntidadClasificacion1.UsuarioCreacion = EntidadClasificacion.Tarjeta.Username.ToUpper()
            EntidadMenuModulo1.FechaCreacion = Now
            EntidadMenuModulo1.idUsuarioActualizacion = 1
            'EntidadClasificacion1.Tarjeta.IdUsuario
            'EntidadClasificacion1.UsuarioActualizacion = EntidadClasificacion.Tarjeta.Username.ToUpper()
            EntidadMenuModulo1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadMenuModulo1.IdModulo), "El Campo [ID] esta Vacio")
            If EntidadMenuModulo1.IdModulo = 0 Then
                DatosMenuModulo.Insertar(EntidadMenuModulo1)
            Else
                DatosMenuModulo.Actualizar(EntidadMenuModulo1)
            End If
        End If
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadMenuModulo As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosMenuModulo As New Datos.MenuModulo()
        DatosMenuModulo.Obtener(EntidadMenuModulo)
    End Sub
End Class
