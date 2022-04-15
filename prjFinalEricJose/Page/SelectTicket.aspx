<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="SelectTicket.aspx.cs" Inherits="prjFinalEricJose.Page.SelectTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="hero-ct">
                        <h1>Agregar una Película</h1>
                        <ul class="breadcumb">
                            <li class="active"><a href="#">Películas</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Agregar una Película</li>
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
                            <img class="screen" src="../Sources/images/sala-cine-3d.jpg" />
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
                                <div class="seats-container">
                                    <div>
                                        <div class="row seats-row">
                                            <asp:Panel runat="server" ID="pnl_butacas"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt-5">
                                    <div class="col-md-6 form-it">
                                        <label>Total a pagar: ₡12500</label>
                                    </div>
                                    <div class="col-md-6 form-it d-flex justify-content-end">
                                        <asp:Button  CssClass="blue-btn ms-3 me-3" ID="btn_registar_persona" runat="server" Text="Cancelar" />
                                        <asp:Button  CssClass="primary-btn me-3 ms-3" ID="btn_ingresar_persona" runat="server" Text="Comprar Seleccionados"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
