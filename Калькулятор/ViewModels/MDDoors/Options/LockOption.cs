using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors
{
    public class LockOption: BaseClasses.Option
    {

        public BaseClasses.Property LockType { get; private set; }

        #region Конструктор

        public LockOption():base("Запорное устройство")
        {
            object[] Locks = new object[] 
            {
                Helpers.AllNames.MDLockTypes.hingedLock,
                Helpers.AllNames.MDLockTypes.mortiseDownLock,
                Helpers.AllNames.MDLockTypes.mortiseUpLock,
                Helpers.AllNames.MDLockTypes.boltDownLock,
                Helpers.AllNames.MDLockTypes.boltUpLock
            };

            LockType = new BaseClasses.Property("Материал", Helpers.PropertyTypes.StringType, true) { Values = Locks };

            base.properties.Add(LockType);
        }

        #endregion
    }
}
