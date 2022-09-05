using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Local_transportation_map_WPF.Enums;

namespace Local_transportation_map_WPF
{
    [AttributeUsage(AttributeTargets.Property,
    Inherited = false,
    AllowMultiple = false)]
    internal sealed class OptionalAttribute : Attribute { }
    public class ModelGPS
    {
        [Index(0)]
        public Transpordiliik Liik { get; set; }
        [Index(1)]
        public string LineNumber { get; set; }
        [Index(2)]
        public int GPS_Long { get; set; }
        [Index(3)]
        public int GPS_Lat { get; set; }
        //[Optional]
        //[Index(4)]
        //public string Empty { get; set; }
        //[Index(5)]
        //public int Unk1 { get; set; }
        //[Index(6)]
        //public int Unk2 { get; set; }
    }

}
