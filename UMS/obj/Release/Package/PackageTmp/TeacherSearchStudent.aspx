<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherSearchStudent.aspx.cs" Inherits="UMS.TeacherSearchStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="center">
   <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"  CellPadding="5"  CellSpacing="0" >
            <asp:TableHeaderRow  BackColor="LightBlue">
                
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                  Enter Student Registration Number
                </asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
            <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                    <asp:TextBox ID="StudentRegNo" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                
            </asp:TableRow>

        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button button2" OnClick="Button1_Click" />
    </div>

    <div class="center">
        <br />
         <asp:Label ID="Error_1" runat="server" Text="No such student found" ForeColor="Red" ></asp:Label>
        <br />

         <h3>

         <asp:Label ID="BasicInfo" runat="server" Text="Basic Info Student" ForeColor="Black" ></asp:Label>
        </h3>
        <br />
        

    <asp:GridView ID="StudentDetails" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="regno" HeaderText="Registration#" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="name" HeaderText="Name" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="DOB" HeaderText="DOB"  DataFormatString="{0:d}">
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="email" HeaderText="Email" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="phoneno" HeaderText="Phone#" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="cnic" HeaderText="CNIC" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="gender" HeaderText="Gender" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="deptno" HeaderText="Department" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>

    



        </div>

    <br />
<br />
<br />




</asp:Content>
