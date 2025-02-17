using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfThWeek { get; }
        Pie? GetPieById(int pieId);
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
}