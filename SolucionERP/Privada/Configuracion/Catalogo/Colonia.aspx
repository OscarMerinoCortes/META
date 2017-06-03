<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Colonia.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                            <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">Entidad Federativa</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDEntidadFederativaColonia" runat="server" Width="155px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>

                <tr>
                            <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">Municipio</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDMunicipioColonia" runat="server" Width="155px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>

                                <tr>
                            <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">Ciudad</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDCiudadColonia1" runat="server" Width="155px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td style="width: 100%;" colspan="5">
                        <asp:GridView ID="GVColonia" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>

                </tr>
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%; border-collapse: collapse;">



                <tr>
                    <td style="padding-right: 10px;"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdColonia" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                    </td>
                </tr>

                

                <tr>
                    <td></td>
                    <td>Descripcion
                    </td>
                    <td>
                         <asp:TextBox ID="TBDesColonia" runat="server" Width="150"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVDesColonia" runat="server" ControlToValidate="TBDesColonia"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> Colonia Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDesColonia" runat="server" TargetControlID="RFVDesColonia"> </asp:ValidatorCalloutExtender>                                            
                    </td>                    
                </tr>

                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Ciudad
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDCiudadColonia" runat="server" Width="155"></asp:DropDownList>                      
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td >Municipio
                    </td>
                    <td >
                        <asp:DropDownList ID="DDMunColonia" runat="server" Width="155">
                        </asp:DropDownList>              
                    </td>                    
                </tr>

                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">Entidad Federativa
                    </td>
                    <td class="auto-style3">
                         <asp:DropDownList ID="DDEntFedColonia" runat="server" Width="155"></asp:DropDownList>                      
                    </td>
                </tr>

                 <tr>
                    <td></td>
                    <td >Pais
                    </td>
                    <td >
                        <asp:DropDownList ID="DDPaisColonia" runat="server" Width="155">
                        </asp:DropDownList>            
                    </td>                    
                </tr>

                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Codigo Postal
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBCPColonia" runat="server" Width="150"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVCPColonia" runat="server" ControlToValidate="TBCPColonia"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> Codigo Postal Obligatorio"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCECPColonia" runat="server" TargetControlID="RFVCPColonia"> </asp:ValidatorCalloutExtender>  
                        <asp:FilteredTextBoxExtender ID="FTBECPColonia"  runat="server" FilterType="Numbers" TargetControlID="TBCPColonia"/>            
                    </td>                    
                </tr>

                <tr>
                    <td></td>
                    <td >Estado
                    </td>
                    <td >
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td />
                    <td colspan="2">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" style="width: 100%;" />
                    </td>
                </tr>

            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>





<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            height: 23px;
        }
        .auto-style3 {
            width: 100%;
            background-color: rgba(195, 195, 195, 0.38);
            height: 23px;
        }
    </style>
</asp:Content>






