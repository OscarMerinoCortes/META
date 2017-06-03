Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoCalendario
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoCalendario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoCalendario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoCalendario1 = New Entidad.TipoCalendario()
        EntidadTipoCalendario1 = EntidadTipoCalendario
        EntidadTipoCalendario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoCalendario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCalDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoCalendario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCalBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoCalendario1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoCalendario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCalendario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCalendario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCalendario = EntidadTipoCalendario1
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadTipoCalendario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoCalendario1 As New Entidad.TipoCalendario()
        EntidadTipoCalendario1 = EntidadTipoCalendario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActTipCalCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCalendario", EntidadTipoCalendario1.IdTipoCalendario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoCalendario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INMes", EntidadTipoCalendario1.Mes))
            sqlcom1.Parameters.Add(New SqlParameter("@INAno", EntidadTipoCalendario1.Ano))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadTipoCalendario1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoCalendario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoCalendario1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoCalendario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoCalendario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoCalendario1.FechaActualizacion))
            If EntidadTipoCalendario1.IdTipoCalendario = 0 Then
                sqlcom1.Parameters(EntidadTipoCalendario1.IdTipoCalendario).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            EntidadTipoCalendario1.IdTipoCalendario = sqlcom1.Parameters(EntidadTipoCalendario1.IdTipoCalendario).Value
            EntidadTipoCalendario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCalendario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCalendario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCalendario = EntidadTipoCalendario1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
