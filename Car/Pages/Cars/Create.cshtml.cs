using Car.Data;
using Car.Models; // Car.Models.Car sınıfına erişmek için
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity; // UserManager ve IdentityUser için
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using'leriniz buraya

namespace Car.Pages.Cars
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CarDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; // UserManager'ı enjekte etmek için

        public CreateModel(CarDbContext context, UserManager<IdentityUser> userManager) // Constructor'a UserManager ekle
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            // Sayfa yüklendiğinde boş bir CarItem nesnesi oluşturur
            CarItem = new Car.Models.CarModel(); // CarItem olarak güncelledik
            return Page();
        }

        // Hata veren Car özelliğini CarItem olarak değiştirin
        [BindProperty]
        public Car.Models.CarModel CarItem { get; set; } = default!; // Tam nitelikli isim kullandık: Car.Models.Car

        public async Task<IActionResult> OnPostAsync()
        {
            // Model durumunun geçerliliğini kontrol et (örn. Required alanlar dolu mu?)
            if (!ModelState.IsValid)
            {
                // Eğer model geçerli değilse, formu yeniden göster
                return Page();
            }

            // *** ÖNEMLİ KISIM: Mevcut kullanıcının ID'sini al ve araca ata ***
            // User, Razor Page'in built-in özelliğidir ve giriş yapmış kullanıcı bilgisini içerir.
            var user = await _userManager.GetUserAsync(User);

            // Eğer bir kullanıcı giriş yapmışsa (user null değilse)...
            if (user != null)
            {
                CarItem.UserId = user.Id; // Bu aracın sahibi olarak giriş yapan kullanıcının ID'sini ata.
            }
            else
            {
                // Kullanıcı giriş yapmamışsa veya user null ise ne yapılacağı.
                // Bu durumda 'CarItem.UserId' null kalır. Eğer bu sayfaya sadece
                // giriş yapmış kullanıcıların erişmesini istiyorsanız, OnGet ve OnPost
                // metotlarına [Authorize] niteliğini ekleyebilirsiniz.
                // Şimdilik 'UserId' null atanabilir olduğu için hata vermeyecektir.
            }

            // CarItem nesnesini veritabanı bağlamına ekle.
            _context.Cars.Add(CarItem); // CarItem kullanıldı
            // Bekleyen değişiklikleri (yani yeni aracı) veritabanına kaydet.
            await _context.SaveChangesAsync();

            // İşlem başarılı olursa, kullanıcıyı araç listeleme sayfasına yönlendir.
            return RedirectToPage("./Index");
        }
    }
}