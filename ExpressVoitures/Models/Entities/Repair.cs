using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class Repair
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prix des réparations est obligatoire")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "La descriptions des réparations effectuées est obligatoire")]
        public string Description { get; set; }
    }
}
