<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucVentaAviso.ascx.vb" Inherits="WucVentaAviso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="centraDiv">
    <div class="row">
        <h2 style="text-align: center; padding-bottom: 15px;"><asp:Label runat="server" ID="LBTitulo"></asp:Label></h2>
    </div>
    <div class="row" style="text-align: -webkit-center;">
        <asp:Image runat="server" CssClass="img-responsive" ID="IMImagen" style="max-height: 300px"/>
    </div>
    <div class="row">
        <h4 style="text-align: center; padding-top: 10px;"><asp:Label runat="server" ID="LBDetalle"/></h4>
    </div>
    <div class="row" style="text-align: right; margin-top: 5px; padding: 0px;">
        <div class="hidden-xs col-sm-2 col-md-4 col-lg-4"></div>
        <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4" style="padding-bottom: 10px;">
            <asp:LinkButton ID="BTNVPendiente" runat="server" CssClass="btn btn-default" Style="box-shadow: 0px 0px 5px #001f40; color: black;"><span style="font-size: 26px;" class="fa fa-clock-o"></span>&nbsp;Pendiente</asp:LinkButton>
        </div>
        <div class="col-xs-12 col-sm-5 col-md-4 col-lg-4">
            <asp:LinkButton ID="BTNVCancelar" runat="server" CssClass="btn btn-default"  Style="box-shadow: 0px 0px 5px #001f40; color: black;"><span style="font-size: 26px;" class="fa fa-times"></span>&nbsp;Regresar</asp:LinkButton>
        </div>
    </div>
</div>

