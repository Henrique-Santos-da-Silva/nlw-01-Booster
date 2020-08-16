using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items = _repository.GetAllItems();

            return Ok(await items);
        }
    }
}
