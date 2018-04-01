using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IOption
    {
        string Name { get; }
        bool Checked { get; set; }
        Property[] Properties { get; }
    }
}
