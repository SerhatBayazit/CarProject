using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Car.Data;
using Car.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Car.Pages
{
    [Authorize] // Giriþ yapmamýþsa eriþim engellenir
    public class MyCarsModel : PageModel
    {
        private readonly CarDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MyCarsModel(CarDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<CarModel> MyCarList { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = _userManager.GetUserId(User);
            MyCarList = await _context.Cars
                .Where(c => c.UserId == currentUserId)
                .ToListAsync();
        }
    }
}
