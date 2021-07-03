﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVCLocalizationByURL.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using AspNetCoreMVCLocalizationByURL.Internationalization;

namespace AspNetCoreMVCLocalizationByURL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private string _currentLanguage;
        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                return _currentLanguage;
            }
        }
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public ActionResult RedirectToDefaultCulture()
        {
            var culture = CurrentLanguage;
            if (culture != "en")
                culture = "en";

            return RedirectToAction("Index", new { culture });
        }
        public IActionResult Index()
        {
            string d = DaysOfWeek.Friday.ToLocalizedString();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _localizer["Your application description page."];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = _localizer["Your contact page."];

            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact contact )
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Contact));
            }

            return View(contact);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class MyClass
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
