using System;

namespace FuelLog.Dal
{
    public interface IDalManager : IDisposable
    {
        T GetProvider<T>() where T : class;
    }
}
