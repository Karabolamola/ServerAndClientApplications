using Microsoft.AspNetCore.Mvc;

namespace ServerAndClientApplications.Api.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public string[] Get()
    {
        return new string[]
        {
            "Mango",
            "Banana",
            "Pear",
            "Apple",
            "Grapes"
        };
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}