using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management.Web.Data;
using AutoMapper;
using Management.Web.Models;

namespace Management.Web.Controllers
{
    public class MyControlTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MyControlTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: MyControlTypes
        public async Task<IActionResult> Index()
        {
            var myControlTypes = _mapper.Map<List<MyControlTypeVM>>(await _context.MyControlTypes.ToListAsync());
              return _context.MyControlTypes != null 
                ? View(myControlTypes) 
                : Problem("Entity set 'ApplicationDbContext.MyControlTypes'  is null.");
        }

        // GET: MyControlTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyControlTypes == null)
            {
                return NotFound();
            }

            var myControlType = await _context.MyControlTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myControlType == null)
            {
                return NotFound();
            }

            return View(myControlType);
        }

        // GET: MyControlTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyControlTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MyControlTypeVM myControlTypeVM)
        {
            if (ModelState.IsValid)
            {
                var myControlType = _mapper.Map<MyControlType>(myControlTypeVM);
                _context.Add(myControlType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myControlTypeVM);
        }

        // GET: MyControlTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyControlTypes == null)
            {
                return NotFound();
            }

            var myControlType = await _context.MyControlTypes.FindAsync(id);
            if (myControlType == null)
            {
                return NotFound();
            }
            var myControlTypeVM = _mapper.Map<MyControlTypeVM>(myControlType);
            return View(myControlTypeVM);
        }

        // POST: MyControlTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MyControlTypeVM myControlTypeVM)
        {
            if (id != myControlTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var myControlType = _mapper.Map<MyControlType>(myControlTypeVM);
                    _context.Update(myControlType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyControlTypeExists(myControlTypeVM.Id))
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
            return View(myControlTypeVM);
        }

        // GET: MyControlTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyControlTypes == null)
            {
                return NotFound();
            }

            var myControlType = await _context.MyControlTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myControlType == null)
            {
                return NotFound();
            }

            return View(myControlType);
        }

        // POST: MyControlTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyControlTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyControlTypes'  is null.");
            }
            var myControlType = await _context.MyControlTypes.FindAsync(id);
            if (myControlType != null)
            {
                _context.MyControlTypes.Remove(myControlType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyControlTypeExists(int id)
        {
          return (_context.MyControlTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
