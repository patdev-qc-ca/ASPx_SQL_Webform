using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;
/*https://csharp-station.com/Tutorial/AdoDotNet/Lesson03 */
namespace ASPx_SQL_Webform
{
    public partial class ASPxSQLWebform : System.Web.UI.Page
    {
        SqlDataReader reader;
        SqlCommand cmd;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
          con= new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=GRB2023;Integrated Security=True");
          //        SqlConnection con = new SqlConnection("Database=GRB2023;server=Intranet\\SQLEXPRESS;user=sa;password=Password01$;");
            try
            {
                con.Open();
                MessageBox.Show(con.State.ToString());
                cmd = new SqlCommand(@"select distinct employe from GrbEmploye where actif=1 and Supprime=0", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DropDownList1.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally 
            {
                if (reader != null){ reader.Close();}
                if(con != null) {  con.Close(); }   
            }

            con.Close();
        }
    }
}