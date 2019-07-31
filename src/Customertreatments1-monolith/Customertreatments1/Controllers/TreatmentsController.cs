using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Customertreatments1.Data;
using Customertreatments1.Models;

namespace Customertreatments1.Controllers
{
    [Authorize]
    public class TreatmentsController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
   

        public TreatmentsController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }


      

    
        public async Task<IActionResult> Index()
        {
            var AllTreatments = await _context.Treatments.ToListAsync();


            return View(AllTreatments);
        }

     
        public async Task<IActionResult> Details(string id)
        {
          
            if (id == null)
            {
                  return NotFound();

            }
            var treatment =  _context.Treatments
               .FirstOrDefault(a => a.ID == id);
        

            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

 
        public IActionResult Create()
        {
          //  ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Treatment treatment)
        {
            if (ModelState.IsValid)
            {  
                _context.Add(treatment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

 
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Treatment treatment)
        {
            if (id != treatment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(treatment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            else return View(treatment);
            }
        


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (treatment == null)
            {
                return NotFound();
            }

            return View(treatment);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var treatment = await _context.Treatments.FindAsync(id);

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
