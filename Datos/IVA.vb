Imports System.Threading
Imports System.Data.SqlClient
Public Class IVA
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadIVA1 As New Entidad.IVA()
        EntidadIVA1 = EntidadIVA
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActInsIVACod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdIva", EntidadIVA1.IdIva))
            sqlcom1.Parameters.Add(New SqlParameter("@IVIVA", EntidadIVA1.IVA))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIVA1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIVA1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIVA1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIVA1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIVA = EntidadIVA1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadIVA1 = New Entidad.IVA()
        EntidadIVA1 = EntidadIVA
        EntidadIVA1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadIVA1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConIVACod", sqlcon1)
                    sqldat1.Fill(EntidadIVA1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConIVACodId", sqlcon1)
                    sqldat1.Fill(EntidadIVA1.TablaConsulta)
                Case Else
            End Select
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIVA1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIVA = EntidadIVA1
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadIVA1 As New Entidad.IVA()
        EntidadIVA1 = EntidadIVA
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActInsIVACod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdIva", EntidadIVA1.IdIva))
            sqlcom1.Parameters.Add(New SqlParameter("@IVIVA", EntidadIVA1.IVA))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIVA1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadIVA1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadIVA1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIVA1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIVA1.FechaActualizacion))
            If EntidadIVA1.IdIva = 0 Then
                sqlcom1.Parameters(EntidadIVA1.IdIva).Direction = ParameterDirection.InputOutput
            End If


            sqlcom1.ExecuteNonQuery()
            EntidadIVA1.IdIva = sqlcom1.Parameters(EntidadIVA1.IdIva).Value
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIVA1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIVA1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIVA = EntidadIVA1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadIVA As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
