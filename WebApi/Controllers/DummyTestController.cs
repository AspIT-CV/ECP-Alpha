using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is a test controller a client can use for testing purposes.
    /// </summary>
    public class DummyTestController : Controller
    {
        /// <summary>
        /// This is a test action method a client can call for testing purposes.
        /// </summary>
        /// <returns>The current time on the server.</returns>
        [HttpGet]
        [Route("/GetDummyData")]
        public async Task<ActionResult<string>> GetCurrentTime()
        {
            string time = "Wait for it...";
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                time = $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.ffffff")}";
            });
            return Ok(time);
        }
    }
}