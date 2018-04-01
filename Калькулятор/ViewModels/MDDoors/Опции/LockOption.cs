using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MDDoors
{
    public class LockOption: IOption
    {
        public string Name { get { return "Запорное устройство"; } }
        public bool Checked { get; set; }

        public double Price { get; set; }

        public Property LockType { get; private set; }
        public Property[] Properties { get; private set; }

        #region Конструктор

        public LockOption()
        {
            object[] Locks = new object[] 
            {
                Helpers.AllNames.MDLockTypes.hingedLock,
                Helpers.AllNames.MDLockTypes.mortiseDownLock,
                Helpers.AllNames.MDLockTypes.mortiseUpLock,
                Helpers.AllNames.MDLockTypes.boltDownLock,
                Helpers.AllNames.MDLockTypes.boltUpLock
            };

            LockType = new Property("Материал", Locks);

            Properties = new Property[] { LockType };
        }

        #endregion
    }
}
