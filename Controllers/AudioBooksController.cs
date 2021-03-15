using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [Route("audioBook")]
    [ApiController]
    public class AudioBooksController : BaseController<AudioBook>
    {
        public AudioBooksController(AudiosContext audiosContext) : base(audiosContext)
        {
        }

    }
}
