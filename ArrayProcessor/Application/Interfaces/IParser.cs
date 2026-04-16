using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    /// <summary>
    /// Parser of given input, used to parse provided input into the requested type for next processing step
    /// </summary>
    /// <typeparam name="T">The output type</typeparam>
    public interface IParser<T>
    {
        T Parse(string input);
    }
}
