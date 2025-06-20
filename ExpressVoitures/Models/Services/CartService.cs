using ExpressVoitures.Models.Entities;
using Projet_5.Models.Services.Interfaces;

public class Cart : ICartService
{
    private readonly List<CartLine> _cartLines;

    public Cart()
    {
        _cartLines = new List<CartLine>();
    }

    public void AddItem(CarToSells car)
    {
        var line = _cartLines.FirstOrDefault(c => c.Car.ID == car.ID);
        if (line == null)
        {
            _cartLines.Add(new CartLine { Car = car });
        }
    }

    public void RemoveLine(CarToSells car)
    {
        _cartLines.RemoveAll(c => c.Car.ID == car.ID);
    }
    public double GetTotalValue()
    {
        return _cartLines.Sum(l => l.Car.Price);
    }

    public void Clear() => _cartLines.Clear();
}

public class CartLine
{
    public int OrderLineId { get; set; }
    public CarToSells Car { get; set; }
}