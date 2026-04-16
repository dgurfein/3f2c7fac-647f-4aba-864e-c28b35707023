using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessor.Application.Interfaces
{
    public interface IUseCaseResolver
    {
        /// <summary>
        /// get the use case matching provided name
        /// </summary>
        /// <param name="name">use case name</param>
        /// <returns></returns>
        IUseCase Resolve(string name);
    }
}
