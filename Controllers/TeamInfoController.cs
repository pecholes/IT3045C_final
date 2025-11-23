using Microsoft.AspNetCore.Mvc;
using IT3045C_final.Models;

namespace IT3045C_final.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamInfoController(ILogger<TeamInfoController> logger) : Controller
{
    private readonly ILogger<TeamInfoController> _logger = logger;

    private static readonly List<TeamInfo> teamMembers = new()
    {
        new() {
            ID = 1,
            Name = "Ben Stewart",
            Birthdate = "02-28-2002",
            CollegeProgram = "Information Technology",
            YearInProgram = "Junior"
        },
        new() {
            ID = 2,
            Name = "Patricia Echoles",
            Birthdate = "03-21-1991",
            CollegeProgram = "Information Technology",
            YearInProgram = "Sophomore"
        },
        new() {
            ID = 3,
            Name = "Madison Evanshine",
            Birthdate = "06-20-2005",
            CollegeProgram = "Cybersecurity",
            YearInProgram = "Junior"
        },
        new() {
            ID = 4,
            Name = "Jacob Nolen",
            Birthdate = "08-01-05",
            CollegeProgram = "Information Technology",
            YearInProgram = "Junior"
        }
    };

    public IActionResult Get()
    {
        return Ok(teamMembers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var member = teamMembers.FirstOrDefault(x => x.ID == id);
        if (member == null) return NotFound();
        return Ok(member);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TeamInfo newMember)
    {
        newMember.ID = teamMembers.Max(x => x.ID) + 1;
        teamMembers.Add(newMember);
        return Ok(newMember);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TeamInfo updated)
    {
        var existing = teamMembers.FirstOrDefault(x => x.ID == id);
        if (existing == null) return NotFound();

        existing.Name = updated.Name;
        existing.Birthdate = updated.Birthdate;
        existing.CollegeProgram = updated.CollegeProgram;
        existing.YearInProgram = updated.YearInProgram;

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var member = teamMembers.FirstOrDefault(x => x.ID == id);
        if (member == null) return NotFound();

        teamMembers.Remove(member);
        return Ok();
    }
}
