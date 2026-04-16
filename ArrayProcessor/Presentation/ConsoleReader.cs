using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayProcessor.Application.Interfaces;

namespace ArrayProcessor.Presentation
{
    /// <summary>
    /// Input provider implementation for console input
    /// </summary>
    internal class ConsoleReader : IInputProvider
    {
        public string Read(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
