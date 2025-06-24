using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le prix de vente est obligatoire")]
        [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public double SellingPrice { get; set; }

        [Required(ErrorMessage = "Le prix d'achat est obligatoire")]
        [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public double PurchasePrice { get; set; }

        [Required(ErrorMessage = "Une description est obligatoire")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1900, 1990, ErrorMessage = "Saississez une année entre 1900 et 1990")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La disponibilité est obligatoire")]
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "La date d'achat est obligatoire")]
        public required DateTime PurchasedAt { get; set; }

        [Required(ErrorMessage = "La date de disponibilité à la vente est obligatoire")]
        public required DateTime ReleasedAt { get; set; }

        [Required(ErrorMessage = "La date de la vente est obligatoire")]
        public required DateTime SoldAt { get; set; }
        public required string Finish { get; set; }

    }
}
