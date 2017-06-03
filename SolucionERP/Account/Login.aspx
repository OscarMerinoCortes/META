<%@ Page Title="Página principal" Language="VB" MasterPageFile="~/MasterPageLogin.Master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Inicio" UICulture="es-MX" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />

    <%-- <img class="" src="../Imagenes/Modulo/IMLogoSistema1.png" style="height: 74px; position: absolute; left: 50%; top: 31%;" />--%>

    <div class="col-sm-6 col-md-3 panel panel-default " style="height: 40%; position: absolute; left: 35%; top: 35%; margin-left: auto; border-radius: 40px; margin-right: auto;">

        <div class="tab-content">
            <img class="" src="../Imagenes/Modulo/IMLogometa.png" style="padding-left: 45%; padding-top: 20px; height: 74px;" />
            <div class="tab-pane fade in active">
                <div class="col-xs-12" id="DVUsuario" runat="server" style="padding-left: 15%; padding-right: 4px; padding-top: 10px;">
                    <div class="input-group">

                        <span class="input-group-addon">
                            <img src="../Imagenes/Venta/user1.ico" style="width: 20px;" /></span>

                        <asp:TextBox ID="TBUsuario" runat="server" CssClass="form-control col-xs-12 col-sm-3 col-md-3" Width="77%" placeholder="Usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12" id="DVContrasena" runat="server" style="padding-left: 15%; padding-right: 4px; padding-top: 20px;">
                    <div class="input-group">
                        <span class="input-group-addon">
                            <img src="../Imagenes/Venta/lock.ico" style="width: 20px;" /></span>
                        <asp:TextBox ID="TBContrasena" runat="server" CssClass="form-control col-xs-12 col-sm-3 col-md-3" Width="77%" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                </div>

                <div class="col-xs-12" style="padding-left: 12%; padding-right: 4px; padding-top: 1%;">
                    <div class="input-group">
                        <asp:Label ID="LBError" Visible="false" runat="server" CssClass="form-control col-xs-12 col-sm-3 col-md-3" ForeColor="Red" Width="100%">Nombre de usuario y/o contraseña incorrectos</asp:Label>
                    </div>
                </div>

                <%--<asp:imagebutton id="IBTIniciar" runat="server" imageurl="~/Imagenes/IMConsultar.png" style="padding-left: 250px; padding-right: 4px; padding-top: 30px;" />--%>
                <div class="col-xs-12 col-sm-3 col-md-3" style="width: 100%; padding-left: 4px; padding-right: 4px; padding-top: 1%; top: 25px">
                    <!--Le movi aqui <3 !-->
                    <div style="width: 100%;" class="col-md-12 col-sm-12 col-xs-12">
                        <asp:Button ID="IBTIniciar" Style="width: 100%;" runat="server" Text="Iniciar" CssClass="btn btn-primary" />
                    </div>

                </div>


            </div>
        </div>
    </div>



</asp:Content>
