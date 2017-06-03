Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class SubTipoMovimientoInventario
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadSubTipoMovimientoInventario1 As New Entidad.SubTipoMovimientoInventario()
        EntidadSubTipoMovimientoInventario1 = EntidadSubTipoMovimientoInventario
        EntidadSubTipoMovimientoInventario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadSubTipoMovimientoInventario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisSubTipMovInvCod", sqlcon1)
                    sqldat1.Fill(EntidadSubTipoMovimientoInventario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
                    sqlcom1 = New SqlCommand("ERP_LisSubTipMovIdPad", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()                    
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadSubTipoMovimientoInventario1.IdTipo))
                    sqldat1.Fill(EntidadSubTipoMovimientoInventario1.TablaConsulta)
            End Select
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadSubTipoMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubTipoMovimientoInventario = EntidadSubTipoMovimientoInventario1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadSubTipoMovimientoInventario1 As New Entidad.SubTipoMovimientoInventario()
        EntidadSubTipoMovimientoInventario1 = EntidadSubTipoMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCodSubTipMovInv", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoInventario", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadSubTipoMovimientoInventario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoInventario", EntidadSubTipoMovimientoInventario1.IdTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadSubTipoMovimientoInventario1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadSubTipoMovimientoInventario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSubTipoMovimientoInventario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSubTipoMovimientoInventario1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSubTipoMovimientoInventario1.IdEstado))
            sqlcom1.Parameters("@INIdSubTipoMovimientoInventario").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadSubTipoMovimientoInventario1.IdSubTipo = sqlcom1.Parameters("@INIdSubTipoMovimientoInventario").Value
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSubTipoMovimientoInventario1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubTipoMovimientoInventario = EntidadSubTipoMovimientoInventario1
        End Try
    End Sub

    Public Overridable Sub Actualizar(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadSubTipoMovimientoInventario1 As New Entidad.SubTipoMovimientoInventario()
        EntidadSubTipoMovimientoInventario1 = EntidadSubTipoMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCodSubTipMovInv", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoInventario", EntidadSubTipoMovimientoInventario1.IdSubTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadSubTipoMovimientoInventario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoInventario", EntidadSubTipoMovimientoInventario1.IdTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSubTipoMovimientoInventario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INidUsuarioActualizacion", EntidadSubTipoMovimientoInventario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSubTipoMovimientoInventario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadSubTipoMovimientoInventario1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadSubTipoMovimientoInventario = EntidadSubTipoMovimientoInventario1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadSubTipoMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadSubTipoMovimientoInventario1 As New Entidad.SubTipoMovimientoInventario()
        EntidadSubTipoMovimientoInventario1 = EntidadSubTipoMovimientoInventario
        EntidadSubTipoMovimientoInventario1.TablaSubTipoMovimientoInventario = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()        
            sqlcom1 = New SqlCommand("ERP_LisSubTipMovInvFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadSubTipoMovimientoInventario1.IdSubTipoFiltro = "-1" Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoIni", EntidadSubTipoMovimientoInventario1.IdSubTipoFiltro))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipoMovimientoFin", EntidadSubTipoMovimientoInventario1.IdSubTipoFiltro))
            End If
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadSubTipoMovimientoInventario1.DescripcionFiltro))
            If EntidadSubTipoMovimientoInventario1.IdTipoFiltro = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoIni", EntidadSubTipoMovimientoInventario1.IdTipoFiltro))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMovimientoFin", EntidadSubTipoMovimientoInventario1.IdTipoFiltro))
            End If
            If EntidadSubTipoMovimientoInventario1.IdEstadoFiltro = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", EntidadSubTipoMovimientoInventario1.IdEstadoFiltro))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", EntidadSubTipoMovimientoInventario1.IdEstadoFiltro))
            End If           
            sqldat1.Fill(EntidadSubTipoMovimientoInventario1.TablaSubTipoMovimientoInventario)
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadSubTipoMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadSubTipoMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ConsultarNoEsGafi(ByRef EntidadBase As Entidad.EntidadBase)
        'Dim EntidadPais As New Entidad.Pais()
        'EntidadPais = EntidadBase
        'EntidadPais.TablaConsulta = New DataTable()
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqldat1 As SqlDataAdapter
        'Try
        '    sqlcon1.Open()
        '    sqldat1 = New SqlDataAdapter("pld_LisPaiCodGaf", sqlcon1)
        '    sqldat1.Fill(EntidadPais.TablaConsulta)
        '    EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadPais.Tarjeta.Excepcion = ex.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadBase = EntidadPais
        '    Bitacora.Insertar(EntidadPais.Tarjeta)
        'End Try
    End Sub

    Public Sub ConsultarEsParaiso(ByRef EntidadBase As Entidad.EntidadBase)
        '    Dim EntidadPais As New Entidad.Pais()
        '    EntidadPais = EntidadBase
        '    EntidadPais.TablaConsulta = New DataTable()
        '    Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        '    Dim sqldat1 As SqlDataAdapter
        '    EntidadPais.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Datos
        '    Dim Bitacora As New Seguridad.Bitacora()
        '    Try
        '        sqlcon1.Open()
        '        sqldat1 = New SqlDataAdapter("pld_LisPaiCodPar", sqlcon1)
        '        sqldat1.Fill(EntidadPais.TablaConsulta)
        '        EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        '    Catch ex As Exception
        '        EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '        EntidadPais.Tarjeta.Excepcion = ex.ToString()
        '    Finally
        '        sqlcon1.Close()
        '        EntidadBase = EntidadPais
        '        Bitacora.Insertar(EntidadPais.Tarjeta)
        '    End Try
    End Sub
End Class
