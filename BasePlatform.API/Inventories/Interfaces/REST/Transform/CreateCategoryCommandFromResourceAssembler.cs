using BasePlatform.API.Inventories.Domain.Model.Commands;
using BasePlatform.API.Inventories.Domain.Model.ValueObjects;
using BasePlatform.API.Inventories.Interfaces.REST.Resources;

namespace BasePlatform.API.Inventories.Interfaces.REST.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(
            resource.Name,
            (EGroup)resource.GroupId,
            resource.Description,
            resource.ReferenceImageUrl
        );
    }
}