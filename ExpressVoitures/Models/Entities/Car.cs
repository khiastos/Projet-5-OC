using System.ComponentModel.DataAnnotations;
using Projet_5.Models.Entities;

namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le prix de vente est obligatoire")]
        [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public double SellingPrice { get; set; }

        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1900, 1990, ErrorMessage = "Saississez une année entre 1900 et 1990")]
        public int Year { get; set; }

        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Les finitions sont obligatoires")]
        public required string Finish { get; set; }

        public int BrandId { get; set; }
        public Brand? brand { get; set; }

        public int ModelId { get; set; }
        public Model? model { get; set; }
        public int? CarImageId { get; set; }
        //public CarImage? CarImage { get; set; }

    }
}
