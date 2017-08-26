namespace SklepInternetowy.Models
{
    public class OrderPosition
    {
        public int OrderPositionId { get; set; }
        public int OrderId { get; set; }
        public int SupplementId { get; set; }
        public int Amount { get; set; }
        //public decimal PurchasePrice { get; set; }

        public virtual Supplement Supplement { get; set; }
        public virtual Order Order { get; set; }

    }
}