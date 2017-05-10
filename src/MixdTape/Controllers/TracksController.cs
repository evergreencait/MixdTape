using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MixdTape.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MixdTape.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TracksController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {

            return View(_db.Tracks.ToList());
        }

        public IActionResult SearchTrack()
        {
            var allArtists = Track.GetTrack();
            return View(allArtists);
        }

        public IActionResult GetTrack()
        {
            return View(_db.Tracks.ToList());
        }

    }

}
