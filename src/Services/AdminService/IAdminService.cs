using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Database.Repositories.MyTest;
using Qubiz.QuizEngine.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Services.AdminService
{
    public interface IAdminService
    {
        Task<ValidationError[]> AddAdminAsync(MyAdmin admin, string originator);
        Task<ValidationError[]> DeleteAdminAsync(Guid id, string originator);
        Task<ValidationError[]> UpdateAdminAsync(MyAdmin admin, string originator);
        Task<MyAdmin[]> GetAllAdminsAsync();
        Task<MyAdmin> GetAdminAsync(Guid id);
    }
}