using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Sikiro.Tookits.Files.Sample.Web.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Import(HttpPostedFileBase file)
        {
            var importData = ExcelHelper.HttpImport<UserModel>(file);
            return View("Index", importData);
        }

        public void Export()
        {
            var list = new List<UserModel> { new UserModel { Mobile = "18988565555", Name = "陈珙1" }, new UserModel { Mobile = "18988565552", Name = "陈珙2" }, new UserModel { Mobile = "18988565553", Name = "陈珙4" } };
            ExcelHelper.HttpExport(list, "Test");
        }
    }

    public class UserModel
    {
        [Display(Name = "手机号")]
        public string Mobile { get; set; }

        [Display(Name = "名字")]
        public string Name { get; set; }
    }
}