<%@ Page Title="" Language="C#" MasterPageFile="~/Director.Master" AutoEventWireup="true" CodeBehind="DirectorTeacher.aspx.cs" Inherits="UMS.TeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <center><h2><strong>List of Teachers in UMS</strong></h2></center>

     <asp:GridView ID="TeacherDetails" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
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
                 
              
                <asp:TemplateField AccessibleHeaderText="Select Student" ItemStyle-HorizontalAlign="center" >
                   <HeaderTemplate>
                       Select Teacher

                    </HeaderTemplate>
                    <ItemTemplate>
                        
                        <asp:CheckBox ID="Mark_Student" runat="server" OnCheckedChanged="Mark_Student_CheckedChanged" />
                    </ItemTemplate>

                                    </asp:TemplateField>
      
                </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>


<%--    Button to remove will come here--%>
    <div class="center">

        <br />
    <asp:Button ID="UnEnroll" CssClass="button button3" runat="server" Text="Remove" style="height: 60px" OnClick="UnEnroll_Click" />
    <br /><br />
         <asp:Table ID="Enroll" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid" Caption="Add New Teacher" CellPadding="5"  CellSpacing="0" >
            <asp:TableHeaderRow  BackColor="LightBlue">
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                   Regno#
                </asp:TableHeaderCell>
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                   Name
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 DOB(MM-D-YEAR)
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                Email
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Phone#
                </asp:TableHeaderCell>
                <%-- <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 CNIC
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Gender
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Department
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Password
                </asp:TableHeaderCell>--%>
            </asp:TableHeaderRow>
           
             <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="RegistrationNumber" runat="server"></asp:Label>
                    <asp:TextBox ID="RegNotxt" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:TextBox ID="Name" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <asp:TextBox ID="DOB" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <asp:TextBox ID="Emailtxt" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    <asp:TextBox ID="Phone" runat="server"  ></asp:TextBox>
               
                        
                

                    </asp:TableCell>


    </asp:TableRow>
              <asp:TableHeaderRow  BackColor="LightBlue">
                   <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 CNIC
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Gender
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Department
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                 Password
                </asp:TableHeaderCell>
                  </asp:TableHeaderRow>

                 




                 <asp:TableRow>


                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    <asp:TextBox ID="CNIC" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    <asp:DropDownList id="Gender" runat="server" >
        <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
                            
                </asp:TableCell>
                    <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    <asp:TextBox ID="Department" runat="server"  ></asp:TextBox>
                </asp:TableCell>
              <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                    <asp:TextBox ID="Password" runat="server"  ></asp:TextBox>
                </asp:TableCell>


            </asp:TableRow>

        </asp:Table>


          <asp:Label ID="Error_1" runat="server"  ForeColor="Red" ></asp:Label>

          <br />
          <br />
    <asp:Button ID="Enroll_Butt" CssClass="button button1" runat="server" Text="Add" style="height: 60px" OnClick="Enroll_Butt_Click" />


    </div>
</asp:Content>
