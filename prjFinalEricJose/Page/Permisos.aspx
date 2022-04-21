<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="prjFinalEricJose.Page.Permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero user-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
                <div class="row">
                        <h1>Módulo de Permisos</h1>
                    <ul class="row d-flex justify-content-center breadcumb">
                        <li class="active"><a href="/inicio">Inicio</a></li>
                        <li><span class="ion-ios-arrow-right"></span>Módulo de Permisos</li>
                    </ul>
                </div>
            </div>
		</div>
	</div>
</div>
<div class="page-single">
	<asp:Panel runat="server" ID="formulario_persona" class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12 form-style-1 user-pro">
				<div class="" action="#">
					<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
							<div action="#" class="user">
								<div class="col-md-4">
									<div class="row">
										<div class="col-md-9 form-it">
											<h4>Agregar nuevo Rol</h4>
										</div>
									</div>
									<div class="row mt-5">
										<div class="col-md-10 form-it">
											<label>Nombre del Rol</label>
											<asp:TextBox runat="server" ID="txt_nombre_rol" type="text" placeholder="Nombre del nuevo Rol"></asp:TextBox>
										</div>
									</div>
									<div class="row">
										<div class="col-md-3">
											<asp:Button  CssClass="btn-red" ID="btn_guardar_rol" runat="server" Text="Agregar Rol" OnClick="btn_guardar_rol_Click" />
										</div>
									</div>	
									<div class="row mt-4 d-flex justify-content-center">
										<asp:Label CssClass="green-text" Visible="false" runat="server" ID="lb_mensaje_guardo"/>
									</div>
								</div>
								<div class="col-md-8 editar-roles">
									<div class="row">
										<div class="col-md-9 form-it">
											<h4>Modificar los Rols</h4>
										</div>
									</div>
									<div class="row  d-flex justify-content-around mt-5">
										<div class="col-md-3 form-it">
											<label>Nombre del Role</label>
											<asp:DropDownList ID="ddl_roles" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddl_roles_SelectedIndexChanged"  />
										</div>
										<div class="col-md-3 form-it">
											<label>Nombre del Módulo</label>
											<asp:DropDownList ID="ddl_modulos" runat="server" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddl_roles_SelectedIndexChanged"  />
										</div>
									</div>
									<div class="row d-flex justify-content-center">
										<asp:Label CssClass="green-text" Visible="false" runat="server" ID="lb_mensaje_resultado"/>
									</div>
									<div class="row">
										<asp:GridView
											ID="grd_permisos" 
											runat="server" 
											AutoGenerateColumns="false"
											CssClass="col-md-12 mt-4">
											<Columns>
												<asp:TemplateField HeaderText="Consultar">  
													<ItemTemplate>  
														<asp:CheckBox runat="server" ID="cbx_consulta" OnCheckedChanged="cbx_permisos_CheckedChanged" AutoPostBack="true" CausesValidation="false" Checked='<%# Eval("consultar_Prop")  %>' />
													</ItemTemplate>  
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Registrar">  
													<ItemTemplate>  
														<asp:CheckBox runat="server" ID="cbx_registrar" OnCheckedChanged="cbx_permisos_CheckedChanged" AutoPostBack="true" CausesValidation="false" Checked='<%# Eval("registrar_Prop")  %>' />
													</ItemTemplate>  
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Editar">  
													<ItemTemplate>  
														<asp:CheckBox runat="server" ID="cbx_modificar" OnCheckedChanged="cbx_permisos_CheckedChanged" AutoPostBack="true" CausesValidation="false" Checked='<%# Eval("editar_Prop")  %>' />
													</ItemTemplate>  
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Eliminar">  
													<ItemTemplate>  
														<asp:CheckBox runat="server" ID="cbx_eliminar" OnCheckedChanged="cbx_permisos_CheckedChanged" AutoPostBack="true" CausesValidation="false" Checked='<%# Eval("eliminar_Prop")  %>' />
													</ItemTemplate>  
												</asp:TemplateField>
											</Columns>
										</asp:GridView>
									</div>
									<div class="row">
										<div class="col-md-3">
											<asp:Button  CssClass="btn-red" ID="btn_eliminar_rol" runat="server" Text="Eliminar Rol" OnClick="btn_eliminar_rol_Click" />
										</div>
									</div>	
								</div>
							</div>
						</ContentTemplate>
                    </asp:UpdatePanel>  
				</div>
			</div>
		</div>
	</asp:Panel>
</div>
</asp:Content>
