<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="prjFinalEricJose.Page.AddUser" %>
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
	<div class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<h4>Detalles del nuevo Usuario</h4>
						<div class="row">
							<div class="col-md-3 form-it">
								<label>Numero de Cédula</label>
								<input type="text" placeholder="Numero de Cédula">
							</div>
							<div class="col-md-3 form-it">
								<label>Nombre de Usuario</label>
								<input type="text" placeholder="Nombre de Usuario">
							</div>
							<div class="col-md-3 form-it">
								<label>Contraseña</label>
								<input type="text" placeholder="Contraseña">
							</div>
							<div class="col-md-3 form-it">
								<label>Repetir Contraseña</label>
								<input type="text" placeholder="Repetir Contraseña">
							</div>
						</div>
						<div class="row">
							<div class="col-md-3 form-it">
								<label>Primer Nombre</label>
								<input type="text" placeholder="Primer Nombre">
							</div>
							<div class="col-md-3 form-it">
								<label>Segundo nombre</label>
								<input type="text" placeholder="Segundo nombre">
							</div>
							<div class="col-md-3 form-it">
								<label>Primer Apellido</label>
								<input type="text" placeholder="Primer Apellido">
							</div>
							<div class="col-md-3 form-it">
								<label>Segundo Apellido</label>
								<input type="text" placeholder="Segundo Apellido">
							</div>
						</div>
						<div class="row">
							<div class="col-md-3 form-it">
								<label>Rol del Usuario</label>
								<select>
									<option value="" selected disabled hidden>Seleccione Rol</option>
										<option value="1">Administrador</option>
										<option value="2">Cliente</option>
								</select>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<button class="btn-red" type="submit" value="save">Agregar Usuario</button>
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="row">
	<div class="col-md-12">
		<div class="row">
            <div class="col-md-3 float-end">
                <button class="btn-red" type="submit" value="save">Agregar nuevo usuario</button>
            </div>
		</div>	
		<asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="col-md-12 mt-4">
			<Columns>
				<asp:BoundField DataField="dni_Prop" HeaderText="Identificación" />
				<asp:BoundField DataField="nombre1_Prop" HeaderText="Nombre y apellidos" />
				<asp:BoundField DataField="fecha_creacion_Prop" HeaderText="Fecha de Registro" />
				<asp:BoundField DataField="role_Prop" HeaderText="Role" />
				<asp:CommandField ShowSelectButton="true" HeaderStyle-Width="60px" ControlStyle-ForeColor="Black" />
			</Columns>
		</asp:GridView>
	</div>
</div>
</asp:Content>
