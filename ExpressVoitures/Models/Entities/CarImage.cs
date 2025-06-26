using System.ComponentModel.DataAnnotations;

namespace Projet_5.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
    }
}
