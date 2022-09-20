using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Models.ViewModels;

namespace Assignment2.Controllers
{
    public class BrokeragesController : Controller
    {
        private readonly MarketDbContext _context;

        public BrokeragesController(MarketDbContext context)
        {
            _context = context;
        }

        // GET: Brokerages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brokerages.ToListAsync());
        }

        // GET: Brokerages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brokerage = await _context.Brokerages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brokerage == null)
            {
                return NotFound();
            }

            return View(brokerage);
        }

        public async Task<IActionResult> Select(String? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients = await _context.Clients.ToListAsync();



            BrokerageViewModel brokerageViewModel = new BrokerageViewModel();
            var allClients = await _context.Clients.ToListAsync();
            //   filter clients that are subscribed to this brokerage
            // select clientid from subscription sub where sub.brokerageId = id
            

            brokerageViewModel.Clients = allClients;


            return View(brokerageViewModel);
        }

        // GET: Brokerages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brokerages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Fee")] Brokerage brokerage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brokerage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brokerage);
        }

        // GET: Brokerages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brokerage = await _context.Brokerages.FindAsync(id);
            if (brokerage == null)
            {
                return NotFound();
            }
            return View(brokerage);
        }

        // POST: Brokerages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Title,Fee")] Brokerage brokerage)
        {
            if (id != brokerage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brokerage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerageExists(brokerage.ID))
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
            return View(brokerage);
        }

        // GET: Brokerages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brokerage = await _context.Brokerages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brokerage == null)
            {
                return NotFound();
            }

            return View(brokerage);
        }

        // POST: Brokerages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var brokerage = await _context.Brokerages.FindAsync(id);
            _context.Brokerages.Remove(brokerage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerageExists(string id)
        {
            return _context.Brokerages.Any(e => e.ID == id);
        }



        //ads
        //get /brokerage/:id/ads

        public async Task<IActionResult> AdsIndex(String id)
        {

            //return View(ads)
            return View();
        }


        ///posting a nwe ad
        [HttpPost]
        public async Task<IActionResult> CreateAds(String id,IFormFile file)
        {

            //return View(ads)
            return View();
        }

        //get
        public async Task<IActionResult> CreateAds(String id)
        {

            //return View(ads)
            return View();
        }


        //delete an ad
        [HttpDelete]
        public async Task<IActionResult> DeleteAds(String id)
        {

            //return View(ads)
            return View();
        }
        //get
        public async Task<IActionResult> DeleteAds(String id, IFormFile file)
        {

            //return View(ads)
            return View();
        }
    }
}
