using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BizLogic
{
    [DataContract]
    public class RepresentativeInformationDataStore
    {

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public string Quantity { get; set; }

        [DataMember]
        public string CollectionPoint { get; set; } 

    }
}
