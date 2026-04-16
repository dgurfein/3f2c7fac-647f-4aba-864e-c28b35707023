using ArrayProcessor.Application.Common.Parsers;
using ArrayProcessor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Parsers
{
    internal class IntArrayParser : ArrayParser<int>
    {
        protected override int ParseElement(string element)
        {
            try 
            { 
                return int.Parse(element);
            }
            catch 
            {
                throw;
            }
        }
    }
}
