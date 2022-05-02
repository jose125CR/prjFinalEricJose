<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="CreacionPdf.aspx.cs" Inherits="prjFinalEricJose.Page.CreacionPdf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                            <h1>Módulo de PDF</h1>
                        <ul class="row d-flex justify-content-center breadcumb">
                            <li class="active"><a href="/inicio">Inicio</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Módulo de PDF</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-single">
        <div class="container">
            <div class="row ipad-width">
                <div class="col-md-12 col-sm-12 col-xs-12 d-flex">
                    <div class="col-md-8 form-style-1 user-pro factura-contenedor margin-auto" action="#">
                        <div action="#" class="user">
                            <h4>Mensaje</h4>
                            <div class="row d-flex justify-content-center">
                                <asp:Label CssClass="mensaje-pdf" runat="server" ID="lb_mensaje_final" Text="" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



