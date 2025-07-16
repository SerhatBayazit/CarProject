using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car.Data;
using Car.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Car.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(CarDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [TempData]
        public string? SuccessMessage { get; set; }


        public List<CarModel> CarList { get; set; }

        [BindProperty]
        public CarModel NewCar { get; set; }

        public string? CurrentUserId { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUserId = _userManager.GetUserId(User);
            CarList = await _context.Cars.ToListAsync();

        }
        [Authorize]
        public async Task<IActionResult> OnPostAddCarAsync()
        {
            if (!ModelState.IsValid)
            {
                // CarList yeniden yüklenmezse sayfa boş gelir.
                CurrentUserId = _userManager.GetUserId(User);
                CarList = await _context.Cars.ToListAsync();
                return Page();
            }

            NewCar.UserId = _userManager.GetUserId(User);
            _context.Cars.Add(NewCar);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // Sayfayı yenile
        }
    }
}
