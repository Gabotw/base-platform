using BasePlatform.API.Insurance.Domain.Model.Queries;
using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Inventories.Domain.Model.Queries;
using BasePlatform.API.Inventories.Domain.Repositories;
using BasePlatform.API.Inventories.Domain.Services;

namespace BasePlatform.API.Inventories.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{

    public async Task<IEnumerable<Category>> Handle(GetAllPoliciesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }
}
