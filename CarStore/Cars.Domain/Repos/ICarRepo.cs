using Cars.Domain.Models;
using System.Linq.Expressions;

namespace Cars.Domain.Repos
{
    public interface ICarRepo
    {
        Task<Guid> CreateAsync(Car car, CancellationToken cancellationToken = default);
        Task<Car> GetFirstOrDefaultAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default);
        Task<Car[]> GetWhereAsync(Expression<Func<Car, bool>> filter, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Car car, CancellationToken cancellationToken = default);
    }
}
