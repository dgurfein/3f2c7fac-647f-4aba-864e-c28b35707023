using ArrayProcessor.Application.Interfaces;

namespace ArrayProcessor.Presentation
{
    /// <summary>
    /// Output writer implementation for console output
    /// </summary>
    internal class ConsoleWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
