using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);

        bool Delete(string id);
        bool Delete(T Model);

        bool UpdateAsync(T model);
        bool UpdateRangeAsync(List<T> model);

        Task<int> SaveAsync();

    }
}
