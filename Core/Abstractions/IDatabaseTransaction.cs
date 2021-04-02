using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
