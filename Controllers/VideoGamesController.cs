using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VideogamesManagement.BusinessLayer;
using VideogamesManagement.DataLayer.DB_Context;
using VideogamesManagement.DataLayer.Entitites;

namespace VideogamesManagement.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        [HttpGet("getallvideogames")]
        public List<VideoGame> GetAllVideoGames()
        {
            var videoGameService = new VideoGameService();
            return videoGameService.GetAllVideoGames();
        }

        [HttpGet("findbyid")]

        public VideoGame FindByID([FromQuery] int id)
        {
            var videoGameService = new VideoGameService();
            var game = videoGameService.FindByID(id);


            return game;
        }

        [HttpDelete("deletevideogames")]
        public IActionResult DeleteVideo([FromQuery] int id)
        {
            var videoGameService = new VideoGameService();
            videoGameService.DeleteVideo(id);
            return new OkObjectResult("Videogame was deleted successfully");
        }

        [HttpPost("addvideogames")]
        public IActionResult Addvideo([FromBody] VideoGame game)
        {
            var videoGameService = new VideoGameService();
            videoGameService.AddVideo(game);
            return new OkObjectResult("Videogame was added succesfully");
        }

        [HttpPut("modifyvideogames")]
        public IActionResult UpdateVideoGames([FromBody] VideoGame game)
        {
            var videoGameService = new VideoGameService();
            videoGameService.UpdateVideoGames(game);
            return new OkObjectResult("Videogame was updated succesfully");
        }

        [HttpGet("filter")]
        public List<VideoGame> FilterVideoGame(string? name, int? size, string? studio)
        {
            var videoGameService = new VideoGameService();
            return videoGameService.FilterVideoGame(name, size, studio);
            //return new OkObjectResult("Videogame was updated succesfully");
            
        }
    }
}
    

    
     
   