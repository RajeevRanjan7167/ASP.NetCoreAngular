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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        }
    }
}
