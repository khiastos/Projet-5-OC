using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'URL de l'image est obligatoire")]
        [RegularExpression(@"^(http|https)://.*\.(jpg|jpeg|png|gif)$", ErrorMessage = "L'URL doit être une image valide (jpg, jpeg, png, gif)")]
        public string Url { get; set; }

        [Required(ErrorMessage = "La description de l'image est obligatoire")]
        [StringLength(100, ErrorMessage = "La description ne peut pas dépasser 100 caractères")]
        public string Description { get; set; }
    }
}
