Public Class Periodo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosPeriodo As New Datos.Periodo()
        DatosPeriodo.Consultar(EntidadPeriodo)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosPeriodo As New Datos.Periodo()
        Dim EntidadPeriodo1 As New Entidad.Periodo()
        EntidadPeriodo1 = EntidadPeriodo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadPeriodo1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPeriodo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadPeriodo1.IdUsuarioCreacion = 1
            'EntidadPeriodo1.Tarjeta.IdUsuario
            'EntidadPeriodo1.UsuarioCreacion = EntidadPeriodo.Tarjeta.Username.ToUpper()
            EntidadPeriodo1.FechaCreacion = Now
            EntidadPeriodo1.IdUsuarioActualizacion = 1
            'EntidadPeriodo1.Tarjeta.IdUsuario
            'EntidadPeriodo1.UsuarioActualizacion = EntidadPeriodo.Tarjeta.Username.ToUpper()
            EntidadPeriodo1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadPeriodo1.IdPeriodo), "El Campo [ID] esta Vacio")
            If EntidadPeriodo1.IdPeriodo = 0 Then
                DatosPeriodo.Insertar(EntidadPeriodo1)
            Else
                DatosPeriodo.Actualizar(EntidadPeriodo1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
