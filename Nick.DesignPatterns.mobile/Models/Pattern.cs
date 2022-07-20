namespace DesignPatterns.Models;

public class Pattern
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<string> Images { get; set; }
    public string Icon { get; set; }
}