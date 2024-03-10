using Microsoft.AspNetCore.Mvc;
using crud.Models;
using crud.Data;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers;

public class UserController : Controller
{
    private readonly UserDbContext _context;

    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.UserId == id);
    }
    public UserController(UserDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> IndexAsync()
    {
        return View(await _context.User.ToListAsync());

    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("UserId,Name,Email")] UserModel user)
    {
        if (id != user.UserId)
        {

            Console.WriteLine(id);
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserId))
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
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Store([Bind("UserId,Name,Email")] UserModel user)
    {
        if (ModelState.IsValid)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Console.WriteLine(id);
        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}


