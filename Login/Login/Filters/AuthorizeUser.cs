using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Users oUser;
        private LoginEntities db = new LoginEntities();
        private int idOperation;

        public AuthorizeUser(int idOperation = 0)
        {
            this.idOperation = idOperation;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String operationName = "";
            String moduleName = "";

            try
            {
                oUser = (Users)HttpContext.Current.Session["User"];
                var lstOperations = from m in db.Rol_Operation
                                    where m.idRol == oUser.UserIdRol 
                                    && m.idOperation == idOperation
                                    select m;

                if (lstOperations.ToList().Count() == 0)
                {
                    var Operation = db.Operation.Find(idOperation);
                    int idModulo = Operation.operationModuleId;
                    operationName = getOperationName(idOperation);
                    moduleName = getModuleName(idModulo);
                    //moduleName = moduleName.Replace(' ', '+');
                    //operationName = operationName.Replace(' ', '+');
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?opertion" + operationName + "&modulo" + moduleName + "&msjeErrorException=");

                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?opertion" + operationName + "&modulo" + moduleName + "&msjeErrorException=" + ex.Message);
            }
        }

        private string getOperationName(int idOperation)
        {
            var ope = from op in db.Operation
                      where op.opertaionId == idOperation
                      select op.opertaionName;

            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getModuleName (int? idModule)
        {
            var modulo = from m in db.Module
                         where m.moduleId == idModule
                         select m.moduleName;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }
}