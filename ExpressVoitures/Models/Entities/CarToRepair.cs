
using System.ComponentModel.DataAnnotations;

public class CarToRepair
{
    public int ID { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime OnSaleDate { get; set; }

    [Required(ErrorMessage = "Le prix d'achat est obligatoire")]
    [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix d'achat doit être un nombre valide avec jusqu'à deux décimales.")]
    [Range(0.01, int.MaxValue, ErrorMessage = "Le prix d'achat doit être supérieur à 0")]
    public int PurchasePrice { get; set; }

    [Required(ErrorMessage = "Le prix des réparations est obligatoire")]
    [RegularExpression(@"^-?\d+([.,]\d{1,2})?$", ErrorMessage = "Le prix des réparations doit être un nombre valide avec jusqu'à deux décimales.")]
    [Range(0.01, int.MaxValue, ErrorMessage = "Le prix des réparations doit être supérieur à 0")]
    public int RepairCost { get; set; }
    public string? Repair { get; set; }
}

