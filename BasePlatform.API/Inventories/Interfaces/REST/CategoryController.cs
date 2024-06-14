using BasePlatform.API.Inventories.Domain.Model.Queries;
using BasePlatform.API.Inventories.Domain.Services;
using BasePlatform.API.Inventories.Interfaces.REST.Resources;
using BasePlatform.API.Inventories.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BasePlatform.API.Inventories.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]

public class CategoryController(
    ICategoryCommandService categoryCommandService,
    ICategoryQueryService categoryQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> createCategory([FromBody] CreateCategoryResource Resource)
    {
        var createCategoryCommand =
            CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(Resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = resource.Id }, resource);
    }
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int categoryId)
    {
        var category = await categoryQueryService.Handle(new GetCategoryByIdQuery(categoryId));
        if (category == null) return NotFound();
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
    
}