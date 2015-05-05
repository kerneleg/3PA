using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace TPA2
{
    public class ConnectionClass
    {
        private static SqlConnection conn;
        private static SqlCommand command;

        static ConnectionClass()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            conn = new SqlConnection(connectionstring);
            command = new SqlCommand("", conn);
        }

        public static List<KeyValuePair<string, string>> AuthenticateUser(string username, string password)
        {
            //Check if user exist
            command.CommandText = "spAuthenticateUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            try
            {
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", password);

                command.Parameters.Add(paramUsername);
                command.Parameters.Add(paramPassword);

                conn.Open();
                SqlDataReader rdr = command.ExecuteReader();
                var querylist = new List<KeyValuePair<string, string>>();
                while (rdr.Read())
                {

                    string RetryAttempts = Convert.ToString(rdr["RetryAttempts"]);
                    querylist.Add(new KeyValuePair<string, string>("RetryAttempts", RetryAttempts));

                    string AccountLocked = Convert.ToString(rdr["AccountLocked"]);
                    querylist.Add(new KeyValuePair<string, string>("AccountLocked", AccountLocked));

                    string Authenticated = Convert.ToString(rdr["Authenticated"]);
                    querylist.Add(new KeyValuePair<string, string>("Authenticated", Authenticated));

                    if (Authenticated == "1")
                    {
                        string UserType = Convert.ToString(rdr["UserType"]);
                        querylist.Add(new KeyValuePair<string, string>("UserType", UserType));

                        string EmpName = Convert.ToString(rdr["EmpName"]);
                        querylist.Add(new KeyValuePair<string, string>("EmpName", EmpName));
                    }
                }
                rdr.Close();
                conn.Close();

                return querylist;

            }
            catch (Exception e)
            {
                var errorlist = new List<KeyValuePair<string, string>>();
                errorlist.Add(new KeyValuePair<string, string>(e.Message, "-5"));
                return errorlist;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int ResetPassword(string username)
        {
            command.CommandText = "spResetPassword";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            try
            {
                SqlParameter paramUsername = new SqlParameter("@UserName", username);

                command.Parameters.Add(paramUsername);

                conn.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToBoolean(rdr["ReturnCode"]))
                    {
                        ConnectionClass CS = new ConnectionClass();
                        CS.SendPasswordResetEmail(rdr["Email"].ToString(), username, rdr["UniqueId"].ToString());
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                rdr.Close();
                conn.Close();
                return -1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            MailMessage mailMessage = new MailMessage("ahmtalat@gmail.com", ToEmail);

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("http://localhost30873/Registration/ChangePassword.aspx?uid=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Trust Medical</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ahmtalat@gmail.com",
                Password = "xxxxxxxxx"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public static bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();

            foreach (SqlParameter parameter in SPParameters)
            {
                command.Parameters.Add(parameter);
            }

            conn.Open();
            try
            {
                return Convert.ToBoolean(command.ExecuteScalar());
            }
            finally
            {
                conn.Close();
            }
        }

    }
}





