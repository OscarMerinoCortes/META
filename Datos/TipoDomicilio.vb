Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoDomicilio
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoDomicilio1 As New Entidad.TipoDomicilio()
        EntidadTipoDomicilio1 = EntidadTipoDomicilio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipDomCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", EntidadTipoDomicilio1.IdTipoDomicilio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoDomicilio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDomicilio1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDomicilio1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDomicilio1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDomicilio = EntidadTipoDomicilio1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoDomicilio1 = New Entidad.TipoDomicilio()
        EntidadTipoDomicilio1 = EntidadTipoDomicilio
        EntidadTipoDomicilio1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoDomicilio1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDomDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoDomicilio1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDomBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoDomicilio1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDomicilio = EntidadTipoDomicilio1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoDomicilio1 As New Entidad.TipoDomicilio()
        EntidadTipoDomicilio1 = EntidadTipoDomicilio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipDomCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoDomicilio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDomicilio1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoDomicilio1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoDomicilio1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDomicilio1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDomicilio1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoDomicilio1.IdTipoDomicilio).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoDomicilio1.IdTipoDomicilio = sqlcom1.Parameters(EntidadTipoDomicilio1.IdTipoDomicilio).Value
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDomicilio = EntidadTipoDomicilio1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
