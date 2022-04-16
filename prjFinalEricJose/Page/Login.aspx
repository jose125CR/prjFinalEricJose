<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prjFinalEricJose.Page.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="page-single login-container">
		<div class="row login-header-logo-container">
			<div class="login-header-logo">
				<a href="index-2.html"><img class="logo" src="../Sources/images/logo1.png" alt="" width="180"></a>
			</div>
			
		</div>
		<div class="row login-header-title-container">
			<div class="login-header-title">
				<h1>Acceso Restringido</h1>
			</div>
		</div>
		<asp:Panel runat="server" ID="formulario_persona" class="container">
			<div class="row ipad-width display-flex">
				<div class="col-md-6 col-sm-12 col-xs-12 margin-auto">
					<div class="form-style-1 user-pro" action="#">
						<div action="#" class="user">
							<div class="row d-flex justify-content-center">
								<div class="form-it">
									<h4>ACCEDER A LA PÁGINA DE MOVIE CENTER</h4>
								</div>
							</div>
							<div class="row mt-4 d-flex justify-content-center">
								<div class="col-md-5 form-it">
									<asp:TextBox runat="server" ID="txt_usuario" type="text" placeholder="Usuario"></asp:TextBox>
								</div>
							</div>
							<div class="row d-flex justify-content-center">
								<div class="col-md-5 form-it">
									<asp:TextBox runat="server" ID="txt_contrasena" type="text" placeholder="Contraseña"></asp:TextBox>
								</div>
							</div>
							<div class="row mt-5 d-flex justify-content-center">
								<asp:Button  CssClass="primary-btn me-2" ID="btn_ingresar_persona" runat="server" Text="Iniciar Sesión" OnClick="btn_ingresar_persona_Click" />
								<asp:Button  CssClass="blue-btn ms-2" ID="btn_registar_persona" runat="server" Text="Registrarme" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</asp:Panel>
	</div>
</asp:Content>
