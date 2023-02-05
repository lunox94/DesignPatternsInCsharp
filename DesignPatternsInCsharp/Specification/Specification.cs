namespace DesignPatternsInCsharp.Specification;

public interface ISpecification<TEntity>
{
    ISpecification<TEntity> And(ISpecification<TEntity> right);

    bool IsSatisfiedBy(TEntity entity);
    
    ISpecification<TEntity> Not();
    
    ISpecification<TEntity> Or(ISpecification<TEntity> right);
}

public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    public ISpecification<TEntity> And(ISpecification<TEntity> right)
    {
        return new AndSpecification<TEntity>(this, right);
    }

    public abstract bool IsSatisfiedBy(TEntity entity);

    public ISpecification<TEntity> Not()
    {
        return new NotSpecification<TEntity>(this);
    }

    public ISpecification<TEntity> Or(ISpecification<TEntity> right)
    {
        return new OrSpecification<TEntity>(this, right);
    }
}

public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
{
    protected readonly ISpecification<TEntity> Left;

    protected readonly ISpecification<TEntity> Right;

    protected CompositeSpecification(ISpecification<TEntity> left,
        ISpecification<TEntity> right)
    {
        Left = left;
        Right = right;
    }
}

public class AndSpecification<TEntity> : CompositeSpecification<TEntity>
{
    public AndSpecification(ISpecification<TEntity> left,
        ISpecification<TEntity> right) : base(left, right)
    {
    }

    public override bool IsSatisfiedBy(TEntity entity)
    {
        return Left.IsSatisfiedBy(entity) && Right.IsSatisfiedBy(entity);
    }
}

public class NotSpecification<TEntity> : Specification<TEntity>
{
    private readonly ISpecification<TEntity> _origin;

    public NotSpecification(ISpecification<TEntity> origin)
    {
        _origin = origin;
    }

    public override bool IsSatisfiedBy(TEntity entity)
    {
        return !_origin.IsSatisfiedBy(entity);
    }
}

public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
{
    public OrSpecification(ISpecification<TEntity> left,
        ISpecification<TEntity> right) : base(left, right)
    {
    }

    public override bool IsSatisfiedBy(TEntity entity)
    {
        return Left.IsSatisfiedBy(entity) | Right.IsSatisfiedBy(entity);
    }
}