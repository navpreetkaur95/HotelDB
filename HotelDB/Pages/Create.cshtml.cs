using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;


namespace HotelDB.Pages
{
    public class CreateModel : PageModel
    {
        public string Message { get; set; }
        public string customerInformationEntry;
        public string[] dataInArray;

        public string customerID;
        public string Name;
        public string City;
        public string roomNumber;
        public string amount;
        public string paymentMethod;
        public string paymentStatus;
        public string days;
        public string verified;

        MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=Hotel;Uid=root;Pwd=rootuser;");

        public void OnGet()
        {

            customerInformationEntry = Request.QueryString.Value;

            if (customerInformationEntry == null)
            {
                Message = "Information NULL. NO ACTION TAKEN!";
            }
            else
            {

                Message = "Data created on SQL Server!";

                dataInArray = new string[9];
                dataInArray = customerInformationEntry.Split("&");

                string Data = "";
                foreach (string item in dataInArray)
                {
                    Data = Data + "," + item.Split("=")[1];
                }

                dataInArray = new string[10];
                dataInArray = Data.Split(",");

                customerID = dataInArray[1];
                Name = dataInArray[2];
                City = dataInArray[3];
                roomNumber = dataInArray[4];
                days = dataInArray[5];
                amount = dataInArray[6];
                paymentMethod = dataInArray[7];
                paymentStatus = dataInArray[8];
                verified = dataInArray[9];
                try
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = connection.CreateCommand();
                    mySqlCommand.CommandType = CommandType.Text;

                    mySqlCommand.CommandText = "insert into Customer values ('" + customerID + "','" + Name + "','" + City + "')";
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand.CommandText = "insert into Room values ('" + customerID + "','" + roomNumber + "')";
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand.CommandText = "insert into Transaction values ('" + customerID + "','" + amount + "','" + paymentMethod + "','" + paymentStatus + "')";
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand.CommandText = "insert into Invoice values ('" + customerID + "','" + days + "','" + roomNumber + "','" + verified + "')";
                    mySqlCommand.ExecuteNonQuery();

                    connection.Close();

                }
                catch(Exception e)
                {
                }

            }
        }
    }
}
