<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="QuaintTAE.Pages.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Registration"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- main container start here -->
            <div class="bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="places">
                                <h1>Registration</h1>
                                <hr>
                                <div class="placetop">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtlName">Full Name:<span>*</span></label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full Name" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Email:</label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtContactNumber">Contact Number:<span>*</span></label>
                                                <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" placeholder="Contact Number" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtAddress">Address:</label>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                            </div>
                                        </div>                                        
                                        <div class="col-sm-12">
                                            <asp:Button ID="btnSend" runat="server" class="btn-primary" Text="Send" OnClick="btnSend_Click" />
                                        </div>
                                        <div style="margin-top: 10px;" class="col-sm-12 pull-right" runat="server" id="alertMessage"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
