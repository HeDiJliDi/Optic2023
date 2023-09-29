using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
<<<<<<< HEAD
using DocumentFormat.OpenXml.InkML;
=======
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Domain.Common.Contracts;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using System.Threading;
=======
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3

namespace FSH.WebApi.Infrastructure.Persistence.Repository;

// Inherited from Ardalis.Specification's RepositoryBase<T>
public class ApplicationDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public ApplicationDbRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

<<<<<<< HEAD
  
    public Task<IEnumerable<object>> GetBySpecAsync()
    {
        throw new NotImplementedException();
    }

=======
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3
    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    // This is only done when no Selector is defined, so regular specifications with a selector also still work.
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
}