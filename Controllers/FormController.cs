using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using test1.Models;

namespace test1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
    
        private readonly ILogger<FormController> _logger;


        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] FormData formData)
        {

            if (formData == null) return new BadRequestResult();

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(formData, options);
            var filePath = "formdata.json";
            System.IO.File.WriteAllText(filePath, json);

            return Ok();
        }
    }
}