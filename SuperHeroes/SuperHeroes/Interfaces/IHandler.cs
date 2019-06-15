using System;
namespace SuperHeroes.Interfaces
{
    public interface IHandler<T>
    {
        T ApplySorting();
    }
}
