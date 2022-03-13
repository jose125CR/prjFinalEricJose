<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="prjFinalEricJose.Page.AddMovie" %>
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
						<li> <span class="ion-ios-arrow-right"></span>Agregar una Película</li>
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
						<h4>Detalles de la nueva Película</h4>
						<div class="row">
							<div class="col-md-6 form-it">
								<label>Nombre de la Película</label>
								<input type="text" placeholder="Nombre de la Película">
							</div>
							<div class="col-md-6 form-it">
								<label>Imagen de la Película</label>
								<input type="file" style="width: 100%;" >
							</div>
						</div>
						<div class="row">
							<div class="col-md-12 form-it">
								<label>Sipnosis</label>
								<textarea type="text" placeholder="Escribe la sipnosis de la Película "></textarea>
							</div>
						</div>
						<div class="row">
							<div class="col-md-2 form-it">
								<label>Fecha de Estreno</label>
								<input type="date" value="2018-07-22" >
							</div>
							<div class="col-md-4 form-it">
								<label>Salas donde se presentara la película</label>
								<div class="row form-it m-auto">
									<input type="checkbox" id="sala1" name="sala1" value="Bike">
									<label for="sala1"> Sala 1 2D</label>
									<input type="checkbox" class="ms-3" id="sala2" name="sala2" value="Car">
									<label for="sala2"> Sala 3 3D</label>
									<input type="checkbox" class="ms-3" id="sala3" name="sala3" value="Car">
									<label for="sala3"> Sala 5 IMAX</label>
								</div>
								<div class="row form-it m-auto">
									<input type="checkbox" id="sala4" name="sala1" value="Bike">
									<label for="sala1"> Sala 2 2D</label>
									<input type="checkbox" class="ms-3" id="sala5" name="sala2" value="Car">
									<label for="sala2"> Sala 4 3D</label>
									<input type="checkbox" class="ms-3" id="sala6" name="sala3" value="Car">
									<label for="sala3"> Sala 6 IMAX</label>
								</div>
							</div>
							<div class="col-md-6 form-it">
								<label>Categoría de Edad</label>
								<select>
								  <option value="1">Todo Público</option>
								  <option value="2">Mayores de 16 años</option>
								  <option value="3">Mayores de 16 años</option>
								</select>
							</div>
						</div>
						<%--<div class="row">
							<div class="col-md-6 form-it">
								<label>Country</label>
								<select>
								  <option value="united">United States</option>
								  <option value="saab">Others</option>
								</select>
							</div>
							<div class="col-md-6 form-it">
								<label>State</label>
								<select>
								  <option value="united">New York</option>
								  <option value="saab">Others</option>
								</select>
							</div>
						</div>--%>
						<div class="row">
							<div class="col-md-2 form-it">
								<label>Horarios Sala 1</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
							<div class="col-md-2 form-it">
								<label>Horarios Sala 2</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
							<div class="col-md-2 form-it">
								<label>Horarios Sala 3</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
							<div class="col-md-2 form-it">
								<label>Horarios Sala 4</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
							<div class="col-md-2 form-it">
								<label>Horarios Sala 5</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
							<div class="col-md-2 form-it">
								<label>Horarios Sala 6</label>
								<div class="group-ip">
									<select
										name="skills" multiple="" class="ui fluid dropdown">
										<option value="" selected disabled hidden>Horarios</option>
										<option value="1">10:00</option>
										<option value="2">10:30</option>
										<option value="3">11:00</option>
										<option value="4">11:30</option>
										<option value="5">12:00</option>
										<option value="6">12:30</option>
										<option value="7">13:00</option>
										<option value="8">13:30</option>
										<option value="9">14:00</option>
										<option value="10">14:30</option>
										<option value="11">15:00</option>
										<option value="12">15:30</option>
										<option value="13">16:00</option>
										<option value="14">16:30</option>
										<option value="15">17:00</option>
										<option value="16">17:30</option>
										<option value="17">18:00</option>
										<option value="18">18:30</option>
										<option value="19">19:00</option>
										<option value="20">19:30</option>
										<option value="21">20:00</option>
									</select>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<button class="btn-red" type="submit" value="save">Agregar Pelicula</button>
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
