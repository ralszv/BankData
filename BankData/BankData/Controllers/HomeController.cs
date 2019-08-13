using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankData.Interface;
using BankData.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeInterface _homeInterface;

        public HomeController(IHomeInterface homeInterface)
        {
            _homeInterface = homeInterface;
        }

        public IActionResult Index()
        {
            var i = _homeInterface.GetList();
            
            HomeViewModel vm = new HomeViewModel()
            {
                Title = "List of top 10 countries by GDP (2018)",
                Values = i.Result.Data.Where(a => !String.IsNullOrEmpty(a.countryiso3code)).OrderByDescending(c => c.value).Take(10).ToList()
            };
            
            return View(vm);
        }
    }
}