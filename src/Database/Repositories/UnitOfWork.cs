﻿using Qubiz.QuizEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly QuizEngineDataContext dbContext;

        private IFeatureFlagRepository featureFlagRepository;
        private IAdminRepository AdminsRepository;

        public UnitOfWork(IConfig config)
        {
            dbContext = new QuizEngineDataContext(config.ConnectionString);
        }

        public IFeatureFlagRepository FeatureFlagRepository
        {
            get
            {
                if (this.featureFlagRepository == null)
                {
                    this.featureFlagRepository = new FeatureFlagRepository(this.dbContext, this);
                }

                return this.featureFlagRepository;
            }
        }

        public IAdminRepository AdminRepository
        {
            get
            {
                if (this.AdminRepository == null)
                {
                    this.AdminsRepository = new AdminRepository(this.dbContext, this);
                }
                return this.AdminsRepository;
            }
        }

        /*  public IAdminRepository AdminRepo
 {
     get
     {
         if (this.AdminRepository == null)
         {
             this.AdminsRepository = new AdminRepository(this.dbContext, this);
         }
         return this.AdminsRepository;
     }
 }

*/

        public async Task SaveAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
