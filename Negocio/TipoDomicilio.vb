Public Class TipoDomicilio
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoDomicilio As New Datos.TipoDomicilio()
        DatosTipoDomicilio.Consultar(EntidadTipoDomicilio)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoDomicilio1 As New Entidad.TipoDomicilio()
        Dim DatosTipoDomicilio As New Datos.TipoDomicilio()
        EntidadTipoDomicilio1 = EntidadTipoDomicilio
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoDomicilio1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoDomicilio1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoDomicilio1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoDomicilio1.FechaCreacion = Now
            EntidadTipoDomicilio1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoDomicilio1.FechaActualizacion = Now

            If EntidadTipoDomicilio1.IdTipoDomicilio = 0 Then
                DatosTipoDomicilio.Insertar(EntidadTipoDomicilio1)
            Else
                DatosTipoDomicilio.Actualizar(EntidadTipoDomicilio1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
