using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using lan_week.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class NewsController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly DatabaseManager _context; 

    public NewsController(UserManager<IdentityUser> userManager, DatabaseManager context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var newsArticles = await _context.NewsArticles.ToListAsync();
        return View(newsArticles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NewsArticleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            var newsArticle = new NewsArticle
            {
                Title = model.Title,
                Content = model.Content,
                PublishedDate = DateTime.Now,
                AuthorId = user?.UserName 
            };

            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "News");
        }

        return View(model);
    }
}
