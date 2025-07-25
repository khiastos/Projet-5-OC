using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class Model
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du modèle est obligatoire")]
        [Display(Name = "Nom")]
        public required string Name { get; set; }
    }
}
