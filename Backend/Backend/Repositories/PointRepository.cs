using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly DataContext _context;

        public PointRepository(DataContext context)
        {
            _context = context;
        }


        public async Task CreatePoint(Point point)
        {
            if (point == null || _context.Points.Any(p => p.Name.Equals(point.Name)))
                throw new ArgumentNullException(nameof(point), "Point is null or contains repeated name");

            _context.Points.Add(point);
            await _context.SaveChangesAsync();
        }

        public async Task CreatePointItems(List<PointItem> pointItems)
        {
            if (pointItems == null)
                throw new ArgumentNullException(nameof(pointItems), "Point items is null");

            _context.PointItems.AddRange(pointItems);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Point>> GetFilteredPoints(string city, string uf, List<int> items)
        {
            return await (
                from point in _context.Points
                join point_item in _context.PointItems on point.Id equals point_item.PointId
                where (
                    items.Contains(point_item.ItemId) &&
                    point.City == city &&
                    point.Uf == uf
                )
                select point
                ).Distinct().ToListAsync();
        }

        public async Task<Point> GetPointById(int id) => await _context.Points.FirstOrDefaultAsync(point => point.Id == id);
    }
}
