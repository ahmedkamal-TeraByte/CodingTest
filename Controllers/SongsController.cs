using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [Route("song")]
    [ApiController]
    public class SongsController : BaseController<Song>
    {
        public SongsController(AudiosContext audiosContext) : base(audiosContext)
        {

        }
    }
}
