<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="FacturaTickets.aspx.cs" Inherits="prjFinalEricJose.Page.FacturaTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                            <h1>Módulo de Resumen</h1>
                        <ul class="row d-flex justify-content-center breadcumb">
                            <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Módulo de Resumen</li>
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
                            <h4>Resumen de la Compra Movie Center</h4>
                            <p>Por favor guarde esta Factura para futuros reclamos, sin la factura el reclamo no será valido</p>
                            <div class="row">
                                <div class="col-md-5 form-it">
                                    <label>Fecha y hora de la compra:</label>
                                </div>
                                <div class="col-md-7 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_fecha_hora_compra" Text="Miercoles 24 de Junio de 2022 a las 11:25 am" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Nombre de la pelicula:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_nombre_pelicula" Text="Avengers" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Categoria de Pelicula:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_categoria_pelicula" Text="Todo Público" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Identificación del Cliente:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_dni_cliente" Text="115960067" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Nombre del cliente:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_nombre_completo_cliente" Text="Jose Luis Morales Mora" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas General:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_butacas_general" Text="0 Butaca(s)" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas Niños:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_butacas_nino" Text="0 Butaca(s)" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas Adultos Mayores:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_butacas_adulto" Text="0 Butaca(s)" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butaca(s) Comprada(s):</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_lista_butacas" Text="A-1" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Sala de la Función:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_sala" Text="Sala 1 2D" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Horario de la Función:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_hora_pelicula" Text="11:25 am" />
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Puntos ganados en esta compra:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_puntos_ganados" Text="0" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Total Pagado Colones:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_total_pagado_colones" Text="₡0" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Total Pagado Dólares:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <asp:Label CssClass="label-general" runat="server" ID="txt_total_pagado_dolares" Text="$0" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 d-flex justify-content-end">
                                    <asp:Button runat="server" Text="Imprimir" CssClass="btn-red" ID="btn_guardar_pelicula" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
