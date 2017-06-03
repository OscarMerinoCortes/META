Public Class Credito
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCredito As New Datos.Credito()
        DatosCredito.Consultar(EntidadCredito)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCredito1 As New Entidad.Credito()
        Dim DatosCredito As New Datos.Credito()
        EntidadCredito1 = EntidadCredito
        EntidadCredito1.idUsuarioCreacion = 1
        'EntidadCredito1.Tarjeta.IdUsuario
        'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
        EntidadCredito1.FechaCreacion = Now
        EntidadCredito1.idUsuarioActualizacion = 1
        'EntidadCredito1.Tarjeta.IdUsuario
        'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
        EntidadCredito1.FechaActualizacion = Now
        If EntidadCredito1.IdCredito = 0 Then
            DatosCredito.Insertar(EntidadCredito1)
        Else
            DatosCredito.Actualizar(EntidadCredito1)
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosCredito As New Datos.Credito()
        DatosCredito.Obtener(EntidadCredito)
    End Sub
End Class
