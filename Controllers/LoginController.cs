using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using BSCPEWEB.Models;

namespace BSCPEWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentContext _studentContext;
        public LoginController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Student students)
        {
            bool isSuccess = _studentContext.InsertStudent(students);

            if (ModelState.IsValid)
            {
                if (isSuccess)
                {
                    TempData["SuccessMessage"] = "Form submitted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed";

                }
            }
            return View(students);

        }
    }
}
