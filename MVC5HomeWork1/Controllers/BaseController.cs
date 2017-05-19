using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HomeWork1.Controllers
{
    [HandleError(ExceptionType = typeof(System.Data.Entity.Validation.DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public abstract class BaseController : Controller
    {
        // GET: Base
        public ActionResult Debug()
        {
            return Content("Hello");
        }

    }
}