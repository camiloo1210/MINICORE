namespace MINICORE.Models
{
    public class Seller
    {
        public int Id_Seller { get; set; }
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
