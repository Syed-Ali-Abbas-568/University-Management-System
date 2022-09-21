<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentCourse.aspx.cs" Inherits="UMS.StudentCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <h3><strong>COURSES ALREADY REGISTERED</strong></h3>
        <asp:Label ID="lblErrorMessage" runat="server" Text="STUDENT IS NOT REGISTERED IN ANY COURSES" ForeColor="Red" ></asp:Label>
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
                        </Columns>
            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>
      </div>

    <div class="center">
        <br />
                                <h3><strong>Course Available </strong></h3>
        <asp:GridView ID="CoursesAvailable" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center"  >
            <Columns>
                <asp:TemplateField AccessibleHeaderText="Select">
                    <HeaderTemplate>
                       Select

                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="Insert_Course" runat="server" OnCheckedChanged="Insert_Course_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>



                            <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="150px" DataField="Coursename" HeaderText="CourseName" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>

        <div class="center">
        <asp:Label ID="ERROR_LABEL1" runat="server" Text="STUDENT CANNOT REGISTER IN MORE THAN 5 COURSES" ForeColor="Red" ></asp:Label>

            <br />

        <asp:Button ID="Submit" CssClass="button button1" runat="server" Text="Register" OnClick="Submit_Click" />
         </div>
        <br />
        <br />
        <br />

    </div>

</asp:Content>
