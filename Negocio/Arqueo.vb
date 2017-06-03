Public Class Arqueo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosArqueo As New Datos.Arqueo()
        DatosArqueo.Consultar(EntidadArqueo)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadArqueo1 As New Entidad.Arqueo()
        Dim DatosArqueo As New Datos.Arqueo()
        EntidadArqueo1 = EntidadArqueo
        Dim DSResRul As String = ""    
        AddRul(DSResRul, Vacio(EntidadArqueo1.IdSucursal), "El Campo [IdSucursal] esta vacio")
        AddRul(DSResRul, Vacio(EntidadArqueo1.IdCaja), "El Campo [IdCaja] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadArqueo1.IdSucursal), "El Campo [IdSucursal] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadArqueo1.IdEstado), "El Campo [IdEstado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadArqueo1.idUsuarioCreacion = 1            
            EntidadArqueo1.FechaCreacion = Now
            EntidadArqueo1.idUsuarioActualizacion = 1           
            EntidadArqueo1.FechaActualizacion = Now
            If EntidadArqueo1.IdArqueo = 0 Then
                DatosArqueo.Insertar(EntidadArqueo1)
            Else
                DatosArqueo.Actualizar(EntidadArqueo1)
            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosArqueo As New Datos.Arqueo()
        DatosArqueo.Obtener(EntidadArqueo)
    End Sub
End Class
