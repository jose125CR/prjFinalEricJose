<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="prjFinalEricJose.Page.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero user-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="hero-ct">
					<h1>Agregar un Usuario</h1>
					<ul class="breadcumb">
						<li class="active"><a href="#">Usuarios</a></li>
						<li> <span class="ion-ios-arrow-right"></span>Agregar un Usuario</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="page-single">
	<asp:Panel runat="server" ID="formulario_persona" class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<div class="row">
							<div class="col-md-9 form-it">
								<h4>Detalles del nuevo Usuario</h4>
							</div>
							<div class="col-md-3 form-it">
								<label>Rol del Usuario</label>
								<asp:DropDownList ID="ddl_roles" runat="server"  />
								<%--<select>
									<option value="" selected disabled hidden>Seleccione Rol</option>
										<option value="1">Administrador</option>
										<option value="2">Cliente</option>
								</select>--%>
							</div>
						</div>
						<div class="row mt-5">
							<div class="col-md-3 form-it">
								<label>Numero de Cédula</label>
								<asp:TextBox runat="server" ID="txt_dni" type="text" placeholder="Numero de Cédula"></asp:TextBox>
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
								<asp:TextBox runat="server" ID="txt_correo" type="email" placeholder="Correo Electrónico"></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Fecha de Nacimiento</label>
								<asp:TextBox runat="server" ID="txt_fecha_nac" type="date" value="2018-07-22" ></asp:TextBox>
							</div>
							<div class="col-md-3 form-it">
								<label>Número de Teléfono</label>
								<asp:TextBox runat="server" ID="txt_telefono" type="text" placeholder="Número Teléfonico"></asp:TextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<asp:Button  CssClass="btn-red" ID="btn_guardar_persona" runat="server" Text="Agregar Usuario" OnClick="btn_guardar_persona_Click" />
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>
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
									<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center">
										<ItemTemplate>
											<%# ((int)Eval("id_rol_Prop") == 1) ? "Administrador" : "Cliente" %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:ButtonField  CommandName="update" ButtonType="Image" ControlStyle-Width="25" ControlStyle-Height="25" ImageUrl="../Sources/newIcons/icons8-edit-64.png"  />
									<asp:ButtonField  CommandName="delete" ButtonType="Image" ControlStyle-Width="25" ControlStyle-Height="25" ImageUrl="../Sources/newIcons/icons8-remove-48.png" />
									<%--<asp:CommandField ShowSelectButton="true" ButtonType="Image" DeleteImageUrl="~/Sources/images/logo1.png" HeaderStyle-Width="60px" ControlStyle-ForeColor="White" />--%>
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
