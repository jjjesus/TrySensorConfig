using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace TrySensorConfig.Model
{
    public class SensorConfigService
    {
        private bool _isXmlValid = true;
        private XNamespace _defaultNS = "http://www.example.org/SensorConfig";
        private string _xsdPath = @"Configuration/SensorConfig.xsd";
        private string _xmlPath = @"Configuration/SensorConfig.xml";

        public List<SensorConfig> SensorConfigList { get; set; }

        public SensorConfigService()
        {
            SensorConfigList = new List<SensorConfig>();
            validateXml();
            if (_isXmlValid)
            {
                loadXml();
            }
        }

        private void validateXml()
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            try
            {
                schemaSet.Add(_defaultNS.NamespaceName, _xsdPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem loading xsd schema file");
                Console.WriteLine(e.Message);
            }
            validateXml(_xmlPath, schemaSet);
        }

        private void validateXml(string filename, XmlSchemaSet schemaSet)
        {
            Console.WriteLine();
            Console.WriteLine("\r\nValidating XML file {0}...", filename.ToString());

            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(validationCallBack);
            settings.ValidationType = ValidationType.Schema;

            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            //Create the schema validating reader.
            XmlReader vreader = XmlReader.Create(filename, settings);
            try
            {
                while (vreader.Read()) { }
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation error: ");
                Console.WriteLine(e.Message);
                _isXmlValid = false;
            }
            finally
            {
                //Close the reader.
                vreader.Close();
            }
        }

        private void validationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
            {
                Console.WriteLine("\tValidation error: " + args.Message);
                _isXmlValid = false;
            }
        }

        private void loadXml()
        {
            try
            {
                XDocument doc = XDocument.Load(_xmlPath);
                var sensorConfigs = from item in doc.Descendants(_defaultNS + "SensorConfig")
                                    select new SensorConfig()
                                    {
                                        Name = item.Element(_defaultNS + "Name").Value,
                                        SlotNum = int.Parse(item.Element(_defaultNS + "SlotNum").Value),
                                        SensorThresholdList = (from thresh in item.Elements(_defaultNS + "Threshold")
                                                               select new SensorThreshold()
                                                               {
                                                                   Level = (LevelEnum)Enum.Parse(typeof(LevelEnum), thresh.Attribute("Level").Value, true),
                                                                   Value = double.Parse(thresh.Value)
                                                               }).ToList()
                                    };
                foreach (var sc in sensorConfigs)
                {
                    this.SensorConfigList.Add(sc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem loading xml file");
                Console.WriteLine(e.Message);
            }
        }

    }
}
