using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems();

        Item GetItemById(int id);

        Task<IEnumerable<Item>> GetItemsByPointId(int pointId);
    }
}
