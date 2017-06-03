Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Imports System.Math
Public Class Obsequio
    Implements ICatalogo
    Public Overridable Sub Actualizar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Actualizar
    End Sub
    Public Overridable Sub Consultar(ByRef EntidadObsequio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadObsequio1 = New Entidad.Obsequio()
        EntidadObsequio1 = EntidadObsequio
        EntidadObsequio1.TablaConsulta = New DataTable()

        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadObsequio1.Tarjeta.Consulta

                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPromocionDescuento", sqlcon1)
                    sqldat1.Fill(EntidadObsequio1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_Con_Promocion_Obsequio", sqlcon1)
                    sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                Case Consulta.Ninguno 'Consulta para sacar los productos por almacen 
                    sqlcom1 = New SqlCommand("ERP_LisPromocionPro", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadObsequio1.IdClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadObsequio1.IdSubClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadObsequio1.Sucursal))
                    sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    If EntidadObsequio1.IndicadorConsulta = 0 Then
                        sqlcom1 = New SqlCommand("ERP_Con_PromObsDetCod", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                        sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                    End If
                    If EntidadObsequio1.IndicadorConsulta = 1 Then
                        sqlcom1 = New SqlCommand("ERP_Con_ProObsDetCanCod", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                        sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                    End If
                    If EntidadObsequio1.IndicadorConsulta = 2 Then
                        sqlcom1 = New SqlCommand("ERP_Con_PromObsPro", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                        sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                    End If
                    'If EntidadObsequio1.IndicadorConsulta = 3 Then
                    '    sqlcom1 = New SqlCommand("ERP_Con_PromAlm", sqlcon1)
                    '    sqldat1 = New SqlDataAdapter(sqlcom1)
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                    '    sqldat1.Fill(EntidadObsequio1.TablaConsulta)
                    'End If
            End Select
            EntidadObsequio1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadObsequio1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadObsequio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadObsequio1 = EntidadObsequio1
        End Try
    End Sub
    Public Overridable Sub InsertarActualizar(ByRef EntidadObsequio As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadObsequio1 As New Entidad.Obsequio()
        EntidadObsequio1 = EntidadObsequio
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            '''''''MiDataRow("IdPromocionDetalle") = IdGenerado.ToString()
            '''''''TablaPromocionObsequioDetalleCantidad 

            '''''''For Each MiDataRow2 As DataRow In EntidadObsequio1.TablaObsequioDetalleCantidad.Rows
            '''''''    sqlcom1.CommandText = "ERP_InsActPromObsDetCantCod"
            '''''''    sqlcom1.CommandType = CommandType.StoredProcedure
            '''''''    sqlcom1.Parameters.Clear()
            '''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalleCantidad", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
            '''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
            '''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
            '''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
            '''''''    If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
            '''''''        sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Direction = ParameterDirection.InputOutput
            '''''''    End If
            '''''''    sqlcom1.ExecuteNonQuery()
            '''''''    Dim IdPromocionObsequioDetalle2 As Integer = sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Value
            '''''''Next






            'For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionDetalleObsequio.Rows
            '    sqlcom1.CommandText = "ERP_InsActPromDetObsCod"
            '    sqlcom1.CommandType = CommandType.StoredProcedure
            '    sqlcom1.Parameters.Clear()
            '    sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoObsequio", CInt(MiDataRow("IdPromocionDetalle"))))
            '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
            '    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
            '    sqlcom1.Parameters.Add(New SqlParameter("@INPrecioBase", CDbl(MiDataRow("PrecioBase"))))
            '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(IIf(MiDataRow("Estado") = "ACTIVO", 1, 2))))
            '    If MiDataRow("IdPromocionDetalle") = 0 Then
            '        sqlcom1.Parameters("@INIdProductoObsequio").Direction = ParameterDirection.InputOutput
            '    End If
            '    sqlcom1.ExecuteNonQuery()
            '    Dim IdGenerado As Integer = sqlcom1.Parameters("@INIdProductoObsequio").Value
            '    MiDataRow("IdPromocionDetalle") = IdGenerado.ToString()
            'Next
            If EntidadObsequio1.IndicadorEstado = 1 Then 'Áctualizar
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_InsActPromObsCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadObsequio1.Descripcion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadObsequio1.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@MontoPorcentaje", EntidadObsequio1.MontoPorcentaje))
                sqlcom1.Parameters.Add(New SqlParameter("@TipoMontoPorcentaje", EntidadObsequio1.TipoMontoPorcentaje))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadObsequio1.FechaInicio))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadObsequio1.FechaFin))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadObsequio1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadObsequio1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadObsequio1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadObsequio1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadObsequio1.FechaActualizacion))
                If EntidadObsequio1.IdPromocion = 0 Then
                    sqlcom1.Parameters(EntidadObsequio1.IdPromocion).Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()
                EntidadObsequio1.IdPromocion = IIf(EntidadObsequio1.IdPromocion = 0, sqlcom1.Parameters(EntidadObsequio1.IdPromocion).Value, EntidadObsequio1.IdPromocion)

                For Each MiDataRow As DataRow In EntidadObsequio1.TablaRegistro.Rows   'ES PARA ACTUALIZAR LOS REGISTROS YA INSERTADOS    
                    Dim IdPromocionObsequioDetalle As Integer
                    sqlcom1.CommandText = "ERP_InsActPromObsDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                    If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                        sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Direction = ParameterDirection.InputOutput
                    End If
                    sqlcom1.ExecuteNonQuery()
                    IdPromocionObsequioDetalle = sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Value
                Next
                For Each MiDataRow As DataRow In EntidadObsequio1.TablaRegistro.Rows   'ES PARA ACTUALIZAR LOS REGISTROS YA INSERTADOS    
                    sqlcom1.CommandText = "ERP_InsActPromObsDetCantCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalleCantidad", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", CInt(MiDataRow("IdSucursal"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("Cantidad"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                    sqlcom1.ExecuteNonQuery()
                Next
                For Each MiDataRow As DataRow In EntidadObsequio1.TablaRegistroObsequio.Rows   'ES PARA ACTUALIZAR LOS REGISTROS YA INSERTADOS    
                    sqlcom1.CommandText = "ERP_ActPromObsProdCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow("IdPromocionObsequioProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("Cantidad"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                    'If MiDataRow("IdPromocionObsequioProducto") = 0 Then
                    '    sqlcom1.Parameters("@INIdPromocionObsequioProducto").Direction = ParameterDirection.InputOutput
                    'End If
                    sqlcom1.ExecuteNonQuery()
                Next

                For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionObsequioDetalle.Rows
                    If CInt(MiDataRow("IdPromocionObsequioDetalle")) <> 0 Then
                        Dim IdPromocionObsequioDetalle As Integer
                        sqlcom1.CommandText = "ERP_InsActPromObsDetCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                        If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                            sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Direction = ParameterDirection.InputOutput
                        End If
                        sqlcom1.ExecuteNonQuery()
                        IdPromocionObsequioDetalle = sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Value

                        sqlcom1.CommandText = "ERP_InsActPromObsDetCantCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalleCantidad", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", CInt(MiDataRow("IdSucursal"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("Cantidad"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                        'If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                        '    sqlcom1.Parameters("@INIdPromocionObsequioDetalleCantidad").Direction = ParameterDirection.InputOutput
                        'End If
                        sqlcom1.ExecuteNonQuery()
                    Else
                        Dim IdPromocionObsequioDetalle As Integer
                        sqlcom1.CommandText = "ERP_InsActPromObsDetCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                        If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                            sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Direction = ParameterDirection.InputOutput
                        End If
                        sqlcom1.ExecuteNonQuery()
                        IdPromocionObsequioDetalle = sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Value

                        sqlcom1.CommandText = "ERP_InsActPromObsDetCantCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalleCantidad", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", CInt(MiDataRow("IdSucursal"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("Cantidad"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                        'If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                        '    sqlcom1.Parameters("@INIdPromocionObsequioDetalleCantidad").Direction = ParameterDirection.InputOutput
                        'End If
                        sqlcom1.ExecuteNonQuery()

                        ''''''For Each MiDataRow3 As DataRow In EntidadObsequio1.TablaPromocionObsequioProducto.Rows
                        ''''''    If CInt(MiDataRow3("IdPromocionObsequioProducto")) = -1 Then
                        ''''''        sqlcom1.CommandText = "ERP_ActPromObsProdCod"
                        ''''''        sqlcom1.CommandType = CommandType.StoredProcedure
                        ''''''        sqlcom1.Parameters.Clear()
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow3("IdPromocionObsequioProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow3("IdPromocionObsequioDetalle"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow3("IdProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow3("Cantidad"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow3("IdEstado"))))
                        ''''''        sqlcom1.ExecuteNonQuery()

                        ''''''        sqlcom1.CommandText = "ERP_InsActPromObsProdCod"
                        ''''''        sqlcom1.CommandType = CommandType.StoredProcedure
                        ''''''        sqlcom1.Parameters.Clear()
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow3("IdPromocionObsequioProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow3("IdProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow3("Cantidad"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow3("IdEstado"))))
                        ''''''        'If MiDataRow3("IdPromocionObsequioProducto") = 0 Then
                        ''''''        '    sqlcom1.Parameters("@INIdPromocionObsequioProducto").Direction = ParameterDirection.InputOutput
                        ''''''        'End If
                        ''''''        sqlcom1.ExecuteNonQuery()
                        ''''''        Dim IdPromocionObsequioProducto As Integer = sqlcom1.Parameters("@INIdPromocionObsequioProducto").Value

                        ''''''    Else
                        ''''''        sqlcom1.CommandText = "ERP_InsActPromObsProdCod"
                        ''''''        sqlcom1.CommandType = CommandType.StoredProcedure
                        ''''''        sqlcom1.Parameters.Clear()
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow3("IdPromocionObsequioProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow3("IdProducto"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow3("Cantidad"))))
                        ''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow3("IdEstado"))))
                        ''''''        sqlcom1.ExecuteNonQuery()
                        ''''''        Dim IdPromocionObsequioProducto As Integer = sqlcom1.Parameters("@INIdPromocionObsequioProducto").Value


                        ''''''    End If
                        ''''''Next

                    End If
                Next
                For Each MiDataRow As DataRow In EntidadObsequio1.TablaProductoObsequio1.Rows   'ES PARA ACTUALIZAR LOS REGISTROS YA INSERTADOS    
                    sqlcom1.CommandText = "ERP_InsActPromoObsProdCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow("IdPromocionObsequioProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProductoObsequio"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto2", CInt(MiDataRow("IdProductoEncabezado"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("CantidadObsequio"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 1))
                    'If MiDataRow("IdPromocionObsequioProducto") = 0 Then
                    '    sqlcom1.Parameters("@INIdPromocionObsequioProducto").Direction = ParameterDirection.InputOutput
                    'End If
                    sqlcom1.ExecuteNonQuery()
                Next





                '''''''''''Dim sqldat1 As SqlDataAdapter
                '''''''''''sqlcom1 = New SqlCommand("ERP_Del_PromAlmCod", sqlcon1)
                '''''''''''sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''sqlcom1.Parameters.Clear()
                '''''''''''sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                '''''''''''sqlcom1.ExecuteNonQuery()

                '''''''''''For Each MiDataRow As DataRow In EntidadObsequio1.TablaSucursal.Rows
                '''''''''''    sqlcom1.CommandText = "ERP_InsActPromAlmCod"
                '''''''''''    sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''    sqlcom1.Parameters.Clear()
                '''''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionSucursal", 0))
                '''''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                '''''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                '''''''''''    sqlcom1.ExecuteNonQuery()
                '''''''''''Next

                ''''''''''''sqlcon1.Open()
                '''''''''''sqlcom1 = New SqlCommand("ERP_Del_ProdObsCod", sqlcon1)
                '''''''''''sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''sqlcom1.Parameters.Clear()
                '''''''''''sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                '''''''''''sqlcom1.ExecuteNonQuery()
                ''''''''''''----
                '''''''''''sqlcom1 = New SqlCommand("ERP_Con_PromDetEnc", sqlcon1)
                '''''''''''sqldat1 = New SqlDataAdapter(sqlcom1)
                '''''''''''sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''sqlcom1.Parameters.Clear()
                '''''''''''sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                '''''''''''EntidadObsequio1.TablaPromocionDetalle.Rows.Clear()
                '''''''''''sqldat1.Fill(EntidadObsequio1.TablaPromocionDetalle)
                ''''''''''''------
                '''''''''''sqlcom1 = New SqlCommand("ERP_Con_PromDetObs", sqlcon1)
                '''''''''''sqldat1 = New SqlDataAdapter(sqlcom1)
                '''''''''''sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''sqlcom1.Parameters.Clear()
                '''''''''''sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                '''''''''''EntidadObsequio1.TablaPromocionDetalleObsequio.Rows.Clear()
                '''''''''''sqldat1.Fill(EntidadObsequio1.TablaPromocionDetalleObsequio)
                ''''''''''''------
                ''''''''''''If EntidadObsequio1.TipoMontoPorcentaje = 3 Then
                ''''''''''''    For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionDetalle.Rows
                ''''''''''''        For Each MiDataRow2 As DataRow In EntidadObsequio1.TablaPromocionDetalleObsequio.Rows
                ''''''''''''            sqlcom1.CommandText = "ERP_InsActProdObsCod"
                ''''''''''''            sqlcom1.CommandType = CommandType.StoredProcedure
                ''''''''''''            sqlcom1.Parameters.Clear()
                ''''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalleObsequio", 0))
                ''''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEncabezado", CInt(MiDataRow("IdPromocionDetalle"))))
                ''''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoObsequio", CInt(MiDataRow2("IdPromocionDetalle"))))
                ''''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                ''''''''''''            Dim PrecioAjustado As Double = CDbl(MiDataRow("PrecioBase"))
                ''''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioAjustado", IIf(EntidadObsequio1.AplicarRedondeo = 2, Round(PrecioAjustado), PrecioAjustado)))
                ''''''''''''            sqlcom1.ExecuteNonQuery()
                ''''''''''''        Next
                ''''''''''''    Next
                ''''''''''''Else
                '''''''''''''''''''  Aqui cambiar
                '''''''''''If EntidadObsequio1.TipoMontoPorcentaje = 2 Then
                '''''''''''    For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionDetalle.Rows
                '''''''''''        For Each MiDataRow2 As DataRow In EntidadObsequio1.TablaPromocionDetalleObsequio.Rows
                '''''''''''            sqlcom1.CommandText = "ERP_InsActProdObsCod"
                '''''''''''            sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''''            sqlcom1.Parameters.Clear()
                '''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalleObsequio", 0))
                '''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEncabezado", CInt(MiDataRow("IdPromocionDetalle"))))
                '''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoObsequio", CInt(MiDataRow2("IdPromocionDetalle"))))
                '''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                '''''''''''            Dim PrecioAjustado As Double = CDbl(MiDataRow("PrecioBase")) + CDbl(MiDataRow2("PrecioBase"))
                '''''''''''            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioAjustado", IIf(EntidadObsequio1.AplicarRedondeo = 2, Round(PrecioAjustado), PrecioAjustado)))
                '''''''''''            sqlcom1.ExecuteNonQuery()
                '''''''''''        Next
                '''''''''''    Next
                ''''''Else
                ''''''        For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionDetalle.Rows
                ''''''            For Each MiDataRow2 As DataRow In EntidadObsequio1.TablaPromocionDetalleObsequio.Rows
                ''''''                sqlcom1.CommandText = "ERP_InsActProdObsCod"
                ''''''                sqlcom1.CommandType = CommandType.StoredProcedure
                ''''''                sqlcom1.Parameters.Clear()
                ''''''                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalleObsequio", 0))
                ''''''                sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEncabezado", CInt(MiDataRow("IdPromocionDetalle"))))
                ''''''                sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoObsequio", CInt(MiDataRow2("IdPromocionDetalle"))))
                ''''''                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                ''''''                Dim PrecioAjustado As Double = CDbl(MiDataRow("PrecioBase")) + IIf(EntidadObsequio1.TipoMontoPorcentaje = 1, EntidadObsequio1.MontoPorcentaje, EntidadObsequio1.MontoPorcentaje / 100 * CDbl(MiDataRow("PrecioBase")))
                ''''''                sqlcom1.Parameters.Add(New SqlParameter("@INPrecioAjustado", IIf(EntidadObsequio1.AplicarRedondeo = 2, Round(PrecioAjustado), PrecioAjustado)))
                ''''''                sqlcom1.ExecuteNonQuery()
                ''''''            Next
                ''''''        Next
                ''''''    End If
                'End If
            Else
                '''''''''For Each MiDataRow As DataRow In EntidadObsequio1.TablaSucursal.Rows
                '''''''''    sqlcom1.CommandText = "ERP_InsActPromAlmCod"
                '''''''''    sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''    sqlcom1.Parameters.Clear()
                '''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionSucursal", 0))
                '''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                '''''''''    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                '''''''''    sqlcom1.ExecuteNonQuery()
                '''''''''Next

                '''''''''For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionDetalle.Rows
                '''''''''    For Each MiDataRow2 As DataRow In EntidadObsequio1.TablaPromocionDetalleObsequio.Rows
                '''''''''        sqlcom1.CommandText = "ERP_InsActProdObsCod"
                '''''''''        sqlcom1.CommandType = CommandType.StoredProcedure
                '''''''''        sqlcom1.Parameters.Clear()
                '''''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalleObsequio", 0))
                '''''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEncabezado", CInt(MiDataRow("IdPromocionDetalle"))))
                '''''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoObsequio", CInt(MiDataRow2("IdPromocionDetalle"))))
                '''''''''        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                '''''''''        Dim PrecioAjustado = CDbl(MiDataRow("PrecioBase")) + CDbl(MiDataRow2("PrecioBase"))
                '''''''''        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioAjustado", IIf(EntidadObsequio1.AplicarRedondeo = 2, Round(PrecioAjustado), PrecioAjustado)))
                '''''''''        sqlcom1.ExecuteNonQuery()
                '''''''''    Next
                '''''''''Next
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_InsActPromObsCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", EntidadObsequio1.IdPromocion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadObsequio1.Descripcion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadObsequio1.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@MontoPorcentaje", EntidadObsequio1.MontoPorcentaje))
                sqlcom1.Parameters.Add(New SqlParameter("@TipoMontoPorcentaje", EntidadObsequio1.TipoMontoPorcentaje))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadObsequio1.FechaInicio))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadObsequio1.FechaFin))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadObsequio1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadObsequio1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadObsequio1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadObsequio1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadObsequio1.FechaActualizacion))
                If EntidadObsequio1.IdPromocion = 0 Then
                    sqlcom1.Parameters(EntidadObsequio1.IdPromocion).Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()
                EntidadObsequio1.IdPromocion = IIf(EntidadObsequio1.IdPromocion = 0, sqlcom1.Parameters(EntidadObsequio1.IdPromocion).Value, EntidadObsequio1.IdPromocion)


                For Each MiDataRow As DataRow In EntidadObsequio1.TablaPromocionObsequioDetalle.Rows
                    Dim IdPromocionObsequioDetalle As Integer
                    sqlcom1.CommandText = "ERP_InsActPromObsDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", CInt(EntidadObsequio1.IdPromocion)))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                    If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                        sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Direction = ParameterDirection.InputOutput
                    End If
                    sqlcom1.ExecuteNonQuery()
                    IdPromocionObsequioDetalle = sqlcom1.Parameters("@INIdPromocionObsequioDetalle").Value

                    sqlcom1.CommandText = "ERP_InsActPromObsDetCantCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalleCantidad", CInt(MiDataRow("IdPromocionObsequioDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", CInt(MiDataRow("IdSucursal"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow("Cantidad"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow("IdEstado"))))
                    'If MiDataRow("IdPromocionObsequioDetalle") = 0 Then
                    '    sqlcom1.Parameters("@INIdPromocionObsequioDetalleCantidad").Direction = ParameterDirection.InputOutput
                    'End If
                    sqlcom1.ExecuteNonQuery()

                    For Each MiDataRow3 As DataRow In EntidadObsequio1.TablaPromocionObsequioProducto.Rows
                        sqlcom1.CommandText = "ERP_InsActPromObsProdCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioProducto", CInt(MiDataRow3("IdPromocionObsequioProducto"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequioDetalle", IdPromocionObsequioDetalle))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow3("IdProducto"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", CInt(MiDataRow3("Cantidad"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(MiDataRow3("IdEstado"))))
                        If MiDataRow3("IdPromocionObsequioProducto") = 0 Then
                            sqlcom1.Parameters("@INIdPromocionObsequioProducto").Direction = ParameterDirection.InputOutput
                        End If
                        sqlcom1.ExecuteNonQuery()
                        Dim IdPromocionObsequioProducto As Integer = sqlcom1.Parameters("@INIdPromocionObsequioProducto").Value
                    Next
                Next
            End If

            EntidadObsequio1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadObsequio1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadObsequio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadObsequio = EntidadObsequio1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class