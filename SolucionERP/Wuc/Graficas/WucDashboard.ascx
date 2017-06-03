<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucDashboard.ascx.vb" Inherits="WucDashboard" %>
<script src="../../Scripts/Imprimir.js"></script>
<script src="../../Scripts/graficas/Chart.js"></script>
<script src="../../Scripts/graficas/Dashboard.js"></script>
<div class="container-fluid">
    <div class="row" style="padding-left: 10px; padding-right: 20px;">
        <div class="col-xs-12 col-md-6 col-lg-5">
            <div id="grafica1" class="col-xs-12" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica1()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica1" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica1"></canvas>
            </div>
            <div id="grafica4" class="col-xs-12" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica4()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica4" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica2"></canvas>
            </div>
        </div>
        <div class="col-xs-12 col-md-6 col-lg-7">
            <div id="grafica2" class="col-xs-12 col-sm-6" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica2()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica2" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica3"></canvas>
            </div>
            <div id="grafica3" class="col-xs-12 col-sm-6" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica3()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica3" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica4"></canvas>
            </div>
            <div id="grafica5" class="col-xs-12 col-sm-6" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica5()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica5" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica5"></canvas>
            </div>
            <div id="grafica6" class="col-xs-12 col-sm-6" style="text-align: center; padding: 0; height: 250px;">
                <%--<a href="#" onclick="Grafica6()" style="position: absolute; padding-left: 40%;" class="hidden-xs"><span id="spnGrafica6" class="hidden fa fa-expand" style="font-size: 24px;"></span></a>--%>
                <canvas id="dvGrafica6"></canvas>
            </div>
        </div>
    </div>
</div>
