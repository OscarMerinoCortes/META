Public Class TipoEmpleo
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosTipoEmpleo As New Datos.TipoEmpleo()
        DatosTipoEmpleo.Consultar(EntidadTipoEmpleo)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadTipoEmpleo1 As New Entidad.TipoEmpleo()
        Dim DatosTipoEmpleo As New Datos.TipoEmpleo()
        EntidadTipoEmpleo1 = EntidadTipoEmpleo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadTipoEmpleo1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadTipoEmpleo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadTipoEmpleo1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoEmpleo1.FechaCreacion = Now
            EntidadTipoEmpleo1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadTipoEmpleo1.FechaActualizacion = Now
            If EntidadTipoEmpleo1.IdTipoEmpleo = 0 Then
                DatosTipoEmpleo.Insertar(EntidadTipoEmpleo1)
            Else
                DatosTipoEmpleo.Actualizar(EntidadTipoEmpleo1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadTipoEmpleo As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
