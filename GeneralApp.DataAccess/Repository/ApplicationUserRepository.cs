using GeneralApp.DataAccess.Data;
using GeneralApp.DataAccess.Repository.IRepository;
using GeneralApp.Models;
using GeneralApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralApp.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
