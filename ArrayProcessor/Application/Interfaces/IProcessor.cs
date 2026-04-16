using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    /// <summary>
    /// Data processor, takes input of type TInput, process it and returns TOutput
    /// </summary>
    /// <typeparam name="TInput">Input type</typeparam>
    /// <typeparam name="TOutput">Output type</typeparam>
    public interface IProcessor<TInput, TOutput>
    {
        TOutput Process(TInput input);
    }
}
