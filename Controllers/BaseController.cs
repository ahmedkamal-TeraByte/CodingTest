using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T> : Controller where T : class
    {
        private readonly AudiosContext AudiosContext;
        public BaseController(AudiosContext audiosContext)
        {
            AudiosContext = audiosContext;
        }

        #region Routes

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            try
            {
                var audio = AddOrUpdateData(request);
                return Ok(audio);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var audio = GetAudio(id);
            return Ok(audio);

        }
        [HttpGet]
        public IActionResult Get()
        {

            var audios = GetAllAudios();
            return Ok(audios);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateRequest request)
        {
            try
            {
                var audio = AddOrUpdateData(request, true, id);
                return Ok(audio);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var audio = GetAudio(id);
            if (audio != null)
            {
                AudiosContext.Remove<T>(audio);
                AudiosContext.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("No Item found with given information.");
        }

        #endregion

        #region Operations

        private List<T> GetAllAudios()
        {
            if (typeof(T) == typeof(Song))
                return AudiosContext.Songs.ToList() as List<T>;
            else if (typeof(T) == typeof(Podcast))
                return AudiosContext.Podcasts.ToList() as List<T>;
            else if (typeof(T) == typeof(AudioBook))
                return AudiosContext.AudioBooks.ToList() as List<T>;
            else
                return null;
        }
        private T GetAudio(int id)
        {
            return AudiosContext.Find<T>(id);
        }
        private IAudio AddOrUpdateData(CreateRequest request, bool update = false, int id = -1)
        {
            IAudio audio = null;
            if (typeof(T) == typeof(Song))
            {
                if (request.AudioFileType.Equals("Song"))
                {
                    audio = new Song(request.Metadata);
                }
                else
                    throw new Exception("Please call corresponding route.");
            }
            else if (typeof(T) == typeof(Podcast))
            {
                if (request.AudioFileType.Equals("Podcast"))
                {
                    audio = new Podcast(request.Metadata);
                }
                else
                    throw new Exception("Please call corresponding route.");
            }
            else if (typeof(T) == typeof(AudioBook))
            {
                if (request.AudioFileType.Equals("AudioBook"))
                {
                    audio = new AudioBook(request.Metadata);
                }
                else
                    throw new Exception("Please call corresponding route.");
            }
            AddOrUpdate(audio, update, id);
            return audio;
        }

        private void AddOrUpdate(IAudio audio, bool update, int id = -1)
        {
            if (update)
            {
                var existingAudio = GetAudio(id) as IAudio;
                if (existingAudio != null)
                    audio.ID = id;
                AudiosContext.Update<T>(audio as T);
            }
            AudiosContext.Add<T>(audio as T);
            AudiosContext.SaveChanges();
        }
        #endregion
    }
}
