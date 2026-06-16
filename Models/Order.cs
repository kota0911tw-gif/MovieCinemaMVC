namespace WebApplication1.Models;

public class Order
{
    public int Id { get; set; }

    public string MovieTitle { get; set; } = "";

    public decimal Price { get; set; }

    public DateTime OrderDate { get; set; }
}