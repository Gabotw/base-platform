using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Inventories.Domain.Model.Commands;

namespace BasePlatform.API.Inventories.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
}