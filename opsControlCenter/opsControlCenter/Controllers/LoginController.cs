using opsControlCenter.Helpers;
using opsControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace opsControlCenter.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            //Si usamos en la vista un modelo (model.Usuario), es necesario pasarle el objeto inicializado, para que no de error 'System.NullReferenceException'
            //Por lo tanto NO podemos usar: return View();
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Login(Usuario user, string returnUrl)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.USR_LOGIN, false);
                if (returnUrl == null)
                    return Redirect("/Home/Index");
                else
                    return Redirect(returnUrl);
            }
            else
            {
                ViewBag.UsuarioNoValido = "Usuario no válido";
                return View(user);
            }          
        }

        private bool IsValid(Usuario user)
        {
            MapDataSetToModel mapDataSetToModel = new MapDataSetToModel();
            var usuario = mapDataSetToModel.MapUsuarioByLoginName(user.USR_LOGIN);
            return (user.USR_LOGIN != null && user.USR_PASSWORD != null && user.USR_LOGIN == usuario.USR_LOGIN && user.USR_PASSWORD == usuario.USR_PASSWORD);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}