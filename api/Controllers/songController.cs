using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models;

namespace pa3spring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songController : ControllerBase
    {
        // GET: api/song
        [HttpGet]
        public IEnumerable<string> Get()
        {
            song testSong = new song()
            {
                songId = 1,
                songTitle = "Daisy's Song",
                artistName = "Daisy",
                isFavorited = false,
                isDeleted = false
            };
            string testString = testSong.songTitle.ToString();
            
            return new string[] {testString};
        }

        // GET: api/song/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/song
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/song/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/song/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
