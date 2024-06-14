using BasePlatform.API.Insurance.Domain.Model.Queries;
using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Inventories.Domain.Model.Queries;

namespace BasePlatform.API.Inventories.Domain.Services;

public interface ICategoryQueryService
{
    Task<IEnumerable<Category>> Handle(GetAllPoliciesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
}