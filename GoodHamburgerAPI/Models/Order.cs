namespace GoodHamburgerAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int SandwichId { get; set; }
        public int? FriesId { get; set; } // Nullable, pois o cliente pode não pedir batata frita
        public int? DrinkId { get; set; } // Nullable, pois o cliente pode não pedir refrigerante
        public decimal TotalAmount { get; set; }
    }
}
