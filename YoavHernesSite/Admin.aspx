<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainHeadline" Runat="Server">
    דף מנהלים 
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <p>
        טבלת משתמשים
    </p>
    <%=str %>
</asp:Content>

