using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.db
{
    class DB
    {

        private string connetionString = null;
        private SqlConnection connection = null;
        private SqlCommand command = null;


        public DB()
        {
            connetionString = "server=localhost;database=Kiosk;Integrated Security=true;";
            connection = new SqlConnection(connetionString);
        }

       

        public  SqlDataReader select(string query, Dictionary<string,string> values = null)
        {
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        command.Parameters.AddWithValue(key, values[key]);
                    }
                }
                SqlDataReader dataReader = command.ExecuteReader();
                return dataReader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public int insert(string query, Dictionary<string, string> values = null)
        {
            int affected = 0;
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        if (values[key] != null)
                        {
                            command.Parameters.AddWithValue(key, values[key]);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(key, "");
                        }
                    }
                }
                affected = command.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return affected;
        }


        public int update(string query, Dictionary<string, string> values = null)
        {
            int affected = 0;
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        command.Parameters.AddWithValue(key, values[key]);
                    }
                }
                affected = command.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return affected;
        }



        public int delete(string query, Dictionary<string, string> values = null)
        {
            int affected = 0;
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        command.Parameters.AddWithValue(key, values[key]);
                    }
                }
                affected = command.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return affected;
        }






        public void close()
        {
            if (command != null)
            {
                command.Dispose();
                connection.Close();
            }
        }



        
    }
}
