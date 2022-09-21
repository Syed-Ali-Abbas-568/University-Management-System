<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UMS.login" %>
<!DOCTYPE html>
<html>
<head>
    <link href="ButtonSheet1.css" rel="stylesheet" />
<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}

input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}





.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}

img.avatar {
  width: 40%;
  border-radius: 50%;
}

.container {
  padding: 16px;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
  
}

</style>
</head>
<body>

<center><h1>UMS LOGIN FORM</h1></center>

    <form id="form1" runat="server">
  <div class="imgcontainer">
      
      
      <img src="Images/kindpng_7554518.png" alt="Avatar" class="avatar"/>
  </div>

  <div class="container" id="login">
      <label for="uname"><b>Registration Number</b></label>
      <br />
         <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
      <br />
      <label for="psw"><b>Password</b></label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

    <div>
        
        <h3>Please select your account type:</h3>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Student" Checked="True" GroupName="Account_type" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Teacher" GroupName="Account_type" />  
        <asp:RadioButton ID="RadioButton3" runat="server" Text="Director" GroupName="Account_type" />
        
        
        
        
        
    
         
    </div>
      <div class="center">
      <asp:Button ID="Button1" runat="server" Text="LOGIN" Height="51px" Width="918px" BorderStyle="Groove"  CssClass="button button2" OnClick="btnLogin_Click" />
        </div>
          <br />
        <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>
        
      
      
      <br />
      
      
  </div>

    </form>

</body>
</html>

























<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
    <style>
        body{
            background-color:lightblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="margin:auto;border:5px solid white">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>--%>