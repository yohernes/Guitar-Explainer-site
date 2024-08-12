<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainHeadline" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
	<a>
		כשאתה נרשם אתה נותן לנו פרטים עליך כדי שנוכל להתאים לך את חווית המשתמש בצורה הטובה ביותר😇 (אין לנו שום מטרות זדוניות)
	</a>

<form action="Registration.aspx" method="post">		
				
	<p class = "inputName">שם פרטי:</p>
<input type="text" id = "firstName" name = "firstName"value="<%=firstName %>"/><br/>
			
	<p class="inputName">שם משפחה:</p>
	<input type="text"id = "lastName" name = "lastName"value="<%=lastName %>"/><br/>
			
	<p class="inputName">שם משתמש:</p>
	<input type="text"id = "userName" name = "userName"value="<%=userName %>"/><br/>
			
	<p class="inputName">סיסמה:</p>
	<input type="Password"id = "pswd" name = "pswd"/><br/>
			
	<p class="inputName"> אימות סיסמה:</p>
	<input type="Password"id = "pswdValidate" name = "pswdValidate"/><br/> 
			
	<p class="inputName">ת"ז:</p>
	<input type="text"id = "idNum" name = "idNum"value="<%=idNum %>"/><br/>

	<p class="inputName">טלפון:</p>
	<input type="text"id = "phone" name = "phone"value="<%=phone %>"/><br/>

	<p class="inputName">דוא"ל:</p>
	<input type="text"id = "mail" name = "mail"value="<%=mail %>"/><br/>
			
	<p class="inputName">מין:</p>
	<input type="radio" id = "genderMale" name = "gender" value="male"/>זכר<br/>
	<input type="radio"id = "genderFemale" name = "gender" value="female"/>נקבה<br/>
	<input type="radio"id = "genderOther" name = "gender" value="other"/>אחר<br/>
			
	<input type="checkbox" id = "approval" name = "approval" value="approve"/> 	<a class="inputName">אני מאשר\ת את </a> 
 	<a href =" Takanon.aspx"> תקנון האתר</a>
<br/>

	<input type="submit"/>
			
</form>
	<%=data %>
</asp:Content>

