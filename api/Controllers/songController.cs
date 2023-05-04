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
            
            // songHandler mySongHandler = new songHandler();
            return songHandler.GetAllSongs();
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
            songSave.AddSong(value);
        }

        // PUT: api/song/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] song value)
        {
            List<song> songSearch = songHandler.GetAllSongs();
            int indexNumber = songSearch.FindIndex(s => s.songId == id);
            song putSong = songSearch[indexNumber];
            System.Console.WriteLine(id);
            songPut.SaveEdit(id, putSong);
        }

        // DELETE: api/song/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            List<song> songSearch = songHandler.GetAllSongs();
            int indexNumber = songSearch.FindIndex(s => s.songId == id);
            song deleteSong = songSearch[indexNumber];
            songDelete.DeleteSong(id, deleteSong);
        }
    }
}
