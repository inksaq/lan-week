using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Threading.Tasks;
using lan_week;

public class MemberController : Controller
{
    private readonly DatabaseManager _context;

    public MemberController(DatabaseManager context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Members.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MemberId,Name,Email")] Member member)
    {
        if (ModelState.IsValid)
        {
            _context.Add(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(member);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }
        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("MemberId,Name,Email")] Member member)
    {
        if (id != member.MemberId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.MemberId))
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
        return View(member);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members
            .FirstOrDefaultAsync(m => m.MemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var member = await _context.Members.FindAsync(id);
        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MemberExists(int id)
    {
        return _context.Members.Any(e => e.MemberId == id);
    }
}