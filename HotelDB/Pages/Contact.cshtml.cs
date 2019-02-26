using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace HotelDB.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }
        public string customerInformationEntry;
        public string[] dataInArray;

        public void OnGet()
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=Hotel;Uid=root;Pwd=rootuser;");
            customerInformationEntry = Request.QueryString.Value;

            if (customerInformationEntry == null)
            {
                Message = "Information NULL. NO ACTION TAKEN!";
            }
            else
            {

                Message = "Data deleted from SQL Server!";

                dataInArray = new string[9];
                dataInArray = customerInformationEntry.Split("&");

                string Data = "";
                foreach (string item in dataInArray)
                {
                    Data = Data + "," + item.Split("=")[1];
                }

                dataInArray = new string[10];
                dataInArray = Data.Split(",");

            }

            connection.Open();

            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;

            mySqlCommand.CommandText = "delete from Room where customerID = '" + dataInArray[1] + "'";
            mySqlCommand.ExecuteNonQuery();
            mySqlCommand.CommandText = "delete from Transaction where customerID = '" + dataInArray[1] + "'";
            mySqlCommand.ExecuteNonQuery();
            mySqlCommand.CommandText = "delete from Invoice where customerID = '" + dataInArray[1] + "'";
            mySqlCommand.ExecuteNonQuery();
            mySqlCommand.CommandText = "delete from Customer where customerID = '" + dataInArray[1] + "'";
            mySqlCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
