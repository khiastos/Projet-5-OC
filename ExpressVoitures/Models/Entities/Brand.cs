using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la marque est obligatoire")]
        [Display(Name= "Nom")]
        public required string Name { get; set; }
    }
}
