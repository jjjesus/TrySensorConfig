using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrySensorConfig.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);

        void GetSensorConfigList(int slotNum, Action<List<SensorConfig>, Exception> callback);
    }
}
