using System.Linq;
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
                SensorThreshold th = (from thresh in SensorConfig.SensorThresholdList
                                      where thresh.Level == LevelEnum.Lower
                                      select thresh).FirstOrDefault();
                return th.Value;
            }

            set
            {
                SensorThreshold th = (from thresh in SensorConfig.SensorThresholdList
                                      where thresh.Level == LevelEnum.Lower
                                      select thresh).FirstOrDefault();

                if (th.Value == value)
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

        /// <summary>
        /// Sets and gets the UpperThreshold property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double UpperThreshold
        {
            get
            {
                SensorThreshold th = (from thresh in SensorConfig.SensorThresholdList
                                     where thresh.Level == LevelEnum.Upper
                                     select thresh).FirstOrDefault();
                return th.Value;
            }

            set
            {
                SensorThreshold th = (from thresh in SensorConfig.SensorThresholdList
                                      where thresh.Level == LevelEnum.Upper
                                      select thresh).FirstOrDefault();

                if (th.Value == value)
                {
                    return;
                }

                th.Value = value;
                RaisePropertyChanged(UpperThresholdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Minimum" /> property's name.
        /// </summary>
        public const string MinimumPropertyName = "Minimum";

        /// <summary>
        /// Sets and gets the Minimum property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Minimum
        {
            get
            {
                return SensorConfig.Minimum;
            }

            set
            {
                if (SensorConfig.Minimum == value)
                {
                    return;
                }

                SensorConfig.Minimum = value;
                RaisePropertyChanged(MinimumPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Maximum" /> property's name.
        /// </summary>
        public const string MaximumPropertyName = "Maximum";

        /// <summary>
        /// Sets and gets the Maximum property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Maximum
        {
            get
            {
                return SensorConfig.Maximum;
            }

            set
            {
                if (SensorConfig.Maximum == value)
                {
                    return;
                }

                SensorConfig.Maximum = value;
                RaisePropertyChanged(MaximumPropertyName);
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
