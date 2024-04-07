using Microsoft.AspNetCore.Mvc;
using VideogamesManagement.DataLayer.Entitites;
using VideogamesManagement.DataLayer.Repository;

namespace VideogamesManagement.BusinessLayer
{
    public class VideoGameService
    {
        public List<VideoGame> GetAllVideoGames()
        {
            try
            {
                var videoGameRepository = new VideoGameRepository();
                var games = videoGameRepository.GetAllVideoGames();
                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
        public VideoGame FindByID(int id)
        {
            try
            {
                var videoGameRepository = new VideoGameRepository();
                var game = videoGameRepository.FindByID(id);
                return game;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public void DeleteVideo(int id)
        {
            try
            {
                var videoGameRepository = new VideoGameRepository();
                var videogametoDelete = videoGameRepository.FindByID(id);
                if (videogametoDelete == null)
                {

                    Console.WriteLine("Videogame does not exist");
                }

                videoGameRepository.DeleteVideo(videogametoDelete);

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
                //var videoGameRepository = new VideoGameRepository();
                //var videogametoAdd = videoGameRepository.FindByID(id);

                //if (videogametoAdd == null)
                //{
                //    videoGameRepository.AddVideo(videogametoAdd);
                //}
                //else

                //    Console.WriteLine("Videogame exists");
                var videoGameRepository = new VideoGameRepository();
                videoGameRepository.AddVideo(game);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public void UpdateVideoGames(VideoGame game)
        {
            try
            {
                var videoGameRepository = new VideoGameRepository();
                videoGameRepository.UpdateVideoGames(game);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
        public List<VideoGame> FilterVideoGame(string? name, int? size, string? studio)
        {
            var videoGameRepository = new VideoGameRepository();

            var videoGames = videoGameRepository.GetAllVideoGames();

            if (!string.IsNullOrEmpty(name))
            {
                videoGames = videoGames.Where(p => p.Name.Contains(name))
                   .ToList();
            }

            if (size != 0 && size != null)
            {
                videoGames = videoGames.Where(p => p.Size == size).ToList();
            }

            if (!string.IsNullOrEmpty(studio))
            {
                videoGames = videoGames.Where(p => p.Studio.Contains(studio))
                   .ToList();
            }

            return videoGames;

        }
    }
}

