using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Security;
using BSCPEWEB.Models;

namespace BSCPEWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
            public DatabaseController()
            { }
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        public DatabaseController(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }
        [HttpGet("Testconnection")]
        public IActionResult Testconnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var dbContext = new Dbcontext(connectionString);
            try
            {
                bool isConnected = dbContext.testconnection();

                if (isConnected)
                {
                    return Ok(new { Message = "Successfully Connected to the Database" });
                }
                else
                {
                    return BadRequest(new { Message = "failed to Connect" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An Error is occured while checking the database:{ex.Message}" });
            }
        }
    }
}
