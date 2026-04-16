using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    /// <summary>
    /// A generic use case that can be processed by this Data Processor
    /// </summary>
    public interface IUseCase
    {
        /// <summary>
        /// The Name of the use case, used as a key to get/resolve the use case when injected.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The input prompt message, to be displayed when asking for input in interactive mode
        /// </summary>
        string Prompt { get; }
        /// <summary>
        /// Description of command line usage for the input part, displayed in case of parsing errors
        /// </summary>
        string CommandLineUsage { get; }
        /// <summary>
        /// A parser implementation of the input
        /// </summary>
        /// <param name="rawInput">input as provided by user or other sources</param>
        /// <returns>object of type expected by this use case validator and processor</returns>
        object ParseInput(string rawInput);
        /// <summary>
        /// An input validator implementation, to verify input is valid before it is being processed
        /// </summary>
        /// <param name="input">input of the use case DTO type, need to match the type returned by the parser</param>
        void ValidateInput(object input);
        /// <summary>
        /// The use case process implementation. Process the input and returns the defined use case output
        /// </summary>
        /// <param name="input"></param>
        /// <returns>object of use case DTO result type</returns>
        object Process(object input);
        /// <summary>
        /// A formatter that turns the provided result into a presented string
        /// </summary>
        /// <param name="result">the result to present, must be of the use case DTO result type</param>
        /// <returns>string to display</returns>
        string FormatOutput(object result);
    }
}
