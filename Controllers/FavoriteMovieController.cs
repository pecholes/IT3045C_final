using Microsoft.AspNetCore.Mvc;
using IT3045C_final.Models;

namespace IT3045C_final.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoriteMovieController : ControllerBase
{
    private static readonly List<FavoriteMovie> favoriteMovies = new()
    {
        new FavoriteMovie { ID = 1, Title = "RED", Director = "Robert Schwentke", ReleaseYear = "2010", Genre = "Dark Comedy" },
        new FavoriteMovie { ID = 2, Title = "The Proposal", Director = "Anne Fletcher", ReleaseYear = "2009", Genre = "Rom-Com" },
        new FavoriteMovie { ID = 3, Title = "The Maze Runner", Director = "Wes Ball", ReleaseYear = "2014", Genre = "Sciene Fiction" },
        new FavoriteMovie { ID = 4, Title = "Jason X", Director = "James Isaac", ReleaseYear = "2001", Genre = "Slasher" }
    };

    [HttpGet]
    public IEnumerable<FavoriteMovie> Get()
    {
        return favoriteMovies;
    }

    [HttpGet("{id}")]
    public ActionResult<FavoriteMovie> Get(int id)
    {
        var movie = favoriteMovies.FirstOrDefault(m => m.ID == id);
        if (movie == null)
        {
            return NotFound();
        }
        return movie;
    }

    [HttpPost]
    public ActionResult<FavoriteMovie> Post(FavoriteMovie movie)
    {
        movie.ID = favoriteMovies.Max(x => x.ID) + 1;
        favoriteMovies.Add(movie);
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, FavoriteMovie updated)
    {
        var existing = favoriteMovies.FirstOrDefault(x => x.ID == id);
        if (existing == null) return NotFound();

        existing.Title = updated.Title;
        existing.Director = updated.Director;
        existing.ReleaseYear = updated.ReleaseYear;
        existing.Genre = updated.Genre;

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = favoriteMovies.FirstOrDefault(x => x.ID == id);
        if (movie == null) return NotFound();

        favoriteMovies.Remove(movie);
        return Ok();
    }
}
