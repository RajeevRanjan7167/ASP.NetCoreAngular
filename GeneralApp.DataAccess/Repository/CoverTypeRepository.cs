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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverType coverType)
        {
            var objFormDB = _db.CoverTypes.FirstOrDefault(c => c.id == coverType.id);
            if (objFormDB != null)
            {
                objFormDB.Name = coverType.Name;
            }
        }
    }
}
