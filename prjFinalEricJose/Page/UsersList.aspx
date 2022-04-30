<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="prjFinalEricJose.Page.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero user-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
                <div class="row">
                        <h1>Módulo de Usuarios</h1>
                    <ul class="row d-flex justify-content-center breadcumb">
                        <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                        <li><span class="ion-ios-arrow-right"></span>Módulo de Usuarios</li>
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
					<asp:Button CssClass="primary-btn" runat="server" Visible="false" ID="btn_abrir_panel_nuevo_usuario" Text="Agregar Nuevo Usuario" OnClick="btn_abrir_panel_nuevo_usuario_Click" />
				</div>
				<div class="row d-flex justify-content-center">
					<asp:Label Visible="false" ID="lb_mensaje" CssClass="green-text" runat="server" Text="La operación se ha completado con exito" />
				</div>
				<asp:Panel Visible="false" runat="server" ID="formulario_persona" class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<div class="row">
							<div class="col-md-9 form-it">
								<h4>Detalles del nuevo Usuario</h4>
							</div>
							<div class="col-md-3 form-it">
								<label>Rol del Usuario</label>
								<asp:DropDownList ID="ddl_roles" runat="server"  />
							</div>
						</div>
						<div class="row mt-5">
							<div class="col-md-3 form-it">
								<label>Numero de Cédula</label>
								<asp:TextBox runat="server" AutoCompleteType="Disabled" ID="txt_dni" type="text" placeholder="Numero de Cédula" TextMode="Number" onKeyDown="if(this.value.length>=9 && event.keyCode!=8 || event.keyCode==109 || event.keyCode==189 || event.keyCode==107 || event.keyCode==187) return false;"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Nombre de Usuario</label>
								<asp:TextBox runat="server" ID="txt_usuario" type="text" placeholder="Nombre de Usuario"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Contraseña</label>
								<asp:TextBox runat="server" ID="txt_contrasena" type="password" placeholder="Contraseña"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Repetir Contraseña</label>
								<asp:TextBox runat="server" ID="txt_contrasena2" type="password" placeholder="Repetir Contraseña"></asp:TextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3 form-it">
								<label>Primer Nombre</label>
								<asp:TextBox runat="server" ID="txt_nombre1" type="text" placeholder="Primer Nombre"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Segundo nombre</label>
								<asp:TextBox runat="server" ID="txt_nombre2" type="text" placeholder="Segundo nombre"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Primer Apellido</label>
								<asp:TextBox runat="server" ID="txt_apellido1" type="text" placeholder="Primer Apellido"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Segundo Apellido</label>
								<asp:TextBox runat="server" ID="txt_apellido2" type="text" placeholder="Segundo Apellido"></asp:TextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3 form-it">
								<label>Correo Electrónico</label>
								<asp:TextBox runat="server" ID="txt_correo" type="email" placeholder="Correo Electrónico" TextMode="Email"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Fecha de Nacimiento</label>
								<asp:TextBox runat="server" ID="txt_fecha_nac" type="date" value="2018-07-22" ></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Número de Teléfono</label>
								<asp:TextBox runat="server" ID="txt_telefono" type="text" placeholder="Número Teléfonico" TextMode="Phone"></asp:TextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-6" >
								<asp:Button  CssClass="primary-btn" ID="btn_guardar_persona" runat="server" Text="Agregar Usuario" OnClick="btn_guardar_persona_Click" />
								<asp:Button  CssClass="primary-btn ms-3" ID="btn_cancelar_formulario" runat="server" Text="Cancelar" OnClick="btn_cancelar_formulario_Click" />
							</div>
						</div>	
					</div>
				</asp:Panel>
			</div>
		</div>
	</div>
	<div class="page-single pt-0">
		<div class="container">
			<div class="row ipad-width2">
				<div class="col-md-12 col-sm-12 col-xs-12">
					<div class="row">
						<div class="col-md-12">	
							<asp:GridView
								OnRowDeleting="grdUsuarios_RowDeleting"
								OnRowUpdating="grdUsuarios_RowUpdating"
								ID="grdUsuarios"
								runat="server"
								AutoGenerateColumns="false"
								PageSize="20"
								CssClass="col-md-12 mt-4">
								<Columns>
									<asp:BoundField DataField="dni_persona_Prop" HeaderText="Identificación" />
									<asp:TemplateField HeaderText="Nombre de la Persona" ItemStyle-HorizontalAlign="center">
										<ItemTemplate>
											<%# Eval("nombre1_Prop") + " " + Eval("apellido1_Prop")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="fecha_creacion_Prop" HeaderText="Fecha de Registro" />
									<asp:BoundField DataField="rol_Prop" HeaderText="Rol Asignado" />
									<asp:TemplateField HeaderText="Editar">
										<ItemTemplate>
											<asp:ImageButton Visible ="false" ID="btn_editar" runat="server" Width="25" Height="25" ImageUrl="../Sources/newIcons/icons8-edit-64.png" CommandName="update"/>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Borrar">
										<ItemTemplate>
											<asp:ImageButton Visible ="false" ID="btn_borrar" runat="server" Width="25" Height="25" ImageUrl="../Sources/newIcons/icons8-remove-48.png" CommandName="delete"/>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
