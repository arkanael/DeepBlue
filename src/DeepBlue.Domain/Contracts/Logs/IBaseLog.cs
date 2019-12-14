using System;

namespace DeepBlue.Domain.Contracts.Logs
{
    public interface IBaseLog<TEnity> : IDisposable where TEnity : class
    {
        void Create(TEnity entity, string message, DateTime dateHora);


    }
}
