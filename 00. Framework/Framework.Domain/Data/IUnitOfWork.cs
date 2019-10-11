using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
