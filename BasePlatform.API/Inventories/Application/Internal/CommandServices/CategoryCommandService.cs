using Category = BasePlatform.API.Inventories.Domain.Model.Aggregates.Category;
using BasePlatform.API.Inventories.Domain.Model.Commands;
using BasePlatform.API.Inventories.Domain.Repositories;
using BasePlatform.API.Inventories.Domain.Services;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Inventories.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork): ICategoryCommandService
{
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(
            command.Name, 
            command.GroupId,
            command.Description,
            command.ReferenceImageUrl
            );
        var categories = await categoryRepository.FindByNameAsync(command.Name);
        if (categories.Any()) throw new Exception("Category with the same name already exists");
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}