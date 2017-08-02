﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калькулятор
{
    class MDDoor: Door
    {
        public string SubTypeName
        {
            get
            {
                return AllSubTypes[(int)SubType];
            }
            set
            {
                for(int i=0; i<AllSubTypes.Count();i++)
                {
                    if(AllSubTypes[i]==value)
                    {
                        SubType = (MDSubTypes)i;
                        break;
                    }
                }
            }
        }
        public MDSubTypes SubType { get; set; }  // Тип двери. Свойство
        public string[] SubTypes { get { return AllSubTypes; } }

        private string[] AllSubTypes = new string[] { "МДО(ОН)" , "МДД(ОН)" , "МДО(СН)" , "МДД(СН)" };

        public MDDoor() { }

        public MDDoor(MDSubTypes subType, int width, int height, byte count):base(width, height, count)
        {
            SubType = subType;
        }

        public override void Open()
        {
            MDWindow NewWindow = new MDWindow();
            NewWindow.DataContext = this;
            NewWindow.ShowDialog();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", AllSubTypes[(int)SubType], base.ToString());
        }
    }
}
