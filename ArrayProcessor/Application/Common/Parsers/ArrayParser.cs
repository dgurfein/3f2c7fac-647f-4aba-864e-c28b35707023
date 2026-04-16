using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Common.Parsers
{
    /// <summary>
    /// A generic array parser, to parse given a string to an array of elements
    /// </summary>
    /// <typeparam name="T">The type of the array</typeparam>
    internal abstract class ArrayParser<T>
    {
        /// <summary>
        /// Provide a parser that turns single element input to type T and return it
        /// </summary>
        /// <param name="element">a string representing the element to parse</param>
        /// <returns>object of type T</returns>
        protected abstract T ParseElement(string element);
        /// <summary>
        /// Parse a given input string in csv format to an array of elements of type T
        /// </summary>
        /// <param name="rawInput">a csv string, each token in the string represent an element</param>
        /// <param name="separator">separator string to use between array elements, default is ","</param>
        /// <returns>Array of elements of type T</returns>
        /// <exception cref="Exception">Parsing issues if input is not in expected format or elements do not match the type</exception>
        public T[] Parse(string rawInput, string separator=",")
        {
            Type elementType = typeof(T);
            try
            {
                T[] elements = rawInput
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => ParseElement(s.Trim()))
                    .ToArray();
                return elements;
            }
            catch (Exception ex)
            {
                throw new Exception($"Parsing failed for '{rawInput}', Input must be a list of {elementType.Name} elements, separated by '{separator}'.", ex);
            }
        }
    }
}
