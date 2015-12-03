using System;
using System.Collections.Generic;

namespace TrySensorConfig.Model
{
    public class DataService : IDataService
    {
        private readonly SensorConfigService _sensorConfigService;
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public DataService()
        {
            _sensorConfigService = new SensorConfigService();
        }


        public void GetSensorConfigList(int slotNum, Action<List<SensorConfig>, Exception> callback)
        {
            List<SensorConfig> sensorConfigList = new List<SensorConfig>();
            foreach (var sc in _sensorConfigService.SensorConfigList)
            {
                sensorConfigList.Add(sc);
            }
            callback(sensorConfigList, null);
        }
    }
}