using Microsoft.AspNetCore.Mvc;

namespace WindsorStartupError.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestServiceController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestServiceController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public string GetRandomData()
        {
            return _testService.GetRandomData();
        }
    }
}
