using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Une adresse mail est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide")]
        public string Email { get; set; }

    }
}
