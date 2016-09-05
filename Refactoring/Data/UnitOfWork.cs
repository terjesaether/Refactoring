using Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refactoring.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IShopContext _db;

        public UnitOfWork(IShopContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}