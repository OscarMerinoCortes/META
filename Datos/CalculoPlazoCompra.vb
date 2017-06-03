Imports System.Threading
Imports System.Data.SqlClient
Public Class CalculoPlazoCompra
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Actualizar
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadCalculoPlazo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCalculoPlazo1 = New Entidad.CalculoPlazoCompra()
        EntidadCalculoPlazo1 = EntidadCalculoPlazo
        EntidadCalculoPlazo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadCalculoPlazo1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConConfPlazo", sqlcon1)
                    sqldat1.Fill(EntidadCalculoPlazo1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConConfPlazDet", sqlcon1)
                    sqldat1.Fill(EntidadCalculoPlazo1.TablaConsulta)
            End Select
            EntidadCalculoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadCalculoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadCalculoPlazo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCalculoPlazo = EntidadCalculoPlazo
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadCalculoPlazo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCalculoPlazo1 As New Entidad.CalculoPlazoCompra()
        EntidadCalculoPlazo1 = EntidadCalculoPlazo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActConfPlazCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdConfiguracionCalculoPlazo", EntidadCalculoPlazo1.IdConfiguracionCalculo))
            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioInicio", EntidadCalculoPlazo1.PrecioInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioFin", EntidadCalculoPlazo1.PrecioFin))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPlazoContado", EntidadCalculoPlazo1.IdTipoPlazoContado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPlazoCredito", EntidadCalculoPlazo1.IdTipoPlazoCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCalculoPlazo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCalculoPlazo1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCalculoPlazo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCalculoPlazo1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCalculoPlazo1.FechaActualizacion))
            If EntidadCalculoPlazo1.IdConfiguracionCalculo = 0 Then
                sqlcom1.Parameters(EntidadCalculoPlazo1.IdConfiguracionCalculo).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
        Catch ex As Exception
            EntidadCalculoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadCalculoPlazo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCalculoPlazo = EntidadCalculoPlazo1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
