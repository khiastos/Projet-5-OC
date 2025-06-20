using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Entities
{
    public class CarToSells
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        public required string Brand { get; set; }

        [Required(ErrorMessage = "Le model est obligatoire")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1900, 1990, ErrorMessage = "Saississez une année entre 1900 et 1990")]
        public int Year { get; set; }
        public required string Finish { get; set; }
        public required string SellingDate { get; set; }

        [Required(ErrorMessage = "La disponibilité est obligatoire")]
        public bool IsAvailable { get; set; } = true;

    }
}
