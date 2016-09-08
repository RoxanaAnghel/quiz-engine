using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Database.Repositories.MyTest;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Database.Repositories
{
    public class AdminRepository : MyBaseRepository<Admin,MyAdmin>, IAdminRepository
    {
        public AdminRepository(QuizEngineDataContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public async Task<MyAdmin[]> ListAsync()
        {
            return await dbSet.ToArrayAsync();
        }

        public async Task<MyAdmin> GetByIDAsync(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<MyAdmin> GetByNameAsync(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public void Create(MyAdmin model)
        {
            throw new NotImplementedException();
        }

        public void Update(MyAdmin model)
        {
            throw new NotImplementedException();
        }

        public void Delete(MyAdmin model)
        {
            throw new NotImplementedException();
        }
    }
}