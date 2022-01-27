using System;
using System.Collections.Generic;
using System.Text;

namespace WorkListGenerator.Model
{
    public interface IGeneratorRule<T>
    {
        T Generate();
    }

}
