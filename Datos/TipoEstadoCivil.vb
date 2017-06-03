Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoEstadoCivil
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadEstadoCivil1 As New Entidad.TipoEstadoCivil()
        EntidadEstadoCivil1 = EntidadEstadoCivil
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActEstCivCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", EntidadEstadoCivil1.IdTipoEstadoCivil))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadEstadoCivil1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadEstadoCivil1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadEstadoCivil1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadEstadoCivil1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadEstadoCivil1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadEstadoCivil = EntidadEstadoCivil1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadEstadoCivil1 = New Entidad.TipoEstadoCivil()
        EntidadEstadoCivil1 = EntidadEstadoCivil
        EntidadEstadoCivil1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadEstadoCivil1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEstCivDet", sqlcon1)
                    sqldat1.Fill(EntidadEstadoCivil1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipEstCivBas", sqlcon1)
                    sqldat1.Fill(EntidadEstadoCivil1.TablaConsulta)
                Case Else
            End Select
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadEstadoCivil1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadEstadoCivil = EntidadEstadoCivil1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadEstadoCivil1 As New Entidad.TipoEstadoCivil()
        EntidadEstadoCivil1 = EntidadEstadoCivil
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsEstCivCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadEstadoCivil1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadEstadoCivil1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadEstadoCivil1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadEstadoCivil1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadEstadoCivil1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadEstadoCivil1.FechaActualizacion))
            sqlcom1.Parameters(EntidadEstadoCivil1.IdTipoEstadoCivil).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadEstadoCivil1.IdTipoEstadoCivil = sqlcom1.Parameters(EntidadEstadoCivil1.IdTipoEstadoCivil).Value
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEstadoCivil1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadEstadoCivil1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadEstadoCivil = EntidadEstadoCivil1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
