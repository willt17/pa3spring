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
        public List<song> Get()
        {
            // song testSong = new song()
            // {
            //     songId = "1",
            //     songTitle = "Daisy's Song",
            //     artistName = "Daisy",
            //     isFavorited = false,
            //     isDeleted = false
            // };
            
            songHandler mySongHandler = new songHandler();
            return mySongHandler.GetAllSongs();
        }

        // GET: api/song/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/song
        [HttpPost]
        public void Post([FromBody] song value)
        {
            value.songId = Guid.NewGuid().ToString();
            songHandler mySongHandler = new songHandler();
            mySongHandler.AddSong(value);
        }

        // PUT: api/song/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] song value)
        {
            songHandler mySongHandler = new songHandler();
        }

        // DELETE: api/song/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            songHandler mySongHandler = new songHandler();
        }
    }
}
