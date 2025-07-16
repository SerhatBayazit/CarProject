using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car.Data;
using Car.Models;

namespace Car.Pages.Cars
{
    public class DetailModel : PageModel
    {
        private readonly CarDbContext _context;

        public DetailModel(CarDbContext context)
        {
            _context = context;
        }

        public CarModel Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
                return NotFound();

            Car = car;
            return Page();
        }
    }
}
