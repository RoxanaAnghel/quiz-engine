using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Database.Repositories.MyTest;
using System;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Database.Repositories
{
    public interface IAdminRepository
    {
        Task<MyAdmin[]> ListAsync();

        Task<MyAdmin> GetByIDAsync(Guid id);

        Task<MyAdmin> GetByNameAsync(string name);

        void Create(MyAdmin model);

        void Update(MyAdmin model);

        void Delete(MyAdmin model);
    }
}