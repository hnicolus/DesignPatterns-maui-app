using Markdig;

namespace DesignPatterns.Models;

public class Pattern
{
    private string description;

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get => description; set => description = value; }
    public List<string> Images { get; set; }
    public string Icon { get; set; }
    public Pattern()
    {
    }

}
