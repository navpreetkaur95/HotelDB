using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelDB.Pages
{
    public class PrivacyModel : PageModel
    {
        public string Message { get; set; }

        MySqlConnection connection = new MySqlConnection(@"Server=localhost;Database=Hotel;Uid=root;Pwd=rootuser;");
        String html;

        public void OnGet()
        {
            showData();
        }

        public void showData()
        {
            connection.Open();

            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;

            mySqlCommand.CommandText = "select * from Room;";
            mySqlCommand.ExecuteNonQuery();

            MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                string Name = dataReader.GetString(1);
                string Pass = dataReader.GetString(2);
                html += "<tr><td>" + id + "</td><td>" + Name + "</td><td>" + Pass + "</td></tr>";
            }

            connection.Close();
            Message = html;
        }
    }
}