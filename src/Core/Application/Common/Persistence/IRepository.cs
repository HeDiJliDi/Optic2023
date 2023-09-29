<<<<<<< HEAD
﻿
namespace FSH.WebApi.Application.Common.Persistence;
=======
﻿namespace FSH.WebApi.Application.Common.Persistence;
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3

// The Repository for the Application Db
// I(Read)RepositoryBase<T> is from Ardalis.Specification

/// <summary>
/// The regular read/write repository for an aggregate root.
/// </summary>
public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
<<<<<<< HEAD
    
    Task<IEnumerable<object>> GetBySpecAsync();
=======
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3
}

/// <summary>
/// The read-only repository for an aggregate root.
/// </summary>
public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

/// <summary>
/// A special (read/write) repository for an aggregate root,
/// that also adds EntityCreated, EntityUpdated or EntityDeleted
/// events to the DomainEvents of the entities before adding,
/// updating or deleting them.
/// </summary>
public interface IRepositoryWithEvents<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}