using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MovilRestService
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet]
        string GetDataUsingMethod(string value);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCamiones/{value}")]
        string GetCamionesCercanos(string value);


        [OperationContract]
        [WebGet(UriTemplate = "/AltaUsuario/{value}")]
        string AltaUsuario(string value);


        [OperationContract]
        [WebGet(UriTemplate = "/GetSpots/{value}")]
        string GetSpots(string value);


        [OperationContract]
        [WebGet(UriTemplate = "/SetAnswers/{value}")]
        string SetAnswers(string value);


        [OperationContract]
        [WebGet(UriTemplate = "/GetGps/{value}")]
        string GetGps(string value);


        [OperationContract]
        [WebGet(UriTemplate = "/SetGps/{value}")]
        string SetGps(string value);
    }


   
}
