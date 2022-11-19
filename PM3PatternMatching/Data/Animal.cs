namespace PM3PatternMatching.Data;

public abstract class Animal
{
    public string Name { get; set; } = null!;
    
    public virtual bool IsDangerous { get; }

    public Enclosure Enclosure { get; set; } = null!;

    public virtual string Group { get; } = null!;

    public virtual string AnimalName { get; } = null!;
    
    public virtual string? Description { get; set; }
    
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{AnimalName} ({Group}) {Name} {Description}";
    }

    public void Deconstruct(out string name, out string group, out string animalName, 
        out string? description, out bool isDangerous)
    {
        name = Name;
        isDangerous = IsDangerous;
        group = Group;
        animalName = AnimalName;
        description = Description;
    }
}