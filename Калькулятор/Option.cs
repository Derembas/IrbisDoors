using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калькулятор
{
    class Option
    {
        public bool Nalich { get; set; } // Наличие опции
        public string Name { get; set; } // Имя опции
        public double Price { get; set; } // Стоимость

    }

    // Опция бампер
    class BampOpc : Option
    {
        public string Mater { get; set; } // Материал бампера
        public int Height { get; set; } // Высота бампера
    }

    // Опция порог
    class PorogOpc: Option
    {
        public string Mater { get; set; } // Материал порога
        public string Type { get; set; } // Тип порога
    }

    // Опция материал
    class MaterOpc: Option
    {
        public string Mater { get; set; }
        public string Color { get; set; }
    }

    // Класс список опций
    class Options
    {
        private List<Option> options; //
    }
}
