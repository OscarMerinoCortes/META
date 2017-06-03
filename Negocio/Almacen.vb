Public Class Almacen
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadAlmacen As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosAlmacen As New Datos.Almacen()
        DatosAlmacen.Consultar(EntidadAlmacen)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadAlmacen As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosAlmacen As New Datos.Almacen()
        Dim EntidadAlmacen1 As New Entidad.Almacen()
        EntidadAlmacen1 = EntidadAlmacen
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadAlmacen1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadAlmacen1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadAlmacen1.IdUsuarioCreacion = 1
            'EntidadAlmacen1.Tarjeta.IdUsuario
            'EntidadAlmacen1.UsuarioCreacion = EntidadAlmacen.Tarjeta.Username.ToUpper()
            EntidadAlmacen1.FechaCreacion = Now
            EntidadAlmacen1.IdUsuarioActualizacion = 1
            'EntidadAlmacen1.Tarjeta.IdUsuario
            'EntidadAlmacen1.UsuarioActualizacion = EntidadAlmacen.Tarjeta.Username.ToUpper()
            EntidadAlmacen1.FechaActualizacion = Now
            If EntidadAlmacen1.IdAlmacen = 0 Then
                DatosAlmacen.Insertar(EntidadAlmacen1)
            Else
                DatosAlmacen.Actualizar(EntidadAlmacen1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadAlmacen As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
