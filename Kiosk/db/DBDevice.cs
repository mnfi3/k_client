using Kiosk.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.db
{
    class DBDevice:DBModel
    {

        public bool isLoggedIn()
        {
            bool isLoggedIn = false;
            SqlDataReader dataReader = db.select("select * from device");
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    isLoggedIn = true;
                }
            }
            db.close();
            return isLoggedIn;
        }



        public Device getDevice()
        {
            Device device = new Device();
            SqlDataReader dataReader = db.select("select top 1 * from device");

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    int columnIndex;
                    columnIndex = dataReader.GetOrdinal("id");
                    device.id = dataReader.GetInt32(columnIndex) ;
                    columnIndex = dataReader.GetOrdinal("user_name");
                    device.user_name = dataReader.GetString(columnIndex);
                    columnIndex = dataReader.GetOrdinal("name");
                    device.name = dataReader.GetString(columnIndex);
                    columnIndex = dataReader.GetOrdinal("token");
                    device.token = dataReader.GetString(columnIndex);
                    columnIndex = dataReader.GetOrdinal("client_key");
                    device.client_key = dataReader.GetString(columnIndex);
                    break;
                }
            }

            db.close();
            return device;
        }

        public int saveDevice(int id, string user_name, string name, string token, string client_key)
        {
            db.delete("delete from device");

            values.Clear();
            values.Add("@id", id.ToString());
            values.Add("@user_name", user_name);
            values.Add("@name", name);
            values.Add("@token", token);
            values.Add("@client_key", client_key);
            return db.insert("insert into device (id,user_name,name,token,client_key) values (@id, @user_name, @name, @token, @client_key)", values);
        }


        public int logoutDevice()
        {
            return db.delete("delete from device");
        }


        
    }
}
