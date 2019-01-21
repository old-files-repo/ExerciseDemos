using System;
using HATEOAS.Data;
using HATEOAS.DomainModel;

namespace HATEOAS.Repositorys
{
    public interface IEntityBaseRepository<T> where T : EntityBase, new()
    {
        void Add();
        void Update();
        void Delete();
        void Get();
    }

    public abstract class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : EntityBase, new()
    {
        protected SalesContext Context { get; }

        public EntityBaseRepository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork as SalesContext;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
