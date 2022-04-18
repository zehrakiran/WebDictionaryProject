using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebDictionaryProject.Helpers;
using WebDictionaryProject.Models;

namespace WebDictionaryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepositoryWords _wordRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _wordRepository = RepositoryFactory.CreateRepo("WORD");
        }

        [HttpGet]
        public IActionResult Index(string order, string searchBox)
        {
            List<Words> liste = _wordRepository.List();

            if (order == "Kelime")
                liste = liste.OrderBy(c => c.Kelime).ToList();
            else if (order == "KelimeAnlami")
                liste = liste.OrderBy(c => c.KelimeAnlami).ToList();
            else
                liste = liste.OrderBy(c => c.Id).ToList();

            if (!String.IsNullOrEmpty(searchBox))
            {
                // liste = liste.Where(c => c.Name == searchBox || c.Surname==searchBox).ToList();
                //  liste = liste.Where(c => c.Name.Contains(searchBox) || c.Surname.Contains(searchBox)).ToList();
                liste = liste.Where(c => c.Kelime.StartsWith(searchBox) || c.KelimeAnlami.StartsWith(searchBox)).ToList();
            }
            return View(liste);

        }
        [HttpGet]
        public IActionResult CreateWord(int? id)
        {
            Words model = new Words();
            if (id.HasValue && id > 0)
            {
                List<Words> word = _wordRepository.List();
                model = word.First(c => c.Id == id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateWord(Words words)
        {
            _wordRepository.AddOrUpdate(words);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _wordRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy(KelimeTest kelime)
        {


            return View(kelime);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
