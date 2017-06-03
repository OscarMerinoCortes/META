Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Persona
    Implements IPersona
    Public Sub Actualizar(ByRef EntidadPersona As Entidad.EntidadBase) Implements IPersona.Actualizar
        Dim EntidadPersona1 As New Entidad.Persona()
        EntidadPersona1 = EntidadPersona
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadPersona1.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", EntidadPersona1.RazonSocial))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadPersona1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadPersona1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadPersona1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadPersona1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", EntidadPersona1.FechaNacimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", EntidadPersona1.IdTipoGenero))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", EntidadPersona1.IdTipoEstadoCivil))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", EntidadPersona1.Observaciones))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaIdentificacion.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaIdentificacion") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerIde"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIdentificacion", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoIdentificacion", MiDataRow("IdTipoIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Numero", MiDataRow("ClaveIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@IdPersonaIdentificacion").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else

                        sqlcom1.CommandText = "ERP_ActPerIde"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIdentificacion", MiDataRow("IdPersonaIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoIdentificacion", MiDataRow("IdTipoIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Numero", MiDataRow("ClaveIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Conyugue=====================================================
            'insertar Conyugue
            For Each MiDataRow As DataRow In EntidadPersona1.TablaConyugue.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersona") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", MiDataRow("IdTipoPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", MiDataRow("Equivalencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", MiDataRow("RazonSocial")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", MiDataRow("PrimerNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", MiDataRow("SegundoNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", MiDataRow("ApellidoPaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", MiDataRow("ApellidoMaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", CDate(MiDataRow("FechaNacimiento"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", MiDataRow("IdTipoGenero")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", MiDataRow("IdTipoEstadoCivil")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", MiDataRow("Observaciones")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters(EntidadPersona1.IdConyugue).Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                        EntidadPersona1.IdConyugue = sqlcom1.Parameters(EntidadPersona1.IdConyugue).Value
                        If EntidadPersona1.IdConyugue <> 0 Then
                            sqlcom1 = New SqlCommand("ERP_InsPerConCod", sqlcon1)
                            sqlcom1.CommandType = CommandType.StoredProcedure
                            sqlcom1.Parameters.Clear()
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdConyugue", 0))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona1", EntidadPersona1.IdPersona))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona2", EntidadPersona1.IdConyugue))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadPersona1.idUsuarioCreacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadPersona1.FechaCreacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
                            sqlcom1.ExecuteNonQuery()
                        End If
                    Else
                        sqlcom1.CommandText = "ERP_ActPerCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", MiDataRow("IdPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", MiDataRow("IdTipoPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", MiDataRow("RazonSocial")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", MiDataRow("PrimerNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", MiDataRow("SegundoNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", MiDataRow("ApellidoPaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", MiDataRow("ApellidoMaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", CDate(MiDataRow("FechaNacimiento"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", MiDataRow("IdTipoGenero")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", MiDataRow("IdTipoEstadoCivil")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                        'EntidadPersona1.IdConyugue = sqlcom1.Parameters(EntidadPersona1.IdConyugue).Value
                        If EntidadPersona1.IdConyugue <> 0 Then
                            sqlcom1 = New SqlCommand("ERP_ActPerConCod", sqlcon1)
                            sqlcom1.CommandType = CommandType.StoredProcedure
                            sqlcom1.Parameters.Clear()
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdConyugue", MiDataRow("IdPersonaConyugue")))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona1", EntidadPersona1.IdPersona))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona2", MiDataRow("IdPersona")))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
                            sqlcom1.ExecuteNonQuery()
                        End If
                    End If
                End If
            Next
            '==========================================================Contacto=====================================================
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaContacto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaMedio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerMed"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaMedio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoMedio", MiDataRow("IdTipoMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@IdPersonaMedio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerMed"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaMedio", MiDataRow("IdPersonaMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoMedio", MiDataRow("IdTipoMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Domicilio=====================================================
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaDomicilio.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaDomicilio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerDomCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaDomicilio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", MiDataRow("IdTipoDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomPropietario", MiDataRow("Propietario")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomPais", MiDataRow("Pais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomEstado", MiDataRow("Estado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomMunicipio", MiDataRow("Municipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomLocalidad", MiDataRow("Localidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomColonia", MiDataRow("Colonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomCodigoPostal", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters("@INIdPersonaDomicilio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaDomicilio", MiDataRow("IdPersonaDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", MiDataRow("IdTipoDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomPropietario", MiDataRow("Propietario")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomPais", MiDataRow("Pais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomEstado", MiDataRow("Estado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomMunicipio", MiDataRow("Municipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomLocalidad", MiDataRow("Localidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomColonia", MiDataRow("Colonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomCodigoPostal", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Empleo=====================================================
            'insertar Empleo
            For Each MiDataRow As DataRow In EntidadPersona1.TablaEmpleo.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaEmpleo") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerEpmCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaEmpleo", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", MiDataRow("IdTipoEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacion", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresa", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters("@INIdPersonaEmpleo").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerEmp"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaEmpleo", MiDataRow("IdPersonaEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", MiDataRow("IdTipoEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacion", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresa", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Referencia=====================================================
            'insertar Referencia
            For Each MiDataRow As DataRow In EntidadPersona1.TablaReferencia.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaReferencia") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerRefCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaReferencia", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", MiDataRow("IdTipoReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNombreReferencia", MiDataRow("NombreReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacionReferencia", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresaReferencia", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedadReferencia", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilioReferencia", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefonoReferencia", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters("@INIdPersonaReferencia").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerRef"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaReferencia", MiDataRow("IdPersonaReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", MiDataRow("IdTipoReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNombreReferencia", MiDataRow("NombreReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacionReferencia", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresaReferencia", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedadReferencia", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilioReferencia", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefonoReferencia", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            ''==========================================================Linea credito=====================================================
            ''insertar Linea credito
            'For Each MiDataRow As DataRow In EntidadPersona1.TablaLineaCredito.Rows
            '    'si se va a actualizar el registro
            '    If MiDataRow("idActualizar") = 1 Then
            '        If MiDataRow("IdPersonaLineaCredito") = 0 Then
            '            sqlcom1.CommandText = "ERP_InsPerLinCod"
            '            sqlcom1.CommandType = CommandType.StoredProcedure
            '            sqlcom1.Parameters.Clear()
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", 0))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
            '            sqlcom1.Parameters("@INIdPersonaLineaCredito").Direction = ParameterDirection.InputOutput
            '            sqlcom1.ExecuteNonQuery()
            '        Else
            '            sqlcom1.CommandText = "ERP_ActPerLinCod"
            '            sqlcom1.CommandType = CommandType.StoredProcedure
            '            sqlcom1.Parameters.Clear()
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", MiDataRow("IdPersonaLineaCredito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
            '            sqlcom1.ExecuteNonQuery()
            '        End If
            '    End If
            'Next
            '==========================================================Limite de credito=====================================================
            'insertar Linea credito
            For Each MiDataRow As DataRow In EntidadPersona1.TablaLimiteCredito.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    'If MiDataRow("IdPersonaLineaCredito") = 0 Then
                    sqlcom1.CommandText = "ERP_InsActSalPer"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLimiteCredito", MiDataRow("IdPersona")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INSaldoLimite", MiDataRow("SaldoLimite")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INSaldoDisponible", MiDataRow("SaldoDisponible")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    sqlcom1.Parameters("@INIdPersonaLimiteCredito").Direction = ParameterDirection.InputOutput
                    sqlcom1.ExecuteNonQuery()
                    'Else
                    '    sqlcom1.CommandText = "ERP_ActPerLinCod"
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", MiDataRow("IdPersonaLineaCredito")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                    '    sqlcom1.ExecuteNonQuery()
                    'End If
                End If
            Next
            '==========================================================Indicador=====================================================
            'insertar Indicador
            For Each MiDataRow As DataRow In EntidadPersona1.TablaIndicador.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaIndicador") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerIndCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaIndicador", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", MiDataRow("IdTipoIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INMontoIndicador", MiDataRow("Monto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters("@INIdPersonaIndicador").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerIndCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaIndicador", MiDataRow("IdPersonaIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", MiDataRow("IdTipoIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INMontoIndicador", MiDataRow("Monto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            EntidadPersona1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPersona1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadPersona1
        End Try
    End Sub

    Public Sub VentaObtener(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim EntidadPersona1 = New Entidad.Persona()
        EntidadPersona1 = EntidadPersona
        EntidadPersona1.TablaConsulta = New DataTable()
        EntidadPersona1.TablaIdentificacion = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadPersona1.Tarjeta.Consulta
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_VenObtPerId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaPorDescripcion
                    sqlcom1 = New SqlCommand("ERP_VenObtPerDes", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadPersona1.PrimerNombre))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
            End Select
            EntidadPersona1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPersona1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadPersona1
        End Try
    End Sub

    Public Sub Consultar(ByRef EntidadPersona As Entidad.EntidadBase) Implements IPersona.Consultar
        Dim EntidadPersona1 = New Entidad.Persona()
        EntidadPersona1 = EntidadPersona
        EntidadPersona1.TablaConsulta = New DataTable()
        EntidadPersona1.TablaIdentificacion = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadPersona1.Tarjeta.Consulta
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConRegPerId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqldat1.Fill(EntidadPersona1.TablaIdentificacion)
                Case Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_ConRegPerDet", sqlcon1)
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    sqlcom1 = New SqlCommand("ERP_ConRegPerBas", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INBuscar", EntidadPersona1.Buscar))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaProveedor
                    sqldat1 = New SqlDataAdapter("ERP_ConRegPerProv", sqlcon1)
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaProveedorIdPer
                    sqlcom1 = New SqlCommand("ERP_ConRegPerProvId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaProveedorIdPro
                    sqlcom1 = New SqlCommand("ERP_ConRegPerProvIdPro", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadPersona1.IdPersona))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_ConPerBus", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona1.Equivalencia))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadPersona1.PrimerNombre))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_ConRegPerPorFil", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaCXP
                    sqldat1 = New SqlDataAdapter("ERP_ConRegPerBasCXP", sqlcon1)
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaPorNombreCompleto
                    sqlcom1 = New SqlCommand("ERP_BusCliPorNomWuc", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVNombreCliente", EntidadPersona1.NombreCompleto))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", EntidadPersona1.FechaNacimiento))
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
                Case Consulta.ConsultaBusqueda ' Se usa para el wuc de cliente
                    sqldat1 = New SqlDataAdapter("ERP_BusCliWuc", sqlcon1)
                    sqldat1.Fill(EntidadPersona1.TablaConsulta)
            End Select
            EntidadPersona1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPersona1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadPersona1
        End Try
    End Sub

    Public Sub ConsultarProveedor(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim EntidadPersona1 = New Entidad.Persona()
        EntidadPersona1 = EntidadPersona
        EntidadPersona1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConRegPerProId", sqlcon1)
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadPersona1.PrimerNombre))
            sqldat1.Fill(EntidadPersona1.TablaConsulta)
            EntidadPersona1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPersona1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadPersona1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadPersona As Entidad.EntidadBase) Implements IPersona.Insertar
        Dim EntidadPersona1 As New Entidad.Persona()
        EntidadPersona1 = EntidadPersona
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadPersona1.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", EntidadPersona1.RazonSocial))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadPersona1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadPersona1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadPersona1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadPersona1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", EntidadPersona1.FechaNacimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", EntidadPersona1.IdTipoGenero))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", EntidadPersona1.IdTipoEstadoCivil))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", EntidadPersona1.Observaciones))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadPersona1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadPersona1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
            sqlcom1.Parameters(EntidadPersona1.IdPersona).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadPersona1.IdPersona = sqlcom1.Parameters(EntidadPersona1.IdPersona).Value
            '==========================================================Identificacion=====================================================
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaIdentificacion.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaIdentificacion") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerIde"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIdentificacion", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoIdentificacion", MiDataRow("IdTipoIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Numero", MiDataRow("ClaveIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@IdPersonaIdentificacion").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerIde"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIdentificacion", MiDataRow("IdPersonaIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoIdentificacion", MiDataRow("IdTipoIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Numero", MiDataRow("ClaveIdentificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Conyugue=====================================================
            'insertar Conyugue
            For Each MiDataRow As DataRow In EntidadPersona1.TablaConyugue.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersona") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", MiDataRow("IdTipoPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", MiDataRow("Equivalencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", MiDataRow("RazonSocial")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", MiDataRow("PrimerNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", MiDataRow("SegundoNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", MiDataRow("ApellidoPaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", MiDataRow("ApellidoMaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", CDate(MiDataRow("FechaNacimiento"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", MiDataRow("IdTipoGenero")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", MiDataRow("IdTipoEstadoCivil")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", MiDataRow("Observaciones")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters(EntidadPersona1.IdConyugue).Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                        EntidadPersona1.IdConyugue = sqlcom1.Parameters(EntidadPersona1.IdConyugue).Value
                        If EntidadPersona1.IdConyugue <> 0 Then
                            sqlcom1 = New SqlCommand("ERP_InsPerConCod", sqlcon1)
                            sqlcom1.CommandType = CommandType.StoredProcedure
                            sqlcom1.Parameters.Clear()
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdConyugue", 0))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona1", EntidadPersona1.IdPersona))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona2", EntidadPersona1.IdConyugue))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadPersona1.idUsuarioCreacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadPersona1.FechaCreacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
                            sqlcom1.ExecuteNonQuery()
                        End If
                    Else
                        sqlcom1.CommandText = "ERP_ActPerCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", MiDataRow("IdPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", MiDataRow("IdTipoPersona")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", MiDataRow("RazonSocial")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", MiDataRow("PrimerNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", MiDataRow("SegundoNombre")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", MiDataRow("ApellidoPaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", MiDataRow("ApellidoMaterno")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaNacimiento", CDate(MiDataRow("FechaNacimiento"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", MiDataRow("IdTipoGenero")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEstadoCivil", MiDataRow("IdTipoEstadoCivil")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters(EntidadPersona1.IdConyugue).Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                        EntidadPersona1.IdConyugue = sqlcom1.Parameters(EntidadPersona1.IdConyugue).Value
                        If EntidadPersona1.IdConyugue <> 0 Then
                            sqlcom1 = New SqlCommand("ERP_ActPerConCod", sqlcon1)
                            sqlcom1.CommandType = CommandType.StoredProcedure
                            sqlcom1.Parameters.Clear()
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdConyugue", MiDataRow("IdPersonaConyugue")))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona1", EntidadPersona1.IdPersona))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona2", EntidadPersona1.IdConyugue))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona1.IdEstado))
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPersona1.idUsuarioActualizacion))
                            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPersona1.FechaActualizacion))
                            sqlcom1.ExecuteNonQuery()
                        End If
                    End If
                End If
            Next
            '==========================================================Contacto=====================================================
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaContacto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaMedio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerMed"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaMedio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoMedio", MiDataRow("IdTipoMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@IdPersonaMedio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerMed"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaMedio", MiDataRow("IdPersonaMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdTipoMedio", MiDataRow("IdTipoMedio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", MiDataRow("Descripcion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Domicilio=====================================================
            'insertar identificacion
            For Each MiDataRow As DataRow In EntidadPersona1.TablaDomicilio.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaDomicilio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerDomCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaDomicilio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", MiDataRow("IdTipoDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomPropietario", MiDataRow("Propietario")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomPais", MiDataRow("Pais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomEstado", MiDataRow("Estado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomMunicipio", MiDataRow("Municipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomLocalidad", MiDataRow("Localidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomColonia", MiDataRow("Colonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomCodigoPostal", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters("@INIdPersonaDomicilio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaDomicilio", MiDataRow("IdPersonaDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDomicilio", MiDataRow("IdTipoDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomPropietario", MiDataRow("Propietario")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomPais", MiDataRow("Pais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomEstado", MiDataRow("Estado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomMunicipio", MiDataRow("Municipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomLocalidad", MiDataRow("Localidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomColonia", MiDataRow("Colonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomNumExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDomCodigoPostal", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            '==========================================================Empleo=====================================================
            'insertar Empleo
            For Each MiDataRow As DataRow In EntidadPersona1.TablaEmpleo.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaEmpleo") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerEpmCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaEmpleo", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", MiDataRow("IdTipoEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacion", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresa", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters("@INIdPersonaEmpleo").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerEmp"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaEmpleo", MiDataRow("IdPersonaEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEmpleo", MiDataRow("IdTipoEmpleo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacion", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresa", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedad", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            '==========================================================Referencia=====================================================
            'insertar Referencia
            For Each MiDataRow As DataRow In EntidadPersona1.TablaReferencia.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaReferencia") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerRefCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaReferencia", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", MiDataRow("IdTipoReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNombreReferencia", MiDataRow("NombreReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacionReferencia", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresaReferencia", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedadReferencia", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilioReferencia", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefonoReferencia", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.Parameters("@INIdPersonaReferencia").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerRef"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaReferencia", MiDataRow("IdPersonaReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoReferencia", MiDataRow("IdTipoReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNombreReferencia", MiDataRow("NombreReferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVOcupacionReferencia", MiDataRow("Ocupacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVEmpresaReferencia", MiDataRow("Empresa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INAntiguedadReferencia", MiDataRow("Antiguedad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilioReferencia", MiDataRow("Domicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVTelefonoReferencia", MiDataRow("Telefono")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INTipoAntiguedad", MiDataRow("TipoAntiguedad")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            ''==========================================================Linea credito=====================================================
            ''insertar Empleo
            'For Each MiDataRow As DataRow In EntidadPersona1.TablaLineaCredito.Rows
            '    'si se va a actualizar el registro
            '    If MiDataRow("idActualizar") = 1 Then
            '        If MiDataRow("IdPersonaLineaCredito") = 0 Then
            '            sqlcom1.CommandText = "ERP_InsPerLinCod"
            '            sqlcom1.CommandType = CommandType.StoredProcedure
            '            sqlcom1.Parameters.Clear()
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", 0))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
            '            sqlcom1.Parameters("@INIdPersonaLineaCredito").Direction = ParameterDirection.InputOutput
            '            sqlcom1.ExecuteNonQuery()
            '        Else
            '            sqlcom1.CommandText = "ERP_ActPerLinCod"
            '            sqlcom1.CommandType = CommandType.StoredProcedure
            '            sqlcom1.Parameters.Clear()
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", MiDataRow("IdPersonaLineaCredito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
            '            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
            '            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
            '            sqlcom1.ExecuteNonQuery()
            '        End If
            '    End If
            'Next
            '==========================================================Limite de credito=====================================================
            'insertar Linea credito
            For Each MiDataRow As DataRow In EntidadPersona1.TablaLimiteCredito.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    ' If MiDataRow("IdPersona") = 0 Then
                    sqlcom1.CommandText = "ERP_InsActSalPer"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLimiteCredito", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INSaldoLimite", MiDataRow("SaldoLimite")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INSaldoDisponible", MiDataRow("SaldoDisponible")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdPersonaLimiteCredito").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    ' Else

                    '    sqlcom1.CommandText = "ERP_ActPerLinCod"
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaLineaCredito", MiDataRow("IdPersonaLineaCredito")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", CDate(MiDataRow("Fecha"))))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IVCredito", MiDataRow("Credito")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                    '    sqlcom1.ExecuteNonQuery()
                    'End If
                End If
            Next
            '==========================================================Indicador=====================================================
            'insertar Indicador
            For Each MiDataRow As DataRow In EntidadPersona1.TablaIndicador.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdPersonaIndicador") = 0 Then
                        sqlcom1.CommandText = "ERP_InsPerIndCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaIndicador", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", MiDataRow("IdTipoIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INMontoIndicador", MiDataRow("Monto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.Parameters("@INIdPersonaIndicador").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActPerIndCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaIndicador", MiDataRow("IdPersonaIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona1.IdPersona))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIndicador", MiDataRow("IdTipoIndicador")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INMontoIndicador", MiDataRow("Monto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("idEstado")))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            EntidadPersona1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPersona1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPersona1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadPersona1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadPersona As Entidad.Persona) Implements IPersona.Obtener
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPersona.TablaConyugue = New DataTable()
        EntidadPersona.TablaIdentificacion = New DataTable()
        EntidadPersona.TablaContacto = New DataTable()
        EntidadPersona.TablaDomicilio = New DataTable()
        EntidadPersona.TablaEmpleo = New DataTable()
        EntidadPersona.TablaReferencia = New DataTable()
        EntidadPersona.TablaLineaCredito = New DataTable()
        EntidadPersona.TablaLimiteCredito = New DataTable()
        EntidadPersona.TablaIndicador = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona.IdPersona))
            sqldat1.Fill(EntidadPersona.TablaIdentificacion)
            'Tabla Conyugue
            sqlcom1.CommandText = "ERP_LisPerConCod"
            sqldat1.Fill(EntidadPersona.TablaConyugue)
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_LisPerMedCod"
            sqldat1.Fill(EntidadPersona.TablaContacto)
            'Tabla Domicilio
            sqlcom1.CommandText = "ERP_LisPerDomCod"
            sqldat1.Fill(EntidadPersona.TablaDomicilio)
            'Tabla Empleo
            sqlcom1.CommandText = "ERP_LisPerEmpCod"
            sqldat1.Fill(EntidadPersona.TablaEmpleo)
            'TablaReferencia
            sqlcom1.CommandText = "ERP_LisPerRefCod"
            sqldat1.Fill(EntidadPersona.TablaReferencia)
            ''Tabla Linea Credito
            'sqlcom1.CommandText = "ERP_LisPerLinCreCod"
            'sqldat1.Fill(EntidadPersona.TablaLineaCredito)
            'Tabla Limite Credito
            sqlcom1.CommandText = "ERP_LisPerLimCreCod"
            sqldat1.Fill(EntidadPersona.TablaLimiteCredito)
            'Tabla Indicador
            sqlcom1.CommandText = "ERP_LisPerIndCod"
            sqldat1.Fill(EntidadPersona.TablaIndicador)
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ObtenerTablas(ByRef EntidadPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPersona.TablaIdentificacion = New DataTable()
        EntidadPersona.TablaContacto = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona.IdPersona))
            sqldat1.Fill(EntidadPersona.TablaIdentificacion)
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_LisPerMedCod"
            sqldat1.Fill(EntidadPersona.TablaContacto)
            'Tabla Domicilio
            sqlcom1.CommandText = "ERP_LisPerDomCod"
            sqldat1.Fill(EntidadPersona.TablaDomicilio)
            EntidadPersona.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPersona.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ReportePersona(ByRef EntidadReportePersona As Entidad.ReportePersona)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReportePersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisRepPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadReportePersona.IdTipoPersona = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaIni", EntidadReportePersona.IdTipoPersona))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaFin", EntidadReportePersona.IdTipoPersona))
            End If
            If EntidadReportePersona.IdGenero = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", EntidadReportePersona.IdGenero))
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", EntidadReportePersona.IdGenero))
            End If
            If EntidadReportePersona.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadReportePersona.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadReportePersona.IdEstado))
            End If
            sqldat1.Fill(EntidadReportePersona.TablaConsulta)
            EntidadReportePersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReportePersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReportePersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub PerfilPersona(ByRef EntidadPerfilPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPerfilPersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisPerfPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqldat1.Fill(EntidadPerfilPersona.TablaConsulta)
            EntidadPerfilPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPerfilPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPerfilPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_ConPerFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadPersona.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadPersona.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadPersona.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", EntidadPersona.IdTipoGenero))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadPersona.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona.IdEstado))
            sqldat1.Fill(EntidadPersona.TablaConsulta)
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
