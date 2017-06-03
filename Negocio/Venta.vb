Imports Entidad

Public Class Venta
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosVenta As New Datos.Venta()
        DatosVenta.Consultar(EntidadVenta)
    End Sub

    Public Sub Guardar(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadVenta1 As New Entidad.Venta()
        Dim DatosVenta As New Datos.Venta()
        EntidadVenta1 = EntidadVenta
        If EntidadVenta1.Id = 0 Then
            DatosVenta.Insertar(EntidadVenta1)
        Else
            DatosVenta.Actualizar(EntidadVenta1)
        End If
    End Sub

    Public Sub Obtener(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosVenta As New Datos.Venta()
        DatosVenta.Obtener(EntidadVenta)
    End Sub
    'Public Sub ReporteVenta(ByRef EntidadReporteVenta As Entidad.ReporteVenta)
    '    Dim DatosReporteVenta As New Datos.Venta()
    '    DatosReporteVenta.ReporteVenta(EntidadReporteVenta)
    'End Sub
    Public Sub PerfilVenta(ByRef EntidadPerfilVenta As Entidad.EntidadBase)

    End Sub

    Public Sub VentaObtener(EntidadVenta As Entidad.EntidadBase)
        Dim DatosVenta As New Datos.Venta()
        DatosVenta.VentaObtener(EntidadVenta)
    End Sub

    Public Sub ObtenerObsequio(ByRef entidadProducto As EntidadBase)
        Dim DatosVenta As New Datos.Venta()
        DatosVenta.ObtenerObsequio(entidadProducto)
    End Sub

    Public Sub ProcesarImprimir(ByRef entidadVenta As Entidad.Venta, ByRef cadena As String, empresa As Integer)
        If empresa = 1 Then
        ElseIf empresa = 2 Then 'lalos
            Try
                cadena = cadena.Replace("[Cliente.ID]", entidadVenta.IdPersona)
                cadena = cadena.Replace("[Venta.FolioFisico]", entidadVenta.FolioFisico)
                cadena = cadena.Replace("[Cliente.NombreCompleto]", entidadVenta.Persona)
                cadena = cadena.Replace("[Cliente.Domicilio]", entidadVenta.DomicilioEntrega)
                cadena = cadena.Replace("[Sistema.Fecha]", entidadVenta.Credito.FechaInicio)

                For i = 0 To 5
                    If entidadVenta.Detalle.Count - 1 >= i Then
                        Dim producto = entidadVenta.Detalle(i).Producto
                        If producto.Length > 40 Then
                            producto = entidadVenta.Detalle(i).Producto.Substring(0, 40)
                        End If
                        Dim precioB = 0.0
                        If entidadVenta.Detalle(i).TotalCredito > 0 Then
                            precioB = entidadVenta.Detalle(i).TotalCredito
                        End If
                        cadena = cadena.Replace("[Venta.Codigo" + (i + 1).ToString() + "]", entidadVenta.Detalle(i).IdProductoCorto)
                        cadena = cadena.Replace("[Venta.Descripcion" + (i + 1).ToString() + "]", producto)
                        cadena = cadena.Replace("[Venta.Descripcion" + (i + 1).ToString() + (i + 1).ToString() + "]", entidadVenta.Detalle(i).Promocion)
                        cadena = cadena.Replace("[Venta.Cantidad" + (i + 1).ToString() + "]", entidadVenta.Detalle(i).Cantidad)
                        cadena = cadena.Replace("[Venta.PrecioBase" + (i + 1).ToString() + "]", String.Format("{0:c}", precioB))
                        cadena = cadena.Replace("[Venta.Total" + (i + 1).ToString() + "]", String.Format("{0:c}", entidadVenta.Detalle(i).TotalCredito))
                        cadena = cadena.Replace("[Venta.Total" + (i + 1).ToString() + (i + 1).ToString() + "]", "Descuento -" + String.Format("{0:c}", entidadVenta.Detalle(i).DescuentoCredito))
                    Else
                        cadena = cadena.Replace("[Venta.Codigo" + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.Descripcion" + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.Descripcion" + (i + 1).ToString() + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.Cantidad" + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.PrecioBase" + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.Total" + (i + 1).ToString() + "]", "")
                        cadena = cadena.Replace("[Venta.Total" + (i + 1).ToString() + (i + 1).ToString() + "]", "")
                    End If
                Next

                Dim tipoPeriodo = entidadVenta.Credito.Periodo.ToLower()
                Dim cada = ""
                If tipoPeriodo = "dia" Then
                    cada = "1"
                ElseIf tipoPeriodo = "semana" Then
                    cada = "7"
                ElseIf tipoPeriodo = "quincena" Then
                    cada = "15"
                ElseIf tipoPeriodo = "mes" Then
                    cada = "30"
                End If

                cadena = cadena.Replace("[Venta.Subtotal]", String.Format("{0:c}", entidadVenta.Subtotal))
                cadena = cadena.Replace("[Venta.Descuento]", String.Format("{0:c}", entidadVenta.DescuentoMonto))
                cadena = cadena.Replace("[Venta.Contado]", "CONTADO A " + entidadVenta.Credito.PlazoContado + _
                                        " " + String.Format("{0:c}", entidadVenta.Credito.Total) + "  VENCE EL " + entidadVenta.Credito.FechaFinContado)
                cadena = cadena.Replace("[Venta.Contado2]", entidadVenta.Credito.PeriodoContado.ToString() + _
                                        " PAGOS RECOMENDADOS DE " + String.Format("{0:c}", entidadVenta.Credito.ImporteContado) + " CADA " + cada + " DIAS")
                cadena = cadena.Replace("[Venta.Vendedor]", entidadVenta.Vendedor)
                cadena = cadena.Replace("[Venta.Folio]", "Folio: " + entidadVenta.Folio)
                cadena = cadena.Replace("[Venta.Anticipo]", String.Format("{0:c}", entidadVenta.Credito.Anticipo))

                Dim cargoMonto = 0.0
                For Each cargo In entidadVenta.Cargo
                    If cargo.IdTipo = 2 And cargo.Activo Then
                        cargoMonto += cargo.Total
                    End If
                Next
                cadena = cadena.Replace("[Venta.Cobranza]", String.Format("{0:c}", cargoMonto))
                cadena = cadena.Replace("[Venta.NoPeriodo]", entidadVenta.Credito.PeriodoCredito)
                cadena = cadena.Replace("[Venta.Importe]", String.Format("{0:c}", entidadVenta.Credito.ImporteCredito))
                cadena = cadena.Replace("[Venta.PeriodoDias]", cada)
                cadena = cadena.Replace("[Venta.Total]", String.Format("{0:c}", entidadVenta.Total))

            Catch ex As Exception
                Dim mensaje = ex.Message
            End Try
        End If
    End Sub
    Public Sub ProcesarImprimirReporte(ByVal TablaReporte As DataTable, ByRef cadena As String, empresa As Integer)
        If empresa = 1 Then
        ElseIf empresa = 2 Then 'lalos
            Try
                'Cargar logo y datos de la empresa desde la variable de session
                Dim EmpresaLogo = "<img alt=""logo"" src=""../../../../Imagenes/Lighthouse.jpg"" style=""width: 128px;""/>"
                Dim EmpresaNombre = "Meta"
                Dim EmpresaDireccion = ""

                Dim FechaInicio = CDate(TablaReporte.Rows(0).Item("Fecha"))
                Dim FechaFin = CDate(TablaReporte.Rows(TablaReporte.Rows.Count - 1).Item("Fecha"))
                
                cadena = cadena.Replace("[Empresa.Logo]", EmpresaLogo)
                cadena = cadena.Replace("[Empresa.Nombre]", EmpresaNombre)
                cadena = cadena.Replace("[Empresa.Direccion]", EmpresaDireccion)
                cadena = cadena.Replace("[Sistema.Fecha]", Now.Date.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Fecha.Inicio]", FechaInicio.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Fecha.Fin]", FechaFin.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Tabla.Reporte]", Comun.Presentacion.Impresion.ConvertDataTableToHTML(TablaReporte))

            Catch ex As Exception
                Dim mensaje = ex.Message
            End Try
        End If
    End Sub

End Class
