using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity; // UserId için bu using gerekli

namespace Car.Models
{
    [Table("Arabalar")]
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Marka")]
        [Required(ErrorMessage = "Marka alanı zorunludur.")]
        [DisplayName("Marka")]
        [StringLength(255)]
        public string Brand { get; set; } = string.Empty; 

        [Column("Model")]
        [Required(ErrorMessage = "Model alanı zorunludur.")]
        [StringLength(255)]
        public string Model { get; set; } = string.Empty;

        [Column("Yil")]
        [Required(ErrorMessage = "Yıl alanı zorunludur.")]
        [DisplayName("Yıl")]
        [Range(1900, 2050, ErrorMessage = "Geçerli bir yıl giriniz.")]
        public int Year { get; set; }

        [Column("Renk")]
        [Required(ErrorMessage = "Renk alanı zorunludur.")]
        [DisplayName("Renk")]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty; // << Düzeltme

        [Column("Fiyat", TypeName = "numeric(18)")]
        [Range(0, int.MaxValue, ErrorMessage = "Fiyat 0 veya daha büyük bir tam sayı olmalıdır.")]
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        [DisplayName("Fiyat")]
        public decimal DailyPrice { get; set; }

        [Column("DonanimSeviyesi")]
        [StringLength(500)]
        [DisplayName("Donanım Seviyesi")]
        public string Description { get; set; } = string.Empty; 

        [NotMapped]
        public string ImageUrl { get; set; } = string.Empty; 


        public string? UserId { get; set; }
        
    }
}