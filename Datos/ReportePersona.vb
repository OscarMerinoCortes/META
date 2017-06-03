Imports System.Threading
Imports System.Data.SqlClient
Public Class ReportePersona
    Implements IPersonas



    'Public Overridable Sub Actualizar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Actualizar
    '    Dim EntidadTipoDomicilio1 As New Entidad.TipoDomicilio()
    '    EntidadTipoDomicilio1 = EntidadTipoDomicilio
    '    Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
    '    Dim sqlcom1 As SqlCommand
    '    Try
    '        sqlcon1.Open()
    '        sqlcom1 = New SqlCommand("ERP_ActTipDomCod", sqlcon1)
    '        sqlcom1.CommandType = CommandType.StoredProcedure
    '        sqlcom1.Parameters.Clear()
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(0).Nombre), EntidadTipoDomicilio1.Campo(0).Valor))
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(1).Nombre), EntidadTipoDomicilio1.Campo(1).Valor))
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(2).Nombre), EntidadTipoDomicilio1.Campo(2).Valor))
    '        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDomicilio1.idUsuarioActualizacion))
    '        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDomicilio1.FechaActualizacion))
    '        sqlcom1.ExecuteNonQuery()
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
    '    Catch ex As Exception
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
    '        EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
    '    Finally
    '        sqlcon1.Close()
    '        EntidadTipoDomicilio = EntidadTipoDomicilio1
    '    End Try
    'End Sub

    'Public Overridable Sub Consultar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Consultar
    '    Dim EntidadTipoDomicilio1 = New Entidad.TipoDomicilio()
    '    EntidadTipoDomicilio1 = EntidadTipoDomicilio
    '    EntidadTipoDomicilio1.TablaConsulta = New DataTable()
    '    Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
    '    Try
    '        sqlcon1.Open()
    '        Select Case EntidadTipoDomicilio1.Tarjeta.Consulta
    '            Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
    '                Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDomCod", sqlcon1)
    '                sqldat1.Fill(EntidadTipoDomicilio1.TablaConsulta)
    '            Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
    '                Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDomEst", sqlcon1)
    '                sqldat1.Fill(EntidadTipoDomicilio1.TablaConsulta)
    '            Case Else
    '        End Select
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
    '    Catch ex As Exception
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
    '        EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
    '    Finally
    '        sqlcon1.Close()
    '        EntidadTipoDomicilio = EntidadTipoDomicilio1
    '    End Try
    'End Sub

    'Public Overridable Sub Insertar(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Insertar
    '    Dim EntidadTipoDomicilio1 As New Entidad.TipoDomicilio()
    '    EntidadTipoDomicilio1 = EntidadTipoDomicilio
    '    Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
    '    Dim sqlcom1 As SqlCommand
    '    Try
    '        sqlcon1.Open()
    '        sqlcom1 = New SqlCommand("ERP_InsTipDomCod", sqlcon1)
    '        sqlcom1.CommandType = CommandType.StoredProcedure
    '        sqlcom1.Parameters.Clear()
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(0).Nombre), 0))
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(1).Nombre), EntidadTipoDomicilio1.Campo(1).Valor))
    '        sqlcom1.Parameters.Add(New SqlParameter(CStr(EntidadTipoDomicilio1.Campo(2).Nombre), EntidadTipoDomicilio1.Campo(2).Valor))
    '        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoDomicilio1.idUsuarioCreacion))
    '        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoDomicilio1.FechaCreacion))
    '        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDomicilio1.idUsuarioActualizacion))
    '        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDomicilio1.FechaActualizacion))
    '        sqlcom1.Parameters(EntidadTipoDomicilio1.Campo(0).Nombre).Direction = ParameterDirection.InputOutput
    '        sqlcom1.ExecuteNonQuery()
    '        EntidadTipoDomicilio1.Campo(0).Valor = sqlcom1.Parameters(EntidadTipoDomicilio1.Campo(0).Nombre).Value
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
    '    Catch ex As Exception
    '        EntidadTipoDomicilio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
    '        EntidadTipoDomicilio1.Tarjeta.Excepcion = ex.Message.ToString()
    '    Finally
    '        sqlcon1.Close()
    '        EntidadTipoDomicilio = EntidadTipoDomicilio1
    '    End Try

    'End Sub

    'Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    'End Sub


    Public Sub Actualizar(ByRef EntidadTipoDomicilio As Entidad.Persona) Implements IPersonas.Actualizar

    End Sub

    Public Function Consultar(ByRef EntidadBase As Entidad.Persona) As DataTable Implements IPersonas.Consultar

    End Function

    Public Function Insertar(ByRef EntidadBase As Entidad.Persona) As Integer Implements IPersonas.Insertar

    End Function

    Public Function Obtener(ByRef EntidadBase As Entidad.Persona) As DataTable Implements IPersonas.Obtener

    End Function

    Public Function ObtenerTablas(ByRef EntidadBase As Entidad.Persona) As DataTable Implements IPersonas.ObtenerTablas

    End Function

    Public Function ReportePersona(ByRef EntidadBase As Entidad.Persona) As DataTable Implements IPersonas.ReportePersona

    End Function
End Class
