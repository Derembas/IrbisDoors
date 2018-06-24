using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IProperty
    {
        bool IsEnabled { get; set; }
        object Value { get; set; }
    }
}
