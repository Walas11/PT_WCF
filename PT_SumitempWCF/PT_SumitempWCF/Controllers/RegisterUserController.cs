using Microsoft.AspNetCore.Mvc;
using PT_SumitempWCF.Models;
using PT_SumitempWCF.Services;

namespace PT_SumitempWCF.Controllers
{
    public class RegisterUserController : Controller
    {
        public static RegisterUserService _RegisterUserService;

        public RegisterUserController(RegisterUserService registerUserService)
        {
            _RegisterUserService = registerUserService;
        }


        // GET: RegisterUserController
        public ActionResult Dashboard()
        {
            // Obtener los usuarios desde la base de datos.
            var usuarios = _RegisterUserService.GetUsers();
            return View(usuarios);
        }

        // GET: RegisterUserController/Create
        public ActionResult InsertarUsuario()
        {
            return View();
        }

        // POST: RegisterUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertarUsuario(UserDto user)
        {
            if (ModelState.IsValid)
            {
                var result = _RegisterUserService.CrearUsuario(user);
                if (result)
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    // Agregar un mensaje de error al ModelState
                    ModelState.AddModelError("", "El usuario ya existe.");
                }
            }

            return View(user);
        }

    }
}
