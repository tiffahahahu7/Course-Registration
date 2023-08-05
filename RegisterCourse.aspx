<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="App_Themes/Style.css" />
    <title>Course Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="display-4 text-center pt-5 fw-bold">Registrations</h1>
            <div class="row p-5 d-flex align-items-center">
                <div class="form-group mb-3">
                    <label for="ddlStudent" class="form-label fw-bold">Student:</label>
                    <asp:DropDownList ID="ddlStudent" CssClass="form-select" runat="server" OnSelectedIndexChanged="Student_Selected" AutoPostBack="true">
                        <asp:ListItem Value="">Select...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStudent" runat="server" ControlToValidate="ddlStudent" InitialValue="" Display="Dynamic" EnableClientScript="true" CssClass="text-danger">Must select a student!</asp:RequiredFieldValidator>
                </div>
                <asp:Panel ID="pnlSummary" runat="server" Visible="false" CssClass="mb-3">
                    <asp:Label ID="lblSummary" runat="server" Text="" CssClass="text-primary h5"></asp:Label>
                </asp:Panel>
                <div class="mb-3">
                    <p class="lead">Following courses are currently available for registration</p>
                    <asp:Panel ID="pnlAlert" runat="server" Visible="false" CssClass="mb-3">
                        <asp:Label ID="lblAlert" runat="server" Text="" CssClass="text-danger h5"></asp:Label>
                    </asp:Panel>
                    <asp:CheckBoxList ID="cblCourse" runat="server" RepeatLayout="Flow" CssClass="form-checkbox-list"></asp:CheckBoxList>
                </div>
                <div>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SaveButton_Clicked"/>  
                </div>
            </div>
            <div class="row px-5 mb-3">
                <div class="col">
                    <a href="AddStudent.aspx" class="btn btn-outline-primary">Back to Add Students</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
