using Microsoft.AspNetCore.Mvc;
using Task2;

[Route("api/[controller]")]
[ApiController]
public class HumanController : ControllerBase
{
    private readonly HumanService _humanService;

    public HumanController(HumanService humanService)
    {
        _humanService = humanService;
    }
    
    [HttpGet]
    public IEnumerable<Human> GetHumans()
    {
        return _humanService.GetAllHumans();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Human> GetHuman(int id)
    {
        var human = _humanService.GetHumanById(id);

        if (human == null)
        {
            return NotFound();
        }

        return human;
    }
    
    [HttpPost]
    public ActionResult<Human> PostHuman(Human human)
    {
        _humanService.AddHuman(human);

        return CreatedAtAction(nameof(GetHuman), new { id = human.Id }, human);
    }

    [HttpPut("{id}")]
    public IActionResult PutHuman(int id, Human human)
    {
        try
        {
            _humanService.UpdateHuman(id, human);
        }
        catch (ArgumentException)
        {
            return BadRequest("Invalid ID");
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Human> DeleteHuman(int id)
    {
        var human = _humanService.DeleteHuman(id);

        if (human == null)
        {
            return NotFound();
        }

        return human;
    }
}