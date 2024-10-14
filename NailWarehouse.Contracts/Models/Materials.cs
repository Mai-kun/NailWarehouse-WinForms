using System.ComponentModel;

namespace NailWarehouse.Contracts.Models
{
    public enum Materials
    {
        [Description("Медь")]
        Copper = 1,

        [Description("Сталь")]
        Steel = 2,

        [Description("Железо")]
        Iron = 3,

        [Description("Хром")]
        Chrome = 4,
    }
}