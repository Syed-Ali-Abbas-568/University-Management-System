<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherTranscript.aspx.cs" Inherits="UMS.TeacherTranscript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    Add transcript 
    Courses     click
    select Student
    edit transcrip 
    and submit--%>
    <div class="center">
    <h2><strong><center>Add Student Transcript</center>
        </strong>
    
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
    <div class="center">
        <br />
        <asp:Label ID="Error_2" runat="server" Text="Attendance is yet to be added for this course" ForeColor="Red" ></asp:Label>
        <br />    
    </div>


<%--    Student displayed Grid--%>

    <div class ="center">
        <asp:GridView ID="TransGrid" Caption="Select Student To View Transcript Of Student" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
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
               
     
                
                <asp:TemplateField AccessibleHeaderText="Select Student" ItemStyle-HorizontalAlign="center" >
                    <HeaderTemplate>
                       Select Student

                    </HeaderTemplate>

                    <ItemTemplate>
                        
                       <asp:RadioButton ID="GetTranscript" runat="server"  AutoPostBack="true" OnCheckedChanged="GetTranscript_CheckedChanged"/>
                    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>

        <asp:Label ID="Error_3" runat="server"  ForeColor="Red" ></asp:Label>

        <br />



        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"  CellPadding="5"  CellSpacing="0" >
            <asp:TableHeaderRow  BackColor="LightBlue">
                
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                  Enter Obtained Marks
                </asp:TableHeaderCell>
                   <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                  Enter Total Marks
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                    <asp:TextBox ID="Obtained_Marks" runat="server"  ></asp:TextBox>
                </asp:TableCell>
                  <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid" HorizontalAlign="Center">
                    <asp:TextBox ID="Total_Marks" runat="server"  ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

        <br />
        <br />

        <asp:Button ID="Submit" runat="server" Text="Add" CssClass="button button2" OnClick="Submit_Click" />
        <br />
           
    <asp:GridView ID="Transcript_Table" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" HorizontalAlign="Center" >
            <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="courseid" HeaderText="CourseID" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>
                                 <asp:BoundField ItemStyle-Width="150px" DataField="regno" HeaderText="RegistrationNumber" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="150px" DataField="obtainedmarks" HeaderText="ObtainedMarks" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="totalMarks" HeaderText="TotalMarks" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>

                    <asp:BoundField ItemStyle-Width="150px"  HeaderText="Grade Given" >
            <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundField>



                        </Columns>
            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        <RowStyle BackColor="#A1DCF2"></RowStyle>
        </asp:GridView>

        <br />
        <br />
        <br />
        <br />

        </div>
</asp:Content>
