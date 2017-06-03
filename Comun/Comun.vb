Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Namespace Constantes
    Public Enum TipoProceso
        ImportarOperaciones = 1
        ImportarPersonas = 2
        GenerarOperacionesRelevantes = 3
        GenerarOperacionesInusuales = 4
        RevisarUnaPersonaEnListas = 5
        RevisarTodasLasPersonaEnListas = 6
    End Enum
    Public Enum TimeOutTipoProceso
        prueba = 1
        ImportarOperaciones = 1800
        ImportarListas = 1800
    End Enum
End Namespace

Namespace Presentacion
    Public Class StringTruncado
        Public Shared Function Truncar(text As String, maxLength As Integer) As String
            If text Is Nothing Then
                Return String.Empty
            End If

            If text.Length < maxLength Then
                Return text
            End If

            Return text.Substring(0, maxLength)
        End Function
    End Class
    Public Class Comprobacion
        ''' <summary>
        ''' Valida si la fecha es correcta, de no serlo regresa la fecha siguiente: 01/01/Año actual.</summary>
        ''' <param name="Fecha">Fecha a validar.</param>
        ''' <returns>Fecha en formato Date</returns>
        Shared Function ValidaFechaInicio(Fecha As String) As Date
            Dim fechaInicio = "01/01/" + Now.ToString("yyyy")
            Try
                fechaInicio = CDate(Fecha)
            Catch ex As Exception
            End Try
            Return fechaInicio
        End Function
        ''' <summary>
        ''' Valida si la fecha es correcta, de no serlo regresa la fecha actual del sistema.</summary>
        ''' <param name="Fecha">Fecha a validar.</param>
        ''' <returns>Fecha en formato Date</returns>
        Shared Function ValidaFechaFin(Fecha As String) As Date
            Dim fechaInicio = Now.ToString("dd/MM/yyyy")
            Try
                fechaInicio = CDate(Fecha)
            Catch ex As Exception
            End Try
            Return fechaInicio
        End Function
    End Class

    Public Class Impresion
        Shared Sub AgregarFila(ByRef Tabla As DataTable, ByVal TipoContenido As String, ByVal Contenido As String)
            Dim FilaTemporal As DataRow
            FilaTemporal = Tabla.NewRow()
            FilaTemporal("TipoContenido") = TipoContenido
            FilaTemporal("Contenido") = Contenido
            Tabla.Rows.Add(FilaTemporal)
        End Sub
        Shared Function ConvertDataTableToHTML(dt As DataTable) As String
            Dim html As String = "<table style=""width: 100%;"" cellpadding=""0"" cellspacing=""0"">"
            'add header row
            html += "<tr style=""border: 1px solid black; background: #0094ff;"">"
            For i As Integer = 0 To dt.Columns.Count - 1
                html += "<td style=""border: 1px solid black;"">" + dt.Columns(i).ColumnName + "</td>"
            Next
            html += "</tr>"
            'add rows
            For i As Integer = 0 To dt.Rows.Count - 1
                html += "<tr>"
                For j As Integer = 0 To dt.Columns.Count - 1
                    html += "<td style=""border: 1px solid black;"">" + dt.Rows(i)(j).ToString() + "</td>"
                Next
                html += "</tr>"
            Next
            html += "</table>"
            Return html
        End Function
    End Class

    Public Class Cuadricula
        Shared Sub AgregarColumna(ByRef GridView1 As Object, ByRef Columna1 As Object, ByRef DSTitulo As String, ByRef DSCampo As String, Optional ByVal DSFormato As String = "", Optional ByVal Alineacion As Object = Nothing)
            Columna1.HeaderText = DSTitulo
            Columna1.DataField = DSCampo
            Columna1.SortExpression = DSCampo
            Columna1.ReadOnly = True
            If DSFormato <> String.Empty Then
                Columna1.DataFormatString = DSFormato
            End If
            If Alineacion <> Nothing Then
                Columna1.ItemStyle.HorizontalAlign = Alineacion
            End If
            GridView1.Columns.Add(Columna1)
        End Sub

        'Shared Function ExportarTabla(ByRef Tabla1 As Object, ByRef DBTodos As Boolean, ByRef Titulo As String, ByRef Columnas As String) As String
        '    ExportarTabla = String.Empty
        '    Try
        '        ExportarTabla = ExportarTabla + Titulo + System.Environment.NewLine

        '        For Each Renglon As DataRow In Tabla1.Rows
        '            Dim Linea As String = String.Empty
        '            For DINumCol As Integer = 0 To Tabla1.Columns.Count - 1
        '                If DBTodos Then
        '                    Linea = Linea + Renglon.Item(DINumCol).ToString + ","
        '                Else
        '                    Dim ColumnaABuscar As String = Tabla1.Columns(DINumCol).ColumnName + ","
        '                    If Columnas.IndexOf(ColumnaABuscar) >= 0 Then
        '                        Linea = Linea + Renglon.Item(DINumCol).ToString + ","
        '                    End If
        '                End If
        '            Next
        '            Linea = Linea.Remove(Linea.Length - 1, 1)
        '            ExportarTabla = ExportarTabla + Linea + System.Environment.NewLine
        '        Next
        '    Catch ex As Exception
        '    End Try
        '    Return ExportarTabla
        'End Function
        Shared Sub ConvertirADataTable(ByRef GVReferencia As Object, ByVal DTObjeto As Object)
            Dim GVObjeto As New Object()

            If GVReferencia.HeaderRow IsNot Nothing Then
                For i As Integer = 0 To GVReferencia.HeaderRow.Cells.Count - 1
                    DTObjeto.Columns.Add(GVReferencia.Columns(i).HeaderText)
                    ''DTObjeto.Columns.Add(GVReferencia.Columns(i).FooterText)
                Next
            End If

            For Each row In GVReferencia.Rows
                Dim DRFooter As DataRow
                DRFooter = DTObjeto.NewRow()
                For i As Integer = 0 To row.Cells.Count - 1
                    If row.Cells(i).Text = "&nbsp;" Then
                        DRFooter(i) = " "
                    Else
                        DRFooter(i) = row.Cells(i).Text

                    End If
                Next
                DTObjeto.Rows.Add(DRFooter)
            Next

            'agregar totales de las columnas
            'agregue el If por que marcaba error en la i¿siguiente linea cuando esta vacio el grid
            If GVReferencia.Rows.Count > 0 Then
                If GVReferencia.FooterRow IsNot Nothing Then
                    Dim rowFooter As GridViewRow = GVReferencia.FooterRow
                    Dim DR As DataRow
                    DR = DTObjeto.NewRow()
                    For i As Integer = 0 To rowFooter.Cells.Count - 1
                        If rowFooter.Cells(i).Text = "&nbsp;" Then
                            DR(i) = " "
                        Else
                            DR(i) = rowFooter.Cells(i).Text

                        End If
                    Next
                    DTObjeto.Rows.Add(DR)
                End If
            End If
        End Sub
        Shared Sub CopiarColumnasADataTable(ByRef DTTabla As DataTable, ByVal DSColumnas As String())
            DTTabla = DTTabla.DefaultView.ToTable("tempTableName", False, DSColumnas)
        End Sub
        Shared Sub ObtenerTablaDinamica(ByRef GridView As Object, ByVal DTObjeto As Object, ByVal Controles As String(), ByVal Columnas As String())
            For s As Integer = 0 To Columnas.Length - 1
                DTObjeto.Columns.Add(Columnas(s))
            Next
            For Each row As GridViewRow In GridView.Rows
                Dim DR As DataRow
                DR = DTObjeto.NewRow()
                Dim i As Integer = 0
                For Each con As String In Controles
                    Dim label1 As Label = TryCast(row.FindControl(con), Label)
                    If label1 IsNot Nothing Then
                        DR(Columnas(i)) = label1.Text
                    End If
                    Dim text1 As TextBox = TryCast(row.FindControl(con), TextBox)
                    If text1 IsNot Nothing Then
                        DR(Columnas(i)) = text1.Text
                    End If
                    i = i + 1
                Next
                DTObjeto.Rows.Add(DR)
            Next
        End Sub
        Shared Function ExportarTabla(ByRef Tabla1 As Object, ByRef DBTodos As Boolean, ByRef Titulo As String, ByRef Columnas As String) As String
            ExportarTabla = String.Empty
            Try
                ExportarTabla = ExportarTabla + Titulo + System.Environment.NewLine

                For Each Renglon As DataRow In Tabla1.Rows
                    Dim Linea As String = String.Empty
                    For DINumCol As Integer = 0 To Tabla1.Columns.Count - 1
                        If DBTodos Then
                            Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                        Else
                            Dim ColumnaABuscar As String = Tabla1.Columns(DINumCol).ColumnName + ","
                            If Columnas.ToUpper.IndexOf(ColumnaABuscar.ToUpper) >= 0 Then
                                Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                            End If
                        End If
                    Next
                    Linea = Linea.Remove(Linea.Length - 1, 1)
                    ExportarTabla = ExportarTabla + Linea + System.Environment.NewLine
                Next
            Catch ex As Exception
            End Try
            Return ExportarTabla
        End Function
        Shared Function ExportarTablaSinTitulos(ByRef Tabla1 As Object, ByRef DBTodos As Boolean, ByRef Columnas As String) As String
            ExportarTablaSinTitulos = String.Empty
            Try
                ''ExportarTablaSinTitulos = ExportarTablaSinTitulos() + Titulo + System.Environment.NewLine

                For Each Renglon As DataRow In Tabla1.Rows
                    Dim Linea As String = String.Empty
                    For DINumCol As Integer = 0 To Tabla1.Columns.Count - 1
                        If DBTodos Then
                            Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                        Else
                            Dim ColumnaABuscar As String = Tabla1.Columns(DINumCol).ColumnName + ","
                            If Columnas.ToUpper.IndexOf(ColumnaABuscar.ToUpper) >= 0 Then
                                Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                            End If
                        End If
                    Next
                    Linea = Linea.Remove(Linea.Length - 1, 1)
                    ExportarTablaSinTitulos = ExportarTablaSinTitulos + Linea + System.Environment.NewLine
                Next
            Catch ex As Exception
            End Try
            Return ExportarTablaSinTitulos
        End Function

    End Class
    Public Class Herramientas
        'Esta parte de codigo la saque de la siguiente pagina http://www.aspsnippets.com/Articles/Using-HTML5-Canvas-charts-in-ASPNet.aspx
        'Lo que hace es obtener la consulta en SqlDataReader y este la convierte en texto plano con formato json
        Shared Function ConvierteSqlDataReaderAJSON(ByVal sdr As SqlDataReader, Optional columnaTres As Boolean = False) As String
            Dim sb As New StringBuilder()
            sb.Append("[")
            While sdr.Read()
                sb.Append("{")
                'System.Threading.Thread.Sleep(5)
                'Dim color As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
                If columnaTres Then
                    Try
                        sb.Append(String.Format("text :'" + sdr(0).ToString() + "', value:" + sdr(1).ToString() + ", tipo:" + sdr(2).ToString()))
                    Catch ex As Exception
                        sb.Append(String.Format("text :'" + sdr(0).ToString() + "', value:" + sdr(1).ToString() + ", tipo:1"))
                        columnaTres = False
                    End Try
                Else
                    sb.Append(String.Format("text :'" + sdr(0).ToString() + "', value:" + sdr(1).ToString() + ", tipo:1"))
                End If
                'sb.Append(String.Format("text :'{0}', value:{1}, color: '{2}'", sdr(0), sdr(1), color))
                sb.Append("},")
            End While
            sb = sb.Remove(sb.Length - 1, 1)
            sb.Append("]")
            Return sb.ToString()
        End Function
        Shared Function ConvertDataTableToHTML(dt As DataTable) As String
            Dim html As String = "<table style=""width: 100%;"" cellpadding=""0"" cellspacing=""0"">"
            'add header row
            html += "<tr style=""border: 1px solid black; background: #104577; text-align:center;"">"
            For i As Integer = 0 To dt.Columns.Count - 1
                html += "<td style=""border: 1px solid black; color: #ffffff;"">" + dt.Columns(i).ColumnName + "</td>"
            Next
            html += "</tr>"
            'add rows
            For i As Integer = 0 To dt.Rows.Count - 1
                html += "<tr>"
                For j As Integer = 0 To dt.Columns.Count - 1
                    If IsNumeric(dt.Rows(i)(j)) Then
                        If InStr(dt.Rows(i)(j), ".") Then 'Si identifica decimal
                            html += "<td style=""border: 1px solid black; font-size:12px; color:#000; text-align:right; "">" + String.Format("{0:c}", dt.Rows(i)(j)) + "</td>"
                        Else 'Si identifica entero
                            html += "<td style=""border: 1px solid black; font-size:12px; color:#000; text-align:center; "">" + dt.Rows(i)(j).ToString() + "</td>"
                        End If
                    Else 'Si es Letra
                        html += "<td style=""border: 1px solid black; font-size:12px; color:#000; text-align:left; "">" + dt.Rows(i)(j).ToString() + "</td>"
                    End If
                Next
                html += "</tr>"
            Next
            html += "</table>"
            Return html
        End Function
    End Class
End Namespace


