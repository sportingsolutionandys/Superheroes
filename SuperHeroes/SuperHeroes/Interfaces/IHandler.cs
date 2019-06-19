using System;
namespace SuperHeroes.Interfaces
{
    /// <summary>
    /// Handler Interface for retreiving characters
    /// </summary>
    public interface IHandler<T>
    {
        T GetCharacters();
    }
}
