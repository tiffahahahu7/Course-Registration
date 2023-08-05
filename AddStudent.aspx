<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <title>Student Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="display-4 text-center pt-5 fw-bold">Students</h1>
            <div class="row p-5 d-flex align-items-center">
                <div class="col-md-6 form-group mb-3">
                    <label for="txtName" class="form-label fw-bold">Student Name:</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" EnableClientScript="true" CssClass="text-danger">Name is required!</asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group mb-3">
                    <label for="ddlType" class="form-label fw-bold">Student Type:</label>
                    <asp:DropDownList ID="ddlType" CssClass="form-select" runat="server">
                        <asp:ListItem Value="">Select...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType" InitialValue="" Display="Dynamic" EnableClientScript="true" CssClass="text-danger">Student type is required!</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="AddButton_Clicked"/>  
                </div>
            </div>
            <div class="row px-5">
                <div class="col">
                    <asp:Table ID="tblStudents" CssClass="table table-bordered table-primary table-striped" runat="server"></asp:Table>
                </div>
            </div>
            <div class="row px-5 mt-2">
                <div class="col">
                    <a href="RegisterCourse.aspx" class="btn btn-outline-primary">Go to Register Courses</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
