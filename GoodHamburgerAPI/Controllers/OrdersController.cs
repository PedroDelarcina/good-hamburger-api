using GoodHamburgerAPI.Data;
using GoodHamburgerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly GoodHamburgerDBContext _dbContext;
        public OrdersController(GoodHamburgerDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {

            var sandwich = _dbContext.Sandwiches.FirstOrDefault(s => s.Id == order.SandwichId);
            if (sandwich == null)
            {
                return BadRequest("Sanduíche inválido.");
            }

            Extra fries = null;
            if (order.FriesId.HasValue)
            {
                fries = _dbContext.Extras.FirstOrDefault(e => e.Id == order.FriesId);
                if (fries == null)
                {
                    return BadRequest("Batata frita inválida.");
                }
            }

            Extra drink = null;
            if (order.DrinkId.HasValue)
            {
                drink = _dbContext.Extras.FirstOrDefault(e => e.Id == order.DrinkId);
                if (drink == null)
                {
                    return BadRequest("Refrigerante inválido.");
                }
            }

            decimal totalAmount = sandwich.Price;
            if (fries != null)
                totalAmount += fries.Price;
            if (drink != null)
                totalAmount += drink.Price;


            if (fries != null && drink != null)
            {
                totalAmount *= 0.80m; // Desconto de 20%
            }
            else if (drink != null)
            {
                totalAmount *= 0.85m; // Desconto de 15%
            }
            else if (fries != null)
            {
                totalAmount *= 0.90m; // Desconto de 10%
            }


            order.TotalAmount = totalAmount;


            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();


            return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrder()
        {
            return Ok(_dbContext.Orders.ToList());
        }

        [HttpPut("{id}")]

        public ActionResult UpdateOrder(int id, [FromBody] Order updateOrder)
        {
            var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder != null)
            {
                return NotFound("Pedido não encontrado");
            }

            existingOrder.SandwichId = updateOrder.SandwichId;
            existingOrder.DrinkId = updateOrder.DrinkId;
            existingOrder.FriesId = updateOrder.FriesId;

            var sandwich = _dbContext.Sandwiches.FirstOrDefault(s => s.Id == updateOrder.SandwichId);
            if (sandwich != null)
            {
                return BadRequest("Sanduíche Inválido");
            }

            Extra fries = null;
            if (updateOrder.FriesId.HasValue)
            {
                fries = _dbContext.Extras.FirstOrDefault(e => e.Id == updateOrder.FriesId);
                if (fries != null)
                {
                    return BadRequest("Batata frita Inválida");
                }
            }

            Extra drink = null;
            if (updateOrder.DrinkId.HasValue)
            {
                drink = _dbContext.Extras.FirstOrDefault(e => e.Id == updateOrder.DrinkId);
                if (drink != null)
                {
                    return BadRequest("Refrigerante Inválido");
                }

            }

            decimal totalAmount = sandwich.Price;
            if (fries != null)
            {
                totalAmount += fries.Price;
            }
            if (drink != null)
            {
                totalAmount += drink.Price;
            }

            if (fries != null && drink != null)
            {
                totalAmount *= 0.80m;
            }
            else if (drink != null)
            {
                totalAmount *= 0.85m;
            }
            else if (fries != null)
            {
                totalAmount *= 0.90m;
            }
            existingOrder.TotalAmount = totalAmount;

            _dbContext.SaveChanges();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder (int id)
        {
            var deleteOrders = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (deleteOrders == null)
            {
                return NotFound("Pedido não encontrado");
            }
            _dbContext.Orders.Remove(deleteOrders);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
    

}


