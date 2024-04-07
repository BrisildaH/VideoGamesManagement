using Microsoft.AspNetCore.Mvc;
using VideogamesManagement.BusinessLayer;
using VideogamesManagement.DataLayer.DB_Context;
using VideogamesManagement.DataLayer.Entitites;

namespace VideogamesManagement.DataLayer.Repository
{
    public class VideoGameRepository
    {
        private readonly VideoGamesContext _videoGameContext;
        public VideoGameRepository()
        {
            _videoGameContext = new VideoGamesContext();
        }
        // Get All Student
        public List<VideoGame> GetAllVideoGames()
        {
            var games = _videoGameContext.VideoGames.ToList();
            return games;
        }
        // Get By ID
        public VideoGame FindByID(int id)
        {
            try
            {
                var game = _videoGameContext.VideoGames.Where(p => p.ID == id)
                    .FirstOrDefault();
                return game;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //Update
        //Remove
        public void DeleteVideo(VideoGame game)
        {
            try
            {
                _videoGameContext.VideoGames.Remove(game);
                _videoGameContext.SaveChanges();
                Console.WriteLine("Student removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString());
                throw ex;
            }
        }
        public void UpdateVideoGames(VideoGame game)
        {
            try
            {
                var videogameExists = _videoGameContext.VideoGames.Where(p => p.ID == game.ID)
                .FirstOrDefault();

                if (videogameExists == null)
                {
                    throw new Exception("Record does not exists");
                }

                videogameExists.Name = game.Name;
                videogameExists.Size = game.Size;
                videogameExists.Studio = game.Studio;


                _videoGameContext.VideoGames.Update(videogameExists);
                _videoGameContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public void AddVideo(VideoGame game)
        {
            try
            {
                _videoGameContext.VideoGames.Add(game);
                _videoGameContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}