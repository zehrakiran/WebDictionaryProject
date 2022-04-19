using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionaryProject.Controllers
{
    public class TestController : Controller
    {
        Test _tst;
        public TestController(Test tst)
        {
            _tst = tst;
        }
        public ActionResult Index()
        {
            return Json("Kelime:black");
        }
    }
}
