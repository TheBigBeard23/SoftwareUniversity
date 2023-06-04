using System.Collections;

namespace MiniORM;

public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal DbSet(IEnumerable<TEntity> entities)
    {
        Entities = entities.ToList();
        ChangeTracker = new ChangeTracker<TEntity>(entities);
    }

    internal ChangeTracker<TEntity> ChangeTracker { get; set; }

    internal IList<TEntity> Entities { get; set; }

    public int Count 
        => Entities.Count;

    public bool IsReadOnly 
        => Entities.IsReadOnly;

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        Entities.Add(entity);
        ChangeTracker.Add(entity);
    }

    public bool Remove(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        bool isRemoved = Entities.Remove(entity);
        if (isRemoved)
        {
            ChangeTracker.Remove(entity);
        }

        return isRemoved;
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            Remove(entity);
        }
    }

    public void Clear()
    {
        while (Entities.Any())
        {
            TEntity entityToDelete = Entities.First();
            Remove(entityToDelete);
        }
    }

    public bool Contains(TEntity entity) 
        => Entities.Contains(entity);

    public void CopyTo(TEntity[] array, int arrayIndex) 
        => Entities.CopyTo(array, arrayIndex);

    public IEnumerator<TEntity> GetEnumerator() 
        => Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();
}

