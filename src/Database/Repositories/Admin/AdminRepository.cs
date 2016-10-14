using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Database.Repositories.MyTest;
using Qubiz.QuizEngine.Infrastructure;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Database.Repositories
{
    public class AdminRepository : MyBaseRepository<MyAdmin,Admin>, IAdminRepository
    {
        public AdminRepository(QuizEngineDataContext context, UnitOfWork unitOfWork)
            : base(context, unitOfWork)
        { }

        public async Task<MyAdmin[]> ListAsync()
        {
            Admin[] admins= await dbSet.ToArrayAsync();
            MyAdmin[] myAdmins = admins.DeepCopyTo<MyAdmin[]>();
            return myAdmins;
        }

        public async Task<MyAdmin> GetByIDAsync(Guid id)
        {
            Admin admin = await dbSet.FirstOrDefaultAsync(x => x.ID == id);
            MyAdmin myAdmin = admin.DeepCopyTo<MyAdmin>();
            return myAdmin;
        }

        public async Task<MyAdmin> GetByNameAsync(string name)
        {
            Admin admin = await dbSet.FirstOrDefaultAsync(x => x.Name == name);
            MyAdmin myAdmin = admin.DeepCopyTo<MyAdmin>();
            return myAdmin;
        }
    }
}