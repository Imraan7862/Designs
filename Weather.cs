using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServer
{
    public class Weather
    {

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class CurrentWeather
        {

            private string locationField;

            private string timeField;

            private string windField;

            private string temperatureField;

            private string dewPointField;

            private string relativeHumidityField;

            private string pressureField;

            private string statusField;

            /// <remarks/>
            public string Location
            {
                get
                {
                    return this.locationField;
                }
                set
                {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            public string Time
            {
                get
                {
                    return this.timeField;
                }
                set
                {
                    this.timeField = value;
                }
            }

            /// <remarks/>
            public string Wind
            {
                get
                {
                    return this.windField;
                }
                set
                {
                    this.windField = value;
                }
            }

            /// <remarks/>
            public string Temperature
            {
                get
                {
                    return this.temperatureField;
                }
                set
                {
                    this.temperatureField = value;
                }
            }

            /// <remarks/>
            public string DewPoint
            {
                get
                {
                    return this.dewPointField;
                }
                set
                {
                    this.dewPointField = value;
                }
            }

            /// <remarks/>
            public string RelativeHumidity
            {
                get
                {
                    return this.relativeHumidityField;
                }
                set
                {
                    this.relativeHumidityField = value;
                }
            }

            /// <remarks/>
            public string Pressure
            {
                get
                {
                    return this.pressureField;
                }
                set
                {
                    this.pressureField = value;
                }
            }

            /// <remarks/>
            public string Status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }
        }


    }
}
