<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainHeadline" Runat="Server">
    לכניסה
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <form method="post" action="Login.aspx">		
			
			<p class="inputName">שם משתמש:</p>
			<input type="text"id = "userName" name = "userName"/>
			
			<p class="inputName">סיסמא:</p>
			<input type="Password" id = "pswd" name = "pswd"/>
	
			<input type="submit"/>
			
	</form>
	<h2><%=str%></h2>
</asp:Content>

