Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class ReportesProcesoCompra
    Shared proveedor As Boolean = False
    Public Sub ReporteOrdenCompra(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_LisRepOrdComDet")
    End Sub
    Public Sub ObtenerSolicitudes(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_LisSolCom")
    End Sub
    Public Sub ObtenerSolicitudAutorizada(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_LisSolComAut")
    End Sub
    Public Sub ObtenerSolicitudesOrdenadas(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        proveedor = True
        ObtenerSol(EntidadProcesoCompra, "ERP_LisOrdCom")
    End Sub
    Public Sub ReporteSolicitudCompra(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_LisRepSolComDet")
    End Sub
    Public Sub ReporteCompra(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_LisRepComDet")
    End Sub
    Public Sub ReporteCompras(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)

        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            EntidadProcesoCompra.TablaConsulta = New DataTable()
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisRepCom", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            'parametros
            sqlcom1.Parameters.Add(New SqlParameter("@IdProveedor", EntidadProcesoCompra.IdProveedor))
            sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio", EntidadProcesoCompra.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@FechaFin", EntidadProcesoCompra.FechaFin.AddDays(1)))
            sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", EntidadProcesoCompra.IdSolicitudEstado))
            sqldat1.Fill(EntidadProcesoCompra.TablaConsulta)
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProcesoCompra.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
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
            If proveedor Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProcesoCompra.IdProveedor))
                proveedor = False
            End If
            If EntidadProcesoCompra.IdProceso = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", EntidadProcesoCompra.IdProceso))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", EntidadProcesoCompra.IdProceso))
            End If
            If EntidadProcesoCompra.IdAlmacen = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", EntidadProcesoCompra.IdAlmacen))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", EntidadProcesoCompra.IdAlmacen))
            End If

            If EntidadProcesoCompra.IdClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdClasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdClasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdClasificacionIni", EntidadProcesoCompra.IdClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IdClasificacionFin", EntidadProcesoCompra.IdClasificacion))
            End If

            If EntidadProcesoCompra.IdSubclasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdSubclasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSubclasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdSubclasificacionIni", EntidadProcesoCompra.IdSubclasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSubclasificacionFin", EntidadProcesoCompra.IdSubclasificacion))
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
End Class
