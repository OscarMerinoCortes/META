

Imports System.Data
Imports Operacion.Configuracion.Constante
Partial Class Wuc_WucGraficaMovimientoInventario
    Inherits System.Web.UI.UserControl
    Private TablaConsultarMovimientoInventario As New DataTable()
    Public Event Seleccionado As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Tabla As New DataTable
        Dim Tabla2 As New DataTable
        Dim Tabla3 As New DataTable
        Dim Tabla4 As New DataTable
        Dim Tabla5 As New DataTable

        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario.Tarjeta.Consulta = Consulta.ConsultaPorCantidad
        NegocioMovimientoInventario.GraficasMovimientoInventario(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaCantidadPorSucursal
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart1.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "$#,###,##0.00"
        Chart1.Legends(0).Enabled = True
        Chart1.DataSource = Tabla              

        Tabla2 = EntidadMovimientoInventario.TablaMontoPorSucursal
        Chart2.ChartAreas(0).AxisX.Interval = 1
        Chart2.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart2.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart2.ChartAreas(0).AxisY.LabelStyle.Format = "$#,###,##0.00"
        Chart2.Legends(0).Enabled = True
        Chart2.DataSource = Tabla2

        Tabla3 = EntidadMovimientoInventario.TablaExistenciaPorAlmacen
        Chart3.ChartAreas(0).AxisX.Interval = 1
        Chart3.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart3.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount       
        Chart3.Legends(0).Enabled = True
        Chart3.DataSource = Tabla3

        Tabla4 = EntidadMovimientoInventario.TablaExcedentes
        Chart4.ChartAreas(0).AxisX.Interval = 1
        Chart4.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart4.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart4.Legends(0).Enabled = True
        Chart4.DataSource = Tabla4

        Tabla5 = EntidadMovimientoInventario.TablaFaltantes
        Chart5.ChartAreas(0).AxisX.Interval = 1     
        Chart5.ChartAreas(0).AxisX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Number
        Chart5.ChartAreas(0).AxisX.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
        Chart5.Legends(0).Enabled = True
        Chart5.DataSource = Tabla5
    End Sub
End Class
