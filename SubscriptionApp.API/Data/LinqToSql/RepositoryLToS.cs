using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Infrastructure.Querying;
using SubscriptionApp.API.Infrastructure.UnitOfWork;

namespace SubscriptionApp.API.Data.LinqToSql
{
    public abstract class RepositoryLToS<T, TEntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public RepositoryLToS(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
           
        }

        public void Remove(T entity)
        {
           
        }

        public void Save(T entity)
        {
            
        }

        public T FindBy(TEntityKey id)
        {
             throw new NotImplementedException();
        }

        public async Task<T> FindByAsync(TEntityKey id)
        {
             throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAllAsync(int index, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindBy(Query query)
        {
             throw new NotImplementedException();
        }

         public async Task<IEnumerable<T>> FindByAsync(Query query)
        {
             throw new NotImplementedException();
        }        

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
             throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindByAsync(Query query, int index, int count)
        {
             throw new NotImplementedException();
        }             
    }
}