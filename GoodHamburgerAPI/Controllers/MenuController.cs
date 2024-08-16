using GoodHamburgerAPI.Data;
using GoodHamburgerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace GoodHamburgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly GoodHamburgerDBContext _dbContext;
        public MenuController(GoodHamburgerDBContext dBContext)
        {
            _dbContext = dBContext;


            if (!_dbContext.Sandwiches.Any() && !_dbContext.Extras.Any())
            {
                _dbContext.Sandwiches.AddRange(

                    new Sandwich { Id = 1, Name = "X Burger", Price = 5.00m },
                    new Sandwich { Id = 2, Name = "X Egg", Price = 4.50m },
                    new Sandwich { Id = 3, Name = "X Bacon", Price = 7.00m }

                    );
                _dbContext.Extras.AddRange(

                    new Extra { Id = 1, Name = "Fries", Price = 2.00m },
                    new Extra { Id = 2, Name = "Soft Drink", Price = 2.50m }

                    );

                _dbContext.SaveChanges();
            }
        }
        [HttpGet("all")]
        public ActionResult<List<Object>> GetAllMenuItems()
        {
            var sandwiches = _dbContext.Sandwiches.ToList();
            var extras = _dbContext.Extras.ToList();


            var allItems = new List<Object>();

            allItems.AddRange(sandwiches);
            allItems.AddRange(extras);

            return Ok(allItems);
        }
        [HttpGet("sandwiches")]

        public ActionResult<List<Sandwich>> GetSandWiches()
        {
            var sandwiches = _dbContext.Sandwiches.ToList();
            return Ok(sandwiches);
        }

        [HttpGet("extras")]
        public ActionResult<List<Extra>> GetExtras()
        {
            var extras = _dbContext.Extras.ToList();
            return Ok(extras);
        }

    }
}



  