using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace HW
{
    public class DB
    {
        public static string GetAllBillingsHTML()
        {
            string htmlStr = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "SELECT UserName,BillingInfo,BillingKey FROM [Table]";
            using (SqlConnection conn = new SqlConnection(constr))
            {

                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string Name = reader[0].ToString();
                    string CryptedBI = reader[1].ToString();
                    string key = reader[2].ToString();

                    string BK = Crypt.RsaDecrypt(key);
                    string BillingInfo = Crypt.AesDecrypt(CryptedBI, BK);
                    htmlStr += "<tr><td>" + Name + "</td><td>"  + BillingInfo + "</td></tr>";
                }

                conn.Close();
            }
            return htmlStr;
        }
        public static string GetInfo(string username, string pass)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "SELECT UserInfo,N,salt2 FROM [Table] WHERE UserName = @name";
            using (SqlConnection conn = new SqlConnection(constr))
            {

                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", username);

                reader = cmd.ExecuteReader();
                reader.Read();

                string EncryptedInfo = reader[0].ToString();
                if (EncryptedInfo == "") 
                {
                    conn.Close();
                    return EncryptedInfo;
                }
                  
                int N = Convert.ToInt32(reader[1]);
                string salt2 = reader[2].ToString();

                string key = pass + salt2;
                for (int i = 0; i < N; i++)
                {
                    key = Crypt.GetHash(key);
                }
                string text  = Crypt.AesDecrypt(EncryptedInfo, key);
                conn.Close();

                return text;
            }
        }
        public static void ChangeInfo(string username, string pass, string text)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sqlget = "SELECT N,salt2 FROM [Table] WHERE UserName = @name";
            string sqlset = "UPDATE [Table] SET UserInfo = @info WHERE UserName = @name";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(sqlget, conn);

                cmd.Parameters.AddWithValue("@name", username);

                reader = cmd.ExecuteReader();
                reader.Read();

                int N = Convert.ToInt32(reader[0]);
                string salt2 = reader[1].ToString();
                conn.Close();
                string key = pass + salt2;
                for (int i = 0; i < N; i++)
                {
                    key = Crypt.GetHash(key);
                }
                string encryptedtext = Crypt.AesEncrypt(text, key);

                conn.Open();
                cmd = new SqlCommand(sqlset, conn);

                cmd.Parameters.AddWithValue("@name", username);

                cmd.Parameters.AddWithValue("@info", encryptedtext);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        public static void ChangePass(string username, string pass)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "UPDATE [Table] SET Password = @pass,salt1 = @s1 WHERE UserName = @name";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    string Salt1 = Crypt.GenerateSalt();

                    cmd.Parameters.AddWithValue("@name", username);

                    cmd.Parameters.AddWithValue("@pass", Crypt.GetHash(pass + Salt1));

                    cmd.Parameters.AddWithValue("@s1", Salt1);

                    cmd.ExecuteNonQuery();

                    conn.Close();
            }
        }
        public static bool UserExists(string username)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "SELECT id FROM [Table] WHERE UserName = @name";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", username);
                    return (cmd.ExecuteScalar() != null);
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }

        public static bool CreateUser(string username, string pass, int n, string BI)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "insert into [Table](UserName,Password,salt1,salt2,N,BillingInfo,BillingKey)"+
                " values (@name,@pass,@s1,@s2,@n,@BI,@BK)";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    string Salt1 = Crypt.GenerateSalt();
                    string Salt2 = Crypt.GenerateSalt();
                    string BK = Crypt.GenerateSalt();

                    string Key = Crypt.RsaEncrypt(BK);
                    string BillingInfo = Crypt.AesEncrypt(BI, BK);

                    cmd.Parameters.AddWithValue("@name", username);

                    cmd.Parameters.AddWithValue("@pass", Crypt.GetHash(pass + Salt1));

                    cmd.Parameters.AddWithValue("@s1", Salt1);

                    cmd.Parameters.AddWithValue("@s2", Salt2);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@BI", BillingInfo);

                    cmd.Parameters.AddWithValue("@BK", Key);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }

        public static bool IsValid(string username, string pass)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string sql = "SELECT Password,salt1 FROM [Table] WHERE UserName = @name";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", username);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    string checkpass = reader[0].ToString();
                    string checksalt = reader[1].ToString();

                    string cmp = Crypt.GetHash(pass + checksalt);

                    return cmp == checkpass;
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                return false;
            }
        }
    }
}