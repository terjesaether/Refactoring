using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Refactoring.Models;
using System.Data.Entity;

namespace Refactoring.Data
{
    public class ItemsRepository : IDisposable, IItemsRepository
    {
        private readonly IShopContext _db;

        //public ItemsRepository()
        //{
        //    _db = new ApplicationDbContext();
        //}

        public ItemsRepository(IShopContext db)
        {
            _db = db;
        }

        public List<Item> GetAll()
        {
            return _db.Items.ToList();
        }

        public Item GetById(int id)
        {
            return _db.Items.Find(id);
        }

        public Item Add(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void Update(Item item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}