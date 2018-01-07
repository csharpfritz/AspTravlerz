using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspTravlerz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspTravlerz.Web.Controllers
{

  // [Route("api/[controller]")]
  public class TripsController : Controller
  {

    private readonly TripDbContext _context;

    public TripsController(TripDbContext context)
    {
      _context = context;
    }

    // GET: Trips
    public async Task<IActionResult> Index()
    {
      return View(await _context.Trips.ToListAsync());
    }

    [Route("Trips/Add"), HttpGet]
    public IActionResult Add()
    {

      return View();

    }


    // GET: Trips/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var trip = await _context.Trips.SingleOrDefaultAsync(m => m.ID == id);
      if (trip == null)
      {
        return NotFound();
      }

      return View(trip);
    }

    // GET: Trips/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Trips/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Description,EndDate,Name,StartDate")] Trip trip)
    {
      if (ModelState.IsValid)
      {
        _context.Add(trip);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(trip);
    }


    // GET: Trips/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var trip = await _context.Trips.SingleOrDefaultAsync(m => m.ID == id);
      if (trip == null)
      {
        return NotFound();
      }
      return View(trip);
    }

    // POST: Trips/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Destination,EndDate,Name,StartDate")] Trip trip)
    {
      if (id != trip.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(trip);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TripExists(trip.ID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction("Index");
      }
      return View(trip);
    }


  

    // GET: Trips/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var trip = await _context.Trips.SingleOrDefaultAsync(m => m.ID == id);
      if (trip == null)
      {
        return NotFound();
      }

      return View(trip);
    }

    // POST: Trips/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var trip = await _context.Trips.SingleOrDefaultAsync(m => m.ID == id);
      _context.Trips.Remove(trip);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    private bool TripExists(int id)
    {
      return _context.Trips.Any(e => e.ID == id);
    }
  }
}
