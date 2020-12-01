# Entity Framework Repository (library)

The main task of this libraries its easy provide for access to your data

## How to work
To use, you need to inherit your repository class with the **CRUDRepository<Entity, Id, YourDbContext>** where:  
***Entity*** - your class for creating Repository  
***Id*** - type of your entity Id  
***YourDbContext*** - your class which inherit from DbContext

## Setting

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

```csharp
public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }
}
```

```csharp
public class PersonRepository : CRUDRepository<Person, string, PersonContext>
{
    public PersonRepository(PersonContext db):base(db){}
}
```

# Usage

```csharp
PersonRepository personRepository = new PersonRepository(new PersonContext());

var users = await personRepository.GetAllAsync(); //now this method available
```


## Define
Interface have next methods (1.0.6):
```csharp
    public interface ICRUDRepository<TEntity, TypeId> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
        Task<TEntity> GetByIdAsTrackingAsync(TypeId Id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FirstAsync();
        Task<TEntity> LastAsync();
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> match);
        Task<long> CountLongAsync();
        Task<long> CountLongAsync(Expression<Func<TEntity, bool>> match);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match, int count, int skip);
        Task<List<TEntity>> FindListAsTrackingAsync(Expression<Func<TEntity, bool>> match);
    }
```
