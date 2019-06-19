using System;
using System.Collections.Generic;

namespace SuperHeroes.Interfaces
{
    /// <summary>
    /// File reader interface.
    /// </summary>
    public interface IFileReader<T>
    {
        List<T> ReadFromFile();
    }
}
