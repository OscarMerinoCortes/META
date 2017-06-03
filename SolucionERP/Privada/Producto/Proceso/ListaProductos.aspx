<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ListaProductos.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarProductoDetalle.ascx" TagName="wucConsultarProductoDetalle" TagPrefix="WUCCPD" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" class="MenuHead">
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTReporte" runat="server" ImageUrl="~/Imagenes/IMReporte.png" Visible="False" />
                        <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" Visible="False" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>

                <tr>
                    <td class="PrimeraColumna">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBId" runat="server" Width="150"></asp:TextBox>
                    </td>                                        
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cod. Corto</td>
                    <td>
                        <asp:TextBox ID="TBCodigoCorto" runat="server" Width="150"></asp:TextBox>
                    </td>                                        
                </tr>
                <%--<tr>
                    <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Inicio Registro</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaInicioRegistro" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioRegistro" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Fin Registro</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaFinRegistro" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinRegistro" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Inicio Actualizacion</td>
                    <td style="width: 241px"><asp:TextBox ID="TBFechaInicioActualizacion" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioActualizacion" />
                    </td>
                    <td style="width: 156px">&nbsp;</td>
                    <td style="width: 273px">
                        &nbsp;</td>
                </tr>--%>
                <%--<tr>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha Fin Actualizacion</td>
                    <td style="width: 241px">
                        <asp:TextBox ID="TBFechaFinActualizacion" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinActualizacion" />
                    </td>
                    <td style="width: 156px"></td>
                    <td style="width: 273px"></td>
                </tr>--%>
                <tr>
                    <td class="PrimeraColumna">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descripcion</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>
                    </td>                                        
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Clasificación</td>
                    <td>
                        <asp:DropDownList ID="DDClasificacion" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>                                 
                </tr>
                <tr>
                    <td class="auto-style27">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;SubClasificación</td>
                    <td class="auto-style28">
                        <asp:DropDownList ID="DDSubClasificacion" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>                                        
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Sucursal</td>
                    <td>
                        <asp:DropDownList ID="DDSucursal" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>                                        
                </tr>
                <tr>
                    <td class="PrimeraColumna">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Almacén</td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDAlmacen" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>                                        
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>                                   
                </tr>
                <tr>
                    <td></td>
                    <td></td>                                        
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="2"><span>
                        <asp:GridView ID="GVListaProductos" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                        </span></td>
                </tr>
            </table>            
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        
        .auto-style27 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            height: 22px;
        }
        .auto-style28 {
            width: 100%;
            background-color: rgba(195, 195, 195, 0.38);
            height: 22px;
        }
    </style>
</asp:Content>

