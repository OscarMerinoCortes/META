Public Class Sucursal
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosSucursal As New Datos.Sucursal()
        DatosSucursal.Consultar(EntidadSucursal)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosSucursal As New Datos.Sucursal()
        Dim EntidadSucursal1 As New Entidad.Sucursal()
        EntidadSucursal1 = EntidadSucursal
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadSucursal1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadSucursal1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadSucursal1.IdUsuarioCreacion = 1
            'EntidadSucursal1.Tarjeta.IdUsuario
            'EntidadSucursal1.UsuarioCreacion = EntidadSucursal.Tarjeta.Username.ToUpper()
            EntidadSucursal1.FechaCreacion = Now
            EntidadSucursal1.IdUsuarioActualizacion = 1
            'EntidadSucursal1.Tarjeta.IdUsuario
            'EntidadSucursal1.UsuarioActualizacion = EntidadSucursal.Tarjeta.Username.ToUpper()
            EntidadSucursal1.FechaActualizacion = Now
            If EntidadSucursal1.IdSucursal = 0 Then
                DatosSucursal.Insertar(EntidadSucursal1)
            Else
                DatosSucursal.Actualizar(EntidadSucursal1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
