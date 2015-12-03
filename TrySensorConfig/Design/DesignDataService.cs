using System;
using System.Collections.Generic;
using TrySensorConfig.Model;

namespace TrySensorConfig.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }


        public void GetSensorConfigList(int slotNum, Action<List<SensorConfig>, Exception> callback)
        {
            List<SensorConfig> sensorConfigList = new List<SensorConfig>();
            callback(sensorConfigList, null);
        }
    }
}