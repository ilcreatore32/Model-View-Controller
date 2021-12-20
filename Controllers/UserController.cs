using Microsoft.AspNetCore.Mvc;
using MVC.Models.DB;
using System.Web;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            using (MVCContext db = new())
            {
                var users = db.Users.ToList();
                ViewData["Users"] = users;
                return View();
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            using (MVCContext db = new())
            {
                var users = db.Users.ToList();
                var user = users.FirstOrDefault(u => u.Id == Id);
                return View(user);
            }
        }

        public ActionResult postUser(
            string name,
            string nickname,
            string email,
            int phone,
            string date,
            string location
            )
        {
            try
            {
                User user = new()
                {
                    Name = name,
                    Nickname = nickname,
                    Email = email,
                    Phone = phone,
                    Date = date,
                    Location = location,
                    IdState = 1
                };
                using (MVCContext db = new())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Content("1");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error, " + ex.Message);
            }
        }
        public ActionResult putUser(
            int id,
            string name,
            string nickname,
            string email,
            int phone,
            string date,
            string location,
            int state
            )
        {
            try
            {
                using (MVCContext db = new())
                {
                    User user = db.Users.FirstOrDefault(u => u.Id == id);
                    user.Name = name;
                    user.Nickname = nickname;
                    user.Email = email;
                    user.Phone = phone;
                    user.Date = date;
                    user.Location = location;
                    user.IdState = state;
                    db.SaveChanges();
                    return Content("1");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error, " + ex.Message);
            }
        }
        public IActionResult nuevo()
        {
            return View();
        }
    }

}