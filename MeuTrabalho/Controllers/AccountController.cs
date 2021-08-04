using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=sql8;Integrated Security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand($"SELECT username FROM tbLogin WHERE email=@email AND pwd=@pwd", connection);
                cmd.Parameters.AddWithValue("@email", model.Email);
                cmd.Parameters.AddWithValue("@pwd", model.Password);

                connection.Open();

                object retorno = cmd.ExecuteScalar();

                if (retorno != null)
                {
                    string username = retorno.ToString();
                    return Redirect($"/Home/Dashboard?name={username}");
                }
                else
                {
                    return View();
                }
            }

        }
    }
}
