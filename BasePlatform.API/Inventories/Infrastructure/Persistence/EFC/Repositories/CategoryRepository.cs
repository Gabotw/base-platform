using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Inventories.Domain.Repositories;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasePlatform.API.Inventories.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context): BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<IEnumerable<Category>> FindByNameAsync(string name)
    {
        return await Context.Set<Category>()
            .Where(category => category.Name == name)
            .ToListAsync();
    }
}