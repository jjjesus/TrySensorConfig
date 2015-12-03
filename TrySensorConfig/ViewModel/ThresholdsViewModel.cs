using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using TrySensorConfig.Model;

namespace TrySensorConfig.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ThresholdsViewModel : ViewModelBase
    {

        private readonly IDataService _dataService;

        private readonly ObservableCollection<SensorConfigViewModel> sensorConfigVmList_1;
        public ObservableCollection<SensorConfigViewModel> SensorConfigVmList_1
        {
            get { return this.sensorConfigVmList_1; }
        }
        

        /// <summary>
        /// Initializes a new instance of the ThresholdsViewModel class.
        /// </summary>
        public ThresholdsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            sensorConfigVmList_1 = new ObservableCollection<SensorConfigViewModel>();

            int slotNum = 1;
            _dataService.GetSensorConfigList(
                slotNum,
                (scList, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    foreach (SensorConfig sc in scList)
                    {
                        sensorConfigVmList_1.Add(
                            new SensorConfigViewModel() { SensorConfig = sc }
                            );
                    }
                });
        }
    }
}