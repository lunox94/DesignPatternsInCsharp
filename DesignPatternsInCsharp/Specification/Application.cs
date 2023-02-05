namespace DesignPatternsInCsharp.Specification;

public class TableLegsSpecification : Specification<Table>
{
    public TableLegsSpecification(int legs)
    {
        Legs = legs;
    }

    private int Legs { get; }

    public override bool IsSatisfiedBy(Table entity)
    {
        return entity.Legs == Legs;
    }
}

public class TableMaterialSpecification : Specification<Table>
{
    public TableMaterialSpecification(string material)
    {
        Material = material;
    }

    private string Material { get; }

    public override bool IsSatisfiedBy(Table entity)
    {
        return entity.Material == Material;
    }
}

public class TableTypeSpecification : Specification<Table>
{
    public TableTypeSpecification(string type)
    {
        Type = type;
    }

    private string Type { get; }

    public override bool IsSatisfiedBy(Table entity)
    {
        return entity.Type == Type;
    }
}

public class TableSizeSpecification : Specification<Table>
{
    public TableSizeSpecification(string size)
    {
        Size = size;
    }

    private string Size { get; }

    public override bool IsSatisfiedBy(Table entity)
    {
        return entity.Size == Size;
    }
}

public class SchoolTableSpecification : Specification<Table>
{
    private readonly ISpecification<Table> _fourLegsTableSpecification =
        new TableLegsSpecification(legs: 4);

    private readonly ISpecification<Table> _woodTableSpecification =
        new TableMaterialSpecification(material: "Wood");
    
    private readonly ISpecification<Table> _plasticTableSpecification =
        new TableMaterialSpecification(material: "Plastic");

    private readonly ISpecification<Table> _scholarTableSpecification =
        new TableTypeSpecification(type: "Scholar");

    private readonly ISpecification<Table> _largeSizeTableSpecification =
        new TableSizeSpecification(size: "Large");

    public override bool IsSatisfiedBy(Table entity)
    {
        return _fourLegsTableSpecification
            .And(_woodTableSpecification.Or(_plasticTableSpecification))
            .And(_scholarTableSpecification)
            .And(_largeSizeTableSpecification.Not())
            .IsSatisfiedBy(entity);
    }
}

public class Table
{
    public Table(int legs, string material, string type, string size)
    {
        Legs = legs;
        Material = material;
        Type = type;
        Size = size;
    }

    public int Legs { get; set; }
    public string Material { get; set; }
    public string Type { get; set; }
    public string Size { get; set; }
}