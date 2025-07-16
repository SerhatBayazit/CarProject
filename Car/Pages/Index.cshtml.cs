using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Bu metod, sayfa ilk kez yüklendiðinde (GET isteðiyle) çalýþýr.
            // Örneðin, burada veritabanýndan ana sayfada gösterilecek verileri çekebilirsiniz.
        }

        // Eðer ana sayfada bir form olsaydý,
        // form gönderildiðinde çalýþacak bir OnPost() metodu ekleyebilirdiniz.
        // public void OnPost()
        // {
        //    // Form verilerini iþle
        // }
    }
}