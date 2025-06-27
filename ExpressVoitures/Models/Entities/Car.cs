using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projet_5.Models.Entities;

namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Prix de vente")]
        [Required(ErrorMessage = "Le prix de vente est obligatoire")]
        [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide avec jusqu'à deux décimales.")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]

        public double SellingPrice { get; set; }

        [Display(Name = "Année")]
        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1900, 1990, ErrorMessage = "Saississez une année entre 1900 et 1990")]
        public int Year { get; set; }

        [Display(Name = "Disponibilité")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Finition")]
        [Required(ErrorMessage = "Les finitions sont obligatoires")]
        public required string Finish { get; set; }
        public int BrandId { get; set; }
        [Display(Name = "Marque")]
        public Brand? brand { get; set; }
        public int ModelId { get; set; }
        [Display(Name = "Modèle")]
        public Model? model { get; set; }

        [Display(Name = "Photo de la voiture")]
        [NotMapped] public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
    }

}

