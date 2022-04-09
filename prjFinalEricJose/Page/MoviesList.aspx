<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="MoviesList.aspx.cs" Inherits="prjFinalEricJose.Page.MoviesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero common-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="hero-ct">
					<h1> movie listing - list</h1>
					<ul class="breadcumb">
						<li class="active"><a href="#">Home</a></li>
						<li> <span class="ion-ios-arrow-right"></span> movie listing</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="page-single movie_list">
	<div class="container">
		<div class="row ipad-width2">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="topbar-filter">
					<p>Found <span>1,608 movies</span> in total</p>
					<label>Sort by:</label>
					<select>
						<option value="popularity">Popularity Descending</option>
						<option value="popularity">Popularity Ascending</option>
						<option value="rating">Rating Descending</option>
						<option value="rating">Rating Ascending</option>
						<option value="date">Release date Descending</option>
						<option value="date">Release date Ascending</option>
					</select>
					<a href="movielist.html" class="list"><i class="ion-ios-list-outline active"></i></a>
					<a  href="moviegrid.html" class="grid"><i class="ion-grid"></i></a>
				</div>
				<asp:ListView 
						ID="ltvPeliculas" 
						runat="server" 
						OnItemCommand="ltvPeliculas_ItemCommand"
						OnItemEditing="ltvPeliculas_ItemEditing" 
						OnItemDeleting="ltvPeliculas_ItemDeleting" 
						OnItemUpdating="ltvPeliculas_ItemUpdating"
					>
					<ItemTemplate>
						<div class="movie-item-style-2">
							<asp:Image runat="server" ImageUrl='<%# Eval("img_url_Prop") %>' />
							<div class="mv-item-infor">
								<div class="btn-actions-movies">
									<asp:Button CssClass="remove-btn" ID="btn_delete" runat="server" Text="Eliminar Pelicula" CommandName="delete" CommandArgument='<%# Eval("id_Prop") %>' />  
									<asp:Button CssClass="blue-btn" ID="Button1" runat="server" Text="Editar Pelicula" CommandName="edit" CommandArgument='<%# Eval("id_Prop") %>' />  
									<asp:Button CssClass="yellow-btn" ID="btnupdt" runat="server" Text="Editar Pelicula" CommandName="update" CommandArgument='<%# Eval("id_Prop") %>' /> 		
								</div>
								<h6>
									<asp:HyperLink runat="server" href='<%# Eval("id_Prop") %>'> <%# Eval("nombre_Prop") %>
										<asp:Label ID="year" runat="server" Text='<%# Eval(" year_Prop") %>' />
									</asp:HyperLink>
								</h6>
								<p class="rate"><i class="ion-android-star"></i><span>8.1</span> /10</p>
								<p class="describe"><%# Eval("sipnosis_Prop") %></p>
								<p class="run-time"> Run Time: 2h21’    .     <span>MMPA: PG-13 </span>    .     <span>Release: 1 May 2015</span></p>
								<p>Director: <a href="#">Joss Whedon</a></p>
								<p>Stars: <a href="#">Robert Downey Jr.,</a> <a href="#">Chris Evans,</a> <a href="#">  Chris Hemsworth</a></p>
							</div>
						</div>
					</ItemTemplate>
				</asp:ListView>
				<div class="topbar-filter">
					<label>Movies per page:</label>
					<select>
						<option value="range">5 Movies</option>
						<option value="saab">10 Movies</option>
					</select>
					<div class="pagination2">
						<span>Page 1 of 2:</span>
						<a class="active" href="#">1</a>
						<a href="#">2</a>
						<a href="#"><i class="ion-arrow-right-b"></i></a>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
