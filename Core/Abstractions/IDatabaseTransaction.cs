using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
