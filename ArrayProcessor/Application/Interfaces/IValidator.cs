using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    public interface IValidator<T>
    {
        /// <summary>
        /// Validate the input, throws exception when validation fails
        /// </summary>
        /// <param name="input"></param>
        void Validate(T input);
    }
}
