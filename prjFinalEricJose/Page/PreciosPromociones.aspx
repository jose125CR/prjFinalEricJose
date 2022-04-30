<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="PreciosPromociones.aspx.cs" Inherits="prjFinalEricJose.Page.PreciosPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero user-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
                <div class="row">
                        <h1>Módulo de Precios</h1>
                    <ul class="row d-flex justify-content-center breadcumb">
                        <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                        <li><span class="ion-ios-arrow-right"></span>Módulo de Precios</li>
                    </ul>
                </div>
            </div>
		</div>
	</div>
</div>
<div class="page-single">
	<asp:Panel runat="server" Visible="false" ID="pnl_precios_promociones" class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<div class="row">
							<div class="col-md-9 form-it">
								<h4>Precios de las promociones</h4>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">	
								<asp:GridView
									ID="grd_promociones" 
									runat="server" 
									AutoGenerateColumns="false" 
									PageSize="20"
									CssClass="col-md-12 mt-4 tabla-precios">
									<Columns>
										<asp:BoundField DataField="nombre_sala_prop" HeaderText="Tipo Sala" />
										<asp:TemplateField HeaderText="Domingo">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_domingo" runat="server" Text='<%# Eval("dia_domingo_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Lunes">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_lunes" runat="server" Text='<%# Eval("dia_lunes_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Martes">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_martes" runat="server" Text='<%# Eval("dia_martes_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Miercoles">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_miercoles" runat="server" Text='<%# Eval("dia_miercoles_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Jueves">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_jueves" runat="server" Text='<%# Eval("dia_jueves_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Viernes">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_viernes" runat="server" Text='<%# Eval("dia_viernes_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Sabado">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_sabado" runat="server" Text='<%# Eval("dia_sabado_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>				
									</Columns>
								</asp:GridView>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<asp:Button Visible="false" CssClass="btn-red" ID="btn_actualizar_promociones" runat="server" Text="Actualizar" OnClick="btn_actualizar_promociones_Click" />
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>
	<asp:Panel runat="server" ID="pnl_precios_categorias" Visible="false" class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<div class="row">
							<div class="col-md-9 form-it">
								<h4>Precios Regulares</h4>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">	
								<asp:GridView
									ID="grd_precios_categorias" 
									runat="server" 
									AutoGenerateColumns="false" 
									PageSize="20"
									CssClass="col-md-12 mt-4 tabla-precios">
									<Columns>
										<asp:BoundField DataField="nombre_sala_prop" HeaderText="Tipo Sala" />
										<asp:TemplateField HeaderText="Entrada General">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_general" runat="server" Text='<%# Eval("precio_general_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Entrada Niños">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_nino" runat="server" Text='<%# Eval("precio_nino_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Entrada Adulto Mayor">
											<ItemTemplate>
												<asp:TextBox Enabled="false" ID="txt_adulto" runat="server" Text='<%# Eval("precio_adulto_prop") %>' />
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<asp:Button Visible="false" CssClass="btn-red" ID="btn_actualizar_precios_categorias" runat="server" Text="Actualizar" OnClick="btn_actualizar_precios_categorias_Click" />
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>
	<asp:Panel runat="server" ID="pnl_puntos_canjes" Visible="false" class="container">
		<div class="row ipad-width">
			<div class="col-md-12 col-sm-12 col-xs-12">
				<div class="form-style-1 user-pro" action="#">
					<div action="#" class="user">
						<div class="row">
							<div class="col-md-9 form-it">
								<h4>Puntos y Canjeos</h4>
							</div>
						</div>
						<div class="row canjeos-puntos">
							<div class="col-md-12">	
								<div class="row">
									<div class="col-md-3">
										<label>Puntos necesarios para 2D</label>
									</div>
									<div class="col-md-2">
										<asp:TextBox Enabled="false" ID="txt_puntos_minimos" MaxLength="2" TextMode="Number" runat="server" Text="0" />
									</div>
								</div>
								<div class="row mt-3">
									<div class="col-md-3">
										<label>Canjeos necesarios para IMAX</label>
									</div>
									<div class="col-md-2">
										<asp:TextBox Enabled="false" ID="txt_canjes_minimos" MaxLength="2" TextMode="Number" runat="server" Text="0" />
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<asp:Button Visible="false" ID="btn_actualizar_puntos_canjes" CssClass="btn-red" runat="server" Text="Actualizar" OnClick="btn_actualizar_puntos_canjes_Click" />
							</div>
						</div>	
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>

</div>
</asp:Content>

