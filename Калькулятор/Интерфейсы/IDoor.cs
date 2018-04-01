using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IDoor
    {
        string Type { get; set; } // Тип двери
        int Width { get; set; } // Ширина двери
        int Height { get; set; } // Высота двери
        string OpenSide { get; set; } // Сторона отурывания двери
        int Count { get; set; } // Количество дверей

        IOption[] Options { get; }
    }
}
