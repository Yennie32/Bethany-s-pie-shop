using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository: IPieRepository // reference to pie interface file
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;
// constructor injection
        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        // pie interface implementation
        public IEnumerable<Pie> AllPies =>
                // get request; returns the Category with the pie. 
                // Include = Specifies related entities to include in the query results.
                _bethanysPieShopDbContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfThWeek =>
                _bethanysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}