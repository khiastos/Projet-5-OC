using System.ComponentModel.DataAnnotations;
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

        public double? SellingPrice { get; set; }

        [Display(Name = "Année")]
        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1950, 2025, ErrorMessage = "Rentrez une année valide entre 1950 et 2025")]
        public int? Year { get; set; }

        [Display(Name = "Disponible à la vente")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Finition")]
        [Required(ErrorMessage = "Les finitions sont obligatoires")]
        public required string Finish { get; set; }

        [Display(Name = "Marque")]
        public Brand? Brand { get; set; }
        [Display(Name = "Marque")]
        public int BrandId { get; set; }

        [Display(Name = "Modèle")]
        public Model? Model { get; set; }
        [Display(Name = "Modèle")]
        public int ModelId { get; set; }

        [Display(Name = "Photo de la voiture")]
        public string? ImageUrl { get; set; }
    }

}

