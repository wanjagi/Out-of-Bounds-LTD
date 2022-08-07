using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using customerwebservice;

public partial class ProjectDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ShowProjectDetails()
    {
        if (Session["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Service service = new Service();

            Project[] projects = service.GetListOfProjects((int)Session["id"]);

            for (int i = 0;i < projects.Length; i++)
            {
                Project p = projects[i];
                Response.Write("<p>Project: <b>" + p.Name + "</br><br>");
                Task[] tasks = p.Tasks;
                for (int j = 0; j < tasks.Length; j++)
                {
                    Task t = tasks[j];
                    Response.Write("Task: <i>" + t.Name + " - " + t.theStatus + "</i><br>");
                }
                Response.Write("</p>");
            }
        }
    }
}