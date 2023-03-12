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
            StringToNumber converter = new StringToNumber();
            string output = converter.Run(input.UserText);

            return Ok("Output" + $": '{output}'");
        }
    }
}
