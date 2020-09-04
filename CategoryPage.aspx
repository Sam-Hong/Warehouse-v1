<%@ Page Title="" Language="C#" MasterPageFile="~/Warehouse.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="Warehouse.CategoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1>Categories</h1>
        <hr />
        <div class="card">
            <!-- Default panel contents -->
            <div class="card-header bg-info text-white">All Categories</div>

            <asp:Repeater ID="rptrCategory" runat="server">
                <HeaderTemplate>
                    <table class="card-table table">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Index</th>
                                <th>Start</th>
                                <th>End</th>
                                <th>Maintain</th>
                                <th>Repair</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("CategoryName") %></th>
                        <td><%# Eval("CategoryIndex") %></td>
                        <td><%# Eval("StartTime") %></td>
                        <td><%# Eval("EndTime") %></td>
                        <td><%# Eval("MaintainMoney") %></td>
                        <td><%# Eval("RepairMoney") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Label ID="NoCategoryData" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
</asp:Content>
