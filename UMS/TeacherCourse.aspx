<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherCourse.aspx.cs" Inherits="UMS.TeacherCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
    <strong><center>
        <br />
        Currently Teaching</center></strong>
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
    
    


     <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"  CellPadding="5"  CellSpacing="0" >
           
            <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                <asp:GridView ID="StudentDetails" Caption="ATTENDANCE OF THIS COURSE" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"  >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="regno" HeaderText="Student Registration#" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="date" HeaderText="Date"  DataFormatString="{0:d}">
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="status" HeaderText="Status" >
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
            </Columns>
             
<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>
                
                </asp:TableCell>
                  <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                   
         <asp:GridView ID="AttendanceGrid" Caption="Percentage Attendance of Students" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Justify" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="regno" HeaderText="Student Registration#" >
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px"  HeaderText="Percentage"  DataFormatString="{0:d}">
                        <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
     
                
               
            </Columns>
             
<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>




    
    

   


   
   <div class="center">
      


              <br />
        <br />  <br />
        <br />  <br />
        <br />
        <br />
             </div>

    
    <br />
        <br />
    




</asp:Content>
