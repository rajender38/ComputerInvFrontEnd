using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersInventory.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputersInventory.DAL.Repositories.BaseRepositories
{
    public abstract class BaseEntityCrudRepository<T> : BaseEntityRepository<T>, IBaseEntityCrudRepository<T>
        where T : class
    {

        protected BaseEntityCrudRepository(ComputerInventoryContext dbContext) :
            base(dbContext)
        {
        }

        public async Task<int> Create(T record)
        {

            dbContext.Set<T>().Add(record);
            await dbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<T> Update(T record)
        {


            var objectIdentifier = GetEntityKey(dbContext, record);

            var entity = await dbContext.Set<T>().FindAsync(objectIdentifier);

            if (entity == null)
                throw new Exception($"Record of type [{record.GetType()}] is not found");
            dbContext.Entry(entity).CurrentValues.SetValues(record);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Delete(T record)
        {

            var objectIdentifier = GetEntityKey(dbContext, record);

            var entity = dbContext.Set<T>().Find(objectIdentifier);
            dbContext.Set<T>().Remove(entity ?? throw new InvalidOperationException());
            await dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<T> GetSingleAsync(int identifier)
        {

            return await dbContext.Set<T>().FindAsync(identifier);
        }

        private static int GetEntityKey(DbContext context, T entity)
        {
            if (context == null)
                throw new NullReferenceException("context");

            var keyName = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            return (int)entity.GetType().GetProperty(keyName).GetValue(entity, null);

        }
    }
}
