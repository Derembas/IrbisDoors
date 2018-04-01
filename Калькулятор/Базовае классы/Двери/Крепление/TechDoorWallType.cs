using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calculator
{
    public class TechDoorWallType : INotifyPropertyChanged
    {
        // Тип рамы крепления
        private string frameType;
        public string FrameType
        {
            get { return frameType; }
            set
            {
                if (frameType != value)
                {
                    frameType = value;
                    OnPropertyChanged("FrameType");
                    OnPropertyChanged("WallMaterials");
                    OnPropertyChanged("FasteningType");
                }
            }
        }

        public string[] FrameTypes { get; private set; }

        // Материал стены
        private string wallMaterial;
        public string WallMaterial
        {
            get { return wallMaterial; }
            set
            {
                if(wallMaterial!=value)
                {
                    wallMaterial = value;
                    OnPropertyChanged("WallMaterial");
                    OnPropertyChanged("FasteningType");
                }
            }
        }

        private string[] embarceWallMaterials; // Материалы стены для рамы в обхват
        private string[] cornerWallMaterials; // Материалы стены для угловой рамы
        private string[] p_typeWallMaterials; // Материалы стены для рамы внутрь проёма 
        public string[] WallMaterials
        {
            get
            {
                if (wallMaterial == Helpers.AllNames.Frames.cornerFrame)
                    return cornerWallMaterials;
                else if (wallMaterial == Helpers.AllNames.Frames.p_typeFrame)
                    return p_typeWallMaterials;
                else
                    return embarceWallMaterials;
            }
        }

        // Толщина стены
        private int wallThickness;
        public int WallThickness
        {
            get { return wallThickness; }
            set
            {
                if (wallThickness!=value)
                {
                    wallThickness = value;
                    OnPropertyChanged("WallThickness");
                }
            }
        }

        /// <summary>Тип крепежа</summary>
        public string FasteningType
        {
            get
            {
                if(frameType== Helpers.AllNames.Frames.embraceFrame)
                {
                    if (wallMaterial == Helpers.AllNames.WallMaterials.sandwichPanelAndMetal)
                        return Helpers.AllNames.FasteningTypes.techFastenT4;

                    else if (wallMaterial == Helpers.AllNames.WallMaterials.metallConstruct)
                        return Helpers.AllNames.FasteningTypes.techFastenT2;

                    else if (wallMaterial == Helpers.AllNames.WallMaterials.concrate ||
                        wallMaterial == Helpers.AllNames.WallMaterials.fullBrick)
                    {
                        return Helpers.AllNames.FasteningTypes.techFastenT3;
                    }

                    else
                        return Helpers.AllNames.FasteningTypes.techFastenT1;

                }
                else if(frameType == Helpers.AllNames.Frames.cornerFrame)
                {
                    if (wallMaterial == Helpers.AllNames.WallMaterials.emptyBricks)
                        return Helpers.AllNames.FasteningTypes.techFastenT5;
                    else if (wallMaterial == Helpers.AllNames.WallMaterials.metallConstruct)
                        return Helpers.AllNames.FasteningTypes.techFastenT6;
                    else
                        return Helpers.AllNames.FasteningTypes.techFastenT7;
                }
                else
                {
                    if (wallMaterial == Helpers.AllNames.WallMaterials.metallConstruct)
                        return Helpers.AllNames.FasteningTypes.techFastenT8;
                    else if (wallMaterial == Helpers.AllNames.WallMaterials.sandwichPanelAndMetal)
                        return Helpers.AllNames.FasteningTypes.techFastenT10;
                    else
                        return Helpers.AllNames.FasteningTypes.techFastenT9;
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Конструктор

        public TechDoorWallType()
        {
            FrameTypes = new string[] 
            {
                Helpers.AllNames.Frames.embraceFrame,
                Helpers.AllNames.Frames.cornerFrame,
                Helpers.AllNames.Frames.p_typeFrame
            };

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
        }

        #endregion

    }
}
