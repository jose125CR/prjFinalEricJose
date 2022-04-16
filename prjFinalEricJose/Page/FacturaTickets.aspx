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
                                    <label>Miercoles 24 de Junio de 2022 a las 11:25 am</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Nombre de la pelicula:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>Macgiver</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Categoria de Pelicula:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>Todo Público</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Identificación del Cliente:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>115960067</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Nombre del cliente:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>Jose Luis Morales Mora</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas General:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>10 Butacas</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas Niños:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>5 Butacas</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Butacas Adultos Mayores:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>2 Butacas</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Lista de Butacas:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>A-2, A-5, A-10, A-12, A-15, A-20, A-25</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Sala de la Función:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>Sala 1 2D</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Horario de la Función:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>11:00</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Total Pagado Colones:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>₡12500</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 form-it">
                                    <label>Total Pagado Dólares:</label>
                                </div>
                                <div class="col-md-4 form-it">
                                    <label>$12500</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
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
