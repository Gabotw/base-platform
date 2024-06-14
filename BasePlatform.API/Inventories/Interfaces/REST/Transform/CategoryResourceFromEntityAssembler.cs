using BasePlatform.API.Inventories.Domain.Model.Aggregates;
using BasePlatform.API.Inventories.Interfaces.REST.Resources;

namespace BasePlatform.API.Inventories.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category category)
    {
        return new CategoryResource(
            category.Id,
            category.Name,
            category.GroupId,
            category.Description,
            category.ReferenceImageUrl
        );
    }
}