<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guide.aspx.cs" Inherits="QuaintTAE.Pages.Guide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Guide"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="container content-page">
                <div class="row content-page-section">
                    <div class="col-md-4 col-md-offset-4">
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <table class="table table-responsive table-striped table-hover content-page-table">
                            <thead>
                                <tr>
                                    <th>Serial</th>
                                    <th>Name</th>
                                    <th>Contact Number</th>
                                    <th>Location</th>
                                </tr>
                            </thead>

                            <tbody class="text-center">
                                <asp:Repeater ID="rptrList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-left"><%# Container.ItemIndex + 1 %></td>
                                            <td class="text-left"><%# Eval("Name") %></td>
                                            <td class="text-left"><%# Eval("ContactNumber") %></td>
                                            <td class="text-left"><%# Eval("LocationName") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody> 
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlLocation" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
