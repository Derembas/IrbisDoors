using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CommonClasses
{
    public class CoolDoorWallType : BaseClasses.Option
    {
        // Материал стены
        public BaseClasses.Property WallMaterial { get; private set; }

        // Толщина стены
        public BaseClasses.Property WallThickness { get; private set; }

        /// <summary>Тип крепежа</summary>
        public BaseClasses.Property FasteningType { get; private set; }

        #region Конструктор

        public CoolDoorWallType(string name, bool _isNecessary = false) : base(name, _isNecessary)
        {
            WallMaterial = new BaseClasses.Property("Материал стены", Helpers.PropertyTypes.StringType, true)
            {
                Values = new object[]
                {
                    Helpers.AllNames.WallMaterials.sandwichPanel,
                    Helpers.AllNames.WallMaterials.emptyBricks,
                    Helpers.AllNames.WallMaterials.gasBlocks,
                    Helpers.AllNames.WallMaterials.metallConstruct,
                    Helpers.AllNames.WallMaterials.concrate,
                    Helpers.AllNames.WallMaterials.fullBrick,
                    Helpers.AllNames.WallMaterials.sandwichPanelAndMetal,
                    Helpers.AllNames.WallMaterials.framePanels,
                    Helpers.AllNames.WallMaterials.emptyBrickAndInnerFrame
                }
            };
            WallThickness = new BaseClasses.Property("Толщина стены", Helpers.PropertyTypes.IntegerType);
            FasteningType = new BaseClasses.Property("Тип крепежа", Helpers.PropertyTypes.StringType) { IsEnabled = false };

            base.properties.AddRange(new BaseClasses.Property[] { WallMaterial, WallThickness, FasteningType });
        }

        #endregion
    }
}
