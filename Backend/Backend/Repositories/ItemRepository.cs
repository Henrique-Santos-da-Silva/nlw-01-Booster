using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var items = _context.Items.Select(i => new Item
            {
                Id = i.Id,
                Title = i.Title,
                ImageUrl = $"http://localhost:5000/Uploads/{i.Image}",
            }).ToListAsync();

            return await items;
        }

        public Item GetItemById(int id) => _context.Items.FirstOrDefault(item => item.Id == id);

        public async Task<IEnumerable<Item>> GetItemsByPointId(int pointId)
        {
            return await (
                from item in _context.Items
                join point_item in _context.PointItems on item.Id equals point_item.ItemId
                where (point_item.PointId == pointId)
                select item).ToListAsync();
        }
    }
}
