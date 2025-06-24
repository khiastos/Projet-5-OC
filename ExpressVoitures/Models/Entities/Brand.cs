using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class Brand
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom de la marque est obligatoire")]
        public required string Name { get; set; }
    }
}
