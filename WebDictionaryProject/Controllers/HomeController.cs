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
        Test _tst;
        Test1 _tst1;
        public HomeController(ILogger<HomeController> logger, IRepositoryWords repositoryWords, Test tst, Test1 tst1)
        {
            _logger = logger;
            _wordRepository = repositoryWords;
            _tst = tst;
            _tst1 = tst1;

            //_wordRepository = RepositoryFactory.CreateRepo("WORD");
        }

        [HttpGet]
        public IActionResult Index(string order, string searchBox)
        {
            return RedirectToAction("Index","Test");
            List<Words> liste = _wordRepository.List();


            if (order == "Words")
            {
                liste = liste.OrderBy(c => c.Kelime).ToList();
            }
            else if (order == "Description")
            {
                liste = liste.OrderBy(c => c.KelimeAnlami).ToList();
            }
            else
            {
                liste = liste.OrderBy(c => c.Id).ToList();
            }


            if (!String.IsNullOrEmpty(searchBox))
            {
                liste = liste.Where(c => c.Kelime.StartsWith(searchBox) || c.KelimeAnlami.StartsWith(searchBox)).ToList();
            }

            List<WordViewModel> model = new List<WordViewModel>();

            foreach (var item in liste)
            {
                WordViewModel wv = new WordViewModel() { Id = item.Id, Kelime = item.Kelime, KelimeAnlami = item.KelimeAnlami };
                model.Add(wv);
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult CreateWord(int? id)
        {
            WordViewModel model = new WordViewModel();
            if (id.HasValue && id > 0)
            {
                List<Words> kelimeler = _wordRepository.List();
                var word = kelimeler.First(c => c.Id == id);
                model.Id = word.Id;
                model.Kelime = word.Kelime;
                model.KelimeAnlami = word.KelimeAnlami;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateWord(Words words)
        {
            if (!ModelState.IsValid)
            {
                return View(words);
            }
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
