using Microsoft.AspNetCore.Mvc;

namespace ServerAndClientApplications.Api.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var output = new Person
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        
        return Ok(output);
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}