using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories.Interfaces
{
    public interface IPointRepository
    {
        Task CreatePoint(Point point);

        Task CreatePointItems(List<PointItem> pointItems);

        Task<Point> GetPointById(int id);

        Task<IEnumerable<Point>> GetFilteredPoints(string city, string uf, List<int> items);
    }
}
