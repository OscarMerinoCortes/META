Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Ciudad
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadCiudad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCiudad1 As New Entidad.Ciudad()
        EntidadCiudad1 = EntidadCiudad
        EntidadCiudad1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadCiudad1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisCiuDet", sqlcon1)
                    sqldat1.Fill(EntidadCiudad1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisCiuBas", sqlcon1)
                    sqldat1.Fill(EntidadCiudad1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_pld_LisMunCodPId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", EntidadCiudad1.IdMunCiudad))


                    'If EntidadCiudad1.IdMunCiudad = -1 Then
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdMunicipioIni", 0))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdMunicipioFin", 100000))
                    'Else
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdMunicipioIni", EntidadCiudad1.IdMunCiudad))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdMunicipioFin", EntidadCiudad1.IdMunCiudad))
                    'End If
                    'If EntidadCiudad1.IdEstadoCiudad = -1 Then
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", 0))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", 100000))
                    'Else
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", EntidadCiudad1.IdEstadoCiudad))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", EntidadCiudad1.IdEstadoCiudad))
                    'End If
                    sqldat1.Fill(EntidadCiudad1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_LisCiuFilEntFedMun", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", EntidadCiudad1.IdMunCiudad))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadCiudad1.IdEntFedCiudad))
                    sqldat1.Fill(EntidadCiudad1.TablaConsulta)
                    'por entidad federativa
            End Select
            EntidadCiudad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadCiudad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadCiudad1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCiudad = EntidadCiudad1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadCiudad As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCiudad1 As New Entidad.Ciudad()
        EntidadCiudad1 = EntidadCiudad
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCiuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCiudad", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadCiudad1.DescripcionCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INidPais", EntidadCiudad1.IdPaisCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadCiudad1.IdEntFedCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", EntidadCiudad1.IdMunCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadCiudad1.EquivalenciaCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCiudad1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCiudad1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCiudad1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCiudad1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCiudad1.IdEstadoCiudad))
            sqlcom1.Parameters("@INIdCiudad").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadCiudad1.IdCiudad = sqlcom1.Parameters("@INIdCiudad").Value
            EntidadCiudad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadCiudad1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCiudad1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadCiudad = EntidadCiudad1
        End Try
    End Sub

    Public Overridable Sub Actualizar(ByRef EntidadCiudad As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadCiudad1 As New Entidad.Ciudad()
        EntidadCiudad1 = EntidadCiudad
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCiuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCiudad", EntidadCiudad1.IdCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadCiudad1.DescripcionCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INidPais", EntidadCiudad1.IdPaisCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadCiudad1.IdEntFedCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", EntidadCiudad1.IdMunCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadCiudad1.EquivalenciaCiudad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCiudad1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCiudad1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCiudad1.IdEstadoCiudad))
            sqlcom1.ExecuteNonQuery()
            EntidadCiudad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadCiudad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadCiudad1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadCiudad = EntidadCiudad1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        'Dim EntidadPais1 As New Entidad.Pais()
        'EntidadPais1 = EntidadPais
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("pld_ExiPaiCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@IdPais", EntidadPais1.IdPais))
        '    sqlcom1.Parameters.Add(New SqlParameter("@CodigoUIF", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Gentilicio", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Equivalencia", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioCreacion", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate("01/01/1900")))
        '    sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioActualizacion", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate("01/01/1900")))
        '    sqlcom1.Parameters("@CodigoUIF").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Descripcion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Gentilicio").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Equivalencia").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@IdEstado").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@idUsuarioCreacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@FechaCreacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@idUsuarioActualizacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@FechaActualizacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@CodigoUIF").Size = 50
        '    sqlcom1.Parameters("@Descripcion").Size = 100
        '    sqlcom1.Parameters("@Gentilicio").Size = 100
        '    sqlcom1.Parameters("@Equivalencia").Size = 100
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadPais1.IdPais = sqlcom1.Parameters("@idPais").Value
        '    EntidadPais1.CodigoUIF = sqlcom1.Parameters("@CodigoUIF").Value
        '    ' EntidadPais1.idEsGafi = sqlcom1.Parameters("@idEsGafi").Value
        '    'EntidadPais1.idEsParaisoFiscal = sqlcom1.Parameters("@idEsParaisoFiscal").Value
        '    EntidadPais1.Descripcion = sqlcom1.Parameters("@Descripcion").Value
        '    EntidadPais1.Gentilicio = sqlcom1.Parameters("@Gentilicio").Value
        '    EntidadPais1.Equivalencia = sqlcom1.Parameters("@Equivalencia").Value
        '    EntidadPais1.IdEstado = sqlcom1.Parameters("@IdEstado").Value
        '    EntidadPais1.idUsuarioCreacion = sqlcom1.Parameters("@idUsuarioCreacion").Value
        '    EntidadPais1.FechaCreacion = sqlcom1.Parameters("@FechaCreacion").Value
        '    EntidadPais1.idUsuarioActualizacion = sqlcom1.Parameters("@idUsuarioActualizacion").Value
        '    EntidadPais1.FechaActualizacion = sqlcom1.Parameters("@FechaActualizacion").Value
        '    EntidadPais1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadPais1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadPais1.Tarjeta.Excepcion = ex.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadPais = EntidadPais1
        '    Bitacora.Insertar(EntidadPais1.Tarjeta)
        '    'End Try
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