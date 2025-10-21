namespace MINICORE.Models
{
    public class Sale
    {
     
            public int Id_Sale { get; set; }

            public int SellerlId { get; set; }
            public Seller Seller { get; set; }

            public DateTime SaleDate{ get; set; }
            public decimal Amount { get; set; }

    }
}

