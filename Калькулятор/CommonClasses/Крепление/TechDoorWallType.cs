using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calculator.CommonClasses
{
    public class TechDoorWallType : BaseClasses.Option
    {
        // Тип рамы крепления
        public BaseClasses.Property FrameType { get; private set; }

        // Материал стены
        public BaseClasses.Property WallMaterial { get; private set; }

        private string[] embarceWallMaterials; // Материалы стены для рамы в обхват
        private string[] cornerWallMaterials; // Материалы стены для угловой рамы
        private string[] p_typeWallMaterials; // Материалы стены для рамы внутрь проёма 

        // Толщина стены
        public BaseClasses.Property WallThickness { get; private set; }

        /// <summary>Тип крепежа</summary>
        public BaseClasses.Property FasteningType { get; private set; }

        private void PropertyUpdate()
        {
            if (FrameType.Value.ToString() == Helpers.AllNames.Frames.embraceFrame)
            {
                WallMaterial.Values = embarceWallMaterials;
                if (WallMaterial.Value.ToString() == Helpers.AllNames.WallMaterials.sandwichPanelAndMetal)
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT4;

                else if (WallMaterial.Value.ToString() == Helpers.AllNames.WallMaterials.metallConstruct)
                    FasteningType.Value =Helpers.AllNames.FasteningTypes.techFastenT2;

                else if (WallMaterial.Value.ToString() == Helpers.AllNames.WallMaterials.concrate ||
                    WallMaterial.Value.ToString() == Helpers.AllNames.WallMaterials.fullBrick)
                {
                    FasteningType.Value =Helpers.AllNames.FasteningTypes.techFastenT3;
                }

                else
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT1;

            }
            else if (FrameType.Value.ToString() == Helpers.AllNames.Frames.cornerFrame)
            {
                WallMaterial.Values = cornerWallMaterials;
                if (WallMaterial.Values.ToString() == Helpers.AllNames.WallMaterials.emptyBricks)
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT5;
                else if (WallMaterial.Values.ToString() == Helpers.AllNames.WallMaterials.metallConstruct)
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT6;
                else
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT7;
            }
            else
            {
                WallMaterial.Values = p_typeWallMaterials;
                if (WallMaterial.Values.ToString() == Helpers.AllNames.WallMaterials.metallConstruct)
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT8;
                else if (WallMaterial.Values.ToString() == Helpers.AllNames.WallMaterials.sandwichPanelAndMetal)
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT10;
                else
                    FasteningType.Value = Helpers.AllNames.FasteningTypes.techFastenT9;
            }
        }
    

        #region Конструктор

        public TechDoorWallType(string name, bool _isNecessary=false):base(name, _isNecessary)
        {
            embarceWallMaterials = new string[]
            {
                Helpers.AllNames.WallMaterials.sandwichPanel,
                Helpers.AllNames.WallMaterials.dryWall,
                Helpers.AllNames.WallMaterials.emptyBricks,
                Helpers.AllNames.WallMaterials.gasBlocks,
                Helpers.AllNames.WallMaterials.metallConstruct,
                Helpers.AllNames.WallMaterials.concrate,
                Helpers.AllNames.WallMaterials.fullBrick,
                Helpers.AllNames.WallMaterials.sandwichPanelAndMetal
            };

            cornerWallMaterials = new string[]
            {
                Helpers.AllNames.WallMaterials.emptyBricks,
                Helpers.AllNames.WallMaterials.metallConstruct,
                Helpers.AllNames.WallMaterials.concrate,
                Helpers.AllNames.WallMaterials.fullBrick
            };

            p_typeWallMaterials = new string[]
            {
                Helpers.AllNames.WallMaterials.metallConstruct,
                Helpers.AllNames.WallMaterials.concrate,
                Helpers.AllNames.WallMaterials.fullBrick,
                Helpers.AllNames.WallMaterials.sandwichPanelAndMetal
            };

            // Тип рамы
            FrameType = new BaseClasses.Property ( "Материал рамы", Helpers.PropertyTypes.StringType, true)
            {
                Values= new object[]
                {
                    Helpers.AllNames.Frames.embraceFrame,
                    Helpers.AllNames.Frames.cornerFrame,
                    Helpers.AllNames.Frames.p_typeFrame
                }
            };

            WallMaterial = new BaseClasses.Property("Материал стены", Helpers.PropertyTypes.StringType, true) { Values= embarceWallMaterials };
            WallThickness = new BaseClasses.Property("Толщина стены", Helpers.PropertyTypes.IntegerType);
            FasteningType = new BaseClasses.Property("Тип крепежа", Helpers.PropertyTypes.StringType) { IsEnabled=false};

            base.properties.AddRange( new BaseClasses.Property[] { FrameType, WallMaterial, WallThickness, FasteningType});
        }

        #endregion

    }
}
