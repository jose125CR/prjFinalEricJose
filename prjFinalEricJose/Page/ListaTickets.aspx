<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Menu.Master" AutoEventWireup="true" CodeBehind="ListaTickets.aspx.cs" Inherits="prjFinalEricJose.Page.ListaTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="hero user-hero">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
                <div class="row">
                        <h1>Módulo de Facturas</h1>
                    <ul class="row d-flex justify-content-center breadcumb">
                        <li class="active"><a href="../Page/index.aspx">Inicio</a></li>
                        <li><span class="ion-ios-arrow-right"></span>Módulo de Facturas</li>
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
								<h4>Filtrar por Cédula</h4>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3 form-it">
								<asp:TextBox runat="server" ID="txt_buscar_ticket" type="text" placeholder="Ingrese la Cédula"></asp:TextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-3">
								<asp:Button  CssClass="btn-red" ID="btn_buscar_ticket" runat="server" Text="Buscar" OnClick="btn_buscar_ticket_Click" />
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
								ID="grd_tickets" 
								runat="server" 
								AutoGenerateColumns="false" 
								PageSize="20"
								CssClass="col-md-12 mt-4">
								<Columns>
									<asp:BoundField DataField="dni_persona_Prop" HeaderText="Identificación" />
									<asp:BoundField DataField="nombre_apellido_Prop" HeaderText="Nombre y Apellido" />
									<asp:BoundField DataField="hora_compra_Prop" HeaderText="Fecha de la Compra" />
									<asp:HyperLinkField datatextfield="id_ticket_Prop" datanavigateurlfields="id_ticket_Prop"
										datanavigateurlformatstring="~\factura/{0}"  />
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
