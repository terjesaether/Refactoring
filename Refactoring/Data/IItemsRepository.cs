using System.Collections.Generic;
using Refactoring.Models;
using System;

namespace Refactoring.Data
{
    public interface IItemsRepository : IDisposable
    {
        Item Add(Item item);
        List<Item> GetAll();
        Item GetById(int id);
        void Update(Item item);
        void Delete(int id);
        //void Dispose();
    }
}