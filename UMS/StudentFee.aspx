<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="StudentFee.aspx.cs" Inherits="UMS.StudentFee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <br />
    <br />
    <div class="center">



        <h3><strong>Fee Challan</strong></h3>
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid"  CellPadding="5"  CellSpacing="0" >
            <asp:TableHeaderRow  BackColor="LightBlue">
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                   #of Courses Registered
                </asp:TableHeaderCell>
                <asp:TableHeaderCell BorderColor="Black" BorderStyle="Solid">
                   Fee Per Course/Rs.
                </asp:TableHeaderCell>
                <asp:TableHeaderCell  BorderColor="Black" BorderStyle="Solid">
                   Total Fee Payable/Rs.
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow BorderColor="Black" BorderStyle="Solid">
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Num_of_couses" runat="server"></asp:Label>

                </asp:TableCell>
                <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    7500Rs.

                </asp:TableCell>
                 <asp:TableCell BorderColor="Black" BackColor="White" BorderStyle="Solid">
                    <asp:Label ID="Total_Payable" runat="server"></asp:Label>

               </asp:TableCell>

            </asp:TableRow>

        </asp:Table>




    </div>
    <br />
    <br />
</asp:Content>
