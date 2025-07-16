using Car.Data;
using Car.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Car.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly CarDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(CarDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public CarModel CarItem { get; set; } = default!;

        [TempData]
        public string? SuccessMessage { get; set; } // ✅ Silindikten sonra gösterilecek mesaj

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (car == null) return NotFound();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || car.UserId != currentUser.Id)
            {
                return Forbid();
            }

            CarItem = car;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || car.UserId != currentUser.Id)
            {
                return Forbid();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            SuccessMessage = "Araç başarıyla silindi."; // ✅ TempData ile mesaj gönder

            return RedirectToPage("./Index");
        }
    }
}
