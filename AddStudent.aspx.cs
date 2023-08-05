using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        private List<string> types = new List<string>()
        {
            "Full Time",
            "Part Time",
            "Coop"
        };

        List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            }
            else
            {
                students = new List<Student>();
            }
            Display_Students();

            if (!IsPostBack)
            {
                foreach (string type in types)
                {
                    ddlType.Items.Add(new ListItem(type));
                }
            }
        }
        protected void AddButton_Clicked(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                switch (ddlType.SelectedValue)
                {
                    case "Full Time":
                        students.Add(new FulltimeStudent(txtName.Text));
                        break;
                    case "Part Time":
                        students.Add(new ParttimeStudent(txtName.Text));
                        break;
                    case "Coop":
                        students.Add(new CoopStudent(txtName.Text));
                        break;
                }
                Session["students"] = students;
                Reset();
                Display_Students();
            }
        }

        protected void Display_Students()
        {
            tblStudents.Rows.Clear();

            TableHeaderRow tableHeaderRow = new TableHeaderRow();
            TableHeaderCell idHeaderCell = new TableHeaderCell();
            idHeaderCell.Text = "ID";
            TableHeaderCell nameHeaderCell = new TableHeaderCell();
            nameHeaderCell.Text = "Name";
            tableHeaderRow.Cells.Add(idHeaderCell);
            tableHeaderRow.Cells.Add(nameHeaderCell);
            tblStudents.Rows.Add(tableHeaderRow);

            if (students.Count == 0)
            {
                TableRow row = new TableRow();
                TableCell idCell = new TableCell();
                TableCell nameCell = new TableCell();
                nameCell.Text = "No Student Yet!";
                nameCell.CssClass = "text-danger";

                row.Cells.Add(idCell);
                row.Cells.Add(nameCell);
                tblStudents.Rows.Add(row);
            } else
            {
                foreach (Student student in students)
                {
                    TableRow row = new TableRow();

                    TableCell idCell = new TableCell();
                    idCell.Text = student.Id.ToString();

                    TableCell nameCell = new TableCell();
                    nameCell.Text = student.Name;

                    row.Cells.Add(idCell);
                    row.Cells.Add(nameCell);
                    tblStudents.Rows.Add(row);
                }
            }
        }
        protected void Reset()
        {
            txtName.Text = string.Empty;
            ddlType.SelectedIndex = 0;
        }
    }
}