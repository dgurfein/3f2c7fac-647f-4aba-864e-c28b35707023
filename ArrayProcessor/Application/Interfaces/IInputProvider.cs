using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    /// <summary>
    /// Interface for reading input
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Prompt for requested input and read response from the input source
        /// </summary>
        /// <param name="prompt">The prompt to use for interactive input source</param>
        /// <returns></returns>
        string Read(string prompt);
    }
}
