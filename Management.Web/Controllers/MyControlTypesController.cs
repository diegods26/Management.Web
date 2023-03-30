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
using Management.Web.Contracts;

namespace Management.Web.Controllers
{
    public class MyControlTypesController : Controller
    {
        private readonly IControlTypeRepository _controlTypeRepository;
        private readonly IMapper _mapper;

        public MyControlTypesController(IControlTypeRepository controlTypeRepository, IMapper mapper)
        {
            _controlTypeRepository = controlTypeRepository;
            _mapper = mapper;
        }

        // GET: MyControlTypes
        public async Task<IActionResult> Index()
        {
            var myControlTypes = _mapper.Map<List<MyControlTypeVM>>(await _controlTypeRepository.GetAllAsync());
            return View(myControlTypes);
                
        }

        // GET: MyControlTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var myControlType = await _controlTypeRepository.GetAsync(id);
                     
            if (myControlType == null)
            {
                return NotFound();
            }

            var myControlTypeVm = _mapper.Map<MyControlTypeVM>(myControlType);
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
                await _controlTypeRepository.AddAsync(myControlType);

                return RedirectToAction(nameof(Index));
            }
            return View(myControlTypeVM);
        }

        // GET: MyControlTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var myControlType = await _controlTypeRepository.GetAsync(id);
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
                    await _controlTypeRepository.UpdateAsync(myControlType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _controlTypeRepository.Exists(myControlTypeVM.Id))
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

        // POST: MyControlTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _controlTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private async Task<bool> MyControlTypeExists(int id)
        //{
        //    return await _controlTypeRepository.Exists(id);
        //}
    }
}
