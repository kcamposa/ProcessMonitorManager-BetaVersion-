using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace webapp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           job();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            job();
        }
        public void job()
        {
            //allMachines_();
            //notconnected();
            //connected();
        }
        //public void allMachines_()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
        //    SqlCommand cmd = new SqlCommand("SELECT [computerName] as 'Nombre equipo', [computerStatus] as 'Estado' FROM [dbo].[Computers];", con);
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    ad.Fill(dt);
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    con.Close();
        //}

        //public void connected()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM [Computers] WHERE [computerStatus] <> '0';", con);
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    ad.Fill(dt);
        //    GridView2.DataSource = dt;
        //    GridView2.DataBind();
        //    con.Close();
        //}

        //public void notconnected()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM [Computers] WHERE [computerStatus] <> '1';", con);
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    ad.Fill(dt);
        //    GridView3.DataSource = dt;
        //    GridView3.DataBind();
        //    con.Close();
        //}



        //**************************************************
    }
}