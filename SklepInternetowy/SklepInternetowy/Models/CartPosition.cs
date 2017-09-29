namespace SklepInternetowy.Models
{
    public class CartPosition
    {
        public Supplement Supplement { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}