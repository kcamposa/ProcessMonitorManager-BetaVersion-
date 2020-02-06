using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace WS
{
    /// <summary>
    /// Summary description   for IS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IS : System.Web.Services.WebService
    {
        static string name;
        static bool status;

        [WebMethod]
        public void receiveMachines(string machine, bool Statusconnection)
        {
            name = machine;
            status = Statusconnection;
            //search only machine
            bool ver = searchMachine(name);
            if (ver.Equals(true))
            {
                //update status if machine isnt connected
                bool ver1 = searchStatusSame(name, status);
                if (ver1 == false)
                {
                    //update new status to machine
                    updateStatusMachine(name, status);
                }
            }
            else
            {
                //insert if machine isnt created
                insertNewMachine(name, status);
            }
        }

        //insert if machine isnt created
        public bool insertNewMachine(string computerName, bool status)
        {
            int newstatus;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }
            bool insert_;
            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Computers] ([computerName], [computerStatus]) VALUES (@computerName, @newstatus)", con);

            cmd.Parameters.Add("@computerName", SqlDbType.VarChar).Value = computerName;
            cmd.Parameters.Add("@newstatus", SqlDbType.Bit).Value = newstatus;

            int numReg = cmd.ExecuteNonQuery();
            if (numReg > 0)
            {
                insert_ = true;
            }
            else
            {
                insert_ = false;
            }
            con.Close();
            return insert_;
        }

        //update new status to machine
        public bool updateStatusMachine(string computerName, bool status)
        {
            int newstatus;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }

            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            SqlDataAdapter da = new SqlDataAdapter("UPDATE [Computers] SET [computerStatus] = '" + newstatus + "' WHERE [computerName] = '" + computerName + "';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //return ds;
            return true;
        }

        //change status if machine isnt connected
        public bool searchStatusSame(string computerName, bool status)
        {
            int newstatus;
            bool ver = false;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }

            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Computers] WHERE [computerName] = '" + computerName + "';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count == 1)
            {
                int estado = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                if (estado.Equals(newstatus))
                {
                    ver = true;
                }
                else
                {
                    ver = false;
                }
            }
            return ver;
        }

        //search only machine
        public bool searchMachine(string computerName)
        {
            bool ver = false;

            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            SqlDataAdapter da = new SqlDataAdapter("SELECT [computerName] FROM [Computers] WHERE [computerName] = '" + computerName + "';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 1)
            {
                ver = true;
            }
            else
            {
                ver = false;
            }
            return ver;
        }
                     




        //------------------------------------------------------------------------------
        public bool update(string computerName, bool status)
        {
            int newstatus;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }

            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            SqlDataAdapter da = new SqlDataAdapter("UPDATE [Computers] SET [computerStatus] = '" + newstatus + "' WHERE [computerName] = '" + computerName + "';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //return ds;
            return true;
        }

        public bool select(string computerName, bool status)
        {
            int newstatus;
            bool ver = false;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }

            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Computers] WHERE [computerName] = '" + computerName + "' and [computerStatus] = '" + newstatus + "';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count == 1)
            {
                ver = true;
            }
            else
            {
                ver = false;
            }
            return ver;
        }

        public bool insert(string computerName, bool status)
        {
            int newstatus;
            if (status == false)
            {
                newstatus = 0;
            }
            else
            {
                newstatus = 1;
            }
            bool insert_;
            SqlConnection con = new SqlConnection(@"Data Source=SRV-DV-06,1433;Initial Catalog=ODProcesses;User Id=respaldos_hghhhh;Password=Hh8585hhh*");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Computers] ([computerName], [computerStatus]) VALUES (@computerName, @newstatus)", con);

            cmd.Parameters.Add("@computerName", SqlDbType.VarChar).Value = computerName;
            cmd.Parameters.Add("@newstatus", SqlDbType.Bit).Value = newstatus;

            int numReg = cmd.ExecuteNonQuery();
            if (numReg > 0)
            {
                insert_ = true;
            }
            else
            {
                insert_ = false;
            }
            con.Close();
            return insert_;
        }


        //****************************************
    }
}
