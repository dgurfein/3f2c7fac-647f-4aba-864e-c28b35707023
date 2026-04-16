using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    /// <summary>
    /// Intefacr for writing output
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Write provided message to the designated output
        /// </summary>
        /// <param name="message">message to write</param>
        void Write(string message);
    }
}
