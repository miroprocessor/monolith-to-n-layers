using CustomerTreatments.Entities;
using CustomerTreatments.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerTreatments.WebControllers
{
    [Authorize]
    public class TreatmentsController : Controller
    {

        private readonly TreatmentsService _treatmentsService;

        private readonly UserManager<IdentityUser> _userManager;


        public TreatmentsController(TreatmentsService treatmentsService, UserManager<IdentityUser> userManager)
        {
            _treatmentsService = treatmentsService;
            _userManager = userManager;

        }





        public async Task<IActionResult> Index()
        {
            var AllTreatments = await _treatmentsService.GetTreatments();


            return View(AllTreatments);
        }


        public async Task<IActionResult> Details(string id)
        {

            if (id == null)
            {
                return NotFound();

            }
            var treatment = _treatmentsService.GetTreatment(id);


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
                await _treatmentsService.Add(treatment);
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

            var treatment = await _treatmentsService.GetTreatment(id);
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
                await _treatmentsService.Edit(treatment);
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

            var treatment = await _treatmentsService.GetTreatment(id);
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
            var treatment = new Treatment() { ID = id };

            await _treatmentsService.Delete(treatment);
            return RedirectToAction(nameof(Index));
        }


    }
}
