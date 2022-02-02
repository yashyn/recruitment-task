using Cars.Domain.Models;
using Cars.Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cars.Infrastructure.Repos
{
    public class CarRepo : ICarRepo
    {
        private readonly CarsContext _context;

        public CarRepo(CarsContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Car car, CancellationToken cancellationToken = default)
        {
            await _context.Cars.AddAsync(car, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return car.Id;
        }

        public async Task<Car> GetFirstOrDefaultAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default)
        {
            var query = GetQuery(filter);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Car[]> GetWhereAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default)
        {
            var query = GetQuery(filter);
            return await query.ToArrayAsync(cancellationToken);
        }

        private IQueryable<Car> GetQuery(Expression<Func<Car, bool>> filter)
        {
            IQueryable<Car> query = _context.Cars;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
           var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Car car, CancellationToken cancellationToken = default)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
