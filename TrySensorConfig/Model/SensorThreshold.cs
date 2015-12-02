using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrySensorConfig.Model
{
    public class SensorThreshold
    {
        public LevelEnum Level { get; set; }
        public double Value { get; set; }
    }
    public enum LevelEnum
    {
        Lower,
        Upper
    }
}
