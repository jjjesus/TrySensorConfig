using GalaSoft.MvvmLight;
using TrySensorConfig.Model;

namespace TrySensorConfig.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SensorConfigViewModel : ViewModelBase
    {
        public SensorConfig SensorConfig { get; set; }

        public string Name
        {
            get {
                if (SensorConfig != null)
                {
                    return this.SensorConfig.Name;
                }
                else
                {
                    return "No Name";
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the SensorConfigViewModel class.
        /// </summary>
        public SensorConfigViewModel()
        {
        }
    }
}
