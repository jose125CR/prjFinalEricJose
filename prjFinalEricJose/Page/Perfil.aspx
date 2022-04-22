<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="prjFinalEricJose.Page.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                            <h1>Módulo de Perfil</h1>
                        <ul class="row d-flex justify-content-center breadcumb">
                            <li class="active"><a href="/inicio">Inicio</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Módulo de Perfil</li>
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
                            <h4>Perfil de Usuario</h4>
                            <div class="row">
                                <div class="col-md-4">
                                    <image src="../Sources/images/profile-user.png"/>
                                </div>
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Nombre:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_nombre_completo" Text="" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Rol:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_rol" Text="" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Correo:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_correo" Text="" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Nacio el:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_fecha_nac" Text="" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Télefono:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_telefono" Text="" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Registro:</label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label CssClass="label-general" runat="server" ID="lb_fecha_registro" Text="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-md-6">
                                    <label>Puntos:</label>
                                    <asp:Label CssClass="label-general" runat="server" ID="lb_puntos" Text="" />
                                </div>
                                <div class="col-md-6">
                                    <label>Canjeos:</label>
                                    <asp:Label CssClass="label-general" runat="server" ID="lb_canjeos" Text="" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

