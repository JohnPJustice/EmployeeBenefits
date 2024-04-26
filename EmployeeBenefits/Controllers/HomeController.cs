using EmployeeBenefits.Interfaces;
using EmployeeBenefits.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeBenefits.Controllers
{
    public class HomeController : Controller
    {
        private IBenefitCalculatorHelper _benefitCalulatorHelper;

        public HomeController()
        {
            _benefitCalulatorHelper = UnityConfig.Resolve<IBenefitCalculatorHelper>();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("GetBenefitPreview")]
        public JsonResult GetBenefitPreview(string employeeName, List<string> dependents)
        {
            string result;
            var model = new EmployeeBenefitPreviewModel()
            {
                Dependents = dependents ?? new List<string>(),
                EmployeeName = employeeName
            };
            var response = _benefitCalulatorHelper.CalculateBenefitPreview(model);
            if (response != null)
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                return Json(result);
            }



            return new JsonResult();

        }


    }
}