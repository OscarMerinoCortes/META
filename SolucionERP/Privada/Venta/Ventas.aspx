<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Ventas.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/Graficas/WucDashboard.ascx" TagName="wucDashboard" TagPrefix="WUCGC" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <WUCGC:wucDashboard ID="wucGraficaDashboard" runat="server" />
</asp:Content>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <script>
        function Grafica1() {
            if (document.getElementById('grafica2').classList.contains('hidden')) {
                document.getElementById('spnGrafica1').classList.add('fa-expand');
                document.getElementById('spnGrafica1').classList.remove('fa-compress');

                document.getElementById('grafica1').classList.add('col-sm-6');
                document.getElementById('grafica1').classList.add('col-md-4');
                document.getElementById('grafica1').classList.add('col-lg-4');

                document.getElementById('grafica2').classList.remove('hidden');
                document.getElementById('grafica3').classList.remove('hidden');
                document.getElementById('grafica4').classList.remove('hidden');
                document.getElementById('grafica5').classList.remove('hidden');
                document.getElementById('grafica6').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica1').classList.remove('fa-expand');
                document.getElementById('spnGrafica1').classList.add('fa-compress');

                document.getElementById('grafica1').classList.remove('col-sm-6');
                document.getElementById('grafica1').classList.remove('col-md-4');
                document.getElementById('grafica1').classList.remove('col-lg-4');

                document.getElementById('grafica2').classList.add('hidden');
                document.getElementById('grafica3').classList.add('hidden');
                document.getElementById('grafica4').classList.add('hidden');
                document.getElementById('grafica5').classList.add('hidden');
                document.getElementById('grafica6').classList.add('hidden');


            }
        }
        function Grafica2() {
            if (document.getElementById('grafica1').classList.contains('hidden')) {
                document.getElementById('spnGrafica2').classList.add('fa-expand');
                document.getElementById('spnGrafica2').classList.remove('fa-compress');

                document.getElementById('grafica2').classList.add('col-sm-6');
                document.getElementById('grafica2').classList.add('col-md-4');
                document.getElementById('grafica2').classList.add('col-lg-4');

                document.getElementById('grafica1').classList.remove('hidden');
                document.getElementById('grafica3').classList.remove('hidden');
                document.getElementById('grafica4').classList.remove('hidden');
                document.getElementById('grafica5').classList.remove('hidden');
                document.getElementById('grafica6').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica2').classList.remove('fa-expand');
                document.getElementById('spnGrafica2').classList.add('fa-compress');

                document.getElementById('grafica2').classList.remove('col-sm-6');
                document.getElementById('grafica2').classList.remove('col-md-4');
                document.getElementById('grafica2').classList.remove('col-lg-4');

                document.getElementById('grafica1').classList.add('hidden');
                document.getElementById('grafica3').classList.add('hidden');
                document.getElementById('grafica4').classList.add('hidden');
                document.getElementById('grafica5').classList.add('hidden');
                document.getElementById('grafica6').classList.add('hidden');
            }
        }
        function Grafica3() {
            if (document.getElementById('grafica1').classList.contains('hidden')) {
                document.getElementById('spnGrafica3').classList.add('fa-expand');
                document.getElementById('spnGrafica3').classList.remove('fa-compress');

                document.getElementById('grafica3').classList.add('col-sm-6');
                document.getElementById('grafica3').classList.add('col-md-4');
                document.getElementById('grafica3').classList.add('col-lg-4');

                document.getElementById('grafica1').classList.remove('hidden');
                document.getElementById('grafica2').classList.remove('hidden');
                document.getElementById('grafica4').classList.remove('hidden');
                document.getElementById('grafica5').classList.remove('hidden');
                document.getElementById('grafica6').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica3').classList.remove('fa-expand');
                document.getElementById('spnGrafica3').classList.add('fa-compress');

                document.getElementById('grafica3').classList.remove('col-sm-6');
                document.getElementById('grafica3').classList.remove('col-md-4');
                document.getElementById('grafica3').classList.remove('col-lg-4');

                document.getElementById('grafica1').classList.add('hidden');
                document.getElementById('grafica2').classList.add('hidden');
                document.getElementById('grafica4').classList.add('hidden');
                document.getElementById('grafica5').classList.add('hidden');
                document.getElementById('grafica6').classList.add('hidden');
            }
        }
        function Grafica4() {
            if (document.getElementById('grafica1').classList.contains('hidden')) {
                document.getElementById('spnGrafica4').classList.add('fa-expand');
                document.getElementById('spnGrafica4').classList.remove('fa-compress');

                document.getElementById('grafica4').classList.add('col-sm-6');
                document.getElementById('grafica4').classList.add('col-md-4');
                document.getElementById('grafica4').classList.add('col-lg-4');

                document.getElementById('grafica1').classList.remove('hidden');
                document.getElementById('grafica2').classList.remove('hidden');
                document.getElementById('grafica3').classList.remove('hidden');
                document.getElementById('grafica5').classList.remove('hidden');
                document.getElementById('grafica6').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica4').classList.remove('fa-expand');
                document.getElementById('spnGrafica4').classList.add('fa-compress');

                document.getElementById('grafica4').classList.remove('col-sm-6');
                document.getElementById('grafica4').classList.remove('col-md-4');
                document.getElementById('grafica4').classList.remove('col-lg-4');

                document.getElementById('grafica1').classList.add('hidden');
                document.getElementById('grafica2').classList.add('hidden');
                document.getElementById('grafica3').classList.add('hidden');
                document.getElementById('grafica5').classList.add('hidden');
                document.getElementById('grafica6').classList.add('hidden');
            }
        }
        function Grafica5() {
            if (document.getElementById('grafica1').classList.contains('hidden')) {
                document.getElementById('spnGrafica5').classList.add('fa-expand');
                document.getElementById('spnGrafica5').classList.remove('fa-compress');

                document.getElementById('grafica5').classList.add('col-sm-6');
                document.getElementById('grafica5').classList.add('col-md-4');
                document.getElementById('grafica5').classList.add('col-lg-4');

                document.getElementById('grafica1').classList.remove('hidden');
                document.getElementById('grafica2').classList.remove('hidden');
                document.getElementById('grafica3').classList.remove('hidden');
                document.getElementById('grafica4').classList.remove('hidden');
                document.getElementById('grafica6').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica5').classList.remove('fa-expand');
                document.getElementById('spnGrafica5').classList.add('fa-compress');
                document.getElementById('grafica5').classList.remove('col-sm-6');
                document.getElementById('grafica5').classList.remove('col-md-4');
                document.getElementById('grafica5').classList.remove('col-lg-4');

                document.getElementById('grafica1').classList.add('hidden');
                document.getElementById('grafica2').classList.add('hidden');
                document.getElementById('grafica3').classList.add('hidden');
                document.getElementById('grafica4').classList.add('hidden');
                document.getElementById('grafica6').classList.add('hidden');
            }
        }
        function Grafica6() {
            if (document.getElementById('grafica1').classList.contains('hidden')) {
                document.getElementById('spnGrafica6').classList.add('fa-expand');
                document.getElementById('spnGrafica6').classList.remove('fa-compress');

                document.getElementById('grafica6').classList.add('col-sm-6');
                document.getElementById('grafica6').classList.add('col-md-4');
                document.getElementById('grafica6').classList.add('col-lg-4');

                document.getElementById('grafica1').classList.remove('hidden');
                document.getElementById('grafica2').classList.remove('hidden');
                document.getElementById('grafica3').classList.remove('hidden');
                document.getElementById('grafica4').classList.remove('hidden');
                document.getElementById('grafica5').classList.remove('hidden');
            } else {
                document.getElementById('spnGrafica6').classList.remove('fa-expand');
                document.getElementById('spnGrafica6').classList.add('fa-compress');

                document.getElementById('grafica6').classList.remove('col-sm-6');
                document.getElementById('grafica6').classList.remove('col-md-4');
                document.getElementById('grafica6').classList.remove('col-lg-4');

                document.getElementById('grafica1').classList.add('hidden');
                document.getElementById('grafica2').classList.add('hidden');
                document.getElementById('grafica3').classList.add('hidden');
                document.getElementById('grafica4').classList.add('hidden');
                document.getElementById('grafica5').classList.add('hidden');
            }
        }
    </script>
</asp:Content>

