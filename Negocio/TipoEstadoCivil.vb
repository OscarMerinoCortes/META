Public Class TipoEstadoCivil
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosEstadoCivil As New Datos.TipoEstadoCivil()
        DatosEstadoCivil.Consultar(EntidadEstadoCivil)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadEstadoCivil1 As New Entidad.TipoEstadoCivil()
        Dim DatosEstadoCivil As New Datos.TipoEstadoCivil()
        EntidadEstadoCivil1 = EntidadEstadoCivil
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadEstadoCivil1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadEstadoCivil1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadEstadoCivil1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadEstadoCivil1.FechaCreacion = Now
            EntidadEstadoCivil1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadEstadoCivil1.FechaActualizacion = Now
            If EntidadEstadoCivil1.IdTipoEstadoCivil = 0 Then
                DatosEstadoCivil.Insertar(EntidadEstadoCivil1)
            Else
                DatosEstadoCivil.Actualizar(EntidadEstadoCivil1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
