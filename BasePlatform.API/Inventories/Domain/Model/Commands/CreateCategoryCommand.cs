using BasePlatform.API.Inventories.Domain.Model.ValueObjects;

namespace BasePlatform.API.Inventories.Domain.Model.Commands;

public record CreateCategoryCommand(
    string Name,
    EGroup GroupId,
    string Description,
    string ReferenceImageUrl
    );