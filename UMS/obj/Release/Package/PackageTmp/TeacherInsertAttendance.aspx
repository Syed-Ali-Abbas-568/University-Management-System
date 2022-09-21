<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherInsertAttendance.aspx.cs" Inherits="UMS.TeacherInsertAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
  <%--  First we need to display courses with a select button 
    also a title to click a course
    then studnet list with new date 
    and then with drop down list table of attendance
    submit button--%>
    <br />
    <strong><center><h2>Click on a course to Add Attendance</h2></center></strong>

<%--     Error message when no no course is returened --%>
    <div class="center">

    <asp:Label ID="Error_1" runat="server" Text="You are currently not teaching any course" ForeColor="Red" ></asp:Label>
        <br />
        </div>

      <asp:GridView ID="CurrentCourses" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                   </asp:BoundField>
                 <asp:BoundField ItemStyle-Width="150px" DataField="Coursename" HeaderText="CourseName" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                 </asp:BoundField>
                
                <asp:TemplateField AccessibleHeaderText="Select">
                    <HeaderTemplate>
                       Select

                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:RadioButton ID="GetInfo" runat="server"  AutoPostBack="true" OnCheckedChanged="GetInfo_CheckedChanged1"/>
                    </ItemTemplate>
                </asp:TemplateField>



              </Columns>
            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <RowStyle BackColor="#A1DCF2"></RowStyle>
    </asp:GridView>
        <br />

    <div class="center"> 
        <asp:Label ID="Error_2" runat="server" Text="Attendance is yet to be added for this course" ForeColor="Red" ></asp:Label>
     </div>
    
    


    <br />


    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"  CellPadding="5"  CellSpacing="0" >
            <asp:TableHeaderRow  BackColor="LightBlue">
                
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                  Enter Date of New Attendance (Month-Date-Year)
                </asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
            <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                    <asp:TextBox ID="Date_New" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                
            </asp:TableRow>

        </asp:Table>

    <br />  


<div class ="center">
        <asp:GridView ID="AttendanceGrid" Caption="Select Status Of Student" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField ItemStyle-Width="150px" HeaderText="CourseName" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="regno" HeaderText="Student Registration#" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
               
     
                
                <asp:TemplateField AccessibleHeaderText="Select Status" ItemStyle-HorizontalAlign="center" >
                    <HeaderTemplate>
                       Select Status

                    </HeaderTemplate>

                    <ItemTemplate>
                         <asp:DropDownList ID="Status_Att" runat="server">
                            <asp:ListItem Selected="True" Value="P">
                                P
                            </asp:ListItem>
                            <asp:ListItem Value="A">A</asp:ListItem>
                        </asp:DropDownList>
                    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
        <br />
</div>



   

<%--    Option to insert attendance with new date--%>


    <div class="center">
        <asp:Button ID="Add__Attendance_Butt" CssClass="button button4" runat="server" Text="Create New Attendance" OnClick="Add__Attendance_Butt_Click" />
        <br />

           
  


    </div>
        <div class="center"> 
        <asp:Label ID="Success" runat="server" Text="Attendance Inserted Successfully" ForeColor="green" ></asp:Label>
            <asp:Label ID="Failure" runat="server" Text="Error: Attendance Already Exists for this date" ForeColor="red" ></asp:Label>
     </div>
    

</asp:Content>
