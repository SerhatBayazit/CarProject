using Car.Data;
using Car.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // UserManager için

namespace Car.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; // << EKLE

        public EditModel(CarDbContext context, UserManager<IdentityUser> userManager) // << CONSTRUCTOR'A EKLE
        {
            _context = context;
            _userManager = userManager; // << ATA
        }

        [BindProperty]
        public Car.Models.CarModel Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            // *** YETKİLENDİRME KONTROLÜ (GET isteği için) ***
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || car.UserId != currentUser.Id)
            {
                return Forbid(); // Erişimi reddet (403 Forbidden)
                // Veya kullanıcıyı başka bir sayfaya yönlendirebilirsiniz:
                // return RedirectToPage("/AccessDenied"); // Varsayılan Identity Access Denied sayfası
            }

            Car = car;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // *** YETKİLENDİRME KONTROLÜ (POST isteği için) ***
            var existingCar = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Car.Id);
            if (existingCar == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || existingCar.UserId != currentUser.Id)
            {
                return Forbid(); // Erişimi reddet (403 Forbidden)
            }

            // UserId'nin değiştirilmesini engelle. Formdan gelmemeli, DB'den gelmeli.
            Car.UserId = existingCar.UserId;

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}