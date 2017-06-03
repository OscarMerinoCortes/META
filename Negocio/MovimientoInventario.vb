Public Class MovimientoInventario
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        DatosMovimientoInventario.Consultar(EntidadMovimientoInventario)
    End Sub

    Public Sub Guardar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadMovimientoInventario1.Fecha), "El Campo [Fecha] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadMovimientoInventario1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadMovimientoInventario1.idUsuarioCreacion = 1       
            EntidadMovimientoInventario1.FechaCreacion = Now
            EntidadMovimientoInventario1.idUsuarioActualizacion = 1         
            EntidadMovimientoInventario1.FechaActualizacion = Now           
            DatosMovimientoInventario.UpSert(EntidadMovimientoInventario1)           
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        DatosMovimientoInventario.Obtener(EntidadMovimientoInventario)
    End Sub
    Public Sub Aplicar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim DSResRul As String = ""        
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else        
            EntidadMovimientoInventario1.idUsuarioCreacion = 1           
            EntidadMovimientoInventario1.FechaCreacion = Now
            EntidadMovimientoInventario1.idUsuarioActualizacion = 1            
            EntidadMovimientoInventario1.FechaActualizacion = Now
            DatosMovimientoInventario.Aplicar(EntidadMovimientoInventario1)
        End If
    End Sub
    Public Sub Cancelar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim DSResRul As String = ""       
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadMovimientoInventario1.idUsuarioCreacion = 1           
            EntidadMovimientoInventario1.FechaCreacion = Now
            EntidadMovimientoInventario1.idUsuarioActualizacion = 1            
            EntidadMovimientoInventario1.FechaActualizacion = Now
            DatosMovimientoInventario.Cancelar(EntidadMovimientoInventario1)
        End If
    End Sub
    Public Sub ObtenerPendientes(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        DatosMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
    End Sub
    Public Sub ActualizarPendientes(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadMovimientoInventario1.idUsuarioCreacion = 1       
            EntidadMovimientoInventario1.FechaCreacion = Now
            EntidadMovimientoInventario1.idUsuarioActualizacion = 1        
            EntidadMovimientoInventario1.FechaActualizacion = Now
            DatosMovimientoInventario.ActualizarPendientes(EntidadMovimientoInventario1)
        End If
    End Sub
    Public Sub ConsultarTraspasoEnvio(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        DatosMovimientoInventario.ConsultaTraspasoEnvio(EntidadMovimientoInventario)
    End Sub
    Public Sub GraficasMovimientoInventario(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim DatosMovimientoInventario As New Datos.MovimientoInventario()
        DatosMovimientoInventario.GraficasMovimientoInventario(EntidadMovimientoInventario)
    End Sub
End Class
