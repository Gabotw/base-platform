using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class TutorialsController : ControllerBase
{
    private readonly ITutorialCommandService _tutorialCommandService;
    private readonly ITutorialQueryService _tutorialQueryService;

    public TutorialsController(ITutorialCommandService tutorialCommandService,
        ITutorialQueryService tutorialQueryService)
    {
        _tutorialCommandService = tutorialCommandService;
        _tutorialQueryService = tutorialQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource createTutorialResource)
    {
        var createTutorialCommand =
            CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(createTutorialResource);
        var tutorial = await _tutorialCommandService.Handle(createTutorialCommand);
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialIdentifier = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTutorials()
    {
        var getAllTutorialsQuery = new GetAllTutorialsQuery();
        var tutorials = await _tutorialQueryService.Handle(getAllTutorialsQuery);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{tutorialId}")]
    public async Task<IActionResult> GetTutorialById([FromRoute] int tutorialId)
    {
        var tutorial = await _tutorialQueryService.Handle(new GetTutorialByIdQuery(tutorialId));
        if (tutorial == null) return NotFound();
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return Ok(resource);
    }

    [HttpPost("{tutorialId}/videos")]
    public async Task<IActionResult> AddVideoToTutorial([FromBody] AddVideoAssetToTutorialResource addVideoAssetToTutorialResource,
        [FromRoute] int tutorialId)
    {
        var addVideAssetToTutorialCommand =
            AddVideoAssetToTutorialCommandFromResourceAssembler.ToCommandFromResource(addVideoAssetToTutorialResource,
                tutorialId);
        var tutorial = await _tutorialCommandService.Handle(addVideAssetToTutorialCommand);
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialIdentifier = resource.Id }, resource);
    }
}