using System;

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
    }
}