using Microsoft.AspNetCore.Mvc;
using samplesolution.Data;
using samplesolution.Models;
using System.Collections.Generic;
using System.Linq;

namespace samplesolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemDbContext _context;

        public ItemController(ItemDbContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAllItems()
        {
            return Ok(_context.itemss.ToList());
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = _context.itemss.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/Item
        [HttpPost]
        public ActionResult<Item> AddItem(Item newItem)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            _context.itemss.Add(newItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);
        }

        // Other methods (PUT, DELETE) can be implemented similarly
    }
}
