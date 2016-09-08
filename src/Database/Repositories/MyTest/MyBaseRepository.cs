using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Database.Repositories.MyTest
{
    public class MyBaseRepository<TModel, DbModel>where DbModel : class
        where TModel:class
    {
        protected DbContext dbContext;
        protected DbSet<DbModel> dbSet;

        protected UnitOfWork unitOfWork;

        public MyBaseRepository(DbContext context, UnitOfWork unitOfWork)
        {
            this.dbContext = context;
            this.dbSet = dbContext.Set<DbModel>();
            this.unitOfWork = unitOfWork;
        }

        public System.Collections.Generic.IEnumerable<TModel> GetAll()
        {
            var query = from t in dbSet select t;
            return query.DeepCopyTo<TModel[]>();
        }

        public async Task<TModel> GetByIDAsync(int? id)
        {
            DbModel dbModel= await dbSet.FindAsync(id);
            TModel tModel = dbModel.DeepCopyTo<TModel>();
            return tModel;
        }

        public void Create(TModel model)
        {
            DbModel dbModel = model.DeepCopyTo<DbModel>();
            dbSet.Add(dbModel);
        }

        public void Update(TModel model)
        {
            DbModel dbModel = model.DeepCopyTo<DbModel>();
            dbSet.Attach(dbModel);
            dbContext.Entry(dbModel).State = EntityState.Modified;
        }
        public void Delete(TModel model)
        {
            DbModel dbModel = model.DeepCopyTo<DbModel>();
            if (dbContext.Entry(dbModel).State == EntityState.Detached)
            {
                dbSet.Attach(dbModel);
            }
            dbSet.Remove(dbModel);
        }

        public virtual void Upsert<TModel, DbModel>(TModel entity)
            where DbModel : class, IEntity
            where TModel:class
        {

            if (entity == null) throw new System.NullReferenceException("Value cannot be null");

            DbModel dbEntity = entity.DeepCopyTo<DbModel>();

            DbModel existingEntity = dbContext.Set<DbModel>().Find(dbEntity.ID);

            if (existingEntity == null)
            {
                dbContext.Set<DbModel>().Add(dbEntity);
            }
            else
            {
                Mapper.Map(entity, existingEntity);
            }
            dbContext.SaveChanges();
        }
    }
}
