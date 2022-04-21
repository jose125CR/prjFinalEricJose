<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="SelectTicket.aspx.cs" Inherits="prjFinalEricJose.Page.SelectTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                            <h1>Módulo de Boletos</h1>
                        <ul class="row d-flex justify-content-center breadcumb">
                            <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Módulo de Boletos</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-single">
        <div class="container">
            <div class="row mt-3 ipad-width">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="row d-flex justify-content-center">
                        <div class="me-3 ms-3 form-it">
                            <label class="asiento-label">Disponible</label>
                            <div class="margin-auto seat mt-1"></div>
                        </div>
                        <div class="me-3 ms-3 form-it">
                            <label class="asiento-label">Ocupada</label>
                            <div class="margin-auto seat ocupada mt-1"></div>
                        </div>
                        <div class="me-3 ms-3 form-it">
                            <label class="asiento-label">Seleccionada</label>
                            <div class="margin-auto seat seleccionada mt-1"></div>
                        </div>
                        <div class="me-3 ms-3 form-it">
                            <label class="asiento-label">Discapacitados</label>
                            <div class="margin-auto seat mt-1"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row ipad-width">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="row d-flex justify-content-center">
                        <div>
                            <img class="screen" src="/Sources/images/sala-cine-3d.jpg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row ipad-width">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="form-style-1 user-pro">
                        <div action="#" class="user">
                            <div class="container"> 
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row d-flex justify-content-center">
                                            <div class="col-md-3 me-3 ms-3 form-it">
                                                <asp:DropDownList runat="server" Visible="false" CssClass="general-select" AutoPostBack="true" CausesValidation="false" ID="ddl_seleccionar_persona" OnSelectedIndexChanged="ddl_seleccionar_persona_SelectedIndexChanged" />  
                                            </div>
                                        </div>
                                        <div class="seats-container">
                                            <div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="row d-flex justify-content-end">
                                                            <div class="col-6">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Generales: " />
                                                            </div>
                                                            <div class="col-1">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_cantidad_general" runat="server" Text="0" />
                                                            </div>
                                                        </div>
                                                        <div class="row d-flex justify-content-end">
                                                            <div class="col-6">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Niños: " />
                                                            </div>
                                                            <div class="col-1">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_cantidad_ninos" runat="server" Text="0" />
                                                            </div>
                                                        </div>
                                                        <div class="row d-flex justify-content-end">
                                                            <div class="col-6">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Adulto Mayor: " />
                                                            </div>
                                                            <div class="col-1">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_cantidad_adulto" runat="server" Text="0" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 seats-row">
                                                        <div>
                                                            <asp:PlaceHolder ID="PlaceholderControls" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 ps-5">
                                                        <div class="row d-flex">
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Generales:" />
                                                            </div>
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_precio_general" runat="server" Text="₡0" />
                                                            </div>
                                                        </div>
                                                        <div class="row d-flex">
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Niños:" />
                                                            </div>
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_precio_ninos" runat="server" Text="₡0" />
                                                            </div>
                                                        </div>
                                                        <div class="row d-flex">
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" runat="server" Text="Butacas Adulto Mayor:" />
                                                            </div>
                                                            <div class="col">
                                                                <asp:Label CssClass="label-venta-ticket" ID="txt_precio_adulto" runat="server" Text="₡0" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mt-5">
                                            <div class="col-md-3 form-it">
                                                <div class="row">
                                                    <asp:Label CssClass="label-venta-ticket" runat="server" Text="Total a pagar Colones: ₡" />
                                                    <asp:Label CssClass="label-venta-ticket" ID="txt_total_pagar_colones" runat="server" Text="0" />
                                                </div>
                                            </div>
                                            <div class="col-md-3 form-it">
                                                <div class="row">
                                                    <asp:Label CssClass="label-venta-ticket" runat="server" Text="Total a pagar Dólares: $" />
                                                    <asp:Label CssClass="label-venta-ticket" ID="txt_total_pagar_dolares" runat="server" Text="0" />
                                                </div>
                                            </div>
                                            <div class="col-md-6 form-it d-flex justify-content-end">
                                                <asp:Button  CssClass="blue-btn ms-3 me-3" ID="btn_registar_persona" runat="server" Text="Cancelar" />
                                                <asp:Button  CssClass="primary-btn me-3 ms-3" ID="btn_comprar" runat="server" Text="Comprar Seleccionados" OnClick="btn_comprar_Click"/>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>      
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
