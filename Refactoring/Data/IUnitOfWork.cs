using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refactoring.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

    
}
