Imports System.Data.SqlClient
Imports Entidad
Imports Operacion.Configuracion.Constante
Public Class SolicitudCompra
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActSolCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitud", EntidadSolicitudCompra1.IdSolicitudCompra))
            AgragarParametrosSolicitudCompra(sqlcom1, EntidadSolicitudCompra1)
            sqlcom1.ExecuteNonQuery()

            '========================================================== Solicitud Detalle =====================================================
            For Each MiDataRow As DataRow In EntidadSolicitudCompra1.TablaSolicitudDetalle.Rows
                'si se va a actualizar el registro
                InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow, EntidadSolicitudCompra1)
            Next

            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSolicitudCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSolicitudCompra = EntidadSolicitudCompra1
        End Try
    End Sub

    Public Sub ConsultarFiltro(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_ObtSolComFil")
    End Sub


    Private Sub ObtenerSol(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra, sp As String)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            EntidadProcesoCompra.TablaConsulta = New DataTable()
            sqlcon1.Open()
            sqlcom1 = New SqlCommand(sp, sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadProcesoCompra.IdProceso = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", EntidadProcesoCompra.IdProceso))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", EntidadProcesoCompra.IdProceso))
            End If
            If EntidadProcesoCompra.IdTipoPrioridad = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadIni", EntidadProcesoCompra.IdTipoPrioridad))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadFin", EntidadProcesoCompra.IdTipoPrioridad))
            End If

            If EntidadProcesoCompra.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", EntidadProcesoCompra.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", EntidadProcesoCompra.IdEstado))
            End If

            If EntidadProcesoCompra.IdSolicitudEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoIni", EntidadProcesoCompra.IdSolicitudEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoFin", EntidadProcesoCompra.IdSolicitudEstado))
            End If

            If EntidadProcesoCompra.FechaInicio = "01/01/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", EntidadProcesoCompra.FechaInicio))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            End If

            If EntidadProcesoCompra.FechaFin = "01/12/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", EntidadProcesoCompra.FechaFin.AddDays(1)))
            End If
            sqldat1.Fill(EntidadProcesoCompra.TablaConsulta)
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProcesoCompra.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ActualizarSolicitudDetalle(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActSolDetAutCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", EntidadSolicitudCompra1.IdSolicitudCompra))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", EntidadSolicitudCompra1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", EntidadSolicitudCompra1.IdTipoSolicitudEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadSolicitudCompra1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSolicitudCompra1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSolicitudCompra1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSolicitudCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSolicitudCompra = EntidadSolicitudCompra1
        End Try
    End Sub
    Private Sub AgragarParametrosSolicitudCompra(ByRef sqlcom1 As SqlCommand, ByVal entidadSolicitudCompra1 As Entidad.SolicitudCompra)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", entidadSolicitudCompra1.IdTipoPrioridad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", entidadSolicitudCompra1.IdTipoSolicitudEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", entidadSolicitudCompra1.IdEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadSolicitudCompra1.idUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadSolicitudCompra1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IVOservacion", entidadSolicitudCompra1.Observacion))
    End Sub
    Private Sub InsertarActualizarSolicitudDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadSolicitudCompra1 As Entidad.SolicitudCompra)
        If miDataRow("IdActualizar") = 1 Then
            If miDataRow("IdSolicitudDetalle") = 0 Then
                sqlcom1.CommandText = "ERP_InsSolDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("IdUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
                AgregarParametrosSolicitudDetalle(sqlcom1, miDataRow, entidadSolicitudCompra1)
                sqlcom1.Parameters("@INIdSolicitudDetalle").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
            Else
                sqlcom1.CommandText = "ERP_ActSolDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", miDataRow("IdSolicitudDetalle")))
                AgregarParametrosSolicitudDetalle(sqlcom1, miDataRow, entidadSolicitudCompra1)
                sqlcom1.ExecuteNonQuery()
            End If
        End If
    End Sub
    Private Sub AgregarParametrosSolicitudDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadSolicitudCompra1 As Entidad.SolicitudCompra)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitud", entidadSolicitudCompra1.IdSolicitudCompra))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", miDataRow("IdProducto")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", entidadSolicitudCompra1.IdTipoPrioridad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", miDataRow("Descripcion")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", miDataRow("IdSucursal")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", miDataRow("IdAlmacen")))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadAlterna", miDataRow("CantidadAlterna")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidadAlterna", miDataRow("IdUnidadAlterna")))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", miDataRow("Cantidad")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidad", miDataRow("IdUnidad")))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadInventario", miDataRow("CantidadInventario")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidadInventario", miDataRow("IdUnidadInventario")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
    End Sub

    Public Sub Consultar(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadSolicitudCompra1 = New Entidad.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        EntidadSolicitudCompra1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadSolicitudCompra1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSolDet", sqlcon1)
                    sqldat1.Fill(EntidadSolicitudCompra1.TablaConsulta)
                Case Consulta.Ninguno
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSolNin", sqlcon1)
                    sqldat1.Fill(EntidadSolicitudCompra1.TablaConsulta)
                Case Else
            End Select
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSolicitudCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSolicitudCompra = EntidadSolicitudCompra1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsSolCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitud", 0))
            AgragarParametrosSolicitudCompra(sqlcom1, EntidadSolicitudCompra1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadSolicitudCompra1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadSolicitudCompra1.FechaCreacion))
            sqlcom1.Parameters(EntidadSolicitudCompra1.IdSolicitudCompra).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadSolicitudCompra1.IdSolicitudCompra = sqlcom1.Parameters(EntidadSolicitudCompra1.IdSolicitudCompra).Value

            '========================================================== Solicitud Detalle =====================================================
            For Each MiDataRow As DataRow In EntidadSolicitudCompra1.TablaSolicitudDetalle.Rows
                InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow, EntidadSolicitudCompra1)
            Next
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSolicitudCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSolicitudCompra = EntidadSolicitudCompra1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadSolicitudCompra1.TablaSolicitudDetalle = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtSolDetCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitud", EntidadSolicitudCompra1.IdSolicitudCompra))
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_ObtSolDetCod"
            sqldat1.Fill(EntidadSolicitudCompra1.TablaSolicitudDetalle)

            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSolicitudCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSolicitudCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerTablas(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadSolicitudCompra.TablaIdentificacion = New DataTable()
        'EntidadSolicitudCompra.TablaContacto = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudCompra", EntidadSolicitudCompra.IdSolicitudCompra))
        '    sqldat1.Fill(EntidadSolicitudCompra.TablaIdentificacion)
        '    'Tabla Contacto
        '    sqlcom1.CommandText = "ERP_LisPerMedCod"
        '    sqldat1.Fill(EntidadSolicitudCompra.TablaContacto)
        '    'Tabla Domicilio
        '    sqlcom1.CommandText = "ERP_LisPerDomCod"
        '    sqldat1.Fill(EntidadSolicitudCompra.TablaDomicilio)
        '    EntidadSolicitudCompra.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadSolicitudCompra.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadSolicitudCompra.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub

End Class
