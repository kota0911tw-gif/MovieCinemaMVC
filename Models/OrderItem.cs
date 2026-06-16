namespace WebApplication1.Models;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MovieId { get; set; }

    public string MovieTitle { get; set; } = "";

    public decimal Price { get; set; }
}