Public Class TipoIndicador
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosIndicadores As New Datos.TipoIndicador()
        DatosIndicadores.Consultar(EntidadIndicadores)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadIndicadores1 As New Entidad.TipoIndicador()
        Dim DatosIndicadores As New Datos.TipoIndicador()
        EntidadIndicadores1 = EntidadIndicadores
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadIndicadores1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadIndicadores1.Descripcion), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadIndicadores1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadIndicadores1.FechaCreacion = Now
            EntidadIndicadores1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadIndicadores1.FechaActualizacion = Now
            If EntidadIndicadores1.IdTipoIndicador = 0 Then
                DatosIndicadores.Insertar(EntidadIndicadores1)
            Else
                DatosIndicadores.Actualizar(EntidadIndicadores1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadIndicadores As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
