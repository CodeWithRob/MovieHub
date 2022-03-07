#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieHub.Data;
using MovieHub.Models;

namespace MovieHub.Controllers
{
    public class TicketTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketType
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickettype.ToListAsync());
        }

        // GET: TicketType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickettype = await _context.Tickettype
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickettype == null)
            {
                return NotFound();
            }

            return View(tickettype);
        }

        // GET: TicketType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description")] Tickettype tickettype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tickettype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tickettype);
        }

        // GET: TicketType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickettype = await _context.Tickettype.FindAsync(id);
            if (tickettype == null)
            {
                return NotFound();
            }
            return View(tickettype);
        }

        // POST: TicketType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description")] Tickettype tickettype)
        {
            if (id != tickettype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tickettype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TickettypeExists(tickettype.Id))
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
            return View(tickettype);
        }

        // GET: TicketType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickettype = await _context.Tickettype
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickettype == null)
            {
                return NotFound();
            }

            return View(tickettype);
        }

        // POST: TicketType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tickettype = await _context.Tickettype.FindAsync(id);
            _context.Tickettype.Remove(tickettype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TickettypeExists(int id)
        {
            return _context.Tickettype.Any(e => e.Id == id);
        }

        public IEnumerable<Tickettype> GetNormalTicket()
        {
            IEnumerable<Tickettype> ticket =  _context.Tickettype
                .Where(t => t.Name.Equals("Normal"));
            
            return ticket.Cast<Tickettype>();
        }
        
        
    }
    
}
