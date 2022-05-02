<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="MoviesList.aspx.cs" Inherits="prjFinalEricJose.Page.MoviesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero user-hero">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                            <h1>Módulo de Ingreso de Películas</h1>
                        <ul class="row d-flex justify-content-center breadcumb">
                            <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                            <li><span class="ion-ios-arrow-right"></span>Módulo de Ingreso de Películas</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-single">
        <div class="container">
            <div class="row ipad-width">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="row">
					    <asp:Button Visible="false" CssClass="primary-btn" runat="server" ID="btn_abrir_panel_nueva_pelicula" Text="Agregar Nueva Película" OnClick="btn_abrir_panel_nueva_pelicula_Click" />
				    </div>
				    <div class="row d-flex justify-content-center">
					    <asp:Label Visible="false" ID="lb_mensaje" CssClass="green-text" runat="server" Text="La operación se ha completado con exito" />
				    </div>
                    <asp:Panel Visible="false" ID="pnl_formulario" runat="server" class="form-style-1 user-pro">
                        <div action="#" class="user">
                            <h4>Detalles de la nueva Película</h4>
                            <div class="row">
                                <div class="col-md-6 form-it">
                                    <label>Nombre de la Película</label>
                                    <asp:TextBox runat="server" ID="txt_nombre_pelicula" placeholder="Nombre de la Película" />
                                </div>
                                <div class="col-md-6 form-it">
                                    <label>Imagen de la Película</label>
                                    <asp:FileUpload CssClass="w-100" runat="server" ID="fud_imagen_pelicula" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-it">
                                    <label>Sipnosis</label>
                                    <asp:TextBox ID="txt_sipnosis" runat="server" Wrap="true" TextMode="MultiLine" placeholder="Escribe la sipnosis de la Película " />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-it">
                                    <div class="col-md-6 form-it">
                                        <label>Categoría de Edad</label>
                                        <asp:DropDownList ID="ddl_categoria_edad" CssClass="general-select" runat="server" />
                                    </div>
                                    <div class="col-md-6 form-it">
                                        <label>Horarios Disponibles</label>
                                        <div class="group-ip">
                                            <asp:ListBox CssClass="multi-select" ID="ltb_horarios_disponibles" SelectionMode="Multiple" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 form-it">
                                    <label>Salas donde se presentara la película</label>
                                    <div class="row form-it d-flex">
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" ID="sala1" name="sala1" />
                                            <label for="sala1">Sala 1 2D</label>
                                        </div>
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" class="ms-3" ID="sala2" name="sala2" />
                                            <label for="sala2">Sala 2 3D</label>
                                        </div>
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" class="ms-3" ID="sala3" name="sala3" />
                                            <label for="sala3">Sala 3 IMAX</label>
                                        </div>
                                    </div>
                                    <div class="row form-it d-flex">
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" ID="sala4" name="sala4" />
                                            <label for="sala4">Sala 4 2D</label>
                                        </div>
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" class="ms-3" ID="sala5" name="sala2" />
                                            <label for="sala5">Sala 5 3D</label>
                                        </div>
                                        <div class="col d-flex justify-content-center">
                                            <asp:CheckBox runat="server" class="ms-3" ID="sala6" name="sala3" />
                                            <label for="sala6">Sala 6 IMAX</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Button runat="server" Text="Agregar Pelicula" CssClass="primary-btn" ID="btn_guardar_pelicula" OnClick="btn_guardar_pelicula_Click" />
								    <asp:Button  CssClass="primary-btn ms-3" ID="btn_cancelar_formulario" runat="server" Text="Cancelar" OnClick="btn_cancelar_formulario_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <%--**********************************************************************************--%>
    <div class="page-single movie_list">
        <div class="container">
            <div class="row ipad-width2">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:ListView
                        ID="ltvPeliculas"
                        runat="server"
                        OnItemCommand="ltvPeliculas_ItemCommand"
                    >
                        <ItemTemplate>
                            <div class="movie-item-style-2">
                                <asp:Image runat="server" ImageUrl='<%# "../Sources/images/uploads/" + Eval("direccion_img_prop") %>' />
                                <div class="mv-item-infor">
                                    <div class="btn-actions-movies">
                                        <asp:Button Visible="false" CssClass="primary-btn me-2" ID="btn_delete" runat="server" Text="Eliminar Pelicula" CommandName="eliminar_pelicula" CommandArgument='<%# Eval("id_pelicula_Prop") %>' />
                                        <asp:Button Visible="false" CssClass="blue-btn me-2 me-2 ms-2" ID="btn_edit" runat="server" Text="Editar Pelicula" CommandName="editar_pelicula" CommandArgument='<%# Eval("id_pelicula_Prop") %>' />
                                        <asp:Button CssClass="yellow-btn ms-2" ID="btnupdt" runat="server" Text="Seleccionar Butacas" CommandName="seleccionar_butaca" CommandArgument='<%# Eval("id_pelicula_Prop") %>' />
                                    </div>
                                    <h6>
                                        <asp:HyperLink runat="server">
                                            <%# Eval("nombre_pelicula_Prop") %>
                                            <asp:Label CssClass="ms-1" runat="server" Text="2022" />
                                        </asp:HyperLink>
                                    </h6>
                                    <div class="row d-flex">
                                        <p class="rate"><i class="ion-android-star"></i><span>8.1</span> /10</p>
                                        <asp:Label ID="lb_categoria_edad" CssClass="ms-3 yellow-text" runat="server" Text='<%# ((int)Eval("id_categoria_edad_pelicula_Prop") == 1) ? "(Todo Público)" : ((int)Eval("id_categoria_edad_pelicula_Prop") == 2) ? "(Mayores de 16 años)" : "(Mayores de 18 años)" %>' />
                                    </div>
                                    <p class="describe"><%# Eval("sinopsis_prop") %></p>
                                    <p class="alerta-pelicula">Por favor verifica los datos de la película!!</p>
                                    <div class="row">
                                        <div class="col-md-2 form-it">
                                            <label class="white-color-text">Horarios Disponibles</label>
                                            <asp:DropDownList ID="horario" CssClass="general-select" runat="server" DataSource='<%# Eval("horarios_Prop") %>' DataTextField="horario_Prop" DataValueField="id_horario_Prop" />
                                        </div>
                                        <div class="col-md-2 form-it">
                                            <label class="white-color-text">Salas Disponibles</label>
                                            <asp:DropDownList ID="sala" CssClass="general-select" runat="server" DataSource='<%# Eval("salas_Prop") %>' DataTextField="nombre_tipo_sala_Prop" DataValueField="id_sala_cartelera_Prop" />
                                        </div>
                                        <div class="col-md-2 form-it">
                                            <label class="white-color-text">Días Disponibles</label>
                                            <asp:DropDownList ID="dia" CssClass="general-select" runat="server" DataSource='<%# Eval("dias_Prop") %>' DataTextField="nombre_dia_Prop" DataValueField="id_dia_Prop" />
                                        </div>
                                        <div class="col-md-2 form-it d-flex justify-content-center">
                                            <asp:Button  CssClass="black-btn margin-bonificacion-btn" CommandName="btn_bono_2d" CommandArgument='<%# Eval("id_pelicula_Prop") %>' ID="btn_promocion_2d" runat="server" Text="Bonificación 2D" />
                                        </div>
                                        <div class="col-md-2 form-it d-flex justify-content-center">
                                            <asp:Button  CssClass="black-btn margin-bonificacion-btn" CommandName="btn_bono_imax" CommandArgument='<%# Eval("id_pelicula_Prop") %>' ID="btn_registar_persona" runat="server" Text="Bonificación IMAX" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
