Public Class Calendario
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCalendario As New Datos.Calendario()
        DatosCalendario.Consultar(EntidadCalendario)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosCalendario As New Datos.Calendario()
        Dim EntidadCalendario1 As New Entidad.Calendario()
        EntidadCalendario1 = EntidadCalendario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCalendario1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCalendario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCalendario1.IdUsuarioCreacion = 1
            'EntidadCalendario1.Tarjeta.IdUsuario
            'EntidadCalendario1.UsuarioCreacion = EntidadCalendario.Tarjeta.Username.ToUpper()
            EntidadCalendario1.FechaCreacion = Now
            EntidadCalendario1.IdUsuarioActualizacion = 1
            'EntidadCalendario1.Tarjeta.IdUsuario
            'EntidadCalendario1.UsuarioActualizacion = EntidadCalendario.Tarjeta.Username.ToUpper()
            EntidadCalendario1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadCalendario1.IdCalendario), "El Campo [ID] esta Vacio")
            If EntidadCalendario1.IdCalendario = 0 Then
                DatosCalendario.Insertar(EntidadCalendario1)
            Else
                DatosCalendario.Actualizar(EntidadCalendario1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
