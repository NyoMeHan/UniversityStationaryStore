using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BizLogic;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IscvikramService" in both code and config file together.
    [ServiceContract]
    public interface IscvikramService
    {
        [OperationContract]
        [WebInvoke (Method="GET",ResponseFormat=WebMessageFormat.Json,
                    UriTemplate = "CollectionPoint")]   
        List<CollectionDataSource> getCurrentPoint();



        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "Representative?i={i}")]
        List<RepresentativeInformationDataStore> getData(int i); 
    }
}
