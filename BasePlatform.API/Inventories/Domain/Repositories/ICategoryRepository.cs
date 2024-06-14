using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Inventories.Domain.Repositories;

public interface ICategoryRepository: IBaseRepository<Category>
{
    Task<IEnumerable<Category>> FindByNameAsync(string name);
}