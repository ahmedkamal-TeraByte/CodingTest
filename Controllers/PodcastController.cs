using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [Route("podcast")]
    [ApiController]
    public class PodcastController : BaseController<Podcast>
    {
        public PodcastController(AudiosContext audiosContext) : base(audiosContext)
        {

        }
    }

}
