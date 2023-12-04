namespace ExerciseOopHierarchy;

public abstract class MenuItem
{
    private string name { get; set; }
    private string description { get; set; }
    private decimal price { get; set; }

    public string Name { get { return name; } set { this.Name = value; } }

    public string Description { get { return description; } set { this.Description = value; } }
    public decimal Price { get { return price; } set { this.Price = value; } }

    public MenuItem(string name, string description, decimal price) {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Description} - ${this.Price}";
    }
}
