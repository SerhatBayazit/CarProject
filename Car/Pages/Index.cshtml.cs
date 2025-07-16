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
            // Bu metod, sayfa ilk kez y�klendi�inde (GET iste�iyle) �al���r.
            // �rne�in, burada veritaban�ndan ana sayfada g�sterilecek verileri �ekebilirsiniz.
        }

        // E�er ana sayfada bir form olsayd�,
        // form g�nderildi�inde �al��acak bir OnPost() metodu ekleyebilirdiniz.
        // public void OnPost()
        // {
        //    // Form verilerini i�le
        // }
    }
}