<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="prjFinalEricJose.Page.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero common-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="hero-ct">
					<h1>Administrar Usuarios</h1>
					<ul class="breadcumb">
						<li class="active"><a href="#">Usuarios</a></li>
						<li> <span class="ion-ios-arrow-right"></span>Administrar Usuarios</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>
<!-- celebrity list section-->
<div class="page-single">
	<div class="container">
		<div class="row ipad-width2">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="topbar-filter">
					<p class="pad-change">Found <span>1,608 celebrities</span> in total</p>
					<label>Sort by:</label>
					<select>
						<option value="popularity">Popularity Descending</option>
						<option value="popularity">Popularity Ascending</option>
						<option value="rating">Rating Descending</option>
						<option value="rating">Rating Ascending</option>
						<option value="date">Release date Descending</option>
						<option value="date">Release date Ascending</option>
					</select>
					<a href="celebritylist.html" class="list"><i class="ion-ios-list-outline active"></i></a>
					<a  href="celebritygrid01.html" class="grid"><i class="ion-grid "></i></a>
				</div>
				<div class="row">
					<div class="col-md-12">
						<div class="row">
                            <div class="col-md-3 float-end">
                                <button class="btn-red" type="submit" value="save">Agregar nuevo usuario</button>
                            </div>
						</div>	
						<table class="personal-table-dark mt-4" style="width:100%">
							<tr>
								<th>Identificación</th>
								<th>Nombre y Apellidos</th>
								<th>Fecha de Registro</th>
								<th>Rol</th>
								<th>Acciones</th>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>115960067</td>
								<td>Jose Morales Mora</td>
								<td>14/02/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
							<tr>
								<td>159263145</td>
								<td>Eric Bonilla Vargas</td>
								<td>15/07/2021</td>
								<td>Administrador</td>
								<td>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-pen"></i>
									</button>
									<button class="button-icon-tranparent ">
										<i class="fa-solid fa-trash-can"></i>
									</button>
								</td>
							</tr>
						</table>
					</div>
				</div>
				<div class="topbar-filter">
					<label>Reviews per page:</label>
					<select>
						<option value="range">36 Reviews</option>
						<option value="saab">18 Reviews</option>
					</select>
					
					<div class="pagination2">
						<span>Page 1 of 6:</span>
						<a class="active" href="#">1</a>
						<a href="#">2</a>
						<a href="#">3</a>
						<a href="#">4</a>
						<a href="#">5</a>
						<a href="#">6</a>
						<a href="#"><i class="ion-arrow-right-b"></i></a>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
