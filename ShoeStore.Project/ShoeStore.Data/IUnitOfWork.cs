using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
