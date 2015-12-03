using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrySensorConfig.Model
{
    public class SensorConfig
    {
        public int SlotNum { get; set; }
        public string Name { get; set; }
        public List<SensorThreshold> SensorThresholdList { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
