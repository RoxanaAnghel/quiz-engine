using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Database.Repositories.MyTest;
using Qubiz.QuizEngine.Infrastructure;
using Qubiz.QuizEngine.Services.AdminService;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Qubiz.QuizEngine.Areas.M.Controllers.Api
{
    [Admin]
    public class AdminController : ApiController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAdmin(Guid id)
        {
            MyAdmin admin = await adminService.GetAdminAsync(id);
            return Ok(admin);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAdmins()
        {
            MyAdmin[] admins = await adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddAdmin([FromBody]MyAdmin admin)
        {
            ValidationError[] validationErrors = await adminService.AddAdminAsync(admin, User.Identity.Name);
            if (validationErrors.Length == 0)
            {
                ApplicationMemoryCache.Instance.Remove("GetAllAdmins()");
                return Ok();
            }

            return BadRequest(validationErrors[0].Message);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAdmin(Guid id)
        {
            ValidationError[] validationErrors = await adminService.DeleteAdminAsync(id, User.Identity.Name);

            if (validationErrors.Length == 0)
            {
                ApplicationMemoryCache.Instance.Remove("GetAllAdmins()");
                return Ok();
            }

            return BadRequest(validationErrors[0].Message);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAdmin([FromBody]MyAdmin admin)
        {
            ValidationError[] validationErrors = await adminService.UpdateAdminAsync(admin, User.Identity.Name);

            if (validationErrors.Length == 0)
            {
                ApplicationMemoryCache.Instance.Remove("GetAllAdmins()");
                return Ok();
            }

            return BadRequest(validationErrors[0].Message);
        }
    }
}