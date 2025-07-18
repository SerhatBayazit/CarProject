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
            // Bu metod, sayfa ilk kez yüklendiğinde (GET isteğiyle) çalışır.
            // Örneğin, burada veritabanından ana sayfada gösterilecek verileri çekebilirsiniz.
        }

        // Eğer ana sayfada bir form olsaydı,
        // form gönderildiğinde çalışacak bir OnPost() metodu ekleyebilirdiniz.
        // public void OnPost()
        // {
        //    // Form verilerini işle
        // }
    }
}