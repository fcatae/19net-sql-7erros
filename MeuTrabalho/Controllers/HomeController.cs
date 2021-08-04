using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using MeuTrabalho.Repositories;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About([FromQuery]string teste = "")
        {
            using (SqlConnection connection = new SqlConnection("Server=martedb.database.windows.net;Database=sql7;User=app;Connection Timeout=3;Password=homework-ago21;Max Pool Size=2"))
            {
                LogRepository logRepository = new LogRepository("Server=martedb.database.windows.net;Database=sql7;User=app;Connection Timeout=3;Password=homework-ago21;Max Pool Size=2");

                connection.Open();

                if (teste == "")
                {
                    teste = logRepository.TotalRegistros().ToString();
                }

                ViewData["Message"] = "Total de acessos: " + teste;

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", connection);
                sql.ExecuteNonQuery();

                return View();
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            using (SqlConnection conn1 = new SqlConnection("Server=martedb.database.windows.net;Database=sql7;User=app;Connection Timeout=3;Password=homework-ago21;Max Pool Size=2"))
            {
                conn1.Open();

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')", conn1);
                sql.ExecuteNonQuery();

                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
