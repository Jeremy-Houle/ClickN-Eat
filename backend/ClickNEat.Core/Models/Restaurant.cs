namespace ClickNEat.Core.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string CoverImageUrl { get; set; } = "";
    public string AccentColor { get; set; } = "#FF416C";
    public string LogoUrl { get; set; } = "";
}
