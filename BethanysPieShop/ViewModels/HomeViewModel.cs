using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class HomeViewModel
    {
// Read-only property that returns a collection of "Pie" objects (likely a model representing a pie)
        public IEnumerable<Pie> PiesOfTheWeek { get; }
// Constructor of the HomeViewModel class that takes a collection of pies of the week as a parameter
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
    // Initializing the property with the pies passed as a parameter
            PiesOfTheWeek = piesOfTheWeek;
        }
    }
}