using System.Drawing;

namespace PM3PatternMatching.Data;

public class Enclosure
{
    public Point Position { get; init; }

    public List<Animal> Animals { get; set; } = new();
}