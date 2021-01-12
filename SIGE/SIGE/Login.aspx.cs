using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security;

namespace SIGE.Models
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateUser(string userName, string passWord)
        {
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
                // Consult with your SQL Server administrator for an appropriate connection
                // string to use to connect to your local SQL Server.
                
                cn.Open();

                // Create SqlCommand to select pwd field from users table given supplied userName.
                string strSql = "SELECT COUNT(*) FROM users WHERE username=' " + txtusuario + "' AND password=' " + txtpassword + "'";
                SqlCommand command = new SqlCommand(strSql, cn);
                
                // Execute command and fetch pwd field into lookupPassword string.
                lookupPassword = (string)command.ExecuteScalar();

                // Cleanup command and connection objects.
                command.Dispose();
                cn.Dispose();
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, passWord, false));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtusuario.Text;
            string pass = txtpassword.Text;

            ValidateUser(user,pass);

           /* if((null == user) || (0 == user.Length) || (null == pass) || (0 ==pass.Length))
            {
                string script = "alert('Debe ingresar usuario y contraseña');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnLogin, this.GetType(), "Test", script, true);
            }
            else
            {
                try
                {
                    cn.Open();
                    string strSql = "SELECT COUNT(*) FROM users WHERE username=' " + txtusuario + "' AND password=' " + txtpassword + "'";
                    SqlCommand command = new SqlCommand(strSql, cn);                    
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    cn.Close();
                }
                catch(Exception error)
                {
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + error.Message);
                }
            }


            */
        }
    }
}