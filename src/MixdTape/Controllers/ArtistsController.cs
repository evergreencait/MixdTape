using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MixdTape.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MixdTape.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArtistsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Favorite()
        {
            return View(_db.Artists.ToList());
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            _db.Artists.Add(artist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetArtists(string searchedArtist)
        {
            var allArtists = Artist.GetArtists(searchedArtist);
            return Json(allArtists);
        }




    }

}