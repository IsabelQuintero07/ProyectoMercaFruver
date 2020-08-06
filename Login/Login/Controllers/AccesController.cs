using Login.Models.ViewModels;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class AccesController : Controller
    {
        string urlDomain = "http://localhost:63609";

        // GET: Acces  sha256 forma de encriptacion - obtener
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult startRecovery()
        {
            RecoveryViewModel model = new RecoveryViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult startRecovery(RecoveryViewModel model)
        {
            try {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string token = GetSha256(Guid.NewGuid().ToString());

                using (LoginEntities db = new LoginEntities())
                {
                    var oUser = db.Users.Where(d => d.email_User == model.Email).FirstOrDefault();
                    if (oUser != null)
                    {
                        oUser.tokenpass_User = token;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        SendEmail(oUser.email_User, token);

                        ViewBag.Message = "Email Sent";
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            RecoveryPasswordViewModel model = new RecoveryPasswordViewModel();
            model.token = token;
            using (LoginEntities db= new LoginEntities())
            {
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View("Index");
                }

                var oUser = db.Users.Where(d => d.tokenpass_User == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Expired token";
                    return View("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Recovery(RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (LoginEntities db = new LoginEntities())
                {

                    var oUser = (db.CheckToken(model.token)).ToList();
                    if (oUser != null)
                    {
                        string saveEncripass = GetSha256(model.Password);

                        foreach (var item in oUser)
                        {
                            db.UpdateUser (item.email_User, saveEncripass);
                        }

                        
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.Message = "Password successfully recovered";
            return View("Index");
        }


        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new LoginEntities())
            {
                var lista = from d in db.Users
                            where d.email_User == model.Email
                            select d;

                if (lista.Count() == 0)
                { 
                db.IngreUser(model.UserName, model.Email, GetSha256(model.Password));
                db.SaveChanges();
                }

                else
                {
                    ViewBag.Mssje = "User already exists";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Enter(string username, string password)
        {
            try
            {
                using (var db = new LoginEntities())
                {
                    string saveEncripass = GetSha256(password);
                    var lst = (db.ProcedureCheckLogin(username, saveEncripass)).ToList();

                    if (lst.Count() > 0)
                    {
                        Users oUser = lst.First();
                        //foreach (var item in lst)
                        //{
                        //    oUser.email_User = item.email_User;
                        //    oUser.password_User = item.password_User;
                        //}

                        Session["User"] = oUser;
                        return Content("1");
                    }

                    else
                    {
                        return Content("Wrong user");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred" + ex.Message);
            }
        }

        #region HELPERS // archivos que ayudan a hacer otras fuciones en este caso a encriptar
        private String GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        
        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "musisoftsa2020@gmail.com";
            string Contraseña = "@2020musi";
            string url = urlDomain + "/Acces/Recovery/?token=" + token;

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recovery Password", 
                "<p>Email for recovery password</p><br>"+
                "<a href = '"+ url +"'>Click for recovery</a>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtopClient = new SmtpClient("smtp.gmail.com");
            oSmtopClient.EnableSsl = true;
            oSmtopClient.UseDefaultCredentials = false;
            oSmtopClient.Port = 587;
            oSmtopClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtopClient.Send(oMailMessage);
            oSmtopClient.Dispose();
        }
        #endregion
       
    }
}