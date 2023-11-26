using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lan_week.Models;
using System.Linq;
using System.Threading.Tasks;

public class CompetitionController : Controller
{
    private readonly DatabaseManager _context;
    private readonly UserManager<IdentityUser> _userManager;

    public CompetitionController(DatabaseManager context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new CompetitionIndexViewModel();

        viewModel.PastCompetitions = await _context.Competitions
            .Where(c => c.EventDate < DateTime.Now)
            .OrderByDescending(c => c.EventDate)
            .Take(3)
            .ToListAsync();

        if (User.Identity.IsAuthenticated)
        {
            viewModel.UpcomingCompetitions = await _context.Competitions
                .Where(c => c.EventDate >= DateTime.Now)
                .OrderBy(c => c.EventDate)
                .Take(3)
                .ToListAsync();
        }

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Upcoming()
    {
        var upcomingCompetitions = await _context.Competitions
            .Where(c => c.EventDate >= DateTime.Now)
            .OrderBy(c => c.EventDate)
            .ToListAsync();

        return View(upcomingCompetitions);
    }

    [HttpGet]
    public async Task<IActionResult> Past()
    {
        var pastCompetitions = await _context.Competitions
            .Where(c => c.EventDate < DateTime.Now)
            .OrderByDescending(c => c.EventDate)
            .ToListAsync();

        return View(pastCompetitions);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateCompetitionViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,EventDate,Location,GameType,PrizePool,Description")] Competition competition)
    {
        if (ModelState.IsValid)
        {
            _context.Add(competition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Upcoming));
        }
        return View(competition);
    }



    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var competition = await _context.Competitions
            .FirstOrDefaultAsync(m => m.CompetitionId == id);

        if (competition == null)
        {
            return NotFound();
        }

        return View(competition);
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var competition = await _context.Competitions.FindAsync(id);
        if (competition == null)
        {
            return NotFound();
        }

        return View(competition);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CompetitionId,Name,EventDate,GameType,PrizePool,Description,Location")] Competition competition)
    {
        if (id != competition.CompetitionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(competition);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(competition.CompetitionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(competition);
    }

    private bool CompetitionExists(int id)
    {
        return _context.Competitions.Any(e => e.CompetitionId == id);
    }

}
