using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        List<Student> students;
        List<Course> courses = Helper.GetAvailableCourses();
        

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

            if (!IsPostBack)
            {
                foreach (Student student in students)
                {
                    ddlStudent.Items.Add(new ListItem(student.ToString()));
                }

                foreach(Course course in courses)
                {
                    ListItem listItem = new ListItem($"{course.Code} {course.Title} - {course.WeeklyHours} hours per week");
                    cblCourse.Items.Add(listItem);   
                }
            }
        }

        protected void Student_Selected(object sender, EventArgs e)
        {
            Reset();
            if (ddlStudent.SelectedIndex > 0)
            {
                string selectedId = ddlStudent.SelectedValue.Substring(0, 6);
                Student selectedStudent = students.Find(student => student.Id.ToString() == selectedId);

                if (selectedStudent != null)
                {
                    lblSummary.Text = $"Selected student has registered {selectedStudent.RegisteredCourses.Count()} course(s), {selectedStudent.TotalWeeklyHours(selectedStudent.RegisteredCourses)} hours weekly";
                    pnlSummary.Visible = true;

                    foreach (Course registeredCourse in selectedStudent.RegisteredCourses)
                    {
                        foreach (ListItem course in cblCourse.Items)
                        {
                            if (registeredCourse.Code == course.Value.Substring(0, 7))
                            {
                                course.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    lblSummary.Text = "";
                    pnlSummary.Visible = false;
                }
            } else
            {
                lblSummary.Text = "";
                pnlSummary.Visible = false;
            }
        }

        protected void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (Page.IsValid) { 
                string selectedId = ddlStudent.SelectedValue.Substring(0, 6);
                Student selectedStudent = students.Find(student => student.Id.ToString() == selectedId);
                if (cblCourse.SelectedIndex == -1)
                {
                    lblAlert.Text = "You need select at least one course.";
                    pnlAlert.Visible = true;
                } else
                {
                    lblAlert.Text = "";
                    pnlAlert.Visible = false;
                    try
                    {
                        List<Course> selectedCourses = new List<Course>();
                        foreach (ListItem course in cblCourse.Items)
                        {
                            if (course.Selected)
                            {
                                selectedCourses.Add(Helper.GetCourseByCode(course.Value.Substring(0, 7)));                          
                            }
                        }
                
                        selectedStudent.RegisterCourses(selectedCourses);
                        lblSummary.Text = $"Selected student has registered {selectedStudent.RegisteredCourses.Count()} course(s), {selectedStudent.TotalWeeklyHours(selectedStudent.RegisteredCourses)} hours weekly";
                        pnlSummary.Visible = true;
                        Session["students"] = students;                   
                    } catch (Exception ex)
                    {
                        lblAlert.Text = ex.Message;
                        pnlAlert.Visible = true;
                    }
                }
            }
        }
        protected void Reset()
        {
            foreach (ListItem course in cblCourse.Items)
            {
                course.Selected = false;
            }
            lblAlert.Text = "";
            pnlAlert.Visible = false;
        }
    }
}