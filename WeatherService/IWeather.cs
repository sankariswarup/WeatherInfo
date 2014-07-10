using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWeather
    {

        [OperationContract]
        string GetData(int value);
        [OperationContract]
        Weather GetWeather(string city);
        [WebGet]
        [OperationContract]
        string GetWeatherJson(string city);

    

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Weather
    {
        bool boolValue = true;
        string cityValue = "Auburn";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string City
        {
            get { return cityValue; }
            set { cityValue = value; }
        }
    }
}
