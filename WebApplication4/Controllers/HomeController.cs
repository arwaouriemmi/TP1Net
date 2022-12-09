using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using WebApplication4.Models;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Debug.WriteLine("Opening a connetion to the DataBase...");
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\gl3\\framework\\project\\2022 GL3 .NET Framework TP3 - SQLite database.db"))
                {
                    connection.Open();
                    Debug.WriteLine("connetion opened ");
                    string queryString = " SELECT * FROM personal_info;";
                    SQLiteCommand command = new SQLiteCommand(queryString, connection);
                    using (SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                               int id =(int)dataReader["id"];
                                string first_name = (string)dataReader["first_name"];
                                string last_name = (string)dataReader["last_name"];
                                string email = (string)dataReader["email"];
                                //DateTime date_birth = (DateTime)dataReader["date_birth"];
                                string image = (string)dataReader["image"];       
                                string country = (string)dataReader["country"];
                                Debug.WriteLine("id =" + id +" first_name:" + first_name + " last_name :" + last_name + " email :" + email +  " image :" +image +" country :" + country);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("datareader returned 0 rows ");
                        }

                    }
                }


            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught :" + e.Message);
            }
            finally
            {
                Debug.WriteLine("program finished !");
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}