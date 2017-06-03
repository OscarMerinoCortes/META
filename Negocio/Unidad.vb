Public Class Unidad
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosUnidad As New Datos.Unidad()
        DatosUnidad.Consultar(EntidadUnidad)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosUnidad As New Datos.Unidad()
        Dim EntidadUnidad1 As New Entidad.Unidad()
        EntidadUnidad1 = EntidadUnidad
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadUnidad1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadUnidad1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadUnidad1.IdUsuarioCreacion = 1
            'EntidadUnidad1.Tarjeta.IdUsuario
            'EntidadUnidad1.UsuarioCreacion = EntidadUnidad.Tarjeta.Username.ToUpper()
            EntidadUnidad1.FechaCreacion = Now
            EntidadUnidad1.IdUsuarioActualizacion = 1
            'EntidadUnidad1.Tarjeta.IdUsuario
            'EntidadUnidad1.UsuarioActualizacion = EntidadUnidad.Tarjeta.Username.ToUpper()
            EntidadUnidad1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadUnidad1.IdUnidad), "El Campo [ID] esta Vacio")
            If EntidadUnidad1.IdUnidad = 0 Then
                DatosUnidad.Insertar(EntidadUnidad1)
            Else
                DatosUnidad.Actualizar(EntidadUnidad1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
