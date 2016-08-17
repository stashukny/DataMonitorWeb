using DataMonitorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataMonitorWeb.Controllers
{
    public class ControllerBase : Controller
    {
        private bool _hasErrors;
        public bool HaveErrors(DataMonitorEntities db)
        {

            EfStatus efStatus = db.SaveChangesWithValidation();
            if (efStatus.EfErrors != null && efStatus.EfErrors.Count > 0)
            {
                efStatus.EfErrors.ToList().ForEach(validationResult => ModelState.AddModelError(String.Empty, validationResult.ErrorMessage));
                _hasErrors = true;
            }
            else
            {
                _hasErrors = false;
            }

            return _hasErrors;
        }
    }
}