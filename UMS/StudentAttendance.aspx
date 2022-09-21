<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentAttendance.aspx.cs" Inherits="UMS.StudentAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
        <br />
       <strong><h2>ATTENDANCE</h2></strong></center>
     
      <div class="center">
          <asp:Label ID="Error_no_course" runat="server" Text="Student must be registered in at least ONE course to view attendance" ForeColor="Red" ></asp:Label>

      </div>
    <div>
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
                    <ItemTemplate >
                        <asp:RadioButton runat="server"   ID="AttendanceSelected" AutoPostBack="true" OnCheckedChanged="AttendanceSelected_CheckedChanged"/>
                    </ItemTemplate>
                </asp:TemplateField>

                        </Columns>
            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>
      </div>    



    <br />
       <div class="center">
        <asp:Label ID="lblErrorMessage" runat="server" Text="Attendance of this course is yet to be updated" ForeColor="Red" ></asp:Label>
    </div>    
    <div>
        <asp:GridView ID="StudentDetails" Caption="ATTENDANCE OF THIS COURSE" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
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



   
    </div>

    <div class="center">
        <br />
        <asp:Label ID="AttendPercentage" runat="server"  BorderColor="#0000ff" BorderStyle="Dotted" BackColor="#33ccff" ForeColor="white"  Font-Size="Large"></asp:Label>

    </div>


    <br />
    <br />
    <br />
    <br />
    <br />
    

</asp:Content>
