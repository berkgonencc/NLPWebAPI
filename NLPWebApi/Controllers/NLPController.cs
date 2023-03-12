using Microsoft.AspNetCore.Mvc;
using NLPWebApi.Algorithm;
using NLPWebApi.Models;

namespace NLPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NLPController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnterInput(Input inputText)
        {
            var input = new Input()
            {
                UserText = inputText.UserText,
            };
            Parser parser = new Parser();
            string output = parser.InputParser(input.UserText);

            return Ok("Output" + $": '{output}'");
        }
    }
}
