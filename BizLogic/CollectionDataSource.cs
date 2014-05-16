using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BizLogic
{

    [DataContract]
    public class CollectionDataSource
    {

        [DataMember]
        public string CollectionPlace { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }
    }
}
