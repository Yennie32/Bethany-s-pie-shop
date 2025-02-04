using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BethanysPieShop.Controllers
{
    // HomeController class inherits from the base Controller class
    public class HomeController : Controller
    {
        // Private read-only field to store a reference to the pie repository
        private readonly IPieRepository _pieRepository;

        // Constructor that takes an IPieRepository implementation as a parameter
        public HomeController(IPieRepository pieRepository)
        {
            // Assigns the provided repository to the private field
            _pieRepository = pieRepository;
        }

        // Action method that handles the request for the home page
        public IActionResult Index()
        {
            // Retrieves the pies of the week from the repository
            var piesOfTheWeek = _pieRepository.PiesOfThWeek;

            // Creates a ViewModel instance containing the pies
            var homeViewModel = new HomeViewModel(piesOfTheWeek);

            // Returns the view with the ViewModel data
            return View(homeViewModel);
        }
    }
}
