using System;
using System.Collections.Generic;

namespace SuperHeroes.Interfaces
{
    public interface IFileReader<T>
    {
        List<T> ReadFromFile();
    }
}
