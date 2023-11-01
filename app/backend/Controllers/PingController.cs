
namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : Controller
{
    [HttpGet]
    public string Get() => "pong";
}
