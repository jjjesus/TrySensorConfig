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

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        public const string NamePropertyName = "Name";

        /// <summary>
        /// Sets and gets the Name property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Name
        {
            get
            {
                if (SensorConfig != null)
                {
                    return this.SensorConfig.Name;
                }
                else
                {
                    return "No Name";
                }
            }

            set
            {
                if (SensorConfig.Name == value)
                {
                    return;
                }

                SensorConfig.Name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }


        /// <summary>
        /// The <see cref="LowerThreshold" /> property's name.
        /// </summary>
        public const string LowerThresholdPropertyName = "LowerThreshold";

        /// <summary>
        /// Sets and gets the LowerThreshold property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double LowerThreshold
        {
            get
            {
                return SensorConfig.SensorThresholdList[0].Value;
            }

            set
            {
                if (SensorConfig.SensorThresholdList[0].Value == value)
                {
                    return;
                }

                SensorConfig.SensorThresholdList[0].Value = value;
                RaisePropertyChanged(LowerThresholdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UpperThreshold" /> property's name.
        /// </summary>
        public const string UpperThresholdPropertyName = "UpperThreshold";

        private double _upperThreshold = 0;

        /// <summary>
        /// Sets and gets the UpperThreshold property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double UpperThreshold
        {
            get
            {
                return SensorConfig.SensorThresholdList[1].Value;
            }

            set
            {
                if (SensorConfig.SensorThresholdList[1].Value == value)
                {
                    return;
                }

                SensorConfig.SensorThresholdList[1].Value = value;
                RaisePropertyChanged(UpperThresholdPropertyName);
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
